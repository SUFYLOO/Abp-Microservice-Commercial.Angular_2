using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobPairsAppService _userCompanyJobPairsAppService;
        private readonly IRepository<UserCompanyJobPair, Guid> _userCompanyJobPairRepository;

        public UserCompanyJobPairsAppServiceTests()
        {
            _userCompanyJobPairsAppService = GetRequiredService<IUserCompanyJobPairsAppService>();
            _userCompanyJobPairRepository = GetRequiredService<IRepository<UserCompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetListAsync(new GetUserCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f72bbfa1-9360-424b-8bb6-579ca0f4958f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetAsync(Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairCreateDto
            {
                UserMainId = Guid.Parse("7b3d6214-62bb-4783-9f70-381dc3b8219a"),
                Name = "847b3b4c81ed42ea9fa5a0a73580f2d9ceb51b5192784b3185",
                PairCondition = "5719a0dbc5404ad0851941fd89beecc83749ec1ce16e4777ad949239dadb135c4ca3867cfdf14f12822cfb206d2c861ccf0effc7d52b4551b984372e2085221e9f920b171b324cb390ae2eb1d27c4c0c5d88b4f173c8459a9da7a44637a7d54cb5e097d080db4a8bb9cb17a39bf61d209ef5bd4a7f2d4770ab5e1399b52fd4c86aa7e4d1aa744e34a6086592f397177cc7371f32f8d7419e957d49def9b37cc9dc957373ca76476ea1b5f5d949e43ddd8ac3430c92a14a5f9f1993efc395056117748c11cbb84f4280d0bf718051d71d2ed109f7c7ae48faae672bb0409d8fcfa19a149b60554da5b9076bb7b38a6368129863879ff74d5481be",
                ExtendedInformation = "98ab2fc2943047f68007f329ee701a9247ef37177c1e4940b86fed0447d9bae460e0da6186d742989a9b9f053c4f13b89f354a7db03e46e8afaf536e71a9ff9359c40f99b21b408eab892a50c9209d08f3ca4cd9f6264f499c0b93c0d11046bc81ec0f4813a740d6867b519dfdabfee5d5ff08abf837476e88bb2088493cf20f393fdebf73774fdea42945f72e71ad701103ac63722844ea9ff1d9351f640c1f30b36889ca3e4b53a5d3781313b234672ae0a247bc004d49b31809e17e572fb1ba7ebb6d188a486bb9967329edd43ff72e6cffa33b4b49d5b5055b769cb138b27d48b395dbb144dca4361ee89036298440f31b75d02846088da7",
                DateA = new DateTime(2017, 11, 1),
                DateD = new DateTime(2007, 6, 3),
                Sort = 1562504676,
                Note = "e36778cfc65c411e83807d66f3144626ade229b6bdd54f1a92fdab204bc95d3f65ebe9900d7f45bf86241669b655d8b06108350e24554a249dd4706a4cab0a732088f3b58b7344d29d335630d3bc9c97ecc122b5d24d4fb996e480d90465a9dd12456986186c491a80ac0b487a42407aa507f64e19564346a51ed69533dbadae998e1ac21a6a4d8e989ca93460928a7b132dcd24b26c4b1bba63e8aab626adffc7159440bd454b22ac7353e18d40e219adba7ee0252b40cab3ec4dcdc29e15b30c3f31a57ad440e5a0996a559d216d7f27d028be47834c54b435d01cc80e251da4dae98403ed43d09c3d7ba9380e702d6b7f42486a4d409d9c54",
                Status = "98b03b463ed545d3b4a0f10de64a60c49b06abf29af54a37ac"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("7b3d6214-62bb-4783-9f70-381dc3b8219a"));
            result.Name.ShouldBe("847b3b4c81ed42ea9fa5a0a73580f2d9ceb51b5192784b3185");
            result.PairCondition.ShouldBe("5719a0dbc5404ad0851941fd89beecc83749ec1ce16e4777ad949239dadb135c4ca3867cfdf14f12822cfb206d2c861ccf0effc7d52b4551b984372e2085221e9f920b171b324cb390ae2eb1d27c4c0c5d88b4f173c8459a9da7a44637a7d54cb5e097d080db4a8bb9cb17a39bf61d209ef5bd4a7f2d4770ab5e1399b52fd4c86aa7e4d1aa744e34a6086592f397177cc7371f32f8d7419e957d49def9b37cc9dc957373ca76476ea1b5f5d949e43ddd8ac3430c92a14a5f9f1993efc395056117748c11cbb84f4280d0bf718051d71d2ed109f7c7ae48faae672bb0409d8fcfa19a149b60554da5b9076bb7b38a6368129863879ff74d5481be");
            result.ExtendedInformation.ShouldBe("98ab2fc2943047f68007f329ee701a9247ef37177c1e4940b86fed0447d9bae460e0da6186d742989a9b9f053c4f13b89f354a7db03e46e8afaf536e71a9ff9359c40f99b21b408eab892a50c9209d08f3ca4cd9f6264f499c0b93c0d11046bc81ec0f4813a740d6867b519dfdabfee5d5ff08abf837476e88bb2088493cf20f393fdebf73774fdea42945f72e71ad701103ac63722844ea9ff1d9351f640c1f30b36889ca3e4b53a5d3781313b234672ae0a247bc004d49b31809e17e572fb1ba7ebb6d188a486bb9967329edd43ff72e6cffa33b4b49d5b5055b769cb138b27d48b395dbb144dca4361ee89036298440f31b75d02846088da7");
            result.DateA.ShouldBe(new DateTime(2017, 11, 1));
            result.DateD.ShouldBe(new DateTime(2007, 6, 3));
            result.Sort.ShouldBe(1562504676);
            result.Note.ShouldBe("e36778cfc65c411e83807d66f3144626ade229b6bdd54f1a92fdab204bc95d3f65ebe9900d7f45bf86241669b655d8b06108350e24554a249dd4706a4cab0a732088f3b58b7344d29d335630d3bc9c97ecc122b5d24d4fb996e480d90465a9dd12456986186c491a80ac0b487a42407aa507f64e19564346a51ed69533dbadae998e1ac21a6a4d8e989ca93460928a7b132dcd24b26c4b1bba63e8aab626adffc7159440bd454b22ac7353e18d40e219adba7ee0252b40cab3ec4dcdc29e15b30c3f31a57ad440e5a0996a559d216d7f27d028be47834c54b435d01cc80e251da4dae98403ed43d09c3d7ba9380e702d6b7f42486a4d409d9c54");
            result.Status.ShouldBe("98b03b463ed545d3b4a0f10de64a60c49b06abf29af54a37ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairUpdateDto()
            {
                UserMainId = Guid.Parse("b05a4edf-219d-48b0-992a-e0cae0d78d50"),
                Name = "21f579a5e65a4825a643381201b89169a3bfcee935ec4225af",
                PairCondition = "bc98c62a235f4a5b8ce8c3ea1b5b6dd8922b77d9f0914263966630d233202cd82963b95ef08b46f096706743202142e5cb7da240c03a4e6e8a9ed85c66f800af0612a6890a27492e8a76186bbea5c9934b2bab292c594aa4a4f23f6c4d99c6cec19df708749340aaa7d3de805fd9718ab1c2d6b89377485c82f666ecf788b931cdd2a3490e194788ac229762701972bea42287be94b8479894dd729ea8c1321164a2f36a12c8408d986817068c2b4a69969ad95707854d05b29bade1fca114cb0160a20eef714926b48c28438cb6a7bb8b2eb4dab8e54a4aaf01053f61a89d0ac595b162be3b497dbe55ffefde99df6aa41c851b42934ec8abac",
                ExtendedInformation = "007c05df03dd45f59300bc9866c225feb97fff7839934d9aa3352d5809008ce578ab1252ceba443eac575a89bf5b795b2a88e7c2ee1844da93ebd2376c480fb5c2bd93b97acc4ec2a94b930ae5dab2320b1b1660363442f9aec5bdca07b9253a107e5bb6d9904b2fbc845e8494fa08589e93884ce0ee440ba96361f4bcd0163eee081544ed364c9fa7cf79d97e8b062cce7df8ddcebb485ea9f17207207bb5c3c3c2eff2424a466bb787fdd552112dc37966deb136904b35a48191e158cbe678ccd7a0fc75e545c9866d3d4a4b35384094b92fef7f3e497e9d50f0a9e7ac3fd660194faca668491ca96c6a8c2b8e332ffcdc48db10e04756979d",
                DateA = new DateTime(2017, 11, 18),
                DateD = new DateTime(2002, 4, 23),
                Sort = 269859210,
                Note = "a843472fa91b42e19eb9831ed352522af9fe641f0da74a2b9cfdc43867d28ad5e8e99210b40947b9bf094d67d30b366e125264e800f042618aecd55d278e0211ec256f2887264ce2acc7388349700bdaa793ccaf88304b078c6202855031b6c28aa2fca3762847d18c66fa156afff46fb180c2286da44b9e9586742cd09ba1e618eb1c9aaa2f4a83a40b86ee0d5d4cdbd207e10e7f934d34a17dd29a0f75ffa76882a8396b9b4252b85c89d48f2fa9c371f1aab02d8144aaa6635482e7dc7d73ab794bf42c934ee5b04cc7633b7d789e3f42798491d047c8a4aa202358a4a816d2a2f35eb37f4b5183dc147aa8b6bc03608de4cc811946ada0be",
                Status = "c8c01513b1134c60979c670c0b31936417e879683c314bbab1"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.UpdateAsync(Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"), input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("b05a4edf-219d-48b0-992a-e0cae0d78d50"));
            result.Name.ShouldBe("21f579a5e65a4825a643381201b89169a3bfcee935ec4225af");
            result.PairCondition.ShouldBe("bc98c62a235f4a5b8ce8c3ea1b5b6dd8922b77d9f0914263966630d233202cd82963b95ef08b46f096706743202142e5cb7da240c03a4e6e8a9ed85c66f800af0612a6890a27492e8a76186bbea5c9934b2bab292c594aa4a4f23f6c4d99c6cec19df708749340aaa7d3de805fd9718ab1c2d6b89377485c82f666ecf788b931cdd2a3490e194788ac229762701972bea42287be94b8479894dd729ea8c1321164a2f36a12c8408d986817068c2b4a69969ad95707854d05b29bade1fca114cb0160a20eef714926b48c28438cb6a7bb8b2eb4dab8e54a4aaf01053f61a89d0ac595b162be3b497dbe55ffefde99df6aa41c851b42934ec8abac");
            result.ExtendedInformation.ShouldBe("007c05df03dd45f59300bc9866c225feb97fff7839934d9aa3352d5809008ce578ab1252ceba443eac575a89bf5b795b2a88e7c2ee1844da93ebd2376c480fb5c2bd93b97acc4ec2a94b930ae5dab2320b1b1660363442f9aec5bdca07b9253a107e5bb6d9904b2fbc845e8494fa08589e93884ce0ee440ba96361f4bcd0163eee081544ed364c9fa7cf79d97e8b062cce7df8ddcebb485ea9f17207207bb5c3c3c2eff2424a466bb787fdd552112dc37966deb136904b35a48191e158cbe678ccd7a0fc75e545c9866d3d4a4b35384094b92fef7f3e497e9d50f0a9e7ac3fd660194faca668491ca96c6a8c2b8e332ffcdc48db10e04756979d");
            result.DateA.ShouldBe(new DateTime(2017, 11, 18));
            result.DateD.ShouldBe(new DateTime(2002, 4, 23));
            result.Sort.ShouldBe(269859210);
            result.Note.ShouldBe("a843472fa91b42e19eb9831ed352522af9fe641f0da74a2b9cfdc43867d28ad5e8e99210b40947b9bf094d67d30b366e125264e800f042618aecd55d278e0211ec256f2887264ce2acc7388349700bdaa793ccaf88304b078c6202855031b6c28aa2fca3762847d18c66fa156afff46fb180c2286da44b9e9586742cd09ba1e618eb1c9aaa2f4a83a40b86ee0d5d4cdbd207e10e7f934d34a17dd29a0f75ffa76882a8396b9b4252b85c89d48f2fa9c371f1aab02d8144aaa6635482e7dc7d73ab794bf42c934ee5b04cc7633b7d789e3f42798491d047c8a4aa202358a4a816d2a2f35eb37f4b5183dc147aa8b6bc03608de4cc811946ada0be");
            result.Status.ShouldBe("c8c01513b1134c60979c670c0b31936417e879683c314bbab1");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobPairsAppService.DeleteAsync(Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"));

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"));

            result.ShouldBeNull();
        }
    }
}