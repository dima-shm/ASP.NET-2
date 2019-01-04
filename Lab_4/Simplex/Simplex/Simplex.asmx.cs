using Newtonsoft.Json;
using Simplex.Models;
using System.Web.Script.Services;
using System.Web.Services;

namespace Simplex
{
    [ScriptService]
    [WebService(Namespace = "http://sda/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    public class Simplex : WebService
    {
        [WebMethod(Description = "Возвращает значение суммы двух параметров", MessageName = "Add")]
        public int Add(int x, int y)
        {
            return (x + y);
        }

        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        [WebMethod(Description = "Возвращает значение суммы двух параметров(JSON)", MessageName = "AddJS")]
        public string AddJS(int x, int y)
        {
            return JsonConvert.SerializeObject(x + y);
        }

        [WebMethod(Description = "Возвращает конкатенацию первого и второго параметров", MessageName = "Concat")]
        public string Concat(string s, double d)
        {
            return string.Concat(s, d);
        }

        [WebMethod(Description = "Возвращает объект A", MessageName = "Sum")]
        public A Sum(A a1, A a2)
        {
            A model = new A();
            model.s = string.Concat(a1.s, a2.s);
            model.k = a1.k + a2.k;
            model.f = a1.f + a2.f;
            return model;
        }
    }
}