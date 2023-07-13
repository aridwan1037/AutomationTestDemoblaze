using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTest.PageContent
{
    public class HomePage
    {
        private IWebDriver driver;
        private By loginButton = By.Id("login2");
        private By addToCartButton = By.XPath("//h5[contains(text(), 'Samsung Galaxy S21')]/following-sibling::a");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void NavigateTo()
        {
            driver.Navigate().GoToUrl("https://www.demoblaze.com/");
        }

        public void ClickLoginButton()
        {
            WaitAndClick(loginButton);
        }

        public void ProductDetail(string itemName)
        {
            By addToCartButtonForItem = By.XPath($"//*[@id=\"tbodyid\"]/div[1]/div/div/h4/a");

            bool isAddedToCart = false;
            int retries = 3;

            while (!isAddedToCart && retries > 0)
            {
                try
                {
                    WaitAndClick(addToCartButtonForItem);
                    isAddedToCart = true;
                }
                catch (StaleElementReferenceException)
                {
                    retries--;
                }
            }
        }
        public void AddToCart(string itemName)
        {
            By addToCart = By.XPath($"//*[@id=\"tbodyid\"]/div[2]/div/a");
            WaitAndClick(addToCart);
        }

        public void GoToCart()
        {
            WaitAndClick(By.LinkText("Cart"));
        }

        private void WaitAndClick(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }
    }
}