using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class CatalogsPage : WebPage
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

            _pageElements.Add(ElementNames.EmbroideredPaintings, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var chapterItemSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Anchor)
                        .WithChild()
                        .WithTag(HtmlTagNames.Division)
                        .CompileRule();

                    var chapterElements = _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Element
                       .FindElements(By.CssSelector(chapterItemSelector));

                    return chapterElements.FirstOrDefault(e => e.Text.Contains(ElementNames.EmbroideredPaintings));
                }
            });

            _pageElements.Add(ElementNames.Jewerly, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var chapterItemSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Anchor)
                        .WithChild()
                        .WithTag(HtmlTagNames.Division)
                        .CompileRule();

                    var chapterElements = _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Element
                       .FindElements(By.CssSelector(chapterItemSelector));

                    return chapterElements.FirstOrDefault(e => e.Text.Contains(ElementNames.Jewerly));
                }
            });

            _pageElements.Add(ElementNames.Batik, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var chapterItemSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Anchor)
                        .WithChild()
                        .WithTag(HtmlTagNames.Division)
                        .CompileRule();

                    var chapterElements = _pageElements.GetValueOrDefault(ElementCssRules.ContentContainer).Element
                       .FindElements(By.CssSelector(chapterItemSelector));

                    return chapterElements.FirstOrDefault(e => e.Text.Contains(ElementNames.Batik));
                }
            });
        }

        public static new CatalogsPage Create(IWebDriver webDriver)
        {
            var catalogsPage = new CatalogsPage();

            catalogsPage.CreatePageContent();
            catalogsPage.ValidatePageContent();
            catalogsPage.InitializePageContent(webDriver);

            return catalogsPage;
        }

        public void ShowEmbroideredPaintings()
        {
            _pageElements.GetValueOrDefault(ElementNames.EmbroideredPaintings).Element.Click();
        }

        public void ShowJewerly()
        {
            _pageElements.GetValueOrDefault(ElementNames.Jewerly).Element.Click();
        }

        public void ShowBatik()
        {
            _pageElements.GetValueOrDefault(ElementNames.Batik).Element.Click();
        }
    }
}
