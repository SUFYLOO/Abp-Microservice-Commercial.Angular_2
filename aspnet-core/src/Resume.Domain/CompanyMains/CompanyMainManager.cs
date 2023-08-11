using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyMains
{
    public class CompanyMainManager : DomainService
    {
        private readonly ICompanyMainRepository _companyMainRepository;

        public CompanyMainManager(ICompanyMainRepository companyMainRepository)
        {
            _companyMainRepository = companyMainRepository;
        }

        public async Task<CompanyMain> CreateAsync(
        string name, bool allowSearch, DateTime dateA, DateTime dateD, int sort, string status, string industryCategory, string companyUrl, int capitalAmount, bool hideCapitalAmount, string companyScaleCode, bool hidePrincipal, string companyProfile, string businessPhilosophy, string operatingItems, string welfareSystem, bool matching, bool contractPass, string compilation = null, string officePhone = null, string faxPhone = null, string address = null, string principal = null, string extendedInformation = null, string note = null, Guid? companyUserId = null)
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyMainConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyMainConsts.StatusMaxLength);
            Check.NotNullOrWhiteSpace(industryCategory, nameof(industryCategory));
            Check.Length(industryCategory, nameof(industryCategory), CompanyMainConsts.IndustryCategoryMaxLength);
            Check.Length(companyUrl, nameof(companyUrl), CompanyMainConsts.CompanyUrlMaxLength);
            Check.NotNullOrWhiteSpace(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), CompanyMainConsts.CompanyScaleCodeMaxLength);
            Check.Length(companyProfile, nameof(companyProfile), CompanyMainConsts.CompanyProfileMaxLength);
            Check.Length(businessPhilosophy, nameof(businessPhilosophy), CompanyMainConsts.BusinessPhilosophyMaxLength);
            Check.Length(operatingItems, nameof(operatingItems), CompanyMainConsts.OperatingItemsMaxLength);
            Check.Length(welfareSystem, nameof(welfareSystem), CompanyMainConsts.WelfareSystemMaxLength);
            Check.Length(compilation, nameof(compilation), CompanyMainConsts.CompilationMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyMainConsts.OfficePhoneMaxLength);
            Check.Length(faxPhone, nameof(faxPhone), CompanyMainConsts.FaxPhoneMaxLength);
            Check.Length(address, nameof(address), CompanyMainConsts.AddressMaxLength);
            Check.Length(principal, nameof(principal), CompanyMainConsts.PrincipalMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyMainConsts.NoteMaxLength);

            var companyMain = new CompanyMain(
             GuidGenerator.Create(),
             name, allowSearch, dateA, dateD, sort, status, industryCategory, companyUrl, capitalAmount, hideCapitalAmount, companyScaleCode, hidePrincipal, companyProfile, businessPhilosophy, operatingItems, welfareSystem, matching, contractPass, compilation, officePhone, faxPhone, address, principal, extendedInformation, note, companyUserId
             );

            return await _companyMainRepository.InsertAsync(companyMain);
        }

        public async Task<CompanyMain> UpdateAsync(
            Guid id,
            string name, bool allowSearch, DateTime dateA, DateTime dateD, int sort, string status, string industryCategory, string companyUrl, int capitalAmount, bool hideCapitalAmount, string companyScaleCode, bool hidePrincipal, string companyProfile, string businessPhilosophy, string operatingItems, string welfareSystem, bool matching, bool contractPass, string compilation = null, string officePhone = null, string faxPhone = null, string address = null, string principal = null, string extendedInformation = null, string note = null, Guid? companyUserId = null
        )
        {
            Check.NotNullOrWhiteSpace(name, nameof(name));
            Check.Length(name, nameof(name), CompanyMainConsts.NameMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyMainConsts.StatusMaxLength);
            Check.NotNullOrWhiteSpace(industryCategory, nameof(industryCategory));
            Check.Length(industryCategory, nameof(industryCategory), CompanyMainConsts.IndustryCategoryMaxLength);
            Check.Length(companyUrl, nameof(companyUrl), CompanyMainConsts.CompanyUrlMaxLength);
            Check.NotNullOrWhiteSpace(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), CompanyMainConsts.CompanyScaleCodeMaxLength);
            Check.Length(companyProfile, nameof(companyProfile), CompanyMainConsts.CompanyProfileMaxLength);
            Check.Length(businessPhilosophy, nameof(businessPhilosophy), CompanyMainConsts.BusinessPhilosophyMaxLength);
            Check.Length(operatingItems, nameof(operatingItems), CompanyMainConsts.OperatingItemsMaxLength);
            Check.Length(welfareSystem, nameof(welfareSystem), CompanyMainConsts.WelfareSystemMaxLength);
            Check.Length(compilation, nameof(compilation), CompanyMainConsts.CompilationMaxLength);
            Check.Length(officePhone, nameof(officePhone), CompanyMainConsts.OfficePhoneMaxLength);
            Check.Length(faxPhone, nameof(faxPhone), CompanyMainConsts.FaxPhoneMaxLength);
            Check.Length(address, nameof(address), CompanyMainConsts.AddressMaxLength);
            Check.Length(principal, nameof(principal), CompanyMainConsts.PrincipalMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyMainConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyMainConsts.NoteMaxLength);

            var companyMain = await _companyMainRepository.GetAsync(id);

            companyMain.Name = name;
            companyMain.AllowSearch = allowSearch;
            companyMain.DateA = dateA;
            companyMain.DateD = dateD;
            companyMain.Sort = sort;
            companyMain.Status = status;
            companyMain.IndustryCategory = industryCategory;
            companyMain.CompanyUrl = companyUrl;
            companyMain.CapitalAmount = capitalAmount;
            companyMain.HideCapitalAmount = hideCapitalAmount;
            companyMain.CompanyScaleCode = companyScaleCode;
            companyMain.HidePrincipal = hidePrincipal;
            companyMain.CompanyProfile = companyProfile;
            companyMain.BusinessPhilosophy = businessPhilosophy;
            companyMain.OperatingItems = operatingItems;
            companyMain.WelfareSystem = welfareSystem;
            companyMain.Matching = matching;
            companyMain.ContractPass = contractPass;
            companyMain.Compilation = compilation;
            companyMain.OfficePhone = officePhone;
            companyMain.FaxPhone = faxPhone;
            companyMain.Address = address;
            companyMain.Principal = principal;
            companyMain.ExtendedInformation = extendedInformation;
            companyMain.Note = note;
            companyMain.CompanyUserId = companyUserId;

            return await _companyMainRepository.UpdateAsync(companyMain);
        }

    }
}