using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareTags
{
    public class ShareTagsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareTagsAppService _shareTagsAppService;
        private readonly IRepository<ShareTag, Guid> _shareTagRepository;

        public ShareTagsAppServiceTests()
        {
            _shareTagsAppService = GetRequiredService<IShareTagsAppService>();
            _shareTagRepository = GetRequiredService<IRepository<ShareTag, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareTagsAppService.GetListAsync(new GetShareTagsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("bee2c53c-006a-454e-9af6-871eba4282d0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareTagsAppService.GetAsync(Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareTagCreateDto
            {
                ColorCode = "fd86f37b0b9f45738dc67f2e57c4f00a00c9a505ec344e93b7",
                Key1 = "64239a5f71194adba11b8ddc973e60284b9453f4960541a993",
                Key2 = "b76b6361a2204c3db935f3883621454b291ef5d479864444bf",
                Key3 = "0d0417cb542d46da89b173de1b9b017b46ea1949408e4dea97",
                Name = "a18c6eb9ec59434b9403a71c18074caab155dc45f9574472be3620d04c247f7de685b45d9386461da25e6df0d9e0f6073a3dfebbbdf249cf8e9244fd3a3aeb4337f65308353d4c68bda00274fba3290b313ca16c3a0940f9b02c43cffde6c14716a06e0281274873a8b7797e71d516aac33535136af54c9eb9c7e9899987b7963bd220f51bf542c9bdbab66e25eebfba57862f1e79514a12b8fb1f99815f057fa3d4196ba5864e3cb8a617f99fc11affa757b224f923421fa34f919d4992eac64ac5c79f46c548b69938ae94cd98a0f1b11f93160ec041fd9731183757ec212dfa5f953d32834a79be20790315d2d507c46df818b7ae4062b1e3",
                TagCategoryCode = "513a16aaaec8458387d6b6e6bc9df99e0481b265b8d549a4a4",
                ExtendedInformation = "c36f71e41f0148daafe18156b2b8e14314cd2dfc7d1c4fcea6736556b14ccb514263516ca41246488433593510e61b66fa2666b9107449c58a50eb48932ad9a95e41d4e664e040babc77a645734376c7183ff645f8974c3d97fade6cefc711c76b903a4b06fc4114ba5b12c67cc23766e849203a5af347c2875b5ceb17782889988c4498f15c4d2a8d98c342fbe43bbc60e7e07e5d594975b0593cb19636c5e3001e8684c12a4c21ae19c7b9aa7f3ee906d4e6621add44b5b000d1103edda8c76a5cb177442040ffbff9625946e3c1deacb7a0c6f40e450cb1fa45905390dcbae13e69472bff4859b9fa306f89d0f3d31110ababeb014776b94f",
                DateA = new DateTime(2006, 2, 12),
                DateD = new DateTime(2020, 6, 13),
                Sort = 185995492,
                Note = "dbdfc122c41b41ffa4f00b981b36064007216bf19cad48b4921db48d76d16de6c90536a01aa942f385f226af2e155b5ccea86d9e259449dfbf93f8e47e546bba5618e69776b549c1a39b71676139b32dc4af35b6b2304f14aa9cc0f25af635cc111d17d809124f599cbddd0dd46827dcae1afb5ec63046408595676510099c811e093193e023464aacce7682fda2075c09e1762a8fd8411f8ed708e2f244e0cf6a42e56cb17f434ca35252cfcd969862246657eae3df498589745c1a5563676ea8e1bb0790164482b6ffca2bf2b3dc689f66cce466cf4023a14bd617117143c7d8b32a3eb7b0416f8b5500cd59080daa67c190003ea743f69811",
                Status = "b85a3ac443214c1d8d76dc7261c0d1130597d604c7e544dd8a"
            };

            // Act
            var serviceResult = await _shareTagsAppService.CreateAsync(input);

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ColorCode.ShouldBe("fd86f37b0b9f45738dc67f2e57c4f00a00c9a505ec344e93b7");
            result.Key1.ShouldBe("64239a5f71194adba11b8ddc973e60284b9453f4960541a993");
            result.Key2.ShouldBe("b76b6361a2204c3db935f3883621454b291ef5d479864444bf");
            result.Key3.ShouldBe("0d0417cb542d46da89b173de1b9b017b46ea1949408e4dea97");
            result.Name.ShouldBe("a18c6eb9ec59434b9403a71c18074caab155dc45f9574472be3620d04c247f7de685b45d9386461da25e6df0d9e0f6073a3dfebbbdf249cf8e9244fd3a3aeb4337f65308353d4c68bda00274fba3290b313ca16c3a0940f9b02c43cffde6c14716a06e0281274873a8b7797e71d516aac33535136af54c9eb9c7e9899987b7963bd220f51bf542c9bdbab66e25eebfba57862f1e79514a12b8fb1f99815f057fa3d4196ba5864e3cb8a617f99fc11affa757b224f923421fa34f919d4992eac64ac5c79f46c548b69938ae94cd98a0f1b11f93160ec041fd9731183757ec212dfa5f953d32834a79be20790315d2d507c46df818b7ae4062b1e3");
            result.TagCategoryCode.ShouldBe("513a16aaaec8458387d6b6e6bc9df99e0481b265b8d549a4a4");
            result.ExtendedInformation.ShouldBe("c36f71e41f0148daafe18156b2b8e14314cd2dfc7d1c4fcea6736556b14ccb514263516ca41246488433593510e61b66fa2666b9107449c58a50eb48932ad9a95e41d4e664e040babc77a645734376c7183ff645f8974c3d97fade6cefc711c76b903a4b06fc4114ba5b12c67cc23766e849203a5af347c2875b5ceb17782889988c4498f15c4d2a8d98c342fbe43bbc60e7e07e5d594975b0593cb19636c5e3001e8684c12a4c21ae19c7b9aa7f3ee906d4e6621add44b5b000d1103edda8c76a5cb177442040ffbff9625946e3c1deacb7a0c6f40e450cb1fa45905390dcbae13e69472bff4859b9fa306f89d0f3d31110ababeb014776b94f");
            result.DateA.ShouldBe(new DateTime(2006, 2, 12));
            result.DateD.ShouldBe(new DateTime(2020, 6, 13));
            result.Sort.ShouldBe(185995492);
            result.Note.ShouldBe("dbdfc122c41b41ffa4f00b981b36064007216bf19cad48b4921db48d76d16de6c90536a01aa942f385f226af2e155b5ccea86d9e259449dfbf93f8e47e546bba5618e69776b549c1a39b71676139b32dc4af35b6b2304f14aa9cc0f25af635cc111d17d809124f599cbddd0dd46827dcae1afb5ec63046408595676510099c811e093193e023464aacce7682fda2075c09e1762a8fd8411f8ed708e2f244e0cf6a42e56cb17f434ca35252cfcd969862246657eae3df498589745c1a5563676ea8e1bb0790164482b6ffca2bf2b3dc689f66cce466cf4023a14bd617117143c7d8b32a3eb7b0416f8b5500cd59080daa67c190003ea743f69811");
            result.Status.ShouldBe("b85a3ac443214c1d8d76dc7261c0d1130597d604c7e544dd8a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareTagUpdateDto()
            {
                ColorCode = "c975fa5eb0ce44f0b035dc151528402472cb2465bc7542c592",
                Key1 = "6da2096fd35e4d32b6db0f542ad394070fde49f314544f509a",
                Key2 = "6e621d35347a4176a5b3e9848a92b114e6e6aa721869494bb2",
                Key3 = "516e1582b92740c5bd6d2c57a4d72e30ced2c5f0bc864a6baf",
                Name = "1e045b513012447a97eace8948e4cf693b24103256b44d1fa2d9c8180e4af7bf729c8b7ebaae4ee999c9d32821bcc71028ed0cc0d7cf44dd90da5bb445675fc0ece03c8b136f43a5ac7c7941f40ef4b50f6ab31e558941bdab0a491d26a8a8d6174b7ccf07334c3d9aa0917f555b4304606d924aded9430c9639f252ea3162e1d5fd41417759439e821772bc620e9ced0dbb73377292409d9096b8de2374bcb5731f6b662a2e47f884b5674018a99747e6102e5f839d4f8fb3508cf85e6e55cd5f4fdae00c604b3da15ec015e859c65eab26056dd3dc4ff9965e66e1a4ff1a243c3d9193c38c49a9a761ddab980a8a4d1a6d90fe87cc450e9932",
                TagCategoryCode = "4623f20267bf46dd8a8ce971e317f3886de886e7bfca4487bf",
                ExtendedInformation = "7a97819ae3474530a34a611836a7eaf1991561e30cc94cb9bd1ecb5dfc8af01ed410c8701feb4de6bbb4e0e182de6851d033b1831d454a348e939acdfb3aae45f460f32ef6b54f8b96344ee4b89bf40cdd507726acc046ac89db6e6c34adf80e34539cf20dd841b2af00b01f38746e2b66fa5c2158174af9850fdd8c775019cb3236af6f3ee24c5d88358677174dc69b9c64fdf140764280a5bbcf456ac2ddbcac2359141a564ec499f3de6e117ad82db0d650674a924d3081a67c4da17f93692d415e49a8404e779ed20f4f71dad416d0d6a230be1442e3a9a86d63f8ca5a9c23763e19a59c45fcab3187221e79f0bc5451c7c14c854dfc9a1c",
                DateA = new DateTime(2013, 6, 26),
                DateD = new DateTime(2001, 7, 27),
                Sort = 87343604,
                Note = "a2d9266a1eab4befb151b3ea07d7fc6ce8bbacb74aa142999e993bb596938adc3f88a077abd94ff0829e27cade1a2220d813de03d8e545258a7e7da3bd3843a2cf25dfb2a43b4719bdf2a7af1d9f3204605a117d78ad47fc98c2c177e64738252e52d4d37ebe4d68b41323a59d82c67acd80f55096684b74819c55b2c027d3c1ba94e78b36014c418f6bb592cac44b3bf663550d27a04ba887a0ef9ac5c1e761c8746f89d3d4411c855e2d2ba4ca94d3990760cc486945708a8d7ac87b020eafddf59e3e387846df8f2a5a5bf8c5236e10a1bb1147694d60aa9536d0c09839877a42d413ec2d4e62946419cb79b344df936ad477ae82428c9f67",
                Status = "7a7ddba44e224814b69f9a157f8b36aba3996f3537e2460690"
            };

            // Act
            var serviceResult = await _shareTagsAppService.UpdateAsync(Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"), input);

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ColorCode.ShouldBe("c975fa5eb0ce44f0b035dc151528402472cb2465bc7542c592");
            result.Key1.ShouldBe("6da2096fd35e4d32b6db0f542ad394070fde49f314544f509a");
            result.Key2.ShouldBe("6e621d35347a4176a5b3e9848a92b114e6e6aa721869494bb2");
            result.Key3.ShouldBe("516e1582b92740c5bd6d2c57a4d72e30ced2c5f0bc864a6baf");
            result.Name.ShouldBe("1e045b513012447a97eace8948e4cf693b24103256b44d1fa2d9c8180e4af7bf729c8b7ebaae4ee999c9d32821bcc71028ed0cc0d7cf44dd90da5bb445675fc0ece03c8b136f43a5ac7c7941f40ef4b50f6ab31e558941bdab0a491d26a8a8d6174b7ccf07334c3d9aa0917f555b4304606d924aded9430c9639f252ea3162e1d5fd41417759439e821772bc620e9ced0dbb73377292409d9096b8de2374bcb5731f6b662a2e47f884b5674018a99747e6102e5f839d4f8fb3508cf85e6e55cd5f4fdae00c604b3da15ec015e859c65eab26056dd3dc4ff9965e66e1a4ff1a243c3d9193c38c49a9a761ddab980a8a4d1a6d90fe87cc450e9932");
            result.TagCategoryCode.ShouldBe("4623f20267bf46dd8a8ce971e317f3886de886e7bfca4487bf");
            result.ExtendedInformation.ShouldBe("7a97819ae3474530a34a611836a7eaf1991561e30cc94cb9bd1ecb5dfc8af01ed410c8701feb4de6bbb4e0e182de6851d033b1831d454a348e939acdfb3aae45f460f32ef6b54f8b96344ee4b89bf40cdd507726acc046ac89db6e6c34adf80e34539cf20dd841b2af00b01f38746e2b66fa5c2158174af9850fdd8c775019cb3236af6f3ee24c5d88358677174dc69b9c64fdf140764280a5bbcf456ac2ddbcac2359141a564ec499f3de6e117ad82db0d650674a924d3081a67c4da17f93692d415e49a8404e779ed20f4f71dad416d0d6a230be1442e3a9a86d63f8ca5a9c23763e19a59c45fcab3187221e79f0bc5451c7c14c854dfc9a1c");
            result.DateA.ShouldBe(new DateTime(2013, 6, 26));
            result.DateD.ShouldBe(new DateTime(2001, 7, 27));
            result.Sort.ShouldBe(87343604);
            result.Note.ShouldBe("a2d9266a1eab4befb151b3ea07d7fc6ce8bbacb74aa142999e993bb596938adc3f88a077abd94ff0829e27cade1a2220d813de03d8e545258a7e7da3bd3843a2cf25dfb2a43b4719bdf2a7af1d9f3204605a117d78ad47fc98c2c177e64738252e52d4d37ebe4d68b41323a59d82c67acd80f55096684b74819c55b2c027d3c1ba94e78b36014c418f6bb592cac44b3bf663550d27a04ba887a0ef9ac5c1e761c8746f89d3d4411c855e2d2ba4ca94d3990760cc486945708a8d7ac87b020eafddf59e3e387846df8f2a5a5bf8c5236e10a1bb1147694d60aa9536d0c09839877a42d413ec2d4e62946419cb79b344df936ad477ae82428c9f67");
            result.Status.ShouldBe("7a7ddba44e224814b69f9a157f8b36aba3996f3537e2460690");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareTagsAppService.DeleteAsync(Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"));

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"));

            result.ShouldBeNull();
        }
    }
}