using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemPages;

namespace Resume.SystemPages
{
    public class SystemPagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemPageRepository _systemPageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemPagesDataSeedContributor(ISystemPageRepository systemPageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemPageRepository = systemPageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemPageRepository.InsertAsync(new SystemPage
            (
                id: Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"),
                typeCode: "6327105e793847b9bc6e4140f9ff5c2f6b4ac79932b3433ba5",
                filePath: "a92ab7e8d56b45fa86d060ddaf6eccd8139427ce15ed4889998e77d7078c465fb8994719a28246bda667d61662458c2a7debe666bde74300ab43118a48776afd4675bd324d5b41e29fe604db48c9c45e5017456d1a3845b3b8b89b3e10a852b480173e7a56054cb28b59f5a7e8b03c1c5a7c94f3158049bc917bd5cc4c98c8cf9798c8b6bdb44f15a6d47cdd2672733713638021cce34aa8be1337aaaedf92ec010afc81b2b2450eac72605c3f08ca074eac75da41ff4e73ba1ad79051135c419d5b2bf459114a9ebb4ca6aad1564e754af159ccd1f84bdab47563bb3c306a948edea361850844f385cd998f5e33555d3a0e964cb0aa4fe3954d",
                fileName: "f8c9126b9da24b09aff1fa9bb9eefbafc5ef91acc25f47f599bf62dd0392de285f905a9b00724354a4f25e5fe0b60857c6a4be6337a8415791a4779fe496e469f2cbbf0523854646be0f5b43600227967d751f54ba4e446195c94ac98711b104efcdc496fffe4110a800a43781a31da3448e1b1571e14f6d8be8a952fc00ce8227159f48b4114f7188d06da373aa0437aee030a884b04de9956582329a0a72a55fe7dfd6d82d4c4b922b05fa407c94e6ebe676c7033449c9ad069b00424f8a22aa9f8c247065457b8a1296e83d0245ec09212010dcf746e59f2b5812537d8c5522b4f5363339434c896c3a29ccd0b6ee18fb4565f2c842a0bf4d",
                fileTitle: "e677ac7cabb64034a49dadcb040964ef6b66eae83f744cbb952306823ce6739e1eb683ba6b0d489f91dc61ed7090ccc9b7e561deac9a46e099f22ad767b6df3d006e0cde666447689dccac9a23942a8063042fe9e4c948a7bd2346d2ff6fbaca6536b459",
                systemUserRoleKeys: "cbc2dd0804d94afa9f2db9c20fe75ebeadf0e078686347ccba",
                parentCode: "1c31fc0c17c6425aaa4fac1a03fc564359867035277c461b96",
                extendedInformation: "353fa0dc5c07471b9894625d32c1b5c338761fa458024c718e0c4832a8c99ad857694fcc86b04c22952ba9a70df8f96dea2894a6068b44aba2cfc65acbe5ec1c66e54d3f88524c4bb9979389897c56df79ead78a64b1434e81fdab48936cb40f27022f67fc41426788838b9cf916b8c0ea8b7e3252c240b385a20f6f1cd30cc120d68fee02fb4bd4a9444d0f049e7758e00c3087dda240c4b0ae49e0a11c9a2164dec9a2489d40dcacd1ff507a5717b912a2ced3153045269a201abc7a1fb0b9cfc45c590bf549b9a6a3bb16a2165bb3ddaf3cc47e8849c68e9db804003ad659fce2fa2ea18843328f1504e48fbc1426efe7e4e35f5748f5a797",
                dateA: new DateTime(2001, 3, 9),
                dateD: new DateTime(2007, 2, 10),
                sort: 834543685,
                note: "40fe2bbb22554e6b8a4ec2c966a7bc29494849173a954360ba4cc157581d6eb98fcec99c04a34d7abc88ce21f1e41bd72ebde05cfa8e407dae485fdadb26f41b2b3e84b9f4b049df9d397455cfc81eef38b80a1053b442f1bddd590375289202bd2400757d2d4b419b05c5f1453c030f58c96cf0535a4d50912ebab14e6ccfb308a5c397f8984a1a8c39de4858c1cf875c8a0ba5be6c4789bd7f2a1e36727c3666837d205c2645bf89f30b3dedbcacc3ceba95267bea4a569416d212824cbef325d17942a3584bf7b0b6cbc5b8609a35e5a980087fe54d288a8325013d7b71c4399b3bcd1c754383b106da3a0e61e4f62973d1f3d5044898aeba",
                status: "b3bb2db18fd547039915286e91cdad0911d1824ea590461285"
            ));

            await _systemPageRepository.InsertAsync(new SystemPage
            (
                id: Guid.Parse("e12249a3-1e7b-4463-82cb-2108ba40740a"),
                typeCode: "d7b57488b53f4eaba64ea9ca2bfdf2cbde4553eb8bf4443084",
                filePath: "f0cf316fd3544645a87d45b43ac37239aca3946c6b19414b9032692406018eb437cfa97682d845eeabe5bfe949ceb150ea8e23a440f34a0f973133229ee480c69e3844c7179346dda4ddf988037e6f8ef2d4228cd114486fb956883d28e552648528d23b7f184dd09084a38111578a8660d1577995de44548e9a98deb41fdffc81c6b633c99f412fabf97746381a554d5ac1cac1b709461fb55442f0dec2a7b512aecc45df0a4a828ef790c4400c6e89a595c47e154e4c848a24dfc714206d48d5842452ef4c411091774ed33f0d836ac29d7b7cdd3c40798cb6f36f3df212fd17a310f9f0254e7093ea6f4b6444c71da49da3f4ce674f309d68",
                fileName: "0d586a6a8fba4eb89b7278a39654e7cfb88b9410952f4bf9b505442e9c27a63e73342e935d124057bedf51b10d77785da63fbc0a551745d384b10cbb5543149dd9b7673a83004bd0b6150dc6aee377b5daacf2d516994912a76c730da09861bc980e916bb76f42c696b799964c9bad5d96e348054ccd4384ba9206131ec729e3f2a139bbf281493da58866555552975b3a8bd71572c34818ac2ebc1baeae1f7018abf2aefbc84444bff853605c4edd541532d850c992430698219685e6a8c687a1d3e56eb1b644238bdeea1af2b94b7ff9f8564bbc79406194b53de8dc8c6cb6324d9bb55c1048adbe974b88cfa9a1371193f3ebac7048ed8202",
                fileTitle: "ef659659c45a49c683769a0f45a3469cbf21d5da2e2a4d64adb90dee64df0ec7a7b9c98ec0224512bb0379217a105919ed89edb3fb93416e962a3ee7a318374495222897441d47a4bc8a0a553b8a13d7d4d83e4039944a5b97b23a17164a784871af80b0",
                systemUserRoleKeys: "1194e32e68164221b5c18fcaea056c7acee99823fc3441a486",
                parentCode: "9afacc2807b3403db81069c7f15c584a1f43c66dfbcc49409e",
                extendedInformation: "a50002baf81c499bbd1eaa6f9eac01b0ac69ef47e1a647efb1917196f2d885730862d6538e92422dbf84698a21e2bcb5e9b689f8e99c47eebcd3e8b4a1ec51ef33f6ebbb58c348e08a4f0a1144d9bb1b79cd50e64661402d97d755276aaf73ae0d470aa9f4ef49cc84c6a298fc1c031679cbd8f3f9074a39b73a8211d933edf2d0de94eede5f456ab50f76970bdc787f139720b28b91435e8c0f4692243870786d00bb1fb8c94a1382c12e98c6384d29d28a4ff61d16413d95e197e4b0b3502b8209fa9dab6943caa16d1d84a7042c23821390bc714a49919dec289af3ee9eeb95f55f577bd84670abc05d063567c86cc4ad049320ff43409496",
                dateA: new DateTime(2011, 11, 22),
                dateD: new DateTime(2013, 2, 15),
                sort: 557404736,
                note: "54854c5d8c8144eeab529561fe6e5e3e1ef04e63526e4194bd4e7d6a8b62c97b472e081f7fcf457a9b8ea2d80fbc6e2c720d143a4ba34fe8a52ec6dda13c97911f51e6cfae804341888104f1ae748cda5138914c541640f88e867275fd6b6345a268b19a002d48be8684361530c38a590f97881250004f5c9fa3c3d2df5ec4a3d7b790be58ba41d69b635878ca328cb460dab35695e84c3cafcdccc75a6bfe976d57dfd80909477a9cd767fe94dce72f25157f6f7a62480f98b845e6def64b60563df86057d64401ad8f27db8e30def1439dc4383990450aba3731a967f72f3f1aa86acc1af44bbe9a80491ffdc78854fec47a4c12744ac69cd8",
                status: "50e9902999724db3bbfbd07253f34a862f41c0d046cb44939b"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}