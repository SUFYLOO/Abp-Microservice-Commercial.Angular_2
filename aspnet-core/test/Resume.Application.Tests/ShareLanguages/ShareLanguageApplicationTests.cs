using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareLanguages
{
    public class ShareLanguagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareLanguagesAppService _shareLanguagesAppService;
        private readonly IRepository<ShareLanguage, Guid> _shareLanguageRepository;

        public ShareLanguagesAppServiceTests()
        {
            _shareLanguagesAppService = GetRequiredService<IShareLanguagesAppService>();
            _shareLanguageRepository = GetRequiredService<IRepository<ShareLanguage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareLanguagesAppService.GetListAsync(new GetShareLanguagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("1a6592c6-5afa-4cf6-9f08-d95641ba4765")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareLanguagesAppService.GetAsync(Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareLanguageCreateDto
            {
                Name = "6582574b9d984e079a5afec162c4c83c653c8fa522d9469996",
                ExtendedInformation = "87922c2250b14826a9bb0544110b23ca2be93f0ccddc4a178191a12fb0f0613cce2160201370428a80f0a13407d68dbe29d361ce194f4d048cfe5e0848b4e17c52a393e0604942c8adc373822fc5e071f9f5350dd9c5471cbf19c329db4bec3516b3e486d83644fab7a07e69f7a3c3120eae6846b1bb4b03aae01defb32b46b34a26046ee9994b50b862b072da34950ce8a679afe8954cdbb13daa46c37a457dd76ab840c784411693c59d34b668ee96e36b37109ba64aa699e46901795d3f056166e46b24d34e48bb7dadf23d6dd865e9ac7bc099f1486b9116a15e9d42a8549dfc2e3ea66741d99e6fc6694073a109d0af91aa65624dddaec4",
                DateA = new DateTime(2006, 7, 23),
                DateD = new DateTime(2005, 5, 10),
                Sort = 846128233,
                Note = "ae9af255116c4edc84d532cc96be8481fa87d70c325e4e1ba5922137bdd6673b987313c1524949a994c7d68d975e5225ac601739aef34f50be6b38fda821e31d9d45cb31ce654770b93ae8046face025bc85f1d69f7e4b8e9cc2fb3497772eca5d94a90debbc4bd7ac1a805a995ded3ae4923448c16c49ebbacde233750745c857beb0f4d4f841ac9a7baac2713c2c7b3e55a9b0e8d54ac391786603555c06b38474f5ece2c442be97defc89d2a5bf969509def6ce7848f8ac078e9f62cef5bf3be92271af7e4865970845a90e9475522963d1524d0e4ed88f2beea508f54aa1de0cc0f36bff4b40aa540d5ff2ff3551df195dd007e042758270",
                Status = "4ff3816cc3d54fa686340dc86b404610f1ce512f650a4ef9ac"
            };

            // Act
            var serviceResult = await _shareLanguagesAppService.CreateAsync(input);

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("6582574b9d984e079a5afec162c4c83c653c8fa522d9469996");
            result.ExtendedInformation.ShouldBe("87922c2250b14826a9bb0544110b23ca2be93f0ccddc4a178191a12fb0f0613cce2160201370428a80f0a13407d68dbe29d361ce194f4d048cfe5e0848b4e17c52a393e0604942c8adc373822fc5e071f9f5350dd9c5471cbf19c329db4bec3516b3e486d83644fab7a07e69f7a3c3120eae6846b1bb4b03aae01defb32b46b34a26046ee9994b50b862b072da34950ce8a679afe8954cdbb13daa46c37a457dd76ab840c784411693c59d34b668ee96e36b37109ba64aa699e46901795d3f056166e46b24d34e48bb7dadf23d6dd865e9ac7bc099f1486b9116a15e9d42a8549dfc2e3ea66741d99e6fc6694073a109d0af91aa65624dddaec4");
            result.DateA.ShouldBe(new DateTime(2006, 7, 23));
            result.DateD.ShouldBe(new DateTime(2005, 5, 10));
            result.Sort.ShouldBe(846128233);
            result.Note.ShouldBe("ae9af255116c4edc84d532cc96be8481fa87d70c325e4e1ba5922137bdd6673b987313c1524949a994c7d68d975e5225ac601739aef34f50be6b38fda821e31d9d45cb31ce654770b93ae8046face025bc85f1d69f7e4b8e9cc2fb3497772eca5d94a90debbc4bd7ac1a805a995ded3ae4923448c16c49ebbacde233750745c857beb0f4d4f841ac9a7baac2713c2c7b3e55a9b0e8d54ac391786603555c06b38474f5ece2c442be97defc89d2a5bf969509def6ce7848f8ac078e9f62cef5bf3be92271af7e4865970845a90e9475522963d1524d0e4ed88f2beea508f54aa1de0cc0f36bff4b40aa540d5ff2ff3551df195dd007e042758270");
            result.Status.ShouldBe("4ff3816cc3d54fa686340dc86b404610f1ce512f650a4ef9ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareLanguageUpdateDto()
            {
                Name = "c86c0108dfd64128a0da4e7a10765a322e4a3ec6c387477d91",
                ExtendedInformation = "4dafe6d3dc8d4d408e7f4ca5205341e60c9257733a3c422ea9ae4e785f36dcf8f7550c6c2e3a47529164150eb5136e8672b517449edb49c89c397723caa14eea5c7e710d004e4b9a8448f30613a197f8dfdc640dc8af4a97b2ebf20b222cf282b92a8eb9ca074eb08d74a7daac0f9adc6295c2a8f04441c7bebc087228d9510cf758d59cb6ec4f6eb263440923b6b7fb5dc11987904e441ba4210360709b3c9ab4888ccede74454aae09d1be24a0e59f348912b35f884734a559778e24ce904c9d5b08db349c41198ed864f34912076cc290c360b0d4491b99d4d6a6a93c92bf2b04e851d20640fcb7a225dd0f67b2d8761ff16d3da14e08b22a",
                DateA = new DateTime(2002, 6, 23),
                DateD = new DateTime(2018, 5, 27),
                Sort = 929436146,
                Note = "1e9bb3c1687e4caea817dc360dc90e0b0500de2f18654ceb82c84f0536f5d2324b50411feffc4cb184d7ef8ddb44f97b92caae4ba35946d68ee8b798b4d04a05b216dd0fbfe24b8191d9b90f6a9c01e23d6c277ee2864a248f9da4e746656918ff5b5b5b7f0e4dca96771927fdf51d4a3783de183a7b4e8fb42f45cefde9315c4251cad2da3d4c6c81045a37448511053c2180d30a224b0d9c986a11f4015283f22f00a631af49de875526d97037ab337cf0f3dda7f44ad2ab7193497225d30f9aeeaa8009de418286ee5d950ea97d03adbf54ab3f464b84b2803a2ffc4aff918c9bc644fd074f249a05b7161d044c88372217cd35b54645be9c",
                Status = "96840eaa30c146e3bcb341c146baf7882da8dee3c9204c7ea5"
            };

            // Act
            var serviceResult = await _shareLanguagesAppService.UpdateAsync(Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"), input);

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("c86c0108dfd64128a0da4e7a10765a322e4a3ec6c387477d91");
            result.ExtendedInformation.ShouldBe("4dafe6d3dc8d4d408e7f4ca5205341e60c9257733a3c422ea9ae4e785f36dcf8f7550c6c2e3a47529164150eb5136e8672b517449edb49c89c397723caa14eea5c7e710d004e4b9a8448f30613a197f8dfdc640dc8af4a97b2ebf20b222cf282b92a8eb9ca074eb08d74a7daac0f9adc6295c2a8f04441c7bebc087228d9510cf758d59cb6ec4f6eb263440923b6b7fb5dc11987904e441ba4210360709b3c9ab4888ccede74454aae09d1be24a0e59f348912b35f884734a559778e24ce904c9d5b08db349c41198ed864f34912076cc290c360b0d4491b99d4d6a6a93c92bf2b04e851d20640fcb7a225dd0f67b2d8761ff16d3da14e08b22a");
            result.DateA.ShouldBe(new DateTime(2002, 6, 23));
            result.DateD.ShouldBe(new DateTime(2018, 5, 27));
            result.Sort.ShouldBe(929436146);
            result.Note.ShouldBe("1e9bb3c1687e4caea817dc360dc90e0b0500de2f18654ceb82c84f0536f5d2324b50411feffc4cb184d7ef8ddb44f97b92caae4ba35946d68ee8b798b4d04a05b216dd0fbfe24b8191d9b90f6a9c01e23d6c277ee2864a248f9da4e746656918ff5b5b5b7f0e4dca96771927fdf51d4a3783de183a7b4e8fb42f45cefde9315c4251cad2da3d4c6c81045a37448511053c2180d30a224b0d9c986a11f4015283f22f00a631af49de875526d97037ab337cf0f3dda7f44ad2ab7193497225d30f9aeeaa8009de418286ee5d950ea97d03adbf54ab3f464b84b2803a2ffc4aff918c9bc644fd074f249a05b7161d044c88372217cd35b54645be9c");
            result.Status.ShouldBe("96840eaa30c146e3bcb341c146baf7882da8dee3c9204c7ea5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareLanguagesAppService.DeleteAsync(Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"));

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"));

            result.ShouldBeNull();
        }
    }
}