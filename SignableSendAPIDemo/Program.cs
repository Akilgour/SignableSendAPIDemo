using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SignableSendAPIDemo
{
    class Program
    {
        static string getTemplates = "https://api.signable.co.uk/v1/templates?offset=0&limit=3";

        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            Console.WriteLine("Enter your API Key from  https://app.signable.co.uk/api");
            string apiKey = Console.ReadLine();

            var webClient = CreateWebClient(apiKey);

            GetDetail(webClient, getTemplates);

            Console.WriteLine("End");
            Console.WriteLine("Press any key to end ...");
            Console.ReadLine();
        }

        private static WebClient CreateWebClient(string apiKey)
        {
            WebClient webClient = new WebClient();
            webClient.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            var credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes(apiKey + ":x"));
            var authorization = string.Format("Basic {0}", credentials);
            webClient.Headers[HttpRequestHeader.Authorization] = authorization;
            return webClient;
        }

        private static void GetDetail(WebClient webClient, string apiCommand)
        {
            var results = webClient.DownloadString(apiCommand);
            Console.WriteLine(results);
            Console.WriteLine("Press any key to continue ...");
            Console.ReadLine();
        }
    }
}
