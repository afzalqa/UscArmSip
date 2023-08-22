using OpenQA.Selenium;

namespace UscArmSip
{
    public class AdministrationPage : BaseUserData
    {
        public AdministrationPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        // Создание пользователя // Чекбоксы ролей

        public IWebElement PortalOperatorRoleCheckbox => elements.GetElement(By.XPath("//div[@test-id='operatorPortal']"));
        public IWebElement PersonalCabinetOperatorRoleCheckbox => elements.GetElement(By.XPath("//div[@test-id='operatorLk']"));
        public IWebElement CallCenterOperatorRoleCheckbox => elements.GetElement(By.XPath("//div[@test-id='operatorCallCenter']"));
        public IWebElement SocialNetworksOperatorRoleCheckbox => elements.GetElement(By.XPath("//div[@test-id='operatorSocNet']"));
        public IWebElement AdministratorRoleCheckbox => elements.GetElement(By.XPath("//div[@test-id='isAdmin']"));
        public IWebElement BlockedCheckbox => elements.GetElement(By.XPath("//div[@test-id='isBlocked']"));

        // Создание пользователя // Кнопки

        public IWebElement CreateUserButton => elements.GetElement(By.XPath("//div[@test-id='add-user-button']"));
        public IWebElement SaveButton => elements.GetElement(By.XPath("//div[@test-id='confirm-button']"));
        public IWebElement CancelButton => elements.GetElement(By.XPath("//div[@test-id='cancel-button']"));

        // Поля поиска

        public IWebElement ColumnNumberSearchInput => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-1']//input[@aria-label]"));
        public IWebElement LastNameFirstNameMiddleNameColumnSearchInput => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-2']//input[@aria-label]"));

        // Дропдауны

        public IWebElement PortalOperatorColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-3']//input[@aria-label]"));
        public IWebElement PersonalCabinetColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-4']//input[@aria-label]"));
        public IWebElement CallCenterOperatorColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-5']//input[@aria-label]"));
        public IWebElement SocialNetworksOperatorColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-6']//input[@aria-label]"));
        public IWebElement AdminColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-7']//input[@aria-label]"));
        public IWebElement BlockedColumnDropdown => elements.GetElement(By.XPath("//td[@aria-describedby='dx-col-8']//input[@aria-label]"));
    }
}
