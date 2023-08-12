using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyJobApplies;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobApplyRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyJobApplyRepository _userCompanyJobApplyRepository;

        public UserCompanyJobApplyRepositoryTests()
        {
            _userCompanyJobApplyRepository = GetRequiredService<IUserCompanyJobApplyRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobApplyRepository.GetListAsync(
                    userMainId: Guid.Parse("a07202a2-a59d-487c-bb3f-0afc37df4b38"),
                    companyJobId: Guid.Parse("fe98c41a-8832-41c0-868d-83748cda76c5"),
                    extendedInformation: "c3e2ecb704374dbfa0eecc494ad9251d3993d4bcbec84bee94c2df244b2bc937425890b02a32400ea983bde702b0ed0f23be95a7b4d746f3a6ed24d5d78f4f737cbedcff33e64aeba0409469b40c1599e6af60ca490245ae91f13c319927bc26943f17fec7684f7e867c48d0e55eba66736fe383b60f45e799fc771cbb693d33c74573f5e531491c8ebd970fc16f833629e138dbcc0d495f8ee1a906a1d5fad82c74e2ef4c684275890edd1b44b3e5a90cde6f5506794c3e86a8588ff62b930f2c9b8118d784475e8f24177724043b797bda96ae6c594d5382953fc6a89fa303de1603a2601a43a787f8e014fea95e78bd648412fcc84639bbbb",
                    note: "9dd0b59a448a401790801de7a715f3b5c0548e9b6fd24d84ad36e42e0c5d9c93153780d42ec4412ab12c4dcc0a39bb5a8e4e2895b0cd4aeca4719ec548287dc97f253ff99ba540198300c3b5c8cbccd4b3b005a50ad04e1da149d20f68e2a994e075fe6114034b49bf16f0bc2d0c1b57904195f3e9834ba687a867a5bc2e6d67411d36eaad3042a1bab86efbb0ca8b39aae2292daed74d03a21d792bfdec789006394b90c0a14f3da2b3f713a2e236348c56969a2ea846b8944ead2561eb2ca99f790751579d4032a9d8b75102655043b0263eff2dd44b83826c058b1bfd6ea7c0b84c2409b844b4be054659d4ecdbaae86d02a78c014ad6a57d",
                    status: "66c980fea62f4913a1c32d8b4ccdd57d1a3d130404484c8a93"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobApplyRepository.GetCountAsync(
                    userMainId: Guid.Parse("baea2d2f-21c4-471b-84c9-c45a71d51841"),
                    companyJobId: Guid.Parse("f1c266a3-5893-428b-9320-f6ee579dce49"),
                    extendedInformation: "cbcca035bd6f486687b8a11c068f25c462232b104f094d4d85a4f22c795f1f7b47a38eaf45784af281025a87fe2a2b039c8c9b40b83f48818510f3d63a8be5f0c4e7be797c504dafb844bf3108b8300edfa5e2b171f44dcabc7fc02f896d445056a2f03c34504db58f3395319c76059be2c1b37c57494853927cc499c836066470620cb62aa348f88f0effa4a8e40b709211266f3cdd425bbcec8ff89e0ad039d729e69c5d084d82b4f663346a6a2ed7b80d85f23805470ead1013c8ac1efd179dd1770473954722ba7cb95132f08990e5eb74a500f842b4975e23ef4df18f17d682efdb3f51476494854234cc6427ab40cb01ca5324439d9e57",
                    note: "67b84bdecca848f98854891e4720bd91e274b19e9fac4bee8761954de9a3e8cf7e10a5e470b845aa8bd5679943a1e42852e2cf4b0e104570a08bfab6788292d01d1b513873a740af8ecc58c9b949e8ef4fcff4f47a214fce833a73321aa76ee5b989e006bc5d4d4988e9efaa003f4bab32ab5d9f59c340b5a72fe42b04b40aa12d44ec59803642c086bbf40b55408d3ba8db51be3d4c48309e83a46fdc032b643770b229b5304361bbf7ae085f9e66763107750fda314bbb882a73191daacad53e9cb2647c1f4863ab200a3eceb862eb0bacf2039c6f403ab1648852e87fcd7e4d80a075f49c4cbc9a45a30826e62d3eb90b0c6b540443ed8287",
                    status: "9fa295c96fb74edc941f86197f9ca9bbe9d8b4f3a21a4dbbb2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}