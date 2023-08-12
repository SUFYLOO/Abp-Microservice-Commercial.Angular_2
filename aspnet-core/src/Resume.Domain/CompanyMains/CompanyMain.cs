using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace Resume.CompanyMains
{
    public class CompanyMain : FullAuditedAggregateRoot<Guid>, IMultiTenant
    {
        public virtual Guid? TenantId { get; set; }

        [NotNull]
        public virtual string Name { get; set; }

        [CanBeNull]
        public virtual string? Compilation { get; set; }

        [CanBeNull]
        public virtual string? OfficePhone { get; set; }

        [CanBeNull]
        public virtual string? FaxPhone { get; set; }

        [CanBeNull]
        public virtual string? Address { get; set; }

        [CanBeNull]
        public virtual string? Principal { get; set; }

        public virtual bool AllowSearch { get; set; }

        [CanBeNull]
        public virtual string? ExtendedInformation { get; set; }

        public virtual DateTime? DateA { get; set; }

        public virtual DateTime? DateD { get; set; }

        [CanBeNull]
        public virtual string? Note { get; set; }

        public virtual int? Sort { get; set; }

        [CanBeNull]
        public virtual string? Status { get; set; }

        [NotNull]
        public virtual string IndustryCategory { get; set; }

        [CanBeNull]
        public virtual string? CompanyUrl { get; set; }

        public virtual int CapitalAmount { get; set; }

        public virtual bool HideCapitalAmount { get; set; }

        [NotNull]
        public virtual string CompanyScaleCode { get; set; }

        public virtual bool HidePrincipal { get; set; }

        public virtual Guid? CompanyUserId { get; set; }

        [CanBeNull]
        public virtual string? CompanyProfile { get; set; }

        [CanBeNull]
        public virtual string? BusinessPhilosophy { get; set; }

        [CanBeNull]
        public virtual string? OperatingItems { get; set; }

        [CanBeNull]
        public virtual string? WelfareSystem { get; set; }

        public virtual bool Matching { get; set; }

        public virtual bool ContractPass { get; set; }

        public CompanyMain()
        {

        }

        public CompanyMain(Guid id, string name, bool allowSearch, string industryCategory, string companyUrl, int capitalAmount, bool hideCapitalAmount, string companyScaleCode, bool hidePrincipal, string companyProfile, string businessPhilosophy, string operatingItems, string welfareSystem, bool matching, bool contractPass, string compilation = null, string officePhone = null, string faxPhone = null, string address = null, string principal = null, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, string note = null, int? sort = null, string status = null, Guid? companyUserId = null)
        {

            Id = id;
            Check.NotNull(name, nameof(name));
            Check.Length(name, nameof(name), CompanyMainConsts.NameMaxLength, 0);
            Check.NotNull(industryCategory, nameof(industryCategory));
            Check.Length(industryCategory, nameof(industryCategory), CompanyMainConsts.IndustryCategoryMaxLength, 0);
            Check.Length(companyUrl, nameof(companyUrl), CompanyMainConsts.CompanyUrlMaxLength, 0);
            Check.NotNull(companyScaleCode, nameof(companyScaleCode));
            Check.Length(companyScaleCode, nameof(companyScaleCode), CompanyMainConsts.CompanyScaleCodeMaxLength, 0);
            Check.Length(companyProfile, nameof(companyProfile), CompanyMainConsts.CompanyProfileMaxLength, 0);
            Check.Length(businessPhilosophy, nameof(businessPhilosophy), CompanyMainConsts.BusinessPhilosophyMaxLength, 0);
            Check.Length(operatingItems, nameof(operatingItems), CompanyMainConsts.OperatingItemsMaxLength, 0);
            Check.Length(welfareSystem, nameof(welfareSystem), CompanyMainConsts.WelfareSystemMaxLength, 0);
            Check.Length(compilation, nameof(compilation), CompanyMainConsts.CompilationMaxLength, 0);
            Check.Length(officePhone, nameof(officePhone), CompanyMainConsts.OfficePhoneMaxLength, 0);
            Check.Length(faxPhone, nameof(faxPhone), CompanyMainConsts.FaxPhoneMaxLength, 0);
            Check.Length(address, nameof(address), CompanyMainConsts.AddressMaxLength, 0);
            Check.Length(principal, nameof(principal), CompanyMainConsts.PrincipalMaxLength, 0);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyMainConsts.ExtendedInformationMaxLength, 0);
            Check.Length(note, nameof(note), CompanyMainConsts.NoteMaxLength, 0);
            Check.Length(status, nameof(status), CompanyMainConsts.StatusMaxLength, 0);
            Name = name;
            AllowSearch = allowSearch;
            IndustryCategory = industryCategory;
            CompanyUrl = companyUrl;
            CapitalAmount = capitalAmount;
            HideCapitalAmount = hideCapitalAmount;
            CompanyScaleCode = companyScaleCode;
            HidePrincipal = hidePrincipal;
            CompanyProfile = companyProfile;
            BusinessPhilosophy = businessPhilosophy;
            OperatingItems = operatingItems;
            WelfareSystem = welfareSystem;
            Matching = matching;
            ContractPass = contractPass;
            Compilation = compilation;
            OfficePhone = officePhone;
            FaxPhone = faxPhone;
            Address = address;
            Principal = principal;
            ExtendedInformation = extendedInformation;
            DateA = dateA;
            DateD = dateD;
            Note = note;
            Sort = sort;
            Status = status;
            CompanyUserId = companyUserId;
        }

    }
}