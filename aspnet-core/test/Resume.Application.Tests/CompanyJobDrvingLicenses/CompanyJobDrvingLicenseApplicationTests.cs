using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicensesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobDrvingLicensesAppService _companyJobDrvingLicensesAppService;
        private readonly IRepository<CompanyJobDrvingLicense, Guid> _companyJobDrvingLicenseRepository;

        public CompanyJobDrvingLicensesAppServiceTests()
        {
            _companyJobDrvingLicensesAppService = GetRequiredService<ICompanyJobDrvingLicensesAppService>();
            _companyJobDrvingLicenseRepository = GetRequiredService<IRepository<CompanyJobDrvingLicense, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetListAsync(new GetCompanyJobDrvingLicensesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("dd8b2fc5-e4db-4547-9094-3ff52e22b165")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetAsync(Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseCreateDto
            {
                CompanyMainId = Guid.Parse("77096547-142e-4476-b877-53984d16ef5d"),
                CompanyJobId = Guid.Parse("d7965288-29f1-4e9d-9b20-0aa2a7939faf"),
                DrvingLicenseCode = "51480eb36b7b46f5bae8e0cdeca5dc735b96dc0c0bde44139d",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "83201db2e12a44f5afd4c4acc2fe48f98c843b10e0cd4d8cba709c1c22f4721cbbe11fd643534b09be4031b3d59d4bad3b33d7eb60c14104b402c3dfc0d7abbf975a0b075b8d47f98f29319c6c0bfe2d9a8a304d30cb49c9967d34e603419e53eabec59967bf41049748fdbe2982ded91fc6b21c60b2481686565104c92a5babeafab3fdbbaf42cdaaac841b20ead642e2078a5266314e41a650b969206c7378af4b56ecdf3147d09176b4e62eb16bb6c06912c85ce74a70b1bf8829a788d324b8583a1c552b4d569583d93fc3dd86d18b1adc7750d343d38c8eb8138e1a915a3c2aa2c1eb194efcbfbe0b1548f9d3fb576a9688ed1c45a287f2",
                DateA = new DateTime(2002, 5, 9),
                DateD = new DateTime(2011, 6, 18),
                Sort = 1921457512,
                Note = "31f7e22a77394ca58dd4ecfaf6667490a5e5bbf2e2414022b25f4c0ebde769b1975e77eb71d1474bb67de7a17d499876d696d73187614d52a23c10a3fad957569e58c95a755541d48d61d6131735bb6157750cf1b15749058fb1087ead3095c338e3f3353b15466faf83978741eb3d88f58517dd4e5840bd9c843b0d303b26e11737884243304b76bf1c5b6edbe3903a2067095d383b4fa58ff2f716219b9e1f6fa8e0b8b90947c08770f08e2a1facce655a80793256402dacd014132ad7697f5c658e3fabad4ccda7cd71f8e5af4187a358f2f3815b4d2f82a92243106a07c871101f0669134211bba4665778d2fe3645365dbc2ab5472787e3",
                Status = "5b209368314343bb875d3e197a9b97913cd99bf76a394b35b0"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("77096547-142e-4476-b877-53984d16ef5d"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d7965288-29f1-4e9d-9b20-0aa2a7939faf"));
            result.DrvingLicenseCode.ShouldBe("51480eb36b7b46f5bae8e0cdeca5dc735b96dc0c0bde44139d");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("83201db2e12a44f5afd4c4acc2fe48f98c843b10e0cd4d8cba709c1c22f4721cbbe11fd643534b09be4031b3d59d4bad3b33d7eb60c14104b402c3dfc0d7abbf975a0b075b8d47f98f29319c6c0bfe2d9a8a304d30cb49c9967d34e603419e53eabec59967bf41049748fdbe2982ded91fc6b21c60b2481686565104c92a5babeafab3fdbbaf42cdaaac841b20ead642e2078a5266314e41a650b969206c7378af4b56ecdf3147d09176b4e62eb16bb6c06912c85ce74a70b1bf8829a788d324b8583a1c552b4d569583d93fc3dd86d18b1adc7750d343d38c8eb8138e1a915a3c2aa2c1eb194efcbfbe0b1548f9d3fb576a9688ed1c45a287f2");
            result.DateA.ShouldBe(new DateTime(2002, 5, 9));
            result.DateD.ShouldBe(new DateTime(2011, 6, 18));
            result.Sort.ShouldBe(1921457512);
            result.Note.ShouldBe("31f7e22a77394ca58dd4ecfaf6667490a5e5bbf2e2414022b25f4c0ebde769b1975e77eb71d1474bb67de7a17d499876d696d73187614d52a23c10a3fad957569e58c95a755541d48d61d6131735bb6157750cf1b15749058fb1087ead3095c338e3f3353b15466faf83978741eb3d88f58517dd4e5840bd9c843b0d303b26e11737884243304b76bf1c5b6edbe3903a2067095d383b4fa58ff2f716219b9e1f6fa8e0b8b90947c08770f08e2a1facce655a80793256402dacd014132ad7697f5c658e3fabad4ccda7cd71f8e5af4187a358f2f3815b4d2f82a92243106a07c871101f0669134211bba4665778d2fe3645365dbc2ab5472787e3");
            result.Status.ShouldBe("5b209368314343bb875d3e197a9b97913cd99bf76a394b35b0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseUpdateDto()
            {
                CompanyMainId = Guid.Parse("6cb9a1e9-3a2e-4266-a1f7-a74fa9cb5c3b"),
                CompanyJobId = Guid.Parse("3cd4d596-f894-4efe-9d19-c9a94e77ed6b"),
                DrvingLicenseCode = "50266eb6eb0446b9b08108df89787ab19fdb0674d4a748f68c",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "6af446329623485a97040fe5aa9193774ee9a05f2a6d46e29a65bb13a1507ed989dcd86495084b28b3c9095f770bdcceeeafee0bf2e0496693c2859aa75203635b73b467eeff4507863d8a3089cb774a24836ac04bce47b895c32ef234aeacba5fb8d280e848472fb3e3d4bbb2938393099ac470f9fa46ccb63fa6f2cacc2e100e3fd4c2b416412b87938eccdacc0c57f7d994276d20434d9da61c7ea68908e2b401b494f1ad4c4989602586cc114c7b97322dde24fb43b09ecef4b0db76debf7809957b7f034bb9bcd78aa579c6d22cfaa4d19e4bd0453e905c6580c9fc9a05572d01bdef7c42588cfce23e0773fdeca9cfd0759b4644779758",
                DateA = new DateTime(2008, 2, 24),
                DateD = new DateTime(2010, 1, 24),
                Sort = 1993083492,
                Note = "7b57a0ad46004db4bc85b51d80760397b3ab7348a497431d940d73dea8f6bfd8c0c398512bdd4c6d8b3866e362e5adbb0b5d3552e5a84fa698030c580de4c880e25cbeab9cf946f6bb3d31d2d21f0a8088cc1205b1ce4d52ab2dd987fa91746926141826ad8a41289bfe6f00e0e50dbe59f805a1ad1747dc8ee7e7d5217350d75af1422ff66b4c60b5346a6da1cad0efaa85225f959c40efa45acd2d12c77b1635f87b0a1e1b44c794af02f14cea16761ab9662437b64a729117fbe1554534623820df9170f847bab63638a6ee62655d3c7b10ce7ecd4af285cc5d9004e9dcd55917093ed57e49a48b3f83b6089a489825851c20b0ea4787b18d",
                Status = "dd103b65f6ce4ebb91912511352f1b5772e3c5b455fb4ff0b0"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.UpdateAsync(Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"), input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("6cb9a1e9-3a2e-4266-a1f7-a74fa9cb5c3b"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3cd4d596-f894-4efe-9d19-c9a94e77ed6b"));
            result.DrvingLicenseCode.ShouldBe("50266eb6eb0446b9b08108df89787ab19fdb0674d4a748f68c");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("6af446329623485a97040fe5aa9193774ee9a05f2a6d46e29a65bb13a1507ed989dcd86495084b28b3c9095f770bdcceeeafee0bf2e0496693c2859aa75203635b73b467eeff4507863d8a3089cb774a24836ac04bce47b895c32ef234aeacba5fb8d280e848472fb3e3d4bbb2938393099ac470f9fa46ccb63fa6f2cacc2e100e3fd4c2b416412b87938eccdacc0c57f7d994276d20434d9da61c7ea68908e2b401b494f1ad4c4989602586cc114c7b97322dde24fb43b09ecef4b0db76debf7809957b7f034bb9bcd78aa579c6d22cfaa4d19e4bd0453e905c6580c9fc9a05572d01bdef7c42588cfce23e0773fdeca9cfd0759b4644779758");
            result.DateA.ShouldBe(new DateTime(2008, 2, 24));
            result.DateD.ShouldBe(new DateTime(2010, 1, 24));
            result.Sort.ShouldBe(1993083492);
            result.Note.ShouldBe("7b57a0ad46004db4bc85b51d80760397b3ab7348a497431d940d73dea8f6bfd8c0c398512bdd4c6d8b3866e362e5adbb0b5d3552e5a84fa698030c580de4c880e25cbeab9cf946f6bb3d31d2d21f0a8088cc1205b1ce4d52ab2dd987fa91746926141826ad8a41289bfe6f00e0e50dbe59f805a1ad1747dc8ee7e7d5217350d75af1422ff66b4c60b5346a6da1cad0efaa85225f959c40efa45acd2d12c77b1635f87b0a1e1b44c794af02f14cea16761ab9662437b64a729117fbe1554534623820df9170f847bab63638a6ee62655d3c7b10ce7ecd4af285cc5d9004e9dcd55917093ed57e49a48b3f83b6089a489825851c20b0ea4787b18d");
            result.Status.ShouldBe("dd103b65f6ce4ebb91912511352f1b5772e3c5b455fb4ff0b0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDrvingLicensesAppService.DeleteAsync(Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"));

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"));

            result.ShouldBeNull();
        }
    }
}