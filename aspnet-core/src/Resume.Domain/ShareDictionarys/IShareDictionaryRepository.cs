using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Resume.ShareDictionarys
{
    public interface IShareDictionaryRepository : IRepository<ShareDictionary, Guid>
    {
        Task<List<ShareDictionary>> GetListAsync(
            string filterText = null,
            Guid? shareLanguageId = null,
            Guid? shareTagId = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            Guid? shareLanguageId = null,
            Guid? shareTagId = null,
            string key1 = null,
            string key2 = null,
            string key3 = null,
            string name = null,
            string extendedInformation = null,
            DateTime? dateAMin = null,
            DateTime? dateAMax = null,
            DateTime? dateDMin = null,
            DateTime? dateDMax = null,
            int? sortMin = null,
            int? sortMax = null,
            string note = null,
            string status = null,
            CancellationToken cancellationToken = default);
    }
}