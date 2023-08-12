using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobApplicationMethods;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodRepositoryTests()
        {
            _companyJobApplicationMethodRepository = GetRequiredService<ICompanyJobApplicationMethodRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetListAsync(
                    companyMainId: Guid.Parse("7eb11928-b534-4702-b1e9-e199a4a89c5e"),
                    companyJobId: Guid.Parse("2249e876-3864-4066-85e9-9b676a819c0d"),
                    orgDept: "98511a73606848eb86e91812d4d9d2a600fc86d40bd843568418f3df9589e1dd0fbc464e61bc45b4b8aac1480d4947e446865c10dac74b6aad968ba0b371f364bf2089a58c4b425cb663b29430efcfda323b0055998b4d1eb82d5da76058ac6bdfdddc842cdd4b109a550627f34dbb3856de74d57b8b4a8e8f4808d87eb8e2e4aa0eaa37a95a4f70b08ab1e81fb3a962ce5f213239df4785b54fb24e039082a3532bbac0234f41da9590d35cd2774ea0332351f9e83f4acdad4f7d9c048056157c9331a13da4468c97e41313c89049d76642a0fbc72c42359ee10ea92adefb135f1088d9290142f8a847c6dd5a31a7294bfd67c2e7a342288c8c",
                    orgContactPerson: "3b13c53aa2b447149c79d5666d2072c1dcc2568998c546aa81",
                    orgContactMail: "1ab5ecb500574ed2b485f5d3306d5a5c2d4fce422b69436797630a959e2cb936fe7a93356ac343a580c4b69bc6655c87f2d6d7a060a445d78957e5e542eef6029aa74ccc3bf644b4a4044047fc0be29025bbe73eedd04a5e9087f8a15a47fc92f12f29c91681415e8cdba2b34296a4528450f940b4444df0996878596cc4647dda84c4d6100f439db8df6ea4ad54dd405711c06ecf3b4b0a87c1e519a29bd12197dbf54558ff47389c828caa853468507e59618b81c8491f9cc92e066b9c1373e5617e11c55644e58bf5ff1115df6ed1d8f9c3d437cd4b45a61f7de6bee98f5892d84a80e85e4d5d8cbbf205f6b04e091e82435024764ea7b001",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "9792724dd67c47e5a59291665d4c5eb75c54dbd834f6491983",
                    personally: "cea6b051ed7d465cb2a7a60351f4f3cad6c4d29e37f2416a86f92e337611e23caf60ec4da83e4dc1b842ebae3a9fc8586a0997af4e3540ecae3c18992dc032f8d01a359e54484b1ba03010d8189b1514443870032db8400b870187962e0df4fdae84b169",
                    personallyAddress: "3b7e3a2c88554390bf6f08db210b0ff376e4b21a58dd40eb92a81c348885eb98e464b4190b7d41b187ad8dbf20bf83a73330901ab44147b6ae6c0de27ffb0f402252076bf93f4616bbaf7924622467f5afb5c74834f346569146ecedd034633fca58cdf1",
                    extendedInformation: "267bf41d607b4dfbb62ab0e460a299255fc6d44835c04c2db6a9649a5dedee6a0f4a24d907ab4954938f9c6bf036bebe2aab7f8ef199470cb118ba6ffb81c5502f3a49d5fc7d4419b040ff54b23e94f8fecf1998dd554735ac394a64e5af7e0ffb853d59930d4e548b00367aeffae4eb1f8be5c1789e4562a0019948ba5f7d7845e177bd7009431eadb0e3c9a2eee6349cf1dd363c314228a91182173c4a8c4ab75445ef19e74579b0747b23cab570ec92ae67354050402ea530173412d3e05835c32f2c71184e5093c522698f8851b8ec01a54ebb39490289f2934ce0d0d1d1f49ee2d4e92849c694d847993203e41a62269fa3ba0346208424",
                    note: "86fbd3b196fb41cf810b7176243d3721ddc76dee6bd44e4ebb25ca4bedabfa34955f0fa74eb64c4e876b552d00b044864a402314a45c4268a681e33fa78e231d0b62ba72353d4c6ca53e74dff4f26fbe9881f0f3e2a4497fa99b0d6879edda8b7b499f48bb9743d8a2a4059b5131291e9f3df4a8613242c9bc6c8fcc2300b9ed44f943a1e7e34b22905fab3dabb98ae65d0b1ca3129b470eb7a2b670074be64d30c54366fd4345c790209d96e6bb26531bbc49ba47fd4dac92b7807c6f211913eac9121ae174486cb23a50f9eca875c91d7067478d2f43fdbce8d5fea860087b70203750f8864fcf9e17dcde7feab66cd36a548efabf4037a55a",
                    status: "406481153f414fafbedc3c95deb21e82c014a17c1d454a03b9"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ad773da8-2889-48e9-821c-9cb2b68bb64c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetCountAsync(
                    companyMainId: Guid.Parse("a8177b5c-307c-4596-852e-80a4e3922a6f"),
                    companyJobId: Guid.Parse("4ad3d86e-3cd5-464a-a302-70b8b3463294"),
                    orgDept: "7232a361ba56442c9338de0c1f211630d555623ba9cf427789a3228200c75ea30c9e86f03f65465bacfb6fa34e3842f4deaf4e5322f84644b6e0a755d16f4311a4e6786308da43809982a571e975afc730b9eda3861e4898bc8150bef7630352a10f4d47d38742f3b27ef467278c7ed62cbf10459c8247f18faced206853c6775af40cec32d6448da9486d4a3e3d4df0270faac906fe4f90868bd5a126ed1661ae96e57fde1c4475a957fb21cdad1edcc9dcd75b0f0149ea826b0cb99d4548b20fd25824452f46d1ba25e3b1cf8efca3021645421aae42609e7c12aa248f3c2d84b194bd2b544147b879df7b1cd37b0116c8c40b687e46b888c3",
                    orgContactPerson: "c5ff0eec45564762a5b45fdb671e17696e238d60d7ea4f8c87",
                    orgContactMail: "f0e1600ec3434eefbcda97646e75abdf1e7e0330313a439eb317ab2008a8f5b6d93391298ab84dafb700a348861a2468bbac8a13591f4485956498f291d599de9cf4f202b1c64cb19ea897462b3c5d200484bc8f143a467e96c349c609903a0735ac0be3df874f888ab3b722acaad89293abdd0be7aa468f93d1c4d2a3a3057545e4353e0afa48efbc7bbda10d5dd503381953220fbf4e9fa7874c5e424f663991f5845d6ebd439c9c813aef86f33a416955059a61934b8a826b65443112b56207bdfcc9837e4fac8ccb1056717e1fe01d211087e57f462fb8f4e59ac706e9521005e1bdb0db4031a88dd65d5deb81bbcaa838a1f4dd476899b8",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "f553d411c95b4180bb8f408565117c076cc3104a140f4af380",
                    personally: "2e9bb92cf92146d0a8e26b2c40878a364547713d143c4341bb48d0c94584a1fb356baaa7787046b69842e68d472f8bc7f2864af1d2a940b5b08b9830170b319e5598f4c8a56b4d36b9347e1ab50568f16ec0b7d4187043e9b4f10c06d591e45c99c02660",
                    personallyAddress: "b336599515f24fc9b32f49ce9e39f0190bd00648d75e4275af13305c4e28427582fd8b2f3da846f284e5907a266d236c566ce82204cf4d4a8ec0a93e980a229225650d47fbb14e099f83fbaf0bfe64b621617e0a9fc14a33b019eb0dff3dce730fc4ec58",
                    extendedInformation: "361122682ab848b7b16d33aa62299dc8005d1c88bec848eca21aff403348c051bb6ab93c2c544491966c2e5c26b55dfeb243b9b140d04c4a8c7c3fddfefc9ecc9a21ae60e0e94a83b545b86af28ab1715d0476617f014acd889e1756270a53d7008f3a0d3bcc44e3b5a9907ea6dcae97db9d7214c1254a95923ae4816f4fc03284db4700c86747219fbeee0d544939b1b68acd4fce064e2e82af519d4a5c9e384ed8b7980b0c4cfd9ea0d211e8a2e5eb13bf90cc89e14001b0f87ee5771bf21298c4ff90394a4e90aea0ad5d5fabde175500d48a57854b1abaa80483a85d2e723ee9ee3fddd545e49e7f5f7c0f2f1cfbfd5b48ae2ee941f39be5",
                    note: "41a4a6a7922244d0817f3f727791e9f6b79dfbbf2c374b5ea5f31cf51f0935c57fa012b5c4254b37bbc6baa7767f1c8a64c8ab3d99d8458c9c0db23eafe1c6941ade9ab11a184da7aa013185c21ca577b296882555314ff0b98a8d8d09542b79f51e3facb4bf4fe09c0dd70ebb67698213fc5dcf8ecb459ca10e15f327b0113c9a887a43e6684840a531467e14322a8805b22965891c4cd19468af27e81285d71736af0a564c48dfbc70bf46e966359120023ba9adbc416295716db3935edf19112a83742bca4b7084e09c3c8d245c2ed6d768acb8d54b64a1196d5dc6e2cd2886dd7fe3f26d4e31bde6273dbfe5246c98ded425a84f4fd19cce",
                    status: "95e9354631a94cacb25f8859021b14c1d7e80508c680452d97"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}