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
                    key1: "a7e1e5c3783042a18970fc45285d9ef3d631fadba8c1469593",
                    key2: "8a74d2a059d94a1d95db6e0d2f0c3461d9700d64d9a0429887",
                    key3: "903830aeb6264e0cbad697f29fce5ef8f18c8dacbd1c40a999",
                    sendTypeCode: "6b3bec236e664bc599fdcda1dab015cb4c5d63b0178941dea6",
                    fromAddr: "63ee64808f634594a373ea7a4bba42111a638e12012b41e9874635be6f4232f698d3bd712d6849c58f0ab39fa082d1049498f13ea5584e009aab4fd5c72458f43833a16b86174f4494ae8562a0475886b243c3c9d8fd4f139ddd6175ff0d1e8901248b67",
                    toAddr: "936fe88099cb4c528e2e5f3e19cb1e695d3542ee9b6d42b09c51b3b5f62642c537a3992a370d463caf7436ff28232fb0ef54062ca47a4db6a762dc406c3a04667a647506f9b94d40beee26fbe52cb0036ac9b9cd654240228d614a2f1a98e98d37c5e474d6b847ecbf241de9f715ace324ffde3f268e48c6961ea0bebb02eb65ca00332ce4ec4acb91f88555cadcddb4af47ee12ad7243888b10473c3bb5f42f003ba4b3c76b44f586a055e50bf5577aea61ad91cff94ac689765548760b107568dd2102900c433a839868ae0a29e5259258ad887e2046f394b00aa0113aad494c98ee4453e64321b05c1fa17368ce7243d87dba7f1c497eab55",
                    titleContents: "c689818fbbf74a75a95b157f26cec5c208a14ef6979c479793611b577f0b9668ec2991445bd143d183d9d276d5c454b00cfba5d78080426695a411fcd7cfb164abe43856070140b8810beabdae76a4bdaccc893aeea447e79433d0df0d0a250f7b968f861be2438d9283f593c8e89032c1a81fe9f1ef46cbbc8149ffd976ff343521b5774146480e9c09cba0a44040eff136279347684c469a5e9335b87ad0815abd81a7ab7943a58d906dfcfe4e0801953e1efbf2d94f83810095c7d232bd1bdb47f352a5ad41898059dfe998d75e18c0f4eca6c0764302ba11e2e73e9cf679e166c51bf79d4f64ae8b29a1c492df594acbb805950745b2acf1",
                    contents: "65ce43fc54644c908fc2ad837e9033ef04f091c094ed432c834f41e3dfe84ab03652b861",
                    sucess: true,
                    suspend: true,
                    extendedInformation: "073418fb39a84da2bb671fe57b1c9e1d0ca49f555a4c4fe682c2fc4356e8823bbefeb63a211544e6910701bf894e8c7661f7d3ae0c424cceb270fe06acde1f7ce01753fc334d4ca1a087d13e621f9bd286e374847d964d02815772f767d1828611ce2396275d430e9c6772b64eab3b33bb9021627f464b949df76a0d3ad7a3b49721a77e6c20481c99a42a8824107228ce0fbfc07cc14652a5b38225858a716dfd6d51cbbfb3424a9c6ed2763902312057d2bf6ad01b4c798bece07965ed6f7a948b674e43f34f87bded3577955f9050925e4c32a0de41e986723f694084b179284eba5f00aa4d07bf50b65e59bb94b57363488553b34b709bc4",
                    note: "90cb5ee78d2c4fc7a655a8ba63c9c65dee42e933d5d04dbe97773865cfbdf87b4d5d1d1400824138a9180a6b561390a431276b696dac414cb85cf51dfcac89feffc1b124641b45b1aede39963fce7cf436dbd23931db4b289337e83500c9589f29077153c2014aad9c94705b927d560560592caa17864e86a09edc3d58e1abfe1f06043c826849a986fa53fb8ab8ce69c0b14a05c4b8453e87982601f708db4c3be66a845e7f49369a422e1f2646c5b1a44f4a1202884ba0951f0702bf9cf4e1ffdcc37b53644d6797e1bb373d784b9283f034f62bb14fbb9b7f45110c2b1fd62f1954108b0140f197bdad4b6bc5034b55831b500ef54364abf0",
                    status: "28c9b471c0bd4c14b35b2619e9d6e001c7ca81f7b683440f98"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"));
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
                    key1: "b9bef294a0eb49caa13e02a914441b573e07cfc4cd1c4968af",
                    key2: "a07ab44e41bd4f319263dc13e539c3ae39456957cf2e4e1783",
                    key3: "ae7765fbee6545eebb5e04ff00ff00675ddd824937884f18b9",
                    sendTypeCode: "700f3a6535ec48c38d146a27a2af6af945177e44c8d942e2a2",
                    fromAddr: "45b883ed5d9440af84520ce21da896282307bc60839a431fbe1418ca9a3fdd75fc886582276d4299a0ca8177c3ff3b59d4f1d7c7e05f470691e77627dfe9c8984570ee235e824858b7d2715b02b63541aa6b0da676e34befa976e68ce2702f0699bd7ad0",
                    toAddr: "6e04b3b4bd604182ae861f4765b53fcb7d62480e8dd141da94da94f085ca0d3b80955d228f2840efbbff7c1b1ae2a785f4a0e28af0984ec99c10d59fe7d1eceb261707fb3a9f47d599d41865e9883a4ed424c33feaa84ec798523a0c07e6bd37feeadc0cb8ea4e07bc476522bb951ea1f284e03ca1f74cc1b87a8498a048091bc9b125ce8be74510ad0c34bb71690a47656b98222e204f94af45eb5b8964a289b566dd140fe0479b9f043fda1e0ccf5b3eadc16d401742df8167ed92583bc835df0fe070f41c48f99804d7e4dba31a0644b7c83e79d64f63a54e395cc9bdd3cad1c7d6db292a40b69108fc1207c52295ca9461741c5c4ffab3fe",
                    titleContents: "fe485ab6b0534d7dad144dbbfda9b8f421f5929e727c454faa4331178ba2d0055c08fad0b3d549ff80586718730d4ce1e6c847fa1c8e4bd2acf6e21e1ec3a33e660ec57ca3c845caa9812e408be1bb7ce473f9ec9179471e937ade84837efd1a961206c4996b47cbad4bf245ce7b8239b9d6033a88644f5c8e6504b9ddeb6ce55d88a505f7a846bcb0c86cb7a8c4550bf10167fe3a4a45d99be1155d50e6d044b5c9d37817d340828120bdfc60dbf7b0b75a31d19f4241f2aa953e9e06ab5a5ec914566275c4466eb2913ab1bc0f03a814045a7d0c4c4824b360e59e57c5515facfd9bf262be4be48ba8c2ba29a6a04a0683bcaedede4eadaf83",
                    contents: "4955a1f49449481f8226485a458ea8c50d3bef1cdf0",
                    sucess: true,
                    suspend: true,
                    extendedInformation: "77fba4d0de7b4095a864995ee519afaced970219285241a5a05817129b686c267fcd99e4e1db4889a7c2ab7fafac3501d864196c64df4b91b5f43f0025a270b65e84b932465e478da62536c4b6963f663ad06e4c535840e18e2b80638b41703e54127c8ec4314277af08eac99590034f9664862a3918489aa414c23dbdd7668ad98c28596f614e9fa4cdcbe93b03a23b179f677f5cda43729089ad986134e817946b069372034209b6bfc8bbd971f753cf027c30d51d4389b39a151094c466cb77291dd8fe3744be9b801f941f1e7ec0a74fe43725954fd3bc42d59dca384f3569fe874e103a455285e3dca5b3c11378391e4cabab654c6f872a",
                    note: "5fb644517a6444f6a6477b4de3ccf5dc5bf08c32f6cb44c99d586b376a5873d8a4c71d0a63534485b7a6bc0a95139d6203310cb374a84ee8bcba565d25d18a22b808efad3ac5453b850fd2cf82813fb0ea87caf2a0d3484abae567675e0650e43599336296f0440c9f8c5811bd73b971a56862a2344c41f4867743453e95f5792c879046232c449190b47229c4e3b973eacea419c1c44752999a316babf0a52b6860d62cc7294258b3068f8ec712906c058216d3e44441538272065af84002345d5a9c594ab54fec985b7b1379cd6259c975723e51b54f43862a6335ae6c656209db17fdd7f94448b2efd1bd5ad64409382a91a6c1144667a07a",
                    status: "7573327207da4dad92385272019f277396a6418cceec4500a8"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}