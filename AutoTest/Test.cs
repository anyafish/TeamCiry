using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using System.Threading;
using AutoTest.pages;

namespace AutoTest
{
    [TestFixture]
    public class Test
    {
        public static string igWorkDir = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location); // рабочий каталог, относительно исполняемого файла (в нашем случае относительно DLL)
        public static IWebDriver driver;

        [OneTimeSetUp] // вызывается перед началом запуска всех тестов
        public void OneTimeSetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArguments("--ignore-certificate-errors");
            options.AddArguments("--ignore-ssl-errors");
            driver = new ChromeDriver(igWorkDir, options);
            driver.Manage().Window.Maximize();
        }

        [OneTimeTearDown] //вызывается после завершения всех тестов
        public void OneTimeTearDown()
        {
            driver.Quit();
        }

        [SetUp] // вызывается перед каждым тестом
        public void SetUp()
        {
            // ТУТ КОД
        }

        [TearDown] // вызывается после каждого теста
        public void TearDown()
        {
            // ТУТ КОД
        }

        [Test]
        public void Test_1()
        {
            driver.Navigate().GoToUrl("https://www.google.ru");
            driver.FindElement(By.CssSelector("input[title='Поиск']")).Click(); // кликаем в поле ввода поисковой фразы
            driver.FindElement(By.CssSelector("input[title='Поиск']")).SendKeys("В чём сила брат?"); // вводим поисковую фразу
            driver.FindElement(By.CssSelector("input[value='Поиск в Google']")).Click(); // нажимаем на кнопку "Поиск в Google"
            Thread.Sleep(5000); // пауза за наблюдением результата поиска, для наглядности
            driver.FindElement(By.CssSelector("a#logo")).Click(); // возвращаемся на главную страницу кликнув по логотипу
            Thread.Sleep(5000); // пауза за наблюдением перехода на главную, для наглядности
        }

        [Test]
        public void Test_2()
        {
            driver.Navigate().GoToUrl("https://www.google.ru");
            PageHome pageHome = new PageHome(); // чтобы могли обращаться к объектам из PageHome.cs
            PageFactory.InitElements(driver, pageHome); // инициализация элементов Page Object из PageHome.cs
            pageHome.TxtSearchForm.Click(); // кликаем в поле ввода поисковой фразы
            pageHome.TxtSearchForm.SendKeys("В чём сила брат?"); // вводим поисковую фразу
            pageHome.BtnSearchSubmit.Click(); // нажимаем на кнопку "Поиск в Google"
            Thread.Sleep(5000); // пауза за наблюдением результата поиска, для наглядности
            PageResultSearch pageResult = new PageResultSearch(); // чтобы могли обращаться к объектам из PageResultSearch.cs
            PageFactory.InitElements(driver, pageResult); // инициализация элементов Page Object из PageResultSearch.cs
            pageResult.LnkLogo.Click(); // возвращаемся на главную страницу кликнув по логотипу
            Thread.Sleep(5000); // пауза за наблюдением перехода на главную, для наглядности
        }
    }
}
