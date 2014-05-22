using System;
using System.Linq;
using MVVM_Template_Project.Properties;

namespace MVVM_Template_Project.Auxiliary.Helpers
{
	/// <summary>
	/// This holds some string extension methods I find useful, and some I've used once, just
	/// to give you an idea of where to group them.
	/// Feel free to remove, edit, or expand.
	/// </summary>
	public static class StringExtensionMethods
	{
		/*
		 * Note on ContractAnnotation:
		 * 
		 * Used to help resharper figure out things. If you haven't seen them before, have a look at
		 * the two following links:
		 * 
		 * Original SO question: http://stackoverflow.com/q/23404686/1698987
		 * Related blog : http://blog.jetbrains.com/dotnet/2012/08/15/contract-annotations-in-resharper-7/
		 */
		#region strings and white spaces

		/// <summary>
		/// Make IsNullOrEmpty act like an extension, instead of the awkward string.IsNullOrEmpty(aValue)
		/// </summary>
		/// <param name="aTarget">The string you work with</param>
		/// <returns>True if null or empty, false otherwise</returns>
		[ContractAnnotation("aTarget:null => true")]
		public static bool IsNullOrEmpty(this string aTarget)
		{
			return String.IsNullOrEmpty(aTarget);
		}
	   

		/// <summary>
		/// Make IsNullOrWhiteSpace to act like an extension, instead of the awkward string.IsNullOrWhiteSpace(aValue)
		/// </summary>
		/// <param name="aTarget">The string you work with</param>
		/// <returns>True if null or empty, false otherwise</returns>
		[ContractAnnotation("aTarget:null => true")]
		public static bool IsNullOrWhiteSpace(this string aTarget)
		{
			return String.IsNullOrWhiteSpace(aTarget);
		}

		/// <summary>
		/// String extension to see if a string is NOT null or empty
		/// </summary>
		/// <param name="aTarget"></param>
		/// <returns>True if NOT null or empty, false otherwise</returns>
		[ContractAnnotation("aTarget:null => false")]
		public static bool IsNotNullOrEmpty(this string aTarget)
		{
			return !String.IsNullOrEmpty(aTarget);
		}

		/// <summary>
		/// String extension to see if a string is NOT null or white space
		/// </summary>
		/// <param name="aTarget"></param>
		/// <returns>True if NOT null or WhiteSpace, false otherwise</returns>
		[ContractAnnotation("aTarget:null => false")]
		public static bool IsNotNullOrWhiteSpace(this string aTarget)
		{
			return !String.IsNullOrWhiteSpace(aTarget);
		} 
		#endregion

		#region strings and commas

		/// <summary>
		/// True if string has no commas in it
		/// </summary>
		/// <param name="anInput"></param>
		/// <returns></returns>
		public static bool HasNoCommas(this string anInput)
		{
			if (anInput == null) throw new ArgumentNullException();
			return (anInput.IndexOf(',') < 0);
		}

		/// <summary>
		/// True if string has commas in it
		/// </summary>
		/// <param name="anInput"></param>
		/// <returns></returns>
		public static bool HasCommas(this string anInput)
		{
			if (anInput == null) throw new ArgumentNullException();
			return (anInput.IndexOf(',') >= 0);
		}

		/// <summary>
		/// Number of commas in the string
		/// </summary>
		/// <param name="anInput"></param>
		/// <returns></returns>
		public static int CountCommas(this string anInput)
		{
			if (anInput == null) throw new ArgumentNullException();
			return (anInput.Count(c => c == ','));
		}
		
		#endregion
	}
}
