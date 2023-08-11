using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

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
        Guid companyMainId, string companyPointsTypeCode, int points, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {
            Check.Length(companyPointsTypeCode, nameof(companyPointsTypeCode), CompanyPointsConsts.CompanyPointsTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyPointsConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyPointsConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyPointsConsts.StatusMaxLength);

            var companyPoints = new CompanyPoints(
             GuidGenerator.Create(),
             companyMainId, companyPointsTypeCode, points, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyPointsRepository.InsertAsync(companyPoints);
        }

        public async Task<CompanyPoints> UpdateAsync(
            Guid id,
            Guid companyMainId, string companyPointsTypeCode, int points, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.Length(companyPointsTypeCode, nameof(companyPointsTypeCode), CompanyPointsConsts.CompanyPointsTypeCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyPointsConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyPointsConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
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

            companyPoints.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyPointsRepository.UpdateAsync(companyPoints);
        }

    }
}