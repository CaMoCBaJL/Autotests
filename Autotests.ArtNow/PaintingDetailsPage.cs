using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class PaintingDetailsPage : WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();

            _pageElements.Add(ElementNames.PaintingStyleType, new DomElement()
            {
                InitializerFunction = driver =>
                {
                    var infoContainerSelector = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.PaintingInfoContainer)
                        .CompileRule();

                    var paintingInfoElement = driver.FindElement(By.CssSelector(infoContainerSelector));

                    var textDataSelectors = new CssRuleFactory()
                        .WithTag(HtmlTagNames.Division)
                        .WithClass(ElementCssRules.TextLine)
                        .CompileRule();

                    var styleData = paintingInfoElement.FindElements(By.CssSelector(textDataSelectors));
                        
                    var result = styleData.Skip(1).Take(1).FirstOrDefault();

                    return result;
                }
            });
        }

        public static new PaintingDetailsPage Create(IWebDriver webDriver)
        {
            var paintingDetailsPage = new PaintingDetailsPage();

            paintingDetailsPage.CreatePageContent();
            paintingDetailsPage.ValidatePageContent();
            paintingDetailsPage.InitializePageContent(webDriver);

            return paintingDetailsPage;
        }

        public bool ComparePaintingStyle(string style)
        {
            var styleElement = _pageElements.GetValueOrDefault(ElementNames.PaintingStyleType)?.Element;

            return styleElement.Text.Contains(style);
        }
    }
}
