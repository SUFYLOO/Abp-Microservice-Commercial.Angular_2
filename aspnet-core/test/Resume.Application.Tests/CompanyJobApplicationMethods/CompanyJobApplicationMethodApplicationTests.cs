using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobApplicationMethodsAppService _companyJobApplicationMethodsAppService;
        private readonly IRepository<CompanyJobApplicationMethod, Guid> _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodsAppServiceTests()
        {
            _companyJobApplicationMethodsAppService = GetRequiredService<ICompanyJobApplicationMethodsAppService>();
            _companyJobApplicationMethodRepository = GetRequiredService<IRepository<CompanyJobApplicationMethod, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetListAsync(new GetCompanyJobApplicationMethodsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ed46678e-5e14-484e-a64b-a70547eed0ad")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetAsync(Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodCreateDto
            {
                CompanyMainId = Guid.Parse("8e922527-dcc8-45fd-a579-476f4c73a121"),
                CompanyJobId = Guid.Parse("7a2d3d49-23ed-43ca-b5ce-542a07a97a9a"),
                OrgDept = "c32ead2d303746a2a5e79cf505e413049393427b2db74eb5b7981fb83a6c0dc4b8fca1830d25442ca83ccb8b53bd88b619be04cb023647588af826be9f0fd34b1e0b4d87cc48476c8f02969fc3c8215709c447fe6ed14542b5d7f3d95acd80e08d844eff1d2d49918677c021d49c1b1e3f43391471df42a89cc1f02fec3f61e11ddcca179412474eb2f3edabbc9c2c0498f316625cfc446ea499764b9d11cbd382cb40d731d34914a534e4e24c2222082c23fe48f00d4863931554f52495054897f354534fd94ff8b0a931bc78ffe1453af8f9e0333e4645a60a39522bd15c78f8705c078d5e44f79de56ae35677c47392eeb777c10f4caeb46f",
                OrgContactPerson = "06ccfa7f99fa4c8faef2083023d4ae0c2f31c78f0ef64b21b8",
                OrgContactMail = "c70ba7cf540d4c77a8dbd5dc9416dff075f8c45253c84de4a3c5fc88b6cf6607cd7ca10fac2f4d08ac69933860f1a2ce60e023cde88c4948a1b812b82755c336aa0f3e129089483f86858b8814198045f0c4761e67044d1c8665d0deae60b8e06c63c2f13ab54ceab7d6142bb5d2c6a35e49d6da885f4ed4ac3c7fc7fa17273fef4a79c99b4e48f3a9404b09ca12312f3f48841201f14136a8b4fc243faf0b14b5d8f60e553e4fd18609f294ed0bf7c1b92425b36a0c45dda1e8f375f43e7248d75d933859974713bd3b4cbe515db4465d7c2d78957545b995daecbd3c9454eee45be42a98ef4f0785fd027a96d4964fe7cfa41e3e6f4137b02f",
                ToRespondDay = 1318074074,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "60cfcf8e1c484fccae1aee96839987e6484d8d606c434e91b7",
                Personally = "8445e87911524004bc43ed84ea796a123c38eee51a524925b9663bd18b532d931fb0b2bb10dd44488f3c570d60de74c55f1202a8debf42a5a779d3b947beb838e179b436d0cf4225b93ff13b26e391c28705968aa6c14a9286259c6f1fd22abd56cb1221",
                PersonallyAddress = "9b55942ec3194b1c8e92d4b5115ef1b4e5672422ec3846a6a3bd3850e74fa36706e565ebbe0f4e76a98f0fc89143ac97001f0d3be55e473794cf97c00a69541940b150313bca448b840075da445f35ca783180b19c264d46900d846e42bae93a646bc52a",
                ExtendedInformation = "9d8b2cf729764506be0d93df06674f554e66a798e55f4021922a9a510a7ad4cbb0fd617ec5d94b3c81e39f23d6f92de9cd8611a18bc144ed9c5c4fc490b2a063deace71311f6474d9e8be6e3c06ecc622a161424b06d4b599f5c7fa430c0370977848a8354c644aeb70783da4749d936aa070c2a865f4d85a02b04a7e5a543a2aaa0337cd235498db6f0be55c98ee724b1d241c9b3b5488c902d0bd6f8be8e265630ecc1588d49db9c71f617f74a21bc2b2467ff2be04f3fafdef512b5c87d24990350f95a6a46da9cf3499abf1b9806cc556346f96346d9a1b425d660292122a7cc2893d9d24a7bbbc139e4db563981238586655ddc4e018eca",
                DateA = new DateTime(2021, 2, 26),
                DateD = new DateTime(2011, 10, 14),
                Sort = 352062074,
                Note = "6a47a9a6dbbb4210a3d6bcead4b824a459c139a67dd04cf49551eb7b28b4417e74b5dbeab9f344f8aa10ad346a47a673ef040d547e514215a133ddcff69e311eab24972a7c7742a993df2ef77ba065103bec293d8b8442cc8c3116098b9bf6423a20dcc36cd2498aa3b9c934d767cad1a13d3a180d1d48078f1261bca238738ff1c8aedf52074e3bbb781bd786a34a75c0a173c1f5d44966abb8218fa43f31c882c81dcf5fe045ed992cce6ba4ef1f4ed31a627e2f7445dc978b0da5eeecae081574a8c6225e42e690ae2db14d876a5429547502bd8e4002afbcb05cc9671e9c679a13a6cec04d089a1f2e8146c2878c8c5a825ec54f4e118c2b",
                Status = "3869e453425c4f808534579466566fa3228eec24ce85413fbd"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("8e922527-dcc8-45fd-a579-476f4c73a121"));
            result.CompanyJobId.ShouldBe(Guid.Parse("7a2d3d49-23ed-43ca-b5ce-542a07a97a9a"));
            result.OrgDept.ShouldBe("c32ead2d303746a2a5e79cf505e413049393427b2db74eb5b7981fb83a6c0dc4b8fca1830d25442ca83ccb8b53bd88b619be04cb023647588af826be9f0fd34b1e0b4d87cc48476c8f02969fc3c8215709c447fe6ed14542b5d7f3d95acd80e08d844eff1d2d49918677c021d49c1b1e3f43391471df42a89cc1f02fec3f61e11ddcca179412474eb2f3edabbc9c2c0498f316625cfc446ea499764b9d11cbd382cb40d731d34914a534e4e24c2222082c23fe48f00d4863931554f52495054897f354534fd94ff8b0a931bc78ffe1453af8f9e0333e4645a60a39522bd15c78f8705c078d5e44f79de56ae35677c47392eeb777c10f4caeb46f");
            result.OrgContactPerson.ShouldBe("06ccfa7f99fa4c8faef2083023d4ae0c2f31c78f0ef64b21b8");
            result.OrgContactMail.ShouldBe("c70ba7cf540d4c77a8dbd5dc9416dff075f8c45253c84de4a3c5fc88b6cf6607cd7ca10fac2f4d08ac69933860f1a2ce60e023cde88c4948a1b812b82755c336aa0f3e129089483f86858b8814198045f0c4761e67044d1c8665d0deae60b8e06c63c2f13ab54ceab7d6142bb5d2c6a35e49d6da885f4ed4ac3c7fc7fa17273fef4a79c99b4e48f3a9404b09ca12312f3f48841201f14136a8b4fc243faf0b14b5d8f60e553e4fd18609f294ed0bf7c1b92425b36a0c45dda1e8f375f43e7248d75d933859974713bd3b4cbe515db4465d7c2d78957545b995daecbd3c9454eee45be42a98ef4f0785fd027a96d4964fe7cfa41e3e6f4137b02f");
            result.ToRespondDay.ShouldBe(1318074074);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("60cfcf8e1c484fccae1aee96839987e6484d8d606c434e91b7");
            result.Personally.ShouldBe("8445e87911524004bc43ed84ea796a123c38eee51a524925b9663bd18b532d931fb0b2bb10dd44488f3c570d60de74c55f1202a8debf42a5a779d3b947beb838e179b436d0cf4225b93ff13b26e391c28705968aa6c14a9286259c6f1fd22abd56cb1221");
            result.PersonallyAddress.ShouldBe("9b55942ec3194b1c8e92d4b5115ef1b4e5672422ec3846a6a3bd3850e74fa36706e565ebbe0f4e76a98f0fc89143ac97001f0d3be55e473794cf97c00a69541940b150313bca448b840075da445f35ca783180b19c264d46900d846e42bae93a646bc52a");
            result.ExtendedInformation.ShouldBe("9d8b2cf729764506be0d93df06674f554e66a798e55f4021922a9a510a7ad4cbb0fd617ec5d94b3c81e39f23d6f92de9cd8611a18bc144ed9c5c4fc490b2a063deace71311f6474d9e8be6e3c06ecc622a161424b06d4b599f5c7fa430c0370977848a8354c644aeb70783da4749d936aa070c2a865f4d85a02b04a7e5a543a2aaa0337cd235498db6f0be55c98ee724b1d241c9b3b5488c902d0bd6f8be8e265630ecc1588d49db9c71f617f74a21bc2b2467ff2be04f3fafdef512b5c87d24990350f95a6a46da9cf3499abf1b9806cc556346f96346d9a1b425d660292122a7cc2893d9d24a7bbbc139e4db563981238586655ddc4e018eca");
            result.DateA.ShouldBe(new DateTime(2021, 2, 26));
            result.DateD.ShouldBe(new DateTime(2011, 10, 14));
            result.Sort.ShouldBe(352062074);
            result.Note.ShouldBe("6a47a9a6dbbb4210a3d6bcead4b824a459c139a67dd04cf49551eb7b28b4417e74b5dbeab9f344f8aa10ad346a47a673ef040d547e514215a133ddcff69e311eab24972a7c7742a993df2ef77ba065103bec293d8b8442cc8c3116098b9bf6423a20dcc36cd2498aa3b9c934d767cad1a13d3a180d1d48078f1261bca238738ff1c8aedf52074e3bbb781bd786a34a75c0a173c1f5d44966abb8218fa43f31c882c81dcf5fe045ed992cce6ba4ef1f4ed31a627e2f7445dc978b0da5eeecae081574a8c6225e42e690ae2db14d876a5429547502bd8e4002afbcb05cc9671e9c679a13a6cec04d089a1f2e8146c2878c8c5a825ec54f4e118c2b");
            result.Status.ShouldBe("3869e453425c4f808534579466566fa3228eec24ce85413fbd");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodUpdateDto()
            {
                CompanyMainId = Guid.Parse("6649ef15-169f-4cff-b113-42a403b76acb"),
                CompanyJobId = Guid.Parse("3df5be7f-10fe-4c9b-9eb5-737c57613565"),
                OrgDept = "dcc24d6d37a449d1b2a1f7e2a28bd27a9877e8a82b914f379d5367e95efd2ba6f1f47768f5234bd4a8e0a7140a9baa2f290afb1b3a744a0791f5778e3ea3d3721866d2f3a00c48269cb5dda3dd686c7089dc851d959546a3bd7a5319b21aa744abe4514f0b744ee5ad6025d8e19d02b483c0408eb8524aae8240317125497ee9d2f0b9f1330740d7af71222cb9c74e9e6c9b88d2694b43b5a7d06854df29e99c04bdba6a8d2740bdb8d29f6173d27390718f981fbeb842dca563c5403a735f53fcd1731ab3bb43fd82b979b9510d4fd308f70aa6c26c497cb45a1ff4327ecaa58352656a89cd4e3995e8c856f968eeb1fa4d53b408ee4cfab3ff",
                OrgContactPerson = "e90fac22ff00403ba94b0bd5c0a7ccd68f277c88067f4a41aa",
                OrgContactMail = "f7cf42f097224f349cd27f0caa69436d73bdcc8de1324ac78ce84f9c09797edea718b88e81624dcb99a5bd5872f1469749ff5f3a05344b85a9eff858d6629aed366b1f0d35c64b23991b2e6cecedb713bd7a3336210c454b9c7519a1ff16e6ffc493e1761198405ba34d2a65aee50775d490d121a0a54554bd7bc4f2aaaf50d3fc5a1fc576454d468649833a5d81106270a39712c0024d8591b3dc5db8ba2f030620f94e4ecc487c8f6aad7a487a4c7c0fe5e0d01fc149acbfb414714a9916f7892cd2a8dfd1427094c8263fcfc258a4a767a58a3bad4a8fa0dcf959d78a3542dfa501f002f14843a83d89e732aba090e0091c09ca8e459b99ab",
                ToRespondDay = 1034421431,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "338e17dea56247569ac4fe074b7ef299dc30044d89f6414e97",
                Personally = "4c60510e90a84c81af0e0032a7125e20e274adea59f04360a316d11e4404603537f2c9821d72459aa7313bf07c950f1488dfbfabaee248c385de8487cea5e6de3274828269a14cc789543a724d7b287f5be6aeb148064459a0d4a6ed7371c9b0524487c2",
                PersonallyAddress = "f22085dd33fe43fe961b9043a4dca33c330608cf3ae248888b348c9e0478dbbdae044fc85c844f829b730cc3b3149b89db312b028ff94e7e93d8ee54b18772b841d1a2c683154cf2b72cc6ebfb062c1bd62e5f35530149799077b148978fac661ba15e91",
                ExtendedInformation = "741c2c0efdc0475ca9b9f23160cd027a9cb1d22521504912af622ed2b1654c61960c5a410d9149c0acd4f38932e80dfb8d3d969729ce4c489874ade8c3103dabbc7eafe05c42466cbb258708b5c5493af697b9e93202492f93e5b2aaa9cd49552db1e9896fe14be683bfbe93c8f2d56b01c7864e32304419b176c2f07aa4e00ccde66faced954c82a160c7b5a78aed4699677523448a4620a8e094fa70d999333b266cf8ac284ce1948257ae772c932a45daa6a461954820905ed629a63e8f31362fa125471046bc8a799c32db09c9df89996cdd9ae84c268cf0b759a46815befbab69c073c64c64be0855a361b4747a99ecae3c2be045c99ea6",
                DateA = new DateTime(2016, 4, 11),
                DateD = new DateTime(2007, 4, 3),
                Sort = 1293413309,
                Note = "efdcc56b3582452c936b06550f525fe59b8a6ddf80604bf1846624cbcbfee19e2fc8b99ec45548c787f54c54d5a6a835e958a3432d794b828e18c9e835456adbb119d6b25bad4d85b71552f7185d2769efc7ef6c6bfb40f8993147612afb353e81fdf28bf77a43b0b33a4ae8fbbb72d5a9ffa90c59534b6193cbef77ee50d54bc1a2d1c9452a4e29a41d402534f1ea08ab871c7cb1a3488dbeea2f5fd6ff586e9792dca922994b98b5a8e4fdd86caaf423c018ce1e0842ecbcbe187c10ac8f2e7b5dc84dc23248dfb072269ad05097637399bbfff3a4400eb3512fd59e7d9de6bdfe2a4790ce4c778385f592da9be71dda9ed23af3d648c7a7ba",
                Status = "9dbbb6396cb74ec783b22626157e1a23ee6a0bc6b3654c00be"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.UpdateAsync(Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"), input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("6649ef15-169f-4cff-b113-42a403b76acb"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3df5be7f-10fe-4c9b-9eb5-737c57613565"));
            result.OrgDept.ShouldBe("dcc24d6d37a449d1b2a1f7e2a28bd27a9877e8a82b914f379d5367e95efd2ba6f1f47768f5234bd4a8e0a7140a9baa2f290afb1b3a744a0791f5778e3ea3d3721866d2f3a00c48269cb5dda3dd686c7089dc851d959546a3bd7a5319b21aa744abe4514f0b744ee5ad6025d8e19d02b483c0408eb8524aae8240317125497ee9d2f0b9f1330740d7af71222cb9c74e9e6c9b88d2694b43b5a7d06854df29e99c04bdba6a8d2740bdb8d29f6173d27390718f981fbeb842dca563c5403a735f53fcd1731ab3bb43fd82b979b9510d4fd308f70aa6c26c497cb45a1ff4327ecaa58352656a89cd4e3995e8c856f968eeb1fa4d53b408ee4cfab3ff");
            result.OrgContactPerson.ShouldBe("e90fac22ff00403ba94b0bd5c0a7ccd68f277c88067f4a41aa");
            result.OrgContactMail.ShouldBe("f7cf42f097224f349cd27f0caa69436d73bdcc8de1324ac78ce84f9c09797edea718b88e81624dcb99a5bd5872f1469749ff5f3a05344b85a9eff858d6629aed366b1f0d35c64b23991b2e6cecedb713bd7a3336210c454b9c7519a1ff16e6ffc493e1761198405ba34d2a65aee50775d490d121a0a54554bd7bc4f2aaaf50d3fc5a1fc576454d468649833a5d81106270a39712c0024d8591b3dc5db8ba2f030620f94e4ecc487c8f6aad7a487a4c7c0fe5e0d01fc149acbfb414714a9916f7892cd2a8dfd1427094c8263fcfc258a4a767a58a3bad4a8fa0dcf959d78a3542dfa501f002f14843a83d89e732aba090e0091c09ca8e459b99ab");
            result.ToRespondDay.ShouldBe(1034421431);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("338e17dea56247569ac4fe074b7ef299dc30044d89f6414e97");
            result.Personally.ShouldBe("4c60510e90a84c81af0e0032a7125e20e274adea59f04360a316d11e4404603537f2c9821d72459aa7313bf07c950f1488dfbfabaee248c385de8487cea5e6de3274828269a14cc789543a724d7b287f5be6aeb148064459a0d4a6ed7371c9b0524487c2");
            result.PersonallyAddress.ShouldBe("f22085dd33fe43fe961b9043a4dca33c330608cf3ae248888b348c9e0478dbbdae044fc85c844f829b730cc3b3149b89db312b028ff94e7e93d8ee54b18772b841d1a2c683154cf2b72cc6ebfb062c1bd62e5f35530149799077b148978fac661ba15e91");
            result.ExtendedInformation.ShouldBe("741c2c0efdc0475ca9b9f23160cd027a9cb1d22521504912af622ed2b1654c61960c5a410d9149c0acd4f38932e80dfb8d3d969729ce4c489874ade8c3103dabbc7eafe05c42466cbb258708b5c5493af697b9e93202492f93e5b2aaa9cd49552db1e9896fe14be683bfbe93c8f2d56b01c7864e32304419b176c2f07aa4e00ccde66faced954c82a160c7b5a78aed4699677523448a4620a8e094fa70d999333b266cf8ac284ce1948257ae772c932a45daa6a461954820905ed629a63e8f31362fa125471046bc8a799c32db09c9df89996cdd9ae84c268cf0b759a46815befbab69c073c64c64be0855a361b4747a99ecae3c2be045c99ea6");
            result.DateA.ShouldBe(new DateTime(2016, 4, 11));
            result.DateD.ShouldBe(new DateTime(2007, 4, 3));
            result.Sort.ShouldBe(1293413309);
            result.Note.ShouldBe("efdcc56b3582452c936b06550f525fe59b8a6ddf80604bf1846624cbcbfee19e2fc8b99ec45548c787f54c54d5a6a835e958a3432d794b828e18c9e835456adbb119d6b25bad4d85b71552f7185d2769efc7ef6c6bfb40f8993147612afb353e81fdf28bf77a43b0b33a4ae8fbbb72d5a9ffa90c59534b6193cbef77ee50d54bc1a2d1c9452a4e29a41d402534f1ea08ab871c7cb1a3488dbeea2f5fd6ff586e9792dca922994b98b5a8e4fdd86caaf423c018ce1e0842ecbcbe187c10ac8f2e7b5dc84dc23248dfb072269ad05097637399bbfff3a4400eb3512fd59e7d9de6bdfe2a4790ce4c778385f592da9be71dda9ed23af3d648c7a7ba");
            result.Status.ShouldBe("9dbbb6396cb74ec783b22626157e1a23ee6a0bc6b3654c00be");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobApplicationMethodsAppService.DeleteAsync(Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"));

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"));

            result.ShouldBeNull();
        }
    }
}