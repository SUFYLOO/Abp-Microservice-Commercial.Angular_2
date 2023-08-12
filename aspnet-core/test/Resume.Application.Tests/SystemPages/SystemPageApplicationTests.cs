using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemPages
{
    public class SystemPagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemPagesAppService _systemPagesAppService;
        private readonly IRepository<SystemPage, Guid> _systemPageRepository;

        public SystemPagesAppServiceTests()
        {
            _systemPagesAppService = GetRequiredService<ISystemPagesAppService>();
            _systemPageRepository = GetRequiredService<IRepository<SystemPage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemPagesAppService.GetListAsync(new GetSystemPagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("48bdc64b-2842-4608-9217-4375e96dae12")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemPagesAppService.GetAsync(Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemPageCreateDto
            {
                TypeCode = "ea25377d34b44c62b04318247e34941bdeb705bee2cd460fbc",
                FilePath = "c3074d767cce44599ef4c2c058e7d804374ae7239062499eab6f35f9ab3b7047335990d5094244db8f1ad65ef40aad45756b70fec28f4d6d82cc47b9a9c910801e9963d738d3400d92b1a5677ad0ea44b2c26d407cb4486ea3aeef550400c1f83b816d3e65bf4564bcc3a5936e5892b3e5834d22bc9c457883547b5f609593529e1e3abcb3534e009916ac549965620383625f81f3ef4a599fe59ae6aabae552a2c397934eae4ababe3da0e0b627601c49e2dbafbbf74e1bab8136cdd9fbf93f7aaa0bfb87c147a292e5a0aaff259af5d67e175697e7443f9f9edd5b40bed3abb002ebf30c854298b172671530ffe7f2875805af68ec466eb4bb",
                FileName = "a423cd0fdc94422caa0293cfab846a01c77ef5c2bc504ff398eea2139a6327e3b1af77a774a64c99b19139452972ee4df84062489c164286b52d5c7da578e1738aa542f482ad432184151f9e89eaac4cf96e2eb21d49439bbabd5eb79dac835a9de552ea256447239b2540ab17b05a5c1397fbd77d7d423daf46a1c94c2380cf9da924fb63f34da594b298db128099ead02f4a971b784f0f911ae361b2084a81a1bb8b412a85406eaa7685abffeee79454de4c37ca9648b4aea667a398df8e03a3bf68a9ef90486485c13903565df201a254ce91c22d40cfba110f28e4ed61230d74f14f958f4ad5b97ad785e24a4d05cc5c112b63114c1ca748",
                FileTitle = "67fa48c8f7f64b31ad7f61cfee1391f3e5c0116cf946406d9e08bb5b0c57527a4a07834c4b31482693c707d5e45c5ec4caec85a7973c41e6bafaab0acc4940ba91f9690ac1544325869017b61f2312498f36f9c5e46c43929ab56c82f227b59145f0a393",
                SystemUserRoleKeys = "162438e54c194939a7d2f25388e782fc79994f808fd34cb585",
                ParentCode = "3feeacde6d3c44e88e34031dc91aab0ef2b0020b73374ddea2",
                ExtendedInformation = "035536bff56c4963ae117a2f7d6e3cbdddabaff06d724764becb19dee9257427544eb59b1cf04b75b0904510d173fb369ec897a0c44d4d8f92068c490384fbeec9f68e8b2dad4615bfcee5836503fbab6e2444a32c6b4f3e9bc05dfdef2437055b7ade5984d44f1eb08e699a2d1954be7e0c7af910ce4920b0046b1d73042ef9882320f6d7444c65baf831673055e673f1e3dbb6fadc47e7b5f22e23b824179f9bd7e798b3f141fc9bdc69ce4d33c8167f9c0eb8a5064c0da11e885c5c53509cbc4698a4b760485c8f60b65384a9a3d26969d6c2058e4ea587f7bf80442f37ce9de38b4522cc43c997ab04bcf9c6b4eb4dc6b07fa31546779943",
                DateA = new DateTime(2016, 1, 8),
                DateD = new DateTime(2006, 4, 22),
                Sort = 2027818015,
                Note = "a24436445103452c8465efe3dcc9869aed8f562f2a4b471e8fe49a64a9f65b6941871a1708424f1e8f1f4b8716de8f79e9774984985d4aaf9694cb789acef3b4e4537f31ffc94ba1a8dd4e8989cb7b9fa6a29e70658e44ce9ced339aa8de06d5acf3faf8feb94772b2fa21e686a5a9cf77e4d41ea6624abd81c5f011b68c46c268aacae1517449e58a7bc269e82c44076df7317b50e9405a979c5c9893fe82bf5da09af0818846e08b4abc3f5ea74562124f2e5428c748858957169de1f4961d8a4714a5ac184caeb5661efd3db104fb798450fdd6e745ed9a6cde1c6c15faa209dfabef3d0f45e99656d13d01a2f06f406fadb39fb243919b96",
                Status = "d0b965f773b845c4bd8bf53411db4cf21ec2e1c7f6354ee5a6"
            };

            // Act
            var serviceResult = await _systemPagesAppService.CreateAsync(input);

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TypeCode.ShouldBe("ea25377d34b44c62b04318247e34941bdeb705bee2cd460fbc");
            result.FilePath.ShouldBe("c3074d767cce44599ef4c2c058e7d804374ae7239062499eab6f35f9ab3b7047335990d5094244db8f1ad65ef40aad45756b70fec28f4d6d82cc47b9a9c910801e9963d738d3400d92b1a5677ad0ea44b2c26d407cb4486ea3aeef550400c1f83b816d3e65bf4564bcc3a5936e5892b3e5834d22bc9c457883547b5f609593529e1e3abcb3534e009916ac549965620383625f81f3ef4a599fe59ae6aabae552a2c397934eae4ababe3da0e0b627601c49e2dbafbbf74e1bab8136cdd9fbf93f7aaa0bfb87c147a292e5a0aaff259af5d67e175697e7443f9f9edd5b40bed3abb002ebf30c854298b172671530ffe7f2875805af68ec466eb4bb");
            result.FileName.ShouldBe("a423cd0fdc94422caa0293cfab846a01c77ef5c2bc504ff398eea2139a6327e3b1af77a774a64c99b19139452972ee4df84062489c164286b52d5c7da578e1738aa542f482ad432184151f9e89eaac4cf96e2eb21d49439bbabd5eb79dac835a9de552ea256447239b2540ab17b05a5c1397fbd77d7d423daf46a1c94c2380cf9da924fb63f34da594b298db128099ead02f4a971b784f0f911ae361b2084a81a1bb8b412a85406eaa7685abffeee79454de4c37ca9648b4aea667a398df8e03a3bf68a9ef90486485c13903565df201a254ce91c22d40cfba110f28e4ed61230d74f14f958f4ad5b97ad785e24a4d05cc5c112b63114c1ca748");
            result.FileTitle.ShouldBe("67fa48c8f7f64b31ad7f61cfee1391f3e5c0116cf946406d9e08bb5b0c57527a4a07834c4b31482693c707d5e45c5ec4caec85a7973c41e6bafaab0acc4940ba91f9690ac1544325869017b61f2312498f36f9c5e46c43929ab56c82f227b59145f0a393");
            result.SystemUserRoleKeys.ShouldBe("162438e54c194939a7d2f25388e782fc79994f808fd34cb585");
            result.ParentCode.ShouldBe("3feeacde6d3c44e88e34031dc91aab0ef2b0020b73374ddea2");
            result.ExtendedInformation.ShouldBe("035536bff56c4963ae117a2f7d6e3cbdddabaff06d724764becb19dee9257427544eb59b1cf04b75b0904510d173fb369ec897a0c44d4d8f92068c490384fbeec9f68e8b2dad4615bfcee5836503fbab6e2444a32c6b4f3e9bc05dfdef2437055b7ade5984d44f1eb08e699a2d1954be7e0c7af910ce4920b0046b1d73042ef9882320f6d7444c65baf831673055e673f1e3dbb6fadc47e7b5f22e23b824179f9bd7e798b3f141fc9bdc69ce4d33c8167f9c0eb8a5064c0da11e885c5c53509cbc4698a4b760485c8f60b65384a9a3d26969d6c2058e4ea587f7bf80442f37ce9de38b4522cc43c997ab04bcf9c6b4eb4dc6b07fa31546779943");
            result.DateA.ShouldBe(new DateTime(2016, 1, 8));
            result.DateD.ShouldBe(new DateTime(2006, 4, 22));
            result.Sort.ShouldBe(2027818015);
            result.Note.ShouldBe("a24436445103452c8465efe3dcc9869aed8f562f2a4b471e8fe49a64a9f65b6941871a1708424f1e8f1f4b8716de8f79e9774984985d4aaf9694cb789acef3b4e4537f31ffc94ba1a8dd4e8989cb7b9fa6a29e70658e44ce9ced339aa8de06d5acf3faf8feb94772b2fa21e686a5a9cf77e4d41ea6624abd81c5f011b68c46c268aacae1517449e58a7bc269e82c44076df7317b50e9405a979c5c9893fe82bf5da09af0818846e08b4abc3f5ea74562124f2e5428c748858957169de1f4961d8a4714a5ac184caeb5661efd3db104fb798450fdd6e745ed9a6cde1c6c15faa209dfabef3d0f45e99656d13d01a2f06f406fadb39fb243919b96");
            result.Status.ShouldBe("d0b965f773b845c4bd8bf53411db4cf21ec2e1c7f6354ee5a6");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemPageUpdateDto()
            {
                TypeCode = "3d1667a45cbb4842ad8279e5a73fb8f0fbeaf7d3b3cc45e596",
                FilePath = "d3ebdbc238d94acbba7f6694c385adb97593a2b7af794a5caf01d8099d1a435f09e78df27fdb45989625b9178daefd086a3c2e71b13240959b1e1a71bb2a71572382ab5ded564a63b28f7c5f223342c4ed02b99418d443ae881d3f48cac4b8e9f415aa71d91f41bb96f3130f31f97f59947e84da64c343edbac7a5463763831cbbf2916067ea4f5387561a19b3ed0ad0f03f22b23c284c9eb1eea1a35dae163ab45c7835a2b64225bad24a7179913dc72118fe493eae4500a0b2d50db6085a143cb9eaf206934f2c957e3de25e74494ef2784ed43818425a9b1be377ca5fb032a53aca3720fa438cb92c23716041bbf04bff0d3f37be4419854a",
                FileName = "35c7f081bba24f96a31bc6db2c607d106bdcfcf0736b46c98cd8d44197b607fcfd22357e25d34341b7b44fab301df33c78b7d68f24524cf281a4ab063d8adc366298bca0b80040acb6eb21a90a60e708aefd3cd35bc248c99ce3a21c93df4388d0fcff8a8ae74428b9bcd09178f13af9da227ea87f6d418a8dad4390ea0965de32179d4b03134c84b19b73a960b2cb1c6648b0ad393b47d99f990554da6b3d86f5e3cf3571d146508ce57498d6ece3659f88adb1c5cc44b986570d55df80fd8924d6754685804589ad440a4e4b3f129d9c5042b5b3314f2a848b8482a03047e3476c83e009d6475d8d01916a6aa89c8d2461e2937e7344638304",
                FileTitle = "62964558e96a4c04aa33c271d375f0f09548670530064ee28f33af91230ceaceef8a40687adc4faeb4014ad74a3ca0e32795095d13fb441aac42f901b80560e6a25433eabb4240a2b5db5e4248a7ed9501bf32cf3f7a4007b4113359111839fed7e6a607",
                SystemUserRoleKeys = "e45a9aa425a64be0b2a13b9ff197573f68f744c118f84e90a2",
                ParentCode = "28c3a9407f284308ae762c25f6c2bb5108e9571d43be441cbb",
                ExtendedInformation = "965fd8d279a7452bbb261bc6aa3e671c174108a19a9045598f1cc943fce6e914cb8c9cf6c8574c08a6ba633e8ff2d9d925433d3deaa141379b3d7bd144fd9e6119971b6eab6f4e51872cc918ba5ce89f71eaca36347f4d468c14b38ae12c4961387b9fef99c544e798185a81418f18c159706c91e17c47cc8a2bf29d3f877babd26ceabd327e41368363c8b29b1fc7271e4082a649b944c79b44ee9a9a8c48d9ed0c653305084218b5b9cf2bb369f3a7d174ef248e694533bb694edbfd01dd5268e37ec945cd4395a4922b85efbdc24f0e792e8e5e2b4549a22d95b6ae7925be1b2e020992f44839bdc537a45ebabd56ca74f7a485894644a450",
                DateA = new DateTime(2010, 2, 19),
                DateD = new DateTime(2022, 7, 2),
                Sort = 1776526025,
                Note = "706266bafd8446c58a0f412e23642ded9f019656dbd945a7bcf5b61f3db0cdada521dc3fcac14f10a754fa2635832be564d96a0f3de74054ba4e84cd90ed9da41f4e4d719ac74773a377428f831b64419f0bcd134e7642fc9deeb1236ad3b90a184697e47453480bbf14745245d543b7e8ac8e1ea44e48e8bbf53eb758b705ec83c10dfc0bc44642b6f386b5308ff95b270cc581407e44f59255ec5f21b9c60b6726d40416964f2085447c93f7740dea24f9072c738f41e68a1c071a21648aff7dbe8d01f3ab4d819b52e7aab6e540e143a2693df6524cbfab6ed702924659fa6af424eb3351480aa600a39b44f9aee1c17981d2a4c34fc8aa80",
                Status = "c4f0380d90ce405fb16e4310c97de4211b10412e3e1c464a8b"
            };

            // Act
            var serviceResult = await _systemPagesAppService.UpdateAsync(Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"), input);

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TypeCode.ShouldBe("3d1667a45cbb4842ad8279e5a73fb8f0fbeaf7d3b3cc45e596");
            result.FilePath.ShouldBe("d3ebdbc238d94acbba7f6694c385adb97593a2b7af794a5caf01d8099d1a435f09e78df27fdb45989625b9178daefd086a3c2e71b13240959b1e1a71bb2a71572382ab5ded564a63b28f7c5f223342c4ed02b99418d443ae881d3f48cac4b8e9f415aa71d91f41bb96f3130f31f97f59947e84da64c343edbac7a5463763831cbbf2916067ea4f5387561a19b3ed0ad0f03f22b23c284c9eb1eea1a35dae163ab45c7835a2b64225bad24a7179913dc72118fe493eae4500a0b2d50db6085a143cb9eaf206934f2c957e3de25e74494ef2784ed43818425a9b1be377ca5fb032a53aca3720fa438cb92c23716041bbf04bff0d3f37be4419854a");
            result.FileName.ShouldBe("35c7f081bba24f96a31bc6db2c607d106bdcfcf0736b46c98cd8d44197b607fcfd22357e25d34341b7b44fab301df33c78b7d68f24524cf281a4ab063d8adc366298bca0b80040acb6eb21a90a60e708aefd3cd35bc248c99ce3a21c93df4388d0fcff8a8ae74428b9bcd09178f13af9da227ea87f6d418a8dad4390ea0965de32179d4b03134c84b19b73a960b2cb1c6648b0ad393b47d99f990554da6b3d86f5e3cf3571d146508ce57498d6ece3659f88adb1c5cc44b986570d55df80fd8924d6754685804589ad440a4e4b3f129d9c5042b5b3314f2a848b8482a03047e3476c83e009d6475d8d01916a6aa89c8d2461e2937e7344638304");
            result.FileTitle.ShouldBe("62964558e96a4c04aa33c271d375f0f09548670530064ee28f33af91230ceaceef8a40687adc4faeb4014ad74a3ca0e32795095d13fb441aac42f901b80560e6a25433eabb4240a2b5db5e4248a7ed9501bf32cf3f7a4007b4113359111839fed7e6a607");
            result.SystemUserRoleKeys.ShouldBe("e45a9aa425a64be0b2a13b9ff197573f68f744c118f84e90a2");
            result.ParentCode.ShouldBe("28c3a9407f284308ae762c25f6c2bb5108e9571d43be441cbb");
            result.ExtendedInformation.ShouldBe("965fd8d279a7452bbb261bc6aa3e671c174108a19a9045598f1cc943fce6e914cb8c9cf6c8574c08a6ba633e8ff2d9d925433d3deaa141379b3d7bd144fd9e6119971b6eab6f4e51872cc918ba5ce89f71eaca36347f4d468c14b38ae12c4961387b9fef99c544e798185a81418f18c159706c91e17c47cc8a2bf29d3f877babd26ceabd327e41368363c8b29b1fc7271e4082a649b944c79b44ee9a9a8c48d9ed0c653305084218b5b9cf2bb369f3a7d174ef248e694533bb694edbfd01dd5268e37ec945cd4395a4922b85efbdc24f0e792e8e5e2b4549a22d95b6ae7925be1b2e020992f44839bdc537a45ebabd56ca74f7a485894644a450");
            result.DateA.ShouldBe(new DateTime(2010, 2, 19));
            result.DateD.ShouldBe(new DateTime(2022, 7, 2));
            result.Sort.ShouldBe(1776526025);
            result.Note.ShouldBe("706266bafd8446c58a0f412e23642ded9f019656dbd945a7bcf5b61f3db0cdada521dc3fcac14f10a754fa2635832be564d96a0f3de74054ba4e84cd90ed9da41f4e4d719ac74773a377428f831b64419f0bcd134e7642fc9deeb1236ad3b90a184697e47453480bbf14745245d543b7e8ac8e1ea44e48e8bbf53eb758b705ec83c10dfc0bc44642b6f386b5308ff95b270cc581407e44f59255ec5f21b9c60b6726d40416964f2085447c93f7740dea24f9072c738f41e68a1c071a21648aff7dbe8d01f3ab4d819b52e7aab6e540e143a2693df6524cbfab6ed702924659fa6af424eb3351480aa600a39b44f9aee1c17981d2a4c34fc8aa80");
            result.Status.ShouldBe("c4f0380d90ce405fb16e4310c97de4211b10412e3e1c464a8b");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemPagesAppService.DeleteAsync(Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"));

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"));

            result.ShouldBeNull();
        }
    }
}