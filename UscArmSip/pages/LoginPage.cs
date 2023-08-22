using OpenQA.Selenium;

namespace UscArmSip
{
    public class LoginPage : PageBase
    {
        public LoginPage(IWebDriver driver, Elements elements) : base(driver, elements) { }

        public IWebElement LoginInput => elements.GetElement(By.XPath("//input[@test-id='login-input']"));
        public IWebElement LoginInputClearButton => elements.GetElement(By.XPath("(//span[@class='dx-icon dx-icon-clear'])[1]"));
        public IWebElement PasswordInput => elements.GetElement(By.XPath("//input[@test-id='password-input']"));
        public IWebElement PasswordInputClearButton => elements.GetElement(By.XPath("(//span[@class='dx-icon dx-icon-clear'])[2]"));
        public IWebElement EnterButton => elements.GetElement(By.XPath("//div[@test-id='login-button']"));
        public IWebElement ArmNameTitle => elements.GetElement(By.XPath("//div[@class='arm-title title' and text()='АРМ СИП']"));
    }
}
