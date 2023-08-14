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
            result.Items.Any(x => x.Id == Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("91b29225-a219-4df2-8b21-c47eafb009fb")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobOrganizationUnitsAppService.GetAsync(Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitCreateDto
            {
                CompanyMainId = Guid.Parse("203a7023-ec38-4a8d-a1d3-7ebeb91297c9"),
                CompanyJobId = Guid.Parse("949fa78c-30d6-41dc-a5ed-d492924bc479"),
                OrganizationUnitId = Guid.Parse("d4ce6b2d-947d-4623-b035-eb763e5ef597"),
                ExtendedInformation = "0c987d63f0694a498a75dfc4135aa6864121487025ab4ff2a951dedfd5e586ab2129d4b0c34445ad924c7e52d321a26ff30abe7e93eb488b80ebf6cda92a99a393112ab1fe7c42b1bb92fb3187b6f26f9621ba08cd714a608f02d3216f4cf7102893ca0a5365494dadd07139ccac2fd999c82e2a1cab4a27a338758c663c35876f10272477b645caaa47b8f9511caa00eee998ef43b64755906d7493cf27a8a16b85b42b75a04680a1fcccd9eee545c928325db98d3c40b3af6c291530fdf54ab7e9cb3fdae34d65990447b9c1172beb3d0681358d6b4686ba5c1883ba95a4f2da71748b76794268bc36633decb20e1de73775e02a8844cbbb40",
                DateA = new DateTime(2010, 11, 26),
                DateD = new DateTime(2009, 8, 18),
                Sort = 1873416879,
                Note = "3b0c4ec86b904b52b75edc6855f00805d372354aa00b44e3a36c0be372ecfdab608be82f2fcf4ad2902eb82c6abca45368c6f1e6816545688a7fb1736de29fb442a5e63fa10d4cf89f8d439f11888d44ebad276e8834446e8cc70d0d47c3ea2b96c0b50e4fdd4efdbbda455d5dd10fd43912b966cce841ff937ceb1d30bcc04d17b474f8528646588b64604cb44f201f4a3b3b205dd44d82a31a42befc40a33dd1fa80cbf4db43fba50a15bda34b81635cd095dba90e440fb3e903c857e9b5389a41c2286e52495b9483a576d5c2b7aa8070f5d60ce64251bd479d28b20402856183bc5417ea450c903dec643b6f530f15ea87d9f9804b21a710",
                Status = "8d798ced76104d118de389c9e1e0c044fdf0139aca804c4597"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("203a7023-ec38-4a8d-a1d3-7ebeb91297c9"));
            result.CompanyJobId.ShouldBe(Guid.Parse("949fa78c-30d6-41dc-a5ed-d492924bc479"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("d4ce6b2d-947d-4623-b035-eb763e5ef597"));
            result.ExtendedInformation.ShouldBe("0c987d63f0694a498a75dfc4135aa6864121487025ab4ff2a951dedfd5e586ab2129d4b0c34445ad924c7e52d321a26ff30abe7e93eb488b80ebf6cda92a99a393112ab1fe7c42b1bb92fb3187b6f26f9621ba08cd714a608f02d3216f4cf7102893ca0a5365494dadd07139ccac2fd999c82e2a1cab4a27a338758c663c35876f10272477b645caaa47b8f9511caa00eee998ef43b64755906d7493cf27a8a16b85b42b75a04680a1fcccd9eee545c928325db98d3c40b3af6c291530fdf54ab7e9cb3fdae34d65990447b9c1172beb3d0681358d6b4686ba5c1883ba95a4f2da71748b76794268bc36633decb20e1de73775e02a8844cbbb40");
            result.DateA.ShouldBe(new DateTime(2010, 11, 26));
            result.DateD.ShouldBe(new DateTime(2009, 8, 18));
            result.Sort.ShouldBe(1873416879);
            result.Note.ShouldBe("3b0c4ec86b904b52b75edc6855f00805d372354aa00b44e3a36c0be372ecfdab608be82f2fcf4ad2902eb82c6abca45368c6f1e6816545688a7fb1736de29fb442a5e63fa10d4cf89f8d439f11888d44ebad276e8834446e8cc70d0d47c3ea2b96c0b50e4fdd4efdbbda455d5dd10fd43912b966cce841ff937ceb1d30bcc04d17b474f8528646588b64604cb44f201f4a3b3b205dd44d82a31a42befc40a33dd1fa80cbf4db43fba50a15bda34b81635cd095dba90e440fb3e903c857e9b5389a41c2286e52495b9483a576d5c2b7aa8070f5d60ce64251bd479d28b20402856183bc5417ea450c903dec643b6f530f15ea87d9f9804b21a710");
            result.Status.ShouldBe("8d798ced76104d118de389c9e1e0c044fdf0139aca804c4597");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobOrganizationUnitUpdateDto()
            {
                CompanyMainId = Guid.Parse("505dcb92-448e-492b-94c8-5a00a3146b1c"),
                CompanyJobId = Guid.Parse("0e026db6-d311-4966-876b-5c68d2a9f82d"),
                OrganizationUnitId = Guid.Parse("c5a003bb-204f-447d-96fa-5678204be1d2"),
                ExtendedInformation = "ccbb3146294641ac87d9335e4fae9d5e1e6d385f69fe405cb88bcbcfb85b1f1691e3256eb47e42afb974c4df0ee090096a43bd7278644beeb6058ec8b877db32f85d1f6548b14f719ebe202dacc72901425bae597d0c4f8890346185446eaf08a45161778b0d435787c37fc1cf89fed056a5e06141d049889ac064f90b3542b8dd778e11131740d6a0777c4659f44e598a9dce317f28472684fe9b3337baacf242063aaf6ed34aa6b986fdf696b53815fbfb4a31452045d5a0044e2508c33476e5e27fdd5287425996feb6d588d666dfae19cd865d60484182c8ff913333e077bc6bb6e7180844e5ab9c49ded24a47b15646a1e7b89b4516b1e0",
                DateA = new DateTime(2017, 2, 26),
                DateD = new DateTime(2014, 8, 2),
                Sort = 305257074,
                Note = "a8a0338d767545e8b41379f485d1c3aa70bae30dcc7f4bdcb9b7ec306bd2f7274d236fac6f9c4baebcba96897a740898b1507fe59bf148249f8a0cc83824789ca21d64dbbc4f440983629c61adc25937110cc7a3c86c4aa1ae57755e214545d225ded83aaddf43e4b8b5890b64f2b60a98fb910a686f4890a0b0abb243c23343ee6b1e90e1ad47dc92d04662f6865680e627b04a84844746877fe22cc62d72b04f9c181db36845088f75eb242b6ef43597f6d1b542034950bd00f0fa38c9e47ca6ddbc40ec744e99aa2089986a8e5c7d7385443a8e3c45518d8cfcae6fd29144d86dbb2b17e84d5cbfef49d9b7d826d3b1e7acd814064878a7a9",
                Status = "fcdbfce1b2ef48bf82636d751e7ea6d7b06ba196696c4b4ab3"
            };

            // Act
            var serviceResult = await _companyJobOrganizationUnitsAppService.UpdateAsync(Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"), input);

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("505dcb92-448e-492b-94c8-5a00a3146b1c"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0e026db6-d311-4966-876b-5c68d2a9f82d"));
            result.OrganizationUnitId.ShouldBe(Guid.Parse("c5a003bb-204f-447d-96fa-5678204be1d2"));
            result.ExtendedInformation.ShouldBe("ccbb3146294641ac87d9335e4fae9d5e1e6d385f69fe405cb88bcbcfb85b1f1691e3256eb47e42afb974c4df0ee090096a43bd7278644beeb6058ec8b877db32f85d1f6548b14f719ebe202dacc72901425bae597d0c4f8890346185446eaf08a45161778b0d435787c37fc1cf89fed056a5e06141d049889ac064f90b3542b8dd778e11131740d6a0777c4659f44e598a9dce317f28472684fe9b3337baacf242063aaf6ed34aa6b986fdf696b53815fbfb4a31452045d5a0044e2508c33476e5e27fdd5287425996feb6d588d666dfae19cd865d60484182c8ff913333e077bc6bb6e7180844e5ab9c49ded24a47b15646a1e7b89b4516b1e0");
            result.DateA.ShouldBe(new DateTime(2017, 2, 26));
            result.DateD.ShouldBe(new DateTime(2014, 8, 2));
            result.Sort.ShouldBe(305257074);
            result.Note.ShouldBe("a8a0338d767545e8b41379f485d1c3aa70bae30dcc7f4bdcb9b7ec306bd2f7274d236fac6f9c4baebcba96897a740898b1507fe59bf148249f8a0cc83824789ca21d64dbbc4f440983629c61adc25937110cc7a3c86c4aa1ae57755e214545d225ded83aaddf43e4b8b5890b64f2b60a98fb910a686f4890a0b0abb243c23343ee6b1e90e1ad47dc92d04662f6865680e627b04a84844746877fe22cc62d72b04f9c181db36845088f75eb242b6ef43597f6d1b542034950bd00f0fa38c9e47ca6ddbc40ec744e99aa2089986a8e5c7d7385443a8e3c45518d8cfcae6fd29144d86dbb2b17e84d5cbfef49d9b7d826d3b1e7acd814064878a7a9");
            result.Status.ShouldBe("fcdbfce1b2ef48bf82636d751e7ea6d7b06ba196696c4b4ab3");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobOrganizationUnitsAppService.DeleteAsync(Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"));

            // Assert
            var result = await _companyJobOrganizationUnitRepository.FindAsync(c => c.Id == Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"));

            result.ShouldBeNull();
        }
    }
}