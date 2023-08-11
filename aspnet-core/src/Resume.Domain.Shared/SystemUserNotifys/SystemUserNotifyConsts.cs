namespace Resume.SystemUserNotifys
{
    public static class SystemUserNotifyConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "SystemUserNotify." : string.Empty);
        }

        public const int KeyIdMaxLength = 50;
        public const int KeyNameMaxLength = 50;
        public const int NotifyTypeCodeMaxLength = 50;
        public const int AppNameMaxLength = 50;
        public const int AppCodeMaxLength = 50;
        public const int TitleContentsMaxLength = 500;
        public const int ContentsMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}