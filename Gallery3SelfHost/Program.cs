using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Gallery3SelfHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create a service host
            using (ServiceHost serviceHost = new ServiceHost(typeof(Service1)))
            {
                //Open the ServiceHost to create listeners
                // and start listening for messages
                serviceHost.Open();

                // The service can now be accessed
                Console.WriteLine("The service is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();
            }
        }
    }
}
