using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace FeedzillaArticles
{
    class ArticlesConsoleClient
    {
        static void Main()
        {
            var client = new HttpClient { BaseAddress = new Uri("http://api.feedzilla.com/v1/articles/") };
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            // Search for "Michael"
            Console.Write("Please, enter a search term: ");
            string sTerm = Console.ReadLine();

            Console.Write("Please, enter number of articles to retreive: ");
            int numArticles = int.Parse(Console.ReadLine());

            SearchArticles(client, sTerm, numArticles);

            Console.ReadKey();
        }

        private async static void SearchArticles(HttpClient client, string sTerm, int numArticles)
        {
            var response = await client.GetAsync(String.Format("search.json?q={0}&count={1}", sTerm, numArticles));

            var articlesJson = await response.Content.ReadAsStringAsync();

            var articles = JsonConvert.DeserializeObject<ArticlesList>(articlesJson);

            foreach (var article in articles.Articles)
            {
                Console.WriteLine(article.Title);
                Console.WriteLine(article.PublishDate);
                Console.WriteLine(article.Source);
                Console.WriteLine(article.Url);
                Console.WriteLine();
                Console.WriteLine(article.Summary);
            }

            Console.WriteLine("Finished. Press any key to quit.");
        }
    }
}
