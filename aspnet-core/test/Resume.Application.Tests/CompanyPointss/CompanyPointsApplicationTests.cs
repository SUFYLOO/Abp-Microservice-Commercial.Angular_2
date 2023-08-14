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
            result.Items.Any(x => x.Id == Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ba1c8e5e-84b7-4797-99db-9d6d173e11d6")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyPointssAppService.GetAsync(Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyPointsCreateDto
            {
                CompanyMainId = Guid.Parse("f709fcdc-2862-4be8-9923-056f5cfd5ce7"),
                CompanyPointsTypeCode = "3e641aabd41b42b1ae7c1383d3dceb9807437aec6d6742d592",
                Points = 1565892303,
                ExtendedInformation = "ff51215386944868a1d9e842ca5424254320fab49c754212855e5ea9d14e6a575a9dfb858358401da749549672dfd38693c7cb03fbd143209f71bcdb70a32301dbe6c6d61dcc42a0820e403e9f472d1900277505b3644cedaa986404162e4f01f5e5bc611d0f4eedacfcba0b073eb28de9e79a5791bf47fb8f5f684668ba525dd801c46553934f588cdbef718a6c34b5a77d482bf003412f928e46b4e05fc96de17836818992462a8d47297b8577e12335b45435b15745ff9b11337d9370a3625bfaca5053f9477cb63fa97d63b0c15765d3000c8ecc4f8584a0237ccda2fcbd20ff1f1f4e6a49609c1b4a05641726e03377958cc59840a38d35",
                DateA = new DateTime(2003, 2, 15),
                DateD = new DateTime(2021, 5, 3),
                Sort = 146691293,
                Note = "b0466a57e62d493b839e8150ad323ae707bfb9c0353c485e91ff6aa2b65801345e0ae5deee874ca184cdee0d00b1a2617d8f6fb10c2c4023a4c22f85df899f105192f7dba1ef4ab6a8f57eb2fead024a9b73a3615ea241c0b1cfddf8346984bce311551cb88d4543bcec1b6ea91a61a751bf6f24f71340848ce99d6552ddbb82406b1b71a894449885b592896aa5e87a2937880b4ed94641a65173683b0aff06c4ae755a7fb441089b38dd7eb2fe91bc39b5d0f0632c4f6a8b081fbb4b6465bbf9d54af7e9c24c91b28fd2ab4c8a208ec6fade073b95482799057caaf308f3fc9855f22051fa447b9807f7c44727bc721c1f7c51dd8744d38483",
                Status = "a2d7e9d9d72b49c895ba6456ef6102ec74994d54737a4928a4"
            };

            // Act
            var serviceResult = await _companyPointssAppService.CreateAsync(input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f709fcdc-2862-4be8-9923-056f5cfd5ce7"));
            result.CompanyPointsTypeCode.ShouldBe("3e641aabd41b42b1ae7c1383d3dceb9807437aec6d6742d592");
            result.Points.ShouldBe(1565892303);
            result.ExtendedInformation.ShouldBe("ff51215386944868a1d9e842ca5424254320fab49c754212855e5ea9d14e6a575a9dfb858358401da749549672dfd38693c7cb03fbd143209f71bcdb70a32301dbe6c6d61dcc42a0820e403e9f472d1900277505b3644cedaa986404162e4f01f5e5bc611d0f4eedacfcba0b073eb28de9e79a5791bf47fb8f5f684668ba525dd801c46553934f588cdbef718a6c34b5a77d482bf003412f928e46b4e05fc96de17836818992462a8d47297b8577e12335b45435b15745ff9b11337d9370a3625bfaca5053f9477cb63fa97d63b0c15765d3000c8ecc4f8584a0237ccda2fcbd20ff1f1f4e6a49609c1b4a05641726e03377958cc59840a38d35");
            result.DateA.ShouldBe(new DateTime(2003, 2, 15));
            result.DateD.ShouldBe(new DateTime(2021, 5, 3));
            result.Sort.ShouldBe(146691293);
            result.Note.ShouldBe("b0466a57e62d493b839e8150ad323ae707bfb9c0353c485e91ff6aa2b65801345e0ae5deee874ca184cdee0d00b1a2617d8f6fb10c2c4023a4c22f85df899f105192f7dba1ef4ab6a8f57eb2fead024a9b73a3615ea241c0b1cfddf8346984bce311551cb88d4543bcec1b6ea91a61a751bf6f24f71340848ce99d6552ddbb82406b1b71a894449885b592896aa5e87a2937880b4ed94641a65173683b0aff06c4ae755a7fb441089b38dd7eb2fe91bc39b5d0f0632c4f6a8b081fbb4b6465bbf9d54af7e9c24c91b28fd2ab4c8a208ec6fade073b95482799057caaf308f3fc9855f22051fa447b9807f7c44727bc721c1f7c51dd8744d38483");
            result.Status.ShouldBe("a2d7e9d9d72b49c895ba6456ef6102ec74994d54737a4928a4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyPointsUpdateDto()
            {
                CompanyMainId = Guid.Parse("f16d3b17-3eb8-4e69-9ff3-a19880133aef"),
                CompanyPointsTypeCode = "2c9d9452ad6e4aaf940814b03e0e4d23c23a88698e04442ab7",
                Points = 759519152,
                ExtendedInformation = "d8a0b51b61a344d9b28e93d3fcc820d85371d6fd0aea497daf01318f9587428db91c96e34cbd4f0e8e63c4b47cb6acdaa02ca9bd6b614ebdab8e3f21960c5d9d0b9cfce5ce5c4c599833ee42d924e611026268a429f3479398b949581670b4e39536d2eb4c114dc6b1f2a8d3282dafdf1d20c5f8f95e4c8f80b196c8d511f73d09a60b2a2a17452584c2b290038d5c68554cf1687ccf4ebfaa73e30e02bc9c3d1697807d2b7a48e4b90def5661dd945cc6571676f9bb41e6a1651c1e878a1b0209bd53a089904b26864c6a703aa20c0e345c4fa1bc6048fd812aa30696c2a484ba8abe80e705453cb1ac67c36d7b9e988b354447692f44bf97c7",
                DateA = new DateTime(2018, 6, 14),
                DateD = new DateTime(2000, 5, 6),
                Sort = 891567660,
                Note = "9dd8dae0ee3042e0a50e468641675e6aad6b208199744e9a9024049fdf0fd8c93c3c27792b3d40918f01bc1543896760b3dce4db16b54f7a97892101c5de3a41edd2f6d137a54c02a7985df0b5933f364d3909b58e05473fbbf9ca7f1f6ca639c1bd170a014b46488be69767b1eb4ae1c5b7194efa2647149b82640daa65776d78ce1aebc1ef40d0bfe35d5857eed056c36328308101462fb1fe5a2cc0429bf3e025f8a8cfb24a4699897bd23f6ba5c0cefb76888bc84fa68f653e030fab7db31815dcaa8bb84ccea0e57835e5c1fdc2dfd1f91675e2415e94b3b39ef2dacc08c7f1a6b0f6c940718ba50c61f7833e5f4c9078bdfd664714b905",
                Status = "cea6d1c6a5ee4368bd6d2bf6009f50b4918941dbf99b4cec8d"
            };

            // Act
            var serviceResult = await _companyPointssAppService.UpdateAsync(Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"), input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f16d3b17-3eb8-4e69-9ff3-a19880133aef"));
            result.CompanyPointsTypeCode.ShouldBe("2c9d9452ad6e4aaf940814b03e0e4d23c23a88698e04442ab7");
            result.Points.ShouldBe(759519152);
            result.ExtendedInformation.ShouldBe("d8a0b51b61a344d9b28e93d3fcc820d85371d6fd0aea497daf01318f9587428db91c96e34cbd4f0e8e63c4b47cb6acdaa02ca9bd6b614ebdab8e3f21960c5d9d0b9cfce5ce5c4c599833ee42d924e611026268a429f3479398b949581670b4e39536d2eb4c114dc6b1f2a8d3282dafdf1d20c5f8f95e4c8f80b196c8d511f73d09a60b2a2a17452584c2b290038d5c68554cf1687ccf4ebfaa73e30e02bc9c3d1697807d2b7a48e4b90def5661dd945cc6571676f9bb41e6a1651c1e878a1b0209bd53a089904b26864c6a703aa20c0e345c4fa1bc6048fd812aa30696c2a484ba8abe80e705453cb1ac67c36d7b9e988b354447692f44bf97c7");
            result.DateA.ShouldBe(new DateTime(2018, 6, 14));
            result.DateD.ShouldBe(new DateTime(2000, 5, 6));
            result.Sort.ShouldBe(891567660);
            result.Note.ShouldBe("9dd8dae0ee3042e0a50e468641675e6aad6b208199744e9a9024049fdf0fd8c93c3c27792b3d40918f01bc1543896760b3dce4db16b54f7a97892101c5de3a41edd2f6d137a54c02a7985df0b5933f364d3909b58e05473fbbf9ca7f1f6ca639c1bd170a014b46488be69767b1eb4ae1c5b7194efa2647149b82640daa65776d78ce1aebc1ef40d0bfe35d5857eed056c36328308101462fb1fe5a2cc0429bf3e025f8a8cfb24a4699897bd23f6ba5c0cefb76888bc84fa68f653e030fab7db31815dcaa8bb84ccea0e57835e5c1fdc2dfd1f91675e2415e94b3b39ef2dacc08c7f1a6b0f6c940718ba50c61f7833e5f4c9078bdfd664714b905");
            result.Status.ShouldBe("cea6d1c6a5ee4368bd6d2bf6009f50b4918941dbf99b4cec8d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyPointssAppService.DeleteAsync(Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"));

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"));

            result.ShouldBeNull();
        }
    }
}