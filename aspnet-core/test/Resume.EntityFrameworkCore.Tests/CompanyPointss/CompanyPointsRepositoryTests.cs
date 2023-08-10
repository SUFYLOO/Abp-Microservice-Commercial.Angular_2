using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyPointss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyPointss
{
    public class CompanyPointsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyPointsRepository _companyPointsRepository;

        public CompanyPointsRepositoryTests()
        {
            _companyPointsRepository = GetRequiredService<ICompanyPointsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyPointsRepository.GetListAsync(
                    companyMainId: Guid.Parse("68da8702-f644-4ff9-bb74-deb1560b0532"),
                    companyPointsTypeCode: "6813eb0b0d9c45f88773636ae070b3563b8f4dab29a34438b2",
                    extendedInformation: "3005f41392484ddb8bdfb2cd436d8521426711657c4c4b7bbc04fa934ae02233335451450e244e73803f16037fc947f8cf2e5e0866e14883997d544bac95596d3fdf4db41d9147baa4575875ad69a6cc545cd9b1a66c42cdba9f63e628e6bd3f87a52837080b4b4a99ae5dc864e30863d07004b4b649497fa04ca840b85c15cb1c1016bfac91476e933e0568690f7fbc7d5367f185b44513a699ccce233f6cdcdf44c2ba1a744ce5b6b6464c361b8973c95277f43ed74dce9f352c386e28cc0dd4edb1f387ff4c9a91f6b5eb2e2e396f9b2690a1b2fe42c589fbab20a898e2436a1bb2006cbe439e96bf67a5f3f83f19a7bb0c15cb1b44fc8c31",
                    note: "bb480e6844c446e3b0589799e539d67b726ea85d5d9d4094915ee02d73dc72348b05d435b3e04d789f1a0358e7408f30c3764a3dd35f4b939d545f75dac06a45857b8e2668904796b41614aa4474e8155e9a20ba99c64040a2e8a6c00b0ee8a8487601eaed3f4080bd7150b8c090af5e21892543b0994c339fd40e219c3eba8930ca5c7993e242f0a825efe7c37c23561f24761705154b5398051fb991343dbd842672c90d9545f2a3e616ad92744c27271ead5b8b6a464089f73e90b60b5dd444f5970fb95348d2a1c10910aac7917cbf5f27a7c0c943e98fa2b1030d3efa7ea87b0bed89054d6f9090395c13e08b84b336c4d8de8c4fca9c02",
                    status: "2780a6e4950646569c4c5f330f32fda8c9510e5f082a4a7197"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c7ad5219-1a51-4ee0-9663-867bf7ab0577"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyPointsRepository.GetCountAsync(
                    companyMainId: Guid.Parse("8f5568be-8f60-4ba7-a52c-22b067158b2f"),
                    companyPointsTypeCode: "7500757e62f34469a3c6d2b64e422eac9e94b0de7c1c40678e",
                    extendedInformation: "b870ed6ad5c1496da5aa1101566c73e29c398fb1643e4685b6d7f9590df8eccb92c42083473c4e93899c0b91685b65e8e56b74565c76436ba04eda428f67b5ab6d66f979c6ed410c9ced4f6462f6f247d213ed2c688c4099b7e9e75b99181682636fc12e8c6643acb62fef83445e98b017b7f433fb9a4a599cbbe917101c0809c53edf38dc404938a3512d4d503ed15a442702c14d924241b1a96c4156abf2b78e706816fb4f4b09b6dd19e05d29224d9bb037f68d24431e8b9935bab0aab54e43dcdb3d539a49e895ca4e70d9bfd40497858a34d8ed4a59a9f7563cd5ec21ae7dd8bfa3cbde49eab28e8dc9fa32a19c433f0a04e3bb4283a98f",
                    note: "d9388d9eca00424385366643557010aa37b682ce8510409bad76256548d9eb9642a5844f0a0347868343e56c51f0a16a0a7698ee903e47afa9cf3b1dad91c7fe5886d4119a3e4e1fafa6b1c6a449368084be6334b14041b7aaa75a3d86894a7d2e72aa6f7159421ea0d61bee59678659d9d3db5d3f3b4d32832b5732d26652ab0914d5788d654c2aacb2aaf1ec0c2a9cf26ba7ac9d3b4bd9b714abb734d5ee91e3929cc5c04c4b00ac3f481251c2200772bcc7597e854e9797007582a032dfb56560b8810e1b487eb2da4ee0e79a0aba27acfdbc0dd04c5fbb7c994211410b319a86ade7147b4889bfd2339aa9357102936c8db680a34b24898f",
                    status: "44584c4724944174af28df3985d8038b24795db2839a429f8a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}