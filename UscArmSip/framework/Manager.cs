using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UscArmSip
{
    public class Manager : IDisposable
    {
        public IWebDriver driver;
        public Elements elements;
        public Pages pages;
        public Navigation navigation;

        public Manager()
        {
            var options = new ChromeOptions ();
            options.AddArguments(Arguments.RegularStart);
            driver = new ChromeDriver(options);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(1);

            elements = new Elements(driver);
            pages = new Pages(driver, elements);
            navigation = new Navigation(pages);
        }

        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                driver?.Dispose();
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}



