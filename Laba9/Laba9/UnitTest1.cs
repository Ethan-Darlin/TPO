using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Text;
using System;
using System.IO;

namespace Laba9
{
    public class Tests
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            baseURL = "https://vk.com/";
            verificationErrors = new StringBuilder();

        }

        [TearDown]
        public void TearDownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Assert.That(verificationErrors.ToString(), Is.EqualTo(""));
        }

        [Test]
        public void TestAddItemToBasket()
        {

            driver.Navigate().GoToUrl(baseURL);
            Thread.Sleep(20000);
            IWebElement search = driver.FindElement(By.XPath("//span[@class='LeftMenuItem-module__label--GaKMH']/span[text()='Мессенджер']"));
            search.Click();
            Thread.Sleep(2000);
            IWebElement element = driver.FindElement(By.XPath("//span[@class='_im_dialog_link' and text()='Избранное']"));
            element.Click();
            Thread.Sleep(2000);
            search = driver.FindElement(By.XPath("/ html / body / div[11] / div / div / div[2] / div[2] / div[3] / div / div / div[1] / div[3] / div[2] / div[4] / div[4] / div[4] / div[1] / div[4]"));
          
            string messageText = "Авто тест 9";
            search.SendKeys(messageText);
            Thread.Sleep(2000);
            
            IWebElement sendButton = driver.FindElement(By.XPath("/html/body/div[11]/div/div/div[2]/div[2]/div[3]/div/div/div[1]/div[3]/div[2]/div[4]/div[4]/div[4]/div[1]/button/span[2]"));

            sendButton.Click();
          
            Thread.Sleep(2000);

            IWebElement message = driver.FindElement(By.XPath($"//div[@class='im-mess--text wall_module _im_log_body' and text()='{messageText}']"));

       
            string lastMessageText = message.Text;
            Assert.IsTrue(lastMessageText.Contains(messageText, StringComparison.OrdinalIgnoreCase));
    
        }
    }
}