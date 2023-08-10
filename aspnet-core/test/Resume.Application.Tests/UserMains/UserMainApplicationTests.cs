using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserMains
{
    public class UserMainsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserMainsAppService _userMainsAppService;
        private readonly IRepository<UserMain, Guid> _userMainRepository;

        public UserMainsAppServiceTests()
        {
            _userMainsAppService = GetRequiredService<IUserMainsAppService>();
            _userMainRepository = GetRequiredService<IRepository<UserMain, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userMainsAppService.GetListAsync(new GetUserMainsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("09628d9c-5356-40c0-9d68-0d8d484e2449")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userMainsAppService.GetAsync(Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserMainCreateDto
            {
                UserId = Guid.Parse("6a910b2d-92ff-42c5-bff1-495bf37cf47e"),
                Name = "5f6ab2091e924d84b13c9a092ef9e930fbcd6ed5e67447dbb7",
                AnonymousName = "232077a02ad24384bc5b67cc2851dc0a58339ae96f0a401cb7",
                LoginAccountCode = "ac29c5f522bd46bd892aa12dd8094205d07e1eaa5008486690",
                LoginMobilePhoneUpdate = "4d34a99c60d34304814429f079cd78ab480c2291086e4388be",
                LoginMobilePhone = "0eb45ed5cff249fb807614d4ec33e3a3c1462e27cd034c60be",
                LoginEmailUpdate = "2794f96336e3466e93e38ffb5992fba40ca274b3d46043e1875a598fe3695fd7b1f52c7018814c28ace2e959ff45d4cc652e47ade2da469a948b90ce78466fdcf4cff7d70511455891e1889e20689085304102a59c074805ac6c15a098a7243e7ab19ad6",
                LoginEmail = "5070b6cde9704cfa9b58a92fe8dd8bce54c7f35110064d8cb622837afa799b3aa30c7497496c4acbaf02f83eb1a01c8749f94161da6a431a96fdd73b354fe9535ed15e00159447379bd5ebba15807af2313ea123536740e8aa9b07dc58269d239e2357b5",
                LoginIdentityNo = "28d687a7d600403da6daa7b6033441a9acbf936c0cb041659d",
                Password = "48de0a9560d942abbc6e1791f28a04f118517710a0404b43b4a49c96101026ba949414c92bc14450beb3cc2c0f01fcd30b5323dddfb1436a9a18897b8f6163334e8ef006870645bc97164084639eab7d4ec6b94ce8fe4494ba4012d59d00d601339e2d7c",
                SystemUserRoleKeys = 1796944001,
                AllowSearch = true,
                DateA = new DateTime(2018, 6, 14),
                ExtendedInformation = "77c8421c2ed04d80bf7e63ac401db5c4f0b89fdd39e549b791a1af7933e407749be588d504284869a5d44cfdcc4f771f88a103cf5aa74cc1861c0f5edc608f8bc626b3fb170f468991ee8df86d3072a2bad4865e044a4bf69f6a3989fb83f09aa88b5d477d8e49afa08eafb45cd3f03b734d1d9ba5664e37b35939ee9a73741dd6b8442969a64cf2a2a25d32842e7bd49cea6468893949d1939d5f6f1828af1c70a830b1a9ba4dc3a93f44409d0dceab6cdc3c49512f4a339190cff64d122ad8d66736b000194062bd8bcc0980627d95fdff3a85c41d4aed9da43c65bf2a8075d59561fca1194216a2470fc073f85e7de8c14b1e231d4294bb96",
                DateD = new DateTime(2022, 1, 7),
                Sort = 2130533146,
                Note = "c16fa05b272e4a84a9b068b4b6782a3b9ad9941c20ef4e53856ecb24c7f7dc15ab45460ee3fc46538b40fd8412adadc005e3f422354340a3bb8a73ec14307ab000f962973eef4023903d1febb08087ac725de9cc0dd948758b0843b8a066faa098b939f67dfd483c86648e19bed4ae872258bebedb364fc8b29a521d4b407198ae2d0189670e419780f52bdb830a99c6e4872bf01094498d9c5df1392d2d55f11fe138b4ca4846f086e37ff9ec0bf133ba99dbdc9e61424182b9a232cb339d6b286202d547334478976ce465952a1bbc0b3a0300766f4094a063e07f4c160ce8b54c879beb6b4b1cb2a44d392381469fa44762a6a0ef485aa308",
                Status = "a4895b6d3da8483f8f9fabe8ca962ac9d0f7750409214095b6",
                Matching = true
            };

            // Act
            var serviceResult = await _userMainsAppService.CreateAsync(input);

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("6a910b2d-92ff-42c5-bff1-495bf37cf47e"));
            result.Name.ShouldBe("5f6ab2091e924d84b13c9a092ef9e930fbcd6ed5e67447dbb7");
            result.AnonymousName.ShouldBe("232077a02ad24384bc5b67cc2851dc0a58339ae96f0a401cb7");
            result.LoginAccountCode.ShouldBe("ac29c5f522bd46bd892aa12dd8094205d07e1eaa5008486690");
            result.LoginMobilePhoneUpdate.ShouldBe("4d34a99c60d34304814429f079cd78ab480c2291086e4388be");
            result.LoginMobilePhone.ShouldBe("0eb45ed5cff249fb807614d4ec33e3a3c1462e27cd034c60be");
            result.LoginEmailUpdate.ShouldBe("2794f96336e3466e93e38ffb5992fba40ca274b3d46043e1875a598fe3695fd7b1f52c7018814c28ace2e959ff45d4cc652e47ade2da469a948b90ce78466fdcf4cff7d70511455891e1889e20689085304102a59c074805ac6c15a098a7243e7ab19ad6");
            result.LoginEmail.ShouldBe("5070b6cde9704cfa9b58a92fe8dd8bce54c7f35110064d8cb622837afa799b3aa30c7497496c4acbaf02f83eb1a01c8749f94161da6a431a96fdd73b354fe9535ed15e00159447379bd5ebba15807af2313ea123536740e8aa9b07dc58269d239e2357b5");
            result.LoginIdentityNo.ShouldBe("28d687a7d600403da6daa7b6033441a9acbf936c0cb041659d");
            result.Password.ShouldBe("48de0a9560d942abbc6e1791f28a04f118517710a0404b43b4a49c96101026ba949414c92bc14450beb3cc2c0f01fcd30b5323dddfb1436a9a18897b8f6163334e8ef006870645bc97164084639eab7d4ec6b94ce8fe4494ba4012d59d00d601339e2d7c");
            result.SystemUserRoleKeys.ShouldBe(1796944001);
            result.AllowSearch.ShouldBe(true);
            result.DateA.ShouldBe(new DateTime(2018, 6, 14));
            result.ExtendedInformation.ShouldBe("77c8421c2ed04d80bf7e63ac401db5c4f0b89fdd39e549b791a1af7933e407749be588d504284869a5d44cfdcc4f771f88a103cf5aa74cc1861c0f5edc608f8bc626b3fb170f468991ee8df86d3072a2bad4865e044a4bf69f6a3989fb83f09aa88b5d477d8e49afa08eafb45cd3f03b734d1d9ba5664e37b35939ee9a73741dd6b8442969a64cf2a2a25d32842e7bd49cea6468893949d1939d5f6f1828af1c70a830b1a9ba4dc3a93f44409d0dceab6cdc3c49512f4a339190cff64d122ad8d66736b000194062bd8bcc0980627d95fdff3a85c41d4aed9da43c65bf2a8075d59561fca1194216a2470fc073f85e7de8c14b1e231d4294bb96");
            result.DateD.ShouldBe(new DateTime(2022, 1, 7));
            result.Sort.ShouldBe(2130533146);
            result.Note.ShouldBe("c16fa05b272e4a84a9b068b4b6782a3b9ad9941c20ef4e53856ecb24c7f7dc15ab45460ee3fc46538b40fd8412adadc005e3f422354340a3bb8a73ec14307ab000f962973eef4023903d1febb08087ac725de9cc0dd948758b0843b8a066faa098b939f67dfd483c86648e19bed4ae872258bebedb364fc8b29a521d4b407198ae2d0189670e419780f52bdb830a99c6e4872bf01094498d9c5df1392d2d55f11fe138b4ca4846f086e37ff9ec0bf133ba99dbdc9e61424182b9a232cb339d6b286202d547334478976ce465952a1bbc0b3a0300766f4094a063e07f4c160ce8b54c879beb6b4b1cb2a44d392381469fa44762a6a0ef485aa308");
            result.Status.ShouldBe("a4895b6d3da8483f8f9fabe8ca962ac9d0f7750409214095b6");
            result.Matching.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserMainUpdateDto()
            {
                UserId = Guid.Parse("4dcbe5dd-c2ad-47df-bc5a-6849e02292f4"),
                Name = "b3c363b581bd4966b687e6e0811337a737860a32f2fa4d7e8e",
                AnonymousName = "872fb2df19ad4ba98ee81404f878812613a4baf2d5b743418d",
                LoginAccountCode = "406e964dbb8846ffa5e87006f7aeb85a52941e8ce9264e089f",
                LoginMobilePhoneUpdate = "7180c63631194b13b49f55f27b7782611cc828b897c1443399",
                LoginMobilePhone = "81b0499981f944ccaf2019a68accf4b8b653afae749f462db4",
                LoginEmailUpdate = "b46da854c15d4159a59517fe65f35a26e8ff7c2501504a79acce78a503369998a8375b8506ce46fdbe0347fc7645c28fc9e612bae3ad41968f786da2aa58bbd9caf4bda7d0b446e2bcdc9c545fd14c1fd9e226393b6c47a69ddb21896c83a5f07688938d",
                LoginEmail = "3a6ca9cbdec34fb1b8874a3b3d3eb288277f8584869041179a92a35b00e668dcbbdbfa4b74774f67a7230d9c09a9526083a47e78fa724b1fa3568d3ae39d18d208f1ac733d604afe9ecb5489f2d02835bcb707d742094f709a18356105157087e8034cdb",
                LoginIdentityNo = "6deb079d09cc4118910fbd8344bbedb8ddb46df74ac944b4ac",
                Password = "541b8e25f05e4f51ac904df514cc3e301442c93f9b44497597b6b2068d41273c25ff980b34f849aa80ff20e4991e4f1bde8a45b25d6e4754a0077b8019fc2e72b850ef11ba7543379326b8c53421688428b537301a914b4aa838748b0922ac42ef998462",
                SystemUserRoleKeys = 1850158833,
                AllowSearch = true,
                DateA = new DateTime(2001, 4, 18),
                ExtendedInformation = "790276b47c594410ad5f02fa3a271fcc3e957a8a34964acb9484a4b86d8ce982e2a3c10dbaa441138899ce15a75d10612a21b093b4e44f6fbe3f91a99893429cd338db1f05e64a869a5c34b91ae9d76f2f4bad760bdc4720b993f2ea177fa138613b5fa0d2364f54aa5d3c13e0ff057f9ea45554b7f4406d82673a2254b97fbb7fdce60f15f24000ac9b61527bc7e75e70dddd93853e4af3b5fbd41f8e18eda395d111b2b74d4d8ba47a9d527bb027b3c487730944b44867a68994f3f6e0fad313fbc05ddffe4451be9f54a143cece0341f60746899249ca9beb0c16d31ff481b7520f9db10e45b999f237fdd511a2e7e585781f257a4db5bacc",
                DateD = new DateTime(2021, 1, 12),
                Sort = 1685659434,
                Note = "fd19161ef1754458be82820b969ab032ee323e7bec4b493fb909a4b8fe663faa1bf82e90657f440a8ce8a6a31cbc966bedce616af8be4ef485d4e9fe178abcf268da706161e44d8cab4a965b33875e8ba65f153c38124af2b6fecc3de00a5a5c5142120c83b2410aa74d530b2e4afb33accf4c146e3d45618682df423181ec989c968f49af6640f59c593190b0f1df3c39f6f1cddb7942f9b5f9711a7afabe624058afccb04c4c3590e575e59578de6677d98115c30d4952bbf897b6741ef908ed9b2e58fdf14781b298191baae8efc778013cf3cc6844288452e4ea31179f569073c68178cc444780097a3fe2e2e01c4f50d73566244fb2bbec",
                Status = "b9504a654209456790e099a42111b0d228828fcfd4db442595",
                Matching = true
            };

            // Act
            var serviceResult = await _userMainsAppService.UpdateAsync(Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"), input);

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("4dcbe5dd-c2ad-47df-bc5a-6849e02292f4"));
            result.Name.ShouldBe("b3c363b581bd4966b687e6e0811337a737860a32f2fa4d7e8e");
            result.AnonymousName.ShouldBe("872fb2df19ad4ba98ee81404f878812613a4baf2d5b743418d");
            result.LoginAccountCode.ShouldBe("406e964dbb8846ffa5e87006f7aeb85a52941e8ce9264e089f");
            result.LoginMobilePhoneUpdate.ShouldBe("7180c63631194b13b49f55f27b7782611cc828b897c1443399");
            result.LoginMobilePhone.ShouldBe("81b0499981f944ccaf2019a68accf4b8b653afae749f462db4");
            result.LoginEmailUpdate.ShouldBe("b46da854c15d4159a59517fe65f35a26e8ff7c2501504a79acce78a503369998a8375b8506ce46fdbe0347fc7645c28fc9e612bae3ad41968f786da2aa58bbd9caf4bda7d0b446e2bcdc9c545fd14c1fd9e226393b6c47a69ddb21896c83a5f07688938d");
            result.LoginEmail.ShouldBe("3a6ca9cbdec34fb1b8874a3b3d3eb288277f8584869041179a92a35b00e668dcbbdbfa4b74774f67a7230d9c09a9526083a47e78fa724b1fa3568d3ae39d18d208f1ac733d604afe9ecb5489f2d02835bcb707d742094f709a18356105157087e8034cdb");
            result.LoginIdentityNo.ShouldBe("6deb079d09cc4118910fbd8344bbedb8ddb46df74ac944b4ac");
            result.Password.ShouldBe("541b8e25f05e4f51ac904df514cc3e301442c93f9b44497597b6b2068d41273c25ff980b34f849aa80ff20e4991e4f1bde8a45b25d6e4754a0077b8019fc2e72b850ef11ba7543379326b8c53421688428b537301a914b4aa838748b0922ac42ef998462");
            result.SystemUserRoleKeys.ShouldBe(1850158833);
            result.AllowSearch.ShouldBe(true);
            result.DateA.ShouldBe(new DateTime(2001, 4, 18));
            result.ExtendedInformation.ShouldBe("790276b47c594410ad5f02fa3a271fcc3e957a8a34964acb9484a4b86d8ce982e2a3c10dbaa441138899ce15a75d10612a21b093b4e44f6fbe3f91a99893429cd338db1f05e64a869a5c34b91ae9d76f2f4bad760bdc4720b993f2ea177fa138613b5fa0d2364f54aa5d3c13e0ff057f9ea45554b7f4406d82673a2254b97fbb7fdce60f15f24000ac9b61527bc7e75e70dddd93853e4af3b5fbd41f8e18eda395d111b2b74d4d8ba47a9d527bb027b3c487730944b44867a68994f3f6e0fad313fbc05ddffe4451be9f54a143cece0341f60746899249ca9beb0c16d31ff481b7520f9db10e45b999f237fdd511a2e7e585781f257a4db5bacc");
            result.DateD.ShouldBe(new DateTime(2021, 1, 12));
            result.Sort.ShouldBe(1685659434);
            result.Note.ShouldBe("fd19161ef1754458be82820b969ab032ee323e7bec4b493fb909a4b8fe663faa1bf82e90657f440a8ce8a6a31cbc966bedce616af8be4ef485d4e9fe178abcf268da706161e44d8cab4a965b33875e8ba65f153c38124af2b6fecc3de00a5a5c5142120c83b2410aa74d530b2e4afb33accf4c146e3d45618682df423181ec989c968f49af6640f59c593190b0f1df3c39f6f1cddb7942f9b5f9711a7afabe624058afccb04c4c3590e575e59578de6677d98115c30d4952bbf897b6741ef908ed9b2e58fdf14781b298191baae8efc778013cf3cc6844288452e4ea31179f569073c68178cc444780097a3fe2e2e01c4f50d73566244fb2bbec");
            result.Status.ShouldBe("b9504a654209456790e099a42111b0d228828fcfd4db442595");
            result.Matching.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userMainsAppService.DeleteAsync(Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"));

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"));

            result.ShouldBeNull();
        }
    }
}