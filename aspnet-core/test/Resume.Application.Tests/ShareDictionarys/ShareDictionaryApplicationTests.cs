using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareDictionarys
{
    public class ShareDictionarysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareDictionarysAppService _shareDictionarysAppService;
        private readonly IRepository<ShareDictionary, Guid> _shareDictionaryRepository;

        public ShareDictionarysAppServiceTests()
        {
            _shareDictionarysAppService = GetRequiredService<IShareDictionarysAppService>();
            _shareDictionaryRepository = GetRequiredService<IRepository<ShareDictionary, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareDictionarysAppService.GetListAsync(new GetShareDictionarysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("b23a586f-bbbb-4b7b-aee7-387628583946")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareDictionarysAppService.GetAsync(Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareDictionaryCreateDto
            {
                ShareLanguageId = Guid.Parse("5c858825-51ea-41d3-a751-ceecb77d6041"),
                ShareTagId = Guid.Parse("388709e4-03a4-4686-a71c-3418ed835919"),
                Key1 = "d792c202f2b64317bbdcc58f76be8e89eb39a819ef4a4545a7",
                Key2 = "fd7dbecc87c24212bc0ef4defb1ffe704610014371974309bb",
                Key3 = "e53a356f8c1345cca7283d717c0dad5d4ab2e45d077f4dad98",
                Name = "2963495e76224be0b5a0f4812a311c169279ded4c0b2428a93e80356faed07a3c9c0d1584e164c249d59cdca8289dac3fa10d3e691b849beaca5368a1b6859c4f274ca2a123941629395f8b775beeea582619047a11841ebbee9978f28938465cb4f96d5",
                ExtendedInformation = "006cb1e67c584f40b1457eb1d59922c86aeae4f02afa4a918fcf0eaa9af39aa11aa774c147fd400b882ccfbcbe09a129bbcfe985c59544d7912396cbc468a5f0b97f06b1a78d443eadd0bff92989a4c7c95ef0ccd01f492c884e623a7a45d327152b847befb24656b24ac6abe99421f68da7ea7c052d4d64b4a2bcb6e5813f23dd60ffbf04a84659b99eb6d58b56bff8a8abc50c90ce4096820e3ac05d370c8f90d75c2d594e4774b2e999108fc8b034ae2c1772cdc4437cb553b7fb2aeda1d3eb7f513d61ab4c289a181bcb7b965e7c67b10e3d690f4b4e90162ff741e254b0171d08f2b945428a8d5a3dc9e292f316263bd13a22a94883a891",
                DateA = new DateTime(2019, 9, 25),
                DateD = new DateTime(2001, 6, 22),
                Sort = 1752680118,
                Note = "02968190f4284857bbcd6f7fe8344b97c4b9931888794b6a8f15f33ed9b564b6811054d1233e47d68c5bfe232d16051369a6d8a72fca46dc9df5bb3a3e31698bd259f12439e2418d82a95ab798c114d3506cb546908c4ce29dd5808a4276ca5656f5d3126b0943e2bef60c387f9f1e384d1cf44f7cfb4c66a3e2689da8c9229fa9249060828c4fe6aabeaa018ae2ffb3e5d9e0afdb3f4c27a0f1db4dc678e8f051e5f877e83c45e9b8fc7e6f3bcebbd54831f81b76684397b29644fbcf18d9112695ef2c96854d9882573f50b4ff10e610ae47e56e5f44f386a89cbff7a1ce310638f5aebb94432ca3daa13cf0ef0a588a43a865f2264b3680c7",
                Status = "c37fd9f33f274b8c9a3ea013b869c02ace6d8a276fde4f0988"
            };

            // Act
            var serviceResult = await _shareDictionarysAppService.CreateAsync(input);

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ShareLanguageId.ShouldBe(Guid.Parse("5c858825-51ea-41d3-a751-ceecb77d6041"));
            result.ShareTagId.ShouldBe(Guid.Parse("388709e4-03a4-4686-a71c-3418ed835919"));
            result.Key1.ShouldBe("d792c202f2b64317bbdcc58f76be8e89eb39a819ef4a4545a7");
            result.Key2.ShouldBe("fd7dbecc87c24212bc0ef4defb1ffe704610014371974309bb");
            result.Key3.ShouldBe("e53a356f8c1345cca7283d717c0dad5d4ab2e45d077f4dad98");
            result.Name.ShouldBe("2963495e76224be0b5a0f4812a311c169279ded4c0b2428a93e80356faed07a3c9c0d1584e164c249d59cdca8289dac3fa10d3e691b849beaca5368a1b6859c4f274ca2a123941629395f8b775beeea582619047a11841ebbee9978f28938465cb4f96d5");
            result.ExtendedInformation.ShouldBe("006cb1e67c584f40b1457eb1d59922c86aeae4f02afa4a918fcf0eaa9af39aa11aa774c147fd400b882ccfbcbe09a129bbcfe985c59544d7912396cbc468a5f0b97f06b1a78d443eadd0bff92989a4c7c95ef0ccd01f492c884e623a7a45d327152b847befb24656b24ac6abe99421f68da7ea7c052d4d64b4a2bcb6e5813f23dd60ffbf04a84659b99eb6d58b56bff8a8abc50c90ce4096820e3ac05d370c8f90d75c2d594e4774b2e999108fc8b034ae2c1772cdc4437cb553b7fb2aeda1d3eb7f513d61ab4c289a181bcb7b965e7c67b10e3d690f4b4e90162ff741e254b0171d08f2b945428a8d5a3dc9e292f316263bd13a22a94883a891");
            result.DateA.ShouldBe(new DateTime(2019, 9, 25));
            result.DateD.ShouldBe(new DateTime(2001, 6, 22));
            result.Sort.ShouldBe(1752680118);
            result.Note.ShouldBe("02968190f4284857bbcd6f7fe8344b97c4b9931888794b6a8f15f33ed9b564b6811054d1233e47d68c5bfe232d16051369a6d8a72fca46dc9df5bb3a3e31698bd259f12439e2418d82a95ab798c114d3506cb546908c4ce29dd5808a4276ca5656f5d3126b0943e2bef60c387f9f1e384d1cf44f7cfb4c66a3e2689da8c9229fa9249060828c4fe6aabeaa018ae2ffb3e5d9e0afdb3f4c27a0f1db4dc678e8f051e5f877e83c45e9b8fc7e6f3bcebbd54831f81b76684397b29644fbcf18d9112695ef2c96854d9882573f50b4ff10e610ae47e56e5f44f386a89cbff7a1ce310638f5aebb94432ca3daa13cf0ef0a588a43a865f2264b3680c7");
            result.Status.ShouldBe("c37fd9f33f274b8c9a3ea013b869c02ace6d8a276fde4f0988");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareDictionaryUpdateDto()
            {
                ShareLanguageId = Guid.Parse("95ec5cb7-ff41-479c-b820-929d5c8ebbdc"),
                ShareTagId = Guid.Parse("5fe52015-8c6f-439b-a55e-70e9b483a7a1"),
                Key1 = "03a7f2fac7d84020b0636be301adc3c5afaf50c93005462196",
                Key2 = "4528c5f006bb4751b266c272da03a531b46ca52af1a2492a91",
                Key3 = "e8a56d172b3b4d5cab78c37e2312fefd5de509f8b3664f229e",
                Name = "d6e3b93db1b84876b04796e5f5d392d66588393a73f44e0f84d3e354bfa64b583147634fe1294675bd9420afc8388315f37d8be6016b4e4bbe6d5c05b145626653050a0463844cea9fbfd322f042d637a6291821f66b45bba3dd563c41b223b535bd482f",
                ExtendedInformation = "4caf3bca60884f10b2abf6a3190888afcf7a321f3eaf4e63987f56786b7552e120b2e5bda6084d2faa5903982de97d5bd81a05bed4d14c368f92c20f182245b1cede194f9c7549fd8af6bb34b5fcdd052f550f64c9cb4d9e9ad4576c865df5dce2513411cb6f4839a0e4ad17190dc63193baeab4883440f3a585478437ddce3a270c5a4ddf2b4cd083b85bc1e3178b600c0d124b06b64c65beffc15229d03e5c5e8aec5182104e28817eac4342a3b38e633faa2b110d4dbca828141c6e014432bdae4423942b4ad19a21b54e4cd3ed55bf2185f08d8c4650b050f37085664d2c3a86cd77613a4dc1985228a5176673ea74682f9e26c64737b2b6",
                DateA = new DateTime(2003, 5, 6),
                DateD = new DateTime(2020, 4, 8),
                Sort = 1870025451,
                Note = "a7875298035e4e948333ac83553c7a88021325c1133c4bd8ba380ebef786d7ed63a00b3daa2547efb59f6bc7b47ae698cc39c152bc274dc08e220f5e5f73aefb118c3c5de10e41ecb5b09fab9dd0cf3824062fed748b4c17a29b2a582a8c1adde5ae2eb13c04480282162e7856954ef318627096ecba47538b673d2376e8e7825b6a34f215944749b26106ead1c40a7f389c7320e1c54cb181058d643ecb8338202dd7d07cd3410985be63670793e54b08c7306fa55b4887a90ff2133bbcc56dfbc3cbde9f3f4292b785e443bd171c390f21a1c3b9934a0ab88b8677fe37ae6801f80ded07764148ae6c7edde1b35b888b91d24c320948478a4f",
                Status = "e924dcf9d6704aa488176d6e2774390ecb446390ec1d4013b4"
            };

            // Act
            var serviceResult = await _shareDictionarysAppService.UpdateAsync(Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"), input);

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ShareLanguageId.ShouldBe(Guid.Parse("95ec5cb7-ff41-479c-b820-929d5c8ebbdc"));
            result.ShareTagId.ShouldBe(Guid.Parse("5fe52015-8c6f-439b-a55e-70e9b483a7a1"));
            result.Key1.ShouldBe("03a7f2fac7d84020b0636be301adc3c5afaf50c93005462196");
            result.Key2.ShouldBe("4528c5f006bb4751b266c272da03a531b46ca52af1a2492a91");
            result.Key3.ShouldBe("e8a56d172b3b4d5cab78c37e2312fefd5de509f8b3664f229e");
            result.Name.ShouldBe("d6e3b93db1b84876b04796e5f5d392d66588393a73f44e0f84d3e354bfa64b583147634fe1294675bd9420afc8388315f37d8be6016b4e4bbe6d5c05b145626653050a0463844cea9fbfd322f042d637a6291821f66b45bba3dd563c41b223b535bd482f");
            result.ExtendedInformation.ShouldBe("4caf3bca60884f10b2abf6a3190888afcf7a321f3eaf4e63987f56786b7552e120b2e5bda6084d2faa5903982de97d5bd81a05bed4d14c368f92c20f182245b1cede194f9c7549fd8af6bb34b5fcdd052f550f64c9cb4d9e9ad4576c865df5dce2513411cb6f4839a0e4ad17190dc63193baeab4883440f3a585478437ddce3a270c5a4ddf2b4cd083b85bc1e3178b600c0d124b06b64c65beffc15229d03e5c5e8aec5182104e28817eac4342a3b38e633faa2b110d4dbca828141c6e014432bdae4423942b4ad19a21b54e4cd3ed55bf2185f08d8c4650b050f37085664d2c3a86cd77613a4dc1985228a5176673ea74682f9e26c64737b2b6");
            result.DateA.ShouldBe(new DateTime(2003, 5, 6));
            result.DateD.ShouldBe(new DateTime(2020, 4, 8));
            result.Sort.ShouldBe(1870025451);
            result.Note.ShouldBe("a7875298035e4e948333ac83553c7a88021325c1133c4bd8ba380ebef786d7ed63a00b3daa2547efb59f6bc7b47ae698cc39c152bc274dc08e220f5e5f73aefb118c3c5de10e41ecb5b09fab9dd0cf3824062fed748b4c17a29b2a582a8c1adde5ae2eb13c04480282162e7856954ef318627096ecba47538b673d2376e8e7825b6a34f215944749b26106ead1c40a7f389c7320e1c54cb181058d643ecb8338202dd7d07cd3410985be63670793e54b08c7306fa55b4887a90ff2133bbcc56dfbc3cbde9f3f4292b785e443bd171c390f21a1c3b9934a0ab88b8677fe37ae6801f80ded07764148ae6c7edde1b35b888b91d24c320948478a4f");
            result.Status.ShouldBe("e924dcf9d6704aa488176d6e2774390ecb446390ec1d4013b4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareDictionarysAppService.DeleteAsync(Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"));

            // Assert
            var result = await _shareDictionaryRepository.FindAsync(c => c.Id == Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"));

            result.ShouldBeNull();
        }
    }
}