using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoriesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobDisabilityCategoriesAppService _companyJobDisabilityCategoriesAppService;
        private readonly IRepository<CompanyJobDisabilityCategory, Guid> _companyJobDisabilityCategoryRepository;

        public CompanyJobDisabilityCategoriesAppServiceTests()
        {
            _companyJobDisabilityCategoriesAppService = GetRequiredService<ICompanyJobDisabilityCategoriesAppService>();
            _companyJobDisabilityCategoryRepository = GetRequiredService<IRepository<CompanyJobDisabilityCategory, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobDisabilityCategoriesAppService.GetListAsync(new GetCompanyJobDisabilityCategoriesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("53e66dda-7799-406e-b139-021069e0b337")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2bd583e5-fbab-4a33-a8ee-be0102fd8b57")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDisabilityCategoriesAppService.GetAsync(Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryCreateDto
            {
                CompanyMainId = Guid.Parse("0557a604-3de1-44f7-8628-aa09575ea2fd"),
                CompanyJobId = Guid.Parse("1061c628-4dc6-40cb-886a-55d2b1e91bfa"),
                DisabilityCategoryCode = "3a40990437c64d6da1e30f5ca5b40961642d9c6bc96c464087",
                DisabilityLevelCode = "10f519b53864475bb03526abca032921f0dc70d92d304d0894",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "6df3f04c41d84a52939fac96271992b561880671a1cc46d7afaef1a892fc411a3a96e422861343278c28fa60aae6551c31f75d1ec6c9496d839f16880f6416449ab99f6c80484b4190920fd925f28d9e9aa913d73df9433dadcd29c3244203035d710bf038a948d69653879b1b2984406961d1825299484385153a01a31239174d156ed33faa42c4966c4b071c1f8c7c6b877c1acd8d4b08a1e62c60ac5fb9745ec0c3bd76c14a7e945e04671041ef2e9c32920b8e624838ab2d4666e0e3925328105233c0a649458032a8c8b18b771943afbe0a4c02454cb108a565b7e7fbbf8752e9201d55464a916d521f14237c5414f9949ee388467dada1",
                DateA = new DateTime(2007, 2, 18),
                DateD = new DateTime(2004, 5, 24),
                Sort = 477793166,
                Note = "2f6b50d29a3846c48bf236fdb056a03ad226a5af693d4afe84f7871831bb7ec5fc553a525b334f56a37d9847f64c9fa09d339f1bf9494f8695a425f1d2228a5488377df96ff640d9aa03ce1f6b36304e298b703045804b49b15a47b699ef84b22f642806b8fc40e790581e5e64713148bcc4538369494da9adabfa535b07683358cc2f9f288543a8ad84dd55c0c29dc220b0264851b74015b586e06e725eba34a39d065e3ca54ff2898f3c779ca180eff1be0b0fb4794bddaf9595fc700b9842fce20a88fd3f45d68f754094538a1693a657bf585ff5462b8f0beaf28d59c27f8abe79863e5447d0a02fcccb76c718520059c09abe8a4f19a6a8",
                Status = "3c1f073d4e0145e2878fba97626269a6a55f7e384d4e4b90bc"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("0557a604-3de1-44f7-8628-aa09575ea2fd"));
            result.CompanyJobId.ShouldBe(Guid.Parse("1061c628-4dc6-40cb-886a-55d2b1e91bfa"));
            result.DisabilityCategoryCode.ShouldBe("3a40990437c64d6da1e30f5ca5b40961642d9c6bc96c464087");
            result.DisabilityLevelCode.ShouldBe("10f519b53864475bb03526abca032921f0dc70d92d304d0894");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("6df3f04c41d84a52939fac96271992b561880671a1cc46d7afaef1a892fc411a3a96e422861343278c28fa60aae6551c31f75d1ec6c9496d839f16880f6416449ab99f6c80484b4190920fd925f28d9e9aa913d73df9433dadcd29c3244203035d710bf038a948d69653879b1b2984406961d1825299484385153a01a31239174d156ed33faa42c4966c4b071c1f8c7c6b877c1acd8d4b08a1e62c60ac5fb9745ec0c3bd76c14a7e945e04671041ef2e9c32920b8e624838ab2d4666e0e3925328105233c0a649458032a8c8b18b771943afbe0a4c02454cb108a565b7e7fbbf8752e9201d55464a916d521f14237c5414f9949ee388467dada1");
            result.DateA.ShouldBe(new DateTime(2007, 2, 18));
            result.DateD.ShouldBe(new DateTime(2004, 5, 24));
            result.Sort.ShouldBe(477793166);
            result.Note.ShouldBe("2f6b50d29a3846c48bf236fdb056a03ad226a5af693d4afe84f7871831bb7ec5fc553a525b334f56a37d9847f64c9fa09d339f1bf9494f8695a425f1d2228a5488377df96ff640d9aa03ce1f6b36304e298b703045804b49b15a47b699ef84b22f642806b8fc40e790581e5e64713148bcc4538369494da9adabfa535b07683358cc2f9f288543a8ad84dd55c0c29dc220b0264851b74015b586e06e725eba34a39d065e3ca54ff2898f3c779ca180eff1be0b0fb4794bddaf9595fc700b9842fce20a88fd3f45d68f754094538a1693a657bf585ff5462b8f0beaf28d59c27f8abe79863e5447d0a02fcccb76c718520059c09abe8a4f19a6a8");
            result.Status.ShouldBe("3c1f073d4e0145e2878fba97626269a6a55f7e384d4e4b90bc");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryUpdateDto()
            {
                CompanyMainId = Guid.Parse("f2e27aec-3eee-4bbe-87d5-0fae85eb9480"),
                CompanyJobId = Guid.Parse("f1ee7229-e57b-4785-a773-e0a73510dffe"),
                DisabilityCategoryCode = "4d3761aa651344d5a29dc161075495bc1cda31d7c99b40f7a0",
                DisabilityLevelCode = "3da7307872b5475284380cf6e94947b1a5345aa6b4c14b4f8f",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "a9c623d0a2224a04b6db83a9a95cc8f6fa878e7358404aeba4da7f37d710ac8b92c6f110c0854a8e8b27faf6dede8dfae2603e94242f40059cca0b5e796a3153343b8d261aea4e0dae415d868b15e32c8d6eff604b8c48c2bbfe10dfc6d54ca7841a1994e8bc40258292bc7e5ef1d8408e9d46ab4c4c43db9d8cad56825fe5ed003540cdf262434e9b8dde5a5c052b07c4e5b16a82b44a0cb6c86926fb188b95db94a70db96a485ca01f7dec519cb2732b02829db12741759c82b668b5c6bbad2d60928a0a8f498ea0a473c25f04964c0678505dc8984b7b86316e966414ba95f1f71f8ce2204f169ae4891982144dea8773a53637604584bd28",
                DateA = new DateTime(2009, 7, 26),
                DateD = new DateTime(2003, 4, 3),
                Sort = 362032555,
                Note = "e8137df2a44844cb904d97e76febeab2012b90cd06a34f27b9ebc01264aa4c836d5a82f1c8ac4c5aa845766a73af00d698e00c247b7942b48545392aa8810490584a2e8595f242c4a75b2a8e2cff3372906e34f2d4af49de916415f9ccb79dd909be50f3df9b41429006725fc69d475fda136d61675a4382a4dd9be2ec27346719657070a1434b419db6d9b4df231a6a6aac87f179ae43da9f8a9f379234c07b2671958ee9de46e28937ec577780d53287059373f7db4a65a869d5e1004ef088091edc90cac64baab8375a8c69db011a776c1c352dc94ed7ac15942cb0a2e370c88a7526bbf44d67be4fb17f4980b6dcb86d27a2ca4e40039430",
                Status = "b76f913d07d748798d5dfd2c1b326d9a10b4d65c7f604d1fa0"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.UpdateAsync(Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"), input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f2e27aec-3eee-4bbe-87d5-0fae85eb9480"));
            result.CompanyJobId.ShouldBe(Guid.Parse("f1ee7229-e57b-4785-a773-e0a73510dffe"));
            result.DisabilityCategoryCode.ShouldBe("4d3761aa651344d5a29dc161075495bc1cda31d7c99b40f7a0");
            result.DisabilityLevelCode.ShouldBe("3da7307872b5475284380cf6e94947b1a5345aa6b4c14b4f8f");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("a9c623d0a2224a04b6db83a9a95cc8f6fa878e7358404aeba4da7f37d710ac8b92c6f110c0854a8e8b27faf6dede8dfae2603e94242f40059cca0b5e796a3153343b8d261aea4e0dae415d868b15e32c8d6eff604b8c48c2bbfe10dfc6d54ca7841a1994e8bc40258292bc7e5ef1d8408e9d46ab4c4c43db9d8cad56825fe5ed003540cdf262434e9b8dde5a5c052b07c4e5b16a82b44a0cb6c86926fb188b95db94a70db96a485ca01f7dec519cb2732b02829db12741759c82b668b5c6bbad2d60928a0a8f498ea0a473c25f04964c0678505dc8984b7b86316e966414ba95f1f71f8ce2204f169ae4891982144dea8773a53637604584bd28");
            result.DateA.ShouldBe(new DateTime(2009, 7, 26));
            result.DateD.ShouldBe(new DateTime(2003, 4, 3));
            result.Sort.ShouldBe(362032555);
            result.Note.ShouldBe("e8137df2a44844cb904d97e76febeab2012b90cd06a34f27b9ebc01264aa4c836d5a82f1c8ac4c5aa845766a73af00d698e00c247b7942b48545392aa8810490584a2e8595f242c4a75b2a8e2cff3372906e34f2d4af49de916415f9ccb79dd909be50f3df9b41429006725fc69d475fda136d61675a4382a4dd9be2ec27346719657070a1434b419db6d9b4df231a6a6aac87f179ae43da9f8a9f379234c07b2671958ee9de46e28937ec577780d53287059373f7db4a65a869d5e1004ef088091edc90cac64baab8375a8c69db011a776c1c352dc94ed7ac15942cb0a2e370c88a7526bbf44d67be4fb17f4980b6dcb86d27a2ca4e40039430");
            result.Status.ShouldBe("b76f913d07d748798d5dfd2c1b326d9a10b4d65c7f604d1fa0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDisabilityCategoriesAppService.DeleteAsync(Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"));

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"));

            result.ShouldBeNull();
        }
    }
}