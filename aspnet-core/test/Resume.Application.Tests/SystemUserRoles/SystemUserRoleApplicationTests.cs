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
            result.Items.Any(x => x.Id == Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("1c99b465-630c-46c2-9f85-677c2c7c70bf")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemUserRolesAppService.GetAsync(Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemUserRoleCreateDto
            {
                Name = "88f8f19c03934dd4aa14d6d138050f6be3cac08179004e068b",
                Keys = 1226276079,
                ExtendedInformation = "3d7c0212bb1c42698cecbb838f25115a88feb10e9fc9438b9667f51a6e2df5e0c6c49c9df26142e1801c77200b3e37c7934ef1f57bfb49e2bf0f0c8d8b80d711c84c578f6b5040df9ccb7ac7b75b41c91cb3e919fd9e4ecb85162b4f646dd2229674f082c349433a9250553306b47f123aabc2c7cc3143d2bfe8e9b1e3a9691505d10e7657604823ae0e8973fe2bc7d0f084c4b44129472d92df18f7f5204f32dfee1b166d7545c084ab13ea09cc5de83dd1173fdd5a42f58cf2ace356564c2b60a2a7abe4474d36a9849e7a072673a98dce6528168348668da35290c85886abf6cec0ada5ea4dffbd302ea892ee441156cc0d1eecd148118288",
                DateA = new DateTime(2013, 8, 23),
                DateD = new DateTime(2017, 10, 6),
                Sort = 297871055,
                Note = "a8180852679e4c3b847a040ae1af19d41271ec15f1d54b1fba7739a07c2e3728f185eb62a9cb470ca01b0b9753d67e90e9fcc7a5929f47f58d19512e282f779483349e2f3d994e59a2f07e8833d54fbc95a63bea44a74c51956b29638b7f1b385aa33d15ba9f4dee9c430af6f4780d5c4d284a3c44524de7a7652bd696dc3bf1c143eeccd39c4748a3ce26ff43ecae0f6bedc9012be942bcbd45ca553cb2c80476d42f9fdc6a458ca2f229521af3685d6a0dddacc1d94a6188b731fcc68d668dc1b1054e23f44c87be53a0aa88d46bd3b83137e1432a491d91253cb356f0e51909e02e705b074628821e67c9661e9f37552f88a2891c4e3ba2ed",
                Status = "bdfcc46fe11340bab1540c6ba50607e95a19dc090c0d4453a4"
            };

            // Act
            var serviceResult = await _systemUserRolesAppService.CreateAsync(input);

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("88f8f19c03934dd4aa14d6d138050f6be3cac08179004e068b");
            result.Keys.ShouldBe(1226276079);
            result.ExtendedInformation.ShouldBe("3d7c0212bb1c42698cecbb838f25115a88feb10e9fc9438b9667f51a6e2df5e0c6c49c9df26142e1801c77200b3e37c7934ef1f57bfb49e2bf0f0c8d8b80d711c84c578f6b5040df9ccb7ac7b75b41c91cb3e919fd9e4ecb85162b4f646dd2229674f082c349433a9250553306b47f123aabc2c7cc3143d2bfe8e9b1e3a9691505d10e7657604823ae0e8973fe2bc7d0f084c4b44129472d92df18f7f5204f32dfee1b166d7545c084ab13ea09cc5de83dd1173fdd5a42f58cf2ace356564c2b60a2a7abe4474d36a9849e7a072673a98dce6528168348668da35290c85886abf6cec0ada5ea4dffbd302ea892ee441156cc0d1eecd148118288");
            result.DateA.ShouldBe(new DateTime(2013, 8, 23));
            result.DateD.ShouldBe(new DateTime(2017, 10, 6));
            result.Sort.ShouldBe(297871055);
            result.Note.ShouldBe("a8180852679e4c3b847a040ae1af19d41271ec15f1d54b1fba7739a07c2e3728f185eb62a9cb470ca01b0b9753d67e90e9fcc7a5929f47f58d19512e282f779483349e2f3d994e59a2f07e8833d54fbc95a63bea44a74c51956b29638b7f1b385aa33d15ba9f4dee9c430af6f4780d5c4d284a3c44524de7a7652bd696dc3bf1c143eeccd39c4748a3ce26ff43ecae0f6bedc9012be942bcbd45ca553cb2c80476d42f9fdc6a458ca2f229521af3685d6a0dddacc1d94a6188b731fcc68d668dc1b1054e23f44c87be53a0aa88d46bd3b83137e1432a491d91253cb356f0e51909e02e705b074628821e67c9661e9f37552f88a2891c4e3ba2ed");
            result.Status.ShouldBe("bdfcc46fe11340bab1540c6ba50607e95a19dc090c0d4453a4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemUserRoleUpdateDto()
            {
                Name = "fb418697bfbd4ad48e03fa99daeacc8d2bbfe7ac4d064cf1a6",
                Keys = 1264768499,
                ExtendedInformation = "9ec4147c0bce4cbdacb4de9dc3f4b6f7dc9cf9986ac54049ac5f8bce2025738eefe95b611dc14734a59cc0f3acc5190509d07d35749340df8f73c920607556483bbabe52a1ae4e66907b66cdc203e44e25ab629051164ff1b2bbc301dd16b7b7fb96c66925a74b4ca473268e20f8c832dedc74dbd21442e3aaca723af422eb448271d1637df74ab996e417396b1902ba4f01e2a12d064cfe84277c5d61a42c5f323c25079ca144f590ac2cbbf2b272615e514380af9049268502f82039a367cf9b3fb914ae764c5fb02906f9217729271b5ff466d63b4ee39cf92ca3dcb9f04772fa90d5470f49468e9386ddf9dea838874f2c9756f7464688a0",
                DateA = new DateTime(2002, 3, 12),
                DateD = new DateTime(2013, 1, 6),
                Sort = 93235414,
                Note = "50390bdbd2db4511b7e347e648ca2c4438a5ff93803e42b49b3fdadc02747363a24cd773134e4646b4905322807a03b177a036a0549d426fa9d8aa35710b017b5aa132b0683d425b8ae21b6b2f7c9d87cf23d3b0783f41b9b5c7d92bf1a3e055c61d91e3e7b34d4790b21da7f68e3f90bf51933490124a098c3d57cf3cf4cf3d1f438955cc24429c842b763dfbdc3739165b97fab04f40e490074cf2eecc24387056bd58fa64444db4914bf4612e0b4d556a28c2aa344a07b6dfb0b1a9f0e2c04b4abff329c6450e878487a51de63388939540db504c451cb9c5b0009761cae1ab1ade1beb114c73816262967bd7db7a391f2f410be64d4ab969",
                Status = "215a25d7e7384fe39987db410bbf3f418e1caa9868874f9aa5"
            };

            // Act
            var serviceResult = await _systemUserRolesAppService.UpdateAsync(Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"), input);

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("fb418697bfbd4ad48e03fa99daeacc8d2bbfe7ac4d064cf1a6");
            result.Keys.ShouldBe(1264768499);
            result.ExtendedInformation.ShouldBe("9ec4147c0bce4cbdacb4de9dc3f4b6f7dc9cf9986ac54049ac5f8bce2025738eefe95b611dc14734a59cc0f3acc5190509d07d35749340df8f73c920607556483bbabe52a1ae4e66907b66cdc203e44e25ab629051164ff1b2bbc301dd16b7b7fb96c66925a74b4ca473268e20f8c832dedc74dbd21442e3aaca723af422eb448271d1637df74ab996e417396b1902ba4f01e2a12d064cfe84277c5d61a42c5f323c25079ca144f590ac2cbbf2b272615e514380af9049268502f82039a367cf9b3fb914ae764c5fb02906f9217729271b5ff466d63b4ee39cf92ca3dcb9f04772fa90d5470f49468e9386ddf9dea838874f2c9756f7464688a0");
            result.DateA.ShouldBe(new DateTime(2002, 3, 12));
            result.DateD.ShouldBe(new DateTime(2013, 1, 6));
            result.Sort.ShouldBe(93235414);
            result.Note.ShouldBe("50390bdbd2db4511b7e347e648ca2c4438a5ff93803e42b49b3fdadc02747363a24cd773134e4646b4905322807a03b177a036a0549d426fa9d8aa35710b017b5aa132b0683d425b8ae21b6b2f7c9d87cf23d3b0783f41b9b5c7d92bf1a3e055c61d91e3e7b34d4790b21da7f68e3f90bf51933490124a098c3d57cf3cf4cf3d1f438955cc24429c842b763dfbdc3739165b97fab04f40e490074cf2eecc24387056bd58fa64444db4914bf4612e0b4d556a28c2aa344a07b6dfb0b1a9f0e2c04b4abff329c6450e878487a51de63388939540db504c451cb9c5b0009761cae1ab1ade1beb114c73816262967bd7db7a391f2f410be64d4ab969");
            result.Status.ShouldBe("215a25d7e7384fe39987db410bbf3f418e1caa9868874f9aa5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemUserRolesAppService.DeleteAsync(Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"));

            // Assert
            var result = await _systemUserRoleRepository.FindAsync(c => c.Id == Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"));

            result.ShouldBeNull();
        }
    }
}