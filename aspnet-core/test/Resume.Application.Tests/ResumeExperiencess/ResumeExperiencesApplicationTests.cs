using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencessAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeExperiencessAppService _resumeExperiencessAppService;
        private readonly IRepository<ResumeExperiences, Guid> _resumeExperiencesRepository;

        public ResumeExperiencessAppServiceTests()
        {
            _resumeExperiencessAppService = GetRequiredService<IResumeExperiencessAppService>();
            _resumeExperiencesRepository = GetRequiredService<IRepository<ResumeExperiences, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetListAsync(new GetResumeExperiencessInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("68429828-f1b5-40ab-87b5-3df674d1641b")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetAsync(Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesCreateDto
            {
                ResumeMainId = Guid.Parse("86893e2d-7ad6-4f55-b239-351640ebc3a0"),
                Name = "619e571e633d4a7dbd67330c4874b24b9a5da2c370c54bb496",
                WorkNatureCode = "2a3cb12235b94f5daacf47be088de5defd7b43ba83ff49b78a",
                HideCompanyName = true,
                IndustryCategoryCode = "249f5b72b7fd4cb682600ddf021b23191f29b118a9b94412b9bc4fdc850455d7e26894621c024b7ab48e379439a0a06e28fc2f61425b4a24840376ab349018a1a50d90fb8e5c4dff9775800f05dc15f2658ea3bfac7e4cd69d9557ee5af716732720510b651043178e7a3161d2ffb5f9b972ff593dd04fb7b5f0cc995f1403c77143092f3b534ff89cae3a7d86d8f9bbf2f2664e3cbb4e909965baaadd8a167c7fead501434c49c7808b9b14c9be712e89d948fa04d446d389e74e8142a540fe71cde6d99e25425bb3cf10e979fa88773269fa316656451593f5c59e2694ac7387c7f685af854f3fb91f069df2b5499213969bb1f56c42e98893",
                JobName = "0c146e422bb44d96a0716d3a623e053b962dcda1625a457791",
                JobType = "bc61de1713ec47149be2989b19aa1ec56bac0a0dbd364236b663fb6bd2f4a4fc2602e18e19c648d39fa44472de91f939056ff771e07c4492942452b9ce26e54aacc95dc28a5d45fc8db14f8666c15108042efe559ccf4a2584ea9731a3069f44e3d36ed4998c48dea482d54c8e9ced079cbdc95afd8b4240b7e6d0676996265fb751f483dd704298be3175c0310b077cff513ae5bef1439fb3f848fb9de381c781eae86c299c4907880869ae52b195a6366e7aeb67e1428ba3d3a9e1691165b698ff4568754345acb9f10714bf4a5b3d8d03927cc3104dd783fcf624e1391050b2d1d591c385431da016e64c88ad7fce77fac0954a7148148707",
                Working = true,
                WorkPlaceCode = "48e9e06d966e48519e9a00b2cb526446b025a37b9780485a8aad23c7c03cc588b54f5572d6cc423b9c216131bae4fc1bd86411f6163846128846b07425dd17cf5837100a25fa48d89ccd3b6edfbb4577928a11cc5ca048b8b2a97696460dbb4c4a06f8a9ac05495bb239cbecad730f8b636af1326ccf4165be19b3adc5ea7aaca36e7166925d43e0a09e1a933f8cb0d92080ebec57d440bcaa16c0b381373455129c025f01b74e7688e6d860abc58f0b00d76aa43a4e489499a9d0845950d9ed730c454741cf43a594fce7d035d016367b6b9f0160c3405b842e804b8c94fa9e0b6b6506e8714450b9c7cb478b871d8787bb8b84b29f4080a48e",
                HideWorkSalary = true,
                SalaryPayTypeCode = "93801da47bba46959d808f218db7057a5668acca219b4160a3",
                CurrencyTypeCode = "5bf8867b339b493ea104c9a11adac9d8f82791f1d71049dfa2",
                Salary1 = 1451609596,
                Salary2 = 1898663869,
                CompanyScaleCode = "64a5d6f5858c4439a15cfb4afd247e8ab918b410584c4aeeaf",
                CompanyManagementNumberCode = "87de556b1783414c84eb51fa9679b9f44d9edaa1c5064cfb8c",
                ExtendedInformation = "83c8073a352748548df023952b3d63a14256344355d54d8194298e216a92a6d2664cf729a58f4574b4c2a0dede5b4622de5f2f2b80b34a5cbf5cde30474b3cea984b35e26cfd4b4b851eac48ad90ae6e9a956de62ed64db2a7ec52078feb2009cc20f047d94c478da19e2490d96927b27964d8f106904d07b0dadd2ff2e42451a342f5224a17442c862b42b86c7536532d1fcedf32f448a8bb38037aa09527c7e407822bc3cb4f07b34170d5088bbeeab62d7ed378b0455f85d72f36dc6e6999cbd862232d0447e5877e5868f6e673b1954ff54c2a2845ffb35437f31ca99bda94f7b6140a78419284b6626cea7ad0e1d73fce44341045e5a453",
                DateA = new DateTime(2010, 8, 19),
                DateD = new DateTime(2002, 9, 18),
                Sort = 316441254,
                Note = "12eed471d6fc4a1c8203dfb84fe107d84d34992332af49898988320e4d4b7621475da681c65f4355bea0d65358be4ad5b0b10034177e48ce90121de0b54c4a51292abdff84b5416983f10a9c4d480f989d3e719ebed44daea7909cdabd8a674f2eee0434488a4d8c9dc2afa86c13682eba3ed326381d4e6b99539a10ef7f7341b1094346b0dd4494a41e3c1b9a2e83c505976c70a4c04cd3ae31c57f439b1809316d1c20f5ff4ab48585fde5dd0f1ae9492729f326d54abfba8956d23cdb70e61481dd360b3141639bc4266eb39579d41d8360ba75f344e4832978d19b10da3debb2531cb3634d22afff94b4cadfda86290d9c6046af418ea236",
                Status = "5b6981fbfae34b47a74df996d806dd2f6fe05c40d39e47fdaa"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.CreateAsync(input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("86893e2d-7ad6-4f55-b239-351640ebc3a0"));
            result.Name.ShouldBe("619e571e633d4a7dbd67330c4874b24b9a5da2c370c54bb496");
            result.WorkNatureCode.ShouldBe("2a3cb12235b94f5daacf47be088de5defd7b43ba83ff49b78a");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategoryCode.ShouldBe("249f5b72b7fd4cb682600ddf021b23191f29b118a9b94412b9bc4fdc850455d7e26894621c024b7ab48e379439a0a06e28fc2f61425b4a24840376ab349018a1a50d90fb8e5c4dff9775800f05dc15f2658ea3bfac7e4cd69d9557ee5af716732720510b651043178e7a3161d2ffb5f9b972ff593dd04fb7b5f0cc995f1403c77143092f3b534ff89cae3a7d86d8f9bbf2f2664e3cbb4e909965baaadd8a167c7fead501434c49c7808b9b14c9be712e89d948fa04d446d389e74e8142a540fe71cde6d99e25425bb3cf10e979fa88773269fa316656451593f5c59e2694ac7387c7f685af854f3fb91f069df2b5499213969bb1f56c42e98893");
            result.JobName.ShouldBe("0c146e422bb44d96a0716d3a623e053b962dcda1625a457791");
            result.JobType.ShouldBe("bc61de1713ec47149be2989b19aa1ec56bac0a0dbd364236b663fb6bd2f4a4fc2602e18e19c648d39fa44472de91f939056ff771e07c4492942452b9ce26e54aacc95dc28a5d45fc8db14f8666c15108042efe559ccf4a2584ea9731a3069f44e3d36ed4998c48dea482d54c8e9ced079cbdc95afd8b4240b7e6d0676996265fb751f483dd704298be3175c0310b077cff513ae5bef1439fb3f848fb9de381c781eae86c299c4907880869ae52b195a6366e7aeb67e1428ba3d3a9e1691165b698ff4568754345acb9f10714bf4a5b3d8d03927cc3104dd783fcf624e1391050b2d1d591c385431da016e64c88ad7fce77fac0954a7148148707");
            result.Working.ShouldBe(true);
            result.WorkPlaceCode.ShouldBe("48e9e06d966e48519e9a00b2cb526446b025a37b9780485a8aad23c7c03cc588b54f5572d6cc423b9c216131bae4fc1bd86411f6163846128846b07425dd17cf5837100a25fa48d89ccd3b6edfbb4577928a11cc5ca048b8b2a97696460dbb4c4a06f8a9ac05495bb239cbecad730f8b636af1326ccf4165be19b3adc5ea7aaca36e7166925d43e0a09e1a933f8cb0d92080ebec57d440bcaa16c0b381373455129c025f01b74e7688e6d860abc58f0b00d76aa43a4e489499a9d0845950d9ed730c454741cf43a594fce7d035d016367b6b9f0160c3405b842e804b8c94fa9e0b6b6506e8714450b9c7cb478b871d8787bb8b84b29f4080a48e");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("93801da47bba46959d808f218db7057a5668acca219b4160a3");
            result.CurrencyTypeCode.ShouldBe("5bf8867b339b493ea104c9a11adac9d8f82791f1d71049dfa2");
            result.Salary1.ShouldBe(1451609596);
            result.Salary2.ShouldBe(1898663869);
            result.CompanyScaleCode.ShouldBe("64a5d6f5858c4439a15cfb4afd247e8ab918b410584c4aeeaf");
            result.CompanyManagementNumberCode.ShouldBe("87de556b1783414c84eb51fa9679b9f44d9edaa1c5064cfb8c");
            result.ExtendedInformation.ShouldBe("83c8073a352748548df023952b3d63a14256344355d54d8194298e216a92a6d2664cf729a58f4574b4c2a0dede5b4622de5f2f2b80b34a5cbf5cde30474b3cea984b35e26cfd4b4b851eac48ad90ae6e9a956de62ed64db2a7ec52078feb2009cc20f047d94c478da19e2490d96927b27964d8f106904d07b0dadd2ff2e42451a342f5224a17442c862b42b86c7536532d1fcedf32f448a8bb38037aa09527c7e407822bc3cb4f07b34170d5088bbeeab62d7ed378b0455f85d72f36dc6e6999cbd862232d0447e5877e5868f6e673b1954ff54c2a2845ffb35437f31ca99bda94f7b6140a78419284b6626cea7ad0e1d73fce44341045e5a453");
            result.DateA.ShouldBe(new DateTime(2010, 8, 19));
            result.DateD.ShouldBe(new DateTime(2002, 9, 18));
            result.Sort.ShouldBe(316441254);
            result.Note.ShouldBe("12eed471d6fc4a1c8203dfb84fe107d84d34992332af49898988320e4d4b7621475da681c65f4355bea0d65358be4ad5b0b10034177e48ce90121de0b54c4a51292abdff84b5416983f10a9c4d480f989d3e719ebed44daea7909cdabd8a674f2eee0434488a4d8c9dc2afa86c13682eba3ed326381d4e6b99539a10ef7f7341b1094346b0dd4494a41e3c1b9a2e83c505976c70a4c04cd3ae31c57f439b1809316d1c20f5ff4ab48585fde5dd0f1ae9492729f326d54abfba8956d23cdb70e61481dd360b3141639bc4266eb39579d41d8360ba75f344e4832978d19b10da3debb2531cb3634d22afff94b4cadfda86290d9c6046af418ea236");
            result.Status.ShouldBe("5b6981fbfae34b47a74df996d806dd2f6fe05c40d39e47fdaa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesUpdateDto()
            {
                ResumeMainId = Guid.Parse("ce2b06a4-7fad-4273-8b9b-1a9ccd9165c8"),
                Name = "f47278f0971d4d1ab53a95ff6ed123172be75b49a8014e54a3",
                WorkNatureCode = "19973d1a9f1648408600b5d48f6aefd922710fe747454f8892",
                HideCompanyName = true,
                IndustryCategoryCode = "a98eb4546fb54531b7cae182593f7dd49592f705a8244966852a3ae67d53b73636dde5aae65b4e2b8c3985d7cfec122b3a6d8f4a27274a1192347250c6e7ab4b100cf98c8ee04d27acefe6107a49eb033a9ee255996a48f98e98b47ea76a70552f869e8547d94f0f9ea3f4c7cf57713527fe7c6e617049d4bb9c15330c11eaec4522d63a931646f3b7b215c3747c1f13c6511f7444b94ec6bd7ab218762adcd58b30a8b43ace43708d35409cabbb3befe4740ca94e0545a4b899e9e8785dd8bd3941b04550b044f3bc48b18a5c9722c7f07dddf2894f4341b7dd83625e6284f2870b3da58c6f45e6bdded86d31607f179a362f10dfce499db880",
                JobName = "d01f7909802a422fa76a3a29485f669846a8f1d3638c40eaaf",
                JobType = "511064c9d22c4912b316554ae33be430a39b909e24874354a70a6fbbce4b5b907b604eb51e084a6385595f1444306b5137adfd38f39b487a95ae60b595a735be2a868af52bca4d2ebb87dd24026d890e9983d132b2e64c4c971be5105a3a60e171af11239a4644c9a8b279b7ca05a45c2550f7400d70490f8ab4dce77590a07cfd0385a1632441638402bc7acdbce3a1bcf159ebd68045788df5ccc1b8d0b02fb4c5fc74c59d42da86b283aba6f9a12b4269900357c34c679a996b3630d34fd19f0e9fb6d9fe455d9b1301fc6fa56a0546d6b9efccfd421a879d8a9b46a27fec901e35d0c68449069ddea1cc19b8bed3af855ecf28994d3c93d5",
                Working = true,
                WorkPlaceCode = "ac088a85c0324f63a1ff662ea6295a267ee979f746c3464198fd79162ec894ebeb1d870eba164131b49fff194afcb57fe944f0927ecc4072a2540f620765197869a20f76c3d9446abd935e2e8940937c2222409f94914654bc600b262757cbfcbc695c3a14fa4dca8a3b6e1971ff01dc68d8a5c7efbb421b842e593ca714f80c9fa4d0a41a3544529436ab1d6b1c103e1ca2cde3412f445ba25917c6f75695026b28b9a568cb42d99e1edcf46c80330a712cbae36a50479e89d6a5531a7eb6266b1b2a9b20d145fb8f718a8cd8015fdd4949b4a89c7043e0b50f6d826ece5970d193416130fc4a12be22ebe99bfdab45a2a1dec60df24c12a314",
                HideWorkSalary = true,
                SalaryPayTypeCode = "aa29e821d86146a1bd8bd1e49097d88bd6e60d40a8c2424380",
                CurrencyTypeCode = "1424940b3a064469b8c335ac5218a1ff3f5e3bda9d4c4eb1b9",
                Salary1 = 407494420,
                Salary2 = 442165935,
                CompanyScaleCode = "53143bf42b4a4388a5c07a8048afa9975bbcb50087ac44a6a3",
                CompanyManagementNumberCode = "d0a6533f5a224fbda5edbcda8ac25840d98343a11c5a4831b6",
                ExtendedInformation = "dc0057f9a2874352811a7a4bf1c58adc34569008de054ec8a5c40a1ff140bf3521cd48f371c64cae91022c71faac6815682523359a164edaaf2bef67ab892e3a705518fe79e3486e86ca7271a249c66ddbd6d17c70474abea840b07cce5df4e6c7d4ec6459324bd0b920026096240c51626cfbbb6a484a01a760bb149cbb9e242da2ab942d974429b0ff00fe15cc9b1ad288b1a1ab864523a460f1c0698ed3b2100111d70af946468fd209cd27965b08ed77862cadc54444a2ab5f7d33743ec4de4f9c7b00404110a70c183de63556df8e2fd5755c734ce6a4da101d40f938e342d590d7df694e98bb3c6340e481ef4d9c7ba8d63447481a9491",
                DateA = new DateTime(2019, 9, 8),
                DateD = new DateTime(2010, 11, 25),
                Sort = 738059967,
                Note = "8886d9bdcff5406b8adf6c251bd823c7467f6720b45342edb2a61bf46e8b9f6b121d66a4c2914aeab6484b3e4c102b48381f4fc2345f420dad70cae1fc7277e45dfdbff625e54708bb826067e95f0576a03b3e617a8743b2abca273ab5e41dc7e5456ccc1a154abb91b1174611af3e3b007c64676ba04826bccb61ed88126fb307ee6df28baa4365a219abbb80286708bd2bb5b5f8fc4f938c5b118838b3391fc1e0bf0f6c7c43e09b3ef9ea6385adf0ceefa197bd64440bba2d494695f112ad44c85dd577f142e98694cdd9916790f3c4f893c3c18e4b27b1d26cd5ecb3c7c38b931a56fb7b48e59580c7d801a10eccf099cc8a115b45f6ba1c",
                Status = "2c1eead0769e49cebe8189512b44736ecb15e2f57c89435488"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.UpdateAsync(Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"), input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("ce2b06a4-7fad-4273-8b9b-1a9ccd9165c8"));
            result.Name.ShouldBe("f47278f0971d4d1ab53a95ff6ed123172be75b49a8014e54a3");
            result.WorkNatureCode.ShouldBe("19973d1a9f1648408600b5d48f6aefd922710fe747454f8892");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategoryCode.ShouldBe("a98eb4546fb54531b7cae182593f7dd49592f705a8244966852a3ae67d53b73636dde5aae65b4e2b8c3985d7cfec122b3a6d8f4a27274a1192347250c6e7ab4b100cf98c8ee04d27acefe6107a49eb033a9ee255996a48f98e98b47ea76a70552f869e8547d94f0f9ea3f4c7cf57713527fe7c6e617049d4bb9c15330c11eaec4522d63a931646f3b7b215c3747c1f13c6511f7444b94ec6bd7ab218762adcd58b30a8b43ace43708d35409cabbb3befe4740ca94e0545a4b899e9e8785dd8bd3941b04550b044f3bc48b18a5c9722c7f07dddf2894f4341b7dd83625e6284f2870b3da58c6f45e6bdded86d31607f179a362f10dfce499db880");
            result.JobName.ShouldBe("d01f7909802a422fa76a3a29485f669846a8f1d3638c40eaaf");
            result.JobType.ShouldBe("511064c9d22c4912b316554ae33be430a39b909e24874354a70a6fbbce4b5b907b604eb51e084a6385595f1444306b5137adfd38f39b487a95ae60b595a735be2a868af52bca4d2ebb87dd24026d890e9983d132b2e64c4c971be5105a3a60e171af11239a4644c9a8b279b7ca05a45c2550f7400d70490f8ab4dce77590a07cfd0385a1632441638402bc7acdbce3a1bcf159ebd68045788df5ccc1b8d0b02fb4c5fc74c59d42da86b283aba6f9a12b4269900357c34c679a996b3630d34fd19f0e9fb6d9fe455d9b1301fc6fa56a0546d6b9efccfd421a879d8a9b46a27fec901e35d0c68449069ddea1cc19b8bed3af855ecf28994d3c93d5");
            result.Working.ShouldBe(true);
            result.WorkPlaceCode.ShouldBe("ac088a85c0324f63a1ff662ea6295a267ee979f746c3464198fd79162ec894ebeb1d870eba164131b49fff194afcb57fe944f0927ecc4072a2540f620765197869a20f76c3d9446abd935e2e8940937c2222409f94914654bc600b262757cbfcbc695c3a14fa4dca8a3b6e1971ff01dc68d8a5c7efbb421b842e593ca714f80c9fa4d0a41a3544529436ab1d6b1c103e1ca2cde3412f445ba25917c6f75695026b28b9a568cb42d99e1edcf46c80330a712cbae36a50479e89d6a5531a7eb6266b1b2a9b20d145fb8f718a8cd8015fdd4949b4a89c7043e0b50f6d826ece5970d193416130fc4a12be22ebe99bfdab45a2a1dec60df24c12a314");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("aa29e821d86146a1bd8bd1e49097d88bd6e60d40a8c2424380");
            result.CurrencyTypeCode.ShouldBe("1424940b3a064469b8c335ac5218a1ff3f5e3bda9d4c4eb1b9");
            result.Salary1.ShouldBe(407494420);
            result.Salary2.ShouldBe(442165935);
            result.CompanyScaleCode.ShouldBe("53143bf42b4a4388a5c07a8048afa9975bbcb50087ac44a6a3");
            result.CompanyManagementNumberCode.ShouldBe("d0a6533f5a224fbda5edbcda8ac25840d98343a11c5a4831b6");
            result.ExtendedInformation.ShouldBe("dc0057f9a2874352811a7a4bf1c58adc34569008de054ec8a5c40a1ff140bf3521cd48f371c64cae91022c71faac6815682523359a164edaaf2bef67ab892e3a705518fe79e3486e86ca7271a249c66ddbd6d17c70474abea840b07cce5df4e6c7d4ec6459324bd0b920026096240c51626cfbbb6a484a01a760bb149cbb9e242da2ab942d974429b0ff00fe15cc9b1ad288b1a1ab864523a460f1c0698ed3b2100111d70af946468fd209cd27965b08ed77862cadc54444a2ab5f7d33743ec4de4f9c7b00404110a70c183de63556df8e2fd5755c734ce6a4da101d40f938e342d590d7df694e98bb3c6340e481ef4d9c7ba8d63447481a9491");
            result.DateA.ShouldBe(new DateTime(2019, 9, 8));
            result.DateD.ShouldBe(new DateTime(2010, 11, 25));
            result.Sort.ShouldBe(738059967);
            result.Note.ShouldBe("8886d9bdcff5406b8adf6c251bd823c7467f6720b45342edb2a61bf46e8b9f6b121d66a4c2914aeab6484b3e4c102b48381f4fc2345f420dad70cae1fc7277e45dfdbff625e54708bb826067e95f0576a03b3e617a8743b2abca273ab5e41dc7e5456ccc1a154abb91b1174611af3e3b007c64676ba04826bccb61ed88126fb307ee6df28baa4365a219abbb80286708bd2bb5b5f8fc4f938c5b118838b3391fc1e0bf0f6c7c43e09b3ef9ea6385adf0ceefa197bd64440bba2d494695f112ad44c85dd577f142e98694cdd9916790f3c4f893c3c18e4b27b1d26cd5ecb3c7c38b931a56fb7b48e59580c7d801a10eccf099cc8a115b45f6ba1c");
            result.Status.ShouldBe("2c1eead0769e49cebe8189512b44736ecb15e2f57c89435488");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeExperiencessAppService.DeleteAsync(Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"));

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"));

            result.ShouldBeNull();
        }
    }
}