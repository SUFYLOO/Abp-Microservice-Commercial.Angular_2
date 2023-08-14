using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPaysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPaysAppService _companyJobPaysAppService;
        private readonly IRepository<CompanyJobPay, Guid> _companyJobPayRepository;

        public CompanyJobPaysAppServiceTests()
        {
            _companyJobPaysAppService = GetRequiredService<ICompanyJobPaysAppService>();
            _companyJobPayRepository = GetRequiredService<IRepository<CompanyJobPay, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetListAsync(new GetCompanyJobPaysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9f1f48c6-4697-4bf9-8792-668370d2c4d5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetAsync(Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPayCreateDto
            {
                CompanyMainId = Guid.Parse("572f25b8-446b-44f7-8475-30a8685ebb3e"),
                CompanyJobId = Guid.Parse("0fda45b4-6d78-41d6-80d9-2f6b26800fa9"),
                JobPayTypeCode = "1200700b84cf4e98b414f375f9f50fa74c339399f1a74799a1",
                DateReal = new DateTime(2017, 2, 18),
                IsCancel = true,
                ExtendedInformation = "37a548b3a7f74319aa8a509daeeff4b464956bf1fb6346478e778c528ed2dbc1944b4f5b358b4e7d9e0daed5d7f70aa888a19ee5cf834a959d6a0d1e72ea3b90942cf26559e743cdb11bca273467718120007686f2484a318f57c85e0d396515587454d458904638be32150c363fd57bee91362f782e4f79a6ce9e90501d52b3a2a0d29ecd6645f3a655b6958e24165a2cb79f0936ed4e8d9c39d1ad0b94a5f300cf2235f49249f398b9892699c39bfd7577fb04bc5044cfba915ed315f63587f969f06190164026a4d9bdef2144cb6c4dd4938091ab4c2683ed0692916a8867637af913cb5c4e38aacf793ad2cf2fe17d82d636d21641588008",
                DateA = new DateTime(2007, 11, 10),
                DateD = new DateTime(2009, 10, 22),
                Sort = 1754188358,
                Note = "e9b2ca9b86524dcf9869cd764cf656c3be77657bad434f50b06d56c8f8e0c65c930696f5bf4e42e38a8729a7da74c9d8a4f8ab5f3d6a4c769fa46e8df7e074ff6c84ab9ee63d49a9bd716ffdd532e354b4f94f2eaa954d1baeefe3b31d15cd6208b022586a844b33aa46b6f88a9b59a018f1b09e720a4215ae449963684edae6ead4f75f39034200a00db61c334f789621f2280e290a4062848aa9730c0918622caab6b69de94b49bdf5bcbc8ba17c011a5e69073b7e4612a318f58500501d33b91b4049280048d88289d02430b57177ee98b2d593fc44d2b9ccdd28d2b9960870fefcdb346e45d6b9d96584652bda54d512aeeb87a047c9973b",
                Status = "bb540e4993a94873b35168fc9093e326f2240c89693d4b5d87"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("572f25b8-446b-44f7-8475-30a8685ebb3e"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0fda45b4-6d78-41d6-80d9-2f6b26800fa9"));
            result.JobPayTypeCode.ShouldBe("1200700b84cf4e98b414f375f9f50fa74c339399f1a74799a1");
            result.DateReal.ShouldBe(new DateTime(2017, 2, 18));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("37a548b3a7f74319aa8a509daeeff4b464956bf1fb6346478e778c528ed2dbc1944b4f5b358b4e7d9e0daed5d7f70aa888a19ee5cf834a959d6a0d1e72ea3b90942cf26559e743cdb11bca273467718120007686f2484a318f57c85e0d396515587454d458904638be32150c363fd57bee91362f782e4f79a6ce9e90501d52b3a2a0d29ecd6645f3a655b6958e24165a2cb79f0936ed4e8d9c39d1ad0b94a5f300cf2235f49249f398b9892699c39bfd7577fb04bc5044cfba915ed315f63587f969f06190164026a4d9bdef2144cb6c4dd4938091ab4c2683ed0692916a8867637af913cb5c4e38aacf793ad2cf2fe17d82d636d21641588008");
            result.DateA.ShouldBe(new DateTime(2007, 11, 10));
            result.DateD.ShouldBe(new DateTime(2009, 10, 22));
            result.Sort.ShouldBe(1754188358);
            result.Note.ShouldBe("e9b2ca9b86524dcf9869cd764cf656c3be77657bad434f50b06d56c8f8e0c65c930696f5bf4e42e38a8729a7da74c9d8a4f8ab5f3d6a4c769fa46e8df7e074ff6c84ab9ee63d49a9bd716ffdd532e354b4f94f2eaa954d1baeefe3b31d15cd6208b022586a844b33aa46b6f88a9b59a018f1b09e720a4215ae449963684edae6ead4f75f39034200a00db61c334f789621f2280e290a4062848aa9730c0918622caab6b69de94b49bdf5bcbc8ba17c011a5e69073b7e4612a318f58500501d33b91b4049280048d88289d02430b57177ee98b2d593fc44d2b9ccdd28d2b9960870fefcdb346e45d6b9d96584652bda54d512aeeb87a047c9973b");
            result.Status.ShouldBe("bb540e4993a94873b35168fc9093e326f2240c89693d4b5d87");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPayUpdateDto()
            {
                CompanyMainId = Guid.Parse("d857e7da-920b-4dfc-8222-e51de5823a52"),
                CompanyJobId = Guid.Parse("cff8f572-2e82-416f-a149-449f846b67b7"),
                JobPayTypeCode = "f8bbca55a3114aeb9de7626bf96b4d4f37bedfbee12940c59a",
                DateReal = new DateTime(2014, 6, 17),
                IsCancel = true,
                ExtendedInformation = "5f8b55b2477a43aebe73e3fed3464d9161fd6a9de95a460ab423a75087fa35d4657b4aae21484930bcc4c7cc69c162d25683fa473a37470780ef8ff9fb757eefa0d8747d02134a26ae4ff526bc1d2161a67945cbb856439285a9e1211875a16b49646bf9bbc04236a62d9aeb63f81eed16b90b61a92e4ec69263c04ef187d9f08a9a064553ec4d8892df93f0eaf4aa1c7244a4ee7aad4b6aa291fe1e0997df7c528ac36a272345459479146fe3147f7d98a7a8a39b404cedb6eb26e6fb64191405f8b8af102e434e9c155ffcc2fdd488fe4094b0dd8940bfaa2a9772464f20da13488e06e4d14f359df0c4c212647b18cc49fa0aed1c46ba884a",
                DateA = new DateTime(2019, 10, 8),
                DateD = new DateTime(2009, 7, 5),
                Sort = 1177665932,
                Note = "97efd6242d1a4db29613032fba46e1f8ded559a4848c49148d8d8caacb5136a575fd336e05f44afaaa923197fe4cf3cea26aca0828d144df83d53b8734dff6101b8953f39c8e4a13be58ada17e73108fa736df8ebc114d3a995e2fe0756b3faea37aa1a363714520a6216e77e6abfb71541649620e4c47098628f5912023bca37ff9b436ba6343a9bc6c29ab57f5bcc2ba66019b2f1d420090ac3927324cd389c561dc09ed304caaac43d11d29bb74791b2c19140fd04453a73ad79830fd643d72ad43c5f3bb490d99eb30eb882ea76d23a87eef3501490f9dfabb432d817e7543584280073e4019b94a35d85bdfe4907512a102d7fd45a09600",
                Status = "e9f33a0b15794e8b9140d65b7ff1cf07501c4b3b7130423a95"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.UpdateAsync(Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"), input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("d857e7da-920b-4dfc-8222-e51de5823a52"));
            result.CompanyJobId.ShouldBe(Guid.Parse("cff8f572-2e82-416f-a149-449f846b67b7"));
            result.JobPayTypeCode.ShouldBe("f8bbca55a3114aeb9de7626bf96b4d4f37bedfbee12940c59a");
            result.DateReal.ShouldBe(new DateTime(2014, 6, 17));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("5f8b55b2477a43aebe73e3fed3464d9161fd6a9de95a460ab423a75087fa35d4657b4aae21484930bcc4c7cc69c162d25683fa473a37470780ef8ff9fb757eefa0d8747d02134a26ae4ff526bc1d2161a67945cbb856439285a9e1211875a16b49646bf9bbc04236a62d9aeb63f81eed16b90b61a92e4ec69263c04ef187d9f08a9a064553ec4d8892df93f0eaf4aa1c7244a4ee7aad4b6aa291fe1e0997df7c528ac36a272345459479146fe3147f7d98a7a8a39b404cedb6eb26e6fb64191405f8b8af102e434e9c155ffcc2fdd488fe4094b0dd8940bfaa2a9772464f20da13488e06e4d14f359df0c4c212647b18cc49fa0aed1c46ba884a");
            result.DateA.ShouldBe(new DateTime(2019, 10, 8));
            result.DateD.ShouldBe(new DateTime(2009, 7, 5));
            result.Sort.ShouldBe(1177665932);
            result.Note.ShouldBe("97efd6242d1a4db29613032fba46e1f8ded559a4848c49148d8d8caacb5136a575fd336e05f44afaaa923197fe4cf3cea26aca0828d144df83d53b8734dff6101b8953f39c8e4a13be58ada17e73108fa736df8ebc114d3a995e2fe0756b3faea37aa1a363714520a6216e77e6abfb71541649620e4c47098628f5912023bca37ff9b436ba6343a9bc6c29ab57f5bcc2ba66019b2f1d420090ac3927324cd389c561dc09ed304caaac43d11d29bb74791b2c19140fd04453a73ad79830fd643d72ad43c5f3bb490d99eb30eb882ea76d23a87eef3501490f9dfabb432d817e7543584280073e4019b94a35d85bdfe4907512a102d7fd45a09600");
            result.Status.ShouldBe("e9f33a0b15794e8b9140d65b7ff1cf07501c4b3b7130423a95");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPaysAppService.DeleteAsync(Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"));

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"));

            result.ShouldBeNull();
        }
    }
}