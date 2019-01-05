using System;

namespace HttpEndpoint
{
    class Program
    {
        static void Main(string[] args)
        {
            WCFSimplex.WCFSimplexClient client = new WCFSimplex.WCFSimplexClient("BasicHttpBinding_IWCFSimplex");
            var result = client.Add(2, 3);
            Console.WriteLine("2 + 3 = " + result);
            Console.ReadLine();
        }
    }
}