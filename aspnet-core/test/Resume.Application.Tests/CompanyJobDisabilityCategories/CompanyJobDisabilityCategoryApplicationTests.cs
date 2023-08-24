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
            result.Items.Any(x => x.Id == Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("aaa36cea-0b02-47d6-953d-68af77191ab1")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDisabilityCategoriesAppService.GetAsync(Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryCreateDto
            {
                CompanyMainId = Guid.Parse("f3a93756-0053-4cbe-88c0-1a3e8a60a878"),
                CompanyJobId = Guid.Parse("4ff9f338-3d13-4f67-bcf9-aee18a1281b1"),
                DisabilityCategoryCode = "f4e59628ce9b49f4a69a1d762187d1f8f201e817049f4e499a",
                DisabilityLevelCode = "501a60f4c6524f6293ec73d4cf9c6ba6e9355d6adc324d8bab",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "667dea442158459486ee5bc8d116c2e8c40140c46ed344398bef64a30964335b19c25ae7e9df47f2a6ad622f1202d14e7083daa9f71f48e7be7e335f44f9a91b93943af552d64097b56dcf5471a7039515b0f83750554819bdff0252f6ecc60de036baa855c34a8c8c5c6cc72881654a2a1da8a833a64532a663a78e68c08db7b2c41fe4672744cbadfc4f87b2f987bc58e9204fbe8844ddacfa28b12c783a001a1961614ecf40afb68fd421d699cc80db5891bd5c194a49a11332293bea8b95ec891ad597a74f64be10d49422dd4e8a93938fac7ee74af08ec115ee237775c5f8c17129a6184b54b4b677d3b6c3f958d36809bbb01b409f95ae",
                DateA = new DateTime(2021, 1, 26),
                DateD = new DateTime(2010, 9, 11),
                Sort = 724237710,
                Note = "d33b75c1fd3143e197639cb5e3b700ed72709747733b42e58f688830e5eaa4f403860233deca426e82cf3595f3c9ddce9b3c8f4f0c934164a1181f58fccdb31a1e26c1e18a00493d895c9e3d88d78375306e664476cd4971a6c6c547ba75bc10ec78f82e16fa4ebb8724f3379ec90ee34930746091784a0bad1110e06dff1078f621a7a90e7e41138dbad5dced25cfb3aad8f5ab77dc4ea6b5cbd3419289834c803ba0207a89433da54e45e1d0267d59d8c6cffd2e0242b395c393a1a67b493b9ec1249ec597453e9528e7ffe4e75f1ef9e3ee30aafb49e9bfdca13273381321d6d7b1013f414f1c88bf2dbaff6ee9568dc6bf3f3209498287f9",
                Status = "69304ec03f4b4b95a5a02bc4a837208d18242894c2254d57ae"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f3a93756-0053-4cbe-88c0-1a3e8a60a878"));
            result.CompanyJobId.ShouldBe(Guid.Parse("4ff9f338-3d13-4f67-bcf9-aee18a1281b1"));
            result.DisabilityCategoryCode.ShouldBe("f4e59628ce9b49f4a69a1d762187d1f8f201e817049f4e499a");
            result.DisabilityLevelCode.ShouldBe("501a60f4c6524f6293ec73d4cf9c6ba6e9355d6adc324d8bab");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("667dea442158459486ee5bc8d116c2e8c40140c46ed344398bef64a30964335b19c25ae7e9df47f2a6ad622f1202d14e7083daa9f71f48e7be7e335f44f9a91b93943af552d64097b56dcf5471a7039515b0f83750554819bdff0252f6ecc60de036baa855c34a8c8c5c6cc72881654a2a1da8a833a64532a663a78e68c08db7b2c41fe4672744cbadfc4f87b2f987bc58e9204fbe8844ddacfa28b12c783a001a1961614ecf40afb68fd421d699cc80db5891bd5c194a49a11332293bea8b95ec891ad597a74f64be10d49422dd4e8a93938fac7ee74af08ec115ee237775c5f8c17129a6184b54b4b677d3b6c3f958d36809bbb01b409f95ae");
            result.DateA.ShouldBe(new DateTime(2021, 1, 26));
            result.DateD.ShouldBe(new DateTime(2010, 9, 11));
            result.Sort.ShouldBe(724237710);
            result.Note.ShouldBe("d33b75c1fd3143e197639cb5e3b700ed72709747733b42e58f688830e5eaa4f403860233deca426e82cf3595f3c9ddce9b3c8f4f0c934164a1181f58fccdb31a1e26c1e18a00493d895c9e3d88d78375306e664476cd4971a6c6c547ba75bc10ec78f82e16fa4ebb8724f3379ec90ee34930746091784a0bad1110e06dff1078f621a7a90e7e41138dbad5dced25cfb3aad8f5ab77dc4ea6b5cbd3419289834c803ba0207a89433da54e45e1d0267d59d8c6cffd2e0242b395c393a1a67b493b9ec1249ec597453e9528e7ffe4e75f1ef9e3ee30aafb49e9bfdca13273381321d6d7b1013f414f1c88bf2dbaff6ee9568dc6bf3f3209498287f9");
            result.Status.ShouldBe("69304ec03f4b4b95a5a02bc4a837208d18242894c2254d57ae");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryUpdateDto()
            {
                CompanyMainId = Guid.Parse("94295855-0758-4bea-8675-37eb008e8f75"),
                CompanyJobId = Guid.Parse("3d7bddb4-a1bf-481d-9c04-a9dc11b0d9ae"),
                DisabilityCategoryCode = "6cb7516317814d539488345419ebb6fe14285eec2db8402eb1",
                DisabilityLevelCode = "9c7a0c9545db4455b4b317f2b876f92c61cb3c52a8db45399e",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "cf3cee456ade454eb572a06ddce3549aec35d532053246b58915e73fadabc396770caa5c47a644718217ae3d25b129ebaac132f9ebba4bfd8ba474e2fe64f4dafaf00d49190f4f7dbdea23cdcfbc45ccfa6394fa633a408fb9c4701491a242548f9dfd8032aa420cb6feeefe20f5dc13a11907b92ddc4eeeba792d8d507bc0715458441916e04ddd97fbd02e5420e6816aeaf7944a3d483f8e04a75cfa96f6161c1d1bc109cd4d3e91e90b529834f9b9f543fc1fea134da7bc9d2a86bdce585f42e57b270b4247ca9077c58b8b1a6476ddec8960439d4bad87e40d76742091a993bbcfb6b1f2470586702a792bbd246d0012b56bb08448c4b81c",
                DateA = new DateTime(2021, 10, 12),
                DateD = new DateTime(2001, 3, 11),
                Sort = 890595574,
                Note = "d5701f7f2951495d9004ebf0352341b422359c2d9df5494c8eba92fb428e5ab479fc6c97f05f4953b96bd45a024c8d5e49eaf06e0ca94dae8f6cfb970a1355368a653b83cd67415c8ca47385fe26389b071d011f07f2427c81d34832e52fd15ba72db194e2d8418e93599f4f3ecc0255372158602ded4b5382ea31491c3174cd9aab2167338b4292923c372747b1e861c0ce111eac964afc8950be15a12aefa3f1f64947b90b4c77813b85cc9bc4a916d0cac11ba95b4724b7fd58292e141806f6db533e8e934fe0b567d471c1626b6836663ee4519f41509d8c5cf83bea574b8afb85dec8894d53a8b156beb4aab47017277b56b1e241e998d2",
                Status = "9c9204ea8c1d44beb984651f12ddf537c026fa9f5cb940a3ae"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.UpdateAsync(Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"), input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("94295855-0758-4bea-8675-37eb008e8f75"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3d7bddb4-a1bf-481d-9c04-a9dc11b0d9ae"));
            result.DisabilityCategoryCode.ShouldBe("6cb7516317814d539488345419ebb6fe14285eec2db8402eb1");
            result.DisabilityLevelCode.ShouldBe("9c7a0c9545db4455b4b317f2b876f92c61cb3c52a8db45399e");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("cf3cee456ade454eb572a06ddce3549aec35d532053246b58915e73fadabc396770caa5c47a644718217ae3d25b129ebaac132f9ebba4bfd8ba474e2fe64f4dafaf00d49190f4f7dbdea23cdcfbc45ccfa6394fa633a408fb9c4701491a242548f9dfd8032aa420cb6feeefe20f5dc13a11907b92ddc4eeeba792d8d507bc0715458441916e04ddd97fbd02e5420e6816aeaf7944a3d483f8e04a75cfa96f6161c1d1bc109cd4d3e91e90b529834f9b9f543fc1fea134da7bc9d2a86bdce585f42e57b270b4247ca9077c58b8b1a6476ddec8960439d4bad87e40d76742091a993bbcfb6b1f2470586702a792bbd246d0012b56bb08448c4b81c");
            result.DateA.ShouldBe(new DateTime(2021, 10, 12));
            result.DateD.ShouldBe(new DateTime(2001, 3, 11));
            result.Sort.ShouldBe(890595574);
            result.Note.ShouldBe("d5701f7f2951495d9004ebf0352341b422359c2d9df5494c8eba92fb428e5ab479fc6c97f05f4953b96bd45a024c8d5e49eaf06e0ca94dae8f6cfb970a1355368a653b83cd67415c8ca47385fe26389b071d011f07f2427c81d34832e52fd15ba72db194e2d8418e93599f4f3ecc0255372158602ded4b5382ea31491c3174cd9aab2167338b4292923c372747b1e861c0ce111eac964afc8950be15a12aefa3f1f64947b90b4c77813b85cc9bc4a916d0cac11ba95b4724b7fd58292e141806f6db533e8e934fe0b567d471c1626b6836663ee4519f41509d8c5cf83bea574b8afb85dec8894d53a8b156beb4aab47017277b56b1e241e998d2");
            result.Status.ShouldBe("9c9204ea8c1d44beb984651f12ddf537c026fa9f5cb940a3ae");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDisabilityCategoriesAppService.DeleteAsync(Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"));

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"));

            result.ShouldBeNull();
        }
    }
}