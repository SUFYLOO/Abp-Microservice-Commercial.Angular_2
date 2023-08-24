using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobEducationLevelsAppService _companyJobEducationLevelsAppService;
        private readonly IRepository<CompanyJobEducationLevel, Guid> _companyJobEducationLevelRepository;

        public CompanyJobEducationLevelsAppServiceTests()
        {
            _companyJobEducationLevelsAppService = GetRequiredService<ICompanyJobEducationLevelsAppService>();
            _companyJobEducationLevelRepository = GetRequiredService<IRepository<CompanyJobEducationLevel, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobEducationLevelsAppService.GetListAsync(new GetCompanyJobEducationLevelsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("a1fddccf-defb-4419-b7ad-759cfc295833")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobEducationLevelsAppService.GetAsync(Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobEducationLevelCreateDto
            {
                CompanyMainId = Guid.Parse("c9cff1bf-8e2b-46cd-80c5-6e92cd66b147"),
                CompanyJobId = Guid.Parse("8ed4ca4c-9e7a-4680-ba24-d157eb1f0a18"),
                EducationLevelCode = "02d5deafcdd044d1958f591710f217312d49ad4f861b436bb4",
                ExtendedInformation = "2d6af53c68324345ac5b80c35e90f5b393bfd7708de340c5881fc88541162bec00bfa8ce239841438689162b431e7715d16e929404674042aaf90150f3c4536ca770af497e954725b31cf18d2c98122956cc53b5027e45689dc00f278df99ed9d33b5ceac0ce4b87b0571eec617b0cf02bb8ea088b074030b2244c728877896ebed2dcd847be43eb979596a279c87583cd235f4d42c14ffab00e89c53d4f3304831c9b5d4681426ebfb16dcb0385cfe6aa00d9d494984be8ab5739d25df1480b24f10a51ea994e659d4591f4a6f376f9ff7a037495d446ca82e3dc3ecd800b5071dc0c141627482a867c84e0126cee2b9bf03337716f4c4ba41c",
                DateA = new DateTime(2019, 4, 10),
                DateD = new DateTime(2022, 7, 19),
                Sort = 452604039,
                Note = "ee9478a7376646858957023b5137e9650eb00b99e1214ba598e4701e37a2ce682c0b79d4b2c84b15a8754f185f0be2c105731edcc21440deb529085ee8c52b509bceba6326814d6088f048a0fffabae8acbe95f2ac904ddfaca35ced19a57572edb417cf37c64ec887ef125bf4ade25726b734340e274b4397d409f98191c1e880a268f77c9f4337a7003b58553757ff412d4bf99f394a29b77cc793cab9a48dc1a4e464d7674a0fbd8095c98d33a2bce72495b39dfc412a9992a86eec8134d55ac867d7fca54629bd6a335bdde3b812c24333e11c724f99979a19d13287402d33b6d326d2ed4f5d8484bf3bfebc5421b5afd6602f4a4bd6b98e",
                Status = "e2578e45156549e5a26d83a4c7ebb409c412d50ff3984d5a93"
            };

            // Act
            var serviceResult = await _companyJobEducationLevelsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c9cff1bf-8e2b-46cd-80c5-6e92cd66b147"));
            result.CompanyJobId.ShouldBe(Guid.Parse("8ed4ca4c-9e7a-4680-ba24-d157eb1f0a18"));
            result.EducationLevelCode.ShouldBe("02d5deafcdd044d1958f591710f217312d49ad4f861b436bb4");
            result.ExtendedInformation.ShouldBe("2d6af53c68324345ac5b80c35e90f5b393bfd7708de340c5881fc88541162bec00bfa8ce239841438689162b431e7715d16e929404674042aaf90150f3c4536ca770af497e954725b31cf18d2c98122956cc53b5027e45689dc00f278df99ed9d33b5ceac0ce4b87b0571eec617b0cf02bb8ea088b074030b2244c728877896ebed2dcd847be43eb979596a279c87583cd235f4d42c14ffab00e89c53d4f3304831c9b5d4681426ebfb16dcb0385cfe6aa00d9d494984be8ab5739d25df1480b24f10a51ea994e659d4591f4a6f376f9ff7a037495d446ca82e3dc3ecd800b5071dc0c141627482a867c84e0126cee2b9bf03337716f4c4ba41c");
            result.DateA.ShouldBe(new DateTime(2019, 4, 10));
            result.DateD.ShouldBe(new DateTime(2022, 7, 19));
            result.Sort.ShouldBe(452604039);
            result.Note.ShouldBe("ee9478a7376646858957023b5137e9650eb00b99e1214ba598e4701e37a2ce682c0b79d4b2c84b15a8754f185f0be2c105731edcc21440deb529085ee8c52b509bceba6326814d6088f048a0fffabae8acbe95f2ac904ddfaca35ced19a57572edb417cf37c64ec887ef125bf4ade25726b734340e274b4397d409f98191c1e880a268f77c9f4337a7003b58553757ff412d4bf99f394a29b77cc793cab9a48dc1a4e464d7674a0fbd8095c98d33a2bce72495b39dfc412a9992a86eec8134d55ac867d7fca54629bd6a335bdde3b812c24333e11c724f99979a19d13287402d33b6d326d2ed4f5d8484bf3bfebc5421b5afd6602f4a4bd6b98e");
            result.Status.ShouldBe("e2578e45156549e5a26d83a4c7ebb409c412d50ff3984d5a93");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobEducationLevelUpdateDto()
            {
                CompanyMainId = Guid.Parse("ca3b2d6b-e554-427e-b717-a9256dd80d65"),
                CompanyJobId = Guid.Parse("013cba84-6ba1-4e0a-a8c1-8b95a30ec669"),
                EducationLevelCode = "3ee637a8ff5e40bb8f6711ce50170c72d3646d88b37f4b53a4",
                ExtendedInformation = "45693bd557a74a659ccc834ee0c7a64e392ce7ea3dfd4767a961084cbb87a448a903345ba6844009b024a7f333a8a477cb357cf2dc974554879538fe1141e25756ecbc28d39549c5a2098dd09494664e802f6a91e42f4728b68d6fcc8427ebda8f4a28d8e253400390cd2e6c47dd1efdf788e4cff05048a2becfbbb42fae34572472d67465e4457ba60d2498ebb47a07327f970afbd348f8a0d6dd351945fb25e0bef315bb2043dc80dafe05adf09d68cb828b09d7534a45a91cd3f5123092ff13bb251fd8c24b4dad8227e0c56e7b479ad193f0113a441da5a50665f3e431bfa2f3b6cc002d444886bf9f91b47e880a106dbc1e3f584ad58fc1",
                DateA = new DateTime(2009, 2, 9),
                DateD = new DateTime(2003, 2, 12),
                Sort = 742058304,
                Note = "f5c5b39e4f884ca4a82f18274aa015cec1cb557b3b074cd68b315e0d3429d5c7a948ba00b7bb43d79451119e2de82dc824587a709c2f46f181312ea1b8bacddcb830488a2e9a4d99b4ee71ecf3dfc57e82261970ea2f43aa98d75bed422d14ea37af152dd6dd403b885ce7b03d01819d405ff49ec65049429e79a48e1d610ceece22f543a5804ec9a7f62d281cffb1aa730452e1541f494fa24fa0832987ef27f317afd8f4cd4b59aa4583f239908fb867cfa151768a442a9dbfac1787c679754c0ed8ca82d143d380b0614087b8d3e2d8e21cd5788e496db9c6a3ca902b0dfd277999d425364ac294a19a473934a641476a057305ad416e874d",
                Status = "92518eb829bf46ceae777aa316816a4c15c4d96f31b04af4be"
            };

            // Act
            var serviceResult = await _companyJobEducationLevelsAppService.UpdateAsync(Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"), input);

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("ca3b2d6b-e554-427e-b717-a9256dd80d65"));
            result.CompanyJobId.ShouldBe(Guid.Parse("013cba84-6ba1-4e0a-a8c1-8b95a30ec669"));
            result.EducationLevelCode.ShouldBe("3ee637a8ff5e40bb8f6711ce50170c72d3646d88b37f4b53a4");
            result.ExtendedInformation.ShouldBe("45693bd557a74a659ccc834ee0c7a64e392ce7ea3dfd4767a961084cbb87a448a903345ba6844009b024a7f333a8a477cb357cf2dc974554879538fe1141e25756ecbc28d39549c5a2098dd09494664e802f6a91e42f4728b68d6fcc8427ebda8f4a28d8e253400390cd2e6c47dd1efdf788e4cff05048a2becfbbb42fae34572472d67465e4457ba60d2498ebb47a07327f970afbd348f8a0d6dd351945fb25e0bef315bb2043dc80dafe05adf09d68cb828b09d7534a45a91cd3f5123092ff13bb251fd8c24b4dad8227e0c56e7b479ad193f0113a441da5a50665f3e431bfa2f3b6cc002d444886bf9f91b47e880a106dbc1e3f584ad58fc1");
            result.DateA.ShouldBe(new DateTime(2009, 2, 9));
            result.DateD.ShouldBe(new DateTime(2003, 2, 12));
            result.Sort.ShouldBe(742058304);
            result.Note.ShouldBe("f5c5b39e4f884ca4a82f18274aa015cec1cb557b3b074cd68b315e0d3429d5c7a948ba00b7bb43d79451119e2de82dc824587a709c2f46f181312ea1b8bacddcb830488a2e9a4d99b4ee71ecf3dfc57e82261970ea2f43aa98d75bed422d14ea37af152dd6dd403b885ce7b03d01819d405ff49ec65049429e79a48e1d610ceece22f543a5804ec9a7f62d281cffb1aa730452e1541f494fa24fa0832987ef27f317afd8f4cd4b59aa4583f239908fb867cfa151768a442a9dbfac1787c679754c0ed8ca82d143d380b0614087b8d3e2d8e21cd5788e496db9c6a3ca902b0dfd277999d425364ac294a19a473934a641476a057305ad416e874d");
            result.Status.ShouldBe("92518eb829bf46ceae777aa316816a4c15c4d96f31b04af4be");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobEducationLevelsAppService.DeleteAsync(Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"));

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"));

            result.ShouldBeNull();
        }
    }
}