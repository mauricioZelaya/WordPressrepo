using RestSharp;
using RestSharp.Authenticators;

namespace WordPress.RestClient
{
    public sealed class RestClientManager
    {
        private RestClientManager()
        {

        }

        public string Create<T>(string type, T objectToCreate)
        {
            //Authenticate
            var client = Authenticate();

            //Request
            var request = new RestRequest(type, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(objectToCreate);

            //Response
            var response = client.Execute(request);
            return response.StatusCode.ToString();
        }

        private RestSharp.RestClient Authenticate()
        {
            var client = new RestSharp
                .RestClient("http://wpautomation.azurewebsites.net/wp-json/wp/v2/");
            client.Authenticator = new HttpBasicAuthenticator("Gonzalo", "Control123!");
            return client;
        }

        private static RestClientManager _instance;
        public static RestClientManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new RestClientManager();
                }

                return _instance;
            }
        }
    }
}
