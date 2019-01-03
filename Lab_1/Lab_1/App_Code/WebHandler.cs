using System;
using System.Web;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace Lab_1.App_Code
{
    public class WebHandler : IHttpHandler
    {
        public static int result = 0;

        public static Stack<int> stack = new Stack<int>();

        public bool IsReusable => true;

        public void ProcessRequest(HttpContext context)
        {
            switch (context.Request.HttpMethod)
            {
                case "GET":
                    {
                        context.Response.Write(JsonConvert.SerializeObject(new
                        {
                            result = result + stack.FirstOrDefault()
                        }));
                    };
                    break;
                case "POST":
                    {
                        result = Convert.ToInt32(context.Request.Params["result"]);
                    };
                    break;
                case "PUT":
                    {
                        stack.Push(Convert.ToInt32(context.Request.Params["add"]));
                    };
                    break;
                case "DELETE":
                    {
                        if (stack.Count != 0)
                        {
                            stack.Pop();
                        }
                    };
                    break;
            }
        }
    }
}