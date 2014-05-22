using System;
using System.Globalization;
using System.Text;
using System.Windows.Controls;
using MVVM_Template_Project.Auxiliary.Helpers;

namespace MVVM_Template_Project.Auxiliary.Validations
{
    /// <summary>
    /// Serves as a template example for a validation.
    /// This will validate a string and return true if it's longer than 3 characters.
    /// </summary>
    class Example_Validation : ValidationRule
    {
        /// <summary>
        /// Example of a simple validation, that can have different validation error contents.
        /// </summary>
        /// <param name="value">A string in this case</param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;      // Convert to our string
            var sb = new StringBuilder();   // For the error messages
            var valid = true;               // Rather obvious

            if (String.IsNullOrWhiteSpace(str))
            {
                valid = false;
                sb.AppendLine("Null or white space is not valid.");
            }
            else if (str.Length < 5)
            {
                valid = false;
                sb.AppendLine("String too short (less than 5).");
            }

            return new ValidationResult(valid, sb.ToString());
        }
    }

    /// <summary>
    /// Checking a string for digits and commas example, using the Validation_Helper.cs
    /// class in the Helpers folder
    /// </summary>
    class SecondExample_Validation : ValidationRule
    {
        /// <summary>
        /// This example uses the methods in Validation_Helper.cs
        /// </summary>
        /// <param name="value">A string in this case</param>
        /// <param name="cultureInfo"></param>
        /// <returns></returns>
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str     = value as string;      // Convert to our string
            var sb      = new StringBuilder();  // For the error messages
            var valid   = true;                 // Rather obvious

            /*
             * Have your logic here, I'm just flipping a coin:
             * True  -> simple logic
             * False -> complex logic
             */
            if (Random_Helper.RandomBool())
            {
                valid = Validation_Helper.ParseInput(str, true);
                sb.AppendLine("only digits and whitespaces allowed.");
            }
            else 
            {
                valid =  Validation_Helper.ParseInput(str, false);
                sb.AppendLine("only digits, whitespaces, colons and commas allowed.");
            }

            return new ValidationResult(valid, sb.ToString());
        }
    }

    /// <summary>
    /// This will validate a string and return true if it's a valid int.
    /// </summary>
    class IsInt_Validation : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            var str = value as string;      // Convert to our string
            var sb = new StringBuilder();   // For the error messages
            var valid = true;               // Rather obvious
            int temp_int;
            
            if (!int.TryParse(str,out temp_int))
            {
                valid = false;
                sb.AppendLine("This is not a valid integer number.");
            }

            return new ValidationResult(valid, sb.ToString());
        }
    }
}
