using RestSharp;

namespace TestingJobInterview.APIEntities
{
    public static class RestHelper
    {
        static RestClient rClient = null;
        static IRestRequest req = null;
        public static void Configure(string baseUrl, IRestRequest request)
        {
            rClient = new RestClient(baseUrl);
            req =  request;
        }


        public static void ConfigureDefaultSearch(string searchString, int resultCount = 25)
        {
            Configure("https://docs.microsoft.com/api",
                new RestRequest($"search?search={searchString}&locale=ru-ru&%24top={resultCount}", Method.GET));
        }

        public static IRestResponse Execute()
        { 
            if (rClient != null && req != null) 
                return rClient.Execute(req);
            return null;
        }
    }
}
