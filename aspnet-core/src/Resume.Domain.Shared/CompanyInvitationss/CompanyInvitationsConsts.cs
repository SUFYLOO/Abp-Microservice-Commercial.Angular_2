namespace Resume.CompanyInvitationss
{
    public static class CompanyInvitationsConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyInvitations." : string.Empty);
        }

        public const int UserMainNameMaxLength = 50;
        public const int UserMainLoginMobilePhoneMaxLength = 50;
        public const int UserMainLoginEmailMaxLength = 200;
        public const int UserMainLoginIdentityNoMaxLength = 50;
        public const int SendTypeCodeMaxLength = 50;
        public const int SendStatusCodeMaxLength = 50;
        public const int ResumeFlowStageCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}