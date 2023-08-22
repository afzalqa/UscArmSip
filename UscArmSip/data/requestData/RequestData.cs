namespace UscArmSip
{
    public class RequestData
    {
        public RequestData()
        {
            reply = new();
        }

        public ReplyData reply;

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string UpperFullName
        {
            get => MiddleName is null ?
                $"{LastName} {FirstName}".ToUpper() :
                $"{LastName} {FirstName} {MiddleName}".ToUpper();
        }
        public string Phone { get; set; }
        public string FormattedPhone => Phone.FormatAsPhone();
        public string Email { get; set; }
        public string Number { get; set; }
        public RequestCategory Category { get; set; }
        public string Date { get; set; }
        public string Text { get; set; }
        public string AttachedFiles { get; set; }
    }
}
