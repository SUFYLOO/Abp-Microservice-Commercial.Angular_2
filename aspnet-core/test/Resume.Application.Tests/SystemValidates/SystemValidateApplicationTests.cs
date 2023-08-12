using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemValidates
{
    public class SystemValidatesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemValidatesAppService _systemValidatesAppService;
        private readonly IRepository<SystemValidate, Guid> _systemValidateRepository;

        public SystemValidatesAppServiceTests()
        {
            _systemValidatesAppService = GetRequiredService<ISystemValidatesAppService>();
            _systemValidateRepository = GetRequiredService<IRepository<SystemValidate, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemValidatesAppService.GetListAsync(new GetSystemValidatesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("26914dc7-65e7-44d9-998e-9152ca1bcff7")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemValidatesAppService.GetAsync(Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemValidateCreateDto
            {
                Param = "ca98b15823ab47338889aca5607f34a1cb8fd883f9ad435b851a00f646f2842501f87e15229f4a4597aa870e66d2a8550d3a638c9b3a487c997109b82762dc0a139eb0a1a43946d2991118f819bef27a68c4c21b30ad4ac6878be0692acc36288bdd8d08",
                DateOpen = new DateTime(2022, 4, 21),
                ExtendedInformation = "1eca9710d7494ce0ac89825413d247ec5eea50e029a7408c97d47786841102016f4c5eb3357144c7aac1dc4ccd13881d7bfaa25aa5094fee959d0677053c1c78a2d3227c4f804a278e940aed5d0c1ba016a94a0684c943579e78a4ddcae4a4a9c759c97ea1e648289f565c01b686d6e5d282667b69c34ae09a24b8da94442c2fa912ef3e85ca47318a249da1358676df3554885815694ac49c2abccc3a27d8c1613beb0cc6174743b6ae52e858008645e726a6f050de40839f025505001c311580cd25debf5b4d818dd9e99a7993bd743596844dd8bc46789da78ac460a7da218c85c0319c4e4d609fae67772aa211f45da2d8ae68b2462fa559",
                DateA = new DateTime(2009, 3, 12),
                DateD = new DateTime(2015, 6, 14),
                Sort = 2091816789,
                Note = "93fe2523c64f467989b475ebbb1788668058a3da95ce407aac3a995f1add0ea8ccedf003286e409fb5cdfebf62aea4b3ecf4e7e5ccbc48af83e591f1cd6c302a6b9aec54a72542f3a7930d1dd8f9d2f8a460bf5cdbc24f10a039e8717f08d7be0f9d71e3f2de46deba948946cc74e1827736f0477d3f42f496259002d7a67e62deba0e2b39864dbba2b37f7bcae12b84e1aa2632f0794968b5f02e682a5c98860eed77cefa6847a5852e6b9c3e38e84a295ed429c37d4fcb9017fd19a3b597369860fdc8176b497fb406c0a1241b3d8a37a599935f6f4de4a5df2ae23d28f0a3b8da33f7dfa34d1e8bf6f1a20ad56a67216ed2c981184eefa5fe",
                Status = "c7c3c9a39ca94e6aa9a637e18c4d67343d355760e4904f15b2"
            };

            // Act
            var serviceResult = await _systemValidatesAppService.CreateAsync(input);

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Param.ShouldBe("ca98b15823ab47338889aca5607f34a1cb8fd883f9ad435b851a00f646f2842501f87e15229f4a4597aa870e66d2a8550d3a638c9b3a487c997109b82762dc0a139eb0a1a43946d2991118f819bef27a68c4c21b30ad4ac6878be0692acc36288bdd8d08");
            result.DateOpen.ShouldBe(new DateTime(2022, 4, 21));
            result.ExtendedInformation.ShouldBe("1eca9710d7494ce0ac89825413d247ec5eea50e029a7408c97d47786841102016f4c5eb3357144c7aac1dc4ccd13881d7bfaa25aa5094fee959d0677053c1c78a2d3227c4f804a278e940aed5d0c1ba016a94a0684c943579e78a4ddcae4a4a9c759c97ea1e648289f565c01b686d6e5d282667b69c34ae09a24b8da94442c2fa912ef3e85ca47318a249da1358676df3554885815694ac49c2abccc3a27d8c1613beb0cc6174743b6ae52e858008645e726a6f050de40839f025505001c311580cd25debf5b4d818dd9e99a7993bd743596844dd8bc46789da78ac460a7da218c85c0319c4e4d609fae67772aa211f45da2d8ae68b2462fa559");
            result.DateA.ShouldBe(new DateTime(2009, 3, 12));
            result.DateD.ShouldBe(new DateTime(2015, 6, 14));
            result.Sort.ShouldBe(2091816789);
            result.Note.ShouldBe("93fe2523c64f467989b475ebbb1788668058a3da95ce407aac3a995f1add0ea8ccedf003286e409fb5cdfebf62aea4b3ecf4e7e5ccbc48af83e591f1cd6c302a6b9aec54a72542f3a7930d1dd8f9d2f8a460bf5cdbc24f10a039e8717f08d7be0f9d71e3f2de46deba948946cc74e1827736f0477d3f42f496259002d7a67e62deba0e2b39864dbba2b37f7bcae12b84e1aa2632f0794968b5f02e682a5c98860eed77cefa6847a5852e6b9c3e38e84a295ed429c37d4fcb9017fd19a3b597369860fdc8176b497fb406c0a1241b3d8a37a599935f6f4de4a5df2ae23d28f0a3b8da33f7dfa34d1e8bf6f1a20ad56a67216ed2c981184eefa5fe");
            result.Status.ShouldBe("c7c3c9a39ca94e6aa9a637e18c4d67343d355760e4904f15b2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemValidateUpdateDto()
            {
                Param = "4a65669ec7734bc4b3840e7e7ed7b59d9c58f34d0fd645fbaeb66098618d02f3eebe76c3f68344238896f9d2475b9265843b3dcd9ce64becba3806e2e2e354e3d68cf0eaaea04d648588d8f8037f3173bf23d6e1df9d4c3e97afe6a36ff2b9bccbe686c4",
                DateOpen = new DateTime(2017, 3, 8),
                ExtendedInformation = "ceca1f52e71a4973b9877a41273f9d8e119e8e79447645949397b487bb3145b86cdf2be099d24eff96c4aed4ef283743924bb411fa64467a86b4b74656059dfe167e1af1d08843eb926e0bc1dd4f1a1ad680584057b44531b191cb8f5d31c20a09ee0f43afd84dfdab50b3c87bbdb5755c71a930e62541f3b8704b965aab8a7f3a1991a15b2b4a5da4b19720da79c5c28c43f4ce7af94b9e8ccb282e8000d434405f59ebf88840ca891dffac7287e1d600a79617905d410f8162d40dcd85490ed41b7fbe986742ab84cc0976f806d5fd6550897dcb964efcb4869a372bcd7a1402222c2b98514770a049174c444100ef3ab60ffb3c9841939c80",
                DateA = new DateTime(2010, 8, 5),
                DateD = new DateTime(2000, 6, 4),
                Sort = 875364239,
                Note = "b12e18ac189e4b9a8bb79b5240c71f4c0d5d23154e5442ffb12dca648dd96d4b1be45f0da64a410d9e10fe685877a5ddb066b7f7037e4e7e99478546de060743582ea476ee2f416cb3b2a0c55dd466b0cb7ee42e02774e66a799e239f353f6d5add8f323fad34a3f861a744caa0ec843558572d1f42b47a9a6a95e01ccd4bc9f9c718091848f489b93861541faa38ca12561d2ce8ae74450a5cbb13537c3051e559036c17c984f9f8e8e38dfa8e6257a19d767c287c84106a052cbfe51bec8c7dc5e0743bfd642ae931c70a56a1406a1889308973c004d60a2b426edad02b4f42e898e8e29c040e0926529f107a953c50fbaf276c0e14cb8b7b4",
                Status = "e7c9a4349c1c475a82f914e7ebcc64cff3929656693848af9d"
            };

            // Act
            var serviceResult = await _systemValidatesAppService.UpdateAsync(Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"), input);

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Param.ShouldBe("4a65669ec7734bc4b3840e7e7ed7b59d9c58f34d0fd645fbaeb66098618d02f3eebe76c3f68344238896f9d2475b9265843b3dcd9ce64becba3806e2e2e354e3d68cf0eaaea04d648588d8f8037f3173bf23d6e1df9d4c3e97afe6a36ff2b9bccbe686c4");
            result.DateOpen.ShouldBe(new DateTime(2017, 3, 8));
            result.ExtendedInformation.ShouldBe("ceca1f52e71a4973b9877a41273f9d8e119e8e79447645949397b487bb3145b86cdf2be099d24eff96c4aed4ef283743924bb411fa64467a86b4b74656059dfe167e1af1d08843eb926e0bc1dd4f1a1ad680584057b44531b191cb8f5d31c20a09ee0f43afd84dfdab50b3c87bbdb5755c71a930e62541f3b8704b965aab8a7f3a1991a15b2b4a5da4b19720da79c5c28c43f4ce7af94b9e8ccb282e8000d434405f59ebf88840ca891dffac7287e1d600a79617905d410f8162d40dcd85490ed41b7fbe986742ab84cc0976f806d5fd6550897dcb964efcb4869a372bcd7a1402222c2b98514770a049174c444100ef3ab60ffb3c9841939c80");
            result.DateA.ShouldBe(new DateTime(2010, 8, 5));
            result.DateD.ShouldBe(new DateTime(2000, 6, 4));
            result.Sort.ShouldBe(875364239);
            result.Note.ShouldBe("b12e18ac189e4b9a8bb79b5240c71f4c0d5d23154e5442ffb12dca648dd96d4b1be45f0da64a410d9e10fe685877a5ddb066b7f7037e4e7e99478546de060743582ea476ee2f416cb3b2a0c55dd466b0cb7ee42e02774e66a799e239f353f6d5add8f323fad34a3f861a744caa0ec843558572d1f42b47a9a6a95e01ccd4bc9f9c718091848f489b93861541faa38ca12561d2ce8ae74450a5cbb13537c3051e559036c17c984f9f8e8e38dfa8e6257a19d767c287c84106a052cbfe51bec8c7dc5e0743bfd642ae931c70a56a1406a1889308973c004d60a2b426edad02b4f42e898e8e29c040e0926529f107a953c50fbaf276c0e14cb8b7b4");
            result.Status.ShouldBe("e7c9a4349c1c475a82f914e7ebcc64cff3929656693848af9d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemValidatesAppService.DeleteAsync(Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"));

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"));

            result.ShouldBeNull();
        }
    }
}