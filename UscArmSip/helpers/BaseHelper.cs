using NUnit.Framework;
using OpenQA.Selenium;

namespace UscArmSip
{
    public class BaseHelper
    {
        protected IWebDriver driver;
        protected Pages pages;
        protected Navigation navigation;
        protected Elements elements;

        private Manager _manager;

        [OneTimeSetUp]
        public void Setup()
        {
            _manager = new Manager();

            driver = _manager.driver;
            pages = _manager.pages;
            navigation = _manager.navigation;
            elements = _manager.elements;

            driver.Navigate().UscArmSip();
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            _manager.Dispose();
        }
    }
}