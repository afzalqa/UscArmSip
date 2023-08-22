using OpenQA.Selenium;

namespace UscArmSip
{
    public class CabinetSectionPage : BaseSections
    {
        public CabinetSectionPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement CardStatus => elements.GetElement(By.XPath("//div[@test-id='card-status']"));
        public IWebElement RequestTab => elements.GetElement(By.XPath("//span[text()='Обращение']"));
        public IWebElement HistoryTab => elements.GetElement(By.XPath("//span[text()='Дополнительно']"));
        public IWebElement AdditionalInfoTab => elements.GetElement(By.XPath("//div[@test-id='card-status']"));
    }
}
