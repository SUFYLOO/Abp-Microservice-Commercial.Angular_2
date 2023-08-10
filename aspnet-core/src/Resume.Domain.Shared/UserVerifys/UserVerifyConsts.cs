namespace Resume.UserVerifys
{
    public static class UserVerifyConsts
    {
        private const string DefaultSorting = "{0}VerifyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserVerify." : string.Empty);
        }

        public const int VerifyIdMaxLength = 500;
        public const int VerifyCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}