using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class CartPage: WebPage
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
        }

        public static new CartPage Create(IWebDriver webDriver)
        {
            var cartPage = new CartPage();

            cartPage.CreatePageContent();
            cartPage.ValidatePageContent();
            cartPage.InitializePageContent(webDriver);

            return cartPage;
        }

        public string GetFirstPaintingPrice(IWebDriver driver)
        {
            var cartContent = GetContentPaintings(driver);
            var firstPainting = cartContent?.FirstOrDefault();

            var paintigInfoSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.PaintingPrice)
                .CompileRule();

            return firstPainting?.FindElement(By.CssSelector(paintigInfoSelector)).Text
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);
        }

        private List<IWebElement> GetContentPaintings(IWebDriver driver)
        {
            _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Reinitialize(driver);

            var cartRowsSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.CartItem)
                        .CompileRule();

            return _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer)?.Element.FindElements(By.CssSelector(cartRowsSelector))?.ToList();
        }
    }
}
