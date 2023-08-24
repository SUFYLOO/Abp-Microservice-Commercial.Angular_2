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
            result.Items.Any(x => x.Id == Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("046db552-8a63-401c-ab7e-c5676124666a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobOrganizationUnitsAppService.GetAsync(Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitCreateDto
            {
                CompanyMainId = Guid.Parse("be6c2997-7659-4c56-acc6-78d19e54380d"),
                CompanyJobId = Guid.Parse("d5ed0382-acec-4866-9465-40b5f60437dc"),
                OrganizationUnitId = Guid.Parse("fd3934bf-143c-4dc6-a667-b254f6d8a2d2"),
                ExtendedInformation = "ef460ad255b84c3f951f87c9b1998df59ec1da6eabfc47b3b5f041ee7693012c086ec938a16f41abb4458fb3535c87d32f4f191f445741d09aa215fad6d017b615c11b780b454e5e86c9d883949e77c7f296245e738c4501be370cd4082a7bee147bca3c9ce84ff8958e2a49177a42af74a6a927d4b04dc8bbdd38dba1c0fd6dace40ccf8bf240898d4da2d59d4d645db7ce72f964b947ad91dcd912a56b00a360e2cbb31f9a4a64930147243651a0f3dfb8a9ecb15c49a3b5ee0c1fac82317cb3e9b744a3d74aba8a5134a81245ec7e2b3f7eef55044893b58397b413d8364f7d77cc669efd4af4b55e899ab8c628491a2a6a55fd3c4720a157",
                DateA = new DateTime(2007, 8, 9),
                DateD = new DateTime(2011, 10, 14),
                Sort = 1310457983,
                Note = "d85ff1356cde4b6f9556b1a1c345e96425d67f85e9a348da82d705374cc6ad6ac27d013f7b924138bfe54e46be1229e85d909b0cd9b942798e2585bcbfde150573a292176ed04eeba67452458b6ac132d8c5abfef18742c8981c49881f9deb0d4ad9693ca7104a6785ef5d765783e54528152ea49ea04daa810bcea8517add98f5bfb4fcdcaa4f42ac8d0a056dd7ace8b0041a41566a4ca4b4df0658b48528aa83e831a6fc2a4302beb37326db0f50bd56451fe109374223ac330d3380761b59c475e26bee5748bea4bf0e33f86528b659a41538c4ad45aa83c2dd632a130ab19acee43a845f4f14a47ac35caca259a7ae7610a414c44b66bc03",
                Status = "5aed96fe06384e109b8f97dfff2eabb0649725752df245c0aa"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("be6c2997-7659-4c56-acc6-78d19e54380d"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d5ed0382-acec-4866-9465-40b5f60437dc"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("fd3934bf-143c-4dc6-a667-b254f6d8a2d2"));
            result.ExtendedInformation.ShouldBe("ef460ad255b84c3f951f87c9b1998df59ec1da6eabfc47b3b5f041ee7693012c086ec938a16f41abb4458fb3535c87d32f4f191f445741d09aa215fad6d017b615c11b780b454e5e86c9d883949e77c7f296245e738c4501be370cd4082a7bee147bca3c9ce84ff8958e2a49177a42af74a6a927d4b04dc8bbdd38dba1c0fd6dace40ccf8bf240898d4da2d59d4d645db7ce72f964b947ad91dcd912a56b00a360e2cbb31f9a4a64930147243651a0f3dfb8a9ecb15c49a3b5ee0c1fac82317cb3e9b744a3d74aba8a5134a81245ec7e2b3f7eef55044893b58397b413d8364f7d77cc669efd4af4b55e899ab8c628491a2a6a55fd3c4720a157");
            result.DateA.ShouldBe(new DateTime(2007, 8, 9));
            result.DateD.ShouldBe(new DateTime(2011, 10, 14));
            result.Sort.ShouldBe(1310457983);
            result.Note.ShouldBe("d85ff1356cde4b6f9556b1a1c345e96425d67f85e9a348da82d705374cc6ad6ac27d013f7b924138bfe54e46be1229e85d909b0cd9b942798e2585bcbfde150573a292176ed04eeba67452458b6ac132d8c5abfef18742c8981c49881f9deb0d4ad9693ca7104a6785ef5d765783e54528152ea49ea04daa810bcea8517add98f5bfb4fcdcaa4f42ac8d0a056dd7ace8b0041a41566a4ca4b4df0658b48528aa83e831a6fc2a4302beb37326db0f50bd56451fe109374223ac330d3380761b59c475e26bee5748bea4bf0e33f86528b659a41538c4ad45aa83c2dd632a130ab19acee43a845f4f14a47ac35caca259a7ae7610a414c44b66bc03");
            result.Status.ShouldBe("5aed96fe06384e109b8f97dfff2eabb0649725752df245c0aa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitUpdateDto()
            {
                CompanyMainId = Guid.Parse("82e153e6-70cf-4bca-b654-b231f4b8bcdf"),
                CompanyJobId = Guid.Parse("15044448-70b3-4ca3-9511-2013e5971bae"),
                OrganizationUnitId = Guid.Parse("bb77e00c-7aad-44a0-8376-9760a40f4230"),
                ExtendedInformation = "76188993915c42539264b2687218d07d8e4a8abad6e64bb5a01976f23dce98c0b6a654931ebe4cd7b2262ab56f751c9379c16b59b7d54581bf635f8fdf5c0c426a3b14094c524ba8840d79e939a71be3cd697e50377649e38e48619a5a0c09c22334a48178224d80938895024266f0883c32e16e80ba4077a35022bc0e4671c35794b70c9b644685ab3cd2f3052bbfb5080542f70820458e9e84a5b7a30804bf157b139971794aaa87a84585cfc749da6dcefc85c65f41deb56d2f380f390012b84b26fdfccb42428351d3ea24484163b6552104936844dbb9dc324f75a2b6538b854b9638434e048f0b0aceb91e9038fb5049eb6bae45f6adb1",
                DateA = new DateTime(2010, 8, 7),
                DateD = new DateTime(2010, 10, 16),
                Sort = 1741701222,
                Note = "2fa7524422964b789b399fbd44d29d35c951c346d8894a02aa82a4a0493fa2fc9eeaaf5245784c689625c15e08715e091856e5e3b02045579bb5afdaf60726408d036f329e4a43a58de2a50647f681da4c2842c9ba654ed88dff00fb0a3babc3bdc359137b6942558aac5541c27044c2463d534a9ecd4099bc7f033f1304093f9eab139f17c741a1b5d1bbfda7f3bc10093a31fe593e4369b52090e58bef6800188f7901faea43ddbc360f2b60937484cc136809dcef4155958f3f84308b29fe5cbaeeb490a84d9abaab5f9f41bb95b00b42b7a4cd384ed2823d70e28c42d7c428f0bb6a12ae412e94e804fcb9420576dd709a505b66413cbb92",
                Status = "227a1a14e9fb4c7a9d29452caef193b5c9c24e87b81e498a8a"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.UpdateAsync(Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"), input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("82e153e6-70cf-4bca-b654-b231f4b8bcdf"));
            result.CompanyJobId.ShouldBe(Guid.Parse("15044448-70b3-4ca3-9511-2013e5971bae"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("bb77e00c-7aad-44a0-8376-9760a40f4230"));
            result.ExtendedInformation.ShouldBe("76188993915c42539264b2687218d07d8e4a8abad6e64bb5a01976f23dce98c0b6a654931ebe4cd7b2262ab56f751c9379c16b59b7d54581bf635f8fdf5c0c426a3b14094c524ba8840d79e939a71be3cd697e50377649e38e48619a5a0c09c22334a48178224d80938895024266f0883c32e16e80ba4077a35022bc0e4671c35794b70c9b644685ab3cd2f3052bbfb5080542f70820458e9e84a5b7a30804bf157b139971794aaa87a84585cfc749da6dcefc85c65f41deb56d2f380f390012b84b26fdfccb42428351d3ea24484163b6552104936844dbb9dc324f75a2b6538b854b9638434e048f0b0aceb91e9038fb5049eb6bae45f6adb1");
            result.DateA.ShouldBe(new DateTime(2010, 8, 7));
            result.DateD.ShouldBe(new DateTime(2010, 10, 16));
            result.Sort.ShouldBe(1741701222);
            result.Note.ShouldBe("2fa7524422964b789b399fbd44d29d35c951c346d8894a02aa82a4a0493fa2fc9eeaaf5245784c689625c15e08715e091856e5e3b02045579bb5afdaf60726408d036f329e4a43a58de2a50647f681da4c2842c9ba654ed88dff00fb0a3babc3bdc359137b6942558aac5541c27044c2463d534a9ecd4099bc7f033f1304093f9eab139f17c741a1b5d1bbfda7f3bc10093a31fe593e4369b52090e58bef6800188f7901faea43ddbc360f2b60937484cc136809dcef4155958f3f84308b29fe5cbaeeb490a84d9abaab5f9f41bb95b00b42b7a4cd384ed2823d70e28c42d7c428f0bb6a12ae412e94e804fcb9420576dd709a505b66413cbb92");
            result.Status.ShouldBe("227a1a14e9fb4c7a9d29452caef193b5c9c24e87b81e498a8a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobOrganizationUnitsAppService.DeleteAsync(Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"));

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"));

            result.ShouldBeNull();
        }
    }
}