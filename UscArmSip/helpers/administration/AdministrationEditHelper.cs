using NUnit.Framework;

namespace UscArmSip
{
    public class AdministrationEditHelper : BaseUserDataHelper
    {
        [SetUp]
        public void Starters()
        {
            if (!Database.CheckTestUserDbData(User.Editable))
            {
                Database.RestoreTestUserDbData(User.Editable);
            }

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

        protected UserData EditUser(EditUserData editData)
        {
            var editableUser = User.Editable.GetDataCopy();

            GetAdministrationGridValue(AdminColumns.EditButton, editableUser).Click();
            EditForm(editData);
            editableUser.Update(editData);
            pages.administration.SaveButton.Click();
            return editableUser;
        }

        protected void EditForm(EditUserData editData)
        {
            EditLogin(editData);
            EditEmail(editData);
            EditName(editData);
            EditPassword(editData);
            SelectRoles(editData);
            SelectMailingStatus(editData);
            EditBlockStatus(editData);
        }
    }
}