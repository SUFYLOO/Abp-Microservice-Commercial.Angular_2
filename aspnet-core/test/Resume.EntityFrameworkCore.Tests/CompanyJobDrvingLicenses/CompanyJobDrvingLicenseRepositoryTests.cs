using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobDrvingLicenses;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicenseRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobDrvingLicenseRepository _companyJobDrvingLicenseRepository;

        public CompanyJobDrvingLicenseRepositoryTests()
        {
            _companyJobDrvingLicenseRepository = GetRequiredService<ICompanyJobDrvingLicenseRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDrvingLicenseRepository.GetListAsync(
                    companyMainId: Guid.Parse("5cf001fe-8f18-4be5-a231-61cab19a84fc"),
                    companyJobId: Guid.Parse("0a8774c3-8482-4c6c-b027-b475c2d65497"),
                    drvingLicenseCode: "22552e9b65c44c65a2e0adc7abf69393f8c1bcea267d45afb0",
                    haveDrvingLicense: true,
                    haveCar: true,
                    extendedInformation: "62035ec6314d4a71b77ce00f2820603aa242df291299401583d83acd0c74970697383d7bdc0341dfa3eb60aba8593ad6a0f0ac1828e64476b6614aba298253f735225b946c374928845d97e3bc09ee186bab9f45892d4a4ca2bd27ebf35b74aff6235bfa7fc94c7eaad421bd4651b6caf70733cc22e04a6990df6ef4bf528cf0d3ba012e65e642d58a4cdb486096d4c860a1fde6999647d4bc909a7186a0c73efdae58482c444b4695ada2d6344b5f1ceaa49e125b7c49729024986005ff9f45bccd4b88978c48e3b20e8b762acd51e4c559e4e58424476e9e2448c46ff11561b366cd8a62b84bbaafe0e29d79ef036b12245dd578344725a4b5",
                    note: "ec6fa8900940421fa16ba2bef5b7de9e41e97266b3724231b8fa811076a1aa4d1a97e4b5e72140dab717276a3ca1414978f48cdde8a44c978a3b9edc8d831a78140632386c764b0b8b16d536d3a4f5c1c09194864c464b4ebb3461e4024d272484fa056dcc8f4bbea5907a23e9360ef1be4ba69170b54cdcbce3c7e660d903e4f3ee26788e334ba497167052d5faf234f13abf7ea2a746f3b5fd0e60d7cc7fe439203807a05944988211cf612473b4c5a439dc26f2e64ebeb8bc313af4d1d0211c3dae1a584c4e4ea40ff713cc307eeee27fc8dfdcae4e8d9eee0441ed3437d8f2eb75363605425cba12bd7b755aa65e6b0e2a24c9394a9e8034",
                    status: "f6a192aa9e2c473f9476201b6a556f4450b556852e1e423396"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("88d83280-0070-4602-aefa-9a6ebbbb6a6a"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobDrvingLicenseRepository.GetCountAsync(
                    companyMainId: Guid.Parse("4d1c50fe-d764-4e61-b595-225f4b88bc0b"),
                    companyJobId: Guid.Parse("a68adedc-5978-495e-9c26-8742d8042b67"),
                    drvingLicenseCode: "c664fa15af394989aaec3be11e4e0a6333ee01c77c8d46c885",
                    haveDrvingLicense: true,
                    haveCar: true,
                    extendedInformation: "73b9682333f040c790925a4cc5333618c2f3950771524a5dbf8e7a7ed2654328c1ac6c334c544555be7a093f0a175d03cb58c7ebc67c466ea467f61b1f1ef0ff6fd2735c03f641e0a46ebcc7c628645c68fb2c5ae84048f386873c4b4c622dc652e568a872704160b87f662d0fe42529b87c4d1748f84ffabd9a0d49a78c0851648ca36c7a2c46ccb59eb74774a500170de96352a3554cb2977386b737e992d859af303ce89d407f806927bab504ea2d46a88d822fae4f4691f11c97976b6fefeb7b38446a8345868948c2c82242c1f612e67dcae53c4bfe8d74afabee1b5b2ff8d9f0ccb2c1416b9e335c5cbbdc50790093b5275b154a3baf72",
                    note: "7ce9e836edb841c486db8b32ba547b6eb17b6e4d48d4459f88766d5db8553e3b7db4dd3093b548dd80e5604811a790e3a2d998a184b34d3d8d06af66ce60b2c669f126ea37224b9ea97c7e5580a9def1f3f7e43708f6460ab0620e14390f58016dcd94d9851e492e8e9e6179248e06014f3507af0efb4813b432528f33983b242ac411e03d574291a7ca7833bd2dc55ed7b5a5c69fa2452382f98f156eba0c9ffd584a37ba8049eeb12a710819127b03b6eb18fbe85a475f98fc82ea798e8bf633b56fd77e7c4caa994303f9b69969f1046a05baf4364ff8ac5002f1648fa98bebb67fbe39864335bfb0ec4135b0ce74eecc7883a79542e3b91c",
                    status: "5339d5febc6948159fc95bdf61eb4325079ddb077b9446b689"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}