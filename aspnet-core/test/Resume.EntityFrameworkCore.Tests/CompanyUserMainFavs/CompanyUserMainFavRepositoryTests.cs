using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyUserMainFavs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyUserMainFavRepository _companyUserMainFavRepository;

        public CompanyUserMainFavRepositoryTests()
        {
            _companyUserMainFavRepository = GetRequiredService<ICompanyUserMainFavRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyUserMainFavRepository.GetListAsync(
                    companyMainId: Guid.Parse("25807ea4-c7b9-461f-8ccd-6f70148a5ee5"),
                    companyJobId: Guid.Parse("45a06ec3-484b-46af-886e-1febff556dbf"),
                    userMainId: Guid.Parse("c6a411b8-860f-467a-bd39-765c36b0112b"),
                    extendedInformation: "fc4dd2b3c5be4b6b9780b846fe6f7ac04542fbc5da2c4eeaaa0a68b59476d68755f78f39f5714101be2857347c92fb506ad5e6ed8302410bb4f299aef73a3c81078df193962148a6a5b5274e8a58c31e6256ef2b42d345a1bf9589da9e4c425d1d4f1987cc404d22bf27b76c788cfbfaf539b1cf72324b46909cf4df404ef491a1a89e26ee884d22b96e15d1b4cd190485e9e904e2b7465ab42e8f3a5ec0110cf59f3c9f42714945a0bdfdb539e4003251332e6f8dc94c23a2ab37ab1e8710063133cb3dbbd7499ebdc9d881e4e384ed6eb1c37cd97441379a7b2dad072508f7eeb72d5a903f4259a424a20e9c95b64437a6bc6f367a407889a2",
                    note: "94fa7ebaeb724d8a8372e7164397f78863d47fd351964492991d4776d943fbac2d7eed1eb95947ad9da90fa8f343e35d7210f001e9e34712925d765a29650e49806d3b2dda5e4581813b51c173c649d026d5609cd82a4030a412a31f7cf28082a445f33f9b00404abc8e68ac9f2839c62b459661b3ee4919a812c6dcdcef6be7dc5c85fdfcbf49d2a696337eb3523db852f1c22ff84f45788926593e5f8257a3edc53cbe10674c42ac378d69b46f1eed74b04d7a8fe741cc9568c556aef6735de8f41c6ed8144a729b1421827add4f0d211b6e3eacef46b59a13a47cd1abf55031e746a433f948e2a7f44ef3da3baeabfed163e8231a4da8ae6c",
                    status: "b0ce7e626fe54344a9760e3d2630cff37056034c8c4249ac9b"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyUserMainFavRepository.GetCountAsync(
                    companyMainId: Guid.Parse("07f4443f-8925-42f4-86ec-80f1ce3f6393"),
                    companyJobId: Guid.Parse("8714d49f-538e-4525-8d77-bfcb5d9d22ce"),
                    userMainId: Guid.Parse("9c109742-1968-40d6-9cb3-b5a9ee91d17d"),
                    extendedInformation: "7a3023a52c87418182dc760db4533c1ab09d0b4d49a1403187bd41fa7f46eb231ebcbf9f2bed4baaab7da70076201c5af5823e6db56e485fb61bfd658092c3dfb7c5f3c6220141dcab7207426587fd2aa97e482a105a494fbf8629a03773d9c07b3f9df0d45a4d9fbb83e466051a533a7562a3bc65604bc4baa390f259199b0dffc087836d1f422c9277fdd91ffb77c615f62d7d5be74c45b072e0ff1bf023450dcbb0dba69442439294d59486846201036cbff632b64270a15e312ee1f9c2a3d2c09faf7cbb4ce99facef503886d7dc50bdea56a6544d2c9376ff97054a7b3e006ea77e4311493d9fbb67f2d662c19c3b0102bccd3143a7908a",
                    note: "356e6dfe7ce047e8a08ab4b555c9b6187c75ef7c466f43549708444cb8aa3d9e5a0132a938d747e89f7406625330b5de5770d06c655d43dd84633a96c960616d3ad7938645b34ff9b7c686250471f155dc759f1b35aa42399e3c2297afe271507c42c3994ea347c1a2075589fe63508e993fd28072664bdf9c7bdc430b0f1240706be5e831dc4f9ebd87fcdf621512b5c9ad432112404c8ba1e4475b5dfd33fc2e43ab4288284ea48abdd6536dec972b927f50e937cd44219664ba85cbb787be466767fa6a8b477388192cc6e640d4e488dc8029c38d4f5ca3b86af9e821bfa496093ad684fa47779eb216b89fdbb1d7c92cf683422b4166996d",
                    status: "cbda7fa2bfb44ec68f08c044d9cd10cf1c7682850f0040ddbb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}