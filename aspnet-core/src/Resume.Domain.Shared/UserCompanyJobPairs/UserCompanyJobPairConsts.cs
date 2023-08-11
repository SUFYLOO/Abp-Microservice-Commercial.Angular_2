namespace Resume.UserCompanyJobPairs
{
    public static class UserCompanyJobPairConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserCompanyJobPair." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int PairConditionMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}