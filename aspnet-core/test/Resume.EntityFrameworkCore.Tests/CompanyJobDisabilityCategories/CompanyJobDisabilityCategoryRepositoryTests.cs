using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobDisabilityCategories;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobDisabilityCategoryRepository _companyJobDisabilityCategoryRepository;

        public CompanyJobDisabilityCategoryRepositoryTests()
        {
            _companyJobDisabilityCategoryRepository = GetRequiredService<ICompanyJobDisabilityCategoryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDisabilityCategoryRepository.GetListAsync(
                    companyMainId: Guid.Parse("2511c2e4-31d8-49e0-be46-204f36f389b3"),
                    companyJobId: Guid.Parse("dbcc1e21-812f-437b-887c-53f3dac57c49"),
                    disabilityCategoryCode: "c3bc3e93ccd24fd18383a91b0bb37192e5dc1749654f418da1",
                    disabilityLevelCode: "c8abf1d59398497cb51981d0429beee32ebae678899d49f9af",
                    disabilityCertifiedDocumentsNeed: true,
                    extendedInformation: "20377d16fe4f46329d0fc4e777d23ef561d506a12ab142679f34b8f7e266fd9b412d7d3ac83340198aaf4db1fadf727f72f28032f1d747628c21b82d14f06c164043aa2d2f0047efbb646fa9002f33f57fe2929082e4430396fb9e1c0afb17f5ef19e20b0db5487991f2fccf4f885cd2ce85acaf255b4823baa773541b86b931bdabab76d5ba4ecaa917c05a7bfa5f4a112c63ef12944885830609223b115d2d3dd76cb0dc9b4272be771b78fbcdb6d477e812ee6ff546c0bffbd2fca8b2926237f4f8c37eca4abf8063a31167cd18ce9bc83c1b1f6544e2a09bc6c692f4bca62ea01098fbfa40d7b150e074bbe6323e357b818f2ea649bdb63f",
                    note: "5ae54eb4e8be47338c16a0b5a9f215c7969bb36bf7004c3eb88d0d9344cd48c35c912a05889e41b8a09d8bdc9eebdd6a5e33cde2e5c0432cb73646508e34e58e62c2c03a108e48bf8d6b0b6df34fd43f5d26e74bbbd34561a1830650265dd62855cccde183ba4117aa5969a1fdd000ec65e1340dd13043beb7c5ee7d3628c47ef1388b5c4eea4a7b880c5dfb4c694aa1b832ac5e492a4cf1bcd03b0b04409e487625a0c5d30143ed9e94aa43540e302dc7f9a949491a472b8c8a0f0d3283bb0109a219959cbe400095dc379cafc0fcc0bc1f556c0d084c7ca6ae79187caa68ac8eff2b36def0457dacb57d848fb09361a41e852880c04d10ba55",
                    status: "6a77a2da53154f9e9d8ec9550fa7b901ec9f94685ae8485a9d"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("53e66dda-7799-406e-b139-021069e0b337"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDisabilityCategoryRepository.GetCountAsync(
                    companyMainId: Guid.Parse("74d9eb44-cd6e-4d43-b493-e9540dd83d80"),
                    companyJobId: Guid.Parse("949256c8-009c-47ea-b2dd-fb743a68b414"),
                    disabilityCategoryCode: "f40f7227a3c948f189de1f80aa69fb52c3a96dd859e14f169c",
                    disabilityLevelCode: "a6ff37a3b0144daa80dca3e3657077fea90b434c6d1d485bae",
                    disabilityCertifiedDocumentsNeed: true,
                    extendedInformation: "c857896c617241d5b45e4ec55937a39454d67513ba70441aa6e2675131e7d380b9742b1758964677881e462c6d6952e52815f328854b46709364d1cbf3655d96298d7f4957b54d729cf7625ad53a831fb38948658bcf4f1bb1b9e086d008ce21cd6168227bed4aa7ac374cf1b6298a9dd946ee3a568e4d16926fd1b4f300698a546d7c0812e1488587d40f4e9e5c776b56eed0572c3140dd9b1444e270a6ac073224e7501f2641b3a45baf63690974c7e3fc4232ad864d4d84a9b594ed73541bd73247aaa54e40df8d379327f7b6d04f499144fedd3a4b16948e6ad5d4bd5b482025cc0497cd4ecdb5c97dcb3556ee2b299e308b5124459bb5af",
                    note: "7ebc631b6db54224b0bf3280387a528577293ed496334e028e3ca01461e0ce689d78fbfaabf741d89f42157488dd36aa6ee75bb461f14fa4a2b71b6b1b5f0daa7c4260a8c35a484c96c618514294b9c621ea62cbc58c498e8e00084ff6493c396426ee80764a41099e700daa2a4db1c54303fa42bf8a4093b87fe46525ea4a390cd7b7f801e24f99a9254642992fd0b22806b8711d0f4e92a2e8f23a084f6203938598c0bf994a6caaa37fc0e0dbe040c477c3b5cc154c42b0f804dea35a7c7bc531e54c830041bfa5d61cdc2e7a889c7101d1cdb6594d52b2ef258ed290f037213203e893ad42ba8f1fffbf6e3dd58d69bce23fda1a416eb16d",
                    status: "c9089af6a64f4021970c4230e20c412b9ea70028f0da4bf5b7"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}