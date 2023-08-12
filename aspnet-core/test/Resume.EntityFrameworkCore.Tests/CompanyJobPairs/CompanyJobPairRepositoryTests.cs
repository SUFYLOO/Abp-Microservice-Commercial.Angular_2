using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobPairs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobPairRepository _companyJobPairRepository;

        public CompanyJobPairRepositoryTests()
        {
            _companyJobPairRepository = GetRequiredService<ICompanyJobPairRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPairRepository.GetListAsync(
                    companyMainId: Guid.Parse("37d528b1-c64f-4fa1-b176-8579e566e585"),
                    name: "7a1d35c7f0104861af633b382fafcb1dccf12fcf26594c538b",
                    pairCondition: "af0c2020116d4f658ff9a955272d52d7ccf2f7b1cf644319a3b52df7822c72928b3f3d1b832340b18c6148b2d4f417c16dcbd4fa114142e19c74267594b12e598f638ca44cf24c8799247f02cb9c325a2b8d332d6a3c4f7192f6ae3d590aed0d234e065709fe4a5ca0174d6e0f19902e5badc5caee164ac69626b18308dc4c847eea2614c6ec4b3890bbcbfe983a9d52930a84b49f18420a876ce4455a9b4af9e236a284bd4e4b6c83c5182c3d8be122aed89dd097f14209b251e66aff6431cc77b4df9d616a4b02a2af2e983e1962b808c9db628f61470bbcddd84a6ec44fb86c73b9b9d8234149917c0886d232e4c9d80939817e8a4db9a5ea",
                    extendedInformation: "90eb8a00ab1447b1a2d213ee81ba88040755d747c45f4fe7a06bec34aa48551046fe6bddb8ee42d7897765abb61a4b596e131cc1cc2d44748d2ec266c0403c76f86de02dc3a74d91b60d78cd275fceea4ac06e9b50d34aea8aa3aa7ce59a4f453837d6701f7e434baeecf36a95e0a690ea5f55b5ff8d4e0e932dde27cabcabedb070b8a2e1324bf7be10b2a5f7949b54d1ac91d4d09a48f3bc0cdfb069f69b64b17213a43307445d886813d909b85d282246418455e04f0a91f2f94722de9e3c162d1dbbabf349148c1974ef921a04bab2868a7ede7b43ae8a20db04390ca3bb7608a70adcfc42cfaeb9c65d89958a1935c23722e34a46aa9f02",
                    note: "2857e8080b6940bcbec7af910b49d3e6193393d12965431299256fc0ed7afc20219cdc34ee7a4e1a9621529022e7a2f476f40eaf069a430591691dc2bb6863e78f3d3c8ac1744fff894c08594193c16344cc76e9d69d4f1a99cd430205dbb8394ba17dd7494443c9a759728d2212e2caae74d0e0866a4515836c3676b896f128cb62d1a95f12432298bce2804a7fc49ab5392f7e18a84a8790aa3473106253dd40ed67701fa740bcaa57a6d0f01d8f5b40e34a3fe0b74221846dcefa90b7ccbf6aa41d4cf45b47e0887cfd58f34c341ccdf989d84b224a0d8fdd93ee79cc35a02096234d3fe64d9a8319d334198cd2effca4b40b42374409908a",
                    status: "a4b9f567d3e145e888cfd29a72b72af21657d830950f42e089"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPairRepository.GetCountAsync(
                    companyMainId: Guid.Parse("80c5d5f8-fddf-4b36-b96b-38cc40ea28cf"),
                    name: "0fb8eb1b483147fcad9027ad0f2d504ff8224a22d9cc4fb283",
                    pairCondition: "b6742f35198f420896408d53426e9e4afdf00b5a528348ba894ed03b2e892a998f2efe6d000941889b86124f908db1b6cc5183e4c13b4ad9a4ab46a6c9524efbe9a64d8e00f84a6eb7c8125395b216476f1bc581eeee4582ab3e722422b93dd5a885cc8567344caaac2489b3add7e9eed43cd3dfe8af43d1ae03ed5bd12339c67134c83712c4418dad531b4f12a1888bced68e3025524661b174db8c256ebfe5231c9045d47d45b2bba5a421adecec9035acfc314b234d3d90354eb0a8c8cda32de7e5fd2fbc4733950c45de26dc9e61fc4186eae5f34b18b79a58e9f55d537a13633e32fdd54030aec24cefde76d1a67c46c5bb34cb495fb382",
                    extendedInformation: "3d02089ec9e4442595e63aa9ebeff0faea48847a78884646858119717358e3ab4fd55b37541745f7a65b2f0e709bc1c173b25420a3d345f297b56e328b190fea0b8649d6956749ebb90264c9d790a7071c68e4f2940944c88ddf06b4b9d3ae3804c0825d55e7407d86a36f8c2a91208211f30406a0ed46d1bf955511acf7edaa4d6aa43a0b2f418fa7cc8bc231491255f63189bc5aea4ae1a7297f053c2f94ffb6e4fee15cc4413ead3e90b29d01e9176bd331d17a894e309b6b9c0b09e5bbae59d274fb880744489f8fee418644a35a0c80a69d1c4c4dba810afbc57ecda20445ffdff11a714e13bab95e2eed06684cbd214f5616044eb1908f",
                    note: "8b1f7deff22c4b6f9b5d5d1e8b9e8bd95c26a7a74eb64dcf97d51248171e0bed4cd9470f01f344819227c6648e54ab4a13633b570b3949408125d67b7203f6e29ebb43c2870944de9071384d5805a3b0a218922ec56f47a6ae7bb090ff10fa6d2651e84207fe42028a7fc541e65249c7d89483079da549468b194028b9123e305c01ba0e2a0b47abb2ffcbcfa3b3f3ba74ccb0cfcfdd43f190c72c43a12e9ce4971a53845ec1411383bcac9970647b85bbc3759dc5fe4c73967b0496210fe28fbe4450969dd44e45ae0eec25fe92ba5fe36b800be6d14fbebdd7136478fdf077d13997a9ea5a4463b15f0ab6f44618f0278b9f5b4de349e1a777",
                    status: "8c7734f467924858866bebcce70d33ef45778303bd7f4ab79a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}