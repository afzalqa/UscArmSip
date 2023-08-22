using FluentAssertions;
using OpenQA.Selenium;

namespace UscArmSip
{
    public class BaseUserDataHelper : BaseHelper
    {
        protected void AssertUserInForm(IUserData user)
        {
            GetAdministrationGridValue(AdminColumns.EditButton, user).Click();

            pages.administration.LoginInput.GetText().Should().Be(user.Login);
            pages.administration.EmailInput.GetText().Should().Be(user.Email);
            pages.administration.LastNameInput.GetText().Should().Be(user.LastName);
            pages.administration.FirstNameInput.GetText().Should().Be(user.FirstName);
            pages.administration.MiddleNameInput.GetText().Should().Be(user.MiddleName);
            pages.administration.PasswordInput.GetText().Should().BeEmpty();
            pages.administration.ConfirmPasswordInput.GetText().Should().BeEmpty();

            foreach (var role in user.Roles)
            {
                if (role is Role.Administrator)
                {
                    pages.administration.PersonalCabinetOperatorRoleCheckbox.Marked().Should().BeTrue();
                    pages.administration.PortalOperatorRoleCheckbox.Marked().Should().BeTrue();
                    pages.administration.CallCenterOperatorRoleCheckbox.Marked().Should().BeTrue();
                    pages.administration.SocialNetworksOperatorRoleCheckbox.Marked().Should().BeTrue();
                    pages.administration.AdministratorRoleCheckbox.Marked().Should().BeTrue();

                    pages.administration.AdministratorRoleCheckbox.Disabled().Should().BeFalse();
                    pages.administration.PersonalCabinetOperatorRoleCheckbox.Disabled().Should().BeTrue();
                    pages.administration.PortalOperatorRoleCheckbox.Disabled().Should().BeTrue();
                    pages.administration.CallCenterOperatorRoleCheckbox.Disabled().Should().BeTrue();
                    pages.administration.SocialNetworksOperatorRoleCheckbox.Disabled().Should().BeTrue();
                }
                else if (role is Role.PersonalCabinetOperator)
                {
                    pages.administration.PersonalCabinetOperatorRoleCheckbox.Marked().Should().BeTrue();
                }
                else if (role is Role.PortalOperator)
                {
                    pages.administration.PortalOperatorRoleCheckbox.Marked().Should().BeTrue();
                }
                else if (role is Role.CallCenterOperator)
                {
                    pages.administration.CallCenterOperatorRoleCheckbox.Marked().Should().BeTrue();
                }
                else if (role is Role.SocialNetworksOperator)
                {
                    pages.administration.SocialNetworksOperatorRoleCheckbox.Marked().Should().BeTrue();
                }
            }

            _ = user.Blocked is true ?
            pages.administration.BlockedCheckbox.Marked().Should().BeTrue() :
            pages.administration.BlockedCheckbox.Marked().Should().BeFalse();

            _ = user.InMailList is true ?
            pages.administration.InMailListCheckbox.Marked().Should().BeTrue() :
            pages.administration.InMailListCheckbox.Marked().Should().BeFalse();

            pages.administration.CancelButton.Click();
        }

