namespace Resume.ResumeEducationss
{
    public static class ResumeEducationsConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeEducations." : string.Empty);
        }

        public const int EducationLevelCodeMaxLength = 50;
        public const int SchoolCodeMaxLength = 50;
        public const int SchoolNameMaxLength = 200;
        public const int MajorDepartmentNameMaxLength = 50;
        public const int MajorDepartmentCategoryMaxLength = 500;
        public const int MinorDepartmentNameMaxLength = 50;
        public const int MinorDepartmentCategoryMaxLength = 500;
        public const int GraduationCodeMaxLength = 50;
        public const int CountryCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}