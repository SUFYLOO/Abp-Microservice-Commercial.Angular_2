namespace Resume.ResumeMains
{
    public static class ResumeMainConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeMain." : string.Empty);
        }

        public const int ResumeNameMaxLength = 50;
        public const int MarriageCodeMaxLength = 50;
        public const int MilitaryCodeMaxLength = 50;
        public const int DisabilityCategoryCodeMaxLength = 50;
        public const int SpecialIdentityCodeMaxLength = 50;
        public const int Autobiography1MaxLength = 4000;
        public const int Autobiography2MaxLength = 4000;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}