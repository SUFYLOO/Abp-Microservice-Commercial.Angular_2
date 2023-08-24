namespace Resume.ResumeSnapshots
{
    public static class ResumeSnapshotConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeSnapshot." : string.Empty);
        }

        public const int SnapshotMaxLength = 4000;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}