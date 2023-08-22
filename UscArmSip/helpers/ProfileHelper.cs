using NUnit.Framework;

namespace UscArmSip
{
    public class ProfileHelper : BaseUserDataHelper
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

            navigation.Login(User.Editable);
            pages.ui.ProfileButton.Click();
        }

        [TearDown]
        public void Closers()
        {
            driver.Navigate().Refresh();
            navigation.Logout();
        }

        protected UserData SelfEditProfile(EditUserData editData)
        {
            var editableUser = User.Editable.GetDataCopy();

            EditProfile(editData);
            editableUser.Update(editData);
            pages.administration.SaveButton.Click();
            return editableUser;
        }

        protected void EditProfile(EditUserData editData)
        {
            EditLogin(editData);
            EditEmail(editData);
            EditName(editData);
            EditProfilePassword(editData);
            SelectMailingStatus(editData);
        }
    }
}