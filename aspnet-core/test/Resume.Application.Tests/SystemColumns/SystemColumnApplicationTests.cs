using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemColumns
{
    public class SystemColumnsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemColumnsAppService _systemColumnsAppService;
        private readonly IRepository<SystemColumn, Guid> _systemColumnRepository;

        public SystemColumnsAppServiceTests()
        {
            _systemColumnsAppService = GetRequiredService<ISystemColumnsAppService>();
            _systemColumnRepository = GetRequiredService<IRepository<SystemColumn, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemColumnsAppService.GetListAsync(new GetSystemColumnsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2da20364-012f-44ae-ae1d-c0c158d36e37")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemColumnsAppService.GetAsync(Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemColumnCreateDto
            {
                SystemTableId = Guid.Parse("fde17147-7374-4873-bfb8-d68ac6a6a3d0"),
                Name = "addeb8694aad4eddb771bcb98ca1dc5f3705f95b2f5a4dcaae",
                IsKey = true,
                IsSensitive = true,
                NeedMask = true,
                DefaultValue = "ad024fd0db5b4b198267ec7a30f0b4858316c38db268494c8a",
                CheckCode = true,
                Related = "4b2dd9e3968242d0828869a2984f20d54acd5bc690bf4fbc9039f5f49c5cc271df98325a75f243ff9630eee88be37f6066f35833a2f44d4b9a2d86df64e7fa76158786575e9a4a6693513971aa033c04e383b249704a4df88ec6bbacb7c43b661265af28",
                AllowUpdate = true,
                AllowNull = true,
                AllowEmpty = true,
                AllowExport = true,
                AllowSort = true,
                ColumnTypeCode = "78e700c9308e4b88930fe783ee994cb54a4fdc8c69d64ed189",
                ExtendedInformation = "7d2f06ce4bec4c3db87eff3752ee76a20799bf03817c4d759b97ee1db831b78779a54f0036c744b49c14792645d89d39f4fbc7ece0684d08b161af6904e5ed652043427eec7c455b80e18617351a6af6437e5c5e03f946d7a96fee86ebb4515a7bd1cbf5c18f4d6b9c3cc926ebb89d2e596251e398a044288d13a3ebfe3f8abde3778080f21e48859019f7cb73042f6589846a5c8574419da2217fe031509cd1b4d382d7c1a54c45b7876352693f2ad496c3f55f453c4d9bb7c42ad45b6dd1d7e9fba1b065a346b0a392ee66844fc342c5ec2543db8c4ad7b95a21b35f41b42a0f8611892de3422c9e5cc21b18738d872158c5bf8abc43a8b4a8",
                DateA = new DateTime(2002, 8, 24),
                DateD = new DateTime(2008, 3, 25),
                Sort = 1349821414,
                Note = "475e8fee392147558a75ddddfb750ced2b6e38ffdd5f4c09b3c13064ffab22c56ef4405a06f6458893bd09a59b6415b3e6c207aa689f4d96ab7cfd7967a69ea0ec8c6946a1894ee48fd325742503373e31b35b9c4c404cd992d5bb1f1325314138a33642640242ec9ad354ea3b920b76c402721df6cc4f59bc7d12603af76481d55b36e560cb44f0a2c8dbeaf2c4e30f2b206e1e72c24ce399cb3b8bab1ce639bcc88bd9ea8f48c5a1ef95e3bcd97031b6021df7d76246799cef9983092fe33333a3dc6770d7498a9c6a0bd028a23ea76d4b70c3bb68411085778e90080f1e072d5c7ae23b6645c7ba8d762776bedd55eed63e1f39c948338634",
                Status = "4e624619d25d4e7188afab27dcc86ab449479c5154c3401a81"
            };

            // Act
            var serviceResult = await _systemColumnsAppService.CreateAsync(input);

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemTableId.ShouldBe(Guid.Parse("fde17147-7374-4873-bfb8-d68ac6a6a3d0"));
            result.Name.ShouldBe("addeb8694aad4eddb771bcb98ca1dc5f3705f95b2f5a4dcaae");
            result.IsKey.ShouldBe(true);
            result.IsSensitive.ShouldBe(true);
            result.NeedMask.ShouldBe(true);
            result.DefaultValue.ShouldBe("ad024fd0db5b4b198267ec7a30f0b4858316c38db268494c8a");
            result.CheckCode.ShouldBe(true);
            result.Related.ShouldBe("4b2dd9e3968242d0828869a2984f20d54acd5bc690bf4fbc9039f5f49c5cc271df98325a75f243ff9630eee88be37f6066f35833a2f44d4b9a2d86df64e7fa76158786575e9a4a6693513971aa033c04e383b249704a4df88ec6bbacb7c43b661265af28");
            result.AllowUpdate.ShouldBe(true);
            result.AllowNull.ShouldBe(true);
            result.AllowEmpty.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ColumnTypeCode.ShouldBe("78e700c9308e4b88930fe783ee994cb54a4fdc8c69d64ed189");
            result.ExtendedInformation.ShouldBe("7d2f06ce4bec4c3db87eff3752ee76a20799bf03817c4d759b97ee1db831b78779a54f0036c744b49c14792645d89d39f4fbc7ece0684d08b161af6904e5ed652043427eec7c455b80e18617351a6af6437e5c5e03f946d7a96fee86ebb4515a7bd1cbf5c18f4d6b9c3cc926ebb89d2e596251e398a044288d13a3ebfe3f8abde3778080f21e48859019f7cb73042f6589846a5c8574419da2217fe031509cd1b4d382d7c1a54c45b7876352693f2ad496c3f55f453c4d9bb7c42ad45b6dd1d7e9fba1b065a346b0a392ee66844fc342c5ec2543db8c4ad7b95a21b35f41b42a0f8611892de3422c9e5cc21b18738d872158c5bf8abc43a8b4a8");
            result.DateA.ShouldBe(new DateTime(2002, 8, 24));
            result.DateD.ShouldBe(new DateTime(2008, 3, 25));
            result.Sort.ShouldBe(1349821414);
            result.Note.ShouldBe("475e8fee392147558a75ddddfb750ced2b6e38ffdd5f4c09b3c13064ffab22c56ef4405a06f6458893bd09a59b6415b3e6c207aa689f4d96ab7cfd7967a69ea0ec8c6946a1894ee48fd325742503373e31b35b9c4c404cd992d5bb1f1325314138a33642640242ec9ad354ea3b920b76c402721df6cc4f59bc7d12603af76481d55b36e560cb44f0a2c8dbeaf2c4e30f2b206e1e72c24ce399cb3b8bab1ce639bcc88bd9ea8f48c5a1ef95e3bcd97031b6021df7d76246799cef9983092fe33333a3dc6770d7498a9c6a0bd028a23ea76d4b70c3bb68411085778e90080f1e072d5c7ae23b6645c7ba8d762776bedd55eed63e1f39c948338634");
            result.Status.ShouldBe("4e624619d25d4e7188afab27dcc86ab449479c5154c3401a81");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemColumnUpdateDto()
            {
                SystemTableId = Guid.Parse("326f30e9-e090-444e-8771-d93f632a0044"),
                Name = "10b19f0d3dc34e1da6809952c83dda12581663c9cdf3477e80",
                IsKey = true,
                IsSensitive = true,
                NeedMask = true,
                DefaultValue = "925d2ec5c413402382da38b8b725efc3627cf4e45011440387",
                CheckCode = true,
                Related = "8aba3d055635448a8615c9e822b4300f2e3a95d878bd47cd8d769beb4ee712180320ce0cc91a45d3a20a7f807f57e06bdc662da6eb3d403c88207b69839108d617c91e9505324f5a8b2b0834e48ecb1b0e3c5c7fcffc4090a43782f0a42a9e8f817786b6",
                AllowUpdate = true,
                AllowNull = true,
                AllowEmpty = true,
                AllowExport = true,
                AllowSort = true,
                ColumnTypeCode = "42c247e0dbd64944be4b5eff4f0e5fba1ef7ad8721494100b6",
                ExtendedInformation = "acb58c8413f24e47827fa9f94d0a52ba0ab9516795e84aa2a06d1ca2284bab7a2e6c0f891a5243bba7259a6b7d9b193a76e29491cc4b42f19bfe65ab57df28527209bf4c0e8a4d1da8308ef90f1c1f557d4b02ef81594158b6a5431d6c55a52f6b1d1a33490541288edd73f2fe295508eb0850b036654893927551fcd57ced0679a3b42f97c0466cb5e812e2531034b5e7ccb6de0c6544b4b56579789d6e0bf72e9a28a90522488c837c95fc275228ae21681cec70c64c33b1f992f0c7cd73133efbb4256b7c4d3e9b8e22d54b72454cb78f98fd4b7943e79dda7d730b1d36257bf896ac86754e7ab5c4fb67a30b0597b2d6c43c85d0428f9e2f",
                DateA = new DateTime(2011, 5, 2),
                DateD = new DateTime(2015, 5, 4),
                Sort = 439692161,
                Note = "8bac7a20d14940d899b50d7fc8e8b703da332268b4ea4e68ba183f1b66390d07208f1ff322e04bce8fbccb726361ec06e35b584f45f44722bc8a944b739e784b52270a906cfc4fe39446da1e25aa1c317cd6697c184a4174a331d3ecf01a8b3623449bd50160462ba192c8e49aacf3ab06beaed3b3a94fb0a29effc0c22b3eb84e24451f5cb4429a8b1e2cb3df3d938648ed0719292d4d0a89bdcc4ec73988c653856851ed7840dc9630d4041fc820e0ab38b105e496419dbe5f7ce12cec004430cd009da9b84413b26ff1aa0935896d2c0cb02a6785490799f25ba45073da27ac486ac4a391414695bfaf75e6b28fd3ef0fc6f508024c55b8ad",
                Status = "e7b759c75502495cae33aa9a7754bcdbe0fc9f35e0fa42d086"
            };

            // Act
            var serviceResult = await _systemColumnsAppService.UpdateAsync(Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"), input);

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemTableId.ShouldBe(Guid.Parse("326f30e9-e090-444e-8771-d93f632a0044"));
            result.Name.ShouldBe("10b19f0d3dc34e1da6809952c83dda12581663c9cdf3477e80");
            result.IsKey.ShouldBe(true);
            result.IsSensitive.ShouldBe(true);
            result.NeedMask.ShouldBe(true);
            result.DefaultValue.ShouldBe("925d2ec5c413402382da38b8b725efc3627cf4e45011440387");
            result.CheckCode.ShouldBe(true);
            result.Related.ShouldBe("8aba3d055635448a8615c9e822b4300f2e3a95d878bd47cd8d769beb4ee712180320ce0cc91a45d3a20a7f807f57e06bdc662da6eb3d403c88207b69839108d617c91e9505324f5a8b2b0834e48ecb1b0e3c5c7fcffc4090a43782f0a42a9e8f817786b6");
            result.AllowUpdate.ShouldBe(true);
            result.AllowNull.ShouldBe(true);
            result.AllowEmpty.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ColumnTypeCode.ShouldBe("42c247e0dbd64944be4b5eff4f0e5fba1ef7ad8721494100b6");
            result.ExtendedInformation.ShouldBe("acb58c8413f24e47827fa9f94d0a52ba0ab9516795e84aa2a06d1ca2284bab7a2e6c0f891a5243bba7259a6b7d9b193a76e29491cc4b42f19bfe65ab57df28527209bf4c0e8a4d1da8308ef90f1c1f557d4b02ef81594158b6a5431d6c55a52f6b1d1a33490541288edd73f2fe295508eb0850b036654893927551fcd57ced0679a3b42f97c0466cb5e812e2531034b5e7ccb6de0c6544b4b56579789d6e0bf72e9a28a90522488c837c95fc275228ae21681cec70c64c33b1f992f0c7cd73133efbb4256b7c4d3e9b8e22d54b72454cb78f98fd4b7943e79dda7d730b1d36257bf896ac86754e7ab5c4fb67a30b0597b2d6c43c85d0428f9e2f");
            result.DateA.ShouldBe(new DateTime(2011, 5, 2));
            result.DateD.ShouldBe(new DateTime(2015, 5, 4));
            result.Sort.ShouldBe(439692161);
            result.Note.ShouldBe("8bac7a20d14940d899b50d7fc8e8b703da332268b4ea4e68ba183f1b66390d07208f1ff322e04bce8fbccb726361ec06e35b584f45f44722bc8a944b739e784b52270a906cfc4fe39446da1e25aa1c317cd6697c184a4174a331d3ecf01a8b3623449bd50160462ba192c8e49aacf3ab06beaed3b3a94fb0a29effc0c22b3eb84e24451f5cb4429a8b1e2cb3df3d938648ed0719292d4d0a89bdcc4ec73988c653856851ed7840dc9630d4041fc820e0ab38b105e496419dbe5f7ce12cec004430cd009da9b84413b26ff1aa0935896d2c0cb02a6785490799f25ba45073da27ac486ac4a391414695bfaf75e6b28fd3ef0fc6f508024c55b8ad");
            result.Status.ShouldBe("e7b759c75502495cae33aa9a7754bcdbe0fc9f35e0fa42d086");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemColumnsAppService.DeleteAsync(Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"));

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"));

            result.ShouldBeNull();
        }
    }
}