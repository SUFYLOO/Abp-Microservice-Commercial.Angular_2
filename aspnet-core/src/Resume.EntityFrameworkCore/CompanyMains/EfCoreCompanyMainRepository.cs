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

namespace Resume.CompanyMains
{
    public class EfCoreCompanyMainRepository : EfCoreRepository<ResumeDbContext, CompanyMain, Guid>, ICompanyMainRepository
    {
        public EfCoreCompanyMainRepository(IDbContextProvider<ResumeDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<CompanyMain>> GetListAsync(
            string filterText = null,
            string name = null,
            string compilation = null,
            string officePhone = null,
            string faxPhone = null,
            string address = null,
            string principal = null,
            bool? allowSearch = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            string note = null,
            int? sortMin = null,
            int? sortMax = null,
            string status = null,
            string industryCategory = null,
            string companyUrl = null,
            int? capitalAmountMin = null,
            int? capitalAmountMax = null,
            bool? hideCapitalAmount = null,
            string companyScaleCode = null,
            bool? hidePrincipal = null,
            Guid? companyUserId = null,
            string companyProfile = null,
            string businessPhilosophy = null,
            string operatingItems = null,
            string welfareSystem = null,
            bool? matching = null,
            bool? contractPass = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, name, compilation, officePhone, faxPhone, address, principal, allowSearch, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, note, sortMin, sortMax, status, industryCategory, companyUrl, capitalAmountMin, capitalAmountMax, hideCapitalAmount, companyScaleCode, hidePrincipal, companyUserId, companyProfile, businessPhilosophy, operatingItems, welfareSystem, matching, contractPass);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? CompanyMainConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string name = null,
            string compilation = null,
            string officePhone = null,
            string faxPhone = null,
            string address = null,
            string principal = null,
            bool? allowSearch = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            string note = null,
            int? sortMin = null,
            int? sortMax = null,
            string status = null,
            string industryCategory = null,
            string companyUrl = null,
            int? capitalAmountMin = null,
            int? capitalAmountMax = null,
            bool? hideCapitalAmount = null,
            string companyScaleCode = null,
            bool? hidePrincipal = null,
            Guid? companyUserId = null,
            string companyProfile = null,
            string businessPhilosophy = null,
            string operatingItems = null,
            string welfareSystem = null,
            bool? matching = null,
            bool? contractPass = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, name, compilation, officePhone, faxPhone, address, principal, allowSearch, extendedInformation, dateAMin, dateAMax, dateDMin, dateDMax, note, sortMin, sortMax, status, industryCategory, companyUrl, capitalAmountMin, capitalAmountMax, hideCapitalAmount, companyScaleCode, hidePrincipal, companyUserId, companyProfile, businessPhilosophy, operatingItems, welfareSystem, matching, contractPass);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<CompanyMain> ApplyFilter(
            IQueryable<CompanyMain> query,
            string filterText,
            string name = null,
            string compilation = null,
            string officePhone = null,
            string faxPhone = null,
            string address = null,
            string principal = null,
            bool? allowSearch = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            string note = null,
            int? sortMin = null,
            int? sortMax = null,
            string status = null,
            string industryCategory = null,
            string companyUrl = null,
            int? capitalAmountMin = null,
            int? capitalAmountMax = null,
            bool? hideCapitalAmount = null,
            string companyScaleCode = null,
            bool? hidePrincipal = null,
            Guid? companyUserId = null,
            string companyProfile = null,
            string businessPhilosophy = null,
            string operatingItems = null,
            string welfareSystem = null,
            bool? matching = null,
            bool? contractPass = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Name.Contains(filterText) || e.Compilation.Contains(filterText) || e.OfficePhone.Contains(filterText) || e.FaxPhone.Contains(filterText) || e.Address.Contains(filterText) || e.Principal.Contains(filterText) || e.ExtendedInformation.Contains(filterText) || e.Note.Contains(filterText) || e.Status.Contains(filterText) || e.IndustryCategory.Contains(filterText) || e.CompanyUrl.Contains(filterText) || e.CompanyScaleCode.Contains(filterText) || e.CompanyProfile.Contains(filterText) || e.BusinessPhilosophy.Contains(filterText) || e.OperatingItems.Contains(filterText) || e.WelfareSystem.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(name), e => e.Name.Contains(name))
                    .WhereIf(!string.IsNullOrWhiteSpace(compilation), e => e.Compilation.Contains(compilation))
                    .WhereIf(!string.IsNullOrWhiteSpace(officePhone), e => e.OfficePhone.Contains(officePhone))
                    .WhereIf(!string.IsNullOrWhiteSpace(faxPhone), e => e.FaxPhone.Contains(faxPhone))
                    .WhereIf(!string.IsNullOrWhiteSpace(address), e => e.Address.Contains(address))
                    .WhereIf(!string.IsNullOrWhiteSpace(principal), e => e.Principal.Contains(principal))
                    .WhereIf(allowSearch.HasValue, e => e.AllowSearch == allowSearch)
                    .WhereIf(!string.IsNullOrWhiteSpace(extendedInformation), e => e.ExtendedInformation.Contains(extendedInformation))
                    .WhereIf(dateAMin.HasValue, e => e.DateA >= dateAMin.Value)
                    .WhereIf(dateAMax.HasValue, e => e.DateA <= dateAMax.Value)
                    .WhereIf(dateDMin.HasValue, e => e.DateD >= dateDMin.Value)
                    .WhereIf(dateDMax.HasValue, e => e.DateD <= dateDMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(note), e => e.Note.Contains(note))
                    .WhereIf(sortMin.HasValue, e => e.Sort >= sortMin.Value)
                    .WhereIf(sortMax.HasValue, e => e.Sort <= sortMax.Value)
                    .WhereIf(!string.IsNullOrWhiteSpace(status), e => e.Status.Contains(status))
                    .WhereIf(!string.IsNullOrWhiteSpace(industryCategory), e => e.IndustryCategory.Contains(industryCategory))
                    .WhereIf(!string.IsNullOrWhiteSpace(companyUrl), e => e.CompanyUrl.Contains(companyUrl))
                    .WhereIf(capitalAmountMin.HasValue, e => e.CapitalAmount >= capitalAmountMin.Value)
                    .WhereIf(capitalAmountMax.HasValue, e => e.CapitalAmount <= capitalAmountMax.Value)
                    .WhereIf(hideCapitalAmount.HasValue, e => e.HideCapitalAmount == hideCapitalAmount)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyScaleCode), e => e.CompanyScaleCode.Contains(companyScaleCode))
                    .WhereIf(hidePrincipal.HasValue, e => e.HidePrincipal == hidePrincipal)
                    .WhereIf(companyUserId.HasValue, e => e.CompanyUserId == companyUserId)
                    .WhereIf(!string.IsNullOrWhiteSpace(companyProfile), e => e.CompanyProfile.Contains(companyProfile))
                    .WhereIf(!string.IsNullOrWhiteSpace(businessPhilosophy), e => e.BusinessPhilosophy.Contains(businessPhilosophy))
                    .WhereIf(!string.IsNullOrWhiteSpace(operatingItems), e => e.OperatingItems.Contains(operatingItems))
                    .WhereIf(!string.IsNullOrWhiteSpace(welfareSystem), e => e.WelfareSystem.Contains(welfareSystem))
                    .WhereIf(matching.HasValue, e => e.Matching == matching)
                    .WhereIf(contractPass.HasValue, e => e.ContractPass == contractPass);
        }
    }
}