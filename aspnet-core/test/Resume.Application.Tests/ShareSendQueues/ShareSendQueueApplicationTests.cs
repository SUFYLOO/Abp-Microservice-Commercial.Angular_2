using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareSendQueues
{
    public class ShareSendQueuesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareSendQueuesAppService _shareSendQueuesAppService;
        private readonly IRepository<ShareSendQueue, Guid> _shareSendQueueRepository;

        public ShareSendQueuesAppServiceTests()
        {
            _shareSendQueuesAppService = GetRequiredService<IShareSendQueuesAppService>();
            _shareSendQueueRepository = GetRequiredService<IRepository<ShareSendQueue, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareSendQueuesAppService.GetListAsync(new GetShareSendQueuesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("fb84997b-f71a-4c91-9704-f40cbd1e9143")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareSendQueuesAppService.GetAsync(Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareSendQueueCreateDto
            {
                Key1 = "e4a4c8bca1af45b4b179d5f78761dd52bef87c0a27d34de78e",
                Key2 = "1b06761f371347df8de37378edef033972d56b432fb04c8395",
                Key3 = "96ca2536e9fe40e6aa34aef07664bf9d367919fedeb344eba1",
                SendTypeCode = "5e2bf629a601440fa6107e19b6a4058874f84fb7b1cf4a9c86",
                FromAddr = "25917ca019764979a84cbcf52d3c0d572aef9388ac7c43e49cadfe5d1993b1fe8af7fa5375ec4327a797460adf2f49ba282c39c60d304dabbafc72f629c71495ec189bb2d793443992591dca0c93fcc173b868cf068045cb801f4f6c38215ed2a3a132a4",
                ToAddr = "81ddb68915674856bc8617e67b8de2fe04531d8d94674a4b80fd6a3bdff12d5e6fb7d6b50e744609bcc58d50098dd8dd995998d2b9bc4479abaf1d367200e5b52df2a2f71aed4b129056d1ea36d6176a109158814ac8405bbaf69df4292725109b396db779114f55bc30d0e5f95614aba5217eba0e7e49b593ad3762d2d94934d87089314410491f93ce2937b0f15a38296f95ae001a412e9f12a6bddc43c4c9c6369314e0794478ba35568c6b0d05e3cf4b6cb749174405844190d790d7acbc96296f91d5624c87adabce95c2e1c0f9a602a30108964e888089d25d288c05cb994d3a181720477eb22eca9b9c797d7e28c9385d1ac742e28569",
                TitleContents = "b15ba3dbe89149d5abec06163d5a66e6989d607abb994cd79eb2d224d3aa77229045de672d124f5f981b1907992d9c0363e2c774d56946f0bce8ac5313b83a442e1927c7e42949bfadeb498000e8e1a637416835e99f4f33882e5b0401c2d4da9afbed4559334e1c8e9d4c872d7a9693d23ba3d4ee794b98bce903eeb1fea8379a3d2ab7ed0c4bb5a95049bb4185b086becca073d4ec4d97b160091ba6a669686c099dbb82f841eb87c8506e6967599c7e70dc4dd2734c589d9e3e4a378f8195bcb68368faef4cd1a82f1f48d269ff5bf8677ec991ea4a23937ce5969298ccdf0fcda540ab2141668e64ef9e0a3681e03d0283da4f364f43bcb8",
                Contents = "b3b445e34f87468cba06954acad2dcf4e473b7d3d3ac4aafae94a2a9068ce88aec43cb5052cd457ba9a483b79857f1af4fe",
                Retry = 1188703702,
                Sucess = true,
                Suspend = true,
                DateSend = new DateTime(2010, 7, 8),
                ExtendedInformation = "5eef49ef906048df980367bda035b5f07261b3ba71cb4be89a2569e7d24cd7aefa69786dea7641028efc083869e6514305a851bad7db4432bd2dc26eee80870c514983a1ee3140a8ade37311f6c64657f717c012f620435fb036aa5a710429b4742615e4f24a4d05b26c5f18afc5440b60c8c52901d04507b23cea66df8085207d71f50f09c1499eaabe99c32fdf4250377c35390efa451faa8bd4a124bd4ee24d0c9fe14cf64e6aac242542042f24014f712714afd244bcaa279ddaadf42d9b2cb266a551ca47a9909d98569bbd5ed6391f283b2d2c4ffa9e7acd1762c2be72b0ea7754b24f435a9a2294de05582d796fc876a21fa746c19ebd",
                DateA = new DateTime(2011, 9, 7),
                DateD = new DateTime(2019, 2, 4),
                Sort = 158344636,
                Note = "5a562f2933f544b3943e42226adba50f745f5dd47548420ca8873b05969c8e4969ace5bd5cd449278a67b3bb892a8df509767912e5ff4e9ebe5185e979a7a1b19223e5d81cc64eaf978021a1974aea4ad41d867a60c64b3cb74ca183efc6363ac2715158a97849cfab706fd6213d8d41614b02dff14446b1bf8bec7d5a798e3a6477cd10f3cc4cb19ca74f29ead3b2f1abd5f6ba0440491b858306d756bb16d2a6e62c78c0fc44db81fd6afb367e08c0be0aae81aea74e2bbd674ed6bdc0ab87dc9969d000914b3dbcb1d5acbd2e860858a75b170d0d446c9b6812cfd0c88075fa40d079d5e94f5c98b052d36df2a7a6e0a734b308a94daba64f",
                Status = "186422db642140e0974235e1f01b9c63db101dd799fc4b188a"
            };

            // Act
            var serviceResult = await _shareSendQueuesAppService.CreateAsync(input);

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("e4a4c8bca1af45b4b179d5f78761dd52bef87c0a27d34de78e");
            result.Key2.ShouldBe("1b06761f371347df8de37378edef033972d56b432fb04c8395");
            result.Key3.ShouldBe("96ca2536e9fe40e6aa34aef07664bf9d367919fedeb344eba1");
            result.SendTypeCode.ShouldBe("5e2bf629a601440fa6107e19b6a4058874f84fb7b1cf4a9c86");
            result.FromAddr.ShouldBe("25917ca019764979a84cbcf52d3c0d572aef9388ac7c43e49cadfe5d1993b1fe8af7fa5375ec4327a797460adf2f49ba282c39c60d304dabbafc72f629c71495ec189bb2d793443992591dca0c93fcc173b868cf068045cb801f4f6c38215ed2a3a132a4");
            result.ToAddr.ShouldBe("81ddb68915674856bc8617e67b8de2fe04531d8d94674a4b80fd6a3bdff12d5e6fb7d6b50e744609bcc58d50098dd8dd995998d2b9bc4479abaf1d367200e5b52df2a2f71aed4b129056d1ea36d6176a109158814ac8405bbaf69df4292725109b396db779114f55bc30d0e5f95614aba5217eba0e7e49b593ad3762d2d94934d87089314410491f93ce2937b0f15a38296f95ae001a412e9f12a6bddc43c4c9c6369314e0794478ba35568c6b0d05e3cf4b6cb749174405844190d790d7acbc96296f91d5624c87adabce95c2e1c0f9a602a30108964e888089d25d288c05cb994d3a181720477eb22eca9b9c797d7e28c9385d1ac742e28569");
            result.TitleContents.ShouldBe("b15ba3dbe89149d5abec06163d5a66e6989d607abb994cd79eb2d224d3aa77229045de672d124f5f981b1907992d9c0363e2c774d56946f0bce8ac5313b83a442e1927c7e42949bfadeb498000e8e1a637416835e99f4f33882e5b0401c2d4da9afbed4559334e1c8e9d4c872d7a9693d23ba3d4ee794b98bce903eeb1fea8379a3d2ab7ed0c4bb5a95049bb4185b086becca073d4ec4d97b160091ba6a669686c099dbb82f841eb87c8506e6967599c7e70dc4dd2734c589d9e3e4a378f8195bcb68368faef4cd1a82f1f48d269ff5bf8677ec991ea4a23937ce5969298ccdf0fcda540ab2141668e64ef9e0a3681e03d0283da4f364f43bcb8");
            result.Contents.ShouldBe("b3b445e34f87468cba06954acad2dcf4e473b7d3d3ac4aafae94a2a9068ce88aec43cb5052cd457ba9a483b79857f1af4fe");
            result.Retry.ShouldBe(1188703702);
            result.Sucess.ShouldBe(true);
            result.Suspend.ShouldBe(true);
            result.DateSend.ShouldBe(new DateTime(2010, 7, 8));
            result.ExtendedInformation.ShouldBe("5eef49ef906048df980367bda035b5f07261b3ba71cb4be89a2569e7d24cd7aefa69786dea7641028efc083869e6514305a851bad7db4432bd2dc26eee80870c514983a1ee3140a8ade37311f6c64657f717c012f620435fb036aa5a710429b4742615e4f24a4d05b26c5f18afc5440b60c8c52901d04507b23cea66df8085207d71f50f09c1499eaabe99c32fdf4250377c35390efa451faa8bd4a124bd4ee24d0c9fe14cf64e6aac242542042f24014f712714afd244bcaa279ddaadf42d9b2cb266a551ca47a9909d98569bbd5ed6391f283b2d2c4ffa9e7acd1762c2be72b0ea7754b24f435a9a2294de05582d796fc876a21fa746c19ebd");
            result.DateA.ShouldBe(new DateTime(2011, 9, 7));
            result.DateD.ShouldBe(new DateTime(2019, 2, 4));
            result.Sort.ShouldBe(158344636);
            result.Note.ShouldBe("5a562f2933f544b3943e42226adba50f745f5dd47548420ca8873b05969c8e4969ace5bd5cd449278a67b3bb892a8df509767912e5ff4e9ebe5185e979a7a1b19223e5d81cc64eaf978021a1974aea4ad41d867a60c64b3cb74ca183efc6363ac2715158a97849cfab706fd6213d8d41614b02dff14446b1bf8bec7d5a798e3a6477cd10f3cc4cb19ca74f29ead3b2f1abd5f6ba0440491b858306d756bb16d2a6e62c78c0fc44db81fd6afb367e08c0be0aae81aea74e2bbd674ed6bdc0ab87dc9969d000914b3dbcb1d5acbd2e860858a75b170d0d446c9b6812cfd0c88075fa40d079d5e94f5c98b052d36df2a7a6e0a734b308a94daba64f");
            result.Status.ShouldBe("186422db642140e0974235e1f01b9c63db101dd799fc4b188a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareSendQueueUpdateDto()
            {
                Key1 = "fe1cac1799254059a00128f64315367360d25f02200945e6b5",
                Key2 = "744dcdd6bc3c41ffa5fbff77798986e01eda158e558f405cba",
                Key3 = "a9b69f2b67064b9caeb1cf713ba1c49ad4231bd1eb1a42558f",
                SendTypeCode = "6c598500082b4596b560668ef3abbd4eb61b2cfb8bc44a6b8f",
                FromAddr = "556fa46b4d41494883f704dc14f5a602c25debc6be2142f5a8218420a9bca2bc3b6a99dea42742ae896de54fd85b92294ac00c1f7acd4b9381d56400b287d6f369aef7c2de454e3d9d87f4f2a9523f8b708273785bc941188f64669fc99a167bf25cae6f",
                ToAddr = "7c38761261924bbc95f4e9c936a6566c26610e5bf3f040009f744dc11303401b75df56aa933746189c12ed33fca89d0f782bae9cc4794287b0f48ceab1ff63d7dc5a674394c54bf690f3207975ffb5216e64ccd683934b39b1a9bece8633642cdd9616c61f9048a3a1819377a76a3beaeb92a07bd73046b7b623536d9e4c0b2787b89d0b2a4345a2b8a151253cc15e2ebec231b4947b4186b7232ea57e74700660afb08a9e68420082cc89dc7de216422d81fd6ce91b433ba04adc5f87a874d1374c369db8054ad7b0dd9189fe8a5a2e74568e18998742b1b0c17236260d5e0064869b8cf6ff4c4e99968ce48b071bc9bbd4c108b3694d4ebf94",
                TitleContents = "52744bb397404df49301dc7cc49b5b70e8a3ab3fee344f769ebf5c3c231bb0509bac9b0efd7a4cf583ed8fd8a8112da2c91fa9e3588749d9b61084564d77e57023b4f4cddfb34f9582abf89b56578f57f901d29c12aa458380934b51efe0b146147201a261ce46aabbab8035c0edc834eadd043fee1f4bb2ab398d35e804680d69a41c855ded4f989ce0c6a8fac336efa2fd89ecd61d4b5da98c68fe8097cbf14f8a13f7a71e4655ac7b9108b862830c57d181a71d2f4134bfc98c5307af84c025ddb8d3c41141859a6f9e5f3da52d0f05244b36eb29421ca1298aabacaec0bedd704a187615438f8a9824066ceab6124bfde2192b54418693cc",
                Contents = "70d9f1b4c105475cae5c810e0296a8ab0e7ec6",
                Retry = 1298966480,
                Sucess = true,
                Suspend = true,
                DateSend = new DateTime(2018, 8, 18),
                ExtendedInformation = "0eb1e4a1a53049cea41c1c183586b54c59151c88ce3b448e87a03180ae278aecb785d918b5c541bc938a340631ffb05c48e4b287e3614416b3a6bfacecc893eba376a5b467e544be99a350ea0bd1a2c411cf4773978040d78e6e6df1835add91de7ecccf65c54e7d94e570ccfabd197a49a4f31f9b664afb8c2c95e53eb41c8e9f2f2facc26e4ba08dcade2f9e0c7b5e519c4a515d6e4f30b74f35a3d3c1a9e859ac14fa8faf4243ab3a86686c8e633b6b7bbfdf50894cd39a7ef479b3eac3ef9e5de71052824d459f787ed24944cc6421546956199e41caa16c7310d2625cf009fb88b8915f45d9ace9de7401a482d1917fd229b6de48a18b87",
                DateA = new DateTime(2018, 5, 18),
                DateD = new DateTime(2002, 8, 17),
                Sort = 771005456,
                Note = "366a54d35fa84c8286af9d6c86b3a4922a86f311c2804a55818c5b331abf4170db1c062bd89c4a298475fbd3614b8b7cf482044d3d254162a8779c09dad5cc8ca7c44f7b5942441db287c614ae5a2a3d4abb6fa6d9794bccb966037f9ac6c1b402970e9dbd3644eda0705e0f792114d4b2779208599a4ae486dabed81ac07794eae6ae42bbb64d53ade47e2b7a5157d196bdd6df875147169fd405cfa7650c915dad05fa294c47ddac5ee1b4eaffc286bb3cbccf5c614e70a552d00564ed4ca110f491386e2240cb9df34a540b1852ecdb05e6cfeaeb44099bac05b689102e14a92515293bb44beaa721bf33ba6d22856b2335a342aa459b9e57",
                Status = "8970ac3f9b3149d98133e25eddbff83c8c1ea237b02446f4a6"
            };

            // Act
            var serviceResult = await _shareSendQueuesAppService.UpdateAsync(Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"), input);

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("fe1cac1799254059a00128f64315367360d25f02200945e6b5");
            result.Key2.ShouldBe("744dcdd6bc3c41ffa5fbff77798986e01eda158e558f405cba");
            result.Key3.ShouldBe("a9b69f2b67064b9caeb1cf713ba1c49ad4231bd1eb1a42558f");
            result.SendTypeCode.ShouldBe("6c598500082b4596b560668ef3abbd4eb61b2cfb8bc44a6b8f");
            result.FromAddr.ShouldBe("556fa46b4d41494883f704dc14f5a602c25debc6be2142f5a8218420a9bca2bc3b6a99dea42742ae896de54fd85b92294ac00c1f7acd4b9381d56400b287d6f369aef7c2de454e3d9d87f4f2a9523f8b708273785bc941188f64669fc99a167bf25cae6f");
            result.ToAddr.ShouldBe("7c38761261924bbc95f4e9c936a6566c26610e5bf3f040009f744dc11303401b75df56aa933746189c12ed33fca89d0f782bae9cc4794287b0f48ceab1ff63d7dc5a674394c54bf690f3207975ffb5216e64ccd683934b39b1a9bece8633642cdd9616c61f9048a3a1819377a76a3beaeb92a07bd73046b7b623536d9e4c0b2787b89d0b2a4345a2b8a151253cc15e2ebec231b4947b4186b7232ea57e74700660afb08a9e68420082cc89dc7de216422d81fd6ce91b433ba04adc5f87a874d1374c369db8054ad7b0dd9189fe8a5a2e74568e18998742b1b0c17236260d5e0064869b8cf6ff4c4e99968ce48b071bc9bbd4c108b3694d4ebf94");
            result.TitleContents.ShouldBe("52744bb397404df49301dc7cc49b5b70e8a3ab3fee344f769ebf5c3c231bb0509bac9b0efd7a4cf583ed8fd8a8112da2c91fa9e3588749d9b61084564d77e57023b4f4cddfb34f9582abf89b56578f57f901d29c12aa458380934b51efe0b146147201a261ce46aabbab8035c0edc834eadd043fee1f4bb2ab398d35e804680d69a41c855ded4f989ce0c6a8fac336efa2fd89ecd61d4b5da98c68fe8097cbf14f8a13f7a71e4655ac7b9108b862830c57d181a71d2f4134bfc98c5307af84c025ddb8d3c41141859a6f9e5f3da52d0f05244b36eb29421ca1298aabacaec0bedd704a187615438f8a9824066ceab6124bfde2192b54418693cc");
            result.Contents.ShouldBe("70d9f1b4c105475cae5c810e0296a8ab0e7ec6");
            result.Retry.ShouldBe(1298966480);
            result.Sucess.ShouldBe(true);
            result.Suspend.ShouldBe(true);
            result.DateSend.ShouldBe(new DateTime(2018, 8, 18));
            result.ExtendedInformation.ShouldBe("0eb1e4a1a53049cea41c1c183586b54c59151c88ce3b448e87a03180ae278aecb785d918b5c541bc938a340631ffb05c48e4b287e3614416b3a6bfacecc893eba376a5b467e544be99a350ea0bd1a2c411cf4773978040d78e6e6df1835add91de7ecccf65c54e7d94e570ccfabd197a49a4f31f9b664afb8c2c95e53eb41c8e9f2f2facc26e4ba08dcade2f9e0c7b5e519c4a515d6e4f30b74f35a3d3c1a9e859ac14fa8faf4243ab3a86686c8e633b6b7bbfdf50894cd39a7ef479b3eac3ef9e5de71052824d459f787ed24944cc6421546956199e41caa16c7310d2625cf009fb88b8915f45d9ace9de7401a482d1917fd229b6de48a18b87");
            result.DateA.ShouldBe(new DateTime(2018, 5, 18));
            result.DateD.ShouldBe(new DateTime(2002, 8, 17));
            result.Sort.ShouldBe(771005456);
            result.Note.ShouldBe("366a54d35fa84c8286af9d6c86b3a4922a86f311c2804a55818c5b331abf4170db1c062bd89c4a298475fbd3614b8b7cf482044d3d254162a8779c09dad5cc8ca7c44f7b5942441db287c614ae5a2a3d4abb6fa6d9794bccb966037f9ac6c1b402970e9dbd3644eda0705e0f792114d4b2779208599a4ae486dabed81ac07794eae6ae42bbb64d53ade47e2b7a5157d196bdd6df875147169fd405cfa7650c915dad05fa294c47ddac5ee1b4eaffc286bb3cbccf5c614e70a552d00564ed4ca110f491386e2240cb9df34a540b1852ecdb05e6cfeaeb44099bac05b689102e14a92515293bb44beaa721bf33ba6d22856b2335a342aa459b9e57");
            result.Status.ShouldBe("8970ac3f9b3149d98133e25eddbff83c8c1ea237b02446f4a6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareSendQueuesAppService.DeleteAsync(Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"));

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == Guid.Parse("7cd5a756-350e-4118-9af4-af184e0ffa22"));

            result.ShouldBeNull();
        }
    }
}