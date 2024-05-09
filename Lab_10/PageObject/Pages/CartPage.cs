using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;


namespace Lab10.Pages
{
    public class CartPage : AbstractPage
    {
        public CartPage(IWebDriver webDriver) : base(webDriver) { }
        
        private readonly By _cartProductName = By.XPath("//div[@class='item']/div[@class='details']/div[@class='info']/button/span");

        public string GetBusketProductName()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_cartProductName));
            IWebElement BusketProductName = driver.FindElement(_cartProductName);
            return BusketProductName.Text;
        }
    }
}
