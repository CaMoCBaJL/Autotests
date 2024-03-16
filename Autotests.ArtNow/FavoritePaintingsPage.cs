using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class FavoritePaintingsPage : WebPage
    {
        public static new FavoritePaintingsPage Create(IWebDriver webDriver)
        {
            var favoritePaintingsPage = new FavoritePaintingsPage();

            favoritePaintingsPage.CreatePageContent();
            favoritePaintingsPage.ValidatePageContent();
            favoritePaintingsPage.InitializePageContent(webDriver);

            return favoritePaintingsPage;
        }

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
        }

        public string GetFirstPaintingInfo(IWebDriver driver)
        {
            var firstPainting = GetContentPaintings(driver)?.FirstOrDefault();

            var paintigInfoSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.ItemInfoContainer)
                .CompileRule();

            return firstPainting?.FindElement(By.CssSelector(paintigInfoSelector)).Text
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);
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

            var result = saContainerElement.FindElements(By.CssSelector(postsSelector)).ToList();
            return result;
        }

    }
}
