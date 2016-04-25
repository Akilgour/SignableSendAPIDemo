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

            Console.WriteLine("Enter first name of the person who is getting this email");
            string firstName = Console.ReadLine();
            Console.WriteLine("Enter surname of the person who is getting this email");
            string surName = Console.ReadLine();
            Console.WriteLine("Enter email of the person who is getting this email");
            string email = Console.ReadLine();

            var envelopesParties = new EnvelopeParties();
            envelopesParties.party_name = firstName + " " + surName;
            envelopesParties.party_email = email;
            envelopesParties.party_id = "1450215"; //template_parties, party_id
            envelopesParties.party_message = "Please sign this!";

            Console.WriteLine("Enter item for the report");
            string reportItem = Console.ReadLine();
            Console.WriteLine("Enter total for the report");
            string reportTotal = Console.ReadLine();

            var documentMergeFields = new List<MergeFields>();
            documentMergeFields.Add(new MergeFields() { field_id = "3560892", field_value = reportItem });
            documentMergeFields.Add(new MergeFields() { field_id = "3560893", field_value = reportTotal });



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

    internal class EnvelopeParties
    {
        public string party_email { get; set; }
        public string party_id { get; set; }
        public string party_message { get; set; }
        public string party_name { get; set; }
    }

    internal class MergeFields
    {
        public string field_id { get; set; }
        public string field_value { get; set; }
    }
}
