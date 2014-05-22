using System.Runtime.CompilerServices;
using GalaSoft.MvvmLight;
using MVVM_Template_Project.Properties;

namespace MVVM_Template_Project.ViewModels
{
	/// <summary>
	/// This class contains properties that a View can data bind to.
	/// <para>
	/// See http://www.galasoft.ch/mvvm
	/// </para>
	/// </summary>
	public class MyBase_ViewModel : ViewModelBase
	{
		
		/// <summary>
		/// This gives us the ReSharper option to transform an autoproperty into a property with change notification
		/// Also leverages .net 4.5 callermembername attribute
		/// </summary>
		/// <param name="property">name of the property</param>
		[NotifyPropertyChangedInvocator]
		protected override void RaisePropertyChanged([CallerMemberName]string property = "")
		{
			base.RaisePropertyChanged(property);
		}

		/// <summary>
		/// This gives us the ReSharper option to transform an autoproperty into a property with change notification
		/// Also leverages .net 4.5 callermembername attribute
		/// </summary>
		/// <param name="property">name of the property</param>
		[NotifyPropertyChangedInvocator]
		protected override void RaisePropertyChanging([CallerMemberName]string property = "")
		{
			base.RaisePropertyChanging(property);
		}
	}
}