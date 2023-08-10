using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Resume.EntityFrameworkCore;

namespace Resume.CompanyInvitationss
{
    public class EfCoreCompanyInvitationsRepository : EfCoreRepository<ResumeDbContext, CompanyInvitations, Guid>, ICompanyInvitationsRepository
    {
        public EfCoreCompanyInvitationsRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyInvitations>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            bool? openAllJob = null,
            Guid? userMainId = null,
            string userMainName = null,
            string userMainLoginMobilePhone = null,
            string userMainLoginEmail = null,
            string userMainLoginIdentityNo = null,
            string sendTypeCode = null,
            string sendStatusCode = null,
            string resumeFlowStageCode = null,
            bool? isRead = null,
            Guid? userCompanyBindId = null,
            Guid? resumeSnapshotId = null,
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainId, companyJobId, openAllJob, userMainId, userMainName, userMainLoginMobilePhone, userMainLoginEmail, userMainLoginIdentityNo, sendTypeCode, sendStatusCode, resumeFlowStageCode, isRead, userCompanyBindId, resumeSnapshotId, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyInvitationsConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            bool? openAllJob = null,
            Guid? userMainId = null,
            string userMainName = null,
            string userMainLoginMobilePhone = null,
            string userMainLoginEmail = null,
            string userMainLoginIdentityNo = null,
            string sendTypeCode = null,
            string sendStatusCode = null,
            string resumeFlowStageCode = null,
            bool? isRead = null,
            Guid? userCompanyBindId = null,
            Guid? resumeSnapshotId = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainId, companyJobId, openAllJob, userMainId, userMainName, userMainLoginMobilePhone, userMainLoginEmail, userMainLoginIdentityNo, sendTypeCode, sendStatusCode, resumeFlowStageCode, isRead, userCompanyBindId, resumeSnapshotId, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyInvitations> ApplyFilter(
            IQueryable<CompanyInvitations> query,
            string filterText,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            bool? openAllJob = null,
            Guid? userMainId = null,
            string userMainName = null,
            string userMainLoginMobilePhone = null,
            string userMainLoginEmail = null,
            string userMainLoginIdentityNo = null,
            string sendTypeCode = null,
            string sendStatusCode = null,
            string resumeFlowStageCode = null,
            bool? isRead = null,
            Guid? userCompanyBindId = null,
            Guid? resumeSnapshotId = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.UserMainName.Contains(filterText) || e.UserMainLoginMobilePhone.Contains(filterText) || e.UserMainLoginEmail.Contains(filterText) || e.UserMainLoginIdentityNo.Contains(filterText) || e.SendTypeCode.Contains(filterText) || e.SendStatusCode.Contains(filterText) || e.ResumeFlowStageCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(companyJobId.HasValue, e => e.CompanyJobId == companyJobId)
                    .WhereIf(openAllJob.HasValue, e => e.OpenAllJob == openAllJob)
                    .WhereIf(userMainId.HasValue, e => e.UserMainId == userMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(userMainName), e => e.UserMainName.Contains(userMainName))
                    .WhereIf(!string.IsNullOrWhiteSpace(userMainLoginMobilePhone), e => e.UserMainLoginMobilePhone.Contains(userMainLoginMobilePhone))
                    .WhereIf(!string.IsNullOrWhiteSpace(userMainLoginEmail), e => e.UserMainLoginEmail.Contains(userMainLoginEmail))
                    .WhereIf(!string.IsNullOrWhiteSpace(userMainLoginIdentityNo), e => e.UserMainLoginIdentityNo.Contains(userMainLoginIdentityNo))
                    .WhereIf(!string.IsNullOrWhiteSpace(sendTypeCode), e => e.SendTypeCode.Contains(sendTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(sendStatusCode), e => e.SendStatusCode.Contains(sendStatusCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(resumeFlowStageCode), e => e.ResumeFlowStageCode.Contains(resumeFlowStageCode))
                    .WhereIf(isRead.HasValue, e => e.IsRead == isRead)
                    .WhereIf(userCompanyBindId.HasValue, e => e.UserCompanyBindId == userCompanyBindId)
                    .WhereIf(resumeSnapshotId.HasValue, e => e.ResumeSnapshotId == resumeSnapshotId)
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status));
        }
    }
}