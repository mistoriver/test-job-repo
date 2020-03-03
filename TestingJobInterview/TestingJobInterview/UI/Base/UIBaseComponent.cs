using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestingJobInterview.UI.Base
{
    public abstract class UIBaseComponent
    {
        public IWebDriver Driver { get; set; }

        public UIBaseComponent(IWebDriver driver)
        {
            Driver = driver;
        }
    }
}
