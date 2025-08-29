using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class InventoryPage
    {
        private string _productName = string.Empty;

        private IWebDriver _driver;

        public InventoryPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ProductElement =>
          _driver.FindElement(By.XPath($"//*[@data-test='inventory-item-description' and .//text()='{_productName}']"));

        internal void GoTo()
        {
            throw new NotImplementedException();
        }

        internal Product GetProductDetails()
        {
            throw new NotImplementedException();
        }      

        internal Product SaveDetailsProduct(string productName)
        {
            IWebElement price = ProductElement.FindElement(By.XPath("*//@data-test='inventory-item-price'"));

            var product = new Product
            {
                Name = productName,
                Price = price.Text
            };

            return product;
        }

        internal void SelectProductByName(string productName)
        {
            _productName = productName;

            IWebElement addToCartBtn = ProductElement.FindElement(By.Id("add-to-cart-sauce-labs-backpack"));
            addToCartBtn.Click();
        }
    }
}
