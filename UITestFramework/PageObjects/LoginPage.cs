using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemoUITestFramework.PageObjects
{
    internal class LoginPage
    {
        private IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement UserName => 
            _driver.FindElement(By.Id("user-name"));

        private IWebElement LoginBtn =>
            _driver.FindElement(By.Id("login-button"));

        private IWebElement Password =>
            _driver.FindElement(By.Id("login-button"));


        internal void GoTo()
        {
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");
        }

        internal void UserLogsIn(string username, string password)
        {
            UserName.SendKeys(username);
            Thread.Sleep(1000); //TODO: Add waiter helper class
            Password.SendKeys(password);
            LoginBtn.SendKeys(username);
        }
    }
}
