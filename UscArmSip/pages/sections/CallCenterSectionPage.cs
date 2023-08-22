using OpenQA.Selenium;

namespace UscArmSip
{
    public class CallCenterSectionPage : BaseSections
    {
        public CallCenterSectionPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement NewRequestButton => elements.GetElement(By.XPath("//div[@test-id='new-request-button']"));
    }
}