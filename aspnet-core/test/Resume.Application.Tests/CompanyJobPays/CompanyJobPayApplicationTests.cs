using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPaysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPaysAppService _companyJobPaysAppService;
        private readonly IRepository<CompanyJobPay, Guid> _companyJobPayRepository;

        public CompanyJobPaysAppServiceTests()
        {
            _companyJobPaysAppService = GetRequiredService<ICompanyJobPaysAppService>();
            _companyJobPayRepository = GetRequiredService<IRepository<CompanyJobPay, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetListAsync(new GetCompanyJobPaysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8e061fe3-a0fc-4cd5-bec3-c8a31d5c506b")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetAsync(Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPayCreateDto
            {
                CompanyMainId = Guid.Parse("5cfee8fd-1588-4965-820d-f8e756609a58"),
                CompanyJobId = Guid.Parse("a2b13452-477f-49b0-aebf-1f3f8b25764a"),
                JobPayTypeCode = "038fa3c0fa69467a9ed17c390fa377fcee2ae26c6a9047bca9",
                DateReal = new DateTime(2005, 10, 12),
                IsCancel = true,
                ExtendedInformation = "6db7f2a499374527916f0f54ea68f4a41eabd76eadff47cbba8ba77026e06e95c8ee354ff43449b998829556109f599a386f32fb9cfc422f8ba45f484892f152d944537b138044abaa79f26c62aa2a6abf2dc8400c48484880a216a34a782fef40021e0690434293ac2798e1d29c792f58a072ea6f354b769d11b5de0c5272ba231a1e232747439a8b531153031351c87ef5bea8c2ec4a568168d2d4f04e781c92676d3f300e4650a98801eddf80ed5ee7a431dbc92c4b5897d6e872d4240d51c0732c857ad8428a9520e82eb3cf642409aae79bda724c4d860d9d3cf55e3915bf5cbf92e81646d093bda84b7fb8f480b6fb80aa6c924ba8a6f6",
                DateA = new DateTime(2002, 3, 4),
                DateD = new DateTime(2021, 9, 27),
                Sort = 1109125653,
                Note = "6f06549d556c493e98fbdcfc8542786bc4fffbdebeb248788a817962ed7dcc612cdc35c6147e48359425b094f351745b1c565cec498c416bb058d6ec0e22132ff53f731cf14a4080bc04bb79c5a9b9e6caa92ad712c54148923608de426fec1c7812536ea2f7480a9a8c57b7a5292755a06bc39a3174491c9f7921c50e4049a1923f1a0c57444f35a262c67a593274b1d249b4ba614a4e2c87ba674d9b60e7fc6ce9e1c08a644114ba274d2c16a091ba53d61cfb71a341eb852a520a730f92a0186034b03f4f4bf8a09f7595da16ccfd08ec4526f3564c039f06479065b6448aa98fd6268afd42db8c6a906c7bc427eee635220c5a0a4667be04",
                Status = "a1d6939f296447ec9add251f38b5fb44c26ec5eef77c4c8398"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("5cfee8fd-1588-4965-820d-f8e756609a58"));
            result.CompanyJobId.ShouldBe(Guid.Parse("a2b13452-477f-49b0-aebf-1f3f8b25764a"));
            result.JobPayTypeCode.ShouldBe("038fa3c0fa69467a9ed17c390fa377fcee2ae26c6a9047bca9");
            result.DateReal.ShouldBe(new DateTime(2005, 10, 12));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("6db7f2a499374527916f0f54ea68f4a41eabd76eadff47cbba8ba77026e06e95c8ee354ff43449b998829556109f599a386f32fb9cfc422f8ba45f484892f152d944537b138044abaa79f26c62aa2a6abf2dc8400c48484880a216a34a782fef40021e0690434293ac2798e1d29c792f58a072ea6f354b769d11b5de0c5272ba231a1e232747439a8b531153031351c87ef5bea8c2ec4a568168d2d4f04e781c92676d3f300e4650a98801eddf80ed5ee7a431dbc92c4b5897d6e872d4240d51c0732c857ad8428a9520e82eb3cf642409aae79bda724c4d860d9d3cf55e3915bf5cbf92e81646d093bda84b7fb8f480b6fb80aa6c924ba8a6f6");
            result.DateA.ShouldBe(new DateTime(2002, 3, 4));
            result.DateD.ShouldBe(new DateTime(2021, 9, 27));
            result.Sort.ShouldBe(1109125653);
            result.Note.ShouldBe("6f06549d556c493e98fbdcfc8542786bc4fffbdebeb248788a817962ed7dcc612cdc35c6147e48359425b094f351745b1c565cec498c416bb058d6ec0e22132ff53f731cf14a4080bc04bb79c5a9b9e6caa92ad712c54148923608de426fec1c7812536ea2f7480a9a8c57b7a5292755a06bc39a3174491c9f7921c50e4049a1923f1a0c57444f35a262c67a593274b1d249b4ba614a4e2c87ba674d9b60e7fc6ce9e1c08a644114ba274d2c16a091ba53d61cfb71a341eb852a520a730f92a0186034b03f4f4bf8a09f7595da16ccfd08ec4526f3564c039f06479065b6448aa98fd6268afd42db8c6a906c7bc427eee635220c5a0a4667be04");
            result.Status.ShouldBe("a1d6939f296447ec9add251f38b5fb44c26ec5eef77c4c8398");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPayUpdateDto()
            {
                CompanyMainId = Guid.Parse("79b4c5df-391f-471b-a15a-54428f1d8d4e"),
                CompanyJobId = Guid.Parse("c689ae1c-b2a1-4abe-b4d1-3c151a6da4b8"),
                JobPayTypeCode = "cc2cdd6fd4f9435c9b43f2e371254e8eb7ee03f368c54e4589",
                DateReal = new DateTime(2020, 7, 7),
                IsCancel = true,
                ExtendedInformation = "5214b8fd58c846d3989b3e616b32688ba9d95a4f504c4f0eb51e338b8567a4ebbe0e02d5de3d459fb026204309253bf8b2641d0066e844c0bc4054a621329345c404feba4a2f468c9100be718f765fecbed076f0f2ec4162b677e2bccfa33b7a079f03085e3c4ba98ac95563ab7078a7868b373449024560a795f2450302bd32d5042161e2964853ac3bce708e1df529c3cba7209b1f4195b59f4f8ba844cefb27604ff854944d10b7b7739fe51d029e3705a2703fc641d284616eee5b544e13c44bf23eea4b467a819bd4667f7efce8aa9d21ae2c714b30ab811d9a0306940b3ee29356f73a46c1b230b4d74fa6416f715e995d09fb494ba4ce",
                DateA = new DateTime(2004, 2, 24),
                DateD = new DateTime(2017, 1, 24),
                Sort = 139004564,
                Note = "3dc0fd953c0040929dfc4c3cb54491d2ad475a7ff953491e85a37e05777e070e0c8c8a760a6e4f4597dc1e0b3ef31b18e2a3d7b84cd24c56a386e51c3bc33b5cbb253c40a1d643b89d2165c266be7ae59a50077d2ad743af804818fae1321860869d5480e8e04dd08e9108b57349cec878efde6444a34ef8b2a5b0c14f89dba0af8ce827ca9e4780b9b5c93e8e9e9f5e220ab567c43947bfab1f5827f742e91cb08bdb8fe22744038e91bedd66f0103817492e78a8dc4015acf6672b3f99fc21802172c015ac46288efd47b7a2ed146ce53c53e95aac46d4b92dcc50538ad641cc1ddae978eb4fefa1ff2bfbd401b4cd51b82e73350f4ab083ac",
                Status = "f0b0f0d7546744d6910c26f12742ea1d3e6b833baf1a4f72a6"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.UpdateAsync(Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"), input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("79b4c5df-391f-471b-a15a-54428f1d8d4e"));
            result.CompanyJobId.ShouldBe(Guid.Parse("c689ae1c-b2a1-4abe-b4d1-3c151a6da4b8"));
            result.JobPayTypeCode.ShouldBe("cc2cdd6fd4f9435c9b43f2e371254e8eb7ee03f368c54e4589");
            result.DateReal.ShouldBe(new DateTime(2020, 7, 7));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("5214b8fd58c846d3989b3e616b32688ba9d95a4f504c4f0eb51e338b8567a4ebbe0e02d5de3d459fb026204309253bf8b2641d0066e844c0bc4054a621329345c404feba4a2f468c9100be718f765fecbed076f0f2ec4162b677e2bccfa33b7a079f03085e3c4ba98ac95563ab7078a7868b373449024560a795f2450302bd32d5042161e2964853ac3bce708e1df529c3cba7209b1f4195b59f4f8ba844cefb27604ff854944d10b7b7739fe51d029e3705a2703fc641d284616eee5b544e13c44bf23eea4b467a819bd4667f7efce8aa9d21ae2c714b30ab811d9a0306940b3ee29356f73a46c1b230b4d74fa6416f715e995d09fb494ba4ce");
            result.DateA.ShouldBe(new DateTime(2004, 2, 24));
            result.DateD.ShouldBe(new DateTime(2017, 1, 24));
            result.Sort.ShouldBe(139004564);
            result.Note.ShouldBe("3dc0fd953c0040929dfc4c3cb54491d2ad475a7ff953491e85a37e05777e070e0c8c8a760a6e4f4597dc1e0b3ef31b18e2a3d7b84cd24c56a386e51c3bc33b5cbb253c40a1d643b89d2165c266be7ae59a50077d2ad743af804818fae1321860869d5480e8e04dd08e9108b57349cec878efde6444a34ef8b2a5b0c14f89dba0af8ce827ca9e4780b9b5c93e8e9e9f5e220ab567c43947bfab1f5827f742e91cb08bdb8fe22744038e91bedd66f0103817492e78a8dc4015acf6672b3f99fc21802172c015ac46288efd47b7a2ed146ce53c53e95aac46d4b92dcc50538ad641cc1ddae978eb4fefa1ff2bfbd401b4cd51b82e73350f4ab083ac");
            result.Status.ShouldBe("f0b0f0d7546744d6910c26f12742ea1d3e6b833baf1a4f72a6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPaysAppService.DeleteAsync(Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"));

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"));

            result.ShouldBeNull();
        }
    }
}