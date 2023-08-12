using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobAppliesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobAppliesAppService _userCompanyJobAppliesAppService;
        private readonly IRepository<UserCompanyJobApply, Guid> _userCompanyJobApplyRepository;

        public UserCompanyJobAppliesAppServiceTests()
        {
            _userCompanyJobAppliesAppService = GetRequiredService<IUserCompanyJobAppliesAppService>();
            _userCompanyJobApplyRepository = GetRequiredService<IRepository<UserCompanyJobApply, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetListAsync(new GetUserCompanyJobAppliesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("61ed38a5-97d2-4af8-8f97-5b6dbc616e4f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetAsync(Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyCreateDto
            {
                UserMainId = Guid.Parse("c738b5ea-4f08-4b0e-9ef5-286589f486a5"),
                CompanyJobId = Guid.Parse("8de842e7-a5cc-4ab4-b1a1-4d98de7ffa1f"),
                ExtendedInformation = "2bf6949da3c44df3ab1de9606300b45c2084fd34753f4a5c9908b535e3e553d09588fe9961fc44cb9093b2da11345040a853178f0a504b84ac15cbd585a0712c719c59a04b174dfa87de1ca7674f603f694ab9551e8d4f63b65f6565fd7880b64ea81c9bf4024ec0acdca44651d59a8a009949f917134f348f31545e3d809530e3b636a206ce4c498c6c1cf04028f3566c5b2876774f49ddae7fb6a9ab2332496f3b02fc30cb474882134cddc598b52a8761855bb1234480a480f18095f9c9fa54218361f3b74c6f86f545f5dde04f0dfe020ce203ca44088f89a26b349933bd5ee3f07c396d4eb584735be87ed6621cd9c1338ff81e469097a5",
                DateA = new DateTime(2006, 9, 23),
                DateD = new DateTime(2018, 3, 15),
                Sort = 1145948054,
                Note = "e5489e8800d4461486d3ddc848d955c6b46b22aca46d47cca800646ec7a862d9ff68b4f81b0b4b108c534d6d17bf3389b97f1f323c3e455db7a65700281b16bdfc18ec256d584003a62b478970053d4f93fbc2456f134cf184c645dfec191cfd6942034be74e49e1b0570664cb17244da2f73bdb39e44fa2bd6bf68bfd9e41418dda12ee97a54ca3891a01021e0dcbef4a1f4baf423f4ca3bf55db1ce789c2e03423769229e049ccbfa25c8562c78340a1eeff740b3349f295c7cfe10a80c3825eb4f8069c0247e58b4875da359bf338f6383bcb398348b8ad7a75cc35228542bf0c16c6853a4be49ba08528336dfd40a49a068cc5fe484b833a",
                Status = "7a25f18da2b84cd4bcfac90099f5f897439d9ac0738f4c62ab"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("c738b5ea-4f08-4b0e-9ef5-286589f486a5"));
            result.CompanyJobId.ShouldBe(Guid.Parse("8de842e7-a5cc-4ab4-b1a1-4d98de7ffa1f"));
            result.ExtendedInformation.ShouldBe("2bf6949da3c44df3ab1de9606300b45c2084fd34753f4a5c9908b535e3e553d09588fe9961fc44cb9093b2da11345040a853178f0a504b84ac15cbd585a0712c719c59a04b174dfa87de1ca7674f603f694ab9551e8d4f63b65f6565fd7880b64ea81c9bf4024ec0acdca44651d59a8a009949f917134f348f31545e3d809530e3b636a206ce4c498c6c1cf04028f3566c5b2876774f49ddae7fb6a9ab2332496f3b02fc30cb474882134cddc598b52a8761855bb1234480a480f18095f9c9fa54218361f3b74c6f86f545f5dde04f0dfe020ce203ca44088f89a26b349933bd5ee3f07c396d4eb584735be87ed6621cd9c1338ff81e469097a5");
            result.DateA.ShouldBe(new DateTime(2006, 9, 23));
            result.DateD.ShouldBe(new DateTime(2018, 3, 15));
            result.Sort.ShouldBe(1145948054);
            result.Note.ShouldBe("e5489e8800d4461486d3ddc848d955c6b46b22aca46d47cca800646ec7a862d9ff68b4f81b0b4b108c534d6d17bf3389b97f1f323c3e455db7a65700281b16bdfc18ec256d584003a62b478970053d4f93fbc2456f134cf184c645dfec191cfd6942034be74e49e1b0570664cb17244da2f73bdb39e44fa2bd6bf68bfd9e41418dda12ee97a54ca3891a01021e0dcbef4a1f4baf423f4ca3bf55db1ce789c2e03423769229e049ccbfa25c8562c78340a1eeff740b3349f295c7cfe10a80c3825eb4f8069c0247e58b4875da359bf338f6383bcb398348b8ad7a75cc35228542bf0c16c6853a4be49ba08528336dfd40a49a068cc5fe484b833a");
            result.Status.ShouldBe("7a25f18da2b84cd4bcfac90099f5f897439d9ac0738f4c62ab");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyUpdateDto()
            {
                UserMainId = Guid.Parse("8454be93-82ca-43e6-a537-163c543a99ec"),
                CompanyJobId = Guid.Parse("f70c91ad-bebe-468d-b5ea-3047ab95be46"),
                ExtendedInformation = "30e2c76c260a4ed89d31e2319ba000780e1b9d62b72f42b588b553d2cd9b2b210f5ace1e6c414c5faf0bd31ac62eb3e2f1f0e385890a4267af239c442b4be418b46da781ab4741bf95948ae7b619ec727ef4871e8438418d932315216ddaab382f656e4d9e07443192fdade5d5501e3d7e8270b0bc944e1ab6ea2308107ff0c543423a8e47a14f658d958b063944a971d33cf27383ca48289f9d3eefb65ed9f0bfb685cbee06474db03c50d68935d9f3b82688453d7e470186d1da242fbf51ad117eb7d804924a27814ff5eb149f5bd6d4952ce9236945d695d060771ce3c7a960c833a09a55402ea43dea93ce0da9a2440cab24ceea403fb29e",
                DateA = new DateTime(2018, 5, 14),
                DateD = new DateTime(2012, 6, 8),
                Sort = 1752820964,
                Note = "6708af19375a4bc0a91afd39fa5aeece359ca9a567a5471986dd3caae2e2871a27d823ceb790429191e368520b20d435d8aa5ed822ed475a8530623e8f2bd80440a5369cc932477ab252fa35614ad248d451ee77609d4495af3ad29c98dd6896a378a64b16944a9e8628cd5af4e0ad3366a83539e9de401dad4b230a20c1547f5c776930a9934131a4f20aa3aa597cfd2c7e28cd7b2b4063b95425b94c6977cc8ea3876d44154a6caad3f04b26a01ca9b2a4f0e9e41a41519a76700a6b0bdbbf75bd8ff7c18843db862bb3429e8be62d8e948791ef954ede9f541adaa5badac9b1779d77277a4fe99aacb7e015826bb3fa5b72c47c2c4f9f90eb",
                Status = "6ede1fc576db4018ba5a197e88d884a531aaa16d9a3e46888f"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.UpdateAsync(Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"), input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("8454be93-82ca-43e6-a537-163c543a99ec"));
            result.CompanyJobId.ShouldBe(Guid.Parse("f70c91ad-bebe-468d-b5ea-3047ab95be46"));
            result.ExtendedInformation.ShouldBe("30e2c76c260a4ed89d31e2319ba000780e1b9d62b72f42b588b553d2cd9b2b210f5ace1e6c414c5faf0bd31ac62eb3e2f1f0e385890a4267af239c442b4be418b46da781ab4741bf95948ae7b619ec727ef4871e8438418d932315216ddaab382f656e4d9e07443192fdade5d5501e3d7e8270b0bc944e1ab6ea2308107ff0c543423a8e47a14f658d958b063944a971d33cf27383ca48289f9d3eefb65ed9f0bfb685cbee06474db03c50d68935d9f3b82688453d7e470186d1da242fbf51ad117eb7d804924a27814ff5eb149f5bd6d4952ce9236945d695d060771ce3c7a960c833a09a55402ea43dea93ce0da9a2440cab24ceea403fb29e");
            result.DateA.ShouldBe(new DateTime(2018, 5, 14));
            result.DateD.ShouldBe(new DateTime(2012, 6, 8));
            result.Sort.ShouldBe(1752820964);
            result.Note.ShouldBe("6708af19375a4bc0a91afd39fa5aeece359ca9a567a5471986dd3caae2e2871a27d823ceb790429191e368520b20d435d8aa5ed822ed475a8530623e8f2bd80440a5369cc932477ab252fa35614ad248d451ee77609d4495af3ad29c98dd6896a378a64b16944a9e8628cd5af4e0ad3366a83539e9de401dad4b230a20c1547f5c776930a9934131a4f20aa3aa597cfd2c7e28cd7b2b4063b95425b94c6977cc8ea3876d44154a6caad3f04b26a01ca9b2a4f0e9e41a41519a76700a6b0bdbbf75bd8ff7c18843db862bb3429e8be62d8e948791ef954ede9f541adaa5badac9b1779d77277a4fe99aacb7e015826bb3fa5b72c47c2c4f9f90eb");
            result.Status.ShouldBe("6ede1fc576db4018ba5a197e88d884a531aaa16d9a3e46888f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobAppliesAppService.DeleteAsync(Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"));

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == Guid.Parse("99367996-2cdf-4c2f-81d3-3a780f32c40c"));

            result.ShouldBeNull();
        }
    }
}