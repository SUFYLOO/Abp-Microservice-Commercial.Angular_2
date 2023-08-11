using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareDefaults
{
    public class ShareDefaultsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareDefaultsAppService _shareDefaultsAppService;
        private readonly IRepository<ShareDefault, Guid> _shareDefaultRepository;

        public ShareDefaultsAppServiceTests()
        {
            _shareDefaultsAppService = GetRequiredService<IShareDefaultsAppService>();
            _shareDefaultRepository = GetRequiredService<IRepository<ShareDefault, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareDefaultsAppService.GetListAsync(new GetShareDefaultsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("78c25316-3cb5-45e2-9222-347b0dad6b03")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareDefaultsAppService.GetAsync(Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareDefaultCreateDto
            {
                GroupCode = "bd4fff3143f14864b884b290ef7e56986775ae833d5e4c27be",
                Key1 = "1d3bc271c90c4f9facca5cc691a946b9d4c938bc1cfb4a7fb4",
                Key2 = "9ca37fc52303488b9c29f18ac7c4f4b0c37f9411d99a4df99d",
                Key3 = "1a12a566c48b484eaab306f7823884f712302e790b6343808c",
                Name = "f5264df418304e178055c11fa40f2340581669a9b5fc428fac741664b59469fc99bb64627d3d417fbd70ddf60638be2fa1d26d9c13154a4781d0143d157ab85dd8ac89010fe54ba9946a49fa48a410721c4204eb61a7444eaec89abb1cb79d8928b99b4f",
                FieldKey = "8f3b11b3cdf64a72ad94264ab1b18562e7a4ade5e7ea417995",
                FieldValue = "2e3d47de64244da6bb38f46a7de762b02155762d0d984ba494127bebb9bb10f5b336eee32d0d4403b0a74e3d115c2af407dd279314124f22a89dfeff667bda72e8fad290d6c344ffb9de3a1a5823323fa271c5f82a8245fdb541da9a2ce6f6b335af4e58a3ed4be7923f60184c35e849bdc32e76eb944522a4f4993f1a3a2be4bd0504a534fc4cc1ab07e557189e81e4567b2ecdf8bd4fb59a4c08d115967af0975738ada1704086aac4a873f9eb62b23a49370d5dae443d89a10cd2602ab87dc0d357113d054694b756a4e2e74ec181f0b0429a892e411b98f5b599be9b3fee26582dda2409469799c7019dbd592c5f3f36ed7ddf664fcfa673",
                ColumnTypeCode = "41393718b474479893218431c4f6f49a4b6faa057d2d4778a3",
                FormTypeCode = "ff8da3e8a33946838a7f014279c76456fd0421f9ebf940b0ac",
                SystemUse = true,
                ExtendedInformation = "4199eff627784a1fb653c8e034102f9ef989996cf2e7407996164385b4ea0554a221968c5d0a407cafc519a7c1d7f6187318a367bb9e44e3a52cf2dcf069eec8cf723b7438c74f89ba8ab5a680aabf9dbe68b7513a304b83bb191aa9e140278d47347c93d5764da898e712358b3b280395a327db7d1a4cd4a10797d5996135bcb143ba24b8c340e6987bd2906402ac38ae3550ce9bc4438098be345150afdcad71f2989209114620bf1c6a709484a33544b6be490c2a4d6188d2c22ee8b7cb18689b0d51e578420b843da9975a034e3d11c2029c12fc46509dcff6dbf9ad62ce7eb08530e55a4cd9b4eb8f88ff07ab60c71e292a0be049fcb23a",
                DateA = new DateTime(2013, 6, 12),
                DateD = new DateTime(2021, 4, 20),
                Sort = 1634179558,
                Note = "d38718a0722f4791bf4aa1a73d828f653a4a4ef9e1f54b909d976fbe648e0bdde849442dd34c4ca6a41b7964b2210d90d927c38a28a94b9fa7bbdfb069952dc602da7401c93c4f5aba11a9a99fdcdb4c6018156da1cd4fa78298396a798b6c25da89032c2c254bfa919263eac33b873ea93809cbecfb4e6ca856b0b6fe6dc78a959b6677e7c643a994f65a98e50175d047d36ce91024465db8cb32d08f1090f90d1feb6c59094fe8b25a1192b53e3ee0404743526ccc4a6b89f482baa7cf79242d3486eeb1934faead03117ebc9b318b38fee29e9ab647a5a4371820e31852de3072e7fe1a2246598751e8a66da7d01d2267da37196f48a8823e",
                Status = "f69af6b075084d498a4b6c718751c94af3609dce81d84430a1"
            };

            // Act
            var serviceResult = await _shareDefaultsAppService.CreateAsync(input);

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("bd4fff3143f14864b884b290ef7e56986775ae833d5e4c27be");
            result.Key1.ShouldBe("1d3bc271c90c4f9facca5cc691a946b9d4c938bc1cfb4a7fb4");
            result.Key2.ShouldBe("9ca37fc52303488b9c29f18ac7c4f4b0c37f9411d99a4df99d");
            result.Key3.ShouldBe("1a12a566c48b484eaab306f7823884f712302e790b6343808c");
            result.Name.ShouldBe("f5264df418304e178055c11fa40f2340581669a9b5fc428fac741664b59469fc99bb64627d3d417fbd70ddf60638be2fa1d26d9c13154a4781d0143d157ab85dd8ac89010fe54ba9946a49fa48a410721c4204eb61a7444eaec89abb1cb79d8928b99b4f");
            result.FieldKey.ShouldBe("8f3b11b3cdf64a72ad94264ab1b18562e7a4ade5e7ea417995");
            result.FieldValue.ShouldBe("2e3d47de64244da6bb38f46a7de762b02155762d0d984ba494127bebb9bb10f5b336eee32d0d4403b0a74e3d115c2af407dd279314124f22a89dfeff667bda72e8fad290d6c344ffb9de3a1a5823323fa271c5f82a8245fdb541da9a2ce6f6b335af4e58a3ed4be7923f60184c35e849bdc32e76eb944522a4f4993f1a3a2be4bd0504a534fc4cc1ab07e557189e81e4567b2ecdf8bd4fb59a4c08d115967af0975738ada1704086aac4a873f9eb62b23a49370d5dae443d89a10cd2602ab87dc0d357113d054694b756a4e2e74ec181f0b0429a892e411b98f5b599be9b3fee26582dda2409469799c7019dbd592c5f3f36ed7ddf664fcfa673");
            result.ColumnTypeCode.ShouldBe("41393718b474479893218431c4f6f49a4b6faa057d2d4778a3");
            result.FormTypeCode.ShouldBe("ff8da3e8a33946838a7f014279c76456fd0421f9ebf940b0ac");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("4199eff627784a1fb653c8e034102f9ef989996cf2e7407996164385b4ea0554a221968c5d0a407cafc519a7c1d7f6187318a367bb9e44e3a52cf2dcf069eec8cf723b7438c74f89ba8ab5a680aabf9dbe68b7513a304b83bb191aa9e140278d47347c93d5764da898e712358b3b280395a327db7d1a4cd4a10797d5996135bcb143ba24b8c340e6987bd2906402ac38ae3550ce9bc4438098be345150afdcad71f2989209114620bf1c6a709484a33544b6be490c2a4d6188d2c22ee8b7cb18689b0d51e578420b843da9975a034e3d11c2029c12fc46509dcff6dbf9ad62ce7eb08530e55a4cd9b4eb8f88ff07ab60c71e292a0be049fcb23a");
            result.DateA.ShouldBe(new DateTime(2013, 6, 12));
            result.DateD.ShouldBe(new DateTime(2021, 4, 20));
            result.Sort.ShouldBe(1634179558);
            result.Note.ShouldBe("d38718a0722f4791bf4aa1a73d828f653a4a4ef9e1f54b909d976fbe648e0bdde849442dd34c4ca6a41b7964b2210d90d927c38a28a94b9fa7bbdfb069952dc602da7401c93c4f5aba11a9a99fdcdb4c6018156da1cd4fa78298396a798b6c25da89032c2c254bfa919263eac33b873ea93809cbecfb4e6ca856b0b6fe6dc78a959b6677e7c643a994f65a98e50175d047d36ce91024465db8cb32d08f1090f90d1feb6c59094fe8b25a1192b53e3ee0404743526ccc4a6b89f482baa7cf79242d3486eeb1934faead03117ebc9b318b38fee29e9ab647a5a4371820e31852de3072e7fe1a2246598751e8a66da7d01d2267da37196f48a8823e");
            result.Status.ShouldBe("f69af6b075084d498a4b6c718751c94af3609dce81d84430a1");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareDefaultUpdateDto()
            {
                GroupCode = "a99a5baba28f41ba96ef4e48f965276e4da6491fd5154eac8b",
                Key1 = "5658d21b18544ac08a25c7fb7a04c8e5f8d2a431e43f41e3a1",
                Key2 = "22f63b1d417e476db2bfc3eb458ad30edf661f0e81dd4bf3ac",
                Key3 = "6032604b7d2a4e6f9781d0edeb870167b6566269323347c3ba",
                Name = "03f03f51afe44f90894d39c5973ede7e48ff11e01b234cf79b06d4af03721f08dc250a5bf6d84c48b67d5588ecc540cac9b273b4b4134093a5c42ad1af0c5e1b950a953440fb4d8b896c78d817c7c16a1280d4bafbb34f948ae434df257da030c5aa3ac6",
                FieldKey = "8c606a27c77d47e1b4dbf9a1892559ef878b794044804bc399",
                FieldValue = "14c9e076ba0d49039f7d4fb96482f8edeec7a45a83184d889436c582a2b062a7433c0d7e46a64ecb87fcbec582ab4a8e2555466cc0c640f6a65deae6642008e624cec16b0dff4b01a2de7e60c0dae065a0d375ead455413bbb81b746dec1704676f3f72979654624b290f87fd773b75b5ac3f110d7e04279ac27582b294e35dc185c45d1d3d14d7fad33ed7b66123f9bcddb5ef392474202883cb874973a57495be67210a89248de95d404dca094551bf536ba952b004b8ba16c83753b24c2aaf335435455ce4e6e8f66c37d7f623a7e3d912454163848b8a99f7519921414633ecd62876c92424098a6789255a34ebe3a55175e0b7d4b39ab26",
                ColumnTypeCode = "e1be13a2559b4de4a825ee811805413897d7a86efd4541128d",
                FormTypeCode = "83db9a6e063449b8af315d58c786b9e54f3b7eb198ba42cfa8",
                SystemUse = true,
                ExtendedInformation = "55352aa0bfe44e4d928552db2bdb0cf0f4cbddeab1384d91a43393ba019903d66c0f5f9d172b46f5b85439c4aef2d8f6735d0bbb1c644b0e9cc45ec155c9cc885aca5792d7d74b4c8bd6dd935c09dd77dddbcbc961664631aeab44c109057ad4945e54095f6e48ffb57ad66f9ccdf43d8eb1a35a4e0c42f3a109e216166010ae3eec8f2454e84d6bad8e50463a6de5cff0fd4673e60b4f0cafa6dcf0b04b32586d9329f8fa2543408084ab58b2c5f8a87e2596a7186a4fb984c81f79d7f8d50c1b34266e063c4692a77abd4f8fc5102de47fc8b8fae74f8c8830ea734a9df0a1e72839fa255a4857b24d97c3ad0630b234ab1c8e3ebc41df958f",
                DateA = new DateTime(2016, 7, 25),
                DateD = new DateTime(2014, 4, 21),
                Sort = 1453768787,
                Note = "9922518445b94fdb98798d356a076ff1a4a07c8d99a9413082e362be249ef2a9c6c9d1ca7db4412baa358ea9fe02c92833e07cdb251345178e1094df954b2b52c386ac845aa449b8a7c2fc47208eb49ba031e4100a1f4a28bfed13abc6a73db525e6fb6022784bd8a198885c62654b6176f53eda0b5340ee94d2f81ffa582db50d9b8d90515d47ba806f96bf5e592172aeee2e7c5a464c869fde82064734de5bc911b8adab4d4052bea23fe01d966b68c84bcff2b8d341d7a6d33c449524db9ed087d890d9784dafa4274602ea86ca034af03e66f0c94105bd35170adcb130bbc18596b963c042e9b5462df0130054dfb24a33f2f431417c91d5",
                Status = "103a67dc178542b2aa3523417442568fc528dac5ae7b4242b4"
            };

            // Act
            var serviceResult = await _shareDefaultsAppService.UpdateAsync(Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"), input);

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("a99a5baba28f41ba96ef4e48f965276e4da6491fd5154eac8b");
            result.Key1.ShouldBe("5658d21b18544ac08a25c7fb7a04c8e5f8d2a431e43f41e3a1");
            result.Key2.ShouldBe("22f63b1d417e476db2bfc3eb458ad30edf661f0e81dd4bf3ac");
            result.Key3.ShouldBe("6032604b7d2a4e6f9781d0edeb870167b6566269323347c3ba");
            result.Name.ShouldBe("03f03f51afe44f90894d39c5973ede7e48ff11e01b234cf79b06d4af03721f08dc250a5bf6d84c48b67d5588ecc540cac9b273b4b4134093a5c42ad1af0c5e1b950a953440fb4d8b896c78d817c7c16a1280d4bafbb34f948ae434df257da030c5aa3ac6");
            result.FieldKey.ShouldBe("8c606a27c77d47e1b4dbf9a1892559ef878b794044804bc399");
            result.FieldValue.ShouldBe("14c9e076ba0d49039f7d4fb96482f8edeec7a45a83184d889436c582a2b062a7433c0d7e46a64ecb87fcbec582ab4a8e2555466cc0c640f6a65deae6642008e624cec16b0dff4b01a2de7e60c0dae065a0d375ead455413bbb81b746dec1704676f3f72979654624b290f87fd773b75b5ac3f110d7e04279ac27582b294e35dc185c45d1d3d14d7fad33ed7b66123f9bcddb5ef392474202883cb874973a57495be67210a89248de95d404dca094551bf536ba952b004b8ba16c83753b24c2aaf335435455ce4e6e8f66c37d7f623a7e3d912454163848b8a99f7519921414633ecd62876c92424098a6789255a34ebe3a55175e0b7d4b39ab26");
            result.ColumnTypeCode.ShouldBe("e1be13a2559b4de4a825ee811805413897d7a86efd4541128d");
            result.FormTypeCode.ShouldBe("83db9a6e063449b8af315d58c786b9e54f3b7eb198ba42cfa8");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("55352aa0bfe44e4d928552db2bdb0cf0f4cbddeab1384d91a43393ba019903d66c0f5f9d172b46f5b85439c4aef2d8f6735d0bbb1c644b0e9cc45ec155c9cc885aca5792d7d74b4c8bd6dd935c09dd77dddbcbc961664631aeab44c109057ad4945e54095f6e48ffb57ad66f9ccdf43d8eb1a35a4e0c42f3a109e216166010ae3eec8f2454e84d6bad8e50463a6de5cff0fd4673e60b4f0cafa6dcf0b04b32586d9329f8fa2543408084ab58b2c5f8a87e2596a7186a4fb984c81f79d7f8d50c1b34266e063c4692a77abd4f8fc5102de47fc8b8fae74f8c8830ea734a9df0a1e72839fa255a4857b24d97c3ad0630b234ab1c8e3ebc41df958f");
            result.DateA.ShouldBe(new DateTime(2016, 7, 25));
            result.DateD.ShouldBe(new DateTime(2014, 4, 21));
            result.Sort.ShouldBe(1453768787);
            result.Note.ShouldBe("9922518445b94fdb98798d356a076ff1a4a07c8d99a9413082e362be249ef2a9c6c9d1ca7db4412baa358ea9fe02c92833e07cdb251345178e1094df954b2b52c386ac845aa449b8a7c2fc47208eb49ba031e4100a1f4a28bfed13abc6a73db525e6fb6022784bd8a198885c62654b6176f53eda0b5340ee94d2f81ffa582db50d9b8d90515d47ba806f96bf5e592172aeee2e7c5a464c869fde82064734de5bc911b8adab4d4052bea23fe01d966b68c84bcff2b8d341d7a6d33c449524db9ed087d890d9784dafa4274602ea86ca034af03e66f0c94105bd35170adcb130bbc18596b963c042e9b5462df0130054dfb24a33f2f431417c91d5");
            result.Status.ShouldBe("103a67dc178542b2aa3523417442568fc528dac5ae7b4242b4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareDefaultsAppService.DeleteAsync(Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"));

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"));

            result.ShouldBeNull();
        }
    }
}