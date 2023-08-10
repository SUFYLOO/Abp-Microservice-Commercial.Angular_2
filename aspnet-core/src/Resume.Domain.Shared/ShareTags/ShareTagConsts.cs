namespace Resume.ShareTags
{
    public static class ShareTagConsts
    {
        private const string DefaultSorting = "{0}ColorCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareTag." : string.Empty);
        }

        public const int ColorCodeMaxLength = 50;
        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int NameMaxLength = 500;
        public const int TagCategoryCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}