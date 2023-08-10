using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyPointss
{
    public class CompanyPointssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyPointssAppService _companyPointssAppService;
        private readonly IRepository<CompanyPoints, Guid> _companyPointsRepository;

        public CompanyPointssAppServiceTests()
        {
            _companyPointssAppService = GetRequiredService<ICompanyPointssAppService>();
            _companyPointsRepository = GetRequiredService<IRepository<CompanyPoints, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyPointssAppService.GetListAsync(new GetCompanyPointssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e8a1bcdc-7775-4515-bd66-930426401efc")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyPointssAppService.GetAsync(Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyPointsCreateDto
            {
                CompanyMainId = Guid.Parse("02cec1e5-24d3-42fa-90b0-3cf30c539e62"),
                CompanyPointsTypeCode = "a75f225f62d9479893b3cd8be03b14625d7428e420294f1a96",
                Points = 1705483409,
                ExtendedInformation = "5276587307c34fcc845a95af663635d9a56cccc5eccd4933bca58db55966790d6d895c222c2843078c0d523743d275470581ff2fee9c482db75733b563f15c2445b349d0f1b644b3bed0c715b20481e2154ff255f2fc4480959a91b417ab7d7b7ce9bde0556c4d16814093df302372666f6ba4f4ca694f3083250af961cf32b17ee1ddab7bb345ef915c35a7bd8b524d030ba5fb39ec4ffe9f897d08f5a756324fd7a041e94042f39628f9ac69dce987e6786f0960214b1e8a2aae849c26357924f1ad702821465ea6ff4bef4e56fe1ab733487404a04fa5b55c2f5ff3949ec442bbabb7363b4137bf926e037129c31988adb6688a8448a1a0e2",
                DateA = new DateTime(2007, 1, 19),
                DateD = new DateTime(2010, 11, 5),
                Sort = 1124638610,
                Note = "051ba3aecbd84c52a31063e319d5fcf42cbc20857b5c4726afe916faf49ae89a4d9b3657823345f8a99ad4d4785a61f4f56c1d78a53341a882a2c5b54cc77776acbc8072f99141819d9f1df878abbc66d17faac9be6147e9877799bbcbd27782296143eb0e7444b799ab7585bfdb120342c2827c73f546f29caa2779faa06bf3e9c07feaf38b4816b063390d91ea8b66ec6daab73f1949ed8432b5a1c484c8d759c0d6c532364b959f9a203a9025e36160b39e6be6ac496294e1e384f8d72ce40eace1ee64154601a9fec04d07f40b8206540cb6fd904282993b216ad09404a4108db6ad3a3948ce97dafa3ed4de7855425a7354f0e546288d78",
                Status = "b63fd83637ac4a2a8e3793e9425915816a4810014350427aa7"
            };

            // Act
            var serviceResult = await _companyPointssAppService.CreateAsync(input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("02cec1e5-24d3-42fa-90b0-3cf30c539e62"));
            result.CompanyPointsTypeCode.ShouldBe("a75f225f62d9479893b3cd8be03b14625d7428e420294f1a96");
            result.Points.ShouldBe(1705483409);
            result.ExtendedInformation.ShouldBe("5276587307c34fcc845a95af663635d9a56cccc5eccd4933bca58db55966790d6d895c222c2843078c0d523743d275470581ff2fee9c482db75733b563f15c2445b349d0f1b644b3bed0c715b20481e2154ff255f2fc4480959a91b417ab7d7b7ce9bde0556c4d16814093df302372666f6ba4f4ca694f3083250af961cf32b17ee1ddab7bb345ef915c35a7bd8b524d030ba5fb39ec4ffe9f897d08f5a756324fd7a041e94042f39628f9ac69dce987e6786f0960214b1e8a2aae849c26357924f1ad702821465ea6ff4bef4e56fe1ab733487404a04fa5b55c2f5ff3949ec442bbabb7363b4137bf926e037129c31988adb6688a8448a1a0e2");
            result.DateA.ShouldBe(new DateTime(2007, 1, 19));
            result.DateD.ShouldBe(new DateTime(2010, 11, 5));
            result.Sort.ShouldBe(1124638610);
            result.Note.ShouldBe("051ba3aecbd84c52a31063e319d5fcf42cbc20857b5c4726afe916faf49ae89a4d9b3657823345f8a99ad4d4785a61f4f56c1d78a53341a882a2c5b54cc77776acbc8072f99141819d9f1df878abbc66d17faac9be6147e9877799bbcbd27782296143eb0e7444b799ab7585bfdb120342c2827c73f546f29caa2779faa06bf3e9c07feaf38b4816b063390d91ea8b66ec6daab73f1949ed8432b5a1c484c8d759c0d6c532364b959f9a203a9025e36160b39e6be6ac496294e1e384f8d72ce40eace1ee64154601a9fec04d07f40b8206540cb6fd904282993b216ad09404a4108db6ad3a3948ce97dafa3ed4de7855425a7354f0e546288d78");
            result.Status.ShouldBe("b63fd83637ac4a2a8e3793e9425915816a4810014350427aa7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyPointsUpdateDto()
            {
                CompanyMainId = Guid.Parse("92f95288-73ba-40af-8562-46c1c53f6aea"),
                CompanyPointsTypeCode = "d248d2a63ed546609a0ce5c6e37df7f88f88332446fd4289ab",
                Points = 574596576,
                ExtendedInformation = "3523b63f8f7e47a3b55549f9ffa29ce73af20598b5594450b657a2846380749f5ee594370986423fb7624150ee1faf7d96880e6376ff437ab97d1e4f6ac074ab8d33feea77724772845790310685e21571d60f8050e5458f939b730e85ee79905c2773d5639945fc984181a7642df2989e339121184f476fb8a619328307b5d46e0557ee015546858198523a019e5b43f67ae3ec001249deb5e61553db9f04e0f5c3aa494ce04f2783b2b94d2ff14828ead1047396f2444c9750928ef28a44ba4879419e425d4718a75d5cfa8b2539878c3629589d984843881c1fb2d94a8155c0688db93b5c401d8389d2b3ac70e179301b97658b614250b49c",
                DateA = new DateTime(2017, 11, 12),
                DateD = new DateTime(2017, 2, 23),
                Sort = 921541059,
                Note = "4a9ae5b8669e442d97c005a000885b9bed45f536fd974115b82b35dbc7d67b186174666be20c49c68e8de9e6b249a6ffc9c547e8b9d443d7854472b20af9a3c19e89e11454ee4eb0957f5384a0d44f5e2df731e485bc4e88b1317e48aeb49d819523c6d112d846c9ae86d50858627a708b1398c86d3841a297b534f6fdac42da244c26afcb6e4a9cb0525d281a6caf1c761e6cccd6724f3bafaa36ac7180a5a41c34be4b83eb4db7875be9ebb1004c61b86c5fb3f22446da91a144fd607432b62b1e23c2568142c5968f9fbfbccd97b9184d881d23b0439098cbf1c20435524dc4861a2d80d44b9da2d6a079f56027ad3c4b88bcb6b945309703",
                Status = "e26998b573514844b0bb006dcd5b01e8cb09846801a14f6fb1"
            };

            // Act
            var serviceResult = await _companyPointssAppService.UpdateAsync(Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"), input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("92f95288-73ba-40af-8562-46c1c53f6aea"));
            result.CompanyPointsTypeCode.ShouldBe("d248d2a63ed546609a0ce5c6e37df7f88f88332446fd4289ab");
            result.Points.ShouldBe(574596576);
            result.ExtendedInformation.ShouldBe("3523b63f8f7e47a3b55549f9ffa29ce73af20598b5594450b657a2846380749f5ee594370986423fb7624150ee1faf7d96880e6376ff437ab97d1e4f6ac074ab8d33feea77724772845790310685e21571d60f8050e5458f939b730e85ee79905c2773d5639945fc984181a7642df2989e339121184f476fb8a619328307b5d46e0557ee015546858198523a019e5b43f67ae3ec001249deb5e61553db9f04e0f5c3aa494ce04f2783b2b94d2ff14828ead1047396f2444c9750928ef28a44ba4879419e425d4718a75d5cfa8b2539878c3629589d984843881c1fb2d94a8155c0688db93b5c401d8389d2b3ac70e179301b97658b614250b49c");
            result.DateA.ShouldBe(new DateTime(2017, 11, 12));
            result.DateD.ShouldBe(new DateTime(2017, 2, 23));
            result.Sort.ShouldBe(921541059);
            result.Note.ShouldBe("4a9ae5b8669e442d97c005a000885b9bed45f536fd974115b82b35dbc7d67b186174666be20c49c68e8de9e6b249a6ffc9c547e8b9d443d7854472b20af9a3c19e89e11454ee4eb0957f5384a0d44f5e2df731e485bc4e88b1317e48aeb49d819523c6d112d846c9ae86d50858627a708b1398c86d3841a297b534f6fdac42da244c26afcb6e4a9cb0525d281a6caf1c761e6cccd6724f3bafaa36ac7180a5a41c34be4b83eb4db7875be9ebb1004c61b86c5fb3f22446da91a144fd607432b62b1e23c2568142c5968f9fbfbccd97b9184d881d23b0439098cbf1c20435524dc4861a2d80d44b9da2d6a079f56027ad3c4b88bcb6b945309703");
            result.Status.ShouldBe("e26998b573514844b0bb006dcd5b01e8cb09846801a14f6fb1");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyPointssAppService.DeleteAsync(Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"));

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"));

            result.ShouldBeNull();
        }
    }
}