using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.TradeOrders;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.TradeOrders
{
    public class TradeOrderRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ITradeOrderRepository _tradeOrderRepository;

        public TradeOrderRepositoryTests()
        {
            _tradeOrderRepository = GetRequiredService<ITradeOrderRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeOrderRepository.GetListAsync(
                    keyId: Guid.Parse("1043387e-fc92-46ac-ad21-6ddfc1cc7a4a"),
                    orderNumber: "bda33824f7f74dc980269d88f87fe621bfbc8ffe2d374bf7b0",
                    deliveryMethodCode: "4f18cf0f8cfa48fbaf4979130e1764c77049eee4a2ca43218a",
                    deliveryZipCode: "9023c85c73564400833e5b58ccda53fabea34bd635c049ab97",
                    deliveryCityCode: "b04bd016e9c04fa2b50fc7e2dc44dc29c1c449df53ca4110b6",
                    deliveryAreaCode: "291b91723fd14b148a0b6d8bd66f45a2375d39d809f143958b",
                    deliveryAddress: "057fb72a1fc04cc3b086f6fa3765b8d6639544ded5994ad5a5",
                    userName: "7615df1461f449729e8853085905af2ca6d4285844614a36b9",
                    orderStateCode: "246a8ceb13fa4c539e459514c73911f7689dfdf410a74ce28b",
                    extendedInformation: "4b581a517cd5433aa54fd1ff4a8dc520c912dc305a6841bca938c08cbf29d6cec183f2ce7f9b41d4b9b44443e0630fe0f9ef75f284cb455fb4dfdd3b2121fa9f386985bb8cf8457b944fc5638940155d99259f5edffd4f268cc9483728d9464cf8155bdb30f24d3184ac37ded7eb8635b771a37f2c4842908ada4271aa02651d8d6242fdfd3948b0b55b3eb50b542f5dbb0432af479b4a3d81ce98d5e1e5db8a7d24a09426db4d3ab743f0d049c2cdd3f5df2afb3a2340a1a6241039a1fdb201ab69888587b94aee9d18fe6d62a8c79599e0e996ad7641099902b6e94d0af0fe4f00bfd8f8c64c65919c1073056398dc559a8769733845f2b84b",
                    note: "a0900f3bcee14d3d8f2aa6c9095613a0c986ec2920c244a18168d1e92058bd397af40127713b49bfa4331e3252dad19c84ad04290042475aaf5bbfa7a008e96da72d7aac0702441ba9c82e9f51ee837d6407d39220b74d5399912b0664a7c0ad8af5487c207f43bf8db16f028b64efbe52570a68bc1f49d3898587ad9fe98087e0fc25e1b9794562b661cb3d43d7fc4e7be21eb542e045a19c44a72778268258ba32834648e84357bfd318ae0eaa23628129bf2bef6643ce9ffb19b720b354ccfaaefe2cbbee4a0882df1671b08e807d5f3143994cba450abd89ce11798a696e79cc8f09008347caa259cda0eb1e4973c599f085ab18437db9ce",
                    status: "909112bdcf5249949abd5eb1d1644ea9e9446412005c4623ae"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("40f7ff75-5653-4e38-b446-48b35f6a67eb"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _tradeOrderRepository.GetCountAsync(
                    keyId: Guid.Parse("88c14f0f-4d04-473f-b226-222429e4c597"),
                    orderNumber: "d3951e092fe9442abce583f7a3a99a164f9961e4ff1540c5b4",
                    deliveryMethodCode: "05c2606bdef24b8c8cea3947dd014ce11c3b7fc03276478692",
                    deliveryZipCode: "e8f6015c87ff4623b85b4b0fcc53793d07c06caba5fa4fafa9",
                    deliveryCityCode: "b00255c78f6e48ba8a8d3207fabfbc7a413be5873a704d248b",
                    deliveryAreaCode: "1dda1812459148acb25742c2f5ee39026bcee6cec4c345a988",
                    deliveryAddress: "24dd46d9e43941dbb8ebd44d5885d41e86a31a21ee5c43fa95",
                    userName: "ca2b2fd3313e4cf9b26bf01c759e41d717948a2bdea442c197",
                    orderStateCode: "fce4999b332d4d27b7d72876b8d91440bd30963c6af14acabe",
                    extendedInformation: "7efce15c490f4dabaa8c667a3bd86d44f2518f36060043668e0cdf8ee39b20b73e6c18c78dc54acba2548e39f8fd75a138abf6653a26437885e7d5f3480f1629c4a8887186924efc885853eb5a3cd353ea3cc219d05c47baae5742d47ab20aaf254cc940292040589f494689d631a5a2a4bcd5d20e03448f87eb890cf906921c46f1e9a2e247447f8dd155d0bad35914a59bad0eed4d47b1a8fb1d400ba028b8b6bbc01e8050439399d98d190ddfc89ad5bd85c38bf24a59ae7af7cd1653bdc827f6b64c2ffa41bba7f65c8e834e7313259c673d52f54047920270fe4ddb2a0f3ef1f1207af74fd7972986f46123be2b9ca2bd94c824481daa87",
                    note: "10fc9aba00484618be0bdfbc5a30a75cb921f6ada6734e7ea08b085c7d7ac987ed46a3fdff0348db814474884bf4316b2ec6fe53336a4c019b7ff4a90b93d867fc60397bfe5944489f7f45a66565ef4658aa4ca269a348088baf28f11a04d2d8d7e113c6b2af428a9f1ee7cc75b992036f4027ebf611428c9bbcf4925e752b88dc2e7cddf69f46a4bbd3c7c8eda286d4b89b1f98af6747cab3572dfd3527ccd632e0c6a272984938a53426084b0d9b0ab2870afb197047f2a50da9d5c6400272b3148e9f884c4fff96174d3f9150edd73cf66e411e9a42a488972ed0c4ee750fe077fd751496454ba7e3608e0dda89a98736dd443fd044fcaf7e",
                    status: "e1441c371cdb4b6f8f024b90e535d4880d03dc1086d946f2a5"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}