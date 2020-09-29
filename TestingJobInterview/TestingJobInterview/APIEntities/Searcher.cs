using System.Collections.Generic;

namespace TestingJobInterview.APIEntities
{
    public class Searcher
    {
        /// <summary>
        /// Выполняет поиск по поисковой строке, возвращая определённое количество результатов
        /// </summary>
        /// <param name="searchString">Поисковая строка</param>
        /// <param name="resultCount">Количество результатов, которые нужно вернуть</param>
        /// <returns></returns>
        public static List<SearchResultItem> Search(string searchString, int resultCount)
        {
            List<string> responses = new List<string>();

            for (int i = 0; i < resultCount - 25; i += 25)
            {
                RestSearchHelper.ConfigureSearch(searchString, i, 25);
                var response = RestSearchHelper.Execute();

                if (response != null && response.StatusCode == System.Net.HttpStatusCode.OK)
                    responses.Add(response.Content);
            }
            return ResponseHelper.Deserialize(ResponseHelper.ConcatResponses(responses));
        }
    }
}
