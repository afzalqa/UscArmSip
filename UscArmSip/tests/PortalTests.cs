using NUnit.Framework;

namespace UscArmSip
{
    [TestFixture]
    public class PortalTests : PortalSectionHelper
    {
        // ������ ������ // ����������

        [TestCase(TestName = "������ // ���������� // �������� ����� ��������� / ��� �������� / ������� ������")]
        public void AssertPortalRequestThatRequiresAnswer() => AssertRequest(new());

        [TestCase(TestName = "������ // ���������� // �������� ����� ��������� / ��� �������� / ������� ������")]
        public void AssertPortalRequestThatDoNotRequiresAnswer() => AssertRequest(new() { AnswerRequired = false });

        [TestCase(TestName = "������ // ���������� // ����� �� ��������� / ��� �������� / ������� ������")]
        public void ReplyWithoutAttachment() => ReplyToRequest(new());

        // ������ ������ // ����������
    }
}
