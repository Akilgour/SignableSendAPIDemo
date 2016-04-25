using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignableSendAPIDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Start");

            Console.WriteLine("Enter your API Key from  https://app.signable.co.uk/api");
            string apiKey = Console.ReadLine();

            var bytes = Encoding.UTF8.GetBytes(apiKey + ":x");
            var base64 = Convert.ToBase64String(bytes);

            Console.WriteLine("End");
            Console.WriteLine("Press any key to end ...");
            Console.ReadLine();
        }
    }
}
