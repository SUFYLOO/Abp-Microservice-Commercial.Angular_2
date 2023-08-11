using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareSendQueues;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueueRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareSendQueueRepository _shareSendQueueRepository;

        public ShareSendQueueRepositoryTests()
        {
            _shareSendQueueRepository = GetRequiredService<IShareSendQueueRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareSendQueueRepository.GetListAsync(
                    key1: "5b334351c08f457b9c88eb812d19c6df7890937a6565498bb8",
                    key2: "d4535332baad44799c65a35c56d11d9b36616c6cb43d459a99",
                    key3: "8624502e9aae4e5397c8dc78dafb9a759200b433081f464498",
                    sendTypeCode: "d5475abaeae1402d8eb87a7805c2f12544c876a24d6e4a8887",
                    fromAddr: "e3054e7786144e8d93ea704ab4c8b92f78224165b61547fcb2b9c2a219aa9b9d718c53d86a5246ff8be27f24c5a411bc17478545706e444a83ea23f9c6fa6af75375fe481e2e49b491351afeade4d51665455a3375e94e5b80b84b5dfa741bd7adc7a38a",
                    toAddr: "53a29359f49b4ce78c3f1ce13fe2217a29d51c2886344bc88299697018fac82d769f826096c74df684507f7074fab20f6bf05da4b16a421ea8937b2d5d657054af4487af1c504ae3b19d5a05a93dbe816ba18e15336349f4b77dfd6016b563751360e0bcc5f84805be9ed398f18cb7bb2de4f40891c14afabf3a33d1f532042c0183d3d04f9a49618111fd3d05e45037b33a784c7d884b5ea17437e744c052a440fb2771867b46a8891dacd33cbe2c0b1ef70e0861664693a4f0555e6bb97a813bf1be8ac5f74e93bc22193af2fc1fb7e383ca798a5547eb8f3673d8b086da662b2dec7d192643259e4fe495f1b748d4b9630bc1cec34841873f",
                    titleContents: "bc712406d6fc433c941b47eb5b22f682f3b04f6eb3f14c2287226bf71549d65a4206680289424d34b7cee7da509dee31426d6691dc094340b5a9d2d867c731dfa0ff8cef28ce492aa80792efc0e21bf54e4878f3158c4d35b34d5cc4f5ec21d62f4ddcb214cf40a08df4b76f219546c99755e9f633da46d9b101ce6b023bea7018a0b9d4504b45c4a0d5c1913cc692983934ba5e89b9454fbc4b434a160c6d620c325ae3be574e7bbfa811cf3d0db45f060d78eaccde46b884631b40aa0abac97cf492cb68b94d1ea88fdb82dfd0752594c110b3ce454cd498f8e428c21fcc532059cb4ff16e48e0aa54be8b0799d4c885f219142e654dbfa604",
                    contents: "41afc25325e74bacbaee176145a573e733c53d",
                    sucess: true,
                    suspend: true,
                    extendedInformation: "bb9e70f486cd40a69be64467ea378650504b3c0294f7497f8d1aa7c646785edeaa352f7a48904416941097e09bc14dab75071c4d238741a18e7e5fe0add7e77585996a243886440e97bd41ae132ceed112c7e1861ae340c3bc46a20e93bca89ef4ad4a93791547a98724bdc17302bde12f4c9d6fcc1b47e79167102c81f7bed35c7637364f2d4702984883b4b8176e586b1692f9ed964553bc7c0d1f260917e0f15a0d551c08407aa9385c3524ea52b40615d79ebedb418da1c4f8b797fd7b88052f502d32c6414ea0d872595fdca1b108e105d8f2894289922bcadb2af2a50ebfe62eb790864e3f91855d7733601359bcaf1b1663634fb9abba",
                    note: "b9ef18753d4a4276b92290ec0e5716e057d4cdbe19de4420b948ab55dfad3766ec0125db9d6c44eeab5cc11241e8edb17be4c0f36e8d43cbb4a6d9723e63171171aab7b27d7142b7abc22bccd68950df98debffa0c88485aa665bf9e9143932755ab7442c0354dedb5e7a05517710db21c1db9482f9949e3a476fc1421753adceb3e75cee5974643ba7215deba38523c6054c92fd07f4a1b82f55989f93820c58e7b4b16b95e41709b5bc3cae5982b27f0d0a65e04e2472b8f49e0da6be0806e1eddaaa4da1b4d52bb3ceb53e15ca5883e77c5d7f9ba47aaa975fabd4b2f4da51daf9bb2ca02473483fd51c2f4f9d0cd441a97b901f24244a908",
                    status: "d022c06d81a74910b8fbaa8a830cf0992794d77e138a488ba9"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareSendQueueRepository.GetCountAsync(
                    key1: "21146c3971a540e995d642efdb41a5fbf174484d63144e0190",
                    key2: "313b6318344d447d97bddfdde45d6567b8f6c1db2b2c4e47b9",
                    key3: "96fc47267995417aa6735d34081e04b16b7f4f1a70a54cb6bb",
                    sendTypeCode: "a1fd9f2867a54658857982ca9c6c3cea32999f866e8c43128d",
                    fromAddr: "879a101b61ad4c02b36398fcdb4a0f4f911d8e1baf6244b382b05939126745c8a8fe3eeb94ae472192936ca94ead9de23972cdae276e4b3abc00bcb093333a80e9705149588d422785927dbf2479a16eeb1523601353475aba6de2dd099a0319e66a2723",
                    toAddr: "c766596de5db434faa5fb13d157fb06061547c56952741c2b933035147562f1e1b38be22faf74c249b98d6e768f323f3d4b36763c29644689eec4f3c76fe344bfb813b95596d4e9e8cad6585b9319d230efc7ddef4f046759a6e15bf7518d69f19f7b782cd244fa49641e4b758033efaa4c2033c4d3e45f3bc498f4cd2236cd442a1c7fc96564eb099e845dd57aaab84d5dd234839f14eec8b4dfa8e6de2000d365a4bdccb0642eba41d4eaa6a62854c484d072f37724c78ba4c8c5c91aea402c1b12898544649f6b521f7cd65220f5e6902d722a17840f085efa1dca1ba5c73ded745dd679d4918af47088be345f56aa6ea3e3a881b45a79265",
                    titleContents: "41896f62c88f41a29cb71099b63febb4da35c74feb184bd4aaa3ac16d3ba52b0ad0202ccb71d4625a2a440048df65ef3ff65c94da1054e4dafe39e8b1793d6daeb342eb3561145e0ab8a42802674e17085cfe18c19b14ef5b6ee4727b921f3074e8d0b9f8a4e424ca1ae260cb4cf000e36119fd75dc44c23a43771bcada900bfcd66ac80436d4dcabba5b4e67229ca5818ef13d3ec6e450f924e2eb11c4fd5a65b8175f5f4ec4103a8725162bfe3773c2d22c72a813d46a18c06e438043d6d1aec3ed56be30b40ab97d1074aa3e495549794f305fb1f429e957e63ae70c9f9f7d3add692b71942c08c90402b652aedb38127ffebe69243faae18",
                    contents: "dd5b3ef9d7084efdaef6953a3b5efc16e8f52e9f",
                    sucess: true,
                    suspend: true,
                    extendedInformation: "b8bef5f92b2449008c5a8782e934a020ed8d0fdff3674b03ab865a187f109fd80198d227065842dfa4d893a083b9a4dae201f6f97e584555813508e45cdd11bd231362943e18437298fa6eb312a078e1565545e6a59c4a3580981323f84607a4274303d3dcb54173bed3ade68c90d9ff0432f3d69e1345c08d18e2d6ed442a211a09e79adec844ff8eac9827ea21ba6edd701128651649949e9e4e77f0ff5de25f0e55a89ff245f6932cf22b793527053ea057b7cc424b3daeef9a42c030a64aeebfd109072b40fb8c6a11af22aa317bb65393023d404bfeaaba4569c9981431ffa783453da34eacb99f8b401f5fbbbffd5ba4a0cd8142be870e",
                    note: "f9182723f58549e08696012ab5cbe33df4722891b08b4d7bbd60e9cdc5aef892de8c6c623d19405c81311ecaa2bfabf24decb7cc42ee4bc5acb8d6ff967e21218bced9fa03a14110a1ee91c7a81d4f94d1e19ef36a114ba28aa8dbec88698aa73cbf2b3dc8364c92a9d4f355ffd1e197286d2334f41e463aa25a986e2cab823b021ec6df0a494e32a5c9949fe8b1320b92104b7a069a4206ba6d72d154005afa904de8d2b42e48ad8fd8d30087c8529a6088801a83414e93bb32e5f5ad9c3ce44f28f87a55754d94a9f1c3766f62b7d650b86df722184beb90494de18c14ed008d2abdc35383406eb8d02538e58942d844adcfcb61ee43e18ebf",
                    status: "aad04d61ddcc4bad9d7e5fbb69f1d16eb122013effba4725b8"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}