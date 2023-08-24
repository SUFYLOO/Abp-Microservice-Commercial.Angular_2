using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobDisabilityCategories;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoryRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobDisabilityCategoryRepository _companyJobDisabilityCategoryRepository;

        public CompanyJobDisabilityCategoryRepositoryTests()
        {
            _companyJobDisabilityCategoryRepository = GetRequiredService<ICompanyJobDisabilityCategoryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDisabilityCategoryRepository.GetListAsync(
                    companyMainId: Guid.Parse("67b51fab-29fe-43a4-81d5-a18d97e95a44"),
                    companyJobId: Guid.Parse("2748dac1-f588-4424-be9d-086821b0ae31"),
                    disabilityCategoryCode: "fabb4e8cf9dc422ebbd9607d02c8cdf3227dfaef136b44b29e",
                    disabilityLevelCode: "9eab472bbe51466a994c91dd2a2af471db157fc2e00a4d8396",
                    disabilityCertifiedDocumentsNeed: true,
                    extendedInformation: "5dc87db2b1e94a8caf0aaa662aa6162c078c043f114e4f509ac0591b6439dc811305529f7e634770af82a43fd5020036672af1167edb44f7858546581a87c7fa50d4c64c64c843c1889e53fd08628e8ce0d5df4c22ca4f199926b2600f211d7e47125f331ef04d708d223ff01bdf21bda0f16f9e7d2a4d08825b1f59de85bdf06e9050e27ca146f4897951598a62701f11b8db0769cf4ca483cb8845cfddce452e13d2b958bc4777a541dfbb8d9417b4465db20fc87e45469b9ee5d07d80bd3546fb69e08c38465cb765e65f89a05efc049a1c426ea245d396fadf0af5256cead1ab273fb9694f73b16e81d7082dbf51c4faaaba2e614853bca2",
                    note: "6d7beaefa69d47118a964b96b632c2fc54709a2d8c6046c5b5d53704ae95873cef39c3b54353494ea661ad1d889805c10b1d417236334ea79d30f884b766e9ba70c104d63e9540c39cfeaa71f876bdaad28590e9b8114095ba9986b9b8969278f8efa1c2807541ad8e35ea17a2055c0731a7180c76234a25966a6c842122339fa1aceedca2854f78b666a6d14a982ffd21e33344cdb7489ca8cf8e64f03158f2fef53f79620d4cf797f3f2b1564fae6a04aa234bafbd48c89c95f43498eaedbd1fb22a5fc6a2429d9883bc4f4c2dd3822dea4d50e10e4331b281219d840191d4a8d4802cbd54493abdc29bd47b29098acae96e7cdfc34243a8b5",
                    status: "0e9bb5763f2f44ba9b4ec55ba2a44252aeff4ca9b0f5441c96"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("b79fb9a1-ae5a-40a7-b545-d88eff4b40a1"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDisabilityCategoryRepository.GetCountAsync(
                    companyMainId: Guid.Parse("1822f807-f40f-462c-8ab0-800a7abbe657"),
                    companyJobId: Guid.Parse("ec8fe382-9379-4acf-8f29-8055f2f7d64e"),
                    disabilityCategoryCode: "12cd81b1e9b240d9a8ca16acbd707f12b09da4be26f042a585",
                    disabilityLevelCode: "7d83d0757a6c4b2ab2cb2a7d022d686c9b960824c47d4165a1",
                    disabilityCertifiedDocumentsNeed: true,
                    extendedInformation: "7ebc3e623add44629fd1176b4a16f5ff1a724057a4b04efea4c88e4b567ff881bc92fcd9b94f4db68fb2ecc0a15195cc9234711709bd4802ac03fa40ad017f27cabf055c8c0347ebb402da055b7a4a916d6dad6a61d044feb372129d2f5dc3938c62d87249c54e90b6372d9313c5977c17c4292dd411484184f731c03fafee733e7aedfc8dcf4d838cce2d0804a05f177d5e64270cee4010b1bede5575e0920a6d9bd624bfd84e1e80f7ba988255815361d17f84d2b34eccaf552fbcae6351f2627bad8eee5c47ff8db61dc89ed78d537f9c55a8137c4361b6eb674c56a3ef577fdcdde6bb11479795358fadccaa6870e2e3e6bad5f64f4b97e4",
                    note: "3cb67d540f574efe90f5650ce9ae045b913b5330afab4edaa9609ce312720bfef00c5f68481142d79f493f8237153c74934a6ec729e44b8ba9e84dcbbff480ee07451545d6604acd95bf3c7c9ce18577cb0532d7bb7f4736b1d96891813959c391f2dc3814604963aab4e54a07910a24bd57ba6b1de44c59a8613256aa0b6bdf069c37e7da8b4685821f879140409083adfa6c5eb9404bc1be7e945871625650e5c1ba9cc3c84f4788c7363d454cbcdcda16d1a0afb94dfdbc49a10f4d30e228d33fd2d9611c4dc299179966b2a0af195abe60233cb644b5a80a974decd5d7e1e32ebed486574745ac33f80e6cd2c31c8b934b0bf2b94325a7e0",
                    status: "d5676ac32f084bff8dc631851f5395f689bf636ce51444febc"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}