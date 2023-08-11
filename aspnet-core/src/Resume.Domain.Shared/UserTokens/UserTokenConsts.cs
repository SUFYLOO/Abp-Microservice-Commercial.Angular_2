namespace Resume.UserTokens
{
    public static class UserTokenConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserToken." : string.Empty);
        }

        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}