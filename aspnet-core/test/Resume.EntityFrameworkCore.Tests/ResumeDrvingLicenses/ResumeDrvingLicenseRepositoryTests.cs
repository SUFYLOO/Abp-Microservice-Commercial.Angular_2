using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeDrvingLicenses;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicenseRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeDrvingLicenseRepository _resumeDrvingLicenseRepository;

        public ResumeDrvingLicenseRepositoryTests()
        {
            _resumeDrvingLicenseRepository = GetRequiredService<IResumeDrvingLicenseRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeDrvingLicenseRepository.GetListAsync(
                    resumeMainId: Guid.Parse("44c60275-91e4-4417-96ff-e48d957d33df"),
                    drvingLicenseCode: "83123e707762425e913a621d8be0630b2aa19cc2c569412a8b",
                    haveDrvingLicense: true,
                    haveCar: true,
                    extendedInformation: "cc17c6f783a049d89767586aa8a416d5ec8c65f804a54711b423a5f66aaba3a5be9a72e2ac4d40a19c7a151686e9db1be29d931c332247649f5cbf8edbf893deb2809c19ed764d378c7a3f12f795f230bbe35ce60c9449f0820578df1cde196979aadf6221b24692ac3dd032459624f92a1f7f9c7b3a4619b1b1b9f5dc3a144fef7458fc2313440491c9a0d5279c1d4fe7411fa7d05048619310751e89dddf025867204262fa4fe0af1efe2130bdc85416514fec06b045bdbf9183b7d619be22917f8558b31545409e93589d2cfc804bb99a80a7328d467b82e95c7195325520cd3260c2b8f24e2d93648254444131adaaa3cbc9323c4f3f95f8",
                    note: "8c85ffd202ae4246aa16b02c96491c36baf8b0c7d30c45d492cc60558a24ff30909eb2f3594543a1a57b26db53719adaf7bfc17ce67d426a82a621fa875c901b763c1e2e8cb44edaa56941c4ad4c2f8819a29f91b6254464a0eeb887abb253edc24ed68d9542463aa238f691184f1db0284127aa269f4164a2b6d4e10b49c45d59655f2c78954313893d3f6b5545f5bb9d03d540f861480082445546429e940028698481468f411a974e2694bf760cd048851da0b01e47aabf5f4aec5603cd2c82f2cfd8c6a042468d8351554553a6464e1a78b04a5e44f8b68daca9e9909e531f584e0e94134ea6afed7f8ccabb5ef6c99c5c86178f40c58f58",
                    status: "e016c8e54d8d442a992fc8dd0e61518d8451acd7149a4cdaa8"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeDrvingLicenseRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("21079d1b-af8f-4f9d-9dfc-bb106704fb2d"),
                    drvingLicenseCode: "7f780234baf048cd91980bc3bfc3e1badfd3cd46964141a4b3",
                    haveDrvingLicense: true,
                    haveCar: true,
                    extendedInformation: "62607c5a164e475e820b0af73d0a399c32a0d471b48942f6b611419aab2c99cdc8908e1509a844ae927924f4b24868d0d49dfc6201a9444db923e594c877589eb26460ef62e6470a80be5e3fc23d615e753b2e673197452cb616a31eb1bbf9f2d2c1c0fc5f05400591512b42171018266abdb7169c23495b8ff859246927e776ad34b1c645de4ac9a0662bbc3ed5d2f4b16e38be196541ec8a06499fcce09d3ec2b6846eea5c42e6a51f6864578186719c658de67ef34a8db18abf4f6271c47fe32e3e5593c8401e910a9923f49f307d4bfcc47799a74ba1aef6a84aacfce3a29c035832fd8d4e9199cdfcf42d5fa8117611ecc122e5408982f4",
                    note: "c70e1ba44c444898a107ef01c1b169984efcb5fdf41041658c5dfee1682bb24d3ec7d8949eea4c97814102673bad08a8bbd42b7995bb4ea1915a6c845c894160e0c632b450a642fb9e045e1c6bb810553e6c41dba0884943aff31405848b97d4e898ab0b4f804db7ab6ca0ad678f5a6c8f30c95d840b4d558be0a1a793aef9a9d7007bab95ab40a2bae228459278903a4af3b0af42d2421aa26166b10c2527273917027db1ad4af5b05d108bb38d76e627c23c96a6d645078252bcf713b2ddf3adc7efa2c62947e5bc862955d5f242caaf60d46388d94bf3a4bd36791b216ea9e3da292557124c23b36022a8c9502c56475f405cb6174e859f1b",
                    status: "a1687bfb6e374b309620ebe8c4d895fed95662bbab304bc19a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}