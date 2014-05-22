using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MVVM_Template_Project.Auxiliary.Helpers;

namespace MVVM_Template_UnitTest
{
    /// <summary>
    /// This is just a stub for Unit Tests.
    /// Please don't take any of these test too seriously, and don't
    /// quit your day job because you think they actually do anything
    /// usefel ATM.
    /// </summary>
    [TestClass]
    public class RandomHelper_Tests
    {
        /// <summary>
        /// Fetch 10 numbers, see they are in range, and print them out.
        /// </summary>
        [TestMethod]
        public void Test_RandomInt()
        {
            for (int i = 0; i < 10; i++)
            {
                var rand_int = Random_Helper.RandomInt(0, 10);
                Console.Out.WriteLine("Run {0}\t int val = {1}", i + 1, rand_int);

                Assert.AreEqual(true, rand_int < 10);
                Assert.AreEqual(true, rand_int >= 0);
            }
        }

        /// <summary>
        /// Fetch 10 phone numbers, see they are start with 1234, and print them out.
        /// </summary>
        [TestMethod]
        public void Test_RandomPhone()
        {
            for (int i = 0; i < 10; i++)
            {
                var rand_phone = Random_Helper.RandomPhone();
                Console.Out.WriteLine("Run {0}\t Phone = {1}", i + 1, rand_phone);

                Assert.AreEqual(true, rand_phone.StartsWith("1234-"));
            }
        }

        /// <summary>
        /// Fetch 10 random dates, see they are within valid ranges, and print them out.
        /// </summary>
        [TestMethod]
        public void Test_RandomDateBetween()
        {
            var start_date = new DateTime(1950, 1, 1);
            var end_date = new DateTime(1999, 12, 31);

            for (int i = 0; i < 10; i++)
            {
                var rand_date = Random_Helper.RandomDate(start_date,end_date);
                Console.Out.WriteLine("Run {0}\t date = {1}", i + 1, rand_date);

                Assert.AreEqual(true, rand_date > start_date);
                Assert.AreEqual(true, rand_date < end_date);
            }
        }

        /// <summary>
        /// Fetch 10 random names, see that they have 2 parts, and print them out.
        /// </summary>
        [TestMethod]
        public void Test_RandomName()
        {
            for (int i = 0; i < 10; i++)
            {
                var rand_name = Random_Helper.RandomName();
                Console.Out.WriteLine("Run {0}\tname: {1}", i + 1, rand_name);

                Assert.AreEqual(true, rand_name.Split(' ').Count() ==2);
            }
        }
    }
}
