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
            result.Items.Any(x => x.Id == Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2ae42dc4-a0cd-4630-b17d-85b2fe064f81")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyContractsAppService.GetAsync(Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyContractCreateDto
            {
                CompanyMainId = Guid.Parse("fbcddcbe-9577-49ee-8637-9136aa6df51c"),
                PlanCode = "46a1a4fe9a9b49879a56223d8140bf58f2e255e53fcd401daa",
                PointsTotal = 919162553,
                PointsPay = 1035457662,
                PointsGift = 115582575,
                ExtendedInformation = "eb8b02a663104500b45159d9bc6ec4cc0ede525eaf2840e69182459a7ff29bad5eadd867646c441fb1e081b409d281baf68713457cbc4ade853fc24ad1ff0157c78bf5480e174ab799987db14ce9438f127ec6cb1a6540e7902ac86ff331e0ca9f874610691b483793472e7da33777c88c0f2cfc423f40798b1c2dc7e44090941b1ac026662a4c18a8bdd9233a99a1d7a56ecbffb61648659e4e29564a87c60b7a86f03491894a0cb5faa479464d0bd28e6e82ffb4ec401b830a4e65ee65e803d0054944ec184cbba4dd4168565332d385a7daba1a71464094a61dfc48d3ad407600cb0ee5d24ed0b846e70cc169858daba41505251543d98bb0",
                DateA = new DateTime(2020, 7, 9),
                DateD = new DateTime(2013, 2, 25),
                Sort = 1750750339,
                Note = "201c0de1827c4bc59555f49551c88c11327209b3cd3c4c6f881f9ce734f78c87d14ff907623e460ab3c33994b64e34b9f155099b409c4f3a94d8a3a2f7b30937b19ad12ba40146d6b44815dd876ba19334760a06242743c98b30091f5b4bac78a97bae0bffa14324a4fb7a2e5ca2b6b549df8e5b1c7743e2b72b95bbe01ae933dd72c97e410a4808b9d9d1abec05f24c669d9480e49b46cea59057313311cf10ed0c3029a24741aa945ed31325268929beb931853f754e1b863fc3750ea83c3b1a146b09b2f6499d9d3c39bc10c525c508225c34b0344c82908abf253c35527e6462c905da3f4da892f81ba29bf38d6c361d0508fd6949929da6",
                Status = "e3e5b538bfc84400b407f470d204f49263737a375cd248d8ac"
            };

            // Act
            var serviceResult = await _companyContractsAppService.CreateAsync(input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("fbcddcbe-9577-49ee-8637-9136aa6df51c"));
            result.PlanCode.ShouldBe("46a1a4fe9a9b49879a56223d8140bf58f2e255e53fcd401daa");
            result.PointsTotal.ShouldBe(919162553);
            result.PointsPay.ShouldBe(1035457662);
            result.PointsGift.ShouldBe(115582575);
            result.ExtendedInformation.ShouldBe("eb8b02a663104500b45159d9bc6ec4cc0ede525eaf2840e69182459a7ff29bad5eadd867646c441fb1e081b409d281baf68713457cbc4ade853fc24ad1ff0157c78bf5480e174ab799987db14ce9438f127ec6cb1a6540e7902ac86ff331e0ca9f874610691b483793472e7da33777c88c0f2cfc423f40798b1c2dc7e44090941b1ac026662a4c18a8bdd9233a99a1d7a56ecbffb61648659e4e29564a87c60b7a86f03491894a0cb5faa479464d0bd28e6e82ffb4ec401b830a4e65ee65e803d0054944ec184cbba4dd4168565332d385a7daba1a71464094a61dfc48d3ad407600cb0ee5d24ed0b846e70cc169858daba41505251543d98bb0");
            result.DateA.ShouldBe(new DateTime(2020, 7, 9));
            result.DateD.ShouldBe(new DateTime(2013, 2, 25));
            result.Sort.ShouldBe(1750750339);
            result.Note.ShouldBe("201c0de1827c4bc59555f49551c88c11327209b3cd3c4c6f881f9ce734f78c87d14ff907623e460ab3c33994b64e34b9f155099b409c4f3a94d8a3a2f7b30937b19ad12ba40146d6b44815dd876ba19334760a06242743c98b30091f5b4bac78a97bae0bffa14324a4fb7a2e5ca2b6b549df8e5b1c7743e2b72b95bbe01ae933dd72c97e410a4808b9d9d1abec05f24c669d9480e49b46cea59057313311cf10ed0c3029a24741aa945ed31325268929beb931853f754e1b863fc3750ea83c3b1a146b09b2f6499d9d3c39bc10c525c508225c34b0344c82908abf253c35527e6462c905da3f4da892f81ba29bf38d6c361d0508fd6949929da6");
            result.Status.ShouldBe("e3e5b538bfc84400b407f470d204f49263737a375cd248d8ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyContractUpdateDto()
            {
                CompanyMainId = Guid.Parse("2a63395b-ec3b-4140-a684-4b5db776150e"),
                PlanCode = "2ce7f47e42824c9995f10eab9f2fad75af0688ae039a488a99",
                PointsTotal = 776165578,
                PointsPay = 918571434,
                PointsGift = 1890056250,
                ExtendedInformation = "22796c20f9f647cd94c75b4e7ff6921be13801a26623414bbbce3070f8abb588ad3fc00bf01a4380bc90c349c99313587d85d5bf5f5b4f2fa9f61460f0057440deb6ff8dab9a481da7db692a85c3473a330237ec6b704561b41fa7acd65cb36dad9f7892c46249ea8913e477bf2836be3b277189ee92479fa3c0cc9b2e1f03e61158161c25aa44fdb0d9b81a2c2e50f1f1538fcc4108491c8f106e2ffe3c7683cdeb32be5138437c88e0d792efe237a7ce82923a74ee46178ecb2be54eb6470bf99618ecbdf944318b0f588ad3e1a64b0780456028854f8f98a8369774300aa6e92f3516692141718b2e46bf47039227cf97254eda76448a8c98",
                DateA = new DateTime(2010, 1, 8),
                DateD = new DateTime(2015, 9, 1),
                Sort = 1935006646,
                Note = "c5e5a9ae563e430a8e491d428968a52aeb7f723b4a5345fea04115d2c3b11b6123af28cb3f604fa4800b2f3fa900d365c0cff3f132134258be9aa8c529a227234715d0ba91124e148a31544fcdb5c12c2c7dc8f7cc284462b3e1ba4f96f6971337e93673b19b47f08db000bd20db20ec595b4e3497a342a3bcc6624900a14d1a17406343bfd143dab6a80cabd5d835e4fd561cfd7b0e4439abdc10ec9f87de06b11e184b320d40ab9194930b1607cfeb4b6b392d88bd42ada9a718da84a52ec0e5641386bd414101a5876b47594cf0a09c971db427ac457ab962302bbcc0b624ff882aed9b304d1a97564746ed455dbd2a306b5880c945d29f6e",
                Status = "78952f9c31b3473baf1f5d8c661a998afe9b172d7b534e9b8e"
            };

            // Act
            var serviceResult = await _companyContractsAppService.UpdateAsync(Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"), input);

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("2a63395b-ec3b-4140-a684-4b5db776150e"));
            result.PlanCode.ShouldBe("2ce7f47e42824c9995f10eab9f2fad75af0688ae039a488a99");
            result.PointsTotal.ShouldBe(776165578);
            result.PointsPay.ShouldBe(918571434);
            result.PointsGift.ShouldBe(1890056250);
            result.ExtendedInformation.ShouldBe("22796c20f9f647cd94c75b4e7ff6921be13801a26623414bbbce3070f8abb588ad3fc00bf01a4380bc90c349c99313587d85d5bf5f5b4f2fa9f61460f0057440deb6ff8dab9a481da7db692a85c3473a330237ec6b704561b41fa7acd65cb36dad9f7892c46249ea8913e477bf2836be3b277189ee92479fa3c0cc9b2e1f03e61158161c25aa44fdb0d9b81a2c2e50f1f1538fcc4108491c8f106e2ffe3c7683cdeb32be5138437c88e0d792efe237a7ce82923a74ee46178ecb2be54eb6470bf99618ecbdf944318b0f588ad3e1a64b0780456028854f8f98a8369774300aa6e92f3516692141718b2e46bf47039227cf97254eda76448a8c98");
            result.DateA.ShouldBe(new DateTime(2010, 1, 8));
            result.DateD.ShouldBe(new DateTime(2015, 9, 1));
            result.Sort.ShouldBe(1935006646);
            result.Note.ShouldBe("c5e5a9ae563e430a8e491d428968a52aeb7f723b4a5345fea04115d2c3b11b6123af28cb3f604fa4800b2f3fa900d365c0cff3f132134258be9aa8c529a227234715d0ba91124e148a31544fcdb5c12c2c7dc8f7cc284462b3e1ba4f96f6971337e93673b19b47f08db000bd20db20ec595b4e3497a342a3bcc6624900a14d1a17406343bfd143dab6a80cabd5d835e4fd561cfd7b0e4439abdc10ec9f87de06b11e184b320d40ab9194930b1607cfeb4b6b392d88bd42ada9a718da84a52ec0e5641386bd414101a5876b47594cf0a09c971db427ac457ab962302bbcc0b624ff882aed9b304d1a97564746ed455dbd2a306b5880c945d29f6e");
            result.Status.ShouldBe("78952f9c31b3473baf1f5d8c661a998afe9b172d7b534e9b8e");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyContractsAppService.DeleteAsync(Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"));

            // Assert
            var result = await _companyContractRepository.FindAsync(c => c.Id == Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"));

            result.ShouldBeNull();
        }
    }
}