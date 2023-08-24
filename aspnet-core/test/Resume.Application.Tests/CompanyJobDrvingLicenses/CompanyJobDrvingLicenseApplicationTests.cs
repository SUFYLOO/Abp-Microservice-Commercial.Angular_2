using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicensesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobDrvingLicensesAppService _companyJobDrvingLicensesAppService;
        private readonly IRepository<CompanyJobDrvingLicense, Guid> _companyJobDrvingLicenseRepository;

        public CompanyJobDrvingLicensesAppServiceTests()
        {
            _companyJobDrvingLicensesAppService = GetRequiredService<ICompanyJobDrvingLicensesAppService>();
            _companyJobDrvingLicenseRepository = GetRequiredService<IRepository<CompanyJobDrvingLicense, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetListAsync(new GetCompanyJobDrvingLicensesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2cb6d9f5-0313-4f65-91a1-8f0e30f06a70")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetAsync(Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseCreateDto
            {
                CompanyMainId = Guid.Parse("0fd79405-bdc9-4dd9-949a-92fb11171c05"),
                CompanyJobId = Guid.Parse("134b2829-a7ec-4785-b249-e2d332feb909"),
                DrvingLicenseCode = "a531305c61fb4000a2bb2dd581e1d95e1a6655170dc0410a84",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "b4ef779e8275430d8aae383de42742be151dd2e72fcc4ec3900387a197a65aa0c9f9f600506a42ddac2dc2c6fd92419c3f47153b530e4d738d4fc9f66b5ead934752ca5644ef47be88d501b7fb05117e043d6185e2e44750b3a12845dbd513f10ba92df7c1344777af34302a0cb4819824669e6f12a448c0b647a7eeacb5ccbac34fe0951d6949b9affc507ffbe0d38d6e5837b2a81049ffa917604064a92d330fcb067eb0dc4addb409eef175bf2f086bac003e257f4ef2ac79fbda23e055196cab4b35bc7b4f009e5131a53cb14eec563ccb762378451597fd16923597606d78f2afb107f343e4badedc2782a7b110846e8821612347ae813d",
                DateA = new DateTime(2015, 10, 3),
                DateD = new DateTime(2011, 2, 1),
                Sort = 715006373,
                Note = "328a63e2e5794e7c8dd3f6492a421b49e4a5c1999aa64f168f8f600530fb89306e07f1b584e94e67878f9b8b290b5b4baededb00002c4781a98031ed7658e1daceb9f1b298224e979c2eacd4dbd08a7e80b843cc50264ac48ebffefb571fed031c9ae18d8a5842248af1a22e4c83727b2481c41766774d95af77575f3cfba34fcf18b55e0c3f40adbb2ed9f93f6fc9af7160bf9b92b94b5d876e782d801575e40a664ec15fab44bea28e1cfccabebd73b26695863857423f8d13b0b4e51d5c9c2192c124035547c2815fbc2f4733b6959243643671ae422fadae6932ddf3e4c81f3b371307ee42fcbad8ca3f2e33218bc6895c5013c045f0ac9e",
                Status = "c00ff70f9af34b6785a884fb923520e12bbea1a5f2984fffa4"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("0fd79405-bdc9-4dd9-949a-92fb11171c05"));
            result.CompanyJobId.ShouldBe(Guid.Parse("134b2829-a7ec-4785-b249-e2d332feb909"));
            result.DrvingLicenseCode.ShouldBe("a531305c61fb4000a2bb2dd581e1d95e1a6655170dc0410a84");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("b4ef779e8275430d8aae383de42742be151dd2e72fcc4ec3900387a197a65aa0c9f9f600506a42ddac2dc2c6fd92419c3f47153b530e4d738d4fc9f66b5ead934752ca5644ef47be88d501b7fb05117e043d6185e2e44750b3a12845dbd513f10ba92df7c1344777af34302a0cb4819824669e6f12a448c0b647a7eeacb5ccbac34fe0951d6949b9affc507ffbe0d38d6e5837b2a81049ffa917604064a92d330fcb067eb0dc4addb409eef175bf2f086bac003e257f4ef2ac79fbda23e055196cab4b35bc7b4f009e5131a53cb14eec563ccb762378451597fd16923597606d78f2afb107f343e4badedc2782a7b110846e8821612347ae813d");
            result.DateA.ShouldBe(new DateTime(2015, 10, 3));
            result.DateD.ShouldBe(new DateTime(2011, 2, 1));
            result.Sort.ShouldBe(715006373);
            result.Note.ShouldBe("328a63e2e5794e7c8dd3f6492a421b49e4a5c1999aa64f168f8f600530fb89306e07f1b584e94e67878f9b8b290b5b4baededb00002c4781a98031ed7658e1daceb9f1b298224e979c2eacd4dbd08a7e80b843cc50264ac48ebffefb571fed031c9ae18d8a5842248af1a22e4c83727b2481c41766774d95af77575f3cfba34fcf18b55e0c3f40adbb2ed9f93f6fc9af7160bf9b92b94b5d876e782d801575e40a664ec15fab44bea28e1cfccabebd73b26695863857423f8d13b0b4e51d5c9c2192c124035547c2815fbc2f4733b6959243643671ae422fadae6932ddf3e4c81f3b371307ee42fcbad8ca3f2e33218bc6895c5013c045f0ac9e");
            result.Status.ShouldBe("c00ff70f9af34b6785a884fb923520e12bbea1a5f2984fffa4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseUpdateDto()
            {
                CompanyMainId = Guid.Parse("7767810b-ee33-49a7-8db9-fae70af1264f"),
                CompanyJobId = Guid.Parse("8bf56317-a77d-48dd-b1b8-a9fbb410a38e"),
                DrvingLicenseCode = "487a087b7f8f47f3b2566cfc995a2fb65ddeb863261e4a4786",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "21d71c6dad244e0f9fe467c2c61aad2355dab48e463c4ba18c99e93f84ee5543ec80fd2fa2bc464d975df254a0c2b1508decfdac7f7147afae4895f3125a2e4abe73069477554b0783c6d7a5af8c4d8b2db6964a70374e77a5ebf56dcd50fdd2b49a5cf5890f470e9b9f3a537a4eaa36c32a482215514f0b9f0b643c73fd9b9d75e18feccc6c4e568cee8c9ec51b245414bb7b76d1084fb5b2fc9eb753590173c48d2ee310884d49ac427bc8a30ca1e3fc8203e137854385a6029699b8a028e9619d14be530a48d1ad08476114b55fed903c4141c2c745e1a5526e9d73cff87627c441f87eca415aa0a305d9af3f0be41d30d8c3806640698c08",
                DateA = new DateTime(2010, 5, 19),
                DateD = new DateTime(2014, 9, 11),
                Sort = 1559854015,
                Note = "2a56f3a30e414fd7ab2ba22acc438d1f6a079e3e76cf43aa9f4572debd961143b53387320c3e421aa083a0186f71e61fd001cb9fa7bf41c8add5036ebc6ac9347137aee0aa8649318619aecfd99ef1f0ac7c218378c9447592b29c6112d630a8adbe345998ba4f479bb875ce2e497466dc7d80c615524f928353d9fb7c12324f1cebe3239c4b481c9fecae03f40a15da25d31a4e8c6c43e6b8fecd7239c22ea30d6934314ee148b0a5b9e78420ae49138c694eba6aae4330b73ff9e9eb71275dfa854c102edd4eaa86fc3cef83d18de1ea68bea1900c410cb8a177f8e8a421829a72a9de6a4146efb29bd8869bfbd3ca7bcf3fc127134116bb4d",
                Status = "b3b747f434664228af0eaf58c4b8aaec3bce22c9d12e48eb99"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.UpdateAsync(Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"), input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("7767810b-ee33-49a7-8db9-fae70af1264f"));
            result.CompanyJobId.ShouldBe(Guid.Parse("8bf56317-a77d-48dd-b1b8-a9fbb410a38e"));
            result.DrvingLicenseCode.ShouldBe("487a087b7f8f47f3b2566cfc995a2fb65ddeb863261e4a4786");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("21d71c6dad244e0f9fe467c2c61aad2355dab48e463c4ba18c99e93f84ee5543ec80fd2fa2bc464d975df254a0c2b1508decfdac7f7147afae4895f3125a2e4abe73069477554b0783c6d7a5af8c4d8b2db6964a70374e77a5ebf56dcd50fdd2b49a5cf5890f470e9b9f3a537a4eaa36c32a482215514f0b9f0b643c73fd9b9d75e18feccc6c4e568cee8c9ec51b245414bb7b76d1084fb5b2fc9eb753590173c48d2ee310884d49ac427bc8a30ca1e3fc8203e137854385a6029699b8a028e9619d14be530a48d1ad08476114b55fed903c4141c2c745e1a5526e9d73cff87627c441f87eca415aa0a305d9af3f0be41d30d8c3806640698c08");
            result.DateA.ShouldBe(new DateTime(2010, 5, 19));
            result.DateD.ShouldBe(new DateTime(2014, 9, 11));
            result.Sort.ShouldBe(1559854015);
            result.Note.ShouldBe("2a56f3a30e414fd7ab2ba22acc438d1f6a079e3e76cf43aa9f4572debd961143b53387320c3e421aa083a0186f71e61fd001cb9fa7bf41c8add5036ebc6ac9347137aee0aa8649318619aecfd99ef1f0ac7c218378c9447592b29c6112d630a8adbe345998ba4f479bb875ce2e497466dc7d80c615524f928353d9fb7c12324f1cebe3239c4b481c9fecae03f40a15da25d31a4e8c6c43e6b8fecd7239c22ea30d6934314ee148b0a5b9e78420ae49138c694eba6aae4330b73ff9e9eb71275dfa854c102edd4eaa86fc3cef83d18de1ea68bea1900c410cb8a177f8e8a421829a72a9de6a4146efb29bd8869bfbd3ca7bcf3fc127134116bb4d");
            result.Status.ShouldBe("b3b747f434664228af0eaf58c4b8aaec3bce22c9d12e48eb99");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDrvingLicensesAppService.DeleteAsync(Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"));

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"));

            result.ShouldBeNull();
        }
    }
}