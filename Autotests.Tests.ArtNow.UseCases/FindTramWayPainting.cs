using Autotests.Tests.ArtNow.Pages;
using OpenQA.Selenium;
using UseCases;

namespace Autotests.Tests.ArtNow.UseCases
{
    public class FindTraimWayPainting : UseCase
    {
        public FindTraimWayPainting(
            IWebDriver webDriver
            ) 
        {
            Page = new PageFactory(webDriver).CreateHomePage();
        }

        public override bool Act()
        {
            throw new NotImplementedException();
        }

        public override void Initialize()
        {
            throw new NotImplementedException();
        }

        public override void SetupExpectations()
        {
            throw new NotImplementedException();
        }
    }
}
