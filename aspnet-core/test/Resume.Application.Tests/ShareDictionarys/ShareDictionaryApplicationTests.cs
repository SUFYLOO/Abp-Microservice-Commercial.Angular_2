using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareDictionarys
{
    public class ShareDictionarysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareDictionarysAppService _shareDictionarysAppService;
        private readonly IRepository<ShareDictionary, Guid> _shareDictionaryRepository;

        public ShareDictionarysAppServiceTests()
        {
            _shareDictionarysAppService = GetRequiredService<IShareDictionarysAppService>();
            _shareDictionaryRepository = GetRequiredService<IRepository<ShareDictionary, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareDictionarysAppService.GetListAsync(new GetShareDictionarysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("644513bf-4097-4d02-ae71-1210bfcfb085")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareDictionarysAppService.GetAsync(Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareDictionaryCreateDto
            {
                ShareLanguageId = Guid.Parse("43e2121a-2d0e-490c-bd98-9adc907227ac"),
                ShareTagId = Guid.Parse("da828e94-8bb3-404c-a6a7-36b8641048f3"),
                Key1 = "a8aa5f3c359b4414be50ac1463ed0c13ec198d37f1e24d5797",
                Key2 = "92e5a5223d284efda3560e8c3367adb6574f1d2c86f64e2b88",
                Key3 = "9b5a0d505ba54446873b4c9bb351cd325dda257ebf964552bb",
                Name = "78fd41a664f945968424884a282454dc607094e713884db0bc4f8e894b48f9eee45ec0a7a9ed4031be89c16947a9ce016d46911899a64458879d8f46134e932f3851933f7d134011a9df2531f6c5ecd921a5309e6d404d2e81a707dcbafd47570d5ce015",
                ExtendedInformation = "df1bdf2933da4478b226e7cd0cecdc6e8cefa3b33ca54261b3c1f16e00b34d52e379ab03a8d94bf280826e1c698efe43d6aec5d725b64eac9ee4d054ba366380fc1c5cbcf671485a9b32e9a2ed600599707f4466f4d34f1892580653c88e4cb72a35793f98bf4d36b8ebc41a1cf9d0f1256808ce0fd74823ab2ceaf9679e7db02ede17a059f8447186eb70623244f5e7e76858dd14d449fa813a19ca96247fca162b9265ba074580b3e41ffddaf2f252c2b26855f1a540e49802b6f626c857e26f19dc93231b4ca9b86f30fbe7ed79a0fab419edb43e408c93908f03dcc563f73a57ea1a82ff4e52ae5b09418c2e75d2946906d6534a45cc8222",
                DateA = new DateTime(2007, 1, 4),
                DateD = new DateTime(2022, 11, 2),
                Sort = 2070417253,
                Note = "f9b5ead7a4ff42428e55a820692987659f8e6389a11341b2ba52f7adbb0fe1a02e7eed517229453fb18cd7f4a30ed0566eb00ba5bc1c4820ac235b9d68a40cec7728fd72cc394f76a9d4ae30d8b965c0afcc6c92806b4f97a779a9b84dd263d960a6e72ba47f4ce986081025cda0b13fbb0486b632264426b57320cb392e0156c44eb86be06549c0af71567fd2f25e587bcccdcf4edb460f9cd510994a1ee0bf782307bdbec045d1818db5470ec2024b4fef43fc1b1e400fa7dd789cd6101d46ed8c319661f74e4293a931f7fe43ff14af9082375ec24609a30c8fd6bae055a2932e2247d1754b998febe3dcb7c852db63d0e296ce704f0496ed",
                Status = "e12403b1c6e440378fb7cc162108538390d3b7e8a94d424c94"
            };

            // Act
            var serviceResult = await _shareDictionarysAppService.CreateAsync(input);

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ShareLanguageId.ShouldBe(Guid.Parse("43e2121a-2d0e-490c-bd98-9adc907227ac"));
            result.ShareTagId.ShouldBe(Guid.Parse("da828e94-8bb3-404c-a6a7-36b8641048f3"));
            result.Key1.ShouldBe("a8aa5f3c359b4414be50ac1463ed0c13ec198d37f1e24d5797");
            result.Key2.ShouldBe("92e5a5223d284efda3560e8c3367adb6574f1d2c86f64e2b88");
            result.Key3.ShouldBe("9b5a0d505ba54446873b4c9bb351cd325dda257ebf964552bb");
            result.Name.ShouldBe("78fd41a664f945968424884a282454dc607094e713884db0bc4f8e894b48f9eee45ec0a7a9ed4031be89c16947a9ce016d46911899a64458879d8f46134e932f3851933f7d134011a9df2531f6c5ecd921a5309e6d404d2e81a707dcbafd47570d5ce015");
            result.ExtendedInformation.ShouldBe("df1bdf2933da4478b226e7cd0cecdc6e8cefa3b33ca54261b3c1f16e00b34d52e379ab03a8d94bf280826e1c698efe43d6aec5d725b64eac9ee4d054ba366380fc1c5cbcf671485a9b32e9a2ed600599707f4466f4d34f1892580653c88e4cb72a35793f98bf4d36b8ebc41a1cf9d0f1256808ce0fd74823ab2ceaf9679e7db02ede17a059f8447186eb70623244f5e7e76858dd14d449fa813a19ca96247fca162b9265ba074580b3e41ffddaf2f252c2b26855f1a540e49802b6f626c857e26f19dc93231b4ca9b86f30fbe7ed79a0fab419edb43e408c93908f03dcc563f73a57ea1a82ff4e52ae5b09418c2e75d2946906d6534a45cc8222");
            result.DateA.ShouldBe(new DateTime(2007, 1, 4));
            result.DateD.ShouldBe(new DateTime(2022, 11, 2));
            result.Sort.ShouldBe(2070417253);
            result.Note.ShouldBe("f9b5ead7a4ff42428e55a820692987659f8e6389a11341b2ba52f7adbb0fe1a02e7eed517229453fb18cd7f4a30ed0566eb00ba5bc1c4820ac235b9d68a40cec7728fd72cc394f76a9d4ae30d8b965c0afcc6c92806b4f97a779a9b84dd263d960a6e72ba47f4ce986081025cda0b13fbb0486b632264426b57320cb392e0156c44eb86be06549c0af71567fd2f25e587bcccdcf4edb460f9cd510994a1ee0bf782307bdbec045d1818db5470ec2024b4fef43fc1b1e400fa7dd789cd6101d46ed8c319661f74e4293a931f7fe43ff14af9082375ec24609a30c8fd6bae055a2932e2247d1754b998febe3dcb7c852db63d0e296ce704f0496ed");
            result.Status.ShouldBe("e12403b1c6e440378fb7cc162108538390d3b7e8a94d424c94");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareDictionaryUpdateDto()
            {
                ShareLanguageId = Guid.Parse("a14514ec-2c2e-4d29-a328-b9e1b947e1fc"),
                ShareTagId = Guid.Parse("5c560088-23f8-46a1-9960-61ebf6f46ce2"),
                Key1 = "01ee8d448e7c405d94a1217eb83920d144f08ed7d0ba481593",
                Key2 = "30c5ec78f549468784c6b90fa01a3313312a1d25552d46ce97",
                Key3 = "4f0c94ecd1f24004aaeceecbb969590a11f194970dab4308b5",
                Name = "96c5ca2f42514d61a96b71174921884ca7b1e6b2092b4583940d832c2149036f5718965a4d1d4f6abf9ee77a54e4c9e3bffdcfca8a414a7ca19cc0848865e10615e2c964ed5e4ac09ac24f191f7e4e1fc32775a32da249fe9c5d8be4af0fc12f65f7f51e",
                ExtendedInformation = "fb67b8b8cb194a5f8ef59d912f67f1460c40dfba65a846188d5b82305104b21235604025dc534580ae2099e028bb08a2444fab0b7e3b45f6a2c98793184c534a7b88d380e62947ccb13801bee41d859772f6d29464af41bf90662ce2dc79cb32ee517b83f7e04085889aa005814c6404cf194a68d52e4cbbbcbd92136f1b5e15ee91198a89814edca1d7b68a0d6d49bdc8b0a7d75aef4fc0b1e440a701cf90e7152eca8ff9bc46628133301a87fbc424dad9ba8e048b44ac8eddbcacd41a50073c087fc7d88f4f06a0b99c3a9988046bde385aa2599b4867ab20792580de9d152722493e10ee45d1a9119cec1a96f96eabca28f5e58946acbe18",
                DateA = new DateTime(2020, 1, 22),
                DateD = new DateTime(2007, 9, 15),
                Sort = 1871211041,
                Note = "2ab63730081b4e5f8f2ee9fde54cec0cfc5de93cf69846de8ebeae8831728a4637c20ab6687c48679e33db3f8c0e184549a150c1bbf14fdfbb17c1951f67d99ce67575ad7c4b4b078747eb5bbb75d61586dcfdfafe384a3399164b999f7c6ccad2af48d828f04d438da463d9132f0168e831d5cff73642669e3024c3a10646b24bb6778c57484c06af47c18b2cf9a235e901026391314a78a0bb54708d1cb3f8f58a7fb1e2f2487684d6d45ea735d8edffd576b699124e219ce483797a4fa52906a242ef23a54fa3a717a98beb63e709eab1b891ab7b41a38b81886eb729117b1fba0bc664c8486e8c05612e67817dcf7148c0e97ff142298cf5",
                Status = "b5cc9e0d866c4709b68747f795228ce09ff9c0d24428425aa0"
            };

            // Act
            var serviceResult = await _shareDictionarysAppService.UpdateAsync(Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"), input);

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ShareLanguageId.ShouldBe(Guid.Parse("a14514ec-2c2e-4d29-a328-b9e1b947e1fc"));
            result.ShareTagId.ShouldBe(Guid.Parse("5c560088-23f8-46a1-9960-61ebf6f46ce2"));
            result.Key1.ShouldBe("01ee8d448e7c405d94a1217eb83920d144f08ed7d0ba481593");
            result.Key2.ShouldBe("30c5ec78f549468784c6b90fa01a3313312a1d25552d46ce97");
            result.Key3.ShouldBe("4f0c94ecd1f24004aaeceecbb969590a11f194970dab4308b5");
            result.Name.ShouldBe("96c5ca2f42514d61a96b71174921884ca7b1e6b2092b4583940d832c2149036f5718965a4d1d4f6abf9ee77a54e4c9e3bffdcfca8a414a7ca19cc0848865e10615e2c964ed5e4ac09ac24f191f7e4e1fc32775a32da249fe9c5d8be4af0fc12f65f7f51e");
            result.ExtendedInformation.ShouldBe("fb67b8b8cb194a5f8ef59d912f67f1460c40dfba65a846188d5b82305104b21235604025dc534580ae2099e028bb08a2444fab0b7e3b45f6a2c98793184c534a7b88d380e62947ccb13801bee41d859772f6d29464af41bf90662ce2dc79cb32ee517b83f7e04085889aa005814c6404cf194a68d52e4cbbbcbd92136f1b5e15ee91198a89814edca1d7b68a0d6d49bdc8b0a7d75aef4fc0b1e440a701cf90e7152eca8ff9bc46628133301a87fbc424dad9ba8e048b44ac8eddbcacd41a50073c087fc7d88f4f06a0b99c3a9988046bde385aa2599b4867ab20792580de9d152722493e10ee45d1a9119cec1a96f96eabca28f5e58946acbe18");
            result.DateA.ShouldBe(new DateTime(2020, 1, 22));
            result.DateD.ShouldBe(new DateTime(2007, 9, 15));
            result.Sort.ShouldBe(1871211041);
            result.Note.ShouldBe("2ab63730081b4e5f8f2ee9fde54cec0cfc5de93cf69846de8ebeae8831728a4637c20ab6687c48679e33db3f8c0e184549a150c1bbf14fdfbb17c1951f67d99ce67575ad7c4b4b078747eb5bbb75d61586dcfdfafe384a3399164b999f7c6ccad2af48d828f04d438da463d9132f0168e831d5cff73642669e3024c3a10646b24bb6778c57484c06af47c18b2cf9a235e901026391314a78a0bb54708d1cb3f8f58a7fb1e2f2487684d6d45ea735d8edffd576b699124e219ce483797a4fa52906a242ef23a54fa3a717a98beb63e709eab1b891ab7b41a38b81886eb729117b1fba0bc664c8486e8c05612e67817dcf7148c0e97ff142298cf5");
            result.Status.ShouldBe("b5cc9e0d866c4709b68747f795228ce09ff9c0d24428425aa0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareDictionarysAppService.DeleteAsync(Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"));

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == Guid.Parse("2b641381-29fc-45cc-8e92-43b6adc6b8b1"));

            result.ShouldBeNull();
        }
    }
}