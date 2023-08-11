using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyContracts
{
    public class CompanyContractsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyContractsAppService _companyContractsAppService;
        private readonly IRepository<CompanyContract, Guid> _companyContractRepository;

        public CompanyContractsAppServiceTests()
        {
            _companyContractsAppService = GetRequiredService<ICompanyContractsAppService>();
            _companyContractRepository = GetRequiredService<IRepository<CompanyContract, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyContractsAppService.GetListAsync(new GetCompanyContractsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("7241cdc8-9e25-4259-9bcd-64fbf5acafbf")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyContractsAppService.GetAsync(Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyContractCreateDto
            {
                CompanyMainId = Guid.Parse("131abc1a-ff98-4d8b-bffd-87fbb66f59ba"),
                PlanCode = "6b299aea1deb41e58e0408acd88fd93a70be7e4d1c6545e3b0",
                PointsTotal = 1931161247,
                PointsPay = 2094027166,
                PointsGift = 197500100,
                ExtendedInformation = "c877515e581143939bd2d6f828cdcad3990759ab3bad4c9898c8e72bea44dfb781472f2335434485be9e3d7f60031a017e29880de07b4de68c3ed84daa8b18b42781175556bd4ff59143c4fb6570955990d7638e859048a2a68adb95b10ae0e6a3c9cbf37b804c93ae14ef6153957b0a8c7cc41bf4724befac0188aa08fdc3bfaba308b232b5407da5a2f92aea51b56b1f3197bc502a4a55a446b9873c264fd5b6973c43055a43b0b992dfc77dfec90418b9af4d878649198ad12325f874ef8ced1f9e29ade54212a9798cb8070de5a2da2470e63a2d455f9d388edf35062b5b12965843ca9548bba97ef919a9b4679019aadb291405415a9b85",
                DateA = new DateTime(2018, 5, 22),
                DateD = new DateTime(2001, 4, 4),
                Sort = 1823538711,
                Note = "352b5a191b774bd481352fa762327ef7e625a726c8f64018a5ed40b19422f2584e69fa1ee5b64c67be76e35908da256b9cb8865239f24dd6aba6139228eca5171b3a6f72865643d295a98db6d5156ee1b56f809957b6444585297e6f653e320c72dbd961df4042a8be1c10180adaf1fa097db62422c24848baf0bb46d8e2eb2a2038cec57f324273a93332a54f1cd8213e34433be1464ecf94690f62d62744764ebf404dfae6499b9650cb8afdd9911d36feaa4c6505472f93ba318e242e0af266d424320b7d4b7ba87e3b19f2bdc9816a0e03d63346440889c45bedca25da8c660dee53264b4e8383ae7cf2018bf21c31e9ba5d22834ff4ace8",
                Status = "f294eff0edc744a18549ae4a1727b345ea643fdd54644e04b2"
            };

            // Act
            var serviceResult = await _companyContractsAppService.CreateAsync(input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("131abc1a-ff98-4d8b-bffd-87fbb66f59ba"));
            result.PlanCode.ShouldBe("6b299aea1deb41e58e0408acd88fd93a70be7e4d1c6545e3b0");
            result.PointsTotal.ShouldBe(1931161247);
            result.PointsPay.ShouldBe(2094027166);
            result.PointsGift.ShouldBe(197500100);
            result.ExtendedInformation.ShouldBe("c877515e581143939bd2d6f828cdcad3990759ab3bad4c9898c8e72bea44dfb781472f2335434485be9e3d7f60031a017e29880de07b4de68c3ed84daa8b18b42781175556bd4ff59143c4fb6570955990d7638e859048a2a68adb95b10ae0e6a3c9cbf37b804c93ae14ef6153957b0a8c7cc41bf4724befac0188aa08fdc3bfaba308b232b5407da5a2f92aea51b56b1f3197bc502a4a55a446b9873c264fd5b6973c43055a43b0b992dfc77dfec90418b9af4d878649198ad12325f874ef8ced1f9e29ade54212a9798cb8070de5a2da2470e63a2d455f9d388edf35062b5b12965843ca9548bba97ef919a9b4679019aadb291405415a9b85");
            result.DateA.ShouldBe(new DateTime(2018, 5, 22));
            result.DateD.ShouldBe(new DateTime(2001, 4, 4));
            result.Sort.ShouldBe(1823538711);
            result.Note.ShouldBe("352b5a191b774bd481352fa762327ef7e625a726c8f64018a5ed40b19422f2584e69fa1ee5b64c67be76e35908da256b9cb8865239f24dd6aba6139228eca5171b3a6f72865643d295a98db6d5156ee1b56f809957b6444585297e6f653e320c72dbd961df4042a8be1c10180adaf1fa097db62422c24848baf0bb46d8e2eb2a2038cec57f324273a93332a54f1cd8213e34433be1464ecf94690f62d62744764ebf404dfae6499b9650cb8afdd9911d36feaa4c6505472f93ba318e242e0af266d424320b7d4b7ba87e3b19f2bdc9816a0e03d63346440889c45bedca25da8c660dee53264b4e8383ae7cf2018bf21c31e9ba5d22834ff4ace8");
            result.Status.ShouldBe("f294eff0edc744a18549ae4a1727b345ea643fdd54644e04b2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyContractUpdateDto()
            {
                CompanyMainId = Guid.Parse("08ecca5f-b8a4-4191-9202-9fb4f9f937f9"),
                PlanCode = "a2455705c36a4aedbc9675678a542abbb8e49f6dd33c4e2b8f",
                PointsTotal = 256031590,
                PointsPay = 1005205595,
                PointsGift = 1640855127,
                ExtendedInformation = "400233e9eea645bdb02e2f4cae5c61feea806c736b744e65b420008d98a63237935daf11180a440484a09b99b986295c16471e54d0904628bc32c815d1f92126207e9e35757a48fbb27ecd74f3d9e7af0044cf312cb64eb89af99122f35b2479a3c1fc63951e46f8ace924bff02ac88efd97f552fb9247108b5094d6636c58afe7a0edd30e4742aaa5e4d5b67dcc85384bc78d1c758d442399ec7ecead80f7f18cd27f754e464bf383deb724f5cf7ec26ed6fa9f6d624c6f86580a64937d258cb557d58d762b408ca0e8953e25d65e949a937278c9c247c98dac0f0014e9170122e1f9119ac14e44bde524292f513a5e00e10860a9014713ae79",
                DateA = new DateTime(2022, 2, 19),
                DateD = new DateTime(2021, 5, 13),
                Sort = 1130595644,
                Note = "ab6d9149c8f04b37a2304705d5566d67a6e69d5d1b64411ba9abc4b8a82dd3b60602338ebc204ad192c42873e8e754d701a953e5f37f47fda8300facedf7917cf7f8ab6599204c12ae28edd2dea4f0af44d8af4e2c85474692cf61c62e8d4cd05da4f20163f74dd491cc34859aa57d0485ddac39f0f148948b28abae1dd13fbeca8275db9a424521bdcb27a5b72b72c2606e88fa13d64f5cb5e601cd8b6eb573322537ee445f486a91e60cc7322cc85e547de29ab61b4bbdad8be69b9140fbf405eb1f6750f4413697cd839c3c200c6ecc49c721f15c4192b2af9c44a55dc6192359840e951940c2b0d38bb425fc5481e5adc5bc971b4a6bb484",
                Status = "38dc26f938234d74a820b56232c1e46feda75b1d507948ef8f"
            };

            // Act
            var serviceResult = await _companyContractsAppService.UpdateAsync(Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"), input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("08ecca5f-b8a4-4191-9202-9fb4f9f937f9"));
            result.PlanCode.ShouldBe("a2455705c36a4aedbc9675678a542abbb8e49f6dd33c4e2b8f");
            result.PointsTotal.ShouldBe(256031590);
            result.PointsPay.ShouldBe(1005205595);
            result.PointsGift.ShouldBe(1640855127);
            result.ExtendedInformation.ShouldBe("400233e9eea645bdb02e2f4cae5c61feea806c736b744e65b420008d98a63237935daf11180a440484a09b99b986295c16471e54d0904628bc32c815d1f92126207e9e35757a48fbb27ecd74f3d9e7af0044cf312cb64eb89af99122f35b2479a3c1fc63951e46f8ace924bff02ac88efd97f552fb9247108b5094d6636c58afe7a0edd30e4742aaa5e4d5b67dcc85384bc78d1c758d442399ec7ecead80f7f18cd27f754e464bf383deb724f5cf7ec26ed6fa9f6d624c6f86580a64937d258cb557d58d762b408ca0e8953e25d65e949a937278c9c247c98dac0f0014e9170122e1f9119ac14e44bde524292f513a5e00e10860a9014713ae79");
            result.DateA.ShouldBe(new DateTime(2022, 2, 19));
            result.DateD.ShouldBe(new DateTime(2021, 5, 13));
            result.Sort.ShouldBe(1130595644);
            result.Note.ShouldBe("ab6d9149c8f04b37a2304705d5566d67a6e69d5d1b64411ba9abc4b8a82dd3b60602338ebc204ad192c42873e8e754d701a953e5f37f47fda8300facedf7917cf7f8ab6599204c12ae28edd2dea4f0af44d8af4e2c85474692cf61c62e8d4cd05da4f20163f74dd491cc34859aa57d0485ddac39f0f148948b28abae1dd13fbeca8275db9a424521bdcb27a5b72b72c2606e88fa13d64f5cb5e601cd8b6eb573322537ee445f486a91e60cc7322cc85e547de29ab61b4bbdad8be69b9140fbf405eb1f6750f4413697cd839c3c200c6ecc49c721f15c4192b2af9c44a55dc6192359840e951940c2b0d38bb425fc5481e5adc5bc971b4a6bb484");
            result.Status.ShouldBe("38dc26f938234d74a820b56232c1e46feda75b1d507948ef8f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyContractsAppService.DeleteAsync(Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"));

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"));

            result.ShouldBeNull();
        }
    }
}