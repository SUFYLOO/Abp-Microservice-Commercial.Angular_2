using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.CompanyJobApplicationMethods
{
    public interface ICompanyJobApplicationMethodRepository : IRepository<CompanyJobApplicationMethod, Guid>
    {
        Task<List<CompanyJobApplicationMethod>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string orgDept = null,
            string orgContactPerson = null,
            string orgContactMail = null,
            int? toRespondDayMin = null,
            int? toRespondDayMax = null,
            bool? toRespond = null,
            bool? systemSendResume = null,
            bool? displayMail = null,
            string telephone = null,
            string personally = null,
            string personallyAddress = null,
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
            string orgDept = null,
            string orgContactPerson = null,
            string orgContactMail = null,
            int? toRespondDayMin = null,
            int? toRespondDayMax = null,
            bool? toRespond = null,
            bool? systemSendResume = null,
            bool? displayMail = null,
            string telephone = null,
            string personally = null,
            string personallyAddress = null,
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