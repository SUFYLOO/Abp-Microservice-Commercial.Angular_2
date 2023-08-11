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
                    companyMainId: Guid.Parse("880ab642-e062-4827-94a8-e34c8fe8c933"),
                    companyJobId: Guid.Parse("f2995331-9e02-43d0-bd36-b60d18b08044"),
                    name: "6ca717b8c05b4789827d5c11642dd36dda3ed07c288b48aaa2",
                    jobTypeCode: "5ee752eaae8e4e8b9f440ca775d26fba3791c641efa24195bf",
                    peopleRequiredNumberUnlimited: true,
                    jobType: "3e993d84cf4c47479553862fee5df5404c7b85795ec34a32b2e61aa38dcc76b868b48cdefd69470d8bc00bd044647592fdeed4efaae9437384c2d70c9c6b5ba9a3823d7baece4fd6b53841370e9450d3c2e64338734e4b1abf4b483e1c26ca18731b307e",
                    jobTypeContent: "cf8541484f4b438a8528893ac308456c99081a7de20e44ec9",
                    salaryPayTypeCode: "895e0a0f8bd345bdbffc16beaff81181197b7aa7c57447c3be",
                    salaryUp: true,
                    workPlace: "c20c1a8f18fd4671a8012c111b343737fd6a230db8004f718ea455a40c9a1f261ef3c5f5983f43a4ace06f0576b12ea1941da2b45917433997d4bf2e726884b75e216da94ed54ebabfc4d880311c377cb5775f1676414c95ac3268661498af8bb6007388",
                    workHours: "9a8e3e1d66e64ae1b0f223fae54745b56f3eb04ad0a743908d860883b685d9d38be2d0ecc34a48d9ab789a746a38aa92e41651bcdf404633bd0a5871ddfcc9199d39f6a8bcb2420786d76d656fc7b35c2b75924877da4518a7b93482df10ee8453a48426",
                    workHour: "f5bacfd4ad434dbbb5ee57e7553caaa5a6fef9d513e8488199828a302b01aec382fd72f949c54e4e9bfd644a8bd39cd6d7e0c3d47d8c4c7897b930c43bc0a970ee847b9ec0d348a1b3922811335488f8c7fe77d52d8f4a3785aac126264bdd4eae9bb947",
                    workShift: true,
                    workRemoteAllow: true,
                    workRemoteTypeCode: "766ba032efd14ea4b73da1e0ba6ea25fdaf8e4ae5dc24269a6",
                    workRemote: "8bf7601e970642b2b580a3b5c8c433cc612c63e791b34b70a8d5b6b9064f504965524c043a41434b8841e327ca0e7a32d1fec2e2756044e2901592f72e6596fc54648e68b218441ba7d808fb75d4dcc5084a196bf3954b6da233cb9e63d695e8dd9a5671",
                    workDifferentPlaces: "fb4c4df4f2f74c4182b8a2b0172d80905b37f2f6c1f14bce8eaa599d95ff941f7ca37c9ac66547bf8d35340d965e096102e6b6cd3f754be7ab5bab6ddf0532d8538c5f17001243138d3338105c167b1e6042e514248e4f52a4f15388251d7b504060558c",
                    holidaySystemCode: "8b95ae715b414058813b1b26802f0190b7a0f15a1bfa42b4aa",
                    workDayCode: "6f31d02a1126494c8484ac798d40b0471d9c1af25a2b444ca2",
                    workIdentityCode: "70717cf93f994f5ab92829c6cd6570ba13ed4b4828ea40238c8eac69b0cad019a6c7168e7e884e00a278863c7b61f8f3a9a562ada39849849d22bfabd3c390ed9e52ce24b5054ba8890b72cd7c32a89c6a0ef886055e4c9e82a81b732f619e1a155d238c",
                    disabilityCategory: "4b51c3324d27487da7fc7c6143e8540f56f98ba2199443f1b741430ecd648e1d11a7740696d64843b9e0711eeb71892224bad80a6a974e2d8a10f2811f04d4b2ba4edfc9ff284a56aafbf53e40190f790441e21267c9466ab4622d7da3a1d6286af2a18d",
                    extendedInformation: "b94d38efd86848ff8d98aa3a554da77447b0922785ab43e0b4e75646da0c6a50f69be17dab9f4301a775c1fe5e8adafba9e5423b530440f299646edacb4b2fa91b06af2a6d4f42429361cace0bb444f60709898b6f1d4daeae5962ff7ce93b5fdc7911fca5b4448eb855da73ecc68b1e4734d2c83d5243c4a08f71c3d6209514906332b8b03b4c938e208001fc9ad79f4db32b66552f4d2ab2784dc644f738c11ad092a48a2f45bba2cce55b32bbdf7f24144a0a6ed640b18082791ec146d52b847e1847f7b84519b170187febf34357b1554ffeacad422c804fb94712287997e7b0924d4471475cb17b282d2b9b6411642544dff04f474f8431",
                    note: "232a126b9c064393a2199a0509263a6289b4725519c745c689b8ddcb6ebcadde4b54ceb546a8472587fbd62aa5dd70ec4a6438f39b0245b7adc2518ca245caf809067cd1a75b4dbd84e82a2c46b4c34bd91cdcefb531448c81b3ee306acaeb92e3eed2d6d375424b92cc8b05454ca72c6e8f43362daa422e9fa002bd47f29c494011a969e6d2436bb3f1f6bdbac4d50c246db8234a794095bc1659f5f202f8796d749c6b8b3b4915b8035876b7bed5b7ba4b6d216c4f46b08dd9ceb0e1f5102c17177e2d19e54a2485713835e5d99f810cd92890e7724f54968943a6321205b8a06a448e9b7a4d9fbe00316e39f67787f492e62a55134e11b363",
                    status: "3a0b6abe9524400dbeee246777bf7b9a489978fdc6fb4a6d8f"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"));
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
                    companyMainId: Guid.Parse("8b8441ed-1dcf-455b-b613-adb0ee9e6fbd"),
                    companyJobId: Guid.Parse("8493025a-ab8c-4708-947d-dda2537f3673"),
                    name: "9f91a4e1b1374f5cb3b1c058972d4b6bb7eb3fe1405a4271b3",
                    jobTypeCode: "2f2542eee0d7467dad2a633af0474f21ff5a686f1a4146588e",
                    peopleRequiredNumberUnlimited: true,
                    jobType: "c4cba2ee28d6413ea7df7a4a973e41e771fbea2e72584450acfe38f426d175148c21cbcd44874788949d6c5e29cc5860c8149c9f11704a27a9ce2fa053fb4f6bb4233c1d765346649b08ca56c15fb7ca0f099c082fcd4c4b95d0fa32a074ee5d9c241dc2",
                    jobTypeContent: "c18cd8a9ffa746ae81c357b663855501896cb4ea925e4928b9b4b6a628c0ec6a9",
                    salaryPayTypeCode: "d95ac48430ae4f19ba6417c944a1fbd19d50fd7339aa43f39c",
                    salaryUp: true,
                    workPlace: "2348075546984ee1834fc044a2abf1ddd6919731a88f4a5b9b1e7c1f330c6ac90ca43ed410f64f3bbe1fbd4b6748f49af3f6bb90a112471ca322e9e3e2cef3cd967b550e5e6a4492a5b94b28c997692f3846ad499c654bb39efbc2a159e0e07c4d933956",
                    workHours: "d2db6792531a47afad81fd69b7651765a9eb8be70c434457a6ad8eed8dd273d5a79cee3b220540f781a19c618d2e571ca23d47453d9f4dfdb89461e099ab74fdf7412bf2ffaf4b89891e58b4c1afb869e0d20421be1641769ac419926d254c54987d6621",
                    workHour: "a63592cf248c42c79f6bbc2ff734b91ed7b963bf2722433c8aa5e6aab407a2c48b7e0739d11f425692e9ef37c899949be188f8a64c5142aa9be95b60be015d26a3fa582735ec45e7b7eb930520015b2c7fc641f1311a4d21afad1f441589eb3e043bf64e",
                    workShift: true,
                    workRemoteAllow: true,
                    workRemoteTypeCode: "55af1d56522c4b9b9c1516d8bd3edb2feff08d7f8c89478094",
                    workRemote: "ae06c64919f44d3ca6f25813341b49b49c9cc93d78e64be68d18359d2f29d1100c2a404ed4d04c34879c5f5e0b649917207e9d006cf04adc9ac6157ed72c98df1a0edd7c8bb449e9a3fbef2aa420b1ad1909bb86857f419a9c58bf91cc8404ef2ed6ee1a",
                    workDifferentPlaces: "d4187b23f2784df6ba9c848a6e18b4dc3fe2326cb0634713ace5da55c631e49bb38c5d4cdaad43ec9f33d0f69edaab40a44865c0162b48859f69a097c0dd23f4a3f4a18add434552bc852fd661998b56945c745f0fbd4e2b9daa973bdba40f53df53c700",
                    holidaySystemCode: "515b0c2d55f344518976c62612a74d38a83f7cb1800743e295",
                    workDayCode: "3984525ab7a741b88f5f18a4761b2385ec5b729df12e445eb0",
                    workIdentityCode: "128d4549e2854d94940afb02780c1c7425a86fe1011c4752972ba32a100fe0e8425a919288ee49428af86429589c9d146c9cbfd3dcbe463ea6bbd62746b7d3c6a47ea92b5984410187aeb389aeb2abaa5adece33979e44d1be03c0d19ffb5c83f4f82376",
                    disabilityCategory: "4dc50b39d9ec425e82ea0995036605ffeb2ace2261854b2bbf86e258d32a9d176fe8c738ce874d25bd617c7ac94b6f01dcdf77f3b54f4d5fb56bed94162c94833b7fe9be2b464eb9ad2357297a237bbec7f8a93a207b4cd18ac504d1e8140aed937c18ee",
                    extendedInformation: "be2ee35395c74f82b298a2478978b845e9a23fb1226f4635b8b3559139397beffff96ab1097847d78f57ec800cbb347e1d3a54ddc08847a6bb87465f3ebe778d69cd8aa883e34426b26f9584a45b38d506420fc12b9e45d18daa29a3e06ebffdf42c771be154410f83642c5c77dcbbeb59635b78abe8495da7755cac59d8d86e3a2bb1395b9a4639a76913079081691d67d204170c634dd582c127d5b9f639126ee08732a9a44dd9b5aa8c88cddaee37c77192c0feb542b0978596d1e5eea96bdbe87b6ec9c94b3186b323b30bec905cee2a63398c5347a5a5e5b0bea82dab2a3fcd3b0e6b6e47248653b97656ff1b929e489372f1d3430294a4",
                    note: "ceb16fd78f1c406f955f9f07865e6288b4f65dc5d4784bec975da0690bffd06e85f10147ef7b4b1ea0dbc76ffadc39f84e86110aa6774c65851b6dd1bb26f0ae1341b664f26c4d82bb8528a89764ea1ebbe29b64e9c14fea9a47eb9ddcf7d6c96dcc68ca64094baabfbbf27a1e32c6e2fe3a3f871f674d369444d6855f22e85db323fedf97694837be7addbca5c07198fc5a6df9943b41b5af90dd0b4a267e44dd22e9338de24ed58e8619e93b8cc714cea4f8bedccf4b99a43b7374245e8d4f03bbb63bebac46239abb8c9771fd3824c43706c7d9694555a0de5dd8ee1238824040dce96d7b4fa7ae5c0fd313f7a2ca00192363f75e43b6a2fd",
                    status: "30d3401a151a48aa927dd9e49f6c023550e96bff251f4003b3"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}