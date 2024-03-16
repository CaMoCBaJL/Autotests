using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class PaintingDetailsPage : WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();
        }

        public static new PaintingDetailsPage Create(IWebDriver webDriver)
        {
            var paintingDetailsPage = new PaintingDetailsPage();

            paintingDetailsPage.CreatePageContent();
            paintingDetailsPage.ValidatePageContent();
            paintingDetailsPage.InitializePageContent(webDriver);

            return paintingDetailsPage;
        }
    }
}
