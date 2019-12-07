using Microsoft.VisualStudio.TestTools.UnitTesting;
using StarWarsLibrary;

namespace StarWarTests
{
    [TestClass]
    public class StarShipUnitTest
    {
        [TestMethod]
        public void CalculateDistance()
        {

            StarShip starShip = new StarShip
            {
                Consumables = "2 months",
                MGLT = "75",
                Name = "X Winger"
            };


           starShip.CalculateDistance(1000000);

            Assert.AreEqual(9, starShip.PlanetStops);


        }

        [TestMethod]
        public void CalculateWrongStopShouldFail()
        {

            StarShip starShip = new StarShip
            {
                Consumables = "2 months",
                MGLT = "75",
                Name = "Y Winger"
            };


            starShip.CalculateDistance(1000000);

            Assert.AreNotEqual(3, starShip.PlanetStops);


        }
    }
}
