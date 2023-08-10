namespace Resume.CompanyInvitationsCodes
{
    public static class CompanyInvitationsCodeConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyInvitationsCode." : string.Empty);
        }

        public const int CompanyInvitationIdMaxLength = 50;
        public const int VerifyIdMaxLength = 500;
        public const int VerifyCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}