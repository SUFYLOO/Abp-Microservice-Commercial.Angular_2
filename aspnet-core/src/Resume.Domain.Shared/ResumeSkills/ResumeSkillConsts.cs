namespace Resume.ResumeSkills
{
    public static class ResumeSkillConsts
    {
        private const string DefaultSorting = "{0}ResumeMainId asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "ResumeSkill." : string.Empty);
        }

        public const int ComputerSkillsMaxLength = 500;
        public const int ComputerSkillsEtcMaxLength = 500;
        public const int ChineseTypingCodeMaxLength = 50;
        public const int ProfessionalLicenseMaxLength = 500;
        public const int ProfessionalLicenseEtcMaxLength = 500;
        public const int WorkSkillsMaxLength = 500;
        public const int WorkSkillsEtcMaxLength = 500;
        public const int ExtendedInformationMaxLength = 500;
        public const int NoteMaxLength = 500;
        public const int StatusMaxLength = 50;
    }
}