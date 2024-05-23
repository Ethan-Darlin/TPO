using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace MyWebSiteCaseTests.Framework
{
    public class BrowserManager
    {
        private readonly IWebDriver _driver;

        public BrowserManager()
        {
            _driver = new ChromeDriver();
        }

        public IWebDriver GetDriver()
        {
            return _driver;
        }

        public void QuitDriver()
        {
            _driver.Quit();
        }
    }
}
