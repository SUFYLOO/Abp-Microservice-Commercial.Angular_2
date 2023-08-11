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
            result.Items.Any(x => x.Id == Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("d7b34a5b-83ad-4dd9-9619-6fa47b18d338")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeProductsAppService.GetAsync(Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeProductCreateDto
            {
                Name = "27c8597b20ff42c28a3a196add7b7cab6a64c20c74964d84af",
                Contents = "1efdbce3bdfa4bdb87a8f32103879872a46b3b0c24994d77a5d26417f28abee3cee60444c69840c4a1ecf31d474551c494dda70b2466493fbb87504b938da0d19fc7dbd592004dafa0dd7ac8665915bbd1d75ea9403349beac28794152b6db3892639171fcd542b8a416a2117af3bb50f65ca429429846838be476e888a7d34b5c401b395cc848eab389b910ec8fb3e1f734eddd2e7a461487c1f36ff54703f21101d51b911e48a9b55761eb311fd59cc4b3d5a9c79b49868e6b2e96fec4777c05424f384ff54fecbb547d49832fb0e3e3a30a254b3b4394a8a30a9eedf552b4ed0cb77c0d004512bb31b3a1c28ebf793874acf390a140268f96",
                ProductCategoryCode = "b7f44f2870f6475987eaebf02e6b7685d95788b1c9de4a13a7",
                UnitPrice = 457833438,
                UnitPricePromotions = 1338998254,
                UnitCode = "421f19cd587e4d0198ac32e412c0bd003fc1c1c78e6442d59c",
                QuantityStock = 1623754867,
                QuantityOrdered = 1364164201,
                QuantitySafetyStock = 805145117,
                ExtendedInformation = "5543ed8723ce440f9bed970dd0665a790e5e54a459f74d34888f1a1509e6709d51543d3bd8c245528ea6014f51c3591bc265d91dc2c84c778ced42c60e9b835c85fcf33d26dc4b73af4cc1adbc549cee879e216f6f444502bb85351b8d4cbbff5fc4c12626db4f3ab61042216e8c941fafeaf7c64a4b402988ae94a1c77df028cf170d11cb924387b5e57342cdbae4fb52c21c5ae3294b1b9707561996767f89c44870f980c340ba9dbab9da1d947107cebea26f5330472f80f2a75040cb5e790e6a506a71904c36a12d3fd360c4e5726c1faab136f74049a53b5d53cef0240cafdf3db5242d4557a8559dc2e8f200c517735a7b73af40a7a2bd",
                DateA = new DateTime(2018, 4, 11),
                DateD = new DateTime(2004, 4, 20),
                Sort = 1191082087,
                OrderStateCode = "0c3b3ffeb73b4d4c83a5c863562fb34423c6d63dbc0240fb9a44904bec5464dea395bf51af444a14a6250abcda1ce0f24e147c847ad141feb08b70aa3d5b72e3ab5337071ab64d51a519b7925671f47dd775c66af8e447d990f8834e5b7ab8476acaf1652c6b41e99bb7987d885c20028c2724660f9b4524b081e17917a9de29bdba214e646943cda685fd919b78e3e2dddbf40e29074f0d95d8022e3f8ab56cf3b3633737e34184a629f2be1749747a4f0719562e854ed987b4ca79ff337989120b9b2750264c99ae37e9119fef460a8e3d73afc0f647d39a93f13c9c51421b6440c1e93d984ccea5a97f795c1abd2d0d1259b8b1ca41f19244",
                Status = "00a085e7eecd45e1917c44b3056e36b04bf687f986464245b9"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("27c8597b20ff42c28a3a196add7b7cab6a64c20c74964d84af");
            result.Contents.ShouldBe("1efdbce3bdfa4bdb87a8f32103879872a46b3b0c24994d77a5d26417f28abee3cee60444c69840c4a1ecf31d474551c494dda70b2466493fbb87504b938da0d19fc7dbd592004dafa0dd7ac8665915bbd1d75ea9403349beac28794152b6db3892639171fcd542b8a416a2117af3bb50f65ca429429846838be476e888a7d34b5c401b395cc848eab389b910ec8fb3e1f734eddd2e7a461487c1f36ff54703f21101d51b911e48a9b55761eb311fd59cc4b3d5a9c79b49868e6b2e96fec4777c05424f384ff54fecbb547d49832fb0e3e3a30a254b3b4394a8a30a9eedf552b4ed0cb77c0d004512bb31b3a1c28ebf793874acf390a140268f96");
            result.ProductCategoryCode.ShouldBe("b7f44f2870f6475987eaebf02e6b7685d95788b1c9de4a13a7");
            result.UnitPrice.ShouldBe(457833438);
            result.UnitPricePromotions.ShouldBe(1338998254);
            result.UnitCode.ShouldBe("421f19cd587e4d0198ac32e412c0bd003fc1c1c78e6442d59c");
            result.QuantityStock.ShouldBe(1623754867);
            result.QuantityOrdered.ShouldBe(1364164201);
            result.QuantitySafetyStock.ShouldBe(805145117);
            result.ExtendedInformation.ShouldBe("5543ed8723ce440f9bed970dd0665a790e5e54a459f74d34888f1a1509e6709d51543d3bd8c245528ea6014f51c3591bc265d91dc2c84c778ced42c60e9b835c85fcf33d26dc4b73af4cc1adbc549cee879e216f6f444502bb85351b8d4cbbff5fc4c12626db4f3ab61042216e8c941fafeaf7c64a4b402988ae94a1c77df028cf170d11cb924387b5e57342cdbae4fb52c21c5ae3294b1b9707561996767f89c44870f980c340ba9dbab9da1d947107cebea26f5330472f80f2a75040cb5e790e6a506a71904c36a12d3fd360c4e5726c1faab136f74049a53b5d53cef0240cafdf3db5242d4557a8559dc2e8f200c517735a7b73af40a7a2bd");
            result.DateA.ShouldBe(new DateTime(2018, 4, 11));
            result.DateD.ShouldBe(new DateTime(2004, 4, 20));
            result.Sort.ShouldBe(1191082087);
            result.OrderStateCode.ShouldBe("0c3b3ffeb73b4d4c83a5c863562fb34423c6d63dbc0240fb9a44904bec5464dea395bf51af444a14a6250abcda1ce0f24e147c847ad141feb08b70aa3d5b72e3ab5337071ab64d51a519b7925671f47dd775c66af8e447d990f8834e5b7ab8476acaf1652c6b41e99bb7987d885c20028c2724660f9b4524b081e17917a9de29bdba214e646943cda685fd919b78e3e2dddbf40e29074f0d95d8022e3f8ab56cf3b3633737e34184a629f2be1749747a4f0719562e854ed987b4ca79ff337989120b9b2750264c99ae37e9119fef460a8e3d73afc0f647d39a93f13c9c51421b6440c1e93d984ccea5a97f795c1abd2d0d1259b8b1ca41f19244");
            result.Status.ShouldBe("00a085e7eecd45e1917c44b3056e36b04bf687f986464245b9");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeProductUpdateDto()
            {
                Name = "ebb900ef4e90420ba381a974c9f9e4a2b5ccf4640d134833b2",
                Contents = "fd0a017cd92449c5a124f8b8e08f3d4970ae00febf404c268b3843ec858a100e8c7a0a8d79044f6c95056406d4bf783d3d61b4f8e7a24d13a46ddaa836623eea0831ff77df7f42cc9a228236b6511e8f2dc2aaaef77a47c38289b47e09b4d5763757d88cd1944e37a8d7271baf276fd47ed1c812b31a4c618c7f7b3766a6113aeaa3fd75a8374eceba4328dfdf6d876f1b76df12724f4dadb1720022709c5632dabf16090ad54e7abba94a294f608aed4602f595ea2747a187c9b5d319b6a265772469c44090491c85c50def61032e89d6a99a851daf4d59a4e1f910fe0e9fe18086b6779c7b4021b2c85b54d86a64204e485154978446dabf1b",
                ProductCategoryCode = "dc5887e10d2e4d859326f88054c7d95801ac5b222f5a46bc96",
                UnitPrice = 1431281527,
                UnitPricePromotions = 1661395689,
                UnitCode = "6b90f4fb814749d0b9749d2eca280451d6917bc131dc4127bb",
                QuantityStock = 1892356897,
                QuantityOrdered = 1666385790,
                QuantitySafetyStock = 1641699584,
                ExtendedInformation = "7c98d20a46ed49678067e7d32472611e1ea497efc3844a40b07b1d727474e74652eefd489f3843a593944d1cc8e47829a1e9eaca90274e328e2f7073f296950006d36e348b8b422b9821c10e6d009f428f34970101514d728bf6b99fb09183e1e38a40bf919b4d4cbe7a855d08c758878d503f7d1fcf4aa9bc9797914dac7b5e59be1d02f1a346b2bfaa064f5c03a0ce0d7e405b3a114856b30879e9aa181153ecc7c4f984ea4802ac437302db46ccaf627361022a37457293789b80cb32dbedd146237bcdc04f85a40a752b9b2f9d2928e88b87fa164ea6a93d2bd00cefc1d67285aa5ee9fa4dd6811223c8bd146952bab5eb6b3d5e4cf99ab7",
                DateA = new DateTime(2001, 2, 19),
                DateD = new DateTime(2021, 9, 5),
                Sort = 1070572261,
                OrderStateCode = "c62776c613a44461bb816efc2829e0625b196cb49def485b8dd49896c3932959327621fbed6544159c2dab94a4acc67953d1cdd4ca2a4649b72bb89eeaa257a7aceeae258dd249ea84b5fb0c146f51e7c21568ef300e4eecba6e40ef7ece4d892440c4347dc644439a1efbab0c728e5400b5ee2782be4c6db3c5ede34f7f4fc497633d175fea49e98b43c6d9e86433d84c2006a365744dfc84cebea6d2082c96f7e42b1b306e456da1773cd00de9d1092313782dbde0431f9b78dbf24db7fc19be11d9bb75ca401ea1bce4e0a735d83d614297cee4ba48a5998c6ca806254589674255e79eb04559a2c1ee305bd923cd5f8883e4ba1d469482f2",
                Status = "fa22c42a5b684aae96dd6665ff46ab4725999aeff46445eeaa"
            };

            // Act
            var serviceResult = await _tradeProductsAppService.UpdateAsync(Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"), input);

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("ebb900ef4e90420ba381a974c9f9e4a2b5ccf4640d134833b2");
            result.Contents.ShouldBe("fd0a017cd92449c5a124f8b8e08f3d4970ae00febf404c268b3843ec858a100e8c7a0a8d79044f6c95056406d4bf783d3d61b4f8e7a24d13a46ddaa836623eea0831ff77df7f42cc9a228236b6511e8f2dc2aaaef77a47c38289b47e09b4d5763757d88cd1944e37a8d7271baf276fd47ed1c812b31a4c618c7f7b3766a6113aeaa3fd75a8374eceba4328dfdf6d876f1b76df12724f4dadb1720022709c5632dabf16090ad54e7abba94a294f608aed4602f595ea2747a187c9b5d319b6a265772469c44090491c85c50def61032e89d6a99a851daf4d59a4e1f910fe0e9fe18086b6779c7b4021b2c85b54d86a64204e485154978446dabf1b");
            result.ProductCategoryCode.ShouldBe("dc5887e10d2e4d859326f88054c7d95801ac5b222f5a46bc96");
            result.UnitPrice.ShouldBe(1431281527);
            result.UnitPricePromotions.ShouldBe(1661395689);
            result.UnitCode.ShouldBe("6b90f4fb814749d0b9749d2eca280451d6917bc131dc4127bb");
            result.QuantityStock.ShouldBe(1892356897);
            result.QuantityOrdered.ShouldBe(1666385790);
            result.QuantitySafetyStock.ShouldBe(1641699584);
            result.ExtendedInformation.ShouldBe("7c98d20a46ed49678067e7d32472611e1ea497efc3844a40b07b1d727474e74652eefd489f3843a593944d1cc8e47829a1e9eaca90274e328e2f7073f296950006d36e348b8b422b9821c10e6d009f428f34970101514d728bf6b99fb09183e1e38a40bf919b4d4cbe7a855d08c758878d503f7d1fcf4aa9bc9797914dac7b5e59be1d02f1a346b2bfaa064f5c03a0ce0d7e405b3a114856b30879e9aa181153ecc7c4f984ea4802ac437302db46ccaf627361022a37457293789b80cb32dbedd146237bcdc04f85a40a752b9b2f9d2928e88b87fa164ea6a93d2bd00cefc1d67285aa5ee9fa4dd6811223c8bd146952bab5eb6b3d5e4cf99ab7");
            result.DateA.ShouldBe(new DateTime(2001, 2, 19));
            result.DateD.ShouldBe(new DateTime(2021, 9, 5));
            result.Sort.ShouldBe(1070572261);
            result.OrderStateCode.ShouldBe("c62776c613a44461bb816efc2829e0625b196cb49def485b8dd49896c3932959327621fbed6544159c2dab94a4acc67953d1cdd4ca2a4649b72bb89eeaa257a7aceeae258dd249ea84b5fb0c146f51e7c21568ef300e4eecba6e40ef7ece4d892440c4347dc644439a1efbab0c728e5400b5ee2782be4c6db3c5ede34f7f4fc497633d175fea49e98b43c6d9e86433d84c2006a365744dfc84cebea6d2082c96f7e42b1b306e456da1773cd00de9d1092313782dbde0431f9b78dbf24db7fc19be11d9bb75ca401ea1bce4e0a735d83d614297cee4ba48a5998c6ca806254589674255e79eb04559a2c1ee305bd923cd5f8883e4ba1d469482f2");
            result.Status.ShouldBe("fa22c42a5b684aae96dd6665ff46ab4725999aeff46445eeaa");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeProductsAppService.DeleteAsync(Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"));

            // Assert
            var result = await _tradeProductRepository.FindAsync(c => c.Id == Guid.Parse("09badd80-ecd7-4db0-baa9-ac16fa3cacd8"));

            result.ShouldBeNull();
        }
    }
}