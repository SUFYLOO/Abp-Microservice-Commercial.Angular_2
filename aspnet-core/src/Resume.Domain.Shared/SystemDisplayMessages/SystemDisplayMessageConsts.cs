namespace Resume.SystemDisplayMessages
{
    public static class SystemDisplayMessageConsts
    {
        private const string DefaultSorting = "{0}DisplayTypeCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SystemDisplayMessage." : string.Empty);
        }

        public const int DisplayTypeCodeMaxLength = 50;
        public const int TitleContentsMaxLength = 500;
        public const int ContentsMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}