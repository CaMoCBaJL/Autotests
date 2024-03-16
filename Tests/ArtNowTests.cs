using Autotests.PlatformAdapter.Web;
using NUnit.Allure.Core;
using Allure.Net.Commons;
using Autotests.ArtNow.Pages;
using Autotests.PlatformAdapter.Shared.Enums;
using OpenQA.Selenium;
using NUnit.Allure.Attributes;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Legacy;

namespace Autotests.ArtNow.Tests
{
    [AllureNUnit]
    [TestFixture]
    [AllureSuite("1")]
    public class ArtNowsTests
    {
        private BrowserAdapter _browserAdapter;
        private IWebDriver _driver;

        [OneTimeSetUp]
        public void OnTestStart()
        {
            _browserAdapter = new BrowserAdapter("https://artnow.ru/");
            _browserAdapter.InitializeBrowser(BrowserType.Google_Chrome);
            _driver = _browserAdapter.WebDriver;

            _browserAdapter.OpenUrl();
        }

        [Test]
        public void Check_GiraffeSearch_ReturnsAnyGiraffePainting()
        {
            var homePage = new PageFactory(_driver).CreateHomePage();
            homePage.Search(_driver, "Жираф");
            Assert.That(homePage.FirstPaintingContain(_driver, "Жираф"));
        }

        [Test]
        public void Check_FindTramWay_ReturnsPaiting()
        {
            var pageFactory = new PageFactory(_driver);

            var homePage = pageFactory.CreateHomePage();
            homePage.GoToCatalogs();

            var catalogsPage = pageFactory.CreateCatalogsPage();
            catalogsPage.ShowEmbroideredPaintings();

            var embroidedPage = pageFactory.CreateEmbroidedPainitingsPage();
            embroidedPage.SearchCityScapePaintings(_driver);

            Assert.That(embroidedPage.AnyPaintingContain(_driver, "Трамвайный путь"));
        }

        [Test]
        public void Check_TramWayPaintingStyle_IsRealism()
        {
            var pageFactory = new PageFactory(_driver);

            var homePage = pageFactory.CreateHomePage();
            homePage.GoToCatalogs();

            var catalogsPage = pageFactory.CreateCatalogsPage();
            catalogsPage.ShowEmbroideredPaintings();

            var embroidedPage = pageFactory.CreateEmbroidedPainitingsPage();
            embroidedPage.SearchCityScapePaintings(_driver);

            embroidedPage.ShowPainitingContaing(_driver, "Трамвайный путь");

            Assert.That(pageFactory.CreatePaintingDetailsPage().ComparePaintingStyle("Реализм"));
        }

        [Test]
        public void Check_AddBatikPaintingToFavorites_AddsPaintingToFavorites()
        {
            var pageFactory = new PageFactory(_driver);

            var homePage = pageFactory.CreateHomePage();
            homePage.GoToCatalogs();

            var catalogsPage = pageFactory.CreateCatalogsPage();
            catalogsPage.ShowBatik();

            var batikPage = pageFactory.CreateBatikPaintingsPage();
            var firstBatikPainting = batikPage.GetFirstPaintingInfo(_driver);
            batikPage.AddFirstPaintigToFavorites(_driver);
            batikPage.ShowFavoritePaintings(_driver);

            var favoritesPage = pageFactory.CreateFavoritePaintingsPage();
            var firstFavoriteItem = favoritesPage.GetFirstPaintingInfo(_driver);

            Assert.That(firstBatikPainting == firstFavoriteItem);
        }

        [Test]
        public void Check_AddJewerlyToCart_AddsItemToCartWithConstantPrice()
        {
            var pageFactory = new PageFactory(_driver);

            var homePage = pageFactory.CreateHomePage();
            homePage.GoToCatalogs();

            var catalogsPage = pageFactory.CreateCatalogsPage();
            catalogsPage.ShowJewerly();
        }

        [OneTimeTearDown]
        public void OnTestTearDown()
        {
            //if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            //{
            //    AllureApi.AddAttachment($"{TestContext.CurrentContext.Test.MethodName}.png", "image/png", _browserAdapter.CreateScreenShot().AsByteArray);
            //}

            _browserAdapter.Dispose();
            //how to generate and serve allure report
            //open ps
            //cd .\Autotests\Tests\bin\Debug\net8.0
            //allure generate
            //allure serve
        }
    }
}
