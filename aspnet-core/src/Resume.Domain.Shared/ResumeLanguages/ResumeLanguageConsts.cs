namespace Resume.ResumeLanguages
{
    public static class ResumeLanguageConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeLanguage." : string.Empty);
        }

        public const int LanguageCategoryCodeMaxLength = 50;
        public const int LevelSayCodeMaxLength = 50;
        public const int LevelListenCodeMaxLength = 50;
        public const int LevelReadCodeMaxLength = 50;
        public const int LevelWriteCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}