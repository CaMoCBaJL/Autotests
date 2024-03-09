using Autotests.PlatformAdapter;
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

            _pageElements.Add(ElementCssRules.Header, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var headerSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.Header)
                        .CompileRule();

                    return driver.FindElement(By.CssSelector(headerSelector));
                }
            });

            _pageElements.Add(ElementCssRules.SearchBar, new DomElement()
            {
                InitializerFunction = _ =>
                {
                    var searchBarSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Span)
                        .WithClass(ElementCssRules.SearchBar)
                        .CompileRule();

                    return _pageElements.GetValueOrDefault(ElementCssRules.Header)?.Element?.FindElement(By.CssSelector(searchBarSelector));
                }
            });

            _pageElements.Add(ElementCssRules.InputSearchBar, new DomElement()
            {
                InitializerFunction = _ =>
                {
                    var searchBarElement = _pageElements.GetValueOrDefault(ElementCssRules.SearchBar)?.Element;

                    var inputSearchBarSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Input)
                        .WithClass(ElementCssRules.InputSearchBar)
                        .CompileRule();

                    return searchBarElement?.FindElement(By.CssSelector(inputSearchBarSelector));
                }
            });

            _pageElements.Add(ElementCssRules.SearchButton, new DomElement()
            {
                InitializerFunction = _ =>
                {
                    var searchButtonSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Button)
                        .WithClass(ElementCssRules.SearchButton)
                        .CompileRule();

                    return _pageElements.GetValueOrDefault(ElementCssRules.Header)?.Element?.FindElement(By.CssSelector(searchButtonSelector));
                }
            });

            _pageElements.Add(ElementCssRules.TopMenu, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var topMenuSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.TopMenu)
                        .CompileRule();

                    return driver.FindElement(By.CssSelector(topMenuSelector));
                }
            });

            _pageElements.Add(ElementNames.CatalogButton, new DomElement()
            {
                InitializerFunction = _ =>
                {
                    var topMenuElements = _pageElements.GetValueOrDefault(ElementCssRules.TopMenu)?.Element
                        .FindElements(By.TagName(HtmlTagNames.UnorderedList)).FirstOrDefault(); ;

                    var catalogsSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.ListItem)
                        .WithChild()
                        .WithTag(HtmlTagNames.Anchor)
                        .CompileRule();

                    return topMenuElements?.FindElement(By.CssSelector(catalogsSelector));
                }
            });

            _pageElements.Add(ElementCssRules.ContentContainer, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var contentContainerSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.ContentContainer)
                        .CompileRule();

                    return driver.FindElement(By.CssSelector(contentContainerSelector));
                }
            });
        }

        public static new HomePage Create(IWebDriver webDriver)
        {
            var homePage = new HomePage();

            homePage.CreatePageContent();
            homePage.ValidatePageContent();
            homePage.InitializePageContent(webDriver);

            return homePage;
        }

        public List<IWebElement> Search(IWebDriver driver, string searchQuery)
        {
            _pageElements.GetValueOrDefault(ElementCssRules.InputSearchBar)?.Element?.SendKeys(searchQuery);

            _pageElements.GetValueOrDefault(ElementCssRules.SearchButton)?.Element?.Click();

            var wait = new WebDriverWait(driver, PlatformConstants.DefaultBroswserActionTimeout);

            wait.Until(driver => driver.FindElement(By.Id(ElementIds.SearchContentContainer)).FindElements(By.CssSelector(ElementCssRules.Post)).Count == 0);

            return GetContentPaintings(driver);
        }

        private List<IWebElement> GetContentPaintings(IWebDriver driver)
        {
            _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Reinitialize(driver);

            var saContainerSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithId(ElementIds.SearchContentContainer)
                        .CompileRule();

            var saContainerElement = _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer)?.
                Element.FindElement(By.CssSelector(saContainerSelector));

            var postsSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.Post)
                .CompileRule();

            return saContainerElement.FindElements(By.CssSelector(postsSelector)).ToList();
        }

        public bool AnyPaintingContain(IWebDriver driver, string searchQuery)
        {
            var paintingContents = GetContentPaintings(driver).Select(p => p.Text);

            return !string.IsNullOrEmpty(paintingContents.FirstOrDefault(i => i.Contains(searchQuery)));
        }

        public void GoToCatalogs()
        {
            _pageElements.GetValueOrDefault(ElementNames.CatalogButton)?.Element?.Click();
        }
    }
}
