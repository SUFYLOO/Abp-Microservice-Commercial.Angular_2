using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.TradeProducts;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.TradeProducts
{
    public class TradeProductRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ITradeProductRepository _tradeProductRepository;

        public TradeProductRepositoryTests()
        {
            _tradeProductRepository = GetRequiredService<ITradeProductRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeProductRepository.GetListAsync(
                    name: "5d7d2964d0064a96af6b765967b4d0e7a1bc52cb63d54a90b3",
                    contents: "e837c8f8991a4eb5b38b4777d998b8c39507961b4d954f10a4f60902cc696559547b1bce75b942ea95b44904e5c4b4005d767e0cf8384c5183ee24576d9a17304f3a7db38781443a9f27557c881698b5c0c2a45510104a39a60d7644fb09862edccbf97d3d2c42b3af7c8421ddd77e139b08a3954d1d4b03adaa1d328817e21346d86ef660fc4ddb94f8991691efdbdf6cbc6b59c2e5429495ffd263bfc6a96ca34787bc22ed40c490943cdb17db26d308c58d8f168c4d3f975ea8b192920ed66473f4abe25f402e86d2a37b61818b4c6cf60547a85f485d8b4b1f80a371c0821ecf8748eaa04a648f78c3da5eee12f92d21eb4586044512a6aa",
                    productCategoryCode: "1432714ba6a54ef690d049dec1db2766584e5ceec1b74127be",
                    unitCode: "677700db56b0443d9ed8799a5dd0141feba8e1c009cc4639ac",
                    extendedInformation: "004d1c64a97f4418b523596fb8d0eb633f5a30f8378541dfa928f55438bdaefb4ca5bb4548b74e37a66ad337b94d662288529d3a013d4f5ea4d172d4dd0cf8da75edda077fa344568ce348339bff289a520231d8faf5438eb52fdcd4c1d6bc829f55419a3a94461fa50a33ae7c36f6018d8fd641687b4f878021225c9cfec008356f0ad2ae7948bda47a862f972015b46a84d96a01844bf8950427282ccbb7c671d840df12514a90a00fa473018ca74fe145b3d45ca84d7b93d79d075b4c35fd0743caf46f9b413e93c4086606e989236c445d1e8aae40b4b0eb50e5d920a6fecc6c80117d3449bd8c0cc446525bd73b70eabba6cbfc44c9801d",
                    orderStateCode: "0b917fc57abc4090bbecfdec7653d504fb88e49e21ac48e6871e54c19cf477a89ceb24e649a3455cb441061328459b16a9b14e003fcc4ec5b0e6b3df7c9cfe0b543453a70e7241cdbf53e599f403e84fdf6df256a94944fca5ca4a910bd5ca212dcf52593da24bc88371f01e93c25a61dcb9280ab75541a19f6775bce2db0327476d17cdd9c94536819ad53ad4558b25c0d0d864981d4f9286a592349d8f9470c803967ff3bb4f88b5c6205a1486889874aa6b73d5e146baa6fd00742b0f915694b3e3ec589746f690e0b7fa3e30fa0a96e0a9365f86400f86f44a4106cf3420c7e4776d3a684b80ba16f424ef2d86cb5b3ed0f531874bc3acdc",
                    status: "45bc9dcdd4234959b3d059aed069232db7be3b50191c4fc490"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeProductRepository.GetCountAsync(
                    name: "8cc140b002b44f629f887bd5cbbbf37424850e917fd94b33a1",
                    contents: "7e63ff2ae6774804becf087911589f273f31fbebd4c7452aa44a35a46000d1fb8d70a8b4bf5e4018ac67836d368dcc80e7eaff05e5a74a87a9f18c456621dd48fbc85350bdb44aceadfb1d3252cad28c23b87601f0674716862eb446ee76320b40cc8299a832466ebfdd3e92f99ed76aba8e7ed9412e4f7bb288b3a256ee831c08de78bb390644ec8abee2eaa4a2a00b2b7a1d56e0614facb887b5588c4bc81d986ec09a79a74eaea07f0620e49e5f24bf9cdfc14cbe4b8db42e609e2efc56a062137447a81c45be8bc086e73eb4e9753a74de1aab5a4cac935252266896dc29b24d429647c244099a8d78fac55693456f3e26a8bf9a4d7b9d3d",
                    productCategoryCode: "645a2193f35f41b9badb8f9c3939d94e99f4722be9f34e7c8a",
                    unitCode: "08970c9d441d4545aa330f4ed2a04e6652fc035a8d664cf2af",
                    extendedInformation: "9bad70224f4745c7b195d95a7a604fb953d959325e26445389b06771ef3f1639720c6138abcc4a909d1eff6284222e4a963d107a34ee44949afdc6407c107a50f4cd1c7188964d909d8cba17fb5a2699459c3c250402400cac3b4c40ed9584b901fa072e939b4784937e923ded9b65fe3f1623a5c9a34b7b9b569f9f3ece62b41b618973d5304fbf8b60248616520e927faba1af275740fcadede17ef1203cf9145bebfec1c14d46b8da65923bf3d2a8a3598ec4b26544cfa6ddf4fb8b5b6564251a08cf20f049babdbed944d066bbd06f7e4a2046374435b9be762939d7ef88318c2e2be4994e9489922ae21b4df08785b631eb30854dd7ac2e",
                    orderStateCode: "fae9951f61a6434a93298dd67f5a6e31df3c50fe65dc484b851e31e3a0c828a86c3958b4f7064219bf5a39877d80a88f4132a14e63a04688b1c9670272d1286c97855a312ddd4f2598e37719ddcd6794625129c663ec4dbfb177a5e2518a2f194d5e6afb40a14aa9b8ad9c11ec47fd63e85ec4ab4cc74e96bd850956d6f05771536b9fce019b446e80b72705432aa317711ef0191299464da559c04951e6d67eb55ed4ae9b11449fa06de9c180670b74c0944ece1b5342d788866e86b9abd066c606e0100c4a4577a99b704884de366ab9437ae65fdb45db9a88e5df62cd2307386cfdc9ee744abd95d90dd14d772a07c9cedc71dd30490bab11",
                    status: "b7d91a5914ac453cbd55b55a159821deee3495a2666a4e2588"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}