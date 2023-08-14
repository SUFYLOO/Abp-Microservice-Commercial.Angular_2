using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ITradeOderDetailsAppService _tradeOderDetailsAppService;
        private readonly IRepository<TradeOderDetail, Guid> _tradeOderDetailRepository;

        public TradeOderDetailsAppServiceTests()
        {
            _tradeOderDetailsAppService = GetRequiredService<ITradeOderDetailsAppService>();
            _tradeOderDetailRepository = GetRequiredService<IRepository<TradeOderDetail, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _tradeOderDetailsAppService.GetListAsync(new GetTradeOderDetailsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("5312bd17-4a4f-4d4b-b859-2590fa1cd53a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOderDetailsAppService.GetAsync(Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOderDetailCreateDto
            {
                TradeOrderId = Guid.Parse("b69535d3-c808-44d0-b1d8-cd59a91cbe3f"),
                TradeProductId = Guid.Parse("41817069-25d6-4c15-808c-e67d673c6943"),
                UnitPrice = 1363068386,
                Quantity = 1710463840,
                OrderDetailStateCode = "0d9d20f36629438182fe84e52e2e9ad878e8c007528d4f6b9f",
                ExtendedInformation = "698f0134f4df4ae383e09da5cd9a6d2d039510fb86a34c8d93614fd40bf2fe06a438e38fba6a42349e9fc2c8ccef1ea78aea29d1ede34d51ba87b6fc7e7d53ed044ae48ed2564d509af77f7e324b2d693fc1dcff00a1478cb10060a421101f829ff9fac1c1ce4732b5561b0906ea0dce6854589a02ca4e38ad9a694f7e586a92fc3609b62366425585291f6df7148c432b52d963076540baa111ab01f1200194b48d9f35f60f4d41b7aee9cae7f7b32052e2a4048d594e0eb21b1732aac49bfc79f1f7e72dae4deea18fffd996a9b6d4cf5849bca74c446a8b9800e36a41681016105dc1f7274b3faa2e9b6e630a1d02d69d83a771db42a18df3",
                DateA = new DateTime(2017, 1, 18),
                DateD = new DateTime(2007, 4, 8),
                Sort = 930856715,
                Note = "aa290e4ef1214ea08f848ff5ccc0185051186bb1219f4fe89e19e2103780a672ddd0d0b6400649a3b6bc22e3e15553db9f35ce6b47d844a29a3885e34a43e361b710ebec03354efe8d1607c2436f19540c8b0124448444ea86671b7887e26a9620fe0ce82c314f8e9b884b39fd74545c45f61e91ce5d4a0c95d62d1cb3c4a30edbfd5874263a41ec8eae5f95c46d01363190baca28194ade801a17ed243ed1c179452d40d8d54282a42851c9c307da4d26bc1d15ed6749dfa2d3cfea5f8f61527f1e403bdd5d4cdc8a14106c4fd384b38889c4756bc64fbe99a6f24d766e9267eccbd5a158b946b5bf679701da01460e2f006d2e0fb142caa99f",
                Status = "f63486891d9e43adb949a5216d11da27769d02c4bb9b4cb887"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("b69535d3-c808-44d0-b1d8-cd59a91cbe3f"));
            result.TradeProductId.ShouldBe(Guid.Parse("41817069-25d6-4c15-808c-e67d673c6943"));
            result.UnitPrice.ShouldBe(1363068386);
            result.Quantity.ShouldBe(1710463840);
            result.OrderDetailStateCode.ShouldBe("0d9d20f36629438182fe84e52e2e9ad878e8c007528d4f6b9f");
            result.ExtendedInformation.ShouldBe("698f0134f4df4ae383e09da5cd9a6d2d039510fb86a34c8d93614fd40bf2fe06a438e38fba6a42349e9fc2c8ccef1ea78aea29d1ede34d51ba87b6fc7e7d53ed044ae48ed2564d509af77f7e324b2d693fc1dcff00a1478cb10060a421101f829ff9fac1c1ce4732b5561b0906ea0dce6854589a02ca4e38ad9a694f7e586a92fc3609b62366425585291f6df7148c432b52d963076540baa111ab01f1200194b48d9f35f60f4d41b7aee9cae7f7b32052e2a4048d594e0eb21b1732aac49bfc79f1f7e72dae4deea18fffd996a9b6d4cf5849bca74c446a8b9800e36a41681016105dc1f7274b3faa2e9b6e630a1d02d69d83a771db42a18df3");
            result.DateA.ShouldBe(new DateTime(2017, 1, 18));
            result.DateD.ShouldBe(new DateTime(2007, 4, 8));
            result.Sort.ShouldBe(930856715);
            result.Note.ShouldBe("aa290e4ef1214ea08f848ff5ccc0185051186bb1219f4fe89e19e2103780a672ddd0d0b6400649a3b6bc22e3e15553db9f35ce6b47d844a29a3885e34a43e361b710ebec03354efe8d1607c2436f19540c8b0124448444ea86671b7887e26a9620fe0ce82c314f8e9b884b39fd74545c45f61e91ce5d4a0c95d62d1cb3c4a30edbfd5874263a41ec8eae5f95c46d01363190baca28194ade801a17ed243ed1c179452d40d8d54282a42851c9c307da4d26bc1d15ed6749dfa2d3cfea5f8f61527f1e403bdd5d4cdc8a14106c4fd384b38889c4756bc64fbe99a6f24d766e9267eccbd5a158b946b5bf679701da01460e2f006d2e0fb142caa99f");
            result.Status.ShouldBe("f63486891d9e43adb949a5216d11da27769d02c4bb9b4cb887");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOderDetailUpdateDto()
            {
                TradeOrderId = Guid.Parse("499ad2ce-54a8-474c-9daf-abcc6d8f84c1"),
                TradeProductId = Guid.Parse("4160eb62-6602-4c3d-9591-d889eb3a6f69"),
                UnitPrice = 1101059931,
                Quantity = 1115742476,
                OrderDetailStateCode = "3e92292804e94a4aaff9859bf02adc7bbe70d1b4cc964729b2",
                ExtendedInformation = "ac23537153ef47cdb2316851bf27ab8d3df844432b02458d8f14157ccd64dd740b6b6b8274a4459baded01288d9217bbed701463abde42ea98678fd93da92c31752c3aaa2f184c91810c85d4baf53d13f0c60c8120d44f3d8fa59dbf4fedbab0269bba02822e48d28f2720fe9d8fa8c3dd42fb02d50745f692d0afa3cdab9daead35415fc6fb43c6b283177116915e35323a8998106748cc89d4620a465f84917a0edeef838d45b1afeb1f8f7b287f867e8afbaf4576434abf5906474cb3847168a62848d3074c04b0b7fb7f89eb45eacc151af5f3524ebdb7b3f8a1760239f855bce67c224b4799af21c9e8111e6224b24ac407722840e88ec8",
                DateA = new DateTime(2010, 4, 24),
                DateD = new DateTime(2003, 10, 8),
                Sort = 1109019063,
                Note = "a30f6ea2a7b64a48bb265032d9f4727142fc280492334435bbb9267cd37f0e1afca776abaf7c49a0ac3a7ed2ac74ccc51df80e2bed1143d0ba0532d08298fc644c2c01e6b96a41b29c6cc82a7ba2e730bc497745fb9f435085b37aa167ed290635bd0aff2e9845bc9e9c130be343910e931c846742c64eb68056a46ca3da3a2efba16a446e824c5c9f09184dcfd1015025a6e8091f37444b955a9e644aa4f9bfabda049cf2c345d582df31c6b6c3ccdf7d7a547f051d4ec6817f570d4dc1a4c82ba3ca40004a41a68a2feb0ae042b3969dfa66d1cb9040d8b026d09bc5ec4e9a4ed366d8ca154c33b47ccc633410a6619e855336971b4770aa73",
                Status = "f1f528a79d5847749ec0e3ff0bd759772bc8865d743c4b298b"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.UpdateAsync(Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"), input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("499ad2ce-54a8-474c-9daf-abcc6d8f84c1"));
            result.TradeProductId.ShouldBe(Guid.Parse("4160eb62-6602-4c3d-9591-d889eb3a6f69"));
            result.UnitPrice.ShouldBe(1101059931);
            result.Quantity.ShouldBe(1115742476);
            result.OrderDetailStateCode.ShouldBe("3e92292804e94a4aaff9859bf02adc7bbe70d1b4cc964729b2");
            result.ExtendedInformation.ShouldBe("ac23537153ef47cdb2316851bf27ab8d3df844432b02458d8f14157ccd64dd740b6b6b8274a4459baded01288d9217bbed701463abde42ea98678fd93da92c31752c3aaa2f184c91810c85d4baf53d13f0c60c8120d44f3d8fa59dbf4fedbab0269bba02822e48d28f2720fe9d8fa8c3dd42fb02d50745f692d0afa3cdab9daead35415fc6fb43c6b283177116915e35323a8998106748cc89d4620a465f84917a0edeef838d45b1afeb1f8f7b287f867e8afbaf4576434abf5906474cb3847168a62848d3074c04b0b7fb7f89eb45eacc151af5f3524ebdb7b3f8a1760239f855bce67c224b4799af21c9e8111e6224b24ac407722840e88ec8");
            result.DateA.ShouldBe(new DateTime(2010, 4, 24));
            result.DateD.ShouldBe(new DateTime(2003, 10, 8));
            result.Sort.ShouldBe(1109019063);
            result.Note.ShouldBe("a30f6ea2a7b64a48bb265032d9f4727142fc280492334435bbb9267cd37f0e1afca776abaf7c49a0ac3a7ed2ac74ccc51df80e2bed1143d0ba0532d08298fc644c2c01e6b96a41b29c6cc82a7ba2e730bc497745fb9f435085b37aa167ed290635bd0aff2e9845bc9e9c130be343910e931c846742c64eb68056a46ca3da3a2efba16a446e824c5c9f09184dcfd1015025a6e8091f37444b955a9e644aa4f9bfabda049cf2c345d582df31c6b6c3ccdf7d7a547f051d4ec6817f570d4dc1a4c82ba3ca40004a41a68a2feb0ae042b3969dfa66d1cb9040d8b026d09bc5ec4e9a4ed366d8ca154c33b47ccc633410a6619e855336971b4770aa73");
            result.Status.ShouldBe("f1f528a79d5847749ec0e3ff0bd759772bc8865d743c4b298b");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOderDetailsAppService.DeleteAsync(Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"));

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"));

            result.ShouldBeNull();
        }
    }
}