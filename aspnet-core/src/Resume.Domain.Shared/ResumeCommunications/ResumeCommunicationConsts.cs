namespace Resume.ResumeCommunications
{
    public static class ResumeCommunicationConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeCommunication." : string.Empty);
        }

        public const int CommunicationCategoryCodeMaxLength = 50;
        public const int CommunicationValueMaxLength = 200;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}