using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.Tests.ArtNow.Pages
{
    public class HomePage : WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();

            _pageElements.Add("search-bar", new DomElement() { InitializerFunction = FindSearchBar });
            _pageElements.Add("search-bar__input", new DomElement() { InitializerFunction = FindSearchBarInput });
            _pageElements.Add("art-types__list", new DomElement() { InitializerFunction = FindArtTypesList });
        }

        public static new HomePage Create(IWebDriver webDriver)
        {
            var homePage = new HomePage();

            homePage.CreatePageContent();
            homePage.ValidatePageContent();
            homePage.InitializePageContent(webDriver);

            return homePage;
        }

        private IWebElement FindSearchBar(IWebDriver driver)
        {
            var header = driver.FindElement(By.CssSelector(ElementCssRules.Header));

            var searchBarElement = header?.FindElement(By.CssSelector(ElementCssRules.SearchBar));

            return searchBarElement;
        }

        private IWebElement FindSearchBarInput(IWebDriver driver)
        {
            var searchBar = FindSearchBar(driver);

            return searchBar?.FindElement(By.CssSelector(ElementCssRules.InputSearchBar));
        }

        private IWebElement FindArtTypesList(IWebDriver driver)
        {
            var shellNavigation = driver.FindElement(By.CssSelector(ElementCssRules.LeftShellNavigation));

            return shellNavigation?.FindElements(By.TagName(HtmlTagNames.UlTag))?.Skip(1)?.Take(1)?.FirstOrDefault();
        }
    }
}
