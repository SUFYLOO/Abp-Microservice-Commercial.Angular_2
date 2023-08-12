using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.TradeProducts;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.TradeProducts
{
    public class TradeProductRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ITradeProductRepository _tradeProductRepository;

        public TradeProductRepositoryTests()
        {
            _tradeProductRepository = GetRequiredService<ITradeProductRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeProductRepository.GetListAsync(
                    name: "06e279d843344c66a53d345435d4e044e78377abff6047b8a4",
                    contents: "fe3570c746fc4d929c820a246c6400ef630c8a74dc16490bacfbab386e0b09ac453483c12aee4715b6931d34de827bf76627b08deb444ac893ba28cd5a1230b2a051da36d384441d961b160a1bd7c95b8e85f3f0faa54a5682f9b362d39ebd1008004d8066d94264af41ec3a4e5acb126b95256e0893460bbd28cb32c87421977b6731d965014226bc4e2e11575fef966187daa7905b4363ba7ec6b6b2d4debce6c395642db3497d8ba981697c48c1fb072d356e777f40379a8be0fb04be13d27044bd8eeea14a5e8a47e191bd4c4e2e9326254bfa0e4868b4b9090e6ac7aa400852c46be1c744d2aed194390ffadbee83ec1c96b29d4c1595e5",
                    productCategoryCode: "a675d96de39d49bebe060fb261c1bfa69cfe5c8d5fe04ea399",
                    unitCode: "28ac3c33db7d4b0980563402029754ced252dbe4a8d44828b6",
                    extendedInformation: "8a9207d07302463eb11f378ae86ca6f93885af14d27f4c469c18e98aab65fc723465e328dff74edeb365de6cc18cadb2716c7d150bf24a768b3bc98e1a070dac049724c617ff491ebaff282c24ccb8ab1d4da6727e7249d980483efa745c6b22456cd693b4424b71baa9eb3865a2bc605df00078eab44c71b017f9ab25abd69d9a81e7c4f7c44a79b41ad34db5d9cdf467816863e079492499358cca7e88626a7a8b6a792e0d4583a4000c5d503e22e151d8cac6d14b4052bffcc5960cfe0bcb2b87fc9cb6774c108562fbeda41d0ec5c7f26c7f618142639cb07a6922aab83ef6e388d867894e528ce221d74d5db99b169a35392e9b495ab9b0",
                    orderStateCode: "accb6f180e524ce18772c63d49f332eae86fac90dd9d4bf483bfbd66e1bda0e76b67dee177594b3cb0cab772a8acd781afd100d427014003a8f861458abb75b7feba4fd04cb34944881ddb6ea1d1becaea6e6e134f784b178f10ff00a0799c20d38f80be1c3543829055109b650f5c6759264de991a44933bcdd589121164cc2f19b423186354ad99ffd68347097500b5e9b3010c3e14aa996e093b1e2d80274eed0883a9752442ebbaeec59a991735a2e3ca371d4ea4df28ba8e904e9584073eb8ffca78c154e86947cfe4102892de346ad27d6c73d46f985440152120621d2c24892429f44435b8f7765264ed37797749322d597f040d09032",
                    status: "1917d3b24d26437aa10d9550201e55bc8d94870a1a0f41dba6"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeProductRepository.GetCountAsync(
                    name: "a39457f9c4b04d7db78f73c85895567dda4b51c7cf6c4c7caf",
                    contents: "66fef9d13d114401b26889d6e2e35fb873e0d794562c472db6cd8f8342573d31ba6c8935cfa34fc5847f75ae0363f9b6f7319aba98b647969cebf406b17bfb8fcb9ed96f1ef04531a7fa53a76a8728754c5daeb5326242be87e7f4741c58804fe8328e38c9de461eae8a182c91d0497bd79089354a0e4e54a2c20e7d9fce567dfa469a4b8d1d4203a0c82b5b4b3b6ac8303cbee2e91646648a5cf57236fddcb4290c6157f8a34aafae519cbe3a00a9257d809c704347477b8d9293576a702ea8cfcfbfbe80934129a801d250a0a17021687c6897c6a245a5ac7da65fb1f6c3ebc68cdc84418846f4967b781038d19d5f60b11e792478494d894f",
                    productCategoryCode: "33429676e17a4395858a18ba1ea53433da5ec757997d468c9c",
                    unitCode: "58a8cde8d92649f2b3a55b0d98a502debd4547aeb5584ead88",
                    extendedInformation: "054255cc2fa74d2d90d2656bef6c1077dc85c677ee6d4651bcf4f16727915d1e91fe7525eb2d4763b6e7cc0265fd55a5509ef305d842459fbc829c00c3e019b3782890b81c5e427fb169e16d73eea78372ac190f225740b38129f5aa649bfd7ae39ca7a3b4424f6ba87527fe45e8534f2002a4468fce437f93056a23e8152cdbd4316d8745f143fdaef4c40e65f862d2db7b7bf65b9d481088e4087f37809467cb510617d2e64645ba8597c861d441e9d3f3b8db48b64fb5b487f9e6a36a26c0d80c6cf9176e42aebf70798c56a997fbedb9c4004f22465bbc0c4b3066c523f2640f8cbafe51457c8550368ffc003b380f42adcade304aa79008",
                    orderStateCode: "59e7a3cd99564e85b523fd8145d117381e86296656144df392c5bf43d53fee8ee14f32687469458b84f2b7931e69e47ea3d917a7ad56425b9551de78750e872856ddbd4378024cee9bdfa400cdaf4f23069476bafc284cccbe40b14daaa8e680f1fd688605ff497cb20c1ca08197ae2fc1a38f75e38f4ff3a3b3de4522600e99bf008ec457d44139a0f4c2dcaddadcad4542624a459646e08be39d35c9d68c82c70b96a072214e34aa842d689e39e688e3943948f9b04761a2775847257e73ae56dc96b352504577930cb1155350a9076ee2b2d8901d4ca2abf12deae25424d580daffcc5de24239b10e991e136e661b1a124c63566c41a68cd3",
                    status: "df4029bbd13442a3917510522c550f71f0dc6e0c6a324162b9"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}