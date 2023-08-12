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
            result.Items.Any(x => x.Id == Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("875aea5d-a415-4138-862c-b1b278e3b70c")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOrdersAppService.GetAsync(Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOrderCreateDto
            {
                KeyId = Guid.Parse("bf967ab7-c22b-4edc-86aa-78120317b390"),
                OrderNumber = "a7951ef0fc3045e5b7e346da2f9f2689391169ca404241709b",
                DateOrder = new DateTime(2004, 8, 22),
                DateNeed = new DateTime(2011, 4, 7),
                DateDelivery = new DateTime(2017, 10, 1),
                DeliveryMethodCode = "f69727dcac6a4fbea64875b0996d67f615354d30dc464183a0",
                DeliveryZipCode = "0c14b6cd7bb8430b842d33da64c40690787fa071e8fc46cea9",
                DeliveryCityCode = "3676eac02b924e7c8e4916b2b3f09f50f8778e6c3d5a481485",
                DeliveryAreaCode = "d29ff39e60c44b57af70525c124934c32c0d7df0bfea40bba2",
                DeliveryAddress = "7beaa248dda14aff924f547621bc0443e0e3b54fca814b0bae",
                DeliveryFee = 719442374,
                UserName = "d3c3af58023c4943b6e2686a126aaa3381a2964fb4d94c59a0",
                OrderStateCode = "b7ba6689d2d044e3b2d8ec81e0fa187eb2a836f44e394eac8d",
                ExtendedInformation = "b0065ba65b01426ea40ea24d823ee0afc39a623ce4dc4c9b96d5517b85989e9d0da8a1c10ff948bb82365bda23f5d6d0bda6be25648a4734b6691b0ccf273b7f1423ce1f613144cdbb4aebb5449edc0c6954ed9eb9234866ade23c4dd8b4aa6c17c40a60f99648779268e9fb710611be75bc3d99441744819077187fe90d4db5f02e02188f9e426db9e7ede0a01f54314cd5d13b7f7e4ba0878dac531cb3e49d9e9bc4af81334129a1a3d6347fdc013e1c80c51177ee442fa28cedb2c6077d6cc616324613fa4b65af834c19a58f6b8ddce3eaec8ea6422fb5b5dd9cc7696fe697211e10cd49433787a5ecd87502d36af6e8f5c4702e4d7cbba0",
                DateA = new DateTime(2008, 10, 10),
                DateD = new DateTime(2018, 7, 5),
                Sort = 464315852,
                Note = "5ed9d52a304a46729d79eddb26b567288c3bae0da1f54ae889915c4cf419c6f4a09c0a6deeac43d38f89ca2d31cd997f69e05dc7f77b46d1afd2c34f44dc0e95e487037de94e473b815ab7d037139b9a69425335de0643c5bf3bd29499a536dddac735f579ee40d8bab96776da8408fae414c419476a418399583180eb3d487bb594e86e5fe64516877d331f0d544d3e94ccb8cee55343a6a4a8d5af7fe6d4641d2228d507f347ab874477c455175ad63a438008e99e4209bb9b14e07cdd2ff262e113ec4728436baeed095cd7f3bbeb296860722a5541868c01b21c87cf120b52da8a6dca3142819c173810e224c527fa25519ba2664a22b1a2",
                Status = "6ac4edad2fb5488397f58b2bd62f8e432f12f63130864ff9ad"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("bf967ab7-c22b-4edc-86aa-78120317b390"));
            result.OrderNumber.ShouldBe("a7951ef0fc3045e5b7e346da2f9f2689391169ca404241709b");
            result.DateOrder.ShouldBe(new DateTime(2004, 8, 22));
            result.DateNeed.ShouldBe(new DateTime(2011, 4, 7));
            result.DateDelivery.ShouldBe(new DateTime(2017, 10, 1));
            result.DeliveryMethodCode.ShouldBe("f69727dcac6a4fbea64875b0996d67f615354d30dc464183a0");
            result.DeliveryZipCode.ShouldBe("0c14b6cd7bb8430b842d33da64c40690787fa071e8fc46cea9");
            result.DeliveryCityCode.ShouldBe("3676eac02b924e7c8e4916b2b3f09f50f8778e6c3d5a481485");
            result.DeliveryAreaCode.ShouldBe("d29ff39e60c44b57af70525c124934c32c0d7df0bfea40bba2");
            result.DeliveryAddress.ShouldBe("7beaa248dda14aff924f547621bc0443e0e3b54fca814b0bae");
            result.DeliveryFee.ShouldBe(719442374);
            result.UserName.ShouldBe("d3c3af58023c4943b6e2686a126aaa3381a2964fb4d94c59a0");
            result.OrderStateCode.ShouldBe("b7ba6689d2d044e3b2d8ec81e0fa187eb2a836f44e394eac8d");
            result.ExtendedInformation.ShouldBe("b0065ba65b01426ea40ea24d823ee0afc39a623ce4dc4c9b96d5517b85989e9d0da8a1c10ff948bb82365bda23f5d6d0bda6be25648a4734b6691b0ccf273b7f1423ce1f613144cdbb4aebb5449edc0c6954ed9eb9234866ade23c4dd8b4aa6c17c40a60f99648779268e9fb710611be75bc3d99441744819077187fe90d4db5f02e02188f9e426db9e7ede0a01f54314cd5d13b7f7e4ba0878dac531cb3e49d9e9bc4af81334129a1a3d6347fdc013e1c80c51177ee442fa28cedb2c6077d6cc616324613fa4b65af834c19a58f6b8ddce3eaec8ea6422fb5b5dd9cc7696fe697211e10cd49433787a5ecd87502d36af6e8f5c4702e4d7cbba0");
            result.DateA.ShouldBe(new DateTime(2008, 10, 10));
            result.DateD.ShouldBe(new DateTime(2018, 7, 5));
            result.Sort.ShouldBe(464315852);
            result.Note.ShouldBe("5ed9d52a304a46729d79eddb26b567288c3bae0da1f54ae889915c4cf419c6f4a09c0a6deeac43d38f89ca2d31cd997f69e05dc7f77b46d1afd2c34f44dc0e95e487037de94e473b815ab7d037139b9a69425335de0643c5bf3bd29499a536dddac735f579ee40d8bab96776da8408fae414c419476a418399583180eb3d487bb594e86e5fe64516877d331f0d544d3e94ccb8cee55343a6a4a8d5af7fe6d4641d2228d507f347ab874477c455175ad63a438008e99e4209bb9b14e07cdd2ff262e113ec4728436baeed095cd7f3bbeb296860722a5541868c01b21c87cf120b52da8a6dca3142819c173810e224c527fa25519ba2664a22b1a2");
            result.Status.ShouldBe("6ac4edad2fb5488397f58b2bd62f8e432f12f63130864ff9ad");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOrderUpdateDto()
            {
                KeyId = Guid.Parse("e84d3be8-c3f9-4431-87ee-2f5eeb326e5a"),
                OrderNumber = "f2c91c456c234a5fb5994f3cdc60812df35299d5513444caa9",
                DateOrder = new DateTime(2012, 3, 25),
                DateNeed = new DateTime(2002, 8, 21),
                DateDelivery = new DateTime(2022, 6, 12),
                DeliveryMethodCode = "41a87dd7631c48c9936a379dea8992aa73db6c4291f246e084",
                DeliveryZipCode = "b756908f2ba44f07951f48a52c21c59d5eceffd704e14ed59f",
                DeliveryCityCode = "53e902aa59ea4c12ae4b80d9e688c11cfeb72ceb88d94196b6",
                DeliveryAreaCode = "2e7387a020f04874bec47726956150def63eec33c73a4620bf",
                DeliveryAddress = "2d6365c882dc48aa94e1659ebef3244722578fac70ef43c196",
                DeliveryFee = 1699055544,
                UserName = "dacb355cce5746058a94553a18b6f343a8e224a60bdc4ad58a",
                OrderStateCode = "feb2fa2ea04647bab6a08968452df00a9f4292ba509c44e4b1",
                ExtendedInformation = "df9d9f8dea644a9ba1263cbe4b1b1dedf5fcc01b4e8145d2903fec2c0217a15be37f0e04b7774cd99a8669cad1d73d467a16ab0e74ac4a328e7ba9c571d1c8ec6a113069d15547f4b60176ba406afcb7f3e7306f288f48aa960ddd500169b3f7dd1de204c900491ea78129a1d109aa30657eee8bf25a42cd938e140375c448c6ee94cf762e1a46fa8621843ce9bdcc2e36e61138c4f442cab651ea3525268d00a111f7f2fdc543c8aaf9f42b42011617870105139af444d58c8d943e0b9985b53abbfcbdb0464584a1a49f3bead827a5d8ec280a2c744d338f4e16c02cd8b50515a9576e28744c63a2c62e426d6f08995812274ea83f417d8b30",
                DateA = new DateTime(2000, 9, 12),
                DateD = new DateTime(2000, 1, 12),
                Sort = 1788156105,
                Note = "8f7c8145477344c6903a5c39018f6c41ff7b27e38185433092638fd01ef69eb075e3e65e7f254a63918025b470e2b4277a5083fe2175474aa5ffdb92550170980adab8aa392b478e868acb752131ee8d915c85d2ad384fa392ae91fe2ed04ab3e47744ccefa7430aa4e9fc8b625bb5cb6b6bf02ea17d4c96a9a058de41d6126d8b0877195f5e434aabcaddbfcf023a019c11d19720544e558adb3b09c1fafe45dd38ee71ad5749209456de5e987c8f78d3531e2531ca4ee2a77a70277ea376d0f76f7134db8b498d88d119b9df2e6b79c400271c61c541ffb803f643610bf53e7c02e8b092b249078323b48bf2a1fc0e11ddc66532c64d609f6e",
                Status = "6659d9dc0f4949e0b680bdbac8065f25e6de8c4ed2dd4ebf87"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.UpdateAsync(Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"), input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("e84d3be8-c3f9-4431-87ee-2f5eeb326e5a"));
            result.OrderNumber.ShouldBe("f2c91c456c234a5fb5994f3cdc60812df35299d5513444caa9");
            result.DateOrder.ShouldBe(new DateTime(2012, 3, 25));
            result.DateNeed.ShouldBe(new DateTime(2002, 8, 21));
            result.DateDelivery.ShouldBe(new DateTime(2022, 6, 12));
            result.DeliveryMethodCode.ShouldBe("41a87dd7631c48c9936a379dea8992aa73db6c4291f246e084");
            result.DeliveryZipCode.ShouldBe("b756908f2ba44f07951f48a52c21c59d5eceffd704e14ed59f");
            result.DeliveryCityCode.ShouldBe("53e902aa59ea4c12ae4b80d9e688c11cfeb72ceb88d94196b6");
            result.DeliveryAreaCode.ShouldBe("2e7387a020f04874bec47726956150def63eec33c73a4620bf");
            result.DeliveryAddress.ShouldBe("2d6365c882dc48aa94e1659ebef3244722578fac70ef43c196");
            result.DeliveryFee.ShouldBe(1699055544);
            result.UserName.ShouldBe("dacb355cce5746058a94553a18b6f343a8e224a60bdc4ad58a");
            result.OrderStateCode.ShouldBe("feb2fa2ea04647bab6a08968452df00a9f4292ba509c44e4b1");
            result.ExtendedInformation.ShouldBe("df9d9f8dea644a9ba1263cbe4b1b1dedf5fcc01b4e8145d2903fec2c0217a15be37f0e04b7774cd99a8669cad1d73d467a16ab0e74ac4a328e7ba9c571d1c8ec6a113069d15547f4b60176ba406afcb7f3e7306f288f48aa960ddd500169b3f7dd1de204c900491ea78129a1d109aa30657eee8bf25a42cd938e140375c448c6ee94cf762e1a46fa8621843ce9bdcc2e36e61138c4f442cab651ea3525268d00a111f7f2fdc543c8aaf9f42b42011617870105139af444d58c8d943e0b9985b53abbfcbdb0464584a1a49f3bead827a5d8ec280a2c744d338f4e16c02cd8b50515a9576e28744c63a2c62e426d6f08995812274ea83f417d8b30");
            result.DateA.ShouldBe(new DateTime(2000, 9, 12));
            result.DateD.ShouldBe(new DateTime(2000, 1, 12));
            result.Sort.ShouldBe(1788156105);
            result.Note.ShouldBe("8f7c8145477344c6903a5c39018f6c41ff7b27e38185433092638fd01ef69eb075e3e65e7f254a63918025b470e2b4277a5083fe2175474aa5ffdb92550170980adab8aa392b478e868acb752131ee8d915c85d2ad384fa392ae91fe2ed04ab3e47744ccefa7430aa4e9fc8b625bb5cb6b6bf02ea17d4c96a9a058de41d6126d8b0877195f5e434aabcaddbfcf023a019c11d19720544e558adb3b09c1fafe45dd38ee71ad5749209456de5e987c8f78d3531e2531ca4ee2a77a70277ea376d0f76f7134db8b498d88d119b9df2e6b79c400271c61c541ffb803f643610bf53e7c02e8b092b249078323b48bf2a1fc0e11ddc66532c64d609f6e");
            result.Status.ShouldBe("6659d9dc0f4949e0b680bdbac8065f25e6de8c4ed2dd4ebf87");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOrdersAppService.DeleteAsync(Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"));

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"));

            result.ShouldBeNull();
        }
    }
}