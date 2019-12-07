using System;
using System.Text.RegularExpressions;

namespace StarWarsLibrary
{
    public class StarShip
    {
        
        public StarShip() {


        }

        public string Name { get; set; }
        public string MGLT { get; set; }
        public string Consumables { get; set; }

        public Int64 PlanetStops { get; set; }

        public string MGLTTime { get; set; }

       
        public void CalculateDistance(Int64 userInput) {

            //retrives the number from string 
            int numberFromConsumable = Util.Util.GetIntFromString(this.Consumables);

            ///mulitplys the number value by the string value e.g (week * 7) = 7 weeks, and  return the value in date time.
            DateTime dateTime =  Util.Util.ConvertConsumableToHours(this.Consumables, numberFromConsumable);

            DateTime t = DateTime.Now;

            decimal result = 0;

            //// Gets the time it takes to travel to distination per ship
            var timeToSupplyInHours = (dateTime -  t).TotalHours;

            Decimal.TryParse(this.MGLT,out decimal MGLTDec);



            decimal userInputToDec = Convert.ToDecimal(userInput);

            if (userInput != 0 && MGLTDec != 0)
            {
                // divides the users input distance by the starships MGLT speed
                 result = userInputToDec / MGLTDec;
            }

            //puts  the result of MGLT into mins
            var min = (result * 60);
           
            ///displays the time it takes for this starship to reach its distination
            this.MGLTTime = Util.Util.TimeFromMins(min);

            //divides the time it takes to get there by the time need for supply.
            //IN Hours
            var r = Convert.ToDouble(result) / timeToSupplyInHours;


            /// Sets the the amount of planet stops
            this.PlanetStops = Convert.ToInt64(r);
        }
     
    }
}
