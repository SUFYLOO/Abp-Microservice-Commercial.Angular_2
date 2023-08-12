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
            result.Items.Any(x => x.Id == Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8cd2a324-b761-40bc-881b-f40bf9c4d1e6")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareSendQueuesAppService.GetAsync(Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareSendQueueCreateDto
            {
                Key1 = "305d036e7b544297bba09c63a0fd2bf73a1e31ac5a6248b884",
                Key2 = "bb4c8a973db544a6bc55167d712fd84d3367a1e4bba0407e80",
                Key3 = "d55d22b9a3b04bc283fcbb7fc622faeb7982cd732da9463c8c",
                SendTypeCode = "cd84672cbf8146af87bb59a47d988de3ecd50dc2396e4e22a2",
                FromAddr = "8cd55b7fd23b4fd6a34b5a845f5d2f570aa7330e4f624aa4a739e2f1689b6237a6e40eaa308b4569ba5f5fcabc0f9549ab83f5340c34466abe7c73f3c8bb9b892f4902356bfc420aad4876f56b498096cbc57b5b9a024e9893fd22f8f8363aff445c16ee",
                ToAddr = "dc8a8a6316a74e98a1886c3a24d29cd8484e5f05a313491498765fe768d28272e58b6e10686f48738405735f4b00a5ccc2f706a9d84d4eb1b3e49a89c3d17ce3fa5c1b9570a64feca84c0d8c72ecf52f70c2483b1b6744798d766e18fc2fcab44714c110e80d480aac3713f08ab6636b775b88a1aa174ed7abe1abebd02ea137a20be9e82e634eddb0d7619b1ad508458d31d6dd8b5d43c6a397c2b223d6f56edace15f921b346c88460bf3c82189fbf79e97b56867542a49605dfa2f614c8a082f03ee00817469093af4cd2f76b9b0e11a0c5efbdb744918afbbcb640cdde4ee208b05c43b842a5898cbfc98f9143af69eb718f4c6c4f16b2f6",
                TitleContents = "37d650400ba6464a95a07e2d9964bfe4ac12c75325cf41979de7b5ec176bfd26118e080bf9614a60a5ae3841b451430556f17a53388748b39943f9c31ce111b956205cfb618f441f955b7e37a92f7d1e78a8139bcb8d47a08e554e93f8b2ceabee6439335b524454b3c428089388e542bb7b76cb0b8441fb847cfce3e9d5baea5eef21858db94b15be1552e09d89eac942f3815da39c42d88a3ce3a2ef00bfd2a1eb612aff3f43c6bcbd3e5ec573f6e625f50b043609435f913a7702218edc8b6767f842b2a74755b64a8dff8dc0560683592873da6b425b9038b2d8a4dcd6374cfd902e541d474e8e9aabe45f88942b92122d1e4ae041df9e02",
                Contents = "a23bd4bac4d245d788bcfb",
                Retry = 125196987,
                Sucess = true,
                Suspend = true,
                DateSend = new DateTime(2013, 9, 3),
                ExtendedInformation = "77cfe843818044c7acbc8c60821bb05d97b08402a268491998c1516635f647a4ee0c2eefc45e49e48f8e93d924e69250f524ba100b5245d7ac8d69bad00e46a97a6042747866497398045a62184087e0aa8912c10dfd449aae3af62a8b9706985f936b4b3da84c7d95df049f4ddd1529e6e4d306e731451e8585ca6689cbadd45cb65ac4babb41ffb0a1a556dcc5aaa59aa011aef68948a7a04e9fb4fbfccdbcc17404cd3c124ca98e6a680e4d4f766ecbfc3cd777984a3d855130dbd5a6626a1558670090474aec911cf0d19810a17f11631ca23f6643c0aecf8369445462a5acd213ff0a48416199e1a0029d5f1f66636d14575db2406999e0",
                DateA = new DateTime(2007, 2, 1),
                DateD = new DateTime(2005, 6, 16),
                Sort = 573312824,
                Note = "e76c6544b7274b2da9484a66e16fd1bae9f50abb3e13419f9aa129a5e2b7b7d49d809726dcb948e39ff4ebd78842e6c1e28599048937461c9731b2893ee574d4bb30a91ffdfa4ba9be18e07c739a8e54ef523e55b27642a481a202ebc805bf9d459a10f8125b4a76b86d5c4d81515a14800f846a592b4f3ab9f1e4466bcb1e020d56e4c7ab624a478fc2f51499fedb4150fdb2c399fa4826b3456bc06b4b2ce83eb6031c2a6e40248802acd3fd33e7e113adaf995ae54f8fad112a388723d3ed62b94a82b63846d080ce8842249aafc126a30c6cd73645de8c92d5d23d6a9937febfe6694bdc4326a1138efe2412f8308d705fbb17764c7e8712",
                Status = "346e7f6f2db74b259383ca7353babcf0c8eef9fc4fb5469285"
            };

            // Act
            var serviceResult = await _shareSendQueuesAppService.CreateAsync(input);

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("305d036e7b544297bba09c63a0fd2bf73a1e31ac5a6248b884");
            result.Key2.ShouldBe("bb4c8a973db544a6bc55167d712fd84d3367a1e4bba0407e80");
            result.Key3.ShouldBe("d55d22b9a3b04bc283fcbb7fc622faeb7982cd732da9463c8c");
            result.SendTypeCode.ShouldBe("cd84672cbf8146af87bb59a47d988de3ecd50dc2396e4e22a2");
            result.FromAddr.ShouldBe("8cd55b7fd23b4fd6a34b5a845f5d2f570aa7330e4f624aa4a739e2f1689b6237a6e40eaa308b4569ba5f5fcabc0f9549ab83f5340c34466abe7c73f3c8bb9b892f4902356bfc420aad4876f56b498096cbc57b5b9a024e9893fd22f8f8363aff445c16ee");
            result.ToAddr.ShouldBe("dc8a8a6316a74e98a1886c3a24d29cd8484e5f05a313491498765fe768d28272e58b6e10686f48738405735f4b00a5ccc2f706a9d84d4eb1b3e49a89c3d17ce3fa5c1b9570a64feca84c0d8c72ecf52f70c2483b1b6744798d766e18fc2fcab44714c110e80d480aac3713f08ab6636b775b88a1aa174ed7abe1abebd02ea137a20be9e82e634eddb0d7619b1ad508458d31d6dd8b5d43c6a397c2b223d6f56edace15f921b346c88460bf3c82189fbf79e97b56867542a49605dfa2f614c8a082f03ee00817469093af4cd2f76b9b0e11a0c5efbdb744918afbbcb640cdde4ee208b05c43b842a5898cbfc98f9143af69eb718f4c6c4f16b2f6");
            result.TitleContents.ShouldBe("37d650400ba6464a95a07e2d9964bfe4ac12c75325cf41979de7b5ec176bfd26118e080bf9614a60a5ae3841b451430556f17a53388748b39943f9c31ce111b956205cfb618f441f955b7e37a92f7d1e78a8139bcb8d47a08e554e93f8b2ceabee6439335b524454b3c428089388e542bb7b76cb0b8441fb847cfce3e9d5baea5eef21858db94b15be1552e09d89eac942f3815da39c42d88a3ce3a2ef00bfd2a1eb612aff3f43c6bcbd3e5ec573f6e625f50b043609435f913a7702218edc8b6767f842b2a74755b64a8dff8dc0560683592873da6b425b9038b2d8a4dcd6374cfd902e541d474e8e9aabe45f88942b92122d1e4ae041df9e02");
            result.Contents.ShouldBe("a23bd4bac4d245d788bcfb");
            result.Retry.ShouldBe(125196987);
            result.Sucess.ShouldBe(true);
            result.Suspend.ShouldBe(true);
            result.DateSend.ShouldBe(new DateTime(2013, 9, 3));
            result.ExtendedInformation.ShouldBe("77cfe843818044c7acbc8c60821bb05d97b08402a268491998c1516635f647a4ee0c2eefc45e49e48f8e93d924e69250f524ba100b5245d7ac8d69bad00e46a97a6042747866497398045a62184087e0aa8912c10dfd449aae3af62a8b9706985f936b4b3da84c7d95df049f4ddd1529e6e4d306e731451e8585ca6689cbadd45cb65ac4babb41ffb0a1a556dcc5aaa59aa011aef68948a7a04e9fb4fbfccdbcc17404cd3c124ca98e6a680e4d4f766ecbfc3cd777984a3d855130dbd5a6626a1558670090474aec911cf0d19810a17f11631ca23f6643c0aecf8369445462a5acd213ff0a48416199e1a0029d5f1f66636d14575db2406999e0");
            result.DateA.ShouldBe(new DateTime(2007, 2, 1));
            result.DateD.ShouldBe(new DateTime(2005, 6, 16));
            result.Sort.ShouldBe(573312824);
            result.Note.ShouldBe("e76c6544b7274b2da9484a66e16fd1bae9f50abb3e13419f9aa129a5e2b7b7d49d809726dcb948e39ff4ebd78842e6c1e28599048937461c9731b2893ee574d4bb30a91ffdfa4ba9be18e07c739a8e54ef523e55b27642a481a202ebc805bf9d459a10f8125b4a76b86d5c4d81515a14800f846a592b4f3ab9f1e4466bcb1e020d56e4c7ab624a478fc2f51499fedb4150fdb2c399fa4826b3456bc06b4b2ce83eb6031c2a6e40248802acd3fd33e7e113adaf995ae54f8fad112a388723d3ed62b94a82b63846d080ce8842249aafc126a30c6cd73645de8c92d5d23d6a9937febfe6694bdc4326a1138efe2412f8308d705fbb17764c7e8712");
            result.Status.ShouldBe("346e7f6f2db74b259383ca7353babcf0c8eef9fc4fb5469285");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareSendQueueUpdateDto()
            {
                Key1 = "ba274ad0bb474d878694fa837a85921ab6398bfa480245b9b9",
                Key2 = "d67614d471894415ab8b291aaebb89d4b09981480f304ecfa7",
                Key3 = "9ebf686bbe4147d1bbb1a0f8512f66488d76b5d303b44574a3",
                SendTypeCode = "d4caa652d11f4b628231bfb34b7efb91d3dca7eea4ba453ea2",
                FromAddr = "309666a0c2a44e209f2895b7fb3a95b0728153103ae244318bdd629bbf5b9cc62205660c28de478b842bfc63e90d93c02f00498d6e164ccfa4d396a637f40bd1b83d9e9e675e499099874a9b45e941480d002ffaa7444e43b9ca8e3b97f52e53666747d4",
                ToAddr = "d49de9b75b4d48b780a981d0fd8c91ef93bdc1bae7a940f8862c25f5f5e50253958797c4c2104165be3ae0f0258e7d68903c3cf407a54219844b895806795ab8645887fa9fe44981b69660d07b8be39ccab3e5e671724963ab80cf62c92369c533f5604f3605463e8d95f29348bd9fc860ea1a94e0d3434c87d3f09fbcf36c1c06552f47287a4f1a94e1d569953faca31b9c3a5a803d494daad05d9e789c4b9771a5cf5cbced4dfdbbf9b62ebd06faf8bcae0d6aa0394ead89e71cb82e3893dae63af2ffd6294051a35ce697a5ac6418f85e127fadb9496ca9511503c47c3554fe51f830d74b4a9a88d752a80412ba428ff9a737b513481d98df",
                TitleContents = "92e17362057d4d0094c91b1609fc4bdc5322a5f5d25641b3b01d62c79370bd5c1809ade4a3ca4032a640d7a0c4bbf110bcebe707090946f6ab0b80db6f49d2c13313ef36ad504fafbb7b8b5c7bc85e6cba9505fbf38e4f228211f071878f922089e3073ad1cb40a4a49a6e71e4fb33cbac4c8bd50ad54345bcac4d8c33ce0d672e857f7ad13641bba6a2bd4724a074b4882eeeb585bc4b7dafd9bc710f3476b3ed4bf204407a4618be16372b184fdc2c95813474d8224e0787f779bbd7421b2f8b6c9038644646a6962d91708103b69ba522d05d24a84cd08c867d79197b864e3473b3b201114f43a1e4ac5d0d48648977e593c0a8074375831b",
                Contents = "a351383188ca4178b039aaa01b03c47fea18bf028b7b4fc792c5694554f7ab27b3730b2587454cdc994ca90a5",
                Retry = 680573719,
                Sucess = true,
                Suspend = true,
                DateSend = new DateTime(2000, 1, 11),
                ExtendedInformation = "94ad3a619aa546dfacd8b909b613272ba2204dadb364430e9d4e3e90c5aa2a5a76cecba3d4e44c26aac8e178031ac9cdec7fcdaa505249c4a611bc6e0592fa9f041652c5e9a44173b581938655a272a95696fc4d4c33483ab52dd23cf66840dad0ece9d9b3ad4a83ba5dff074bc9fc247e282fc3968c40a6b1ac2981a54f54b484535fe3ee0941449c3542d99057f89124a241daddb64c89aa2c5559694af8c6a242f19d764f40db97ca6fb8a460ddfae456a5cfbc2046178df28ea0200ce980a4b27f2a4c2740b08e08d0bd3caeba1d63b62c64180e4ea090fdd18e45d4ea52f716603eaf8a430e8bd31c233259d45dbcbf251be0834cfebc7b",
                DateA = new DateTime(2006, 5, 10),
                DateD = new DateTime(2010, 1, 17),
                Sort = 275484908,
                Note = "7e551f61f7e24897bc19542f1d0618c0cf7ceda37b6b47d6870fe3016601fd19a76284fb6c924aa682a516ade26fe99691f26df5f2e44d08887cd15bd1984bedc8529c7401ac4da68b5bbdf9d59ec2f1fd21f199b70a468caff7371c389dfc0b1b35bf328ec14046bc496a4e8b9cb86525e7d2e2e2134a85b7adb47c5bcb464b4021e945881445dd8acd236f96e6cfa1337bd97affed4da1a550b882cad604ddb3fbe235e75d4d1594f18348793ee43d93957be03c3d4df69ea158140cf9097062b8701155da4c7cb525d65bfc20ef9dc868b66f53074e5f8f1d33e37749153c541782cc569f4ee4be3fd9154b055fa675cf25f0ec4c4c179c94",
                Status = "11c76ea7e3674928ae37e5637ada666485c4fe347828457ea1"
            };

            // Act
            var serviceResult = await _shareSendQueuesAppService.UpdateAsync(Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"), input);

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("ba274ad0bb474d878694fa837a85921ab6398bfa480245b9b9");
            result.Key2.ShouldBe("d67614d471894415ab8b291aaebb89d4b09981480f304ecfa7");
            result.Key3.ShouldBe("9ebf686bbe4147d1bbb1a0f8512f66488d76b5d303b44574a3");
            result.SendTypeCode.ShouldBe("d4caa652d11f4b628231bfb34b7efb91d3dca7eea4ba453ea2");
            result.FromAddr.ShouldBe("309666a0c2a44e209f2895b7fb3a95b0728153103ae244318bdd629bbf5b9cc62205660c28de478b842bfc63e90d93c02f00498d6e164ccfa4d396a637f40bd1b83d9e9e675e499099874a9b45e941480d002ffaa7444e43b9ca8e3b97f52e53666747d4");
            result.ToAddr.ShouldBe("d49de9b75b4d48b780a981d0fd8c91ef93bdc1bae7a940f8862c25f5f5e50253958797c4c2104165be3ae0f0258e7d68903c3cf407a54219844b895806795ab8645887fa9fe44981b69660d07b8be39ccab3e5e671724963ab80cf62c92369c533f5604f3605463e8d95f29348bd9fc860ea1a94e0d3434c87d3f09fbcf36c1c06552f47287a4f1a94e1d569953faca31b9c3a5a803d494daad05d9e789c4b9771a5cf5cbced4dfdbbf9b62ebd06faf8bcae0d6aa0394ead89e71cb82e3893dae63af2ffd6294051a35ce697a5ac6418f85e127fadb9496ca9511503c47c3554fe51f830d74b4a9a88d752a80412ba428ff9a737b513481d98df");
            result.TitleContents.ShouldBe("92e17362057d4d0094c91b1609fc4bdc5322a5f5d25641b3b01d62c79370bd5c1809ade4a3ca4032a640d7a0c4bbf110bcebe707090946f6ab0b80db6f49d2c13313ef36ad504fafbb7b8b5c7bc85e6cba9505fbf38e4f228211f071878f922089e3073ad1cb40a4a49a6e71e4fb33cbac4c8bd50ad54345bcac4d8c33ce0d672e857f7ad13641bba6a2bd4724a074b4882eeeb585bc4b7dafd9bc710f3476b3ed4bf204407a4618be16372b184fdc2c95813474d8224e0787f779bbd7421b2f8b6c9038644646a6962d91708103b69ba522d05d24a84cd08c867d79197b864e3473b3b201114f43a1e4ac5d0d48648977e593c0a8074375831b");
            result.Contents.ShouldBe("a351383188ca4178b039aaa01b03c47fea18bf028b7b4fc792c5694554f7ab27b3730b2587454cdc994ca90a5");
            result.Retry.ShouldBe(680573719);
            result.Sucess.ShouldBe(true);
            result.Suspend.ShouldBe(true);
            result.DateSend.ShouldBe(new DateTime(2000, 1, 11));
            result.ExtendedInformation.ShouldBe("94ad3a619aa546dfacd8b909b613272ba2204dadb364430e9d4e3e90c5aa2a5a76cecba3d4e44c26aac8e178031ac9cdec7fcdaa505249c4a611bc6e0592fa9f041652c5e9a44173b581938655a272a95696fc4d4c33483ab52dd23cf66840dad0ece9d9b3ad4a83ba5dff074bc9fc247e282fc3968c40a6b1ac2981a54f54b484535fe3ee0941449c3542d99057f89124a241daddb64c89aa2c5559694af8c6a242f19d764f40db97ca6fb8a460ddfae456a5cfbc2046178df28ea0200ce980a4b27f2a4c2740b08e08d0bd3caeba1d63b62c64180e4ea090fdd18e45d4ea52f716603eaf8a430e8bd31c233259d45dbcbf251be0834cfebc7b");
            result.DateA.ShouldBe(new DateTime(2006, 5, 10));
            result.DateD.ShouldBe(new DateTime(2010, 1, 17));
            result.Sort.ShouldBe(275484908);
            result.Note.ShouldBe("7e551f61f7e24897bc19542f1d0618c0cf7ceda37b6b47d6870fe3016601fd19a76284fb6c924aa682a516ade26fe99691f26df5f2e44d08887cd15bd1984bedc8529c7401ac4da68b5bbdf9d59ec2f1fd21f199b70a468caff7371c389dfc0b1b35bf328ec14046bc496a4e8b9cb86525e7d2e2e2134a85b7adb47c5bcb464b4021e945881445dd8acd236f96e6cfa1337bd97affed4da1a550b882cad604ddb3fbe235e75d4d1594f18348793ee43d93957be03c3d4df69ea158140cf9097062b8701155da4c7cb525d65bfc20ef9dc868b66f53074e5f8f1d33e37749153c541782cc569f4ee4be3fd9154b055fa675cf25f0ec4c4c179c94");
            result.Status.ShouldBe("11c76ea7e3674928ae37e5637ada666485c4fe347828457ea1");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareSendQueuesAppService.DeleteAsync(Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"));

            // Assert
            var result = await _shareSendQueueRepository.FindAsync(c => c.Id == Guid.Parse("f4766396-b2fe-46ea-b8a2-8ca417da37fb"));

            result.ShouldBeNull();
        }
    }
}