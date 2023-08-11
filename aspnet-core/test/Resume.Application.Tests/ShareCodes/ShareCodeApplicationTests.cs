using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareCodes
{
    public class ShareCodesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareCodesAppService _shareCodesAppService;
        private readonly IRepository<ShareCode, Guid> _shareCodeRepository;

        public ShareCodesAppServiceTests()
        {
            _shareCodesAppService = GetRequiredService<IShareCodesAppService>();
            _shareCodeRepository = GetRequiredService<IRepository<ShareCode, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareCodesAppService.GetListAsync(new GetShareCodesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e716cda3-8d45-45a9-925a-9a3c4d353845")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareCodesAppService.GetAsync(Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareCodeCreateDto
            {
                GroupCode = "abcaabbb339745e39101018bc4e0067ff213a5aafd29433da8",
                Key1 = "fb9918a3b93f456a94514e81b446588565ea8712edf045de9ed4c86293365d5fc176fcecf7af478183c64c4817e033014679",
                Key2 = "c527af8bc8e34ccf86ee43ee35a30ba81a40f6d137f84af18a573c0270696c7de8f0f0b48bdf4f288d3ee0ee4e845f528bca",
                Key3 = "ffc74ef2e93e4e7e9566c1f6340896e4e411bf8360324b42939bdd3da9c8ef023ff2a32ac61c4eaab9b8fda71bacd7896fe1",
                Name = "62cc0f1aab4c40e185a1dd65f9d10b1b5f43067d7124492db58b88f7e494131b868cbe4e843b4bd4b1ca59d9b3911875f351",
                Column1 = "a11768a890f845f3a8b8ec340c1178579305a4641ee9433981",
                Column2 = "16de8b22b13645b2adee037a61a3c7f2eef4de11685d40c3a4",
                Column3 = "10eadadd3f72489d9be2e7b3069a3ea30cc976864d45414582",
                SystemUse = true,
                ExtendedInformation = "c40bec10d6c44b0bb478a6d3577931076607ce9cb4eb47f59c11c587752c09c38ef965c7a67d41a8bb447f0bc28c6f800bf6f7aa1d5849079c94b9419c9696e1559cf0761e464ca099fc7bfe906f46ec57c5981cccbb4e08a1ec5c1b0bc448ec9ec0e13eb5cc4a34a7672fd241ddb1be6b4b93020ae14eee81554cc7a472071de68cccbfda384286b60ecf3c3fc8ecc8f2ca28376e5b40e8b36c94aaa56e03c70956ab38ce4a4923b057a274f80812e930e58adf8c0042dab150f8c7f9a4710040966ebed2684233ae1f7a7ceb8f6ed5909d23bf32b64d59bb4452d2c3dc97c5c87bb0227ea34170938258c51c5a2eb08302642bde80453191ec",
                DateA = new DateTime(2001, 9, 1),
                DateD = new DateTime(2016, 2, 18),
                Sort = 830907079,
                Note = "2dd453a937d84384967a8aeb5ebc35b05c264581872e41749949e706dfafd02a7720540125f344478afb5eed081a0edc68065b0b27584c7db5aefb93716c94ef6fd4ccf2b49f41e1981d5ec09e945488213c87a5d0354d29a959630f484a259701bcc3a844cf4b9b8ba9f767b7d5c38db955695d47774f318f0b0a9a95474183358d833298e345a5b7baea391413c030ffb05b09293d451cb835b205a2163cef17144b4c884946a79c94501b4db676eaf705015540a749eba1f0b399685c951813b4a74f693d4237aee00bbda024071fc1503844d5f440809ec25cdf9a72efe6e3172ac467e74b9ea0b81a490817a85a9f859bebf9e148959b45",
                Status = "1aeba8df871847feadf65dcb9552741801f3d3f29b26467ea1"
            };

            // Act
            var serviceResult = await _shareCodesAppService.CreateAsync(input);

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("abcaabbb339745e39101018bc4e0067ff213a5aafd29433da8");
            result.Key1.ShouldBe("fb9918a3b93f456a94514e81b446588565ea8712edf045de9ed4c86293365d5fc176fcecf7af478183c64c4817e033014679");
            result.Key2.ShouldBe("c527af8bc8e34ccf86ee43ee35a30ba81a40f6d137f84af18a573c0270696c7de8f0f0b48bdf4f288d3ee0ee4e845f528bca");
            result.Key3.ShouldBe("ffc74ef2e93e4e7e9566c1f6340896e4e411bf8360324b42939bdd3da9c8ef023ff2a32ac61c4eaab9b8fda71bacd7896fe1");
            result.Name.ShouldBe("62cc0f1aab4c40e185a1dd65f9d10b1b5f43067d7124492db58b88f7e494131b868cbe4e843b4bd4b1ca59d9b3911875f351");
            result.Column1.ShouldBe("a11768a890f845f3a8b8ec340c1178579305a4641ee9433981");
            result.Column2.ShouldBe("16de8b22b13645b2adee037a61a3c7f2eef4de11685d40c3a4");
            result.Column3.ShouldBe("10eadadd3f72489d9be2e7b3069a3ea30cc976864d45414582");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("c40bec10d6c44b0bb478a6d3577931076607ce9cb4eb47f59c11c587752c09c38ef965c7a67d41a8bb447f0bc28c6f800bf6f7aa1d5849079c94b9419c9696e1559cf0761e464ca099fc7bfe906f46ec57c5981cccbb4e08a1ec5c1b0bc448ec9ec0e13eb5cc4a34a7672fd241ddb1be6b4b93020ae14eee81554cc7a472071de68cccbfda384286b60ecf3c3fc8ecc8f2ca28376e5b40e8b36c94aaa56e03c70956ab38ce4a4923b057a274f80812e930e58adf8c0042dab150f8c7f9a4710040966ebed2684233ae1f7a7ceb8f6ed5909d23bf32b64d59bb4452d2c3dc97c5c87bb0227ea34170938258c51c5a2eb08302642bde80453191ec");
            result.DateA.ShouldBe(new DateTime(2001, 9, 1));
            result.DateD.ShouldBe(new DateTime(2016, 2, 18));
            result.Sort.ShouldBe(830907079);
            result.Note.ShouldBe("2dd453a937d84384967a8aeb5ebc35b05c264581872e41749949e706dfafd02a7720540125f344478afb5eed081a0edc68065b0b27584c7db5aefb93716c94ef6fd4ccf2b49f41e1981d5ec09e945488213c87a5d0354d29a959630f484a259701bcc3a844cf4b9b8ba9f767b7d5c38db955695d47774f318f0b0a9a95474183358d833298e345a5b7baea391413c030ffb05b09293d451cb835b205a2163cef17144b4c884946a79c94501b4db676eaf705015540a749eba1f0b399685c951813b4a74f693d4237aee00bbda024071fc1503844d5f440809ec25cdf9a72efe6e3172ac467e74b9ea0b81a490817a85a9f859bebf9e148959b45");
            result.Status.ShouldBe("1aeba8df871847feadf65dcb9552741801f3d3f29b26467ea1");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareCodeUpdateDto()
            {
                GroupCode = "e399fe36458b4bb692f1b0eda6c422019d18f769d3204469bc",
                Key1 = "fd584dc078eb4a549412a5e0fdb74a60a6be57a5d23144ca9811905ead80898cbd8ff806964c40ecad81560b98cd115d899e",
                Key2 = "9bc0a8dc936446dba351824f21f9ace20695ef6f8cbb43d09e49215094d8a7cb48d81b0df17d4493a4abfc91101898725996",
                Key3 = "f199d37013bb43c1b16ac040b9a96f06ee413efc44ef4c6c836336a5b5df7cd16e11b2467a704b32b77fb0548cb941200a1e",
                Name = "39eb784dc1264b06ac61a8477535898e0e435c9a0ea34211b26a1f0c6843e56bb286821d1f0f4c4a8a1fff19d75f895d2e4e",
                Column1 = "415b27559cfe438eb3064e8d31eaede7ecde79e4bb904df284",
                Column2 = "35eb89d8267f4d719d21d5b15ff181f88d24b7eea7814ead88",
                Column3 = "844aeb72086941c08ad3a2c2059223a7f2e38220e41944caa6",
                SystemUse = true,
                ExtendedInformation = "43920ba1b9054c3c8121ec9384ff750bffc72998787244de82cd049ab1dbdf5694d4f56872e5441994c2b59a90a21bb7d9a27301758c479c8a4b53ad937f51e21a1d2aa884b24c149107419d4fd5a342039503003fde4b04b4ead65d264767824f385d00c59c4e1b8685178593cdb41eace20d2c717f484c9ceb4c6e048827500005e7cf342140d992f71032636868d16444f05e1bdd4554b976345e6a2cd9ba9ad42bc852254337bebae2ff5cbbaa5c81ed898f8e8342dc89dbb74286c476e31f882867d3164cb0b48b70d7fc920e59be46d532a8ad49cc99b29b5ea06e32f92305e88578b2476d91d1e9704030a205e402aa6cf0cb465a8dc4",
                DateA = new DateTime(2018, 11, 11),
                DateD = new DateTime(2018, 7, 17),
                Sort = 1318658240,
                Note = "21f3165d38db4caa98c6d00ee93fc2d6cb9794081b0143e4aeef79eba2271056103d8dd482db4a7487fe9c81a9bd771692df935c5033469ab75dab64863d8670e009cc3861634c80b2f920272f76e7af74f64e0306ab495897cceb3a1bf0d8e4643c2e6898bc4f6f9bdbca9056e523bb698b9f5371f74b618e868d7a3044ddc5baec343c79e848ad9722fcccf3e5c2673ee283e45f214f18addb82b18bbe0c3bd8c0a6f0461047a9b7803b31b707241f8255270bf7e54bc09a075193eaf2242663b2d6c506e8448ab75cc7ad809892e4df460ebc593149158d6dcedeec89d869102d2034c4244a70b6a50c28a5addd8d5afac62218e14f1f850b",
                Status = "a79dd22c3d1e40299e7e59f1eac7eac6e249e9f0497343729a"
            };

            // Act
            var serviceResult = await _shareCodesAppService.UpdateAsync(Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"), input);

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("e399fe36458b4bb692f1b0eda6c422019d18f769d3204469bc");
            result.Key1.ShouldBe("fd584dc078eb4a549412a5e0fdb74a60a6be57a5d23144ca9811905ead80898cbd8ff806964c40ecad81560b98cd115d899e");
            result.Key2.ShouldBe("9bc0a8dc936446dba351824f21f9ace20695ef6f8cbb43d09e49215094d8a7cb48d81b0df17d4493a4abfc91101898725996");
            result.Key3.ShouldBe("f199d37013bb43c1b16ac040b9a96f06ee413efc44ef4c6c836336a5b5df7cd16e11b2467a704b32b77fb0548cb941200a1e");
            result.Name.ShouldBe("39eb784dc1264b06ac61a8477535898e0e435c9a0ea34211b26a1f0c6843e56bb286821d1f0f4c4a8a1fff19d75f895d2e4e");
            result.Column1.ShouldBe("415b27559cfe438eb3064e8d31eaede7ecde79e4bb904df284");
            result.Column2.ShouldBe("35eb89d8267f4d719d21d5b15ff181f88d24b7eea7814ead88");
            result.Column3.ShouldBe("844aeb72086941c08ad3a2c2059223a7f2e38220e41944caa6");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("43920ba1b9054c3c8121ec9384ff750bffc72998787244de82cd049ab1dbdf5694d4f56872e5441994c2b59a90a21bb7d9a27301758c479c8a4b53ad937f51e21a1d2aa884b24c149107419d4fd5a342039503003fde4b04b4ead65d264767824f385d00c59c4e1b8685178593cdb41eace20d2c717f484c9ceb4c6e048827500005e7cf342140d992f71032636868d16444f05e1bdd4554b976345e6a2cd9ba9ad42bc852254337bebae2ff5cbbaa5c81ed898f8e8342dc89dbb74286c476e31f882867d3164cb0b48b70d7fc920e59be46d532a8ad49cc99b29b5ea06e32f92305e88578b2476d91d1e9704030a205e402aa6cf0cb465a8dc4");
            result.DateA.ShouldBe(new DateTime(2018, 11, 11));
            result.DateD.ShouldBe(new DateTime(2018, 7, 17));
            result.Sort.ShouldBe(1318658240);
            result.Note.ShouldBe("21f3165d38db4caa98c6d00ee93fc2d6cb9794081b0143e4aeef79eba2271056103d8dd482db4a7487fe9c81a9bd771692df935c5033469ab75dab64863d8670e009cc3861634c80b2f920272f76e7af74f64e0306ab495897cceb3a1bf0d8e4643c2e6898bc4f6f9bdbca9056e523bb698b9f5371f74b618e868d7a3044ddc5baec343c79e848ad9722fcccf3e5c2673ee283e45f214f18addb82b18bbe0c3bd8c0a6f0461047a9b7803b31b707241f8255270bf7e54bc09a075193eaf2242663b2d6c506e8448ab75cc7ad809892e4df460ebc593149158d6dcedeec89d869102d2034c4244a70b6a50c28a5addd8d5afac62218e14f1f850b");
            result.Status.ShouldBe("a79dd22c3d1e40299e7e59f1eac7eac6e249e9f0497343729a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareCodesAppService.DeleteAsync(Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"));

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"));

            result.ShouldBeNull();
        }
    }
}