using OpenQA.Selenium;

namespace UscArmSip
{
    public class SocialNetworksSectionPage : BaseSections
    {
        public SocialNetworksSectionPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement NewRequestButton => elements.GetElement(By.XPath("//div[@test-id='new-request-button']"));
    }
}