
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System.Text;
using System;
using System.IO;
using MyWebSiteCaseTests.Pages;
using OpenQA.Selenium.Chrome;
using Laba9.Pages;

namespace Laba9
{
    public class Tests
    {
       [Test]
        public void SendMessageTest()
        {
            VKPage vkPage = new VKPage(new EdgeDriver());

            string message = "Лаба 10, автотест";

            vkPage.GoToPage("https://vk.com/");
            Thread.Sleep(25000);
            vkPage.ClickMessageTab();
            Thread.Sleep(3000);
            vkPage.ClickBySelectedContact();
            Thread.Sleep(3000);
            vkPage.ClickOnTheInputField();
            vkPage.SendMesage(message);
            Assert.IsTrue(vkPage.CheckMessage(message).Contains(message, StringComparison.OrdinalIgnoreCase));
        }

        [Test]
        public void TestAddItemToBasket()
        {
            GroupPage groupPage = new GroupPage(new EdgeDriver());

            groupPage.GoToPage("https://vk.com/");
            Thread.Sleep(25000);
            groupPage.ClickGroupTab();
            Thread.Sleep(3000);
            groupPage.ClickOnTheGroup();
            Thread.Sleep(4000);
            groupPage.MoveMous();
            Thread.Sleep(4000);
            groupPage.ClickUnsub();
            Assert.IsFalse(groupPage.CheckSub().Contains("Подписаться", StringComparison.OrdinalIgnoreCase));
        }
    }
}