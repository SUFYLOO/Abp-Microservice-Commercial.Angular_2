using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavManager : DomainService
    {
        private readonly ICompanyUserMainFavRepository _companyUserMainFavRepository;

        public CompanyUserMainFavManager(ICompanyUserMainFavRepository companyUserMainFavRepository)
        {
            _companyUserMainFavRepository = companyUserMainFavRepository;
        }

        public async Task<CompanyUserMainFav> CreateAsync(
        Guid companyMainId, Guid companyJobId, Guid userMainId, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null)
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserMainFavConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserMainFavConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyUserMainFavConsts.StatusMaxLength);

            var companyUserMainFav = new CompanyUserMainFav(
             GuidGenerator.Create(),
             companyMainId, companyJobId, userMainId, extendedInformation, dateA, dateD, sort, note, status
             );

            return await _companyUserMainFavRepository.InsertAsync(companyUserMainFav);
        }

        public async Task<CompanyUserMainFav> UpdateAsync(
            Guid id,
            Guid companyMainId, Guid companyJobId, Guid userMainId, string extendedInformation, DateTime? dateA = null, DateTime? dateD = null, int? sort = null, string note = null, string status = null
        )
        {
            Check.Length(extendedInformation, nameof(extendedInformation), CompanyUserMainFavConsts.ExtendedInformationMaxLength);
            Check.Length(note, nameof(note), CompanyUserMainFavConsts.NoteMaxLength);
            Check.Length(status, nameof(status), CompanyUserMainFavConsts.StatusMaxLength);

            var companyUserMainFav = await _companyUserMainFavRepository.GetAsync(id);

            companyUserMainFav.CompanyMainId = companyMainId;
            companyUserMainFav.CompanyJobId = companyJobId;
            companyUserMainFav.UserMainId = userMainId;
            companyUserMainFav.ExtendedInformation = extendedInformation;
            companyUserMainFav.DateA = dateA;
            companyUserMainFav.DateD = dateD;
            companyUserMainFav.Sort = sort;
            companyUserMainFav.Note = note;
            companyUserMainFav.Status = status;

            return await _companyUserMainFavRepository.UpdateAsync(companyUserMainFav);
        }

    }
}