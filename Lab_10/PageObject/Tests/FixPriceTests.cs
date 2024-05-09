using Lab10.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge;

namespace Lab10
{
    public class FixPriceTests
    {
        IWebDriver? driver;

        FixPricePage fixPricePage;
        LoginPage loginPage;
        FavoritesPage favoritesPage;
        CartPage cartPage;
        KufarMarketPage kufarMarketPage;

        Data data;
        string? productName;
        private string[] user;

        public FixPriceTests()
        {
            data = new Data();
            user = new string[] { data.login, data.password };
        }

        [SetUp]
        public void Init()
        {
            if (driver == null)
            {
                driver = new EdgeDriver();
            }
            driver.Manage().Window.Maximize();
            fixPricePage = new FixPricePage(driver);
            loginPage = new LoginPage(driver);
            favoritesPage = new FavoritesPage(driver);
            cartPage = new CartPage(driver);
            kufarMarketPage = new KufarMarketPage(driver);
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
            driver = null;
        }

        [Test]
        public void AddItemToFavorite()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.AuthorizeUser(user, loginPage);
            productName = fixPricePage.ClickFirstProduct();
            fixPricePage.LikeProduct();
            fixPricePage.ClickProfileFavorites();
            Assert.IsTrue(favoritesPage.GetFavoriteProductName() == productName);
        }

        [Test]
        public void AddProductToCart()
        {
            fixPricePage.GoToMainPage();
            fixPricePage.AuthorizeUser(user, loginPage);
            productName = fixPricePage.AddToCartFirstProductCard();
            fixPricePage.GoToCart();
            Assert.IsTrue(cartPage.GetBusketProductName() == productName);
        }

    }
}
