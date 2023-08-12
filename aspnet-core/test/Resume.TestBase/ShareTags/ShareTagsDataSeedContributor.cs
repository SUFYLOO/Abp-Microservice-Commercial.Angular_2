using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareTags;

namespace Resume.ShareTags
{
    public class ShareTagsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareTagRepository _shareTagRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareTagsDataSeedContributor(IShareTagRepository shareTagRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareTagRepository = shareTagRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareTagRepository.InsertAsync(new ShareTag
            (
                id: Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"),
                colorCode: "b546ed676cb941e49af2569e6038ac9008ce6e6e758e4184a8",
                key1: "fda0f574e4a646fe99446116ea24383a565d4c94d97649b1a9",
                key2: "da731010a8c647c080676d711ec1a690f01b5ec6165145fea7",
                key3: "da72b6e2bea94fa2bd1f81e5365d441f07ad456dc50a4cc094",
                name: "f06687e3af61443f971ccc2f30ef89b06491390b94e64a669f9da9f8bca920dfb5ec49d993934a55995129751584bac3742f9e85cce24aa986523650c8c9558a7588ab175b934edaa84877d75d3e5a4a6d919d1077cf43e59a0e527934db6e32e1c2848d33bd459f8576e77b0c3cdfb4f05d019cf7d14142906d58af273927cb441c9901aeab4925a4ac31d726be6275baf2c106f4bf4f1f853740895447de91ad23c156f1ab48eaa10f4aeac690c9295ca89c4f1c45473d813267b3f1f9274ae85766e8d48c4c0e9399f4a05e84b9ac986f1d576c1b4d4caaa9a4ca9632da4345672e4a5b79440a94199d01ab3c6df417de7225e12543d38e8b",
                tagCategoryCode: "0410573f7e954e249270f507a5383fc4120f6da0a5834ce183",
                extendedInformation: "7352301e28c54f509d33db5881a2bd5aa06c8bb484af418aa5fcd05582c98e5aefebc119ea3542eb8804881563ffa285d834369fbcc64540b60bbf8dea6bc90fd3d0386ffd3b43c79293dcb141a4214e4e08239eb60e413484d079e193f6b41a6e9f458e7ada48f8814fca14d832607b1e4e7b48c7064d698befa7ad88b07187d77c95d0062c4811ad05090b88a554490d022c144b1e46bdb1ffda205e1b37c2a31dd51f84a24e82bceb5e57c3aea3b18fbc80a2c56b4927b7fa04a8c0b5a9a605ef9511ff624abc9bf636327dd0aa72ab6c4ebee19941258a94ea1814657e4a30c28817846944b99a8bd3f5c9ca6421640b7db1f46545cc8847",
                dateA: new DateTime(2020, 5, 22),
                dateD: new DateTime(2018, 7, 20),
                sort: 701404603,
                note: "d41ab664abf34238a48908730cbc3f9774a69beeaac446a49fd67092e4c8f054a007f60fd5754c728c6870648496a067eb0adf512baf4193a30c5af14554476f2f5a27b1fe114f808aad3f7c7fac6ca2b912043356b74156a80b108c6ce558a45810cd5b073f4cae84f2f47761c1ec9e8ec6a9b3f5e74c559fd13a8be95f6b87f9bf822a42bd4ba6b61226a796c1ba5f26c0085a94f941889c5df5c0bce5a6b9e886a59036ce4b3d879c8f276009e8910fe452316a014953845bcda3766e37414d0284d8217f493395b3a98e1d01d20d24b13c42f5f14e18a9234da875c2c36f49dab924e13545ab9c5eeb1d80acee1dbf0d31c7f1684676b689",
                status: "fd16c492f5614aa6bbf8b163b2fecd900f12e4625bac47e0a3"
            ));

            await _shareTagRepository.InsertAsync(new ShareTag
            (
                id: Guid.Parse("3b52c94c-881e-4b69-b542-2c4be493fd57"),
                colorCode: "e58dcedeef514ae683060f1656a29113eb21b33c784e4016a4",
                key1: "dfebf3ebb1bc4a99b986855fb72ec7a30d47699cc0024744b5",
                key2: "54ec80a17175406d9ed493b6c8f0e3fe751f1461b434404792",
                key3: "4d9703f10d4b4a84bdebc05b35c04b46afd626c08ff5412d9c",
                name: "4ff60404e34949ebaa00c651944a8e91d49c23795dae4ae9bc305388df9a6dde37c893e1a05a418db8c255b73b32eef04efc1fa882c7459f983ee39d27c79fb553b51f4ff7794b9daab5d0eef94fac3846ead30d0f024aa3b4be9ce45e5996704e6d0bf5a53b4a82b39d545d0ab07026950c34ee33c54e9b873e24f718ad2480bd4b64401a2b46668129bdeeaccf14ca005a588b95be4f5c889569bc3356dd6fa75157d3aa814926a12ee60d11a498014856a4e16c76488293163fe1d3dcf517b206adb675a24fa883aff43f8dc40143a74461924d984620828564cf1321f82db1af29f4aeec440f8c7c930dc1e04deada003cb24af34b9aa527",
                tagCategoryCode: "7bcb62f520174d54a5a5814b9a40daec8a361a3d95634a0098",
                extendedInformation: "9a315eeea5d34155a3ce257d8b5ae21f535572106f9f4f678fd129ba747caab0ddde3cf190e846bc88bdbf775447c52a4b51fc16b32647b198f3213d766c30e97b20c023fa504eb59e87e853c0fae2d01161e0b986e142bda873aa59181af55c29fcecad2b8b421bb4978c5e4631aa2ba2cab19e4b0b40d0ba32d46929ea1608ebe823a1b4be451f91305758a831c6cf43399ee3eefe47f6bb3aeb1886c972df06fc17d70ea947a2932c81c5c16abca0e85b514dd2714772a7b8836d236a261650c714a8ded34ca4864fce3d1561d76f4674316e3bfa45f0b6c8002d6209162079d0f08b62174629b1b8250a238c1cf9e67cb8ee015341f7a815",
                dateA: new DateTime(2022, 7, 12),
                dateD: new DateTime(2004, 4, 8),
                sort: 1179489116,
                note: "0694c2fc6bcd492ab7a6962b27bd350ac7227174bc744ea9ab6116088247241a0bdf60a60b444c70bd8b8988313791d709c363a14ed74e61b7ee5cdfa9c00768e52f15941b0d409eae250f80f89ec5e5177ecae613af4e0c845f269765f50e1c1dbb560d1a3142debbdbe1b88f0fbd8a4d8ae49ffe6a4950b008b1c1a7855c22996aae0c69404f46ad365c29a8634bd869e42ba463e1455f81e066608cdcf91100d8c4cdcb7342d5aac5104ceede38c663d51da054ea4704abd25ea2bb92ab7349548c0eec0a444c9580119928aaa02e92130fb096e54b47b7e94b1c8162d0e3bc18b364c2f64828a6fb1fd1be5e3ca29f70c8575818467eb739",
                status: "517be631e72c4cf3832a6022a70086f93d5ad5f7d3de48afa8"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}