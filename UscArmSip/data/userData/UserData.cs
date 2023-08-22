namespace UscArmSip
{
    public class UserData : IUserData
    {
        public UserData()
        {
            Login = Generate.Login(Chars.English);
            Email = Generate.Email();
            LastName = Generate.Name(Chars.Cyrillic);
            FirstName = Generate.Name(Chars.Cyrillic);
            MiddleName = Generate.Name(Chars.Cyrillic);
            Password = "asdf1234";

            Roles = new()
            {
                Role.Administrator
            };

            InMailList = false;
            Blocked = false;
        }

        public UserData(
            string login,
            string firstName,
            string lastName,
            string middleName)
        {
            Login = login;
            FirstName = firstName;
            LastName = lastName;
            MiddleName = middleName;
            Password = "asdf1234";
            ConfirmPassword = "asdf1234";
            PassHash =
                "312433c28349f63c4f38795" +
                "3ff337046e794bea0f9b9eb" +
                "fcb08e90046ded9c76";
        }

        public UserData Update(EditUserData data)
        {
            Login = data.Login ?? Login;
            Email = data.Email ?? Email;
            LastName = data.LastName ?? LastName;
            FirstName = data.FirstName ?? FirstName;
            MiddleName = data.MiddleName ?? MiddleName;
            Password = data.Password ?? Password;
            ConfirmPassword = data.ConfirmPassword ?? ConfirmPassword;
            Roles = data.Roles ?? Roles;
            InMailList = data.InMailList ?? InMailList;
            Blocked = data.Blocked ?? Blocked;

            return this;
        }

        public UserData GetDataCopy()
        {
            UserData user = new()
            {
                Login = Login,
                Email = Email,
                LastName = LastName,
                FirstName = FirstName,
                MiddleName = MiddleName,
                Password = Password,
                ConfirmPassword = ConfirmPassword,
                Roles = Roles,
                InMailList = InMailList,
                Blocked = Blocked
            };

            return user;
        }

        public string Login { get; set; }
        public string Email { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string FullName
        {
            get => MiddleName is null ?
                $"{LastName} {FirstName}" :
                $"{LastName} {FirstName} {MiddleName}";
        }

        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public static string InvalidPassword => "invalidpassword";
        public static string EmptyValue => string.Empty;
        public List<Role> Roles { get; set; }
        public bool? InMailList { get; set; }
        public bool? Blocked { get; set; }
        public string PassHash { get; set; }
    }
}