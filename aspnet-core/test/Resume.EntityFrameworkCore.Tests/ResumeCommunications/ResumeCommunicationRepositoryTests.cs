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
                    resumeMainId: Guid.Parse("95c8fd8e-9f2e-406b-be26-72c06033b644"),
                    communicationCategoryCode: "867495e46a194c8e92ffcb6dda82f66bbc3bc58b0c7a44e685",
                    communicationValue: "f11c738149da4d6f838b0603df5cd0e912ec489b2f74424d9d4e886ca8784e6218a27434928646af8e3d356dee8b6cde7b83ae13e6cc46c286fdafbfec659b11166b5bcd710d455ea23ca608c10adc76fd909e816efa45068127e8d2b337f59f121e4aad",
                    main: true,
                    extendedInformation: "af96efbfdf8f44b6a010a247b72ab73d5e5b0553c43d4b1a8722d7c54c03f9f1145f6fddc9784c0fa51e2e332145f581871d6370cff34e06ab3b851e81377e2aef1e35d77b504af891f04ecd1eb2bb931fc3efd21a2a40f9942de4d0b361b5d275f64adae10e4055b118fdea89453183bb6945e72d464f9facaf78165921bb494208e06240b34cd8b28a9a494705571a9b4312da1eaf4da68bbf3bbf24aedcc9138ae9ab57b64ef49a91065d6239a1e0aba08f573e314447a30d4c2d9b4abb10a084d9c7f6e649e6afafd83125be4796b049f1f9f7254924b1166b8f76567ea8396d42dd6a4041b6a2f30e749e2b394bf616730dac9044458877",
                    note: "c8cd9fa5d1e745ba8624ef58e7d0941c67d4f3f8727e440690079fcfdc1c5a76c53c34c7039846c9a7c20dfe581a8f04c806fa09d303466dab05332bcde64f7287176101d5c54f61a8e645a438598679cebc5e01d5ad4a4d99846b0788a6b94e8b658347c3e04a61a5b5d6a85696b3b6350260bc05fc4b898a73e87b42bad410758ef05a9fc74dfb99716909884a7527578695ac36e548a58c41a4bfae6376281df3bf3bb8354c059f4bd2421096c5d5e2dd9469ac704e90a7a86c09c74ea6c3046109708e514ae492432c2ef07ddc815bb1e85271f94c228c87e614ffeade79a990ce0f66eb4d57a43094a30e8f615087d37cf3486e4055bfdc",
                    status: "1821e785e89f4de0b386da5cf76ec1c3d53c386b26e64b3ebb"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"));
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
                    resumeMainId: Guid.Parse("240665a2-a832-41d5-9d51-0ab2464a6836"),
                    communicationCategoryCode: "8e0bb27d248e4a0387f33e2c6823511254a17ede9f364cbeb1",
                    communicationValue: "306ac53716d64e2c874cbc571eb0e239d6c2c642279342f682651ad38ac9097e646f56a47dc541f9bf0f3bff7e5031f83f8697a43d7c451180b116ca36e4d531dc3406a232c44c0ba30ada4e0b93d9e8533cce3113c04f25a6635632424fef8dc9402d4c",
                    main: true,
                    extendedInformation: "7375cb3340a54dbe95560b6242e7693c4b1452ef7a79480288e4f3757ee53e6f255006fe0cd0488886685241ed5abe691c7c599afcac41d78db457a938f9739b16a9b9babe8f43de8790cb66812c6b7e3beacf1c82a1406d9b349fb3998712588d7da38f489b4e9385b4acfcfecd9ee2e8ed16ec48cb48d58b306018dc304596cb6c07a103f941d8b3380509ffd07f0c0e48fc3b91734294a8fd899033042394f112b869b16448ed9092d2ca32035a0037ddbc02eb0e4664ac7c5ecd845a17f1357533e77b57463883d462bc75ae361f5b2e604f7cc04f01bb5dd4b2230533b9aea3a9855dcc4d199ed772c5020c778af49b50d461d24b518633",
                    note: "5867eead55a64e06a1160ac53455fb53cb23937daa904693ae87c70f7b8003afe2438b82096e4fb39680aa66c682b51a2f88a31ec68a41fc8bac6fdaf623b10cea1f49accfed498080ee856f483b523e465004b445a2430aa9347f8d42ac9f54ec247cb6f67143808219abbae02947c32dc39ed6534146e29b05f401cae7c52276a5215bda5e4f40a8265cb0c01fd148d4ade08cca994bc091bcc1f553499b6295ab08d719bd4e66850cd1322efe0bcf33cf274d0fa24595896d9b69ca50fb2d6c5ecd3517a54f738e7b69807a47057756fab6a07cdd4fa3819bcf472582145836be2ddb9e194d4c80b924ecde42204e6037616435de4ec091e1",
                    status: "fe5ea251cef84e6a8e11198c701074ededcf7ea3ba064917ba"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}