using Nancy.Hosting.Self;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APCIEmailService
{
    public class APCIService
    {
        private NancyHost host;

        public bool Start()
        {
            NancyHost host;
            ushort port = Convert.ToUInt16(ConfigurationManager.AppSettings.Get("httpPort"));

            var uri = new Uri("http://localhost:" + port + "/");
            var config = new HostConfiguration(); config.UrlReservations.CreateAutomatically = true;

            host = new NancyHost(config, uri);
            try
            {
                host.Start();
            }
            catch (Exception e)
            {
                Console.WriteLine("Unhandled exception \n" + e.Message);
            }

            return true;
        }

        public bool Stop()
        {
            host.Stop();
            Console.WriteLine("APCI Service Stopped. Good bye!");
            return false;
        }
    }
}
