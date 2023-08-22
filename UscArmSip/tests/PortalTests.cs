using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class PortalTests : PortalSectionHelper
    {
        // СЕКЦИЯ ПОРТАЛ // ПОЗИТИВНЫЕ

        [TestCase(TestName = "ПОРТАЛ // ПОЗИТИВНЫЙ // ПРОВЕРКА ПОЛЕЙ ОБРАЩЕНИЯ / Без вложения / Требует ответа")]
        public void AssertPortalRequestThatRequiresAnswer() => AssertRequest(new());

        [TestCase(TestName = "ПОРТАЛ // ПОЗИТИВНЫЙ // ПРОВЕРКА ПОЛЕЙ ОБРАЩЕНИЯ / Без вложения / Требует ответа")]
        public void AssertPortalRequestThatDoNotRequiresAnswer() => AssertRequest(new() { AnswerRequired = false });

        [TestCase(TestName = "ПОРТАЛ // ПОЗИТИВНЫЙ // ОТВЕТ НА ОБРАЩЕНИЕ / Без вложения / Требует ответа")]
        public void ReplyWithoutAttachment() => ReplyToRequest(new());

        // СЕКЦИЯ ПОРТАЛ // НЕГАТИВНЫЕ
    }
}
