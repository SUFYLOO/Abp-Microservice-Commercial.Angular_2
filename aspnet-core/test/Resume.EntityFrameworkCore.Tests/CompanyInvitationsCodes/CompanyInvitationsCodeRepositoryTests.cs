using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyInvitationsCodes;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodeRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyInvitationsCodeRepository _companyInvitationsCodeRepository;

        public CompanyInvitationsCodeRepositoryTests()
        {
            _companyInvitationsCodeRepository = GetRequiredService<ICompanyInvitationsCodeRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsCodeRepository.GetListAsync(
                    companyMainId: Guid.Parse("16470ac0-2648-4c5d-8734-765efb970953"),
                    companyJobId: Guid.Parse("6f2fac5f-7a69-41a8-830c-eaa6f2d987ad"),
                    companyInvitationId: "f0baafd0386042f582e9e2c6dfcbf7efc1c6cd37f89b49ef9c",
                    verifyId: "548ac72fa2f9499baed0b5c983d307f13dbc2aaaee6944678756d132df520fe2bfdb8aaaef664d1ead8e1fc0be6828e484e684492acc4a98ba3007ca33bc1f3215e67ac95ef841599d61bc87b8d3ccb92324e9357cf24356a01b1d22719fe78af6a5c2fb94704e609f76b50f09a54a4a83089a7f0e2f4f6fa6fc0ebb37ad55151b3ef9c6f00e4334961f89a8e5a3623a08bff54d2c4448faa507a689d5e6981b57912828993a439f83e56284f32034d7df158606329b4665bb58e539003e53df64c9ae3a733a4ac389147c644b41c4e81104a42162c2423d8df840bd779daf6600ab623023434976967a7bab5b0753628e5234f27baf4ab4b874",
                    verifyCode: "442c87498212446196e3ae17415e2d612ae9d48a6f6a4c44b6",
                    extendedInformation: "4b9472e6ee6a433d89c4942201d261ccf26a75393b374895abed4df9c7d69fbbda721c77c7394a62a8764e1a2b7ad15f9f866762da434969b034e58cfb2d9c85ebe2a4ff64bc45f7b688b0c428f37de0f1076cf9ee064fe3bbbe7bb27fb0d74eb10188cc7650407bb121de8e9720917b7bda000d64044f24800f34ab5f2fc87835a0ec227b3b4c4697d6deead7fe3bc4408126df478d42249057f179b2bed417acf325a7dba6438ba4721391243473dc4b632b3a4dbf4326a552b8f9485b222e5bd0ca737866444ca70cd4c49eb26df9f0d6b83a972d47ee884bd7c95a12373f3b2eaf84aff846ecb5f056ebcc381e0268da5f048891427a9568",
                    note: "2a75f0d3817248ccbd44456797c0a7b48e2671c61c7c432dbf2a2ff8cc9d695db41d18c4a4c84ff0a5598651ddce2b6cbf382b9842d545d584270ef3f4087c81c58c57bd73164c1caea3f4a25a61bfed433758bfb9d640a780e39479878b6fd50fa118b47a9844bfb8c2dabfe9d0894de291668ed60749d58b049223f19f510c3212cc8c52f04f73a8fa37508f22fc073bcd922eddde499c82966d75a7e7948501d4f1b33e24456397a5e778688da4b119eabb44af5449038428cba62b31dc9f87931bcda58746a1a02db34295c90441f3892d90b92f489c80cf6aed5cf12bb44cb6ad7a8d5344cfba43c57e64bea421f5aaaceb10da456aba86",
                    status: "5a3d143c2f3941cd8e7bfa89b4be6837242ad00f1c854a66ba"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("e2234963-8d1b-443a-85ea-db7221aae648"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsCodeRepository.GetCountAsync(
                    companyMainId: Guid.Parse("f86935a6-af80-4ddb-aed8-93fe92a06427"),
                    companyJobId: Guid.Parse("c4b6868f-d224-4b5a-b87a-7073d42e1871"),
                    companyInvitationId: "c6e7dfee98e142a889410d26074477e2b6ccb701287a4e209e",
                    verifyId: "4fd95042158b43e591204f374d71f843583284f5f98c44c9a85bf0f876bdda23cb1a94c53d044df8b830dcd81685aa929972b3a616304a1fb91db5f7571a0a24354989809c3d41a4b4546415852f89be1a3a41beb8a145ed8690b5e7dfb45eb35921d998ae4c44bea7088c42c452429bc55d17dde2714d16b1d672039c210fe2d1a7f5f67877466c81a69c3f086e4432279c21b4c38f4d05ad711a9a69674ef26394c63b8d744c6cab8e49693a30fdcc868cee3761244f5195ebd043de894c7dea99c5f99973400f81c76a5bd988227204f5d0c1f9f14a56aaa3154b3faee09d0ca5183b758448609489cdd772e20395200ec52b5222404eb576",
                    verifyCode: "e5596b4cb3be4a58a353a665d52c98b523e48c89cfe9474594",
                    extendedInformation: "321679e7de92482cb3617e5a79c645e429aca754a5204f67b5b94c0ab1027e718ffce09adbed47dd94710f658d338b1bddc3341b1526426999c345850385e0cbcc46c19912d74fee9c7ad2ffde19529a476664bf5e4443d3b2d021338981e134ae218abe6b4c45c8872c7e650609f1d606369eb8af014dfdb9867d8af43dfa72a74570c6c5ef4c80bccdabf0a1c84304665db75be1b04a6297ea6d1dbfe05ce8f28c3a994e16419b94d3dc10f39229f5ddd06828f32e4836baa4744b2dba98aa0564ce27036a4ffa901b7b0a7b07aa1c1ce04446e16c41249118977939b731e6fe8ae2e029654083bdc4097717eb57125ee84ede0e23439bb858",
                    note: "8e039494ef824edb82f75f5b0cf6fdffca0a82f943c548db8dca2507a9183fa7c54357f9bff84f7c9ad92799ba9b24949d128205417240c0a4ad3a4a5d1136b90cc82f81bdf94728886e7d56154811195b03bf8561f541a8980f1fc94737488998c6aa4549184126956a39b76090fbee6f641998383141f78ca8fd85b9ea26daaeafb011037e49278df912bf9d2cb00fc4615d0f33f94d24bf4b0f60b524093159d889d188be4c2982cf69cd13d030a65efbecfe8d9a40cba8dd0cca64aedbbe1583e292b2a44814b0f60fb44742fedfc45ddda206bb4827a8f75e8266c4c81b1112dbbe4f9c48cd9e50078bb599a00df81ce9fe5075481f9f8e",
                    status: "bfc54582f83043c5b6c93a98051018635e477da892e0428090"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}