namespace Resume.CompanyJobs
{
    public static class CompanyJobConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJob." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int JobTypeCodeMaxLength = 50;
        public const int MailTplIdMaxLength = 50;
        public const int SMSTplIdMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}