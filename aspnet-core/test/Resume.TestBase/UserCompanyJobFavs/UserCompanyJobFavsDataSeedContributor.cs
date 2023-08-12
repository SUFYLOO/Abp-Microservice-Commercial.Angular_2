using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserCompanyJobFavs;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserCompanyJobFavRepository _userCompanyJobFavRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserCompanyJobFavsDataSeedContributor(IUserCompanyJobFavRepository userCompanyJobFavRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userCompanyJobFavRepository = userCompanyJobFavRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userCompanyJobFavRepository.InsertAsync(new UserCompanyJobFav
            (
                id: Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"),
                userMainId: Guid.Parse("8643a752-ea09-45c5-9dc3-8c12a367348c"),
                companyJobId: Guid.Parse("fa68e116-5f86-48f1-a086-ebe1c1a8d994"),
                extendedInformation: "bb043f7edc34436499c5d1ef803b8f5d03db2c56a962428e868d1d488a3d25b4ec8e7ee4b8ae4141a2f7e7ab320670386815d211f1bf4e06adeadba7aa8131fa87bc9774d8064c958631f6297c1a6a8430232104d07d433da1c39d8a4df7fb09fd31ae7cca6a4bc7bf84334b093ddf584463cbfeceda46d08167df31ffcefb9c6749e5c816634a10bdc4658bcff8b9a2a41f5a33e8a94be584d14cdab0eb6bdf80e60c7070c24ed0aa76feeba6a6dd8b73197c3cc04e48308f2df5348a72ba6648e592f955124e689ba71ad61c8b97392a03b6a252c24cdb9b3649b6d9ab2fd9956f4d019ba14eb389c0ad16fdc03e8e67d56abb00c64d9aafbc",
                dateA: new DateTime(2020, 6, 21),
                dateD: new DateTime(2020, 6, 18),
                sort: 1067999162,
                note: "8976eabced81414b827e89ec6a208c956f33ac2ffd974843b8a284cd7d39954f4dd20cc20a364a3697646a82dd4f522b235db44bb2cd42c29889dba8479643d8c5999bdd209246298da8c15c9d1a65b59548192c6f3b4218b32be7222ea85c8d577fdb6ce67c4c5492b5370db3ab89c37cb5d17678cf4ec7aa7d92c7642e64d0bb8ed2677a9341ed9c06b63a9074c6d4b1b0228ad08e47619dbe50773aae52d643b75b4d832341f6a9e3e324bb4469f996677ad4c0fa4ba89bbe6711f204a5300a6e27210628416cbbcb599c788ae1d531d9e212e84c44f6985a996a0dd441029b49835ac8ee41b4aa0d9b4f0e37eb3d9f6b09da6e5d40db9c04",
                status: "8a1040575e9c4988abce85ddf32e27d0be064fba84274836b3"
            ));

            await _userCompanyJobFavRepository.InsertAsync(new UserCompanyJobFav
            (
                id: Guid.Parse("762db719-85cf-4df2-a121-75783302538a"),
                userMainId: Guid.Parse("b847a864-17ce-49bb-8a43-9136d61bcaaa"),
                companyJobId: Guid.Parse("0d175c6a-2fb0-4aff-8447-4d73723d8706"),
                extendedInformation: "8322565f7bf04316b12f32e6ae32569f9bb3fa8d5e8948399f15809c165d3c9cfc1207a5fbcc48d784c64f4a6d73549c9edfdba691bc466aa686a37d56cb2cf5a24c43a88cbc4e2f97da1fb1263c5f0056df5d798dec4f309cfc726825e890db42998d940bca41b485ef962cfb0c6cbf77516bdc0fee4b79b6e686716e4130956913285afd4b4a628aa67c8e573b8f19a2e866ca96164780ac6154bed666fe327cf05b778cad476aa8e9deb036b3a6268d474f6053c746908b978403070ff903504e5494f1094c79a64c7c22754f5698781142734ed44878baf4fcb016566d5b8c39dbc07bd7459ba1feae84256100ab176dc4c7d34e449a84fb",
                dateA: new DateTime(2017, 4, 1),
                dateD: new DateTime(2008, 9, 18),
                sort: 205338558,
                note: "3662f143791b4f179eb5b23d71c5a25df86297878c9446089828574f7574e3d094ba6ecaa2d84d5faee3b5d02b5845604042f93452264ad7a1726b264dd438bf712a4f47532d4cf19fb89f0a115630ef91b6acca922b467088af47a3fdaf243f6dfcff50f5f4487abf8d0d8dc87c336edd918aca27df4ecab2d3e9c35188690336bf5e0f646944e782718ad74932b717547a38ab2aa74bfdac4f5445ae19218b8b8c3da2945047c1bb653c92a5208750523ffb81f6c845b5b99b12bd1785caede2b30f7203be4749a53889af2120d4b2fda9f86cd5af4b16b73660a61c667686bfb40aa5e07d48e49d2a9e86242114acf7f190f30beb497fbb24",
                status: "8553e8ff169640d5b39424a47f0ba36be3f674c15c10490bb5"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}