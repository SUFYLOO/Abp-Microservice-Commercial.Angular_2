using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobs
{
    public class CompanyJobsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobsAppService _companyJobsAppService;
        private readonly IRepository<CompanyJob, Guid> _companyJobRepository;

        public CompanyJobsAppServiceTests()
        {
            _companyJobsAppService = GetRequiredService<ICompanyJobsAppService>();
            _companyJobRepository = GetRequiredService<IRepository<CompanyJob, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobsAppService.GetListAsync(new GetCompanyJobsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("65c2124a-be3e-49e1-bbd5-d115f87402e9")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobsAppService.GetAsync(Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobCreateDto
            {
                CompanyMainId = Guid.Parse("00f2debc-ec8b-441e-ba1e-54b5820b7b39"),
                Name = "d690c4dcc28748cc8ea50c8b7ea99461454c98d6695f42a5b8",
                JobTypeCode = "9bebcd686e2349aab30731a98f52f59125e2e2eb527349ad9b",
                JobOpen = true,
                MailTplId = "d682edc4c9954bfa8c576b50c1442c2f9bf426ed30684837a5",
                SMSTplId = "012d73a23913479e99a7434d90fa9a7945b7b87d909144d6b9",
                ExtendedInformation = "a31ebf75a70c48da9f0ff152f436153537cff2c77b354753a4e9b7cac9f259cf080dd9a4d6c941ccbb32f1428e692d5044345898dfb448f29b3aa53430d317f4203e234b63fb4102816736cbe593ad08f740d1fd564246439a3d090f42ccb736f365279d3c5b4d5397aed9c91bdde2403534e85f55854453a9d5088c4dc0e37c3d69f8eede2d409094bf71c9af92ee5f284821ed43364aeea31e3c61ac08e1068c7aa7c1c2d84cfa8e3a5c6fa9acd6ed88b8e4f7b1164c2b882f73f5290c03a225d7249ddb29441abd87a0306763430250fb45e1d087414eb35c15ee193f5e3d3b99acd2e5694de09bef86f698d477b677fdeba3cb19435295ab",
                DateA = new DateTime(2009, 6, 19),
                DateD = new DateTime(2006, 1, 18),
                Sort = 1813709877,
                Note = "0415ce778d274bf6bbf113f8637d4fe6bb93736d3270409bb13aac31f8b2bf56f343159cbb064d6e9bc2e22c726c0ab2fbff5e68089941259a0edace05daf6ad64e15a894f694e3dada9095a71fe8d327fbe1b6f96644306ad5f697a83985c42c714af7e567341a290d0c472073df8df4ed93978df9f49b0bdc79c8cc0a193e1bfbbd179aab540aea244ad09ae5178ed6020c06ddc2e4e24b3757a61b7961afc1f0cfe8049764d1b9ee5e20e54a8341d04f37f92497f4f3680832abe8681e834f8a071040b61409e953648280e839cbcd29e64bfc535470d92887aeb5e41da4a367c43428a514dde9f84c4dad49df7ef05e22864c3af45ea8bca",
                Status = "8d1a306981f742eaa7b28ca63c1c72e4b8347d05a9294058b0"
            };

            // Act
            var serviceResult = await _companyJobsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("00f2debc-ec8b-441e-ba1e-54b5820b7b39"));
            result.Name.ShouldBe("d690c4dcc28748cc8ea50c8b7ea99461454c98d6695f42a5b8");
            result.JobTypeCode.ShouldBe("9bebcd686e2349aab30731a98f52f59125e2e2eb527349ad9b");
            result.JobOpen.ShouldBe(true);
            result.MailTplId.ShouldBe("d682edc4c9954bfa8c576b50c1442c2f9bf426ed30684837a5");
            result.SMSTplId.ShouldBe("012d73a23913479e99a7434d90fa9a7945b7b87d909144d6b9");
            result.ExtendedInformation.ShouldBe("a31ebf75a70c48da9f0ff152f436153537cff2c77b354753a4e9b7cac9f259cf080dd9a4d6c941ccbb32f1428e692d5044345898dfb448f29b3aa53430d317f4203e234b63fb4102816736cbe593ad08f740d1fd564246439a3d090f42ccb736f365279d3c5b4d5397aed9c91bdde2403534e85f55854453a9d5088c4dc0e37c3d69f8eede2d409094bf71c9af92ee5f284821ed43364aeea31e3c61ac08e1068c7aa7c1c2d84cfa8e3a5c6fa9acd6ed88b8e4f7b1164c2b882f73f5290c03a225d7249ddb29441abd87a0306763430250fb45e1d087414eb35c15ee193f5e3d3b99acd2e5694de09bef86f698d477b677fdeba3cb19435295ab");
            result.DateA.ShouldBe(new DateTime(2009, 6, 19));
            result.DateD.ShouldBe(new DateTime(2006, 1, 18));
            result.Sort.ShouldBe(1813709877);
            result.Note.ShouldBe("0415ce778d274bf6bbf113f8637d4fe6bb93736d3270409bb13aac31f8b2bf56f343159cbb064d6e9bc2e22c726c0ab2fbff5e68089941259a0edace05daf6ad64e15a894f694e3dada9095a71fe8d327fbe1b6f96644306ad5f697a83985c42c714af7e567341a290d0c472073df8df4ed93978df9f49b0bdc79c8cc0a193e1bfbbd179aab540aea244ad09ae5178ed6020c06ddc2e4e24b3757a61b7961afc1f0cfe8049764d1b9ee5e20e54a8341d04f37f92497f4f3680832abe8681e834f8a071040b61409e953648280e839cbcd29e64bfc535470d92887aeb5e41da4a367c43428a514dde9f84c4dad49df7ef05e22864c3af45ea8bca");
            result.Status.ShouldBe("8d1a306981f742eaa7b28ca63c1c72e4b8347d05a9294058b0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobUpdateDto()
            {
                CompanyMainId = Guid.Parse("6dde83d4-20b6-4272-88c4-4175833fc368"),
                Name = "05377a47b02f481d996f6a7d4d021505bea95189bead4bdab4",
                JobTypeCode = "06a9d1ceea36499ab279861654f1a88e130637dc7ae5449e82",
                JobOpen = true,
                MailTplId = "3e0c44119dd0424e9a6b24f30cf22902ffc5f46408a844be80",
                SMSTplId = "db6ab39ed876495bab10e615231d50ae617af717c7af458eac",
                ExtendedInformation = "defeb00b7c954be4bce40ee5fc652264753dd02102bc48718a5179b4300253f3ddcb67332c584157b1b6706b395dd0d17d0a21fdc7864a8ebf50e5ae3717ee3d80ad50b914e64ac3bbc5c967daa4570a88a621a0a45d41afa7969c58c24ba73355663a28591a4a838291afb2a63ae7d761f71a9298dc44c2a0747678cc04459289692a626af14901a68436acbf2b58fd975dfec6d47242179a5b9131f19fd28067faa24c5f104fe6877e6515c02e8637c4eafbfb046e4043a8779c8f62df5aec277c63b827cd407bbdad37df3ae398f1f6e6b4ac41764c79b7aa6e29209dc519569e41dd7ad248c2aa7ba9922ccfc15c7877e929725742b3a965",
                DateA = new DateTime(2002, 11, 11),
                DateD = new DateTime(2020, 5, 27),
                Sort = 35302989,
                Note = "7d74507f96cc4fb2bcc292d3a82119df220e8ed503b84538b36114358959fa2bb67fcce69f2c4746b1e0f7af12deae6dcfaad8e68e6f4bc9a3708d21fcb6084e24319d5e66e541c3a60905ffd3f28d725b41950559e34afe953bbac19468e78836bf551e95e64412b6ac662dc550d729c51b6724e31e490e8ee7543e6e3fe734829a3eda175d4423a8eab863c038db6299903dfdfd0041288d46548acfbdbd12c159d2c314bf42fea84f7937f4e7b50345b833a03c9348499fb4f1ff9a3e30f60f60fe561b914441a107467436cbe6520ebff1236dad488eb2113bfa97f64c7f85c0fd5fa9ad4824a562116d0ca9a3d7f5c1e4bb34884384a0ab",
                Status = "b90a0d0e215f4cba988c4b921cd5c93ecc6a4191f4ec433594"
            };

            // Act
            var serviceResult = await _companyJobsAppService.UpdateAsync(Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"), input);

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("6dde83d4-20b6-4272-88c4-4175833fc368"));
            result.Name.ShouldBe("05377a47b02f481d996f6a7d4d021505bea95189bead4bdab4");
            result.JobTypeCode.ShouldBe("06a9d1ceea36499ab279861654f1a88e130637dc7ae5449e82");
            result.JobOpen.ShouldBe(true);
            result.MailTplId.ShouldBe("3e0c44119dd0424e9a6b24f30cf22902ffc5f46408a844be80");
            result.SMSTplId.ShouldBe("db6ab39ed876495bab10e615231d50ae617af717c7af458eac");
            result.ExtendedInformation.ShouldBe("defeb00b7c954be4bce40ee5fc652264753dd02102bc48718a5179b4300253f3ddcb67332c584157b1b6706b395dd0d17d0a21fdc7864a8ebf50e5ae3717ee3d80ad50b914e64ac3bbc5c967daa4570a88a621a0a45d41afa7969c58c24ba73355663a28591a4a838291afb2a63ae7d761f71a9298dc44c2a0747678cc04459289692a626af14901a68436acbf2b58fd975dfec6d47242179a5b9131f19fd28067faa24c5f104fe6877e6515c02e8637c4eafbfb046e4043a8779c8f62df5aec277c63b827cd407bbdad37df3ae398f1f6e6b4ac41764c79b7aa6e29209dc519569e41dd7ad248c2aa7ba9922ccfc15c7877e929725742b3a965");
            result.DateA.ShouldBe(new DateTime(2002, 11, 11));
            result.DateD.ShouldBe(new DateTime(2020, 5, 27));
            result.Sort.ShouldBe(35302989);
            result.Note.ShouldBe("7d74507f96cc4fb2bcc292d3a82119df220e8ed503b84538b36114358959fa2bb67fcce69f2c4746b1e0f7af12deae6dcfaad8e68e6f4bc9a3708d21fcb6084e24319d5e66e541c3a60905ffd3f28d725b41950559e34afe953bbac19468e78836bf551e95e64412b6ac662dc550d729c51b6724e31e490e8ee7543e6e3fe734829a3eda175d4423a8eab863c038db6299903dfdfd0041288d46548acfbdbd12c159d2c314bf42fea84f7937f4e7b50345b833a03c9348499fb4f1ff9a3e30f60f60fe561b914441a107467436cbe6520ebff1236dad488eb2113bfa97f64c7f85c0fd5fa9ad4824a562116d0ca9a3d7f5c1e4bb34884384a0ab");
            result.Status.ShouldBe("b90a0d0e215f4cba988c4b921cd5c93ecc6a4191f4ec433594");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobsAppService.DeleteAsync(Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"));

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"));

            result.ShouldBeNull();
        }
    }
}