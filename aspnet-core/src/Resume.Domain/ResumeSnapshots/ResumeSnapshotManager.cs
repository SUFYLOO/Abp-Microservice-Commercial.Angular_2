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
        Guid userMainId, Guid resumeMainId, Guid companyMainId, string snapshot, Guid? companyJobId = null, Guid? userCompanyBindId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(snapshot, nameof(snapshot));
            Check.Length(snapshot, nameof(snapshot), ResumeSnapshotConsts.SnapshotMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSnapshotConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSnapshotConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeSnapshotConsts.StatusMaxLength);

            var resumeSnapshot = new ResumeSnapshot(
             GuidGenerator.Create(),
             userMainId, resumeMainId, companyMainId, snapshot, companyJobId, userCompanyBindId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _resumeSnapshotRepository.InsertAsync(resumeSnapshot);
        }

        public async Task<ResumeSnapshot> UpdateAsync(
            Guid id,
            Guid userMainId, Guid resumeMainId, Guid companyMainId, string snapshot, Guid? companyJobId = null, Guid? userCompanyBindId = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.NotNullOrWhiteSpace(snapshot, nameof(snapshot));
            Check.Length(snapshot, nameof(snapshot), ResumeSnapshotConsts.SnapshotMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), ResumeSnapshotConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), ResumeSnapshotConsts.NoteMaxLength);
            Check.Length(status, nameof(status), ResumeSnapshotConsts.StatusMaxLength);

            var resumeSnapshot = await _resumeSnapshotRepository.GetAsync(id);

            resumeSnapshot.UserMainId = userMainId;
            resumeSnapshot.ResumeMainId = resumeMainId;
            resumeSnapshot.CompanyMainId = companyMainId;
            resumeSnapshot.Snapshot = snapshot;
            resumeSnapshot.CompanyJobId = companyJobId;
            resumeSnapshot.UserCompanyBindId = userCompanyBindId;
            resumeSnapshot.ExtendedInformation = extendedInformation;
            resumeSnapshot.DateA = dateA;
            resumeSnapshot.DateD = dateD;
            resumeSnapshot.Sort = sort;
            resumeSnapshot.Note = note;
            resumeSnapshot.Status = status;

            return await _resumeSnapshotRepository.UpdateAsync(resumeSnapshot);
        }

    }
}