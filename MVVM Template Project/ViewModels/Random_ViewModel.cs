using System;
using System.Linq;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVM_Template_Project.Auxiliary.Helpers;
using MVVM_Template_Project.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace MVVM_Template_Project.ViewModels
{
	public class Random_ViewModel : MyBase_ViewModel
	{
		private readonly IDataService _dataService;

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the Main_ViewModel class.
		/// </summary>
		public Random_ViewModel(IDataService dataService)
		{
			_dataService = dataService;
			EnumCollection = new ObservableCollection<string>(Enum.GetNames(typeof(Example_Enum)).ToList());
			PeopelCollection = _dataService.GetPeople(5);

			/*
			 * Not much point in this case, but for the record, you can have 
			 * different data depending on if you're in design or runtime like this:
			 */
			if (IsInDesignMode)
			{
				RefreshNamesOptions = new List<int> { 4, 5, 6};
			}
			else
			{
				RefreshNamesOptions = new List<int> { 15, 10, 5, 1 };
			}

			// This will register our method with the Messenger class for incoming 
			// messages of type RefreshPeople.
			Messenger.Default.Register<RefreshPeople>(this, (msg) => Execute_RefreshPeople(msg.PeopleToFetch));
		}
		#endregion
	  
		#region Properties

		/// <summary>
		/// Will hold our example enumration values as strings, for our combobox
		/// </summary>
		public ObservableCollection<string> EnumCollection { get; set; }
		
		/// <summary>
		/// Will hold a random collection of people.
		/// The "Person" resides in the "Models" namespace/folder for
		/// this demo.
		/// </summary>
		public ObservableCollection<Person> PeopelCollection

		{
			get { return _peopelCollection; }
			set
			{
				if (Equals(value, _peopelCollection)) return;
				_peopelCollection = value;
				RaisePropertyChanged();
			}
		}
		private ObservableCollection<Person> _peopelCollection;

		/// <summary>
		/// This collection is the source for the combo box: "Cmb_NamesAmount" on the XAML.
		/// It also serves it's selected index to the refresh names command, which will
		/// disable the button if the selected item is lower than 3.
		/// When we set it (basically, change the selected item in the combo box), we'll
		/// ask the command manager to reevaluate the conditions to see if the button needs
		/// to be active or disactive. 
		/// </summary>
		public IEnumerable<int> RefreshNamesOptions
		{
			get { return _refreshNamesOptions; }
			set
			{
				if (Equals(value, _refreshNamesOptions)) return;
				_refreshNamesOptions = value;
				RaisePropertyChanged();
				// Without the following line, the button will not be disabled if you'll select 
				// 1 from the combo box. It might still work (as in, you won't be able to click it
				// but the change won't happen immediately).
				CommandManager.InvalidateRequerySuggested();
			}
		}
		private IEnumerable<int> _refreshNamesOptions;

		#endregion

		#region Refresh names command 

		/*
		 * First way of using the relay commands and ICommand. 
		 * The Command is created when we first try to get it, saving us the need to
		 * initialize it in the constructor.
		 */	

		/// <summary>
		/// You'll bind to this from a button on the GUI.
		/// Note the Execute    -> this will be run when the button is clicked
		/// and the CanExecute  -> This will enable / disable the button to begin with
		/// 
		/// Also, we're passing an int through the binding in the XAML:
		/// ----> CommandParameter="{Binding ElementName=Cmb_NamesAmount, Path=SelectedItem}" 
		/// which is an item from the list of ints we defined. so the RelayCommand takes an "int",
		/// hence the syntax with the type of paramater we'll accept
		/// ----> "_refreshNames_command = new RelayCommand..." 
		/// </summary>
		public ICommand RefreshPeople_Command
		{
			get
			{
				return _refreshPeopleCommand ??
					 (_refreshPeopleCommand = new RelayCommand<int>(Execute_RefreshPeople, CanExecute_RefreshPeople));
			}
		}
		private ICommand _refreshPeopleCommand;

		/// <summary>
		/// If you select 1 in the drop down menu, the button will become disable. 
		/// Rather simple, but it's a place holder for whatever logic you might want.
		/// </summary>
		/// <param name="arg">We're passing an int from the xaml.</param>
		/// <returns></returns>
		private bool CanExecute_RefreshPeople(int arg)
		{
			return arg > 3;
		} 

		/// <summary>
		/// This happens when you click the button.
		/// </summary>
		/// <param name="arg"></param>
		private void Execute_RefreshPeople(int arg)
		{
			PeopelCollection = new ObservableCollection<Person>(_dataService.GetPeople(arg));
			var msg = arg + " people refreshed.";
			StatusSetter.SetStatus(msg);
		}
		#endregion


		#region ListBoxDoubleClick_Command
		/// <summary>
		/// Simple example of how to react to a double click on a listbox, and show the 
		/// selected item in it.
		/// </summary>
		public ICommand ListBoxDoubleClick_Command
		{
			get
			{
				return _listBoxDoubleClickCommand ??
					 (_listBoxDoubleClickCommand = new RelayCommand<object>(Execute_ListBoxDoubleClick));
			}
		}
		private ICommand _listBoxDoubleClickCommand;

		/// <summary>
		/// This happens when you double click on the listbox.
		/// </summary>
		private void Execute_ListBoxDoubleClick(object anObject)
		{
			var person  = anObject as Person;
			/*
			 * This check is redundant in this specific case, but you might
			 * want to remember to check for nulls in other cases.
			 */
			var name = (person == null) ? "Person was null!!" : person.Name; 

			var msg     = string.Format("You double clicked on {0} in the list box. {1}Congratulations.",
											name, 
											Environment.NewLine);

			System.Windows.Forms.MessageBox.Show(msg);
		}
		#endregion
	}
}
