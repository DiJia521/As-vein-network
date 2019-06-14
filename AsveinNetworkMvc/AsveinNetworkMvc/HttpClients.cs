using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace AsveinNetworkMvc
{
    public class Http
    {
        public static string GetApiResult(string request, string actionName, object obj = null)
        {
            string json = "";
            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("http://localhost:44370/api/AsveinNetwork/");

            Task<HttpResponseMessage> task = null;
            switch (request)
            {
                case "get":
                    task = hc.GetAsync(actionName);
                    break;
                case "post":
                    task = hc.PostAsJsonAsync(actionName, obj);
                    break;
                case "put":
                    task = hc.PutAsJsonAsync(actionName, obj);
                    break;
                case "delete":
                    task = hc.DeleteAsync(actionName);
                    break;
            }
            task.Wait();

            var result = task.Result;
            if (result.IsSuccessStatusCode)
            {
                var getresultTask = result.Content.ReadAsStringAsync();

                getresultTask.Wait();

                json = getresultTask.Result;
            }

            return json;
        }
    }
}