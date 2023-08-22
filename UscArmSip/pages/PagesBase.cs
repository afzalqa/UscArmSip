using OpenQA.Selenium;

namespace UscArmSip
{
    public class PageBase
    {
        public PageBase(IWebDriver driver, Elements elements)
        {
            this.driver = driver;
            this.elements = elements;
        }

        protected IWebDriver driver;
        protected Elements elements;
    }
}
