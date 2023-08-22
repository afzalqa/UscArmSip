namespace UscArmSip
{
    public class PortalRequestData : RequestData
    {
        public PortalRequestData()
        {
            FirstName ??= Generate.Name(30);
            LastName ??= Generate.Name(30);
            Phone ??= Generate.Phone();
            Email ??= Generate.Email();
            Category ??= Generate.RequestCategory();
            AnswerRequired ??= true;
            Date = DateTime.Today.ToString("dd/MM/yyyy");
            Text ??= Generate.GetString(2000);

            reply.Text ??= Generate.Answer();
            reply.Tone ??= RequestTone.Neutral;
        }

        public RequestAnswerRequired AnswerRequired { get; set; }
    }
}
