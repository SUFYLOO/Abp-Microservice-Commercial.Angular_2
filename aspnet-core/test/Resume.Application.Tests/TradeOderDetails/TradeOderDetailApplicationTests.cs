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
            result.Items.Any(x => x.Id == Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("49b64dbc-456a-4d5e-bb0f-1c1377103e4f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOderDetailsAppService.GetAsync(Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOderDetailCreateDto
            {
                TradeOrderId = Guid.Parse("160c4464-85be-4e4c-b86e-1a4fc2d5c7b6"),
                TradeProductId = Guid.Parse("75ca6f2a-fce7-46ae-b17a-03a3d47c18a3"),
                UnitPrice = 249717988,
                Quantity = 1550017241,
                OrderDetailStateCode = "fbc368520616484495048372d4d36e56b87fcb28dcf44324b8",
                ExtendedInformation = "c86407af84a548a081c74582cc8962ade9661296da8e418393f20e1b04da76d74a6fed42fced4b95a7ff00e926cef696fefa17616f4a45cd939a18a660163cd5b331f42bb4c44b119753861089718c0d7421cde4d08e4e29b7f08336699df52efeac9d1718d5440ea882937e8627c0eabdc5c5db19dc4360a5b86734612f25942abcaf0728564f518255fd9ba3b50956e31b0c83a9084fc09115eccc95310f5173e8434b06bf4029830e2329265618adcad18727a14546df903eda549ae8cde0213b5d86261849ddb3a9958788fdca7f5c5aee834ce84609a163ca27cafb2df786d5437ee0af4d60a63add84fcc8fc3b9c25bfe6001642ffb1ac",
                DateA = new DateTime(2017, 3, 26),
                DateD = new DateTime(2013, 3, 14),
                Sort = 1815801026,
                Note = "775c814a17b7462dbc592f9823dee94b7709824b451c4675af9e405ecd97445066149869d71e4cdbbd3e52b0bba6e67a90fc9b651d8a411d8525180c0659efc516cb66b36bfd46d3b4b4ec2c1345b2fec747d174adbb4dbcba78a13d8e956279869a17ca46294e44a95f4f3bef68db81052c24dbf4664947a6b1151626ab34748d0ebe0c9dd04d0c8b67412fadbc2e94d9677abdb10744e0bdb02a99f1d85080f58da298b5774e30a0924d68af71bfc1dfc2d021dc484340b521bf8f42d0163e9733eca9c46543ad812e430afc7790d4352400d2bf50400ea33bb7c14eee2b4e242872ea04b043cc9899c293dd01baf67070dc823c06490fa228",
                Status = "8c950635a3eb42fd89c5accd5ef43938d49e8b75b1cd47e8a0"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("160c4464-85be-4e4c-b86e-1a4fc2d5c7b6"));
            result.TradeProductId.ShouldBe(Guid.Parse("75ca6f2a-fce7-46ae-b17a-03a3d47c18a3"));
            result.UnitPrice.ShouldBe(249717988);
            result.Quantity.ShouldBe(1550017241);
            result.OrderDetailStateCode.ShouldBe("fbc368520616484495048372d4d36e56b87fcb28dcf44324b8");
            result.ExtendedInformation.ShouldBe("c86407af84a548a081c74582cc8962ade9661296da8e418393f20e1b04da76d74a6fed42fced4b95a7ff00e926cef696fefa17616f4a45cd939a18a660163cd5b331f42bb4c44b119753861089718c0d7421cde4d08e4e29b7f08336699df52efeac9d1718d5440ea882937e8627c0eabdc5c5db19dc4360a5b86734612f25942abcaf0728564f518255fd9ba3b50956e31b0c83a9084fc09115eccc95310f5173e8434b06bf4029830e2329265618adcad18727a14546df903eda549ae8cde0213b5d86261849ddb3a9958788fdca7f5c5aee834ce84609a163ca27cafb2df786d5437ee0af4d60a63add84fcc8fc3b9c25bfe6001642ffb1ac");
            result.DateA.ShouldBe(new DateTime(2017, 3, 26));
            result.DateD.ShouldBe(new DateTime(2013, 3, 14));
            result.Sort.ShouldBe(1815801026);
            result.Note.ShouldBe("775c814a17b7462dbc592f9823dee94b7709824b451c4675af9e405ecd97445066149869d71e4cdbbd3e52b0bba6e67a90fc9b651d8a411d8525180c0659efc516cb66b36bfd46d3b4b4ec2c1345b2fec747d174adbb4dbcba78a13d8e956279869a17ca46294e44a95f4f3bef68db81052c24dbf4664947a6b1151626ab34748d0ebe0c9dd04d0c8b67412fadbc2e94d9677abdb10744e0bdb02a99f1d85080f58da298b5774e30a0924d68af71bfc1dfc2d021dc484340b521bf8f42d0163e9733eca9c46543ad812e430afc7790d4352400d2bf50400ea33bb7c14eee2b4e242872ea04b043cc9899c293dd01baf67070dc823c06490fa228");
            result.Status.ShouldBe("8c950635a3eb42fd89c5accd5ef43938d49e8b75b1cd47e8a0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOderDetailUpdateDto()
            {
                TradeOrderId = Guid.Parse("5bebd9b4-7dcc-4232-bec7-5f2e332404f1"),
                TradeProductId = Guid.Parse("af2b8832-1bb7-4109-9916-b1dfccb01eba"),
                UnitPrice = 48397909,
                Quantity = 578567062,
                OrderDetailStateCode = "c20a0ff57ef246f990a45a14af0f05c6a11a10fc5eae466c8e",
                ExtendedInformation = "36cba7b0f4bb4d4db9d9965614159f00125e336fca004f188326a214174d9bb67fcfff7fb26f4b8fbe23af1ad4b172d78d0674388619491c9df45447b6e8d51ce8391b5ca04646598267f7498384f87dcdfea7d79a244f5b94e761569867c6241e3bf46bd3cf42e99c9f101e37090f2a4ea689195fe34059a956187fc3d0169044754db6982f41d1b8c54c60eeb3ff9ff399cf97bd374871a8274416490cef08b8a0fe853cc7452dac38f3811b72bdb2a74800349e794588a3a5efe03b14293e2bf6c73c85d8418aa9a29110ab048dc7d61182b9b60c4ade9f9a599eb6bed9847d51f7d918e2441497697d8763abbd489eacf91f249b431886b4",
                DateA = new DateTime(2016, 7, 14),
                DateD = new DateTime(2019, 1, 4),
                Sort = 2082403793,
                Note = "29df12d0c6304a4fa36c90a47bd2f078b59c25fb0e6d42edaf1d01799015be8c9f348a07cecb45cdbe47be44ebd2f5051321c332c3b54f93a1aaf918fdde287af921435569514855819fac907f470de12a0f5f492e81426e9a75818c1a089e1de6bfba5ef63e4ecdbb15c83d1325b2648aa1f5c775f045e59d5a377a337d68abed98529ce6b845008c65a43cd19ae45b77af5a4a58314258b99beba6a3d890530e99e4291fbe4efdb98692e1d78a7e0ffee68374902f4640b601a0a1a607cdad8534e0fe3b724f9f91e2ecb8fb3bdfe79ec8801bf26f4c4689dc58f476492cf47d633a6dd4444626948d083f591297a823844b63b61e49ffb9a9",
                Status = "9a86a4e1d15740c791ae94045985801e160ce70f1e25415f9d"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.UpdateAsync(Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"), input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("5bebd9b4-7dcc-4232-bec7-5f2e332404f1"));
            result.TradeProductId.ShouldBe(Guid.Parse("af2b8832-1bb7-4109-9916-b1dfccb01eba"));
            result.UnitPrice.ShouldBe(48397909);
            result.Quantity.ShouldBe(578567062);
            result.OrderDetailStateCode.ShouldBe("c20a0ff57ef246f990a45a14af0f05c6a11a10fc5eae466c8e");
            result.ExtendedInformation.ShouldBe("36cba7b0f4bb4d4db9d9965614159f00125e336fca004f188326a214174d9bb67fcfff7fb26f4b8fbe23af1ad4b172d78d0674388619491c9df45447b6e8d51ce8391b5ca04646598267f7498384f87dcdfea7d79a244f5b94e761569867c6241e3bf46bd3cf42e99c9f101e37090f2a4ea689195fe34059a956187fc3d0169044754db6982f41d1b8c54c60eeb3ff9ff399cf97bd374871a8274416490cef08b8a0fe853cc7452dac38f3811b72bdb2a74800349e794588a3a5efe03b14293e2bf6c73c85d8418aa9a29110ab048dc7d61182b9b60c4ade9f9a599eb6bed9847d51f7d918e2441497697d8763abbd489eacf91f249b431886b4");
            result.DateA.ShouldBe(new DateTime(2016, 7, 14));
            result.DateD.ShouldBe(new DateTime(2019, 1, 4));
            result.Sort.ShouldBe(2082403793);
            result.Note.ShouldBe("29df12d0c6304a4fa36c90a47bd2f078b59c25fb0e6d42edaf1d01799015be8c9f348a07cecb45cdbe47be44ebd2f5051321c332c3b54f93a1aaf918fdde287af921435569514855819fac907f470de12a0f5f492e81426e9a75818c1a089e1de6bfba5ef63e4ecdbb15c83d1325b2648aa1f5c775f045e59d5a377a337d68abed98529ce6b845008c65a43cd19ae45b77af5a4a58314258b99beba6a3d890530e99e4291fbe4efdb98692e1d78a7e0ffee68374902f4640b601a0a1a607cdad8534e0fe3b724f9f91e2ecb8fb3bdfe79ec8801bf26f4c4689dc58f476492cf47d633a6dd4444626948d083f591297a823844b63b61e49ffb9a9");
            result.Status.ShouldBe("9a86a4e1d15740c791ae94045985801e160ce70f1e25415f9d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOderDetailsAppService.DeleteAsync(Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"));

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"));

            result.ShouldBeNull();
        }
    }
}