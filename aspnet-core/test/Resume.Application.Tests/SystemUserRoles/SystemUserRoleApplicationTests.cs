using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemUserRoles
{
    public class SystemUserRolesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemUserRolesAppService _systemUserRolesAppService;
        private readonly IRepository<SystemUserRole, Guid> _systemUserRoleRepository;

        public SystemUserRolesAppServiceTests()
        {
            _systemUserRolesAppService = GetRequiredService<ISystemUserRolesAppService>();
            _systemUserRoleRepository = GetRequiredService<IRepository<SystemUserRole, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemUserRolesAppService.GetListAsync(new GetSystemUserRolesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("d2f74e71-88db-4480-9ab3-8bafb90c9d5b")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemUserRolesAppService.GetAsync(Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemUserRoleCreateDto
            {
                Name = "593eeb396822465ab1a67fc0bdd81c70c8d0e2b3fba74eaeb7",
                Keys = 1256377594,
                ExtendedInformation = "2077e8ff62664d1ba777310af06484e8751b2cd733cb42cfbb12042830a4ff9898923b8ba6e749bfa8e9a54611e47f1c15a6f20e02fd43ee86461b881d850b93018ee7dea68748208c9cb0f27bade8d4ee13822c9f304d89a9a1b82b074e006c9dab278744094c1c9873dd36bebef7c12b2a870338534e2f92ffb2284240fbc3486bf46891464579adedbee7720172b6472be96871a74cab8a72bbc0d923085f2628d141a491401081fd6d7ad6da40041c337027689446f4876833c7fe9530869d3bdebe534f4d9fb4378df4ea8291c6f68580d8a6fa46d1bb4587e039ef28748a2fae84a3dc438b9007f97d7c8231046f433d63c40047f6b93e",
                DateA = new DateTime(2013, 7, 27),
                DateD = new DateTime(2003, 1, 15),
                Sort = 225398351,
                Note = "81e59420e0b143089d809f5b86d1180a83bf5d1057614367a9fd7896a58eccf954bc2ae18c9a408c80c782b663733d30e4f60154ff2849278561a3bd3e66f99c66e5ba9fbf704773b6ba236079e7e36cb3a293cdde1a4187923360415fad84f43df0420d0930497a82dbe843a061712f30e0d2c4d9f74789a6dbb96b1e512c16b925c58d71974addaf293104a0a231c567b13a647d84482183ba22083cc62334128da7c5e7ea4f3d82ce14d8ef8e99a0f74c803f307b49249ec4da9f6f2160790672215667654e28b032a9c32102f86cf33b27232fdf42909332de5d17350af645f942f7e04d44a4916fe71c4e7cbeae8faacd1ff6cf4c7fadb2",
                Status = "a653114e431248819db3490a75343b4bb8d76a92a62f4df188"
            };

            // Act
            var serviceResult = await _systemUserRolesAppService.CreateAsync(input);

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("593eeb396822465ab1a67fc0bdd81c70c8d0e2b3fba74eaeb7");
            result.Keys.ShouldBe(1256377594);
            result.ExtendedInformation.ShouldBe("2077e8ff62664d1ba777310af06484e8751b2cd733cb42cfbb12042830a4ff9898923b8ba6e749bfa8e9a54611e47f1c15a6f20e02fd43ee86461b881d850b93018ee7dea68748208c9cb0f27bade8d4ee13822c9f304d89a9a1b82b074e006c9dab278744094c1c9873dd36bebef7c12b2a870338534e2f92ffb2284240fbc3486bf46891464579adedbee7720172b6472be96871a74cab8a72bbc0d923085f2628d141a491401081fd6d7ad6da40041c337027689446f4876833c7fe9530869d3bdebe534f4d9fb4378df4ea8291c6f68580d8a6fa46d1bb4587e039ef28748a2fae84a3dc438b9007f97d7c8231046f433d63c40047f6b93e");
            result.DateA.ShouldBe(new DateTime(2013, 7, 27));
            result.DateD.ShouldBe(new DateTime(2003, 1, 15));
            result.Sort.ShouldBe(225398351);
            result.Note.ShouldBe("81e59420e0b143089d809f5b86d1180a83bf5d1057614367a9fd7896a58eccf954bc2ae18c9a408c80c782b663733d30e4f60154ff2849278561a3bd3e66f99c66e5ba9fbf704773b6ba236079e7e36cb3a293cdde1a4187923360415fad84f43df0420d0930497a82dbe843a061712f30e0d2c4d9f74789a6dbb96b1e512c16b925c58d71974addaf293104a0a231c567b13a647d84482183ba22083cc62334128da7c5e7ea4f3d82ce14d8ef8e99a0f74c803f307b49249ec4da9f6f2160790672215667654e28b032a9c32102f86cf33b27232fdf42909332de5d17350af645f942f7e04d44a4916fe71c4e7cbeae8faacd1ff6cf4c7fadb2");
            result.Status.ShouldBe("a653114e431248819db3490a75343b4bb8d76a92a62f4df188");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemUserRoleUpdateDto()
            {
                Name = "eb97560c507049ab86b518e110a8a2f254860a140dfa483aa3",
                Keys = 1854792885,
                ExtendedInformation = "0e6337edf0ee466d899e0dc156c49ed6942cf02c801942ada3d34e7eccc74c948216e0b830f345f286f78406e19c915cc9db7aca4fd243a68ddd2693d3dbd7da8a6f7656c922488287d970e46835eb7c8fdabffba2a0485098e9c27870b2bc4dde1bfbb0e6e64e1394ac709849295ad8f60b87975d8c47259cabbbaa54421da71bc54a55e3854426857eee0367b987a41a3a685b679349b2bba88c7836f9da860d452e402f2649d6b3040685915b81d7b25af0efa8794c3abc23cb2209b9d3d04fed453d242f4963b80cdc091d75a250f5196df87777428aae61b068c3e56e8e9b4c38f028ff420d858ee893aa6b717dc2833e8e6eee469a8a09",
                DateA = new DateTime(2015, 8, 6),
                DateD = new DateTime(2015, 6, 4),
                Sort = 676335466,
                Note = "59f958cbf25643bf923d246bb087412271035018fade438889b21cff828b0c4112a64c9e74e744028369aef9fcb3c56d829c9bb026ff498bba3293c14bb0e1caa42f6237f0c84aa8b1ba75a7a8c60405c9fcc25b540c454d90ea5ebc821a9c643c76f96a71194b0fa136dbd7f4b30eb6448e1b57ed5d4bdf9c454eec9d6e59212b87469c36824e21a1aca23c067aaaf27a2b09756ce54713a2c54a5d6fbdf20e131e3640959a4a8daa1e81129833308409e822bb541e49e5bbecf19d1b1f20239fc5d63bc5d6427ea42a4130ce77c5626242d2ceb0b64c85bf4691856bd656591c3b60f77af241c5b4099db0b48e0bf253e0aec9406c4370bb48",
                Status = "da471dabec2c49f89c187c66f804ebc9fda160c92e694762b3"
            };

            // Act
            var serviceResult = await _systemUserRolesAppService.UpdateAsync(Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"), input);

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("eb97560c507049ab86b518e110a8a2f254860a140dfa483aa3");
            result.Keys.ShouldBe(1854792885);
            result.ExtendedInformation.ShouldBe("0e6337edf0ee466d899e0dc156c49ed6942cf02c801942ada3d34e7eccc74c948216e0b830f345f286f78406e19c915cc9db7aca4fd243a68ddd2693d3dbd7da8a6f7656c922488287d970e46835eb7c8fdabffba2a0485098e9c27870b2bc4dde1bfbb0e6e64e1394ac709849295ad8f60b87975d8c47259cabbbaa54421da71bc54a55e3854426857eee0367b987a41a3a685b679349b2bba88c7836f9da860d452e402f2649d6b3040685915b81d7b25af0efa8794c3abc23cb2209b9d3d04fed453d242f4963b80cdc091d75a250f5196df87777428aae61b068c3e56e8e9b4c38f028ff420d858ee893aa6b717dc2833e8e6eee469a8a09");
            result.DateA.ShouldBe(new DateTime(2015, 8, 6));
            result.DateD.ShouldBe(new DateTime(2015, 6, 4));
            result.Sort.ShouldBe(676335466);
            result.Note.ShouldBe("59f958cbf25643bf923d246bb087412271035018fade438889b21cff828b0c4112a64c9e74e744028369aef9fcb3c56d829c9bb026ff498bba3293c14bb0e1caa42f6237f0c84aa8b1ba75a7a8c60405c9fcc25b540c454d90ea5ebc821a9c643c76f96a71194b0fa136dbd7f4b30eb6448e1b57ed5d4bdf9c454eec9d6e59212b87469c36824e21a1aca23c067aaaf27a2b09756ce54713a2c54a5d6fbdf20e131e3640959a4a8daa1e81129833308409e822bb541e49e5bbecf19d1b1f20239fc5d63bc5d6427ea42a4130ce77c5626242d2ceb0b64c85bf4691856bd656591c3b60f77af241c5b4099db0b48e0bf253e0aec9406c4370bb48");
            result.Status.ShouldBe("da471dabec2c49f89c187c66f804ebc9fda160c92e694762b3");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemUserRolesAppService.DeleteAsync(Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"));

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"));

            result.ShouldBeNull();
        }
    }
}