using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using System.Xml.Linq;


namespace Lab10.Pages
{
    public class ProfileSettingsPage : AbstractPage
    {
        public ProfileSettingsPage(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _notificationSwither1 = By.XPath("//*[@id=\"__layout\"]/div/div/div[3]/div/div/div/div[2]/div[2]/div/div[7]/div[2]/div[1]/div[1]");
        private readonly By _notificationSwither2 = By.XPath("//*[@id=\"__layout\"]/div/div/div[3]/div/div/div/div[2]/div[2]/div/div[7]/div[2]/div[2]/div[1]");

        public string[] FindAndDisableNotificationsSettings()
        {
            Thread.Sleep(2000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 500);");
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_notificationSwither1)).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_notificationSwither2)).Click();
            Thread.Sleep(3000);
            IWebElement element1 = driver.FindElement(_notificationSwither1);
            IWebElement element2 = driver.FindElement(_notificationSwither1);
            string classAttribute1 = element1.GetAttribute("class");
            string classAttribute2 = element2.GetAttribute("class");
            string[] arr = { classAttribute1, classAttribute2 };
            return arr;
        }
    }
}
