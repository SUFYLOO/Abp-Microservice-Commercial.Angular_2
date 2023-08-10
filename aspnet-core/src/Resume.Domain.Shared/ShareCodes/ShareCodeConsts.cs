namespace Resume.ShareCodes
{
    public static class ShareCodeConsts
    {
        private const string DefaultSorting = "{0}GroupCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareCode." : string.Empty);
        }

        public const int GroupCodeMaxLength = 50;
        public const int Key1MaxLength = 100;
        public const int Key2MaxLength = 100;
        public const int Key3MaxLength = 100;
        public const int NameMaxLength = 100;
        public const int Column1MaxLength = 50;
        public const int Column2MaxLength = 50;
        public const int Column3MaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}