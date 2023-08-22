using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class CabinetTests : CabinetSectionHelper
    {
        // СЕКЦИЯ ЛИЧНОГО КАБИНЕТА // ПОЗИТИВНЫЕ

        [TestCase(TestName = "ЛИЧНЫЙ КАБИНЕТ // ПОЗИТИВНЫЙ // ПРОВЕРКА ПОЛЕЙ ОБРАЩЕНИЯ / Без вложения")]
        public void CabinetRequest() => AssertRequest(new(CabinetUsers.SkbActiveFCardUser));

        [TestCase(TestName = "ЛИЧНЫЙ КАБИНЕТ // ПОЗИТИВНЫЙ // ОТВЕТ НА ОБРАЩЕНИЕ / Без вложения")]
        public void ReplyWithoutAttachment() => ReplyToRequest(new(CabinetUsers.SkbActiveFCardUser));

        // СЕКЦИЯ ЛИЧНОГО КАБИНЕТА // НЕГАТИВНЫЕ
    }
}