        protected void AssertUserInGrid(IUserData user)
        {
            if (!user.Roles.Contains(Role.Administrator))
            {
                _ = user.Roles.Contains(Role.PortalOperator) ?
                    GetAdministrationGridValue(AdminColumns.PortalOperatorRoleCheckbox, user).Marked().Should().BeTrue() :
                    GetAdministrationGridValue(AdminColumns.PortalOperatorRoleCheckbox, user).Marked().Should().BeFalse();

                _ = user.Roles.Contains(Role.PersonalCabinetOperator) ?
                    GetAdministrationGridValue(AdminColumns.CabinetOperatorRoleCheckbox, user).Marked().Should().BeTrue() :
                    GetAdministrationGridValue(AdminColumns.CabinetOperatorRoleCheckbox, user).Marked().Should().BeFalse();

                _ = user.Roles.Contains(Role.SocialNetworksOperator) ?
                    GetAdministrationGridValue(AdminColumns.SocialNetworksOperatorRoleCheckbox, user).Marked().Should().BeTrue() :
                    GetAdministrationGridValue(AdminColumns.SocialNetworksOperatorRoleCheckbox, user).Marked().Should().BeFalse();

                _ = user.Roles.Contains(Role.CallCenterOperator) ?
                    GetAdministrationGridValue(AdminColumns.CallCenterOperatorRoleCheckbox, user).Marked().Should().BeTrue() :
                    GetAdministrationGridValue(AdminColumns.CallCenterOperatorRoleCheckbox, user).Marked().Should().BeFalse();
            }
            else if (user.Roles.Contains(Role.Administrator))
            {
                GetAdministrationGridValue(AdminColumns.PortalOperatorRoleCheckbox, user).Marked().Should().BeTrue();
                GetAdministrationGridValue(AdminColumns.CabinetOperatorRoleCheckbox, user).Marked().Should().BeTrue();
                GetAdministrationGridValue(AdminColumns.SocialNetworksOperatorRoleCheckbox, user).Marked().Should().BeTrue();
                GetAdministrationGridValue(AdminColumns.CallCenterOperatorRoleCheckbox, user).Marked().Should().BeTrue();
                GetAdministrationGridValue(AdminColumns.AdministratorRoleCheckbox, user).Marked().Should().BeTrue();
            }

            _ = user.Blocked is true ?
                GetAdministrationGridValue(AdminColumns.BlockedStatusCheckbox, user).Marked().Should().BeTrue() :
                GetAdministrationGridValue(AdminColumns.BlockedStatusCheckbox, user).Marked().Should().BeFalse();
        }

        protected void SelectRoles(IUserData data)
        {
            if (data.Roles is not null)
            {
                if (pages.administration.AdministratorRoleCheckbox.Marked()
                    && !data.Roles.Contains(Role.Administrator))
                {
                    pages.administration.AdministratorRoleCheckbox.Click();
                }
                else if (!pages.administration.AdministratorRoleCheckbox.Marked()
                    && data.Roles.Contains(Role.Administrator))
                {
                    pages.administration.AdministratorRoleCheckbox.Click();
                }

                if (!data.Roles.Contains(Role.Administrator))
                {
                    if (pages.administration.PersonalCabinetOperatorRoleCheckbox.Marked()
                        && !data.Roles.Contains(Role.PersonalCabinetOperator))
                    {
                        pages.administration.PersonalCabinetOperatorRoleCheckbox.Click();
                    }
                    else if (!pages.administration.PersonalCabinetOperatorRoleCheckbox.Marked()
                        && data.Roles.Contains(Role.PersonalCabinetOperator))
                    {
                        pages.administration.PersonalCabinetOperatorRoleCheckbox.Click();
                    }

                    if (pages.administration.PortalOperatorRoleCheckbox.Marked()
                        && !data.Roles.Contains(Role.PortalOperator))
                    {
                        pages.administration.PortalOperatorRoleCheckbox.Click();
                    }
                    else if (!pages.administration.PortalOperatorRoleCheckbox.Marked()
                        && data.Roles.Contains(Role.PortalOperator))
                    {
                        pages.administration.PortalOperatorRoleCheckbox.Click();
                    }

                    if (pages.administration.CallCenterOperatorRoleCheckbox.Marked()
                        && !data.Roles.Contains(Role.CallCenterOperator))
                    {
                        pages.administration.CallCenterOperatorRoleCheckbox.Click();
                    }
                    else if (!pages.administration.CallCenterOperatorRoleCheckbox.Marked()
                        && data.Roles.Contains(Role.CallCenterOperator))
                    {
                        pages.administration.CallCenterOperatorRoleCheckbox.Click();
                    }

                    if (pages.administration.SocialNetworksOperatorRoleCheckbox.Marked()
                        && !data.Roles.Contains(Role.SocialNetworksOperator))
                    {
                        pages.administration.SocialNetworksOperatorRoleCheckbox.Click();
                    }
                    else if (!pages.administration.SocialNetworksOperatorRoleCheckbox.Marked()
                        && data.Roles.Contains(Role.SocialNetworksOperator))
                    {
                        pages.administration.SocialNetworksOperatorRoleCheckbox.Click();
                    }
                }
            }
        }

