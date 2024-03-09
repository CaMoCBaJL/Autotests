using Autotests.PlatformAdapter.Web;
using Autotests.Tests.ArtNow.Pages;

namespace Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var adapter = new BrowserAdapter("https://artnow.ru/");
            adapter.InitializeBrowser(Autotests.PlatformAdapter.Shared.Enums.BrowserType.Mozila_Filerfox);
            var driver = adapter.WebDriver;

            adapter.OpenUrl();

            var homePage = HomePage.Create(driver);
            homePage.Search(driver, "Жираф");
            if (!homePage.AnyPaintingContain(driver, "Жираф"))
                adapter.SaveScreenShot(adapter.CreateScreenShot(), "C:\\images\\1.png");
        }
    }
}
