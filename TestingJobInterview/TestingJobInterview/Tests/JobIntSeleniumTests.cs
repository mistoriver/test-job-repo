using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TestingJobInterview.UI;

namespace TestingJobInterview
{
    [TestFixture]
    public class JobIntSeleniumTests
    {
        IWebDriver driver = new ChromeDriver(@"\TestingRest\bin\Debug\netcoreapp2.2");
        MsSearchPage SearchPage;

        [Test]
        public void SeleniumSearchTest()
        {
            SearchPage = new MsSearchPage(driver);

            driver.Url = "https://docs.microsoft.com/ru-ru/";
            SearchPage.SearchPanel.Set("LINQ\n");
            //var a = SearchPage.Results.First();
            driver.Close();
        }
    }
}
