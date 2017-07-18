using HelloWorld.Data;
using System;
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
            runAsync().Wait();
        }

        private static async Task runAsync()
        {
            client.BaseAddress = new Uri("http://localhost:53526/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                // Get the product
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
