using OpenQA.Selenium;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class PurchaseCompletePage
    {
        private IWebDriver _driver;

        public PurchaseCompletePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement CheckoutCompleteContainer =>
            _driver.FindElement(By.Id("checkout_complete_container"));

        internal string GetMessage()
        {
            return CheckoutCompleteContainer.Text;
        }
    }
}
