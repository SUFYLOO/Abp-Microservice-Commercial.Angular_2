using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemTables
{
    public class SystemTablesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemTablesAppService _systemTablesAppService;
        private readonly IRepository<SystemTable, Guid> _systemTableRepository;

        public SystemTablesAppServiceTests()
        {
            _systemTablesAppService = GetRequiredService<ISystemTablesAppService>();
            _systemTableRepository = GetRequiredService<IRepository<SystemTable, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemTablesAppService.GetListAsync(new GetSystemTablesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8726b177-93cf-439d-ac98-98d67b0db868")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemTablesAppService.GetAsync(Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemTableCreateDto
            {
                Name = "2931c2b4b6ff419ea21fe71a63033598fe896f7db82e48ddb4",
                AllowInsert = true,
                AllowUpdate = true,
                AllowDelete = true,
                AllowSelect = true,
                AllowExport = true,
                AllowImport = true,
                AllowPage = true,
                AllowSort = true,
                ExtendedInformation = "33f5df9fb3c747509f49de2c8aa18aadf10ced3c5d654d7bb0b3f29a0328cfc2700e3ef0275c45cfab3d90362f8144dd04bad1ec35ae4096b57818e4fa6f25699c091916b4e04d709c6604dccd0008ef76ec61cde8244fa09b3b253d1751cf7dfdeb3f594d4b405bb8b26ecf7e13513c7fceaa527a294022a06804215ad2bdf3b3ba7f98f1934ddea7c08a583d95acb46ae25f2ae0e84551a13ffc20281173e18bac390d45c441948f6b6581e38a6b12cdaa3a4da53d409cb469a803a5b8b53b096ce11c2ceb4f2b930e1823041e4e7d3f6d2500d2674135b1392b49df28e4982dabd51909394438abac958e80623fa86d94600e439541ccab8b",
                DateA = new DateTime(2010, 11, 23),
                DateD = new DateTime(2011, 2, 21),
                Sort = 1108157326,
                Note = "cd7d497c2fca4ea7b1485671eb56280a8b3afe81d1c3417aaf5efa8bedf8317d63a7f6b868b14e26aba6dc2c5203bb7ba20584e7bab84caa8e2f9717d93bf367cb89000611f7458d98ff6317f339d6a44fb1f08ee04a4907b66caa1942dc8f3178e4c4174d93497c885354d8e854380b3b92555c1cc241c6b44194ec1ad5ae126ae91a9ebfa544cba0b84341226b1a0940c54a01d3ee441cbfceeb9db1081a424c79d8acdc8d45e6bf1af6ba49e97a78c56efc931e1840bb8a3b9f92f3d46bffed0aa5305220414c87d189cc0f5716047a20eb1d3a89443eb982140cc0f8ff1e87500e283e724869ba27f31fb00c9e1c4447d3aebf9945239a2c",
                Status = "78e252aa92f94b6e9dacd7fac07909ed3cec17fbeaf346698f"
            };

            // Act
            var serviceResult = await _systemTablesAppService.CreateAsync(input);

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("2931c2b4b6ff419ea21fe71a63033598fe896f7db82e48ddb4");
            result.AllowInsert.ShouldBe(true);
            result.AllowUpdate.ShouldBe(true);
            result.AllowDelete.ShouldBe(true);
            result.AllowSelect.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowImport.ShouldBe(true);
            result.AllowPage.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("33f5df9fb3c747509f49de2c8aa18aadf10ced3c5d654d7bb0b3f29a0328cfc2700e3ef0275c45cfab3d90362f8144dd04bad1ec35ae4096b57818e4fa6f25699c091916b4e04d709c6604dccd0008ef76ec61cde8244fa09b3b253d1751cf7dfdeb3f594d4b405bb8b26ecf7e13513c7fceaa527a294022a06804215ad2bdf3b3ba7f98f1934ddea7c08a583d95acb46ae25f2ae0e84551a13ffc20281173e18bac390d45c441948f6b6581e38a6b12cdaa3a4da53d409cb469a803a5b8b53b096ce11c2ceb4f2b930e1823041e4e7d3f6d2500d2674135b1392b49df28e4982dabd51909394438abac958e80623fa86d94600e439541ccab8b");
            result.DateA.ShouldBe(new DateTime(2010, 11, 23));
            result.DateD.ShouldBe(new DateTime(2011, 2, 21));
            result.Sort.ShouldBe(1108157326);
            result.Note.ShouldBe("cd7d497c2fca4ea7b1485671eb56280a8b3afe81d1c3417aaf5efa8bedf8317d63a7f6b868b14e26aba6dc2c5203bb7ba20584e7bab84caa8e2f9717d93bf367cb89000611f7458d98ff6317f339d6a44fb1f08ee04a4907b66caa1942dc8f3178e4c4174d93497c885354d8e854380b3b92555c1cc241c6b44194ec1ad5ae126ae91a9ebfa544cba0b84341226b1a0940c54a01d3ee441cbfceeb9db1081a424c79d8acdc8d45e6bf1af6ba49e97a78c56efc931e1840bb8a3b9f92f3d46bffed0aa5305220414c87d189cc0f5716047a20eb1d3a89443eb982140cc0f8ff1e87500e283e724869ba27f31fb00c9e1c4447d3aebf9945239a2c");
            result.Status.ShouldBe("78e252aa92f94b6e9dacd7fac07909ed3cec17fbeaf346698f");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemTableUpdateDto()
            {
                Name = "7e472d1a9c0f4702a205ecca2ab87bd466e66858b030420d8f",
                AllowInsert = true,
                AllowUpdate = true,
                AllowDelete = true,
                AllowSelect = true,
                AllowExport = true,
                AllowImport = true,
                AllowPage = true,
                AllowSort = true,
                ExtendedInformation = "905be6db2a954334b39fa0ce8e69e54152493dbd02c142b286f2fe8088b2ef070d3fe92d2ed04aafb58825ba3878d31bcdc6835be2f048d6b57a284d03eadf64857e371fe33a4418963e2872b68958e7e045b304c26e4796990aaa1f917b762e7c7d5b94a29d4a1db881ffa06252a67ab933963da80a45ba807482f9300b1bd0de962cfcb0124df7a95cf30ad676a82693903b3d2bcc47eaa31c9d9b639f3a6480019ae3e38f40958b8d0fd99f207f1d8c9d8c5aafd94204b33daa811126697c9636bcc6819447c9af8e10fe710be07ca80c9ec2d2e744c6944e2cfbe5a7764868b28648393d41cfb40fd7a8806201725d49a7c44bf744288499",
                DateA = new DateTime(2010, 4, 14),
                DateD = new DateTime(2009, 6, 17),
                Sort = 1574252298,
                Note = "f0b648eded8049f09ce78a04ef67ed55bbf98b766c0947a99e0e807a19f1d266658b3fd7c1884702bd3b0fc0cea5bcdf83bc6dcf6b3d47a9bc82da30ac6f6ad86ed3c16cb6cf4e05a91936ced1b153fc1179b730872b46edbf11d66b00aec5ec6788f3adb79e45f3a2d703b65e7a82b0bb2431bf24804d74ac007dbffce10916f19cfe97bbd349b8a898bdd5d3de72cc0984547fa3f34582879eabd3c250c9f4bca7539086fb4315befa7602c1a4d3f198b8efcb8d7845468604709acefbb2514098e5b6a3c749b6b0ffeac074e8898c0ca12b450aa2418995547d48b64b6dce6afe8ab2d9de4991906eadf9a4402374fac3a4337fe24de79075",
                Status = "6ada4b5dac7c4735969257e9031d76cedfca078c05044c96b5"
            };

            // Act
            var serviceResult = await _systemTablesAppService.UpdateAsync(Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"), input);

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("7e472d1a9c0f4702a205ecca2ab87bd466e66858b030420d8f");
            result.AllowInsert.ShouldBe(true);
            result.AllowUpdate.ShouldBe(true);
            result.AllowDelete.ShouldBe(true);
            result.AllowSelect.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowImport.ShouldBe(true);
            result.AllowPage.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("905be6db2a954334b39fa0ce8e69e54152493dbd02c142b286f2fe8088b2ef070d3fe92d2ed04aafb58825ba3878d31bcdc6835be2f048d6b57a284d03eadf64857e371fe33a4418963e2872b68958e7e045b304c26e4796990aaa1f917b762e7c7d5b94a29d4a1db881ffa06252a67ab933963da80a45ba807482f9300b1bd0de962cfcb0124df7a95cf30ad676a82693903b3d2bcc47eaa31c9d9b639f3a6480019ae3e38f40958b8d0fd99f207f1d8c9d8c5aafd94204b33daa811126697c9636bcc6819447c9af8e10fe710be07ca80c9ec2d2e744c6944e2cfbe5a7764868b28648393d41cfb40fd7a8806201725d49a7c44bf744288499");
            result.DateA.ShouldBe(new DateTime(2010, 4, 14));
            result.DateD.ShouldBe(new DateTime(2009, 6, 17));
            result.Sort.ShouldBe(1574252298);
            result.Note.ShouldBe("f0b648eded8049f09ce78a04ef67ed55bbf98b766c0947a99e0e807a19f1d266658b3fd7c1884702bd3b0fc0cea5bcdf83bc6dcf6b3d47a9bc82da30ac6f6ad86ed3c16cb6cf4e05a91936ced1b153fc1179b730872b46edbf11d66b00aec5ec6788f3adb79e45f3a2d703b65e7a82b0bb2431bf24804d74ac007dbffce10916f19cfe97bbd349b8a898bdd5d3de72cc0984547fa3f34582879eabd3c250c9f4bca7539086fb4315befa7602c1a4d3f198b8efcb8d7845468604709acefbb2514098e5b6a3c749b6b0ffeac074e8898c0ca12b450aa2418995547d48b64b6dce6afe8ab2d9de4991906eadf9a4402374fac3a4337fe24de79075");
            result.Status.ShouldBe("6ada4b5dac7c4735969257e9031d76cedfca078c05044c96b5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemTablesAppService.DeleteAsync(Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"));

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"));

            result.ShouldBeNull();
        }
    }
}