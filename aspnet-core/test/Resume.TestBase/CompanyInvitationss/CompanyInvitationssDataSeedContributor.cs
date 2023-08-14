using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyInvitationss;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyInvitationsRepository _companyInvitationsRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyInvitationssDataSeedContributor(ICompanyInvitationsRepository companyInvitationsRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyInvitationsRepository = companyInvitationsRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyInvitationsRepository.InsertAsync(new CompanyInvitations
            (
                id: Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"),
                companyMainId: Guid.Parse("3fe460ac-2ea3-42cd-be7e-814a6f093a0a"),
                companyJobId: Guid.Parse("c1cb276b-1d46-458a-90f6-0b57ca3a8bb1"),
                openAllJob: true,
                userMainId: Guid.Parse("a416cbec-f56b-4065-be2b-a108dc230c4c"),
                userMainName: "76a62ce1fd354ac4b658dff7af43f810098b82b2c6c94092b4",
                userMainLoginMobilePhone: "e7d693b548564b2c9190122568b17ccf79ac5ef3c53c4cf199",
                userMainLoginEmail: "7f59fc680ed54785b2b46e6a8d4bcc78f49207363dd14619b130d16c8381e8e8a2c12a41cf22470ab21805a4029a77b4ec808429e3af4e6097a624fa7a7f5fca79739ccb874a430f8509a4251f1e35426acc7b116c4f4047ba90427612b36859b4ccd6ad",
                userMainLoginIdentityNo: "13161e6c62044795961de5e252a323494d467e4bc557479d81",
                sendTypeCode: "82873287f4494418af18c39ed06bf50557734c66ec614d59ab",
                sendStatusCode: "924bee05371c4646b98427facbc25227fbb0835b43054f9fa1",
                resumeFlowStageCode: "4769857d9d4d4e77a4e1b00b3661f0975d4644511c8141a484",
                isRead: true,
                userCompanyBindId: Guid.Parse("106fc808-86bb-4b43-b37a-f2f143bff4f6"),
                resumeSnapshotId: Guid.Parse("9f55ff73-941a-4fcc-9cae-8bef02d3681d"),
                extendedInformation: "34bf3ecf65e94d0b9bed2c54ca00fe8f7aba22abcfca47438fb5d6d47016c15f1ff432f609f44e86aee20f15383670fef566fd70cd374ee4b931d39754eedcf35ae5c45abf784296b19ba1f788a95f081dc5ddb9373c4976824778257a79707518613a0978134e9ea60ef9b31727af8c7d2b22db5f764e09af1ff15ed4f65d4e1243576f65684200910c0acbdf4a29c4d301ac5ac7f64505b2fb8765417354e07afb9b064e6340ba9a1d77d19e4be21170116e8a787d492c85af5d44ebb265e12745e7a4c93e46c99008b6dbd88fd78b4084381092ef47c5b4b7199efc8d447c3d07ecd8f0ff411793979e27bbbf2a14f41ae3fed72842229765",
                dateA: new DateTime(2013, 3, 11),
                dateD: new DateTime(2009, 1, 9),
                sort: 2064405224,
                note: "e447328d74974fc7bf36b913d8e347180031a6bec40842609571d3d08da3934fb30c1291c9f24dbd9eabde08c7fb285056d3bb5a70ec4e82b733f442325a6a632bdb286da6404b1fb0cbca02f1f5f26bf1c7c38294144ae38ed2decca6c9206ad136710f5ae64fbf9e2677b98252df5e4e39818c5b694f8eab77f25cb09b662058b036f0cf3e43eeb9746fa6e862bc551c9247835a3a42c7b98c6487c4a03f6d12b38ccaddbf4864a3440ad4ad01907d1bab9dba6dbd400d8c3aa7b1f080e8c2275b474f659f4b6fa3fd5401d3c0405b29464723f0e54adf975c091a16d8edcd58199ba26864423ea37f85f213c01a4a40a4a16bef06408aa24a",
                status: "776ed3d7c787450fa66a2cb95ba52177187f852b59704d6da6"
            ));

            await _companyInvitationsRepository.InsertAsync(new CompanyInvitations
            (
                id: Guid.Parse("3952d736-e13d-4130-8668-67ae52fa4183"),
                companyMainId: Guid.Parse("73df2bde-2f9d-4fad-903f-a6b529810a82"),
                companyJobId: Guid.Parse("609cd05d-1c53-421e-a7b7-719e8ba552ec"),
                openAllJob: true,
                userMainId: Guid.Parse("3518923c-9ae5-40fb-a275-4e7b9976a85c"),
                userMainName: "c5790fa1a8224ae5a1249e755beb3b566ba0056800b747e4b4",
                userMainLoginMobilePhone: "5e3d83ad37464517b254f0d8595ad094af3710ffb0a645e1ac",
                userMainLoginEmail: "d3a6102a214942c18ace05bc0f663158dbf405d79e834c4d8d72c1dc7933a38a332ebafc8cd940ba96006330fc5ea1609c6256018cc14d68abebf31105f7c0e07853b6ef3e3f4942b5c2d23833fd4210f988ebb956314c87ab77053bc5e1199e822c14a3",
                userMainLoginIdentityNo: "b225b5b1fa254bf9b26c7c972c8955c556f8c4384dff48068e",
                sendTypeCode: "ca37e0b26181435385c048efaa7042b6bfae53d704534b9cbc",
                sendStatusCode: "9c48fc40db6d4657ae1076a4ddd9b24e59d239b94cd54cb681",
                resumeFlowStageCode: "5ab9fdefbd4f41aca04e91e5983cacb976304c948963434896",
                isRead: true,
                userCompanyBindId: Guid.Parse("1f2e1344-c2ef-4cf5-b99a-7cf6a269c4b0"),
                resumeSnapshotId: Guid.Parse("5c5456ed-c3a0-42f9-9c97-6efdfbfa1485"),
                extendedInformation: "d44597c24c714e7eb58ff19a3d91f9741edf06352f934c88b972dab32d2a1a1d35636cf33de14a00b23f84501c1a761a6ea0d6efe1d34e19b22d3139f7aef3a13b5ade77ed0b402c9f9cf8117cadf6f8a47df57ee14e444586ab2b73285166b9c4888ad1471347fa93dcc222f31bf1c6e6152e1e6e4e4fb1aff4e31af8fc598aca54ebe13c3f4650ada7aa259e19974844bf4e0e3684498392a736f2e03765deb2550be7714d44d6abe2442c75f95f2d05a288bfdd1f49b6b4747f4dcdac1002ab1597dafedf4b7c8e51b6e46486f66720f7839b70eb4b88921bd615a01f34794705a43235d74896b16180e76be727a3b83cab9db6264d92aa1b",
                dateA: new DateTime(2001, 8, 6),
                dateD: new DateTime(2018, 9, 11),
                sort: 137319943,
                note: "0639f3a5cbbe43b2815303a8d0efc5bc8e2dec6f18db43f7a75257ddbfbbc7bb0d7421f08b354507bc9f2ad977c5732965f5877b809b4e76904b6503d9665d0694093f58b4ca4473ac1636d3229e61d7e7b3f27aaa9a4bc4a5d02679a77b0caf6fb8f22d8fba4ebe85493e13f41e6b6fd21ed10c5d924f9c86916cda903368ad1cfd863db61f4274aa3ea954fc31af7cbc21062ec68a4271853b9515bd0755bf58e4b4afe6874fd494338336e065bbf981f99afeb25941fa9c82216b504cfd63085fc0eb326f43a89a0188308a14e2b2b7521b8d2e364c6e8616c600d482e9377f405055b22b4f6292f21bf19c93051a1b6bb9dc11cb4e99acef",
                status: "e67b34523a59400ab24114aeb99ba5500e64cf8b45c14f7bbf"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}