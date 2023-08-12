using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyInvitationss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyInvitationsRepository _companyInvitationsRepository;

        public CompanyInvitationsRepositoryTests()
        {
            _companyInvitationsRepository = GetRequiredService<ICompanyInvitationsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsRepository.GetListAsync(
                    companyMainId: Guid.Parse("3d4f4f2d-244d-4461-8676-46e94d290c69"),
                    companyJobId: Guid.Parse("18b5fd60-2b62-4de5-8adb-4ccb2bf13f28"),
                    openAllJob: true,
                    userMainId: Guid.Parse("5088759b-475e-4ebd-a35e-24c265bd462b"),
                    userMainName: "7bee3abc39db4bfc90fc663c88d6c65318c0b21c76314341b7",
                    userMainLoginMobilePhone: "9d5ebe2c2aeb49cea24888d46fed64c880efda545c644d2cbc",
                    userMainLoginEmail: "8ebf660e855440189f1a1c81f7924e26fda2c54b0c954482b526e5b6f3cdb6ab270e7af344644ef1b818f10f5ff0ed86a02938d95084475bb11122776cfbdebd0bb9ddf798ad4980b4cf34fcc81f58c59df778bacd8a456a914378a0f99d53da4a260503",
                    userMainLoginIdentityNo: "72ea46c80c3f4e98a668b604b463677ae4501e847fa44291b5",
                    sendTypeCode: "0e00f3ebc365491090d52c737504f3fac2546b9149214b9988",
                    sendStatusCode: "7b49ce288067494d9e150866c25fb04333a941c81c6947c094",
                    resumeFlowStageCode: "1ddf59a829ab430ead1e2f8d2b3787969ba1b11083904e28ba",
                    isRead: true,
                    userCompanyBindId: Guid.Parse("40ce67b7-c397-4dee-8032-53487fb4ef99"),
                    resumeSnapshotId: Guid.Parse("a287896f-e5f4-422b-bff4-e8ce8cea79a6"),
                    extendedInformation: "61ab36b02ff34ad39b743ca8f9994c88193c6c0c1287411780b703b70e7aa3e722c5da389b5248cf9cdafb453c02e7c7b9009b8630e64c4c9288e72457626d47e8d956aeba2c4fc4afe4f3cd2ae24d1962a45d7608ed4867b1dd938b8439f588ca5e3bbcc4344c51b2220d3b38657ab0c301332435694f57b410a2fafe6b784437d0c16405374a8f88dd1def4d862fed942bfd51adaf45738616424218da660fb6fe3f749fcd407f886fb3fadf6befb66cfcd6e7a8374969afc034b6e94a3566588f25b0f5da49c7b1cbe1480efadb151f276312913c434da944d5847dab5132be70647e63d541728d1bd56f350c71ee976ebf9430ab404bba59",
                    note: "2458c4b76c29470c804614af0fc7812f45a7f10858984c8282a989e41a00d9287a1bef21fc07443d833fec5e2061710b63597d1f397544ce9f116319f31adb439eed86e841f047309409bb371c9f7eae1239a596fad54f03bdc85c8e12dfa6d4a3ab9896f17645c39a39fa8f9f1e88414e8a3655d2604c299bc07a16c759385a6300407d0cd6451a9b055cd508c9452dc3ed958ae5e6458eb7637b8cb9c2040164d65eb31d4745bf8728fc3bfbcbd5d112d331c51ae64c19994252c4bf1acfd79a9ec89d05754375bdc6526447163ac230ec6a8521a64d88b366bd99e4922e2c031aab880b334be9ae7cdf9a472143c226af339c341f46989015",
                    status: "a0ae6dd178f845b28187ff29b87b208d976572934e7847aaa4"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsRepository.GetCountAsync(
                    companyMainId: Guid.Parse("bec53c2f-ef7a-464b-892d-5f739483b7ad"),
                    companyJobId: Guid.Parse("4f0b4d39-38d1-4021-bda9-3902800890a2"),
                    openAllJob: true,
                    userMainId: Guid.Parse("1c6190e0-bb15-4bb1-b39d-96444a8ce279"),
                    userMainName: "690995598c264af1b40d7df9e786f2120cdc5d87dd9d40ee9a",
                    userMainLoginMobilePhone: "02246eba05d64f8e8443d39da4df3c530688d447d53e45e99e",
                    userMainLoginEmail: "d08d22d42e744dceac88bfdc49f5831e5120a999d6464ae892d09907eb822acca2b54c3040aa467e9894cb806cb4323d18904ccaa8d94d57aa4fbf1b3de3aa149c51892b6cd24c1bbbd0fd64a869e728c24c4140e34140f7a44e7dba916e71dcbbe42086",
                    userMainLoginIdentityNo: "5ce7013d04904e878144f56c5983a13892bb47211530463a8a",
                    sendTypeCode: "b68874b61ee845c7a2cf5c7c5f34b714239adf45a7754459a9",
                    sendStatusCode: "d9ebf5c284a64d5087a749c9afba13050d4f57f7d05949c5ac",
                    resumeFlowStageCode: "447935bfb6644aa0ab5ff23e2a1ca8e2bb4d8e890e474cbba0",
                    isRead: true,
                    userCompanyBindId: Guid.Parse("f8a2316d-3c49-4c7e-9961-06deb3ccdc5b"),
                    resumeSnapshotId: Guid.Parse("e5519cd2-d4c6-4c18-b9d4-506b5719afd4"),
                    extendedInformation: "c362592d8d874256a578d4a38a0f8f4661096afc33854544b7862327ffde5ae399da23035718481dbd7f19aacf5a593d31e38bd6f0dd4b7c9ef5994a3f2bf020fd5edaaae1c648cc82d6690b3ffced6ca933dc1f94a54f50a2c3b65a67990cfdd92a9114674441d599f5fb4228d696863fafc9683ebd45da83fdb7fdceace6d5017faa9626d74c59bec147bfb0147239afc94c9212ba4dbeb56cf3ffe1f21f441de0c4d9e4fd46d1a4b69631f5e70ccdde331f52ef514aa1911d6f0b8fcfb04c724ee26ce0764efdb94f072ef8e5fdbe389a4f5f305f4277b97211041da00f635c528c57fbfa4c5d87fd7edd430ac8896332f9784c1049dfb595",
                    note: "6a480384461d47ada4194ab5c2a4db5a48a0dc0946dd472eb85f98df733133df4d1b375f9cd34a4d80ca1af6e783626a3b8df8b2707741ab84fd00d38610c61e9962d8dcfe614c1dbb4257f96ccfbd407b2deaa16f8848ebbf6086b69e98e558c93961b1da1345eb80b62640e665d1509f4cd41c5f9e423a99ff70fdb012a61a8e495fd22624435691c75a3f8f8c2603226f7d482477497681a8ef492a51c0718e2f0f0b94ab42c7af47ac062f63451aca4a33d3fb5845db980a0baf2d2c5f31a2b575238d1e4819ac6d6ccc89299b898c358a9d32c545beaa49e40f3b1f8afed1bfeb1bbec146188d29b6ec6a9851331e4d7232f7204ac38895",
                    status: "c64024e7aebb423f9b1247a452a4004b6329845ff53a43f2ad"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}