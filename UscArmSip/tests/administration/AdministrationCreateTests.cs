using FluentAssertions;
using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class AdministrationCreateTests : AdministrationCreateHelper
    {
        // АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ ПОЛЬЗОВАТЕЛЯ // ПОЗИТИВНЫЕ

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Пароль на латинице с цифрами")]
        public void CreateUserLatinPassword()
        {
            var data = CreateUser(new()
            {
                Password = "asdf1234"
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Администратор")]
        public void CreateUserAdmin()
        {
            var data = CreateUser(new()
            {
                Roles = new()
                { 
                    Role.Administrator
                }
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Оператор портала / Оператор ЛК")]
        public void CreateUserCabinetOperator()
        {
            var data = CreateUser(new()
            {
                Roles = new()
                {
                    Role.PortalOperator,
                    Role.PersonalCabinetOperator
                }
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Все роли")]
        public void CreateUserAllOperatorRoles()
        {
            var data = CreateUser(new()
            {
                Roles = new()
                {
                    Role.PortalOperator,
                    Role.PersonalCabinetOperator,
                    Role.CallCenterOperator,
                    Role.SocialNetworksOperator,
                }
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / ФИО зарегестрированного ранее пользователя")]
        public void CreateUserAlreadyTakenName()
        {
            var data = CreateUser(new()
            {
                FirstName = User.Administrator.FirstName,
                LastName = User.Administrator.LastName,
                MiddleName = User.Administrator.MiddleName
            });

            AssertUserInGrid(data);
            AssertUserInForm(data);
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Отмена")]
        public void CreateUserCancellation()
        {
            pages.administration.CreateUserButton.Click();
            pages.administration.SaveButton.IsPresent();
            pages.administration.CancelButton.Click();
            pages.administration.SaveButton.IsNotPresent();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // ПОЗИТИВНЫЙ / Конвертация двойных пробелов и вырезка крайних из полей ФИО")]
        public void CreateUserMultipleNameSpaces()
        {
            var data = CreateUser(new()
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

        // АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ ПОЛЬЗОВАТЕЛЯ // НЕГАТИВНЫЕ

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Логин на кириллице")]
        public void CreateUserAttemptCyrillicLogin()
        {
            CreateUser(new()
            {
                Login = Generate.Login(Chars.Cyrillic)
            });

            pages.administration.LastNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.FirstNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.MiddleNameInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.LoginInputValidation.GetText().Should().Be(Validations.LatinAndDigitsOnly);
            pages.administration.EmailInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.PasswordInputValidation.GetText().Should().BeNullOrEmpty();
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Логин ранее зарегестрированного пользователя")]
        public void CreateUserAttemptLoginAlreadyTaken()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Пароль 7 символов")]
        public void CreateUserAttempt7CharsPassword()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Пароль 21 символ")]
        public void CreateUserAttempt21CharsPassword()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / ФИО на кириллице")]
        public void CreateUseAttemptCyrillicName()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / ФИО 61 символ")]
        public void CreateUserAttempt61charsName()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Разные значения в полях Пароль и Подтвердить пароль")]
        public void CreateUserAttemptDifferentValuesPasswordConfirmPassword()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Пароль на кириллице")]
        public void CreateUserAttemptCyrillicPassword()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Пароль из знаков")]
        public void CreateUserAttemptSymbolsPassword()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Поля не заполнены")]
        public void CreateUserAttemptNoFieldsFilled()
        {
            pages.administration.CreateUserButton.Click();
            pages.administration.SaveButton.Click();

            pages.administration.LastNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.FirstNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.MiddleNameInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.LoginInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.EmailInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.PasswordInputValidation.GetText().Should().Be(Validations.MandatoryField);
            pages.administration.ConfirmPasswordInputValidation.GetText().Should().BeNullOrEmpty();
        }

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / ФИО из цифр")]
        public void CreateUserAttemptDigitsName()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / ФИО из знаков")]
        public void CreateUserAttemptSingsName()
        {
            CreateUser(new()
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

        [TestCase(TestName = "АДМИНИСТРИРОВАНИЕ // СОЗДАНИЕ // НЕГАТИВНЫЙ / Без выбора роли")]
        public void CreateUserAttemptNoSelectedRoles()
        {
            CreateUser(new()
            {
                Roles = null
            });

            // todo проверка красных чек-боксов 
        }
    }
}

