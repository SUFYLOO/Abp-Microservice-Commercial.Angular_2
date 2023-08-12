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
            result.Items.Any(x => x.Id == Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("b508e74c-5247-476e-983d-71b63229e5a9")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _tradeOderDetailsAppService.GetAsync(Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new TradeOderDetailCreateDto
            {
                TradeOrderId = Guid.Parse("2a58e0f5-32c8-42c5-a6e2-01870773f182"),
                TradeProductId = Guid.Parse("f82ca6ae-6224-4bf0-812d-b34ba1fb07fd"),
                UnitPrice = 1332984216,
                Quantity = 1925443172,
                OrderDetailStateCode = "c200b13eccce4536bd38634287ced2988f0a582c09c042b680",
                ExtendedInformation = "e56ba8a60fd849189e8742ab3d6b4b8df70a7e72ed6a43528b8712772a80ef63ef4541e498b9481a9185951f963cf50c522c7e5fba994f5f9e98425e226e76c5ac4035722f6640088e0f4fdf8ac93b5983e5ffec86ba4842935b48c193295db2506a6885865046bbabd94b0ae87bbca21f1b4a71813f4d4b962e40a31664a031ce3cb23107984705a5750026dbb473b3fa55aaf2b03f4114a0606abcbc1cf8792321dab11ec34888aa1bbe93cbfb01f48e766b1542f9473297c49be303712b42c306734679d24dd8940f69f4f35dfa344fce399cb1e94f6cad64fd6433fa188c69818fb7604349519926df1df95e688588117504fa71489cb3b6",
                DateA = new DateTime(2011, 9, 21),
                DateD = new DateTime(2002, 5, 7),
                Sort = 1581248504,
                Note = "f183056af02a40eeb296ebd9f1911a44f7ee8407185548ea988af41b6595251019b6b573b3184b75867dd96792848ea6f43192b34aef40038504db8f812c0644c72dc0cfca164af0ab9e658ed53261e9535d880d543343d0901bbe9b417f0d323582dcdce65e4b9baee4aa4913ad501da4fb93fec734441280129ffe657553fd8141004a86ad49c38c2c315205601524ee8a0a268fe6491a9c3fdda124b5048068909e2636b4412598d962574828dd5d48af5bcb02054ec6bebf2107dc5dd27728137a3a64e546d380193d7ab5911f1b343baf59dc4641e3aa7b5d26a825583e59b7f652353a424f9adb8c69081c8080a72926dea6224817aa4f",
                Status = "b669d3a8ffd64923b1ef3317d8324e5eaa6a07067a564790a7"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.CreateAsync(input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("2a58e0f5-32c8-42c5-a6e2-01870773f182"));
            result.TradeProductId.ShouldBe(Guid.Parse("f82ca6ae-6224-4bf0-812d-b34ba1fb07fd"));
            result.UnitPrice.ShouldBe(1332984216);
            result.Quantity.ShouldBe(1925443172);
            result.OrderDetailStateCode.ShouldBe("c200b13eccce4536bd38634287ced2988f0a582c09c042b680");
            result.ExtendedInformation.ShouldBe("e56ba8a60fd849189e8742ab3d6b4b8df70a7e72ed6a43528b8712772a80ef63ef4541e498b9481a9185951f963cf50c522c7e5fba994f5f9e98425e226e76c5ac4035722f6640088e0f4fdf8ac93b5983e5ffec86ba4842935b48c193295db2506a6885865046bbabd94b0ae87bbca21f1b4a71813f4d4b962e40a31664a031ce3cb23107984705a5750026dbb473b3fa55aaf2b03f4114a0606abcbc1cf8792321dab11ec34888aa1bbe93cbfb01f48e766b1542f9473297c49be303712b42c306734679d24dd8940f69f4f35dfa344fce399cb1e94f6cad64fd6433fa188c69818fb7604349519926df1df95e688588117504fa71489cb3b6");
            result.DateA.ShouldBe(new DateTime(2011, 9, 21));
            result.DateD.ShouldBe(new DateTime(2002, 5, 7));
            result.Sort.ShouldBe(1581248504);
            result.Note.ShouldBe("f183056af02a40eeb296ebd9f1911a44f7ee8407185548ea988af41b6595251019b6b573b3184b75867dd96792848ea6f43192b34aef40038504db8f812c0644c72dc0cfca164af0ab9e658ed53261e9535d880d543343d0901bbe9b417f0d323582dcdce65e4b9baee4aa4913ad501da4fb93fec734441280129ffe657553fd8141004a86ad49c38c2c315205601524ee8a0a268fe6491a9c3fdda124b5048068909e2636b4412598d962574828dd5d48af5bcb02054ec6bebf2107dc5dd27728137a3a64e546d380193d7ab5911f1b343baf59dc4641e3aa7b5d26a825583e59b7f652353a424f9adb8c69081c8080a72926dea6224817aa4f");
            result.Status.ShouldBe("b669d3a8ffd64923b1ef3317d8324e5eaa6a07067a564790a7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new TradeOderDetailUpdateDto()
            {
                TradeOrderId = Guid.Parse("37b2fb62-ceb2-4e67-a4f4-e3429167cc67"),
                TradeProductId = Guid.Parse("d11b35e0-3556-488a-a829-bb313418043e"),
                UnitPrice = 1574412980,
                Quantity = 564919126,
                OrderDetailStateCode = "2f2624fa63a14bffb213aacb8887af9d02dacad33a704f6385",
                ExtendedInformation = "a9b3de83b0944e679e0489dbbe81d016f2a15f610fb449f4a5815ec99fae25b57e43c60a2d8d4937a1113dfa7c2d7b947a536573ec9f4f47bc620ed8eb389c1d278108561b884ec3ac5f7902244de5b05d253925004a462b996cc77dc77ddceff82c3d4b2cb44bc39dc08cf3fa80c403d541a07db43840e68b9de61de44e13d1f54b73ce028a4f088325df1547b8d220c0026e2e20dc4e0892129220347a5783f6d19c7020fa46a283ef93c8c6fffce0126f8300402c42079fb9f4080b473e96117dbd3cbf1640a2a2e999e6118d4d0e166deb67c5124aa6bbb18fdea598b649b4b18474bb414d6794fd0b6a89381230ef5b8d6de328426c94df",
                DateA = new DateTime(2019, 1, 19),
                DateD = new DateTime(2010, 8, 15),
                Sort = 1180493076,
                Note = "12d91667dbcb40829ed83e7681e1b84867260d4230c7415184cc6236c8c1d8f9efd3540faed144a3a88f3b5ee33eb686b1513753a6f04cd49bd06442aeee47dcd9711dffac0648ea891b3b1b8f2c3c1e69a3b034d61346369295f44ae0993e64284e9e4e33ff4a45834fe78fd6eecba4b43b1d0f575949d1a71a79f55ff7d79f8e4192609fac4ab2a8a279db420a8b0d788564d0cc4345b2a504790a992879bed8f0c6f87b8b4cc5acb4f81d4805a2a0449d5a187ddb403ab9d26ff549b500f78435a5634096426fb9eb19c878b5c78aa1559c672e2e48f682e899e23988b9f5d583d689694b4cec9db4056abd8e096fb15cc6ea02e84cd19813",
                Status = "a5a4a43969cd423fab04a2c16efe44177c0a5b25379244f1a8"
            };

            // Act
            var serviceResult = await _tradeOderDetailsAppService.UpdateAsync(Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"), input);

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TradeOrderId.ShouldBe(Guid.Parse("37b2fb62-ceb2-4e67-a4f4-e3429167cc67"));
            result.TradeProductId.ShouldBe(Guid.Parse("d11b35e0-3556-488a-a829-bb313418043e"));
            result.UnitPrice.ShouldBe(1574412980);
            result.Quantity.ShouldBe(564919126);
            result.OrderDetailStateCode.ShouldBe("2f2624fa63a14bffb213aacb8887af9d02dacad33a704f6385");
            result.ExtendedInformation.ShouldBe("a9b3de83b0944e679e0489dbbe81d016f2a15f610fb449f4a5815ec99fae25b57e43c60a2d8d4937a1113dfa7c2d7b947a536573ec9f4f47bc620ed8eb389c1d278108561b884ec3ac5f7902244de5b05d253925004a462b996cc77dc77ddceff82c3d4b2cb44bc39dc08cf3fa80c403d541a07db43840e68b9de61de44e13d1f54b73ce028a4f088325df1547b8d220c0026e2e20dc4e0892129220347a5783f6d19c7020fa46a283ef93c8c6fffce0126f8300402c42079fb9f4080b473e96117dbd3cbf1640a2a2e999e6118d4d0e166deb67c5124aa6bbb18fdea598b649b4b18474bb414d6794fd0b6a89381230ef5b8d6de328426c94df");
            result.DateA.ShouldBe(new DateTime(2019, 1, 19));
            result.DateD.ShouldBe(new DateTime(2010, 8, 15));
            result.Sort.ShouldBe(1180493076);
            result.Note.ShouldBe("12d91667dbcb40829ed83e7681e1b84867260d4230c7415184cc6236c8c1d8f9efd3540faed144a3a88f3b5ee33eb686b1513753a6f04cd49bd06442aeee47dcd9711dffac0648ea891b3b1b8f2c3c1e69a3b034d61346369295f44ae0993e64284e9e4e33ff4a45834fe78fd6eecba4b43b1d0f575949d1a71a79f55ff7d79f8e4192609fac4ab2a8a279db420a8b0d788564d0cc4345b2a504790a992879bed8f0c6f87b8b4cc5acb4f81d4805a2a0449d5a187ddb403ab9d26ff549b500f78435a5634096426fb9eb19c878b5c78aa1559c672e2e48f682e899e23988b9f5d583d689694b4cec9db4056abd8e096fb15cc6ea02e84cd19813");
            result.Status.ShouldBe("a5a4a43969cd423fab04a2c16efe44177c0a5b25379244f1a8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _tradeOderDetailsAppService.DeleteAsync(Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"));

            // Assert
            var result = await _tradeOderDetailRepository.FindAsync(c => c.Id == Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"));

            result.ShouldBeNull();
        }
    }
}