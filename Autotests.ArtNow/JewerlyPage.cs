using Autotests.PlatformAdapter;
using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Autotests.ArtNow.Pages
{
    public class JewerlyPage: WebPage
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

        public static new JewerlyPage Create(IWebDriver webDriver)
        {
            var jewerlyPage = new JewerlyPage();

            jewerlyPage.CreatePageContent();
            jewerlyPage.ValidatePageContent();
            jewerlyPage.InitializePageContent(webDriver);

            return jewerlyPage;
        }

        public void AddFirstPaintigToCart(IWebDriver driver)
        {
            var firstPainting = GetContentPaintings(driver)?.FirstOrDefault();

            var addToFavoriteSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.BuyPainting)
                .CompileRule();

            firstPainting.FindElement(By.CssSelector(addToFavoriteSelector))?.Click();
        }

        public string GetFirstPaintingPrice(IWebDriver driver)
        {
            var firstPainting = GetContentPaintings(driver)?.FirstOrDefault();

            var paintigInfoSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.PaintingPrice)
                .CompileRule();

            return firstPainting?.FindElement(By.CssSelector(paintigInfoSelector)).Text
                .Replace(" ", string.Empty)
                .Replace(Environment.NewLine, string.Empty);
        }

        public void ShowCart(IWebDriver driver)
        {
            var goToCartSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.PaintingAddedToCartModalWindow)
                .WithChild()
                .WithTag(HtmlTagNames.Paragraph)
                .WithChild()
                .WithTag(HtmlTagNames.Button)
                .WithClass(ElementCssRules.GoToCartInModal)
                .CompileRule();

            driver.FindElement(By.CssSelector(goToCartSelector))?.Click();

            var wait = new WebDriverWait(driver, PlatformConstants.DefaultBroswserActionTimeout);

            _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Reinitialize(driver);
            var cartRowSelector = new CssRuleFactory()
                .WithTag(HtmlTagNames.Division)
                .WithClass(ElementCssRules.CartItem)
                .CompileRule();

            wait.Until(driver => _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer)?.Element.FindElements(By.CssSelector(cartRowSelector)).Count > 0);
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
