using NUnit.Framework;
using TestingJobInterview.APIEntities;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntRestTests
    {
        [Test]
        public void UpperLinqTest()
        {
            //API сайта отбивает запросы с top>25, поэтому не 50, как было попрошено, а 25
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
    }
}
