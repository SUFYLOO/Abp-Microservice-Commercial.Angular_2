using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.TradeProducts
{
    public class TradeProductsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ITradeProductsAppService _tradeProductsAppService;
        private readonly IRepository<TradeProduct, Guid> _tradeProductRepository;

        public TradeProductsAppServiceTests()
        {
            _tradeProductsAppService = GetRequiredService<ITradeProductsAppService>();
            _tradeProductRepository = GetRequiredService<IRepository<TradeProduct, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tradeProductsAppService.GetListAsync(new GetTradeProductsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6e09d72e-a135-47f2-83bb-0f5764feaaf2")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeProductsAppService.GetAsync(Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeProductCreateDto
            {
                Name = "5d1b2cfe541f41a2a06098bac6b7b6323d04d0fcc4c84c61a1",
                Contents = "37904e0f849b458db435f75aff727f903493a83c5c1343489ef1a4c647e2e18c1a284b0cab6a48cd947bde53505b7ad9da460ab34437498a8c8d8d626cfb05e43da05bb880054cb186164725547c719209fd3f4db3814b3cb0863e9b2b6832691df8640c36824daab8037457c1fffb5e0e9147e3fbef463296d7490fa0ca2d843cdc750a19184f63b28cac77e2e85cee49db9a0020604b6485754b50b8e81e36927c2f5093cc421dac43206f9c95aac1c6aaa26dad304f52b48a091558403256f815bee511254821bcb1eddf160d9889eccc80c72c32416d99e0309085e884e8d8e9418c357743a1a53a46ae60dfa71b9a7fd42479a84ed7a5fc",
                ProductCategoryCode = "dddc546a8d8742138c0f77f989046b1170c78936330b4f898f",
                UnitPrice = 709099514,
                UnitPricePromotions = 218644227,
                UnitCode = "50db348ee3fe4a8486438d5ed613d67dfbf4d8acd3d14eb891",
                QuantityStock = 72581723,
                QuantityOrdered = 471445472,
                QuantitySafetyStock = 1661857430,
                ExtendedInformation = "817ee3a02f3c4e8a83740c60d5e721dbfb17cbe8be7b4b6abc177b7916d7fea8e50931a535d947c49e3c6a6c2cfdc0c7c6751378638d4ad18fb338d424ffff0251c5f7df21ed4263a6acd31f8c151a5448357789a5ef4f2390c269a1cc63c2b387d02ebf4d5b44f9b82bac1a1cd2a0f0b4b4a87ab66e43559e1387a4cd3e69894069747a25d14743a02b906c88e02c185f63a0ab1e9f4c4aa15e816b7bfe57a8305c2f54b99f4baca5e3dee49513bd7c645dcc5d138b4d0eb478ff7a5af9bede6a7e0202f56c4896b32c40099e3f60dd72e9f7fad3294c41a4a1427b2ed14b7fa291b0e187164fbebc25e063488a1e374bf7e0039cb24941993d",
                DateA = new DateTime(2018, 5, 23),
                DateD = new DateTime(2006, 6, 3),
                Sort = 1075263747,
                OrderStateCode = "64b089c0c39345e6ba4e3ed3dd93a17eed477c147cb844d2a1f7f920a60868bf43ea0af427224725895dd4fc2606085860bfe216e84c482f99dcbdc399d236a34b911c0fb3e740a78c492c5d5e135b6c3e1e797f1d504f029f4d1c88f8034a92e983f845c02742d081a53c6eb1e38d3147649d325b8a40f1835e731504d2621ca26ff111e1ff4ccaab080eaca600d292af4f4d7b9ccf4c42926af15f155166ee16cb109fdff14642b3f2db36f7749cbfe22ccc7c09d94c03bc3bd627fb7940e23cf1d83698e04ce0bb45ae61eeeaf8f638dc2189d4ff4311b45218c4db949b6feb3bf4b893c5449e84810fdcad234431bc9e5c74cf4146c39cdb",
                Status = "fed7fd848d3d4830ba0f1d86818635843335713ddaf64aa2aa"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("5d1b2cfe541f41a2a06098bac6b7b6323d04d0fcc4c84c61a1");
            result.Contents.ShouldBe("37904e0f849b458db435f75aff727f903493a83c5c1343489ef1a4c647e2e18c1a284b0cab6a48cd947bde53505b7ad9da460ab34437498a8c8d8d626cfb05e43da05bb880054cb186164725547c719209fd3f4db3814b3cb0863e9b2b6832691df8640c36824daab8037457c1fffb5e0e9147e3fbef463296d7490fa0ca2d843cdc750a19184f63b28cac77e2e85cee49db9a0020604b6485754b50b8e81e36927c2f5093cc421dac43206f9c95aac1c6aaa26dad304f52b48a091558403256f815bee511254821bcb1eddf160d9889eccc80c72c32416d99e0309085e884e8d8e9418c357743a1a53a46ae60dfa71b9a7fd42479a84ed7a5fc");
            result.ProductCategoryCode.ShouldBe("dddc546a8d8742138c0f77f989046b1170c78936330b4f898f");
            result.UnitPrice.ShouldBe(709099514);
            result.UnitPricePromotions.ShouldBe(218644227);
            result.UnitCode.ShouldBe("50db348ee3fe4a8486438d5ed613d67dfbf4d8acd3d14eb891");
            result.QuantityStock.ShouldBe(72581723);
            result.QuantityOrdered.ShouldBe(471445472);
            result.QuantitySafetyStock.ShouldBe(1661857430);
            result.ExtendedInformation.ShouldBe("817ee3a02f3c4e8a83740c60d5e721dbfb17cbe8be7b4b6abc177b7916d7fea8e50931a535d947c49e3c6a6c2cfdc0c7c6751378638d4ad18fb338d424ffff0251c5f7df21ed4263a6acd31f8c151a5448357789a5ef4f2390c269a1cc63c2b387d02ebf4d5b44f9b82bac1a1cd2a0f0b4b4a87ab66e43559e1387a4cd3e69894069747a25d14743a02b906c88e02c185f63a0ab1e9f4c4aa15e816b7bfe57a8305c2f54b99f4baca5e3dee49513bd7c645dcc5d138b4d0eb478ff7a5af9bede6a7e0202f56c4896b32c40099e3f60dd72e9f7fad3294c41a4a1427b2ed14b7fa291b0e187164fbebc25e063488a1e374bf7e0039cb24941993d");
            result.DateA.ShouldBe(new DateTime(2018, 5, 23));
            result.DateD.ShouldBe(new DateTime(2006, 6, 3));
            result.Sort.ShouldBe(1075263747);
            result.OrderStateCode.ShouldBe("64b089c0c39345e6ba4e3ed3dd93a17eed477c147cb844d2a1f7f920a60868bf43ea0af427224725895dd4fc2606085860bfe216e84c482f99dcbdc399d236a34b911c0fb3e740a78c492c5d5e135b6c3e1e797f1d504f029f4d1c88f8034a92e983f845c02742d081a53c6eb1e38d3147649d325b8a40f1835e731504d2621ca26ff111e1ff4ccaab080eaca600d292af4f4d7b9ccf4c42926af15f155166ee16cb109fdff14642b3f2db36f7749cbfe22ccc7c09d94c03bc3bd627fb7940e23cf1d83698e04ce0bb45ae61eeeaf8f638dc2189d4ff4311b45218c4db949b6feb3bf4b893c5449e84810fdcad234431bc9e5c74cf4146c39cdb");
            result.Status.ShouldBe("fed7fd848d3d4830ba0f1d86818635843335713ddaf64aa2aa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeProductUpdateDto()
            {
                Name = "7e482f075ee64abc9f11498e23095af219c5336e1d4849bdb2",
                Contents = "51ffe5ec6bae46f6a20ac92d6722abac9a43e4fae0124823bfe6eca781f9fb3086d3131890964aba9ce0562c4b6f00e3eb4a1e9293204d9b86a844c6c26d4cc75dd79b4047b44062bcabbc07bfd9d12d7aa597d7f58b49a0bbbbf3f948827d2446cc2871653247c78537e4f1f6b8c1d70d9fcd483adb4970b1af132285e1036af6eeb6f6fab848e69888560bde806451a05aa811afab48f28cb109dc6b4925f45baac2ffdcac46ac88bb16ac465f1398b695ed786b9d4f38a252d82fd87cf4b03bf51b665db94cf29767ace0d4d4f54ff5265a179c2d48f08e9242de20deff2f8b2455ef5ecd4c4c8a0e27bbc77a0b810a0b04099f504abe8a1e",
                ProductCategoryCode = "1f8ab40cd590441ab405be2eac25ac30d861b27fec7944ab8a",
                UnitPrice = 409525154,
                UnitPricePromotions = 460343399,
                UnitCode = "1d6b78c344004fc498182eddc118e0eb30244726836d46a393",
                QuantityStock = 35973482,
                QuantityOrdered = 1348212184,
                QuantitySafetyStock = 1517857146,
                ExtendedInformation = "b2dbeaf54d424600b2f300bb542db53cbee2fb9dedd64dbd82d5fce5be1b6b5e4e51a8df7854453e8506b2595f7966867775fcf024eb40378911dade00f8fe18281d45903b7143168c8b4be2412f1e3e6d920e816fa549d1a52f4bbcf8d1019146e5495410554dbb815726d5c5ee822ae8fa7aa3c22c430d959ec6e6541de67714651fb2d051438e84c388c64271f2a652e20bf037f94e73842e391bf4f50cf5f8351a1724f04428ab9f6c4d086839cd98063936f16d4501815f11f5a597ff3da9c93a5f2f6f400c97868613598d6acdb9a1c3c5edea4a9f9c0548a7ecdad369e55493051907437ab14e00e925019f71db040ca134d346168066",
                DateA = new DateTime(2003, 4, 7),
                DateD = new DateTime(2015, 3, 11),
                Sort = 1273418581,
                OrderStateCode = "5218d268562547f499233fd4c4f4a28db4d682fe5f714ee69114178d792c5cbd34a029c7ba204a6ea94065f5ca1e7a24621a36d6064d409fb92ed9631fcd83c72a5d7d66603f458e828b5f16970ec8cfe826c2a16ebe46fea72dcfca7d8830aa6096e24b0d30435a81b71ee07e49f1ba749a4b28076143c7918f3fd90954a547c19578cdcc314a6f8165bf02b7ad12e349ee97880bbb4efab199692ee3f405e814aaf178dd234f3cbc0d8596d5ee348fbdf4f640bc7a4ebfb514839bb7089f24a4f9330d93f54655ad2fb8eac5b8188dd5d96b8a5a674c89ad1d4b30c088ed0662b46d54d9cc46668482b5eb90e08493b5554d8687194f10a5ba",
                Status = "ec1019d62eb14f5b84d730a928bb29b4f3c08eb84543427ba2"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.UpdateAsync(Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"), input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("7e482f075ee64abc9f11498e23095af219c5336e1d4849bdb2");
            result.Contents.ShouldBe("51ffe5ec6bae46f6a20ac92d6722abac9a43e4fae0124823bfe6eca781f9fb3086d3131890964aba9ce0562c4b6f00e3eb4a1e9293204d9b86a844c6c26d4cc75dd79b4047b44062bcabbc07bfd9d12d7aa597d7f58b49a0bbbbf3f948827d2446cc2871653247c78537e4f1f6b8c1d70d9fcd483adb4970b1af132285e1036af6eeb6f6fab848e69888560bde806451a05aa811afab48f28cb109dc6b4925f45baac2ffdcac46ac88bb16ac465f1398b695ed786b9d4f38a252d82fd87cf4b03bf51b665db94cf29767ace0d4d4f54ff5265a179c2d48f08e9242de20deff2f8b2455ef5ecd4c4c8a0e27bbc77a0b810a0b04099f504abe8a1e");
            result.ProductCategoryCode.ShouldBe("1f8ab40cd590441ab405be2eac25ac30d861b27fec7944ab8a");
            result.UnitPrice.ShouldBe(409525154);
            result.UnitPricePromotions.ShouldBe(460343399);
            result.UnitCode.ShouldBe("1d6b78c344004fc498182eddc118e0eb30244726836d46a393");
            result.QuantityStock.ShouldBe(35973482);
            result.QuantityOrdered.ShouldBe(1348212184);
            result.QuantitySafetyStock.ShouldBe(1517857146);
            result.ExtendedInformation.ShouldBe("b2dbeaf54d424600b2f300bb542db53cbee2fb9dedd64dbd82d5fce5be1b6b5e4e51a8df7854453e8506b2595f7966867775fcf024eb40378911dade00f8fe18281d45903b7143168c8b4be2412f1e3e6d920e816fa549d1a52f4bbcf8d1019146e5495410554dbb815726d5c5ee822ae8fa7aa3c22c430d959ec6e6541de67714651fb2d051438e84c388c64271f2a652e20bf037f94e73842e391bf4f50cf5f8351a1724f04428ab9f6c4d086839cd98063936f16d4501815f11f5a597ff3da9c93a5f2f6f400c97868613598d6acdb9a1c3c5edea4a9f9c0548a7ecdad369e55493051907437ab14e00e925019f71db040ca134d346168066");
            result.DateA.ShouldBe(new DateTime(2003, 4, 7));
            result.DateD.ShouldBe(new DateTime(2015, 3, 11));
            result.Sort.ShouldBe(1273418581);
            result.OrderStateCode.ShouldBe("5218d268562547f499233fd4c4f4a28db4d682fe5f714ee69114178d792c5cbd34a029c7ba204a6ea94065f5ca1e7a24621a36d6064d409fb92ed9631fcd83c72a5d7d66603f458e828b5f16970ec8cfe826c2a16ebe46fea72dcfca7d8830aa6096e24b0d30435a81b71ee07e49f1ba749a4b28076143c7918f3fd90954a547c19578cdcc314a6f8165bf02b7ad12e349ee97880bbb4efab199692ee3f405e814aaf178dd234f3cbc0d8596d5ee348fbdf4f640bc7a4ebfb514839bb7089f24a4f9330d93f54655ad2fb8eac5b8188dd5d96b8a5a674c89ad1d4b30c088ed0662b46d54d9cc46668482b5eb90e08493b5554d8687194f10a5ba");
            result.Status.ShouldBe("ec1019d62eb14f5b84d730a928bb29b4f3c08eb84543427ba2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeProductsAppService.DeleteAsync(Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"));

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == Guid.Parse("331b000b-d38f-4126-b0ff-7a1635170e9b"));

            result.ShouldBeNull();
        }
    }
}