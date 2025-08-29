using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class CheckoutOverviewPage
    {
        private IWebDriver _driver;
        
        public CheckoutOverviewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ProductContainer =>
            _driver.FindElement(By.XPath("//*[@data-test='inventory-item']"));
        private IWebElement ProductName =>
           ProductContainer.FindElement(By.ClassName("inventory-item-name"));
        private IWebElement ProductQuantity =>
           ProductContainer.FindElement(By.XPath("//*[@data-test='item-quantity']"));
        private IWebElement ProductDescription =>
           ProductContainer.FindElement(By.ClassName("inventory_item_desc"));
        private IWebElement ProductPrice =>
           ProductContainer.FindElement(By.ClassName("inventory_item_price"));

        private IWebElement FinishBtn =>
            _driver.FindElement(By.Id("finish"));

        internal Product GetProductDetails()
        {
            string quantity = ProductQuantity.Text;

            Product product = new Product
            {
                Name = ProductName.Text,
                Price = ProductPrice.Text,
                Quantity = int.Parse(quantity)
            };

            return product;
        }

        internal void FinishTheOrder()
        {
            FinishBtn.Click();
        }
    }
}
