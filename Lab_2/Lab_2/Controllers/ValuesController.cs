using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Lab_2.Controllers
{
    public class ValuesController : ApiController
    {
        public static int result = 0;

        public static Stack<int> stack = new Stack<int>();

        public string Get()
        {
            return JsonConvert.SerializeObject(new
            {
                result = result + stack.FirstOrDefault()
            });
        }

        public void Post([FromBody]string value)
        {
            result = Convert.ToInt32(value);
        }

        public void Put([FromBody]string value)
        {
            stack.Push(Convert.ToInt32(value));
        }

        public void Delete()
        {
            if (stack.Count != 0)
            {
                stack.Pop();
            }
        }
    }
}
