using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V137.Network;
using SauceDemoUITestFramework.Models;
using SauceDemoUITestFramework.PageObjects;
using System;
using System.ComponentModel.Design;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace SauceDemoUITestFramework.Tests.StepsDefinitions
{
    [Binding]
    public class ShoppingCartStepDefinitions
    {
        private readonly ScenarioContext _scenarioContext;
        private LoginPage _loginPage;
        private ProductPage _productPage;
        private purchaseCompletePage _purchaseCompletePage;
        private ShoppingCartPage _shoppingCartPage;
        private ShippingInformationPage _shippingInformationPage;
        private CheckoutOverviewPage _checkoutOverviewPage;

        public ShoppingCartStepDefinitions(IWebDriver driver, ScenarioContext context)
        {
            _scenarioContext = context;
            _loginPage = new LoginPage(driver);
            _productPage = new ProductPage(driver);
            _purchaseCompletePage = new purchaseCompletePage(driver);
            _shoppingCartPage = new ShoppingCartPage(driver);   
            _shippingInformationPage = new ShippingInformationPage(driver);

        }

        [Given(@"My usernme is '(.*)'")]
        public void GivenMyUsernmeIs(string username)
        {
            _scenarioContext.Add("username", username);
        }
       
        [Given(@"my password is '(.*)'")]
        public void GivenMyPasswordIs(string password)
        {
            _scenarioContext.Add("password", password);
        }

        [Given(@"I am already login in my user account")]
        public void GivenIAmAlreadyLoginInMyUserAccount()
        {
            string username = _scenarioContext.Get<string>("username");
            string password = _scenarioContext.Get<string>("password");

            _loginPage.GoTo();
            _loginPage.UserLogsIn(username, password);
        }

        [When(@"I add to the cart the item '(.*)'")]
        public void WhenIAddToTheCartTheItem(string productName)
        {
            _productPage.SelectProductByName(productName);
            Product product = _productPage.SaveDetailsProduct(productName);

            _scenarioContext.Add("product", product);            
        }

        [When(@"I go the shopping cart")]
        public void WhenICheckoutTheItem()
        {
            _shoppingCartPage.GoTo();
        }

        [When(@"My product is in the cart")]
        public void WhenMyProductIsInTheCart()
        {
            Product productExpected =  _scenarioContext.Get<Product>("product");
            Product cartProduct = _shoppingCartPage.GetProductDetails();

            cartProduct.Should().BeEquivalentTo(productExpected);
        }


        [When(@"I enter my shipping information")]
        public void WhenIEnterMyShippingInformation(Table shippingInformation)
        {
            ShippingInfo info = shippingInformation.CreateInstance<ShippingInfo>();

            _shippingInformationPage.AddShippingInformation(info);
            _shippingInformationPage.ContinueNextStep();
        }

        [Then(@"I should see the checkout overview has my purchase correctly")]
        public void ThenIShouldSeeTheCheckoutOverviewHasMyPurchaseCorrectly()
        {
            Product productExpected = _scenarioContext.Get<Product>("product");
            Product cartProduct = _checkoutOverviewPage.GetProductDetails();

            cartProduct.Should().BeEquivalentTo(productExpected);
        }


        [Then(@"I comfirm the order")]
        public void ThenIComfirmTheOrder()
        {
            _checkoutOverviewPage.FinishTheOrder();
        }       

        [Then(@"I should see the confirmation of the purchase '(.*)'")]
        public void ThenIShouldSeeTheConfirmationOfMyOrder(string messageExpected)
        {
            string message = _purchaseCompletePage.GetMessage();
            
            message.Should().Be(messageExpected);
        }
    }
}
