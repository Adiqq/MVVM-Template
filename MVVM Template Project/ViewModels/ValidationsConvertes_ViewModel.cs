using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using MVVM_Template_Project.Models;

namespace MVVM_Template_Project.ViewModels
{
	public class ValidationsConvertes_ViewModel : MyBase_ViewModel
	{
		private readonly IDataService _dataService;

		#region Constructor
		/// <summary>
		/// Initializes a new instance of the Main_ViewModel class.
		/// </summary>
		public ValidationsConvertes_ViewModel(IDataService dataService)
		{
			_dataService = dataService;

			if (IsInDesignMode)
			{
				FirstVal = "first val - design";
				SecondVal = "Second val - design";
				ThirdVal = "Third val - design";
			}
			else
			{
				ThirdVal = "you can write in here ...";
				BtnExampleNumber = "12";
			}

			/*
			 * Second way of using the relay commands and ICommand. Declare simple ICommand 
			 * Property, and then initialize it in the constructor like this.
			 */
			BtnDoesNothing_Command = new RelayCommand(Execute_DoesNothing, CanExecute_DoesNothing);
		}
		#endregion

		#region Properties

		public string FirstVal { get; set; }

		public string SecondVal { get; set; }

		/// <summary>
		/// Since this one will require the converter to fire upon each change, we need
		/// the INPC, so we have a property with a backing value, and we raise the INPC
		/// on the set.
		/// </summary>
		public string ThirdVal
		{
			get { return _thirdVal; }
			set
			{
				if (value == _thirdVal) return;
				_thirdVal = value;
				RaisePropertyChanged();
			}
		}
		private string _thirdVal;

		/// <summary>
		/// Since this one will require the converter to fire upon each change, we need
		/// the INPC, so we have a property with a backing value, and we raise the INPC
		/// on the set.
		/// 
		/// Do note that invalid inputs (anything which is not an int) will not change
		/// the value since the validation will fail on the text box! 
		/// </summary>
		public string BtnExampleNumber
		{
			get { return _btnExampleNumber; }
			set
			{
				if (value == _btnExampleNumber) return;
				_btnExampleNumber = value;
				RaisePropertyChanged();

				// Setting the button enable/disable status.
				// In our example, value must be higher than 9.
				CanDoesNothingExecute = int.Parse(_btnExampleNumber)  > 9;
			}
		}
		private string _btnExampleNumber;

		/// <summary>
		/// Simple bool prop so we can bind a button enable/disable to it.
		/// Note, look at the Button style in the View to see how this is done.
		/// </summary>
		public bool CanDoesNothingExecute { get; set; }

		#endregion

		#region BtnDoesNothing Command 

		/*
		 * Second way of using the relay commands and ICommand. Declare simple ICommand 
		 * Property, and then initialize it in the constructor like this.
		 */	

		/// <summary>
		/// You'll bind to this from a button on the GUI.
		/// Note the Execute    -> this will be run when the button is clicked
		/// and the CanExecute  -> This will enable / disable the button to begin with
		/// </summary>
		public ICommand BtnDoesNothing_Command { get; private set; }

		/// <summary>
		/// We'll set the "CanDoesNothingExecute" in the "BtnExampleNumber" when it changes.
		/// </summary>
		/// <returns></returns>
		private bool CanExecute_DoesNothing()
		{
			return CanDoesNothingExecute;
		} 

		/// <summary>
		/// This happens when you click the button.
		/// </summary>
		private void Execute_DoesNothing()
		{
			// does nothing
		}
		#endregion
	}
}
