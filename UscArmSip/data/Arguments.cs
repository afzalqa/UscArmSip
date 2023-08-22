namespace UscArmSip
{
    public static class Arguments
    {
        public static readonly string[] HeadlessStart
            = new string[] { "--disable-notifications", "--headless", "--window-size=1920,1080", "--proxy-bypass-list=*" };

        public static readonly string[] HeadlessStart2
            = new string[] { "--disable-notifications", "--headless", "--start-maximized", "--proxy-bypass-list=*" };

        public static readonly string[] RegularStart
            = new string[] { "--disable-notifications", "--window-size=1920,1080", "--proxy-bypass-list=*" };

        public static readonly string[] ExperimentalStart
            = new string[] { "--disable-notifications", "--no-sandbox", "--headless", "--window-size=1920,1080", "--proxy-bypass-list=*" };
    }
}
