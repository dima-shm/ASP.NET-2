namespace WCFSiplex
{
    public class WCFSimplex : IWCFSimplex
    {
        public int Add(int x, int y)
        {
            return x + y;
        }

        public string Concat(string s, double d)
        {
            return string.Concat(s, d);
        }

        public A Sum(A a1, A a2)
        {
            A result = new A();
            result.S = a1.S + a2.S;
            result.K = a1.K + a2.K;
            result.F = a1.F + a2.F;
            return result;
        }
    }
}