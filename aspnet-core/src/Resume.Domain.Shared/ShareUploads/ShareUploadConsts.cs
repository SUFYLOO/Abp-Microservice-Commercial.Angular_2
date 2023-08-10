namespace Resume.ShareUploads
{
    public static class ShareUploadConsts
    {
        private const string DefaultSorting = "{0}Key1 asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareUpload." : string.Empty);
        }

        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int UploadNameMaxLength = 200;
        public const int ServerNameMaxLength = 200;
        public const int TypeMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}