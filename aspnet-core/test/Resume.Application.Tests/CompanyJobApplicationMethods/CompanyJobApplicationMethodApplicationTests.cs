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
            result.Items.Any(x => x.Id == Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("ce0ad290-1aa6-48c6-b398-59c2a73d3ce3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetAsync(Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodCreateDto
            {
                CompanyMainId = Guid.Parse("323c7c69-3c9b-4c3c-b0b6-cc36087e189c"),
                CompanyJobId = Guid.Parse("956b4a94-ef01-42e9-b268-b8966719cde9"),
                OrgDept = "91950adf486245b4a6f18783a26e5900aaeedd34c93a4875aa24910511820c91f17527a3b68b424bad9ef784706b83d383d4157a48e34521bb85ba01897a986c8215a65713b54b10a81392579bcfe3c3f04cf2d77dae47d0bd208b58e2b8461ffde18e3ef956456cae730da11aa7c6cf62006e4a725145cd9a72ee87c8f6eb8d9a5fb8afec69494f885ce5f9e57983cc42fafd8475d94e199147968f8e22cbf663d3e31bb5014159a3c1a518b32f231f3c0bfc73092048bbb76f5b14c3fe7c6fc5aca1758d504783934930e2f309f29674cebc9210444edbbe59719bae62d81e590dcd301d9c42279e4dcf77d04bcd1e801fe71b9f504f6f86f7",
                OrgContactPerson = "0434f3c02079402b9ad3392328c66ea1a1768d101b794c9382",
                OrgContactMail = "594986833eb2431584b462501697f440d91961c490524e9d9c2166b944d160a07dfbacff36ea41879204e2fbbd36aac7d08d95dc3cd84e3395a00709d273732cd77ff6fb5237468d94689502bd9a3df016e3b680151447f591fbe903ae1c4c4e369949deaee44b3f8a5f0c619bbe289b3a1fe418186d4194beaa1bfefaf89280a76263be7a0e49eb8bec0eaa568ec7b151c102937a854f91870fce5bcc9ad0c174329c9bc714448a9f892e1690ed82372db8cfba9fef4231b0aea84ae8fde2c1f961ad71a5ef4a928c1df8047e82b14d1c0d558e95ed4548b497031f28fb2e19f99ed5ee4f2f4567ba023b728a2cbb6837ff312f93eb43feb52d",
                ToRespondDay = 223702753,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "fefbfe96b096443abd080006eabaec8114d337926ec34d2699",
                Personally = "7dd254f752204d7e81d8ead2b0a10fe7bb3869ac3afb4c5785b2fe6476f2d4675827bbd26ef64d97b863ab90e516e68a1c838bec4eb74a22a6fa3003bd3beb1bf1d64a1d9ce843ed9a6f5de00c89565a887384f57fe34735aa704f2c17c35f2c9e0c306a",
                PersonallyAddress = "29ffe0e1ecd043dea97e18a225a909b1b6a5fcf14f9b4e109edb58a2e41b1cb62f5e6bf09117407caa55bb3982fce28687b75904613d4c90a6a1a9b6072ddaed58879f5273e044c398adb93bd1c76aa4b2258353a295490798001a0cb8b645b5e5d1b32d",
                ExtendedInformation = "1bc8ea2c3a5848dfae989d3708a13c5af9062bd1df344fbab1309ad1a829535c3d933ec4e57d47fea95b171eb2d1cd00dd2b4341b3b24701ad483dce12cf7f26bea0d3963c53465fa07f5614e92af901d0f32ff5514a4ecc89b1a5d6433098ea634128a9c202401ca7dbcacc46e94e6ca840c694b3ce4a14a2a6176dbba1e236eeda2d8efa364aee81a3668ce6ea53bb4850c449509041d084c3513ad4a0d7a40ef662aa958b42d29616d7996aff00c9ee9c7cc4a262428a9564fa811f8668d05592a81fcc584113b1a126d7a466549f5180c4d70d8643019b7ff9de822f406fcfb5c879671a419b84cf9c2a67726e778be91bc7de9c4298a3a4",
                DateA = new DateTime(2017, 8, 4),
                DateD = new DateTime(2002, 11, 25),
                Sort = 1731213336,
                Note = "3a3b9d509b1b469fa3035fe402c33ab832e2aa5d97b64fc4bc3b83cee3c2f4c269719fde8da543b78e700f82b848e2ec0323106eab0b4f86880207d533dd9fb6a7aa63eeffe64709a5b4bdd289853949d17ad5608b23499fbf9ff481b98e5eb5dc2229258e7b4af88dc20e4ea548431f48442ff456eb4429848a9e216134292c27bfee67c7f34648803f1aab17d56c5f3931d1ac6add45f2a6ad1ff5a9c684135c263e23b0dd4f94ae6e273edffcea583e255fc8a8fe4343a5f13707824dbedba8c128097d7b47568aac03575959735bde6e1a54abcc46d8a199d5ac30e04201b9ccd20eb5e142c28b7dc56fd27c43c565fb10c60a404941ae3f",
                Status = "775dec22be03470981c0360e8a0cb15631867ebded7143f798"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("323c7c69-3c9b-4c3c-b0b6-cc36087e189c"));
            result.CompanyJobId.ShouldBe(Guid.Parse("956b4a94-ef01-42e9-b268-b8966719cde9"));
            result.OrgDept.ShouldBe("91950adf486245b4a6f18783a26e5900aaeedd34c93a4875aa24910511820c91f17527a3b68b424bad9ef784706b83d383d4157a48e34521bb85ba01897a986c8215a65713b54b10a81392579bcfe3c3f04cf2d77dae47d0bd208b58e2b8461ffde18e3ef956456cae730da11aa7c6cf62006e4a725145cd9a72ee87c8f6eb8d9a5fb8afec69494f885ce5f9e57983cc42fafd8475d94e199147968f8e22cbf663d3e31bb5014159a3c1a518b32f231f3c0bfc73092048bbb76f5b14c3fe7c6fc5aca1758d504783934930e2f309f29674cebc9210444edbbe59719bae62d81e590dcd301d9c42279e4dcf77d04bcd1e801fe71b9f504f6f86f7");
            result.OrgContactPerson.ShouldBe("0434f3c02079402b9ad3392328c66ea1a1768d101b794c9382");
            result.OrgContactMail.ShouldBe("594986833eb2431584b462501697f440d91961c490524e9d9c2166b944d160a07dfbacff36ea41879204e2fbbd36aac7d08d95dc3cd84e3395a00709d273732cd77ff6fb5237468d94689502bd9a3df016e3b680151447f591fbe903ae1c4c4e369949deaee44b3f8a5f0c619bbe289b3a1fe418186d4194beaa1bfefaf89280a76263be7a0e49eb8bec0eaa568ec7b151c102937a854f91870fce5bcc9ad0c174329c9bc714448a9f892e1690ed82372db8cfba9fef4231b0aea84ae8fde2c1f961ad71a5ef4a928c1df8047e82b14d1c0d558e95ed4548b497031f28fb2e19f99ed5ee4f2f4567ba023b728a2cbb6837ff312f93eb43feb52d");
            result.ToRespondDay.ShouldBe(223702753);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("fefbfe96b096443abd080006eabaec8114d337926ec34d2699");
            result.Personally.ShouldBe("7dd254f752204d7e81d8ead2b0a10fe7bb3869ac3afb4c5785b2fe6476f2d4675827bbd26ef64d97b863ab90e516e68a1c838bec4eb74a22a6fa3003bd3beb1bf1d64a1d9ce843ed9a6f5de00c89565a887384f57fe34735aa704f2c17c35f2c9e0c306a");
            result.PersonallyAddress.ShouldBe("29ffe0e1ecd043dea97e18a225a909b1b6a5fcf14f9b4e109edb58a2e41b1cb62f5e6bf09117407caa55bb3982fce28687b75904613d4c90a6a1a9b6072ddaed58879f5273e044c398adb93bd1c76aa4b2258353a295490798001a0cb8b645b5e5d1b32d");
            result.ExtendedInformation.ShouldBe("1bc8ea2c3a5848dfae989d3708a13c5af9062bd1df344fbab1309ad1a829535c3d933ec4e57d47fea95b171eb2d1cd00dd2b4341b3b24701ad483dce12cf7f26bea0d3963c53465fa07f5614e92af901d0f32ff5514a4ecc89b1a5d6433098ea634128a9c202401ca7dbcacc46e94e6ca840c694b3ce4a14a2a6176dbba1e236eeda2d8efa364aee81a3668ce6ea53bb4850c449509041d084c3513ad4a0d7a40ef662aa958b42d29616d7996aff00c9ee9c7cc4a262428a9564fa811f8668d05592a81fcc584113b1a126d7a466549f5180c4d70d8643019b7ff9de822f406fcfb5c879671a419b84cf9c2a67726e778be91bc7de9c4298a3a4");
            result.DateA.ShouldBe(new DateTime(2017, 8, 4));
            result.DateD.ShouldBe(new DateTime(2002, 11, 25));
            result.Sort.ShouldBe(1731213336);
            result.Note.ShouldBe("3a3b9d509b1b469fa3035fe402c33ab832e2aa5d97b64fc4bc3b83cee3c2f4c269719fde8da543b78e700f82b848e2ec0323106eab0b4f86880207d533dd9fb6a7aa63eeffe64709a5b4bdd289853949d17ad5608b23499fbf9ff481b98e5eb5dc2229258e7b4af88dc20e4ea548431f48442ff456eb4429848a9e216134292c27bfee67c7f34648803f1aab17d56c5f3931d1ac6add45f2a6ad1ff5a9c684135c263e23b0dd4f94ae6e273edffcea583e255fc8a8fe4343a5f13707824dbedba8c128097d7b47568aac03575959735bde6e1a54abcc46d8a199d5ac30e04201b9ccd20eb5e142c28b7dc56fd27c43c565fb10c60a404941ae3f");
            result.Status.ShouldBe("775dec22be03470981c0360e8a0cb15631867ebded7143f798");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodUpdateDto()
            {
                CompanyMainId = Guid.Parse("4aac4548-26e9-4827-ae4f-9194e7d4c928"),
                CompanyJobId = Guid.Parse("14d24627-6768-4c47-85cf-b3cfd3a94073"),
                OrgDept = "dbc97b34a9f2423983cc55e6444f4d7df9648a950b7643a887935e3a2283806f98c99a0b4eca4f73b0cc0f4a2d8912ba0be52adedb4b4a9a85d0cfb6851652b4153c50263a2f4e3db81ff52b08f76b2546a500a3dfc24f3aaf895fe7949c6ed6b2b7169a8d95431d9dbfc96b3472037f6d7808d1644b46ffbb4e8e0b8b2f976691704c8e4d3343889ec80ade45ff5cf9308d6bcbb2224064b9f81eb7f78448220de986da6d9147679ad8bfb24b5593c20bf6fdd75882434b9f7834a15b702fed0788c6dc48a44350842c48f598f19d7d7f0a9d6aad7141fba4ca3f987f011e2cbee67f9d441b4220b1bb71b151e46a1186cfebddb896441a8e37",
                OrgContactPerson = "339c2e882b394c8995c046caaca5bfe0aa31851f647a493b98",
                OrgContactMail = "3c14b7b7154243679ebbc48f226958c6914f06aca15f4397931cf2cb9e9bd305e2e20b2274934ff7ac6c3eee4b3760533ff5e22aa1d0410ab4a6587f80d25638f65b01e7a2d84269b41b24f45194820b9805e28fa60e4745969f17635e7639869c92198db95c4893b1ad88bcd0fa55455c6ef2a295644e08a24aa5ddb12619dceeea806f718546fe999eff9149af864444200f6fe1784a2e8ea11ca09349416542cf4d113d15465cb2583de0957316d5ce1cfb6e7a974a79b87a81abd01e73d2ea8420fbb27d44838aaf429cbc6ac03821c803456af94830befc98853eca5077553b2681c28849dd9444422b93f2cffbf397cb0f3b5e4544aaac",
                ToRespondDay = 47583274,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "83ea886b432c4f6da4a14bab22903eff5a626914d24048dd8c",
                Personally = "7df8a35fe41a4930924bc506e5064b8ada3cee72382c4f5695fc807064125a3cf1290ce87e114bacaa58c060674d066c841a5a21548449dc9685b5f0c015194c11256ee2db1642249723427efd37af747b0754851287422bafa2503f943e94de34905fe5",
                PersonallyAddress = "1fe38420bc01499ab3187063015764e0db17902dd8ed440faaa12602dd878225664f9a84e7534ce1b4b05e60e941a057ecf8527c23f645b19e9ab06f7f68c2779c5ae5ae52ec45dda21b499a3ea72efc3e97fcf64b584e7eb2ca58509323b8f545ff43a3",
                ExtendedInformation = "5240317bae3c409b8ac2e5d81e106a13a3126099be2249f7926a788effd982a953df609d0f0147798ae5cb2e97cbb1e12f191385a6ac46c7b8887a40ba673816ea6d64b6e8b748c699e31859a857938072342142a50241da872e2df6caaf2e36a41ff897d09b4675879698b30c95311296828b7c91f24e99959ed749e34ae020213d4a199bb743e684ba26e851f7028f10566ae55dae46138ea55ed98fe5805eaca2b1996c9240c18e533367dda0355eda59ff71bdbf4c51a5d47fb812b21cede3f555591a464877a7f60ca567f0ac6ca6edd42cb51149b4a145c9c412203dc98b5ed6f849ce4aa3ad78a926902dafb6b49e9f86cceb40eca3a4",
                DateA = new DateTime(2013, 10, 26),
                DateD = new DateTime(2013, 2, 15),
                Sort = 675369160,
                Note = "4839501bc41544bb921829aa9a18d4b7797f0f67b25f45e9806b14f99adf387743999fc3881e4bd29de3cf99fb48150f160be51682944169b9caabbe7bb3f3b9e3d3674a7e7d444e9106956da76c4cb274faaf17931f465e86116653f18d92e4c48355affde34f2cbab908d2467b71c19ab9391209e74037b3c6db8c8c6d5b762598e655e02d4290be986f11a2d39daa556256954a014d3da8c536274cffa726ec7b36a2278e451eb4ddbfea5a5407b2b067fc82dbb74aa2979413aa2d6575610bd6554e177640469852ac4524e2dec407828fd466304ec89d0c9125bc32927bd1dd49972a1a439c9b62ac06c49e6a6ec96ba49eb71b48d9a2fc",
                Status = "8b1b76b6f2344771813d83529d9359ed467ff617767942fca4"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.UpdateAsync(Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"), input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("4aac4548-26e9-4827-ae4f-9194e7d4c928"));
            result.CompanyJobId.ShouldBe(Guid.Parse("14d24627-6768-4c47-85cf-b3cfd3a94073"));
            result.OrgDept.ShouldBe("dbc97b34a9f2423983cc55e6444f4d7df9648a950b7643a887935e3a2283806f98c99a0b4eca4f73b0cc0f4a2d8912ba0be52adedb4b4a9a85d0cfb6851652b4153c50263a2f4e3db81ff52b08f76b2546a500a3dfc24f3aaf895fe7949c6ed6b2b7169a8d95431d9dbfc96b3472037f6d7808d1644b46ffbb4e8e0b8b2f976691704c8e4d3343889ec80ade45ff5cf9308d6bcbb2224064b9f81eb7f78448220de986da6d9147679ad8bfb24b5593c20bf6fdd75882434b9f7834a15b702fed0788c6dc48a44350842c48f598f19d7d7f0a9d6aad7141fba4ca3f987f011e2cbee67f9d441b4220b1bb71b151e46a1186cfebddb896441a8e37");
            result.OrgContactPerson.ShouldBe("339c2e882b394c8995c046caaca5bfe0aa31851f647a493b98");
            result.OrgContactMail.ShouldBe("3c14b7b7154243679ebbc48f226958c6914f06aca15f4397931cf2cb9e9bd305e2e20b2274934ff7ac6c3eee4b3760533ff5e22aa1d0410ab4a6587f80d25638f65b01e7a2d84269b41b24f45194820b9805e28fa60e4745969f17635e7639869c92198db95c4893b1ad88bcd0fa55455c6ef2a295644e08a24aa5ddb12619dceeea806f718546fe999eff9149af864444200f6fe1784a2e8ea11ca09349416542cf4d113d15465cb2583de0957316d5ce1cfb6e7a974a79b87a81abd01e73d2ea8420fbb27d44838aaf429cbc6ac03821c803456af94830befc98853eca5077553b2681c28849dd9444422b93f2cffbf397cb0f3b5e4544aaac");
            result.ToRespondDay.ShouldBe(47583274);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("83ea886b432c4f6da4a14bab22903eff5a626914d24048dd8c");
            result.Personally.ShouldBe("7df8a35fe41a4930924bc506e5064b8ada3cee72382c4f5695fc807064125a3cf1290ce87e114bacaa58c060674d066c841a5a21548449dc9685b5f0c015194c11256ee2db1642249723427efd37af747b0754851287422bafa2503f943e94de34905fe5");
            result.PersonallyAddress.ShouldBe("1fe38420bc01499ab3187063015764e0db17902dd8ed440faaa12602dd878225664f9a84e7534ce1b4b05e60e941a057ecf8527c23f645b19e9ab06f7f68c2779c5ae5ae52ec45dda21b499a3ea72efc3e97fcf64b584e7eb2ca58509323b8f545ff43a3");
            result.ExtendedInformation.ShouldBe("5240317bae3c409b8ac2e5d81e106a13a3126099be2249f7926a788effd982a953df609d0f0147798ae5cb2e97cbb1e12f191385a6ac46c7b8887a40ba673816ea6d64b6e8b748c699e31859a857938072342142a50241da872e2df6caaf2e36a41ff897d09b4675879698b30c95311296828b7c91f24e99959ed749e34ae020213d4a199bb743e684ba26e851f7028f10566ae55dae46138ea55ed98fe5805eaca2b1996c9240c18e533367dda0355eda59ff71bdbf4c51a5d47fb812b21cede3f555591a464877a7f60ca567f0ac6ca6edd42cb51149b4a145c9c412203dc98b5ed6f849ce4aa3ad78a926902dafb6b49e9f86cceb40eca3a4");
            result.DateA.ShouldBe(new DateTime(2013, 10, 26));
            result.DateD.ShouldBe(new DateTime(2013, 2, 15));
            result.Sort.ShouldBe(675369160);
            result.Note.ShouldBe("4839501bc41544bb921829aa9a18d4b7797f0f67b25f45e9806b14f99adf387743999fc3881e4bd29de3cf99fb48150f160be51682944169b9caabbe7bb3f3b9e3d3674a7e7d444e9106956da76c4cb274faaf17931f465e86116653f18d92e4c48355affde34f2cbab908d2467b71c19ab9391209e74037b3c6db8c8c6d5b762598e655e02d4290be986f11a2d39daa556256954a014d3da8c536274cffa726ec7b36a2278e451eb4ddbfea5a5407b2b067fc82dbb74aa2979413aa2d6575610bd6554e177640469852ac4524e2dec407828fd466304ec89d0c9125bc32927bd1dd49972a1a439c9b62ac06c49e6a6ec96ba49eb71b48d9a2fc");
            result.Status.ShouldBe("8b1b76b6f2344771813d83529d9359ed467ff617767942fca4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobApplicationMethodsAppService.DeleteAsync(Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"));

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"));

            result.ShouldBeNull();
        }
    }
}