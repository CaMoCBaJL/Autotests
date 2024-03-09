using Autotests.PlatformAdapter.Shared.Entities;
using Autotests.Tests.ArtNow.Shared.Constants;
using Autotests.TestUnits.Web;
using OpenQA.Selenium;

namespace Autotests.Tests.ArtNow.Pages
{
    public class CatalogsPage: WebPage
    {
        protected override void CreatePageContent()
        {
            base.CreatePageContent();

            //_pageElements.Add(ElementCssRules.SearchBar, new DomElement() { InitializerFunction = FindSearchBar });
            //_pageElements.Add(ElementCssRules.InputSearchBar, new DomElement() { InitializerFunction = FindSearchBarInput });
            //_pageElements.Add(ElementCssRules.LeftShellNavigation, new DomElement() { InitializerFunction = FindArtTypesList });
            //_pageElements.Add(ElementCssRules.ContentContainer, new DomElement() { InitializerFunction = FindPaintingsContainer });
            //_pageElements.Add(ElementCssRules.SearchButton, new DomElement() { InitializerFunction = FindSearchButton });
            //_pageElements.Add(ElementNames.CatalogButton, new DomElement() { InitializerFunction = FindCatalogButton });
        }

        public static new CatalogsPage Create(IWebDriver webDriver)
        {
            var catalogsPage = new CatalogsPage();

            catalogsPage.CreatePageContent();
            catalogsPage.ValidatePageContent();
            catalogsPage.InitializePageContent(webDriver);

            return catalogsPage;
        }
    }
}
