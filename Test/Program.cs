using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adapter = new BrowserAdapter("https://artnow.ru/");
            adapter.InitializeBrowser(Autotests.PlatformAdapter.Shared.Enums.BrowserType.Google_Chrome);
            var driver = adapter.WebDriver;

            adapter.OpenUrl();

            new WebDriverWait(driver, TimeSpan.FromMinutes(1)).Until(
                d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));

            try
            {
                var homePage = HomePage.Create(driver);
                homePage.Search(driver, "жираф");
                adapter.SaveScreenShot(adapter.CreateScreenShot(), "C:\\images");
            }
            finally
            {
                driver.Quit();
            }
        }
    }
}
