using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserTokens
{
    public class UserTokensAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserTokensAppService _userTokensAppService;
        private readonly IRepository<UserToken, Guid> _userTokenRepository;

        public UserTokensAppServiceTests()
        {
            _userTokensAppService = GetRequiredService<IUserTokensAppService>();
            _userTokenRepository = GetRequiredService<IRepository<UserToken, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userTokensAppService.GetListAsync(new GetUserTokensInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("14f9ddd3-28b2-4ed5-8555-0455c017f6da")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userTokensAppService.GetAsync(Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserTokenCreateDto
            {
                UserMainId = Guid.Parse("cd6eae24-2df6-4e35-ba49-117ef0d85c5b"),
                TokenOld = "b33c043d4da94887b3a1a38e",
                TokenNew = "4bc6df5f72",
                ExtendedInformation = "a4fd411d43024799bce61730d771a8e3c3fe2c51f2bc4f09b21cccbb5035bc194ca9c56d678f4ae89676a9e0307131fe6b75e1696a4e4baab20bd12ede5bc92e486673206c634d258cf78c6f0a6a5cc99d212ecbb3374438ac350149ad9f8b355a5de296f9d04dcd8cc248761423da8a7df43c8a815841e5b8b6a44fa79a1e09510573c68e8d4f568e4a47f934b4ee11e9832c891bd74318891715cc45d2364ccd34515c5b0e4032a2a8216a2bc234e32573b350103d454b8ba1e12fe1845e722a57183d1162417db5057b820444690cb6bad6abdc0e4c5cadf231c25ab7539a5ca9470266fe46e3b3d23301786afedaafdbef9e62cc4a19b51b",
                DateA = new DateTime(2007, 11, 24),
                DateD = new DateTime(2006, 11, 19),
                Sort = 322307400,
                Note = "2849b592ad8641038cdd73a2719bccece9651f689b7645c4afa749988d70374441d544d4829a4adeac2d0b5304b0c7ba72c9436d88e94456953656fef09f99d1285da23b0bd145f59212140dbd2d01df528ea730f2c9404c8ffc0308671d6dffb0989adccd34432b8b1f8f22e049fcbf51720aa96a1c430da4783a3b6f94eecc89e9fa47958a43039b336b0ff1827b7e97a4f29840984bf4b270810ccb30c174d77d9c60263642b8b53e50c69318414f28f09644ddc34f70ac5863b1d048321a9d1570b7e8e04b1ea73a476d8bbbc9c835783e9dab7045c19954c5ab7a5372baedf8f6191fcd44978fef8307a5409722cb22db5040784d49a320",
                Status = "dde063177c34476b902be499c4220b0f4d406d20e7444e519b"
            };

            // Act
            var serviceResult = await _userTokensAppService.CreateAsync(input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("cd6eae24-2df6-4e35-ba49-117ef0d85c5b"));
            result.TokenOld.ShouldBe("b33c043d4da94887b3a1a38e");
            result.TokenNew.ShouldBe("4bc6df5f72");
            result.ExtendedInformation.ShouldBe("a4fd411d43024799bce61730d771a8e3c3fe2c51f2bc4f09b21cccbb5035bc194ca9c56d678f4ae89676a9e0307131fe6b75e1696a4e4baab20bd12ede5bc92e486673206c634d258cf78c6f0a6a5cc99d212ecbb3374438ac350149ad9f8b355a5de296f9d04dcd8cc248761423da8a7df43c8a815841e5b8b6a44fa79a1e09510573c68e8d4f568e4a47f934b4ee11e9832c891bd74318891715cc45d2364ccd34515c5b0e4032a2a8216a2bc234e32573b350103d454b8ba1e12fe1845e722a57183d1162417db5057b820444690cb6bad6abdc0e4c5cadf231c25ab7539a5ca9470266fe46e3b3d23301786afedaafdbef9e62cc4a19b51b");
            result.DateA.ShouldBe(new DateTime(2007, 11, 24));
            result.DateD.ShouldBe(new DateTime(2006, 11, 19));
            result.Sort.ShouldBe(322307400);
            result.Note.ShouldBe("2849b592ad8641038cdd73a2719bccece9651f689b7645c4afa749988d70374441d544d4829a4adeac2d0b5304b0c7ba72c9436d88e94456953656fef09f99d1285da23b0bd145f59212140dbd2d01df528ea730f2c9404c8ffc0308671d6dffb0989adccd34432b8b1f8f22e049fcbf51720aa96a1c430da4783a3b6f94eecc89e9fa47958a43039b336b0ff1827b7e97a4f29840984bf4b270810ccb30c174d77d9c60263642b8b53e50c69318414f28f09644ddc34f70ac5863b1d048321a9d1570b7e8e04b1ea73a476d8bbbc9c835783e9dab7045c19954c5ab7a5372baedf8f6191fcd44978fef8307a5409722cb22db5040784d49a320");
            result.Status.ShouldBe("dde063177c34476b902be499c4220b0f4d406d20e7444e519b");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserTokenUpdateDto()
            {
                UserMainId = Guid.Parse("f868c8e2-aa23-47a9-9e93-47855f13ed74"),
                TokenOld = "5e78723fba87479aa68a00fed34fcda2bd1e5e",
                TokenNew = "34c1ab477dc7497293cefabf8d",
                ExtendedInformation = "5f33023810624ba0bcff46afcddfd724c98a421c8bad43fcaaf235ec5b383539f19d1e55ff92404da02e72b128ff601967299141ccb14f4fb46777511880c898ff284fce1e304e09adb065bbeb3332429373cbeeb75d40ca8e55f8606666165b2599f0a8be34424ebb5d35ff8dc1e2304e8d964308a5407b838cac9619ea6bb32500f3e6a6e8473e83fc98b1acab862dde1fd387c4064367b676a29944058d64ea10dfa11b5b4fd2831306cf6861654bd5d2c928eaa94598b2561009b1edfe88f78b1fe587a04496a910fa5627160e2424ed540ae96946a4a92b009901cdf76599c143f6ae92487b99fdd262ebc51e393d6e7e39353b4d8c9d56",
                DateA = new DateTime(2021, 10, 5),
                DateD = new DateTime(2001, 3, 7),
                Sort = 518626158,
                Note = "f47dfc74a70a47168ceae1f72ca2655a474e90c52d0a41998ce4e87d053857532e80d0ba94454c768b58ae01a9b02ecad91c77543a44474e8a2533f87b134125c529d5339ab54984a2ee02fd00c9114c059e9516c398475383474678e1ae79b45b8fe2392fa74c62b3afde92a11028f59ea67f953c744fd186fa6dcc577af1fe97be26a94d8c4beaacb7bb741250e36246b2734a99af40288c1e808adcdeee21809f4996f19b4095b37d62c9f8a58893363a04c39f4449aa982a626c380111ce765c1a85230e42e1bec56907dc00ea0cf2adc4eadbd74aaab9fd2c275f4ede6e376a04610d3741ec99207c6c63482ac9903c36f8764545caa99b",
                Status = "e17c355f306c449fa7f1be7619acc26c2fdb639d62bb42559d"
            };

            // Act
            var serviceResult = await _userTokensAppService.UpdateAsync(Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"), input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("f868c8e2-aa23-47a9-9e93-47855f13ed74"));
            result.TokenOld.ShouldBe("5e78723fba87479aa68a00fed34fcda2bd1e5e");
            result.TokenNew.ShouldBe("34c1ab477dc7497293cefabf8d");
            result.ExtendedInformation.ShouldBe("5f33023810624ba0bcff46afcddfd724c98a421c8bad43fcaaf235ec5b383539f19d1e55ff92404da02e72b128ff601967299141ccb14f4fb46777511880c898ff284fce1e304e09adb065bbeb3332429373cbeeb75d40ca8e55f8606666165b2599f0a8be34424ebb5d35ff8dc1e2304e8d964308a5407b838cac9619ea6bb32500f3e6a6e8473e83fc98b1acab862dde1fd387c4064367b676a29944058d64ea10dfa11b5b4fd2831306cf6861654bd5d2c928eaa94598b2561009b1edfe88f78b1fe587a04496a910fa5627160e2424ed540ae96946a4a92b009901cdf76599c143f6ae92487b99fdd262ebc51e393d6e7e39353b4d8c9d56");
            result.DateA.ShouldBe(new DateTime(2021, 10, 5));
            result.DateD.ShouldBe(new DateTime(2001, 3, 7));
            result.Sort.ShouldBe(518626158);
            result.Note.ShouldBe("f47dfc74a70a47168ceae1f72ca2655a474e90c52d0a41998ce4e87d053857532e80d0ba94454c768b58ae01a9b02ecad91c77543a44474e8a2533f87b134125c529d5339ab54984a2ee02fd00c9114c059e9516c398475383474678e1ae79b45b8fe2392fa74c62b3afde92a11028f59ea67f953c744fd186fa6dcc577af1fe97be26a94d8c4beaacb7bb741250e36246b2734a99af40288c1e808adcdeee21809f4996f19b4095b37d62c9f8a58893363a04c39f4449aa982a626c380111ce765c1a85230e42e1bec56907dc00ea0cf2adc4eadbd74aaab9fd2c275f4ede6e376a04610d3741ec99207c6c63482ac9903c36f8764545caa99b");
            result.Status.ShouldBe("e17c355f306c449fa7f1be7619acc26c2fdb639d62bb42559d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userTokensAppService.DeleteAsync(Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"));

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"));

            result.ShouldBeNull();
        }
    }
}