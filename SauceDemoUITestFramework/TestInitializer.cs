using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace SauceDemoUITestFramework
{
    [Binding]
    public class TestInitializer
    {
        private IWebDriver _driver;
        private readonly IObjectContainer _container;

        public TestInitializer(IObjectContainer objectContainer)
        {
            _container = objectContainer;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            

            //Register the instance for page objects and scenarios
            _container.RegisterInstanceAs<IWebDriver>(_driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if(_driver != null)
            {
                _driver?.Quit();
                _driver?.Dispose();
            }
        }
    }
}