using MyWebSiteCaseTests.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;


namespace Laba9.Pages
{
    partial class GroupPage : AbstractPage
    {
        public GroupPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public override void GoToPage(string url)
        {
            driver.Navigate().GoToUrl(url);
        }
        public void ClickButton(By locator)
        {
            driver.FindElement(locator).Click();
        }

        public void ClickGroupTab()
        {
            ClickButton(By.XPath("//span[@class='LeftMenuItem-module__label--GaKMH']/span[text()='Сообщества']"));
        }
        public void ClickOnTheGroup()
        {
            ClickButton(By.XPath("//a[@class='group_row_title' and text()='Рифмач']"));
        }
        public void MoveMous()
        {
            ClickButton(By.XPath("//div[@class='redesigned-group-subscribed redesigned-group-subscribed--button']"));
        }
        public void ClickUnsub()
        {
            ClickButton(By.XPath("//div[@class='ui_actions_menu_item page-group-action' and text()='Отписаться']"));
        }

        public string CheckSub()
        {
            IWebElement webElement = driver.FindElement(By.XPath($"//span[@class='FlatButton__content']"));
            return webElement.Text;
        }
    }
}
    