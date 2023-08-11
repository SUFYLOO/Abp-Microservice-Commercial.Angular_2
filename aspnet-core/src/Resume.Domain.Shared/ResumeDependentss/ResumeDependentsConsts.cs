namespace Resume.ResumeDependentss
{
    public static class ResumeDependentsConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeDependents." : string.Empty);
        }

        public const int NameMaxLength = 50;
        public const int IdentityNoMaxLength = 50;
        public const int KinshipCodeMaxLength = 50;
        public const int AddressMaxLength = 200;
        public const int MobilePhoneMaxLength = 50;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}