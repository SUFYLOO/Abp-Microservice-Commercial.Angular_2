using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserTokens;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserTokens
{
    public class UserTokenRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserTokenRepository _userTokenRepository;

        public UserTokenRepositoryTests()
        {
            _userTokenRepository = GetRequiredService<IUserTokenRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userTokenRepository.GetListAsync(
                    userMainId: Guid.Parse("fc395fb3-3a72-4692-9f81-12a1e1602503"),
                    tokenOld: "ce0f55614fb84",
                    tokenNew: "c6cdf56ad8f94febad1379bbc2a7fa3cd3bf889d188f4f20a04cc92e4eac524dd3",
                    extendedInformation: "b021256349c34fb2aa86d5d583cd69c4618650872d3b444bb6ee30693cc4c88a6f02554bc4624213b5f9845fffdd04a55b14c7655e33425d8a557256e06bdf1d842c71f25cfd4c48989e5d593d27b6106d96ee26157d4c0087a59c9f519736384a7e3b9d2aba40f880fda7c1fec6697380282649f0f34476ac3e39fe62b84edc57784f462ecd429b9e7be686e327faa7b8ecd2f3bba545eeb4f8f9eee99c2b92de914c9186b84f9689ed37b59ec5ecfb104bcebd9b3342d091d9a91074f096a3f5d01b8700664b499165633b9e787895a65cf5695cae420b8780697cc2d76028919cf38179a047a1828b2efd385cf685501a211e3cfa4a1dad1e",
                    note: "67169612abc64be39bf37402a96f6eaf0fd124397fd84d449c2303cfebf657e4b606b1052f8a449f9cedd04fad8cf3b0743129dec3cb45038d876a042844d3621f6a2cb023f744739d89dcebf148ee72224860183e1c4fb5b7722a4f6a05ecf92322fdfa1cee43178be66277ea2c99f8567f3295fcda4430b1ac571a871c764f4e1b1d35dd664dd98507172c90c282215a2f4e14491c453980198bc70471b3244f16708f9001450b9353f6b3d1ea0989a785055bdb584e009acb27936829ce80d7567e1eaef24b919c1176cfa9c5aa12e751df30c49a4a6abff8dc4af893a80bb41f132a43f04b5893769c83ea06ffdf745f9254faac491aaada",
                    status: "3004a4ba550d4dddbaa727a14b7a80472f7069606112467c97"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userTokenRepository.GetCountAsync(
                    userMainId: Guid.Parse("880209d0-c92f-462b-9544-4d65178d8a76"),
                    tokenOld: "93792f4b44cf430294b1969618dd342aefd10905a174414292c63c6",
                    tokenNew: "3a85cc304e684052a2aa16b68a86b8bc3c51d2f396254fac83b42e8f400a022051033ed",
                    extendedInformation: "d65b08f33c5c4c128ef5491117d24855e61e49b866804557b0644816f8190186943731b45e8145d3a1c5e0854e2211b5bf7b38bb66c245089442dbc1a84544e04f0d35eef1b24b17a8694e2e42f916003a516cc75f674e3fb00b06513070c22f71c33287620d48e095a8538bff8824920da72093061640e89b49f5fe1469b34e6fda6fba11494f139145b468b613089cd3536c09bf1a494790b8577443e608e775506eaeb96e4050b48f5d02409a7a84aa7dd66468c140e4adbf74a11fa6f77fd142108ae8b84fe69900f2ecfd0a724bdfb2c5a7c93e4f73b689f7243f958c610d265962f3d74294b9e43da02600815101ee86e92ade43e49008",
                    note: "3fec1e7c31d04fd488970b89ce3b8927f45239e868cb471785a75825e003feecd74fe8eea50741e298433aa60d5818ca30a0d47968e844ffb713f072f0292535e2c38f82ef3d4a5ea718ce8f38395b6ed8c16c427bf640158b6b17a904d7f1fba3431013c6a24e419c40853ee4f43020950b8ecdca5e49f09b613980e5847e30c832f1ee2e854887968a537d29813d3b48a06ea78a7a4b62934c8ef2a005b09f484d628746284d05855395ae3c0a804d4960f29a7ab34cf2b7ca40b984b1cbf4e17bda6550c844f2994c54827b23d4e8afc6b6a67e5147b3a9be2cbba1855b36559f99ee7da64353857a28a65a714d452f13891704314d509687",
                    status: "c1ee1e6f650c4866a8f6ecd8af743d57c401ffe3f2f541ebb1"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}