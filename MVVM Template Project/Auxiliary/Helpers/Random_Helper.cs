using System;
using System.Text;
using System.Windows.Media;

namespace MVVM_Template_Project.Auxiliary.Helpers
{
	/// <summary>
	/// This class should provide you with plenty of random method to get random things.
	/// Benefit: no need to create a `Random rand = new Randow();` everywhere in your code.
	/// </summary>
	public static class Random_Helper
	{
		private static readonly Random RandomSeed = new Random();
		
		/// <summary>
		/// Generates a random string with the given length
		/// </summary>
		/// <param name="size">Size of the string</param>
		/// <param name="lowerCase">If true, generate lowercase string</param>
		/// <returns>Random string</returns>
		public static string RandomString(int size, bool lowerCase)
		{
			// StringBuilder is faster than using strings (+=)
			var randStr = new StringBuilder(size);

			// Ascii start position (65 = A / 97 = a)
			var start = (lowerCase) ? 97 : 65;

			// Add random chars
			for (var i = 0; i < size; i++)
				randStr.Append((char) (26*RandomSeed.NextDouble() + start));

			return randStr.ToString();
		}

		/// <summary>
		/// Number between min (inclusive) and max (exclusive)
		/// </summary>
		/// <param name="min">Inclusive</param>
		/// <param name="max">Exclusive</param>
		/// <returns></returns>
		public static int RandomInt(int min, int max)
		{
			return RandomSeed.Next(min, max);
		}

		/// <summary>
		/// Double between 0 (inclusive) and 1 (exclusive)
		/// </summary>
		public static double RandomDouble()
		{
			return RandomSeed.NextDouble();
		}

		/// <summary>
		/// Return a random number between min (inc) and max (exc), with 'digits'
		/// numbers after the decimal point.
		/// </summary>
		/// <param name="min">Lowest number (inclusive)</param>
		/// <param name="max">Highest number (exclusive)</param>
		/// <param name="digits">Precision after decimal point</param>
		public static double RandomNumber(int min, int max, int digits)
		{
			var range 		= max-min;
			var str_format 	= "{0:F"+digits+"}";
			// To avoid having to get an int and then add a random double ...
			var rand_dou 	= Double.Parse(string.Format(str_format, min + range * RandomSeed.NextDouble()));
			
			// If for some random reason the rounding of the double is equal to max, we just call
			// the method again and return the value.
			// This can *theoretically* get into an infinite loop if it happens every time, but
			// this scenario is highly unlikely :0
			return (rand_dou<max) ? rand_dou : RandomNumber(min,max, digits) ; 
			
			/*
			 * Another option will be: 
			 * return Math.Round(RandomSeed.Next(min, max - 1) + RandomSeed.NextDouble(), digits);
			 */
		}

		/// <summary>
		/// Random true/false.
		/// </summary>
		public static bool RandomBool()
		{
			return (RandomSeed.NextDouble() > 0.5);
		}

		/// <summary>
		/// Random phone nmuber. Starts with 1234 and has extra 6 random digts.
		/// </summary>
		public static string RandomPhone()
		{
			string mold = "1234-{0}-{1}";
			return string.Format(mold, RandomInt(0, 1000).ToString().PadLeft(3, '0'), RandomInt(0, 1000).ToString().PadLeft(3, '0'));
		}

		/// <summary>
		/// Will return a random date between 1/1/1900 and Now.
		/// </summary>
		public static DateTime RandomDate()
		{
			return RandomDate(new DateTime(1900, 1, 1), DateTime.Now);
		}

		/// <summary>
		/// Will return a random date between given dates.
		/// </summary>
		/// <param name="from">lower bound date</param>
		/// <param name="to">higher bound date</param>
		/// <returns></returns>
		public static DateTime RandomDate(DateTime from, DateTime to)
		{
			var range = new TimeSpan(to.Ticks - from.Ticks);
			return from + new TimeSpan((long) (range.Ticks*RandomSeed.NextDouble()));
		}

		/// <summary>
		/// Random color (RGB)
		/// </summary>
		public static Color RandomColor()
		{
			return Color.FromRgb((byte) RandomSeed.Next(255), (byte) RandomSeed.Next(255), (byte) RandomSeed.Next(255));
		}


