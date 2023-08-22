using FluentAssertions;
using NUnit.Framework;

namespace UscArmSip
{
    public class LoginHelper : BaseHelper
    {
        [SetUp]
        public void Starters()
        {
            driver.Navigate().Refresh();
        }

        [TearDown]
        public void Closers()
        {
            if (navigation.LoggedIn())
            {
                navigation.Logout();
            }           
        }

        protected void NegativeLogin(
            string login = null,
            string password = null,
            string expectedValidation = null)
        {
            if (login is not null)
            {
                pages.login.LoginInput.SendText(login);
            }

            if (password is not null)
            {
                pages.login.PasswordInput.SendText(password);
            }
                
            pages.login.EnterButton.Click();

            if (expectedValidation is not null)
            {
                pages.ui.Toast.GetText().Should().Be(expectedValidation);
            }           
        }

        protected void NegativeLogin(UserData user, string validation)
        {
            pages.login.LoginInput.SendText(user.Login);
            pages.login.PasswordInput.SendText(user.Password);
            pages.login.EnterButton.Click();
            pages.ui.Toast.GetText().Should().Be(validation);
        }
    }
}