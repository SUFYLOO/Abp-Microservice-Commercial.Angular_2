using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobOrganizationUnits
{
    public class CompanyJobOrganizationUnitsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobOrganizationUnitsAppService _companyJobOrganizationUnitsAppService;
        private readonly IRepository<CompanyJobOrganizationUnit, Guid> _companyJobOrganizationUnitRepository;

        public CompanyJobOrganizationUnitsAppServiceTests()
        {
            _companyJobOrganizationUnitsAppService = GetRequiredService<ICompanyJobOrganizationUnitsAppService>();
            _companyJobOrganizationUnitRepository = GetRequiredService<IRepository<CompanyJobOrganizationUnit, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobOrganizationUnitsAppService.GetListAsync(new GetCompanyJobOrganizationUnitsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("4e35ba27-9e18-4c68-9074-9f5794732132")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobOrganizationUnitsAppService.GetAsync(Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitCreateDto
            {
                CompanyMainId = Guid.Parse("33da1a88-1cc2-4b46-b96c-fa7635aee059"),
                CompanyJobId = Guid.Parse("fdbf2ea8-8dd3-4c58-817e-408a2fcd66ac"),
                OrganizationUnitId = Guid.Parse("c16a7e08-7598-49a4-983e-7604f1dfc244"),
                ExtendedInformation = "cec366f0db764bb1997c9a5a4238115503157488be5e44b3bed820d2ba1b367277b45b5d6cf74a83932cabe36eeea2040301d503cf2c404e9e9d7f19134bac64b232243dc6d9411e900e233ba7b5676b57829401df9b48d4afd3ea56749f3beffd3647350cad4938aae3a6605d391ab36c7b93685a6f47549566760348d9c39009aa11451e584bdc9d2112c8dade36010171d310b14647228ea5ca476c3009928266040bb5b74f02bc1f687d4e2a0149f08f079ef09a4a59bf47583eb8e420e3105f464c51444063b313a9ed0451fe96d8cd0fa305224e78b679b3feddaa11341fc750a6b9dd46a68a307e4cc5ec368ceeb2c35ee8524c5b967a",
                DateA = new DateTime(2020, 5, 24),
                DateD = new DateTime(2005, 9, 18),
                Sort = 1082212589,
                Note = "e5ef2b1d0e6346729a91565c910dcd7f286c057ad33c47e7af9b12ca5c647c91e4218e9da1e84973ba28f942d52aaa5913e19992db2744a2816732cf9d80fca99ef29f54f26e4fe698a2cdf80e3a21e371f62a3aba37456494ebeb235f42abfb5c9297d6baf942f197c10668f32f8a06b49d29cfc9a74236af239e41e83f3a2ce0f0448a7a384e019787396a77a9e63df12de9125171453099d20abcb883fe16d862025dd85e4cc9a5a163af422d3ee7eb6ffce729fb4bed8eba81d03582b0d6d19f725f8fbe49a2843e2fbec2327b417fe23d59ccdd4b448af277dd790fc80cdcbd7d8635fa41859a1c864b1ecbafcad1bb747ee029400494a6",
                Status = "541aeeb8f007426289b7c205c48a548cbd2aa9022e274e72ac"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("33da1a88-1cc2-4b46-b96c-fa7635aee059"));
            result.CompanyJobId.ShouldBe(Guid.Parse("fdbf2ea8-8dd3-4c58-817e-408a2fcd66ac"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("c16a7e08-7598-49a4-983e-7604f1dfc244"));
            result.ExtendedInformation.ShouldBe("cec366f0db764bb1997c9a5a4238115503157488be5e44b3bed820d2ba1b367277b45b5d6cf74a83932cabe36eeea2040301d503cf2c404e9e9d7f19134bac64b232243dc6d9411e900e233ba7b5676b57829401df9b48d4afd3ea56749f3beffd3647350cad4938aae3a6605d391ab36c7b93685a6f47549566760348d9c39009aa11451e584bdc9d2112c8dade36010171d310b14647228ea5ca476c3009928266040bb5b74f02bc1f687d4e2a0149f08f079ef09a4a59bf47583eb8e420e3105f464c51444063b313a9ed0451fe96d8cd0fa305224e78b679b3feddaa11341fc750a6b9dd46a68a307e4cc5ec368ceeb2c35ee8524c5b967a");
            result.DateA.ShouldBe(new DateTime(2020, 5, 24));
            result.DateD.ShouldBe(new DateTime(2005, 9, 18));
            result.Sort.ShouldBe(1082212589);
            result.Note.ShouldBe("e5ef2b1d0e6346729a91565c910dcd7f286c057ad33c47e7af9b12ca5c647c91e4218e9da1e84973ba28f942d52aaa5913e19992db2744a2816732cf9d80fca99ef29f54f26e4fe698a2cdf80e3a21e371f62a3aba37456494ebeb235f42abfb5c9297d6baf942f197c10668f32f8a06b49d29cfc9a74236af239e41e83f3a2ce0f0448a7a384e019787396a77a9e63df12de9125171453099d20abcb883fe16d862025dd85e4cc9a5a163af422d3ee7eb6ffce729fb4bed8eba81d03582b0d6d19f725f8fbe49a2843e2fbec2327b417fe23d59ccdd4b448af277dd790fc80cdcbd7d8635fa41859a1c864b1ecbafcad1bb747ee029400494a6");
            result.Status.ShouldBe("541aeeb8f007426289b7c205c48a548cbd2aa9022e274e72ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitUpdateDto()
            {
                CompanyMainId = Guid.Parse("362d841e-87b3-403b-b065-e425ff85a896"),
                CompanyJobId = Guid.Parse("c8a52db4-959e-44d6-8f9f-0554efdddf5d"),
                OrganizationUnitId = Guid.Parse("765afd6b-bfdb-4c61-879a-ecf2bf57c458"),
                ExtendedInformation = "6e4104a589b942f48d543f52bf260dc955750ddfe2bd41a99e3e032ec8bfb111ad1fbf711bfc4748997cdf28e8cef07492a9ce5d90724e428f178fe303cb0ec5f104f5ce30a84c6d860e62116ee4583d0bf007a37e254fe8b46218b325324acf452b068e76db43b0a2168a6fb78a63800165e5a642fb4478a266f8afd3a5c0e7697735c99775461aac664f38d064b715a15e78ad42d44ba09595dd3ae8c5cea43e4805706ddb45a092640a4275d4817d0934bdb192274b179bada828850715934cef1bcd05f541e3bcc3ae936f007a4482b09ec42011422e8df56076a166e82c144d55a646c747978f301c7ce776afa084ad4e65a36d4382b26f",
                DateA = new DateTime(2013, 5, 15),
                DateD = new DateTime(2004, 3, 6),
                Sort = 1736392466,
                Note = "94afc157bf274a858afad134982807f7db106883c5f0464ca089ad6cf9347e2d41f4ccc70ba4477bbfbe8d176a74e0f73744e53c829144f1b5ea83ac4ee2d6bb542f8d6f869e4e83b415633e1b15633709a6e77196424ad0a7fe49989cda81c11b0b4ad0b23a4dd7948ab16e3eda7211a5ca054d0dda4b568e899354fb3246f00a95b4a2871243e1956812abc0b7480b567e5802a838438a93d07b8e4911f4a2208069baa295400b815d6911be2390cddf75962e8d7746d687e0a98d217be51e64d869408b274f75945ecbe649b0da2a05c0a21d61ce4093b979f805f5ddb23eb420a7979e5147d0a6ac874e42b6ee091284ae060d1f4bcdb83f",
                Status = "2ae2f8f883a440e3a6e3d7568548d8a8226460d03f5549898e"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.UpdateAsync(Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"), input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("362d841e-87b3-403b-b065-e425ff85a896"));
            result.CompanyJobId.ShouldBe(Guid.Parse("c8a52db4-959e-44d6-8f9f-0554efdddf5d"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("765afd6b-bfdb-4c61-879a-ecf2bf57c458"));
            result.ExtendedInformation.ShouldBe("6e4104a589b942f48d543f52bf260dc955750ddfe2bd41a99e3e032ec8bfb111ad1fbf711bfc4748997cdf28e8cef07492a9ce5d90724e428f178fe303cb0ec5f104f5ce30a84c6d860e62116ee4583d0bf007a37e254fe8b46218b325324acf452b068e76db43b0a2168a6fb78a63800165e5a642fb4478a266f8afd3a5c0e7697735c99775461aac664f38d064b715a15e78ad42d44ba09595dd3ae8c5cea43e4805706ddb45a092640a4275d4817d0934bdb192274b179bada828850715934cef1bcd05f541e3bcc3ae936f007a4482b09ec42011422e8df56076a166e82c144d55a646c747978f301c7ce776afa084ad4e65a36d4382b26f");
            result.DateA.ShouldBe(new DateTime(2013, 5, 15));
            result.DateD.ShouldBe(new DateTime(2004, 3, 6));
            result.Sort.ShouldBe(1736392466);
            result.Note.ShouldBe("94afc157bf274a858afad134982807f7db106883c5f0464ca089ad6cf9347e2d41f4ccc70ba4477bbfbe8d176a74e0f73744e53c829144f1b5ea83ac4ee2d6bb542f8d6f869e4e83b415633e1b15633709a6e77196424ad0a7fe49989cda81c11b0b4ad0b23a4dd7948ab16e3eda7211a5ca054d0dda4b568e899354fb3246f00a95b4a2871243e1956812abc0b7480b567e5802a838438a93d07b8e4911f4a2208069baa295400b815d6911be2390cddf75962e8d7746d687e0a98d217be51e64d869408b274f75945ecbe649b0da2a05c0a21d61ce4093b979f805f5ddb23eb420a7979e5147d0a6ac874e42b6ee091284ae060d1f4bcdb83f");
            result.Status.ShouldBe("2ae2f8f883a440e3a6e3d7568548d8a8226460d03f5549898e");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobOrganizationUnitsAppService.DeleteAsync(Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"));

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"));

            result.ShouldBeNull();
        }
    }
}