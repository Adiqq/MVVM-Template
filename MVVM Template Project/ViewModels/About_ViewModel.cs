namespace MVVM_Template_Project.ViewModels
{
	public class About_ViewModel : MyBase_ViewModel
	{
		public About_ViewModel()
		{
			Hello = "Hi guys, I hope you'll enjoy this MVVM tepmlate solution";
		}

		public string Hello { get; private set; }
	}
}
