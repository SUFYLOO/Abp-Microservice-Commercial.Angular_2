namespace Resume.SystemValidates
{
    public static class SystemValidateConsts
    {
        private const string DefaultSorting = "{0}Param asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SystemValidate." : string.Empty);
        }

        public const int ParamMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}