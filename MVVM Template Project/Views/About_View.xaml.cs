using System.Windows.Controls;
using System.Windows.Navigation;

namespace MVVM_Template_Project.Views
{
    /// <summary>
    /// Interaction logic for About_View.xaml
    /// </summary>
    public partial class About_View 
    {
        public About_View()
        {
            InitializeComponent();
        }

        private void NavigateToSO(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("http://stackoverflow.com/users/1698987/noctis");
        }


        private void NavigateToCP(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codeproject.com/Members/_Noctis_");
        }

        private void NavigateToOriginal(object sender, RequestNavigateEventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.codeproject.com/Articles/768427/The-big-MVVM-Template-");
        }
       
    }
}
