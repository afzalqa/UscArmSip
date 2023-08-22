namespace UscArmSip
{
    public static class Validations
    {
        public static string FillAllFields => "Заполните все поля";
        public static string CyrillicSpaceHyphenAllowed => "Допустимы только кириллица, дефис и пробел";
        public static string InvalidEMailAddress => "Введен недопустимый адрес эл.почты";
        public static string InvalidLoginOrPassword => "Некорректный логин или пароль";
        public static string MandatoryField => "Поле обязательно";
        public static string LoginAlreadyTaken => "Такой логин уже есть в системе!";
        public static string SixtySymbolsLength => "Длина не более 60 символов";
        public static string PasswordLength => "Длина пароля от 8 до 20 символов";
        public static string PasswordMissmatch => "Пароли не совпадают";
        public static string LatinAndDigitsOnly => "Допустимы только латинские буквы и цифры";
        public static string AnswerSuccessfullySaved => "Ответ успешно сохранен";
        public static string AttachedFilesNoData => "Вложенные файлы:\r\nНет данных для отображения"; // todo fix
        public static string CurrentPasswordRequired => "Для смены пароля требуется текущий пароль";
    }
}