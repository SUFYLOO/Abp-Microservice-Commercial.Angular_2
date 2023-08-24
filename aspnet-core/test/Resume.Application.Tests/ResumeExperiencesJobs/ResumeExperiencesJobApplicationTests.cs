using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeExperiencesJobsAppService _resumeExperiencesJobsAppService;
        private readonly IRepository<ResumeExperiencesJob, Guid> _resumeExperiencesJobRepository;

        public ResumeExperiencesJobsAppServiceTests()
        {
            _resumeExperiencesJobsAppService = GetRequiredService<IResumeExperiencesJobsAppService>();
            _resumeExperiencesJobRepository = GetRequiredService<IRepository<ResumeExperiencesJob, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeExperiencesJobsAppService.GetListAsync(new GetResumeExperiencesJobsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f701d2ad-33aa-44cc-98cd-b79aa447433d")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeExperiencesJobsAppService.GetAsync(Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesJobCreateDto
            {
                ResumeMainId = Guid.Parse("dd6254ef-74f9-49db-a6c5-8cb74ce45d06"),
                ResumeExperiencesId = Guid.Parse("f27212fb-2382-4ab5-bcc4-650384e538aa"),
                JobType = "d24a797159c74c19aa5500d63b9c0e0f06b022330fbf458a9736922f0081bd87cf8f4113b8ed43329563ec7bbd8efef5412e873a977344c7b5a3ae2b6696513ac3163605952e4b38b1e780272a3aa4c21da601cf276148df88f3ecc686e67b87fffa74e6d39d4be1b8dcdd5ca7bea9b9a6dce7e4b94e49b989c8610aa813e56b44f33e15a82d4c4d85c3c312e438ff618d6c0adcfc09421b868f9fea92cb8dd0b22bc17f302d4271830ec206f402e80cad04d547f53047879e3f765a5dde6b9282684a8d38ad400f840c545e0eabf9a2691dea2f3b5e49acb65a46dd884b63af053a8e0b64b44ee589666deb0ece2bd32aad10f90cc74e35b3d8",
                Year = 658554654,
                Month = 294461585,
                ExtendedInformation = "dfa9605c9af143588551603409367e2bc729d17204d648a4aaa140cdaea1df460e7662bf901248d68d91d6256b6e5a918df643ad8d9b4080a93acc455fe74e2f2ebc611093424780ab39c05797af80514554321731364721b7b2275b5968bbe7d30110324a134b85879b4f16bdcb048df35c226828874ffeaaaeae8d917c601cf30bc3f30f7f4b54a30a7d87cce0bf180244456124424f2a8aeb1537e82e154ae57a73a5935145eb968f1dea0072c4a9eb6e73417739453e955e95c3aed1980bd271fdce467541439cd920a7a0841caed84366474a0542f786153540b1c5cea8c2901a4a03f54a939c465f664a775f415b5c6b7eec464aa8b351",
                DateA = new DateTime(2017, 5, 8),
                DateD = new DateTime(2017, 1, 27),
                Sort = 1159748166,
                Note = "17a128f545304e7ea9d2deb7929f37a480ba9c1e33bb4545a368ca363f8b74a593768a1b2bf147b09a99d1ce17b3114ea41c3d1947b34099b327ce29d32a628351bce93e989c42cc9e1ed8ac0c6643366e30d1a6182a485e8b5ee50deff7720658936d5f8e4242e2a50d517c83d65ca7986b8b76dff74f2abb094211299a1f5d6b0b0c61f9f74c67afd50d47af5f9e55ed82b342a4ac49a18d036c1bf5aa0b1822af1ff5db5148bd80dd2920554bc7b47bb2061c08094e4b93f2a70536ef4e17321824d5324041dabfe7459a31fa0ea4a4283719be2f45b69ef2a370e5bb0af0cc37ce5a96be4eef842e28e7989b934cf1c97c7873c744f68995",
                Status = "65f9759ac44b4deeae14abaa4153d96744db3bf756774a1e95"
            };

            // Act
            var serviceResult = await _resumeExperiencesJobsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("dd6254ef-74f9-49db-a6c5-8cb74ce45d06"));
            result.ResumeExperiencesId.ShouldBe(Guid.Parse("f27212fb-2382-4ab5-bcc4-650384e538aa"));
            result.JobType.ShouldBe("d24a797159c74c19aa5500d63b9c0e0f06b022330fbf458a9736922f0081bd87cf8f4113b8ed43329563ec7bbd8efef5412e873a977344c7b5a3ae2b6696513ac3163605952e4b38b1e780272a3aa4c21da601cf276148df88f3ecc686e67b87fffa74e6d39d4be1b8dcdd5ca7bea9b9a6dce7e4b94e49b989c8610aa813e56b44f33e15a82d4c4d85c3c312e438ff618d6c0adcfc09421b868f9fea92cb8dd0b22bc17f302d4271830ec206f402e80cad04d547f53047879e3f765a5dde6b9282684a8d38ad400f840c545e0eabf9a2691dea2f3b5e49acb65a46dd884b63af053a8e0b64b44ee589666deb0ece2bd32aad10f90cc74e35b3d8");
            result.Year.ShouldBe(658554654);
            result.Month.ShouldBe(294461585);
            result.ExtendedInformation.ShouldBe("dfa9605c9af143588551603409367e2bc729d17204d648a4aaa140cdaea1df460e7662bf901248d68d91d6256b6e5a918df643ad8d9b4080a93acc455fe74e2f2ebc611093424780ab39c05797af80514554321731364721b7b2275b5968bbe7d30110324a134b85879b4f16bdcb048df35c226828874ffeaaaeae8d917c601cf30bc3f30f7f4b54a30a7d87cce0bf180244456124424f2a8aeb1537e82e154ae57a73a5935145eb968f1dea0072c4a9eb6e73417739453e955e95c3aed1980bd271fdce467541439cd920a7a0841caed84366474a0542f786153540b1c5cea8c2901a4a03f54a939c465f664a775f415b5c6b7eec464aa8b351");
            result.DateA.ShouldBe(new DateTime(2017, 5, 8));
            result.DateD.ShouldBe(new DateTime(2017, 1, 27));
            result.Sort.ShouldBe(1159748166);
            result.Note.ShouldBe("17a128f545304e7ea9d2deb7929f37a480ba9c1e33bb4545a368ca363f8b74a593768a1b2bf147b09a99d1ce17b3114ea41c3d1947b34099b327ce29d32a628351bce93e989c42cc9e1ed8ac0c6643366e30d1a6182a485e8b5ee50deff7720658936d5f8e4242e2a50d517c83d65ca7986b8b76dff74f2abb094211299a1f5d6b0b0c61f9f74c67afd50d47af5f9e55ed82b342a4ac49a18d036c1bf5aa0b1822af1ff5db5148bd80dd2920554bc7b47bb2061c08094e4b93f2a70536ef4e17321824d5324041dabfe7459a31fa0ea4a4283719be2f45b69ef2a370e5bb0af0cc37ce5a96be4eef842e28e7989b934cf1c97c7873c744f68995");
            result.Status.ShouldBe("65f9759ac44b4deeae14abaa4153d96744db3bf756774a1e95");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesJobUpdateDto()
            {
                ResumeMainId = Guid.Parse("3c096702-345a-4389-b0f8-7a9135589795"),
                ResumeExperiencesId = Guid.Parse("70cbd599-3df0-4e46-ac6c-420717965715"),
                JobType = "73711799cdd9450a937952d49305fa3bb009740d491049369442c82dc0493c4cffcfa830aa5e42fa903745a5e5e0402c40805797b5e34dff9cf499beb9990825b35a4e505f304fb4947d5833402707a3026986943bb2437baad0acd54851eb6a6db104b77b534cad94fdd4605c2107a36a5dd949717e43d5b2e7760f355a41588520e0e0fe9b4e71a494cdb52b37a4111b00190a2759460888826f0eabefa737c8c3d3d1d0b54d3a868760017a119dd3412ba548d2af406ebb955eac55be1b16088ae7872c7b4cd0b55678b60c989a5d8063243ad90c46bebcb417fdf9bb89dfca57354d7c574fc89af83301365f4b05293bacafee584ea4bba9",
                Year = 695001299,
                Month = 1208294442,
                ExtendedInformation = "733a604f25524a3e92f0b1cf96a5dcad379e3640a07a47b684767ba9e820547b49fdc78c19ad4d34914cec114d9911f26b52a2d523094156a3a0b2ac8e5a406c024143e5a9e740488dd5cb8f7607cae3aa7c49367f3844ea963e0d083f7149b13c328ef3de804156a8f534ca2d7e531718e152e265714a73851438f1fc80411146e169181dbd4e28acb05e4d768abb73b96b64867e3f449e83728a3282b5abb9bd9cfd3e021e48c8a147ed14549a006680a1766a8b0e4e94a9057cf9049c0ff03f4a5d372fda4be0bf3944c3ba780d76a41a90d7efde4ada9eec6418706116a5f72b160b7d2a44089dcb47b7fb1290fdd4b3c0eb0683453eb8fc",
                DateA = new DateTime(2021, 11, 25),
                DateD = new DateTime(2004, 6, 22),
                Sort = 1757628173,
                Note = "5e02df5325d0468c95b752349dffc0340c1ecc32280a41cab7e115387dd72e70ae245f45db6d4ea2be91fd92673b3151b92f2c78eb4e4d21b89dee1427873f73cc21264448264febad5640fe175f9928f69ee47f7ce940dba00aa3068cb826dd4920007ba9cd4669b6e1cfd1f59db7bdcff8d40747a741d2bf12237079301276d302930dd09c451199663281f1e69e069af95678a6b1471b96aac347c877ea84dfa4d6765ac14b7e99de09612e9e2b8b714a91ddf511486a83c7874678b0d3a6af1b6da789514c59aba5c4e9eb14c546ddf961d4a6814ca49892a6d502a416fbde1ba0e0032345f586dd7a67294db7d6b3cfebf5c2084846915b",
                Status = "e2c59ae4e6944925b7b0b199c1126d3e3a5af929688644d583"
            };

            // Act
            var serviceResult = await _resumeExperiencesJobsAppService.UpdateAsync(Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"), input);

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("3c096702-345a-4389-b0f8-7a9135589795"));
            result.ResumeExperiencesId.ShouldBe(Guid.Parse("70cbd599-3df0-4e46-ac6c-420717965715"));
            result.JobType.ShouldBe("73711799cdd9450a937952d49305fa3bb009740d491049369442c82dc0493c4cffcfa830aa5e42fa903745a5e5e0402c40805797b5e34dff9cf499beb9990825b35a4e505f304fb4947d5833402707a3026986943bb2437baad0acd54851eb6a6db104b77b534cad94fdd4605c2107a36a5dd949717e43d5b2e7760f355a41588520e0e0fe9b4e71a494cdb52b37a4111b00190a2759460888826f0eabefa737c8c3d3d1d0b54d3a868760017a119dd3412ba548d2af406ebb955eac55be1b16088ae7872c7b4cd0b55678b60c989a5d8063243ad90c46bebcb417fdf9bb89dfca57354d7c574fc89af83301365f4b05293bacafee584ea4bba9");
            result.Year.ShouldBe(695001299);
            result.Month.ShouldBe(1208294442);
            result.ExtendedInformation.ShouldBe("733a604f25524a3e92f0b1cf96a5dcad379e3640a07a47b684767ba9e820547b49fdc78c19ad4d34914cec114d9911f26b52a2d523094156a3a0b2ac8e5a406c024143e5a9e740488dd5cb8f7607cae3aa7c49367f3844ea963e0d083f7149b13c328ef3de804156a8f534ca2d7e531718e152e265714a73851438f1fc80411146e169181dbd4e28acb05e4d768abb73b96b64867e3f449e83728a3282b5abb9bd9cfd3e021e48c8a147ed14549a006680a1766a8b0e4e94a9057cf9049c0ff03f4a5d372fda4be0bf3944c3ba780d76a41a90d7efde4ada9eec6418706116a5f72b160b7d2a44089dcb47b7fb1290fdd4b3c0eb0683453eb8fc");
            result.DateA.ShouldBe(new DateTime(2021, 11, 25));
            result.DateD.ShouldBe(new DateTime(2004, 6, 22));
            result.Sort.ShouldBe(1757628173);
            result.Note.ShouldBe("5e02df5325d0468c95b752349dffc0340c1ecc32280a41cab7e115387dd72e70ae245f45db6d4ea2be91fd92673b3151b92f2c78eb4e4d21b89dee1427873f73cc21264448264febad5640fe175f9928f69ee47f7ce940dba00aa3068cb826dd4920007ba9cd4669b6e1cfd1f59db7bdcff8d40747a741d2bf12237079301276d302930dd09c451199663281f1e69e069af95678a6b1471b96aac347c877ea84dfa4d6765ac14b7e99de09612e9e2b8b714a91ddf511486a83c7874678b0d3a6af1b6da789514c59aba5c4e9eb14c546ddf961d4a6814ca49892a6d502a416fbde1ba0e0032345f586dd7a67294db7d6b3cfebf5c2084846915b");
            result.Status.ShouldBe("e2c59ae4e6944925b7b0b199c1126d3e3a5af929688644d583");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeExperiencesJobsAppService.DeleteAsync(Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"));

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"));

            result.ShouldBeNull();
        }
    }
}