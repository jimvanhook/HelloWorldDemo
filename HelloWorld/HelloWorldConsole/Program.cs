using HelloWorld.Data;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HelloWorldConsole
{
    class Program
    {
        private static HttpClient client = new HttpClient();

        private static void Main(string[] args)
        {
            var apiUrl = ConfigurationManager.AppSettings["HelloWorld.Api.Url"];
            client.BaseAddress = new Uri(apiUrl);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            runAsync().Wait();
        }

        private static async Task runAsync()
        {
            try
            {
                // Get the message(? ;)
                var apiMessage = await getApiMessageAsync(client.BaseAddress + "api/message");
                showApiMessage(apiMessage);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            Console.ReadLine();
        }

        private static async Task<ApiMessage> getApiMessageAsync(string path)
        {
            ApiMessage apiMessage = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                apiMessage = await response.Content.ReadAsAsync<ApiMessage>();
            }
            return apiMessage;
        }

        private static void showApiMessage(ApiMessage apiMessage)
        {
            Console.WriteLine($"Message from API: {apiMessage.Text}");
        }
    }
}
