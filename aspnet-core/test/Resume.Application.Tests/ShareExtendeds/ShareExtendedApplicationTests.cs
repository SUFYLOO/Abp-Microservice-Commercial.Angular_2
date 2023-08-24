using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareExtendeds
{
    public class ShareExtendedsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareExtendedsAppService _shareExtendedsAppService;
        private readonly IRepository<ShareExtended, Guid> _shareExtendedRepository;

        public ShareExtendedsAppServiceTests()
        {
            _shareExtendedsAppService = GetRequiredService<IShareExtendedsAppService>();
            _shareExtendedRepository = GetRequiredService<IRepository<ShareExtended, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareExtendedsAppService.GetListAsync(new GetShareExtendedsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("093df82e-ff9c-42eb-98a0-2e708f5027f8")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareExtendedsAppService.GetAsync(Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareExtendedCreateDto
            {
                Key1 = "8d79572c0d114de1b6bf4d7c1b9db3669df3b27a476b4d0e98",
                Key2 = "61300928320b4d0ca806d27991b334fb5782afc3cb9b4d9fac",
                Key3 = "26cb4064f4934e30b95c2cff05f998315e84a8f70df54c0c95",
                Key4 = "78299ec265cc43ff99e646283695b0270c78c87a26a8453888",
                Key5 = "006e15d8fb684a468af2298262634424eb167365aac1451792",
                KeyId = Guid.Parse("c78b864b-e6a3-41cc-803b-4582e055889f"),
                FieldValue = "adc7c8c041a34fd3afca06d162231bddd68e11b011994ebeb03ed48fb9dc5197b0711b563ef540a4b1a7fcf9d85b3a5c0cfc09d771db4a4cac2a4ae00529e53a31c4527c9c694b5f953988bad370a783c8e41e9e2fbd4565b1c8c655cef19611e818e6a8",
                ExtendedInformation = "2c0c65dec8814331991bdbe909a4a925bacd1dccde6d4fec98188f5beb93514038479599b6d245c1b39e022396db42abfd4d2d1a71b5481998517b6650ba428f471e8c5758354584b8924f1417bb85b674458f070cb74e6aae00feb6224988f0419f13a9d4a9414bb757b598d8e38391e0c3cdad0eed4429b04f182c80da5f13b486e6433aea4b9ba2396576206a268fcb0287d6515742d69841e816f5ff6b2d9acbb8e2471a4f429687b7d9835baf1b7cf7e10e36894c498499a38cc18e2b518f57d767d83d4ddfb11af7adf64f905953aa571927fb47378871de340961fb6b2fc5d7e7983f45d78762e8205bc44ce32a90dbf97f8647299d8d",
                DateA = new DateTime(2012, 9, 12),
                DateD = new DateTime(2017, 8, 6),
                Sort = 1850705130,
                Note = "42dcbba5850d4b69b768685563ae169c2661aef430f845a988743359af33f52f34153e776c0a4c81ab934bd4806a0007baf3d0602c074a309cae2ddd925b2abbb3343621133f41c1abdd4dd59991db6bffeb44df8a8b4017ad04993067f430c9d0388a22875943e0861f404fd86f417410dc9e895f1a4015905ada2a9fa738f758739e2100874b72b25d25dca2c336e01c7eeb5ff2aa44f98eea5a6615ff7a0951cb61b5fc2d4af6ad6161fc88dd1c01a6c98c0623a843a39e660473a8ef6965e2e331d89bba44508f5a791e0096efdcf1d2458f84cf484d9ac1c2e24747f45252d60beac56842f0ac19798ef22453078322c1621b2546478b8d",
                Status = "a581b31574bf4d9c944ecc83315663130fc28fff181542a499"
            };

            // Act
            var serviceResult = await _shareExtendedsAppService.CreateAsync(input);

            // Assert
            var result = await _shareExtendedRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("8d79572c0d114de1b6bf4d7c1b9db3669df3b27a476b4d0e98");
            result.Key2.ShouldBe("61300928320b4d0ca806d27991b334fb5782afc3cb9b4d9fac");
            result.Key3.ShouldBe("26cb4064f4934e30b95c2cff05f998315e84a8f70df54c0c95");
            result.Key4.ShouldBe("78299ec265cc43ff99e646283695b0270c78c87a26a8453888");
            result.Key5.ShouldBe("006e15d8fb684a468af2298262634424eb167365aac1451792");
            result.KeyId.ShouldBe(Guid.Parse("c78b864b-e6a3-41cc-803b-4582e055889f"));
            result.FieldValue.ShouldBe("adc7c8c041a34fd3afca06d162231bddd68e11b011994ebeb03ed48fb9dc5197b0711b563ef540a4b1a7fcf9d85b3a5c0cfc09d771db4a4cac2a4ae00529e53a31c4527c9c694b5f953988bad370a783c8e41e9e2fbd4565b1c8c655cef19611e818e6a8");
            result.ExtendedInformation.ShouldBe("2c0c65dec8814331991bdbe909a4a925bacd1dccde6d4fec98188f5beb93514038479599b6d245c1b39e022396db42abfd4d2d1a71b5481998517b6650ba428f471e8c5758354584b8924f1417bb85b674458f070cb74e6aae00feb6224988f0419f13a9d4a9414bb757b598d8e38391e0c3cdad0eed4429b04f182c80da5f13b486e6433aea4b9ba2396576206a268fcb0287d6515742d69841e816f5ff6b2d9acbb8e2471a4f429687b7d9835baf1b7cf7e10e36894c498499a38cc18e2b518f57d767d83d4ddfb11af7adf64f905953aa571927fb47378871de340961fb6b2fc5d7e7983f45d78762e8205bc44ce32a90dbf97f8647299d8d");
            result.DateA.ShouldBe(new DateTime(2012, 9, 12));
            result.DateD.ShouldBe(new DateTime(2017, 8, 6));
            result.Sort.ShouldBe(1850705130);
            result.Note.ShouldBe("42dcbba5850d4b69b768685563ae169c2661aef430f845a988743359af33f52f34153e776c0a4c81ab934bd4806a0007baf3d0602c074a309cae2ddd925b2abbb3343621133f41c1abdd4dd59991db6bffeb44df8a8b4017ad04993067f430c9d0388a22875943e0861f404fd86f417410dc9e895f1a4015905ada2a9fa738f758739e2100874b72b25d25dca2c336e01c7eeb5ff2aa44f98eea5a6615ff7a0951cb61b5fc2d4af6ad6161fc88dd1c01a6c98c0623a843a39e660473a8ef6965e2e331d89bba44508f5a791e0096efdcf1d2458f84cf484d9ac1c2e24747f45252d60beac56842f0ac19798ef22453078322c1621b2546478b8d");
            result.Status.ShouldBe("a581b31574bf4d9c944ecc83315663130fc28fff181542a499");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareExtendedUpdateDto()
            {
                Key1 = "48b8ed71a6b24c85963a8dfc8de80508b9abf713fc06484eab",
                Key2 = "963d7ca8b69a4eb28d2d724abe5eef10d5ab0753db994efdba",
                Key3 = "ffbae83146ab482eafb036963fd921861b5157bb89ad42cbad",
                Key4 = "7e40008f878f4a58becc7fb78e6b70f447d604734db745358f",
                Key5 = "a25feaaf52504d6db4081545ae5f2018c6ab86d9f3af436ea8",
                KeyId = Guid.Parse("ca8d4865-3cba-460a-b015-dcd13a8f6c5f"),
                FieldValue = "29f7f009a95440e595d8122162de7358e8a03756cbf14bdb9ed42eb1bad59ed19182df0e24144a60bc00933a598b16a9031258c5901d42ad8408f312b87aaa629b95e60de6544ea592ec6dabb329b144e0d88c5144594d59b0943086417052b157becf7f",
                ExtendedInformation = "2fecb4d894c74021a4da7dd3cf06815bcdc5eb9abfd846b4b707f5c3dca9bf36fd9ced3ce90d450c9a5055d442ec8acad7b5cf015b1f4b1a9bea5f7e795daa5dee30e9a2e2834c5cb5b45f9941b4ebc18181485a081e42148c84fb69591f2d933377bf7fcf8442fc8a1b6f7e37c08295b96b8363502346c899136b3933d66bf935878dc17c584785b190dd0a1fc9b463a64e520a1f9e4eb6a12489676dfd1f4828dc7c580b814150b6ba49f4c36acf798d546bee46224c2b87ec10bdb23cbefe3632c12d4c7c40818df6181c6b098668482727ef053445f6a410a86cde180c7def4772bea34d4287a7fb6cc82d811a95ce0a53926b6a4b878895",
                DateA = new DateTime(2000, 11, 15),
                DateD = new DateTime(2000, 11, 24),
                Sort = 226091940,
                Note = "8f59bce436224788881d51b0a370564195f51ee41a484a08930afc37523671f4f81e5ec36a384645a27ec448161a83ff638d0f3bc89848eab85742464b1fc9da59db8e0146424738b9c0fc90799bbb0c74935e5f394c46adabe1d7b5f6f4be54ca6b29181b084a878fc04fa14a8a5ad5d7c2ace47b9441318dea1054986b8bca0cc251a37d1e45cda7454079bcfece8f1d07a1eeb96f4704a265d8614b54f9a4064efd25377f403ea61a4b60766606c38405472c1cb840c7a74706e956863e7bb0caff063ab54d15bca45b7a8d5e4cfdeaf15de454f34c5e860d33c3f571480e40395220128642139f1aec83d30a4fe2fb9c9f494a5c48d6a351",
                Status = "b43df2c15f0947628e8e5bfa5c18b4fa7f3038cb45524877a2"
            };

            // Act
            var serviceResult = await _shareExtendedsAppService.UpdateAsync(Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"), input);

            // Assert
            var result = await _shareExtendedRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("48b8ed71a6b24c85963a8dfc8de80508b9abf713fc06484eab");
            result.Key2.ShouldBe("963d7ca8b69a4eb28d2d724abe5eef10d5ab0753db994efdba");
            result.Key3.ShouldBe("ffbae83146ab482eafb036963fd921861b5157bb89ad42cbad");
            result.Key4.ShouldBe("7e40008f878f4a58becc7fb78e6b70f447d604734db745358f");
            result.Key5.ShouldBe("a25feaaf52504d6db4081545ae5f2018c6ab86d9f3af436ea8");
            result.KeyId.ShouldBe(Guid.Parse("ca8d4865-3cba-460a-b015-dcd13a8f6c5f"));
            result.FieldValue.ShouldBe("29f7f009a95440e595d8122162de7358e8a03756cbf14bdb9ed42eb1bad59ed19182df0e24144a60bc00933a598b16a9031258c5901d42ad8408f312b87aaa629b95e60de6544ea592ec6dabb329b144e0d88c5144594d59b0943086417052b157becf7f");
            result.ExtendedInformation.ShouldBe("2fecb4d894c74021a4da7dd3cf06815bcdc5eb9abfd846b4b707f5c3dca9bf36fd9ced3ce90d450c9a5055d442ec8acad7b5cf015b1f4b1a9bea5f7e795daa5dee30e9a2e2834c5cb5b45f9941b4ebc18181485a081e42148c84fb69591f2d933377bf7fcf8442fc8a1b6f7e37c08295b96b8363502346c899136b3933d66bf935878dc17c584785b190dd0a1fc9b463a64e520a1f9e4eb6a12489676dfd1f4828dc7c580b814150b6ba49f4c36acf798d546bee46224c2b87ec10bdb23cbefe3632c12d4c7c40818df6181c6b098668482727ef053445f6a410a86cde180c7def4772bea34d4287a7fb6cc82d811a95ce0a53926b6a4b878895");
            result.DateA.ShouldBe(new DateTime(2000, 11, 15));
            result.DateD.ShouldBe(new DateTime(2000, 11, 24));
            result.Sort.ShouldBe(226091940);
            result.Note.ShouldBe("8f59bce436224788881d51b0a370564195f51ee41a484a08930afc37523671f4f81e5ec36a384645a27ec448161a83ff638d0f3bc89848eab85742464b1fc9da59db8e0146424738b9c0fc90799bbb0c74935e5f394c46adabe1d7b5f6f4be54ca6b29181b084a878fc04fa14a8a5ad5d7c2ace47b9441318dea1054986b8bca0cc251a37d1e45cda7454079bcfece8f1d07a1eeb96f4704a265d8614b54f9a4064efd25377f403ea61a4b60766606c38405472c1cb840c7a74706e956863e7bb0caff063ab54d15bca45b7a8d5e4cfdeaf15de454f34c5e860d33c3f571480e40395220128642139f1aec83d30a4fe2fb9c9f494a5c48d6a351");
            result.Status.ShouldBe("b43df2c15f0947628e8e5bfa5c18b4fa7f3038cb45524877a2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareExtendedsAppService.DeleteAsync(Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"));

            // Assert
            var result = await _shareExtendedRepository.FindAsync(c => c.Id == Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"));

            result.ShouldBeNull();
        }
    }
}