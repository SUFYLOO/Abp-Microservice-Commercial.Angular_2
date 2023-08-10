using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemUserRoles;

namespace Resume.SystemUserRoles
{
    public class SystemUserRolesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemUserRoleRepository _systemUserRoleRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemUserRolesDataSeedContributor(ISystemUserRoleRepository systemUserRoleRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemUserRoleRepository = systemUserRoleRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemUserRoleRepository.InsertAsync(new SystemUserRole
            (
                id: Guid.Parse("387a44f6-12b9-4266-adb5-bfb839759ea2"),
                name: "0cba4dab77604fc4941d6d813f18039dfe66ebb04def4ddba3",
                keys: 1020329449,
                extendedInformation: "df5bd03cec234cffb5e1053ce90534f7317d74d1cdfa418baa9b7d472f0d957c5c679ff2fbb6498ea49bd25a9e45b1dc57134eb4ba454d2eb12f5978f62e0bb9b916b6dca159404283148d61001a24e1e618d46d575e4f6d9e2def608b5ac7dfde79c0b29257426e839cf8d78cbe75285810a83ec9e54d45b401964245c5c6783a93278f7ad04f069ed493b618a73b9a073cf12a11134f6ebf72a4491bc13d2a70b25288f9b24af795f65bd380160ea371380cf486724c5d815f60bd936655359d2d546122354bc888ae2b41b3b260d7c8ed33d88d084a19a354b9ce38ec8cc3e9c7d0182da443a3b9ff37667a750786ce056088b5c146bb87e0",
                dateA: new DateTime(2018, 9, 4),
                dateD: new DateTime(2007, 1, 15),
                sort: 1942378091,
                note: "81dbe75716bc4d5b83f571a99e17d12360d71ca3da864ff3ab5ed46a3e4e26d21414187d0a1b4720a0f5fd89f65adcdf6f2dfb8b94d84ef1a93a4fd181e5d47cf078bb4728a74f6c811d49a9835d293e924ed40affbd4680b86769a4cd77c30cdbd80cff64884fc0a42339f36f9d249eb7a3549a351d40daa413ddb2e07880707d6392f8ec1042d5a8b09d49424c9570409327fdfd6e412b850616ffb8bd4f408c71dfff3ce043aeb1b0332db7b2e8954c92f85d1c714763acc4ae9cc4a435bacf895f07fed6478793a0dbb983cf623cb5daefc3093e4371b973dd634cec5e54eeb45fc9a0e049f7b48420d72058f336eb482032b8e245af9b9e",
                status: "a89d736ad34d43d5a3eb3bd84c85b2fe25e2ab27754a43d995"
            ));

            await _systemUserRoleRepository.InsertAsync(new SystemUserRole
            (
                id: Guid.Parse("1c99b465-630c-46c2-9f85-677c2c7c70bf"),
                name: "42fd333a5b374354afcf986ee481c4dd77160133f5f54339ae",
                keys: 208435466,
                extendedInformation: "daac6b3103d14271b446827a31a5b1b46e6fdccc8a6b4abc9a8de8da3b77e2872796848a0c6e4bdc9f36b8583ed9418851d381730e36435ab973726118c5c3a57eed2cf5f429438cae30da1c0f8b9b12227d1b5aabd845dfbeed69e22722c0a775299361ec774c568a222664e6a48149feb5cef355a2484ba5fb51f734657b31be0baa5c781c4a129c22377eb32ed8dbeb74664cfbf34d43b86bff4a5b4a1d164f4ffbc276e04d73861d85fbe7b208c532ca44fc604b4ffb95267167abf07fb121ac4a7f5d67493ca80e10d7ee0b5f545d44d6b8d58a44828bd66a2ab2051cb11f7b1ddb83624693ad5fc8604b6c81353110680d360b4b5c8630",
                dateA: new DateTime(2004, 11, 13),
                dateD: new DateTime(2007, 2, 9),
                sort: 1291151911,
                note: "f081fa2bce904bb6a220de102da878ea4f1a88756d0f4a41be82eeef288d7214ce2cb8921c074a0bafb4467d57ae2315dbc749d1fbce4e1998cb78cb6a6f97d56533472da7a34d32bbb08e59302762ec3de9c69458b74302aa4cde9316b42626d225a3fa8c7b42a19bed1248f4e416cde6f222d6f8ee4f77bdf2255681b5dd5265fbf146433d47eeb35e1f25dfc3997d8af70ea159564338bd58b22a0e0e6d592b377d442899499d940d3b0f690ad8e6d805aebc80df4022a0b4c8872768175c281bf44051ea456bafcad9eca8882748903d54a0e3d7403c8e1ad714883f3d7c9ac5eb6df0cb48eaa6be0cc6c6607d174350977773754362aa1c",
                status: "71b124c6133d4fd7a9ea4563399eb8aeaedd90468f87447685"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}