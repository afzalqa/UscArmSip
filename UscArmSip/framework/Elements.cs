using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace UscArmSip
{
    public class Elements
    {
        public Elements(IWebDriver driver) => _driver = driver;

        private readonly IWebDriver _driver;

        public IWebElement GetElement(By by)
        {
            try
            {
                return MoveToElement(_driver.WaitForElementBeforeGettingIt(by));
            }
            catch (Exception ex) when (
            ex is NoSuchElementException ||
            ex is WebDriverTimeoutException)
            {
                return null;
            }
        }

        public IWebElement GetValidationMessage(By by)
        {
            return _driver.WaitForValidationElementToBeFilledWithText(by);
        }

        public IWebElement MoveToElement(IWebElement element)
        {
            Actions actions = new(_driver);
            actions.MoveToElement(element).Perform();
            actions.Perform();
            return element;
        }
    }
}
