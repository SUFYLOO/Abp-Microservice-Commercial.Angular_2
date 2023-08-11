namespace Resume.CompanyJobConditions
{
    public static class CompanyJobConditionConsts
    {
        private const string DefaultSorting = "{0}CompanyMainCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobCondition." : string.Empty);
        }

        public const int CompanyMainCodeMaxLength = 50;
        public const int CompanyJobCodeMaxLength = 50;
        public const int WorkExperienceYearCodeMaxLength = 50;
        public const int EducationLevelMaxLength = 200;
        public const int MajorDepartmentCategoryMaxLength = 200;
        public const int LanguageCategoryMaxLength = 200;
        public const int ComputerExpertiseMaxLength = 500;
        public const int ProfessionalLicenseMaxLength = 500;
        public const int DrvingLicenseMaxLength = 200;
        public const int EtcConditionMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}