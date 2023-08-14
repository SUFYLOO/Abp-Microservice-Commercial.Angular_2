using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobAppliesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobAppliesAppService _userCompanyJobAppliesAppService;
        private readonly IRepository<UserCompanyJobApply, Guid> _userCompanyJobApplyRepository;

        public UserCompanyJobAppliesAppServiceTests()
        {
            _userCompanyJobAppliesAppService = GetRequiredService<IUserCompanyJobAppliesAppService>();
            _userCompanyJobApplyRepository = GetRequiredService<IRepository<UserCompanyJobApply, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetListAsync(new GetUserCompanyJobAppliesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("18138741-7c9b-4d1e-9eef-df3daecce7a0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetAsync(Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyCreateDto
            {
                UserMainId = Guid.Parse("3324d5c9-5036-414b-afa0-2bb764c49308"),
                CompanyJobId = Guid.Parse("55942f2a-cd2e-4296-a849-4427da6355be"),
                ExtendedInformation = "2d1b140285c44ea585e15fe30cc880500c4ab0645fed457689358f9c532e911436715e1a0ae84a1c979906d29a62d51a51cd3a70720744d3a9fe34b38dede4c7630e3e62b14c448f8add58b6bb1edbc41eadc9f734044242969b9baeb76ea42a5c7a969252ae4f2a8de165c2af713f734047e5eb4dd8483b9c9aea03952dab3a6296f81d4f0f4c7a8a0ab8b26b43a91d9bee0faf973c45e38f67fd95b82d3ba1b90f9ea8fdeb43eaa2dea37354becdce2c10043f0a4240bdb49e467523b7807bed6c357c3fd44083b4dc63c0c5ff717b60babbd3f2cb407cb92b210cce417053423ed38a11e14b07ad7ef2562613f4e52d4840d31dab488e9d2a",
                DateA = new DateTime(2010, 3, 24),
                DateD = new DateTime(2007, 2, 11),
                Sort = 149568762,
                Note = "7c1d2d62f1404147b3fd51bd7c1dd7ec2c87849618d748b9906c8a21a8b7eb766c24384385e04c10b98a47675d069b365997de17d53f4356ac9cb644c0312e50f5b2e34846bc4ee9b733484c89b80069a2acf9e861a540e4b5ebe34ddec0a4866a95759d6fe04df499a060faae0844dff9c904cecb0b4689b1523ab67ead0d673ee3536832254740ace5f967c811aa086faa6d57572f4c1aa605523eaf80ef74b1269207d76c4f1b916751b115ca3764d3dc7ee161054d16a0b2628b16784d92c6a4e54e39524a139241fd005ffd7d740233e63dccea4385aad464c41d6f2a52f6caef0c757f49a2b1037b2360ab8297f2858fc7782146a79b7a",
                Status = "253cc4dc3b9e4d80bd7d050ebb528b6556291400e5c4411784"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("3324d5c9-5036-414b-afa0-2bb764c49308"));
            result.CompanyJobId.ShouldBe(Guid.Parse("55942f2a-cd2e-4296-a849-4427da6355be"));
            result.ExtendedInformation.ShouldBe("2d1b140285c44ea585e15fe30cc880500c4ab0645fed457689358f9c532e911436715e1a0ae84a1c979906d29a62d51a51cd3a70720744d3a9fe34b38dede4c7630e3e62b14c448f8add58b6bb1edbc41eadc9f734044242969b9baeb76ea42a5c7a969252ae4f2a8de165c2af713f734047e5eb4dd8483b9c9aea03952dab3a6296f81d4f0f4c7a8a0ab8b26b43a91d9bee0faf973c45e38f67fd95b82d3ba1b90f9ea8fdeb43eaa2dea37354becdce2c10043f0a4240bdb49e467523b7807bed6c357c3fd44083b4dc63c0c5ff717b60babbd3f2cb407cb92b210cce417053423ed38a11e14b07ad7ef2562613f4e52d4840d31dab488e9d2a");
            result.DateA.ShouldBe(new DateTime(2010, 3, 24));
            result.DateD.ShouldBe(new DateTime(2007, 2, 11));
            result.Sort.ShouldBe(149568762);
            result.Note.ShouldBe("7c1d2d62f1404147b3fd51bd7c1dd7ec2c87849618d748b9906c8a21a8b7eb766c24384385e04c10b98a47675d069b365997de17d53f4356ac9cb644c0312e50f5b2e34846bc4ee9b733484c89b80069a2acf9e861a540e4b5ebe34ddec0a4866a95759d6fe04df499a060faae0844dff9c904cecb0b4689b1523ab67ead0d673ee3536832254740ace5f967c811aa086faa6d57572f4c1aa605523eaf80ef74b1269207d76c4f1b916751b115ca3764d3dc7ee161054d16a0b2628b16784d92c6a4e54e39524a139241fd005ffd7d740233e63dccea4385aad464c41d6f2a52f6caef0c757f49a2b1037b2360ab8297f2858fc7782146a79b7a");
            result.Status.ShouldBe("253cc4dc3b9e4d80bd7d050ebb528b6556291400e5c4411784");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyUpdateDto()
            {
                UserMainId = Guid.Parse("a2f1d112-18ae-400f-93a7-6da0d95779f4"),
                CompanyJobId = Guid.Parse("474fc8eb-0459-46b1-b567-694094674436"),
                ExtendedInformation = "43413cfa0d7947e99866414afc83a32839c1b3b07af74d6b9f5fd281407c615053603f3342074f18bcbb525d1d5168a22b8e15805188435bb79ec5b411957a6cc224c110f7404bc799f5cf5540f47b73797397d2b02140ff868ac867f7bf5cb40692169d0a754a2597616edbd1d7a89a9f70b4d3b7fe418782091b7748eec18bc3f98b810ad24651aab15386414ad7ba5eb68cc34c2344ecb2d673a16a983f2b8db58d3658a5411e8eb271dbf777dfbd4153917eac754af0877f44cadc068a34c310175bc4e04dc0b43bcb195361335fdcc8f8ed000548d0a1fb7e453ea9adfeecb633aa5b6e48d2b01d6319fd7c9b8e74bb72be64ad457ab6bc",
                DateA = new DateTime(2001, 6, 4),
                DateD = new DateTime(2001, 4, 1),
                Sort = 770216746,
                Note = "2a3fe3945e564acaace004103fb53bca3084cdd0c0f24c2b9e5cef8f0a29252d65c0321832254bfba58c8cd72a673004e28f29d1484d49cf9c55175363653ce87ee1caa3bae64693b68bb80aea3d1099f1910eb1ada24373aa207b06385c7723218f4dc2a6364892b6b2695fa9762a3912e9ae32e31d4bae80046018079c9da62cc33748eb494e1f8b5707bf2f3312cc5bb13720d4684e9683056e6b6628d523008257e4540d4ac397d851adac0fa1d8844948a06cd44bf1bbefaf35d3c5ed4de45d39f76ff5430d91eccfccdc135b6932211d0b6cd84b63b29c671d683902949e31b37ee7f14f58875b98072e63f0a67171baa8e574421293c2",
                Status = "e95d60cbc2444aa4b715ba9ed89d0eed3b1b119415c54bdc8a"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.UpdateAsync(Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"), input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("a2f1d112-18ae-400f-93a7-6da0d95779f4"));
            result.CompanyJobId.ShouldBe(Guid.Parse("474fc8eb-0459-46b1-b567-694094674436"));
            result.ExtendedInformation.ShouldBe("43413cfa0d7947e99866414afc83a32839c1b3b07af74d6b9f5fd281407c615053603f3342074f18bcbb525d1d5168a22b8e15805188435bb79ec5b411957a6cc224c110f7404bc799f5cf5540f47b73797397d2b02140ff868ac867f7bf5cb40692169d0a754a2597616edbd1d7a89a9f70b4d3b7fe418782091b7748eec18bc3f98b810ad24651aab15386414ad7ba5eb68cc34c2344ecb2d673a16a983f2b8db58d3658a5411e8eb271dbf777dfbd4153917eac754af0877f44cadc068a34c310175bc4e04dc0b43bcb195361335fdcc8f8ed000548d0a1fb7e453ea9adfeecb633aa5b6e48d2b01d6319fd7c9b8e74bb72be64ad457ab6bc");
            result.DateA.ShouldBe(new DateTime(2001, 6, 4));
            result.DateD.ShouldBe(new DateTime(2001, 4, 1));
            result.Sort.ShouldBe(770216746);
            result.Note.ShouldBe("2a3fe3945e564acaace004103fb53bca3084cdd0c0f24c2b9e5cef8f0a29252d65c0321832254bfba58c8cd72a673004e28f29d1484d49cf9c55175363653ce87ee1caa3bae64693b68bb80aea3d1099f1910eb1ada24373aa207b06385c7723218f4dc2a6364892b6b2695fa9762a3912e9ae32e31d4bae80046018079c9da62cc33748eb494e1f8b5707bf2f3312cc5bb13720d4684e9683056e6b6628d523008257e4540d4ac397d851adac0fa1d8844948a06cd44bf1bbefaf35d3c5ed4de45d39f76ff5430d91eccfccdc135b6932211d0b6cd84b63b29c671d683902949e31b37ee7f14f58875b98072e63f0a67171baa8e574421293c2");
            result.Status.ShouldBe("e95d60cbc2444aa4b715ba9ed89d0eed3b1b119415c54bdc8a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobAppliesAppService.DeleteAsync(Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"));

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"));

            result.ShouldBeNull();
        }
    }
}