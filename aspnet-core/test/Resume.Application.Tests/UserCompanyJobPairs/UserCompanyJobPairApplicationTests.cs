using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobPairsAppService _userCompanyJobPairsAppService;
        private readonly IRepository<UserCompanyJobPair, Guid> _userCompanyJobPairRepository;

        public UserCompanyJobPairsAppServiceTests()
        {
            _userCompanyJobPairsAppService = GetRequiredService<IUserCompanyJobPairsAppService>();
            _userCompanyJobPairRepository = GetRequiredService<IRepository<UserCompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetListAsync(new GetUserCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("03d271f0-aa00-4d34-81b4-0224cf41b5ab")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetAsync(Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairCreateDto
            {
                UserMainId = Guid.Parse("bf9c553d-5a17-41ac-b62f-e778f9b0497f"),
                Name = "035fc0b00a544aa48b0a5d4632cae33a564dc211a5f740e199",
                PairCondition = "c778813c458e4cd4adc788a094af2558ea6b114f5bea4b84abfe2cf6ac0773f3c374e97c6aef4f2989c16f9c3c346a03ad065976bb9d45c2a817532e37fbf0e321029b4a49234a52a3f527d0c009ec6e8e708dc488f3405a8c77c680fb046abd14b271459e344d36900d8e4cbc9323f7786b4d6d3be5488697329cc07c928c6dfee3c7e71e814fd386d9d8fc81b76c28c07671000ce949f08d8b5fd7e0ff4b773e74bdfe103f47fc935af1c8b6bf9b2b1f1e55c7711d46438b2aac9490476c289df90c35be914a8285ab4280aeeb77784c899cbf191b49febd8e8019cb69985edafb33adef4742c7b49e1e03eac6ed49db926a653bc441ecac49",
                ExtendedInformation = "04029230668c429ba29806db04264018591c14f930444c02b5d4afe456bd02f5b2085ecd3729448e84369ed638da021f4b4817f20fc44431828511d8b9818190dae768560576461d965173a45c1afbdd9f5407bee8854f8abc283d316f629b933dda82c4e3434a94a6e2e9793f1864a65e7a021f1c02482bacb81bccf5416a105e46918e60ac4830a2942da89c850050631707881ff1454fae1116a20664b1c4654f7800f55a470d923a3c06c93394e70c3fad933580438a9c55c591a342c0d779c2dd2528794576914fae71bc69573e8270329c9cc840a08de05b0d24a34e8c2ba01131b821425aba780cc276295ded2bdda22bd46d4317a59d",
                DateA = new DateTime(2011, 9, 26),
                DateD = new DateTime(2017, 7, 13),
                Sort = 414024313,
                Note = "eb028d244a7a40dc986195a1c25855b426a68da4ff4249d985e43367147a9be9a55bddd30b344aad8af92cfbf512536dc16964718a7b43d6b3ebcf08ca99f97d2169d61cccdf40c7839880cb1f6349d314a533efa3be4634b929398fa2f0677f5fed819830f44d37a02b10731fd3f30206e45850580e4e9d852f965284e5a400a6c192619b624391abfa507c4cf3eb635431c3297b70412492d88d3fbf52d79ad1b5c1dd9927439fb5981c3f4b8ae25713eb90edc681419d84c73f8aad7a34ebf88ecfe9097c4dc8815b19876b10bfa104b9de1fa70d445e9f4e3033c721ea9d1093a68b066c4b02b52baec799847b0fbba0543c059b4802b433",
                Status = "0706a18dbd4049c5841ec3d3fa05ceb3195ea2f794a942c29e"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("bf9c553d-5a17-41ac-b62f-e778f9b0497f"));
            result.Name.ShouldBe("035fc0b00a544aa48b0a5d4632cae33a564dc211a5f740e199");
            result.PairCondition.ShouldBe("c778813c458e4cd4adc788a094af2558ea6b114f5bea4b84abfe2cf6ac0773f3c374e97c6aef4f2989c16f9c3c346a03ad065976bb9d45c2a817532e37fbf0e321029b4a49234a52a3f527d0c009ec6e8e708dc488f3405a8c77c680fb046abd14b271459e344d36900d8e4cbc9323f7786b4d6d3be5488697329cc07c928c6dfee3c7e71e814fd386d9d8fc81b76c28c07671000ce949f08d8b5fd7e0ff4b773e74bdfe103f47fc935af1c8b6bf9b2b1f1e55c7711d46438b2aac9490476c289df90c35be914a8285ab4280aeeb77784c899cbf191b49febd8e8019cb69985edafb33adef4742c7b49e1e03eac6ed49db926a653bc441ecac49");
            result.ExtendedInformation.ShouldBe("04029230668c429ba29806db04264018591c14f930444c02b5d4afe456bd02f5b2085ecd3729448e84369ed638da021f4b4817f20fc44431828511d8b9818190dae768560576461d965173a45c1afbdd9f5407bee8854f8abc283d316f629b933dda82c4e3434a94a6e2e9793f1864a65e7a021f1c02482bacb81bccf5416a105e46918e60ac4830a2942da89c850050631707881ff1454fae1116a20664b1c4654f7800f55a470d923a3c06c93394e70c3fad933580438a9c55c591a342c0d779c2dd2528794576914fae71bc69573e8270329c9cc840a08de05b0d24a34e8c2ba01131b821425aba780cc276295ded2bdda22bd46d4317a59d");
            result.DateA.ShouldBe(new DateTime(2011, 9, 26));
            result.DateD.ShouldBe(new DateTime(2017, 7, 13));
            result.Sort.ShouldBe(414024313);
            result.Note.ShouldBe("eb028d244a7a40dc986195a1c25855b426a68da4ff4249d985e43367147a9be9a55bddd30b344aad8af92cfbf512536dc16964718a7b43d6b3ebcf08ca99f97d2169d61cccdf40c7839880cb1f6349d314a533efa3be4634b929398fa2f0677f5fed819830f44d37a02b10731fd3f30206e45850580e4e9d852f965284e5a400a6c192619b624391abfa507c4cf3eb635431c3297b70412492d88d3fbf52d79ad1b5c1dd9927439fb5981c3f4b8ae25713eb90edc681419d84c73f8aad7a34ebf88ecfe9097c4dc8815b19876b10bfa104b9de1fa70d445e9f4e3033c721ea9d1093a68b066c4b02b52baec799847b0fbba0543c059b4802b433");
            result.Status.ShouldBe("0706a18dbd4049c5841ec3d3fa05ceb3195ea2f794a942c29e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairUpdateDto()
            {
                UserMainId = Guid.Parse("7b2d8ab2-12ba-4565-89a2-68a43a7aba87"),
                Name = "f742c46f14a74e339256aa332dd3ad0e59fdd0a893dc4e4293",
                PairCondition = "a5ef80633cde488682e3634e1d287de6d01c49f5eb344b08b0c25faa7e0f2cfae5c2f122230a4bfe8c6b925537e184eb2e514b735cb74f91a93ff4f090f9484e1c1b30b2afb544e69318407526aeeba6a33014c0b03f4f09aeff5b7530a40e1b501bb1fbbdad40408e1e1e5be5458b8b48e86b94a29247b18727f91246ca6ff2bfe73aae43274b6ba7f09afef4afe42b36895444c8aa472ca1469f4a70a966905350d93e1fd44321b73ea37dc675803e0f2d2a570e174dfa9f6dbcacaec511abe1551ecb59d64a2e8b1e270b6e4f01790d9a838a95b84720a5b147d9bec7bca88d7c62508a0543ebb313682a41239162a68a1a767de3455c9a7d",
                ExtendedInformation = "95129440876b4e3bbe3473455c310891e49c188f8ff540368ffdb5034defb9638588a2a4e496483fbb31fb1fcb397100fca39260796642ebafa81f85516ea0383eff92f5b4db41d39df92195fd98be0361c197cee9ba40ba8fe22aff8191025c41f827b7a44b48098cb5c711eb92a62fb2ddaa7217f94ced977f070a47d4015288209bfd64ae4b1e93c758d969a24ace08ea1fcb7a8b4b8bb7788357a057ff46c22e3c8e28bd4032a076352f08bd00dc813d0964813347d5b1f913ccf4a235c4cd857865a6e7433291f01dbdf83be8b9a111f109cdf64e569f0e6f122223f295b9da77d9ccfd45e4bd379ec63938223126fbd005c36e4c55a755",
                DateA = new DateTime(2000, 9, 1),
                DateD = new DateTime(2005, 4, 22),
                Sort = 1878978648,
                Note = "882a9601481b4f1481cc82d06fd17e50c933463d44e44a4b8737deec705c319bc59043c6c0e74f4cab33fc6e28ae2111a8896bdb39d14440bcc757dfd18f1a7019e47093ba6f4c45945ad6331fb279535d9f246be8b8426aacd88c248ec3f6b62756cc473d4048d28be31fc5fb7f678ad713cf87e0e04643982542662c55de740c07f35260a740e4840420b4e2d050c561fe378e739242d5b7d10c2fd724f41e367736aaafb644ac95a6c2322ab2a60e253a223c23284fa389de61f30d7a1c230c82f3139f1148f69b48cae6730b523f7f72d45080584eccb647488a01bd6e25c6d29bbba46c4f25a2c591449c42f6ddc4746e78078f480d96e0",
                Status = "d7a5fd91b1c14a0f9a55f0f11ef6492c733e67c8c38f4e93ae"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.UpdateAsync(Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"), input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("7b2d8ab2-12ba-4565-89a2-68a43a7aba87"));
            result.Name.ShouldBe("f742c46f14a74e339256aa332dd3ad0e59fdd0a893dc4e4293");
            result.PairCondition.ShouldBe("a5ef80633cde488682e3634e1d287de6d01c49f5eb344b08b0c25faa7e0f2cfae5c2f122230a4bfe8c6b925537e184eb2e514b735cb74f91a93ff4f090f9484e1c1b30b2afb544e69318407526aeeba6a33014c0b03f4f09aeff5b7530a40e1b501bb1fbbdad40408e1e1e5be5458b8b48e86b94a29247b18727f91246ca6ff2bfe73aae43274b6ba7f09afef4afe42b36895444c8aa472ca1469f4a70a966905350d93e1fd44321b73ea37dc675803e0f2d2a570e174dfa9f6dbcacaec511abe1551ecb59d64a2e8b1e270b6e4f01790d9a838a95b84720a5b147d9bec7bca88d7c62508a0543ebb313682a41239162a68a1a767de3455c9a7d");
            result.ExtendedInformation.ShouldBe("95129440876b4e3bbe3473455c310891e49c188f8ff540368ffdb5034defb9638588a2a4e496483fbb31fb1fcb397100fca39260796642ebafa81f85516ea0383eff92f5b4db41d39df92195fd98be0361c197cee9ba40ba8fe22aff8191025c41f827b7a44b48098cb5c711eb92a62fb2ddaa7217f94ced977f070a47d4015288209bfd64ae4b1e93c758d969a24ace08ea1fcb7a8b4b8bb7788357a057ff46c22e3c8e28bd4032a076352f08bd00dc813d0964813347d5b1f913ccf4a235c4cd857865a6e7433291f01dbdf83be8b9a111f109cdf64e569f0e6f122223f295b9da77d9ccfd45e4bd379ec63938223126fbd005c36e4c55a755");
            result.DateA.ShouldBe(new DateTime(2000, 9, 1));
            result.DateD.ShouldBe(new DateTime(2005, 4, 22));
            result.Sort.ShouldBe(1878978648);
            result.Note.ShouldBe("882a9601481b4f1481cc82d06fd17e50c933463d44e44a4b8737deec705c319bc59043c6c0e74f4cab33fc6e28ae2111a8896bdb39d14440bcc757dfd18f1a7019e47093ba6f4c45945ad6331fb279535d9f246be8b8426aacd88c248ec3f6b62756cc473d4048d28be31fc5fb7f678ad713cf87e0e04643982542662c55de740c07f35260a740e4840420b4e2d050c561fe378e739242d5b7d10c2fd724f41e367736aaafb644ac95a6c2322ab2a60e253a223c23284fa389de61f30d7a1c230c82f3139f1148f69b48cae6730b523f7f72d45080584eccb647488a01bd6e25c6d29bbba46c4f25a2c591449c42f6ddc4746e78078f480d96e0");
            result.Status.ShouldBe("d7a5fd91b1c14a0f9a55f0f11ef6492c733e67c8c38f4e93ae");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobPairsAppService.DeleteAsync(Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"));

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"));

            result.ShouldBeNull();
        }
    }
}