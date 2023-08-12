using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemUserNotifysAppService _systemUserNotifysAppService;
        private readonly IRepository<SystemUserNotify, Guid> _systemUserNotifyRepository;

        public SystemUserNotifysAppServiceTests()
        {
            _systemUserNotifysAppService = GetRequiredService<ISystemUserNotifysAppService>();
            _systemUserNotifyRepository = GetRequiredService<IRepository<SystemUserNotify, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemUserNotifysAppService.GetListAsync(new GetSystemUserNotifysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2dd023e6-4c20-427a-aa09-c54bc56a3b24")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemUserNotifysAppService.GetAsync(Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemUserNotifyCreateDto
            {
                UserMainId = Guid.Parse("ad67cf5c-abd3-44ec-a36a-5c0386a0a151"),
                KeyId = "8212b8fea39a4afcb5bde53ba7933993c45580950ae3475385",
                KeyName = "b18f5a5671b84a5d859ee6daeda284beeaedf030541d4c9aa4",
                NotifyTypeCode = "c9d717971e4845d881d95018eb0420f926f8defb6ba4440fa8",
                AppName = "47c51df30b1e4f63bb977da216caf99b17a9ee24950c4f2d99",
                AppCode = "6eb42387ffab48f0bea4b6ae95cd3c0faee491c9d9f44e7881",
                TitleContents = "526bcd660bcd4b84b32b73e14fa9e98fc610907cf39947a8a3f76deedcdc0e1a37eb4f0d064e49829382490890a1dc6462b41b347f684206b7888f431160b8a3055d3bb335004b1ca8dd690979e82204b22d441c9a7d421bace42481c1a9d671fe7bd8e215f3449c8756bbdcfc84297aedc9c0ca14da4906b061f648697bad35a102aa960c6e422897b3ae636c13b91d1fa170fe41c1448b99ad8c5dae42ac7310194e9c02ea4f1bb7790a7c949021c57aec2558475e4bdd85c322000cd069205fbabe8967aa42849d855b8cefd1c2e68cfb37f4710a44748bc80b2f2decb3667165240f159c4208bc470d7086188034564449dc232041efb526",
                Contents = "f87c90366f2b479c895e8777b1f5ed8ec243324e32be47cc8e040b4c98d2901efde4ae3f80e54a689aba8973a937c3f1aa2bc701833f4f3b9c16e2230f011a37815d8d5c0cb4465aa7af90989f5a967e84c602ccf5444a3092abcb7d5a083b9dcd330df9c1784eb3b1511ab3fc3670be4024cd430c90445e8848ef516d962fe87e1c9864832146869f99ae64e9e61ccb9690c036a8fe44619bd5ce2f4c7f88649e9707cceb2d4c50b6b0ef06a5585202471db9fc82c64bec92abddfca57fe7ffc1ac314ccb64440db70d17f290fa4feb5de84163ff3249eea03c355fe2ad74c703f7aabea963433a93d04116bfaf9a4d47335cbd747c4237b954",
                IsRead = true,
                ExtendedInformation = "e1239b8e597248faa2bc09f68891ec8207121a3bb7f5461d86b149b40d507741f712f2fd28414b5a9f52cb1093eae9dbf384e9f073e6441e9e825fd5e7f33e18c7614e56a80b43198c7c38ff42f8d4c635a10a026e8143b6b37aefff7aaded2d350d881c6fbd4eaf898361b1178f60bfe93545a37d2d4584a3c6f55556cbc8da49768209a978493192d6508ee0d1322e04bae0f93b9449089e0a067cda74efaa52a6758e0faa41808e99ce76c4381fedd00654dddef646b79521dbcf2589a38cff2121074dbb404bbafba99e4c7cec8152e6fb6a94574135812e65fc67c97c25d7cc35f03bf0405bb9bb9a637f450698e931385fc9df4b889a95",
                DateA = new DateTime(2020, 10, 15),
                DateD = new DateTime(2015, 2, 15),
                Sort = 331062716,
                Note = "9563c967e77744ac9143f8b5935dcd72263bb6426959458d90b02a42af021ae92c91f5c97d4e463cbc46150bc105592b3a2b691815634f4fb6777f13d1c09c4ad8f2070b6f2746fbbfaee7f25cbbd915895fad56801c413fb28ac5c0382a36fb9e4a0d02c59242638c1f7b45467da0a6dee8d922183640d5a53736389deaea6b1b5c35583c484902b79ed56918477c8ccd6af5548ed24b4fa1f96b021cb31b3863054aa578f04e75a0b1ece58355b63b8ca3d9af81f048a5994168affb8a81451bc952ccde1244e9bafaf850d52b5781efdad8a983e44c36801452f89714d18821d4a7ab224b4fb5a96166ca2a9271cda69d407cad244f199c92",
                Status = "3260891832b6423f9e886d922756abb9a09e2f1b0b5a4f228b"
            };

            // Act
            var serviceResult = await _systemUserNotifysAppService.CreateAsync(input);

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("ad67cf5c-abd3-44ec-a36a-5c0386a0a151"));
            result.KeyId.ShouldBe("8212b8fea39a4afcb5bde53ba7933993c45580950ae3475385");
            result.KeyName.ShouldBe("b18f5a5671b84a5d859ee6daeda284beeaedf030541d4c9aa4");
            result.NotifyTypeCode.ShouldBe("c9d717971e4845d881d95018eb0420f926f8defb6ba4440fa8");
            result.AppName.ShouldBe("47c51df30b1e4f63bb977da216caf99b17a9ee24950c4f2d99");
            result.AppCode.ShouldBe("6eb42387ffab48f0bea4b6ae95cd3c0faee491c9d9f44e7881");
            result.TitleContents.ShouldBe("526bcd660bcd4b84b32b73e14fa9e98fc610907cf39947a8a3f76deedcdc0e1a37eb4f0d064e49829382490890a1dc6462b41b347f684206b7888f431160b8a3055d3bb335004b1ca8dd690979e82204b22d441c9a7d421bace42481c1a9d671fe7bd8e215f3449c8756bbdcfc84297aedc9c0ca14da4906b061f648697bad35a102aa960c6e422897b3ae636c13b91d1fa170fe41c1448b99ad8c5dae42ac7310194e9c02ea4f1bb7790a7c949021c57aec2558475e4bdd85c322000cd069205fbabe8967aa42849d855b8cefd1c2e68cfb37f4710a44748bc80b2f2decb3667165240f159c4208bc470d7086188034564449dc232041efb526");
            result.Contents.ShouldBe("f87c90366f2b479c895e8777b1f5ed8ec243324e32be47cc8e040b4c98d2901efde4ae3f80e54a689aba8973a937c3f1aa2bc701833f4f3b9c16e2230f011a37815d8d5c0cb4465aa7af90989f5a967e84c602ccf5444a3092abcb7d5a083b9dcd330df9c1784eb3b1511ab3fc3670be4024cd430c90445e8848ef516d962fe87e1c9864832146869f99ae64e9e61ccb9690c036a8fe44619bd5ce2f4c7f88649e9707cceb2d4c50b6b0ef06a5585202471db9fc82c64bec92abddfca57fe7ffc1ac314ccb64440db70d17f290fa4feb5de84163ff3249eea03c355fe2ad74c703f7aabea963433a93d04116bfaf9a4d47335cbd747c4237b954");
            result.IsRead.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("e1239b8e597248faa2bc09f68891ec8207121a3bb7f5461d86b149b40d507741f712f2fd28414b5a9f52cb1093eae9dbf384e9f073e6441e9e825fd5e7f33e18c7614e56a80b43198c7c38ff42f8d4c635a10a026e8143b6b37aefff7aaded2d350d881c6fbd4eaf898361b1178f60bfe93545a37d2d4584a3c6f55556cbc8da49768209a978493192d6508ee0d1322e04bae0f93b9449089e0a067cda74efaa52a6758e0faa41808e99ce76c4381fedd00654dddef646b79521dbcf2589a38cff2121074dbb404bbafba99e4c7cec8152e6fb6a94574135812e65fc67c97c25d7cc35f03bf0405bb9bb9a637f450698e931385fc9df4b889a95");
            result.DateA.ShouldBe(new DateTime(2020, 10, 15));
            result.DateD.ShouldBe(new DateTime(2015, 2, 15));
            result.Sort.ShouldBe(331062716);
            result.Note.ShouldBe("9563c967e77744ac9143f8b5935dcd72263bb6426959458d90b02a42af021ae92c91f5c97d4e463cbc46150bc105592b3a2b691815634f4fb6777f13d1c09c4ad8f2070b6f2746fbbfaee7f25cbbd915895fad56801c413fb28ac5c0382a36fb9e4a0d02c59242638c1f7b45467da0a6dee8d922183640d5a53736389deaea6b1b5c35583c484902b79ed56918477c8ccd6af5548ed24b4fa1f96b021cb31b3863054aa578f04e75a0b1ece58355b63b8ca3d9af81f048a5994168affb8a81451bc952ccde1244e9bafaf850d52b5781efdad8a983e44c36801452f89714d18821d4a7ab224b4fb5a96166ca2a9271cda69d407cad244f199c92");
            result.Status.ShouldBe("3260891832b6423f9e886d922756abb9a09e2f1b0b5a4f228b");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemUserNotifyUpdateDto()
            {
                UserMainId = Guid.Parse("e97df4b6-4346-4316-bc0b-0f72d31bfc9f"),
                KeyId = "3d10a6f5cbd34dd88e3b1cfedc634bc7bc345676b95441f8ab",
                KeyName = "d1fad169c82445058922162c20f0b9d27a55cc4800e54bf194",
                NotifyTypeCode = "d95bd413288c4a40b774b8b54c1ff4cc57a22b646c7e473a88",
                AppName = "10e644960dad422ea1e6b2e2dde93cd664e077b77b4c4c0ab3",
                AppCode = "b7041a06a1b84eca9b05ea7ba6f10a35d1c471299a76478099",
                TitleContents = "1f974883973045968e9e2538182caab58520b8d91a36467fa76be6b46fe2011748925c70eaab472c89a0d5e00a5a397783a687bb6ced41b3832c940072e58639c94f42c4126648eabeb197b553f2d1f41450bd9aa3d643ea987c393b9c6c079146bc1ed3c3854db89293aaa2d76b0b334ec9342dfe97495b9203a468e9669853aee89709ebdb4eecba3f23a380ea587138e933a130b14a4c934c91047c78e4306fd4ec61653e4d2c97cf08da253dcb48d313a0b147c04454a13193bcd99c267390064aff3e4440d1aa37d7e35722a7bcf4d3ca587a9d481cab00d4f3598ed97bb33471af604e4bc782bc250f8c55f6d2a631e75cafcb4fb39dec",
                Contents = "1882fea96bf1460f9989f52a4d44955519a7ed19b20f4819805f5be3474f2fb90ebaf5754a7b4585a72301cfd8b93116a78ae5e098ca4fecaa7cab530e38d7fac06b0c7cb1044c6fb306574290e2803da69a5e5c56604f3183f04cf8ad735c9bcbd6f99c657b4d2297cb94d60cd641d764b0192e61074076ab4d30ef331d4045af1408eb3f0f4a96b0f917adb4f03811488e92891d3d4ea996243b497b0b907a04fee87949754615b13f5cecb88a66aaf506682985c14fcfb874410269351132b732aafcc07646d18199caa4afbb947ed546b55d30b34d26b418adc653f43919b54990ed12c04d398184d8b92c5c0b619ba2cb3dbcc9451e8ed9",
                IsRead = true,
                ExtendedInformation = "e6f5c7fa4e1543469326ebcfdaecda6054a42fa205ad4e6c8b6add9707c90ef75324b003292d42ae89b57dcdfe93b976d81b64e3db5942cc8ce0ea44b1f63869f0713f4d5ba24b3fbbba1412d6397457d4154edb138b4df996bbcc0b2be0bfcb3ec7d257c20a4ce6a5ff1ae5948dfa1481a878dac665431281c0cdbd0a2c07249c8fcc1890a74e16b35417cc70d88844e2f1acb5216d4e9a9857f210b7a28c4efb064f6347d54b209e9fa1aef2ddacf4eaf9795042e64096afa048729529140c3f6ccda802304da8a7dd7c39e3d3203bc6c1e257eb7b4c2c80bb50bf3669719ba93d37c6418e4c09ae35373c445f891d67ec582e1b4e4c8cbd0b",
                DateA = new DateTime(2009, 7, 1),
                DateD = new DateTime(2008, 9, 14),
                Sort = 501269594,
                Note = "6ec54f533e52448a8e4f2fa1035f9684168790161b2c49eeaec74791684b26a7f416a8e12c7b4d64ac4e01ba1fcacb40d10775128ade473f89be7eced3c4605735671176539e43cf9408510df88dafc171e3b6502b2f4eacbf5f7ad5d721733a78f5d4ddf47e4247a93a437eb1440bc0552d126aaefc41459052d6ed6d782d3cb1239ce0264f4887a89688e84dab52b729f72329c5d24ad58c9293222a62ef8483dd8cf2039a45c28ef874adb21f8b9bcd9c1c9696ef40bbb859de8dfe842c7cb9397a1d0a274b568af5946aeda732ba0e7a28aaa69142d28c4c976ef1e625da211a52aab3f14a33880347c1e88204768d171e3170be4f46bd5f",
                Status = "79c82b2ce66246a4a146f1be28cef0c6ee9cb91aad25440eaa"
            };

            // Act
            var serviceResult = await _systemUserNotifysAppService.UpdateAsync(Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"), input);

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("e97df4b6-4346-4316-bc0b-0f72d31bfc9f"));
            result.KeyId.ShouldBe("3d10a6f5cbd34dd88e3b1cfedc634bc7bc345676b95441f8ab");
            result.KeyName.ShouldBe("d1fad169c82445058922162c20f0b9d27a55cc4800e54bf194");
            result.NotifyTypeCode.ShouldBe("d95bd413288c4a40b774b8b54c1ff4cc57a22b646c7e473a88");
            result.AppName.ShouldBe("10e644960dad422ea1e6b2e2dde93cd664e077b77b4c4c0ab3");
            result.AppCode.ShouldBe("b7041a06a1b84eca9b05ea7ba6f10a35d1c471299a76478099");
            result.TitleContents.ShouldBe("1f974883973045968e9e2538182caab58520b8d91a36467fa76be6b46fe2011748925c70eaab472c89a0d5e00a5a397783a687bb6ced41b3832c940072e58639c94f42c4126648eabeb197b553f2d1f41450bd9aa3d643ea987c393b9c6c079146bc1ed3c3854db89293aaa2d76b0b334ec9342dfe97495b9203a468e9669853aee89709ebdb4eecba3f23a380ea587138e933a130b14a4c934c91047c78e4306fd4ec61653e4d2c97cf08da253dcb48d313a0b147c04454a13193bcd99c267390064aff3e4440d1aa37d7e35722a7bcf4d3ca587a9d481cab00d4f3598ed97bb33471af604e4bc782bc250f8c55f6d2a631e75cafcb4fb39dec");
            result.Contents.ShouldBe("1882fea96bf1460f9989f52a4d44955519a7ed19b20f4819805f5be3474f2fb90ebaf5754a7b4585a72301cfd8b93116a78ae5e098ca4fecaa7cab530e38d7fac06b0c7cb1044c6fb306574290e2803da69a5e5c56604f3183f04cf8ad735c9bcbd6f99c657b4d2297cb94d60cd641d764b0192e61074076ab4d30ef331d4045af1408eb3f0f4a96b0f917adb4f03811488e92891d3d4ea996243b497b0b907a04fee87949754615b13f5cecb88a66aaf506682985c14fcfb874410269351132b732aafcc07646d18199caa4afbb947ed546b55d30b34d26b418adc653f43919b54990ed12c04d398184d8b92c5c0b619ba2cb3dbcc9451e8ed9");
            result.IsRead.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("e6f5c7fa4e1543469326ebcfdaecda6054a42fa205ad4e6c8b6add9707c90ef75324b003292d42ae89b57dcdfe93b976d81b64e3db5942cc8ce0ea44b1f63869f0713f4d5ba24b3fbbba1412d6397457d4154edb138b4df996bbcc0b2be0bfcb3ec7d257c20a4ce6a5ff1ae5948dfa1481a878dac665431281c0cdbd0a2c07249c8fcc1890a74e16b35417cc70d88844e2f1acb5216d4e9a9857f210b7a28c4efb064f6347d54b209e9fa1aef2ddacf4eaf9795042e64096afa048729529140c3f6ccda802304da8a7dd7c39e3d3203bc6c1e257eb7b4c2c80bb50bf3669719ba93d37c6418e4c09ae35373c445f891d67ec582e1b4e4c8cbd0b");
            result.DateA.ShouldBe(new DateTime(2009, 7, 1));
            result.DateD.ShouldBe(new DateTime(2008, 9, 14));
            result.Sort.ShouldBe(501269594);
            result.Note.ShouldBe("6ec54f533e52448a8e4f2fa1035f9684168790161b2c49eeaec74791684b26a7f416a8e12c7b4d64ac4e01ba1fcacb40d10775128ade473f89be7eced3c4605735671176539e43cf9408510df88dafc171e3b6502b2f4eacbf5f7ad5d721733a78f5d4ddf47e4247a93a437eb1440bc0552d126aaefc41459052d6ed6d782d3cb1239ce0264f4887a89688e84dab52b729f72329c5d24ad58c9293222a62ef8483dd8cf2039a45c28ef874adb21f8b9bcd9c1c9696ef40bbb859de8dfe842c7cb9397a1d0a274b568af5946aeda732ba0e7a28aaa69142d28c4c976ef1e625da211a52aab3f14a33880347c1e88204768d171e3170be4f46bd5f");
            result.Status.ShouldBe("79c82b2ce66246a4a146f1be28cef0c6ee9cb91aad25440eaa");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemUserNotifysAppService.DeleteAsync(Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"));

            // Assert
            var result = await _systemUserNotifyRepository.FindAsync(c => c.Id == Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"));

            result.ShouldBeNull();
        }
    }
}