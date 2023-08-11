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

namespace Resume.CompanyJobContents
{
    public class EfCoreCompanyJobContentRepository : EfCoreRepository<ResumeDbContext, CompanyJobContent, Guid>, ICompanyJobContentRepository
    {
        public EfCoreCompanyJobContentRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyJobContent>> GetListAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string name = null,
            string jobTypeCode = null,
            int? peopleRequiredNumberMin = null,
            int? peopleRequiredNumberMax = null,
            bool? peopleRequiredNumberUnlimited = null,
            string jobType = null,
            string jobTypeContent = null,
            string salaryPayTypeCode = null,
            int? salaryMinMin = null,
            int? salaryMinMax = null,
            int? salaryMaxMin = null,
            int? salaryMaxMax = null,
            bool? salaryUp = null,
            string workPlace = null,
            string workHours = null,
            string workHour = null,
            bool? workShift = null,
            bool? workRemoteAllow = null,
            string workRemoteTypeCode = null,
            string workRemote = null,
            string workDifferentPlaces = null,
            string holidaySystemCode = null,
            string workDayCode = null,
            string workIdentityCode = null,
            string disabilityCategory = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, companyMainId, companyJobId, name, jobTypeCode, peopleRequiredNumberMin, peopleRequiredNumberMax, peopleRequiredNumberUnlimited, jobType, jobTypeContent, salaryPayTypeCode, salaryMinMin, salaryMinMax, salaryMaxMin, salaryMaxMax, salaryUp, workPlace, workHours, workHour, workShift, workRemoteAllow, workRemoteTypeCode, workRemote, workDifferentPlaces, holidaySystemCode, workDayCode, workIdentityCode, disabilityCategory, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyJobContentConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string name = null,
            string jobTypeCode = null,
            int? peopleRequiredNumberMin = null,
            int? peopleRequiredNumberMax = null,
            bool? peopleRequiredNumberUnlimited = null,
            string jobType = null,
            string jobTypeContent = null,
            string salaryPayTypeCode = null,
            int? salaryMinMin = null,
            int? salaryMinMax = null,
            int? salaryMaxMin = null,
            int? salaryMaxMax = null,
            bool? salaryUp = null,
            string workPlace = null,
            string workHours = null,
            string workHour = null,
            bool? workShift = null,
            bool? workRemoteAllow = null,
            string workRemoteTypeCode = null,
            string workRemote = null,
            string workDifferentPlaces = null,
            string holidaySystemCode = null,
            string workDayCode = null,
            string workIdentityCode = null,
            string disabilityCategory = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, companyMainId, companyJobId, name, jobTypeCode, peopleRequiredNumberMin, peopleRequiredNumberMax, peopleRequiredNumberUnlimited, jobType, jobTypeContent, salaryPayTypeCode, salaryMinMin, salaryMinMax, salaryMaxMin, salaryMaxMax, salaryUp, workPlace, workHours, workHour, workShift, workRemoteAllow, workRemoteTypeCode, workRemote, workDifferentPlaces, holidaySystemCode, workDayCode, workIdentityCode, disabilityCategory, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyJobContent> ApplyFilter(
            IQueryable<CompanyJobContent> query,
            string filterText,
            Guid? companyMainId = null,
            Guid? companyJobId = null,
            string name = null,
            string jobTypeCode = null,
            int? peopleRequiredNumberMin = null,
            int? peopleRequiredNumberMax = null,
            bool? peopleRequiredNumberUnlimited = null,
            string jobType = null,
            string jobTypeContent = null,
            string salaryPayTypeCode = null,
            int? salaryMinMin = null,
            int? salaryMinMax = null,
            int? salaryMaxMin = null,
            int? salaryMaxMax = null,
            bool? salaryUp = null,
            string workPlace = null,
            string workHours = null,
            string workHour = null,
            bool? workShift = null,
            bool? workRemoteAllow = null,
            string workRemoteTypeCode = null,
            string workRemote = null,
            string workDifferentPlaces = null,
            string holidaySystemCode = null,
            string workDayCode = null,
            string workIdentityCode = null,
            string disabilityCategory = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.JobTypeCode.Contains(filterText) || e.JobType.Contains(filterText) || e.JobTypeContent.Contains(filterText) || e.SalaryPayTypeCode.Contains(filterText) || e.WorkPlace.Contains(filterText) || e.WorkHours.Contains(filterText) || e.WorkHour.Contains(filterText) || e.WorkRemoteTypeCode.Contains(filterText) || e.WorkRemote.Contains(filterText) || e.WorkDifferentPlaces.Contains(filterText) || e.HolidaySystemCode.Contains(filterText) || e.WorkDayCode.Contains(filterText) || e.WorkIdentityCode.Contains(filterText) || e.DisabilityCategory.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(companyMainId.HasValue, e => e.CompanyMainId == companyMainId)
                    .WhereIf(companyJobId.HasValue, e => e.CompanyJobId == companyJobId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(jobTypeCode), e => e.JobTypeCode.Contains(jobTypeCode))
                    .WhereIf(peopleRequiredNumberMin.HasValue, e => e.PeopleRequiredNumber >= peopleRequiredNumberMin.Value)
                    .WhereIf(peopleRequiredNumberMax.HasValue, e => e.PeopleRequiredNumber <= peopleRequiredNumberMax.Value)
                    .WhereIf(peopleRequiredNumberUnlimited.HasValue, e => e.PeopleRequiredNumberUnlimited == peopleRequiredNumberUnlimited)
                    .WhereIf(!string.IsNullOrWhiteSpace(jobType), e => e.JobType.Contains(jobType))
                    .WhereIf(!string.IsNullOrWhiteSpace(jobTypeContent), e => e.JobTypeContent.Contains(jobTypeContent))
                    .WhereIf(!string.IsNullOrWhiteSpace(salaryPayTypeCode), e => e.SalaryPayTypeCode.Contains(salaryPayTypeCode))
                    .WhereIf(salaryMinMin.HasValue, e => e.SalaryMin >= salaryMinMin.Value)
                    .WhereIf(salaryMinMax.HasValue, e => e.SalaryMin <= salaryMinMax.Value)
                    .WhereIf(salaryMaxMin.HasValue, e => e.SalaryMax >= salaryMaxMin.Value)
                    .WhereIf(salaryMaxMax.HasValue, e => e.SalaryMax <= salaryMaxMax.Value)
                    .WhereIf(salaryUp.HasValue, e => e.SalaryUp == salaryUp)
                    .WhereIf(!string.IsNullOrWhiteSpace(workPlace), e => e.WorkPlace.Contains(workPlace))
                    .WhereIf(!string.IsNullOrWhiteSpace(workHours), e => e.WorkHours.Contains(workHours))
                    .WhereIf(!string.IsNullOrWhiteSpace(workHour), e => e.WorkHour.Contains(workHour))
                    .WhereIf(workShift.HasValue, e => e.WorkShift == workShift)
                    .WhereIf(workRemoteAllow.HasValue, e => e.WorkRemoteAllow == workRemoteAllow)
                    .WhereIf(!string.IsNullOrWhiteSpace(workRemoteTypeCode), e => e.WorkRemoteTypeCode.Contains(workRemoteTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(workRemote), e => e.WorkRemote.Contains(workRemote))
                    .WhereIf(!string.IsNullOrWhiteSpace(workDifferentPlaces), e => e.WorkDifferentPlaces.Contains(workDifferentPlaces))
                    .WhereIf(!string.IsNullOrWhiteSpace(holidaySystemCode), e => e.HolidaySystemCode.Contains(holidaySystemCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(workDayCode), e => e.WorkDayCode.Contains(workDayCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(workIdentityCode), e => e.WorkIdentityCode.Contains(workIdentityCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(disabilityCategory), e => e.DisabilityCategory.Contains(disabilityCategory))
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