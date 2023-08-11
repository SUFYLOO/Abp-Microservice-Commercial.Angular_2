namespace Resume.CompanyJobPairs
{
    public static class CompanyJobPairConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobPair." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int PairConditionMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}