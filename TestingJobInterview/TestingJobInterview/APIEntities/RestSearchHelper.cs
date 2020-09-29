using RestSharp;

namespace TestingJobInterview.APIEntities
{
    /// <summary>
    /// Класс для осуществления поиска на сайте docs.microsoft.com
    /// </summary>
    public static class RestSearchHelper
    {
        static RestClient rClient = null;
        static IRestRequest req = null;
        static void Configure(string baseUrl, IRestRequest request)
        {
            rClient = new RestClient(baseUrl);
            req = request;
        }

        /// <summary>
        /// Настраивает класс для выдачи нужного количества результатов с нужной строкой поиска
        /// </summary>
        /// <param name="searchString">Строка поиска</param>
        /// <param name="resultCount">Количество результатов, которые нужно вернуть</param>
        public static void ConfigureDefaultSearch(string searchString, int resultCount = 25)
        {
            if (resultCount <= 25)
                Configure("https://docs.microsoft.com/api",
                    new RestRequest($"search?search={searchString}&locale=ru-ru&%24top={resultCount}", Method.GET));
            else throw new System.Exception("Этот метод не поддерживает более 25 результатов");
        }

        /// <summary>
        /// Настраивает класс для выдачи нужного количества результатовв
        /// </summary>
        /// <param name="searchString">Строка поиска</param>
        /// <param name="skipCount">Сколько результатов пропустить перед выдачей</param>
        /// <param name="resultCount">Количество результатов, которые нужно вернуть</param>
        public static void ConfigureSearch(string searchString, int skipCount = 0, int resultCount = 25)
        {
            Configure("https://docs.microsoft.com/api",
                new RestRequest($"search?search={searchString}&locale=ru-ru&%24skip={skipCount}&%24top={resultCount}", Method.GET));
        }

        /// <summary>
        /// Выполняет запрос, если класс настроен
        /// </summary>
        /// <returns></returns>
        public static IRestResponse Execute()
        {
            if (rClient != null && req != null)
                return rClient.Execute(req);
            return null;
        }
    }
}
