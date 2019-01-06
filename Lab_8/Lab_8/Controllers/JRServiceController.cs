﻿using System;
using System.Collections.Generic;
using System.Web.Http;

namespace Lab_8.Controllers
{
    public class JRServiceController : ApiController
    {
        private static MyCache cache = new MyCache();

        [HttpPost]
        public List<JsonRPCResponse> Post(JsonRPCRequest[] request)
        {
            List<JsonRPCResponse> response = new List<JsonRPCResponse>();
            foreach (JsonRPCRequest requestItem in request)
            {
                JsonRPCResponse responseItem = null;

                switch (requestItem.Method.ToLower())
                {
                    case "setm":
                        responseItem = SetM(requestItem);
                        break;
                    case "getm":
                        responseItem = GetM(requestItem);
                        break;
                    case "addm":
                        responseItem = AddM(requestItem);
                        break;
                    case "subm":
                        responseItem = SubM(requestItem);
                        break;
                    case "mulm":
                        responseItem = MulM(requestItem);
                        break;
                    case "divm":
                        responseItem = DivM(requestItem);
                        break;
                    case "errorexit":
                        cache.Clear();
                        return response;
                    default:
                        responseItem = methodNotFound(requestItem);
                        break;
                }
                response.Add(responseItem);
            }
            return response;
        }

        [NonAction]
        private JsonRPCResponse SetM(JsonRPCRequest request)
        {
            try
            {
                string k = request.Params[0] as string;
                int x = int.Parse(request.Params[1].ToString());
                cache.AddValue(k, x);
                var response = new JsonRPCResponse();
                response.Id = request.Id;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = x.ToString();
                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse GetM(JsonRPCRequest request)
        {
            try
            {
                var key = request.Params[0] as string;
                var response = new JsonRPCResponse();
                response.Id = request.Id;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = cache.GetValue(key).ToString();
                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse AddM(JsonRPCRequest request)
        {
            try
            {
                var response = new JsonRPCResponse();
                var key = request.Params[0] as string;
                int value = int.Parse(request.Params[1].ToString());
                cache.AddValue(key, cache.GetValue(key) + value);

                response.Id = request.Id;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = cache.GetValue(key).ToString();

                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse SubM(JsonRPCRequest request)
        {
            try
            {
                var response = new JsonRPCResponse();
                var key = request.Params[0] as string;
                int value = int.Parse(request.Params[1].ToString());
                cache.AddValue(key, cache.GetValue(key) - value);

                response.Id = request.Id;;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = cache.GetValue(key).ToString();

                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse MulM(JsonRPCRequest request)
        {
            try
            {
                var response = new JsonRPCResponse();
                var key = request.Params[0] as string;
                int value = int.Parse(request.Params[1].ToString());
                cache.AddValue(key, cache.GetValue(key) * value);

                response.Id = request.Id;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = cache.GetValue(key).ToString();

                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse DivM(JsonRPCRequest request)
        {
            try
            {
                var response = new JsonRPCResponse();
                var key = request.Params[0] as string;
                int value = int.Parse(request.Params[1].ToString());
                cache.AddValue(key, cache.GetValue(key) / value);

                response.Id = request.Id;
                response.JsonRpc = request.JsonRpc;
                response.Method = request.Method;
                response.Result = cache.GetValue(key).ToString();

                return response;
            }
            catch (Exception)
            {
                return invalidParams(request);
            }
        }

        [NonAction]
        private JsonRPCResponse methodNotFound(JsonRPCRequest request)
        {
            JsonRPCResponse response = new JsonRPCResponse();
            response.JsonRpc = request.JsonRpc;
            response.Id = request.Id;
            response.Method = request.Method;
            response.Result = null;
            JsonRPCError error = new JsonRPCError();
            error.Code = -32601;
            error.Message = "Method not found";
            return response;
        }

        [NonAction]
        private JsonRPCResponse invalidParams(JsonRPCRequest request)
        {
            JsonRPCResponse response = new JsonRPCResponse();
            response.JsonRpc = request.JsonRpc;
            response.Id = request.Id;
            response.Method = request.Method;
            response.Result = null;
            JsonRPCError error = new JsonRPCError();
            error.Code = -32602;
            error.Message = "Invalid params";
            return response;
        }
    }

    public class JsonRPCRequest
    {
        public string Id { get; set; }
        public string JsonRpc { get; set; }
        public string Method { get; set; }
        public Object[] Params { get; set; }
    }

    public class JsonRPCResponse
    {
        public string Id { get; set; }
        public string JsonRpc { get; set; }
        public string Method { get; set; }
        public string Result { get; set; }
    }

    public class JsonRPCError
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }

    public class MyCache
    {
        private Dictionary<String, int> cache = new Dictionary<String, int>();

        public void AddValue(string key, int value)
        {
            cache[key] = value;
        }

        public int GetValue(string key)
        {
            try
            {
                return cache[key];
            }
            catch (KeyNotFoundException)
            {
                return 0;
            }
        }

        public void Clear()
        {
            cache.Clear();
        }
    }
}