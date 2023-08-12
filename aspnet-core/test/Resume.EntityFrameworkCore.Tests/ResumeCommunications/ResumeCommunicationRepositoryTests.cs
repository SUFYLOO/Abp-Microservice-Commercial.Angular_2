using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeCommunications;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeCommunicationRepository _resumeCommunicationRepository;

        public ResumeCommunicationRepositoryTests()
        {
            _resumeCommunicationRepository = GetRequiredService<IResumeCommunicationRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeCommunicationRepository.GetListAsync(
                    resumeMainId: Guid.Parse("ab076429-d0fa-47c7-b8fb-43ef3d315f4b"),
                    communicationCategoryCode: "1287532dbf7e4f398dd8699a1821b21c4ba13c46103b472b95",
                    communicationValue: "785d85267b104ddf976d1e409e918ad2a4ea95437c4a45209727d98f485e9f3b9c854d90927644a3a1df8f33fa050b7bb4ecdfe44b1d40658c889e2e4911fbec9509dca386404450ae7f6413b99ffc38bb98f54f63224534a97532638ed156d140d788e8",
                    main: true,
                    extendedInformation: "20770eaf649f4f2b96fd073fafdc3e96b19e3336f414418d9c09e444358062d178c689b317f1486aa80ec9327489c9e7bcb22cff51c74cd796c9ddb61680f6bb38fdecbe38eb411a9786ac9b49ee5875fcd1951b6a0a400fbd08482fc175b538031b034aae394826b5b7d79387c95cd308a336e746044b25971da55b30e9bb4989946ca2e17e4c7da1f02d46c4f5c4569e039327d6174cb99ed6cb7745a4cd23b7561b24856a43418a31ea72cce6facaa9a57dc367c747a5b14f3cbf01effc98f4c7f02364044eee96e86f9142e4a814ec938d84373245f58bc893fbea0f7c92710174a6103a48a0afe1fd376c743ac075db3d733fef44259da5",
                    note: "6db54ea735e7412e94506e7227f449a1c6ac32fe748d4cbeabc4846a42fa7750e5de0ae6033746e8b6a530322e85193a5ea8c630c6da4b6ea7ab508ff6855b0fbe5443fc630e4da2ba9a006d02ea3b9df337546e217c4a1c8f31dc734a724911334981d174b84ad78940dc151cfb76d2b963e528a4e141d4bcf53a61b191306b456febc3ae7d4e1dbdfaaee3ace2f61b814de01e8de8487795cb9825980988922758a72015f64a888469aed03d8ba25cafd0d5b1893f49e2ac2620b9fe3ed480816c8422bfbe4cb5b736fb7c2d6d22ebb505e03f7bf542c08d00d48d3a29be3ef36d161912a443158c4b57d4be711f3d0304673273234c8aa1d5",
                    status: "6f3b288eae95493fb8a1677ba257f86d70c2be58b6d047e888"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeCommunicationRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("7a50949b-5a24-4c65-ad1c-a19edeefa704"),
                    communicationCategoryCode: "575c878225b5435aa55cb7897bd3a3ee47ad43fadf6d49048b",
                    communicationValue: "c2c36c8fa2bf4bd28f5706dac4c6e8a5e7b154a9c5bc45a485be0c7de9ef79f08ce4dfb736f24cb39b0be111fdc1e06c20d727b764204e4a9003b384cfc68c5331fc12fcf4fe49f8b20ea693ef9266835b06fe38b4574f019a9f7cd608e4c73a4368ff88",
                    main: true,
                    extendedInformation: "e6a0650251144e24a72e87572137e1d415a332552e81422bbd902c6ff43ee48236c0163e73794725b4c76de1a3714d37c12e98ab69d243d9aae2a493b6b3af0ca682d531f644424d9218093278dbabeed569330ccb884799b64814e6de18ab0f90925618cd7442929194d91064fcc90a1afcdcc743ca4836abbfae20125e968d3e982cb1b8024636aea70323938cb0dee302768aeed94b30b978554bb805c42d945e9db46b2346758ab1c172269db9884c0a4500a0b348cfbcd8db5dc7a4a405c1fd83835f9f4398a5dacf1ecf081c6680af59e45a6b42dd83a93acf990e6f154973eea4a3ba42f8ba9d030a494701d9c6e5302c74db40118803",
                    note: "3946d6c8f4a340c1a28e973951406ce99007e20310d54f4ba2d41aa701326b0c53f57958ed494d388e88b40e02997bfb33b45305e0f94a57af09e46e1f4c65448030391ca891460f9a2f3fbea7f44597ccda6173ef4246018fe330085b1c9a4450c7cbd3ba57415f88a37e343c4c05b2e0e7fa6d7ac84d38bc1fc884bc6ffad03b52a8ba18e64f7690701b286050d557de3d3b972fc24776999a48bfd176b5e292fb4f821c0d4085b67b51ffe623b4bf84e5ab12f58a4d5da964c7bb2fc7280ec19547eeeb2345fc91f7920131ea1947bea56420298a4068b71d5f36e6b88518273fb268a0364793a6cd93ad1ff3435144d8707f7133493ba9d9",
                    status: "866c5af6d131490ca70cc8afed18a6f7ac20fe8dc1be42ca8d"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}