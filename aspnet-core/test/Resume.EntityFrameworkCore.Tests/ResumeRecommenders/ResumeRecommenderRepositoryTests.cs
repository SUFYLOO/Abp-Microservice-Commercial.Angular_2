using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeRecommenders;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommenderRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeRecommenderRepository _resumeRecommenderRepository;

        public ResumeRecommenderRepositoryTests()
        {
            _resumeRecommenderRepository = GetRequiredService<IResumeRecommenderRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeRecommenderRepository.GetListAsync(
                    resumeMainId: Guid.Parse("969b94e4-ce52-4dc7-a10d-d692a218fb2f"),
                    name: "f2a9afbdf10341e8abe4d9b94ff12eed0cc558e7552644bcbf",
                    companyName: "5d5ead1123104e3d8245e9cbe4dbc6fdedca6bb01af14aff8a",
                    jobName: "a801b35d71804c1c978f38b48595566e2d24f24c0fb6451e8e",
                    mobilePhone: "ecf675a291ae44cfa75848dc2fa5e04387191fb83945471fae",
                    officePhone: "3173a9b8a3e1452d8d3a3759ead41fbd8a02f94c3cfb49c895",
                    email: "95d33e572aa04c518a15524f0ebe5d5ea0bd018fdbe14ed4887edb84fc1a1b13b888f1b8f79047258530bd5d4b193082b6a2b0be11ac4086ba24a73e104147d0500118a3559f482b90a75d59b24c2d96294339aadea645c79af38722e1a5002eb0e9dfb6",
                    extendedInformation: "f08600e7d7f94d7886862971417f16056d45f4d8b7b5488f95f58d617669ee4cd90d31c246ab4946a8199a0b4824d5f4b05979df64fb4108be566999e738467c3dfc3573f2174af8bbaab2bb72c170f22758c19f978449c78253d31a7800eba851a22bab02ca4cf1b240add1e2d4e28ef972e4366a704176b0e2efbf0be67eabcfed9a04f9d345bfb38b780de245d77a9085d8fa09ca4c69b910f667c2438e1f47569bdd75644908b74fd35127f57aa2501c1a0418ec420e954bee572cd9dd41f937152577a64b34bf6593691e9b91164e28b73252f44a9d9b2e6ff9e7e16d2ed60eadbca0ee435ca5951e5c977abfe1a7c0499b61db4c448574",
                    note: "8cee93f8a0274d6fb89521e23d815728dbecf9de23b5487b86a8bd0cc27665ef3a38544c6ec64732afa1c6a720cb5b561b5bb722adf7498a87eafc8d7401151eef208b5079eb47e6a0f7cab5b291ba914e7c70b3ade34b538fa773387faaf9a5756eadf5ee9e40c4bcbbf1ba70701f56434ea8a9c8f74dd58829b00ad92825066cc71279c0ce4850a5ce0aaea8e9d6426e2a9d5021f34099a488e09ffa36212e952bdf8bdea545398ec0f1c562c60e148a949733bfa34c669cd1fd996456a8e0440f66f052214cfaafba5ef7ca4e34bc7c022a573e154b3db84aba6d00091996fa787fb1115047e9b1bb471192c9c3e570dd89d45fba452d9832",
                    status: "a9e2aa1d474d4c42b1edea2dbcb28902d57d93baa5b945caa0"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("16d6a365-f3bd-4137-84a1-e1faac07ca4c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeRecommenderRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("7e31f6c5-2f7d-459c-9d21-71295c63194d"),
                    name: "8f9f007f75604eceafade0c3e68a84586c7d75ac77d64fa199",
                    companyName: "3652049ae3314c7082d0118626e509f75017b923be0f4624a3",
                    jobName: "a50f4c78222e46468d6fe7fb65ca5871d13546f1f42744fc94",
                    mobilePhone: "ceab2b341fb34b0d92e29e805b5b1181beff6a35a68f45cd8e",
                    officePhone: "32e3a267050640fcb2c705def12457ce2e0755807e7d403787",
                    email: "cdbea9aa71f541759715b8bb44741472eee769333f314eaa87f035597be66d9bc491ae389ea745f7a619ec1d4b7f1a1a4c710b0950ab422981fbef7eb71b484d16fcf2bdea97424eabdff7655d3e23c227ff7363f74c49e991b124dbf304b69a55eb6136",
                    extendedInformation: "661451fa10934e0d8e08689ff36fa1f61648daf723f24eff8ac48f33dd9c0dcaf5bc05c9cc7e4169b6fec399fed248f82da9e3c4856f4d75820f2aef0e66fa187189a03da4b24b08b3760467950b4ed4cb2c81dd50844de89931257a036edb662842e29ab07d4ed2a09b8b6349986901996b659c73374e8c9c731206cd34842fb11eba413fb546bfbea930ce8b93001290a28fe3f9a745f6a3296c4eb6c494d773de98733a4b46bd827d973d183b17cf40a58a545647441d94876b296fdde0f56d9e10f6fdf04e4490834ee9817ab8d5e238f8020bc24440939013c36f645b3c8e3ba66cec69402b9ede7f8d1bca2576e22cda1ff7154b3397ea",
                    note: "c4918e5da0874a98b8274c6c8aae2186782421c815964d0092b17a720b1a9eb80410007c5bac4080b3d7351bd56b69431ac39a0df55f4c41bdaa96ab87c441cc656a2c3e2eea4123b44960dbaabf781a0aff0cac5d8849c3928eeb4e41b427d679529485edcb4f819339dea803dd093c47a7296e95184029a753b18cd3c2edc95e1c146efab04d9aab188a28121ed82bacdd5ac99d654dd78f143cc37eeb26fae0999c2a95e94d27861d9aecca2fe926da0587b22080443593b27c98a2d613efc46811d49c6c49929d144bfc5e92e981791bbd30bd1d441fadaefa8b19ec116d6b9e70857e154d329bcfa17f5c11119ce7a766dcb5934723adbe",
                    status: "054c891a70d54185854661d8bb1acbbbbe82f88f299a478e9b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}