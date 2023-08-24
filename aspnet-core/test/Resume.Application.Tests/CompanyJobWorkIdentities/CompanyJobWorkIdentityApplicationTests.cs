using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentitiesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobWorkIdentitiesAppService _companyJobWorkIdentitiesAppService;
        private readonly IRepository<CompanyJobWorkIdentity, Guid> _companyJobWorkIdentityRepository;

        public CompanyJobWorkIdentitiesAppServiceTests()
        {
            _companyJobWorkIdentitiesAppService = GetRequiredService<ICompanyJobWorkIdentitiesAppService>();
            _companyJobWorkIdentityRepository = GetRequiredService<IRepository<CompanyJobWorkIdentity, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobWorkIdentitiesAppService.GetListAsync(new GetCompanyJobWorkIdentitiesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2b330fdd-99cd-4fc3-b542-56b7ec20a9ce")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobWorkIdentitiesAppService.GetAsync(Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityCreateDto
            {
                CompanyMainId = Guid.Parse("8ba2e9a2-202e-41c0-b9a1-a6fa1144c44e"),
                CompanyJobId = Guid.Parse("6c815c71-726f-4623-855c-c5daf9bf5fbc"),
                WorkIdentityCode = Guid.Parse("1a8b6d47-1827-46e2-8093-97120f4de47b"),
                ExtendedInformation = "787966ca350f4a62b56a91f266621484544dc94b03014f9cbd21f79ae8353f6595fbfbc6a2ef48e084c91a3d39f270d6f42b2a29232d41e8ae2e851612aa808109671360b60d44d4ab8104ea045135e1e9214f83a6164d0bb39b06e89dd605261be093747bd44f03bff2fb3cbdcb1cc05dfe308e6a8d4014b310e945206eebc41490cb7341ae4de4b8a4c3bf7e693f4745079e2d4dda453d90ce4c605376e5353ddd9e34003f45fa9d1c508154523acf0639d53089d64ef9ac1152b75902988677e5a4ee613f4d06afbc8f7244822f5c8b2af667a18a432f9db3d505b71c38c8da44e93d8901474ebb99bec3064a41b164b1a434a5b8427884aa",
                DateA = new DateTime(2007, 10, 6),
                DateD = new DateTime(2014, 1, 19),
                Sort = 1068078310,
                Note = "9ef35b2d642849c2815151f8e4cd718a0d765dbd9ef14af0b0f3f72cc2f9c57ab637288ed8a745fe8604dadc0bb53373d8eb4582402347ccb6d3a92a38b25f98ecb3b08b4e684a0e9d48da0b005bf8399ef69d8ea04d43019e1841d7f94532c9cca70600cf554088872dec221d595f889621b09affb34bd6b236c7920d569219363223b5d2f14c739a3ec9a66ff57f4748dacc8dcfcb47ed9895645d84fcb0e1c011ba44de6d4352b59ad729718d7d3f5e14a3f0db4a4979be811cae9ca3fb6b43d7e88cf7c746c8b34f4847041af3ecf4b7bf983d684dd5aa22839a491ff7280ffda56edf3c4d05b3f8a9a227e086056d3446b1f74841cab5c2",
                Status = "04dcc2231d3647f2a5a7b3ab1b68807bc92ed26d067b4838a6"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("8ba2e9a2-202e-41c0-b9a1-a6fa1144c44e"));
            result.CompanyJobId.ShouldBe(Guid.Parse("6c815c71-726f-4623-855c-c5daf9bf5fbc"));
            result.WorkIdentityCode.ShouldBe(Guid.Parse("1a8b6d47-1827-46e2-8093-97120f4de47b"));
            result.ExtendedInformation.ShouldBe("787966ca350f4a62b56a91f266621484544dc94b03014f9cbd21f79ae8353f6595fbfbc6a2ef48e084c91a3d39f270d6f42b2a29232d41e8ae2e851612aa808109671360b60d44d4ab8104ea045135e1e9214f83a6164d0bb39b06e89dd605261be093747bd44f03bff2fb3cbdcb1cc05dfe308e6a8d4014b310e945206eebc41490cb7341ae4de4b8a4c3bf7e693f4745079e2d4dda453d90ce4c605376e5353ddd9e34003f45fa9d1c508154523acf0639d53089d64ef9ac1152b75902988677e5a4ee613f4d06afbc8f7244822f5c8b2af667a18a432f9db3d505b71c38c8da44e93d8901474ebb99bec3064a41b164b1a434a5b8427884aa");
            result.DateA.ShouldBe(new DateTime(2007, 10, 6));
            result.DateD.ShouldBe(new DateTime(2014, 1, 19));
            result.Sort.ShouldBe(1068078310);
            result.Note.ShouldBe("9ef35b2d642849c2815151f8e4cd718a0d765dbd9ef14af0b0f3f72cc2f9c57ab637288ed8a745fe8604dadc0bb53373d8eb4582402347ccb6d3a92a38b25f98ecb3b08b4e684a0e9d48da0b005bf8399ef69d8ea04d43019e1841d7f94532c9cca70600cf554088872dec221d595f889621b09affb34bd6b236c7920d569219363223b5d2f14c739a3ec9a66ff57f4748dacc8dcfcb47ed9895645d84fcb0e1c011ba44de6d4352b59ad729718d7d3f5e14a3f0db4a4979be811cae9ca3fb6b43d7e88cf7c746c8b34f4847041af3ecf4b7bf983d684dd5aa22839a491ff7280ffda56edf3c4d05b3f8a9a227e086056d3446b1f74841cab5c2");
            result.Status.ShouldBe("04dcc2231d3647f2a5a7b3ab1b68807bc92ed26d067b4838a6");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkIdentityUpdateDto()
            {
                CompanyMainId = Guid.Parse("3bf5f611-e5bc-42bd-bd77-4a30ddb9744b"),
                CompanyJobId = Guid.Parse("db5a7b85-b30d-4c3c-a65e-f364a02ae8cb"),
                WorkIdentityCode = Guid.Parse("02ab699b-2a7b-45ea-8125-c0dab1acb00e"),
                ExtendedInformation = "90fae0378e164ee8ac4c31b75e1a2339f6549d90bc154aa3ba5eb513846c3e832370b796886f43d885a493f6c9dee7050e2c8e2379f443e7bd4ccba90e813848df4051c26bc442769e35b9560a3643ca8bf5076685a9408a95b9bf880cbf51d2340c26515c5d4e1bb60a433f1c4ff1ae94872de8e5724d76adba67336681acc36f52e4f7b1fc4a349bd22fc3eb24682865c0fc89cc464d93b201c9c14826f630c4d5bae4064d49039af973eafe5d083b55952ed6dfe04e07878db10ce07fb8c24eb4064bbe91483985bd15c8070682d9b5a8e0f94ca04b609c71b6600edc369d4dc464f940d84706ad7050625830fe19c486b2856754482d8abd",
                DateA = new DateTime(2018, 1, 15),
                DateD = new DateTime(2012, 9, 2),
                Sort = 1462220238,
                Note = "004da5839aa34734a702943dfafe8b7fc621df0a392342f79bd847e48c5d95746f0b8cef7c754d118b5f5a9bfb702f40032733cec33340d3b457df6010d6685b7c2db6831a774774a755b8a9b8c83f6e064efaaf2f12417d90813d18f1b2e8c09a2a12843fc84f878f4271fba7e625804c81bb47f1334832b57711ad0068ca7e7ecf1498c6df4fe99956165b3c3cd9b8a1a15266a070429084bc0144fa271071025273caf5644cc9b7f463d107ff2d56388e1c580d5e4ca48e78fc5aec9ff07d3eade7cf6e134f068df69ff35d594065c518c7c055664e139e3b48bff2993be87c70d22b498b463a8ead36de86e24d86fcbc4c98f3b846b194d0",
                Status = "8145970f4ce94f7094b22147e235dab890bb4b542ee046a8b9"
            };

            // Act
            var serviceResult = await _companyJobWorkIdentitiesAppService.UpdateAsync(Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"), input);

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("3bf5f611-e5bc-42bd-bd77-4a30ddb9744b"));
            result.CompanyJobId.ShouldBe(Guid.Parse("db5a7b85-b30d-4c3c-a65e-f364a02ae8cb"));
            result.WorkIdentityCode.ShouldBe(Guid.Parse("02ab699b-2a7b-45ea-8125-c0dab1acb00e"));
            result.ExtendedInformation.ShouldBe("90fae0378e164ee8ac4c31b75e1a2339f6549d90bc154aa3ba5eb513846c3e832370b796886f43d885a493f6c9dee7050e2c8e2379f443e7bd4ccba90e813848df4051c26bc442769e35b9560a3643ca8bf5076685a9408a95b9bf880cbf51d2340c26515c5d4e1bb60a433f1c4ff1ae94872de8e5724d76adba67336681acc36f52e4f7b1fc4a349bd22fc3eb24682865c0fc89cc464d93b201c9c14826f630c4d5bae4064d49039af973eafe5d083b55952ed6dfe04e07878db10ce07fb8c24eb4064bbe91483985bd15c8070682d9b5a8e0f94ca04b609c71b6600edc369d4dc464f940d84706ad7050625830fe19c486b2856754482d8abd");
            result.DateA.ShouldBe(new DateTime(2018, 1, 15));
            result.DateD.ShouldBe(new DateTime(2012, 9, 2));
            result.Sort.ShouldBe(1462220238);
            result.Note.ShouldBe("004da5839aa34734a702943dfafe8b7fc621df0a392342f79bd847e48c5d95746f0b8cef7c754d118b5f5a9bfb702f40032733cec33340d3b457df6010d6685b7c2db6831a774774a755b8a9b8c83f6e064efaaf2f12417d90813d18f1b2e8c09a2a12843fc84f878f4271fba7e625804c81bb47f1334832b57711ad0068ca7e7ecf1498c6df4fe99956165b3c3cd9b8a1a15266a070429084bc0144fa271071025273caf5644cc9b7f463d107ff2d56388e1c580d5e4ca48e78fc5aec9ff07d3eade7cf6e134f068df69ff35d594065c518c7c055664e139e3b48bff2993be87c70d22b498b463a8ead36de86e24d86fcbc4c98f3b846b194d0");
            result.Status.ShouldBe("8145970f4ce94f7094b22147e235dab890bb4b542ee046a8b9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobWorkIdentitiesAppService.DeleteAsync(Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"));

            // Assert
            var result = await _companyJobWorkIdentityRepository.FindAsync(c => c.Id == Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"));

            result.ShouldBeNull();
        }
    }
}