using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHoursManager : DomainService
    {
        private readonly ICompanyJobWorkHoursRepository _companyJobWorkHoursRepository;

        public CompanyJobWorkHoursManager(ICompanyJobWorkHoursRepository companyJobWorkHoursRepository)
        {
            _companyJobWorkHoursRepository = companyJobWorkHoursRepository;
        }

        public async Task<CompanyJobWorkHours> CreateAsync(
        Guid companyMainId, Guid companyJobId, string workHoursCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.NotNullOrWhiteSpace(workHoursCode, nameof(workHoursCode));
            Check.Length(workHoursCode, nameof(workHoursCode), CompanyJobWorkHoursConsts.WorkHoursCodeMaxLength);
            Check.Length(note, nameof(note), CompanyJobWorkHoursConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobWorkHoursConsts.StatusMaxLength);

            var companyJobWorkHours = new CompanyJobWorkHours(
             GuidGenerator.Create(),
             companyMainId, companyJobId, workHoursCode, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyJobWorkHoursRepository.InsertAsync(companyJobWorkHours);
        }

        public async Task<CompanyJobWorkHours> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, string workHoursCode, string extendedInformation = null, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(workHoursCode, nameof(workHoursCode));
            Check.Length(workHoursCode, nameof(workHoursCode), CompanyJobWorkHoursConsts.WorkHoursCodeMaxLength);
            Check.Length(note, nameof(note), CompanyJobWorkHoursConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyJobWorkHoursConsts.StatusMaxLength);

            var companyJobWorkHours = await _companyJobWorkHoursRepository.GetAsync(id);

            companyJobWorkHours.CompanyMainId = companyMainId;
            companyJobWorkHours.CompanyJobId = companyJobId;
            companyJobWorkHours.WorkHoursCode = workHoursCode;
            companyJobWorkHours.ExtendedInformation = extendedInformation;
            companyJobWorkHours.DateA = dateA;
            companyJobWorkHours.DateD = dateD;
            companyJobWorkHours.Sort = sort;
            companyJobWorkHours.Note = note;
            companyJobWorkHours.Status = status;

            companyJobWorkHours.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _companyJobWorkHoursRepository.UpdateAsync(companyJobWorkHours);
        }

    }
}