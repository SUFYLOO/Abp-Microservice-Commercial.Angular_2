using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyContracts
{
    public class CompanyContractManager : DomainService
    {
        private readonly ICompanyContractRepository _companyContractRepository;

        public CompanyContractManager(ICompanyContractRepository companyContractRepository)
        {
            _companyContractRepository = companyContractRepository;
        }

        public async Task<CompanyContract> CreateAsync(
        Guid companyMainId, string planCode, int pointsTotal, int pointsPay, int pointsGift, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status)
        {
            Check.NotNullOrWhiteSpace(planCode, nameof(planCode));
            Check.Length(planCode, nameof(planCode), CompanyContractConsts.PlanCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyContractConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyContractConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyContractConsts.StatusMaxLength);

            var companyContract = new CompanyContract(
             GuidGenerator.Create(),
             companyMainId, planCode, pointsTotal, pointsPay, pointsGift, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyContractRepository.InsertAsync(companyContract);
        }

        public async Task<CompanyContract> UpdateAsync(
            Guid id,
            Guid companyMainId, string planCode, int pointsTotal, int pointsPay, int pointsGift, string extendedInformation, DateTime dateA, DateTime dateD, int sort, string note, string status, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(planCode, nameof(planCode));
            Check.Length(planCode, nameof(planCode), CompanyContractConsts.PlanCodeMaxLength);
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyContractConsts.ExtendedInformationMaxLength);
            Check.NotNull(dateA, nameof(dateA));
            Check.NotNull(dateD, nameof(dateD));
            Check.Length(note, nameof(note), CompanyContractConsts.NoteMaxLength);
            Check.NotNullOrWhiteSpace(status, nameof(status));
            Check.Length(status, nameof(status), CompanyContractConsts.StatusMaxLength);

            var companyContract = await _companyContractRepository.GetAsync(id);

            companyContract.CompanyMainId = companyMainId;
            companyContract.PlanCode = planCode;
            companyContract.PointsTotal = pointsTotal;
            companyContract.PointsPay = pointsPay;
            companyContract.PointsGift = pointsGift;
            companyContract.ExtendedInformation = extendedInformation;
            companyContract.DateA = dateA;
            companyContract.DateD = dateD;
            companyContract.Sort = sort;
            companyContract.Note = note;
            companyContract.Status = status;

            companyContract.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyContractRepository.UpdateAsync(companyContract);
        }

    }
}