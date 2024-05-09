using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class LoginPage : AbstractPage
    {
        public LoginPage(IWebDriver webDriver) : base(webDriver) { }


        private readonly By _loginField = By.XPath("//*[@id='modal']/div/div/div[2]/div/input");
        private readonly By _passwordField = By.XPath("//*[@id='modal']/div/div/div[3]/div/input");
        private readonly By _checkboxConfPolicy = By.XPath("//*[@id='modal']/div/div/div[4]/div/div/div");
        private readonly By _signInSubmitButton = By.XPath("//button[text()='Войти']");
        //private readonly By _signInSubmitButton = By.XPath("//form[@data-name='form_login']/div[5]/button");


        public void Login(string[] user)
        {
            Thread.Sleep(1000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_loginField));
            driver.FindElement(_loginField).SendKeys(user[0]);
            wait.Until(ExpectedConditions.ElementIsVisible(_passwordField));
            driver.FindElement(_passwordField).SendKeys(user[1]);
            wait.Until(ExpectedConditions.ElementIsVisible(_checkboxConfPolicy));
            driver.FindElement(_checkboxConfPolicy).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_signInSubmitButton));
            driver.FindElement(_signInSubmitButton).Click();

        }
    }
}
