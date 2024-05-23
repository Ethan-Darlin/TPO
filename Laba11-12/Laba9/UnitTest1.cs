using MyWebSiteCaseTests.Framework; // Импорт BrowserManager
using MyWebSiteCaseTests.Pages;
using NUnit.Framework; // Для аннотаций тестов
using OpenQA.Selenium.Edge; // Для драйвера браузера
using System.Threading; // Для Thread.Sleep
using Laba9.Pages;
namespace Laba9.Tests
{
    public class Tests
    {
        private BrowserManager _browserManager;
        private VKPage _vkPage;
        private GroupPage _groupPage;

        [SetUp]
        public void Setup()
        {
            _browserManager = new BrowserManager(); // Инициализация BrowserManager
            _vkPage = new VKPage(_browserManager.GetDriver()); // Инициализация VKPage с драйвером из BrowserManager
            _groupPage = new GroupPage(_browserManager.GetDriver()); // Инициализация GroupPage с драйвером из BrowserManager
        }

        [TearDown]
        public void TearDown()
        {
            _browserManager.QuitDriver(); // Остановка драйвера браузера после каждого теста
        }

        [Test]
        public void SendMessageTest()
        {
            // Пример теста отправки сообщения
            string message = "Привет, мир"; // Строка сообщения для отправки

            _vkPage.GoToPage("https://vk.com/"); // Переход на страницу
            Thread.Sleep(5000); // Ждем загрузки страницы

            _vkPage.ClickMessageTab(); // Клик по вкладке Мессенджер
            Thread.Sleep(2000); // Ждем появления контактов

            _vkPage.ClickBySelectedContact(); // Клик по избранным контактам
            Thread.Sleep(2000); // Ждем открытия чата

            _vkPage.ClickOnTheInputField(); // Клик по полю ввода сообщения
            _vkPage.SendMesage(message); // Отправка сообщения

            // Проверка успешности отправки сообщения
            Assert.IsTrue(_vkPage.CheckMessage(message).Contains(message, StringComparison.OrdinalIgnoreCase));

            // Логирование результата теста
            Logger.LogInfo($"Тест отправки сообщения прошел успешно.");
        }

        [Test]
        public void TestAddItemToBasket()
        {
            // Пример теста добавления товара в корзину
            string expectedStatus = "Отписаться"; // Ожидаемый статус кнопки после добавления в корзину

            _groupPage.GoToPage("https://vk.com/"); // Переход на страницу
            Thread.Sleep(5000); // Ждем загрузки страницы

            _groupPage.ClickGroupTab(); // Клик по вкладке Сообщества
            Thread.Sleep(2000); // Ждем загрузки списка групп

            _groupPage.ClickOnTheGroup(); // Клик по группе Рифмач
            Thread.Sleep(3000); // Ждем загрузки страницы группы

            _groupPage.MoveMous(); // Движение мыши над кнопкой подписки
            Thread.Sleep(2000); // Ждем появления кнопки подписки

            _groupPage.ClickUnsub(); // Клик по кнопке Отписаться
            Thread.Sleep(2000); // Ждем изменения статуса кнопки

            // Проверка статуса кнопки после подписки
            Assert.IsFalse(_groupPage.CheckSub().Contains(expectedStatus, StringComparison.OrdinalIgnoreCase));

            // Логирование результата теста
            Logger.LogInfo($"Тест добавления товара в корзину прошел успешно.");
        }
    }
}
