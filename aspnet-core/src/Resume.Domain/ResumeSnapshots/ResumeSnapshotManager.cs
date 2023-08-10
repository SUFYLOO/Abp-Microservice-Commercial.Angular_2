using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotManager : DomainService
    {
        private readonly IResumeSnapshotRepository _resumeSnapshotRepository;

        public ResumeSnapshotManager(IResumeSnapshotRepository resumeSnapshotRepository)
        {
            _resumeSnapshotRepository = resumeSnapshotRepository;
        }

        public async Task<ResumeSnapshot> CreateAsync(
        Guid userMainId, Guid resumeMainId, Guid companyMainId, string snapshot, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? userCompanyBindId = null, string extendedInformation = null, string note = null)
        {
            Check.NotNullOrWhiteSpace(snapshot, nameof(snapshot));
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSnapshotConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSnapshotConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSnapshotConsts.NoteMaxLength);

            var resumeSnapshot = new ResumeSnapshot(
             GuidGenerator.Create(),
             userMainId, resumeMainId, companyMainId, snapshot, dateA, dateD, sort, status, companyJobId, userCompanyBindId, extendedInformation, note
             );

            return await _resumeSnapshotRepository.InsertAsync(resumeSnapshot);
        }

        public async Task<ResumeSnapshot> UpdateAsync(
            Guid id,
            Guid userMainId, Guid resumeMainId, Guid companyMainId, string snapshot, DateTime dateA, DateTime dateD, int sort, string status, Guid? companyJobId = null, Guid? userCompanyBindId = null, string extendedInformation = null, string note = null
        )
        {
            Check.NotNullOrWhiteSpace(snapshot, nameof(snapshot));
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), ResumeSnapshotConsts.StatusMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSnapshotConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSnapshotConsts.NoteMaxLength);

            var resumeSnapshot = await _resumeSnapshotRepository.GetAsync(id);

            resumeSnapshot.UserMainId = userMainId;
            resumeSnapshot.ResumeMainId = resumeMainId;
            resumeSnapshot.CompanyMainId = companyMainId;
            resumeSnapshot.Snapshot = snapshot;
            resumeSnapshot.DateA = dateA;
            resumeSnapshot.DateD = dateD;
            resumeSnapshot.Sort = sort;
            resumeSnapshot.Status = status;
            resumeSnapshot.CompanyJobId = companyJobId;
            resumeSnapshot.UserCompanyBindId = userCompanyBindId;
            resumeSnapshot.ExtendedInformation = extendedInformation;
            resumeSnapshot.Note = note;

            return await _resumeSnapshotRepository.UpdateAsync(resumeSnapshot);
        }

    }
}