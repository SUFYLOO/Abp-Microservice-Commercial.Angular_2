namespace Resume.ShareMessageTpls
{
    public static class ShareMessageTplConsts
    {
        private const string DefaultSorting = "{0}Key1 asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareMessageTpl." : string.Empty);
        }

        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int NameMaxLength = 50;
        public const int StatementMaxLength = 500;
        public const int TitleContentsMaxLength = 500;
        public const int ContentSMSMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}