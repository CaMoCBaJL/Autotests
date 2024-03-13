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
            if (!homePage.FirstPaintingContain(driver, "Жираф"))
            {
                var _ = adapter.CreateScreenShot();
            }
        }
    }
}
