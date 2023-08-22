using FluentAssertions;
using OpenQA.Selenium;

namespace UscArmSip
{
    public class Navigation
    {
        public Navigation(Pages pages) => _pages = pages;

        private readonly Pages _pages;

        public void Login(IUserData user)
        {
            _pages.login.LoginInput.SendText(user.Login);
            _pages.login.PasswordInput.SendText(user.Password);
            _pages.login.EnterButton.Click();

            LoggedIn().Should().BeTrue();
        }

        public bool LoggedIn()
        {
            try
            {
                _pages.ui.ProfileButton.IsPresent();
                _pages.ui.ExitButton.IsPresent();
                return true;
            }
            catch (Exception ex) when (
            ex is NoSuchElementException ||
            ex is WebDriverTimeoutException)
            {
                return false;
            }
        }

        public void Logout() 
        {
            _pages.ui.ExitButton.Click();
            _pages.login.EnterButton.IsPresent();
            _pages.login.ArmNameTitle.IsPresent();
        }    
    }
}
