using Newtonsoft.Json;
using StarWarsLibrary;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsService
{
    public class StarWarsService
    {

        private string BaseUrl = "https://swapi.co/api/";
       
        public async Task<PagedListResult<StarShip>> GetStarShipAsync(int? page)
        {
            dynamic response ;


            PagedListResult<StarShip> pagedResults = new PagedListResult<StarShip>
            {
                Results = new List<StarShip>()
            };
            if (page != null)
            {
                response = await ApiCallAsync("starships/?page=" + page);
            }
            else {
                response = await ApiCallAsync("starships/");
            }


            if (response !=null )
            {
               
                pagedResults.Total = response.count;

                foreach (var item in response.results)
                {

                    StarShip starship = new StarShip()
                    {
                        Consumables = item.consumables,
                        MGLT = item.MGLT,
                        Name = item.name,

                    };

                    pagedResults.Results.Add(starship);


                }
            }

            pagedResults.CalculatePages();

            return pagedResults;
        }


        private async Task<dynamic> ApiCallAsync(string query)
        {

            dynamic response;
            using HttpClient client = new HttpClient();


            PagedListResult<StarShip> pagedResults = new PagedListResult<StarShip>();

            using HttpResponseMessage res = await client.GetAsync(BaseUrl + query);
            using HttpContent content = res.Content;
            string data = await content.ReadAsStringAsync();

            if (data != null)
            {
                 response = JsonConvert.DeserializeObject(data);

                return response;
            }

            return null;

        }

    }
}
