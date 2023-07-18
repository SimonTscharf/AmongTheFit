using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using AmongTheFit.Classes;
using System.IO;

namespace AmongTheFit.Classes
{
    class APIData
    {

        public Exercise[] exercises { get; set; }

        public async static Task<Exercise[]> GetExercises()
        {
            List<Exercise> exercises = new List<Exercise>();
            Uri url = new Uri("https://wger.de/api/v2/exercise/?language=1&offset=0&limit=999");

            HttpClient client = new HttpClient();

            client.BaseAddress = url;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            string result = "";

            HttpResponseMessage response = null;

            await Task.Run(new Action(() =>
            {
                response = client.GetAsync(url).Result;

                if (response.IsSuccessStatusCode)
                    result = response.Content.ReadAsStringAsync().Result;

                result = result.Substring(result.IndexOf("\"results\":"));
                result = result.Insert(0, "{");
                result = result.Replace("results", "exercises");
            }));

            var data = JsonConvert.DeserializeObject<APIData>(result);

            return data.exercises;
        }
    }
}
