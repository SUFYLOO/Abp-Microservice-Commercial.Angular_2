namespace Resume.CompanyMains
{
    public static class CompanyMainConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyMain." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int CompilationMaxLength = 50;
        public const int OfficePhoneMaxLength = 50;
        public const int FaxPhoneMaxLength = 50;
        public const int AddressMaxLength = 50;
        public const int PrincipalMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
        public const int IndustryCategoryMaxLength = 500;
        public const int CompanyUrlMaxLength = 200;
        public const int CompanyScaleCodeMaxLength = 50;
        public const int CompanyProfileMaxLength = 500;
        public const int BusinessPhilosophyMaxLength = 500;
        public const int OperatingItemsMaxLength = 500;
        public const int WelfareSystemMaxLength = 500;
    }
}