using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class ProductPage
    {
        private IWebDriver _driver;
        private string _productName = string.Empty;

        public ProductPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement ProductElement => 
            _driver.FindElement(By.XPath($"//*[@data-test='inventory-item-description' and .//text()='{_productName}']"));

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
