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
                    companyMainId: Guid.Parse("8cdb3a09-074b-4c8e-974e-5a7dec1a8944"),
                    companyJobId: Guid.Parse("5276dc8f-b94f-44bd-9509-4d0c67a3e4bc"),
                    orgDept: "cc24aae9d5a240388c9c74002844eb021d31fa8617bb4390a46171bd6fbe21383aaa4cb490bb4c42842546248393e0132025fa807a3342f49975592783bb205d51de72f9573c4594a72bad3ad94233cbf0fd8d4fdc7a459da634b1cbeaf36712339ac508c84e4d459df47a1c7b47c1ac7d8ebfd4a7f64c4aa5adb8fa4e608561db1dbe35e4d743f4a74108baa075877d11913e3331f246bc8873563a15946b43ccaa4ab9ab244710b5d46062a14e333839cea82a8f9a47e1a192af32056147cfb22129f8179f4cda9bcab375219fa5675f00a462462246bcaca1c9c92c555425f3645a261e2541b3b0a518adc11c0edf509c548ec8e94ec7b880",
                    orgContactPerson: "5625dcd749184929a73795b182c20ada264f98e2da084dcda0",
                    orgContactMail: "936e827bd29e41b7a1c494bdf7d8388326ea31035b1444cebaec520d1aa0629029e75eec29114e2fb4e202aa0213e086732295c2e8be4cfe90ff79915deb8c6f7bb19123b6044f25a139538dc40d301331010f490745419a82d6bc14c87447f805d9b31d5f22489ea4ca0950d00f78098004eac4baa1430384527f98d24384542b454a1e719b42e9ba83ee2c06b26d29b110aac2ca134b3dbd10f167314878c56d5ca5a9d7c0427ea34536f49a5ef5bbfe45d49b527945adbd234bbb43fb5681e524464156984fba8943e0815fd6f0cdaf5d30daac604c13b9f6c6a5071e00574cc5780f21ad4f3abe412be44062b03058e0ba8a8a75461e80a6",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "42de5a167e474766a46fe1fad78dc9e07447d0c2303f4ce38f",
                    personally: "e8b4a6ce80e047c3ad79fb47a696477459869a7188334c4faba85237f98fe09c68dc90950e31475da9d36ef6d5e3c94f373759f65cc144cbb0f942b3ccee43fa74ffbe621fe2441b8d0237c427f14b524c874974b5ab4d60b36ac5d7e7a742a143904b4a",
                    personallyAddress: "1c0959e279db4bee9277db34ef12bab92f61db4072dc4858879b964e51234c5c9e079275e01e43e687143a123057bd4d3e27bd6f3b7347f8b14e7b01b78a7963229646ef372a443087656bf0609afe7ace7844836e404aa09f71d3779f8bf1b79781f394",
                    extendedInformation: "6d46d60f9e8f4c669d7d3b8db7fd195e626aaedac4b342a8ae4574fe65cb951ebd016a73d13341449f7383cf6a27a9c02961d16dd119421ea2bdb8854657476fa8fb222540014b0eb217103e4ed67786c3e34c1db208422fbbfdce59d07b85277d9f228640ed4a04b6c22d46e0be149f3e11dd8eb2eb4c3f9ac550a5e61710f61db690fc19a642d6a310fec541f13d88fcffb100c1ed49aa9138d9e9c645da7cc36157d749b449c397fef760760fd99f901f880291c84e8cb7eeca1cedccb06a412161bfead443d0831e96270f18f0c57eba594b35b94d828dafe73b698c615d141eaad6168147168c463bbe15d24e67d549b477706441508b10",
                    note: "d914187399e14540ad90495a625f63c6928f4612274d4b379dc31a1ecc9b94e77d41ef9254b444b6bf6de7134191e37464581cd331f4459ab75e65005bf2b889a8faa92ee22347a6a45c4f015fe7579bb6a3f5ea235a4fffbd1d31de11ba9dc9ea7386a57a39443eac0bd3ea8c961a70af213713138c44f28c478cdd3e51cbe21648ea538b60426fac3b332dbd03300add02174787d44e62b567dd06944c3258dbe7f74867d946bd823725041a2dd544fa409eb9ffc344559a1a154a21f3dba10499ed211c844d35923336d39c95a594d78d5f025dff465aa8b60b3b3ae668bf760c123f83044717afb7a294d5db1469cf088846535c4e16948e",
                    status: "45acd5b15fb44f41a430eefcb7695fbfdf5b640794ba4aa1af"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("49bc66cd-19b2-42d7-8099-45b775e266ae"));
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
                    companyMainId: Guid.Parse("9f56f70d-ade0-42a4-a672-83eee7610be2"),
                    companyJobId: Guid.Parse("334f2315-5dcb-41ff-8d78-b5dfe7b0587f"),
                    orgDept: "0bfe0f1ad5234cffa843bfeee2cb0be100905d9f267948cda121db4a6683552905caffc1813248dd8233d8cb745f6232418b96e421a9471084884bcb397e600a71248ee6155941a4a4c0ad6acb2553c9a32c2accd0794ff883a9731cb43d088acc7e267029094fe08b456fa86b30ac78414b062096d942a1944ce4e7853f2d76fe0a70a712504abf9f1d8a7cce81acc6ea73a36a91084fec851b10ec488ebd82e82cc446135b48fabc596d85c6b593d16578146c110d43fc944681d7ce7c61d56a1a2506736449a9878ec540f24a001241e17ec997f54b12b9e92c2ec00d105a9f9aa04db8e046d0b8eec8518b44854901ac478e9e8b4e4c87eb",
                    orgContactPerson: "005ec8eaee2f43d7b0450bb1153f78f9d888b27db2c1425b9e",
                    orgContactMail: "43fc371fdf7742b18b56e33c43df05eda3ef44fed7bf4e9b8ae3df83ffc463f5d331eedbe0284bcfac0b991b82b476dcda7d119774364415b69310ace1cfc7c5ec40fea878764a6d8ea88cde3d6e0c675a83743d4d7b4c83a6c55064c5b58482dffbf7a807eb4ba0ad38046c112eb5ad008ddd433ba94df1a2ca28e8bb02896223ebd729279c4e3ebce523a4b810aa4cae8ce2fc6d274a388a7dcdba72547d466ff9a9e90edd46e7b054f0ff1563d12574bbc33831cb43bbb3d29f8cb0bb924f22b38ada35aa44268052b93f827b8ec73783ae1c9ba0433f918b79579f240518b7134c56137e4c22b169503c8e2e3a8fe2b8deab303a47f1964f",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "b07825861f6b433b9a6852650d471a1fb3f8c7dc21d64d669a",
                    personally: "edbd8a95997d4b1e80927999bd530bcfc8371d74649141d7b2c449418ad5daa2c896789047f64810a842386a9614a348a9234f50a1a44b2b8be2019eab039121c493da854ba14b35aaea3b620a698b1d0e619a420610401db44c15951d3e9924cd316e6a",
                    personallyAddress: "9e23815401f5488b8f3fff826974a4aa1907661bb0b64d99b8ca9b63c7f2af611838996a161c4fa789ac7564c2ce0b85d253c8b285f44d4fa9658c1a492ffa72bab78cdabb8c4df1b82cc59d63dd7e8b8c6ab4c3facd4c4691f202d27da65c370ab1a2d7",
                    extendedInformation: "7e1a8019f3a746aa82c7cf3d2f90d3a648b7949ad0b247749ffd0fc73a3dbea570c0a30a5a12419fa04599bf39a21f03cb3d01a2860a4b2da039260c44f4ba0e312df24ac0734c788bd857d889359a5f542b56ac42374f57a5211f7550b312badb52f04f26bb49ef94f64e738237f8e930281fe4e8114fb3a8df84f8c7f7e00cd2d0c992614e43c9a7010227eee8981c35acacd37b604951a7a0f3bb698c9a4dedcea8ede49b4aa79578b520fc8f0ee73374f78d28b849caab49aaf85a3b196ff6465fafc6344bce8281d5c92992873588a247398a054dabb0a270728d28c6a3fb1742a41bfb47129bee21612dd7b7c64aa96d57882b411abc92",
                    note: "e60d97bdedce48acb80abb03017223f5e940922a6b4b4cce9d92f99f9e54b610921623534cbe4201aaafa65c9583bbf47436a5301e5b4226a842acf1d2be9e81f48efd6231894bb0916c27807728e15f87f36c9ded004699a74d0c62430c2878d3b504a7e33140e4ad83e3d08532220c6c76b23d7e84468f956c149cea5cc69e605523519dba4c928993430115da0d9c667dd62f2905436f8104a9115c156071f7b2c8c1729749a1b6988f5968b0ce2d63ceb29cfce54930afada6d4f6bcd9648bc6befe95cf4e58b1d104e6552d1050ff6f5c4e1caf474a9d18cc8a66918092d19bbb944edd4da983bded910f387537c58fe5108ab7440e8af3",
                    status: "dd665ed47852481992e3b8d4533686969298cd92b39743e4bc"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}