using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareUploads;

namespace Resume.ShareUploads
{
    public class ShareUploadsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareUploadRepository _shareUploadRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareUploadsDataSeedContributor(IShareUploadRepository shareUploadRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareUploadRepository = shareUploadRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareUploadRepository.InsertAsync(new ShareUpload
            (
                id: Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"),
                key1: "a9024472c99845f9be7357c91a765a23b0bd7934ca544eb489",
                key2: "eb254092c7a342bdbb0bae60413c3f2923fcfdd7456b4a44a5",
                key3: "ca005c5682d44e099214cac4e5e69b094117d00c6c8145be9e",
                uploadName: "b0b3ae594b92462580fb7bac088d5ba7eb8552aa22ca458485e08aed1f5578d43d1c1eb85af7481ba3309766d59f3021b361e86e2bd94c15ac140bce1b1b7af34479f3e9513842c987ca1969fef24bc7a0bedfcb6df048479f99482d65e2981d2809ca2e",
                serverName: "48135354590b40a9b50b96b7da7935cce979fe4e58b2467cb2ca2db6e21e1c3698eb45bf57b4436abd913159c40ed0578e78a91f04dd474582c615bd64d3f82c0ee471b1a6a245efabdf6893aeb3dafe02b5ffadc828442c9e72e633ce5818654a53914a",
                type: "637282ed8d51498d8573eae89432ab14da748d3ac8c54e68999968ce0ee54a159973a19e86dc4537a8ac09e3a0b0f8092fb3775552ef4b8fba646fc514d08f8e50a59cd46be5453a9eb2ed86e585b3fa9b1d2e4e28614f50aef1fa50b48d4e08f1d0cda4",
                size: 765902301,
                systemUse: true,
                extendedInformation: "bf7dc7dc269c473e8439ade44f74d1621e1732135cb14dc28d4d0da25f37507bbbe6abf6db9343a7aa62c5d939d1c71d1744fdbd9fbf4d30b8722570d996b80817ecb4feff4b418695f666b11a6c61d55576db3147e94a68b6bd9e4283ea2d0144c67dad1f664ea58b6906778bd2da21102593a776ae44d3ae499e223dba18d41b082549bb3a485ca6010ac5044d7c3642531c156d0d40ca897be87154749df1a23ab9a10a5444f4a6ca0066295069c60572aae8122e48b18acb1d2334a175edccbace479602420d9d7f107c4dfdbc71f42fa0f7468e4cb9aa7fa0c7e2ee78ad6fbceca6d2824e4da7657e799b26b4dd66e8526e61fe46759d97",
                dateA: new DateTime(2012, 5, 18),
                dateD: new DateTime(2010, 10, 15),
                sort: 2006063046,
                note: "1752707e17a74ceeadca6b6d56b2561424348fdaf51b4220b5c3dde62f81f4870d4f07465b7f400b92560d79490425756e572f20f0f74c81a304e60fa4f540ddaa63136cb2ff4e8a9a53a89c83f76258b4e73a8ed5924f50b0e3514446492527f80a1162a71e4f1890f45be069fc3655b056665aee054a758d50ca92312b306d224351c0571b469aa607e852d5df6ba964785f183d3d496cb5cd5ec9ea79e1086b052f0a63d1486388ed7bd3182850e1ae924c115da34350a1121b40c27d0357d4c4f2b9e28440aebcb9f780e068b00258e34d7ef3a343a8ae3f7db15d81058768bddb3332cc4153986ed0aed504e6b80f9f2f10f8c04908ad7c",
                status: "f01cc9e89e1642ca8be80a49c96519a73095136e56884e2d86"
            ));

            await _shareUploadRepository.InsertAsync(new ShareUpload
            (
                id: Guid.Parse("2d0364e3-5e0c-4860-bed1-673c231be894"),
                key1: "18ec0d2ea0fd45d0b83a36752514d28572c44652eb024d9696",
                key2: "a05d9dbd55554087a0fea1e18a15a590f5bcf22794de4d318c",
                key3: "c283b49a8c864b4f8267149faf2ab16fd271eefdf9864b4fb8",
                uploadName: "0599e054a5654a85b24a41f1f97bdc1d5aaaef412d15404aa6e5cbe128ab366cccf05a6bf49c437591befbbf5caf3a1ebde6fda418f94aec8c9e828e365c93d8c52e202844cd41b7b9bfede267214cd5854c9cd00dcd4e49bcf63ba5c3c1ae8024f69ee4",
                serverName: "064f398a9d7643c48ffbda75c3fb0cb82a1378d1a61c44779548e26d11a18fc109cd43920d45466c84b54b611da811792e0c733574a241deba105a6d12b14a4e5ab2dffe721044e584bdb481a1d204f134c195224e674a38a354f59a4653456031f85fc4",
                type: "4ee7ce252f154e8db66f7acf6d3a8b17f9789e7fb72d4169a73210c95d4aea4b1acb38f0d1574e9895a1c5004c9bb55d83ad232346cb4f63b2a3085ed55b926c7f674556a08048048728484045d50b95fe319bee69984173972124d48c356daf001fdeee",
                size: 1237451585,
                systemUse: true,
                extendedInformation: "10d923f052a94bda911dd725d2554fcf2981170c5dad479eb2bff7efcc06d87f48b24b152e8f4e61aa3648d263ee896f286243068f1d49efa26e70908d06d5f81923e6aba5d14a47b17d9e213db84f0d9620b86dd31b4706b4a897443729a9411003c1a4ce644967abd544fe2c489af6565a0fd38e5a439fb070b21ce5be2010bc7a22f9f2a84f33a6428d6671a5ec1f77a345c20c1246309c2043c56519c527470d79781db844f7b77466b18b62aee4558bce442efc48eebf59a58abd7f8bfadd347a6b644f4c71a102f0ba78eb67c1dd77ff0da53343afbc96e47ca99535a23179dcad77e54313a291a9309c4fc3fb670ff31d875f42098d6a",
                dateA: new DateTime(2020, 8, 16),
                dateD: new DateTime(2006, 9, 18),
                sort: 870861376,
                note: "f507bd3f18824b639c4c1311f5b5673b66437d6c046a4d2cac0598c2c87381b5889b9ba0f29f45b187bd040ad37bf5cf2282473cb5e145f6a7a7893140391dc7620a75392268456eaa59901b38f2d1fbd72db363364b4e4db5a8fda31a5e2c8a933d2e60f8fa418b8c47d3d5fed7b0f131827c2cd56d4d3892223d1d327a7c221bfc5cafc0324c6da5efc7779549e2d40e1e774a0f4244c9a744c2820b2e8464102934ef8e704cc59564c4e239322249b76ee3dcc4954564a2e5837e2d2029841a694e2964294981887aad89eaedcaad49c4eef133c7427dad4c38c8357026b9e6e0a43e76094eb298a3e6e88c60470d63ebdd42f8e2417b9fa1",
                status: "16cf2c30d9984facbb4745e21be29595294c7096e2a541678b"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}