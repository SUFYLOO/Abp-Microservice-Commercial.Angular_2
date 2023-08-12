using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserVerifys
{
    public class UserVerifysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserVerifysAppService _userVerifysAppService;
        private readonly IRepository<UserVerify, long> _userVerifyRepository;

        public UserVerifysAppServiceTests()
        {
            _userVerifysAppService = GetRequiredService<IUserVerifysAppService>();
            _userVerifyRepository = GetRequiredService<IRepository<UserVerify, long>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userVerifysAppService.GetListAsync(new GetUserVerifysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userVerifysAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserVerifyCreateDto
            {
                VerifyId = "8f846cc400f1420bb639c5f2d53c8cebfbf536f8af0f4be7a0a9d505ef1b12cb812feb5523854fe7a18d2ac8edc80a79ddba680ff29e4ccdb85da6ea891aae99451bfc8282eb42c8a530c7d951775dcfe0f37ebad83d4eabab7139339e61ff8d9e5833b41c1f49e49815fc150687733e7fa4cba95b054b7dbded398bae168783d0f1d608f0f9478991fa0b7d1baeb24890f4d88f2c84426cbcc56cd4c59a6936cb92ea4e63604a55a26a742992aeee7de769f3ab7dc74471b71d7029a67160d40c1bb106ca9449f99e175cec511ac4d2a4a2f0599d4045ad8f3aaaaa1f7cff1ae40ca456a2b245539cbca07ff89b71846a8f2d40b7434ec582f6",
                VerifyCode = "f73b01d62da84d6baca2343b34882759ebd4aeb153ad4a24b1",
                ExtendedInformation = "4ef62aad178346a0a14c03df996628837b5a4dba0657432b84aa4ecf5534879deb23e8ec5dd24c28af4fd436cfa9df526395829abb9f425caf0645920570b4d771efb5e98fad4ecbabf6d28f3c4277d271a73b048184449887684650e26294ef4ce21b9f4902421bb511596812038e169df2fdb294ad4b85af005ce6ba3acc4bc78903f378814a60873cbf856f203ade22104b9d8f514f648cf8155daeebcfcece53bd5b517041bcaa303de647613dd7dc26b5dde2044c379e2bfddf5fb326a1d8ca0dacfda64889965f98ccbd6d8fcedfaf916ef9554a44923f5701f1b4a21b919f9470ba6e4cf4a3350954eac8a65adf47503c9d8b427496b0",
                DateA = new DateTime(2016, 6, 9),
                DateD = new DateTime(2012, 1, 7),
                Sort = 683774197,
                Note = "27f1d8ba08c7470e87a780c92fb03401d710c2890258468ea9e38bb367d661a22659718c835c44ada5708761ae83ccb0ad3b691d16724a258418124ee7f1e0997efb904dc8f64a6ca72aa4c6407760ec8c448d3a875847059519f4084ed76af04e47fcd2039f4fc29d9bec3b6d91da9502259c1a3eab422fba6d7a844b22550dde7c6c4400b04fd5a8052b852ed885369c1b8c1531214ea3bc5a0e6a74ceb12d39fe7a282807423590948c98e47358bae66837c456da4a688caff9e9fadd1832a62c39aa967846898455ae7ff9d64eee10fab5436d224665a88fc74253c949c442390f87775e44e8991c939665b1105c12f11401102e41e4957c",
                Status = "843e18090d644921bdb1ac1841bf2a930bbef4caad814c65a6"
            };

            // Act
            var serviceResult = await _userVerifysAppService.CreateAsync(input);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.VerifyId == serviceResult.VerifyId);

            result.ShouldNotBe(null);
            result.VerifyId.ShouldBe("8f846cc400f1420bb639c5f2d53c8cebfbf536f8af0f4be7a0a9d505ef1b12cb812feb5523854fe7a18d2ac8edc80a79ddba680ff29e4ccdb85da6ea891aae99451bfc8282eb42c8a530c7d951775dcfe0f37ebad83d4eabab7139339e61ff8d9e5833b41c1f49e49815fc150687733e7fa4cba95b054b7dbded398bae168783d0f1d608f0f9478991fa0b7d1baeb24890f4d88f2c84426cbcc56cd4c59a6936cb92ea4e63604a55a26a742992aeee7de769f3ab7dc74471b71d7029a67160d40c1bb106ca9449f99e175cec511ac4d2a4a2f0599d4045ad8f3aaaaa1f7cff1ae40ca456a2b245539cbca07ff89b71846a8f2d40b7434ec582f6");
            result.VerifyCode.ShouldBe("f73b01d62da84d6baca2343b34882759ebd4aeb153ad4a24b1");
            result.ExtendedInformation.ShouldBe("4ef62aad178346a0a14c03df996628837b5a4dba0657432b84aa4ecf5534879deb23e8ec5dd24c28af4fd436cfa9df526395829abb9f425caf0645920570b4d771efb5e98fad4ecbabf6d28f3c4277d271a73b048184449887684650e26294ef4ce21b9f4902421bb511596812038e169df2fdb294ad4b85af005ce6ba3acc4bc78903f378814a60873cbf856f203ade22104b9d8f514f648cf8155daeebcfcece53bd5b517041bcaa303de647613dd7dc26b5dde2044c379e2bfddf5fb326a1d8ca0dacfda64889965f98ccbd6d8fcedfaf916ef9554a44923f5701f1b4a21b919f9470ba6e4cf4a3350954eac8a65adf47503c9d8b427496b0");
            result.DateA.ShouldBe(new DateTime(2016, 6, 9));
            result.DateD.ShouldBe(new DateTime(2012, 1, 7));
            result.Sort.ShouldBe(683774197);
            result.Note.ShouldBe("27f1d8ba08c7470e87a780c92fb03401d710c2890258468ea9e38bb367d661a22659718c835c44ada5708761ae83ccb0ad3b691d16724a258418124ee7f1e0997efb904dc8f64a6ca72aa4c6407760ec8c448d3a875847059519f4084ed76af04e47fcd2039f4fc29d9bec3b6d91da9502259c1a3eab422fba6d7a844b22550dde7c6c4400b04fd5a8052b852ed885369c1b8c1531214ea3bc5a0e6a74ceb12d39fe7a282807423590948c98e47358bae66837c456da4a688caff9e9fadd1832a62c39aa967846898455ae7ff9d64eee10fab5436d224665a88fc74253c949c442390f87775e44e8991c939665b1105c12f11401102e41e4957c");
            result.Status.ShouldBe("843e18090d644921bdb1ac1841bf2a930bbef4caad814c65a6");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserVerifyUpdateDto()
            {
                VerifyId = "fcf3d9ddab7f44ada42bb0e0604f6a6a3e70877df16044e2a7e936ed3ba3988d325dcef1d2144e1aa60c53609193241db6964d54ec174094b6b416b165753e031db707a8f10b4d369f87f1c4c895aa3d8b2fd240a6274e4598db79c493ad82969a31f0cf6f6349b7b66d05a594c41df061f2203208e04471bcaef26dcbdfdc5329a09a02e62346bbb69e760b92a9390794cd141a3ebb4e2fa60fdeaf172351ffdb8d6b8cbc3d448e870c0c5542c2ff422681003efe5f4e62939822595cfdf0df0a487f04693b4b7ab493cfac671d6533ad304778212541f2bef8e58f668b671a270776f7212e4e7ba5d46e6a5e47162f32f02e8a30734eea908c",
                VerifyCode = "cfdf8d2963bb4aef9af53bc0f9f22b82aefe6392a37e4490ba",
                ExtendedInformation = "95174494da0242a184022451c03743bdaaf37519f0754b0b8d97cfb4526b43cd22f7b7de008647a7bc46186596687777ab6e8df4d3c74dcc9229de1aba82d8a50998eaf04f4d4a8ea73cd799d923a98197c52b5464e44b1bad49bcb06e72ccfc6a0f6ca67cf54ed988304fec2c8cd8a905ece9ac01564fad8a12372ff1a4b8db3e42d596ef01447caef1f47358d24a66743a468f46d9477391aeeb723b810251f148ca009f034a309ea7719d049e2665677796844b8149619d25797962f4675fb14771092358481eb25b71c735ce8b06b090690337c34248bcbecc604f6275f0cfd1697eae5142379fa458c7ba596e5b0b8c21820b24487ab390",
                DateA = new DateTime(2011, 3, 19),
                DateD = new DateTime(2011, 8, 9),
                Sort = 131111791,
                Note = "f8fe2c6a505c46578c6f5a8821c7ff7f790f3d0c5aa34c6d9de863e8d2a8748185f6f60696a744c489c24c38d6f4bc89ca359034f0124bb7a828bf91d186f1a7b108605fc7d04bdc89487a860dec689598630feb074045caaff7030bd179829ddb898097e108472381b6b9ab5ad83f71a571d636f8e34913a2eade1e0264e9b676bc9d8f48344895b9cb6097a8587f356ab9242d6552486d937321bd347af0b24a692d962a11471c8b02d9be0b2dc8050fe3b7b32e5840528049319f97b264d0b99bd3ebf91b4d1982c1a509487aad69b500af168e374e529954085707e3625b07116645e503493692c9665ef49593895f191d62acb241078ae3",
                Status = "cdbcdc3a47fa4a4d86b928b556ac5b8c2083d74e7a754550b8"
            };

            // Act
            var serviceResult = await _userVerifysAppService.UpdateAsync(1, input);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.VerifyId.ShouldBe("fcf3d9ddab7f44ada42bb0e0604f6a6a3e70877df16044e2a7e936ed3ba3988d325dcef1d2144e1aa60c53609193241db6964d54ec174094b6b416b165753e031db707a8f10b4d369f87f1c4c895aa3d8b2fd240a6274e4598db79c493ad82969a31f0cf6f6349b7b66d05a594c41df061f2203208e04471bcaef26dcbdfdc5329a09a02e62346bbb69e760b92a9390794cd141a3ebb4e2fa60fdeaf172351ffdb8d6b8cbc3d448e870c0c5542c2ff422681003efe5f4e62939822595cfdf0df0a487f04693b4b7ab493cfac671d6533ad304778212541f2bef8e58f668b671a270776f7212e4e7ba5d46e6a5e47162f32f02e8a30734eea908c");
            result.VerifyCode.ShouldBe("cfdf8d2963bb4aef9af53bc0f9f22b82aefe6392a37e4490ba");
            result.ExtendedInformation.ShouldBe("95174494da0242a184022451c03743bdaaf37519f0754b0b8d97cfb4526b43cd22f7b7de008647a7bc46186596687777ab6e8df4d3c74dcc9229de1aba82d8a50998eaf04f4d4a8ea73cd799d923a98197c52b5464e44b1bad49bcb06e72ccfc6a0f6ca67cf54ed988304fec2c8cd8a905ece9ac01564fad8a12372ff1a4b8db3e42d596ef01447caef1f47358d24a66743a468f46d9477391aeeb723b810251f148ca009f034a309ea7719d049e2665677796844b8149619d25797962f4675fb14771092358481eb25b71c735ce8b06b090690337c34248bcbecc604f6275f0cfd1697eae5142379fa458c7ba596e5b0b8c21820b24487ab390");
            result.DateA.ShouldBe(new DateTime(2011, 3, 19));
            result.DateD.ShouldBe(new DateTime(2011, 8, 9));
            result.Sort.ShouldBe(131111791);
            result.Note.ShouldBe("f8fe2c6a505c46578c6f5a8821c7ff7f790f3d0c5aa34c6d9de863e8d2a8748185f6f60696a744c489c24c38d6f4bc89ca359034f0124bb7a828bf91d186f1a7b108605fc7d04bdc89487a860dec689598630feb074045caaff7030bd179829ddb898097e108472381b6b9ab5ad83f71a571d636f8e34913a2eade1e0264e9b676bc9d8f48344895b9cb6097a8587f356ab9242d6552486d937321bd347af0b24a692d962a11471c8b02d9be0b2dc8050fe3b7b32e5840528049319f97b264d0b99bd3ebf91b4d1982c1a509487aad69b500af168e374e529954085707e3625b07116645e503493692c9665ef49593895f191d62acb241078ae3");
            result.Status.ShouldBe("cdbcdc3a47fa4a4d86b928b556ac5b8c2083d74e7a754550b8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userVerifysAppService.DeleteAsync(1);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}