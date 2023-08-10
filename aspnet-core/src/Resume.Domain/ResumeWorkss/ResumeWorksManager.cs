using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeWorkss
{
    public class ResumeWorksManager : DomainService
    {
        private readonly IResumeWorksRepository _resumeWorksRepository;

        public ResumeWorksManager(IResumeWorksRepository resumeWorksRepository)
        {
            _resumeWorksRepository = resumeWorksRepository;
        }

        public async Task<ResumeWorks> CreateAsync(
        Guid resumeMainId, string name, string link, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeWorksConsts.NameMaxLength);
            Check.Length(link, nameof(link), ResumeWorksConsts.LinkMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeWorksConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeWorksConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeWorksConsts.NoteMaxLength);

            var resumeWorks = new ResumeWorks(
             GuidGenerator.Create(),
             resumeMainId, name, link, dateA, dateD, sort, status, extendedInformation, note
             );

            return await _resumeWorksRepository.InsertAsync(resumeWorks);
        }

        public async Task<ResumeWorks> UpdateAsync(
            Guid id,
            Guid resumeMainId, string name, string link, DateTime dateA, DateTime dateD, int sort, string status, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeWorksConsts.NameMaxLength);
            Check.Length(link, nameof(link), ResumeWorksConsts.LinkMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeWorksConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeWorksConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeWorksConsts.NoteMaxLength);

            var resumeWorks = await _resumeWorksRepository.GetAsync(id);

            resumeWorks.ResumeMainId = resumeMainId;
            resumeWorks.Name = name;
            resumeWorks.Link = link;
            resumeWorks.DateA = dateA;
            resumeWorks.DateD = dateD;
            resumeWorks.Sort = sort;
            resumeWorks.Status = status;
            resumeWorks.ExtendedInformation = extendedInformation;
            resumeWorks.Note = note;

            return await _resumeWorksRepository.UpdateAsync(resumeWorks);
        }

    }
}