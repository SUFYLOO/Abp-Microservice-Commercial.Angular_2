namespace Resume.SystemColumns
{
    public static class SystemColumnConsts
    {
        private const string DefaultSorting = "{0}SystemTableId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SystemColumn." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int DefaultValueMaxLength = 50;
        public const int RelatedMaxLength = 200;
        public const int ColumnTypeCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}