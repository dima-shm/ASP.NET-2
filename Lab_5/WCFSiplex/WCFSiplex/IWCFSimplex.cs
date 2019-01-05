using System.Runtime.Serialization;
using System.ServiceModel;

namespace WCFSiplex
{
    [ServiceContract]
    public interface IWCFSimplex
    {
        [OperationContract]
        int Add(int x, int y);

        [OperationContract]
        string Concat(string s, double d);

        [OperationContract]
        A Sum(A a1, A a2);
    }

    [DataContract]
    public class A
    {
        [DataMember]
        public string S { get; set; }

        [DataMember]
        public int K { get; set; }

        [DataMember]
        public float F { get; set; }
    }
}