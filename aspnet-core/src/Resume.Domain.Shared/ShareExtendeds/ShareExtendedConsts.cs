namespace Resume.ShareExtendeds
{
    public static class ShareExtendedConsts
    {
        private const string DefaultSorting = "{0}Key1 asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareExtended." : string.Empty);
        }

        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int Key4MaxLength = 50;
        public const int Key5MaxLength = 50;
        public const int FieldValueMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}