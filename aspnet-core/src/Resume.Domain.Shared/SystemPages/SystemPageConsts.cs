namespace Resume.SystemPages
{
    public static class SystemPageConsts
    {
        private const string DefaultSorting = "{0}TypeCode asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SystemPage." : string.Empty);
        }

        public const int TypeCodeMaxLength = 50;
        public const int FilePathMaxLength = 500;
        public const int FileNameMaxLength = 500;
        public const int FileTitleMaxLength = 200;
        public const int SystemUserRoleKeysMaxLength = 50;
        public const int ParentCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}