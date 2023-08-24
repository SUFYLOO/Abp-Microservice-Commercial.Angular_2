namespace Resume.CompanyJobDisabilityCategories
{
    public static class CompanyJobDisabilityCategoryConsts
    {
        private const string DefaultSorting = "{0}CompanyMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "CompanyJobDisabilityCategory." : string.Empty);
        }

        public const int DisabilityCategoryCodeMaxLength = 50;
        public const int DisabilityLevelCodeMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}