namespace Resume.UserInfos
{
    public static class UserInfoConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserInfo." : string.Empty);
        }

        public const int NameCMaxLength = 50;
        public const int NameEMaxLength = 200;
        public const int IdentityNoMaxLength = 50;
        public const int SexCodeMaxLength = 50;
        public const int BloodCodeMaxLength = 50;
        public const int PlaceOfBirthCodeMaxLength = 50;
        public const int PassportNoMaxLength = 50;
        public const int NationalityCodeMaxLength = 50;
        public const int ResidenceNoMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}