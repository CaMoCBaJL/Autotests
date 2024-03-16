﻿using Autotests.PlatformAdapter.Web;
using NUnit.Allure.Core;
using Allure.Net.Commons;
using Autotests.ArtNow.Pages;

namespace Tests
{
    [AllureNUnit]
    public class HomePageTest
    {
        [Test]
        public void FindGiraffeUseCase()
        {
            using (var adapter = new BrowserAdapter("https://artnow.ru/"))
            {
                adapter.InitializeBrowser(Autotests.PlatformAdapter.Shared.Enums.BrowserType.Mozila_Filerfox);
                var driver = adapter.WebDriver;

                adapter.OpenUrl();

                var homePage = new PageFactory(adapter.WebDriver).CreateHomePage();
                homePage.Search(driver, "Жираф");
                if (!homePage.FirstPaintingContain(driver, "Жираф"))
                {
                    AllureApi.AddAttachment("image1.png", "image/png", adapter.CreateScreenShot().AsByteArray);
                    Assert.Fail();
                }
            }
        }

        [TearDown]
        public void OnTestTearDown()
        {
            //how to generate and serve allure report
            //open ps
            //cd .\Autotests\Tests\bin\Debug\net8.0
            //allure generate
            //allure serve
        }
    }
}