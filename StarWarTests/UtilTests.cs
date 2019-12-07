using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsLibrary.Util;
using System;
using System.Collections.Generic;
using System.Text;

namespace StarWarTests
{
    [TestClass]
    public class UtilTests
    {

        [TestMethod]
        public void NumberFromStringShouldBeCorrect()
        {

            string str = "2 outta 3";
            
             int actual = Util.GetIntFromString(str);

            Assert.AreEqual(2, actual);
        }
        [TestMethod]
        public void NumberFromStringShouldBeWrong()
        {

            string str = "2 outta 3";

            int actual = Util.GetIntFromString(str);

            Assert.AreNotEqual(3, actual);
        }

        [TestMethod]
        public void ConvertStringConsumableTodateTime()
        {


            DateTime expected = DateTime.Now;

            expected = expected.AddDays(14);

            DateTime actual = Util.ConvertConsumableToHours("week",2);

            Assert.AreEqual( expected.Date, actual.Date);
        }

        [TestMethod]
        public void ConvertStringConsumableTodateTimeShouldBeWrong()
        {


            DateTime expected = DateTime.Now;

            expected = expected.AddDays(14);

            DateTime actual = Util.ConvertConsumableToHours("week", 3);

            Assert.AreNotEqual(expected.Date, actual.Date);
        }
    }
}
