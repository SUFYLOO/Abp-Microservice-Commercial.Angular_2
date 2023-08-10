namespace Resume.CompanyUsers
{
    public static class CompanyUserConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyUser." : string.Empty);
        }

        public const int JobNameMaxLength = 50;
        public const int OfficePhoneMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}