using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWebSiteCaseTests.Pages
{
    public class VKPage : AbstractPage
    {

        public VKPage(IWebDriver webDriver) : base(webDriver) { }
        public void ClickButton(By locator)
        {
            driver.FindElement(locator).Click();
        }
        public void ClickMessageTab()
        {
            ClickButton(By.XPath("//span[@class='LeftMenuItem-module__label--GaKMH']/span[text()='Мессенджер']"));
        }

        public void ClickBySelectedContact()
        {
            ClickButton(By.XPath("//span[@class='_im_dialog_link' and text()='Избранное']"));
        }
        
        public void ClickOnTheInputField()
        {
            ClickButton(By.XPath("/ html / body / div[11] / div / div / div[2] / div[2] / div[3] / div / div / div[1] / div[3] / div[2] / div[4] / div[4] / div[4] / div[1] / div[4]"));
        }


        public void SendMesage(string message)
        {
            IWebElement webElement = driver.FindElement(By.XPath("/ html / body / div[11] / div / div / div[2] / div[2] / div[3] / div / div / div[1] / div[3] / div[2] / div[4] / div[4] / div[4] / div[1] / div[4]"));
            webElement.SendKeys(message);
            ClickButton(By.XPath("/html/body/div[11]/div/div/div[2]/div[2]/div[3]/div/div/div[1]/div[3]/div[2]/div[4]/div[4]/div[4]/div[1]/button/span[2]"));
        }

        public string CheckMessage(string messageText)
        {
            IWebElement message = driver.FindElement(By.XPath($"//div[@class='im-mess--text wall_module _im_log_body' and text()='{messageText}']"));
            return message.Text;
        }

        public override void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
    }
}
