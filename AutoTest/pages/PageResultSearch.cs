/* Описывает страницу результатов поиска */
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutoTest.pages
{
    class PageResultSearch
    {
        /// <summary>Логотип-ссылка</summary>
        [FindsBy(How = How.CssSelector, Using = "a#logo")]
        public IWebElement LnkLogo { get; set; }
    }
}
