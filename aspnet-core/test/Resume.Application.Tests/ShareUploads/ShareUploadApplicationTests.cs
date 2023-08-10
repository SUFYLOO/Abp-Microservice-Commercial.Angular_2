using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareUploads
{
    public class ShareUploadsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareUploadsAppService _shareUploadsAppService;
        private readonly IRepository<ShareUpload, Guid> _shareUploadRepository;

        public ShareUploadsAppServiceTests()
        {
            _shareUploadsAppService = GetRequiredService<IShareUploadsAppService>();
            _shareUploadRepository = GetRequiredService<IRepository<ShareUpload, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareUploadsAppService.GetListAsync(new GetShareUploadsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2d0364e3-5e0c-4860-bed1-673c231be894")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareUploadsAppService.GetAsync(Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareUploadCreateDto
            {
                Key1 = "0c42d7026d114b9588fb32bdd2d1b1868396e4ef9d25477080",
                Key2 = "d09b5dbaee494d2a8b42748e2cee0d3627cc4b35e2f14e339d",
                Key3 = "c6b75de327694e99891d08d951075788bea2b205e3eb413095",
                UploadName = "051e05e919d944178fc2cb6b64e1ea7f7d17bd3092c649be9667336388d7077a27de74ccb00449a0a826e7665b35ff9826090f8d325c4257b2dfe87905a0e2292d16e148a24e45619b16d902414b97a98867b1b02f134e6badd76bfea7d6eb143c27f16b",
                ServerName = "6a0771a71fb04cce9ee8aa479e74555dc0221035ec8a40aba315b5da2e77cc2421590b8c845b48a89a459914d63ebe7999f4b86b45334f5ca5b5653353f63b1f7fff86c29bb241a0b99f8e46ff30e5e3685b3b553d9a4230b708fd7b1c1fcba620595fb0",
                Type = "557343abe49a49939f0647d5b510c16e7005785c82ac4be1b792d36af7687fd0ab3b55cff849415e8077169497f246857b6ce615d31d4ea7af412b2d15d54e2ed95045750459461b98ed77b9a1b1b5790061f1be8dd144898dbc2844b7ca8a5ee6060e99",
                Size = 722684193,
                SystemUse = true,
                ExtendedInformation = "541123fe7e394a248a1084a1766e01d69f32dd1e839842f99a4f9ba5bcc3b5e315852c79679946149a50008c8c99d88f8f61fd4894f6462787f0d1e3188e900e38c7434a72f24eed87d4b35441e5d2f2c3741330945040749931bb8d52c31a072dd9374a73f348ff846555713dae78301c5c42e567c04e3eac28660e04d391cef086b55eda7347dea63a935d1155737ec5f1dc6389854c72a3990dbcabbd6b80c7ec11f9de914b208a6f2db551df5444d4284088a00a442dbc19d7e64a4ced042a1555f327574fab8a7356522ccd8b4d80c6cfdbe44c4e209a7b8cf546a3a4ac6c0fe1c57f4a4a5c84d48512f85bfa09e04fa001c3fe41c39631",
                DateA = new DateTime(2010, 11, 16),
                DateD = new DateTime(2008, 2, 5),
                Sort = 1393437374,
                Note = "dea0d317b729463db803cc9fcaf4b512e699b0ee10c54ce492abc7d0e0aa559d999048c4b33041b083a443ab83f0fcf8585d2baa1a844e469c112ce5019b045e99a0a6a103ba4680a4de17e20661358b1a20c0618b4b4620a4a9959ef31dd065ac8a4d83604e4b2eb3e1ab886564b087db57e96b2b384eeda86903e3d9cd1c7f4b48966f013048048c211c50ef9a73f3a982421478444cf4a5564955659a7513987bd41c4188471a898c6fd31f5f30585ddfb2f311164a36a7d06ca2317091d057cb7d2cb9f64390825b9d2387b041640573545f6605486bbf024606344dd6996fcf2896299c4e3caceacf35d54160de1928385547db4c1bb26b",
                Status = "b268ce974a464f9b8b77667a2825980705e656d776f14d7085"
            };

            // Act
            var serviceResult = await _shareUploadsAppService.CreateAsync(input);

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("0c42d7026d114b9588fb32bdd2d1b1868396e4ef9d25477080");
            result.Key2.ShouldBe("d09b5dbaee494d2a8b42748e2cee0d3627cc4b35e2f14e339d");
            result.Key3.ShouldBe("c6b75de327694e99891d08d951075788bea2b205e3eb413095");
            result.UploadName.ShouldBe("051e05e919d944178fc2cb6b64e1ea7f7d17bd3092c649be9667336388d7077a27de74ccb00449a0a826e7665b35ff9826090f8d325c4257b2dfe87905a0e2292d16e148a24e45619b16d902414b97a98867b1b02f134e6badd76bfea7d6eb143c27f16b");
            result.ServerName.ShouldBe("6a0771a71fb04cce9ee8aa479e74555dc0221035ec8a40aba315b5da2e77cc2421590b8c845b48a89a459914d63ebe7999f4b86b45334f5ca5b5653353f63b1f7fff86c29bb241a0b99f8e46ff30e5e3685b3b553d9a4230b708fd7b1c1fcba620595fb0");
            result.Type.ShouldBe("557343abe49a49939f0647d5b510c16e7005785c82ac4be1b792d36af7687fd0ab3b55cff849415e8077169497f246857b6ce615d31d4ea7af412b2d15d54e2ed95045750459461b98ed77b9a1b1b5790061f1be8dd144898dbc2844b7ca8a5ee6060e99");
            result.Size.ShouldBe(722684193);
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("541123fe7e394a248a1084a1766e01d69f32dd1e839842f99a4f9ba5bcc3b5e315852c79679946149a50008c8c99d88f8f61fd4894f6462787f0d1e3188e900e38c7434a72f24eed87d4b35441e5d2f2c3741330945040749931bb8d52c31a072dd9374a73f348ff846555713dae78301c5c42e567c04e3eac28660e04d391cef086b55eda7347dea63a935d1155737ec5f1dc6389854c72a3990dbcabbd6b80c7ec11f9de914b208a6f2db551df5444d4284088a00a442dbc19d7e64a4ced042a1555f327574fab8a7356522ccd8b4d80c6cfdbe44c4e209a7b8cf546a3a4ac6c0fe1c57f4a4a5c84d48512f85bfa09e04fa001c3fe41c39631");
            result.DateA.ShouldBe(new DateTime(2010, 11, 16));
            result.DateD.ShouldBe(new DateTime(2008, 2, 5));
            result.Sort.ShouldBe(1393437374);
            result.Note.ShouldBe("dea0d317b729463db803cc9fcaf4b512e699b0ee10c54ce492abc7d0e0aa559d999048c4b33041b083a443ab83f0fcf8585d2baa1a844e469c112ce5019b045e99a0a6a103ba4680a4de17e20661358b1a20c0618b4b4620a4a9959ef31dd065ac8a4d83604e4b2eb3e1ab886564b087db57e96b2b384eeda86903e3d9cd1c7f4b48966f013048048c211c50ef9a73f3a982421478444cf4a5564955659a7513987bd41c4188471a898c6fd31f5f30585ddfb2f311164a36a7d06ca2317091d057cb7d2cb9f64390825b9d2387b041640573545f6605486bbf024606344dd6996fcf2896299c4e3caceacf35d54160de1928385547db4c1bb26b");
            result.Status.ShouldBe("b268ce974a464f9b8b77667a2825980705e656d776f14d7085");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareUploadUpdateDto()
            {
                Key1 = "61c6ba3d5cd340e68fd99e1ef148a726b2b6195940e34a3587",
                Key2 = "1c5b4d7139d643418e4f3aaa37c178ce013f02886fa74901a8",
                Key3 = "a08e93a83a5e4529b183e6da46c52ce53c1401621520445d9d",
                UploadName = "ad307dd76c044250805638903ea152ca47e39daf5246415d82893bc63c54e8d38959928fc37b44a3aacb5e9f8cc954080b310ab4c9a54df9b6e8d9fc381a87da82d8f21680794d61a3327e65e48e56bdb5741f37089243c5892290476fea9f81011ef424",
                ServerName = "ebb5fe76a6434c73a1fdda6daae6fcbf89f8045329444aadb45e520856c391357aedeac0aa434a6886973ff184d9651e059f4f63ec1f4f6f82bdfadd73fa94c209d40069f2374051adba3e7706a11d511f33cbef349b44be857cd2d4c325965817faaca9",
                Type = "897a4960f9b147408a3d5c9c979a2330feaa3880c20748d6a446710b78015b30ad37aee93dec45aa9d2c532b49c2addbdd0db79b721d48679fb55256caeff76e11b5d4ed25b0403c81395d089a4d5e5f3ce854f5bba944b19e886b86c597d36e108deb64",
                Size = 2043728844,
                SystemUse = true,
                ExtendedInformation = "cc98b2d99775453f8ca564f020a3c05c0644c315064049a0af110908a0c0a39d1082df67e6c0438292ea66b146444b67e9a8c20710834d3a9fc3af94d93644b78316263943844f1fad9f9bf7661d851051a9a2bf98cb436c86c121ff298575e9c45abc03f0da43519a982e846885f4b62c5d0c74b8b14dbbb7b2c74dc236f6b179a5874900334f25871ac2dceefbcdd3e0d9885f13574a759ca8b34fbbe462f1c0ec128aa60d42ea89952450215deb006a557679a2454da9a23df4dcd098494aa850972c85a6457a88d6112e2817eb6f8463e3ac0a374bcfae0174e70a967e329f26a9f9f51449389c0bcb1f40877e77a7df1901f16e459cab53",
                DateA = new DateTime(2008, 4, 2),
                DateD = new DateTime(2016, 10, 12),
                Sort = 40186296,
                Note = "b0ef81edac634d53bc5c947522621a190c9694c06ea340aaa70aea30ae812885d30d905b9427450c89b30fb8125f706d08ceeeea1c924aecb86c812cc0a2b7c4cb2d8703e0214052ae8095ff2fa81ce713fb4dfc10bb42a680d03cf1e18889df6e43d749f8824d29a3b3e2bfaf747ddaddefa1ecf6324352a7adf04628e14b499b69a9efd0834350a8183fb890f014ff7a3f234ef08849e3b299e613d38c4d39a3baa52feb724f59895d667b3ee01fb3411d51da6c7b420bad73a9e7d1d0e7ac75ad01f13b394fb0a568aabf02c9a02b6fefdcc19cfb440082232d99dd7b30db02338f14691048469d8a5f12d0b23bc66c7551dfe0ac452e8e07",
                Status = "c5beb4d4669544d5ba7c7c35cc1d7dcc98c0d1e90d8749fca5"
            };

            // Act
            var serviceResult = await _shareUploadsAppService.UpdateAsync(Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"), input);

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("61c6ba3d5cd340e68fd99e1ef148a726b2b6195940e34a3587");
            result.Key2.ShouldBe("1c5b4d7139d643418e4f3aaa37c178ce013f02886fa74901a8");
            result.Key3.ShouldBe("a08e93a83a5e4529b183e6da46c52ce53c1401621520445d9d");
            result.UploadName.ShouldBe("ad307dd76c044250805638903ea152ca47e39daf5246415d82893bc63c54e8d38959928fc37b44a3aacb5e9f8cc954080b310ab4c9a54df9b6e8d9fc381a87da82d8f21680794d61a3327e65e48e56bdb5741f37089243c5892290476fea9f81011ef424");
            result.ServerName.ShouldBe("ebb5fe76a6434c73a1fdda6daae6fcbf89f8045329444aadb45e520856c391357aedeac0aa434a6886973ff184d9651e059f4f63ec1f4f6f82bdfadd73fa94c209d40069f2374051adba3e7706a11d511f33cbef349b44be857cd2d4c325965817faaca9");
            result.Type.ShouldBe("897a4960f9b147408a3d5c9c979a2330feaa3880c20748d6a446710b78015b30ad37aee93dec45aa9d2c532b49c2addbdd0db79b721d48679fb55256caeff76e11b5d4ed25b0403c81395d089a4d5e5f3ce854f5bba944b19e886b86c597d36e108deb64");
            result.Size.ShouldBe(2043728844);
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("cc98b2d99775453f8ca564f020a3c05c0644c315064049a0af110908a0c0a39d1082df67e6c0438292ea66b146444b67e9a8c20710834d3a9fc3af94d93644b78316263943844f1fad9f9bf7661d851051a9a2bf98cb436c86c121ff298575e9c45abc03f0da43519a982e846885f4b62c5d0c74b8b14dbbb7b2c74dc236f6b179a5874900334f25871ac2dceefbcdd3e0d9885f13574a759ca8b34fbbe462f1c0ec128aa60d42ea89952450215deb006a557679a2454da9a23df4dcd098494aa850972c85a6457a88d6112e2817eb6f8463e3ac0a374bcfae0174e70a967e329f26a9f9f51449389c0bcb1f40877e77a7df1901f16e459cab53");
            result.DateA.ShouldBe(new DateTime(2008, 4, 2));
            result.DateD.ShouldBe(new DateTime(2016, 10, 12));
            result.Sort.ShouldBe(40186296);
            result.Note.ShouldBe("b0ef81edac634d53bc5c947522621a190c9694c06ea340aaa70aea30ae812885d30d905b9427450c89b30fb8125f706d08ceeeea1c924aecb86c812cc0a2b7c4cb2d8703e0214052ae8095ff2fa81ce713fb4dfc10bb42a680d03cf1e18889df6e43d749f8824d29a3b3e2bfaf747ddaddefa1ecf6324352a7adf04628e14b499b69a9efd0834350a8183fb890f014ff7a3f234ef08849e3b299e613d38c4d39a3baa52feb724f59895d667b3ee01fb3411d51da6c7b420bad73a9e7d1d0e7ac75ad01f13b394fb0a568aabf02c9a02b6fefdcc19cfb440082232d99dd7b30db02338f14691048469d8a5f12d0b23bc66c7551dfe0ac452e8e07");
            result.Status.ShouldBe("c5beb4d4669544d5ba7c7c35cc1d7dcc98c0d1e90d8749fca5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareUploadsAppService.DeleteAsync(Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"));

            // Assert
            var result = await _shareUploadRepository.FindAsync(c => c.Id == Guid.Parse("24540c6c-f223-4a31-b00e-9ab8c1f5d0a4"));

            result.ShouldBeNull();
        }
    }
}