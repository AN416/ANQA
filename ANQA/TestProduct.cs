using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;

namespace ANQA
{
    public class TestProduct
    {
        private readonly RequestDelegate _next;

        public TestProduct(RequestDelegate next)
        {
            _next = next;
        }

        private class JsonScanner
        {
            public string Controller { get; set; }
            public string Action { get; set; }
            public string Model { get; set; }


        }

        public async Task Invoke(HttpContext context, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider, IModelMetadataProvider modelMetadataProvider , string Key)
        {
            List<JsonScanner> Json = new  List<JsonScanner>();
            JsonScanner Scanner = new JsonScanner();

            var actionDescriptors = actionDescriptorCollectionProvider.ActionDescriptors.Items;
            
            foreach (var actionDescriptor in actionDescriptors)
            {
                if (actionDescriptor is ControllerActionDescriptor controllerActionDescriptor)
                {
                    var controllerName = controllerActionDescriptor.ControllerName;
                    var actionName = controllerActionDescriptor.ActionName;
                    
                    Scanner.Controller = controllerName;
                    Scanner.Action = actionName;

                    var modelType = GetModelType(controllerActionDescriptor, modelMetadataProvider);

                    if (modelType != null)
                    {
                        Type dynamicType = modelType;
                        object dynamicInstance = Activator.CreateInstance(dynamicType);

                        Scanner.Model = JsonConvert.SerializeObject(dynamicInstance);

                    }

                }
               
                Json.Add(Scanner);

            }

            Post("https://localhost:44383", "/Scanner/GetJson", Json, null);


            await _next(context);
        }
        private Type GetModelType(ControllerActionDescriptor controllerActionDescriptor, IModelMetadataProvider modelMetadataProvider)
        {
            var parameters = controllerActionDescriptor.MethodInfo.GetParameters();

            foreach (var parameter in parameters)
            {
                var modelMetadata = modelMetadataProvider.GetMetadataForType(parameter.ParameterType);
                if (modelMetadata?.ModelType != null)
                {
                    return modelMetadata.ModelType;
                }
            }

            return null;
        }




        private IRestResponse Get(string url, string route, object modelObject, string token)
        {

            var client = new RestClient(url + route);
            client.Timeout = -1;

            var request = new RestRequest(Method.GET);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }

            request.AddHeader("Content-Type", "application/json");

            if (modelObject != null)
            {
                var json = JsonConvert.SerializeObject(modelObject);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }
        private IRestResponse Post(string url, string route, object? modelObject, string token, string? LdapToken)
        {

            var client = new RestClient(url + route);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }

            if (!string.IsNullOrEmpty(LdapToken))
            {
                request.AddHeader("App-API-Key", LdapToken);
            }

            request.AddHeader("Content-Type", "application/json");

            if (modelObject != null)
            {
                var json = JsonConvert.SerializeObject(modelObject);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        private IRestResponse Post(string url, string route, object? modelObject, string token)
        {

            var client = new RestClient(url + route);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }


            request.AddHeader("Content-Type", "application/json");

            if (modelObject != null)
            {
                var json = JsonConvert.SerializeObject(modelObject);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        private IRestResponse Put(string url, string route, object modelObject, string token)
        {

            var client = new RestClient(url + route);
            client.Timeout = -1;

            var request = new RestRequest(Method.PUT);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);
            }

            request.AddHeader("Content-Type", "application/json");

            if (modelObject != null)
            {
                var json = JsonConvert.SerializeObject(modelObject);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);

            return response;
        }

        private IRestResponse Post<TModel>(string url, string route, string token, List<TModel> model)
        {
            var client = new RestClient(url + route);
            client.Timeout = -1;

            var request = new RestRequest(Method.POST);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            if (model != null)
            {
                var json = JsonConvert.SerializeObject(model);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }

            IRestResponse response = client.Execute(request);
            return response;
        }

        private IRestResponse GetWithOutObject(string url, string route, string token)
        {

            var client = new RestClient(url + route)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.GET);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);

            }

            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.AddParameter("application/json charset=utf-8", ParameterType.RequestBody);


            IRestResponse response = client.Execute(request);

            return response;
        }

        private IRestResponse Delete(string url, string route, string token)
        {

            var client = new RestClient(url + route)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.DELETE);

            if (!string.IsNullOrEmpty(token))
            {
                request.AddHeader("Authorization", "Bearer " + token);

            }

            request.AddHeader("Content-Type", "application/json; charset=utf-8");

            request.AddParameter("application/json charset=utf-8", ParameterType.RequestBody);


            IRestResponse response = client.Execute(request);

            return response;
        }

        private IRestResponse GetWithObject(string url, string route, object modelObject, string token)
        {

            var client = new RestClient(url + route)
            {
                Timeout = -1
            };

            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "Bearer " + token);
            request.AddHeader("Content-Type", "application/json");

            if (modelObject != null)
            {
                var json = JsonConvert.SerializeObject(modelObject);
                request.AddParameter("application/json", json, ParameterType.RequestBody);
            }


            IRestResponse response = client.Execute(request);

            return response;
        }

    }


    public static class InspectionMiddlewareExtensions
    {
        public static IApplicationBuilder UseControllerInspectionMiddleware(this IApplicationBuilder builder , string Key)
        {
            return builder.UseMiddleware<TestProduct>(Key);
        }
    }
}
