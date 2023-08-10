using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemUserNotifysAppService _systemUserNotifysAppService;
        private readonly IRepository<SystemUserNotify, Guid> _systemUserNotifyRepository;

        public SystemUserNotifysAppServiceTests()
        {
            _systemUserNotifysAppService = GetRequiredService<ISystemUserNotifysAppService>();
            _systemUserNotifyRepository = GetRequiredService<IRepository<SystemUserNotify, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemUserNotifysAppService.GetListAsync(new GetSystemUserNotifysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("a9f8a7ad-3f64-4a79-8a38-766b7cdd7d23")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemUserNotifysAppService.GetAsync(Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemUserNotifyCreateDto
            {
                UserMainId = Guid.Parse("6a602b43-960b-4c2b-b7d9-07a20d340b5b"),
                KeyId = "f8d609f10ee744bcaacd13ddc4bb8b54c2cdfb5dc27d4dc68a",
                KeyName = "e283aa89b88e478c95759f869dddee0c90b103f31374470dad",
                NotifyTypeCode = "1e40bc3a21274b5586d2935850d300ef4466aae7750a484ab7",
                AppName = "ac1194145a4b4d439c50fe5fedb8ba03155329c8b75a439e9a",
                AppCode = "c151369b87b8417c89e5cd14da761c681750fe7316be48a2a1",
                TitleContents = "4684c3b3249e4b2e8ed470e4750e9456c1abc5f7b72746d2976ad4cc1c19a5af2fe3b28952cf40d9bb39c52c281e53a38a2671bfe15449d9870dedf275bb2bce1b73ac8a986746018972ce8e72fd0745b893e4419d37472eaf9918bcb699e359d84ee4ee56b34feaab371c5d0dae625b73e7a3e43e4447c0beb55fd648d3b3200e93e8301cd2401b95e7ec0a0194284ac5b0abfec066401ba5a1967426da61dec284660c5ef74ee7a1ac56abff8ef5a1f0a21214a08c4219acc5b5fdeb6b349debcb8660e10048d6b3def822469e8fddcbf6881c33b24d64b8c7af629d13acefdd6b6b6031db4efea98f057d55c6e8d858244650a84f428cb0e5",
                Contents = "aabae80b0e8b4a809aab6cf5a4bcea014d975dd249434191a2f696ad128adb0db275e54cec604407a41d5a46dabf4232453c6c3ab9354a69b822eb9245ff4d3a6c560635a4314cd19cfc4ff6f2a28e36a2cd3c5628c0457282a5b7a3cb1c54212c97b7ab79954cafbd6bd8f71506c1daf608f250c4684ecbb818696b500353010786e6663f5a41acbfa0353daaec83acd3192a14d81243e9a87780e6f287ccf36dd17e0be2b44d1f9901fee0aa06be318f642723d4d34d07aa7ae0ca374660f593bc5788ebc64003801cf02c8718d644962f9f9216914590be34b9f26f31e3d8a14dddd51c3b4d8e8d4c11e2b842694d256be1ddcad244ac9381",
                IsRead = true,
                ExtendedInformation = "992c78aa9cbd4aaf99221ee0254f94682a07b2f5be644ba3a0f52a2981a245f7d7059f81d8374aa9a8af90996ee05317128d0c33263e49b6b0f1b506677d1635c8d944354c7548478acb1bf7d2532faa92dbc57e50b84c56baab9477dae73312c0b167569017481ea854e8aefc35fc3ea3b7d49347a34ecb9df2f900737f9f119ae29f64230d43708f989ec624f961603587355a391d4201b74755743f08f90b711ba2a20210462d853e743cd3fec7c4292a2f10e47047b9b0d76a931d40b1804bfe2260c39649f9987f1f96c8e86be13d632e25af194ddaa4353f42e7835fea7d80ee16451e42edb70c113f59d80e5360aba03041be4ffb9c78",
                DateA = new DateTime(2006, 8, 21),
                DateD = new DateTime(2005, 8, 25),
                Sort = 1638069078,
                Note = "663258de9c444ff49c6bbeaf409147205483f9ef67af47b79d855bde9cc3200d023e4cefd5af4a20aafa51700961c8f24adc94e6c1a4418a8793e1a74b38f38404d2e1a408cf44e2a10f2b3183d8241ea3cc26bfbf534d92ab867a6e1f783f7b39b5d7d2aa6a4a7abb7d07f6856a317db7c00acdc18d43c9980791dc62b1d2fa02462df67f884278ab48e9f92f461f15487b9dd68cce4c75bc0e83db6425a01916b6bc28e0da4727a6cb33947e1e0a848eaf4005d04d48e6af9a596f3151dabd2854d0cf0adb4cc9a5449dff49f3858e0d9be6e625bb48bd891852f3afb8266810c1ef3fcedb4acf83c2b382de054e347d5f699d83824ca69463",
                Status = "835bf32327a74978afb76e96fc53a3daf7f29a0ba2954557a5"
            };

            // Act
            var serviceResult = await _systemUserNotifysAppService.CreateAsync(input);

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("6a602b43-960b-4c2b-b7d9-07a20d340b5b"));
            result.KeyId.ShouldBe("f8d609f10ee744bcaacd13ddc4bb8b54c2cdfb5dc27d4dc68a");
            result.KeyName.ShouldBe("e283aa89b88e478c95759f869dddee0c90b103f31374470dad");
            result.NotifyTypeCode.ShouldBe("1e40bc3a21274b5586d2935850d300ef4466aae7750a484ab7");
            result.AppName.ShouldBe("ac1194145a4b4d439c50fe5fedb8ba03155329c8b75a439e9a");
            result.AppCode.ShouldBe("c151369b87b8417c89e5cd14da761c681750fe7316be48a2a1");
            result.TitleContents.ShouldBe("4684c3b3249e4b2e8ed470e4750e9456c1abc5f7b72746d2976ad4cc1c19a5af2fe3b28952cf40d9bb39c52c281e53a38a2671bfe15449d9870dedf275bb2bce1b73ac8a986746018972ce8e72fd0745b893e4419d37472eaf9918bcb699e359d84ee4ee56b34feaab371c5d0dae625b73e7a3e43e4447c0beb55fd648d3b3200e93e8301cd2401b95e7ec0a0194284ac5b0abfec066401ba5a1967426da61dec284660c5ef74ee7a1ac56abff8ef5a1f0a21214a08c4219acc5b5fdeb6b349debcb8660e10048d6b3def822469e8fddcbf6881c33b24d64b8c7af629d13acefdd6b6b6031db4efea98f057d55c6e8d858244650a84f428cb0e5");
            result.Contents.ShouldBe("aabae80b0e8b4a809aab6cf5a4bcea014d975dd249434191a2f696ad128adb0db275e54cec604407a41d5a46dabf4232453c6c3ab9354a69b822eb9245ff4d3a6c560635a4314cd19cfc4ff6f2a28e36a2cd3c5628c0457282a5b7a3cb1c54212c97b7ab79954cafbd6bd8f71506c1daf608f250c4684ecbb818696b500353010786e6663f5a41acbfa0353daaec83acd3192a14d81243e9a87780e6f287ccf36dd17e0be2b44d1f9901fee0aa06be318f642723d4d34d07aa7ae0ca374660f593bc5788ebc64003801cf02c8718d644962f9f9216914590be34b9f26f31e3d8a14dddd51c3b4d8e8d4c11e2b842694d256be1ddcad244ac9381");
            result.IsRead.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("992c78aa9cbd4aaf99221ee0254f94682a07b2f5be644ba3a0f52a2981a245f7d7059f81d8374aa9a8af90996ee05317128d0c33263e49b6b0f1b506677d1635c8d944354c7548478acb1bf7d2532faa92dbc57e50b84c56baab9477dae73312c0b167569017481ea854e8aefc35fc3ea3b7d49347a34ecb9df2f900737f9f119ae29f64230d43708f989ec624f961603587355a391d4201b74755743f08f90b711ba2a20210462d853e743cd3fec7c4292a2f10e47047b9b0d76a931d40b1804bfe2260c39649f9987f1f96c8e86be13d632e25af194ddaa4353f42e7835fea7d80ee16451e42edb70c113f59d80e5360aba03041be4ffb9c78");
            result.DateA.ShouldBe(new DateTime(2006, 8, 21));
            result.DateD.ShouldBe(new DateTime(2005, 8, 25));
            result.Sort.ShouldBe(1638069078);
            result.Note.ShouldBe("663258de9c444ff49c6bbeaf409147205483f9ef67af47b79d855bde9cc3200d023e4cefd5af4a20aafa51700961c8f24adc94e6c1a4418a8793e1a74b38f38404d2e1a408cf44e2a10f2b3183d8241ea3cc26bfbf534d92ab867a6e1f783f7b39b5d7d2aa6a4a7abb7d07f6856a317db7c00acdc18d43c9980791dc62b1d2fa02462df67f884278ab48e9f92f461f15487b9dd68cce4c75bc0e83db6425a01916b6bc28e0da4727a6cb33947e1e0a848eaf4005d04d48e6af9a596f3151dabd2854d0cf0adb4cc9a5449dff49f3858e0d9be6e625bb48bd891852f3afb8266810c1ef3fcedb4acf83c2b382de054e347d5f699d83824ca69463");
            result.Status.ShouldBe("835bf32327a74978afb76e96fc53a3daf7f29a0ba2954557a5");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemUserNotifyUpdateDto()
            {
                UserMainId = Guid.Parse("8ae7b6d4-2583-40bd-aa72-feb611cfba85"),
                KeyId = "fa5f12c0376a4c3ca744d409cdcd57bec3cc741c9bed4a409a",
                KeyName = "9b94bf49e42541ca94d7278b6885f0898bff26cbb01f4b17b2",
                NotifyTypeCode = "b4bb4ed2fa924d2982e791366cf5341dfce999f60a41419ebf",
                AppName = "0084e41a1c6c4ae5a8050c2ce1521b95ab432783319f41dfbc",
                AppCode = "0796f66b5e374da0b655fe1570e2844bba70ebcbf5df4f3dad",
                TitleContents = "3416fc2642a3440082c940cf167aecbf557e84f2e6f64fdf863ee73bb11865d23190208010f444e18a79b816dd1d6441c8ee661826d9441f887c8a40231871495ee3247bc25540739d0e8145369e4099fbcffa713f424af5a92cb7c2567ef80dcb21ee78ab594f7f99e06c98431fea0a63469a30aa3d48c4ba6dc78ffe78a70d257fb78ecac548bfa6e667d585bfd40ee30a6384160e42bc8de052852d972fd9d150fcc1337544dba30d8db592b42e8f1f27b043861642c18c61046b0a64fb9f7bc6a991a69c4f7a8bf8964fbeb3ecce5e94489ca17d4072b700493617d45540de50f0e514294ef187f8df6632525ff81ca1c7d9dc7c427fbb42",
                Contents = "1a3dc5fbd5c0431f8405ef93fb7b1c74235562fe59964dc284fa5c83078621579ab58f52d5304b98afbdc91b082255b8e636585b04b04e659b19b2d62718c6ae9591d2f0cd7f4dc5869969b0af5f8220c81d707d9c504f8e8f3232261047fb003e69c622f1914ab495ae27f64550bb34fe6b6c458dec4be3b6f1c80432269ded1b9dd20b4d52460f9587b5f3e39cc014d77975e952034796abd9b8bbd904b9b760379b44d72246c2953d004457d5df9048ef8e8ee73442bda72f4c6eef64908bb86fcb05188248b1a1f90e6363634829c6af1ee305034d1ebb46a1e9d361d52077205373278c4e398d75985879af2408cacd352767124783905e",
                IsRead = true,
                ExtendedInformation = "26b4dd3ad7ab4520bcae93d38b49b9c12eba904469bd450aa339c2efb2395ac86056e82d072146ee9aa40e4ceb9c3c35fc7b5bb3ff774b8cb93ffb9f9423d6aef981443d0cbc4e0fb384eedea481b21396e7b22d95c7433898becec4f82111c10c395de869b44782acc536950bd22ae6411bf3d276314a60944e8a43a782719a9b649ea388b64801ae83fafd26b8d9c9b9d7084d74b34ed0a05fc8ae59ceb60560beb5d6e6e645eb9ef18e9ec24d9bc8da9959c4a9bd42c68e587a57c2bbf02a9ff35e51f0a245d680be95fe43850f18a8f5427b79f247519e6b0fd8a4186714e52989dac17b4a18a6a7e3fbef7706c9cf5f03accee347a0a6f4",
                DateA = new DateTime(2008, 1, 15),
                DateD = new DateTime(2018, 10, 11),
                Sort = 489822114,
                Note = "d89f73d969ab498ab3cc59f080ffb0d1923d770310044243a01e389d6f570329352a32ebc80e48009ec59bc4f2e86164b66b9b5d5fcd4917bc40ebdc491dd37f632a2ee5feed43d584d9a626f9a59aab3c52377e3de14eb4bc24fd4ffb045dcd0378203dcb8443a794f4a1755cfba09f5c20c233b3f44bd6b2e69adbb372babc3381ce3dc1304299947691e389216b7247692a5f921843e989157e7da111bb050038128a02c24ae48823a993f985f67ecce27f3a2f134262a32baf046d9ec0a3cb7f6af7be2443529e5377f7925d98c741674cc173b9487d8ae7f2eaba6dd0f36df069dcf01c406b8f2d1e8f069a282cf48e23cc57654f52aee9",
                Status = "ad39487bea3d414fad9760dae108ec30023f6fa1581840c6ae"
            };

            // Act
            var serviceResult = await _systemUserNotifysAppService.UpdateAsync(Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"), input);

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("8ae7b6d4-2583-40bd-aa72-feb611cfba85"));
            result.KeyId.ShouldBe("fa5f12c0376a4c3ca744d409cdcd57bec3cc741c9bed4a409a");
            result.KeyName.ShouldBe("9b94bf49e42541ca94d7278b6885f0898bff26cbb01f4b17b2");
            result.NotifyTypeCode.ShouldBe("b4bb4ed2fa924d2982e791366cf5341dfce999f60a41419ebf");
            result.AppName.ShouldBe("0084e41a1c6c4ae5a8050c2ce1521b95ab432783319f41dfbc");
            result.AppCode.ShouldBe("0796f66b5e374da0b655fe1570e2844bba70ebcbf5df4f3dad");
            result.TitleContents.ShouldBe("3416fc2642a3440082c940cf167aecbf557e84f2e6f64fdf863ee73bb11865d23190208010f444e18a79b816dd1d6441c8ee661826d9441f887c8a40231871495ee3247bc25540739d0e8145369e4099fbcffa713f424af5a92cb7c2567ef80dcb21ee78ab594f7f99e06c98431fea0a63469a30aa3d48c4ba6dc78ffe78a70d257fb78ecac548bfa6e667d585bfd40ee30a6384160e42bc8de052852d972fd9d150fcc1337544dba30d8db592b42e8f1f27b043861642c18c61046b0a64fb9f7bc6a991a69c4f7a8bf8964fbeb3ecce5e94489ca17d4072b700493617d45540de50f0e514294ef187f8df6632525ff81ca1c7d9dc7c427fbb42");
            result.Contents.ShouldBe("1a3dc5fbd5c0431f8405ef93fb7b1c74235562fe59964dc284fa5c83078621579ab58f52d5304b98afbdc91b082255b8e636585b04b04e659b19b2d62718c6ae9591d2f0cd7f4dc5869969b0af5f8220c81d707d9c504f8e8f3232261047fb003e69c622f1914ab495ae27f64550bb34fe6b6c458dec4be3b6f1c80432269ded1b9dd20b4d52460f9587b5f3e39cc014d77975e952034796abd9b8bbd904b9b760379b44d72246c2953d004457d5df9048ef8e8ee73442bda72f4c6eef64908bb86fcb05188248b1a1f90e6363634829c6af1ee305034d1ebb46a1e9d361d52077205373278c4e398d75985879af2408cacd352767124783905e");
            result.IsRead.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("26b4dd3ad7ab4520bcae93d38b49b9c12eba904469bd450aa339c2efb2395ac86056e82d072146ee9aa40e4ceb9c3c35fc7b5bb3ff774b8cb93ffb9f9423d6aef981443d0cbc4e0fb384eedea481b21396e7b22d95c7433898becec4f82111c10c395de869b44782acc536950bd22ae6411bf3d276314a60944e8a43a782719a9b649ea388b64801ae83fafd26b8d9c9b9d7084d74b34ed0a05fc8ae59ceb60560beb5d6e6e645eb9ef18e9ec24d9bc8da9959c4a9bd42c68e587a57c2bbf02a9ff35e51f0a245d680be95fe43850f18a8f5427b79f247519e6b0fd8a4186714e52989dac17b4a18a6a7e3fbef7706c9cf5f03accee347a0a6f4");
            result.DateA.ShouldBe(new DateTime(2008, 1, 15));
            result.DateD.ShouldBe(new DateTime(2018, 10, 11));
            result.Sort.ShouldBe(489822114);
            result.Note.ShouldBe("d89f73d969ab498ab3cc59f080ffb0d1923d770310044243a01e389d6f570329352a32ebc80e48009ec59bc4f2e86164b66b9b5d5fcd4917bc40ebdc491dd37f632a2ee5feed43d584d9a626f9a59aab3c52377e3de14eb4bc24fd4ffb045dcd0378203dcb8443a794f4a1755cfba09f5c20c233b3f44bd6b2e69adbb372babc3381ce3dc1304299947691e389216b7247692a5f921843e989157e7da111bb050038128a02c24ae48823a993f985f67ecce27f3a2f134262a32baf046d9ec0a3cb7f6af7be2443529e5377f7925d98c741674cc173b9487d8ae7f2eaba6dd0f36df069dcf01c406b8f2d1e8f069a282cf48e23cc57654f52aee9");
            result.Status.ShouldBe("ad39487bea3d414fad9760dae108ec30023f6fa1581840c6ae");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemUserNotifysAppService.DeleteAsync(Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"));

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"));

            result.ShouldBeNull();
        }
    }
}