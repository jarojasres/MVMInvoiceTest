using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MVMInvoiceTest
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static string url = "http://mvmenduserinvoicefunc-test.azurewebsites.net/api/GenerateInvoice/BidEnergy";
        static string clientKey = "NohotDzQXlPGbQg0OsgWqARaFtNgsK3N7RrAUvRCa8rhHbNzgZXXRQ==";

        public static void Main()
        {

            RunAsync().Wait();
        }

        static async Task RunAsync()
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                    new MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("x-functions-key", clientKey);

            var invoicesString = await GetInvoice();

            Console.WriteLine(invoicesString);
            Console.ReadKey();

        }

        static async Task<string> GetInvoice()
        {

            var invoices = string.Empty;

            var response = await client.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {

                invoices = await response.Content.ReadAsStringAsync();
            }
            return invoices;
        }
    }
}
