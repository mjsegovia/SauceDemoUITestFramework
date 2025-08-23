using OpenQA.Selenium;
using SauceDemoUITestFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class ShippingInformationPage
    {
        private IWebDriver _driver;

        public ShippingInformationPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement FirstNameInput => _driver.FindElement(By.Id("first-name"));
        private IWebElement LastNameInput => _driver.FindElement(By.Id("last-name"));
        private IWebElement PostalCodeInput => _driver.FindElement(By.Id("postal-code")); 
        private IWebElement ContinueBtn => _driver.FindElement(By.Id("continue"));


        internal void AddShippingInformation(ShippingInfo info)
        {
            FirstNameInput.SendKeys(info.FirstName);
            LastNameInput.SendKeys(info.LastName);
            PostalCodeInput.SendKeys(info.PostalCode);
        }

        internal void ContinueNextStep()
        {
            ContinueBtn.Click();
            Thread.Sleep(1000); //TODO: this should be made by a waiter helper class
        }
    }
}
