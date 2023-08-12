using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeWorkss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeWorkss
{
    public class ResumeWorksRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeWorksRepository _resumeWorksRepository;

        public ResumeWorksRepositoryTests()
        {
            _resumeWorksRepository = GetRequiredService<IResumeWorksRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeWorksRepository.GetListAsync(
                    resumeMainId: Guid.Parse("d8abeb81-b1ad-4e08-8354-82818e7be96c"),
                    name: "83546f78d6df4a0b86dfcfe0b5175395228a3486052146dc90dac9e56be276608a624df351a84c1eb85560ef18b13717b0bd46a2c56041878cd6adaf799461eec2dade77f0e84153994156e19a33b6e2a345d3088c8f4e80989e4543c7357f9be1f3ecba",
                    link: "477157e73ac7452bbd0976e8538557b72fecf82a1d0a490f9f99beea810d5a37c12cd0f5f96846d39f3a83f1d6dfbb51a8d79af9eb9d491f80041264c2b5dac1877292280a104745989488b4fc04578c3c8376e8bc004866844e6a0346d20bad3051da826a144819aa230e29cae77479e637dddb2cca4dfd94558878ce92ea87aff0e8673410422ba85e0b61b9a763273943d950e1be49099c6e53a6afea2c286b26bd1c46634418bc2aa91c7cd56a1fab06db5c754d48bda421f7696521c62788e4f29158b1423197e566ca1847a3edd70ff6bf5e084e10a5e5a2f7daedd3d05680e5ef8bf848eaaa66127211cf40ed5367f3dbd8a94e789a3e",
                    extendedInformation: "beb809b8ac8342c08a3e8bce1846b772119a128f47e9411dacd5695c9634aa5a83dc6cc83b7c4baa8d729f7306fb82f03ffbd2aa280f4d07a9ffca9e4ccdaccc167dd003bbbf4e04b1cceffa686190121dbdb818f0fb462f85be3551149583fdd98d5a716537439da3cde0a534404eaaf2ad88f0d9d74ff2a0ac71fe0ccf2c38abaad2c6ae14484dbc94779fc0fa46c6f2e1a5704977437c95a6e6a026c63dfdc59b4b8828d540febded9a0e576502fffac1a60f53ee4349bccd4e7edb19c2d34b181ee46f66401594dfa4c43eeb5f938d735b8cc97a42fdae5cb408c6edb754fec5fdad61624974a02af6c79d86e8d81227cb1dfefc46409e8c",
                    note: "6dc874ba0ad647baac43d273ad5ff1ed3100372d4f81460e85d5664d164d0937cc1b1b2318a94f788642174a54e52267f0a2a42a208743e1a696c165ca3d720ead9fe5a818244eda8cbd669fafd0c0120b230e0e0c9a442d8f525ed992090d774b11fe709df44ef6a8f56679a0f852fc3ae8a6d11be3485f95f542291924346bf5622d6a15f5465190ec3fa99111615f05eb422c0b0c4ca4812b413cd920743a2be48baeeb4149dfb2c1876ea6930a9b60901d91a64b41d8b6cac786aae0a74ed2c78e138ebb4d7885a3854d1c88f9f012488a537bfa4b9f8bc6f5bbdd564847719974e322b64dbc91762cec0f2d4a05d9c23cdec6e54b50bedd",
                    status: "33a34a461e12447eae4f9905e1f2fb8d00627c33720c4e8caa"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeWorksRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("5e160f73-cd4a-4399-a262-f8dd66741ce5"),
                    name: "b53c02be1a634d94a30dfbdecd42ca043bac8d52f70c49b9b1657fb79c13b0031302fc7d72fa4735b270f0485fe471672535c755d0da4a8d8f1b593e703b40f085d3bab003ba4b8f95fb0203c72283b0bad5e43e2d3d4de7a5e47c9317b2cd134f05ed5b",
                    link: "1d0c44cb54da4d2d9fdea8fd58178994378376ffc64e4983a851f847a98af9aac234b6d5480640adb227a7c6b61d956c2c11fca6070148c38881c21a31abfc3a94f457135f0742ddab1e1fa522203f2327ee16b338b54282be4b1388c5b51896c7a6c006f51e4ce0b151b48de24d2549dc1357ee215d48acb9f238e3d62196646c58dadb53ab401ca86b18b645824580e6223b6742df4e80b9d2e5fb7d47dbfbe38bb6a88e4f4285ba3cecd8a03fceff1d4f9b6283ab4128bddc8d1d80c761e0bab39e3ede694e6b9ecc22ac6997998c4322f455913b45c39e65fd36f3dd5c3d102bdee82e754cea9011bcef366d9cf4b808a0b2148b46b7bf34",
                    extendedInformation: "38732982acce4da78801ac8281d077b60ac277d243a04f198917aeee7f22fc12b019341025fd4923ac3b343227a1fb9040e7aed83ecc49b08b9cdba7f637fbf2f28269bd3966435aaf912828dff79ccf63bc0fb773234d28be8e4af85555224d980d95112b0843888ddf9c3769b35ed4ccc14fe7f6524036b2f1ec89627045c2eea8e92299ea4e88af6feef84b780a30ca7e581df77c41eebecf0f2954d6351b5261dd12a352469fa8678249dc7996dc87472a7c4b8649c4b3c0d89719037aa097bb290d14c245559022e2b289c7d6a0c13e01e9710c4a749bdea2e21d7bfe1d37bd0d928db9408fbc0d4e58dc35cb0ff67174664dfb4305a1a6",
                    note: "afc6adac37964818b65902aa8b67c5299e7f9028dec14c4086f80bfa9547b205eba08f34159642b0bcdb0e0116c1dd62e555538ae5b840a48da15408e5199ff0cf7f6fa52c824145b0907d22ecf6ce801eb03ccd41d44c4aa7c74bd41306b0bbc7727c99608447538c1ea3780269601229b7a279e10949aa9e2e9cc2287e3a30ba2f14e6597b48e790cfcc8a3aeed21148476f8e093e44baae90b0163926ee54234f30249f8a40a6b4036cf75e515d25fd066026f2bc47d8a943b9fe846e0e2a44270d3f2f6844589a76cda59cce8fa5cf5b77686f3343ca8140c63ccf89662b355b52d0ddc4493d863297981d5b3eb26948d50524c74d5db164",
                    status: "c62f32723b4f44c7b228c46b060d7965e78f53e6a6ae429f82"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}