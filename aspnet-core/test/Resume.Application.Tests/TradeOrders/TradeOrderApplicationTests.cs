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
            result.Items.Any(x => x.Id == Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f49076a5-cb97-4494-b23e-213de50229a3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOrdersAppService.GetAsync(Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOrderCreateDto
            {
                KeyId = Guid.Parse("8b3f578b-4ae9-4cbd-ace1-6de13fb863f8"),
                OrderNumber = "e8312253f89b4c5a9104e66eb23f5e3c4b3bfd1d8cb5497abf",
                DateOrder = new DateTime(2005, 4, 23),
                DateNeed = new DateTime(2019, 2, 17),
                DateDelivery = new DateTime(2009, 5, 3),
                DeliveryMethodCode = "d828664505cf45daa4264c8e7f31c4870ce7fb2c8ec0498b9b",
                DeliveryZipCode = "b1794d92c50044bd9dfd8a270a63c331c2dbb63276204f7397",
                DeliveryCityCode = "305f60f626de4b6997be0017322ef06e891abf1ddaf745bc9d",
                DeliveryAreaCode = "e2d62e6726424da68b9fa81a460f545f8878e7497684478e97",
                DeliveryAddress = "fb249455040247c9bc6d89954b0b6c3162dfe6360e5e44dd9f",
                DeliveryFee = 308317692,
                UserName = "a209fee373694165983d02ce0eb1fe4670a2d03a778146f5bf",
                OrderStateCode = "6d5abac0e35a40ba8d181e86c0ad113820f16ded8d77422f98",
                ExtendedInformation = "d3479819d5b04a1ca8c14b0c6ca5bb12b991f68db94c4f7f8347e50c0de6c951bbbe15a57fda4fc29a84a65df73de24d1c5e3370e640426681d2682cab4ca96652fda3b93fd0408a91dbbc25bc0c42c4c7d1bdfb899546c292832a40f73de64c0c3ef46431cd487799f132f026ee64a4fd0a971bc6f449bcb7b6f7522161c8999ee7f493070e445bb49a7ae9bf8aad23ecb588d9cc60488ea0f2eaf1e002d9a2fb1362c994af4c97a44c5b6552db8f2ba7d8c7f9a9d242b4828055b7b2ca6675006259975fe1438e8348fa9a93fdd0e534f4d29a0fd346bca5be3755cd23daf80bf907814556492994ced13d81789ca3b1d8da81b67242b2bb67",
                DateA = new DateTime(2006, 4, 24),
                DateD = new DateTime(2008, 5, 17),
                Sort = 1206109428,
                Note = "41738d2010f64a89a04fd6d2fbfdc6d0e858482e8a9a403c8fff1268226bed6e03e8c4c7dbd9464195a2929726612fbd9ee7b3739cc4438db93c9c18fcbb4ef6eb2be537622848e9bd898334d9b6a307a3b5fe23c2234400a6ccd8984b19e7c0f1884f52db994b6fbc93e46c30ab3b0b62db56bb7b484a0f8db5d50a49b3757079e5839291154577ba18194ee5a22c24d3c260d4239f4ecca556157b526edfed234bbcade6bf4d90b6e0f06a034fa58972ca4d1e74594df9bffd556655d995595feea8d8ca464408b5e7d440cc60f86c5c1245fd621b45ce9d4fe84ff4921bc2fddb2f0a754548c897a3fdab2ba1024006033fba610b44728807",
                Status = "78f73601e9fd430fb12734965be0cf3c5599df2a52a5402da9"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("8b3f578b-4ae9-4cbd-ace1-6de13fb863f8"));
            result.OrderNumber.ShouldBe("e8312253f89b4c5a9104e66eb23f5e3c4b3bfd1d8cb5497abf");
            result.DateOrder.ShouldBe(new DateTime(2005, 4, 23));
            result.DateNeed.ShouldBe(new DateTime(2019, 2, 17));
            result.DateDelivery.ShouldBe(new DateTime(2009, 5, 3));
            result.DeliveryMethodCode.ShouldBe("d828664505cf45daa4264c8e7f31c4870ce7fb2c8ec0498b9b");
            result.DeliveryZipCode.ShouldBe("b1794d92c50044bd9dfd8a270a63c331c2dbb63276204f7397");
            result.DeliveryCityCode.ShouldBe("305f60f626de4b6997be0017322ef06e891abf1ddaf745bc9d");
            result.DeliveryAreaCode.ShouldBe("e2d62e6726424da68b9fa81a460f545f8878e7497684478e97");
            result.DeliveryAddress.ShouldBe("fb249455040247c9bc6d89954b0b6c3162dfe6360e5e44dd9f");
            result.DeliveryFee.ShouldBe(308317692);
            result.UserName.ShouldBe("a209fee373694165983d02ce0eb1fe4670a2d03a778146f5bf");
            result.OrderStateCode.ShouldBe("6d5abac0e35a40ba8d181e86c0ad113820f16ded8d77422f98");
            result.ExtendedInformation.ShouldBe("d3479819d5b04a1ca8c14b0c6ca5bb12b991f68db94c4f7f8347e50c0de6c951bbbe15a57fda4fc29a84a65df73de24d1c5e3370e640426681d2682cab4ca96652fda3b93fd0408a91dbbc25bc0c42c4c7d1bdfb899546c292832a40f73de64c0c3ef46431cd487799f132f026ee64a4fd0a971bc6f449bcb7b6f7522161c8999ee7f493070e445bb49a7ae9bf8aad23ecb588d9cc60488ea0f2eaf1e002d9a2fb1362c994af4c97a44c5b6552db8f2ba7d8c7f9a9d242b4828055b7b2ca6675006259975fe1438e8348fa9a93fdd0e534f4d29a0fd346bca5be3755cd23daf80bf907814556492994ced13d81789ca3b1d8da81b67242b2bb67");
            result.DateA.ShouldBe(new DateTime(2006, 4, 24));
            result.DateD.ShouldBe(new DateTime(2008, 5, 17));
            result.Sort.ShouldBe(1206109428);
            result.Note.ShouldBe("41738d2010f64a89a04fd6d2fbfdc6d0e858482e8a9a403c8fff1268226bed6e03e8c4c7dbd9464195a2929726612fbd9ee7b3739cc4438db93c9c18fcbb4ef6eb2be537622848e9bd898334d9b6a307a3b5fe23c2234400a6ccd8984b19e7c0f1884f52db994b6fbc93e46c30ab3b0b62db56bb7b484a0f8db5d50a49b3757079e5839291154577ba18194ee5a22c24d3c260d4239f4ecca556157b526edfed234bbcade6bf4d90b6e0f06a034fa58972ca4d1e74594df9bffd556655d995595feea8d8ca464408b5e7d440cc60f86c5c1245fd621b45ce9d4fe84ff4921bc2fddb2f0a754548c897a3fdab2ba1024006033fba610b44728807");
            result.Status.ShouldBe("78f73601e9fd430fb12734965be0cf3c5599df2a52a5402da9");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOrderUpdateDto()
            {
                KeyId = Guid.Parse("61db6d2e-1f6f-45d0-bfbf-cbbf9f6d3709"),
                OrderNumber = "f81a8976493a49ffada857d0a2275396fcc78ab8bdf945ad86",
                DateOrder = new DateTime(2010, 1, 1),
                DateNeed = new DateTime(2007, 2, 5),
                DateDelivery = new DateTime(2022, 11, 23),
                DeliveryMethodCode = "2d8d2abe581a430d8b807b0a448ccf34b18a8c8e32d7402eb1",
                DeliveryZipCode = "d98dada694f24c36b96106d83fd716e60775a51e230c40c39c",
                DeliveryCityCode = "f5482bf6f131413782057925eb63ee1fe21ef7e6877f4d09af",
                DeliveryAreaCode = "be49b558ac784f4093f3c53ffd22852025b971c0d0db416095",
                DeliveryAddress = "1368179efd5b43878401cd8d4b69539cd090897f9a674c1394",
                DeliveryFee = 627940554,
                UserName = "f9b52b1842b04b87961c81c578af8f510c3458d215104ae38b",
                OrderStateCode = "6db21e49d5664a8eb62aaa7b07e6924621faf72e1c43449494",
                ExtendedInformation = "4309b1b93bec4025a65214d7496747b8c40f39451e4049ceadf354818f62708672b5e4edc7bf4496a73233f80fc82c652730a5a940f240889c866b206efe09e72397749b565a42ecabaefa59d815cba93350c1fed5a34b4a87d4c86be69b9b7192e197b488884a89b56ce4525dbd2adf7949eb2f489841b592c9512d8cbddec54ae26e5dbb3c40ea98bc6d3074c582699ebff9db1dca4ccfbcd428728927dfa761a45e71e5aa430cb9e4646ba4292798eb02eb3ae52647db9aabf7a676c86a78471c9be92dbf4896a9d32d8b80c825ec4f147b9a3e7e4a10a0fe912671a5c4bc397772fa7ac54210929ca1d93a1425dec2af8e5daa214e9683e4",
                DateA = new DateTime(2020, 10, 7),
                DateD = new DateTime(2004, 11, 18),
                Sort = 1346104719,
                Note = "7ba887ef61b34655a946c74f3704f3cac015ec73ed23406e9b04d6fff1f04a87605eb243f3d143579d8099b31cfb01f890f238113ee74c9a8ba06e79114d004f72223a53a9c044caa3e123a189cbf53d0507981c1df0491e81385d5090b015461f724bc42c37482abaa1e3d1e45d200e8032ee2a6e874b4f989921933dd2439fdce6ae8803904f598ea2fc64a1f0718c08e550579e1848e1993a3af8ba35ba829116606e02ab4426be6c1baa1c0676c26f58192dcada4be19dc03ed37d323dc827a2d7675abb4b1d92a296a267a4ebb9a5503f42b966451283763daeaeed93fbf251676d5fba4e2387d0ed4ce651b318091d7c0bda104b4c9004",
                Status = "7240456c2a6145db9dc6175ad653e3676a3a2e6161154f2c93"
            };

            // Act
            var serviceResult = await _tradeOrdersAppService.UpdateAsync(Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"), input);

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.KeyId.ShouldBe(Guid.Parse("61db6d2e-1f6f-45d0-bfbf-cbbf9f6d3709"));
            result.OrderNumber.ShouldBe("f81a8976493a49ffada857d0a2275396fcc78ab8bdf945ad86");
            result.DateOrder.ShouldBe(new DateTime(2010, 1, 1));
            result.DateNeed.ShouldBe(new DateTime(2007, 2, 5));
            result.DateDelivery.ShouldBe(new DateTime(2022, 11, 23));
            result.DeliveryMethodCode.ShouldBe("2d8d2abe581a430d8b807b0a448ccf34b18a8c8e32d7402eb1");
            result.DeliveryZipCode.ShouldBe("d98dada694f24c36b96106d83fd716e60775a51e230c40c39c");
            result.DeliveryCityCode.ShouldBe("f5482bf6f131413782057925eb63ee1fe21ef7e6877f4d09af");
            result.DeliveryAreaCode.ShouldBe("be49b558ac784f4093f3c53ffd22852025b971c0d0db416095");
            result.DeliveryAddress.ShouldBe("1368179efd5b43878401cd8d4b69539cd090897f9a674c1394");
            result.DeliveryFee.ShouldBe(627940554);
            result.UserName.ShouldBe("f9b52b1842b04b87961c81c578af8f510c3458d215104ae38b");
            result.OrderStateCode.ShouldBe("6db21e49d5664a8eb62aaa7b07e6924621faf72e1c43449494");
            result.ExtendedInformation.ShouldBe("4309b1b93bec4025a65214d7496747b8c40f39451e4049ceadf354818f62708672b5e4edc7bf4496a73233f80fc82c652730a5a940f240889c866b206efe09e72397749b565a42ecabaefa59d815cba93350c1fed5a34b4a87d4c86be69b9b7192e197b488884a89b56ce4525dbd2adf7949eb2f489841b592c9512d8cbddec54ae26e5dbb3c40ea98bc6d3074c582699ebff9db1dca4ccfbcd428728927dfa761a45e71e5aa430cb9e4646ba4292798eb02eb3ae52647db9aabf7a676c86a78471c9be92dbf4896a9d32d8b80c825ec4f147b9a3e7e4a10a0fe912671a5c4bc397772fa7ac54210929ca1d93a1425dec2af8e5daa214e9683e4");
            result.DateA.ShouldBe(new DateTime(2020, 10, 7));
            result.DateD.ShouldBe(new DateTime(2004, 11, 18));
            result.Sort.ShouldBe(1346104719);
            result.Note.ShouldBe("7ba887ef61b34655a946c74f3704f3cac015ec73ed23406e9b04d6fff1f04a87605eb243f3d143579d8099b31cfb01f890f238113ee74c9a8ba06e79114d004f72223a53a9c044caa3e123a189cbf53d0507981c1df0491e81385d5090b015461f724bc42c37482abaa1e3d1e45d200e8032ee2a6e874b4f989921933dd2439fdce6ae8803904f598ea2fc64a1f0718c08e550579e1848e1993a3af8ba35ba829116606e02ab4426be6c1baa1c0676c26f58192dcada4be19dc03ed37d323dc827a2d7675abb4b1d92a296a267a4ebb9a5503f42b966451283763daeaeed93fbf251676d5fba4e2387d0ed4ce651b318091d7c0bda104b4c9004");
            result.Status.ShouldBe("7240456c2a6145db9dc6175ad653e3676a3a2e6161154f2c93");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOrdersAppService.DeleteAsync(Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"));

            // Assert
            var result = await _tradeOrderRepository.FindAsync(c => c.Id == Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"));

            result.ShouldBeNull();
        }
    }
}