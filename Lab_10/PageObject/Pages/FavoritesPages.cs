using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;

namespace Lab10.Pages
{
    public class FavoritesPage : AbstractPage
    {
        public FavoritesPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _favoriteProductName = By.XPath("//div[@class='details']/div[@class='information']/div[@class='description']/a");

        public string GetFavoriteProductName()
        {
            Thread.Sleep(5000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_favoriteProductName));
            IWebElement FavoriteProductName = driver.FindElement(_favoriteProductName);
            return FavoriteProductName.Text;
        }
    }
}
