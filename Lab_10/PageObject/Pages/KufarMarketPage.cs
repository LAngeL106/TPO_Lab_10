using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class KufarMarketPage : AbstractPage
    {
        public KufarMarketPage(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _addToCartButton = By.XPath("//div[@class='styles_adViewContainer__NlMUv']/button");
        private readonly By _goToCartButton = By.XPath("//a[@data-cy='navigate_to_cart_button']");

        public void AddToCart()
        {
            Thread.Sleep(13000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_addToCartButton));
            driver.FindElement(_addToCartButton).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_addToCartButton));
            driver.FindElement(_addToCartButton).Click();
        }
        public void GoToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_goToCartButton));
            driver.FindElement(_goToCartButton).Click();
        }

    }
}
