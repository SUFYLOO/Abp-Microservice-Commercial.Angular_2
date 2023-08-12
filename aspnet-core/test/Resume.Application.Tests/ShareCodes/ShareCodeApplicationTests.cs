using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareCodes
{
    public class ShareCodesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareCodesAppService _shareCodesAppService;
        private readonly IRepository<ShareCode, Guid> _shareCodeRepository;

        public ShareCodesAppServiceTests()
        {
            _shareCodesAppService = GetRequiredService<IShareCodesAppService>();
            _shareCodeRepository = GetRequiredService<IRepository<ShareCode, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareCodesAppService.GetListAsync(new GetShareCodesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("a0c2fb89-d7ff-4b5a-9dfd-57dc09f1154b")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareCodesAppService.GetAsync(Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareCodeCreateDto
            {
                GroupCode = "f33e290015af4777a565ce483d44d7f22e5f4f5ca8c1497fbb",
                Key1 = "441bd1f59d114c68b9f63d882f4a28e343dfcc2b818b429086e2763133e112038f6c1788216b4c50b8e61b4027cb2c7fc355",
                Key2 = "d8829efdddbe464696edea41c25d1fe344651c5a4f9a48af9aa1cccf77c04ce4e46ef17cd0ef41d9a9f6fb80a9b16d1e0db6",
                Key3 = "972a1ae639f447079245aa4191dd9514adca866243cb431d858b7d34eab6aea56622ba94b47244228d415e51e51d17da263f",
                Name = "44d5c9e13e6c431b9eaf67c24bd3f68d0d0bf9eb46b94a36b9c67dab9ba32f88c75de8d81c0f46b2981c84a8caaf5d291cee",
                Column1 = "bc0c0a5fe12c422c8db4aa66247bc63347cb60ee805f4cd780",
                Column2 = "736be31957114e5f8090249fa22ad93811f16d6dc1be46f3bf",
                Column3 = "a740af95505947f7ae56dceebaa601234628c375250341ad86",
                SystemUse = true,
                ExtendedInformation = "101153fe251c4abb903e0462ae5daed32a4ed142bcf443e6a125791bad8aa5ff4f46df3945f04bf39adccd85ac52c2187608677f32184682b7b7f613b02fdd608b21eb61bc5a47abaa4ed8cc17c9ff469ad7dfd5dfd54f7d8bf17c56d48a398dee6163bb52fb47f1b8312c32fe031defaa943ee306ac4e54901841782026381d34a6c0eb61b04c40bbc9b249a10f9ad71a727bb10dfe42a283062b42fbeda9d4598ef16bfbc0465b926e17e6422cda2c5fc37284ca4842b9b20bc54412d620d5f32ca80796b14f55beb8139a9aad7b4d29c597d432dc4922b1b13f3ff3257ada4dbdc6d1416e43b48578acb2ddab0c5e1d654aa4a2a840e69b34",
                DateA = new DateTime(2002, 3, 8),
                DateD = new DateTime(2002, 10, 18),
                Sort = 1439444860,
                Note = "935c7d91e09a4f8a9649efb4fb174161dbe1557349a040a99259f91acf8e278422d28d2828924e30a91410cee5e03d0ff704a05ee47e4657a254b161be0e1c6aa99ddf1c30da49df9302043907c4aa1383e4f0692e2a4b4faaa16ffea99e56b3c65ff56437f54f618bc6ae145b0aed3d96d10822592c4321ae6a0a2be49ebf5f811679072e654f5885f5ad47c399c7add5b096e848ce4c8fa2e90a1883ccd85020124d0889e14ff28ce71e43aace0e64f1db8a55f62044f78366dbde37d75f19c5d02c1677b541d7907bffff152188cb6bd15d7a3a79430cbfde73e1e4d223d6ebb6de6ef03e4482817affe5d2d4ae684c6cdef35de443918b92",
                Status = "41b45caed1d947a498ad9850695889cdebb2476ff8954a2086"
            };

            // Act
            var serviceResult = await _shareCodesAppService.CreateAsync(input);

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("f33e290015af4777a565ce483d44d7f22e5f4f5ca8c1497fbb");
            result.Key1.ShouldBe("441bd1f59d114c68b9f63d882f4a28e343dfcc2b818b429086e2763133e112038f6c1788216b4c50b8e61b4027cb2c7fc355");
            result.Key2.ShouldBe("d8829efdddbe464696edea41c25d1fe344651c5a4f9a48af9aa1cccf77c04ce4e46ef17cd0ef41d9a9f6fb80a9b16d1e0db6");
            result.Key3.ShouldBe("972a1ae639f447079245aa4191dd9514adca866243cb431d858b7d34eab6aea56622ba94b47244228d415e51e51d17da263f");
            result.Name.ShouldBe("44d5c9e13e6c431b9eaf67c24bd3f68d0d0bf9eb46b94a36b9c67dab9ba32f88c75de8d81c0f46b2981c84a8caaf5d291cee");
            result.Column1.ShouldBe("bc0c0a5fe12c422c8db4aa66247bc63347cb60ee805f4cd780");
            result.Column2.ShouldBe("736be31957114e5f8090249fa22ad93811f16d6dc1be46f3bf");
            result.Column3.ShouldBe("a740af95505947f7ae56dceebaa601234628c375250341ad86");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("101153fe251c4abb903e0462ae5daed32a4ed142bcf443e6a125791bad8aa5ff4f46df3945f04bf39adccd85ac52c2187608677f32184682b7b7f613b02fdd608b21eb61bc5a47abaa4ed8cc17c9ff469ad7dfd5dfd54f7d8bf17c56d48a398dee6163bb52fb47f1b8312c32fe031defaa943ee306ac4e54901841782026381d34a6c0eb61b04c40bbc9b249a10f9ad71a727bb10dfe42a283062b42fbeda9d4598ef16bfbc0465b926e17e6422cda2c5fc37284ca4842b9b20bc54412d620d5f32ca80796b14f55beb8139a9aad7b4d29c597d432dc4922b1b13f3ff3257ada4dbdc6d1416e43b48578acb2ddab0c5e1d654aa4a2a840e69b34");
            result.DateA.ShouldBe(new DateTime(2002, 3, 8));
            result.DateD.ShouldBe(new DateTime(2002, 10, 18));
            result.Sort.ShouldBe(1439444860);
            result.Note.ShouldBe("935c7d91e09a4f8a9649efb4fb174161dbe1557349a040a99259f91acf8e278422d28d2828924e30a91410cee5e03d0ff704a05ee47e4657a254b161be0e1c6aa99ddf1c30da49df9302043907c4aa1383e4f0692e2a4b4faaa16ffea99e56b3c65ff56437f54f618bc6ae145b0aed3d96d10822592c4321ae6a0a2be49ebf5f811679072e654f5885f5ad47c399c7add5b096e848ce4c8fa2e90a1883ccd85020124d0889e14ff28ce71e43aace0e64f1db8a55f62044f78366dbde37d75f19c5d02c1677b541d7907bffff152188cb6bd15d7a3a79430cbfde73e1e4d223d6ebb6de6ef03e4482817affe5d2d4ae684c6cdef35de443918b92");
            result.Status.ShouldBe("41b45caed1d947a498ad9850695889cdebb2476ff8954a2086");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareCodeUpdateDto()
            {
                GroupCode = "66eabf4b65bc4fe5a61825cc458d487e51ff5940188945648d",
                Key1 = "5d00440e120f410b9001e1744beaa54a57f3dc25cfed4f0ebc12b321b88b080b11dbeb9f6c5d426389e738584523e6612fc5",
                Key2 = "a4b00336f742433cbaa9b34af5878ea46b9f1fa2fb1e498789af7a2852bd4d2fb3c3fae1500c4858bfa41bf7acce79601c34",
                Key3 = "202712cbe34442afba31e9851d912c6e067cee39e9f94ff5bc80669b424be2c0fb449fa831764d439ff20586a7589bbfe476",
                Name = "1167463113c94a11b2853f354c5854bd8c8560cbc1b8402da7611015093c49b6d645fa50b4a84feda0c34efbf7349a24da11",
                Column1 = "133f13df715c475cb3f87038ac5e71a240b2f05fbca74410b2",
                Column2 = "6dcfc6d8df6c4d32a27d57f1ad0c13537987c922c7ef4d2888",
                Column3 = "86959016951d4a0fa6d6c37c9f40a7707d83354c326e450090",
                SystemUse = true,
                ExtendedInformation = "61eb4be5f9314d9c86573ece39e8b84748d781b2621949d2ae0d7fb486403591ba99b5dc94914fb9a5457240584bbc5858bc003b009f4cde8bbc681b97a878126048c949b8184e7092102db5b66949c58564de96316f4459abf23ccb3beec1d266941a4ac0354b2fa5f31db812ad12e5bbd0f0891dc14700af3604266d0103d14e20e0e9da7c4febafa6f0f88771315e343bd9f8187449ffb864ac7c124280fe57ce0e1855664fe980d790073451633750af6cf65a1e41ecbc1590c0292bf8513d0684575e584907997410daa2a120465273fa59adfb4068838718e61368907fd9e9a528ce8144518d692396f4fe3aea389bf2f26a914137849a",
                DateA = new DateTime(2000, 4, 20),
                DateD = new DateTime(2019, 10, 4),
                Sort = 806759864,
                Note = "b7caeb79553946f89347616648d854542345bec83a664f1a8c5c0a465aa3ce76cf4c02aa2f54492199ff7d6ac93f58b1cba15a2752ed4227bf2b9b6adcf8d13bb5534392b7bc455893229ca65520f795e1b8ede48703482a9a9d8104738a6a4bcdef60a0a3654bbd968f85a403acf6b5ccb9e111fdce473c99219c88d0aebc28653e134bbeb649c19d1d29af3eea08d3c3fa83025c554250958aeca887c0f48bad47d864f1aa40b8a23a2c4c52defd5442c38a5e5cf2404aa89dbeee27a1507e5add229582734479b5cedd97ee69c7e23a39f1d8714241d7a761620cb0b97d41cedba03246b642d7898f56f263f05a60a9a86c131c234ef697b8",
                Status = "f5850e2cfa404614a5ed24b6523537b808654de8cf4d46e5b0"
            };

            // Act
            var serviceResult = await _shareCodesAppService.UpdateAsync(Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"), input);

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("66eabf4b65bc4fe5a61825cc458d487e51ff5940188945648d");
            result.Key1.ShouldBe("5d00440e120f410b9001e1744beaa54a57f3dc25cfed4f0ebc12b321b88b080b11dbeb9f6c5d426389e738584523e6612fc5");
            result.Key2.ShouldBe("a4b00336f742433cbaa9b34af5878ea46b9f1fa2fb1e498789af7a2852bd4d2fb3c3fae1500c4858bfa41bf7acce79601c34");
            result.Key3.ShouldBe("202712cbe34442afba31e9851d912c6e067cee39e9f94ff5bc80669b424be2c0fb449fa831764d439ff20586a7589bbfe476");
            result.Name.ShouldBe("1167463113c94a11b2853f354c5854bd8c8560cbc1b8402da7611015093c49b6d645fa50b4a84feda0c34efbf7349a24da11");
            result.Column1.ShouldBe("133f13df715c475cb3f87038ac5e71a240b2f05fbca74410b2");
            result.Column2.ShouldBe("6dcfc6d8df6c4d32a27d57f1ad0c13537987c922c7ef4d2888");
            result.Column3.ShouldBe("86959016951d4a0fa6d6c37c9f40a7707d83354c326e450090");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("61eb4be5f9314d9c86573ece39e8b84748d781b2621949d2ae0d7fb486403591ba99b5dc94914fb9a5457240584bbc5858bc003b009f4cde8bbc681b97a878126048c949b8184e7092102db5b66949c58564de96316f4459abf23ccb3beec1d266941a4ac0354b2fa5f31db812ad12e5bbd0f0891dc14700af3604266d0103d14e20e0e9da7c4febafa6f0f88771315e343bd9f8187449ffb864ac7c124280fe57ce0e1855664fe980d790073451633750af6cf65a1e41ecbc1590c0292bf8513d0684575e584907997410daa2a120465273fa59adfb4068838718e61368907fd9e9a528ce8144518d692396f4fe3aea389bf2f26a914137849a");
            result.DateA.ShouldBe(new DateTime(2000, 4, 20));
            result.DateD.ShouldBe(new DateTime(2019, 10, 4));
            result.Sort.ShouldBe(806759864);
            result.Note.ShouldBe("b7caeb79553946f89347616648d854542345bec83a664f1a8c5c0a465aa3ce76cf4c02aa2f54492199ff7d6ac93f58b1cba15a2752ed4227bf2b9b6adcf8d13bb5534392b7bc455893229ca65520f795e1b8ede48703482a9a9d8104738a6a4bcdef60a0a3654bbd968f85a403acf6b5ccb9e111fdce473c99219c88d0aebc28653e134bbeb649c19d1d29af3eea08d3c3fa83025c554250958aeca887c0f48bad47d864f1aa40b8a23a2c4c52defd5442c38a5e5cf2404aa89dbeee27a1507e5add229582734479b5cedd97ee69c7e23a39f1d8714241d7a761620cb0b97d41cedba03246b642d7898f56f263f05a60a9a86c131c234ef697b8");
            result.Status.ShouldBe("f5850e2cfa404614a5ed24b6523537b808654de8cf4d46e5b0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareCodesAppService.DeleteAsync(Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"));

            // Assert
            var result = await _shareCodeRepository.FindAsync(c => c.Id == Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"));

            result.ShouldBeNull();
        }
    }
}