        protected void SelectMailingStatus(IUserData editData)
        {
            if (editData.InMailList is not null)
            {
                if (editData.InMailList is true)
                {
                    if (!pages.users.InMailListCheckbox.Marked())
                    {
                        pages.users.InMailListCheckbox.Click();
                    }
                }
                else if (editData.InMailList is false)
                {
                    if (pages.users.InMailListCheckbox.Marked())
                    {
                        pages.users.InMailListCheckbox.Click();
                    }
                }
            }
        }

        protected void EditLogin(EditUserData editData)
        {
            if (editData.Login is not null)
            {
                pages.users.LoginInput.SendText(editData.Login);
            }
        }

        protected void EditEmail(EditUserData editData)
        {
            if (editData.Email is not null)
            {
                pages.users.EmailInput.SendText(editData.Login);
            }
        }

        protected void EditName(EditUserData editData)
        {
            if (editData.LastName is not null)
            {
                pages.users.LastNameInput.SendText(editData.LastName);
            }

            if (editData.FirstName is not null)
            {
                pages.users.FirstNameInput.SendText(editData.FirstName);
            }

            if (editData.MiddleName is not null)
            {
                pages.users.MiddleNameInput.SendText(editData.MiddleName);
            }
        }

        protected void EditPassword(EditUserData editData)
        {
            if (
                editData.Password is not null &&
                editData.ConfirmPassword is null)
            {
                pages.administration.PasswordInput.SendText(editData.Password);
                pages.administration.ConfirmPasswordInput.SendText(editData.Password);
            }
            else if (
                editData.Password is not null &&
                editData.ConfirmPassword is not null)
            {
                pages.administration.PasswordInput.SendText(editData.Password);
                pages.administration.ConfirmPasswordInput.SendText(editData.ConfirmPassword);
            }
        }

        protected void EditProfilePassword(EditUserData editData)
        {
            if (editData.CurrentPassword is not null)
            {
                pages.profile.CurrentPasswordInput.SendText(editData.CurrentPassword);
            }

            if (editData.NewPassword is not null)
            {
                pages.profile.NewPasswordInput.SendText(editData.NewPassword);
            }

            if (editData.ConfirmPassword is not null)
            {
                pages.profile.ConfirmPasswordInput.SendText(editData.ConfirmPassword);
            }
        }

        protected void EditBlockStatus(EditUserData editData)
        {
            if (editData.Blocked is not null)
            {
                if (editData.Blocked is true)
                {
                    if (!pages.administration.BlockedCheckbox.Marked())
                    {
                        pages.administration.BlockedCheckbox.Click();
                    }
                }
                else if (editData.Blocked is false)
                {
                    if (pages.administration.BlockedCheckbox.Marked())
                    {
                        pages.administration.BlockedCheckbox.Click();
                    }
                }
            }
        }

        protected IWebElement GetAdministrationGridValue(AdminColumns column, IUserData user)
        {
            return elements.GetElement(By.XPath($"(//*[text()='{user.FullName}'])[last()]/ancestor::tr/td[@aria-colindex='{(int)column}']/div"));
        }
    }

    public enum AdminColumns
    {
        FullName = 2,
        PortalOperatorRoleCheckbox = 3,
        CabinetOperatorRoleCheckbox = 4,
        CallCenterOperatorRoleCheckbox = 5,
        SocialNetworksOperatorRoleCheckbox = 6,
        AdministratorRoleCheckbox = 7,
        BlockedStatusCheckbox = 8,
        EditButton = 9
    }
}