namespace Resume.ShareSendQueues
{
    public static class ShareSendQueueConsts
    {
        private const string DefaultSorting = "{0}Key1 asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ShareSendQueue." : string.Empty);
        }

        public const int Key1MaxLength = 50;
        public const int Key2MaxLength = 50;
        public const int Key3MaxLength = 50;
        public const int SendTypeCodeMaxLength = 50;
        public const int FromAddrMaxLength = 200;
        public const int ToAddrMaxLength = 500;
        public const int TitleContentsMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}