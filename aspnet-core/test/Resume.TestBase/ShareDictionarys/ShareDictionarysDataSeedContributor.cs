using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareDictionarys;

namespace Resume.ShareDictionarys
{
    public class ShareDictionarysDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareDictionaryRepository _shareDictionaryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareDictionarysDataSeedContributor(IShareDictionaryRepository shareDictionaryRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareDictionaryRepository = shareDictionaryRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareDictionaryRepository.InsertAsync(new ShareDictionary
            (
                id: Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"),
                shareLanguageId: Guid.Parse("0d63308e-e79a-4085-8edf-9ef8d5f58478"),
                shareTagId: Guid.Parse("853520c0-3b29-480e-ba79-6720b422966a"),
                key1: "414efb88637c41a882039a03488944b0b5a723b6eddf4eee8b",
                key2: "c069bd2288274f1f8d9834fc0bf3146e1cbc6a10783f4bbfa6",
                key3: "5dc9f0cecfc541e6bca60d83e237027cb3620346d4a34ab9af",
                name: "dc18c8e946154e4095bce64d8d65f484846a6972cf2d48c8b2d0bc970058af0763aaa3a2ab0f47efbf6760d85ef4009d6377575af8a6479889edeaeca5368411b0021931f41a4406826d0890ff603260d9e18860354342c999cad13bd0ff10c833324958",
                extendedInformation: "f2c670b903684de7948dfda573e32c59b4b3f60f57434896814385fd2feae3119a41dea26d05400cb21b15b777cd4075982dc25679bd424aa42257608b997072b5fd9a886b894ddcaa48d9aebaa5c7a3b1179d51ea934d37b029f2eab4cab4bfad8c58cbd4ee427799345974716185f9c9e3f49b158c439f824eb70e111ac6c8ed5c817bca0744bcb309406a00123fc5b9e33dffbd944702ae148e5f07bc3231967588de31d74c3abae2aff8b3477ee1ba8b3cbcf05d47e0b18f02604d93a9d8681105e49bf34deeb9dd3317322607a5a25d768c210642ec992235c7088065893566236957e940529600428a83d0cd9507cab4e130d1456f9307",
                dateA: new DateTime(2000, 9, 8),
                dateD: new DateTime(2001, 9, 18),
                sort: 1345169027,
                note: "8a46579d86e14d9c9e0712deac6edee8fc48ea65fe1544898226d410126a21d3984833cb3832469480f359178c7cfb5264bbe37c2ee243b5a94ec3548d2af835a2ea6cd46d3544a399108e2345452746202d4df8e37d40a19270d8a93ce405460f6fc031f5644780a9077bcb7e67cd6cd2e5ccaaa3dd468ca4c55a92f122e079514948e02f7b49b382a27b88d51df4cf723abd3e6b32406da6e35029b2a56db82aff8a37b622471da83fb8dec692c51b30ccccab4f92469c9c500ed319f9ee1bba0837d680af440fb1740fb4a26fb203095e44b40fba45ccae13772f5ad9dda7e31bc0a8c47e474d805a262a6abe0b668c58d3316478450fbd36",
                status: "c3dda4c4b53648b9bf4418e243e366a8d9b455acdfe64facb9"
            ));

            await _shareDictionaryRepository.InsertAsync(new ShareDictionary
            (
                id: Guid.Parse("644513bf-4097-4d02-ae71-1210bfcfb085"),
                shareLanguageId: Guid.Parse("84cf8847-8fef-4adf-8b7f-0038a2f00532"),
                shareTagId: Guid.Parse("16755df3-c01d-48ce-85d9-79eae3349edb"),
                key1: "61b56da39780474fac6ae9029b491f459f034896e5394900a1",
                key2: "1cce5f869ec14dc99acf32e464e625761c8718f13e2446cc96",
                key3: "42f94d39f90f411ba4d37a3572aa666ee9930f9cc02844a4b7",
                name: "d1d2be827b5b44e49af99096e1b12e995886382caf264cfd9c45902fa211792372057745477a429498fa4a30602fd1b255311fe9e9f7481e81075d8fd2cf9f7728bbfa9fa50f465ca416d7fbb41daa38c06dbda14e6742469c456203d50bbaf537debdea",
                extendedInformation: "78d21f7852bf40beb01718b4a36d83f7822825c99536425798bc64912b7766a1b857ff6c385947268b029211bfb1816c28ce0627b1a64c9295c4d51f769e994980d886e299bf48bd855771d31f6a2d18dc488942d03f49ba88f8b8e75073f54a14be8a730e554aaa8c3d2e5aedcc40e5006b5ebccfd841cc98ae51b8f62b1ead8d07502668474159aa0904823be74be9dc64f70e53794ecdb60096656708a4f413396944ec6f42aabf75eb248bd58419dd4fc8382ee64e4a9e544a71ce89462c032f3a9dd3d943f49714f1e091d71842ab062310f7b747469726321e64a1b9c1b76a93554cb1416b847578705a5627d8eea5d43721974c16a615",
                dateA: new DateTime(2016, 4, 19),
                dateD: new DateTime(2018, 11, 14),
                sort: 1891667764,
                note: "babd0c0208ff41628c8a591faa3aff59ea7935c054c442889ec2d4297a1be767f8d6cc8cc01d47fa80aa703fa4470418111d3f55ce9e48f5b46e3f0e2242702094ee76694a5243d5be597b59ae932836a2b09252d4c748b09a1aba05538ea6a3b55740cd06d9491a93905e54615fc1ce3157f0a55e154b208db12b9482f6551b5d187eecf7a643448332ef2443cfa4136e86ceb214ab4f2d8926fa23b45c6eccc9866ab73c124e54b877ae5827d8608202c61e57fe6747ec8ab91dd50f4bd69c3a7cc7b982e44281b4c8ca6966fbeb8a1c2c90a5407045bc9bcd14c388c14e068da7e48ac80949bb96d4d259f53a9d03b9ee1b5d2a6b48fd90ca",
                status: "1227459714614f708a37ec0d2c408be83dcd41f10f384c3ca4"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}