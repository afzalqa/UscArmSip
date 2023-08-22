using System.Text;

namespace UscArmSip
{
    public static class Generate
    {
        public static string Answer(int? length = null) 
        {
            return length is null ? GetString(Help.Randomize(1, 10000)) : GetString((int)length);
        }

        public static string Password(Chars chars, int? length = null)
        {
            return length is null ? GetString(chars, Help.Randomize(8, 20)) : GetString(chars, (int)length);
        }

        public static string Password(int? length = null)
        {
            return length is null ? GetString(Help.Randomize(8, 20)) : GetString(length);
        }

        public static string Login(Chars chars, int? length = null)
        {
            return length is null ? GetString(chars, Help.Randomize(1, 60)) : GetString(chars, (int)length);
        }

        public static string Login(int? length = null)
        {
            return length is null ? GetString(Help.Randomize(1, 60)) : GetString(length);
        }

        public static string Name(int length = 60, Chars chars = Chars.Cyrillic)
        {
            return GetString(chars, Help.Randomize(1, length));
        }

        public static string Name(Chars chars)
        {
            return GetString(chars, Help.Randomize(1, 60));
        }

        public static string Email()
        {
            return GetString(Help.Randomize(10, 60)) + "@gmail.com";
        }

        public static string Phone()
        {
            return GetString(Chars.Digits, 10);
        }

        public static RequestCategory RequestCategory()
        {
            var random = Help.Randomize(0, 4);

            if (random is 0)
            {
                return new("Карта ЕСК");
            }
            else if (random is 1)
            {
                return new("Банковское приложение");
            }
            else if (random is 2)
            {
                return new("Транспортное приложение");
            }
            else if (random is 3)
            {
                return new("Льготы и их начисление");
            }
            else
            {
                return new("Прочие вопросы");
            }
        }

        public static string GetString(int? length)
        {
            StringBuilder sb = new();

            for (var i = 1; i <= (length - 1) / 32 + 1; i++)
            {
                sb.Append(Guid.NewGuid().ToString("N"));
            }

            return sb.ToString(0, (int)length);
        }

        public static string GetString(Chars s, int length)
        {
            string chars = default;

            if (s is Chars.Cyrillic)
            {
                chars = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            }
            else if (s is Chars.English)
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
            }
            else if (s is Chars.Digits)
            {
                chars = "1234567890";
            }
            else if (s is Chars.Signs)
            {
                chars = "!{}:|><;%:?*()_+#№[]~";
            }

            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[Help.Randomize(s.Length)]).ToArray());
        }
    }

    public enum Chars
    {
        Cyrillic,
        English,
        Digits,
        Signs
    }
}
