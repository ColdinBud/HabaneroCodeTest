using HabaneroCodeTest.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Web;
using System.Web.Http;

namespace HabaneroCodeTest.Controllers
{
    public class ProcessController : ApiController
    {
        [HttpPost]
        public static GamesData GetGames(BaseApiData baseApi)
        {
            try
            {
                GamesData games = new GamesData();
                string uri = "https://ws-test.insvr.com/jsonapi/getgames";

                string param = JsonConvert.SerializeObject(baseApi, Formatting.Indented);

                string response = SendRequest(uri, param);

                GamesData gameList = JsonConvert.DeserializeObject<GamesData>(response);

                return gameList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        private static string SendRequest(string url, string json)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StringContent content = new StringContent(json, Encoding.UTF8, "application/json");
                var response = client.PostAsync(client.BaseAddress, content).Result;
                string responseBody = response.Content.ReadAsStringAsync().Result;

                return responseBody;
            }
            catch (Exception ex)
            {
                return "";
            }
        }
    }
}