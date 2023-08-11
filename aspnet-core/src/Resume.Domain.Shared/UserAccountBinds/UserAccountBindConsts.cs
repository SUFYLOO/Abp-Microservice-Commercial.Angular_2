namespace Resume.UserAccountBinds
{
    public static class UserAccountBindConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserAccountBind." : string.Empty);
        }

        public const int ThirdPartyTypeCodeMaxLength = 50;
        public const int ThirdPartyAccountIdMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}