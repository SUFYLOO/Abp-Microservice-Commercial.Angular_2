using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicensesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeDrvingLicensesAppService _resumeDrvingLicensesAppService;
        private readonly IRepository<ResumeDrvingLicense, Guid> _resumeDrvingLicenseRepository;

        public ResumeDrvingLicensesAppServiceTests()
        {
            _resumeDrvingLicensesAppService = GetRequiredService<IResumeDrvingLicensesAppService>();
            _resumeDrvingLicenseRepository = GetRequiredService<IRepository<ResumeDrvingLicense, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeDrvingLicensesAppService.GetListAsync(new GetResumeDrvingLicensesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("75e33aeb-20ef-4435-b703-6c17a668d296")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeDrvingLicensesAppService.GetAsync(Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeDrvingLicenseCreateDto
            {
                ResumeMainId = Guid.Parse("646249fa-666c-4b1c-b133-9ad7671f50b4"),
                DrvingLicenseCode = "b5f723a607df4c1aa54799f75dac9076ffcec402fd914cf397",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "647f633e590a478391ab04f5726036c839a0f7b709134f569a0208f3cf0baa9f3a9fa4ecaf364abebeb8da2b4586fcf7927ed691a61d4677bcd679f1b737acacbf52440728224529bc1a7bbafabd7c9af9f3919fbb1549f7b19185a16206fdfd3b4ef0d0f29544beb13b573c470887e0d6d1350e9f05423a85e5e3997e13e7b540b30d4bf92046a9888042aea272e0267d29932990b2449a9ed3bf04bf8dbbaf02125061629a459fbb08694a34e0722be5368fb6709d461d994019c1853285c88c657f55d399445ea44776c40ef32238f51700d5a9bb4a658470e6ce8a65184e6aa61ee89f204358a79d4e9bb1bf94479588e4305c584f0ab968",
                DateA = new DateTime(2014, 8, 19),
                DateD = new DateTime(2003, 7, 22),
                Sort = 196532525,
                Note = "4353a715ada34c77b4b23363a69857ab050fb8d2432f44688a3939126818c48c59a62cf6db73424e91798a42888df553a2815f04d86947e48b63a0d99d1647654d9bc588fe0c46a8853c3efa2945cb1916f9dd30f2b34288a287e86a318ed5c9aa80de70fa3e459db807c23d477852fa757cd1a4a1064c6db983d3b41a3af07d036591ce004c47b09a8aff19dfd6b6d74a5909601545466f971ff8587768405121a6f88ac59247ce86f87ff8bfbcfc69ae8e2d920609496eb2c6a714981217fe3e4f91d2ede04f12929df080098fcc8cb1c3fa59f1524b049b3ec787a4841b9cc97eeba88f954d8f959f586937447e839cb00c6796464f65939a",
                Status = "5adba3387f5547e8a2ce7b0d1694beda28925f04ce8e4d3694"
            };

            // Act
            var serviceResult = await _resumeDrvingLicensesAppService.CreateAsync(input);

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("646249fa-666c-4b1c-b133-9ad7671f50b4"));
            result.DrvingLicenseCode.ShouldBe("b5f723a607df4c1aa54799f75dac9076ffcec402fd914cf397");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("647f633e590a478391ab04f5726036c839a0f7b709134f569a0208f3cf0baa9f3a9fa4ecaf364abebeb8da2b4586fcf7927ed691a61d4677bcd679f1b737acacbf52440728224529bc1a7bbafabd7c9af9f3919fbb1549f7b19185a16206fdfd3b4ef0d0f29544beb13b573c470887e0d6d1350e9f05423a85e5e3997e13e7b540b30d4bf92046a9888042aea272e0267d29932990b2449a9ed3bf04bf8dbbaf02125061629a459fbb08694a34e0722be5368fb6709d461d994019c1853285c88c657f55d399445ea44776c40ef32238f51700d5a9bb4a658470e6ce8a65184e6aa61ee89f204358a79d4e9bb1bf94479588e4305c584f0ab968");
            result.DateA.ShouldBe(new DateTime(2014, 8, 19));
            result.DateD.ShouldBe(new DateTime(2003, 7, 22));
            result.Sort.ShouldBe(196532525);
            result.Note.ShouldBe("4353a715ada34c77b4b23363a69857ab050fb8d2432f44688a3939126818c48c59a62cf6db73424e91798a42888df553a2815f04d86947e48b63a0d99d1647654d9bc588fe0c46a8853c3efa2945cb1916f9dd30f2b34288a287e86a318ed5c9aa80de70fa3e459db807c23d477852fa757cd1a4a1064c6db983d3b41a3af07d036591ce004c47b09a8aff19dfd6b6d74a5909601545466f971ff8587768405121a6f88ac59247ce86f87ff8bfbcfc69ae8e2d920609496eb2c6a714981217fe3e4f91d2ede04f12929df080098fcc8cb1c3fa59f1524b049b3ec787a4841b9cc97eeba88f954d8f959f586937447e839cb00c6796464f65939a");
            result.Status.ShouldBe("5adba3387f5547e8a2ce7b0d1694beda28925f04ce8e4d3694");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeDrvingLicenseUpdateDto()
            {
                ResumeMainId = Guid.Parse("465e8309-1b19-497f-8d70-0d6f2a3e1afb"),
                DrvingLicenseCode = "2a50590b3cbd47ffbe357197f64b55d2f313abc93a254018bb",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "7c85adc9d6cd4289b5651eb65c01992a9106565718ad4de4b1b37897efe1abe8d8052f738d5b4c32ae70e45b09b6598ba60846de70814e54b615d4d499792f2512c820ba601c413daccc8db82bc2704cbd18df9102724d09affd9ff3b75db7956887e1d863114a7fbf8cea89201123920e96c11ae130467a8f50be955a95f8aa14fed2612795479397d797c5dd888442796adffd24944e7c9d42832626d78bfdc0c7e0ae118e45508c9151f10247e3a17c0b4d4d588347f7adf8f06af3fa6cf5cf97cd69f6044dc286d7e43d6aa453eebda929a5ea644f1b8879a981af3bde64b4470a0c94904bce824046460c40df3d7d7668bad06d497a8f06",
                DateA = new DateTime(2001, 1, 19),
                DateD = new DateTime(2010, 5, 9),
                Sort = 1676643496,
                Note = "8778448c09ec47fb9f367ac05fa2a2e8ff06daff93a148e4a5301b61fcca73bda0472b43ca984aec98787f690687600f0938043f97dc4b348d2b016c48ffe72ee3330ae573174e43b1c7d47e7f9bd84897819b79998b4366ac7b6fedfab9cff8eec06164b10147af8a5e4a1d6a18635f4150264914774ea7bc10b0103e53df73bd143a417dce4af4bc4de51e98a286f22926e99f7135470bb53da4eedd002d01e13430634c2f4c1691b0c25cbbfe11900065c3313f5e444c8c2b042722c005c0d8862409186d43d0ab0a571138a0edd972f5d2156f3146338716d4ddfad04e2d6ef9c62bfa9a477998684ab769d968e281e0ff515c984c1f971a",
                Status = "ef9487bde3f746458fe14f3ae2f663c3e05c5b530c8e4400a7"
            };

            // Act
            var serviceResult = await _resumeDrvingLicensesAppService.UpdateAsync(Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"), input);

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("465e8309-1b19-497f-8d70-0d6f2a3e1afb"));
            result.DrvingLicenseCode.ShouldBe("2a50590b3cbd47ffbe357197f64b55d2f313abc93a254018bb");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("7c85adc9d6cd4289b5651eb65c01992a9106565718ad4de4b1b37897efe1abe8d8052f738d5b4c32ae70e45b09b6598ba60846de70814e54b615d4d499792f2512c820ba601c413daccc8db82bc2704cbd18df9102724d09affd9ff3b75db7956887e1d863114a7fbf8cea89201123920e96c11ae130467a8f50be955a95f8aa14fed2612795479397d797c5dd888442796adffd24944e7c9d42832626d78bfdc0c7e0ae118e45508c9151f10247e3a17c0b4d4d588347f7adf8f06af3fa6cf5cf97cd69f6044dc286d7e43d6aa453eebda929a5ea644f1b8879a981af3bde64b4470a0c94904bce824046460c40df3d7d7668bad06d497a8f06");
            result.DateA.ShouldBe(new DateTime(2001, 1, 19));
            result.DateD.ShouldBe(new DateTime(2010, 5, 9));
            result.Sort.ShouldBe(1676643496);
            result.Note.ShouldBe("8778448c09ec47fb9f367ac05fa2a2e8ff06daff93a148e4a5301b61fcca73bda0472b43ca984aec98787f690687600f0938043f97dc4b348d2b016c48ffe72ee3330ae573174e43b1c7d47e7f9bd84897819b79998b4366ac7b6fedfab9cff8eec06164b10147af8a5e4a1d6a18635f4150264914774ea7bc10b0103e53df73bd143a417dce4af4bc4de51e98a286f22926e99f7135470bb53da4eedd002d01e13430634c2f4c1691b0c25cbbfe11900065c3313f5e444c8c2b042722c005c0d8862409186d43d0ab0a571138a0edd972f5d2156f3146338716d4ddfad04e2d6ef9c62bfa9a477998684ab769d968e281e0ff515c984c1f971a");
            result.Status.ShouldBe("ef9487bde3f746458fe14f3ae2f663c3e05c5b530c8e4400a7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeDrvingLicensesAppService.DeleteAsync(Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"));

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"));

            result.ShouldBeNull();
        }
    }
}