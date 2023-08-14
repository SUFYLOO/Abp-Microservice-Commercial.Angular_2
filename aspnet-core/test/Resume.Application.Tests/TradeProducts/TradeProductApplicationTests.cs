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
            result.Items.Any(x => x.Id == Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("dce34bc6-f5f5-49e0-baa4-578f675d14ef")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeProductsAppService.GetAsync(Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeProductCreateDto
            {
                Name = "52cca02e5dae434a95af95a21ba72a47ef56ca69713844c395",
                Contents = "fe82c63469834fd1828d569cb1ed00d3ed307c44bc3d4bdfb2af68b151a538c61966c467573e44d5859889ca57eae1a2b56f2aca678b4c4f906ae7c65d6c0cf361e32b29062e4594a6f69d8e9b6b57982871b46642ba40b6a075b3e1ce17f10ce56880b7bdaf43fab36b0f5a46b1ee802c60fd301db348c69df1139d0ad25cad7e8be44b20254a51bf4faf9ba3d881e5af6f3f9556324973a9945ceef0990fa82da3f4937f0e44c4aaf05e68f26c88c85ecca76f5e6b461ab0418ff59ecb2ba7826ae35c077d4af6872bfc899903ec33715cf52aa3094ba592ceb934151e082b0ddefcea556e4e0d93f3f85f8676f35d695d6b25a2a84a2787f6",
                ProductCategoryCode = "a710f560536d4f4099184eda997b73158a3d53a691554d7596",
                UnitPrice = 2056583772,
                UnitPricePromotions = 1699898469,
                UnitCode = "b927334c502d4d8bbcf3946c2f08e6ac5bb2134afb014f4aa1",
                QuantityStock = 284368977,
                QuantityOrdered = 1120717127,
                QuantitySafetyStock = 1416857284,
                ExtendedInformation = "27c4c85c07ab4ec298dbdee45be9ef4933231138fe994790a8273ef0bd838bd6ce2bb23e113c499db9e0026b205e87e6bd15a44108244ddeafb06854d727de2276b97712004247e6b401b95b6202d1a73f713c3bd9024a369d674a5f948ef83de6c57a48c3a44adf9debde408fc18a327d0b1d540c314ab8b8ded79ba1620a8f55628b4d70994c21b4a7e708fca48c96b32414dafe76473c92d541336f29a6fb4bb254ead1e74a71bfb5b7e4211a0e5150fb19542f9344b1aae87baf6652a1eb655035b2438d4e9487f591c50d783e77daf0f9c91eae4392b8bc1bd739ef0f1718911f308b8d4f2ea65847f2b699e076d66724d8ef0740e9afe6",
                DateA = new DateTime(2013, 6, 17),
                DateD = new DateTime(2003, 1, 5),
                Sort = 422041537,
                OrderStateCode = "16384f1e094744bba469834a2f073009e6ea2b6577d1445cafc839f3301547ff43dea34b776b4a8d88d1650f495a7953e7d104a9940d4327ace65aadf34dd08cb939d723fa744a328510197d863bdf91d362a1f7882f4d6ca33c097ec06a415bf58ddcab48bd4d049a09a913ed36507db6f2d4a73e774c4ba4ba57ea3a63e759c237da0d5fb74b22a588b7ef9d6caf71f30d6e66de8044a3a1cac5261e29e371fbce6ffac4004f25978b959ff93e7ac27454059f579f47ab9a7532343dceae5da1b8891dec644b7eb87c8534dc7428d704e18dd736da4e4fbf64269ffe42247cfd13e3ee3e8847cd9a70ca185a9d5bece90f31731a3f4242a5d9",
                Status = "345317889b4d4992923216f8f862672799e0f5b1ff8a4ea085"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("52cca02e5dae434a95af95a21ba72a47ef56ca69713844c395");
            result.Contents.ShouldBe("fe82c63469834fd1828d569cb1ed00d3ed307c44bc3d4bdfb2af68b151a538c61966c467573e44d5859889ca57eae1a2b56f2aca678b4c4f906ae7c65d6c0cf361e32b29062e4594a6f69d8e9b6b57982871b46642ba40b6a075b3e1ce17f10ce56880b7bdaf43fab36b0f5a46b1ee802c60fd301db348c69df1139d0ad25cad7e8be44b20254a51bf4faf9ba3d881e5af6f3f9556324973a9945ceef0990fa82da3f4937f0e44c4aaf05e68f26c88c85ecca76f5e6b461ab0418ff59ecb2ba7826ae35c077d4af6872bfc899903ec33715cf52aa3094ba592ceb934151e082b0ddefcea556e4e0d93f3f85f8676f35d695d6b25a2a84a2787f6");
            result.ProductCategoryCode.ShouldBe("a710f560536d4f4099184eda997b73158a3d53a691554d7596");
            result.UnitPrice.ShouldBe(2056583772);
            result.UnitPricePromotions.ShouldBe(1699898469);
            result.UnitCode.ShouldBe("b927334c502d4d8bbcf3946c2f08e6ac5bb2134afb014f4aa1");
            result.QuantityStock.ShouldBe(284368977);
            result.QuantityOrdered.ShouldBe(1120717127);
            result.QuantitySafetyStock.ShouldBe(1416857284);
            result.ExtendedInformation.ShouldBe("27c4c85c07ab4ec298dbdee45be9ef4933231138fe994790a8273ef0bd838bd6ce2bb23e113c499db9e0026b205e87e6bd15a44108244ddeafb06854d727de2276b97712004247e6b401b95b6202d1a73f713c3bd9024a369d674a5f948ef83de6c57a48c3a44adf9debde408fc18a327d0b1d540c314ab8b8ded79ba1620a8f55628b4d70994c21b4a7e708fca48c96b32414dafe76473c92d541336f29a6fb4bb254ead1e74a71bfb5b7e4211a0e5150fb19542f9344b1aae87baf6652a1eb655035b2438d4e9487f591c50d783e77daf0f9c91eae4392b8bc1bd739ef0f1718911f308b8d4f2ea65847f2b699e076d66724d8ef0740e9afe6");
            result.DateA.ShouldBe(new DateTime(2013, 6, 17));
            result.DateD.ShouldBe(new DateTime(2003, 1, 5));
            result.Sort.ShouldBe(422041537);
            result.OrderStateCode.ShouldBe("16384f1e094744bba469834a2f073009e6ea2b6577d1445cafc839f3301547ff43dea34b776b4a8d88d1650f495a7953e7d104a9940d4327ace65aadf34dd08cb939d723fa744a328510197d863bdf91d362a1f7882f4d6ca33c097ec06a415bf58ddcab48bd4d049a09a913ed36507db6f2d4a73e774c4ba4ba57ea3a63e759c237da0d5fb74b22a588b7ef9d6caf71f30d6e66de8044a3a1cac5261e29e371fbce6ffac4004f25978b959ff93e7ac27454059f579f47ab9a7532343dceae5da1b8891dec644b7eb87c8534dc7428d704e18dd736da4e4fbf64269ffe42247cfd13e3ee3e8847cd9a70ca185a9d5bece90f31731a3f4242a5d9");
            result.Status.ShouldBe("345317889b4d4992923216f8f862672799e0f5b1ff8a4ea085");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeProductUpdateDto()
            {
                Name = "d550ad96b4d14c658facda4bd59eb2a23efa7a7712824b9f82",
                Contents = "3150e14b55634f56aabf37a3ffe06191dfb9ef5e67d24ec0a67a5b19a0334611b0b2da53318042259645d0a86e059260265cd6d504304b46b71136ff1ed6af984a21a10757734b099780464fe73140ccb126dfe89df441b59773c84ea1172201fd5730e424344ddcac33a8f86cc2a569dc7d378708bc4ca1a27efd16f9d3f6a01564bcf36b0f41fc89d31d53671e25c7e71ce53539f9444ab699ef182afe6d7fb986fb9c713549a39ea37b6b76a4a1e9563228cd4472400bafcaeaf80493ca265a1c94cdf9424a27b695d7fda7c8113f55f319858cb14d7e9d0d5a7884685171864a3a7e0b514d83b71dbdcad648bb53536f0bfae606463d8906",
                ProductCategoryCode = "2cbe5666435144378cc2b7a13354283e597ea5d5a05d46999e",
                UnitPrice = 737470540,
                UnitPricePromotions = 121483604,
                UnitCode = "16f85d3cea6f4c949606f518a5c496219a595c3f70e14e6b88",
                QuantityStock = 1747479319,
                QuantityOrdered = 12612233,
                QuantitySafetyStock = 1459779209,
                ExtendedInformation = "2b30a993fc6e4a298933d1397964d92ee05115af6eff4a7abf74da75b22c5d6b23dcd877f0c447cba5f6b2a740fd02fc4fa0b0e3c70c4c3981ef67fe6bbada5f56fdcaedb1ac4fad91bf01235ce94633a68c844253f54ddbaa12605f29e69e48446354b33d0b43889defe2f3169a13e2500c0fb8a4f54c089fcd9ebb71941fbaee77829e74854e7c9c76b4daaf0f4031246b57fa12704fce9a3f833b68e1113b31fa3d43d4e542dab287628b7096e0f1cde1d1ce6f784093a5e71892b7886f49a8e44105da08489883c760ee44ef73ccdd96346b80444200a282995d3218442ec318925379a744afbf6f7fa90e5f7ef18c6cd4cef52b412e875d",
                DateA = new DateTime(2013, 3, 17),
                DateD = new DateTime(2020, 7, 15),
                Sort = 2100810137,
                OrderStateCode = "f6dd26921c8a4da8a502af180c129d78a60b88aed7554318a854ed4036ec8c12dad0728027dc4a269e3afb82336979ee547835bc53b341dab02e64d150fcf4e1aac0ecdbf05d449f93f02653ab795ffcddc4b6c8ad954038ac00f12ee2681761ea062b183a0c4b1ea890e3ef04f8a3ab592cb8e6cc5b4690a9e96e9f3577dc26c9869bb2295549fbaa66ee17fc4560590a148eb6c2fa4633a2d4aaad935f31c01214d9d75af14502a82d66ed3935537e5a9c8a9d6cca4d6aa6c7e87dab08028e8244b11955ca41b8a5fa65fe57647fe38b13ff42f1a949aaa16315a98cbe0e81b18d531280e94ad7a99e6b17362c3016c856a975c75d43b1a638",
                Status = "e28e3cafa25f496a901d764f3be5c3f74bcb627d6d46480693"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.UpdateAsync(Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"), input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("d550ad96b4d14c658facda4bd59eb2a23efa7a7712824b9f82");
            result.Contents.ShouldBe("3150e14b55634f56aabf37a3ffe06191dfb9ef5e67d24ec0a67a5b19a0334611b0b2da53318042259645d0a86e059260265cd6d504304b46b71136ff1ed6af984a21a10757734b099780464fe73140ccb126dfe89df441b59773c84ea1172201fd5730e424344ddcac33a8f86cc2a569dc7d378708bc4ca1a27efd16f9d3f6a01564bcf36b0f41fc89d31d53671e25c7e71ce53539f9444ab699ef182afe6d7fb986fb9c713549a39ea37b6b76a4a1e9563228cd4472400bafcaeaf80493ca265a1c94cdf9424a27b695d7fda7c8113f55f319858cb14d7e9d0d5a7884685171864a3a7e0b514d83b71dbdcad648bb53536f0bfae606463d8906");
            result.ProductCategoryCode.ShouldBe("2cbe5666435144378cc2b7a13354283e597ea5d5a05d46999e");
            result.UnitPrice.ShouldBe(737470540);
            result.UnitPricePromotions.ShouldBe(121483604);
            result.UnitCode.ShouldBe("16f85d3cea6f4c949606f518a5c496219a595c3f70e14e6b88");
            result.QuantityStock.ShouldBe(1747479319);
            result.QuantityOrdered.ShouldBe(12612233);
            result.QuantitySafetyStock.ShouldBe(1459779209);
            result.ExtendedInformation.ShouldBe("2b30a993fc6e4a298933d1397964d92ee05115af6eff4a7abf74da75b22c5d6b23dcd877f0c447cba5f6b2a740fd02fc4fa0b0e3c70c4c3981ef67fe6bbada5f56fdcaedb1ac4fad91bf01235ce94633a68c844253f54ddbaa12605f29e69e48446354b33d0b43889defe2f3169a13e2500c0fb8a4f54c089fcd9ebb71941fbaee77829e74854e7c9c76b4daaf0f4031246b57fa12704fce9a3f833b68e1113b31fa3d43d4e542dab287628b7096e0f1cde1d1ce6f784093a5e71892b7886f49a8e44105da08489883c760ee44ef73ccdd96346b80444200a282995d3218442ec318925379a744afbf6f7fa90e5f7ef18c6cd4cef52b412e875d");
            result.DateA.ShouldBe(new DateTime(2013, 3, 17));
            result.DateD.ShouldBe(new DateTime(2020, 7, 15));
            result.Sort.ShouldBe(2100810137);
            result.OrderStateCode.ShouldBe("f6dd26921c8a4da8a502af180c129d78a60b88aed7554318a854ed4036ec8c12dad0728027dc4a269e3afb82336979ee547835bc53b341dab02e64d150fcf4e1aac0ecdbf05d449f93f02653ab795ffcddc4b6c8ad954038ac00f12ee2681761ea062b183a0c4b1ea890e3ef04f8a3ab592cb8e6cc5b4690a9e96e9f3577dc26c9869bb2295549fbaa66ee17fc4560590a148eb6c2fa4633a2d4aaad935f31c01214d9d75af14502a82d66ed3935537e5a9c8a9d6cca4d6aa6c7e87dab08028e8244b11955ca41b8a5fa65fe57647fe38b13ff42f1a949aaa16315a98cbe0e81b18d531280e94ad7a99e6b17362c3016c856a975c75d43b1a638");
            result.Status.ShouldBe("e28e3cafa25f496a901d764f3be5c3f74bcb627d6d46480693");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeProductsAppService.DeleteAsync(Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"));

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == Guid.Parse("ebfa7967-d5e3-43f5-8eec-27dda7aa4e39"));

            result.ShouldBeNull();
        }
    }
}