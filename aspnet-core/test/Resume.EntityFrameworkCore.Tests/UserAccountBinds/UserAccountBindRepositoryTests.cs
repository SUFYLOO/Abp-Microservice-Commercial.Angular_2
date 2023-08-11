using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserAccountBinds;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserAccountBindRepository _userAccountBindRepository;

        public UserAccountBindRepositoryTests()
        {
            _userAccountBindRepository = GetRequiredService<IUserAccountBindRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userAccountBindRepository.GetListAsync(
                    userMainId: Guid.Parse("da6ebd8f-0e74-4cd4-9942-ba18b1faf6b8"),
                    thirdPartyTypeCode: "b5dee5173c394a8a9c68e00b89b31d20ac9848af293f416ba0",
                    thirdPartyAccountId: "4c625d9ac18443f487890bb8cafa5dbea529fa22effe4d5fa8",
                    extendedInformation: "6f24e65b74a04a10bf463d9be88f770d8717490e0ff04c1aa133415517f9c38dceb7c5f4ce9e450881b735740744f4d00310035f3840413db8515ec06a1d0c13a2cbc17cdc89426bbecefb20c50a803dbc487911ede54af7a323688ffcf03cc861203b7203514cd0a4a69f3469d0c4250516b00d4aeb48af97c23b64259ce4e852d659e83fc84787b8e7844444440675c28c583c982f4b09bf28905cb1307ee92df727dced824de7b6fa747d9972b3a643c5101203204112b4d60492afdd5ea19bf5d07abd674f929233c0bd668fd252e8c52f248ff540928844e2ad710b55f9ca58ffd1feff487d93bce31605e5fb2a4c6a1dad956f4bb69660",
                    note: "7661e1a8272b41d483516c00079a09316b7ceb4423304b9f96f3c44c3189f943a560bb06a2374b1bb10da828bee6a03ab3e1b8c205f242a3b3e802e68dab6cd17d669a91621a49158f20ab5b6c9e739e85fec6df212d46a9b85db9952da7a43e170f9e586ad24dcc991e1d0cb243d976f275405b46e540f38184109801bf504203e67100da2d40b5bb33931b00ed95d9c533438350624d698792265d8dddb5a1d2edf894190c4eaf8ae59c24453a596cb101aae39ba24b7da11ca33f4dfca80412b736db041a4851b896c72418b728f51e9c1fefd4c84d398294d0a73e110b613ceb50cb2c9f48c7962846495012ca8b41b10bfa17bf4269b69a",
                    status: "f8d0f438309848fbac20dc00ed677b395f211fa71e5a4b5db8"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userAccountBindRepository.GetCountAsync(
                    userMainId: Guid.Parse("b60227f4-2a2a-491d-9148-3c7593f37e3d"),
                    thirdPartyTypeCode: "8e8de2e8279946b59759b7de3a3a432caf73b71f96614d73bf",
                    thirdPartyAccountId: "f3b20d6fecb44939acfd0862c74c48e7ad5b5f0db3c44dbc83",
                    extendedInformation: "bef40cfb8f1842729547cae5577d1b340aada54eef984d1babfea8e26c4630096dfaa14cffd543639550d2090a92b897b70246b34dfe47a7a49100dff6700647aa3d8238d92f490d81f64b1e8364a1e7ca85fa9b2c99486bb505f5163f0efb8aee2f30d031ff45caa0fe56a6dd6395337b74d99e8f5a438bab830f0f38e790fa84eeb4404803451f8b46c469f098daf35bd86b2b5f324d02a60d169dd53292dd55e51bc782a44ef9bd33538e5a28df295c7a25d24ad5420f86dac8d8b0f70549b9e4cd6a035241ed99c32b39154d2df012df566366e94071b9616bd8542c9a9aaafbd3ab5e754171bfd2a6a8c06a63c2af5898a1891a4811bd7d",
                    note: "77b787e07bd44dd2bf1b0bce46500bee81519702c94645e1ac6f7456fad47f33efb30173f6ac4004afe7fca83bbd30183bd40e52a8e1449384457893aff38adf8f6cc6366c8c46a483ac42dba88657359e81354ee88d4796a55f7efdb805f9fe14ebb29287ca431eab06ca6453db624f265558790edf4ea8990038b3c925b1c0ded04faf97fd4ec18d3eb8a6460af8c0045643fcdd4f4bbfbaa8f174e6207e8007f0fa547f8b4e4f8b1875ffc7d50421ee5e7383cb8148599abb7a7c5105ceae8a94cad69ea34b82b222bebd3335ea55eeda33dfb5374fb4b12d768835a632db9d217ff6289b4fd39b49a7feca51a8c248b2c14329d14b09a4f5",
                    status: "d5075f3242ff4235a6bba63bff560835fd57a3fbeabe40739b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}