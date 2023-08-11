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
                    companyMainId: Guid.Parse("0da6a12b-89b7-4abc-a131-712718d2d159"),
                    companyJobId: Guid.Parse("3b08e63d-d554-4d22-b3bc-3cc75dc4a835"),
                    openAllJob: true,
                    userMainId: Guid.Parse("b23c6e7e-928f-49b6-994b-b95f2e247a44"),
                    userMainName: "b89626c4be25406dab5a8e544ab07db0be092ccbf18042a081",
                    userMainLoginMobilePhone: "385f26ed1f82493895988b9d45b4288bc1cc9415bea642d18a",
                    userMainLoginEmail: "6b5615c4fb7d43158608341cdc35022c0bedfa1c5aaf4461bcbe5e2f6e61a7f0fc1807ae80a24e13a9a26a1754188160771baa8e77254ac8a5ac485640f5386dffe1cfb632f2488caf97ee9838caa6ec05b0e5f7f7ba4d2cbfef4e3289d32cc0adb556ac",
                    userMainLoginIdentityNo: "9853cc50ebe84a588d6d3f189b5a33d063bde91378474bd686",
                    sendTypeCode: "123030f74250402fa9703f7e315fc84b461e3bfe20c442c4a2",
                    sendStatusCode: "39f0bcb4de1f4cf08cf943af03671a45d80819cbc6ea497894",
                    resumeFlowStageCode: "c150ef2d7a26464485bbe2e80e37936fe0d1d555003346bd94",
                    isRead: true,
                    userCompanyBindId: Guid.Parse("5ee3ce13-527e-4dfd-a72a-be21e48ee86d"),
                    resumeSnapshotId: Guid.Parse("2675d5b8-a674-442a-b804-996e09ffbdd1"),
                    extendedInformation: "199c68474dcb4c6bb40dd61c7844e0f072a52c56d6c946d89d8a7df418213a99e53663ddc8044ec396002b7301b5e08f7654a05d7b9640858b8feb5701d65bd2fa9ed326ec084d40b9645f51cf83845cd94d6e43b3224572b4938e7077c1880733c49e8a13b24e8d82e7a6f5da1d1656e4ea420e4f3e4ac594c5fa547ed06e0f4d5ec05030fc4fa3a47c23e98dc20644d022821552f64eb9bbdda8be1309cc29d6839e6f096443d4ace59baa3515dc0ffb68aa3ea5384a1bb92ad87e2575ab19b67eb94f351646c5ac9008df5c7f1f2056546fc0c8e04df1a8ebdb924555119b96320cd833b64c0e91bc75d63ed0ae741b6b636756014ed68ab2",
                    note: "51d00baf5db1445098cddd7c25caeea0e11a91e657a3417d88dba1877b9fd67eaae0a05c69ff4717a57bcf862e9acf142dd1874c96734618b966c454e209da7e38aa84287ea34ffb96646320aad688eadbeb5a20caf541f5933a6bf0e6816c180e7726c4ace1446a9e9f304663be3c2372301572025d43ab8b4e83d77e8b3f74fa751103faad462ebee5fc96390734a5dc42a158ac5846d99f869cfaa3fe14f18aa3e91904c445d686f5f7510791b16e3dcb3e1fe2db43a48e5cfb0df1dfb6c616081cb9083943a289ec9dadc611dc9d55a677aeb2a54471938e04ca62b04316c52d57241e2544d6b3b1c9d0eba60afa4d26014c1c4c4ac7babe",
                    status: "3e2f039b841a4ca4a66e2145cb468e664dc6aa8e96294fff8a"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"));
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
                    companyMainId: Guid.Parse("19c6407b-2d52-4338-bde9-b91e8eb824f0"),
                    companyJobId: Guid.Parse("83ed56c7-d794-4321-93a0-8f84033a81a4"),
                    openAllJob: true,
                    userMainId: Guid.Parse("efa4f174-861f-48b9-b92f-41ba29a7842a"),
                    userMainName: "762db9b60cea49d08b6b6d498c59b56b7bae2d1f4f724085bd",
                    userMainLoginMobilePhone: "ea9f8e5e0e224062bafc12b790bb6f329de75dd3cb714b23b8",
                    userMainLoginEmail: "92f117e6beb74d898277dd649ea20ea6d017b630ca62455689906d53c7009ff1ebd849d871ff4e2b8f35a5576fa90d1f31a2f4e0dd3f4dd68234515bdbbf971e8d0af36c523549fe9a60d8045adddef47f011047c5414164906883535b75ffe68333f6f0",
                    userMainLoginIdentityNo: "d0b6d27739324085ba46c7609dcde33d3613fcb6e05b443787",
                    sendTypeCode: "dbe9b637c9254831b0fb958bae804b724e9144d76b744abc8d",
                    sendStatusCode: "60174d8fc3804c1c9d0b1fc8a904f06d8f6546dc9a4247b095",
                    resumeFlowStageCode: "0229b5863590424792e70b4f1f325f91c1d3840e172a4375a8",
                    isRead: true,
                    userCompanyBindId: Guid.Parse("409d75c3-b25b-4ddd-8edc-1d2a75a74c4d"),
                    resumeSnapshotId: Guid.Parse("dd9a9548-c9c6-4e24-807e-b37980db162d"),
                    extendedInformation: "2c7e175165c94a99b4ce4510df631c0f4db85a7c0e854f05bc83354904a7b07aa99513b29c7940778fae4efbd328658f6f792f2e0add425a931099265cb5b0eb106a2abd69564cfda0d7ac50c09099c95c999dd88695479f8f04b2d26cb6f5cacf186ce9aae04c56b12c53815259e770fa91fda7d2ca43b8876b93c01263eeb8f2f89c7997634d0dbf11e3bed4d6f566dde8259e49e54271a455994059fea030f1b5559c5dcd43cda85a6892977b2e0f6fba6a771eed4f9eb2c1848b86188971cd6b6c09e3484a478519e0c90990c1366b736ddbe9e14a1a9893de84bc0a4b0e3cc1891b28e34690b5521304fb0634eca8a0849da08e4c259388",
                    note: "39559c2c3e744051a0ef4cd67e5a89d7031287ac807c4c028b6b3ee087d99e4c43a7b5e43b3f4ac8a403f57dd772b87af362a1e059c94d8b9964cbb45208110c801fc85974d740e9823901d34602d8c034cbae58695f42b49c31d8c24c255b70dc43ef2c1d70494dbff0687092c0ab48e2e8e2ef726340a7bd150ffcadc0488dd752248c25b64876a9529ec043ce34c274d469e0deb049b3bf8848a6f508b67681af6908089e4c8db1aafee0642976e6d60bf5132a534e948547dc5f35d0d64dca82d96b3e9347d898ebff428b4222d087138115743b4800923b7693636cb1574d85edb36c7547f3ab042c419116661d57bf290fe84648c4a786",
                    status: "c09d628ea49a4a7995a8aeb14038f2ab7b18593aa9d44544a7"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}