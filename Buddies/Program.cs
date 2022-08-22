using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Buddies
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                using ( var httpClient = new HttpClient()) {

                    var url ="https://swapi.dev/api/people";

                    var httpMessageResponse = await httpClient.GetAsync(url);
                    var JsoResults = await httpMessageResponse.Content.ReadAsStringAsync();
                    //Console.WriteLine(JsoResults);
                    var myDeserializedClass = JsonConvert.DeserializeObject<List<Result>>(JsoResults);

                    

                    foreach (var item in myDeserializedClass)
                    {

                        Console.WriteLine( "Name : " + item.Name + "\nFilms: " + item.Films );

                    }

                    
                
                }
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
            }

            Console.ReadLine();
        }

        public static List<Result> FindBuddies(List<Result> buddies)
        {
            var all = new List<Result>();
            var addBuddies = new List<Result>();

            foreach (var item in buddies)
            {
                var count = all.Where(a => a.Films == item.Films).ToList();
                if (count == null)
                {
                    addBuddies.Add(item);

                }             

            }

            return addBuddies;
        }

    }


   
    public class Result
    {
        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("height")]
        public string Height { get; set; }

        [JsonProperty("mass")]
        public string Mass { get; set; }

        [JsonProperty("hair_color")]
        public string HairColor { get; set; }

        [JsonProperty("skin_color")]
        public string SkinColor { get; set; }

        [JsonProperty("eye_color")]
        public string EyeColor { get; set; }

        [JsonProperty("birth_year")]
        public string BirthYear { get; set; }

        [JsonProperty("gender")]
        public string Gender { get; set; }

        [JsonProperty("homeworld")]
        public string Homeworld { get; set; }

        [JsonProperty("films")]
        public List<string> Films { get; set; }

        [JsonProperty("species")]
        public List<string> Species { get; set; }

        [JsonProperty("vehicles")]
        public List<string> Vehicles { get; set; }

        [JsonProperty("starships")]
        public List<string> Starships { get; set; }

        [JsonProperty("created")]
        public DateTime Created { get; set; }

        [JsonProperty("edited")]
        public DateTime Edited { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }
    }

    public class Root
    {
        [JsonProperty("count")]
        public int Count { get; set; }

        [JsonProperty("next")]
        public string Next { get; set; }

        [JsonProperty("previous")]
        public object Previous { get; set; }

        [JsonProperty("results")]
        public List<Result> Results { get; set; }
    }


}
