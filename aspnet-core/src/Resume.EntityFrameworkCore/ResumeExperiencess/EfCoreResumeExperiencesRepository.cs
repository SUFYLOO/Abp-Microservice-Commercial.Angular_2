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

namespace Resume.ResumeExperiencess
{
    public class EfCoreResumeExperiencesRepository : EfCoreRepository<ResumeDbContext, ResumeExperiences, Guid>, IResumeExperiencesRepository
    {
        public EfCoreResumeExperiencesRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<ResumeExperiences>> GetListAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string workNatureCode = null,
            bool? hideCompanyName = null,
            string industryCategoryCode = null,
            string jobName = null,
            string jobType = null,
            bool? working = null,
            string workPlaceCode = null,
            bool? hideWorkSalary = null,
            string salaryPayTypeCode = null,
            string currencyTypeCode = null,
            decimal? salary1Min = null,
            decimal? salary1Max = null,
            decimal? salary2Min = null,
            decimal? salary2Max = null,
            string companyScaleCode = null,
            string companyManagementNumberCode = null,
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
            var query = ApplyFilter((await GetQueryableAsync()), filterText, resumeMainId, name, workNatureCode, hideCompanyName, industryCategoryCode, jobName, jobType, working, workPlaceCode, hideWorkSalary, salaryPayTypeCode, currencyTypeCode, salary1Min, salary1Max, salary2Min, salary2Max, companyScaleCode, companyManagementNumberCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? ResumeExperiencesConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            Guid? resumeMainId = null,
            string name = null,
            string workNatureCode = null,
            bool? hideCompanyName = null,
            string industryCategoryCode = null,
            string jobName = null,
            string jobType = null,
            bool? working = null,
            string workPlaceCode = null,
            bool? hideWorkSalary = null,
            string salaryPayTypeCode = null,
            string currencyTypeCode = null,
            decimal? salary1Min = null,
            decimal? salary1Max = null,
            decimal? salary2Min = null,
            decimal? salary2Max = null,
            string companyScaleCode = null,
            string companyManagementNumberCode = null,
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
            var query = ApplyFilter((await GetDbSetAsync()), filterText, resumeMainId, name, workNatureCode, hideCompanyName, industryCategoryCode, jobName, jobType, working, workPlaceCode, hideWorkSalary, salaryPayTypeCode, currencyTypeCode, salary1Min, salary1Max, salary2Min, salary2Max, companyScaleCode, companyManagementNumberCode, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, sortMin, sortMax, note, status);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<ResumeExperiences> ApplyFilter(
            IQueryable<ResumeExperiences> query,
            string filterText,
            Guid? resumeMainId = null,
            string name = null,
            string workNatureCode = null,
            bool? hideCompanyName = null,
            string industryCategoryCode = null,
            string jobName = null,
            string jobType = null,
            bool? working = null,
            string workPlaceCode = null,
            bool? hideWorkSalary = null,
            string salaryPayTypeCode = null,
            string currencyTypeCode = null,
            decimal? salary1Min = null,
            decimal? salary1Max = null,
            decimal? salary2Min = null,
            decimal? salary2Max = null,
            string companyScaleCode = null,
            string companyManagementNumberCode = null,
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
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.WorkNatureCode.Contains(filterText) || e.IndustryCategoryCode.Contains(filterText) || e.JobName.Contains(filterText) || e.JobType.Contains(filterText) || e.WorkPlaceCode.Contains(filterText) || e.SalaryPayTypeCode.Contains(filterText) || e.CurrencyTypeCode.Contains(filterText) || e.CompanyScaleCode.Contains(filterText) || e.CompanyManagementNumberCode.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText))
                    .WhereIf(resumeMainId.HasValue, e => e.ResumeMainId == resumeMainId)
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(workNatureCode), e => e.WorkNatureCode.Contains(workNatureCode))
                    .WhereIf(hideCompanyName.HasValue, e => e.HideCompanyName == hideCompanyName)
                    .WhereIf(!string.IsNullOrWhiteSpace(industryCategoryCode), e => e.IndustryCategoryCode.Contains(industryCategoryCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(jobName), e => e.JobName.Contains(jobName))
                    .WhereIf(!string.IsNullOrWhiteSpace(jobType), e => e.JobType.Contains(jobType))
                    .WhereIf(working.HasValue, e => e.Working == working)
                    .WhereIf(!string.IsNullOrWhiteSpace(workPlaceCode), e => e.WorkPlaceCode.Contains(workPlaceCode))
                    .WhereIf(hideWorkSalary.HasValue, e => e.HideWorkSalary == hideWorkSalary)
                    .WhereIf(!string.IsNullOrWhiteSpace(salaryPayTypeCode), e => e.SalaryPayTypeCode.Contains(salaryPayTypeCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(currencyTypeCode), e => e.CurrencyTypeCode.Contains(currencyTypeCode))
                    .WhereIf(salary1Min.HasValue, e => e.Salary1 >= salary1Min.Value)
                    .WhereIf(salary1Max.HasValue, e => e.Salary1 <= salary1Max.Value)
                    .WhereIf(salary2Min.HasValue, e => e.Salary2 >= salary2Min.Value)
                    .WhereIf(salary2Max.HasValue, e => e.Salary2 <= salary2Max.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyScaleCode), e => e.CompanyScaleCode.Contains(companyScaleCode))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyManagementNumberCode), e => e.CompanyManagementNumberCode.Contains(companyManagementNumberCode))
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