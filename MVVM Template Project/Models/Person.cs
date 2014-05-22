using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using MVVM_Template_Project.Auxiliary.Helpers;
using MVVM_Template_Project.Properties;

namespace MVVM_Template_Project.Models
{
    public class Person
    {
        public Person(string aName, string aPhone, DateTime aBirthDate, Color aColor, PersonSex aPresonSex)
        {
            Name = aName;
            Phone = aPhone;
            BirthDate = aBirthDate;
            SomeColor= new SolidColorBrush(aColor);
            Sex = aPresonSex;
        }

        public string Name { get; private set; }
        public string Phone { get; private set; }
        public DateTime BirthDate { get; private set; }
        public SolidColorBrush SomeColor { get; private set; }
        public PersonSex Sex { get; set; }

        /// <summary>
        /// To have some data for printing out
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.Append(Sex.Equals(PersonSex.Male) ? "[M] " : "[F] ");
            sb.Append(string.Format(" {0} - Ph: {1} - Born: {2} ",
                                     Name, Phone,BirthDate)       );

            return sb.ToString();
        }
        public static Person GetRandomPerson()
        {
            var isMale = Random_Helper.RandomBool();

           return new Person(
                (isMale) ? Random_Helper.RandomName(aMale:true) 
                         : Random_Helper.RandomName(aFemale:true) ,
                Random_Helper.RandomPhone(),
                Random_Helper.RandomDate(),
                Random_Helper.RandomColor(),
                (isMale) ? PersonSex.Male 
                         : PersonSex.Female
            );
        }
    }
    
    

    public enum PersonSex
    {
        Male,
        Female
    }
}
