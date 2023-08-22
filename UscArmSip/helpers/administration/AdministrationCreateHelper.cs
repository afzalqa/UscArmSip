using NUnit.Framework;

namespace UscArmSip
{
    public class AdministrationCreateHelper : BaseUserDataHelper
    {
        [SetUp]
        public void Starters()
        {
            if (navigation.LoggedIn())
            {
                navigation.Logout();
            }

            navigation.Login(User.Administrator);
            pages.ui.AdministrationButton.Click();
        }

        [TearDown]
        public void Closers()
        {
            driver.Navigate().Refresh();
            navigation.Logout();
        }

        protected UserData CreateUser(UserData data)
        {
            pages.administration.CreateUserButton.Click();
            FillForm(data);
            pages.administration.SaveButton.Click();
            return data;
        }

        protected void FillForm(UserData data)
        {
            pages.administration.LoginInput.SendText(data.Login);
            pages.administration.EmailInput.SendText(data.Email);
            pages.administration.FirstNameInput.SendText(data.FirstName);
            pages.administration.LastNameInput.SendText(data.LastName);
            pages.administration.MiddleNameInput.SendText(data.MiddleName);

            FillPassword(data);
            SelectRoles(data);
            SelectMailingStatus(data);
        }

        private void FillPassword(UserData data)
        {
            if (data.Password is not null)
            {
                pages.administration.PasswordInput.SendText(data.Password);
                pages.administration.ConfirmPasswordInput.SendText(data.Password);
            }
            else if (
                data.Password is not null &&
                data.ConfirmPassword is not null)
            {
                pages.administration.PasswordInput.SendText(data.Password);
                pages.administration.ConfirmPasswordInput.SendText(data.ConfirmPassword);
            }
        }
    }
}