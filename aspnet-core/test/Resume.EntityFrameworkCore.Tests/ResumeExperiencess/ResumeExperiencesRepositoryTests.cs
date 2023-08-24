using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeExperiencess;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencesRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeExperiencesRepository _resumeExperiencesRepository;

        public ResumeExperiencesRepositoryTests()
        {
            _resumeExperiencesRepository = GetRequiredService<IResumeExperiencesRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeExperiencesRepository.GetListAsync(
                    resumeMainId: Guid.Parse("07a4b8d5-f204-4b8e-8521-f7df9a49ce56"),
                    name: "5a05f2d742a74d89a2007a24c1ad4134937183982e84434793",
                    workNatureCode: "4238ec7b5d5442279f85f9ce1bc63bf66dc0184c31eb47ad93",
                    hideCompanyName: true,
                    industryCategory: "0030410f3bc34990995c564e348e029b52bfc9e3bd2e4ede8581f04a20ef2fbc113b72b81cf4491b9c8d70d02ce8309fdae74f1d69a142d1971a54598ae15dbf170fd5a36381493cb653203ab5e1c9271cf519486ea44d0994fb4e5f1f0aaef5130b5801463644dcb0f9cdd4a5b1ed9f01b989dce52143b495253511a4d4191126f291fce3224afe838e5edee9511dbb27e9654dc7604bc18ac30d8159f035403a74da783f7e4a228307fff5a727d5949c9b73bdb6594b52ab382ea79d2e0ea47906a853292344cda1b0d4b29b58359fe18a687aeb944ff184ef51b0e2b322e9ccd24aedb346436396d4434c18426d900554749ab0db4d8daca3",
                    jobName: "7aed786617004ba7833bd884961cd7c7a352d53cb8a9402594",
                    jobType: "fcea51f035454b72ab5a95447231706e4e16910ed1874a818e49a34122570f6596c95cfd52364cdcb6e9a9f3623d2a79f671a85b26aa49bebca27a9ff322fdae46435971f1a848549c42303b549e09ed8557821711a44f7e9df02eb92f22e11c721cc66c4455459d8d1af03c301f0839c3bf7f3bb8374c41b7b445de7c8970bf1acc9678c04743dfb0c1ebf7e6bd997cafad4cfa352845ca9aad8e22dd60ea8a62c9110083cf408391c7a8ed3adf85c9cf771133a89f415baaf67b28f98d6272adccd162bf3541fd8c64c704874d84f9adee644f405d41efa724e80f5f8ddd863b68b6aa294d4706892c43fcd3a407ae2ee8878079ef4e09bb28",
                    working: true,
                    workPlace: "b03ba1f1c7874bccaae30c65156f3933638d6ef80ade4d41a4f3f7471c0bd03dd39ee8ee9f514780bacdc6c73a33836e23c6a2d90bf34c2283199241617ea1fdb122c1e1ea6d4e359fc798f2a70d2cb8d0bc998e8fa3409b92c7cca371e590231f07ceabb3db4056bc65fa5b9240df4abfd71660a7f94e6ea3033a3c5c35948328593db08225429e9a88c38e0479c5d1a4d721a3414a480697c7ba5bfa2c5b5358e6ca04513443fd9ac1e04c610da3c7ae7902471f0c41198487ecd54cf98a60599d2cc474944f9da2d1fd815fb3410b17348503b6e14de4b1d9a75087ddee39bd1cd79d178c46f88ff6510f5224074c6ab53661d98b41f5b38b",
                    hideWorkSalary: true,
                    salaryPayTypeCode: "9459f79f175c41b0add33dcc541f06684e50e9979fcb46a3b2",
                    currencyTypeCode: "7ede9abe8ed140b29cb7c485c164804c2ac5bb8f8c5e42d596",
                    companyScaleCode: "1b91136ce01b489d9e1893f852c9842776ddb8a3557449deb4",
                    companyManagementNumberCode: "cd7725aec2e54a31b259bd4ad584ac49a68cd2afba674ec68e",
                    extendedInformation: "f5a2dcbad99b4e16a8e62182d02568aedb288602f1ae40b2a701befb175dd506acfd265d40e140fbb2a5c4f82e46870204187e7b0bc54b2eb302ecb15db628903f486a78c6284d56a2809d58eef671d664d46664c4b34687a65d52e6917ff5b30773a0a0f20f4e3ba2dd8a9169f540f5eba04a13e0c842b285b2164e0d3bc97247d19de33a4c4267984fb87ae3f5eb60d54cf80e595b42d3b2b8ea3dec80abd4eeaab57c32fa429e842198861afa059aecfba61415b742e590daa6e32ce4bc70b1b4a3d4e861412ab172a71814fc02afbf34e92df90a47eb97ce592b4a267b0c33fce8243e0a48f6b201e5b1478785b7256e844c89c74657bb45",
                    note: "df4ad9fc617946adb440e9b51a168d99f9712ab88c7f4b04a42245b76a1253192903b37ec8974cbea776a191bf65cbee98fffcbfe515453e9500a3f5208c0d4425f274fc5e804c549a8a8a7858e3f345e41615cc7ab44c7a98f0e5873e51e45ba67241a176bd472fa33e3a140113f6584cf65cd35c554948b5e443c188a07015a24b6fc319284e1eb0f1ed895b9f821b6e1b03c107e94ea185f656a9250575c5ff0005738fab479590a1695490a97cb3a3b0a60c43d9427885d352691d8fe9a419f3ec7ca602430d87ae637bd5bf1fb64f0bb54955de4d3c950673682acf506cb3e3a5d65971407b8859d2c740b8bbce014fd9f7a88e4efcb88f",
                    status: "5df64a148b6340aaa3da1ba301c806a9d4f0513d41104c0287"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("39390b1a-c4a7-42b5-8f1b-6aff1eed7a40"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeExperiencesRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("dcd6fd28-8fdf-4466-95a4-83a96cdb7795"),
                    name: "85cf057bc8d4410a816a0b5a67daa1e08fbb2f48d18f41e8bb",
                    workNatureCode: "8b6ebf867f984d10acb5f5127a384af834a9fb530c184432ac",
                    hideCompanyName: true,
                    industryCategory: "b9b34254d40e4cbd82590bc8a22ae9f5766618c3da45474084fbf54340e0af0249d24549e3904cbfa6b57e9d41733439e5e6537c2ae345a9a3c2285f3f7247aa4407056fc91f47308b8f03a14ae9f5fd5d6526e315fb49e6b3789dc38e234b6b97c0ec351d0647d8a7f0d0574dd1766d25d9236aca394ee09d43b258078c5e1a69655705bd52436f93b2d851139064ba624700bdde0e4deebdbffd758f959f7fe150915f07b24d60a89c6d61329f72ad2a35ee3f14cd490c916fa51c0944550daf292105c68a4caeb51b311b94827287f03f6c0729cc4009b469b88066fcefa773e065bb2233419d9585c2629038fd510b1d7e3932724f638713",
                    jobName: "f67b6aeee464495e83ca3b22d6e6a8fd59933d07f4a24da3bb",
                    jobType: "3a78fc3d4f8f45a3ae08fdd3680f7efe7b5f009eb5e34c04b848434e3b1589e46ba7d1663632443b9a1c649c8eb310f784bfe897998644fc9cd0e8228f40fcce8dee9280bca849698a4133a7c543755b7da4db887a924107a6f84e653300b5ee8f8abd2cf7e843f7aa0958f8547e6e6a753f7662946544058210c38b485e4fd3b5200b1b09c1486fa2a77287e6181601956bde9531654cc39eca45db72d4a87123598147f2be41cfae4860f37c0e0ae9a49e6aee14f54828a4d4c9756392fd68f16c32c74840419e8c72495ab6523fd2fc6c2732c31d4e5b9044a17da415fa36f0cdaf4956f74fe0a3d04a53164278c61ff9fdfc52c741babc92",
                    working: true,
                    workPlace: "4534efc51de4412b8ef11ad22f659b9976b021ad24034f8999f0e6c658b2b78efa8986a5bd3147888efa1c505a481665ea3b2e2019b143aca268777c38f02893bc2e5a199bdb4127b85789fbf19f647492f65ab1951347a7b91e5c5b20fe552db4ecebd1bf8e4577a9bfa5b83a95c97d52b48678782e43e58ce2dda57a3650b5e3e68238bf3347aeabdb1bc30cb43fa7eea969d663904ae69b2802d7a3f56b5366be9e101c3942bd88e8a4fe04e06afac89da7cbccab4ba1839355acd9de398f592ea50eef0141b49b93c2665da15fd1711a04c2569f41e08dd22a0f27f47acc33669b62df5f449a96ba71e8c144b3258f7df7acfe644680a928",
                    hideWorkSalary: true,
                    salaryPayTypeCode: "7001917a96424d28a583162d5ee3afc267190b8147264784b6",
                    currencyTypeCode: "dc384057baa244ba9bbe58e34d0d4599e9899eefbbb54507a0",
                    companyScaleCode: "b8ef0d9f6a0c49d881ec9cf7105dc1fdeb40ab71ceda42a4a7",
                    companyManagementNumberCode: "25b73951f66645828e0601af973485be445ae6be271845f198",
                    extendedInformation: "3a6bc403c2c8424e8d7cd1a6dd82a3761434c27393e34c568629a8671ced145d81e19a34d3f64f63964790fd6ca883d781904b3a0a98438486dc0066d5a2ae968e85ba4b5dbf48a6b73107bcd4755e6a765f35a11e8542519a9443876babeef3503012adbd27495998fea3bc05ba399dfc2adf96b7f24a0897c8a0eb517cd95150cf1d8d03ed4ec9a01ccbf3609e15f4abb0823f10db4a869c462b46ed7ec6902d1fa4a58b494c168d3eba6c4c1dcb0d1efc4e77b839406d8d5dfb5cfac68e0c760020f8134e4f48997ce5f588e6e4bb6f8895006d4048ae9a8ed9ddc6e8f42b77f310628b0d4a1a873fe4c65454d7ee388f13cbb2d84b699621",
                    note: "f901e0aa3c894a688b5e4e93c27c2760a72726f1af0041d8b7f062d39223d26d6d1b9a4df6804f92ae08a8176a78439dea321f38ef464d34a361f74c22837deb5b66d646bd774b58a4c10133129998032df6160ec27d48c9906dc80121268e560f1087da8a6547b1b945e2ce9cc8bf659c0864c4fc224181b8678e759b9fb94df72486bdb0ae4879b541a5cee18c816693e4791f9a7a478eae085c817473e644c4b8394e7eb347df87cb4af71f7dd409b4e3c574fda443e6a2cd73d8bf494c04aef6ada40a53444198f9c2ee47e61bb1a5147985a5b744089738191869c743750745ee438bd8405e9e933c2f25ef585eaeada4ea9b884cbfb966",
                    status: "923246bca52c4ead92cce686e9e2a1f99eb54a64dd1141bd83"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}