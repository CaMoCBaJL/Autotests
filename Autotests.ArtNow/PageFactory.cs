﻿using OpenQA.Selenium;

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

        public CatalogsPage CreateCatalogsPage()
        {
            return CatalogsPage.Create(_driver);
        }

        public EmbroidedPaintingsPage CreateEmbroidedPainitingsPage()
        {
            return EmbroidedPaintingsPage.Create(_driver);
        }

        public PaintingDetailsPage CreatePaintingDetailsPage()
        {
            return PaintingDetailsPage.Create(_driver);
        }

        public BatikPaintingsPage CreateBatikPaintingsPage()
        {
            return BatikPaintingsPage.Create(_driver);
        }

        public FavoritePaintingsPage CreateFavoritePaintingsPage()
        {
            return FavoritePaintingsPage.Create(_driver);
        }

        public JewerlyPage CreateJewerlyPage()
        {
            return JewerlyPage.Create(_driver);
        }

        public CartPage CreateCartPage()
        {
            return CartPage.Create(_driver);
        }
    }
}
