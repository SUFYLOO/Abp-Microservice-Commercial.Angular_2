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
            result.Items.Any(x => x.Id == Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("762db719-85cf-4df2-a121-75783302538a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobFavsAppService.GetAsync(Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavCreateDto
            {
                UserMainId = Guid.Parse("57dffc09-f592-488f-b526-ab00ff241691"),
                CompanyJobId = Guid.Parse("49329d02-d391-4f0c-9bb7-1dee849f66a5"),
                ExtendedInformation = "e3ca83be8bc9404ba0d6431720a6df90a9f4d7c9f8714ce5834e57c23fc28253ef915ff712904949b5ce08b756644872fed22e0fda574aa6a62a680b717a6f81db2f6e5612e1430fb21177b71b3da39e5e7cafa11d4c42ae9d7b8d40761762cfc005902936084735a13ed11b8320923504c245cc79b34496ae7ff6e5183989b9ffb307a7f0484baa840ac289281a9ad1178b842c356843a491d78c873cd5c6985fca80edcca54131a57004663a73f874c381b97ad13b4903813692a17cb9429c999b5ca50c99442c8fabbf939ac07862e65b6d1d4d8c4bb8a9b80a7e8923772ffbc5fb354cf14ea0a17c99efc1d81826b3e1994d82b2438a8f66",
                DateA = new DateTime(2002, 3, 21),
                DateD = new DateTime(2011, 7, 8),
                Sort = 2002384363,
                Note = "3d609c0b3e1d488b864883f231a918295762766e1e90492e87fa6e87ff1e6ff14c5e093d1fa24dd7a6cca33facad5d98cde98589ee4249539261a8449faea094c6d93d2bad5e468b9b28bd740f187f5e9a44a0945edd43d0b8a47b83803ef67ca5a62e07b08b45d5bfed0e88929728fa54f924d92ae64f4785161502a2a88f538768c6df244d440fba4f428c41db27217e4abb690e02439db2c1e8900031e24b6a632f4bfec2409d8c767a67588472844a42bcacca384755a0cb381c713964e6d74f6c9f4f164c22961b6fc10738a5690273ee90dafd4b24a1bf1077e1603b5ad4f96edd84984fc79bbee324b67c0aa084d2e651d92340118dce",
                Status = "1c79c6a512024af4afdbd8160ef6a1cca1ba2a13387c4cfca0"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("57dffc09-f592-488f-b526-ab00ff241691"));
            result.CompanyJobId.ShouldBe(Guid.Parse("49329d02-d391-4f0c-9bb7-1dee849f66a5"));
            result.ExtendedInformation.ShouldBe("e3ca83be8bc9404ba0d6431720a6df90a9f4d7c9f8714ce5834e57c23fc28253ef915ff712904949b5ce08b756644872fed22e0fda574aa6a62a680b717a6f81db2f6e5612e1430fb21177b71b3da39e5e7cafa11d4c42ae9d7b8d40761762cfc005902936084735a13ed11b8320923504c245cc79b34496ae7ff6e5183989b9ffb307a7f0484baa840ac289281a9ad1178b842c356843a491d78c873cd5c6985fca80edcca54131a57004663a73f874c381b97ad13b4903813692a17cb9429c999b5ca50c99442c8fabbf939ac07862e65b6d1d4d8c4bb8a9b80a7e8923772ffbc5fb354cf14ea0a17c99efc1d81826b3e1994d82b2438a8f66");
            result.DateA.ShouldBe(new DateTime(2002, 3, 21));
            result.DateD.ShouldBe(new DateTime(2011, 7, 8));
            result.Sort.ShouldBe(2002384363);
            result.Note.ShouldBe("3d609c0b3e1d488b864883f231a918295762766e1e90492e87fa6e87ff1e6ff14c5e093d1fa24dd7a6cca33facad5d98cde98589ee4249539261a8449faea094c6d93d2bad5e468b9b28bd740f187f5e9a44a0945edd43d0b8a47b83803ef67ca5a62e07b08b45d5bfed0e88929728fa54f924d92ae64f4785161502a2a88f538768c6df244d440fba4f428c41db27217e4abb690e02439db2c1e8900031e24b6a632f4bfec2409d8c767a67588472844a42bcacca384755a0cb381c713964e6d74f6c9f4f164c22961b6fc10738a5690273ee90dafd4b24a1bf1077e1603b5ad4f96edd84984fc79bbee324b67c0aa084d2e651d92340118dce");
            result.Status.ShouldBe("1c79c6a512024af4afdbd8160ef6a1cca1ba2a13387c4cfca0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavUpdateDto()
            {
                UserMainId = Guid.Parse("08bf4ab9-f34f-42e6-9408-d7609f00f5c3"),
                CompanyJobId = Guid.Parse("ebcc2d82-f091-4870-b905-8e7ca887bd1e"),
                ExtendedInformation = "860a49d35c5c46b7ae63f188f6b16dcfa6ba4723eb6a4a77b643168eb3c8ee3d89132b9b3b3945a287fe1092236304bbc08896495ddb4023b387954a25ae54055bfef0b6ccd44a16a70ace58d96007b882d20e3f997249eaaea5c95177c1f9d7dee03d91ba1345ec9b2136c42ff7405326e68990a2cd41bfbc5fddeafc874b19e0a314d7554c46e0a92db7b4dd0b38c45b812cdc091d4c5493ff6eafd43a7dcd91e161372364410ead938928a12cbabb1a3527ff09954d029d848f4438963af77b995161b2cd48cf883e384ceb1f23ce1726bdadbaf843f9b78bd253003fa9a082c22eae40c647268a7647a75118e0e912a1279b90d34058892e",
                DateA = new DateTime(2012, 4, 8),
                DateD = new DateTime(2019, 5, 3),
                Sort = 561940745,
                Note = "f032015897554f91ba77f09822a2b07b6e37fda5fcae40298340679cc964877d06308b0dba8e4f09b13e8e3931e8b53103fd2048ce484f1091b04c5bc805ba5f2369a6a869454dd8b0a1d36cf11ca77911f23c11170a4cde86c766b82a2316d3b5fd329d04f44edfbd121fd88f936fb0fa43dee928544d7a8084d98009fbecb3f1e22c79c2df492d815ce37f35fe756bca85fb1b74c14110bb262c1621dae3a93fe9916e54f242d3b3f4da70b1bd0364842a8a6b33164b52a4e0364aacf8d2be9c131ffb7bb244159b8d09e49372a39a4ee9fabb9d0444d18d395fe567e44a13eab00a2f3c4e45e1952fbdc3ba981296c8af7f95a2414e4ab887",
                Status = "b1fc52f1f8f74eac8f858af9e56f153afdd8586cc5c042be83"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.UpdateAsync(Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"), input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("08bf4ab9-f34f-42e6-9408-d7609f00f5c3"));
            result.CompanyJobId.ShouldBe(Guid.Parse("ebcc2d82-f091-4870-b905-8e7ca887bd1e"));
            result.ExtendedInformation.ShouldBe("860a49d35c5c46b7ae63f188f6b16dcfa6ba4723eb6a4a77b643168eb3c8ee3d89132b9b3b3945a287fe1092236304bbc08896495ddb4023b387954a25ae54055bfef0b6ccd44a16a70ace58d96007b882d20e3f997249eaaea5c95177c1f9d7dee03d91ba1345ec9b2136c42ff7405326e68990a2cd41bfbc5fddeafc874b19e0a314d7554c46e0a92db7b4dd0b38c45b812cdc091d4c5493ff6eafd43a7dcd91e161372364410ead938928a12cbabb1a3527ff09954d029d848f4438963af77b995161b2cd48cf883e384ceb1f23ce1726bdadbaf843f9b78bd253003fa9a082c22eae40c647268a7647a75118e0e912a1279b90d34058892e");
            result.DateA.ShouldBe(new DateTime(2012, 4, 8));
            result.DateD.ShouldBe(new DateTime(2019, 5, 3));
            result.Sort.ShouldBe(561940745);
            result.Note.ShouldBe("f032015897554f91ba77f09822a2b07b6e37fda5fcae40298340679cc964877d06308b0dba8e4f09b13e8e3931e8b53103fd2048ce484f1091b04c5bc805ba5f2369a6a869454dd8b0a1d36cf11ca77911f23c11170a4cde86c766b82a2316d3b5fd329d04f44edfbd121fd88f936fb0fa43dee928544d7a8084d98009fbecb3f1e22c79c2df492d815ce37f35fe756bca85fb1b74c14110bb262c1621dae3a93fe9916e54f242d3b3f4da70b1bd0364842a8a6b33164b52a4e0364aacf8d2be9c131ffb7bb244159b8d09e49372a39a4ee9fabb9d0444d18d395fe567e44a13eab00a2f3c4e45e1952fbdc3ba981296c8af7f95a2414e4ab887");
            result.Status.ShouldBe("b1fc52f1f8f74eac8f858af9e56f153afdd8586cc5c042be83");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobFavsAppService.DeleteAsync(Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"));

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == Guid.Parse("348bd2dd-8a52-4743-be90-c0b157623f5c"));

            result.ShouldBeNull();
        }
    }
}