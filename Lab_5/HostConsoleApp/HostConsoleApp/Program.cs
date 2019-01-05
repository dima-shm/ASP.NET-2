using System;
using System.ServiceModel;

namespace HostConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ServiceHost host = new ServiceHost(typeof(WCFSiplex.WCFSimplex)))
            {
                host.Open();
                Console.WriteLine("Host status: OK.");
                Console.ReadLine();
            }
        }
    }
}
