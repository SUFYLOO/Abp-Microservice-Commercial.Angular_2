namespace Resume.ShareDictionarys
{
    public static class ShareDictionaryConsts
    {
        private const string DefaultSorting = "{0}ShareLanguageId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareDictionary." : string.Empty);
        }

        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int NameMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}