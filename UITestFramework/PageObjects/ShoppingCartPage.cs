using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class ShoppingCartPage
    {
        private readonly IWebDriver _driver;

        public ShoppingCartPage(IWebDriver driver)
        {
            _driver = driver;
        }

        
        private IWebElement ProductName => 
            _driver.FindElement(By.Id("item_0_title_link"));
        private IWebElement ProductPrice => 
            _driver.FindElement(By.XPath("//*[@data-test='inventory-item-price']"));
        private IWebElement ShoppingCartLink =>
            _driver.FindElement(By.XPath("//*[@id='shopping_cart_container']/a"));

        internal void GoTo()
        {
            ShoppingCartLink.Click();
        }
        
       

        internal Product GetProductDetails()
        {
            var product = new Product
            {
                Name = ProductName.Text.Trim(),
                Price = ProductPrice.Text.Trim(),
                Quantity = 1 //TODO: this is mock for running out of time
            }; 
            return product;
        }        
    }
}
