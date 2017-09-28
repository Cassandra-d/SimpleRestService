using ApiGateway.Config;
using Microsoft.Owin.Hosting;
using System;

namespace ApiGateway
{
    class Program
    {
        static void Main(string[] args)
        {
            var address = "https://localhost:12345";
            using (WebApp.Start<Startup>(address))
            {
                Console.WriteLine($"Started on {address}");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }
    }
}
