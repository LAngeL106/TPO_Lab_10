using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace Lab10
{
    public class FixPricePage : AbstractPage
    {
        Data data = new Data();
        public FixPricePage(IWebDriver webDriver) : base(webDriver) { }

        private readonly By _firstAdButton = By.XPath("//div[@id='modal']/div");
        private readonly By _secondAdButton = By.XPath("//*[text()='Закрыть']");
        private readonly By _signInButton = By.XPath("//*[text()='Войти']");
        private readonly By _profileSettingsButton = By.XPath("//*[@id=\"app-header\"]/header/div/div/div[2]/div[6]/div/div/nav/a[4]/div");
        private readonly By _profileFavoritesButton = By.XPath("//*[text()='Избранное']");
        //private readonly By _firstProductCard = By.XPath("//div[@class='slider']/div/div/div/div");
        private readonly By _firstProductCard = By.XPath("//*[text()='В корзину']");
        private readonly By _firstProductCardName = By.XPath("//div[@class='slider']/div/div/div/div/div[3]/div/div/a");
        private readonly By _likeButton = By.XPath("//*[text()='В избранное']");
        private readonly By _showAnnouncementsButton = By.XPath("//button[@data-name='filter-submit-button']");
        private readonly By _placeAnAdButton = By.XPath("//div[@data-name='add-item-button']");
        private readonly By _acceptAllCookiesButton = By.XPath("//button[text()='Принять все файлы cookie']");
        private readonly By _chooseStore = By.XPath("//div[@class='description' and text() = 'Выберите магазин получения']");
        private readonly By _favoriteAdresses = By.XPath("//*[text()='Избранные адреса']");
        private readonly By _chooseFavoriteAdressButton = By.XPath("//button[text()='Выбрать']");
        private readonly By _productModalWindow = By.XPath("//div[@id='modal']/div/button[@class='close']");
        private readonly By _goToCartIcon = By.XPath("//div[contains(@class, 'categories-wrapper') and contains(@class, 'categories')]/a[2]/div[contains(@class, 'icon-wrapper size-small')]");
        private readonly By _searchField = By.XPath("//*[@id=\"app-header\"]/header/div/div/div[2]/div[4]/div[2]/form/input\r\n");
        private readonly By _inputSearchField = By.XPath("//*[@id=\"app-header\"]/header/div/div/div[2]/div[4]/div[2]/form/input\r\n");
        private readonly By _searchButton = By.XPath("//*[@id='app-header']/header/div/div/div[2]/div[4]/div[2]/form/a/i");
        private readonly By _profileButton = By.XPath("//*[@id=\"app-header\"]/header/div/div/div[2]/div[6]/div/a/span");



        public void AuthorizeUser(string[] user, LoginPage loginPage)
        {
            ClosingPolicyAndAdvertisingWindows();
            ClickSignInButton();
            loginPage.Login(user);
            AccepsAllCookies();
        }

        public void GoToMainPage()
        {
            driver.Navigate().GoToUrl(data.url);
        }
        public void ClosingPolicyAndAdvertisingWindows()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementIsVisible(_firstAdButton));
            acceptButton.Click();
        }
        public void AccepsAllCookies()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            IWebElement acceptButton = wait.Until(ExpectedConditions.ElementToBeClickable(_acceptAllCookiesButton));
            Thread.Sleep(3000);
            acceptButton.Click();
        }
        

        public string GetBirthDateError()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_firstProductCardName));
            IWebElement spanElement = driver.FindElement(_firstProductCardName);
            return spanElement.Text;
        }
       

        public string AddToCartFirstProductCard()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_chooseStore));
            driver.FindElement(_chooseStore).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_favoriteAdresses));
            driver.FindElement(_favoriteAdresses).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_chooseFavoriteAdressButton));
            driver.FindElement(_chooseFavoriteAdressButton).Click();
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 900);");
            IWebElement Element = driver.FindElement(_firstProductCardName);
            string ElementText = Element.Text;
            wait.Until(ExpectedConditions.ElementIsVisible(_firstProductCard));
            wait.Until(ExpectedConditions.ElementToBeClickable(_firstProductCard));
            Thread.Sleep(3000);
            driver.FindElement(_firstProductCard).Click();
            wait.Until(ExpectedConditions.ElementIsVisible(_productModalWindow));
            driver.FindElement(_productModalWindow).Click();

            return ElementText;
        }
        
        public string ClickFirstProduct()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            Thread.Sleep(5000);
            ((IJavaScriptExecutor)driver).ExecuteScript("window.scrollBy(0, 900);");
            IWebElement Element = driver.FindElement(_firstProductCardName);
            string ElementText = Element.Text;
            wait.Until(ExpectedConditions.ElementIsVisible(_firstProductCard));
            wait.Until(ExpectedConditions.ElementToBeClickable(_firstProductCard));
            Thread.Sleep(3000);
            driver.FindElement(_firstProductCardName).Click();
            //wait.Until(ExpectedConditions.ElementIsVisible(_productModalWindow));
            //driver.FindElement(_productModalWindow).Click();

            return ElementText;
        }

        public void GoToCart()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_goToCartIcon));
            driver.FindElement(_goToCartIcon).Click();
        }

        public void LikeProduct()
        {
            Thread.Sleep(6000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_likeButton));
            driver.FindElement(_likeButton).Click();
        }
        public void ShowAnnouncements()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_showAnnouncementsButton));
            driver.FindElement(_showAnnouncementsButton).Click();
        }
        
        public void ClickProfileSettings()
        {
            Actions actions = new Actions(driver);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileButton));
            IWebElement menu = driver.FindElement(_profileButton);
            actions.MoveToElement(menu).Perform();
            wait.Until(ExpectedConditions.ElementIsVisible(_profileSettingsButton));
            IWebElement submenu = driver.FindElement(_profileSettingsButton);
            actions.MoveToElement(submenu).Click().Perform();
        }
        
        public void ClickProfileFavorites()
        {
            Thread.Sleep(6000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_profileFavoritesButton));
            driver.FindElement(_profileFavoritesButton).Click();
        }

        public void ClickSignInButton()
        {
            Thread.Sleep(3000);
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_signInButton));
            driver.FindElement(_signInButton).Click();
        }

        public void ClickSearchField()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchField));
            driver.FindElement(_searchField).Click();
        }

        public void EnteringValueInSearchEngine()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_inputSearchField));
            driver.FindElement(_inputSearchField).SendKeys(data.searchString);
        }

        public void ClickButtonSearch()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(_searchButton));
            driver.FindElement(_searchButton).Click();
        }

    }
}
