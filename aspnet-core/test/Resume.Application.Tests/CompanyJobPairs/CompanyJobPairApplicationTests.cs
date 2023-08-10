using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPairsAppService _companyJobPairsAppService;
        private readonly IRepository<CompanyJobPair, Guid> _companyJobPairRepository;

        public CompanyJobPairsAppServiceTests()
        {
            _companyJobPairsAppService = GetRequiredService<ICompanyJobPairsAppService>();
            _companyJobPairRepository = GetRequiredService<IRepository<CompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetListAsync(new GetCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("95a3b9dd-d316-4aff-8f37-aaa6ac6c6fe0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetAsync(Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPairCreateDto
            {
                CompanyMainId = Guid.Parse("80f80ff6-a202-4a33-b28b-1f9791a8d96a"),
                Name = "f103883539e14748b2dc36402b88bdb0a983519bbbcd499e9c",
                PairCondition = "6502672b50724ebcbaf2ebf43b68f60a4b4f8ee3efdd447a944af6fe4662c5041d3e1a717bdc4a91a8954c742e892eabb8e519093bea44d28e9262494c93108eea98a6d3c4424c6bad1208db905ffbb5d11507a1d38740a89b4075eda33f17ae4cea3ac7c24f42ea8393da80503a922a3c5c808d78954c68ae37c6130a53a77478103cf95d2e48a4aa6f631727f6d3d675b5dad079304460903d2c3f544377c9bcf07b28c85649aca0fdc557668bf46a440ea124e2454d42be50ec73d053dc87ed2798534eb4476399559e900549ce9b1f28545e686243d48a3c384d39806c2180bbf28c25e040d297d80e53eefb95c61164afbda1fd4d0aacc3",
                ExtendedInformation = "7aef110a0cef4e6393b3e32ac6dded0a7e3a929f4fc64fbbad34dbfa6c35733abd63e6af59f24e31a6413a6f39bcffdf102f7a2f0eaa437895c6bd2e74e2260e444af31cb4164187adfd2ea149893644bcd9ca5d1e3044a5aa7c99c98ff8ad0597d351ccedca47339af8ec8f3c73c01d030a227640374d7d8c2569af944e92edd4424e1e674b47e9aa8dda55ede7b3068118902b4b3b4d5e8cf7c0ecb28595f45a90aede34074f42b224ab8adec9d92003c510ee74494281857a842ddde1f60e862acaf1b1a547bca7e6a8b2f7b4c2f6059e7f36da8542fe8cdf8b9053c1961b6080b287a55f4c5b877ce84f44a53f471b82d75238e0449fa8d3",
                DateA = new DateTime(2010, 11, 14),
                DateD = new DateTime(2005, 3, 21),
                Sort = 2526856,
                Note = "6d686c979d0a4e20b4a4b2a9fc85b399ddf50eb4bb674483b55f66a0dd1145878852eb532a9f4f53b09c5573668f8cb16f08ba695e0d47d58c8ad613dbfab6fefbe7edb36f9549ec9409c241826a284746f81c35b9fd44b3b7b1e292b0901633367834c2d76443db9c1b9049cba76390cea2b0c16321470aa66e2d9c72ca956206c6d796c182456bbdf469f51a79c2a0d67e563ea05b42a297c900778a3b8a602a78a470685c438b858695395c1a34bbf825f9cbf59f4413944405479c28d6d18519a727fac64405ba5b258864e029d783f417d4e96a4f20b8eab4db826b84c9a6f94c26a6344cffb6047d055c9658fbb2581357cedb4fa79f4f",
                Status = "7b2aa93921504de38584da4a6a4d2b23422f4861f06140f6a4"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("80f80ff6-a202-4a33-b28b-1f9791a8d96a"));
            result.Name.ShouldBe("f103883539e14748b2dc36402b88bdb0a983519bbbcd499e9c");
            result.PairCondition.ShouldBe("6502672b50724ebcbaf2ebf43b68f60a4b4f8ee3efdd447a944af6fe4662c5041d3e1a717bdc4a91a8954c742e892eabb8e519093bea44d28e9262494c93108eea98a6d3c4424c6bad1208db905ffbb5d11507a1d38740a89b4075eda33f17ae4cea3ac7c24f42ea8393da80503a922a3c5c808d78954c68ae37c6130a53a77478103cf95d2e48a4aa6f631727f6d3d675b5dad079304460903d2c3f544377c9bcf07b28c85649aca0fdc557668bf46a440ea124e2454d42be50ec73d053dc87ed2798534eb4476399559e900549ce9b1f28545e686243d48a3c384d39806c2180bbf28c25e040d297d80e53eefb95c61164afbda1fd4d0aacc3");
            result.ExtendedInformation.ShouldBe("7aef110a0cef4e6393b3e32ac6dded0a7e3a929f4fc64fbbad34dbfa6c35733abd63e6af59f24e31a6413a6f39bcffdf102f7a2f0eaa437895c6bd2e74e2260e444af31cb4164187adfd2ea149893644bcd9ca5d1e3044a5aa7c99c98ff8ad0597d351ccedca47339af8ec8f3c73c01d030a227640374d7d8c2569af944e92edd4424e1e674b47e9aa8dda55ede7b3068118902b4b3b4d5e8cf7c0ecb28595f45a90aede34074f42b224ab8adec9d92003c510ee74494281857a842ddde1f60e862acaf1b1a547bca7e6a8b2f7b4c2f6059e7f36da8542fe8cdf8b9053c1961b6080b287a55f4c5b877ce84f44a53f471b82d75238e0449fa8d3");
            result.DateA.ShouldBe(new DateTime(2010, 11, 14));
            result.DateD.ShouldBe(new DateTime(2005, 3, 21));
            result.Sort.ShouldBe(2526856);
            result.Note.ShouldBe("6d686c979d0a4e20b4a4b2a9fc85b399ddf50eb4bb674483b55f66a0dd1145878852eb532a9f4f53b09c5573668f8cb16f08ba695e0d47d58c8ad613dbfab6fefbe7edb36f9549ec9409c241826a284746f81c35b9fd44b3b7b1e292b0901633367834c2d76443db9c1b9049cba76390cea2b0c16321470aa66e2d9c72ca956206c6d796c182456bbdf469f51a79c2a0d67e563ea05b42a297c900778a3b8a602a78a470685c438b858695395c1a34bbf825f9cbf59f4413944405479c28d6d18519a727fac64405ba5b258864e029d783f417d4e96a4f20b8eab4db826b84c9a6f94c26a6344cffb6047d055c9658fbb2581357cedb4fa79f4f");
            result.Status.ShouldBe("7b2aa93921504de38584da4a6a4d2b23422f4861f06140f6a4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPairUpdateDto()
            {
                CompanyMainId = Guid.Parse("24702e85-7204-427a-b170-b24b69e89a13"),
                Name = "9701cf8dc2b5481cb021b4a31438b43e5dfbf1fe399045d492",
                PairCondition = "8758dd56b07a4b548a8b5143b84863ceaee233345a2343e5a856a0a2aa4146d9e8a8f25a0cf54cee9295ba40ba514ac1146640bb69b5467e9b5888863f58230441ef48c43a954788830005e15bee56bafbb590d6366b47099c7e0f8b47f52bac041cf269ee354a60ae2e5c7c055fab2a6e31c12f7a024c8e9553d19ebbaf57785512ce723bca42d0ac84be3220fa691a78cbc23b34254271b13cb74837e3ccdf6e5179fc35ce4605b8ec5fa41c70da04612d65e593fe4b63a9611204f68ca2858827cbd03b234f33b3bc1bf90b1004c421b002899f4f4b1689bb5c516bb5da2fd52adca08d6349d1b685972f01382cb47ca1d246d7cf43898e3f",
                ExtendedInformation = "db90fbe9f0694c50a839de7572445f61245f052573d54de884bd1db5b849aa4b2f48d6e750a04e869f19a4621dd61cc6b67f702b5bc54731815d048388a032df06ef48d5705e40dc9e2b1f1422ee0d25f4a20a5f75e84010a19191ea8e57b967bb90612527d14841acc2d9795520f606b61cce3a05ce4a469f00e463f6de57c7dbab73d254e545e0a95fc4234cc0d4191b21ce1dd977443a820e6793343fea9ee164649241e24439ac5e2465e168b56807def9a6ebd740788ba39b5df0d2984e3e335d3c974d4a458dc3fd429f8f6a9e08ea7faf27284fcc9c5fc91dd4fc8226c0fdec9d2ce5481295ef249890812107d3f7b6e2e6b245969372",
                DateA = new DateTime(2001, 8, 10),
                DateD = new DateTime(2006, 3, 17),
                Sort = 153096588,
                Note = "26c96b99ad5242399e4f02b32f308e6a747687474cfa47249691bbabbd703fcbd5fa11dbdde2448481327a287f4f8d6d3b722a6100714243892b3d3dc63e28fd6a53fc0237744e56a14b0b78d7b91b18bea48b636da84c49b7ae6d5ec2b759edb172807e5f8243a0a4fafe7e546d6405cbc0475d5384457a9671335d367197955bac7532358542cebcaa80d42b598a5ddb5aea75e71a407881bdb78c741c2dfc9b044c6c664a495381500313aeeaaa578890d749f2fd4e0aa3e8221b16034fe55a9e79f6bff74daabe4af05ac8bd056ba6f05e95ff3146f39b0fc4777c7f14249fa5bc185da8447ab1c689b44e5d95056aac243dd3f24684b583",
                Status = "67ae5b04661644b28a63e690f8bbf8466fd82474d03543108c"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.UpdateAsync(Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"), input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("24702e85-7204-427a-b170-b24b69e89a13"));
            result.Name.ShouldBe("9701cf8dc2b5481cb021b4a31438b43e5dfbf1fe399045d492");
            result.PairCondition.ShouldBe("8758dd56b07a4b548a8b5143b84863ceaee233345a2343e5a856a0a2aa4146d9e8a8f25a0cf54cee9295ba40ba514ac1146640bb69b5467e9b5888863f58230441ef48c43a954788830005e15bee56bafbb590d6366b47099c7e0f8b47f52bac041cf269ee354a60ae2e5c7c055fab2a6e31c12f7a024c8e9553d19ebbaf57785512ce723bca42d0ac84be3220fa691a78cbc23b34254271b13cb74837e3ccdf6e5179fc35ce4605b8ec5fa41c70da04612d65e593fe4b63a9611204f68ca2858827cbd03b234f33b3bc1bf90b1004c421b002899f4f4b1689bb5c516bb5da2fd52adca08d6349d1b685972f01382cb47ca1d246d7cf43898e3f");
            result.ExtendedInformation.ShouldBe("db90fbe9f0694c50a839de7572445f61245f052573d54de884bd1db5b849aa4b2f48d6e750a04e869f19a4621dd61cc6b67f702b5bc54731815d048388a032df06ef48d5705e40dc9e2b1f1422ee0d25f4a20a5f75e84010a19191ea8e57b967bb90612527d14841acc2d9795520f606b61cce3a05ce4a469f00e463f6de57c7dbab73d254e545e0a95fc4234cc0d4191b21ce1dd977443a820e6793343fea9ee164649241e24439ac5e2465e168b56807def9a6ebd740788ba39b5df0d2984e3e335d3c974d4a458dc3fd429f8f6a9e08ea7faf27284fcc9c5fc91dd4fc8226c0fdec9d2ce5481295ef249890812107d3f7b6e2e6b245969372");
            result.DateA.ShouldBe(new DateTime(2001, 8, 10));
            result.DateD.ShouldBe(new DateTime(2006, 3, 17));
            result.Sort.ShouldBe(153096588);
            result.Note.ShouldBe("26c96b99ad5242399e4f02b32f308e6a747687474cfa47249691bbabbd703fcbd5fa11dbdde2448481327a287f4f8d6d3b722a6100714243892b3d3dc63e28fd6a53fc0237744e56a14b0b78d7b91b18bea48b636da84c49b7ae6d5ec2b759edb172807e5f8243a0a4fafe7e546d6405cbc0475d5384457a9671335d367197955bac7532358542cebcaa80d42b598a5ddb5aea75e71a407881bdb78c741c2dfc9b044c6c664a495381500313aeeaaa578890d749f2fd4e0aa3e8221b16034fe55a9e79f6bff74daabe4af05ac8bd056ba6f05e95ff3146f39b0fc4777c7f14249fa5bc185da8447ab1c689b44e5d95056aac243dd3f24684b583");
            result.Status.ShouldBe("67ae5b04661644b28a63e690f8bbf8466fd82474d03543108c");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPairsAppService.DeleteAsync(Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"));

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"));

            result.ShouldBeNull();
        }
    }
}