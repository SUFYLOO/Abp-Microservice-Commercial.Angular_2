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
                    resumeMainId: Guid.Parse("16b9cb20-26cb-4a55-b0f5-f6b652522c90"),
                    name: "b38e9363d34a4774884181e582f12137cefa931f609045a585",
                    workNatureCode: "95b635b18b6447e8865b3ccb4d9e4a8ace4841743a994055a6",
                    hideCompanyName: true,
                    industryCategoryCode: "8786514ba36e44a8bc4eff88513da380a482f358687b426095589d947c89ffe8900aa513349e4b10bc831cf65d023a8e99a7521b3178408285a0f625a006ceb30c1a89269a11499aac8fb8081e7f06fe7bee36bb7a994ae8ac28fc20136c979d6724fa6fb1d0452bbdd726c9d0f4c7e0af1bf948d327405681988f2282d1a2d4cb5d25c52995432384f27a6d9fd37ac0804febcbac1a4b018820a1fc9690116c2d287b61e21d45a2b10b276de09c02dcb379bed87d0e43a3874d7dbd6414feda4425b796fe40492596133cf1e8a873ae61aeaae38b224c49a1a60a84b13dd5e2bf1c2652ce4447339e9e4b5cf29560a917ebb08090b34eb3a92f",
                    jobName: "ba8cace86b6e4aba9ed184746deab028b674d3f6595948e981",
                    jobType: "c1cb9d682bd846b19a42f5a090ae0b62b92615234f8c4540bc5f2f6f7d9791894143854874af47478d2cb8006367e900f1199a051c7f448da99a5c5aaf2ebdbbc86d107ed28649f09204aa519fefdd6fc98b2dc0e753482db13091784095e92f4e3a8929cf3d48b18afe232d4aba9fdd7eef622caa5844bc8376a8f2082b06c1cab72b6580dc4b1ca32a5028914b5ecde17046c1747b48f0b8e01e255ba837451215ce4e95694f4c8825343d74c8bb4b6fa7cf8d675d4783bc1673c7ebc9f3397cfc0e92dca34cecb00891b018391c844e6e45e020a6440bbcd21ae78183d680d2e9a302e3dc407fa2038bdd101fda0ac1c8b6b3ae81488f92d2",
                    working: true,
                    workPlaceCode: "d7a398a6cb4f4ee68117abe236208be1c87643aca17844149c52b8974a98cf67fd8486a40bd4411a8d81baa6b6a471d2797b769725cd47d885972491aa1930357a344079ddb541e591edc1eda999fb5493b3e23f83b846ce9cb9979818bbbeda7291b0beab834995be5ed7375a3a550e78c8adb3807d42aa90bc52a8b4efc9a9bb7234bb77204c2ebf371b8fc2a0f38eb5e60d0f82d24cb09c4507107f802ee8f84864d08b6e46019e9ed59c1127e65fdc808b6733af4c2fb2c8fa9d40f25639d32c5bdfcda740c2b5ba960e954eddff84a681f97a064c35ab700eea82ebc0b4bb19a42529d1495198baa047c7e24a78fcd2abf557cd4ba1a18a",
                    hideWorkSalary: true,
                    salaryPayTypeCode: "9af0a8b872cb4752b4494ffdc3952469ba5aba5709cf4d099a",
                    currencyTypeCode: "1f605bd52e224027b9ed1b41d27b238d6591a5815e5647f6bf",
                    companyScaleCode: "9f5dfdeb745e476e8dce1c84d909d76f700a3f10e161430cbd",
                    companyManagementNumberCode: "354175606eef416da86fefeb8d84b1e12cdf8c2b0c5d46828c",
                    extendedInformation: "b081c563538d4e5e80ee287b663c03737e2c6a791a8c47bfac0c80ae892876d518301d46ed594a369ca61e2b882d9dbf23072debda5e4b80b8620d5a9f52f9e278b8e80e98474230b8090ae6a56ea5a6248d50f5efae4b83b751a14d6f97640c5e183f00a966470480eea662cd86123912458ce4e71644fe819c2438d85c965b6f816a973bef4189b8e44e7fca3f6dd124132c4efa3f41918e6b38a54b179b3a596140255ba544f69ec28aa94ae64777a776c68a414a409599e317e44f448dd1c2ef98ab65dd45beb501bf6f2bcdd96ffae0d29d55384ffcaeb5689e7b35f5645a2bd95907aa4760abdbfe7b24839c042f53a4bdfdb34266971a",
                    note: "5aa3e027bb544a009104ea5b7556e4b9aa5d625e87214a169c8459e7869112d48c9b1939365a4dcaa146b07fac8d5222b20a4d7f72e343a08f0295270b016c2cd6fb471151534ecc88d6f011d37c663d46fba654ce3f402cb5b22155995bb17e96f8fa1c775840168f9d5b3223518495af30eaaf96bf4fbe8a33541311c421f5d40c449e28c8419ca6b910f874ac433f3e0c5ab582ef4281a4626efc0f779ae2584fc8cef6b3455b9f50413acdccf166b17c4fbb3042404a828872d6474ac563c52900503fad450aa6a399c3f9c7bccb555700d29c664d8483afc7f127f14e5e723a5e4e49874a778a6f2b07d71a143c509d15a069734b38ada6",
                    status: "f8dd9bf75fe5419a896693852d712b960e682252d8354e1181"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("33926bdf-dca9-4403-a622-446d02427ae7"));
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
                    resumeMainId: Guid.Parse("8b6e5500-4bf5-455b-89d2-7d24b1ea7e03"),
                    name: "d27e06d42a904874940b2bf36d4c1d53c2c9433a2d8b432b81",
                    workNatureCode: "cbfe31bab14146bbb5240009aac1f020f09cdf416ff4451bae",
                    hideCompanyName: true,
                    industryCategoryCode: "452b6d6e0ad6432487456022708e4ca1f600149c82244f8b8bd8384c7703313354430eca13af4574bc0a4dd3f7265e9aa30a94164202491b8a1144399738772ae26b9c40c1804c34b8e01601992e0cd48f70e0ac610a43c28e76888ae8a3fd0f13286b9b3a3145ad9e98eed89cba56adfa74dc5c3f6a4f2daebd52b2259da546dfe8df32e1f043088f0d8425d1090dd2e5b8bae2e16343f09086bb46d16edcd15e123f15394d47d49a39d4e8d1c3dcddc19fc89fbc8e4d6fa183139ea297c9d54c6e621f62c24175a42e49c6cad2b5c27f46f5e09eb54087b4b47b4622e759cc8a153b8fb21c4e59b04e89d40f15f53be2f7857f5d2b4663b03c",
                    jobName: "111bbd0b6fb7402aa5afc41e9fa804a79f48890b0a0c4573b2",
                    jobType: "d71842a7f400463b89c1903d1b679ede711ba920b15944e7a89876afa75d6ac4fafd931566784c17b69531f89b17dd9aa467ab333733459888b80457fcc9b2a4c9421f9840824c3fb6ba9050699e132c319c073388aa4c30be6fe0012bed05c845b6f13ed86140f4b82c70acafb0dbbf39a0014e2eab4f86950daeea81c1be44a5d5778722ca487f9d6e5d21c50a55e15a30bfacbda24bb7ba5056f3a9be4f5a0d2395fca3a04c2fb51b81fa03d14735f61ae872cc5e45ea80af66802c9c563121444f41c4a547f482523978d26032f78a835bbbe0aa45a1a082166281f04e1932770375c6d14f5699988cc37fcb2688703dac92c0f64d41879e",
                    working: true,
                    workPlaceCode: "79e95075da8848a3b4dbf0c564faef4c634714e55bf54fd0a2be14e1d18f646bb3c42a9a239446149a52077101fc79bae75f4cacde904700980459df549e48a0a07209c50b4f495cb932d1489d87e1c3b9ef38ae5cfd489986b2abe12a5994a1864acbe4b0ee46c9b6b8a8af6298f9685c314e3c086f4a0994ce57fc68e0e8b455ae519f17164311ba1dbb2368f247ec1c6ccc59f2d942838e0c9059219f25e42783cdda8bc8472bb86abe15e3dbdbef7a273211a69c4083ab4b886162503e9cdc65246a522f4fee9898e4c4f245febbf363da20d05748df9260e4b30f1409415ae5be66e03c4387bceed41ff52f2f3331076a7fce154f089032",
                    hideWorkSalary: true,
                    salaryPayTypeCode: "56131f949ad542e3aa44a87e54e88e96d4e476276fd14afb95",
                    currencyTypeCode: "539cb779a4a049768b0ff3d564ead2677f758cdecc6d451599",
                    companyScaleCode: "14729ab3b78e4e658f9763515810a72cf26c9788076c464e9f",
                    companyManagementNumberCode: "b7c18657e3f94766b84b0139c71275707da5ec96f8fe4a909a",
                    extendedInformation: "629c6bff8fec4ed0822822bc9d22c45b739260eea07742adb1c922cfe0038d074860d7f20ae447599fc70245b03ffc65a8b8ac39b6d24ca280cc874fe499874505f302abfbf44eecb8d2b97016fe78e8ada5e50323fd46deb6d7bb61cc8265827280457e81a8423aa63e107b5cef8780bbf67ddb3d974920859c8b5e347a14c800b3351ba0264b1a927809f6cee26264e34101653ced40cba02034d5cff5fec6a8cbc4c544f149be8b7a1986509971f4b1c0270cf66343a3b574d2b5718fccf9deb8f70ccc66452ebb22aa73e45302aa356cfd2b002a41ed9ed727c98de1d09ca866493a51434fb88f377942994490fc9a28ace58fa248528506",
                    note: "b26386a1ae444d9fa4eb68b9550521bd7260be66346e4db78ed1fc03b973ba70e24408754f2c4d7790bc28314dffca8caac1d35e620841b78a0296f5de281d8de63a5ba4826542059b5fc930d2e354bdc78553d310ab40d3a936ace77e53c7473a5243c30f3445b69a85afcbdc8929ba321aca9bf5484f1fa67d133725531e2dc20f6495ce384995aa9010068f14526ddc9268dd8a9a4823a9e22b83afa9c9e4933605c2fa8743169d061c5dcfb143ef084fe995b18d44fb8ac7dc4ba573bc3f7d33364fc722421c9a1ad088ddfea24186b88cc066d145a5846ed1410acff2ea9556e51e1c064f2da1b3adf4a922f2fbdd350cfa150741af9a69",
                    status: "c1d808a6f53145f897ae4868ec1a4a8b94a2c4c2d5f545b49b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}