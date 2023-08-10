namespace Resume.ShareDefaults
{
    public static class ShareDefaultConsts
    {
        private const string DefaultSorting = "{0}GroupCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareDefault." : string.Empty);
        }

        public const int GroupCodeMaxLength = 50;
        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int NameMaxLength = 200;
        public const int FieldKeyMaxLength = 50;
        public const int FieldValueMaxLength = 500;
        public const int ColumnTypeCodeMaxLength = 50;
        public const int FormTypeCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}