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
            result.Items.Any(x => x.Id == Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("419eaabf-9a3e-441f-9f8d-63ac7e4aae22")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyContractsAppService.GetAsync(Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyContractCreateDto
            {
                CompanyMainId = Guid.Parse("33356162-3baa-4467-a55f-6b2115ea4d12"),
                PlanCode = "bc79276125264972a7542f4f647de802e28f3ba901ce448aab",
                PointsTotal = 641957233,
                PointsPay = 409759206,
                PointsGift = 1195024789,
                ExtendedInformation = "71f72d6872f24b07a40b8bd477741b43f796a074c03b447c93cf1a742368112ab32915dd64fa419aaf5fc99877bfa2cc88a8a02ab5d34c7196d88f135f5a236ded1008ae16db464bb7e516df79dcdbeab29ca7034c7f4aea95997ab261f5d16b8bdaf0ca8e744acfbef31d6fffa1b8e575f6529061d94adb978d7f2d65e0d4af3962f3bb390e4ac9b44459b954b8c9c6566428152a19415e930457385e7045a187611a98def0465eaa8440a26b44d72b728983e3b8ed47398c04a5124543dab8d50ba823dcc34d4e835a86027d9ecb55e9f141ca738f4ed19ad96aa9478cf53cab3bb273a1134fa98ca19c457ae17f51d80b7440536641f1b854",
                DateA = new DateTime(2016, 2, 27),
                DateD = new DateTime(2007, 3, 21),
                Sort = 658018428,
                Note = "5295fd11364b4e198387bd1e30609bc9263736a0be924a58b0d4d6c445a678388851293d988641eea7ed70d8820add7aa76479459d6341b19de198643b938408796be58bf9a341b9b6115d9aa2d1448f0c425765320f4173869dc206680748a1cc9deea24a9b46d691b55d88343070b5a25aca358e4d45acad1596cd7b79c4b176da9755fc7f44ca8d7768c3d29b59a0e0e10bf4d54444cbb31145c2796031f94a3a63c24d2c4b898b7ce707745dd59e4256a9baef2441949f3b9bb11c175f95c07a79fdee91485998bd0a6f85b33000efaafe2e08864661935a58a718ae577a6de9a2e0f67b488cba5173b0a67ea3c7d33dd7ef4e454904a716",
                Status = "113f61a0bc02466dae2ab690c71b003d8d08a96639cd45b9af"
            };

            // Act
            var serviceResult = await _companyContractsAppService.CreateAsync(input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("33356162-3baa-4467-a55f-6b2115ea4d12"));
            result.PlanCode.ShouldBe("bc79276125264972a7542f4f647de802e28f3ba901ce448aab");
            result.PointsTotal.ShouldBe(641957233);
            result.PointsPay.ShouldBe(409759206);
            result.PointsGift.ShouldBe(1195024789);
            result.ExtendedInformation.ShouldBe("71f72d6872f24b07a40b8bd477741b43f796a074c03b447c93cf1a742368112ab32915dd64fa419aaf5fc99877bfa2cc88a8a02ab5d34c7196d88f135f5a236ded1008ae16db464bb7e516df79dcdbeab29ca7034c7f4aea95997ab261f5d16b8bdaf0ca8e744acfbef31d6fffa1b8e575f6529061d94adb978d7f2d65e0d4af3962f3bb390e4ac9b44459b954b8c9c6566428152a19415e930457385e7045a187611a98def0465eaa8440a26b44d72b728983e3b8ed47398c04a5124543dab8d50ba823dcc34d4e835a86027d9ecb55e9f141ca738f4ed19ad96aa9478cf53cab3bb273a1134fa98ca19c457ae17f51d80b7440536641f1b854");
            result.DateA.ShouldBe(new DateTime(2016, 2, 27));
            result.DateD.ShouldBe(new DateTime(2007, 3, 21));
            result.Sort.ShouldBe(658018428);
            result.Note.ShouldBe("5295fd11364b4e198387bd1e30609bc9263736a0be924a58b0d4d6c445a678388851293d988641eea7ed70d8820add7aa76479459d6341b19de198643b938408796be58bf9a341b9b6115d9aa2d1448f0c425765320f4173869dc206680748a1cc9deea24a9b46d691b55d88343070b5a25aca358e4d45acad1596cd7b79c4b176da9755fc7f44ca8d7768c3d29b59a0e0e10bf4d54444cbb31145c2796031f94a3a63c24d2c4b898b7ce707745dd59e4256a9baef2441949f3b9bb11c175f95c07a79fdee91485998bd0a6f85b33000efaafe2e08864661935a58a718ae577a6de9a2e0f67b488cba5173b0a67ea3c7d33dd7ef4e454904a716");
            result.Status.ShouldBe("113f61a0bc02466dae2ab690c71b003d8d08a96639cd45b9af");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyContractUpdateDto()
            {
                CompanyMainId = Guid.Parse("e61789f6-2bf2-4abf-9fb1-4f3735b4fa94"),
                PlanCode = "60aed3e7e2244415afe8d858baa6e91f3a6d76806ff0416b96",
                PointsTotal = 546656289,
                PointsPay = 352889427,
                PointsGift = 796052209,
                ExtendedInformation = "f5db8cc7e37d4f738d66a7ec078add0a769e1982ec4c43c388c5a27c43337fa9468066f552594dfcbb71c546a26df283d03706441eb448f9bcdab53a28a213575176371ce57a40bb83841341e9b5e06fc41286600393402eac732b44814fa1fbd7f444190f52456e94439d8717a08a1b318848cb598a4b10a93790f3e26648ff0df1bc8aadbc4598b5569139e7fff5d4e760a36c6645417792b252a5b48fbcaa1ce9cabe42a44835a2cb256cd004f8348f57120844ab4382a87993f0440b221c8fb9fe6a4ad54f1991a58c7d39b5d69444b7188702184b3e806898acfeb7f8b6a56b20d2c74e475f8701ab5721ebd471f1f32927218149139d75",
                DateA = new DateTime(2016, 3, 13),
                DateD = new DateTime(2016, 9, 17),
                Sort = 2054508796,
                Note = "27bb24c359d840fe9040e2a0d51d8c8f01b07b2bbe274e0ebb64c7821280987921373c904b474443b3306fee5b3a092ca391c9c5094c4b8bafbed54b1ef7827645c198b6bd6b4dc6b5955657764cf51c5981e1dae63045c6b3d84ee5fd1ae973a77a1734cb1241029095692bb24742caf08012ff18cc4e84b760e7d7a6c0915d6bde55926bb142dcb8bfe2ed6cbfcd38c09a0e1351634560aa2de48eb64c87384dfed71aaa1e45ddab99323eb52956eb67c13ee59e524df7bc8a4f6869c89cc832f26fbe01cd42cc899ec9352cc2dcecc54ae0bfe4bc4e0d834d73fa5b3fa2d3e1154d9bfe2a4799bafe8950f75ef27b929dc85f97e143f9b4ee",
                Status = "e201de9feef548929079fcce194b4d193eb6f7a4f31443c1bf"
            };

            // Act
            var serviceResult = await _companyContractsAppService.UpdateAsync(Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"), input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("e61789f6-2bf2-4abf-9fb1-4f3735b4fa94"));
            result.PlanCode.ShouldBe("60aed3e7e2244415afe8d858baa6e91f3a6d76806ff0416b96");
            result.PointsTotal.ShouldBe(546656289);
            result.PointsPay.ShouldBe(352889427);
            result.PointsGift.ShouldBe(796052209);
            result.ExtendedInformation.ShouldBe("f5db8cc7e37d4f738d66a7ec078add0a769e1982ec4c43c388c5a27c43337fa9468066f552594dfcbb71c546a26df283d03706441eb448f9bcdab53a28a213575176371ce57a40bb83841341e9b5e06fc41286600393402eac732b44814fa1fbd7f444190f52456e94439d8717a08a1b318848cb598a4b10a93790f3e26648ff0df1bc8aadbc4598b5569139e7fff5d4e760a36c6645417792b252a5b48fbcaa1ce9cabe42a44835a2cb256cd004f8348f57120844ab4382a87993f0440b221c8fb9fe6a4ad54f1991a58c7d39b5d69444b7188702184b3e806898acfeb7f8b6a56b20d2c74e475f8701ab5721ebd471f1f32927218149139d75");
            result.DateA.ShouldBe(new DateTime(2016, 3, 13));
            result.DateD.ShouldBe(new DateTime(2016, 9, 17));
            result.Sort.ShouldBe(2054508796);
            result.Note.ShouldBe("27bb24c359d840fe9040e2a0d51d8c8f01b07b2bbe274e0ebb64c7821280987921373c904b474443b3306fee5b3a092ca391c9c5094c4b8bafbed54b1ef7827645c198b6bd6b4dc6b5955657764cf51c5981e1dae63045c6b3d84ee5fd1ae973a77a1734cb1241029095692bb24742caf08012ff18cc4e84b760e7d7a6c0915d6bde55926bb142dcb8bfe2ed6cbfcd38c09a0e1351634560aa2de48eb64c87384dfed71aaa1e45ddab99323eb52956eb67c13ee59e524df7bc8a4f6869c89cc832f26fbe01cd42cc899ec9352cc2dcecc54ae0bfe4bc4e0d834d73fa5b3fa2d3e1154d9bfe2a4799bafe8950f75ef27b929dc85f97e143f9b4ee");
            result.Status.ShouldBe("e201de9feef548929079fcce194b4d193eb6f7a4f31443c1bf");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyContractsAppService.DeleteAsync(Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"));

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"));

            result.ShouldBeNull();
        }
    }
}