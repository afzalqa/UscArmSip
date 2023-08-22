using OpenQA.Selenium;

namespace UscArmSip
{
    public class Pages
    {
        public Pages(IWebDriver driver, Elements elements)
        {
            login = new(driver, elements);
            ui = new(driver, elements);
            profile = new(driver, elements);
            administration = new(driver, elements);
            social = new(driver, elements);
            ccenter = new(driver, elements);
            portal = new(driver, elements);
            cabinet = new(driver, elements);
            reports = new(driver, elements);
            sections = new(driver, elements);
            users = new(driver, elements);
        }

        public Ui ui;

        public BaseSections sections;

        public PortalSectionPage portal;
        public CabinetSectionPage cabinet;
        public CallCenterSectionPage ccenter;
        public SocialNetworksSectionPage social;

        public ReportsPage reports;

        public BaseUserData users;
        public AdministrationPage administration;
        public ProfilePage profile;

        public LoginPage login;
    }
}
