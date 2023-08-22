namespace UscArmSip
{
    public class CabinetRequestData : RequestData
    {
        public CabinetRequestData(CabinetUserData user)
        {
            AuthToken = user.AuthToken;
            FirstName = user.FirstName;
            LastName = user.LastName;
            MiddleName = user.MiddleName;
            CardNumber = user.CardNumber;
            Snils = user.Snils;
            Phone = user.Phone;
            Email = user.Email;
            CardStatus = user.CardStatus;
           
            Category ??= Generate.RequestCategory();
            Date = DateTime.Today.ToString("dd/MM/yyyy");
            Text ??= Generate.GetString(2000);

            reply.Text ??= Generate.GetString(2000);
            reply.Tone ??= RequestTone.Neutral;
        }

        public string AuthToken { get; set; }
        public string Snils { get; set; }
        public string FormattedSnils => Snils.FormatAsSnils();
        public string CardNumber { get; set; }
        public string FormattedCardNumber => CardNumber.FormatAsCardNumber();
        public string CardStatus { get; set; }
    }
}
