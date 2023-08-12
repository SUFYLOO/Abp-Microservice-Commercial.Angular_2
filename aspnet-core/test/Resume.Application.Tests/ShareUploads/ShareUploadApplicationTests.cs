using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareUploads
{
    public class ShareUploadsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareUploadsAppService _shareUploadsAppService;
        private readonly IRepository<ShareUpload, Guid> _shareUploadRepository;

        public ShareUploadsAppServiceTests()
        {
            _shareUploadsAppService = GetRequiredService<IShareUploadsAppService>();
            _shareUploadRepository = GetRequiredService<IRepository<ShareUpload, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareUploadsAppService.GetListAsync(new GetShareUploadsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("7cc6042b-4732-4f1d-9ee2-e8b720bef084")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareUploadsAppService.GetAsync(Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareUploadCreateDto
            {
                Key1 = "3ea42ba00d7a4fbb8dd782c1e455a7b0d3502105e5504120aa",
                Key2 = "914859298bab43de977813d2816b9376b816b28d347d4dc6b2",
                Key3 = "ab1be832817040cca5d3ccf01dba2cda367c3ee064f544dd95",
                UploadName = "fc641599fa52404cbdf628708cc45d10cf977b79edff4ca89a6772b030d775271ba86ef08a38457ca64d985db39b5d66dd2bdcbdea594dceaec40e1fc5229e31db0a47f4c09d47b4967a7cee55ed02e0051a86d1be4a448ebebdafea7979f22e0985addb",
                ServerName = "64677ba949e64143abdda52d861a9b5a7a0466c083494f87bcaf767a20be7383bb274c919beb4b0b8183617bd09c48a2c6388b0d9d4b4127ad0d0198f2ea60d45ed5efbe4f3c43d196c6beb96a9c889d64c41da524a746898d133089aec7a19a858d05fe",
                Type = "8e73ae8bcc0c4f35895c037fd535a599e84391fda7b74b048cee12ce79d344e9154333e8eb744c58b5f5315166662fe5b2c289a0ccb549558bcd261d0a95ce0702327f1f6ad24a0ea28a5f26aafd8aecec2cd699c94a47c2858b19be844c166b2cf130de",
                Size = 384760318,
                SystemUse = true,
                ExtendedInformation = "4100dcdb60ab43a990f8696d91d27edd03cecce9624d4edca66167475667e2fe83a9297124614a72af4f92577fa78e4608caa59853b64e00a836013483425391ba8482c4977749c0bb2412ce6843a507286fde59bf9e43b098fd1a1b32cb18dd1153672e92fc4f23b63c5635d5006cffb23fd261e64a4a5b88400ef10adff9ef752fb5223917466db9531ad353f49300a85f40c981104620976797c1ca5dc9a4d0738fe5d62a4f3291e0e2faa811f9d822f07f6b6f5b4209a473749e3466f3c631637720405a45e4a875e94b8ca7ea11ff51a32afd694c75bc27e60093148969774267e5b5704434aed827c4a934f42f25be21ccc68d47aabd12",
                DateA = new DateTime(2016, 4, 3),
                DateD = new DateTime(2007, 4, 3),
                Sort = 1996152600,
                Note = "7b181b0d137b42d58f2c68521af32a01268d3b56a33749d2b6ee09d804790a94771bfa1f34a3438a803ecdaaa4b0a9e38c65bbc506fc4ef9bcdf297efc5794fece43e21df98b46a2bed42e436c71b0ee21ce38f3178e4b389d0f5b9eccaf32b543d3333bfd74468f91c87ed4607f7fccb786690c67b34003bcf38f901743e650e12e28a24ea84aefb8ee44e571a1edaeaceeb91f7e694ed097ab3cd574c73aa4c6d688a3a482467e9b9ce27333e5c42ab8292f439d4b4e2dbda358ffc4c4db625847ba51bb1f4885a5b2b3f25a5f0d263e40741ff554409b92474ccf40936ac2b15b35b98a8b42e797637d4a513ef13cad9f72f5c0b14f329dcb",
                Status = "c9fa192dc7ee442c8e0fe35388823f467d394fb54962452da4"
            };

            // Act
            var serviceResult = await _shareUploadsAppService.CreateAsync(input);

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("3ea42ba00d7a4fbb8dd782c1e455a7b0d3502105e5504120aa");
            result.Key2.ShouldBe("914859298bab43de977813d2816b9376b816b28d347d4dc6b2");
            result.Key3.ShouldBe("ab1be832817040cca5d3ccf01dba2cda367c3ee064f544dd95");
            result.UploadName.ShouldBe("fc641599fa52404cbdf628708cc45d10cf977b79edff4ca89a6772b030d775271ba86ef08a38457ca64d985db39b5d66dd2bdcbdea594dceaec40e1fc5229e31db0a47f4c09d47b4967a7cee55ed02e0051a86d1be4a448ebebdafea7979f22e0985addb");
            result.ServerName.ShouldBe("64677ba949e64143abdda52d861a9b5a7a0466c083494f87bcaf767a20be7383bb274c919beb4b0b8183617bd09c48a2c6388b0d9d4b4127ad0d0198f2ea60d45ed5efbe4f3c43d196c6beb96a9c889d64c41da524a746898d133089aec7a19a858d05fe");
            result.Type.ShouldBe("8e73ae8bcc0c4f35895c037fd535a599e84391fda7b74b048cee12ce79d344e9154333e8eb744c58b5f5315166662fe5b2c289a0ccb549558bcd261d0a95ce0702327f1f6ad24a0ea28a5f26aafd8aecec2cd699c94a47c2858b19be844c166b2cf130de");
            result.Size.ShouldBe(384760318);
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("4100dcdb60ab43a990f8696d91d27edd03cecce9624d4edca66167475667e2fe83a9297124614a72af4f92577fa78e4608caa59853b64e00a836013483425391ba8482c4977749c0bb2412ce6843a507286fde59bf9e43b098fd1a1b32cb18dd1153672e92fc4f23b63c5635d5006cffb23fd261e64a4a5b88400ef10adff9ef752fb5223917466db9531ad353f49300a85f40c981104620976797c1ca5dc9a4d0738fe5d62a4f3291e0e2faa811f9d822f07f6b6f5b4209a473749e3466f3c631637720405a45e4a875e94b8ca7ea11ff51a32afd694c75bc27e60093148969774267e5b5704434aed827c4a934f42f25be21ccc68d47aabd12");
            result.DateA.ShouldBe(new DateTime(2016, 4, 3));
            result.DateD.ShouldBe(new DateTime(2007, 4, 3));
            result.Sort.ShouldBe(1996152600);
            result.Note.ShouldBe("7b181b0d137b42d58f2c68521af32a01268d3b56a33749d2b6ee09d804790a94771bfa1f34a3438a803ecdaaa4b0a9e38c65bbc506fc4ef9bcdf297efc5794fece43e21df98b46a2bed42e436c71b0ee21ce38f3178e4b389d0f5b9eccaf32b543d3333bfd74468f91c87ed4607f7fccb786690c67b34003bcf38f901743e650e12e28a24ea84aefb8ee44e571a1edaeaceeb91f7e694ed097ab3cd574c73aa4c6d688a3a482467e9b9ce27333e5c42ab8292f439d4b4e2dbda358ffc4c4db625847ba51bb1f4885a5b2b3f25a5f0d263e40741ff554409b92474ccf40936ac2b15b35b98a8b42e797637d4a513ef13cad9f72f5c0b14f329dcb");
            result.Status.ShouldBe("c9fa192dc7ee442c8e0fe35388823f467d394fb54962452da4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareUploadUpdateDto()
            {
                Key1 = "1884f148634549e6b3c7852f5de53f8eaa39c60d609145d2a9",
                Key2 = "da4a1efd961c4c5689582074423c9e1511d9584c75b140f1be",
                Key3 = "1c18bacafb884d73ac998938b5fd90479b0e5df394e7424fb2",
                UploadName = "7a81a3b064464cc1b67e7016cc25cdb13c836dda41714044a625fd20c4b29de63318c138b9044132ade0c5923f3e21e7c7d986fc53394eebbc21c7ea9259a59c35605937475a4fb1940f25987abb49eef6ce031a074842d182a7694dd29f38f7dcc66b87",
                ServerName = "788fe53346554df981a0d90d92831b4ae4a2c3cbe01c4e89b53b4afc8b25dcdcd317326451b4455ab38dc484b0a0614a5b3ce94496264bf386865839ee65628b5c2d707cd03c4b18a79c49a4cad463527a759e1c6918492f92b30b168b96b25f82e573bd",
                Type = "5d0e0a6760a0490aa8c666b9895acd516874c15219d94b3d8e35d27848cc9ffcd8423ac6daab49f1835aedbd027c01506a7b648829fa4a78b1884bce34352f177689e2e1462e411cbdcdf2d9ead1cf262496ee2b868e4c7c8fc4c513115a3591b77ba900",
                Size = 491842591,
                SystemUse = true,
                ExtendedInformation = "4462b1e6d0fc4b30b42e5af6bd6ef849f25be4e0c4d04258a51116e6272659d592d11235b8c4402e9eb5ef03c7c24ad699ac572449cf4eb09414dcc0440296502d865e03915348179cd59fba7d1a452a0699580e892a43ce86cf3e11a6d263352c1eef5c9b75477da9b63ad3391a05044907ccdf31a1458f850e544db22304c7b425b5dcccde4ba9b7fdddff95e9df7936f2f71e0254429d864839df5138158363ffb641f8fd4174921631d4808ca0bc5e77f8caf96f49a58d3cd6985dc298b7925a5503702c4ad5a03f21cfed6c4520dc3170a4dd46438d8cd6d1994c094cf65d01bb721ee446d28827cf6614544f1addee71a8177b4cba9303",
                DateA = new DateTime(2013, 7, 15),
                DateD = new DateTime(2016, 2, 2),
                Sort = 52285524,
                Note = "99be5b0f9c634e44834fd9a07a5840daf19473664ea54ec9b4599baef218594dc0d6e619ecdb45e59d0b8dbd9c6aa65f7be3d15105e240bdbbf3deced075ee5a13b0cc37097f4fddb15770bafcd1c199a2c9401f2c79436c8f6df8c7a58d0e24388615783b7d43a882bbfef98f70921aac3c5c2e91fb49ca9a2e9a4e8d7aa519bc96b87ad72a49d9ab3bdef7dd319602cc461652f08344cdbcee8d2130f66b51cff25ebd75294538968af15b9c9e94e384617526d8ca4b7f86e1e908286754f84dbc4ee63bad46a180e2b1ddffcb39f2d83f0b8128884a24bd11f507f3c3c7fe16eca0c2b4114b2f932170f8305fe88d1d2c0c4910194afdb9ea",
                Status = "a7f90653b9114fbab966bca6e5741c126fce81d1cdc04a48ba"
            };

            // Act
            var serviceResult = await _shareUploadsAppService.UpdateAsync(Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"), input);

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("1884f148634549e6b3c7852f5de53f8eaa39c60d609145d2a9");
            result.Key2.ShouldBe("da4a1efd961c4c5689582074423c9e1511d9584c75b140f1be");
            result.Key3.ShouldBe("1c18bacafb884d73ac998938b5fd90479b0e5df394e7424fb2");
            result.UploadName.ShouldBe("7a81a3b064464cc1b67e7016cc25cdb13c836dda41714044a625fd20c4b29de63318c138b9044132ade0c5923f3e21e7c7d986fc53394eebbc21c7ea9259a59c35605937475a4fb1940f25987abb49eef6ce031a074842d182a7694dd29f38f7dcc66b87");
            result.ServerName.ShouldBe("788fe53346554df981a0d90d92831b4ae4a2c3cbe01c4e89b53b4afc8b25dcdcd317326451b4455ab38dc484b0a0614a5b3ce94496264bf386865839ee65628b5c2d707cd03c4b18a79c49a4cad463527a759e1c6918492f92b30b168b96b25f82e573bd");
            result.Type.ShouldBe("5d0e0a6760a0490aa8c666b9895acd516874c15219d94b3d8e35d27848cc9ffcd8423ac6daab49f1835aedbd027c01506a7b648829fa4a78b1884bce34352f177689e2e1462e411cbdcdf2d9ead1cf262496ee2b868e4c7c8fc4c513115a3591b77ba900");
            result.Size.ShouldBe(491842591);
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("4462b1e6d0fc4b30b42e5af6bd6ef849f25be4e0c4d04258a51116e6272659d592d11235b8c4402e9eb5ef03c7c24ad699ac572449cf4eb09414dcc0440296502d865e03915348179cd59fba7d1a452a0699580e892a43ce86cf3e11a6d263352c1eef5c9b75477da9b63ad3391a05044907ccdf31a1458f850e544db22304c7b425b5dcccde4ba9b7fdddff95e9df7936f2f71e0254429d864839df5138158363ffb641f8fd4174921631d4808ca0bc5e77f8caf96f49a58d3cd6985dc298b7925a5503702c4ad5a03f21cfed6c4520dc3170a4dd46438d8cd6d1994c094cf65d01bb721ee446d28827cf6614544f1addee71a8177b4cba9303");
            result.DateA.ShouldBe(new DateTime(2013, 7, 15));
            result.DateD.ShouldBe(new DateTime(2016, 2, 2));
            result.Sort.ShouldBe(52285524);
            result.Note.ShouldBe("99be5b0f9c634e44834fd9a07a5840daf19473664ea54ec9b4599baef218594dc0d6e619ecdb45e59d0b8dbd9c6aa65f7be3d15105e240bdbbf3deced075ee5a13b0cc37097f4fddb15770bafcd1c199a2c9401f2c79436c8f6df8c7a58d0e24388615783b7d43a882bbfef98f70921aac3c5c2e91fb49ca9a2e9a4e8d7aa519bc96b87ad72a49d9ab3bdef7dd319602cc461652f08344cdbcee8d2130f66b51cff25ebd75294538968af15b9c9e94e384617526d8ca4b7f86e1e908286754f84dbc4ee63bad46a180e2b1ddffcb39f2d83f0b8128884a24bd11f507f3c3c7fe16eca0c2b4114b2f932170f8305fe88d1d2c0c4910194afdb9ea");
            result.Status.ShouldBe("a7f90653b9114fbab966bca6e5741c126fce81d1cdc04a48ba");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareUploadsAppService.DeleteAsync(Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"));

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == Guid.Parse("fb3826fa-de51-4f7d-88b8-b1212da6d62c"));

            result.ShouldBeNull();
        }
    }
}