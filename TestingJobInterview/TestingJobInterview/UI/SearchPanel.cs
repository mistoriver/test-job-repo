using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using TestingJobInterview.UI.Base;

namespace TestingJobInterview.UI
{
    public class SearchPanel : UIBaseComponent
    {
        public SearchPanel(IWebDriver driver) : base(driver)
        { }
        IWebElement OpenSearchButton => Driver.FindElement(By.XPath("//button[@id='form-expander']"));

        IWebElement SearchField => Driver.FindElement(By.XPath("//form[@id='searchForm']//input"));

        public void Set(string value)
        {
            if (!SearchField.Displayed)
            {
                OpenSearchButton.Click();
                new WebDriverWait(Driver, TimeSpan.FromSeconds(10)).Until(e => SearchField.Displayed);
            }
            SearchField.Clear();
            SearchField.SendKeys(value);
        }
        public string GetValue() => SearchField.Text;
    }
}
