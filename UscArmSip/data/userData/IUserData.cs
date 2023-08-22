namespace UscArmSip
{
    public interface IUserData
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
        public string EmptyValue => string.Empty;
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }

    public enum Role
    {
        PortalOperator = 1,
        PersonalCabinetOperator = 2,
        CallCenterOperator = 3,
        SocialNetworksOperator = 4,
        Administrator = 5
    }
}