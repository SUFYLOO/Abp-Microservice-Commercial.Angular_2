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
                    name: "de95d8db57c2417fbf4115875142c6c618c3b43fc78f411c80",
                    contents: "e13a769b5726489594ff7c7466aa60fb2dac68d9a1d44f9c84c26b5539196a5296848eaf39ec49c0901a313aff7ec7f2b0814f9ab48b4344899fd3609e4531c5b64ff7a8a524421e81898ed30fe8a6fa00ec6dbb3cd34c89977d5e29d161bd16a465b6f2ce0443279b16ea5beed13f27abd551fcdb5748d89c25659bed729594a62a779a99dd442bb7457b8fed34e73696c9ae615fc6409e8df2673eb671eabac6229c0dc2944c53a1a0ff144f6c59e3a310062645724fca87dc89cd4cb1676dbaeb63fdcc1942d698e39ca5046bc8913215fa1bdaff4a408f33a0e7f8e3fb29a909811d8f7349e0b1a3d2146787b333094a691a3f4443ee8e21",
                    productCategoryCode: "dfbbdca3b91f484fa1a67fc37834d0742a5a207540aa47219c",
                    unitCode: "67f00abe53674a86983f6cf25753094f9b1cf8febbdf414482",
                    extendedInformation: "309a5d2275174392b08c25cc89ddef21350077e954724a9db319054bffa4b8b6de571e0835bc44e5938b08cde6a47e8cdb92f828c8484dda843e681d278d92dc4c18b913b037449788435f0f9cc79836d10942fca24e4a63adee7696bddcc23cf281740be94c4ae18a62ef8f832b6f07f5111e1b480a4ea18d2dc41c7a770d042807c0f245c045acb072b8a811213fe6915dd5ee31224434aff65ddb86640c7aac27da42cd3e4b419e9f25852a79ef62fa9466b3491e4be6b528d41a738356f1836f8aa6c6cc47e19bb48ff234fdbbc13a0e4dc360ba4862aa09287b4676fc5020bc578b24664f8f8d3ac56b7d364b093980709904eb44e6856b",
                    orderStateCode: "a112ba31bb6340549b33b84d7e59ad2381e8901154244faaa8d3e28b71a5b37a13e83fcef3204a99916cce3889a1703700ac83da931e412a84d3d53fe04c0ca6201a3e9f281148e1ba009aec0773ea6ffda6c8004620475f986e7a778d753b7323b3319ca3a34e55aa204eeb4d3e0d2d4151c15931414a1aa5a5074532733e2b0e1e359651cc427b8a96c1296211164d53f51c32337e4037965c009cb2c3b0befa161455869245e7b82a3306bce61fea9b6084b157ef42e7ad82a23aecc38425bb9e8579794b4c3097a38453ef51e68c3f133cfa4f2f4a4ba27bb629a95f0022efd55ca2a063414f98b46848639ab048a59488fe662f41038875",
                    status: "5701813470ff418c9217f1b648083592057af53f261e4443b4"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"));
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
                    name: "4da5e1b02e2f4ddd968c19002ab8b149533f203a4b2c463ba2",
                    contents: "72a35fe8284f4f7fbca047ba916bbf66d032546ed30c4dd393c35208d3c007c4ac42e7d27f9b49599cb09afaf5997d96e42334cee8214158a7386a5c35ff416eb2c514bca597415b87190e5fa19df0e748ba34bb482c4ddb8ec685cd4e6c2473ccb515abe9aa436daaa5c8ac9a800b85e4a706d36ab1458dbe685e0ab247c53b76b5f9a8890e42229c45c6a35183ddfb4226c60a48d74178902e6fdcd567da1783061fc8bf3946aea143146d620518efeeeb5e0529d84d5fb64a67898eb92a3c954f2531f48546f4a26924d488dfb0bf0105ad6273c2423db80a1190e1b49f4147286fb64ecb4c86bea5761a9aab5c60191e6299d0184e84a65f",
                    productCategoryCode: "87750d6ed8724c4483a4ea4ff816c42dea228426ef6144b2a0",
                    unitCode: "b14707396910469497669547a1647c53cffa94db00c543118b",
                    extendedInformation: "df6ef3e0441a4592b0afe3211774da707dc07692425d4e9fb53529dda3f9b53029f9a34b2fbd4a568119e007cc2dc444545674435d0c41b5b81f01580d511f2b8f6b485ec01c4ef184e72cb22539bc7bcd5234aab90d48f4aad07c1605d18df21ea503cf0a7b4d2e9c93f28869fc40422d62db90615548b0bfb272b850ff22cdd7c9e11d31444fc884debeb7cc556635c40b2472ef1644f6ba62d586c8ca7e99d1b12549a10541b085fc326909d822735d25be61ebb641d19edcfa7f66e995a32a83f3e530614dca9aba1f036eb5e74cbfc0ca96392948f4b880031eb376dddfe9fc2e873cc641f8ab8ef46d5b49a1f1c7638f5aec0f470497b6",
                    orderStateCode: "25eeb4ca54d64908953b1909f21abe76568bf85fd8ed4d53920ea2485ea2fc2cc0be2a90c28f4a1e88857fdbd6a4409bcd90d965dc1f483189c3b87f7266ce8790bd03a048834de890a1b17494cf256a3f25f50eaae34636992c7259f49d717792727b6b4e214b7ba403e73dc991efdfb7c0e46d2f3d4782bf493a700755a13384218d99dd3244c1b11053bb2145046faecb5d9e58c244d2bab043c0073e3ee7395d541f201f44039916f9dd4a076c8be4d9ade880454804b895812586375ff6d8e8d770bbc44a3aab05d3e99d3ec1d8fcab970abe55477aacb9bf0722176cbc7dd32037524c4f0f9b99a080d835a53a6820708ad1f64aff9421",
                    status: "d958df109de64d1ba32dd65d4a500e0d3689fc593eca43e9ba"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}