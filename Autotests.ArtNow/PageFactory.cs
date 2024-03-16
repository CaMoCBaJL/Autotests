using OpenQA.Selenium;

namespace Autotests.ArtNow.Pages
{
    public class PageFactory
    {
        private readonly IWebDriver _driver;

        public PageFactory(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public HomePage CreateHomePage()
        {
            return HomePage.Create(_driver);
        }
    }
}
