namespace UscArmSip
{
    public static class User
    {
        // Пользователи // Основные роли

        public static readonly UserData Administrator = new("atadmin", "ат_Админ", "ат_Админ", "ат_Админ");

        public static readonly UserData CabinetOperator = new("cabinetOPERATOR", "ат_Семенов", "ат_Валерий", "ат_Александрович");
        public static readonly UserData CallCenterOperator = new("callcenterOPERATOR", "ат_Валентинов", "ат_Валентин", "ат_Валентинов");
        public static readonly UserData SocialNetworksOperator = new("socialnetworksOPERATOR", "ат_Алексеев", "ат_Андрей", "ат_Васильевич");
        public static readonly UserData PortalOperator = new("portalOPERATOR", "ат_Новиков", "ат_Евгений", "ат_Дмитриевич");

        // Пользователи // Основные роли // Заблокированные 

        public static readonly UserData AllRolesUserBlocked = new("allrolesBLOCKED", "ат_Шамолин", "ат_Роман", "ат_Викторович");
        public static readonly UserData AdministratorBlocked = new("adminBLOCKED", "ат_Филимонов", "ат_Денис", "ат_Сергеевич");
        public static readonly UserData PortalOperatorBlocked = new("portalBLOCKED", "ат_Степанов", "ат_Степан", "ат_Степанович");
        public static readonly UserData PersonalCabinetOperatorBlocked = new("cabinetBLOCKED", "ат_Шелестов", "ат_Григорий", "ат_Валерьянович");
        public static readonly UserData CallCenterOperatorBlocked = new("callcenterBLOCKED", "ат_Немков", "ат_Вадим", "ат_Валентинович");
        public static readonly UserData SocialNetworksOperatorBlocked = new("socialnetworksBLOCKED", "ат_Маслов", "ат_Михаил", "ат_Витальевич");

        // Пользователи // Смешанные роли

        public static readonly UserData AllRolesUser = new("allOPERATORroles", "ат_Кирюхин", "ат_Кирилл", "ат_Кириллович");
        public static readonly UserData PortalPersonalCabinetOperator = new("portalcabinetOPERATOR", "ат_Константинов", "ат_Александр", "ат_Валерьевич");
        public static readonly UserData PortalCallCenterOperator = new("portalcallcenterOPERATOR", "ат_Степкин", "ат_Степан", "ат_Лигович");
        public static readonly UserData PortalSocialNetworksOperator = new("portalsocialnetworksOPERATOR", "ат_Шастов", "ат_Кирилл", "ат_Саламович");
        public static readonly UserData AdminPortalOperator = new("adminportalOPERATOR", "ат_Аскрен", "ат_Билли", "ат_Шоевич");

        // Пользователи // Тестовый пользователь для редактирования

        public static readonly UserData Editable = new("editableUSER", "Тестовый", "Пользователь", "Редактируемый")
        {
            Email = "editableuser@testmail.com",

            Roles = new()
            {
                Role.Administrator
            },

            InMailList = false,
            Blocked = false
        };
    }
}
