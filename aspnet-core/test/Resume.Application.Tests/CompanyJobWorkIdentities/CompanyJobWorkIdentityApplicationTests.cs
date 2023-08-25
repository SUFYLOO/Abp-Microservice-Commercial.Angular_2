using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentitiesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobWorkIdentitiesAppService _companyJobWorkIdentitiesAppService;
        private readonly IRepository<CompanyJobWorkIdentity, Guid> _companyJobWorkIdentityRepository;

        public CompanyJobWorkIdentitiesAppServiceTests()
        {
            _companyJobWorkIdentitiesAppService = GetRequiredService<ICompanyJobWorkIdentitiesAppService>();
            _companyJobWorkIdentityRepository = GetRequiredService<IRepository<CompanyJobWorkIdentity, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobWorkIdentitiesAppService.GetListAsync(new GetCompanyJobWorkIdentitiesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c42e6b9c-d706-4371-9510-be908dbcc2c2")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobWorkIdentitiesAppService.GetAsync(Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityCreateDto
            {
                CompanyMainId = Guid.Parse("4fe833a4-8ee1-4319-8114-5ffd919b1351"),
                CompanyJobId = Guid.Parse("9c24423f-db46-4398-b394-49bea5680865"),
                WorkIdentityCode = "bd48c503b3264c688895b295f603aa74733aabf71f5e42fe84",
                ExtendedInformation = "ff32212f514a4a70af9d9e22def3d38fc15b97024fe14a5fb3ffd346bd36a007b5b6c78df0ea424da8dcdc6a14b1e8d9ee6ca691b8ec42dea659caea31968442acba047fe0a143c6b30a18185ebaf5e37c4f9300e4df4ebfb0d7d5d8cf471621e5d6da8229b741bca0b6d0df88f29ac64bce01484caf4084ab49a92e4c848e96c88d54132f5a4578ac8bf91ad8fe0c897944e0a271fd41e5b224eed7514ad3d0a57c177cc7634a6d8d5b0b0f4d0ed6db419e60598df549ea8b1546184704f414bf3786990426438d9356496cb93ba96170674889311247f289b1108b584969ef2c71a61b1bb4455a87130f784618d77d97b43d4ce76f4177bac8",
                DateA = new DateTime(2001, 10, 6),
                DateD = new DateTime(2016, 5, 24),
                Sort = 1476375303,
                Note = "2c48724baddb4e739571f06e724bf27d29c9c00d62a243d09581d66989d7b913cf0a41d2be5d4723921e025c0d2476c36fb18f02e94940a8b85d022b87b3d74910b6341ee13f4e5c9cf39691afc60c27fe9113c409e4414592df9e130e14f802441e22edda3f4bf7ac0a9223e4a015e074804e6bf49142178dc156eb38b98a7a83457a6bda734b0e858534b0925771b0d731f552a6a940cabacadcb33554a27a61af2e70c6cb4e8f9734256337741428596aff406c56436984f8c8516f68b0bd5183c25e492d407e95c4dd16483f55c2dc63e24a26b24824a230875d8ea4b5572815e9f2cbf841b0af250f79d89d84863fe485ad391c4ed09233",
                Status = "631c82afc0bc4b1884a8f110514d26f475bf41d955604012a2"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("4fe833a4-8ee1-4319-8114-5ffd919b1351"));
            result.CompanyJobId.ShouldBe(Guid.Parse("9c24423f-db46-4398-b394-49bea5680865"));
            result.WorkIdentityCode.ShouldBe("bd48c503b3264c688895b295f603aa74733aabf71f5e42fe84");
            result.ExtendedInformation.ShouldBe("ff32212f514a4a70af9d9e22def3d38fc15b97024fe14a5fb3ffd346bd36a007b5b6c78df0ea424da8dcdc6a14b1e8d9ee6ca691b8ec42dea659caea31968442acba047fe0a143c6b30a18185ebaf5e37c4f9300e4df4ebfb0d7d5d8cf471621e5d6da8229b741bca0b6d0df88f29ac64bce01484caf4084ab49a92e4c848e96c88d54132f5a4578ac8bf91ad8fe0c897944e0a271fd41e5b224eed7514ad3d0a57c177cc7634a6d8d5b0b0f4d0ed6db419e60598df549ea8b1546184704f414bf3786990426438d9356496cb93ba96170674889311247f289b1108b584969ef2c71a61b1bb4455a87130f784618d77d97b43d4ce76f4177bac8");
            result.DateA.ShouldBe(new DateTime(2001, 10, 6));
            result.DateD.ShouldBe(new DateTime(2016, 5, 24));
            result.Sort.ShouldBe(1476375303);
            result.Note.ShouldBe("2c48724baddb4e739571f06e724bf27d29c9c00d62a243d09581d66989d7b913cf0a41d2be5d4723921e025c0d2476c36fb18f02e94940a8b85d022b87b3d74910b6341ee13f4e5c9cf39691afc60c27fe9113c409e4414592df9e130e14f802441e22edda3f4bf7ac0a9223e4a015e074804e6bf49142178dc156eb38b98a7a83457a6bda734b0e858534b0925771b0d731f552a6a940cabacadcb33554a27a61af2e70c6cb4e8f9734256337741428596aff406c56436984f8c8516f68b0bd5183c25e492d407e95c4dd16483f55c2dc63e24a26b24824a230875d8ea4b5572815e9f2cbf841b0af250f79d89d84863fe485ad391c4ed09233");
            result.Status.ShouldBe("631c82afc0bc4b1884a8f110514d26f475bf41d955604012a2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityUpdateDto()
            {
                CompanyMainId = Guid.Parse("940fbb1c-5e77-42da-b2bf-d26fa528f6f4"),
                CompanyJobId = Guid.Parse("04a9ddd9-be0f-40b9-9229-afc77dc7da0b"),
                WorkIdentityCode = "f836c47c1ffb42cabdabffb6391415d45f3ed9d795a94f74b2",
                ExtendedInformation = "af712a5af6d84e9bb01a1069ee29bcbef7e20fd9a55e412789180c11084fb6c0fee8b99111c64cf5835a135005487c0fd04c2b8264264348b626d28ed4593afc467fa418008c49ca914433c87e0909f4ee6286ed0b1d4abdb8c3d722a8de9af09655b3d463c64d189fcd32664a4b672fe2fb0cb0c3d54404a00645b420527d8c36f91fad87214adbae73865c13ae6df32af66d2cc5174d7f86cdc8edd06ad241a5c6e3ae2e9d48efb72db0fb801c7b6ea68abdaf029d4d959c5efb0f35d7861729df8f21f7d3459e82c4d4ff5920e3877237d355bfa744e785ee50b0bd70006d381ffe04575e4b929cf4049750d9d5446164cbb2d6274137a0cc",
                DateA = new DateTime(2018, 2, 16),
                DateD = new DateTime(2016, 1, 12),
                Sort = 471567845,
                Note = "9bfc396efa8949dd83579d189da5a998ff7428315da14baaa16221999416ca3235b693f0b5234461988e7e7280f8e708824fc49e64b94c908dc8b6159e776fd8d923666daa4d4f9381bafb30bbbe2ee688590f5c274e4042a016bec98a62918be816030abbbb4a41bd73780b4fb72e4e3b84a0c551a24ab3890aa8c2305c032456ffe73e0c1d473daabc2dbbaef6d938791c92af16c746748c8af0905910237de045f550566a4e0f9f239342c7d3b426a919268da448409e947bb669de00c6fb77a07eae7f06405e9005b82d69ce42bc76c5444d83b44c74bc8c7e9d3c3f609c22467dd748e14a6da5245e3308b745bd1cf1b3020e7f4e3a9b4f",
                Status = "c175c457ac2341aa9d7d3dbcead58e8aff6a709af37149549b"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.UpdateAsync(Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"), input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("940fbb1c-5e77-42da-b2bf-d26fa528f6f4"));
            result.CompanyJobId.ShouldBe(Guid.Parse("04a9ddd9-be0f-40b9-9229-afc77dc7da0b"));
            result.WorkIdentityCode.ShouldBe("f836c47c1ffb42cabdabffb6391415d45f3ed9d795a94f74b2");
            result.ExtendedInformation.ShouldBe("af712a5af6d84e9bb01a1069ee29bcbef7e20fd9a55e412789180c11084fb6c0fee8b99111c64cf5835a135005487c0fd04c2b8264264348b626d28ed4593afc467fa418008c49ca914433c87e0909f4ee6286ed0b1d4abdb8c3d722a8de9af09655b3d463c64d189fcd32664a4b672fe2fb0cb0c3d54404a00645b420527d8c36f91fad87214adbae73865c13ae6df32af66d2cc5174d7f86cdc8edd06ad241a5c6e3ae2e9d48efb72db0fb801c7b6ea68abdaf029d4d959c5efb0f35d7861729df8f21f7d3459e82c4d4ff5920e3877237d355bfa744e785ee50b0bd70006d381ffe04575e4b929cf4049750d9d5446164cbb2d6274137a0cc");
            result.DateA.ShouldBe(new DateTime(2018, 2, 16));
            result.DateD.ShouldBe(new DateTime(2016, 1, 12));
            result.Sort.ShouldBe(471567845);
            result.Note.ShouldBe("9bfc396efa8949dd83579d189da5a998ff7428315da14baaa16221999416ca3235b693f0b5234461988e7e7280f8e708824fc49e64b94c908dc8b6159e776fd8d923666daa4d4f9381bafb30bbbe2ee688590f5c274e4042a016bec98a62918be816030abbbb4a41bd73780b4fb72e4e3b84a0c551a24ab3890aa8c2305c032456ffe73e0c1d473daabc2dbbaef6d938791c92af16c746748c8af0905910237de045f550566a4e0f9f239342c7d3b426a919268da448409e947bb669de00c6fb77a07eae7f06405e9005b82d69ce42bc76c5444d83b44c74bc8c7e9d3c3f609c22467dd748e14a6da5245e3308b745bd1cf1b3020e7f4e3a9b4f");
            result.Status.ShouldBe("c175c457ac2341aa9d7d3dbcead58e8aff6a709af37149549b");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobWorkIdentitiesAppService.DeleteAsync(Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"));

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"));

            result.ShouldBeNull();
        }
    }
}