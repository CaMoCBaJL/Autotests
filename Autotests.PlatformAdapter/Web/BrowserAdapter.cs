using Autotests.PlatformAdapter.Base;
using Autotests.PlatformAdapter.Shared.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;

namespace Autotests.PlatformAdapter.Web
{
    public class BrowserAdapter: TestPlatform
    {
        private readonly string _url;
        private WebDriver _driver;

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

        public void OpenUrl()
        {
            _driver.Navigate().GoToUrl(_url);
        }
        
        public Screenshot CreateScreenShot()
        {
            return ((ITakesScreenshot)_driver).GetScreenshot();
        }

        public void SaveScreenShot(Screenshot screenshot, string fileName)
        {
            screenshot.SaveAsFile(fileName);
        }
        ~BrowserAdapter() 
        {
            _driver.Quit();
        }
    }
}
