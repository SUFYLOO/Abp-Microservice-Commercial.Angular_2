using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobPairs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobPairRepository _companyJobPairRepository;

        public CompanyJobPairRepositoryTests()
        {
            _companyJobPairRepository = GetRequiredService<ICompanyJobPairRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPairRepository.GetListAsync(
                    companyMainId: Guid.Parse("43a58d86-33e2-430d-92cb-4f240ce05699"),
                    name: "e7a7bea7d39445f5b6bceb91fa3862a62c2da1567bdb476b98",
                    pairCondition: "2a2639670ee74ea5a70342400098aedaf4824dd64aa94485a097b0cdd384b5b9969587b3f226442e96e0bcb0809f0b101cbcb24c76eb4a46b7857054f33438ae84f1316f2c544e518c8a57e39316194e4ddc01e246424484a6b016395726c3bcd6a051da21294009853702f6c1116926c35ee61f3a94432ba3253ca5bccf93300e2a2d9b6e0a47faa35e7d7a70b01da9c6c83a0eed4b4ac58ac12613ad7bf22961fcde187b0e4395adb1f183cbef2fa18260e16315e840c2901d98d9d39e1d7f9abe46a15cab42f1856f6ae082cbdf7a28bbb35c8b084aaca5ad8dba0fe6b1d11fd22a08ee06453c911ec2ace584ac362399c1048857452d8966",
                    extendedInformation: "ef7668c17e6a42cda4ef380c088dcc81a49fb68417bd4559bdb6c44310092e8a6858588c0e8948348609472cec6f0395d58acc824df14f4989413d0f98f4156e44267be6c56b464db7c011b42a26c02ceb7b398556a84120a4ad8ed4f6a7559a2ba0e575eb544676ab867444d14dee89a8e9bceb8c2f4b41a87eca0579d693956b6fa31c214d4b768831ef5ae38dfb66ad07faca97c840548ab2ce7aa06665e43dd6634e7f824631b5c8c00b370fed0e895beff37a4348c092f0fdb8e5132548ff79d21f962a4f83ad0323caa3bc310956fbc9592f9c4b429736403091320a991201ad62f8344a78b529e66dacbbfbcd9981815f0a354151a24f",
                    note: "e371f5a0dd6a4e59a2602b18dfd90ed944c46da6f2d746e7a102b8a321f9f62cbf9008cccbc04bebb69fa6f0e0d691f7410b6524ebdb4f019b0cc8439ba31384db7b0368930e49a8ad4a69b4ee12bb5aa6dc829660df4de2b3bfc86dbf6a0cbc7cfd2961e9b54c8cbde5ca0bd34030de6e02f7d3635e4bce922e8d8d13a311e4361875c754c04a5f97eb3da4ced0ca1ba9939832f8bb445a9578dfe18fcb370f03049a8ecafe416d8ef97266a2b6acbcfb53dc1701544f7094d1db4dcbe34eadc6e044a0c3b24b7eb82e8433097c21991e6a98968ca0480e9ef8d805482387f52cb25754c5da452f8067fa7189cba08215c3e314c557489ea1d2",
                    status: "6bdc73a5e4f740008ba3eb3e37266dd87b702b28045543b68d"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPairRepository.GetCountAsync(
                    companyMainId: Guid.Parse("f6739157-d80f-43e3-a00c-6b54bd4c4d49"),
                    name: "6d57af737919448aac05cd430b6885b72c6d1be0c4ad45a795",
                    pairCondition: "751342ff43094cdeaa6669453bb1d20d71fa912ef1c6430bb0b2ca31969d85fc2aa49a7e6a9545579888559139edb7f652002a5c482d40eab0495b4e7919be574265bc8ec530407a8f87abb3c793cf86e774855d8aa647378fa28eb870cf2bd3ff179ca60a5b477296d367614e233f4b68e0874d8472404e8830c1186d0469aa770355267362439ebd829fd231fe149c1aebb3dc68f74aa4ab7aed5c1efaabe7f9b97bd3f2cd49ccb279b7a20383db8f87dae3422da748f6a5a6577618b08f1cae4f567a55e74d67a49532b90ca28304aa9519442bce4368a372b45ef81b4cedc20ca42c8cfa45b384dfe13b03ac7ca1c848309ed1ae4383a7b9",
                    extendedInformation: "f2c3ec14995649f9a531c1ec9f523b838135f05c9e394735b11196a400006e1bf078ca66bc6d41cabd4b817797df594c76aef949353f4d1ca4fa2cb2b31da1e1a8bf4d0807fe41e0bb32a793252581e054668e47895343a4a0f9390566d53b7072fcc06be24e499785cbd73c43b3cb669670135eaf21471691af2808c96a274c6970261f28214768bf81b4ad27767b89dd3f057050a846138d92208fb9b4171f192e7b070c804ddcb4def8d31da132ac1a5344dbab9941cb800defebdc764d0729c35660f2474f8f9cc2d49e6df4054fc63126e3bbaf4254ba74804d9805455e66226c87345d4770a3026155723ff9fa7b78ef5ff6c94e4d9646",
                    note: "c9f8cc4d9fbb4b8db8db3e10ec2123a33f5b3cdea4384922ba5457ef1ffe27af8f1ac7a854ab4ab5827ee079f939630006a52ba7204d4e7fa453e2c2cc80d60a07c80af82a154f4cafbfc3aa00c906ae5b5d8132f4f045bf98170bce84a357ba9316b4e1621e41488627d4a5df1fce446f0837d5af2b4189b8634693c54c4adcb30dc631724e4092ba35f4f71166188394184663258e4a4aab34f129684b9233146ef2da99d64ac4840d5c49aa70ea97d2b429cea3d1475bba147f540c186cdf2785ee09aee64b35961588909fb2bf6dc3d56f1b224b421a89104dc4cafb1b139fda55b1adf24bcc9237bd97b3a8e6d2c43412fcb2f84319ab7b",
                    status: "c41e8474e1554ac8aab9b9ec3c7611059c09f80be4014eca85"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}