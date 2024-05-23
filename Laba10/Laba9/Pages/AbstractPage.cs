using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteCaseTests.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver driver;

        public abstract void GoToPage(string url);

        public AbstractPage(IWebDriver webDriver)
        {
            driver = webDriver;
        }

        public void Exit()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
