using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyInvitationsCodesAppService _companyInvitationsCodesAppService;
        private readonly IRepository<CompanyInvitationsCode, Guid> _companyInvitationsCodeRepository;

        public CompanyInvitationsCodesAppServiceTests()
        {
            _companyInvitationsCodesAppService = GetRequiredService<ICompanyInvitationsCodesAppService>();
            _companyInvitationsCodeRepository = GetRequiredService<IRepository<CompanyInvitationsCode, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetListAsync(new GetCompanyInvitationsCodesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9db48014-78cd-47f0-845e-485174a45710")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetAsync(Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeCreateDto
            {
                CompanyMainId = Guid.Parse("e7df523a-1f93-4ed9-8afd-8c21be8fd4fd"),
                CompanyJobId = Guid.Parse("bb380dfc-ba66-4a48-b183-9bfb90c30721"),
                CompanyInvitationId = "be15badc21b24ee68c891d9a71bab7b04df9ead7e5464113a8",
                VerifyId = "4ed8cd9381fd44e892f23ad3d90ed0ef80c6717a6f06438eade51cdc466681140a739d4367a74765b1c6dd6880f2c4bcf6643c8419924526b9f51a561ddc6c8a5e7b61f4d4674e4cb9f3d503105838a8c85d99ff3f9b4eab86de1625aeb119ffe49c0c9f0f124f7693402626fe2bc69b5ea108d6303a4850b88f5492a8a45e03a720390861054618a6204871ef6f0aa050a9adc5fc394baab5e06f9005007c4129eec58f1ea341619bc3f8aba763bee7aa2ef354df974e9eab7d91fc64e582b35606b52cd6244c8cbfefc0bcaa554120bf3abffd62bf4c00b8edf1f537baa2bcf54559847770499782908401b067807bb4fda4d3939248a7ab71",
                VerifyCode = "75bda68ea2134d4881d8cecbfbde536cb4a8ebce1b8c428baf",
                ExtendedInformation = "be26d8e0a5cd4403945adc837e2256aabcd872e1d9e74a04bb90b2554bdc16916363a651fba845239035e37572a998dba20288537b0d46db9a8267b897914c6da3f9ca80d9904997bac5464c0104878d7c643197dd0e4ccf888fe3908e3393aa2e21496f36f045829fe835fba47abb1e70d36bd71b8148ab84e46a8072368d0d094cd2113a27474a8dba4fe4c825055d4f233e4d91c6409a81d5ebcf0f3bd03d1a637e9c77244ef49c8f00ac67ffe84e1aa422288d984ad5a74f0bbe41dd03697655a2f077484c25b8b65460f601ce6fe18ea8e3258845789c83b6b03b5d6ef7431ebc85f08d44db9316af7a4ba0146b0d3f18e3dc234aa58978",
                DateA = new DateTime(2012, 8, 6),
                DateD = new DateTime(2020, 6, 2),
                Sort = 1871706592,
                Note = "5033808a0c144b409a241b3d431e11609718df0bbe384166bd73210453d1f4cdcc7616778d2d41cd89ff71bbd799835e38dfcfdb76964c5dbfa521a50b447e517d836da6278b454787dbc2b902d2934678548f681c874ac496d701b8569d63cb63d2cb4f3b7440c58ff3b98602321cc771379a0fee364c919773ff223b6bd1daea3561d79389427c8fc3b39d7778dc86d3ad43fb95984eda92e95a589a6c7313ea0dd6f0876e43858d60f201949baa3956d3707b48bc473eafa4a7c3764bdeca0426b4c468a74ca99b26751005f56b4ddd118eb796f441a3b9f95693f2e869a04a39d485beb2483c98008b73d4ea48a1746edc81682a427b8481",
                Status = "c299f800c005424e8a62a208a15c90e8b603c764bf1043ff8d"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("e7df523a-1f93-4ed9-8afd-8c21be8fd4fd"));
            result.CompanyJobId.ShouldBe(Guid.Parse("bb380dfc-ba66-4a48-b183-9bfb90c30721"));
            result.CompanyInvitationId.ShouldBe("be15badc21b24ee68c891d9a71bab7b04df9ead7e5464113a8");
            result.VerifyId.ShouldBe("4ed8cd9381fd44e892f23ad3d90ed0ef80c6717a6f06438eade51cdc466681140a739d4367a74765b1c6dd6880f2c4bcf6643c8419924526b9f51a561ddc6c8a5e7b61f4d4674e4cb9f3d503105838a8c85d99ff3f9b4eab86de1625aeb119ffe49c0c9f0f124f7693402626fe2bc69b5ea108d6303a4850b88f5492a8a45e03a720390861054618a6204871ef6f0aa050a9adc5fc394baab5e06f9005007c4129eec58f1ea341619bc3f8aba763bee7aa2ef354df974e9eab7d91fc64e582b35606b52cd6244c8cbfefc0bcaa554120bf3abffd62bf4c00b8edf1f537baa2bcf54559847770499782908401b067807bb4fda4d3939248a7ab71");
            result.VerifyCode.ShouldBe("75bda68ea2134d4881d8cecbfbde536cb4a8ebce1b8c428baf");
            result.ExtendedInformation.ShouldBe("be26d8e0a5cd4403945adc837e2256aabcd872e1d9e74a04bb90b2554bdc16916363a651fba845239035e37572a998dba20288537b0d46db9a8267b897914c6da3f9ca80d9904997bac5464c0104878d7c643197dd0e4ccf888fe3908e3393aa2e21496f36f045829fe835fba47abb1e70d36bd71b8148ab84e46a8072368d0d094cd2113a27474a8dba4fe4c825055d4f233e4d91c6409a81d5ebcf0f3bd03d1a637e9c77244ef49c8f00ac67ffe84e1aa422288d984ad5a74f0bbe41dd03697655a2f077484c25b8b65460f601ce6fe18ea8e3258845789c83b6b03b5d6ef7431ebc85f08d44db9316af7a4ba0146b0d3f18e3dc234aa58978");
            result.DateA.ShouldBe(new DateTime(2012, 8, 6));
            result.DateD.ShouldBe(new DateTime(2020, 6, 2));
            result.Sort.ShouldBe(1871706592);
            result.Note.ShouldBe("5033808a0c144b409a241b3d431e11609718df0bbe384166bd73210453d1f4cdcc7616778d2d41cd89ff71bbd799835e38dfcfdb76964c5dbfa521a50b447e517d836da6278b454787dbc2b902d2934678548f681c874ac496d701b8569d63cb63d2cb4f3b7440c58ff3b98602321cc771379a0fee364c919773ff223b6bd1daea3561d79389427c8fc3b39d7778dc86d3ad43fb95984eda92e95a589a6c7313ea0dd6f0876e43858d60f201949baa3956d3707b48bc473eafa4a7c3764bdeca0426b4c468a74ca99b26751005f56b4ddd118eb796f441a3b9f95693f2e869a04a39d485beb2483c98008b73d4ea48a1746edc81682a427b8481");
            result.Status.ShouldBe("c299f800c005424e8a62a208a15c90e8b603c764bf1043ff8d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeUpdateDto()
            {
                CompanyMainId = Guid.Parse("4df22e55-38be-4b8f-bd53-0cbd8effb794"),
                CompanyJobId = Guid.Parse("3413cd47-0f07-449e-9bb1-0e66786fffb4"),
                CompanyInvitationId = "0fd18c66723746d78107745d4954090808d61129cccf4cb9b4",
                VerifyId = "b3735eebba4141f5ac5c89741a118cefb3a744c547f4438daada10b51b1c960afdef8e984da644cb9eb63596019e490a33298ae80ca04ecba70e4e5e35e0add7da992de41fdc4884849b51dbc71ca39ee9da4cdafcc542cb8acdccdd262f9931aaabe853088f4cc68ddf780b9842c759e5565f8e4d5a451287db311fd33072719aeb5bf88f104815be176b4aa165b3d84b9e97bf813f4d79a899594fefdfde4311165fa373fb437db47f4ea0d8981056c457d3984c6f40ee95a3622c739b34b2091882bf91674e06a920169a3f4d58aa7839c4361015468da8843eecbb569d1362a8fe7870624d7683fecd4b6fcb2dcdf42109147e4b43998ff0",
                VerifyCode = "e914b65a8c17443cacf7ddd2b1ae38e3ce5ba54861a34645a2",
                ExtendedInformation = "8b09f8dab15948659995fbdfa55d5939286b15be6051442a828ab9803c79035099d068cab6c143618dfbca413979129cca49f809d8024ece94a1b52f7957161ca32232243349485392114e18db9f779dbb1f030e3cbb4274a28b8811d07e6f7a387916d2dfef4df1898aa5e9bc93abd79b1c072a388045358a961d9d6b3aad8e2dfb3de4287e415397c9453697aebf78294b06052c554507abc8e4c6c86dd296eb0d4056c0b541cc8dab0a49c07bde4b4f9bef9e068048bcbe6479960e0cd0dd8893560ab4e044d180f18ed1e105a88718dc98f43d674f6e969f200333bfb7d42877709051a84ceb9da16ba6227a96bedfb01dd613dd4cebbb24",
                DateA = new DateTime(2006, 5, 16),
                DateD = new DateTime(2009, 10, 21),
                Sort = 150351067,
                Note = "8a0c5bfa7f8d4211960469cc769c89db4627bdcc9d4f4e36983a0de50c9ddf81013cc0308a474a5887748f7b6afbf172eca5913ba321446a8937c3cba91db933c14dbb910ab84e848393775439b3de956e55a0e43fc64bf1b727bcbae5f39597f3ddfe51cabe4d5c886d699a152ede8e5430be1fcf194c61895223b952e69b0807ea6bec03374f0d840daf190573012c3fa906d81490410baffd95924f46049b62434f5f3fec4d868ad60ef83feb7fde8477e9b0531142fdbbce80339ff415864e6ac943bed64ef5bab4042ad949285f7f0c2fa0661a4cb9963918e2fc140b6b338f63c5868f4e91b97daa6139cbbf98169b77be2e6a4be39d18",
                Status = "1ce870b480804881842d3d8cdcf2e089f10fc043deb04a8480"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.UpdateAsync(Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"), input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("4df22e55-38be-4b8f-bd53-0cbd8effb794"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3413cd47-0f07-449e-9bb1-0e66786fffb4"));
            result.CompanyInvitationId.ShouldBe("0fd18c66723746d78107745d4954090808d61129cccf4cb9b4");
            result.VerifyId.ShouldBe("b3735eebba4141f5ac5c89741a118cefb3a744c547f4438daada10b51b1c960afdef8e984da644cb9eb63596019e490a33298ae80ca04ecba70e4e5e35e0add7da992de41fdc4884849b51dbc71ca39ee9da4cdafcc542cb8acdccdd262f9931aaabe853088f4cc68ddf780b9842c759e5565f8e4d5a451287db311fd33072719aeb5bf88f104815be176b4aa165b3d84b9e97bf813f4d79a899594fefdfde4311165fa373fb437db47f4ea0d8981056c457d3984c6f40ee95a3622c739b34b2091882bf91674e06a920169a3f4d58aa7839c4361015468da8843eecbb569d1362a8fe7870624d7683fecd4b6fcb2dcdf42109147e4b43998ff0");
            result.VerifyCode.ShouldBe("e914b65a8c17443cacf7ddd2b1ae38e3ce5ba54861a34645a2");
            result.ExtendedInformation.ShouldBe("8b09f8dab15948659995fbdfa55d5939286b15be6051442a828ab9803c79035099d068cab6c143618dfbca413979129cca49f809d8024ece94a1b52f7957161ca32232243349485392114e18db9f779dbb1f030e3cbb4274a28b8811d07e6f7a387916d2dfef4df1898aa5e9bc93abd79b1c072a388045358a961d9d6b3aad8e2dfb3de4287e415397c9453697aebf78294b06052c554507abc8e4c6c86dd296eb0d4056c0b541cc8dab0a49c07bde4b4f9bef9e068048bcbe6479960e0cd0dd8893560ab4e044d180f18ed1e105a88718dc98f43d674f6e969f200333bfb7d42877709051a84ceb9da16ba6227a96bedfb01dd613dd4cebbb24");
            result.DateA.ShouldBe(new DateTime(2006, 5, 16));
            result.DateD.ShouldBe(new DateTime(2009, 10, 21));
            result.Sort.ShouldBe(150351067);
            result.Note.ShouldBe("8a0c5bfa7f8d4211960469cc769c89db4627bdcc9d4f4e36983a0de50c9ddf81013cc0308a474a5887748f7b6afbf172eca5913ba321446a8937c3cba91db933c14dbb910ab84e848393775439b3de956e55a0e43fc64bf1b727bcbae5f39597f3ddfe51cabe4d5c886d699a152ede8e5430be1fcf194c61895223b952e69b0807ea6bec03374f0d840daf190573012c3fa906d81490410baffd95924f46049b62434f5f3fec4d868ad60ef83feb7fde8477e9b0531142fdbbce80339ff415864e6ac943bed64ef5bab4042ad949285f7f0c2fa0661a4cb9963918e2fc140b6b338f63c5868f4e91b97daa6139cbbf98169b77be2e6a4be39d18");
            result.Status.ShouldBe("1ce870b480804881842d3d8cdcf2e089f10fc043deb04a8480");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationsCodesAppService.DeleteAsync(Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"));

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"));

            result.ShouldBeNull();
        }
    }
}