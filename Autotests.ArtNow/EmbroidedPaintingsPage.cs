using Autotests.PlatformAdapter;
using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autotests.ArtNow.Pages
{
    public class EmbroidedPaintingsPage: WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();

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

            _pageElements.Add(ElementCssRules.GenresList, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var genresListSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.GenresList)
                        .WithChild()
                        .WithTag(HtmlTagNames.UnorderedList)
                        .WithChild()
                        .WithTag(HtmlTagNames.ListItem)
                        .CompileRule();

                    return driver.FindElements(By.CssSelector(genresListSelector))
                        ?.FirstOrDefault(e => e.Text.Contains("Жанр"));
                }
            });

            _pageElements.Add(ElementNames.CityScape, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var genreSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Label)
                        .CompileRule();

                    return _pageElements?.GetValueOrDefault(ElementCssRules.GenresList).Element
                        ?.FindElements(By.CssSelector(genreSelector))
                        ?.FirstOrDefault(e => e.Text.Contains(ElementNames.CityScape));
                }
            });
        }

        public static new EmbroidedPaintingsPage Create(IWebDriver webDriver)
        {
            var embroidedPaintingsPage = new EmbroidedPaintingsPage();

            embroidedPaintingsPage.CreatePageContent();
            embroidedPaintingsPage.ValidatePageContent();
            embroidedPaintingsPage.InitializePageContent(webDriver);

            return embroidedPaintingsPage;
        }

        public void SearchCityScapePaintings(IWebDriver driver)
        {
            _pageElements.GetValueOrDefault(ElementNames.CityScape).Element.Click();

            new WebDriverWait(driver, PlatformConstants.DefaultBroswserActionTimeout).Until(
                d => driver.FindElement(By.Id(ElementIds.ApplyFilterContainer)));

            driver.FindElement(By.Id(ElementIds.ApplyFilterContainer)).Click();

            var wait = new WebDriverWait(driver, PlatformConstants.DefaultBroswserActionTimeout);

            wait.Until(driver => driver.FindElement(By.Id(ElementIds.SearchContentContainer)).FindElements(By.CssSelector(ElementCssRules.Post)).Count == 0);
        }

        public bool AnyPaintingContain(IWebDriver driver, string searchQuery)
        {
            var paintingContents = GetContentPaintings(driver).Select(p => p.Text).ToList();

            return !string.IsNullOrEmpty(paintingContents.FirstOrDefault(i => i.Contains(searchQuery)));
        }

        public void ShowPainitingContaing(IWebDriver driver, string searchQuery)
        {
            var painting = GetContentPaintings(driver)?.FirstOrDefault(p => p.Text.Contains(searchQuery));

            var nameRefSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Anchor)
                .CompileRule();

            painting.FindElement(By.CssSelector(nameRefSelector))?.Click();

            var imageContainerSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.ImageContainer)
                .CompileRule();

            var wait = new WebDriverWait(driver, PlatformConstants.DefaultBroswserActionTimeout);

            wait.Until(driver => driver.FindElement(By.CssSelector(imageContainerSelector)));
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
    }
}
