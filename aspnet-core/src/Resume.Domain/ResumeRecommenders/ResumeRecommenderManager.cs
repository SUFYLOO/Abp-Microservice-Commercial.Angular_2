using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderManager : DomainService
    {
        private readonly IResumeRecommenderRepository _resumeRecommenderRepository;

        public ResumeRecommenderManager(IResumeRecommenderRepository resumeRecommenderRepository)
        {
            _resumeRecommenderRepository = resumeRecommenderRepository;
        }

        public async Task<ResumeRecommender> CreateAsync(
        Guid resumeMainId, string name, DateTime dateA, DateTime dateD, int sort, string status, string companyName = null, string jobName = null, string mobilePhone = null, string officePhone = null, string email = null, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeRecommenderConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeRecommenderConsts.StatusMaxLength);
            Check.Length(companyName, nameof(companyName), ResumeRecommenderConsts.CompanyNameMaxLength);
            Check.Length(jobName, nameof(jobName), ResumeRecommenderConsts.JobNameMaxLength);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeRecommenderConsts.MobilePhoneMaxLength);
            Check.Length(officePhone, nameof(officePhone), ResumeRecommenderConsts.OfficePhoneMaxLength);
            Check.Length(email, nameof(email), ResumeRecommenderConsts.EmailMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeRecommenderConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeRecommenderConsts.NoteMaxLength);

            var resumeRecommender = new ResumeRecommender(
             GuidGenerator.Create(),
             resumeMainId, name, dateA, dateD, sort, status, companyName, jobName, mobilePhone, officePhone, email, extendedInformation, note
             );

            return await _resumeRecommenderRepository.InsertAsync(resumeRecommender);
        }

        public async Task<ResumeRecommender> UpdateAsync(
            Guid id,
            Guid resumeMainId, string name, DateTime dateA, DateTime dateD, int sort, string status, string companyName = null, string jobName = null, string mobilePhone = null, string officePhone = null, string email = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeRecommenderConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeRecommenderConsts.StatusMaxLength);
            Check.Length(companyName, nameof(companyName), ResumeRecommenderConsts.CompanyNameMaxLength);
            Check.Length(jobName, nameof(jobName), ResumeRecommenderConsts.JobNameMaxLength);
            Check.Length(mobilePhone, nameof(mobilePhone), ResumeRecommenderConsts.MobilePhoneMaxLength);
            Check.Length(officePhone, nameof(officePhone), ResumeRecommenderConsts.OfficePhoneMaxLength);
            Check.Length(email, nameof(email), ResumeRecommenderConsts.EmailMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeRecommenderConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeRecommenderConsts.NoteMaxLength);

            var resumeRecommender = await _resumeRecommenderRepository.GetAsync(id);

            resumeRecommender.ResumeMainId = resumeMainId;
            resumeRecommender.Name = name;
            resumeRecommender.DateA = dateA;
            resumeRecommender.DateD = dateD;
            resumeRecommender.Sort = sort;
            resumeRecommender.Status = status;
            resumeRecommender.CompanyName = companyName;
            resumeRecommender.JobName = jobName;
            resumeRecommender.MobilePhone = mobilePhone;
            resumeRecommender.OfficePhone = officePhone;
            resumeRecommender.Email = email;
            resumeRecommender.ExtendedInformation = extendedInformation;
            resumeRecommender.Note = note;

            return await _resumeRecommenderRepository.UpdateAsync(resumeRecommender);
        }

    }
}