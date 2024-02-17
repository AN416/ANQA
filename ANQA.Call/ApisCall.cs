using Newtonsoft.Json;
using RestSharp;

namespace ANQA.ApiHelper.ApisCall
{
    public class ApisCall
    {
        public IRestResponse Get(string url, string route, object modelObject, string token)
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
        public IRestResponse Post(string url, string route, object? modelObject, string token, string? LdapToken)
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

        public IRestResponse Post(string url, string route, object? modelObject, string token)
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

        public IRestResponse Put(string url, string route, object modelObject, string token)
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

        public IRestResponse Post<TModel>(string url, string route, string token, List<TModel> model)
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

        public IRestResponse GetWithOutObject(string url, string route, string token)
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

        public IRestResponse Delete(string url, string route, string token)
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

        public IRestResponse GetWithObject(string url, string route, object modelObject, string token)
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
}
