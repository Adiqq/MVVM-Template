using System;
using System.Linq;

namespace MVVM_Template_Project.Auxiliary.Helpers
{
	/// <summary>
	/// The idea behind this is the assumption that your validation needs to do repetitive things in multiple
	/// validations (different classes). We move all the duplicated code to a static helper, and simply
	/// call this methods here
	/// </summary>
	public static class Validation_Helper
	{
		/// <summary>
		/// Example of a method to be called repeatedly from a validation method
		/// </summary>
		public static bool ParseInput(string input, bool simpleLogic=true)
		{
			return simpleLogic  ? ParseSimpleLogic (input) 
								: ParseComplexLogic(input);
		}

		#region Simple or Complex Logic

		/// <summary>
		/// parse a string to see if it contains only digits, white spaces, colons or commas
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool ParseComplexLogic(string input)
		{
			if (input.IsNullOrWhiteSpace())
				return false;   // to avoid null or empty string passing through

			return VerifyValidChars(input, DigitsWhiteSpaceColonOrComma_CharBoolPredicate);
		}

		/// <summary>
		/// parse a string to see if it contains only digits or white spaces
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		public static bool ParseSimpleLogic(string input)
		{
			if (input.IsNullOrWhiteSpace())
				return false;   // to avoid null or empty string passing through

			return VerifyValidChars(input, DigitsOrWhiteSpace_CharBoolPredicate);
		}
		
		#endregion

		
		#region Predicates

		/// <summary>
		/// Checks is the char given is a digit, white space, colon or comma
		/// </summary>
		/// <param name="c">Char to check</param>
		/// <returns>True if the char given is a digit, white space, colon or comma</returns>
		public static bool DigitsWhiteSpaceColonOrComma_CharBoolPredicate(char c)
		{
			return (char.IsDigit(c) || char.IsWhiteSpace(c) || c == ':' || c == ',');
		}

		/// <summary>
		/// Checks is the char given is a digit or white space.
		/// </summary>
		/// <param name="c">Char to check</param>
		/// <returns>True if the char given is a digit or a white space</returns>
		public static bool DigitsOrWhiteSpace_CharBoolPredicate(char c)
		{
			return (char.IsDigit(c) || char.IsWhiteSpace(c));
		}

		#endregion
		
		/// <summary>
		/// This will make sure all the chars in the string satisfy the predicate condition
		/// </summary>
		/// <param name="input">The string we'll work with</param>
		/// <param name="pred">The predicate to check against</param>
		/// <returns>True if all chars satisfy the predicate</returns>
		public static bool VerifyValidChars(string input, Func<char,bool> pred)
		{
			return input.All(pred);
		}

	}

	
}