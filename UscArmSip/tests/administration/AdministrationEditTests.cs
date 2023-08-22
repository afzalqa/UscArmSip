using FluentAssertions;
using NUnit.Framework;

namespace UscArmSip
{
    public class AdministrationEditTests : AdministrationEditHelper
    {
        // АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ ПОЛЬЗОВАТЕЛЯ // ПОЗИТИВНЫЕ

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Блокировка")]
        public void EditUserBlockUser()
        {
            var data = EditUser(new()
            {
                Blocked = true
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Логин / ФИО / Пароль")]
        public void EditUserLoginNamePassword()
        {
            var data = EditUser(new()
            {
                Login = Generate.Login(),
                FirstName = Generate.Name(),
                LastName = Generate.Name(),
                MiddleName = Generate.Name(),
                Password = Generate.Password()
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);

            navigation.Logout();
            navigation.Login(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Оператор ЛК")]
        public void EditUserGiveCabinetOperatorRole()
        {
            var data = EditUser(new()
            {
                Roles = new()
                {
                    Role.PersonalCabinetOperator,
                }
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Дать все операторские роли")]
        public void EditUserGiveAllOperatorRoles()
        {
            var data = EditUser(new()
            {
                Roles = new()
                {
                    Role.PortalOperator,
                    Role.PersonalCabinetOperator,
                    Role.SocialNetworksOperator,
                    Role.CallCenterOperator,
                }
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Отмена")]
        public void EditUserCancelEdit()
        {
            EditForm(new()
            {
                Login = Generate.Login(),
                Password = Generate.Password(),
                FirstName = Generate.Name(),
                LastName = Generate.Name(),
                MiddleName = Generate.Name()
            });

            pages.administration.CancelButton.Click();
            pages.administration.CancelButton.IsNotPresent();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Пробелы до, после и в ФИО")]
        public void EditUserNameMultipleSpaces()
        {
            var data = EditUser(new()
            {
                FirstName = Generate.Name(60).AddRandomDoubleSpaces(),
                LastName = Generate.Name(60).AddRandomDoubleSpaces(),
                MiddleName = Generate.Name(60).AddRandomDoubleSpaces()
            });

            data.FirstName = data.FirstName.ConvertDoubleSpacesToSingles();
            data.LastName = data.LastName.ConvertDoubleSpacesToSingles();
            data.MiddleName = data.MiddleName.ConvertDoubleSpacesToSingles();

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // ПОЗИТИВНЫЙ // Пароль на латинице")]
        public void EditUserLatinPassword()
        {
            var data = EditUser(new()
            {
                Password = Generate.Password(Chars.English)
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        // АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ ПОЛЬЗОВАТЕЛЯ // НЕГАТИВНЫЕ

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // ФИО 61 символ")]
        public void EditUserAttempt61charName()
        {
            EditUser(new()
            {
                FirstName = Generate.Name(61),
                LastName = Generate.Name(61),
                MiddleName = Generate.Name(61)
            });

            pages.administration.LastNameInputValidation.GetText().Should().Be(Validations.SixtySymbolsLength);
            pages.administration.FirstNameInputValidation.GetText().Should().Be(Validations.SixtySymbolsLength);
            pages.administration.MiddleNameInputValidation.GetText().Should().Be(Validations.SixtySymbolsLength);
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // ФИО из цифр")]
        public void EditUserAttemptDigitsName()
        {
            EditUser(new()
            {
                FirstName = Generate.Name(Chars.Digits),
                LastName = Generate.Name(Chars.Digits),
                MiddleName = Generate.Name(Chars.Digits)
            });

            pages.administration.LastNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.FirstNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.MiddleNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // ФИО из знаков")]
        public void EditUserAttemptSymbolsName()
        {
            EditUser(new()
            {
                FirstName = Generate.Name(Chars.Signs),
                LastName = Generate.Name(Chars.Signs),
                MiddleName = Generate.Name(Chars.Signs)
            });

            pages.administration.LastNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.FirstNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.MiddleNameInputValidation.GetText().Should().Be(Validations.CyrillicSpaceHyphenAllowed);
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Пароль на кириллице")]
        public void EditUserAttemptCyrillicPassword()
        {
            EditUser(new()
            {
                Password = Generate.Password(Chars.Cyrillic)
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().Be(Validations.LatinAndDigitsOnly);
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Пароль из знаков")]
        public void EditUserAttemptSingsPassword()
        {
            EditUser(new()
            {
                Password = Generate.Password(Chars.Signs)
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().Be(Validations.LatinAndDigitsOnly);
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Пароль из 7 символов")]
        public void EditUserAttempt7charPassword()
        {
            EditUser(new()
            {
                Password = Generate.Password(7)
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().Be(Validations.PasswordLength);
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Пароль из 21 символа")]
        public void EditUserAttempt21charPassword()
        {
            EditUser(new()
            {
                Password = Generate.Password(21)
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().Be(Validations.PasswordLength);
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Разные значения в полях Пароль и Подтвердить пароль")]
        public void EditUserAttemptPasswordAndConfirmPasswordValuesDiffer()
        {
            EditUser(new()
            {
                Password = Generate.Password(),
                ConfirmPassword = Generate.Password()
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().Be(Validations.PasswordMissmatch);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Логин зарегистрированного ранее пользователя")]
        public void EditUserAttemptAlreadyTakenLogin()
        {
            EditUser(new()
            {
                Login = User.Administrator.Login
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().Be(Validations.LoginAlreadyTaken);
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // РЕДАКТИРОВАНИЕ // НЕГАТИВНЫЙ // Сохранение без заполненных обязательных полей")]
        public void EditUserAttemptClearFields()
        {
            EditUser(new()
            {
                Login = string.Empty,
                FirstName = string.Empty,
                MiddleName = string.Empty,
                LastName = string.Empty,
                Email = string.Empty
            });

            pages.administration.LoginInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.EmailInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.LastNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.FirstNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.MiddleNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
        }
    }
}

// todo тесты на чек-бокс рассылки когда пользователь блокируется
