namespace Resume.ResumeExperiencess
{
    public static class ResumeExperiencesConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeExperiences." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int WorkNatureCodeMaxLength = 50;
        public const int IndustryCategoryCodeMaxLength = 500;
        public const int JobNameMaxLength = 50;
        public const int JobTypeMaxLength = 500;
        public const int WorkPlaceCodeMaxLength = 500;
        public const int SalaryPayTypeCodeMaxLength = 50;
        public const int CurrencyTypeCodeMaxLength = 50;
        public const int CompanyScaleCodeMaxLength = 50;
        public const int CompanyManagementNumberCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}