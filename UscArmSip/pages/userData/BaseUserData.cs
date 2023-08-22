using OpenQA.Selenium;

namespace UscArmSip
{
    public class BaseUserData : PageBase
    {
        public BaseUserData(IWebDriver driver, Elements elements) : base(driver, elements) { }

        // Создание / Редактирование пользователя // Поля

        public IWebElement LoginInput => elements.GetElement(By.XPath("//input[@test-id='login']"));
        public IWebElement EmailInput => elements.GetElement(By.XPath("//input[@test-id='e-mail']"));
        public IWebElement LastNameInput => elements.GetElement(By.XPath("//input[@test-id='surname']"));
        public IWebElement FirstNameInput => elements.GetElement(By.XPath("//input[@test-id='firstName']"));
        public IWebElement MiddleNameInput => elements.GetElement(By.XPath("//input[@test-id='middleName']"));
        public IWebElement PasswordInput => elements.GetElement(By.XPath("//input[@test-id='password']"));
        public IWebElement ConfirmPasswordInput => elements.GetElement(By.XPath("//input[@test-id='confirmPassword']"));

        // Создание / Редактирование пользователя // Поля // Валидации

        public IWebElement LoginInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='login_validation']"));
        public IWebElement EmailInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='e-mail_validation']"));
        public IWebElement LastNameInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='surname_validation']"));
        public IWebElement FirstNameInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='firstName_validation']"));
        public IWebElement MiddleNameInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='middleName_validation']"));
        public IWebElement PasswordInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='password_validation']"));
        public IWebElement ConfirmPasswordInputValidation => elements.GetValidationMessage(By.XPath("//div[@test-id='confirmPassword_validation']"));

        // Создание / Редактирование пользователя // Включение в рассылку

        public IWebElement InMailListCheckbox => elements.GetElement(By.XPath("//div[@test-id='notify']"));
    }
}
