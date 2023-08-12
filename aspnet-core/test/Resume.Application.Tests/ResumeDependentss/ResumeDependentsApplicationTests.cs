using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeDependentssAppService _resumeDependentssAppService;
        private readonly IRepository<ResumeDependents, Guid> _resumeDependentsRepository;

        public ResumeDependentssAppServiceTests()
        {
            _resumeDependentssAppService = GetRequiredService<IResumeDependentssAppService>();
            _resumeDependentsRepository = GetRequiredService<IRepository<ResumeDependents, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeDependentssAppService.GetListAsync(new GetResumeDependentssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f2e47ea1-6500-4d50-879d-6af25cd3002d")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeDependentssAppService.GetAsync(Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeDependentsCreateDto
            {
                ResumeMainId = Guid.Parse("fb07f8e9-cd73-4ee6-bb70-4d7e707b3edd"),
                Name = "e563223aaf9f46829f00a62b14509269842c117d75d84f2f93",
                IdentityNo = "ac8f1d4eb36c45ec998c7dd3e0137723e3326eefe0ea433b8d",
                KinshipCode = "dd03336abba24e889a4a2416784447f7b2519ca22cd644918e",
                BirthDate = new DateTime(2006, 4, 2),
                Address = "162237268b074c5eafbc11663a24a31c871c6cac525741e095d966132ab720ebd48efad8081f49cabe8374aa445e705acf193aab476a4e2a99e152a569b7b02e031fbb230e984449b744c4bc06cabeb11495e387a04b489689ec7cd0976444deec200cf2",
                MobilePhone = "3e173b9674b64e18abe8c18fba2bee8c63e14b3132d14c4eaa",
                ExtendedInformation = "d4ab030bfeb74c17ba05db1dbfd45cb0041296e2facb458fa9ada85d134d06340bacb86810284edfbbace7cbefd7f71a7b7d57833dfb482f831002562f30f8503572daca4dc444a09377161a28159c0c15b79d17a0c74922a6f1611dea4b76c259a3434447064cc48f3a4d625832068c343de949e7d748de97165a20fd7d625e0ff51a4e4caa4637ba146b384975b33db73fddc6bcb7423a8ff22afd4833aadf3d1fd900bd6141e086ca46046928baf42e41b3e0282845e2ae30017df4b8d22a0322b63451284179b0a76c00b37309e27bb542b30e974e1599da6fc02275a44dd556c8e4cded4d81883804d6bb6ad4c1e1d56a1ce36c48bfbf02",
                DateA = new DateTime(2000, 4, 25),
                DateD = new DateTime(2015, 4, 22),
                Sort = 642618111,
                Note = "e065541a48c241838f03a681e00a6e2f4c5ff786b52c4ef79aeaa8d7a1c0a01e04819c6766504f39ad15e50019446fdf5488263fb1cb4645bdab29c3237cc94cdec1b6c0e5ea4c788d1ae8895af64d54bdc370ea599d49778de0de848e50b59a01f1c3c663544335b9d04468b059712af75c00c99cbb456e9bc461ff023a64bc28e2a069af0c462690394af2a03b1ee320dca20aae32418695f1ce8fae687d8089ce5dfe967b474380d468e8ade504c58072507522fa414f83e6dec7686ac7a3b2fac4606feb4c07a4ff3351fe64a305a8d8201a92444b1e85eab82fb8a1bdf194d3918c57e943ff8cf70eacf78e0bd4f1212375cb04496182a9",
                Status = "b900d62bf1744affb77e9f02f7a0f0d7f49139206d544e0caf"
            };

            // Act
            var serviceResult = await _resumeDependentssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("fb07f8e9-cd73-4ee6-bb70-4d7e707b3edd"));
            result.Name.ShouldBe("e563223aaf9f46829f00a62b14509269842c117d75d84f2f93");
            result.IdentityNo.ShouldBe("ac8f1d4eb36c45ec998c7dd3e0137723e3326eefe0ea433b8d");
            result.KinshipCode.ShouldBe("dd03336abba24e889a4a2416784447f7b2519ca22cd644918e");
            result.BirthDate.ShouldBe(new DateTime(2006, 4, 2));
            result.Address.ShouldBe("162237268b074c5eafbc11663a24a31c871c6cac525741e095d966132ab720ebd48efad8081f49cabe8374aa445e705acf193aab476a4e2a99e152a569b7b02e031fbb230e984449b744c4bc06cabeb11495e387a04b489689ec7cd0976444deec200cf2");
            result.MobilePhone.ShouldBe("3e173b9674b64e18abe8c18fba2bee8c63e14b3132d14c4eaa");
            result.ExtendedInformation.ShouldBe("d4ab030bfeb74c17ba05db1dbfd45cb0041296e2facb458fa9ada85d134d06340bacb86810284edfbbace7cbefd7f71a7b7d57833dfb482f831002562f30f8503572daca4dc444a09377161a28159c0c15b79d17a0c74922a6f1611dea4b76c259a3434447064cc48f3a4d625832068c343de949e7d748de97165a20fd7d625e0ff51a4e4caa4637ba146b384975b33db73fddc6bcb7423a8ff22afd4833aadf3d1fd900bd6141e086ca46046928baf42e41b3e0282845e2ae30017df4b8d22a0322b63451284179b0a76c00b37309e27bb542b30e974e1599da6fc02275a44dd556c8e4cded4d81883804d6bb6ad4c1e1d56a1ce36c48bfbf02");
            result.DateA.ShouldBe(new DateTime(2000, 4, 25));
            result.DateD.ShouldBe(new DateTime(2015, 4, 22));
            result.Sort.ShouldBe(642618111);
            result.Note.ShouldBe("e065541a48c241838f03a681e00a6e2f4c5ff786b52c4ef79aeaa8d7a1c0a01e04819c6766504f39ad15e50019446fdf5488263fb1cb4645bdab29c3237cc94cdec1b6c0e5ea4c788d1ae8895af64d54bdc370ea599d49778de0de848e50b59a01f1c3c663544335b9d04468b059712af75c00c99cbb456e9bc461ff023a64bc28e2a069af0c462690394af2a03b1ee320dca20aae32418695f1ce8fae687d8089ce5dfe967b474380d468e8ade504c58072507522fa414f83e6dec7686ac7a3b2fac4606feb4c07a4ff3351fe64a305a8d8201a92444b1e85eab82fb8a1bdf194d3918c57e943ff8cf70eacf78e0bd4f1212375cb04496182a9");
            result.Status.ShouldBe("b900d62bf1744affb77e9f02f7a0f0d7f49139206d544e0caf");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeDependentsUpdateDto()
            {
                ResumeMainId = Guid.Parse("98071a8d-52b3-46bf-a95f-518a2c198b43"),
                Name = "37915419b18e4af1b6e9b0dcd2924aca4f5b8758aa4445e68d",
                IdentityNo = "7ae10155df484e86bb0ff1b74fbc31c25aabb53e90044a53b1",
                KinshipCode = "73c392e3a3014502b4ef70ec95c85ea40e1fc06f57d44285b2",
                BirthDate = new DateTime(2019, 8, 8),
                Address = "3605d9f90aee4416b9c5d88001295912bfc65120cb3d41af8b1eb9073ed4ac70f4965100c3634dc1aaf27a7f0c77d824f4b346b564a64bfc9afbb6d1de2c0b0dfd97f0c106fb45c6bae0c34daadaf6bbcd95530792c24f1895e2f2bbc44b1085dbc05c0d",
                MobilePhone = "2320922f78574e2cb122e011c29c401ddccc56b253aa4dd8ae",
                ExtendedInformation = "6c577d87a08646478987f002ea02ee2d3104e9c595e04e08bbc46c343051cd0fcf4250ee93124d2f81bf7c8546c0c4fff9dbbf4c0b164808bd1d3cc43029acce6e5141776745454dbe41b04115bc7e765ba0b31478b54d9e907b3b77489de673a99b3a3ccb1e482d918e65da7ddf9e55b760d9f4f93f40a0a0c04cba5631ca2a7c3c932159604edfb74a3fe8e8b3457a533c400124b94748b0a449da1736ba4d7250fb34e4944f088ae702055e3888c86fde7b6efcad4736ab8f35203a23de8693639738775e4e0a8460c6a8df8715d0941f2a341fd14912bd0956dbe9b43a1816d5267995d4424090edb60e271b4e46216d05caf73541798033",
                DateA = new DateTime(2021, 6, 7),
                DateD = new DateTime(2019, 7, 1),
                Sort = 1398557328,
                Note = "64eff804e1f747d0b248b395d499049a622357ef052147f9b4e5659a1f155c43b3d0f0ad2fcb425ba7ecb712a95403c31554b7b69dca4f9e8d1f05de994e614ae1d0a41c6ce34d27bd225308a9cbf08a15c4c29d863c462aa109cf7db23124a64e74dfe3796a48cdab1a690f19a36faf99701e60689b440699e47e78643d47b52b1527a7b13e4467bf8b5483035e8274a5becac09fa14cc28a5c8128598b2ad4d4a2cf5a40784841a035c5b735e5bee077a9d52d9c094869a58841e37d131eb62dcc86a2c6404955a841128eb0ce1957fabcbc722fd745dcaba9b1e9b239a0f7b7f9190b71b345129f0e64099801e6cf56e739dd47894a488f55",
                Status = "3405c461278f47479a8dc18263ea588dc0a5cd7eddf1417187"
            };

            // Act
            var serviceResult = await _resumeDependentssAppService.UpdateAsync(Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"), input);

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("98071a8d-52b3-46bf-a95f-518a2c198b43"));
            result.Name.ShouldBe("37915419b18e4af1b6e9b0dcd2924aca4f5b8758aa4445e68d");
            result.IdentityNo.ShouldBe("7ae10155df484e86bb0ff1b74fbc31c25aabb53e90044a53b1");
            result.KinshipCode.ShouldBe("73c392e3a3014502b4ef70ec95c85ea40e1fc06f57d44285b2");
            result.BirthDate.ShouldBe(new DateTime(2019, 8, 8));
            result.Address.ShouldBe("3605d9f90aee4416b9c5d88001295912bfc65120cb3d41af8b1eb9073ed4ac70f4965100c3634dc1aaf27a7f0c77d824f4b346b564a64bfc9afbb6d1de2c0b0dfd97f0c106fb45c6bae0c34daadaf6bbcd95530792c24f1895e2f2bbc44b1085dbc05c0d");
            result.MobilePhone.ShouldBe("2320922f78574e2cb122e011c29c401ddccc56b253aa4dd8ae");
            result.ExtendedInformation.ShouldBe("6c577d87a08646478987f002ea02ee2d3104e9c595e04e08bbc46c343051cd0fcf4250ee93124d2f81bf7c8546c0c4fff9dbbf4c0b164808bd1d3cc43029acce6e5141776745454dbe41b04115bc7e765ba0b31478b54d9e907b3b77489de673a99b3a3ccb1e482d918e65da7ddf9e55b760d9f4f93f40a0a0c04cba5631ca2a7c3c932159604edfb74a3fe8e8b3457a533c400124b94748b0a449da1736ba4d7250fb34e4944f088ae702055e3888c86fde7b6efcad4736ab8f35203a23de8693639738775e4e0a8460c6a8df8715d0941f2a341fd14912bd0956dbe9b43a1816d5267995d4424090edb60e271b4e46216d05caf73541798033");
            result.DateA.ShouldBe(new DateTime(2021, 6, 7));
            result.DateD.ShouldBe(new DateTime(2019, 7, 1));
            result.Sort.ShouldBe(1398557328);
            result.Note.ShouldBe("64eff804e1f747d0b248b395d499049a622357ef052147f9b4e5659a1f155c43b3d0f0ad2fcb425ba7ecb712a95403c31554b7b69dca4f9e8d1f05de994e614ae1d0a41c6ce34d27bd225308a9cbf08a15c4c29d863c462aa109cf7db23124a64e74dfe3796a48cdab1a690f19a36faf99701e60689b440699e47e78643d47b52b1527a7b13e4467bf8b5483035e8274a5becac09fa14cc28a5c8128598b2ad4d4a2cf5a40784841a035c5b735e5bee077a9d52d9c094869a58841e37d131eb62dcc86a2c6404955a841128eb0ce1957fabcbc722fd745dcaba9b1e9b239a0f7b7f9190b71b345129f0e64099801e6cf56e739dd47894a488f55");
            result.Status.ShouldBe("3405c461278f47479a8dc18263ea588dc0a5cd7eddf1417187");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeDependentssAppService.DeleteAsync(Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"));

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"));

            result.ShouldBeNull();
        }
    }
}