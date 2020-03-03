using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Linq;
using OpenQA.Selenium.Support.UI;
using TestingJobInterview.UI.Base;

namespace TestingJobInterview.UI
{
    public class MsSearchPage : UIBaseComponent
    {
        public SearchPanel SearchPanel;
        public List<SearchResult> Results
        {
            get
            {
                List<SearchResult> res = new List<SearchResult>();
                new WebDriverWait(Driver, TimeSpan.FromSeconds(10))
                    .Until(d => d.FindElement(By.XPath("//*[contains(@class,'searchResults')]//li")).Displayed);
                Driver.FindElements(By.XPath("//*[contains(@class,'searchResults')]//li")).ToList()
                    .ForEach(e => res.Add(new SearchResult(e)));
                return res;
            }
        }

        public MsSearchPage(IWebDriver driver):base(driver)
        {
            SearchPanel = new SearchPanel(Driver);
        }
    }
    public class SearchResult
    {
        IWebElement Element;
        public string Title => Element.FindElement(By.CssSelector("h2")).Text;
        public string Description => Element.FindElement(By.CssSelector("p")).Text;

        public SearchResult(IWebElement element)
        {
            Element = element;
        }
    }
}
