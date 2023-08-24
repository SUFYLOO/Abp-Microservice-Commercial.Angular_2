using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobManager : DomainService
    {
        private readonly IResumeExperiencesJobRepository _resumeExperiencesJobRepository;

        public ResumeExperiencesJobManager(IResumeExperiencesJobRepository resumeExperiencesJobRepository)
        {
            _resumeExperiencesJobRepository = resumeExperiencesJobRepository;
        }

        public async Task<ResumeExperiencesJob> CreateAsync(
        Guid resumeMainId, Guid resumeExperiencesId, string jobType, int year, int month, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(jobType, nameof(jobType));
            Check.Length(jobType, nameof(jobType), ResumeExperiencesJobConsts.JobTypeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesJobConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeExperiencesJobConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeExperiencesJobConsts.StatusMaxLength);

            var resumeExperiencesJob = new ResumeExperiencesJob(
             GuidGenerator.Create(),
             resumeMainId, resumeExperiencesId, jobType, year, month, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeExperiencesJobRepository.InsertAsync(resumeExperiencesJob);
        }

        public async Task<ResumeExperiencesJob> UpdateAsync(
            Guid id,
            Guid resumeMainId, Guid resumeExperiencesId, string jobType, int year, int month, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(jobType, nameof(jobType));
            Check.Length(jobType, nameof(jobType), ResumeExperiencesJobConsts.JobTypeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeExperiencesJobConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeExperiencesJobConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeExperiencesJobConsts.StatusMaxLength);

            var resumeExperiencesJob = await _resumeExperiencesJobRepository.GetAsync(id);

            resumeExperiencesJob.ResumeMainId = resumeMainId;
            resumeExperiencesJob.ResumeExperiencesId = resumeExperiencesId;
            resumeExperiencesJob.JobType = jobType;
            resumeExperiencesJob.Year = year;
            resumeExperiencesJob.Month = month;
            resumeExperiencesJob.ExtendedInformation = extendedInformation;
            resumeExperiencesJob.DateA = dateA;
            resumeExperiencesJob.DateD = dateD;
            resumeExperiencesJob.Sort = sort;
            resumeExperiencesJob.Note = note;
            resumeExperiencesJob.Status = status;

            resumeExperiencesJob.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _resumeExperiencesJobRepository.UpdateAsync(resumeExperiencesJob);
        }

    }
}