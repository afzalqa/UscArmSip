using FluentAssertions;
using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class LoginTests : LoginHelper
    {
        // АВТОРИЗАЦИЯ // ПОЗИТИВНЫЕ

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Администратор")]
        public void LoginAsAdministator()
        {
            navigation.Login(User.Administrator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsPresent();
            pages.ui.CallCenterSectionButton.IsPresent();
            pages.ui.SocialNetworkSectionButton.IsPresent();
            pages.ui.AdministrationButton.IsPresent();
            pages.ui.ReportsButton.IsPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор ЛК")]
        public void LoginAsPersonalCabinetOperator()
        {
            navigation.Login(User.CabinetOperator);

            pages.ui.PortalSectionButton.IsNotPresent();
            pages.ui.CabinetSectionButton.IsPresent();
            pages.ui.CallCenterSectionButton.IsNotPresent();
            pages.ui.SocialNetworkSectionButton.IsNotPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор соц сетей")]
        public void LoginAsSocialNetworksOperator()
        {
            navigation.Login(User.SocialNetworksOperator);

            pages.ui.PortalSectionButton.IsNotPresent();
            pages.ui.CabinetSectionButton.IsNotPresent();
            pages.ui.CallCenterSectionButton.IsNotPresent();
            pages.ui.SocialNetworkSectionButton.IsPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор колл-центра")]
        public void LoginAsCallCetnerOperator()
        {
            navigation.Login(User.CallCenterOperator);

            pages.ui.PortalSectionButton.IsNotPresent();
            pages.ui.CabinetSectionButton.IsNotPresent();
            pages.ui.CallCenterSectionButton.IsPresent();
            pages.ui.SocialNetworkSectionButton.IsNotPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор портала")]
        public void LoginAsPortalSectionOperator()
        {
            navigation.Login(User.PortalOperator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsNotPresent();
            pages.ui.CallCenterSectionButton.IsNotPresent();
            pages.ui.SocialNetworkSectionButton.IsNotPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор Портала / Оператор ЛК")]
        public void LoginAsPortalAndPersonalCabinetSectionOperator()
        {
            navigation.Login(User.PortalPersonalCabinetOperator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsPresent();
            pages.ui.CallCenterSectionButton.IsNotPresent();
            pages.ui.SocialNetworkSectionButton.IsNotPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор портала / Оператор колл-центра")]
        public void LoginAsPortalAndCallCenterSectionOperator()
        {
            navigation.Login(User.PortalCallCenterOperator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsNotPresent();
            pages.ui.CallCenterSectionButton.IsPresent();
            pages.ui.SocialNetworkSectionButton.IsNotPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор портала / Оператор соц сетей")]
        public void LoginAsPortalAndSocialNetworksSectionOperator()
        {
            navigation.Login(User.PortalSocialNetworksOperator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsNotPresent();
            pages.ui.CallCenterSectionButton.IsNotPresent();
            pages.ui.SocialNetworkSectionButton.IsPresent();
            pages.ui.AdministrationButton.IsNotPresent();
            pages.ui.ReportsButton.IsNotPresent();
        }

        [TestCase(TestName = "АВТОРИЗАЦИЯ // ПОЗИТИВНЫЙ // Оператор портала / Администратор")]
        public void LoginAsPortalAndAdministratorOperator()
        {
            navigation.Login(User.AdminPortalOperator);

            pages.ui.PortalSectionButton.IsPresent();
            pages.ui.CabinetSectionButton.IsPresent();
            pages.ui.CallCenterSectionButton.IsPresent();
            pages.ui.SocialNetworkSectionButton.IsPresent();
            pages.ui.AdministrationButton.IsPresent();
            pages.ui.ReportsButton.IsPresent();
        }

        // АВТОРИЗАЦИЯ // НЕГАТИВНЫЕ

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Администратор / Заблокированный")]
        public void LoginAttemptBlockedAdministratorUser() => NegativeLogin(User.AdministratorBlocked, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Оператор портала / Заблокированный")]
        public void LoginAttemptPortalOperatorBlocked() => NegativeLogin(User.PortalOperatorBlocked, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Оператор ЛК / Заблокированный")]
        public void LoginAttemptCabinetOperatorBlocked() => NegativeLogin(User.PersonalCabinetOperatorBlocked, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Оператор колл-центра / Заблокированный")]
        public void LoginAttemptCallCenterOperatorBlocked() => NegativeLogin(User.CallCenterOperatorBlocked, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Оператор соц сетей / Заблокированный")]
        public void LoginAttemptSocialNetworksOperatorBlocked() => NegativeLogin(User.SocialNetworksOperatorBlocked, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Валидный логин / Невалидный пароль")]
        public void LoginAttemptValidAdminLoginInvalidPassword() => NegativeLogin(User.Administrator.Login, UserData.InvalidPassword, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Валидный логин / Невалидный пароль в ВЕРХНЕМ регистре")]
        public void LoginAttemptAdminUserUpperRegistry() => NegativeLogin(User.Administrator.Login.ToUpper(), User.Administrator.Password.ToUpper(), Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Пустой логин / Пустой пароль")]
        public void LoginAttemptEmptyLoginPasswordFields() => NegativeLogin(UserData.EmptyValue, UserData.EmptyValue, Validations.FillAllFields);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Валидный логин / Пустой пароль")]
        public void LoginAttemptEmptyPasswordFields() => NegativeLogin(User.Administrator.Login, UserData.EmptyValue, Validations.FillAllFields);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Пустой логин / Валидный пароль")]
        public void LoginAttemptEmptyLoginValidPassword() => NegativeLogin(UserData.EmptyValue, User.Administrator.Password, Validations.FillAllFields);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Пароль в поле логин / Логин в поле пароль")]
        public void LoginAttemptLoginPasswordValuesRearranged() => NegativeLogin(User.Administrator.Password, User.Administrator.Login, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Пробел после логина / Валидный пароль")]
        public void LoginAttemptValidLoginWithTrailingSpaceValidPassword() => NegativeLogin(User.Administrator.Login.AddTrailingSpace(), User.Administrator.Password, Validations.InvalidLoginOrPassword);

        [TestCase(TestName = "АВТОРИЗАЦИЯ // НЕГАТИВНЫЙ // Валидный логин / Пробель после пароля")]
        public void LoginAttemptValidLoginValidPasswordWithTrailingSpace() => NegativeLogin(User.Administrator.Login, User.Administrator.Password.AddTrailingSpace(), Validations.InvalidLoginOrPassword);

        // Авторизация // Прочие тесты

        [TestCase(TestName = "ФОРМА АВТОРИЗАЦИИ // Очистка значения поля \"Логин\"")]
        public void LoginFieldClearance()
        { 
            pages.login.LoginInput.SendText(User.Administrator.Login);
            pages.login.LoginInput.GetText().Should().Be(User.Administrator.Login);
            pages.login.LoginInputClearButton.Click();
            pages.login.LoginInput.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "ФОРМА АВТОРИЗАЦИИ // Очистка значения поля \"Пароль\"")]
        public void PasswordFieldClearance()
        {
            pages.login.PasswordInput.SendText(User.Administrator.Password);
            pages.login.PasswordInput.GetText().Should().Be(User.Administrator.Password);
            pages.login.PasswordInputClearButton.Click();
            pages.login.PasswordInput.GetText().Should().BeNullOrEmpty();
        }
    }
}
