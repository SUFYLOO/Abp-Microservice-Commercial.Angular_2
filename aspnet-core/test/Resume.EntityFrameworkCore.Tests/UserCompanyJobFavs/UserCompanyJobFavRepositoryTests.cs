using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyJobFavs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyJobFavRepository _userCompanyJobFavRepository;

        public UserCompanyJobFavRepositoryTests()
        {
            _userCompanyJobFavRepository = GetRequiredService<IUserCompanyJobFavRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobFavRepository.GetListAsync(
                    userMainId: Guid.Parse("d84a7085-db14-467e-831c-d10f17736cde"),
                    companyJobId: Guid.Parse("f6c833a2-b876-47ba-a36b-b8f384b9b1e8"),
                    extendedInformation: "dc9eeedef2604c4fa214197a70eb7b3286d2afd478fd4f399121d92597b164639b66c6385d934b929ec3ed15295ad2051dc68003c1aa457db900d825e0cf52715a25fcc2a2044b12a223a462d11d573edb8573309aa148d184e76386f7ad43dd9c2c4a32ea8444339a92d264b49915e2d6912ed62cb94e2296607b1604f7356f892fa1ec4905471ea9809a0ac5c7d9f73c4f987009f041dc8a286f93119c755a58b72ef735dc4228bbb1d5141d257769ec3ee8ec659f4899b06555523787fff7183d6a18866a4d0991e317c278ac9a54dcea071c887346809bc8ba782007ed6514beb33010f44d4fa284c21da9863e3708ca73c1a312471ea988",
                    note: "9df2eab24ca248f7b503ff3583589b8b4ede6dc541b2489e975541868658d67598e720fa536846d78911d32084dc4c0f22dd310b68944efcbb414d33d999a7072841a2797e164e42acacc4b4e336c50d6a64a8a9596b4f4aa25ea7ba11acac3e560526e4e2b642ca91dc3bfdfef82d8cab57260dbfc14d76859e9977570190b3d56aaa99637e4c7f844f8582c054edea050c483365c9465788c042b0079f283af27ac7cccfb94f6392c3fdd6ed622d1bd2c201058cc24be4a0c7f25d08c1826c456ef55585054b46bf37e305257dd24cd5ade6cf06424c3a989df305669227d2afe47f37954a49ffa9dbde959e113ff504a3672b053d4a29bf4c",
                    status: "38ceec71a871435c9d5554e8a4c5d44d5ec7445d7b8941a982"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobFavRepository.GetCountAsync(
                    userMainId: Guid.Parse("e17336ec-bc58-4f3d-ab3a-164535ece0f2"),
                    companyJobId: Guid.Parse("c4b58b98-2e27-4246-9eca-d93a4b9f82be"),
                    extendedInformation: "84656734c4ac4bf4a339bef4b449615f1d2e786d3946467e8c3ca72261d52bf8fa7a683bc0e44305a6b0987868a68e23af28414fd88f475cb99af1b76b0f0f66b938e8f836654963bde57c01f1e148103faca60268fc4902bba259553d7b6151188544cc9c204e319217045ea5a384362beda7d7f66e4f13ae0629f2ca77ebdf08a4bc55e0c148f0a5a2834550781278bb6f42c5a06743c68900f10b6c916c5c1571a2fdf518407da0dca98a4896aaeadf4a764de1b44729b4799afd8d1529b5dd0e60746628486e9b9260d8146391303ccf1cf46fe249a58a920ed67429077e4474fc48225449eb89b83598df5b94fec60353764cd8442caed1",
                    note: "8d1047a7b916464f8adbf45a438cf477247c0d88738f417d8bda48b27efaec126265e41846414322b4957c2421f7df1b6a1fbeb1ddaf4667a16c8763e7d03e0a6bb920863116493bbe4c0e4ea24242ec3c21291fe0ed493f931f8ce65c35e80ada4159bda4bc4e8b94b59b7739f261d266599333dcca4301af821973d538ae26af13f81f23c240329f3eae7f63bb2e751c093b0602bd4c46aae96f6e79360c3b3e98443914894840b2a94a5c05b1769bb725699076f64da38f3ab475bfdb69043a0fb201084440e3871cc48a3c426176f94144a2a6d04c9aa28b6155db52eb6a8dd2094d419e4287a371040e24e59f4a10e4ddb1ff7d4cb1bbea",
                    status: "042239e7e452439c9418b45b9485861102f6581621aa4ad687"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}