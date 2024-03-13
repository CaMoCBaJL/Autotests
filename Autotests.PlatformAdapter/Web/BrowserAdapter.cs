using Autotests.PlatformAdapter.Base;
using Autotests.PlatformAdapter.Shared.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace Autotests.PlatformAdapter.Web
{
    public class BrowserAdapter: TestPlatform, IDisposable
    {
        private readonly string _url;
        private IWebDriver _driver;

        public BrowserAdapter(string webSiteUrl) 
        {
            _url = webSiteUrl;
        }

        public void InitializeBrowser(BrowserType browserType)
        {
            switch (browserType)
            {
                case BrowserType.Google_Chrome:
                    _driver = new ChromeDriver();
                    return;
                case BrowserType.Mozila_Filerfox:
                    _driver = new FirefoxDriver();
                    return;
                default: 
                    throw new NotSupportedException();
            }
        }

        public IWebDriver WebDriver { get => _driver; }

        public void OpenUrl()
        {
            _driver.Navigate().GoToUrl(_url);

            new WebDriverWait(_driver, PlatformConstants.DefaultBroswserActionTimeout).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }
        
        public Screenshot CreateScreenShot()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot();
        }

        public void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile(fileName);
        }

        public void Dispose()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
