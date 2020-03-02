using NUnit.Framework;
using RestSharp;
using System;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntTests
    {
        //"https://docs.microsoft.com/api/search?search=LINQ&locale=ru-ru&scoringprofile=search_for_en_us_a_b_test&facet=category&%24skip=0&%24top=10" 
        [Test]
        public void RestTest()
        {
            var client = new RestClient("https://docs.microsoft.com/api");
            var request = new RestRequest("search", Method.GET).AddParameter("search", "LINQ").AddParameter("locale", "ru-ru");
            var response = client.Execute<ResponseItem>(request);

            Assert.IsNotNull(response);
            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);
        }
    }
}
