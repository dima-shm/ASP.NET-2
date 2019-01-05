using System;

namespace TCPEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFSimplex.WCFSimplexClient client = new WCFSimplex.WCFSimplexClient("NetTcpBinding_IWCFSimplex");
            var result = client.Concat("qwerty", 13.2);
            Console.WriteLine("qwerty + 13.2 = " + result);
            Console.ReadLine();
        }
    }
}