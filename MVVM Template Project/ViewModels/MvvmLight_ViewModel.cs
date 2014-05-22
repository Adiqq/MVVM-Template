using MVVM_Template_Project.Models;

namespace MVVM_Template_Project.ViewModels
{
    public class MvvmLight_ViewModel : MyBase_ViewModel
    {
        private readonly IDataService _dataService;

        /// <summary>
        /// Gets the WelcomeTitle property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public string WelcomeTitle
        {
            get{return _welcomeTitle;}

            set{
                if (_welcomeTitle == value)
                    return;

                _welcomeTitle = value;
                RaisePropertyChanged();
            }
        }
        private string _welcomeTitle = string.Empty;

        /// <summary>
        /// Initializes a new instance of the Main_ViewModel class.
        /// </summary>
        public MvvmLight_ViewModel(IDataService dataService)
        {
            _dataService = dataService;
            _dataService.GetData(
                (item, error) =>
                {
                    if (error != null)
                    {
                        // Report error here
                        return;
                    }

                    WelcomeTitle = item.Title;
                });
        }
    }
}
