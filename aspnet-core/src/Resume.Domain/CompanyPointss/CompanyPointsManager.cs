using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyPointss
{
    public class CompanyPointsManager : DomainService
    {
        private readonly ICompanyPointsRepository _companyPointsRepository;

        public CompanyPointsManager(ICompanyPointsRepository companyPointsRepository)
        {
            _companyPointsRepository = companyPointsRepository;
        }

        public async Task<CompanyPoints> CreateAsync(
        Guid companyMainId, string companyPointsTypeCode, int points, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(companyPointsTypeCode, nameof(companyPointsTypeCode), CompanyPointsConsts.CompanyPointsTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyPointsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyPointsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyPointsConsts.StatusMaxLength);

            var companyPoints = new CompanyPoints(
             GuidGenerator.Create(),
             companyMainId, companyPointsTypeCode, points, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyPointsRepository.InsertAsync(companyPoints);
        }

        public async Task<CompanyPoints> UpdateAsync(
            Guid id,
            Guid companyMainId, string companyPointsTypeCode, int points, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(companyPointsTypeCode, nameof(companyPointsTypeCode), CompanyPointsConsts.CompanyPointsTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyPointsConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyPointsConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyPointsConsts.StatusMaxLength);

            var companyPoints = await _companyPointsRepository.GetAsync(id);

            companyPoints.CompanyMainId = companyMainId;
            companyPoints.CompanyPointsTypeCode = companyPointsTypeCode;
            companyPoints.Points = points;
            companyPoints.ExtendedInformation = extendedInformation;
            companyPoints.DateA = dateA;
            companyPoints.DateD = dateD;
            companyPoints.Sort = sort;
            companyPoints.Note = note;
            companyPoints.Status = status;

            return await _companyPointsRepository.UpdateAsync(companyPoints);
        }

    }
}