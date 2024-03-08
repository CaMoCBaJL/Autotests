using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.Tests.ArtNow
{
    public class HomePage : WebPage
    {
        private readonly DomElement _searchBar;
        private readonly DomElement _searchBarInput;
        private readonly DomElement _artTypesList;

        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;

            _searchBar = FindSearchBar();
            _searchBarInput = FindSearchBarInput();
            _artTypesList = FindArtTypesList();
        }

        private DomElement FindSearchBar()
        {
            var header = _driver.FindElement(By.CssSelector(ElementCssRules.Header));

            return new DomElement() { Element = header.FindElement(By.CssSelector(ElementCssRules.SearchBar)) };
        }

        private DomElement FindSearchBarInput()
        {
            return new DomElement() { Element = _searchBar.Element.FindElement(By.CssSelector(ElementCssRules.InputSearchBar)) };
        }

        private DomElement FindArtTypesList()
        {
            var shellNavigation = _driver.FindElement(By.CssSelector(ElementCssRules.LeftShellNavigation));

            return new DomElement() { Element = shellNavigation.FindElements(By.TagName(HtmlTagNames.UlTag))?.Skip(1)?.Take(1)?.FirstOrDefault() };
        }
    }
}
