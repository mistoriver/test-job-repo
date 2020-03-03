using NUnit.Framework;
using RestSharp;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntRestTests
    {
        //"https://docs.microsoft.com/api/search?search=LINQ&locale=ru-ru&scoringprofile=search_for_en_us_a_b_test&facet=category&%24skip=0&%24top=10" 
        [Test]
        public void RestTest()
        {
            var client = new RestClient("https://docs.microsoft.com/api");
            var request = new RestRequest("search", Method.GET).AddParameter("search", "LINQ").AddParameter("locale", "ru-ru").AddParameter("top","25");
            var response = client.Execute(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            dynamic deser = JsonConvert.DeserializeObject(response.Content);

            var results = new List<ResponseItem>();
            foreach(dynamic resultItem in deser.results)
            {
                string contents = "";
                foreach(dynamic descr in resultItem.descriptions)
                {
                    contents += descr.content + Environment.NewLine;
                }
                string title = resultItem.title;
                results.Add(new ResponseItem(title, contents));
            }
            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );

            int a = 0;
        }
    }
}
