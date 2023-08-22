using FluentAssertions;
using NUnit.Framework;
using RestSharp;

namespace UscArmSip
{
    public class CabinetSectionHelper : BaseSectionsHelper
    {
        [SetUp]
        public void Starters()
        {
            if (navigation.LoggedIn())
            {
                navigation.Logout();
            }

            navigation.Login(User.CabinetOperator);
            pages.ui.CabinetSectionButton.Click();
        }

        [TearDown]
        public void Closers()
        {
            driver.Navigate().Refresh();
            navigation.Logout();
        }

        protected static CabinetRequestData CreateCabinetRequest(CabinetRequestData cabinetRequest)
        {
            RestRequest restRequest = new("HPA/API/1_0/Requests", Method.Post);

            List<(string, string)> formData = new()
            {
                ("themeId", $"{cabinetRequest.Category.FormDataValue}"),
                ("text", $"{cabinetRequest.Text}")
            };

            restRequest.AddParameters(formData);

            RestRequestService service = new(Api.Cabinet, restRequest, cabinetRequest);
            service.SendRequest();
            cabinetRequest.Number = service.response.requestId;

            return cabinetRequest;
        }

        protected void AssertRequest(CabinetRequestData request)
        {
            request = CreateCabinetRequest(request);
            SortByRowNumber();
            AssertNewRequestInGrid(request);
            OpenRequest(request);
            AssertRequestInForm(request);
        }

        private void AssertRequestInForm(CabinetRequestData request)
        {
            pages.cabinet.RequestTab.Should().NotBeNull();
            pages.cabinet.HistoryTab.Should().NotBeNull();
            pages.cabinet.AdditionalInfoTab.Should().NotBeNull();

            pages.sections.FullName.GetText().Should().Be(request.UpperFullName);
            pages.sections.CardNumber.GetText().Should().Be(request.FormattedCardNumber);
            pages.sections.Snils.GetText().Should().Be(request.FormattedSnils);
            pages.cabinet.CardStatus.GetText().Should().Be(request.CardStatus);
            pages.sections.Phone.GetText().Should().Be(request.FormattedPhone);
            pages.sections.Email.GetText().Should().Be(request.Email);
            pages.sections.RequestNumber.GetText().Should().Be(request.Number);
            pages.sections.Status.GetText().Should().Be("Новое");
            pages.sections.Category.GetText().Should().Be(request.Category.Text);
            pages.sections.RequestDate.GetText().Should().Be(request.Date);
            pages.sections.AnswerDate.GetText().Should().BeNullOrEmpty();
            pages.sections.RequestText.GetText().Should().Be(request.Text);
            pages.sections.RequestAttachedFiles.Should().NotBeNull();
            pages.sections.RequestAnswerAttachedFiles.Should().NotBeNull();

            if (request.AttachedFiles is null)
            {
                pages.sections.RequestAttachedFiles.GetText().Should().Be(Validations.AttachedFilesNoData);
            }
            else if (request.AttachedFiles is not null)
            {
                throw new NotImplementedException();
            }
        }

        protected void ReplyToRequest(CabinetRequestData request)
        {
            CreateCabinetRequest(request);
            SortByRowNumber();
            OpenRequest(request);
            SelectTone(request);
            FillReply(request);
            SendReply(request);
            AssertReplyInForm(request);
            pages.ui.GetBackButton.Click();
            AssertRequestAfterReplyInGrid(request);
        }
    }
}
