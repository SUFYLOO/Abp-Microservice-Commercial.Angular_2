namespace Resume.CompanyJobConditions
{
    public static class CompanyJobConditionConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobCondition." : string.Empty);
        }

        public const int WorkExperienceYearCodeMaxLength = 50;
        public const int EducationLevelMaxLength = 500;
        public const int MajorDepartmentCategoryMaxLength = 500;
        public const int LanguageConditionMaxLength = 4000;
        public const int ComputerExpertiseEtcMaxLength = 4000;
        public const int ProfessionalLicenseMaxLength = 500;
        public const int ProfessionalLicenseEtcMaxLength = 5000;
        public const int WorkSkillsMaxLength = 500;
        public const int WorkSkillsEtcMaxLength = 5000;
        public const int DrvingLicenseMaxLength = 4000;
        public const int EtcConditionMaxLength = 4000;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}