using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.TradeOrders
{
    public class TradeOrdersAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ITradeOrdersAppService _tradeOrdersAppService;
        private readonly IRepository<TradeOrder, Guid> _tradeOrderRepository;

        public TradeOrdersAppServiceTests()
        {
            _tradeOrdersAppService = GetRequiredService<ITradeOrdersAppService>();
            _tradeOrderRepository = GetRequiredService<IRepository<TradeOrder, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tradeOrdersAppService.GetListAsync(new GetTradeOrdersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("a509286d-15cf-4671-80e6-9c157ebfc3cd")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOrdersAppService.GetAsync(Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOrderCreateDto
            {
                KeyId = Guid.Parse("2b5d6fba-79e2-4a55-9cca-1f661b6f41f4"),
                OrderNumber = "ede12fad7fcc475298e480c27f9d0a745f1f32e9109a4a4fb7",
                DateOrder = new DateTime(2013, 4, 16),
                DateNeed = new DateTime(2012, 3, 12),
                DateDelivery = new DateTime(2009, 7, 12),
                DeliveryMethodCode = "f37cf5865935420f9d018346df8a98cea82b001e69dd4ef287",
                DeliveryZipCode = "a91219662bc6435c802a99cb8bbac4920a0fddcd6c6e45a8b9",
                DeliveryCityCode = "588c88db78c242e6bffffc713d4c0ef53542361139104010a6",
                DeliveryAreaCode = "fdd8b34a2d644f739f21b3c328f5fc7dac9d0e90eba34e61a3",
                DeliveryAddress = "3b06eb0dce0b4b509ab3e5dc476bac5066577ab1bdf7488895",
                DeliveryFee = 358460219,
                UserName = "01dcafa744d1482cbf954d315680bcf312e2d23961294f4aa8",
                OrderStateCode = "04167121550d41b7bb6442b6cabb61322b46f56ced8e422693",
                ExtendedInformation = "b2d9fb0be96b46cfa43002dabbdb65c0736e751e2d1842028f52238219268c04f6ecd4e7caab4335b9cf779d529772d2f0a04bb25d23464e93c38e67554780b4178d92debe1d4ba7a334fc503aa433359855b0ea0f994e7e903d18d12789569dc8c60dc7fff240e2b46234b2c4a2c8e78806e73ff4f7445eb1fb8fd4618b5d86a03f872bb7074377a38165a318a4d00a87e9a99bb4c048ceb15233ed9af547457a5b3864b57c4f9b88d6e7c59422b52f82d0310fc3424aacba2744ebece42ea06d91bc1304b74a16b995b96c58163fbe8932f7060af24d2e8b2c73785c7c28bd1457ef5aff8e49b0b03ccfd9758be1f98ec3571a5d684164a0e0",
                DateA = new DateTime(2013, 7, 25),
                DateD = new DateTime(2004, 7, 25),
                Sort = 961986484,
                Note = "59ff1228627e47fdacf8720c5f2957811fc24caa22d04252a2bf7d225937ac9ac00e9dddbd374670927426c37c0b15ed048ee70f52d645bfa360e511070d5fb5ba8b08e1e68349038566ee50142fefa7c440c87c527d4a7f8ed18810364d182a75d645f0944b4daf9d0ff42d1d4de1656b8db16a2fa2489e8636dd5f2ce2484d18fe948cbb694dd8a30e095db606e282bb970cf39a05428d80e552f91c991f9eff9393ed9be1440cbbe1a7f01806b791471977495e42428c85901c2afcbb882a2e11f2338d944ae69b9428a1a0c449941b52f4e7223f4358860a84f8ab18fc021859986c104b400b992f4fa926d269c34ef2af8b7a7b4ac49f7e",
                Status = "8d81acd0913e4c23b87951c95a17882950873b30e2f048e1b5"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("2b5d6fba-79e2-4a55-9cca-1f661b6f41f4"));
            result.OrderNumber.ShouldBe("ede12fad7fcc475298e480c27f9d0a745f1f32e9109a4a4fb7");
            result.DateOrder.ShouldBe(new DateTime(2013, 4, 16));
            result.DateNeed.ShouldBe(new DateTime(2012, 3, 12));
            result.DateDelivery.ShouldBe(new DateTime(2009, 7, 12));
            result.DeliveryMethodCode.ShouldBe("f37cf5865935420f9d018346df8a98cea82b001e69dd4ef287");
            result.DeliveryZipCode.ShouldBe("a91219662bc6435c802a99cb8bbac4920a0fddcd6c6e45a8b9");
            result.DeliveryCityCode.ShouldBe("588c88db78c242e6bffffc713d4c0ef53542361139104010a6");
            result.DeliveryAreaCode.ShouldBe("fdd8b34a2d644f739f21b3c328f5fc7dac9d0e90eba34e61a3");
            result.DeliveryAddress.ShouldBe("3b06eb0dce0b4b509ab3e5dc476bac5066577ab1bdf7488895");
            result.DeliveryFee.ShouldBe(358460219);
            result.UserName.ShouldBe("01dcafa744d1482cbf954d315680bcf312e2d23961294f4aa8");
            result.OrderStateCode.ShouldBe("04167121550d41b7bb6442b6cabb61322b46f56ced8e422693");
            result.ExtendedInformation.ShouldBe("b2d9fb0be96b46cfa43002dabbdb65c0736e751e2d1842028f52238219268c04f6ecd4e7caab4335b9cf779d529772d2f0a04bb25d23464e93c38e67554780b4178d92debe1d4ba7a334fc503aa433359855b0ea0f994e7e903d18d12789569dc8c60dc7fff240e2b46234b2c4a2c8e78806e73ff4f7445eb1fb8fd4618b5d86a03f872bb7074377a38165a318a4d00a87e9a99bb4c048ceb15233ed9af547457a5b3864b57c4f9b88d6e7c59422b52f82d0310fc3424aacba2744ebece42ea06d91bc1304b74a16b995b96c58163fbe8932f7060af24d2e8b2c73785c7c28bd1457ef5aff8e49b0b03ccfd9758be1f98ec3571a5d684164a0e0");
            result.DateA.ShouldBe(new DateTime(2013, 7, 25));
            result.DateD.ShouldBe(new DateTime(2004, 7, 25));
            result.Sort.ShouldBe(961986484);
            result.Note.ShouldBe("59ff1228627e47fdacf8720c5f2957811fc24caa22d04252a2bf7d225937ac9ac00e9dddbd374670927426c37c0b15ed048ee70f52d645bfa360e511070d5fb5ba8b08e1e68349038566ee50142fefa7c440c87c527d4a7f8ed18810364d182a75d645f0944b4daf9d0ff42d1d4de1656b8db16a2fa2489e8636dd5f2ce2484d18fe948cbb694dd8a30e095db606e282bb970cf39a05428d80e552f91c991f9eff9393ed9be1440cbbe1a7f01806b791471977495e42428c85901c2afcbb882a2e11f2338d944ae69b9428a1a0c449941b52f4e7223f4358860a84f8ab18fc021859986c104b400b992f4fa926d269c34ef2af8b7a7b4ac49f7e");
            result.Status.ShouldBe("8d81acd0913e4c23b87951c95a17882950873b30e2f048e1b5");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOrderUpdateDto()
            {
                KeyId = Guid.Parse("a5d6b1cb-ee2d-43ce-b031-9569e315e7f6"),
                OrderNumber = "5283548d16c846be81af681f6ba4e47242fc44bab3df4d289d",
                DateOrder = new DateTime(2009, 2, 2),
                DateNeed = new DateTime(2010, 4, 8),
                DateDelivery = new DateTime(2008, 7, 18),
                DeliveryMethodCode = "d66346a0f7cc41bda53b5a8c4c57539bf70a347e56f24e72b4",
                DeliveryZipCode = "22d0eaf1579443e6a66a2b32bcfb50e4791ac809bf634ebbbb",
                DeliveryCityCode = "df01005dcf424a73aa02130b605ad56ce319154583e64c3787",
                DeliveryAreaCode = "bf48e62a868d4364a3e3828fcadcf1e1a0ee477fb59b428399",
                DeliveryAddress = "77852f14da084a729a7129468265d32e32e9324331c948d982",
                DeliveryFee = 1435255069,
                UserName = "78b266497e764b02ba9db06418a61d28f1bb4e03510447c9b6",
                OrderStateCode = "79570d1008ed444da378f4795c80c36b9c52978d0c68457a96",
                ExtendedInformation = "c446286a328d4d488a2b4e3a0f2e4333f95bf8d6f3ee4b63ae3331c44d049bbb0714145495f74f1aa54be0bc4b7462ebbd2cad62a3724f4ca978690b7d98c7f65d60246bd2e440a280eedc10ef1d0d6c2b59b7c210074a99b694d67cf15e253b251980e57dc74e53b2d727cdcb663b563ce0084e20684395af14f21b732f1b388f2681aeecd54412aa333b74fe8ca823a44761ea74cb4ca3a4ed8bac929b5283e3c3bfaecfa64e1aa202451a08a33bfd73f38d97a8c047f298555de577fe76dae5facec5065e4ea1ba11106c98b9a4f8b2c418717b4b4c08bbfb568e818053a336d4ff297189418c94fb22d6d8c0f0411a30fd27738747c1bded",
                DateA = new DateTime(2012, 6, 3),
                DateD = new DateTime(2002, 6, 27),
                Sort = 837132299,
                Note = "b828f88df9974dc6a118cf761019c54e10246a798ea548cb8d7137ad0144a194965cc8cf31cf41ed91f171a239bdb1e6e22cb3b2a94d4abda964969aa1a3e25589f3d38c80484d98a55d459abfd544266033ece1b13448cd98237c34aa7451f271fc34081570438691f7c056d7febad4605eb211bb3549258467211f448f00defed50b5ac54046d585b90c0a4c08367acd0a3f6117ee4c53a52749ed87f6be94ba7a769b7f02438ba1e3e00cca87e37793bd0d54de9d4c958b33ace3d95ec69241bd845d6a264e0a9124347b8439c3c268d1156600824a689ec8ab0f9ef4c1f85ea2fec6f0ab41dc94bc6980d983282304e8f99e83754a049c14",
                Status = "38eca38c621348e7a6dfd09391cc3772ecfcf418977041dc8f"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.UpdateAsync(Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"), input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("a5d6b1cb-ee2d-43ce-b031-9569e315e7f6"));
            result.OrderNumber.ShouldBe("5283548d16c846be81af681f6ba4e47242fc44bab3df4d289d");
            result.DateOrder.ShouldBe(new DateTime(2009, 2, 2));
            result.DateNeed.ShouldBe(new DateTime(2010, 4, 8));
            result.DateDelivery.ShouldBe(new DateTime(2008, 7, 18));
            result.DeliveryMethodCode.ShouldBe("d66346a0f7cc41bda53b5a8c4c57539bf70a347e56f24e72b4");
            result.DeliveryZipCode.ShouldBe("22d0eaf1579443e6a66a2b32bcfb50e4791ac809bf634ebbbb");
            result.DeliveryCityCode.ShouldBe("df01005dcf424a73aa02130b605ad56ce319154583e64c3787");
            result.DeliveryAreaCode.ShouldBe("bf48e62a868d4364a3e3828fcadcf1e1a0ee477fb59b428399");
            result.DeliveryAddress.ShouldBe("77852f14da084a729a7129468265d32e32e9324331c948d982");
            result.DeliveryFee.ShouldBe(1435255069);
            result.UserName.ShouldBe("78b266497e764b02ba9db06418a61d28f1bb4e03510447c9b6");
            result.OrderStateCode.ShouldBe("79570d1008ed444da378f4795c80c36b9c52978d0c68457a96");
            result.ExtendedInformation.ShouldBe("c446286a328d4d488a2b4e3a0f2e4333f95bf8d6f3ee4b63ae3331c44d049bbb0714145495f74f1aa54be0bc4b7462ebbd2cad62a3724f4ca978690b7d98c7f65d60246bd2e440a280eedc10ef1d0d6c2b59b7c210074a99b694d67cf15e253b251980e57dc74e53b2d727cdcb663b563ce0084e20684395af14f21b732f1b388f2681aeecd54412aa333b74fe8ca823a44761ea74cb4ca3a4ed8bac929b5283e3c3bfaecfa64e1aa202451a08a33bfd73f38d97a8c047f298555de577fe76dae5facec5065e4ea1ba11106c98b9a4f8b2c418717b4b4c08bbfb568e818053a336d4ff297189418c94fb22d6d8c0f0411a30fd27738747c1bded");
            result.DateA.ShouldBe(new DateTime(2012, 6, 3));
            result.DateD.ShouldBe(new DateTime(2002, 6, 27));
            result.Sort.ShouldBe(837132299);
            result.Note.ShouldBe("b828f88df9974dc6a118cf761019c54e10246a798ea548cb8d7137ad0144a194965cc8cf31cf41ed91f171a239bdb1e6e22cb3b2a94d4abda964969aa1a3e25589f3d38c80484d98a55d459abfd544266033ece1b13448cd98237c34aa7451f271fc34081570438691f7c056d7febad4605eb211bb3549258467211f448f00defed50b5ac54046d585b90c0a4c08367acd0a3f6117ee4c53a52749ed87f6be94ba7a769b7f02438ba1e3e00cca87e37793bd0d54de9d4c958b33ace3d95ec69241bd845d6a264e0a9124347b8439c3c268d1156600824a689ec8ab0f9ef4c1f85ea2fec6f0ab41dc94bc6980d983282304e8f99e83754a049c14");
            result.Status.ShouldBe("38eca38c621348e7a6dfd09391cc3772ecfcf418977041dc8f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOrdersAppService.DeleteAsync(Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"));

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"));

            result.ShouldBeNull();
        }
    }
}