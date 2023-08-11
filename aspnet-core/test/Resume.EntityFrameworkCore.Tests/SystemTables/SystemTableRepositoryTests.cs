using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.SystemTables;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.SystemTables
{
    public class SystemTableRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ISystemTableRepository _systemTableRepository;

        public SystemTableRepositoryTests()
        {
            _systemTableRepository = GetRequiredService<ISystemTableRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemTableRepository.GetListAsync(
                    name: "0ee4a8d03f3545a4b2794e018e1781b809361e4c7e4d470aa7",
                    allowInsert: true,
                    allowUpdate: true,
                    allowDelete: true,
                    allowSelect: true,
                    allowExport: true,
                    allowImport: true,
                    allowPage: true,
                    allowSort: true,
                    extendedInformation: "0b4e7d349ca241bca054cdc2f57beac013e3740c298646daa1dc957e561f1b231184d9b2e6c14ebd81ba16f3a68215a6cf1e7628dbc84390ac0cb9e4b827b2b03cbe8691e9254224839dbbcbe55b101eee1974e1c31c4f21a429947cb14fa6bcd3e421b13c984582b9968c2c952ed687afb8828f5cb14707b9974cd9fe6165a823d25a35bbe24db4beba664e5fc62297dcd0be8a62ea450e883060598644591f1a3ae43a44a540b2a782af066e05bf508344491035cd47688bb0b087d45c0b8d3735cf2552bb40438a7e4e088fb7b2faee3925cae7bb4f46b89b2438c06100778b87dacce5db43b4bb5a3112b52b2260595615cdfc6e46a09e42",
                    note: "76eb10cf59fa467280fb9e10574c2ebad7aa441dd74b48dc9e6245969562b3ac2f8b81d279a640dda3977983f950bc971904034d2e4c43b4b6a642fc1081976c9889f81f6f5c4c9a9d597ebaf3ee248b28e91e52b74446a5be83a147f2c4eb99ca4a219ab7fa45f6ba4a67521e34a410e56828f4a9084888a945ed8edf7c676631275571d5554de6b0c6787b12aa763ce307b33d967b46fc8998dcf0a6349d443f2be9e342a9451690935d6061d18d6f64c35a67a7f24c2b981148e2bd8a245c9d0a1fda85ab48b5a0d0fd2d055c7d3260fa816ea2034d51a851f34e7235aa2f0d5f7737df4e4ea79dd8ddd9109f68e6850b3a9897524f6ab80c",
                    status: "b82f0d00241b44ebb2cde92d5e12ea3c889a9b967ec2448ea3"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("2caf691c-41e9-494d-96d5-2b54a5c93218"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemTableRepository.GetCountAsync(
                    name: "30833ad6169244edbae7aef9f4818fa173b3d54c13d24b97bc",
                    allowInsert: true,
                    allowUpdate: true,
                    allowDelete: true,
                    allowSelect: true,
                    allowExport: true,
                    allowImport: true,
                    allowPage: true,
                    allowSort: true,
                    extendedInformation: "e94b2c702a42419883a895d877988c6f229d4560f5b44b92af0fbd364c6c5977ae25866b84ed40baaa66220329877b8e39b30d6cb979481cbb71e00f29e718ca4de469e78d55449e91da6f5e43e3dee23949991d1c4443d28d73a96e42f868fefe9d272d46af44da83230172653b51fbde6c425b3ac34bc9a9da6b2ba637dbcefcec43e0adb3431faa9583b06de255a966152e0213da448ba5a5fc76ab56aaff71e6eb554d1c4009ba1c147d6b7fc5229092cd670fd947fa89f905123ea586d0dd2cd842ec84476a96d5d8a4e6ff41b1b2a90a05315748c098cc0c5e06c451dadb18bcc933c744eb813382c685d7bc3ccc731725480f4cf48542",
                    note: "a2db6eae82e4494099cb24b086b1492d7c8c50f8d7d8492ca8017bd1e0914bfbe2aed93f795a461cad3a1e4f75b52bf8e614337eba90463e88aa99715730b3f492ecefe913ff497388806be26214e5a1a75299666849478a8e4d5922763555bca5d118dbda3d466fa726e763c9e4d610a99ca527966540bd866909285577392d7a738cc79aac4d7fa5847477187a4f1fd4626bc9bc4f4b55a1b25270925876fb912526915733435eade89d86fd45f76bffb3e21ad4ae4a109d0007224e2cba4a7a7ccdf31e6d42f18ef0450c1fd6d415cc20b6ad0fdb46a585f709d7f2401c9d0ae1e984f599476cae71d86c685b9e2f508aa6d4327041cb87cf",
                    status: "7597e970e54f47d9bedb8ddfa6e091ca00f4c08b607d4fbca3"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}