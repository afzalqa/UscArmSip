using OpenQA.Selenium;

namespace UscArmSip
{
    public class PortalSectionPage : BaseSections
    {
        public PortalSectionPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement AnswerRequiredCheckbox => elements.GetElement(By.XPath("//*[@test-id='answer-required']/div"));
    }
}