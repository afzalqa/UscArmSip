using OpenQA.Selenium;

namespace UscArmSip
{
    public class Ui : PageBase
    {
        public Ui(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement HamburgerMenuButton => elements.GetElement(By.XPath("//div[@test-id='menu-toggle-button']"));
        public IWebElement PortalSectionButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-requests-portal']"));
        public IWebElement CabinetSectionButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-requests-cabinet']"));
        public IWebElement CallCenterSectionButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-requests-callCenter']"));
        public IWebElement SocialNetworkSectionButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-requests-socialNet']"));
        public IWebElement AdministrationButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-administration']"));
        public IWebElement ReportsButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-report']"));
        public IWebElement ProfileButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-profile']"));
        public IWebElement ExitButton => elements.GetElement(By.XPath("//a[@test-id='menuitem-logout']"));
        public IWebElement Toast => elements.GetElement(By.XPath("//div[@class='dx-toast-message']"));
        public IWebElement GetBackButton => elements.GetElement(By.XPath("//*[@test-id='go-back-header-button']"));
    }
}