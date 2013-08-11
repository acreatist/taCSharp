using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using MusicCollection.WebAPI.Controllers;

namespace MusicStore.ConsoleClient
{
    class ConsoleClient
    {
        /* README
         * To restore packages, deleted due to large archive size, 
         * For testing and learning sake, what is done:
         * 1. A full CRUD on Albums. Ready repository, controller.
         * 2. CRUD on artists, with the solution of adding an artist to a selected category. Testable with this console client.
         * */

        static void Main(string[] args)
        {
            var client = new HttpClient { BaseAddress = new Uri("http://localhost:56720/api/") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            Console.WriteLine("List artists");
            Console.WriteLine("Press a key ...");
            Console.ReadLine();
            ListAllArtists(client);
            
            Console.ReadLine();
            Console.WriteLine("-----------");

            Console.WriteLine("Add an artist...");
            var newArtist = new ArtistModel() { Name = "New Artist", Country = "New Country", BirthDate = new DateTime(1987, 5, 5) }; 
            AddArtist(client, newArtist);
            Console.ReadLine();
            Console.WriteLine("-----------");
            ListAllArtists(client);
            Console.ReadLine();

            //Console.WriteLine("-----------");
            //Console.WriteLine("Delete Marcheto...");
            //DeleteArtist(client);
            //ListAllArtists(client);
        }

        private static void DeleteArtist(HttpClient client)
        {
            HttpResponseMessage delResponse = client.DeleteAsync("Artists/3").Result;

            if (delResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Marcehto deleted!");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)delResponse.StatusCode, delResponse.ReasonPhrase);
            }
        }
  
        private async static void AddArtist(HttpClient client, ArtistModel newArtist)
        {
            HttpContent postArtist = new StringContent(JsonConvert.SerializeObject(newArtist));
            postArtist.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

            HttpResponseMessage addResponse = await client.PostAsync("Artists/?albumId=1", postArtist);

            if (addResponse.IsSuccessStatusCode)
            {
                Console.WriteLine("Artist added");
            }
            else
            {
                Console.WriteLine("{0} ({1})", (int)addResponse.StatusCode, addResponse.ReasonPhrase);
            }
        }
  
        private static void ListAllArtists(HttpClient client)
        {
            Console.WriteLine("working...");
            
            var response = client.GetAsync("Artists").Result;
            if (response.IsSuccessStatusCode)
            {
                var artists = response.Content.ReadAsAsync<IEnumerable<ArtistModel>>().Result;

                foreach (var artist in artists)
                {
                    Console.WriteLine("{0}, {1}, {2}", artist.Name, artist.BirthDate, artist.Country);
                }
            }

            Console.WriteLine("Ready");
        }
    }
}