		/// <summary>
		/// Random weather. Note that valid values are 0-5 (inclusive), and so the 
		/// default might happen.
		/// </summary>
		/// <returns></returns>
		public static string RandomWeather()
		{
			int rand = RandomInt(0, 6);
			string weather;
			switch (rand)
			{
				case 0:
					weather = "Gloomy day";
					break;
				case 1:
					weather = "Rainy day";
					break;
				case 2:
					weather = "Foggy day";
					break;
				case 3:
					weather = "Sunny day";
					break;
				case 4:
					weather = "Rainy with a chance of meatballs";
					break;
				default:
					weather = "I'm stuck in my cubicle coding. No weather for you! Come back, 1 YEAR!";
					break;
			}
			return weather;
		}

		#region Random names

		private static readonly string[] ListOfMaleFirstNames = 
		{
			"Verna", "Almeta",
			"Melvina", "Digna", "Dortha", "Ione", "Sonya", "Shiela", "Shonna",
			"Tania", "Susanne", "Ellie", "Felice", "Caitlyn", "Bethel", "Kamilah",
			"Camila", "Stefanie", "Daysi", "Brittaney", "Lavonda", "Janice",
			"Tiny", "Peg", "Kaila", "Janay", "Inga", "Melissa", "Delila", "Patience",
			"Delma", "Ressie", "Nenita", "Casimira", "Theda", "Ethel", "Christinia",
			"Nyla", "Letha", "Lea", "Cindy", "Nancy", "Jazmine", "Vanita", "Larhonda",
			"Tai", "Charise", "Latoria", "Shanti", "Kyla"
		};
		private static readonly int MaleFirstNamesCount = ListOfMaleFirstNames.Length;

		private static readonly string[] ListOfFemaleFirstNames = 
		{
			"Verna", "Almeta",
			"Melvina", "Digna", "Dortha", "Ione", "Sonya", "Shiela", "Shonna",
			"Tania", "Susanne", "Ellie", "Felice", "Caitlyn", "Bethel", "Kamilah",
			"Camila", "Stefanie", "Daysi", "Brittaney", "Lavonda", "Janice",
			"Tiny", "Peg", "Kaila", "Janay", "Inga", "Melissa", "Delila", "Patience",
			"Delma", "Ressie", "Nenita", "Casimira", "Theda", "Ethel", "Christinia",
			"Nyla", "Letha", "Lea", "Cindy", "Nancy", "Jazmine", "Vanita", "Larhonda",
			"Tai", "Charise", "Latoria", "Shanti", "Kyla"
		};
		private static readonly int FemaleFirstNamesCount = ListOfFemaleFirstNames.Length;

		private static readonly string[] ListOfLastNames =
		{
			"Smith", "Jones", "Williams", "Brown", "Wilson", "Taylor", "Morton", "White",
			"Martin", "Anderson", "Thompson", "Nguyen", "Thomas", "Walker", "Harris", 
			"Lee", "Ryan", "Robinson", "Kelly", "King", "González", "Rodríguez", 
			"Hernández", "Pérez", "García", "Martín", "Santana", "Díaz", "Suárez", 
			"Sánchez", "Smith", "Brown", "Lee", "Wilson", "Martin", "Patel", "Taylor",
			"Wong", "Campbell", "Williams", "Kim", "Lee", "Park", "Choi", "Jeong", 
			"Kang", "Cho", "Yoon", "Jang", "Lim"
		};
		private static readonly int LastNamesCount = ListOfLastNames.Length;

		#endregion
		/// <summary>
		/// Return a random name. Might be male/female and with a diverse last name range.
		/// </summary>
		/// <param name="aMale">If true will return male name</param>
		/// <param name="aFemale">If true will return female name</param>
		/// <returns>If both param are true or null, random name. Otherwise, male or female
		/// name depending on the param that is true</returns>
		public static string RandomName(bool? aMale=null, bool? aFemale=null)
		{
			string first;
			// Not specified, select at random
			if ((aMale == null && aFemale == null) ||
				(aMale == true && aFemale == true))
			{
				var gender = RandomBool();
				first = (gender) ? ListOfMaleFirstNames[RandomInt(0, MaleFirstNamesCount)]
								 : ListOfFemaleFirstNames[RandomInt(0, FemaleFirstNamesCount)];
			}
			else if (aMale == true)
				first = ListOfMaleFirstNames[RandomInt(0, MaleFirstNamesCount)];
			else
				first = ListOfFemaleFirstNames[RandomInt(0, FemaleFirstNamesCount)];

			string last = ListOfLastNames[RandomInt(0, LastNamesCount)];
			return string.Format("{0} {1}", first, last);
		}
		
	}
}
