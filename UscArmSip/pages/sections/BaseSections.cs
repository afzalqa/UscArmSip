using OpenQA.Selenium;

namespace UscArmSip
{
    public class BaseSections : PageBase
    {
        public BaseSections(IWebDriver driver, Elements elements) : base(driver, elements) { }

        // Грид

        public IWebElement RowNumberHeader => elements.GetElement(By.XPath("//*[@aria-label='Столбец №']"));

        // Карточка обращения

        public IWebElement FullName => elements.GetElement(By.XPath("//*[@test-id='fullname']"));
        public IWebElement CardNumber => elements.GetElement(By.XPath("//*[@test-id='cardnumber']"));
        public IWebElement Phone => elements.GetElement(By.XPath("//*[@test-id='phone']"));
        public IWebElement Snils => elements.GetElement(By.XPath("//*[@test-id='snils']"));
        public IWebElement Email => elements.GetElement(By.XPath("//*[@test-id='email']"));
        public IWebElement RequestNumber => elements.GetElement(By.XPath("//*[@test-id='request-id']"));
        public IWebElement Status => elements.GetElement(By.XPath("//*[@test-id='status-name']"));
        public IWebElement Category => elements.GetElement(By.XPath("(//div[@class='flex flex-row flex-grow flex-vertical-center'])[3]//span[2]"));
        public IWebElement RequestTone => elements.GetElement(By.XPath("//*[@test-id='request-tone-name']"));
        public IWebElement RequestDate => elements.GetElement(By.XPath("//*[@test-id='request-date']"));
        public IWebElement AnswerDate => elements.GetElement(By.XPath("//*[@test-id='answer-date']"));
        public IWebElement RequestText => elements.GetElement(By.XPath("//*[@test-id='request-query']"));
        public IWebElement RequestAnswerTextInput => elements.GetElement(By.XPath("//*[@test-id='answerText']"));
        public IWebElement RequestAttachedFiles => elements.GetElement(By.XPath("//*[@test-id='request-files']"));
        public IWebElement RequestAnswerAttachedFiles => elements.GetElement(By.XPath("//*[@test-id='request-answer-files']"));
        public IWebElement UploadButton => elements.GetElement(By.XPath("//*[@test-id='upload-button']"));
        public IWebElement CancelButton => elements.GetElement(By.XPath("//*[@test-id='cancel-button']"));
        public IWebElement ProcessRequestButton => elements.GetElement(By.XPath("//*[@test-id='send-button']"));
        public IWebElement SelectToneDropdown => elements.GetElement(By.XPath("//*[@test-id='tone-select']"));
    }
}
