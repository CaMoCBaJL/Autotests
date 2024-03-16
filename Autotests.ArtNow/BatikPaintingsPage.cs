using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class BatikPaintingsPage: WebPage
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

            _pageElements.Add(ElementCssRules.FavoritePaintingsIcon, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var favoritePaintingsIconSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Span)
                        .WithClass(ElementCssRules.FavoritePaintingsIcon) 
                        .CompileRule();

                    return driver.FindElement(By.CssSelector(favoritePaintingsIconSelector));
                }
            });
        }

        public static new BatikPaintingsPage Create(IWebDriver webDriver)
        {
            var batikPaintingsPage = new BatikPaintingsPage();

            batikPaintingsPage.CreatePageContent();
            batikPaintingsPage.ValidatePageContent();
            batikPaintingsPage.InitializePageContent(webDriver);

            return batikPaintingsPage;
        }

        public void AddFirstPaintigToFavorites(IWebDriver driver)
        {
            var firstPainting = GetContentPaintings(driver)?.FirstOrDefault();

            var addToFavoriteSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.AddToFavorite)
                .CompileRule();

            firstPainting.FindElement(By.CssSelector(addToFavoriteSelector))?.Click();
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

        public void ShowFavoritePaintings(IWebDriver driver)
        {
            _pageElements.GetValueOrDefault(ElementCssRules.FavoritePaintingsIcon).Element.Click();
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
