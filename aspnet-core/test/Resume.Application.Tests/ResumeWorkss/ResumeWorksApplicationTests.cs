using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeWorkss
{
    public class ResumeWorkssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeWorkssAppService _resumeWorkssAppService;
        private readonly IRepository<ResumeWorks, Guid> _resumeWorksRepository;

        public ResumeWorkssAppServiceTests()
        {
            _resumeWorkssAppService = GetRequiredService<IResumeWorkssAppService>();
            _resumeWorksRepository = GetRequiredService<IRepository<ResumeWorks, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeWorkssAppService.GetListAsync(new GetResumeWorkssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0b94fa65-2c07-4070-854e-3dca34b861e8")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeWorkssAppService.GetAsync(Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeWorksCreateDto
            {
                ResumeMainId = Guid.Parse("7bb790fc-f7f1-4ed4-8e50-85b3eab8e25b"),
                Name = "3b701689b5b846c3ba9b0ad85cd1390bc24eeb1152594360bc9b1aadc551e40d54b73c12a5ac481ba663768dcd6d4fe9f4b8d454543a4a5c8264e60bf9723795ebb7b1e266834638a19adc55a361fe57b171fc4774744c759311abe53f6661ac7a22d432",
                Link = "12c3ad46cca04b989dca2ec0bbf3606d347e2f3bb9fb4790a57601a01036255182892f432dca41ecae7e5edae6c63b74c8c4cb5da8e24944a9e79d282100babc850da438b51b42d9897e9cfa1ce05157fda518ddc845400691373c666d1c2cacfeb8181c3419447d8f1dd78f5156cc415829ca9fa25e4c8c912879d0eed560c745cbed078a814a4da7bb7101c12642aa6058f1def18b4ed19db57b5c63a5d2e0be52e2d2d3d84dd68531ab221b217cd65a709b31e96a40d48dce241d2f8e100c98c776ccd08e4eee8bb66b926ef5fd51245139cf0e7d4482834ff90b9e78c2f57e2987428901472e985990f2cde399646ee649463a594561adb0",
                ExtendedInformation = "949654cc93df411f8fa588f28adb11f1623ad7ba45704a7cb4af1a7ef31f344f8459bc5028cb460fb730b343f8da1eb1e4ba48c8a8de4f8fbd65c5798ebda591e13ac086e5244f4da7afaac6844b009334e2d53028cf4e0584c994e504d916c1ce222e9a9ae54ca7878da0305e5ee8d6dd922411753b44ff8c988ef16bfdaf7746063d9a3b794c8987dfc2d3821e49c1ca647940d3a04faeab0a445adf93689f0a43a2a04b8247ed978c7a342541713aef460e94cf5947d9ba616c138d4e668a0f3ca1b7041443c08a345fae2f5413bc745c43d7edd2449abc130af7d46ef475dfba2a197f2348cb9349e08c6e7fa16f473355fe98f742dfabb6",
                DateA = new DateTime(2008, 8, 19),
                DateD = new DateTime(2019, 6, 17),
                Sort = 146790098,
                Note = "dad674f67c1b48adb14477869b9e90b38c2738bfba8441c192ecdd81303f042f88bd69b185384a53a6babd1ce80adecaa9b8e7be8af347a3ba602a8392ed650e8f1d07259efe44c883912a0af9a262c950f7e65b35c14bb59e97c34bc8d81351d577f21534aa4ae9a5054f3abc372662dcb6be76a9424cc187262b02dbf574614b41383ff51e4538ab56f414a5d28c3953c9d39a32504703974348a31dd845ca48a659169d6848c9ba6b7ed8e31dd0eb9bcf1027e1af4ca3ae88bd7ea260e6fcde03589b17a24455b4b44025f5bb5cd473c0be5a3f5849f5b33b042d876808664018281bb540440983acaf75840e036631be12eea1074afba290",
                Status = "9abd5d9c6aa34e15afb3d11d5481fea4a1143dcfb04e4d5ab0"
            };

            // Act
            var serviceResult = await _resumeWorkssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("7bb790fc-f7f1-4ed4-8e50-85b3eab8e25b"));
            result.Name.ShouldBe("3b701689b5b846c3ba9b0ad85cd1390bc24eeb1152594360bc9b1aadc551e40d54b73c12a5ac481ba663768dcd6d4fe9f4b8d454543a4a5c8264e60bf9723795ebb7b1e266834638a19adc55a361fe57b171fc4774744c759311abe53f6661ac7a22d432");
            result.Link.ShouldBe("12c3ad46cca04b989dca2ec0bbf3606d347e2f3bb9fb4790a57601a01036255182892f432dca41ecae7e5edae6c63b74c8c4cb5da8e24944a9e79d282100babc850da438b51b42d9897e9cfa1ce05157fda518ddc845400691373c666d1c2cacfeb8181c3419447d8f1dd78f5156cc415829ca9fa25e4c8c912879d0eed560c745cbed078a814a4da7bb7101c12642aa6058f1def18b4ed19db57b5c63a5d2e0be52e2d2d3d84dd68531ab221b217cd65a709b31e96a40d48dce241d2f8e100c98c776ccd08e4eee8bb66b926ef5fd51245139cf0e7d4482834ff90b9e78c2f57e2987428901472e985990f2cde399646ee649463a594561adb0");
            result.ExtendedInformation.ShouldBe("949654cc93df411f8fa588f28adb11f1623ad7ba45704a7cb4af1a7ef31f344f8459bc5028cb460fb730b343f8da1eb1e4ba48c8a8de4f8fbd65c5798ebda591e13ac086e5244f4da7afaac6844b009334e2d53028cf4e0584c994e504d916c1ce222e9a9ae54ca7878da0305e5ee8d6dd922411753b44ff8c988ef16bfdaf7746063d9a3b794c8987dfc2d3821e49c1ca647940d3a04faeab0a445adf93689f0a43a2a04b8247ed978c7a342541713aef460e94cf5947d9ba616c138d4e668a0f3ca1b7041443c08a345fae2f5413bc745c43d7edd2449abc130af7d46ef475dfba2a197f2348cb9349e08c6e7fa16f473355fe98f742dfabb6");
            result.DateA.ShouldBe(new DateTime(2008, 8, 19));
            result.DateD.ShouldBe(new DateTime(2019, 6, 17));
            result.Sort.ShouldBe(146790098);
            result.Note.ShouldBe("dad674f67c1b48adb14477869b9e90b38c2738bfba8441c192ecdd81303f042f88bd69b185384a53a6babd1ce80adecaa9b8e7be8af347a3ba602a8392ed650e8f1d07259efe44c883912a0af9a262c950f7e65b35c14bb59e97c34bc8d81351d577f21534aa4ae9a5054f3abc372662dcb6be76a9424cc187262b02dbf574614b41383ff51e4538ab56f414a5d28c3953c9d39a32504703974348a31dd845ca48a659169d6848c9ba6b7ed8e31dd0eb9bcf1027e1af4ca3ae88bd7ea260e6fcde03589b17a24455b4b44025f5bb5cd473c0be5a3f5849f5b33b042d876808664018281bb540440983acaf75840e036631be12eea1074afba290");
            result.Status.ShouldBe("9abd5d9c6aa34e15afb3d11d5481fea4a1143dcfb04e4d5ab0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeWorksUpdateDto()
            {
                ResumeMainId = Guid.Parse("bb42c9d4-d786-493f-a160-2ccc628c5aa2"),
                Name = "d0544a4c344d43d392f7ba15d251908359a97f57cf3d48e4ac040b2db8b01e6309c7f019911f4485af08fffe6e16eaa2634fefb1d22d43c3b067ee1f27e626ef9a8005133699420088a4b01adf6ea5ac8445c26e77844cbfb4506d17ac065b5904dbd3a6",
                Link = "3ada8016e5764c2291ee02ecfcf2b115e0872c2f743244eda4a3882517080c2a58268985b3a94afea58fbe05d7ed991bd5febb22be9e4818aa4d3a5411a4442fecc6325bea7744b4873aaf72f065035e4a3f1ba96ecc4f8598765635a1b43a337455701a67ac436cbe325e233e223d7700458ffc4f024b2c921738c72d2eaa917546139fb6714f10a982549b654d0ae437161bf4b5584a53a5ea0d155aa4899fc37d8a1af3e444bdba12077ef001f47ac9c4adc8adc74429b195e388f0bd8a582e827481751746d3be5cc86bf04713f973414d1623f64d8891bfc90b58f5271059afe39980364e328b62c8e121be1b1e68685e82f01246c09c9d",
                ExtendedInformation = "3c6a5ae02e0341b9aba65e90708dc739d025a60c52a34dcb86949989bf4f1865e81e30b033aa45a18f3463e9f6bd1969e80876de7bc34b03bdf0f3e68e49d4f96df1f8513af342bd8ed3a6f835116d2e1d4bab53731348b497f0454371b5426f6eefa10a2767456abdd923f7bd762020791856b4b9044825aeb42b8d75bb5e44f714a8c31fda4d8bb4f8325f56daa7d0d5dbb8175ea0418b8764f86ebece84a1d0a43974db0a4041a2d9e887ababe65f51df135d98ad40e6825a077af28ebb502d07d17f31a6461681e23234a8254a209fb99b8de7a440fbb0505aef4eddfec30ff4a40b0c454e52afd1408e342919f847e3580d4ee742d1b683",
                DateA = new DateTime(2013, 3, 14),
                DateD = new DateTime(2022, 8, 19),
                Sort = 1396583747,
                Note = "009d272a9a3c414b9c9e2934b5692a01f81217dd7d644226b52e3c1b2856e1f013c7e0c6ced748fea32198e721442861c5ba0713c025453fb6d2e7de9ab502f08fd89c4f48284ed89837decebc6a94ffbc7b602d8b984c8986753388ccbe4afede9aa5a7927f4b7fae71a6d72935c9585fd9dd5de4bb47b48216b278762bd088cc4a4ec865414308b4034029b9204b4bf792e2ae09d9404fa76c5f8cfc83226a6d4f91270cc44f2b804b7086656f14ce38dd9a918849419692f27ca6c3905ce08e735dd4c5a44094af40d77874b2554cbb3f7aa6460a46febb1a2f56ac5ee9112e963c0539494656a958ec5c4deef3b7eeb81098621c4a339697",
                Status = "9d1c8ea28d64497f92bd2629b4f168845facdc641fa2451894"
            };

            // Act
            var serviceResult = await _resumeWorkssAppService.UpdateAsync(Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"), input);

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("bb42c9d4-d786-493f-a160-2ccc628c5aa2"));
            result.Name.ShouldBe("d0544a4c344d43d392f7ba15d251908359a97f57cf3d48e4ac040b2db8b01e6309c7f019911f4485af08fffe6e16eaa2634fefb1d22d43c3b067ee1f27e626ef9a8005133699420088a4b01adf6ea5ac8445c26e77844cbfb4506d17ac065b5904dbd3a6");
            result.Link.ShouldBe("3ada8016e5764c2291ee02ecfcf2b115e0872c2f743244eda4a3882517080c2a58268985b3a94afea58fbe05d7ed991bd5febb22be9e4818aa4d3a5411a4442fecc6325bea7744b4873aaf72f065035e4a3f1ba96ecc4f8598765635a1b43a337455701a67ac436cbe325e233e223d7700458ffc4f024b2c921738c72d2eaa917546139fb6714f10a982549b654d0ae437161bf4b5584a53a5ea0d155aa4899fc37d8a1af3e444bdba12077ef001f47ac9c4adc8adc74429b195e388f0bd8a582e827481751746d3be5cc86bf04713f973414d1623f64d8891bfc90b58f5271059afe39980364e328b62c8e121be1b1e68685e82f01246c09c9d");
            result.ExtendedInformation.ShouldBe("3c6a5ae02e0341b9aba65e90708dc739d025a60c52a34dcb86949989bf4f1865e81e30b033aa45a18f3463e9f6bd1969e80876de7bc34b03bdf0f3e68e49d4f96df1f8513af342bd8ed3a6f835116d2e1d4bab53731348b497f0454371b5426f6eefa10a2767456abdd923f7bd762020791856b4b9044825aeb42b8d75bb5e44f714a8c31fda4d8bb4f8325f56daa7d0d5dbb8175ea0418b8764f86ebece84a1d0a43974db0a4041a2d9e887ababe65f51df135d98ad40e6825a077af28ebb502d07d17f31a6461681e23234a8254a209fb99b8de7a440fbb0505aef4eddfec30ff4a40b0c454e52afd1408e342919f847e3580d4ee742d1b683");
            result.DateA.ShouldBe(new DateTime(2013, 3, 14));
            result.DateD.ShouldBe(new DateTime(2022, 8, 19));
            result.Sort.ShouldBe(1396583747);
            result.Note.ShouldBe("009d272a9a3c414b9c9e2934b5692a01f81217dd7d644226b52e3c1b2856e1f013c7e0c6ced748fea32198e721442861c5ba0713c025453fb6d2e7de9ab502f08fd89c4f48284ed89837decebc6a94ffbc7b602d8b984c8986753388ccbe4afede9aa5a7927f4b7fae71a6d72935c9585fd9dd5de4bb47b48216b278762bd088cc4a4ec865414308b4034029b9204b4bf792e2ae09d9404fa76c5f8cfc83226a6d4f91270cc44f2b804b7086656f14ce38dd9a918849419692f27ca6c3905ce08e735dd4c5a44094af40d77874b2554cbb3f7aa6460a46febb1a2f56ac5ee9112e963c0539494656a958ec5c4deef3b7eeb81098621c4a339697");
            result.Status.ShouldBe("9d1c8ea28d64497f92bd2629b4f168845facdc641fa2451894");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeWorkssAppService.DeleteAsync(Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"));

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"));

            result.ShouldBeNull();
        }
    }
}