namespace UscArmSip
{
    public class RequestCategory
    {
        public RequestCategory(string text)
        {
            Text = text;

            if (text is "Карта ЕСК")
            {
                FormDataValue = 1;
            }
            else if (text is "Банковское приложение")
            {
                FormDataValue = 2;
            }
            else if (text is "Льготы и их начисление")
            {
                FormDataValue = 3;
            }
            else if (text is "Транспортное приложение")
            {
                FormDataValue = 4;
            }
            else if (text is "Прочие вопросы")
            {
                FormDataValue = 5;
            }
        }

        public string Text { get; set; }
        public int FormDataValue { get; private set; }
    }
}
