namespace Resume.ResumeWorkss
{
    public static class ResumeWorksConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeWorks." : string.Empty);
        }

        public const int NameMaxLength = 200;
        public const int LinkMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}