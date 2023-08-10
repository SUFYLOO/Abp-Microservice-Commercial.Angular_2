namespace Resume.TradeOderDetails
{
    public static class TradeOderDetailConsts
    {
        private const string DefaultSorting = "{0}TradeOrderId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TradeOderDetail." : string.Empty);
        }

        public const int OrderDetailStateCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}