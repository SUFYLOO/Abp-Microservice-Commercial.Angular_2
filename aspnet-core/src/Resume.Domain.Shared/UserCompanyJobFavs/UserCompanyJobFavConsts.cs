namespace Resume.UserCompanyJobFavs
{
    public static class UserCompanyJobFavConsts
    {
        private const string DefaultSorting = "{0}UserMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "UserCompanyJobFav." : string.Empty);
        }

        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}