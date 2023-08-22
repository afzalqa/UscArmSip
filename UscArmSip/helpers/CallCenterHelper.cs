using NUnit.Framework;

namespace UscArmSip
{
    public class CallCenterHelper : BaseHelper
    {
        [SetUp]
        public void Starters()
        {
            if (navigation.LoggedIn())
            {
                navigation.Logout();
            }

            navigation.Login(User.CallCenterOperator);
            pages.ui.CallCenterSectionButton.Click();
        }

        [TearDown]
        public void Closers()
        {
            driver.Navigate().Refresh();
            navigation.Logout();
        }
    }
}