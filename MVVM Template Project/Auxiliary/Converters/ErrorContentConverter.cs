using System;
using System.Windows.Data;
using System.Globalization;
using System.Windows.Controls;
using System.Collections.ObjectModel;

namespace MVVM_Template_Project.Auxiliary.Converters
{
	/// <summary>
	/// An example for an error converter.
	/// Should return a list of errors. 
	/// It should solve the issue with warning thrown to the debug output when
	/// a validation goes from error to no-error.
	/// Not working for some reason.
	/// 
	/// Here's where I got it from: 
	/// http://zhebrun.blogspot.com.au/2008/03/wpf-bug-with-validationerror.html
	/// 
	/// or: http://stackoverflow.com/q/2260616/1698987
	/// 
	/// </summary>
	public class ErrorContentConverter : IValueConverter
	{
		public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
		{
			var errors = value as ReadOnlyObservableCollection<ValidationError>;
			if (errors == null  ) return "";  

			return errors.Count > 0 ? errors[0].ErrorContent 
									: "";
		}

		/// <summary>
		/// It it makes sense to convert back, IMPLEMENT the following method as well !!!!
		/// </summary>
		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
		{
			throw new NotImplementedException();
		}
	}
}
