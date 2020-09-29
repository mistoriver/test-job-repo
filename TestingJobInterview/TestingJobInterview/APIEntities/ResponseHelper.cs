using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingJobInterview.APIEntities
{
    public static class ResponseHelper
    {
        public static List<SearchResultItem> Deserialize(string responseContent)
        {
            var results = new List<SearchResultItem>();
            dynamic deser = JsonConvert.DeserializeObject(responseContent);
            foreach (dynamic resultItem in deser.results)
            {
                string contents = "";
                foreach (dynamic descr in resultItem.descriptions)
                {
                    contents += descr.content + Environment.NewLine;
                }
                string title = resultItem.title;
                results.Add(new SearchResultItem(title, contents));
            }
            return results;
        }

        /// <summary>
        /// Сливает контенты двух респонсов так, будто это был один респонс
        /// </summary>
        /// <param name="firstResponse">Контент первого респонса</param>
        /// <param name="secResponse">Контент второго респонса</param>
        /// <returns></returns>
        public static string ConcatResponses(string firstResponse, string secResponse)
        {
            firstResponse = firstResponse.Substring(0, firstResponse.LastIndexOf(']'));
            secResponse = secResponse.Substring(secResponse.IndexOf('[') + 1);
            var res = firstResponse + "," + Environment.NewLine + secResponse;
            return res;
        }

        /// <summary>
        /// Сливает контенты списка респонсов так, будто это был один респонс
        /// </summary>
        /// <param name="responses"></param>
        /// <returns></returns>
        public static string ConcatResponses(List<string> responses)
        {
            return responses.Aggregate((string res1, string res2) => ConcatResponses(res1, res2));
        }

        /// <summary>
        /// Сливает контенты любого количества респонсов так, будто это был один респонс
        /// </summary>
        /// <param name="responses">Контент респонсов</param>
        /// <returns></returns>
        public static string ConcatResponses(params string[] responses)
        {
            return ConcatResponses(responses.ToList());
        }
    }
}
