using NUnit.Framework;
using System;
using TestingJobInterview.APIEntities;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntRestTests
    {
        [Test]
        public void UpperLinqTest()
        {
            //API сайта отбивает запросы с top>25, поэтому пара стандартных проверок
            RestHelper.ConfigureDefaultSearch("LINQ", 25);

            var response = RestHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = DeserializeHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
        [Test]
        public void LowerLinqTest()
        {
            RestHelper.ConfigureDefaultSearch("linq", 25);

            var response = RestHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = DeserializeHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
        [Test]
        public void JumpingLinqTest()
        {
            RestHelper.ConfigureDefaultSearch("lInQ", 25);

            var response = RestHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = DeserializeHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
        [Test]
        public void FiftyLinqTest()
        {
            //А здесь я придумал, как сформировать 50 записей
            RestHelper.ConfigureDefaultSearch("LINQ", 25);

            var response = RestHelper.Execute();
            
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);


            RestHelper.ConfigureSearch("LINQ", 25, 25);
            var secResponse = RestHelper.Execute();

            Assert.IsNotNull(secResponse);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, secResponse.StatusCode);

            var results = DeserializeHelper.Deserialize(DeserializeHelper.ConcatResponses(response.Content,secResponse.Content));

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
    }
}
