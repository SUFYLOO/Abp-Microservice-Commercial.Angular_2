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

namespace Resume.CompanyJobApplicationMethods
{
    public class EfCoreCompanyJobApplicationMethodRepository : EfCoreRepository<ResumeDbContext, CompanyJobApplicationMethod, Guid>, ICompanyJobApplicationMethodRepository
    {
        public EfCoreCompanyJobApplicationMethodRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyJobApplicationMethod>> GetListAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainId, companyJobId, orgDept, orgContactPerson, orgContactMail, toRespondDayMin, toRespondDayMax, toRespond, systemSendResume, displayMail, telephone, personally, personallyAddress, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyJobApplicationMethodConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
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
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainId, companyJobId, orgDept, orgContactPerson, orgContactMail, toRespondDayMin, toRespondDayMax, toRespond, systemSendResume, displayMail, telephone, personally, personallyAddress, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyJobApplicationMethod> ApplyFilter(
            IQueryable<CompanyJobApplicationMethod> query,
            string filterText,
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
            string status = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.OrgDept.Contains(filterText) || e.OrgContactPerson.Contains(filterText) || e.OrgContactMail.Contains(filterText) || e.Telephone.Contains(filterText) || e.Personally.Contains(filterText) || e.PersonallyAddress.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(companyJobId.HasValue, e => e.CompanyJobId == companyJobId)
                    .WhereIf(!string.IsNullOrWhiteSpace(orgDept), e => e.OrgDept.Contains(orgDept))
                    .WhereIf(!string.IsNullOrWhiteSpace(orgContactPerson), e => e.OrgContactPerson.Contains(orgContactPerson))
                    .WhereIf(!string.IsNullOrWhiteSpace(orgContactMail), e => e.OrgContactMail.Contains(orgContactMail))
                    .WhereIf(toRespondDayMin.HasValue, e => e.ToRespondDay >= toRespondDayMin.Value)
                    .WhereIf(toRespondDayMax.HasValue, e => e.ToRespondDay <= toRespondDayMax.Value)
                    .WhereIf(toRespond.HasValue, e => e.ToRespond == toRespond)
                    .WhereIf(systemSendResume.HasValue, e => e.SystemSendResume == systemSendResume)
                    .WhereIf(displayMail.HasValue, e => e.DisplayMail == displayMail)
                    .WhereIf(!string.IsNullOrWhiteSpace(telephone), e => e.Telephone.Contains(telephone))
                    .WhereIf(!string.IsNullOrWhiteSpace(personally), e => e.Personally.Contains(personally))
                    .WhereIf(!string.IsNullOrWhiteSpace(personallyAddress), e => e.PersonallyAddress.Contains(personallyAddress))
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