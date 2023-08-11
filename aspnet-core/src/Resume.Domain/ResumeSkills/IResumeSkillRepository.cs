using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ResumeSkills
{
    public interface IResumeSkillRepository : IRepository<ResumeSkill, Guid>
    {
        Task<List<ResumeSkill>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string computerSkills = null,
            string computerSkillsEtc = null,
            int? chineseTypingSpeedMin = null,
            int? chineseTypingSpeedMax = null,
            string chineseTypingCode = null,
            int? englishTypingSpeedMin = null,
            int? englishTypingSpeedMax = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string computerSkills = null,
            string computerSkillsEtc = null,
            int? chineseTypingSpeedMin = null,
            int? chineseTypingSpeedMax = null,
            string chineseTypingCode = null,
            int? englishTypingSpeedMin = null,
            int? englishTypingSpeedMax = null,
            string professionalLicense = null,
            string professionalLicenseEtc = null,
            string workSkills = null,
            string workSkillsEtc = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            CancellationToken cancellationToken = default);
    }
}