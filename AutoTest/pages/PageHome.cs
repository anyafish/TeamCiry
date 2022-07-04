/* Описывает главную страницу */
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class PageHome
    {
        /// <summary>Строка для ввода текста поиска</summary>
        [FindsBy(How = How.CssSelector, Using = "input[title='Поиск']")]
        public IWebElement TxtSearchForm { get; set; }

        /// <summary>Кнопка Поиск в Google</summary>
        [FindsBy(How = How.CssSelector, Using = "input[value='Поиск в Google']")]
        public IWebElement BtnSearchSubmit { get; set; }
    }
}
