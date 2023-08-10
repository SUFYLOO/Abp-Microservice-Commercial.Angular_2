using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareCodes;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareCodes
{
    public class ShareCodeRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareCodeRepository _shareCodeRepository;

        public ShareCodeRepositoryTests()
        {
            _shareCodeRepository = GetRequiredService<IShareCodeRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareCodeRepository.GetListAsync(
                    groupCode: "d077b4cdd13341ec99431aeebf12cbcc43190df089114a9f99",
                    key1: "736816c837464389b7b8da966b5fd64d3d089d9c25f2487988acc546975e85a784145c1855e74c3fa2258490186842ef1ee9",
                    key2: "2b1e9097d109463c811b4fcbb0e8c1dde87c01c10e954081a72cd58c872f4f5b7b5cea58c2cc4eebaa850ec507d2a43bed62",
                    key3: "8429fcc647ba4da982889922d321fc01fbd7c5365eac4a7ca8a5250a65722674af630fbc08d145d186746658cb94ee76ae05",
                    name: "43a3788295864102b58ed00fb7a30df7c839876e48964ee7968b3bff3d4ad9b4d375a22a19ab4cb88709638828df2bb56778",
                    column1: "211142a34eb44979ad99fdb2ec8cd38d4bde772645a945d490",
                    column2: "9952687614544407bf9bb8a810ccfe76b9e2696b190b45ef91",
                    column3: "f98fe88046d34d95bc6ceddb14318900b2361b1719494eddb4",
                    systemUse: true,
                    extendedInformation: "54c1e7e4430d43c6b32437fa1bedd6f8ca83c6d42eb0425abbf23b739f03173f375a8ec97c3d4787915ee33ce7c30337a085826103574434b9386d20f1dc0a8b40c27257e6e648b783b4a4819c3a3f9802b0b521f29a4a91892e8994b627b997e70df5f7e96c45b38d76d23e3c2fe2924dbbced838124b6f9173898dca8ce69856f7224ab8a5499fbf2f001781c27974233407c15d7f4f5a8434dbec959dd5a7e97bff00799f4a07bc2bd5664d86b11daf7369dd55f74123976f5d75b3b5cda60934c9c61b17481bb1738c02e1cf09144f61be8987e149588f3e301b7abb353cec69bfd70f81408ca36f1c8421b3179af77ea8d26055404ea819",
                    note: "5aa3d023d346405e8bfc3728547cc923d7062f1f4d2e489e8c561a70f40719419a8ff5ced2c943b1844f36217b06b742591e27adba5748b7b303767b8cf93accb028b58708c14e9aa69f5c108305499e57a8df9f01e640a5ad14e33adfb840ce287acfacc8d4410fa08fab25c627c1b67a50d6e9849e4ad181d7028ea9cecfd3e2024fd83f0a4341b82fcb49d3ccadf83653a7a5121542b8ba0342a1ff91ccb3833b677939cc4a4b8a1455cbc1a25b5a1b56641ffb0b47a59f723beb7e8ec875a8af7d693e584ba484932b72f16b0d6a40944162bff546bd9de74b16c9057cd75c81972c9d2a49d5815e0170333e3ef3b89341f05021479e9b75",
                    status: "567f925111ac4ecaa205f2ce6596889a31af4d727da24f1c94"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("5ef88947-59f1-40d6-9324-7ebd7846c4ec"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareCodeRepository.GetCountAsync(
                    groupCode: "8607689a322d4a2097dbe339c18d8ea867ddd88ff9c0474c83",
                    key1: "96a3250ea62d423fac225838d9e47508333f90b2c9ee4f999bc02e1fdddc4442aeaef85747a0448e808510eed21af7fc9fe3",
                    key2: "381f63967bc84cb18147044dbafeaff28cbd3b54933c4c1eaaa112404dd6024f479574ad951a4663aabb80b9b1801bcae18e",
                    key3: "fba456ac649c4d8881f8e32243e654c49ed30e60d4594c02bbf7d0aba3f47d0e9d9bf5e8662441a98c2b96befb2b2af11abe",
                    name: "b51d54d1b4e84980a21d1ac8f12a9eceb48c089025e34e3fbba8399b9a0768cb43093a0bc959409fb958acb8ca0aa1ea185e",
                    column1: "a9160282f3ea4550bdd588ba0288fe6bcab17ccbeb714e3f88",
                    column2: "7572d4cece8449f6a9650d612f6adb1206c74e4edd0e493496",
                    column3: "f0a2a0a434a34ad1afd00d0a485971d9a923109d3b564c1ea3",
                    systemUse: true,
                    extendedInformation: "1b3f07e6bbfd442185acf8f5b8da01424cf36bb128644195913e48155c5aafec8d7b1b734a974a0d9dd636994b57c818b28b2f7f39dd4ef89cf31a36b53c019adc232d49c5944f0183d51573e75decd4360d3bbf30494008824785b5fd7ed3a586d8d7b96a9d43879b7de23bbe09611164699f76e54f485bbef8a384b834713f9970a45c7f7549e082cd00153b89b9d68a712c5c35244058b8ef3142861989b741b7535247dc4df8a918fc55e0fbdada57ecea01216c4db2afe4ec50d2d13ee23088e8ad56c54b688d27ec88d5fd8b78b5371589523647b59cd5b0d2b97eed1986f629dfae01429cb108865451316290a3fe2563147a4fa9a834",
                    note: "84d3e2810f7b4f4c821f3f85c3786a4f4a7d5ca499874170af78a55fe1f0c81cd904a017d0344904ad8271ec963bd1cca2fb0daf68d54a28a62e64e9033926e3a4c475ebe403474ba6e81725a1a4957bdb170d8cbe184898adbb58239e19a7b6b90bca5705d54d798f0b7c541b8edcb2b8ddc4465c8a4e2f88eb3f8148c738ae932ee50febc240939ad3ea787a9ea555dd3c4056044f49f38e297d968621c5a74b20bf03da144e0bb246389951bfaa42f9bea4b0a39b4585bac48b2507da01aa72358c2de8524eee9a42cf2f9f1df12e0ddce0afb67c4412a5ed61b46eabff981cf65caa3d544521954462709b76f4d31b838334df6745ec8a18",
                    status: "374af34b17bf4954b824a7d6da2f6708aa90669398fc47fcac"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}