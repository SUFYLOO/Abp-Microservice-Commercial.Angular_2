using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyJobOrganizationUnits
{
    public class CompanyJobOrganizationUnitManager : DomainService
    {
        private readonly ICompanyJobOrganizationUnitRepository _companyJobOrganizationUnitRepository;

        public CompanyJobOrganizationUnitManager(ICompanyJobOrganizationUnitRepository companyJobOrganizationUnitRepository)
        {
            _companyJobOrganizationUnitRepository = companyJobOrganizationUnitRepository;
        }

        public async Task<CompanyJobOrganizationUnit> CreateAsync(
        Guid companyMainId, Guid companyJobId, Guid organizationUnitId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobOrganizationUnitConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobOrganizationUnitConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobOrganizationUnitConsts.StatusMaxLength);

            var companyJobOrganizationUnit = new CompanyJobOrganizationUnit(
             GuidGenerator.Create(),
             companyMainId, companyJobId, organizationUnitId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobOrganizationUnitRepository.InsertAsync(companyJobOrganizationUnit);
        }

        public async Task<CompanyJobOrganizationUnit> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, Guid organizationUnitId, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyJobOrganizationUnitConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyJobOrganizationUnitConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobOrganizationUnitConsts.StatusMaxLength);

            var companyJobOrganizationUnit = await _companyJobOrganizationUnitRepository.GetAsync(id);

            companyJobOrganizationUnit.CompanyMainId = companyMainId;
            companyJobOrganizationUnit.CompanyJobId = companyJobId;
            companyJobOrganizationUnit.OrganizationUnitId = organizationUnitId;
            companyJobOrganizationUnit.ExtendedInformation = extendedInformation;
            companyJobOrganizationUnit.DateA = dateA;
            companyJobOrganizationUnit.DateD = dateD;
            companyJobOrganizationUnit.Sort = sort;
            companyJobOrganizationUnit.Note = note;
            companyJobOrganizationUnit.Status = status;

            return await _companyJobOrganizationUnitRepository.UpdateAsync(companyJobOrganizationUnit);
        }

    }
}