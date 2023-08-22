namespace UscArmSip
{
    public class RequestAnswerRequired
    {
        public RequestAnswerRequired(bool boolean)
        {
            Boolean = boolean;
            FormDataValue = boolean is true ? 1 : 0;
        }

        public static implicit operator RequestAnswerRequired(bool boolean) => new(boolean);

        public bool Boolean { get; set; }
        public int FormDataValue { get; private set; }    
    }
}
