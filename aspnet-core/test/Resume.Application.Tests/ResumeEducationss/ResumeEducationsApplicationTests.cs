using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeEducationssAppService _resumeEducationssAppService;
        private readonly IRepository<ResumeEducations, Guid> _resumeEducationsRepository;

        public ResumeEducationssAppServiceTests()
        {
            _resumeEducationssAppService = GetRequiredService<IResumeEducationssAppService>();
            _resumeEducationsRepository = GetRequiredService<IRepository<ResumeEducations, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetListAsync(new GetResumeEducationssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8cf61535-470c-4030-bdb3-fed3f5379d85")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetAsync(Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeEducationsCreateDto
            {
                ResumeMainId = Guid.Parse("b8c7fd6a-36ae-4fd4-8521-6cd127f4f532"),
                EducationLevelCode = "9389dffb0b1445aba2f0471e881b0698d6e017597c0544ccb7",
                SchoolCode = "5e865013abab4d34add666218f2e2996c1e5244912334d759e",
                SchoolName = "942aa67fc4a348df9a6b35318967b1d104b624bb3df64fcb82c8ec20efd1eeed6f7d199328854b638b0273db7ab1026987acabca34ed4fde9bc065448d5aa41c850f9fbd777043efa5acdc59e5183754f05658a2f8dc41b38e94b51880e97ac09db5382a",
                Night = true,
                Working = true,
                MajorDepartmentName = "3191f05f21bd42e59a557187d9ec663077d55a761387411d90",
                MajorDepartmentCategory = "c277231468794a8c872baedda854be07124b1b46cbc249468341c72becce8d5a778a0ab2f5f941d992e63bbe7a47f2803fda6e4d7ad64606b82bcd0981d5505a510759620af440c4b6c212124629738b1f72443a96044c2a83381a610064bf9d1e22481c0c824c8899535bef26c29156cfbdb5cf57414127855da88e1f120e365b9ae20ffdba454faf6d717e544dc5a9900f3162b6d34088af293a2abe04aadc860f8306bf334eca8a04bf819de4190dd3b2f44694a74f3f96d66cb4f9f2e9fa7fe697d6c8fb483594411377499371156410adcab9244e8c9acd3c177132c01ccb05892201844bc995fb6ffbcfa0544089b5474bfcfe41f6bc1a",
                MinorDepartmentName = "aa149946819e496b878c66c76f805d12f7ffe28fb934498eb4",
                MinorDepartmentCategory = "75d1acd1ba37407bb95b4e16656896a0faf0a431a2294f65ba36cf2a6b44500b6142d00df2d04534a7ab1ab13ea5c4ab4515fc69020c4f9c860bbacd2be91ce5767d014d198046f8b5f42a372b88542816d740f50751404a899cf659f22e01014854eef0cb644aef930cbe959a9c5bd82c94f20be1eb49a5b027f9b8812091d845a8740968ac4aaca35cf3168e71e04d15219479511147e6b4101d992b8a558456056ef59bb94c07a09392b3114d912f990a9b55baa44934bf021451722c2f572ef47ce0c9cf430c8e32d2c7fa2ad27975ee8d327bd147b1a8ac0440d54e2e20f17fa56f8c334d7bb781fa67f32457eb0d2f225b30e04a16bcdc",
                GraduationCode = "d1c6ca3ea70f4788953b16d98f2cccd31545115213ac41b1b5",
                Domestic = true,
                CountryCode = "4a0f9f261fac4c1a8ec93308bcb1e8e529e305ad2ed9453590",
                ExtendedInformation = "d6fa487cbb4f431ab14c1986a48029d0ef58534853594000a3a750ba90cc5bf89a542e8354cb4f90bbe7adaa9eb92f7096d4d9ca17eb4d4db47708848b2f07d87eb5a7df16b540a58da1201cc302f4da980b9dd6444a464a9d6b6b002ca2879870ed0b9526c147c68dd160fa1476621f17c0806f73c944dc8f4f01ac5e86e9e7ecba51d0cc824412881e30fc57afe106ce21fda269e243c09a7c4bc14fe0463ba165808d36e541c7948f68b72dbac0ca139dbe6fb67a40a1b66fd4fa81dd622b458a32c3c09049fabffecbf6ca9837280c0b008474d0415480b22c1a857e74f96ab1ffebd7954a81a94c46668826ac3a4a0bb53f13784ca2951e",
                DateA = new DateTime(2003, 7, 11),
                DateD = new DateTime(2016, 3, 16),
                Sort = 1382562591,
                Note = "998213db331e4a4ea47b273f29bec0483f8c565f28754db6a859a173616bf5bda13b3fd0b5d3453399cdf4d60f2148a1f6f8d1a2c91941fd98cb20d359fd4e75bc75886db7de48c398f19e430981e8f70bddc73347ff4f9bbc587d898df8090ffa17ec87cf4c49e98d30c15b99dc728b3a5602734dad4fb4aebec7b265bdf2e842828215c0f24939a2a264d707b112eb1d5377ae168740b7aff00a4a06bf131e724ea86a24264a8fa5f812eb4c04382edf03180ad47847c0b43fd69b933cde5a962ba4085678428da2a753d5a1016cc63fb323c8128d4222a1a2d378ddc346e1df2e8e1ba0dd4860b3bcec1453ed917b6fee2e32a1174b929985",
                Status = "ea0dd836d8c74e73b6c68acff8114d2f4417a13541c448ecbb"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("b8c7fd6a-36ae-4fd4-8521-6cd127f4f532"));
            result.EducationLevelCode.ShouldBe("9389dffb0b1445aba2f0471e881b0698d6e017597c0544ccb7");
            result.SchoolCode.ShouldBe("5e865013abab4d34add666218f2e2996c1e5244912334d759e");
            result.SchoolName.ShouldBe("942aa67fc4a348df9a6b35318967b1d104b624bb3df64fcb82c8ec20efd1eeed6f7d199328854b638b0273db7ab1026987acabca34ed4fde9bc065448d5aa41c850f9fbd777043efa5acdc59e5183754f05658a2f8dc41b38e94b51880e97ac09db5382a");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("3191f05f21bd42e59a557187d9ec663077d55a761387411d90");
            result.MajorDepartmentCategory.ShouldBe("c277231468794a8c872baedda854be07124b1b46cbc249468341c72becce8d5a778a0ab2f5f941d992e63bbe7a47f2803fda6e4d7ad64606b82bcd0981d5505a510759620af440c4b6c212124629738b1f72443a96044c2a83381a610064bf9d1e22481c0c824c8899535bef26c29156cfbdb5cf57414127855da88e1f120e365b9ae20ffdba454faf6d717e544dc5a9900f3162b6d34088af293a2abe04aadc860f8306bf334eca8a04bf819de4190dd3b2f44694a74f3f96d66cb4f9f2e9fa7fe697d6c8fb483594411377499371156410adcab9244e8c9acd3c177132c01ccb05892201844bc995fb6ffbcfa0544089b5474bfcfe41f6bc1a");
            result.MinorDepartmentName.ShouldBe("aa149946819e496b878c66c76f805d12f7ffe28fb934498eb4");
            result.MinorDepartmentCategory.ShouldBe("75d1acd1ba37407bb95b4e16656896a0faf0a431a2294f65ba36cf2a6b44500b6142d00df2d04534a7ab1ab13ea5c4ab4515fc69020c4f9c860bbacd2be91ce5767d014d198046f8b5f42a372b88542816d740f50751404a899cf659f22e01014854eef0cb644aef930cbe959a9c5bd82c94f20be1eb49a5b027f9b8812091d845a8740968ac4aaca35cf3168e71e04d15219479511147e6b4101d992b8a558456056ef59bb94c07a09392b3114d912f990a9b55baa44934bf021451722c2f572ef47ce0c9cf430c8e32d2c7fa2ad27975ee8d327bd147b1a8ac0440d54e2e20f17fa56f8c334d7bb781fa67f32457eb0d2f225b30e04a16bcdc");
            result.GraduationCode.ShouldBe("d1c6ca3ea70f4788953b16d98f2cccd31545115213ac41b1b5");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("4a0f9f261fac4c1a8ec93308bcb1e8e529e305ad2ed9453590");
            result.ExtendedInformation.ShouldBe("d6fa487cbb4f431ab14c1986a48029d0ef58534853594000a3a750ba90cc5bf89a542e8354cb4f90bbe7adaa9eb92f7096d4d9ca17eb4d4db47708848b2f07d87eb5a7df16b540a58da1201cc302f4da980b9dd6444a464a9d6b6b002ca2879870ed0b9526c147c68dd160fa1476621f17c0806f73c944dc8f4f01ac5e86e9e7ecba51d0cc824412881e30fc57afe106ce21fda269e243c09a7c4bc14fe0463ba165808d36e541c7948f68b72dbac0ca139dbe6fb67a40a1b66fd4fa81dd622b458a32c3c09049fabffecbf6ca9837280c0b008474d0415480b22c1a857e74f96ab1ffebd7954a81a94c46668826ac3a4a0bb53f13784ca2951e");
            result.DateA.ShouldBe(new DateTime(2003, 7, 11));
            result.DateD.ShouldBe(new DateTime(2016, 3, 16));
            result.Sort.ShouldBe(1382562591);
            result.Note.ShouldBe("998213db331e4a4ea47b273f29bec0483f8c565f28754db6a859a173616bf5bda13b3fd0b5d3453399cdf4d60f2148a1f6f8d1a2c91941fd98cb20d359fd4e75bc75886db7de48c398f19e430981e8f70bddc73347ff4f9bbc587d898df8090ffa17ec87cf4c49e98d30c15b99dc728b3a5602734dad4fb4aebec7b265bdf2e842828215c0f24939a2a264d707b112eb1d5377ae168740b7aff00a4a06bf131e724ea86a24264a8fa5f812eb4c04382edf03180ad47847c0b43fd69b933cde5a962ba4085678428da2a753d5a1016cc63fb323c8128d4222a1a2d378ddc346e1df2e8e1ba0dd4860b3bcec1453ed917b6fee2e32a1174b929985");
            result.Status.ShouldBe("ea0dd836d8c74e73b6c68acff8114d2f4417a13541c448ecbb");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeEducationsUpdateDto()
            {
                ResumeMainId = Guid.Parse("5be01faf-1df2-4395-8bbc-b889fdcc0e5e"),
                EducationLevelCode = "48ef228dfa074ca288ff43e2b6be56491a4051fc3c95422799",
                SchoolCode = "77c25eb4d3964e10b8cb754fea0343ee3acd5a2d891b42f281",
                SchoolName = "c0cbcb02c2a44c79926ff9499bcb534d124f83f5038743169fa16bdfa78b42e941fc59a11887454fa78baeee552510836c5cfa03543a472ea0adde55acab36d9129dbf91f1bd4c14914a7a8a50befdf98b4b992570ad4fafaf6b028f8ff4256929be051e",
                Night = true,
                Working = true,
                MajorDepartmentName = "5a4203f5455b4a43b267449569d83a199eb34d590ab84e1b93",
                MajorDepartmentCategory = "d3dd976a8ead45e9805faeb7636570df7d2f6b15d14e42a780074d60af1b8070a8c1c6973b3e4ca1acee41842efdcc424b510850249f4dbc8cbf47d6f402407884aaa08672944e2083d9af2ae24eac5bed24bbe5cbb14bb5abcc6131b60542c7cffbed53134b4b658760948b255882a02f88c75c77d1424396d1ae3a5744691df83bdf3a4a344d988e5c4e9e2ded8e96477dbfc0e8094181aa2e93975e6600aa3e93178221ac4773bb4b129a97e9e409674e1d0aab944079b8d52ad1adc8afe727a28745252e4a82a52cdaf8629324109a4179cae55f4541b5f8896bb6b2988ab9d62dcbcdaf4e778eb52406260e2c92e174d0bb6057475bbef6",
                MinorDepartmentName = "c9e035e209a5436baa598d33a2f5127c0051ea5e21be420299",
                MinorDepartmentCategory = "e741d8f920a84f31a8c95d94efd3e2722ffa5408f3714b2987a6724289a85511191adf4b1ca441588d5faf3aee4de0629c301e2a17b14627af51103c6aa9b747769b9cd0923b441bbe65732fa73761ab2cf8602a947e414b8059fd811d256e0dae65a91a30164c499b817f84dacc1073f44f71fd767d4f649c5bd4b9e93bb84e2751c79a927c4483bcaf3486ce6d60d01a298ac7b9fd41f2809b6508665b832a6524b28bd5594706bad0d8117d09a645e93757e7243542d999631e62f24ea055afaa473a0d194daf9576df5dab71629c565ebc6ffb8c4d4a948437b16ac8cef5284788e6c28d4d65b56a124eded48957c6dde8a7205848218b5b",
                GraduationCode = "74182df38e3e4f4c86ccb07b883fe7da01f0554b76e54093b2",
                Domestic = true,
                CountryCode = "fbcce44b14574bea8ed933df2be3d7ab2d6ddf99e6b34816b1",
                ExtendedInformation = "0b1f713d4855476f941c2e9dffa6d0719a6cea85d1364dcd9435983ab2b51be27aa68a7532f54414916c7f5bd0a868a5d104069076dc4b18b4d9adb382a67c726da5983586ad4187a8b744d46154721dadb0969d7e154a82889870ec39a9fea33751af79d2d24f64b0d30573c759868c27d69314096541fbba17d524bf1726c95565df78caf04d3c819b059d6de04f80e7633308af484280b02fae25f2e1218f3d5fe0dcfdc24d9e82c042a3a60bcca61b6deafd613f468a9271e509835da993a16b3af46654499aaae6cdbb6d285a21daea9d24491544089e45865561626fd77341fe2b228e4000ba931cab5a8e52669298d21c9e11476d9afb",
                DateA = new DateTime(2000, 8, 6),
                DateD = new DateTime(2016, 11, 18),
                Sort = 3105158,
                Note = "bd2a24d9d12d494885a610562a29b259278e4539266f4fb6963079953cbfc7055940516cb1f44f48abdc1c72a4025a666a03edd9b7884644b4a12a9962ea24d76e8b8e07dd0848eca5910fa7936060d33e0c36a3a82f4eaeaf4125ad704d2de9c535507c9dc5405d9c60b2cda9a5720b6e8e87e345a34ea6844193f3a0fb4fe5ecff7c55f5c74d1ca74401ff463f43baeec17e189be6432294761648e2ae28231d100cf5be604666813261bca60cbf51e6f27d7cd8f8435fa4e0f4309b5a43ff09dd52d177f24fe38ea79c34a70d412dea987bf892a24ba8857f059e9364b195f5c39abcb5d244caa0dcbf0c86506d6c6a28d74fdc9944358cff",
                Status = "6fbaa733f01d447494d2c6f12e26da4ada1b7ffdda544ae89a"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.UpdateAsync(Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"), input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("5be01faf-1df2-4395-8bbc-b889fdcc0e5e"));
            result.EducationLevelCode.ShouldBe("48ef228dfa074ca288ff43e2b6be56491a4051fc3c95422799");
            result.SchoolCode.ShouldBe("77c25eb4d3964e10b8cb754fea0343ee3acd5a2d891b42f281");
            result.SchoolName.ShouldBe("c0cbcb02c2a44c79926ff9499bcb534d124f83f5038743169fa16bdfa78b42e941fc59a11887454fa78baeee552510836c5cfa03543a472ea0adde55acab36d9129dbf91f1bd4c14914a7a8a50befdf98b4b992570ad4fafaf6b028f8ff4256929be051e");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("5a4203f5455b4a43b267449569d83a199eb34d590ab84e1b93");
            result.MajorDepartmentCategory.ShouldBe("d3dd976a8ead45e9805faeb7636570df7d2f6b15d14e42a780074d60af1b8070a8c1c6973b3e4ca1acee41842efdcc424b510850249f4dbc8cbf47d6f402407884aaa08672944e2083d9af2ae24eac5bed24bbe5cbb14bb5abcc6131b60542c7cffbed53134b4b658760948b255882a02f88c75c77d1424396d1ae3a5744691df83bdf3a4a344d988e5c4e9e2ded8e96477dbfc0e8094181aa2e93975e6600aa3e93178221ac4773bb4b129a97e9e409674e1d0aab944079b8d52ad1adc8afe727a28745252e4a82a52cdaf8629324109a4179cae55f4541b5f8896bb6b2988ab9d62dcbcdaf4e778eb52406260e2c92e174d0bb6057475bbef6");
            result.MinorDepartmentName.ShouldBe("c9e035e209a5436baa598d33a2f5127c0051ea5e21be420299");
            result.MinorDepartmentCategory.ShouldBe("e741d8f920a84f31a8c95d94efd3e2722ffa5408f3714b2987a6724289a85511191adf4b1ca441588d5faf3aee4de0629c301e2a17b14627af51103c6aa9b747769b9cd0923b441bbe65732fa73761ab2cf8602a947e414b8059fd811d256e0dae65a91a30164c499b817f84dacc1073f44f71fd767d4f649c5bd4b9e93bb84e2751c79a927c4483bcaf3486ce6d60d01a298ac7b9fd41f2809b6508665b832a6524b28bd5594706bad0d8117d09a645e93757e7243542d999631e62f24ea055afaa473a0d194daf9576df5dab71629c565ebc6ffb8c4d4a948437b16ac8cef5284788e6c28d4d65b56a124eded48957c6dde8a7205848218b5b");
            result.GraduationCode.ShouldBe("74182df38e3e4f4c86ccb07b883fe7da01f0554b76e54093b2");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("fbcce44b14574bea8ed933df2be3d7ab2d6ddf99e6b34816b1");
            result.ExtendedInformation.ShouldBe("0b1f713d4855476f941c2e9dffa6d0719a6cea85d1364dcd9435983ab2b51be27aa68a7532f54414916c7f5bd0a868a5d104069076dc4b18b4d9adb382a67c726da5983586ad4187a8b744d46154721dadb0969d7e154a82889870ec39a9fea33751af79d2d24f64b0d30573c759868c27d69314096541fbba17d524bf1726c95565df78caf04d3c819b059d6de04f80e7633308af484280b02fae25f2e1218f3d5fe0dcfdc24d9e82c042a3a60bcca61b6deafd613f468a9271e509835da993a16b3af46654499aaae6cdbb6d285a21daea9d24491544089e45865561626fd77341fe2b228e4000ba931cab5a8e52669298d21c9e11476d9afb");
            result.DateA.ShouldBe(new DateTime(2000, 8, 6));
            result.DateD.ShouldBe(new DateTime(2016, 11, 18));
            result.Sort.ShouldBe(3105158);
            result.Note.ShouldBe("bd2a24d9d12d494885a610562a29b259278e4539266f4fb6963079953cbfc7055940516cb1f44f48abdc1c72a4025a666a03edd9b7884644b4a12a9962ea24d76e8b8e07dd0848eca5910fa7936060d33e0c36a3a82f4eaeaf4125ad704d2de9c535507c9dc5405d9c60b2cda9a5720b6e8e87e345a34ea6844193f3a0fb4fe5ecff7c55f5c74d1ca74401ff463f43baeec17e189be6432294761648e2ae28231d100cf5be604666813261bca60cbf51e6f27d7cd8f8435fa4e0f4309b5a43ff09dd52d177f24fe38ea79c34a70d412dea987bf892a24ba8857f059e9364b195f5c39abcb5d244caa0dcbf0c86506d6c6a28d74fdc9944358cff");
            result.Status.ShouldBe("6fbaa733f01d447494d2c6f12e26da4ada1b7ffdda544ae89a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeEducationssAppService.DeleteAsync(Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"));

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"));

            result.ShouldBeNull();
        }
    }
}