using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace UscArmSip
{
    public class PortalSectionHelper : BaseSectionsHelper
    {
        [SetUp]
        public void Starters()
        {
            if (navigation.LoggedIn())
            {
                navigation.Logout();
            }

            navigation.Login(User.PortalOperator);
            pages.ui.PortalSectionButton.Click();
        }

        [TearDown]
        public void Closers()
        {
            driver.Navigate().Refresh();
            navigation.Logout();
        }

        protected static PortalRequestData CreatePortalRequest(PortalRequestData request)
        {
            RestRequest restRequest = new("IP/API/1_0/Feedback", Method.Post);

            List<(string, string)> formData = new()
            {
                ("subject_id", $"{request.Category.FormDataValue}"),
                ("body", $"{request.Text}"),
                ("name", $"{request.FirstName}"),
                ("lastname", $"{request.LastName}"),
                ("answer_method", $"{request.AnswerRequired.FormDataValue}"),
                ("phone", $"{request.Phone}"),
                ("email", $"{request.Email}")
            };

            restRequest.AddParameters(formData);

            RestRequestService service = new(Api.Portal, restRequest);
            service.SendRequest();
            request.Number = service.response.requestId;

            return request;
        }

        protected void AssertRequest(PortalRequestData request)
        {
            request = CreatePortalRequest(request);;
            SortByRowNumber();
            AssertNewRequestInGrid(request);
            OpenRequest(request);
            AssertRequestInForm(request);
        }

        protected void ReplyToRequest(PortalRequestData request)
        {
            AssertRequest(request);
            SelectTone(request);
            FillReply(request);
            SendReply(request);
            AssertReplyInForm(request); ;
            pages.ui.GetBackButton.Click();
            AssertRequestAfterReplyInGrid(request);
        }

        private void AssertRequestInForm(PortalRequestData request)
        {
            pages.sections.FullName.GetText().Should().Be(request.UpperFullName);
            pages.sections.Phone.GetText().Should().Be(request.FormattedPhone);
            pages.sections.Email.GetText().Should().Be(request.Email);
            pages.sections.RequestNumber.GetText().Should().Be(request.Number);
            pages.sections.Status.GetText().Should().Be("Новое");
            pages.sections.Category.GetText().Should().Be(request.Category.Text);
            pages.portal.AnswerRequiredCheckbox.Marked().Should().Be(request.AnswerRequired.Boolean);
            pages.sections.RequestDate.GetText().Should().Be(request.Date);
            pages.sections.RequestText.GetText().Should().Be(request.Text);
            pages.sections.RequestAttachedFiles.Should().NotBeNull();

            if (request.AttachedFiles is null)
            {
                pages.sections.RequestAttachedFiles.GetText().Should().Be(Validations.AttachedFilesNoData);
            }
            else if (request.AttachedFiles is not null)
            {
                throw new NotImplementedException();
            }

            if (request.AnswerRequired.Boolean is true)
            {
                pages.sections.RequestAnswerTextInput.Should().NotBeNull();
                pages.sections.RequestAnswerAttachedFiles.Should().NotBeNull();
            }
            else if (request.AnswerRequired.Boolean is false)
            {
                pages.sections.RequestAnswerTextInput.Should().BeNull();
                pages.sections.RequestAnswerAttachedFiles.Should().BeNull();
            }
        }
    }
}


/*        private void OpenRequest(RequestData request)
        {
            elements.GetElement(By.XPath($"//*[contains(text(),'{request.FullName}')]")).DoubleClick();
        }*/

/*
private void SelectCategory(string topic)
{
    pages.feedback.TopicDropdown.Click();
    elements.GetElement(By.XPath($"//li[contains(text(), '{topic}')]")).Click();
}*/
