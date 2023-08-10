using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyInvitationss
{
    public interface ICompanyInvitationsRepository : IRepository<CompanyInvitations, Guid>
    {
        Task<List<CompanyInvitations>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default);
    }
}