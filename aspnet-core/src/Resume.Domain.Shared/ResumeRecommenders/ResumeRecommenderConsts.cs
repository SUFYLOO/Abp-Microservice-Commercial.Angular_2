namespace Resume.ResumeRecommenders
{
    public static class ResumeRecommenderConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeRecommender." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int CompanyNameMaxLength = 50;
        public const int JobNameMaxLength = 50;
        public const int MobilePhoneMaxLength = 50;
        public const int OfficePhoneMaxLength = 50;
        public const int EmailMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}