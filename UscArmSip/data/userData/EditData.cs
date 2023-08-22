namespace UscArmSip
{
    public class EditUserData : IUserData
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string FullName
        {
            get => MiddleName is null ?
                $"{LastName} {FirstName}" :
                $"{LastName} {FirstName} {MiddleName}";
        }

        public List<Role> Roles { get; set; }
        public bool? InMailList { get; set; }
        public bool? Blocked { get; set; }
        public string Password { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public string CurrentPassword { get; set; }
        public string InvalidPassword = "invalidpassword";
    }
}

