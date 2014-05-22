using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using Microsoft.Practices.ServiceLocation;
using MVVM_Template_Project.Auxiliary.Helpers;

namespace MVVM_Template_Project.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class Main_ViewModel : MyBase_ViewModel
    {
        public Main_ViewModel()
        {
            // This will register our method with the Messenger class for incoming 
            // messages of type StatusMessage. So now we can send a StatusMessage from
            // any place in our application, it'l end up here, we'll update the string
            // we use to bind to our MainWindow status bar string, and wualla, magic
            // just happened.
            Messenger.Default.Register<StatusMessage>(this, msg => StatusBarMessage=msg.NewStatus);

            // This is how you can have some design time data
            if (IsInDesignMode)
            {
                StatusBarMessage = "Status in design";
            }
            else
            {
                StatusBarMessage = "Ready to rock and roll.";
            }
        }

        #region View Model Properties

        public Random_ViewModel Random_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<Random_ViewModel>();
            }
        }

        public MvvmLight_ViewModel MvvmLight_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<MvvmLight_ViewModel>();
            }
        }

        public About_ViewModel About_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<About_ViewModel>();
            }
        }

        public ValidationsConvertes_ViewModel ValAndCon_VM
        {
            get
            {
                return ServiceLocator.Current.GetInstance<ValidationsConvertes_ViewModel>();
            }
        } 
        #endregion

        #region Properties
        /// <summary>
        /// Used to bind any incoming status messages, to the MainWindow status bar.
        /// </summary>
        public string StatusBarMessage
        {
            get { return _statusBarMessage; }
            set
            {
                if (value == _statusBarMessage) return;
                _statusBarMessage = value;
                RaisePropertyChanged();
            }
        }
        private string _statusBarMessage; 
        #endregion

        #region Refresh people command.

        /// <summary>
        /// This is in order to bind the command that we have in the MainWindow.
        /// The Command is always enabled (so the can execute just returns true),
        /// And it will send a message (that will be received by the Random View Model.
        /// </summary>
        public ICommand RefreshPeopleMenu_Command
        {
            get
            {
                return _refreshPeopleMenuCommand ??
                     (_refreshPeopleMenuCommand = new RelayCommand<string>(Execute_RefreshPeopleMenu, CanExecute_RefreshPeopleMenu));
            }
        }
        private ICommand _refreshPeopleMenuCommand;

        /// <summary>
        /// Can always exectue this
        /// </summary>
        private bool CanExecute_RefreshPeopleMenu(string aNumberAsString)
        {
            return true;
        }

        /// <summary>
        /// This will send the message when someone hits the command on the menu.
        /// </summary>
        /// <param name="aNumberAsString">In our case, hard codedd in the MenuItem paramater.
        /// You can easily bind it to anything you want.</param>
        private void Execute_RefreshPeopleMenu(string aNumberAsString)
        {
            var people_to_fetch = int.Parse(aNumberAsString);
            Messenger.Default.Send(new RefreshPeople(people_to_fetch));
        }
        
        #endregion

        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}