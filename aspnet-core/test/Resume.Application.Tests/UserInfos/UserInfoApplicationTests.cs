using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserInfos
{
    public class UserInfosAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserInfosAppService _userInfosAppService;
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;

        public UserInfosAppServiceTests()
        {
            _userInfosAppService = GetRequiredService<IUserInfosAppService>();
            _userInfoRepository = GetRequiredService<IRepository<UserInfo, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userInfosAppService.GetListAsync(new GetUserInfosInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c62ab187-cf97-48b2-8116-4edcdf7ff31e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userInfosAppService.GetAsync(Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserInfoCreateDto
            {
                UserMainId = Guid.Parse("1e941ce3-b436-432f-a30e-b56f81a46d53"),
                NameC = "c047dd5f914f420ea42b8fb93634d02158846574e3244b8085",
                NameE = "d2b7a71d926f457a868c197ed9ee3c747fd2fe664c02444aa8e3bc2f8b21223018fbabe503194b2ba704529b7db2be2f4b52f336eb0547768c8695c954bf84cb55a9c54fd1f1490cb5f91777042b8ebebcd5e666506346d2b3fa21c0bd9ba2c00c689006",
                IdentityNo = "3badbdce9e6b451199b7c920fe07f6ec618a7682c24a4e8db5",
                BirthDate = new DateTime(2019, 3, 22),
                SexCode = "cb14ce24fe9f4156b2d314c279626620f4e6f213d0984867b5",
                BloodCode = "ed9e5d88cffb4321b262968554c66e845b15d6e5257f4ff294",
                PlaceOfBirthCode = "4fed54384d0f4ff99d9d02b82cdfe37ff65c222028ee43f3bc",
                PassportNo = "0d8bb9f71fb74fbb832936caa5a38cd5a192adb896e3469b82",
                NationalityCode = "5474afe8c757404a89c8a07cefb5b4bf7d52f9acc7de46eaa2",
                ResidenceNo = "3232a749d1c34d0e9ecc3c92614dd3b7eeb276cf0c4f4d61b0",
                ExtendedInformation = "1e54129e096646c5bde869b4bd704d27c3305b9bbdaf48b5806504fdefb513e683eb52fc769c4d3db8ff0f6becfdcf40c00ce6d123cd43e28579ab68e50dfd1761d0e367f48f4ab19cb500eb3a0b12653d642818278d44f18380d3448ff68d2bae8d6067797b406aa47b88e2ad05ef9023830955b59e4f3ab5efb97de0ad203e150a120665704c7d9f06291ef72f4268d71a72c064e24cbbabd9814a82cb9c08fa9eb0506e004be9aa7a343bde417507c762cd5d4b4f40d3823c39092f3147198fea6a6d902f4e759e90b853ff3d53ede23add83cf894c6fab30bbd5139c60492c6eb3fe9b6e47de8cc783d2db1bddf3f447014ee9154a0cbb35",
                DateA = new DateTime(2003, 9, 17),
                DateD = new DateTime(2018, 11, 21),
                Sort = 584708841,
                Note = "7dcc4a2e14414143851ca47cac930b032f5c0cc04f3349d78029af6d321d4127f6577c1033dc45d9b6bdc47b99153ad10f2fab29cd3b4e7fbfc7407337b779570045e91353ef49d3b2e57b43b52a473175d46cca5d4c45c8ad6dca10ca7ee52b111510fc1d234db4982fdc4b51670a58a8ba772c78a24e598d9e8e444b842cb3519ec023b929466ca7a0ce401f9f84197289002f1a2845e1993ee5566744e81c7c5008bf9aaa458ba6ea3f428957251c83d8d8ff58bc481aada22a4f43439e622cb3ced108aa4cfc86c84b2efbd11fe4feeb0203254a4b06b36091bd27f3cbac7b1322d99c65459ebdb778a3153395cfacbed59b56d544dfa434",
                Status = "1a35784dc4874b3b9ca9cb5d2f48b774b9065918712f480090"
            };

            // Act
            var serviceResult = await _userInfosAppService.CreateAsync(input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("1e941ce3-b436-432f-a30e-b56f81a46d53"));
            result.NameC.ShouldBe("c047dd5f914f420ea42b8fb93634d02158846574e3244b8085");
            result.NameE.ShouldBe("d2b7a71d926f457a868c197ed9ee3c747fd2fe664c02444aa8e3bc2f8b21223018fbabe503194b2ba704529b7db2be2f4b52f336eb0547768c8695c954bf84cb55a9c54fd1f1490cb5f91777042b8ebebcd5e666506346d2b3fa21c0bd9ba2c00c689006");
            result.IdentityNo.ShouldBe("3badbdce9e6b451199b7c920fe07f6ec618a7682c24a4e8db5");
            result.BirthDate.ShouldBe(new DateTime(2019, 3, 22));
            result.SexCode.ShouldBe("cb14ce24fe9f4156b2d314c279626620f4e6f213d0984867b5");
            result.BloodCode.ShouldBe("ed9e5d88cffb4321b262968554c66e845b15d6e5257f4ff294");
            result.PlaceOfBirthCode.ShouldBe("4fed54384d0f4ff99d9d02b82cdfe37ff65c222028ee43f3bc");
            result.PassportNo.ShouldBe("0d8bb9f71fb74fbb832936caa5a38cd5a192adb896e3469b82");
            result.NationalityCode.ShouldBe("5474afe8c757404a89c8a07cefb5b4bf7d52f9acc7de46eaa2");
            result.ResidenceNo.ShouldBe("3232a749d1c34d0e9ecc3c92614dd3b7eeb276cf0c4f4d61b0");
            result.ExtendedInformation.ShouldBe("1e54129e096646c5bde869b4bd704d27c3305b9bbdaf48b5806504fdefb513e683eb52fc769c4d3db8ff0f6becfdcf40c00ce6d123cd43e28579ab68e50dfd1761d0e367f48f4ab19cb500eb3a0b12653d642818278d44f18380d3448ff68d2bae8d6067797b406aa47b88e2ad05ef9023830955b59e4f3ab5efb97de0ad203e150a120665704c7d9f06291ef72f4268d71a72c064e24cbbabd9814a82cb9c08fa9eb0506e004be9aa7a343bde417507c762cd5d4b4f40d3823c39092f3147198fea6a6d902f4e759e90b853ff3d53ede23add83cf894c6fab30bbd5139c60492c6eb3fe9b6e47de8cc783d2db1bddf3f447014ee9154a0cbb35");
            result.DateA.ShouldBe(new DateTime(2003, 9, 17));
            result.DateD.ShouldBe(new DateTime(2018, 11, 21));
            result.Sort.ShouldBe(584708841);
            result.Note.ShouldBe("7dcc4a2e14414143851ca47cac930b032f5c0cc04f3349d78029af6d321d4127f6577c1033dc45d9b6bdc47b99153ad10f2fab29cd3b4e7fbfc7407337b779570045e91353ef49d3b2e57b43b52a473175d46cca5d4c45c8ad6dca10ca7ee52b111510fc1d234db4982fdc4b51670a58a8ba772c78a24e598d9e8e444b842cb3519ec023b929466ca7a0ce401f9f84197289002f1a2845e1993ee5566744e81c7c5008bf9aaa458ba6ea3f428957251c83d8d8ff58bc481aada22a4f43439e622cb3ced108aa4cfc86c84b2efbd11fe4feeb0203254a4b06b36091bd27f3cbac7b1322d99c65459ebdb778a3153395cfacbed59b56d544dfa434");
            result.Status.ShouldBe("1a35784dc4874b3b9ca9cb5d2f48b774b9065918712f480090");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserInfoUpdateDto()
            {
                UserMainId = Guid.Parse("b580fd05-cf47-4316-80fa-d81a611cd1e0"),
                NameC = "a69b751e0c514c118fa65f46b009f06f30bc459310984b4c86",
                NameE = "e0f7762020f74867a82bba942a05abe7d6dfb1cf3870482da66e4bfca8dcd8d2bb35c89acf9641f584d07b32bd9b91657056cfd1716c4ca3bfd18365a8aa674edfd8e1d2739448529ddaf9544e6b88da7975a91151b74bfc83b621da3432fd9422b94b73",
                IdentityNo = "0b6ec25a7727401e86005d868d79fc5cef76cb7b2c1f419085",
                BirthDate = new DateTime(2015, 8, 19),
                SexCode = "1dd7742fa35547908ba272308602516a8d5d03bdce5a41bb9b",
                BloodCode = "d6a3e95bbde248afa13f069468ff5f770f349116bbe34c5bb6",
                PlaceOfBirthCode = "bba7647b5616405695aa9686dea77af4be200c1c3faf4b9080",
                PassportNo = "2026f083bdb94907a1b5178389b9695d4d77612870cb49339b",
                NationalityCode = "0b37d335fd284bfdbb7a23ae74b249657870037285e9414ca4",
                ResidenceNo = "3d945b7befeb468088cd19e636fa4610ee46dbba66e6461faa",
                ExtendedInformation = "827331ffda8b44b1a89a4f726307345696c01a6277334f5ab40581b0ba6cf366e711a371ae9c4d94a7603248b4621d8a7303c2969c5940e2a2c3b1f9ccd071c6e023f1881b6743aaafc2cbbffeee4d4eaa0f7ada8d1c4bbc89c81adb13133491ad4dd87e87804088b36677e1a933042e9e1db7a74fa54ba59b33865ce7e415f6b23c64f46d074302995409bc84d3c412932890ef1b56416e85c2541d9b61489fac01c901f6064a319ab65601ed7cb23600d295157862409b895a729a3e3018554710b0dc285c4e4f8eb611bef5240bfd9b5aeb9d54f64305b9a4a05995813a059d242cfb9f8c440b87699e0aca7f43b109389a55c9a5438ea7dd",
                DateA = new DateTime(2010, 8, 16),
                DateD = new DateTime(2016, 2, 23),
                Sort = 1790681965,
                Note = "3d06ec18b44c478795b2df0e7515e1ce100e453c687a404eab065dabc95a101eb8c0af14776b4600a7073b6375931edd6e9ba97720144ecfafd7124bc2af8088fb227f78f87e4de6b507e5ecee5f4979cea042bad94e41e2ae8d09857425457893597e128c174f3cafe6133e088c055aab17ca5d64bd4075b6f6b56af3964dee3515d76b396f41ad83b085506007d74dcb5ef23206834d9fb4456b89bc996c3f826636ea09714b89b0b260d586138f1e2641b224ea0c4ad4a08f07286febbd2db310ef577880405da8da2dc66ae2113cbd3c52fd090146658b5ea94d60f8c232169ce20b4eaf4c2f8f929a3d9a7b7ab617d00c89b60c41ba8ad4",
                Status = "2363848098b242fc805fd3c6ba328db9c37fd1e10aa4447fa5"
            };

            // Act
            var serviceResult = await _userInfosAppService.UpdateAsync(Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"), input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("b580fd05-cf47-4316-80fa-d81a611cd1e0"));
            result.NameC.ShouldBe("a69b751e0c514c118fa65f46b009f06f30bc459310984b4c86");
            result.NameE.ShouldBe("e0f7762020f74867a82bba942a05abe7d6dfb1cf3870482da66e4bfca8dcd8d2bb35c89acf9641f584d07b32bd9b91657056cfd1716c4ca3bfd18365a8aa674edfd8e1d2739448529ddaf9544e6b88da7975a91151b74bfc83b621da3432fd9422b94b73");
            result.IdentityNo.ShouldBe("0b6ec25a7727401e86005d868d79fc5cef76cb7b2c1f419085");
            result.BirthDate.ShouldBe(new DateTime(2015, 8, 19));
            result.SexCode.ShouldBe("1dd7742fa35547908ba272308602516a8d5d03bdce5a41bb9b");
            result.BloodCode.ShouldBe("d6a3e95bbde248afa13f069468ff5f770f349116bbe34c5bb6");
            result.PlaceOfBirthCode.ShouldBe("bba7647b5616405695aa9686dea77af4be200c1c3faf4b9080");
            result.PassportNo.ShouldBe("2026f083bdb94907a1b5178389b9695d4d77612870cb49339b");
            result.NationalityCode.ShouldBe("0b37d335fd284bfdbb7a23ae74b249657870037285e9414ca4");
            result.ResidenceNo.ShouldBe("3d945b7befeb468088cd19e636fa4610ee46dbba66e6461faa");
            result.ExtendedInformation.ShouldBe("827331ffda8b44b1a89a4f726307345696c01a6277334f5ab40581b0ba6cf366e711a371ae9c4d94a7603248b4621d8a7303c2969c5940e2a2c3b1f9ccd071c6e023f1881b6743aaafc2cbbffeee4d4eaa0f7ada8d1c4bbc89c81adb13133491ad4dd87e87804088b36677e1a933042e9e1db7a74fa54ba59b33865ce7e415f6b23c64f46d074302995409bc84d3c412932890ef1b56416e85c2541d9b61489fac01c901f6064a319ab65601ed7cb23600d295157862409b895a729a3e3018554710b0dc285c4e4f8eb611bef5240bfd9b5aeb9d54f64305b9a4a05995813a059d242cfb9f8c440b87699e0aca7f43b109389a55c9a5438ea7dd");
            result.DateA.ShouldBe(new DateTime(2010, 8, 16));
            result.DateD.ShouldBe(new DateTime(2016, 2, 23));
            result.Sort.ShouldBe(1790681965);
            result.Note.ShouldBe("3d06ec18b44c478795b2df0e7515e1ce100e453c687a404eab065dabc95a101eb8c0af14776b4600a7073b6375931edd6e9ba97720144ecfafd7124bc2af8088fb227f78f87e4de6b507e5ecee5f4979cea042bad94e41e2ae8d09857425457893597e128c174f3cafe6133e088c055aab17ca5d64bd4075b6f6b56af3964dee3515d76b396f41ad83b085506007d74dcb5ef23206834d9fb4456b89bc996c3f826636ea09714b89b0b260d586138f1e2641b224ea0c4ad4a08f07286febbd2db310ef577880405da8da2dc66ae2113cbd3c52fd090146658b5ea94d60f8c232169ce20b4eaf4c2f8f929a3d9a7b7ab617d00c89b60c41ba8ad4");
            result.Status.ShouldBe("2363848098b242fc805fd3c6ba328db9c37fd1e10aa4447fa5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userInfosAppService.DeleteAsync(Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"));

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"));

            result.ShouldBeNull();
        }
    }
}