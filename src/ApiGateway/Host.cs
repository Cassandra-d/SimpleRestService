using ApiGateway.Config;
using Common;
using Microsoft.Owin.Hosting;
using System;

namespace ApiGateway
{
    class Program
    {
        private const string SSL_CONFIG_KEY = "ssl";

        static void Main(string[] args)
        {
            var useSsl = ReadSSLConfiguration();

            var address = "://localhost:12345";

            if (useSsl)
                address = "https" + address;
            else
                address = "http" + address;

            using (WebApp.Start<Startup>(address))
            {
                Console.WriteLine($"Started on {address}");
                Console.WriteLine("Press any key to exit");
                Console.ReadLine();
            }
        }

        private static bool ReadSSLConfiguration()
        {
            bool useSsl;
            var useSslValue = ConfigurationHelper.GetValueOrDefault(SSL_CONFIG_KEY);

            if (string.IsNullOrEmpty(useSslValue))
                return false;

            if (!bool.TryParse(useSslValue, out useSsl))
                return false;

            return useSsl;
        }
    }
}
