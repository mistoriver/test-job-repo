using NUnit.Framework;
using System.Reflection.Metadata;
using TestingJobInterview.APIEntities;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntRestTests
    {
        const string anySearch = "LiNq";
        readonly string upperSearch = anySearch.ToUpper();
        readonly string lowerSearch = anySearch.ToLower();

        #region Самый толковый тест
        [Test]
        public void AnyLinqTest()
        {
            int resultCountNeedToTest = 500;

            var results = Searcher.Search(anySearch, resultCountNeedToTest);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains(lowerSearch) ||
                res.Description.ToLower().Contains(lowerSearch)
                )
            );
        }
        #endregion
        #region Не самые толковые тесты
        [Test]
        public void UpperLinqTest()
        {
            //API сайта отбивает запросы с top>25, поэтому пара стандартных проверок
            RestSearchHelper.ConfigureDefaultSearch(upperSearch, 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains(lowerSearch) ||
                res.Description.ToLower().Contains(lowerSearch)
                )
            );
        }
        [Test]
        public void LowerLinqTest()
        {
            RestSearchHelper.ConfigureDefaultSearch(lowerSearch, 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains(lowerSearch) ||
                res.Description.ToLower().Contains(lowerSearch)
                )
            );
        }
        [Test]
        public void JumpingLinqTest()
        {
            RestSearchHelper.ConfigureDefaultSearch(anySearch, 25);

            var response = RestSearchHelper.Execute();

            Assert.IsNotNull(response);
            Assert.AreEqual(response.StatusCode, System.Net.HttpStatusCode.OK);

            var results = ResponseHelper.Deserialize(response.Content);

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains(lowerSearch) ||
                res.Description.ToLower().Contains(lowerSearch)
                )
            );
        }
        [Test]
        public void FiftyLinqTest()
        {
            //А здесь я придумал самый простой способ, как сформировать 50 записей
            RestSearchHelper.ConfigureDefaultSearch(upperSearch, 25);

            var response = RestSearchHelper.Execute();
            
            Assert.IsNotNull(response);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, response.StatusCode);


            RestSearchHelper.ConfigureSearch(upperSearch, 25, 25);
            var secResponse = RestSearchHelper.Execute();

            Assert.IsNotNull(secResponse);
            Assert.AreEqual(System.Net.HttpStatusCode.OK, secResponse.StatusCode);

            var results = ResponseHelper.Deserialize(ResponseHelper.ConcatResponses(response.Content,secResponse.Content));

            Assert.IsTrue(results.Count > 0);

            results.ForEach(res => Assert.IsTrue(
                res.Title.ToLower().Contains(lowerSearch) ||
                res.Description.ToLower().Contains(lowerSearch)
                )
            );
        }
        #endregion
    }
}
