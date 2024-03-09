using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autotests.Tests.ArtNow.Pages
{
    public class HomePage : WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();

            _pageElements.Add(ElementCssRules.SearchBar, new DomElement() { InitializerFunction = FindSearchBar });
            _pageElements.Add(ElementCssRules.InputSearchBar, new DomElement() { InitializerFunction = FindSearchBarInput });
            _pageElements.Add(ElementCssRules.LeftShellNavigation, new DomElement() { InitializerFunction = FindArtTypesList });
            _pageElements.Add(ElementCssRules.ContentContainer, new DomElement() { InitializerFunction = FindPaintingsContainer });
            _pageElements.Add(ElementCssRules.SearchButton, new DomElement() { InitializerFunction = FindSearchButton });
            _pageElements.Add(ElementNames.CatalogButton, new DomElement() { InitializerFunction = FindCatalogButton });
        }

        public static new HomePage Create(IWebDriver webDriver)
        {
            var homePage = new HomePage();

            homePage.CreatePageContent();
            homePage.ValidatePageContent();
            try
            {
                homePage.InitializePageContent(webDriver);
            }
            finally
            {
                webDriver.Quit();
            }

            return homePage;
        }

        private IWebElement FindCatalogButton(IWebDriver driver)
        {
            var topMenu = driver.FindElement(By.CssSelector(ElementCssRules.TopMenu));

            return topMenu.FindElements(By.TagName(HtmlTagNames.Ul)).FirstOrDefault();
        }

        private IWebElement FindSearchButton(IWebDriver driver)
        {
            var header = driver.FindElement(By.CssSelector(ElementCssRules.Header));

            var searchBarElement = header?.FindElement(By.CssSelector(ElementCssRules.SearchButton));

            return searchBarElement;
        }

        private IWebElement FindPaintingsContainer(IWebDriver driver)
        {
            return driver.FindElement(By.CssSelector(ElementCssRules.ContentContainer));
        }

        private IWebElement FindSearchBar(IWebDriver driver)
        {
            var headerSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Div)
                .WithClass(ElementCssRules.Header)
                .CompileRule();

            var header = driver.FindElement(By.CssSelector(headerSelector));

            var searchBarSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Span)
                .WithClass(ElementCssRules.SearchBar)
                .CompileRule();

            var searchBarElement = header?.FindElement(By.CssSelector(searchBarSelector));

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

            return shellNavigation?.FindElements(By.TagName(HtmlTagNames.Ul))?.Skip(1)?.Take(1)?.FirstOrDefault();
        }

        public void Search(IWebDriver driver, string searchQuery)
        {
            _pageElements.GetValueOrDefault(ElementCssRules.InputSearchBar)?.Element?.SendKeys(searchQuery);

            _pageElements.GetValueOrDefault(ElementCssRules.SearchButton)?.Element?.Click();

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));

            wait.Until(driver => driver.FindElement(By.Id(ElementIds.ContentContainer)).FindElements(By.CssSelector(ElementCssRules.Post)).Count == 0);
        }

        public void GoToCatalogs(IWebDriver driver)
        {
            _pageElements.GetValueOrDefault(ElementNames.CatalogButton)?.Element?.Click();
        }
    }
}
