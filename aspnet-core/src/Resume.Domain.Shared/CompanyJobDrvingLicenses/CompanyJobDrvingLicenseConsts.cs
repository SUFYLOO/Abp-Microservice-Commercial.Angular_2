namespace Resume.CompanyJobDrvingLicenses
{
    public static class CompanyJobDrvingLicenseConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobDrvingLicense." : string.Empty);
        }

        public const int DrvingLicenseCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}