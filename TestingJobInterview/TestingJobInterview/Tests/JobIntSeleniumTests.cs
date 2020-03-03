using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestingJobInterview.UI;
using System.Linq;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntSeleniumTests
    {
        IWebDriver driver;
        MsSearchPage SearchPage;

        [SetUp]
        public void OnTestStart()
        {
            driver = new ChromeDriver(AppDomain.CurrentDomain.BaseDirectory);
            driver.Url = "https://docs.microsoft.com/ru-ru/";
            SearchPage = new MsSearchPage(driver);
        }

        [TearDown]
        public void OnTestEnd()
        {
            driver.Close();
        }

        [Test]
        public void SeleniumUpperSearchTest()
        {
            SearchPage.SearchPanel.Set("LINQ\n");
            SearchPage.Results.ForEach(searchRes => Assert.IsTrue(
                searchRes.Title.ToLower().Contains("linq") ||
                searchRes.Description.ToLower().Contains("linq")
                )
            );
        }
        [Test]
        public void SeleniumLowerSearchTest()
        {
            SearchPage.SearchPanel.Set("linq\n");
            SearchPage.Results.ForEach(searchRes => Assert.IsTrue(
                searchRes.Title.ToLower().Contains("linq") ||
                searchRes.Description.ToLower().Contains("linq")
                )
            );
        }
        [Test]
        public void SeleniumJumpingSearchTest()
        {
            SearchPage.SearchPanel.Set("lInQ\n");
            var a = SearchPage.Results.First();
            SearchPage.Results.ForEach(searchRes => Assert.IsTrue(
                searchRes.Title.ToLower().Contains("linq") ||
                searchRes.Description.ToLower().Contains("linq")
                )
            );
        }
    }
}
