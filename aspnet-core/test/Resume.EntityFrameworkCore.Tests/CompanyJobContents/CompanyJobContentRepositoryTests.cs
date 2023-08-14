using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobContents;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobContentRepository _companyJobContentRepository;

        public CompanyJobContentRepositoryTests()
        {
            _companyJobContentRepository = GetRequiredService<ICompanyJobContentRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobContentRepository.GetListAsync(
                    companyMainId: Guid.Parse("df77704e-0874-4455-bb8e-933a6d47174a"),
                    companyJobId: Guid.Parse("68c6d14a-2949-4ea0-8dd6-56e03eee5ce1"),
                    name: "80ac0b5e247b447f97157cad8af7fd16a16760e7a471479288",
                    jobTypeCode: "3b0ece91017f4f16b10ba0dc4bbc280fe9dd3f738ef5481f87",
                    peopleRequiredNumberUnlimited: true,
                    jobType: "3a552aba46614407bf8b632de06013811c4be36594034d828b12bf60857b21cbff3e99d7d2ad4e059e0f5b1f8ac62d7027a552c22b5f425da6d73edeaf8e3c63cd380470af514732b4439831614ba4bc54074ff7b8b94079bf5ff9fe6247f8ad025dbd0c",
                    jobTypeContent: "ca3275bc32ae4cd089b19207f57038bc35da31edddcd4630bc2fd5a1000d1f1df87fed5aa6144c4a9080f6c1f8",
                    salaryPayTypeCode: "7fc2e120701a40b3b2f149d41f52cee5c3b37871256147019b",
                    salaryUp: true,
                    workPlace: "2ab9cbd4c3fd4c75adff0af1846fd8d5d41ab0ffe8c24a6fb583b957c16c6da4f6f17f05e7fe45c4b519c3679053e3c8c9dd40fbc8a1456cbb19788a43a4efe29f610da062cd4cd8aab8b09c7e1b0648d6cc96ac365f43e18b1cd5d6ebe2741dc8d3525c",
                    workHours: "47b33b2cf3a145b9a73f75b4f186efaa45129884c6d343c1875c5a049a560b2e68025f6309b44f1996259afd483042b9f741757473a14d8ea9227d85a8184d4ca4712c5727d040e3a072dc931973b31c9017d98f0a934460b461d319b1c54a9ec9b1a7d6",
                    workHour: "7f8446a557b14badb94b0cf4732e02b0cea6bb1e1ae5460fa93478d70289745ea2c7e82e35954af495cebc9a712572386be0a5e283604c3484a6655f61d3952e59a70aecaacb48b685140355fedffac709737462a698400592235961d982caa8bdf8fe6a",
                    workShift: true,
                    workRemoteAllow: true,
                    workRemoteTypeCode: "81879d6a72b441d186f231fd60496edc7cbbbd3fe41346ba8d",
                    workRemote: "5371d7eb121f42a289191a26a9152c4fda465705b2224bd1ac3fce5aa7058dc7b23a22c2a9ab46149c537b7435ae354c1df6c7854e05442c950581892b056fdc406a61d96a754af4b46eee279b943851f0d2c11bb41e4d518eb6071126a86f06db223b94",
                    workDifferentPlaces: "38d36c901a644f928d7e6748d27ebd05589d19a4690a42ce99195716a61322f702cbf896fa184a839cdd0c8c7589e2458fe5f8f581404f938a1a3f32d29363806395cf66991341ad8f31cc6b2972bc81ac2280f6c7fd43efa70320209eae06fcfa035ba5",
                    holidaySystemCode: "fa8493d155844949ba31882f4caf38244a28647dc8704b0593",
                    workDayCode: "109c2fd2a95546cf9fbb9ed82a73bcae794c3a4557b84d9da3",
                    workIdentityCode: "d90790ed32a94744a6d5c1761ced191c59b209baf1214fed93260afc6dce953e1e04487aa4794d2bbac4e08b12a47d0e7433c863f32647838f0f3ca6440ae04dc1361a5bc1ad4065aed8b50a5b1e3315b67aab562b114d70b7a2e11fdad8f7d25611e9da",
                    disabilityCategory: "62c537ecbcfa4969b53a4ca8cf13dca33223ef49d4624313bf7a730f48d95e29fd62cde0ea9d4f44893f7ba04e43d19c80aeb0d323e74547bfb038a0b38660cd451a2462bdb343409eaf8fc7dd7bd52263ed3d9c91c44e599565b8a56ae4285c9c4255b6",
                    extendedInformation: "bf1473c577f14317965a824589a6969164298bc317af479a90b472af1eee27d278fb709d33ea401287372424b280344de763c0e931364fd38f22b1855aa04f7551bf0edf2daa4771b38bd9409c052d103e5e8f12d27b41ae8fc5ba20f85e591e366e42bddda347bc928d1f6fe85a972205c197d7fbca4282adb80f57ba103646ce9270239d874715ad767d59fb6079bc4b131559ddb346e19f02075c16da5d6226349ba11243497ea0784ba0a261b436356b0aea8da6452f964ef9253ec2674c5bfb1b6791484e55a5958a9744e50ea8d4b2681c2d0d469f959e65dbf87d650b801373004f0e4be08769ecddb3e3ad4f75ec4dd1cd0c440b8c7f",
                    note: "a14112ff811c42738300bd92435d5f57ad3ba03983ee46be9e1d5aaa46e37eb9ffd521a5bf064576871465863944bd093baadb8374394b84841344f8f17649675a82c6803bfb43ba82adefbd0a9ffe4393a179c24bde43918749d242e78237808a2cb6973bf146d0ac9a8adf49a39632f0b63e37237b41bbb882790966bef68d8a7cca24c52743d1ab973b6b73938dbb43333cc41cad4f98856c193579501cd13e04830abb8a41a4b8b0df071942dddb888913fbe7c546b4b3679ac6413b3547a36050a600b34ed8b48f5df615117781b5ba6aaa6c0b4880b4cbc8f536f3229ad6eb828a0d454dd4a01df5e23804be5cfffb15e061ae45088833",
                    status: "bd1d86ed4cbf443e9bf37245d875d949bbbbddb15a824dc180"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobContentRepository.GetCountAsync(
                    companyMainId: Guid.Parse("c3277102-ec91-4ff1-a0a7-fb3de01e77e7"),
                    companyJobId: Guid.Parse("200186e1-61eb-4168-a839-78e41c4dbbb8"),
                    name: "b5c0c8f17d8e441e86fa400d6f60b331ba82ffd0dd794bd8b0",
                    jobTypeCode: "7fdd0cd467304018a570734ca863ad57da3f0acbd0f94151a0",
                    peopleRequiredNumberUnlimited: true,
                    jobType: "34071fc35388404a8aa6dd4d41a5ad279b6eedd9e21c45b6ab015390ed4fcfb61d04308f31534491ae87d7d9ae8a112d2ceb4611f022432f9d27817210e89ef53347aa4d4a88427da53b362f65edd481d44a83efbf354eb884ccd66a8469e1e5b5f9066f",
                    jobTypeContent: "9bd1588171364c64b8a7e6a8afa354a030b11895945c460a9df1b0cb5c0bb998508ab20ca6244026a5f7b482d",
                    salaryPayTypeCode: "47f55ae10e3c4aa2bbb757322b6348bedaadee9f9a194f558c",
                    salaryUp: true,
                    workPlace: "9d800586bdcf40bb8533a395d673aaf0f52c72230cb944ccbb8e2a22e73618e4d0568c40537740bd87478ecf76a4637cc102823a59b748f2962d1fff8f2a6ae632072e0ca3aa4906806e4e4a32bd6b65a8936f837fb64da0a8661525a915b82110a669de",
                    workHours: "3ee71ad336b4432380f20cd716a9ca3f0e036e94d8354ac087a59b9ce40e5466e5f94caceb9d43178ed227960279976a9ab00aa8957947b69846c16ad2f1f5b4110c74812fd04315a7eb266934cb15603edb314c0f59432eacf3323441ff45b06690d447",
                    workHour: "f9ddbf54c13941b98cd35cc678050c611debd7c5125a4010bf2506286cf9783fe1b2ba191b01447d91cc1c7b7229ef1994aed0583c574ecdb973237de774a85669fea7f6d31d46fb9a52123c16e1b846ae29e1ff6e584b7e9e2afcf4e9c35664260c6c5e",
                    workShift: true,
                    workRemoteAllow: true,
                    workRemoteTypeCode: "ede2098ea53249da9f3b9a3aa57e0ff9c96f3bde3d1443bb9b",
                    workRemote: "e012825acc9e4927846a7c1891bc484ebff908f014e344b2883fe15d64de51eeccb0aae5ff2b4ee09572de11774092b27c443e1758d340a7818ef9b94c7b14d08553fdeeecd245968ae22e745a001f1158888b48534645d580cb91128fa4650d281840f2",
                    workDifferentPlaces: "78a0e6dd4e8c4d2391ca20360faa7f566af962d132484088b27522e3a265faa10a56a632fb98405cbb57f4f6e01bb1eb9dcc3fd75b4d401c8775cde34819b360aa36830f4dc049809d5087e70cf43df60aa7072f3e604254889a3a45ff22c9680c3a8db9",
                    holidaySystemCode: "e883f60c56364e448fbd75e7fc06bf0c8ba0444fa60c4adabc",
                    workDayCode: "1673473125b74d7295554886fe0ddb8b443e8e18385f49bc95",
                    workIdentityCode: "c9ba65870dd14227829f5a226cba3958d6d3ad78d08945bda76c53c3a90f8c9ecec65b0d4a1a420ea9438ab836789be6a2d2ba585ac74bc5a1dec8b5f398b3784ecb6a76a5184f8f894b5f2c3e664fb4ab81f4bc1608487e862a47dc8c9d90c7accf2fa3",
                    disabilityCategory: "858fb8d5ade3478eba1add73dfed39b5c3523e07ef394ff592ec94fab6f6f8630c97d1a8650445049bfd716dc52ced6b685fdef48d234a33b971e0e4782acbd47df43bfc12044406a42a8f8b8014254e2eed3632f90748788330842def1f9f309ee0ae9e",
                    extendedInformation: "0f0ce0b94d7c472cbfa0b9373c9ae6df5c1fb00f37b746f5949a90b283c72b5ab5a45e0644da4b3185fcb5812e09ea6c6fd4c4dfb48640c092350bd9178b5110f98db924c7ad45abb9a2661650c6bc6093463b3df1c84307ae68e13fe0e97436f4d62e0ebe0545b98744f2843a5c87f573a2509ba7de4cc599561a7d59ee5039c6ffc5b5bb4d4b7bb1c48a5fe9161e9e9ce8020b34464421a640cfdd6ddd0584b6129fe618964ff9994ae14e0b657cf951612e4f50af4309855f9bd9b98ff7f6e4c4e3f1701742d4a5d227460fb62bec8b6fca925fe348448b867f73f2629e030f536edba7f942caad78df46c8ccbf9d50d27cf123c745549060",
                    note: "8b583af38dcd4e46b67627b23c596e4646f7cef6e5d945668520d6369bb4629cc92014c781504b46bc608e359cca72fe665e8a64208f4d588b494b5e38487fc9bccf6ef7313c41d590446348fbaa86f7ff79c13175004a0f81343f98a4749c982c22845eaf9c4d09a25e5e58f992323eff774719c85944a38c9ffa1de6f9945db8d88d6e24a944f390494eb7726af659c6876ccf36ee400597644cca6a24cef327114dd574c5492b9819ac7057a671525a4aa42698e84251b622d45278ef145b0068fd1872824dbbb44ebaea42efaf55355f3a4f42f340c49406f1e46fa74b2301e6eaa333e841d2963eba54a81900c95d0f533124d24193b619",
                    status: "a97f9fcd638841a7863edf46406ce8c2d9680d1ee5bb43b7b2"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}