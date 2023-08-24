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
            result.Items.Any(x => x.Id == Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("80fef142-4fa7-4bd8-bbf7-5abd97e2e7df")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobWorkIdentitiesAppService.GetAsync(Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityCreateDto
            {
                CompanyMainId = Guid.Parse("485c7119-6b01-4f30-b2c0-2b25f941129d"),
                CompanyJobId = Guid.Parse("3af1c8bb-94c5-4b88-b275-c8107dce1c7e"),
                WorkIdentityCode = "acfb0e0f23224e35b8539aa6047b4a18b6c9b2dd03444ace92",
                ExtendedInformation = "e24a2bd9f35f4cd6af9868c213696f45ff089b8dffa24d7b8bae74555ea1ebd24b51594472f04e688979a867f7ca67c0e256e559b3d54c4a8049972610a736469079fded49684d5db14a509822e1943454ea6343c0ad44659a2688a267332aff532c4aa435ec4cd4858fc99e28ff9497207541bd54af4bdfa4c9cee5f05d7a4ddf6cbd9e93e84b7b9706c86d149a13197a6f249967b9423e86800e19db995d6d951fb944336a42aca2250f4a4accd9bf23e598f12f0e48429f02f152ffea51745dbea113b2ef4cba89a067f658dc68f6c77fbcd66c374f7db051026b93b19bdec59e49f72b9444198fc63f89976dd695eac8ba750cc0453783e3",
                DateA = new DateTime(2011, 9, 24),
                DateD = new DateTime(2010, 6, 15),
                Sort = 1466606421,
                Note = "f744922cf850444e8d91e771569fab0bb91880acd6e94961a43a24cfcadaca7d1c7ff6be9ed348d583b989289b0a3d57ebbb400ef39744ccabd86bf28f008370076786f979b446a1a9989b4ef480922190d2fce5642546959b573f722258eef18493e77a45d44999bf0883ffd3b60931634edfed2fae4cab8068ffab14b9018e0265ba80262948b29152713fa2eb37e7e6bcc98ca6764dd49e6aa856b0a04e01b3bb1a35a1c74b7c86f0450ff02d2b861c36dc4ded6941d4806e9f93b1d102f05074d448305943a49f4931a16fcd6bdcc1bdf1becc7f4cedbe22fb920c5bf3a158eb74edd8eb415a98e7966ba939e351989998de2bb04d5683b2",
                Status = "a356352b57e8458dbe09e6f517852909316b3e5458ff46d98c"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("485c7119-6b01-4f30-b2c0-2b25f941129d"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3af1c8bb-94c5-4b88-b275-c8107dce1c7e"));
            result.WorkIdentityCode.ShouldBe("acfb0e0f23224e35b8539aa6047b4a18b6c9b2dd03444ace92");
            result.ExtendedInformation.ShouldBe("e24a2bd9f35f4cd6af9868c213696f45ff089b8dffa24d7b8bae74555ea1ebd24b51594472f04e688979a867f7ca67c0e256e559b3d54c4a8049972610a736469079fded49684d5db14a509822e1943454ea6343c0ad44659a2688a267332aff532c4aa435ec4cd4858fc99e28ff9497207541bd54af4bdfa4c9cee5f05d7a4ddf6cbd9e93e84b7b9706c86d149a13197a6f249967b9423e86800e19db995d6d951fb944336a42aca2250f4a4accd9bf23e598f12f0e48429f02f152ffea51745dbea113b2ef4cba89a067f658dc68f6c77fbcd66c374f7db051026b93b19bdec59e49f72b9444198fc63f89976dd695eac8ba750cc0453783e3");
            result.DateA.ShouldBe(new DateTime(2011, 9, 24));
            result.DateD.ShouldBe(new DateTime(2010, 6, 15));
            result.Sort.ShouldBe(1466606421);
            result.Note.ShouldBe("f744922cf850444e8d91e771569fab0bb91880acd6e94961a43a24cfcadaca7d1c7ff6be9ed348d583b989289b0a3d57ebbb400ef39744ccabd86bf28f008370076786f979b446a1a9989b4ef480922190d2fce5642546959b573f722258eef18493e77a45d44999bf0883ffd3b60931634edfed2fae4cab8068ffab14b9018e0265ba80262948b29152713fa2eb37e7e6bcc98ca6764dd49e6aa856b0a04e01b3bb1a35a1c74b7c86f0450ff02d2b861c36dc4ded6941d4806e9f93b1d102f05074d448305943a49f4931a16fcd6bdcc1bdf1becc7f4cedbe22fb920c5bf3a158eb74edd8eb415a98e7966ba939e351989998de2bb04d5683b2");
            result.Status.ShouldBe("a356352b57e8458dbe09e6f517852909316b3e5458ff46d98c");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityUpdateDto()
            {
                CompanyMainId = Guid.Parse("8fc28663-5697-45c8-8810-731b2928c986"),
                CompanyJobId = Guid.Parse("fff0141b-f22e-4950-9cb1-d719e30a1167"),
                WorkIdentityCode = "d3ffbb8e3ce545fe9f48a632ebf5762a469efa9605b745f4ac",
                ExtendedInformation = "1051c42464cd40948604839cae23e04c877ef97fcbca4e2297cdf4a49e48273b89891f56a1ed48ba8aeffb8b086cb5877e3c930d996e450e8203b2b43934f128e747d4f1395649c5ae65ce286a11fcb555c1f16d8f7d4c15bd57a26ef54f4152cc0876fce68342d9b56a30f36e31e65ee4c50fe3d867485b8f062686377b9b9bd7d83857b456496a8289ae4feaeff8280b4030fa0c594c9195b4bcbb1597c8375dc418459292408aaa335d0f8e8ed58e6635ef2db3864e97a653ce32bfdcf3471d70c5c3536a4eeb8184978e31d6b6590a6849d6912e4e828aa0ba3bc4337c0e71efad8bf5c246fc9d5e1db7ff53de205e1db9a34e814d5495d5",
                DateA = new DateTime(2007, 10, 5),
                DateD = new DateTime(2022, 8, 25),
                Sort = 1986257574,
                Note = "62e8140615b142b3a407549b328e3bf1e6133ead48684627aa3c19680ed6aa0786112e1b197e4ddcbcb86a58b19b0885b7784c8007504414835021e87bb908b307b0e9f2294d400d80e5083cff4f3c0ad87bc3e876c64f629ea55b1983f778ce9eb59dbce31c48c28fb053deded601280773db61e42f4a22837f005d99abf2b2e60794a429644700931326d4835c33b0f80c0b1b11f24bf79f2490fc4571a9281d6111778994450da428f28210569696b7c355de8155453eaa0e478a2976292233ecefdecd6c451eb51196143d6bfff2b5ebd5f61bc84581bccd25568512fc1d141cc2bfccd5454c9dc42be2471995bf6bd2c95b86544d84a0c8",
                Status = "58e9bcf82e6c490c9442470aee343050c490e620be0f47d0b9"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.UpdateAsync(Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"), input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("8fc28663-5697-45c8-8810-731b2928c986"));
            result.CompanyJobId.ShouldBe(Guid.Parse("fff0141b-f22e-4950-9cb1-d719e30a1167"));
            result.WorkIdentityCode.ShouldBe("d3ffbb8e3ce545fe9f48a632ebf5762a469efa9605b745f4ac");
            result.ExtendedInformation.ShouldBe("1051c42464cd40948604839cae23e04c877ef97fcbca4e2297cdf4a49e48273b89891f56a1ed48ba8aeffb8b086cb5877e3c930d996e450e8203b2b43934f128e747d4f1395649c5ae65ce286a11fcb555c1f16d8f7d4c15bd57a26ef54f4152cc0876fce68342d9b56a30f36e31e65ee4c50fe3d867485b8f062686377b9b9bd7d83857b456496a8289ae4feaeff8280b4030fa0c594c9195b4bcbb1597c8375dc418459292408aaa335d0f8e8ed58e6635ef2db3864e97a653ce32bfdcf3471d70c5c3536a4eeb8184978e31d6b6590a6849d6912e4e828aa0ba3bc4337c0e71efad8bf5c246fc9d5e1db7ff53de205e1db9a34e814d5495d5");
            result.DateA.ShouldBe(new DateTime(2007, 10, 5));
            result.DateD.ShouldBe(new DateTime(2022, 8, 25));
            result.Sort.ShouldBe(1986257574);
            result.Note.ShouldBe("62e8140615b142b3a407549b328e3bf1e6133ead48684627aa3c19680ed6aa0786112e1b197e4ddcbcb86a58b19b0885b7784c8007504414835021e87bb908b307b0e9f2294d400d80e5083cff4f3c0ad87bc3e876c64f629ea55b1983f778ce9eb59dbce31c48c28fb053deded601280773db61e42f4a22837f005d99abf2b2e60794a429644700931326d4835c33b0f80c0b1b11f24bf79f2490fc4571a9281d6111778994450da428f28210569696b7c355de8155453eaa0e478a2976292233ecefdecd6c451eb51196143d6bfff2b5ebd5f61bc84581bccd25568512fc1d141cc2bfccd5454c9dc42be2471995bf6bd2c95b86544d84a0c8");
            result.Status.ShouldBe("58e9bcf82e6c490c9442470aee343050c490e620be0f47d0b9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobWorkIdentitiesAppService.DeleteAsync(Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"));

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"));

            result.ShouldBeNull();
        }
    }
}