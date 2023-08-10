using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobFavsAppService _userCompanyJobFavsAppService;
        private readonly IRepository<UserCompanyJobFav, Guid> _userCompanyJobFavRepository;

        public UserCompanyJobFavsAppServiceTests()
        {
            _userCompanyJobFavsAppService = GetRequiredService<IUserCompanyJobFavsAppService>();
            _userCompanyJobFavRepository = GetRequiredService<IRepository<UserCompanyJobFav, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobFavsAppService.GetListAsync(new GetUserCompanyJobFavsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("bdcc6eba-cd62-49d4-9edd-afa20c82a48d")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobFavsAppService.GetAsync(Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavCreateDto
            {
                UserMainId = Guid.Parse("3b88e88c-06d1-4f29-9d6c-fdbbbe8e0f74"),
                CompanyJobId = Guid.Parse("e7fdb5b4-6817-46ac-a42f-e7927a28c1e4"),
                ExtendedInformation = "32bb2b3f4c4f46dbb52df4403ebc664b159b445be02f469195b25df1399b10ab122b5bf778c54838870d5ef5fb614bb1d79d0b5eed3245fb8e311abf5e620c269c44df97a85945c6a4450538164f3dc11662815966514b3694e1432f935e65ca093b956a4ccd4d7db1960a944a1e033971f82cdc302d482293356932140ff55a0943981fafe24f25a04d3dc8f1aec03ea1eb160e0987429aa6dc12dab5f1287cf7ccdbe518ab43029ff37e99a68cacf6835312e9ad4e4d798c58233de814ce8a7bffa90963234975992abefe422c4c979595a6649ba444538a56f19a30f067f8a92897ae9d784325aa3b0881969994a5e985d262a1654e82bede",
                DateA = new DateTime(2004, 3, 8),
                DateD = new DateTime(2002, 3, 27),
                Sort = 169252874,
                Note = "920a320b4364498e8e2deee726f67b49e38531c61f4243e9a1d544387004f98c9668d194b8cb413cbe8d62124bb5fc9d86b8bd5025294d089d79ca45aa862625a798f806ebbf43e294b877a001c495ffe8c5c2669974452bb3f39f877b0de64b5af5697fa0b34f3f9b4be02ba86a4b4d1c1602004f7144c59f062d5516ecd2d5d04cd193b3f14ab98f48bd67ddf02dceef9d913514b64a71a9e7a7268af7ea6ddeb853fa62584d29b50fc259e022baa7866b1f4a78724ee6825acfb6c3716259a64c7f3809204d6c9082727e1f98b4581bef497d1cfb4889af05f7265cb4ad5ee80d768c516244359afa68c1d063e975bf1876b16dc348829c3c",
                Status = "ac0d2e66263e4e8b9260e34b87d1282d1d2ff8be9c22436884"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("3b88e88c-06d1-4f29-9d6c-fdbbbe8e0f74"));
            result.CompanyJobId.ShouldBe(Guid.Parse("e7fdb5b4-6817-46ac-a42f-e7927a28c1e4"));
            result.ExtendedInformation.ShouldBe("32bb2b3f4c4f46dbb52df4403ebc664b159b445be02f469195b25df1399b10ab122b5bf778c54838870d5ef5fb614bb1d79d0b5eed3245fb8e311abf5e620c269c44df97a85945c6a4450538164f3dc11662815966514b3694e1432f935e65ca093b956a4ccd4d7db1960a944a1e033971f82cdc302d482293356932140ff55a0943981fafe24f25a04d3dc8f1aec03ea1eb160e0987429aa6dc12dab5f1287cf7ccdbe518ab43029ff37e99a68cacf6835312e9ad4e4d798c58233de814ce8a7bffa90963234975992abefe422c4c979595a6649ba444538a56f19a30f067f8a92897ae9d784325aa3b0881969994a5e985d262a1654e82bede");
            result.DateA.ShouldBe(new DateTime(2004, 3, 8));
            result.DateD.ShouldBe(new DateTime(2002, 3, 27));
            result.Sort.ShouldBe(169252874);
            result.Note.ShouldBe("920a320b4364498e8e2deee726f67b49e38531c61f4243e9a1d544387004f98c9668d194b8cb413cbe8d62124bb5fc9d86b8bd5025294d089d79ca45aa862625a798f806ebbf43e294b877a001c495ffe8c5c2669974452bb3f39f877b0de64b5af5697fa0b34f3f9b4be02ba86a4b4d1c1602004f7144c59f062d5516ecd2d5d04cd193b3f14ab98f48bd67ddf02dceef9d913514b64a71a9e7a7268af7ea6ddeb853fa62584d29b50fc259e022baa7866b1f4a78724ee6825acfb6c3716259a64c7f3809204d6c9082727e1f98b4581bef497d1cfb4889af05f7265cb4ad5ee80d768c516244359afa68c1d063e975bf1876b16dc348829c3c");
            result.Status.ShouldBe("ac0d2e66263e4e8b9260e34b87d1282d1d2ff8be9c22436884");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavUpdateDto()
            {
                UserMainId = Guid.Parse("85976c52-70d5-4a74-8561-a6e17c254284"),
                CompanyJobId = Guid.Parse("0046eee2-5d4c-4dbe-9e01-3175b887d184"),
                ExtendedInformation = "3b8988fe906e40359e58ebc94a96f73ca91ad7e143fb4d67b71a77cbf090c766456fd6284ad846e0bc07c6f23df0a3880ebad17510bc452a9bb15a02a32e97e361ce0acb8ce645cf959391dac2959a9f63acb82ecdec4b859bb038e55f2da00dead6aa5c7aed4283afc3b52caab20e9c53a723ccdd8c4b798ffaae6e0cf9336eace00b99174441e093553f46102c4cfae06c7a6559044d13979c28d6eb38f01673b549228f8b4b9bab1ac8e0c6fba834e34281ec1ed54d5686122d25a394658205b4e32e03554097816ed10631d25cc60602cfddc7db4fa583ad13fad33e5075c1a5ae79c9fb4a7eb7f02276e55a85c0e86811e9d6d447cbb8e9",
                DateA = new DateTime(2009, 4, 6),
                DateD = new DateTime(2012, 3, 14),
                Sort = 1496934570,
                Note = "c6e15477df3a4a1096f5333f43dd3a9e7a8dacde6ffa4933a0b18440c19a84d0b11d4438737d4c0dbaba061f1584179b9accbf01d25f44ebb1969bea92009750580c0950e0814d6aac14c2224c38f01b2fad392489614105aa5ac4d1b17c77da7d9a99230c094d22b833b1ac3b4109270b9b73fdd5624eb0a1f954ba795f410ed350f9cc964345d4ad8deccdce99379b9e290e01d2e748cab34deff33228089aa0b25b0d01e749d08d9a7094ebb96c1e8f27f1742ab441f6a89492887529863494e6c956bec84c9089c4df07b09b0857d43a8880b2b445d0986b8cb85ef639418b2f6ca731d7452f89c29d18a8eb4b88c1bc191797d142afaf96",
                Status = "64817933cb1646759183f55ee42c4e078dafda11208b4b2aa0"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.UpdateAsync(Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"), input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("85976c52-70d5-4a74-8561-a6e17c254284"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0046eee2-5d4c-4dbe-9e01-3175b887d184"));
            result.ExtendedInformation.ShouldBe("3b8988fe906e40359e58ebc94a96f73ca91ad7e143fb4d67b71a77cbf090c766456fd6284ad846e0bc07c6f23df0a3880ebad17510bc452a9bb15a02a32e97e361ce0acb8ce645cf959391dac2959a9f63acb82ecdec4b859bb038e55f2da00dead6aa5c7aed4283afc3b52caab20e9c53a723ccdd8c4b798ffaae6e0cf9336eace00b99174441e093553f46102c4cfae06c7a6559044d13979c28d6eb38f01673b549228f8b4b9bab1ac8e0c6fba834e34281ec1ed54d5686122d25a394658205b4e32e03554097816ed10631d25cc60602cfddc7db4fa583ad13fad33e5075c1a5ae79c9fb4a7eb7f02276e55a85c0e86811e9d6d447cbb8e9");
            result.DateA.ShouldBe(new DateTime(2009, 4, 6));
            result.DateD.ShouldBe(new DateTime(2012, 3, 14));
            result.Sort.ShouldBe(1496934570);
            result.Note.ShouldBe("c6e15477df3a4a1096f5333f43dd3a9e7a8dacde6ffa4933a0b18440c19a84d0b11d4438737d4c0dbaba061f1584179b9accbf01d25f44ebb1969bea92009750580c0950e0814d6aac14c2224c38f01b2fad392489614105aa5ac4d1b17c77da7d9a99230c094d22b833b1ac3b4109270b9b73fdd5624eb0a1f954ba795f410ed350f9cc964345d4ad8deccdce99379b9e290e01d2e748cab34deff33228089aa0b25b0d01e749d08d9a7094ebb96c1e8f27f1742ab441f6a89492887529863494e6c956bec84c9089c4df07b09b0857d43a8880b2b445d0986b8cb85ef639418b2f6ca731d7452f89c29d18a8eb4b88c1bc191797d142afaf96");
            result.Status.ShouldBe("64817933cb1646759183f55ee42c4e078dafda11208b4b2aa0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobFavsAppService.DeleteAsync(Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"));

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"));

            result.ShouldBeNull();
        }
    }
}