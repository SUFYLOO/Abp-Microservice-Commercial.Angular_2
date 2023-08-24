using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencessAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeExperiencessAppService _resumeExperiencessAppService;
        private readonly IRepository<ResumeExperiences, Guid> _resumeExperiencesRepository;

        public ResumeExperiencessAppServiceTests()
        {
            _resumeExperiencessAppService = GetRequiredService<IResumeExperiencessAppService>();
            _resumeExperiencesRepository = GetRequiredService<IRepository<ResumeExperiences, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetListAsync(new GetResumeExperiencessInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("b0cc51c6-d1b0-4918-9875-19d374240090")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetAsync(Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesCreateDto
            {
                ResumeMainId = Guid.Parse("51fe7219-55b3-4b66-b392-00124b8800d0"),
                Name = "1d0c584ada3f4eb6826990655fb7003a1ea2ad63d0864e5daa",
                WorkNatureCode = "98fa855c786f4dbe8c9a61ae0c7813db5ee9d62625c148a5bc",
                HideCompanyName = true,
                IndustryCategory = "3548e60f3d5448999c29abc7a9b55af76211eb94af2b45c8a2042f3dcc67d6cc4b560763819f4ee6afa2af57ea1d192afb14dbe59d514a8cacd5014452a9c7a9605c04d5e9bf4996a76426fc954c63bda945c5c8e74c464daa196fb65b75f25efa586ecda1204bae9dc7b827a8d395840e92b47f94f0473b9acf9649ea44d08bbd56b65601c6477aafd044f7acaf27068cb83f696a30479d961522933f9518c80abe0f22bc1640a7a1f34d017d4d67d0a346793dcaa14f659998ff327adeca7c0c0cfc28248a463d87c1ac54cc1713f30cec29e098b94eecb850afff9e7ccad812e47131a5994f49a40311f80c5da1acc6f2b2ae864c49c0b18a",
                JobName = "891d4353158945f0b9b4905efc687a90069230c7713343bbac",
                JobType = "d8ab849e4c374fa8a8d50e8fe5f01a204bc02467daf147a49c2a18dc39d464d7e46fd0a0c9a04f94b5761c636e0f6c6f7c6b751770384a0ca0174960f13f8a23176ae87987ab4cea96fd9545b62e6635e72d2810aad14b0eb2f388f15b555bceedc750a8c17a444ab2feda63218b2f077503b3025d26494db4eb5f488231d960abc6111116434e6fb8a46da9bb1b2a4888b4aab111bd4afe833c2ab12505c6003fd1c7a8d6b44fa5b457e96c994cc9277299fb17b61649a786b8b4a0b52349824975dd24e60748669648a32ade8410420f350bcddd6b425c89a03739ed00cb6aae27fd03f0db483aa7c70764937c9d8fb3f0f38bf77d4f3bb966",
                Working = true,
                WorkPlace = "78f6fb8ddd6d426f8cc97fb9cf244acfd5fa44f9c84a49efb0ac5436ab8c81d8ad588d9a71ec422a8605b5021a991db754914daba900416eb91b3c4a546a947558ec11405a254ff79ae26f643744f8ad16aa63355070441b9c81d0f3dad2a8e9baea373f32eb41c796de95217040f79406972460dbc04419b4b668bfb27960ab9469b2f995ea451293cac1a36313e14e6ef47050986a4137bff6be083e062bc8cdd458e7b66b4bc5a15c16206ddb9452120bdb00282f4347bde76e733f216011273fbce9356440a4992589641c412d077b695a55e70e4a869f17f922e994655a04349e45749040e5b3137ea3b485e692fba41ee14a564ba6a714",
                HideWorkSalary = true,
                SalaryPayTypeCode = "291a87a16f6e45beaa4f940ea6b519dd12ed5f6308d544ccaa",
                CurrencyTypeCode = "d989611ec9834df4a603d2892df2d69f9ecad6ee5cae499782",
                Salary1 = 2124875572,
                Salary2 = 1844223736,
                CompanyScaleCode = "33690d401ee04dde851cdee2a1343c57e8a92bf09a914bbf90",
                CompanyManagementNumberCode = "e9b49828651e43fe970e96fd5bc55243e12cbca3c858481092",
                ExtendedInformation = "654169b719214a6ebef68690a10a55fe4201cdf5b3bc4066b9d9d15bb37773bdd31010d9500b4a1690955f5013ab5b54ca334e9c762e4ca3b547dc4c185e5a00f7122dbc667945fe954388cfec26d0a816a74a2b3ed54da59887e657d93fe0a5ad42fd2bc42f4af787e13bad0189229fcb14fdda46ed47058c7f68881ae8683a2092587423d845d29c942be5ef33e18f0cc937e893a14a04a844169fd4bc83c14618b6ae508f4697b3a85747eff22b033628b93a76844be28e0123dd78cf0f99403ad98d68434c158d789086648babff1a76d3d2937e4a7f9d9fe0a254a6a573c316133ac1c042e7888e669cd71a84250bf01fa93f964b2caf31",
                DateA = new DateTime(2009, 6, 5),
                DateD = new DateTime(2020, 7, 24),
                Sort = 985451244,
                Note = "17d15cc137d3434cbd407e68352b1585179ef62cc3b143f78c5b019d6087a289213797fc311c41269e936f60229b5ed1f634678831b3431487088b3d587f06465998812341ff4a10a1bb0e498f826c1951280e4009c8445382564c61117dd290dce5a624d0a945ea8c9a9e7ea7e3966464224954317f4540889a5d157bc8e4166fd1eb94bc144f02bbeb1293633d99155b3837913acb4fcebdb83c53e20b7a056dcb187ed574439a83c3e70d05460c47e923d34b91154108901f1edc17ec1f06415f3b4c963148aa83f4ea5d78c8f212b484e2e681bc4934a406ddfe581b29574f0e3bfe885b43db96b789c1d7da2b2edc3fde2514274f588976",
                Status = "31bdac6eff06408691ad68f2ae1ec29844779371ae8c42f9ac"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.CreateAsync(input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("51fe7219-55b3-4b66-b392-00124b8800d0"));
            result.Name.ShouldBe("1d0c584ada3f4eb6826990655fb7003a1ea2ad63d0864e5daa");
            result.WorkNatureCode.ShouldBe("98fa855c786f4dbe8c9a61ae0c7813db5ee9d62625c148a5bc");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategory.ShouldBe("3548e60f3d5448999c29abc7a9b55af76211eb94af2b45c8a2042f3dcc67d6cc4b560763819f4ee6afa2af57ea1d192afb14dbe59d514a8cacd5014452a9c7a9605c04d5e9bf4996a76426fc954c63bda945c5c8e74c464daa196fb65b75f25efa586ecda1204bae9dc7b827a8d395840e92b47f94f0473b9acf9649ea44d08bbd56b65601c6477aafd044f7acaf27068cb83f696a30479d961522933f9518c80abe0f22bc1640a7a1f34d017d4d67d0a346793dcaa14f659998ff327adeca7c0c0cfc28248a463d87c1ac54cc1713f30cec29e098b94eecb850afff9e7ccad812e47131a5994f49a40311f80c5da1acc6f2b2ae864c49c0b18a");
            result.JobName.ShouldBe("891d4353158945f0b9b4905efc687a90069230c7713343bbac");
            result.JobType.ShouldBe("d8ab849e4c374fa8a8d50e8fe5f01a204bc02467daf147a49c2a18dc39d464d7e46fd0a0c9a04f94b5761c636e0f6c6f7c6b751770384a0ca0174960f13f8a23176ae87987ab4cea96fd9545b62e6635e72d2810aad14b0eb2f388f15b555bceedc750a8c17a444ab2feda63218b2f077503b3025d26494db4eb5f488231d960abc6111116434e6fb8a46da9bb1b2a4888b4aab111bd4afe833c2ab12505c6003fd1c7a8d6b44fa5b457e96c994cc9277299fb17b61649a786b8b4a0b52349824975dd24e60748669648a32ade8410420f350bcddd6b425c89a03739ed00cb6aae27fd03f0db483aa7c70764937c9d8fb3f0f38bf77d4f3bb966");
            result.Working.ShouldBe(true);
            result.WorkPlace.ShouldBe("78f6fb8ddd6d426f8cc97fb9cf244acfd5fa44f9c84a49efb0ac5436ab8c81d8ad588d9a71ec422a8605b5021a991db754914daba900416eb91b3c4a546a947558ec11405a254ff79ae26f643744f8ad16aa63355070441b9c81d0f3dad2a8e9baea373f32eb41c796de95217040f79406972460dbc04419b4b668bfb27960ab9469b2f995ea451293cac1a36313e14e6ef47050986a4137bff6be083e062bc8cdd458e7b66b4bc5a15c16206ddb9452120bdb00282f4347bde76e733f216011273fbce9356440a4992589641c412d077b695a55e70e4a869f17f922e994655a04349e45749040e5b3137ea3b485e692fba41ee14a564ba6a714");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("291a87a16f6e45beaa4f940ea6b519dd12ed5f6308d544ccaa");
            result.CurrencyTypeCode.ShouldBe("d989611ec9834df4a603d2892df2d69f9ecad6ee5cae499782");
            result.Salary1.ShouldBe(2124875572);
            result.Salary2.ShouldBe(1844223736);
            result.CompanyScaleCode.ShouldBe("33690d401ee04dde851cdee2a1343c57e8a92bf09a914bbf90");
            result.CompanyManagementNumberCode.ShouldBe("e9b49828651e43fe970e96fd5bc55243e12cbca3c858481092");
            result.ExtendedInformation.ShouldBe("654169b719214a6ebef68690a10a55fe4201cdf5b3bc4066b9d9d15bb37773bdd31010d9500b4a1690955f5013ab5b54ca334e9c762e4ca3b547dc4c185e5a00f7122dbc667945fe954388cfec26d0a816a74a2b3ed54da59887e657d93fe0a5ad42fd2bc42f4af787e13bad0189229fcb14fdda46ed47058c7f68881ae8683a2092587423d845d29c942be5ef33e18f0cc937e893a14a04a844169fd4bc83c14618b6ae508f4697b3a85747eff22b033628b93a76844be28e0123dd78cf0f99403ad98d68434c158d789086648babff1a76d3d2937e4a7f9d9fe0a254a6a573c316133ac1c042e7888e669cd71a84250bf01fa93f964b2caf31");
            result.DateA.ShouldBe(new DateTime(2009, 6, 5));
            result.DateD.ShouldBe(new DateTime(2020, 7, 24));
            result.Sort.ShouldBe(985451244);
            result.Note.ShouldBe("17d15cc137d3434cbd407e68352b1585179ef62cc3b143f78c5b019d6087a289213797fc311c41269e936f60229b5ed1f634678831b3431487088b3d587f06465998812341ff4a10a1bb0e498f826c1951280e4009c8445382564c61117dd290dce5a624d0a945ea8c9a9e7ea7e3966464224954317f4540889a5d157bc8e4166fd1eb94bc144f02bbeb1293633d99155b3837913acb4fcebdb83c53e20b7a056dcb187ed574439a83c3e70d05460c47e923d34b91154108901f1edc17ec1f06415f3b4c963148aa83f4ea5d78c8f212b484e2e681bc4934a406ddfe581b29574f0e3bfe885b43db96b789c1d7da2b2edc3fde2514274f588976");
            result.Status.ShouldBe("31bdac6eff06408691ad68f2ae1ec29844779371ae8c42f9ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesUpdateDto()
            {
                ResumeMainId = Guid.Parse("a6d89067-ad5e-4fb8-95cc-1dc418f648f7"),
                Name = "2f877772ded74be19618d41047d3dfb328ac4609b06a44ad81",
                WorkNatureCode = "597cb4a349a64b09ac3504b47d58e1a715dd6161df924631b8",
                HideCompanyName = true,
                IndustryCategory = "479b2e41028149eca303466c9b692275791e56322f594d78b63f35cb8f5e6b1d19a112cbcf4f4d96bd47fef87bbe20dfd8fb379bd68f4c95b0005d5482abdb11269291a1cc90450ba8fe7f6d7605926114c4477e4dbe40e1a437f4e69185f4eb9adf0768590b4deb84c9341f06571b12a97fb54d12854ab892c61c25501386f968d7f93c7f0846cc876db0f68e66c82e599d47b5b16c49d9a1784c947db960c9ab45f12ee95c464a88628b026fd07a64a5ef54993ab44838981ef3e9ee1d7edf1da2b4d5a0b440fb9b6f34c1ff917da16ef7927d84e74501bdc52003e16bb8544df0666d3c6447488181f2a4ef4d78fb425e6563d34d44258908",
                JobName = "b5d33662bc354baf816cc64ffd95b7b1656f86a5a5c4433f92",
                JobType = "7acba6e8de664f98823ef85d43ba8fce901a73e35e3a479690e22289cfde908aba9e2f8b431c4ec99c4cd2e3ed77c50de75220dbbf5041b69e04790afc772e3e55b63bfa43f94807862a3b37fd621951233c11e1aba6462d98b9d6d1f9c0c477d1c9a2728ad6451880ee8503914da347362d3f1e91544e2dbb4ddd3575fc863c490b062063c040c7a2ff9ee38e20e313d3b0836ee9ed4f7897df26bb84f0b03db555f0f4d61948289a528524c19a314e6f66f24365654087b5c9cd29cf7ea53d94b2640ad4c24ad3900a6842dc05911941189e03bb2e479692a1bc62be24954cb253a68b02664239acb8ec54db537ebb1c3cae4509e74082902f",
                Working = true,
                WorkPlace = "1d21a82287d24550a58169023c3dd95d40f55cb05d7040fdbbcd3193735db8f1ea88a6338cab4c61b9c62c920e59b772f16849fa407644c4bb41684469646601508a470d14e94b7f863b98d3e5f1461ea33e935f5e46471d88b76a103ab20e9146cbffba96d74e8f86056a4158a3506d7b20218c0c564fed8252b5da906b76f48629fd2466a14d77b92fef5cb7281831d41cb2c3efbf40aa86d8da5f028b9308f91150b277874d778876ac77ddb601bf0e2324b757a74b108ff3ace64720bdb91faecf9a34f44ce3a66e6f674453171b3bd627ff3d0d418593bface68ee63e268157a2ea1f894adb943966ca623dce6f65809dde27dd4c0bafc0",
                HideWorkSalary = true,
                SalaryPayTypeCode = "1c29071c204b48eebc4597be45a40842a8e958812d2f4accaa",
                CurrencyTypeCode = "df58a5747e6e429a852c7573b5c68a13172159f74fc14895ac",
                Salary1 = 513432989,
                Salary2 = 2088535518,
                CompanyScaleCode = "5ef3455fcd254888a4a9c77a61ab7b3cb823c25cbd16474486",
                CompanyManagementNumberCode = "4b66f0bb7b854a30b42ad4cd8a7ed9dc5ae5b4aa0a9042b290",
                ExtendedInformation = "00cfba75e9ad461f946eb7ad5e9e0ad0b0d18200f83a43b99ce031f779ec066092a27dbdd1494b6cb1bb92d1b747a96412b2c72516ed455fbeb4f6e5b43cafc74ce7a2bc776f4e0bb5d0c9a6e6f00abc374133ddf9604df7841798f1104383cc019d535679cb455e8e56ef363cf18ebf0cffc7200e4a444099a5dac07063479b270ded71be894007ae7c34828efbc939aa628ef738114372b01b749a8afb53eb26a0261402b443528ea4ff2d5e1066abfef652f1bd494e9ea928d4aa0dc925392fe9b6d3b1c343a58d7115c459eb1718f9a0b192cd1840329e3b88b927a7d2810670db9e36a74655be622056d3dd7ea5f03f1a72410546cb959d",
                DateA = new DateTime(2021, 11, 9),
                DateD = new DateTime(2003, 10, 18),
                Sort = 87655325,
                Note = "1a18a42178a8410e9f827cbc90a68a87d2d93d28e72147009a9fa2cf625b615eda1455a2f98a4dfda9a2b947f553b266646e410c4c4647e9b27a0317130735c4b63e8909c83c4ac18f0d9d0497cb91a809024ebc466440d69a1b15387b4c9283c0004ab7f66a4e979c0940637f15d240ffb9f43436094aecbc4a24bbf02f60a34cc7bd9039dc4a1bbfbc1dfbc88a7037291991e7def844488c96420f1b02aeeb00289f419b5645fab1fac9fb808aa4665fb78ba5971f40589c6b055ee2a3468bc16d9a9cff354d218c286ebb98e9a35cf9b6abedeffd46599a01a2d7ca02a20bc127f2769a6e4ce18c4b1b2a60dc079eff26e98e78ad46d2aa43",
                Status = "eb820a8839114cd686667f9b8a76e6ae14bc3bd2daa64e49af"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.UpdateAsync(Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"), input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("a6d89067-ad5e-4fb8-95cc-1dc418f648f7"));
            result.Name.ShouldBe("2f877772ded74be19618d41047d3dfb328ac4609b06a44ad81");
            result.WorkNatureCode.ShouldBe("597cb4a349a64b09ac3504b47d58e1a715dd6161df924631b8");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategory.ShouldBe("479b2e41028149eca303466c9b692275791e56322f594d78b63f35cb8f5e6b1d19a112cbcf4f4d96bd47fef87bbe20dfd8fb379bd68f4c95b0005d5482abdb11269291a1cc90450ba8fe7f6d7605926114c4477e4dbe40e1a437f4e69185f4eb9adf0768590b4deb84c9341f06571b12a97fb54d12854ab892c61c25501386f968d7f93c7f0846cc876db0f68e66c82e599d47b5b16c49d9a1784c947db960c9ab45f12ee95c464a88628b026fd07a64a5ef54993ab44838981ef3e9ee1d7edf1da2b4d5a0b440fb9b6f34c1ff917da16ef7927d84e74501bdc52003e16bb8544df0666d3c6447488181f2a4ef4d78fb425e6563d34d44258908");
            result.JobName.ShouldBe("b5d33662bc354baf816cc64ffd95b7b1656f86a5a5c4433f92");
            result.JobType.ShouldBe("7acba6e8de664f98823ef85d43ba8fce901a73e35e3a479690e22289cfde908aba9e2f8b431c4ec99c4cd2e3ed77c50de75220dbbf5041b69e04790afc772e3e55b63bfa43f94807862a3b37fd621951233c11e1aba6462d98b9d6d1f9c0c477d1c9a2728ad6451880ee8503914da347362d3f1e91544e2dbb4ddd3575fc863c490b062063c040c7a2ff9ee38e20e313d3b0836ee9ed4f7897df26bb84f0b03db555f0f4d61948289a528524c19a314e6f66f24365654087b5c9cd29cf7ea53d94b2640ad4c24ad3900a6842dc05911941189e03bb2e479692a1bc62be24954cb253a68b02664239acb8ec54db537ebb1c3cae4509e74082902f");
            result.Working.ShouldBe(true);
            result.WorkPlace.ShouldBe("1d21a82287d24550a58169023c3dd95d40f55cb05d7040fdbbcd3193735db8f1ea88a6338cab4c61b9c62c920e59b772f16849fa407644c4bb41684469646601508a470d14e94b7f863b98d3e5f1461ea33e935f5e46471d88b76a103ab20e9146cbffba96d74e8f86056a4158a3506d7b20218c0c564fed8252b5da906b76f48629fd2466a14d77b92fef5cb7281831d41cb2c3efbf40aa86d8da5f028b9308f91150b277874d778876ac77ddb601bf0e2324b757a74b108ff3ace64720bdb91faecf9a34f44ce3a66e6f674453171b3bd627ff3d0d418593bface68ee63e268157a2ea1f894adb943966ca623dce6f65809dde27dd4c0bafc0");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("1c29071c204b48eebc4597be45a40842a8e958812d2f4accaa");
            result.CurrencyTypeCode.ShouldBe("df58a5747e6e429a852c7573b5c68a13172159f74fc14895ac");
            result.Salary1.ShouldBe(513432989);
            result.Salary2.ShouldBe(2088535518);
            result.CompanyScaleCode.ShouldBe("5ef3455fcd254888a4a9c77a61ab7b3cb823c25cbd16474486");
            result.CompanyManagementNumberCode.ShouldBe("4b66f0bb7b854a30b42ad4cd8a7ed9dc5ae5b4aa0a9042b290");
            result.ExtendedInformation.ShouldBe("00cfba75e9ad461f946eb7ad5e9e0ad0b0d18200f83a43b99ce031f779ec066092a27dbdd1494b6cb1bb92d1b747a96412b2c72516ed455fbeb4f6e5b43cafc74ce7a2bc776f4e0bb5d0c9a6e6f00abc374133ddf9604df7841798f1104383cc019d535679cb455e8e56ef363cf18ebf0cffc7200e4a444099a5dac07063479b270ded71be894007ae7c34828efbc939aa628ef738114372b01b749a8afb53eb26a0261402b443528ea4ff2d5e1066abfef652f1bd494e9ea928d4aa0dc925392fe9b6d3b1c343a58d7115c459eb1718f9a0b192cd1840329e3b88b927a7d2810670db9e36a74655be622056d3dd7ea5f03f1a72410546cb959d");
            result.DateA.ShouldBe(new DateTime(2021, 11, 9));
            result.DateD.ShouldBe(new DateTime(2003, 10, 18));
            result.Sort.ShouldBe(87655325);
            result.Note.ShouldBe("1a18a42178a8410e9f827cbc90a68a87d2d93d28e72147009a9fa2cf625b615eda1455a2f98a4dfda9a2b947f553b266646e410c4c4647e9b27a0317130735c4b63e8909c83c4ac18f0d9d0497cb91a809024ebc466440d69a1b15387b4c9283c0004ab7f66a4e979c0940637f15d240ffb9f43436094aecbc4a24bbf02f60a34cc7bd9039dc4a1bbfbc1dfbc88a7037291991e7def844488c96420f1b02aeeb00289f419b5645fab1fac9fb808aa4665fb78ba5971f40589c6b055ee2a3468bc16d9a9cff354d218c286ebb98e9a35cf9b6abedeffd46599a01a2d7ca02a20bc127f2769a6e4ce18c4b1b2a60dc079eff26e98e78ad46d2aa43");
            result.Status.ShouldBe("eb820a8839114cd686667f9b8a76e6ae14bc3bd2daa64e49af");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeExperiencessAppService.DeleteAsync(Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"));

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"));

            result.ShouldBeNull();
        }
    }
}