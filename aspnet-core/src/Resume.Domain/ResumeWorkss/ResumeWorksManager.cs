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
        Guid resumeMainId, string name, string link, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeWorksConsts.NameMaxLength);
            Check.Length(link, nameof(link), ResumeWorksConsts.LinkMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeWorksConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeWorksConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeWorksConsts.StatusMaxLength);

            var resumeWorks = new ResumeWorks(
             GuidGenerator.Create(),
             resumeMainId, name, link, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeWorksRepository.InsertAsync(resumeWorks);
        }

        public async Task<ResumeWorks> UpdateAsync(
            Guid id,
            Guid resumeMainId, string name, string link, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), ResumeWorksConsts.NameMaxLength);
            Check.Length(link, nameof(link), ResumeWorksConsts.LinkMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeWorksConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeWorksConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeWorksConsts.StatusMaxLength);

            var resumeWorks = await _resumeWorksRepository.GetAsync(id);

            resumeWorks.ResumeMainId = resumeMainId;
            resumeWorks.Name = name;
            resumeWorks.Link = link;
            resumeWorks.ExtendedInformation = extendedInformation;
            resumeWorks.DateA = dateA;
            resumeWorks.DateD = dateD;
            resumeWorks.Sort = sort;
            resumeWorks.Note = note;
            resumeWorks.Status = status;

            return await _resumeWorksRepository.UpdateAsync(resumeWorks);
        }

    }
}