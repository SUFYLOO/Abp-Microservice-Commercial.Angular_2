using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyUsers
{
    public class CompanyUsersAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyUsersAppService _companyUsersAppService;
        private readonly IRepository<CompanyUser, Guid> _companyUserRepository;

        public CompanyUsersAppServiceTests()
        {
            _companyUsersAppService = GetRequiredService<ICompanyUsersAppService>();
            _companyUserRepository = GetRequiredService<IRepository<CompanyUser, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyUsersAppService.GetListAsync(new GetCompanyUsersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("516eea04-6864-4c5c-8789-4b4a33773d65")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyUsersAppService.GetAsync(Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyUserCreateDto
            {
                CompanyMainId = Guid.Parse("03d9c354-4c2c-44f3-8885-d96394dabf8e"),
                UserMainId = Guid.Parse("c9dcc91b-1bf1-4b7c-88dd-dced4c40ca18"),
                JobName = "18b0408bfa4f4429ae9c590ddc8de522b4914e00d5bd49c7a0",
                OfficePhone = "d067a5e3d09049569e3c11616f3fbcb0f064a39b9dcd4cf781",
                ExtendedInformation = "df85ea09d32b4b69b7ad10d1ab54ffbb8595c481fa2843769bea264d6941d293a616d7715422447083f18934669af51c0e039a32c4ad477f804ac98b3019b98a9ff96ff0089749bd9530ca34517d88896e14a88b51ee45e2aefd9f8150170c356685994b689840928a33f41660f59cb2654ae2e09b1e4e35a2a858609ccbbae358ce5d55a34948c58bfebb9b127c6ea95aafa332d4724c63b27ebb5982cb9c85fb4ec02220e94f0ba53c7b6b5530dc66c50e7b0c925f4bd5a566686c35507a52d616a9e807fd4c38b29cb13b9782bbfa0cf3894f08814228a9e8589342636e7e0445da4131b6495db0f0aff2c92165a382d673f8c7c946a09cde",
                DateA = new DateTime(2006, 8, 15),
                DateD = new DateTime(2009, 5, 18),
                Sort = 926566302,
                Note = "7e4964a6ba7446388f91b14018ab7a352b12a4a9120f4efab6000b87025f4fb6ebc9b2d3f5e9443da9792b86ddab4d461df11cfc18d4416db81262d4841eefd36b53345e299147498e44246ecedd2756a06a1334db244909934eaed6109cc739265043ebb5864d73a9812b9cec357e59ce8ef28292fb42f9a967819f7fa3f775da4e00363f03491c8fdfbce12bef0d5a88c37fd4fbf44263bef42ef1881a0ea45281799e38454fd9ac9bdff1a550e5ecd193e2c505f34473a733bee2cb0f679170726be02670461395c5d3e876894838d43b0554dff24e4ea8f292078c4d87ac5e7028629e89459c89c746f7c216dc184acd61a9ed764e54b866",
                Status = "8fca93487b814b8cb85f9ff6d117b8e198afcc4f199040fda9",
                MatchingReceive = true
            };

            // Act
            var serviceResult = await _companyUsersAppService.CreateAsync(input);

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("03d9c354-4c2c-44f3-8885-d96394dabf8e"));
            result.UserMainId.ShouldBe(Guid.Parse("c9dcc91b-1bf1-4b7c-88dd-dced4c40ca18"));
            result.JobName.ShouldBe("18b0408bfa4f4429ae9c590ddc8de522b4914e00d5bd49c7a0");
            result.OfficePhone.ShouldBe("d067a5e3d09049569e3c11616f3fbcb0f064a39b9dcd4cf781");
            result.ExtendedInformation.ShouldBe("df85ea09d32b4b69b7ad10d1ab54ffbb8595c481fa2843769bea264d6941d293a616d7715422447083f18934669af51c0e039a32c4ad477f804ac98b3019b98a9ff96ff0089749bd9530ca34517d88896e14a88b51ee45e2aefd9f8150170c356685994b689840928a33f41660f59cb2654ae2e09b1e4e35a2a858609ccbbae358ce5d55a34948c58bfebb9b127c6ea95aafa332d4724c63b27ebb5982cb9c85fb4ec02220e94f0ba53c7b6b5530dc66c50e7b0c925f4bd5a566686c35507a52d616a9e807fd4c38b29cb13b9782bbfa0cf3894f08814228a9e8589342636e7e0445da4131b6495db0f0aff2c92165a382d673f8c7c946a09cde");
            result.DateA.ShouldBe(new DateTime(2006, 8, 15));
            result.DateD.ShouldBe(new DateTime(2009, 5, 18));
            result.Sort.ShouldBe(926566302);
            result.Note.ShouldBe("7e4964a6ba7446388f91b14018ab7a352b12a4a9120f4efab6000b87025f4fb6ebc9b2d3f5e9443da9792b86ddab4d461df11cfc18d4416db81262d4841eefd36b53345e299147498e44246ecedd2756a06a1334db244909934eaed6109cc739265043ebb5864d73a9812b9cec357e59ce8ef28292fb42f9a967819f7fa3f775da4e00363f03491c8fdfbce12bef0d5a88c37fd4fbf44263bef42ef1881a0ea45281799e38454fd9ac9bdff1a550e5ecd193e2c505f34473a733bee2cb0f679170726be02670461395c5d3e876894838d43b0554dff24e4ea8f292078c4d87ac5e7028629e89459c89c746f7c216dc184acd61a9ed764e54b866");
            result.Status.ShouldBe("8fca93487b814b8cb85f9ff6d117b8e198afcc4f199040fda9");
            result.MatchingReceive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyUserUpdateDto()
            {
                CompanyMainId = Guid.Parse("7ac21547-62fc-46ab-a770-ec5d03986931"),
                UserMainId = Guid.Parse("2221d6fd-61c7-4166-bad7-7c7a3baeb023"),
                JobName = "3c31c94962474b8e8be0c17e19198d3bd1bdb3979787408b94",
                OfficePhone = "35ce5f97759a48f289ab1e9fc80be57d5c790530583a49f3a1",
                ExtendedInformation = "64de8cc7636948fc8d77c1ae617547d65898dcb6a90e4302b97fa88d863ee8cc3e2364d455c84839921beb762842a9f560117cb0a17b49ea949601e1774079dc0cb545bf76384a49a18951bbe722af7d749422770a8d4ef29025f7e4efaa47454d7e3184ab214922935dbddb8c1d22a2f8b540a43db0461fa4ca1b55a75dd47c0124ae9f88cc4572bb7529dc2b655f4686534b1725994576a956448a471a9916b159fff9fda0484e809cd7a87ebbce1da4385d1f23bf483d8f2eb7368f1fd8bcea38ab22b53843ae9a7da4cf51f5bcfe8dea6288b9454c6a8c12ddf8598d5d5e0e927ef250d5469093fdb10f5505e267763938382e174549adcb",
                DateA = new DateTime(2011, 7, 2),
                DateD = new DateTime(2001, 5, 4),
                Sort = 267901697,
                Note = "6da4e155116244bd9ce316c5d1824f95c69fcf9d0d374f83bf2b1f5726735af4c9acb93fd4674a5a83d99453de9b2cdf869142a7a9624348b9edaac413caf22e038225d5d4e0495191d7d779ae9fd1a09d79eea080cc46328a4701b748e6a514ecdc2075c27c49cb8e17ab6825b570585be7fd6002e2473a9cdb68b2488869d45c1559482fc34cb1ae6fc810d372fbde37d27b09b4f64019857d6a5f8b11bf7a8e6c5dfdbf4345fbb0074207ccc91842c88e6c7fc5a941edaf6f402e5ddb7e4416e18b8e2a924417b8b9adf850008c44db1541990d0a43868cead1f0768df2ad7849bf7e24ee46e09a9eb0713eb426dd6b5f4ee4194d48caa8d5",
                Status = "f9e73e4e978d4f7bb535ec3d5fd9bc51e9bfae36ab414f9495",
                MatchingReceive = true
            };

            // Act
            var serviceResult = await _companyUsersAppService.UpdateAsync(Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"), input);

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("7ac21547-62fc-46ab-a770-ec5d03986931"));
            result.UserMainId.ShouldBe(Guid.Parse("2221d6fd-61c7-4166-bad7-7c7a3baeb023"));
            result.JobName.ShouldBe("3c31c94962474b8e8be0c17e19198d3bd1bdb3979787408b94");
            result.OfficePhone.ShouldBe("35ce5f97759a48f289ab1e9fc80be57d5c790530583a49f3a1");
            result.ExtendedInformation.ShouldBe("64de8cc7636948fc8d77c1ae617547d65898dcb6a90e4302b97fa88d863ee8cc3e2364d455c84839921beb762842a9f560117cb0a17b49ea949601e1774079dc0cb545bf76384a49a18951bbe722af7d749422770a8d4ef29025f7e4efaa47454d7e3184ab214922935dbddb8c1d22a2f8b540a43db0461fa4ca1b55a75dd47c0124ae9f88cc4572bb7529dc2b655f4686534b1725994576a956448a471a9916b159fff9fda0484e809cd7a87ebbce1da4385d1f23bf483d8f2eb7368f1fd8bcea38ab22b53843ae9a7da4cf51f5bcfe8dea6288b9454c6a8c12ddf8598d5d5e0e927ef250d5469093fdb10f5505e267763938382e174549adcb");
            result.DateA.ShouldBe(new DateTime(2011, 7, 2));
            result.DateD.ShouldBe(new DateTime(2001, 5, 4));
            result.Sort.ShouldBe(267901697);
            result.Note.ShouldBe("6da4e155116244bd9ce316c5d1824f95c69fcf9d0d374f83bf2b1f5726735af4c9acb93fd4674a5a83d99453de9b2cdf869142a7a9624348b9edaac413caf22e038225d5d4e0495191d7d779ae9fd1a09d79eea080cc46328a4701b748e6a514ecdc2075c27c49cb8e17ab6825b570585be7fd6002e2473a9cdb68b2488869d45c1559482fc34cb1ae6fc810d372fbde37d27b09b4f64019857d6a5f8b11bf7a8e6c5dfdbf4345fbb0074207ccc91842c88e6c7fc5a941edaf6f402e5ddb7e4416e18b8e2a924417b8b9adf850008c44db1541990d0a43868cead1f0768df2ad7849bf7e24ee46e09a9eb0713eb426dd6b5f4ee4194d48caa8d5");
            result.Status.ShouldBe("f9e73e4e978d4f7bb535ec3d5fd9bc51e9bfae36ab414f9495");
            result.MatchingReceive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyUsersAppService.DeleteAsync(Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"));

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"));

            result.ShouldBeNull();
        }
    }
}