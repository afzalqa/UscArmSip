using OpenQA.Selenium;

namespace UscArmSip
{
    public class ProfilePage : BaseUserData
    {
        public ProfilePage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        // Профиль // Специфические поля

        public IWebElement EmailPlaceholder => elements.GetElement(By.XPath("//input[@test-id='e-mail']/ancestor::div[1]/div"));
        public IWebElement CurrentPasswordInput => elements.GetElement(By.XPath("//input[@test-id='oldPassword']"));
        public IWebElement NewPasswordInput => elements.GetElement(By.XPath("//input[@test-id='password']"));

        // Профиль // Специфические валидации

        public IWebElement CurrentPasswordInputValidation => elements.GetElement(By.XPath("//*[@test-id='oldPassword_validation']")); 
        public IWebElement CurrentPasswordInputValidationToast => elements.GetElement(By.XPath("//div[@test-id='oldPassword_validation']//div[contains(@class, 'dx-invalid-message-content')]"));
        public IWebElement NewPasswordInputValidation => elements.GetElement(By.XPath("//*[@test-id='password_validation']")); 
    }
}
