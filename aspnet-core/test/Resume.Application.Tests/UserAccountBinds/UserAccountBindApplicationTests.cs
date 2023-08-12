using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserAccountBindsAppService _userAccountBindsAppService;
        private readonly IRepository<UserAccountBind, Guid> _userAccountBindRepository;

        public UserAccountBindsAppServiceTests()
        {
            _userAccountBindsAppService = GetRequiredService<IUserAccountBindsAppService>();
            _userAccountBindRepository = GetRequiredService<IRepository<UserAccountBind, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userAccountBindsAppService.GetListAsync(new GetUserAccountBindsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0bd3f949-61c2-42e4-8121-6293e57bfc2a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userAccountBindsAppService.GetAsync(Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserAccountBindCreateDto
            {
                UserMainId = Guid.Parse("1ee8ee96-f43c-48d0-b68f-08e223a3e753"),
                ThirdPartyTypeCode = "9ec71d0c318e47b2a4bfc24b8c9cd1c6bea64e169d284523a0",
                ThirdPartyAccountId = "d4c24c1bc68a476fa5cb77d5d5175e8e590085d203354a15b3",
                ExtendedInformation = "7dd6e6d1476b4299b4f5859aac7f4d325b2c52272cc649c1a05793c90c22cc62e391e34e0c474162aef9a540854512e49eaef0f3bf3742deba5b924079160ae20ea0ce5929a74975a3a3d8b9200a86333bf81bbacaa646e9a937c4629f2af507087d03a7d53247babc684e91772a2cf9b4fdf5e6c7634d0eb1c4fdd1ee9e6e7da188c495c3714bf88d55072d8146253ce34b7021e99c4b95a8df6653281319727a4a5ee7735f403180cd8d4bdd86c6d60b6e6717cea842e0a7ae387e579119bb95ef82ec106b4b2ab4d90335fbb79c732f0f0df322a743db994cbcc0ce6e5152a13ab5bf155e40a68ea89a7f2b7e4d157bd4b25c0b884d959436",
                DateA = new DateTime(2009, 4, 4),
                DateD = new DateTime(2006, 6, 25),
                Sort = 652965566,
                Note = "366ca7fd7419402089260d40eab756bb3cea5ebfda1b46788a82724a31b994090435aca05974430789d43901f2be9d3bd2603a47c5a9427bb9a64242c3974aa3781eaaad7441495ea337f3a1670432d7f2b05e541a23445da3302f34eea7de0f6b7f8ec837824a479bb79e35c666b8e6c5f587d24c514a549a8c6581bd7a9bd173743b545dc94a15b0b50a784ab0d6d47e77ec124cf04ebabe89faf2d4070a2d582d567d790d4463919c3b6e7500a67a0fe06c37cdec47cc87dd3cb764f06efc8becfc4bf7e1471f804b7c6e02f1099c9d8a03c1f34548b08d1009d60719a728f5c35e1adbdc49d7a4a357589f1033ef9195e8380d4c4fc8875a",
                Status = "100e9ff11d5c4deea03e7fc92c1388900ab59a95ba3546b6a4"
            };

            // Act
            var serviceResult = await _userAccountBindsAppService.CreateAsync(input);

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("1ee8ee96-f43c-48d0-b68f-08e223a3e753"));
            result.ThirdPartyTypeCode.ShouldBe("9ec71d0c318e47b2a4bfc24b8c9cd1c6bea64e169d284523a0");
            result.ThirdPartyAccountId.ShouldBe("d4c24c1bc68a476fa5cb77d5d5175e8e590085d203354a15b3");
            result.ExtendedInformation.ShouldBe("7dd6e6d1476b4299b4f5859aac7f4d325b2c52272cc649c1a05793c90c22cc62e391e34e0c474162aef9a540854512e49eaef0f3bf3742deba5b924079160ae20ea0ce5929a74975a3a3d8b9200a86333bf81bbacaa646e9a937c4629f2af507087d03a7d53247babc684e91772a2cf9b4fdf5e6c7634d0eb1c4fdd1ee9e6e7da188c495c3714bf88d55072d8146253ce34b7021e99c4b95a8df6653281319727a4a5ee7735f403180cd8d4bdd86c6d60b6e6717cea842e0a7ae387e579119bb95ef82ec106b4b2ab4d90335fbb79c732f0f0df322a743db994cbcc0ce6e5152a13ab5bf155e40a68ea89a7f2b7e4d157bd4b25c0b884d959436");
            result.DateA.ShouldBe(new DateTime(2009, 4, 4));
            result.DateD.ShouldBe(new DateTime(2006, 6, 25));
            result.Sort.ShouldBe(652965566);
            result.Note.ShouldBe("366ca7fd7419402089260d40eab756bb3cea5ebfda1b46788a82724a31b994090435aca05974430789d43901f2be9d3bd2603a47c5a9427bb9a64242c3974aa3781eaaad7441495ea337f3a1670432d7f2b05e541a23445da3302f34eea7de0f6b7f8ec837824a479bb79e35c666b8e6c5f587d24c514a549a8c6581bd7a9bd173743b545dc94a15b0b50a784ab0d6d47e77ec124cf04ebabe89faf2d4070a2d582d567d790d4463919c3b6e7500a67a0fe06c37cdec47cc87dd3cb764f06efc8becfc4bf7e1471f804b7c6e02f1099c9d8a03c1f34548b08d1009d60719a728f5c35e1adbdc49d7a4a357589f1033ef9195e8380d4c4fc8875a");
            result.Status.ShouldBe("100e9ff11d5c4deea03e7fc92c1388900ab59a95ba3546b6a4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserAccountBindUpdateDto()
            {
                UserMainId = Guid.Parse("0d9316e3-116e-40d4-8850-c8bf81689b96"),
                ThirdPartyTypeCode = "b570848007674c3b8e739e1a615f13ec6bb41c93ead540a98c",
                ThirdPartyAccountId = "2e17a114a16640eab9b6230086e19fe44d1c0087acbf4e5baf",
                ExtendedInformation = "39375f09b3ab43408cb7e5fa04c166a4414376cd6d5e4bec89db383dbfed4ee5f459e5ecb29b48d197273b8283525050da34bcd1700447e5a7791adaec38d33aa015a20208b84fecb87791a9f4725ec0f2a96f7294c548338357777b173d05d28a33cb6b6a6942b19145399e4f59a826b71699a3be494cb0b7e33f4c93922d472173919c3d72426a833b27e224056473e4f9827502ed4bc4975c27fd004618080ff30ae8869b431282076d6336f71fa94ca1d06cfaee49a09e41297fbae17a73c9b01f61e5394fff929ba8320b2b4012013e3626d57e454cb11f7c817d7cb65474156f91c71f493f96bcda01f4a2c6484ff8ebe0c02e41669f58",
                DateA = new DateTime(2018, 1, 26),
                DateD = new DateTime(2007, 10, 25),
                Sort = 885233169,
                Note = "9360c966210740e792194f6237e72918d6ef77f8770d40d981c966b9f961f17dc2a1d9a611134ad1894a5e4ff6cdc3ecb95ba4cf0f7f4da09c719237b7eb9cd2a5bd77eb115a40ad9357adf929ce48fe3b4536abf21a4d4d94482ff8d53b28f1db57996b3e154cad9253549e5a3a39080013a721558d4c9d84d4cf2dbca09d2f3229cd09ecbd4ced84e3352eb7747653b1d23cbce54e4ccda2ef095c1b0d901084d5bccb559c4e1894d69302783f4e34c15c1a58f0bd470c9e8236b41f3b3e11123c77fd01df4629959658a4e6cca1c4a63967596a554600bd5874ff6858fd46ef9c32bfc360443699a5618de98b9ca5b869d62a69844e608467",
                Status = "3e642ea2d6fa464eb3ec20b422f86a1347622432e9274b69bc"
            };

            // Act
            var serviceResult = await _userAccountBindsAppService.UpdateAsync(Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"), input);

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("0d9316e3-116e-40d4-8850-c8bf81689b96"));
            result.ThirdPartyTypeCode.ShouldBe("b570848007674c3b8e739e1a615f13ec6bb41c93ead540a98c");
            result.ThirdPartyAccountId.ShouldBe("2e17a114a16640eab9b6230086e19fe44d1c0087acbf4e5baf");
            result.ExtendedInformation.ShouldBe("39375f09b3ab43408cb7e5fa04c166a4414376cd6d5e4bec89db383dbfed4ee5f459e5ecb29b48d197273b8283525050da34bcd1700447e5a7791adaec38d33aa015a20208b84fecb87791a9f4725ec0f2a96f7294c548338357777b173d05d28a33cb6b6a6942b19145399e4f59a826b71699a3be494cb0b7e33f4c93922d472173919c3d72426a833b27e224056473e4f9827502ed4bc4975c27fd004618080ff30ae8869b431282076d6336f71fa94ca1d06cfaee49a09e41297fbae17a73c9b01f61e5394fff929ba8320b2b4012013e3626d57e454cb11f7c817d7cb65474156f91c71f493f96bcda01f4a2c6484ff8ebe0c02e41669f58");
            result.DateA.ShouldBe(new DateTime(2018, 1, 26));
            result.DateD.ShouldBe(new DateTime(2007, 10, 25));
            result.Sort.ShouldBe(885233169);
            result.Note.ShouldBe("9360c966210740e792194f6237e72918d6ef77f8770d40d981c966b9f961f17dc2a1d9a611134ad1894a5e4ff6cdc3ecb95ba4cf0f7f4da09c719237b7eb9cd2a5bd77eb115a40ad9357adf929ce48fe3b4536abf21a4d4d94482ff8d53b28f1db57996b3e154cad9253549e5a3a39080013a721558d4c9d84d4cf2dbca09d2f3229cd09ecbd4ced84e3352eb7747653b1d23cbce54e4ccda2ef095c1b0d901084d5bccb559c4e1894d69302783f4e34c15c1a58f0bd470c9e8236b41f3b3e11123c77fd01df4629959658a4e6cca1c4a63967596a554600bd5874ff6858fd46ef9c32bfc360443699a5618de98b9ca5b869d62a69844e608467");
            result.Status.ShouldBe("3e642ea2d6fa464eb3ec20b422f86a1347622432e9274b69bc");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userAccountBindsAppService.DeleteAsync(Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"));

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == Guid.Parse("deda9738-6310-46f0-8bfb-6e2f7ec1b8a1"));

            result.ShouldBeNull();
        }
    }
}