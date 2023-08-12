using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserAccountBinds;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserAccountBindRepository _userAccountBindRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserAccountBindsDataSeedContributor(IUserAccountBindRepository userAccountBindRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userAccountBindRepository = userAccountBindRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userAccountBindRepository.InsertAsync(new UserAccountBind
            (
                id: Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"),
                userMainId: Guid.Parse("10615b93-d12f-4279-8dcd-b4900342e0a4"),
                thirdPartyTypeCode: "6bff824eeaf04963be01e4e879bc3b89c23c3fce849e4c3f9e",
                thirdPartyAccountId: "e1cac0246b024a088eb771fcede59de55fea648e3c844e6b8e",
                extendedInformation: "1182f2f149d94aa3a06c3c9507cf343d438a3e86614b4a3c931cd89236a3d5c6af50f886d4074344b42d2ab99e9de7bf176ab08068a24499843c367eab158af92b27a9a24d214b6da18d2e10d468e2476cca5950814f496888b9d6833314f921579abe1f49704ec7955c662baeb80522a80163854f72444a80c75a610bef8d905f4e519fd47643d8a4a86dde1107a0212dd5ad58a5ae470c986d6c1ef913ca0fd87d769a930049aba46700ebab2a60a5a9d2e0b16e45405f889815284b0fb15280f606f4e2604472a5803b1c4a352e7286767d31a7554e0a886b4b0cabd5e37d5d9ea04df88a48b8b60c2f80cd13f6f125acf46a0d2845759626",
                dateA: new DateTime(2000, 9, 20),
                dateD: new DateTime(2017, 6, 9),
                sort: 1121708978,
                note: "e3aebb890b8746ffae4f9fb8ffa219e3e180aec98e0f4eedb0f1fa72fbec828c043ed4127cee4ce380f09185fa44bfa4554a93a62cb64cdbb43d3d2513a92dded229d5b74e014c5195a71199da11808e6606798004f64b99ae922213f69d5245ce97f4a6da654dde905c335121c5f103104efa926f5e4eb59b54fef3797deda17043eb42286141d990f5012512a126c689a45e21b4f84258bec646ce8f64326ea3576ae906944c9595213f106feb019ca10876c1f3f0409faaf1dd2adfdfb7f09526b980f4004c72bb40f0e41854d1f6b139f571bc654e9d81bcb03092c0dba7bd2855ffc6524282a7714af16bd67e331df8fa3d759b48499e2c",
                status: "7a3991c84e7a43a38c36969c9a907057a56fe5c6554f488786"
            ));

            await _userAccountBindRepository.InsertAsync(new UserAccountBind
            (
                id: Guid.Parse("0bd3f949-61c2-42e4-8121-6293e57bfc2a"),
                userMainId: Guid.Parse("f74817cd-861d-4d97-bbea-2533d16493c6"),
                thirdPartyTypeCode: "6fd72ec553d54702947fe68d3ebb3a307a5aeb8be23d4bed8d",
                thirdPartyAccountId: "2bfd74ccb4204ccd9262434deb336a2c383a1ac8d4364e2f8f",
                extendedInformation: "c08e85224b90471a8e3f242e5a530bbce3d5fa4ec4fc471bb2c0a9b09f83b03e4f276b2cdb5e441699f7f25011fe33da3d5917d155be4bdeb2fcdec309c1b2f89502115e68a647fbba1b6af0f63c07b32d153ee4c1e143cdabbf9541193efeb2f5ace0ad0bc64129858090ad81d26f5d32d32a6c7fb44c01bbc40d00dc681c68b2afb160ce454785a8e838f67bf74ad2fa2f140f4f984c5bb577485bbcde17eb8c9df3480e9f425e8f2cf34b163ad8260c7c38dbacb7412fa44efa05647cb859009e8e10963b477899798d352d38f43facb2c5d9ef374be1886536640435363000241f63ceac406b8166284c00784a6a499b452409634cf79d7e",
                dateA: new DateTime(2019, 4, 10),
                dateD: new DateTime(2005, 8, 20),
                sort: 1355907740,
                note: "6c6845d516794d7d89d6f50a0531689c6b8d1aa09ff14829b5f64cf2e1c2df483ecd469ae7d14dedb99a97e6cfdcdfb7c8f4f4368ecb49a3b568c81986c853ef4024ba8df478427981b6bf7b6ee2c755406cfe6d079d4b698170e3340cdc80243293a4c9386c44a39fe970b77d70def5db59a8ea96ec49a885e347b3d9e5cbeb046db3d671304a3eb35bcb99cff74fec9a228eede5c6465b832b2c2f1b886ebe470aa8071e554c54857602bc4c21b6f98e7dda59f0e949578fe3e4ef727d91c561556a928ed44665a867d9d34dc89aa40c37849fe2c34b9e96a623af7da21d8a0e295570acaf47cfb3cd0bcb302c1c42e933c2e2f2c34ad4a227",
                status: "4d72ce2b0e234e7b804be76664da027af772aeb3848d46e487"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}