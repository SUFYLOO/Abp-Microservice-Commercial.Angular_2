namespace Resume.UserMains
{
    public static class UserMainConsts
    {
        private const string DefaultSorting = "{0}UserId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserMain." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int AnonymousNameMaxLength = 50;
        public const int LoginAccountCodeMaxLength = 50;
        public const int LoginMobilePhoneUpdateMaxLength = 50;
        public const int LoginMobilePhoneMaxLength = 50;
        public const int LoginEmailUpdateMaxLength = 200;
        public const int LoginEmailMaxLength = 200;
        public const int LoginIdentityNoMaxLength = 50;
        public const int PasswordMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}