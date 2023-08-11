using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommendersAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeRecommendersAppService _resumeRecommendersAppService;
        private readonly IRepository<ResumeRecommender, Guid> _resumeRecommenderRepository;

        public ResumeRecommendersAppServiceTests()
        {
            _resumeRecommendersAppService = GetRequiredService<IResumeRecommendersAppService>();
            _resumeRecommenderRepository = GetRequiredService<IRepository<ResumeRecommender, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeRecommendersAppService.GetListAsync(new GetResumeRecommendersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e9c5fbc1-d435-4244-8d0c-afda706874d2")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeRecommendersAppService.GetAsync(Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeRecommenderCreateDto
            {
                ResumeMainId = Guid.Parse("3e733421-a5f9-46d4-9961-e359dfba4dac"),
                Name = "0244774a8c204a3d9429d131d5a762388db0311722314b38a1",
                CompanyName = "a29f11826b814176a14934e4853d70b7199244478fde4c8fad",
                JobName = "e9cb2738c04045a79205a06a3ccd9610fb931908d1bf40e7a0",
                MobilePhone = "322fb0a8e9604b67bc5e60028bf3dcdb0e42688f868f4b0382",
                OfficePhone = "0c0a4e954fc341f393c55b3ee566207064562c7b7a1c464997",
                Email = "e32d56dff8a14e0e97646a9869a2d67006eb6d4232244ac0b3997309582963239f84fdd65c71423287fc752455887da4e166b86d3ec04083a72717414409f367c32f5a80bc8c4e7cb0ad7781c18d511da67a07cce26e4edf8a2a9e653ede9b4c5d0e7259",
                ExtendedInformation = "89f9d498b41a43bca08d7f501b6e03190c0afaa541db488dbfdb1c360b4ff9f978c9bc2fafbc4a48b27e9d23ab2e62fca4fe28ea28c74ae3be112bcf5b3ab3ebacee752121234ae68992856aad081f2dabd0c464841843eaaa35464609cd7c436f96105a8bfb488a81a5e1c529eb8466df50138c0efb419a86640de5b4b7df565156ec24e10e496db0b2b95f1a6cf3143287abca83cd41a390b94f5e05574c5aeebad5c8c1074bb49967472d057e75f23d1eea9330da4d63a4d46df5a51d6a4a73a5f0edbe7b4a0397cbf32ef9c38980d3e29d9e21f341a1958264fd1f5f2a5d76ec7db940954b7783c83a3e1706246a81063b4819e94c88a3eb",
                DateA = new DateTime(2015, 3, 16),
                DateD = new DateTime(2011, 3, 1),
                Sort = 715808275,
                Note = "4657e6b7caab4060b2deabc694e589b0e410a76cfa304c198864430bfcc6d9549cf01f8661674e018506d60ff0e7252974a4971cd06046468e53174a3214d11e181c32efe79b42eda3ecd8628ee7424b26bbd04650c04568a3e57d0f5122989d01ca8d7b2ad5452197a6c05b8024fd28f33e0de3fbd84f2a95f76da9890010e98f5fc454c80a42ccbb095745ec82a7abb206f7bfe1b244dbb5857821afa340dc461bcd680daa431b8bf831671b2dbd263a32a2814be343caba4f95a96514f3f847384f22141e40ce8cae94156c911e8a914a6ee410c842d4aeb6da4bd666c7a59e98529a31ab40d0a93c663f03f4c65a9c9c726633eb41e0bfda",
                Status = "13224b561c844633ae1f12a8a28518f7e247855cde41475495"
            };

            // Act
            var serviceResult = await _resumeRecommendersAppService.CreateAsync(input);

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("3e733421-a5f9-46d4-9961-e359dfba4dac"));
            result.Name.ShouldBe("0244774a8c204a3d9429d131d5a762388db0311722314b38a1");
            result.CompanyName.ShouldBe("a29f11826b814176a14934e4853d70b7199244478fde4c8fad");
            result.JobName.ShouldBe("e9cb2738c04045a79205a06a3ccd9610fb931908d1bf40e7a0");
            result.MobilePhone.ShouldBe("322fb0a8e9604b67bc5e60028bf3dcdb0e42688f868f4b0382");
            result.OfficePhone.ShouldBe("0c0a4e954fc341f393c55b3ee566207064562c7b7a1c464997");
            result.Email.ShouldBe("e32d56dff8a14e0e97646a9869a2d67006eb6d4232244ac0b3997309582963239f84fdd65c71423287fc752455887da4e166b86d3ec04083a72717414409f367c32f5a80bc8c4e7cb0ad7781c18d511da67a07cce26e4edf8a2a9e653ede9b4c5d0e7259");
            result.ExtendedInformation.ShouldBe("89f9d498b41a43bca08d7f501b6e03190c0afaa541db488dbfdb1c360b4ff9f978c9bc2fafbc4a48b27e9d23ab2e62fca4fe28ea28c74ae3be112bcf5b3ab3ebacee752121234ae68992856aad081f2dabd0c464841843eaaa35464609cd7c436f96105a8bfb488a81a5e1c529eb8466df50138c0efb419a86640de5b4b7df565156ec24e10e496db0b2b95f1a6cf3143287abca83cd41a390b94f5e05574c5aeebad5c8c1074bb49967472d057e75f23d1eea9330da4d63a4d46df5a51d6a4a73a5f0edbe7b4a0397cbf32ef9c38980d3e29d9e21f341a1958264fd1f5f2a5d76ec7db940954b7783c83a3e1706246a81063b4819e94c88a3eb");
            result.DateA.ShouldBe(new DateTime(2015, 3, 16));
            result.DateD.ShouldBe(new DateTime(2011, 3, 1));
            result.Sort.ShouldBe(715808275);
            result.Note.ShouldBe("4657e6b7caab4060b2deabc694e589b0e410a76cfa304c198864430bfcc6d9549cf01f8661674e018506d60ff0e7252974a4971cd06046468e53174a3214d11e181c32efe79b42eda3ecd8628ee7424b26bbd04650c04568a3e57d0f5122989d01ca8d7b2ad5452197a6c05b8024fd28f33e0de3fbd84f2a95f76da9890010e98f5fc454c80a42ccbb095745ec82a7abb206f7bfe1b244dbb5857821afa340dc461bcd680daa431b8bf831671b2dbd263a32a2814be343caba4f95a96514f3f847384f22141e40ce8cae94156c911e8a914a6ee410c842d4aeb6da4bd666c7a59e98529a31ab40d0a93c663f03f4c65a9c9c726633eb41e0bfda");
            result.Status.ShouldBe("13224b561c844633ae1f12a8a28518f7e247855cde41475495");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeRecommenderUpdateDto()
            {
                ResumeMainId = Guid.Parse("1f2787a3-d05a-470a-a716-cb19b07adc25"),
                Name = "5ea51efd5e274da7b33bb77fec268c0ab74391cb341b4c689f",
                CompanyName = "e82a25f0ed70440183084f5db1a0d164e575559e70344400a6",
                JobName = "141a1177593a42b885fc1df04dc53f82b34592b7b019425cac",
                MobilePhone = "6d8182646806416ebbe2272c055888c7d740313c55a84967bd",
                OfficePhone = "a0f7f8048fdb429bac532acd16cee006dd20cc0afa3e4154b9",
                Email = "cfa0c165e1d24ee1ab884571f3eae91e4289151e8de44c6bbc96391c722e592765c8cf56adee464ea9fa3ace10995365935fbad204614f45b716f47d13578a1dc071dad9e478453fb09fa6006229bb9c018718e08d4f48b49a3f7141c1d3bbda77c01bb2",
                ExtendedInformation = "b560285878a54dc6a3fbf9b8118c2c2589aa31e6328b461eb9124ff073fc899d9cb998ad67b64515841bbaaa529bc0f86909a7e208d1474399b906547bbbc0ed90e90bc2bbbd44aa95c3b358ac4b22eb2c94702958024e999ac558086dc6331cf687ad21ee3940eb917a368038aaf7413ac65fc9e6594fcda03485ed612287cb047b3c21acdb483dae4b8cffbc50cb8de47927bb80b24901a9d6825a4312b5eac6b0190cf5dd424b83be7ffff8ae0856d71d48fb45f6479b83de1f51e2793f89313edfa36bc94443aace0135d21734c6ba79c554614145a3a9e47971956f5aa812b861aff83846568888e901014ae04d91e7ff512fdf4263b4e4",
                DateA = new DateTime(2014, 1, 23),
                DateD = new DateTime(2018, 10, 21),
                Sort = 969582267,
                Note = "d40a85aeb5cf41db8bb35ce7a018d212c6a8e328f5724498bfeac2d786085ddc616315246abd43f08c5f9e000d0a5ae5e9e0bda013544bf3858315ee4adb765a2b950372723a47e0ac4f4f9d079f43902d2f827ea1ac44f3aa5e1c1b819c0c8d127b59cba14340a4a5272cff5010ccdc5de6cc0382da405ebbb930fd6deeae629817600964ba4034ab070828304f263a3a7de15e03204d7ea8fa3513bae8a70933be393f29374c51ae5208e3d2524f2f189e8b02b112401497693e70395d7b52d03151200a924273b2c1c7c0dcf05278af5e5a74edd64edf8c20f3b905ce4ebe0b635ddc705f4263b982d9ad3607cd26899d01b92d8547a9a806",
                Status = "1bdb3ca54a7041c9936b716b46c5ae81d2f159e50bda4201b2"
            };

            // Act
            var serviceResult = await _resumeRecommendersAppService.UpdateAsync(Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"), input);

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("1f2787a3-d05a-470a-a716-cb19b07adc25"));
            result.Name.ShouldBe("5ea51efd5e274da7b33bb77fec268c0ab74391cb341b4c689f");
            result.CompanyName.ShouldBe("e82a25f0ed70440183084f5db1a0d164e575559e70344400a6");
            result.JobName.ShouldBe("141a1177593a42b885fc1df04dc53f82b34592b7b019425cac");
            result.MobilePhone.ShouldBe("6d8182646806416ebbe2272c055888c7d740313c55a84967bd");
            result.OfficePhone.ShouldBe("a0f7f8048fdb429bac532acd16cee006dd20cc0afa3e4154b9");
            result.Email.ShouldBe("cfa0c165e1d24ee1ab884571f3eae91e4289151e8de44c6bbc96391c722e592765c8cf56adee464ea9fa3ace10995365935fbad204614f45b716f47d13578a1dc071dad9e478453fb09fa6006229bb9c018718e08d4f48b49a3f7141c1d3bbda77c01bb2");
            result.ExtendedInformation.ShouldBe("b560285878a54dc6a3fbf9b8118c2c2589aa31e6328b461eb9124ff073fc899d9cb998ad67b64515841bbaaa529bc0f86909a7e208d1474399b906547bbbc0ed90e90bc2bbbd44aa95c3b358ac4b22eb2c94702958024e999ac558086dc6331cf687ad21ee3940eb917a368038aaf7413ac65fc9e6594fcda03485ed612287cb047b3c21acdb483dae4b8cffbc50cb8de47927bb80b24901a9d6825a4312b5eac6b0190cf5dd424b83be7ffff8ae0856d71d48fb45f6479b83de1f51e2793f89313edfa36bc94443aace0135d21734c6ba79c554614145a3a9e47971956f5aa812b861aff83846568888e901014ae04d91e7ff512fdf4263b4e4");
            result.DateA.ShouldBe(new DateTime(2014, 1, 23));
            result.DateD.ShouldBe(new DateTime(2018, 10, 21));
            result.Sort.ShouldBe(969582267);
            result.Note.ShouldBe("d40a85aeb5cf41db8bb35ce7a018d212c6a8e328f5724498bfeac2d786085ddc616315246abd43f08c5f9e000d0a5ae5e9e0bda013544bf3858315ee4adb765a2b950372723a47e0ac4f4f9d079f43902d2f827ea1ac44f3aa5e1c1b819c0c8d127b59cba14340a4a5272cff5010ccdc5de6cc0382da405ebbb930fd6deeae629817600964ba4034ab070828304f263a3a7de15e03204d7ea8fa3513bae8a70933be393f29374c51ae5208e3d2524f2f189e8b02b112401497693e70395d7b52d03151200a924273b2c1c7c0dcf05278af5e5a74edd64edf8c20f3b905ce4ebe0b635ddc705f4263b982d9ad3607cd26899d01b92d8547a9a806");
            result.Status.ShouldBe("1bdb3ca54a7041c9936b716b46c5ae81d2f159e50bda4201b2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeRecommendersAppService.DeleteAsync(Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"));

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"));

            result.ShouldBeNull();
        }
    }
}