using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeRecommenders;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeRecommenderRepository _resumeRecommenderRepository;

        public ResumeRecommenderRepositoryTests()
        {
            _resumeRecommenderRepository = GetRequiredService<IResumeRecommenderRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeRecommenderRepository.GetListAsync(
                    resumeMainId: Guid.Parse("384acbe6-8ae5-411c-811c-d4aa06fd0c5d"),
                    name: "28937ceb55004132b6d880ede14493ee4a8eb7e36d794389a4",
                    companyName: "cf71d851e1924ae298b618120ba071ecc90e2061c6cc45a0a0",
                    jobName: "7a32e658a5724c21836d57188fd7c75ee69bc30193344903b9",
                    mobilePhone: "fc24ad5c2a7a4804ba18b8b1aee9259196f24dbdb8c5453fbc",
                    officePhone: "8f25d53f83a94e3ea0771707b9aa7115bbb3708a2bda4f51ae",
                    email: "2b62b6529edc408ab115b7f771e33d12e260436d906c4cc1b277eb68f0501d87c61f844f3b754c789dd29fd786804bec76ffbfc03dc14becb0602402f6d5497098b6251a5ce1479f945af492983103639000537a67f84687b40c27876d7394965716c86f",
                    extendedInformation: "7b3d777bc63b4e8184f70bd8f83f23d4fa4a683da4de48b3b9e57825a98e59d2cae06e14084b4589869d7795dbf49639319a7d6563594d98beb19259768e857b2e61c494191146d5a71dc3b5520a9f2f1f1ee71329ba42ccb098b5c722fd065c04a612799afd4c1fbd9e53193dd3998bba8b4dd9d00e476a975ed593f09f319f60dbe29d47174ea3849b8025653db494a493fe54b04b4b0ba8681ecb7ffef9448b864142a89d4361b839edfee5e23607d4b36c36468840e384d47b2bb9f2bdf5e72010c03f724bd489c867688d0439f36b1c5902c20641499b404e6e66cefa9156b2b15d729749a59b0703eff2c873db52cf6a69e9094269973a",
                    note: "677e84c2c71f484797c0915114b481e81497d3f933dd483ca3ae87e174b413968ff8bbb42a0b46998b16ca7ee00ae9c55dc972b0f4d84e73b6b6fc1059c9c8263363ec201298459e99c3f736f4c0e4a51188fa02ea4a4e91a290d58952a651243d9576cad7a347369ece58b740729752b53c57256b7c4f9eb12c11b49c8d5d031c4051785d3a41a19c4d5d028f956bf8a1ede43dea134ce096a7269ad0cf38532c2fe7e7fa1a453a96ec1d3b5b84909483ce5cbe6c9b4c3c87115d7c53cd9f38a14a8ddf0d4846b7abd30daf09caea0ed81971f904a14e37ad59f1d20ddff85f41512b6052594bf481f70a812f20e392240221a412e54b6f870c",
                    status: "061618a37a884822b5983ec3abe6e8357637e6bbecde4b458d"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeRecommenderRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("555278a0-bd15-4639-a7ba-c52b99b31f94"),
                    name: "cb5a6259ccd54062acc7557a68cc861541aeaca3eb244ba789",
                    companyName: "0371a0ca1ff4426ea2c65a10a3da501c86a8f9325ef043aaba",
                    jobName: "58e312fb83434c89b54f270ddd38c2a9b89d96a0dc164c9891",
                    mobilePhone: "9a751479fcdf4edcbaaa5693af5b85462e184f773aaf4d6a95",
                    officePhone: "2f1948883a244e8590d4b2e43e4225c3417bd5279bda4a5d88",
                    email: "55e68ce10ba64ef78e1c195de23b0a0f93469dfb737b4aba85d7fe95b200abd1bb42f63e88234e56b74a02d3d1e88a06cd13ab572e58466198fa781371d4754a0f0319d7f61e456eb4a69776e285cb64861bd73d8db94e1c8a5794e2bb46257a2d25cf0d",
                    extendedInformation: "2db52cb987a447ffbf76cfba1ec090b79173a6fe0b6547749e823ed158af20a76a5c2a95e0744bd3a71f32c4015813a590bf830b56034286889478484675531224602761f90c464fb3dbfa1e16ea72156afb21fe2ca54f5abcbb16bf97e40be8db6703a795b145b4b7ca46fdebcca3b40f44b64b89a94ca2800f73cafd0c5e067d5ba87301074b1b931d3fc080127691e781b51c3be2407a99bd23307a9fa9df814c9f23697842ce898fd1778c9cc85c7020ea2d227a4a74852500592e9a6790a0db1d351a5648e889a5fe1b99c1ed87ecf842490872430a9d412cb06e563b9b8f1190a5b27142fcb02ef8b7cdf494da91a2b42935404409b9ce",
                    note: "20348f2578a94bfb9bbe4eb858747df5a499da68ea824bbeb36f2cd37f2d4e516441f46e352e44ac8f74bd34ed19160a1d82abbac71b464d9ea5b29d04da1b461e2370428a39439c96734fc9c56aba0f576ed67ab74e45a0beda403c86ccc4c112e9c4fc211f452ba86b6aab664c17dd18d682881aaf4c8aab26a017b1c2e998be554127c38e493d9aedc653a8867a850d0bbc13319e47dd8a1be6d68ec7691b649819de256b4875ad4f1f1af2171c5f2e024ea356854b71a71959f5e91835e30f312cd3bac24886a3c3fd8ad52a2003f2eafa8a94564c3384e94a4dd7584b504f8f249fa0044f42b176e9b7c2b927d68736926afe0a4905842e",
                    status: "31426c9888b641cda0591c433d87f61ddca58d4b1c7b401b9e"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}