using FluentAssertions;
using OpenQA.Selenium;

namespace UscArmSip
{
    public class BaseSectionsHelper : BaseHelper
    {
        protected void AssertNewRequestInGrid(RequestData request)
        {
            GetSectionsGridValue(SectionsColumns.Status, request).GetText().Should().Be("Новое");
            GetSectionsGridValue(SectionsColumns.AnswerDate, request).GetText().Should().BeNullOrWhiteSpace();

            AssertRequestInGrid(request);
        }

        protected void AssertRequestAfterReplyInGrid(RequestData request)
        {
            GetSectionsGridValue(SectionsColumns.Status, request).GetText().Should().Be("Завершено");
            GetSectionsGridValue(SectionsColumns.AnswerDate, request).GetText().Should().Be(DateTime.Today.ToString("dd/MM/yyyy"));

            AssertRequestInGrid(request);
        }

        protected void AssertReplyInForm(RequestData request)
        {
            pages.ui.Toast.GetText().Should().Be(Validations.AnswerSuccessfullySaved);
            pages.sections.RequestAnswerTextInput.GetText().Should().Be(request.reply.Text);
            pages.sections.AnswerDate.GetText().Should().Be(DateTime.Today.ToString("dd/MM/yyyy"));

            if (request.reply.Tone is RequestTone.Positive)
            {
                pages.sections.RequestTone.GetText().Should().Be("Положительный");
            }
            else if (request.reply.Tone is RequestTone.Negative)
            {
                pages.sections.RequestTone.GetText().Should().Be("Негативный");
            }
            else if (request.reply.Tone is RequestTone.Neutral)
            {
                pages.sections.RequestTone.GetText().Should().Be("Нейтральный");
            }

            if (request.AttachedFiles is null)
            {
                pages.sections.RequestAttachedFiles.GetText().Should().Be(Validations.AttachedFilesNoData);
            }
            else if (request.AttachedFiles is not null)
            {
                throw new NotImplementedException();
            }

            if (request.reply.AttachedFiles is null)
            {
                pages.sections.RequestAnswerAttachedFiles.GetText().Should().Be(Validations.AttachedFilesNoData);
            }
            else if (request.reply.AttachedFiles is not null)
            {
                throw new NotImplementedException();
            }

            pages.sections.CancelButton.IsNotPresent();
            pages.sections.ProcessRequestButton.IsNotPresent();
            pages.sections.UploadButton.IsNotPresent();
        }

        protected void OpenRequest(RequestData request)
        {
            elements.GetElement(By.XPath($"//*[contains(@aria-describedby,'dx-col') and text()='{request.Number}']")).DoubleClick();
        }

        protected void SelectTone(RequestData request)
        {
            pages.sections.SelectToneDropdown.Click();
            elements.GetElement(By.XPath($"(//*[@class='dx-scrollview-content']/div/div)[{(int)request.reply.Tone}]")).Click();
        }

        protected void FillReply(RequestData request)
        {
            pages.sections.RequestAnswerTextInput.SendKeys(request.reply.Text);
            pages.sections.RequestAnswerTextInput.GetText().Should().Be(request.reply.Text);
        }

        protected void SendReply(RequestData request)
        {
            pages.sections.ProcessRequestButton.Click();
            request.reply.Date = DateTime.Today.ToString("dd/MM/yyyy");
        }

        protected void SortByRowNumber()
        {
            driver.Navigate().Refresh();
            pages.sections.RowNumberHeader.DoubleClick();
        }

        protected IWebElement GetSectionsGridValue(SectionsColumns column, RequestData request)
        {
            return elements.GetElement(By.XPath($"(//*[text()='{request.Number}'])[last()]/ancestor::tr/td[@aria-colindex='{(int)column}']"));
        }

        protected string RequestRowColor(RequestData request)
        {
            return elements.GetElement(By.XPath($"(//*[text()='{request.UpperFullName}'])[last()]/ancestor::tr")).BackgroundColor();
        }

        private void AssertRequestInGrid(RequestData request)
        {
            GetSectionsGridValue(SectionsColumns.RequestNumber, request).GetText().Should().Be(request.Number);
            GetSectionsGridValue(SectionsColumns.Counterparty, request).GetText().Should().Be(request.UpperFullName);
            GetSectionsGridValue(SectionsColumns.Category, request).GetText().Should().Be(request.Category.Text);
            GetSectionsGridValue(SectionsColumns.RequestDate, request).GetText().Should().Be(request.Date);
        }
    }

    public enum SectionsColumns
    {
        RequestNumber = 1,
        Status = 2,
        Counterparty = 3,
        Category = 4,
        RequestDate = 5,
        AnswerDate = 6,
    }

    public enum RequestTone
    {
        Positive = 1,
        Neutral = 2,
        Negative = 3,
    }
}