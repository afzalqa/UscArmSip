using FluentAssertions;
using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class ProfileTests : ProfileHelper
    {
        [TestCase(TestName = "ПРОФИЛЬ // НЕГАТИВНЫЙ // Пустые значения")]
        public void SelfEditAttemptClearFields()
        {
            SelfEditProfile(new()
            {
                Login = string.Empty,
                Email = string.Empty,
                LastName = string.Empty,
                FirstName = string.Empty,
                MiddleName = string.Empty
            });

            pages.profile.LoginInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.profile.EmailInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.profile.EmailPlaceholder.GetText().Should().Be("не указана");
            pages.profile.LastNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.profile.FirstNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.profile.MiddleNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
        }

        [TestCase(TestName = "ПРОФИЛЬ // НЕГАТИВНЫЙ // Логин зарегистрированного ранее пользователя")]
        public void SelfEditAttemptAlreadyTakenLogin()
        {
            SelfEditProfile(new()
            {
                Login = User.Administrator.Login
            });

            pages.profile.LoginInputValidation.GetText().Should().Be(Validations.LoginAlreadyTaken);
            pages.profile.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "ПРОФИЛЬ // НЕГАТИВНЫЙ // Разные значения в поле Текущий Парль и Новый пароль")]
        public void SelfEditAttemptNewPasswordAndConfirmPasswordValuesDiffer()
        {
            SelfEditProfile(new()
            {
                CurrentPassword = User.Editable.Password,
                NewPassword = Generate.Password(),
                ConfirmPassword = Generate.Password()
            });

            pages.profile.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.NewPasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.CurrentPasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.profile.ConfirmPasswordInputValidation.GetText().Should().Be(Validations.PasswordMissmatch);
        }
    }
}
