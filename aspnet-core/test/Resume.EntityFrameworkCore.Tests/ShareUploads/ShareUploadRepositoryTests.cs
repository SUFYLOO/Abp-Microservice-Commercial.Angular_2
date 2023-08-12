using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareUploads;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareUploads
{
    public class ShareUploadRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareUploadRepository _shareUploadRepository;

        public ShareUploadRepositoryTests()
        {
            _shareUploadRepository = GetRequiredService<IShareUploadRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareUploadRepository.GetListAsync(
                    key1: "c40355edc4084ad784ddb6ec3b1451e552dc8f49a9de4138b2",
                    key2: "daf8e8e50627402a831e5fb879e7c741976c986ae5054a1081",
                    key3: "4ebdcfaac49442878e8b2f063f5b1cfd2bd22aa84b1c4cc7ab",
                    uploadName: "ac29ab983d73482b836f48e2f8336c05b1ef4719b1c646fab298ada7b72dfdab419b946ed49b41478da8ade9e0b7dcb19c8b5dfc486b4b069126c4c4357d9e3377dbfff5602c47978e29b745b75ef7f27851215a3a524c238ec46a3015d94ff60c36bddd",
                    serverName: "ac0af7f4395746fcacd5d1a4d8f486a725099d219a3e483cb514eb0e94f94720b74f21a35158419c84fc0be59578b8153070fdae571f4bc29dd88d79987959cc575962149e5140c68a930cef6f4fec8d13746dbbfef24f0eb67707fccc5eb8b6ae7d3613",
                    type: "019ee5f6a1434c728387cd45b6bf47a27efbf0a3e59046ed8f312f688eb1bb507be5702c093040f3acad92619a32b11d0dab9a3abf444d578a5069b8bc7c7865ad750a4d5f594eba8f27f8401aabe900e982e06bca4c4e1284b49c20011dcf7005b5e8cd",
                    systemUse: true,
                    extendedInformation: "645e79133198494e952fd62151961c207a9e2cbd30c741349942e8db209859bdb6e9c2ca1eb141c897e8d9764eb5d04c71ca6da3b6d14fb8978551c654d217914754893ce4804700a329c557b0f6004fc58cbc38e11243a980efc12cb7ba2441c3c1599bf330485598753e32b7c882ce5b9de3f29b0d486fa9bd81bb892e0eb2f3ec6a10818344deb764a082fbf6483063fb822885aa48e88f3ad7a252a2571bdf7dfff788124e5f96c1a33721306f6b08be9cc216e04c35a4f9694e3054002839a0ef894683460cbadc5101a57fb6a978521e254f5746b99744106779fa98a84206c368ffcb412bb4bf2c7746bc32e4b0ed0c3144354de99404",
                    note: "22e81506a32a44afb3437bfcb61737f3de377df3a06940e994a9352a5c1b5c7fae3cb4ff333843af8859ff8cc8c06d51b98ce22d33514dc8a9fa9599e4d9791f9f3e380a5b9c4c6d9984085f975b5ea546546865a6b64cf68bf449dcc54962e323f7dbaf0b724a4b9217bab82651fe4a971b78cb8e4e4625a311a88b98b53a5f8d76f31ac8df43639a5391bf2b14e303313b03e95f1641d2a483da36956acd17bd2f03920a474201bbcb51fad3ae14cd9749b9b9144b449a971b014c5ef7ed6482f50cfc56894681b2c8b8979460260723621420de1c4cbe8aa42668fd938f55a21a8b423b6e4c0c9b0cd2c40be5d55d491d2d18fe07493f8838",
                    status: "88b308c3bfcd43309e25868667997f94b56335e27ae84f4697"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareUploadRepository.GetCountAsync(
                    key1: "938863c2f3ac4f3d9148921887c79a010f0fe61179b648b2a2",
                    key2: "2b5a1c6483ec41baa69c264c2ccf6752a8927844105c447abd",
                    key3: "aac8aee600e3433894bb9b9d63519f491430fefe44fa4e0290",
                    uploadName: "65715f8b016f40cea4cd69fa2a61c84ae0b6df7bc7b348b89b33fe1f96a63d758f70ad108da240f3979544835d1dd753c31ec7ebe4894494a4ee6306b34ea10603d6a55a46b641bca542819c003d805ef9fd4fcd493c4141b6a3e5b2da115fa8af7ac892",
                    serverName: "7d4b954fec174200917658e94db7826fe3179bb3993f434d945ce368f4a597421cd1f0c1b3ad47c0a4d404b3ccec8c57dd3d650183bc4e8c9ad3be1a6e8b483e1dae3318d08c4e5a9d475b42b1e93e7c31c75af1ad434cbf93c6ecbffca7e3a98c5efc48",
                    type: "f0daa7b059ca400fbf737622bd8098c85685779440c0441f9793ea409538dd48f3811e1d3b1a45ceba1e8ebccd21cd0d25bab5b12ea94d849f0c1d28404734daf1c4daea852f48118d49e73954555b32297803334386404aa3e8a39766c50bc8cf758f11",
                    systemUse: true,
                    extendedInformation: "4f8e6699938e46d881ae4496e29e6ed8e7fdf66f454743369fb806087653bee4e784fb5e7b714c91a40eb1ddacaf0c21a0ab98bdf8e04476ba6c745dd5a599de465a910bd0f148b29029e87b9650933bfb2e478462f9419a9b9c76658e1cb2a4cf2cbeaeab694201956a1f4e7c03540e953108ca95da4d4d9b5d0198b53fc93932f9849a3c9a4cc584a6aebdf97eba5552de839c675440e78e4cede3a767338aa4bb28c7947947e7955c1612bc62760008f0e5113424473b8597fcdd4d8f3d0743779e630ad74fdc8849e23c68037e0852436c3aa8df402e9ed9711c85170e7c7afc4459a087489490e1b3dd5e7d654e4bdf77cdf4804391a88e",
                    note: "4d953290934f4394823b60db8a233478b1a52ca3b60a442a955cd07ae16c0c3bfa8c332fe714469f9840a4f654786f67eea1ad26dce647b9b210b83c2265f9f01e0aed34d7d94708927dc0fec4ebd85e8d529852e76e4a59bdfc92827bdeb0dd56862802e6c2445f8aaa674c178097f22d6c1059df0648a7a4b020bb1a84640768a8b6da242c4fd290a4ba81385db2efa9ce78a92371422182203de1f78bfc774786592cc023414e9cf0f506d54854f7d3c49b85c53341928289ed62621a1a89224f4f2949d94d8dba811a292fc234bd516238d3057b469c91dcb4366673d5ee3f9b2bce369d4913a35b96fab82fc702b82ecb2b6df04ef58f17",
                    status: "25d5fd1e876f4d7f82c8040ebbcb7518a2d6bced254248829d"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}