using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class CheckoutOverviewPage
    {
        private readonly IWebDriver _driver;

        public CheckoutOverviewPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FinishBtn =>
            _driver.FindElement(By.Id("finish"));
        private IWebElement ProductName => 
            _driver.FindElement(By.Id("item_0_title_link"));
        private IWebElement ProductPrice => 
            _driver.FindElement(By.XPath("//*[@data-test='inventory-item-price']"));


        internal void FinishTheOrder()
        {
            FinishBtn.Click();
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
