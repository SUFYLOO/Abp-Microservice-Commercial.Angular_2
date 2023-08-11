namespace Resume.TradeOrders
{
    public static class TradeOrderConsts
    {
        private const string DefaultSorting = "{0}KeyId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "TradeOrder." : string.Empty);
        }

        public const int OrderNumberMaxLength = 50;
        public const int DeliveryMethodCodeMaxLength = 50;
        public const int DeliveryZipCodeMaxLength = 50;
        public const int DeliveryCityCodeMaxLength = 50;
        public const int DeliveryAreaCodeMaxLength = 50;
        public const int DeliveryAddressMaxLength = 50;
        public const int UserNameMaxLength = 50;
        public const int OrderStateCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}