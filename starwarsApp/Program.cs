using StarWarsLibrary;
using StarWarsLibrary.Util;
using StarWarsService;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StarWarsApp
{
    class Program
    {

        private static Int64 MGLT;
        private static readonly StarShipService _swDataService = new StarShipService();
     

        static async Task Main(string[] args)
        {
            ///Starting Header 
            ConsoleViewUtil.WriteFullLine("StarWars Starship Planet Stop Calculator", "yellow");

            GetUserInput();

            ConsoleViewUtil.WriteFullLine("Loading Ships to Bay", "green");

            await GetStarShipCalculation();

            ConsoleViewUtil.WriteFullLine("All Ships Loaded ", "green");

        }
        private static async Task GetStarShipCalculation()
        {

            PagedListResult<StarShip> pagedList = await _swDataService.GetStarShipsAsync(null);

            _swDataService.CalculateSupplyStops(ref pagedList, MGLT);

            PrintResults(pagedList.Results);

            if (pagedList.Pages > 1)
            {
                await GetPageResults(pagedList);
            }
        }
        private static async Task GetPageResults(PagedListResult<StarShip> pagedList)
        {

            /// start at 2 as we already have the first paged results
            for (var i = 2; i <= pagedList.Pages; i++)
            {

                ConsoleViewUtil.WriteFullLine(" Load more ?  (type y or yes to continue)", "green");

                var res = Console.ReadLine();

                if (res == "y" || res == "yes" || res == "Y" || res == "YES")
                {
                    //getting the next paged result
                    var temp = await _swDataService.GetStarShipsAsync(i);

                    _swDataService.CalculateSupplyStops(ref temp, MGLT);

                    PrintResults(temp.Results);
                }
                else
                {
                    /// end paging for loop
                    i = pagedList.Pages;
                }


            }
        }
        private static void PrintResults(List<StarShip> starShips)
        {

            foreach (var item in starShips)
            {
                ConsoleViewUtil.WriteFullLine("------------------------------------", "blue");

                ConsoleViewUtil.WriteFullLine("Ship name: " + item.Name, "yellow");

                ConsoleViewUtil.WriteFullLine("Stops: " + item.PlanetStops, "yellow");

                ConsoleViewUtil.WriteFullLine("Flight Speed: " + item.MGLT, "yellow");

                ConsoleViewUtil.WriteFullLine("Resupply limit: " + item.Consumables, "yellow");

                ConsoleViewUtil.WriteFullLine("Time of Travel: " + item.MGLTTime, "yellow");

            }
        }
        public static void GetUserInput()
        {


            bool success = false;

            while (success == false)
            {

                Console.Write("Enter MGLT to Travel: ");

                var temp = Console.ReadLine();

                success = Int64.TryParse(temp, out MGLT);

                if (success)
                {
                    Console.WriteLine("Calculating \n");

                }
                else
                {
                    Console.WriteLine("Attempted conversion of '{0}' failed.",
                                       temp ?? "<null>");
                }

            }


        }
    }
}
