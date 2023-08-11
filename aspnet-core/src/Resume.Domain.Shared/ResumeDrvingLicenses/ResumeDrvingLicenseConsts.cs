namespace Resume.ResumeDrvingLicenses
{
    public static class ResumeDrvingLicenseConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeDrvingLicense." : string.Empty);
        }

        public const int DrvingLicenseCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}