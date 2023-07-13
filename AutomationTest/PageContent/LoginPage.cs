using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTest.PageContent
{
    public class LoginPage
    {
        private IWebDriver driver;
        private By usernameField = By.Id("loginusername");
        private By passwordField = By.Id("loginpassword");
        private By loginButton = By.XPath("//button[contains(text(), 'Log in')]");

        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Login(string username, string password)
        {
            WaitAndSendKeys(usernameField, username);
            WaitAndSendKeys(passwordField, password);
            WaitAndClick(loginButton);
        }

        private void WaitAndSendKeys(By locator, string text)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).SendKeys(text);
        }

        private void WaitAndClick(By locator)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(driver => driver.FindElement(locator).Displayed);
            driver.FindElement(locator).Click();
        }
    }
}