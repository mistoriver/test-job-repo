using NUnit.Framework;
using TestingJobInterview.APIEntities;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntRestTests
    {
        #region Самый толковый тест
        [Test]
        public void AnyLinqTest()
        {
            int resultCountNeedToTest = 500;

            var results = Searcher.Search("LINQ", resultCountNeedToTest);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
        #endregion
        #region Не самые толковые тесты
        [Test]
        public void UpperLinqTest()
        {
            //API сайта отбивает запросы с top>25, поэтому пара стандартных проверок
            RestSearchHelper.ConfigureDefaultSearch("LINQ", 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

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
            RestSearchHelper.ConfigureDefaultSearch("linq", 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

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
            RestSearchHelper.ConfigureDefaultSearch("lInQ", 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

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
            //А здесь я придумал самый простой способ, как сформировать 50 записей
            RestSearchHelper.ConfigureDefaultSearch("LINQ", 25);

            var response = RestSearchHelper.Execute();
            
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);


            RestSearchHelper.ConfigureSearch("LINQ", 25, 25);
            var secResponse = RestSearchHelper.Execute();

            Assert.IsNotNull(secResponse);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, secResponse.StatusCode);

            var results = ResponseHelper.Deserialize(ResponseHelper.ConcatResponses(response.Content,secResponse.Content));

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains("linq") ||
                res.Description.ToLower().Contains("linq")
                )
            );
        }
        #endregion
    }
}
