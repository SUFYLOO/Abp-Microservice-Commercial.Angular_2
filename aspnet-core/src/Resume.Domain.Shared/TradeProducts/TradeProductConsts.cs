namespace Resume.TradeProducts
{
    public static class TradeProductConsts
    {
        private const string DefaultSorting = "{0}Name asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TradeProduct." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int ContentsMaxLength = 500;
        public const int ProductCategoryCodeMaxLength = 50;
        public const int UnitCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int OrderStateCodeMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}