using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeEducationss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeEducationsRepository _resumeEducationsRepository;

        public ResumeEducationsRepositoryTests()
        {
            _resumeEducationsRepository = GetRequiredService<IResumeEducationsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeEducationsRepository.GetListAsync(
                    resumeMainId: Guid.Parse("a0affd00-129c-4c3a-b931-3f85c3079eaa"),
                    educationLevelCode: "a3e30f9b59be41128878636fb6a29c8eb71061b14a6c4594b0",
                    schoolCode: "b5a37150ad3c490fa9ba364df9f69214b26197ded5a849c9b7",
                    schoolName: "004bb20f93db4a16a23f1215e5c49191c10aca7eea4a46ab9034241b5c323c7b4b6a3b1c213d4746bdf719a813775c8fe95ea4c530634215b8c7dcb0a5212c308e26d2f5e1304ccf9a80a5eb7a7144dca75f35e4afc64ac38eacf431e38d0aea0f8cb245",
                    night: true,
                    working: true,
                    majorDepartmentName: "521bce68f58f4b22abcaddab2187de1c18b6ac12d12b40c790",
                    majorDepartmentCategory: "06f26ccb0e1146fe89d7187a93ddb8899d8630d69d8f4718a15a7f56cb12c7cf59f5300814c744b7acf0b7a784881fc612a258e7369b4d7986ce58881229c06547630527a0dc47ac853852411a7c8c5fa79e4e82360a4d1691c8c993650ebca27e9c27a05e654541a1a05cef604e82385699a41b66b3402baa73fa984db2ed76c1b5bb89810b45d1931637a6d9fda280a780112aa8ee4890a0a154f4d2059a03fde0828782f344a1902d6c2997d1d3863c98995f802d4398a2c8c0806c545226fed80163a399443ca4d50269382455c971bca9a68dad450d86f150dfdafc0b0367f9202faba843a8bc29db8ac70291683b3f96f57e9c4aa8ad79",
                    minorDepartmentName: "207c485932a1401c8cab3268c67581e59e23cace14294e35ae",
                    minorDepartmentCategory: "d3560be1091445eca0c325fbc9b2718ca24204e4b989468ea9e86007e46fd006aed981ceb33445b7a2883be3e3da6dc002a8d484b4964033a1207f6a20e5a89c53b81eb36a6446f6be926c14e8e2294a743020b761434654add9469feeef745eb0ed3fee901c489f9b05393a116c1e7a6865f033194b4c549648f29cdce23b042326cf56f4fd4202adb21e2f5ff3d0f52fd23d746f9b4a22a5596f5dcd389b8fe7ea47e0304040b59a70d47bd0b8bd94e402706d44a642e69aa43823c60acb7152390d39ff174a41b2687abefa1bb5465746d8d259394b37b9d91436bd7e504c35bcfc6f8bc14662acff1e07a3704fa2c4e0c2d3433a4833b81e",
                    graduationCode: "a957112224924a89af2ea6dc23d6391c2ac79e27dcae4cc5bb",
                    domestic: true,
                    countryCode: "60ae132eefc34c5c8218a64a8c982f5888a2c754db63470d92",
                    extendedInformation: "507250d5ad55401fa8249cf1763e3bdd77a60a4dfa284ce186ab555b1d8c7c55accb9d03afa741edbf7da6bce623772a6a8058d19fa34e399ea381362dc5b3a9855d41c197f541e6a4a31ddf91f47741614deeabb08f430a95c7957c19096c8288977db9da954ecab14bde6516c36527d7e9ea80f844425c87bc043a5f45596306d805f2bb844ecc8bbb3f19cd81bd05ad54a31f2a774d4ea8bb060410fb4298f8ea21e1f4f34c6dbc3942d8d5d293ad9b43d8a8011a4bec81e7d82f840f280e7c4304e84b3f4475822d64e5a1f21c37491b082d81d946abb38c1cd4830c66857551f4e0dbf949d889901fba5dd2b471a7e71f6d17224bf6a3b1",
                    note: "af1393570340408e8baa8c8e6e4d2067592dd076d2a74a8d80c68b2862b171da71ac74104d27431cba26a56070d02ab9d67ff3877aeb40d6935839c6a3a286ea7bac89cb868c4e06a5872c6672646bff7ebb7a50298d4696acc70919cd990e7e5d64a9e1b7a8461eb778694eabf899c762935a0ec1754389874e3e309561b6db578046df287f4679b0fdf49b9b487b3dd07050425dd44e33a18b6339fdb407e1d52c9109dda84a9a8131da2a8546e28d2161be1a63294c7e9d2e206781955d46d61ba833b71945138230916cc3d35fe9f84ba569d46343c6a9dbf4fee88ac296f92f7cd276ab4d45a887306194edde0b994c2ac2a4c24f64a9de",
                    status: "8ed0d5a10cbe4ffb9bdf6b73a5a0281734d18e2d6b2a4b808c"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("efab13b5-a14c-4f9e-8f22-ff0c2becc1d3"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeEducationsRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("585dcfc0-2894-49f2-9db2-c43091fd074d"),
                    educationLevelCode: "0a0ca62762424295be081a984156b18711e440eddcad4550b8",
                    schoolCode: "afc328f40486420591dcf746e539da832bc9b8036a2e488391",
                    schoolName: "25a63c8a86b8452ab9ef4edf5fbc39068fef92065b464f2d8b9002ef01be1c316dcb5508013345d5b980f53464d08cca0d2599f2b7f843cf809a311d24d2339d31eec2b8e2894f2abf44406b481a0f1ced9f130c8485401b90702daa071ad80e77bc9d00",
                    night: true,
                    working: true,
                    majorDepartmentName: "c0a0b3bf32264e43831cb1f1cf2d999cfa29cca3b670447d8f",
                    majorDepartmentCategory: "0070984d68614cfbbb38101be26100fac2cd001d615c463b944c659defcb1db5b6a5afc94226404d86292fc568723cf763d1911c35074666b22c57d40490a224fd51f4092d0b4bb3bbcb8620e62bdc0b2699866421c0435f8d61f36d70db58fd7ab79b6b3f474c9c863da8cb2bb44dbe0059678534d846f1949dbb475dcfbbab03002bbcfdd24d129e274211eddf8268ab4ff26baa564d119b40fb1154b995a96803ed8a85df44f28edda041ead891beb6faecebdfd84400af3bfb53a5f45798927e35b3f34a4a1ab38e9d8a4544808b4f33c8d3441747dcaa10ca51d3a7b477ff1e8a12722f4a00952b212030a64e400f1aca29584b4bb284bb",
                    minorDepartmentName: "850aa8680848474f80df440bb0de83bd98bc1ccc58374b38a0",
                    minorDepartmentCategory: "a1c86c9e67d7407eaf23fe19c2d405e963f05eeabf02433189b78a0d1cfdd2ea2bb9d9f335a04f429f0c4baa54420ce5fca4eb792c0447ca92139e94daf54a8cad56eaefb1424c178079e066f67991776278cfabfac14dfc9b32116990d8abdd0a8d3f1e40c64a4aad15d120008c369c52f7c6ba367b443bac37b1f73921ccdebc04a932a48944cb89dddadb94cb304931a018e986124b00a09b6436ff6e8db29792fa437f1448798035eec0a276d974896b49d407ea4a40a6e732356b4bd84d58eb43cb2cf1453085beff46dcb4dabd5368014f39d94ae581a60a925aee6d39255334aad96145688e8c539d455e4c8d26674a2af59c4338ab1c",
                    graduationCode: "5c2cb0d734f1428ab44375e355d2b36f9273706fb1424458a6",
                    domestic: true,
                    countryCode: "631eb1daa1bf4c4698ed51c48adbb68b678fe08bbcb148cc8a",
                    extendedInformation: "a0294b1f12d84f88970ebde1d71e40870a5287c279ef4af88de60cfac332a41cb30b70473f7942cf9929fedbb6e6c0629a7fc34a80524111b0684c494610d2c252085f7310f94ee6948de180c6ff41774d4e24d5cd3f4fd781042548d7593dd860dde6f434914a6d8990a691f570b0e676ce71b1787a4a3eb1ac0637d5d7278db2811a86c7e34c9890ba550446b85ece3e164de54c01400ca6a19969035b3bc7aaad4ce80ff2426bb1fb6e579c09561f967904fa622d4969b69e77bfd8a4fc1f7167726765334ab5bd8379b01bc063f0026cdfa9f9f4437caac7d8dd12badf7339109e9556d84bb3a47f3b70c3a9a0a32fa9298a2e354f55b2fe",
                    note: "9d0b90dba7334ee6996d59aa62e5744b272bcf81eca34417aa2f4deca99d1bf6784f94fa3bea41efb45680b280e39b16f7c59a40808449e2b05217cfe941f59d63cee8a1490a41cd8c5fbb9d6b4831e6592e3098835d404f93d515fac22545aaf5f08946472748d7b7f2b85732a14cdfde9a949885b64f1d98f96267feef60f0cf600c1c1aa44e1d91f3f8147649bba707af64979e504819a58404e70ca1985cb036dff4c6394b8cba022158bcb2a0a35a5dbc9ed77e47f08c4fcca04056a89e59093e7e19bb441b8560c150f2fd8f04ff14c77049d44469b9d1d2a13dd3785d7226279f6aec409f928b5583dca3d01760762d6bf8ec41b696ff",
                    status: "a66a1d7d67e84c378225a4023ebb122b600e7d2aebfe48a3b8"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}