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
                    companyMainId: Guid.Parse("92bee010-9b68-4037-8278-ce61bdfd6c49"),
                    companyJobId: Guid.Parse("0834ca45-20be-4b5a-bd3a-adbd0ef00ab7"),
                    companyInvitationId: "7f2650c3fef14f4d817eb41301df112e3b3abb559af24c0b96",
                    verifyId: "bdbf87e3ed4649a1bd3edc8d828e3855314820fb5c634d69a6df2f191e4d6fe13297c29e685d45e3a307c676f0abe1cef1c41572ed7e4dea957e8d1b37d684e6d156a8a921474388b7da3f59773927ddfde91c03e3df4c3488d7987dad4b724e7537685763724fa08ad907877cc67634f44839f8209f468c9d42af3ae68367fd964046b3a432430da75662ae7991b9ca32442b35a3f744919c78e71d095c8be30735d0b28fb440e2a153fb9942fa2f1d9ed0117d2ea24018ba6435b98a571f0290e7918039b64fdeae834646046efbcf2d867d74948247328752431e924f871bb71c2874ce564131a025454687a949266fe7f1432bf248698ba8",
                    verifyCode: "2ef5fd3a13dc4390b7b4ad36a7c5d5db73501091eb614c9682",
                    extendedInformation: "5a6958d47f4445768a8c1da80ff043abf48d2ded17624fcd8a537a8536c01ac08e44a5eee04641ee9c406ce9052679ed4bfc46ae94f845c4866030681c772a725be971c225fc48e59fc0524f41e4d1880b6f87f65cb64c639b909a58953d228c793ec57e9a8d40aa8513d95d46cd84feea812a03513a46f7968adcfaeb75b08762c1ab26de5348788bb965a7b99d33c4a1a6c2c4bcf749e2b37213dcb151d80ec28386fe4ce64775bf5c111eea0c5f0cc1b427b18bb848259675e8d6d9afd6fcc34f1183fc5448e7a080de6fada9bb1663204ffcacf34434819184b690705e7e53686803f1ee4b0a942aff990387f1c336746fd6e48744cc9887",
                    note: "f9deeaf42a5f4daeb46df3e00fd95fa2f2a7f044e7ed4594a114302455d605abef78ff5722f54c9a9f59529f5bb8b0d7021187b03e314b75883ca370052f6dbea71898dcd3524ce7ac1a18faaf92ad1ce0ce4f85b6d8426c9473d2fc50dc7eb907aa59238cf645d3a608d5c058bb2d75cbb3f79b730d44de9057c6c6a86fa92545ddca5609e5490a8f1142c705fe51fe03cca3210207480da76dd9a5823490ef9ceb32f657ee4216978e6835c1657ba8af15291c7d2b4842bbcc1f47b28f6d9cc5501fcc3cb9474b9753b7c8641020a925d0f9916b7f4d86a11b09c508e3d9c78111523d1f3841b1921bdf201357a2ce9025ca465f0b49cf883b",
                    status: "4b318fa37ee44ac79e5094584d2de62b19edf123b02449239e"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"));
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
                    companyMainId: Guid.Parse("2707feae-7486-4886-b2ad-f2962a4bd1f8"),
                    companyJobId: Guid.Parse("c8a395d8-0173-4769-8ab2-9e74bcb9d9f2"),
                    companyInvitationId: "3546c48bf69f4b32a0cb5cba997665d73bb584b366d64b718f",
                    verifyId: "af3b4784ba15463b8b4c45bb8bbe9e6e3a58d3cdd248457f92b38b7540a27f8bf72150dbd01b4487a322baaf3a34a9907e6e0ce8623d4b00aacd3c8bc4e68caa5a3fc704656d42cd8d5a5c583b668725b2ad319170c647d9b5e89e24f67bb85df7d8697101914f318890614f2c4af2186e14c85cb62244fd9c7c452081017583f2baac376b934d5eb9170791339066bec5e5f5ef8ca34778be481e9e6121506fa3891f3dd0fa44429a4749566eef4a35f696052f8765494bb94eec2ca4b778771f2ac8d0234944449f30c2f462db7cf9ff643125898a45349a75e5f5fbb113c29492a9cdb76241ba803beced85e19eb765b4007876b14c7ca6a0",
                    verifyCode: "00415fe519184e2b8dd90cb62307123a164a4c25c3104bffbd",
                    extendedInformation: "d55ccbb606314fbcac468fa7b44a9a985b282b7fc9fb472db98adc853907bdd66e45b55313224204a81a01c12540b7132e7e8117e621499e9ab895d2b3e5a80693e9a35db7684982be10f5fef52abfa981a892ad09f54cebb6dc5de32cb5cd94604e60f2121345569ec7da67cb817fd2b5f60ace713c4301b722120c57ebb95473e306196c56461cbb9f228242efaa4666ecfd78a0ec47f18793b66525df5b83589fa4ec2df74aa788c893e56fdecc096d892bc7d1a542859f4ca4cfccc739e53f643b33ceaf46b8a774d1ba1e38d1df4d473d931f12422ba392265c4bb206da8ed7915395a14bfeb1789fbc9d4bc88305de2d15a5344bb99e3b",
                    note: "f2100c62acef498ea564269740d2e89ff8ae8833c9f04168abdfb2416364f3f7c259bda1f2bf401ca7e09529edbc8a665904da2c6a934abbb131fb2ff10428c2eb71f876260d497fb3aac7dbc0c20e3aa918265d8db5469bb33b284fd96724a068d5ece37a3044f7997f6364046851674f8e6806ec6648b3a49e34ed41221bba93ddfb9eab88404595b5898ee38e22b3d70931f63fab4a249475d90b42b5609537c8682ea13f475f83172fbd6f7c22be36c54db41c6048a4ad20ff75f90b7a6f80ff92e9814b485b9b8ad9a9f458945aa9b981b8e3b04e3d9f0b74fe3564af2bc75209683f214bebb8312b07407a751abfb61e50cc53401c80aa",
                    status: "0722d8204dc44a38a4f940a66cd7a3b1ebf8dd08c94e473f9c"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}