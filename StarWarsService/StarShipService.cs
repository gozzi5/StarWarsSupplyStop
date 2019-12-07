using StarWarsLibrary;
using StarWarsLibrary.Util;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsService
{
    public class StarShipService
    {
       
        private static readonly StarWarsService _swDataService = new StarWarsService();
        public  async Task<PagedListResult<StarShip>> GetStarShipsAsync(int? page)
        {

            var pagesResults = await _swDataService.GetStarShipAsync(page);

            var starShips = pagesResults;

         
            return starShips;

        }
        public void CalculateSupplyStops(ref PagedListResult<StarShip> pagedList,Int64 MGLT)
        {

            foreach (var item in pagedList.Results)
            {

                item.CalculateDistance(MGLT);

            }

        }
      
    }
}
