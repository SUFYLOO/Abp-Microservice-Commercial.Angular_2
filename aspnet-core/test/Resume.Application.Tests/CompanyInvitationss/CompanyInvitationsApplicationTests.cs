using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyInvitationss
{
    public class CompanyInvitationssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyInvitationssAppService _companyInvitationssAppService;
        private readonly IRepository<CompanyInvitations, Guid> _companyInvitationsRepository;

        public CompanyInvitationssAppServiceTests()
        {
            _companyInvitationssAppService = GetRequiredService<ICompanyInvitationssAppService>();
            _companyInvitationsRepository = GetRequiredService<IRepository<CompanyInvitations, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyInvitationssAppService.GetListAsync(new GetCompanyInvitationssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("99abf58f-5856-4d08-b241-1c75c7b53b09")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationssAppService.GetAsync(Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCreateDto
            {
                CompanyMainId = Guid.Parse("96f2f5b8-1e3c-4f84-b6d0-3d149ea44583"),
                CompanyJobId = Guid.Parse("36278b38-b788-4594-b989-d9d9430ee9ee"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("e23b0b5c-0f7d-47d8-879c-b4553a31f6f5"),
                UserMainName = "9e14547ba60b426bbf529d2fd6769917703eef8c81c44e4292",
                UserMainLoginMobilePhone = "2de2121d91f74f70a1298c0e6847d97978d51d3c145c417db9",
                UserMainLoginEmail = "a53528213bd54713ba1746ef949dff4d93a783fa98114cf2adc60fecc88fa20351755148436b4d109986b7409a282765dd84b6a6909b461783626efd54ebdcb82e41cb5fe0b0410280c12d39102bedc267a9c38d4f154c1fa9f185bb9fdccb6360785efc",
                UserMainLoginIdentityNo = "5d4eb252b2f940258613ac01536e0110c3bf8ede01b144f9b7",
                SendTypeCode = "05ac5d7abe96437dbe56590580a0468a4f7b7b7ebebf403eb9",
                SendStatusCode = "68498503177a4df5be788cd2601f7d74db88443095584b4e85",
                ResumeFlowStageCode = "9968d23b1f1f4e249b4934ddc5741bfc717d5e44dc4f4c03a0",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("32c4801b-79a3-4171-bbdf-4c61d5f839ca"),
                ResumeSnapshotId = Guid.Parse("6ea0b888-4af6-425a-8038-3edda686afcc"),
                ExtendedInformation = "d2a4dc065a004b629dc3410cf9359797a524e565608741b786d49f1a52299cd314b22a01daf14b3199940618445928284a2029233994401f93d2afb6312f33a8ca4cc25b68a1458aaaf1324be329b96bdcab7819cf11408ab503ae2e5e1545cc08d571e1407745489a9dbcb539ee806543469b10222d436f9ef613ff290a40a76d7ae0bfe867430389c469fbdd37478c90ab61d9b27f4ab3b944901548d859f3f86289c03c684356816e7afdca50eb2234a82184b6dc440993bd6dc11500156c3e6ad41b0f9d4cc5b8bfb9ec17c0c94aab69173da9cf4ce485fd4c6111dd9915d234b645dda04599b8436eae59a8ad2b6633f574cf4749c29337",
                DateA = new DateTime(2004, 3, 11),
                DateD = new DateTime(2011, 3, 21),
                Sort = 2078908310,
                Note = "a6c41aa4f84b43cca3d53843e727d91af4439cbc177f4c62b10416cd4f85bf3d4b7f1c48f7004f4b831000ff2da494680c70ed8e812a43b5bbbf73c0576d882a4ceed79bdec84b8b9835d97109fd906bfbd3e685f9784115b60e3aa7f7ca681dc2ebb4aed2644bb884fdcae2a4d41314c30262463f5a42368b8e4ddc61ea50f82a3cf14d80dd4a92abaecd6319ce44ac564ed0d81b5b48fd818fac3ee23ee87018a40ddcc0e74e80816a84e201760521ad1f95eb3d454e25bdf92879247a4fdc4fb2e08d7dab43b69e7d5a0cedc66ab27ced40fe94574164a0e9b00db759d9418adaf64a0c77411aaedbed94b344e6ed3f16a5abc647445d8c0b",
                Status = "bf95b59dbfa143a6bf583ae18a1614d33e808ee55eea48938d"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("96f2f5b8-1e3c-4f84-b6d0-3d149ea44583"));
            result.CompanyJobId.ShouldBe(Guid.Parse("36278b38-b788-4594-b989-d9d9430ee9ee"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("e23b0b5c-0f7d-47d8-879c-b4553a31f6f5"));
            result.UserMainName.ShouldBe("9e14547ba60b426bbf529d2fd6769917703eef8c81c44e4292");
            result.UserMainLoginMobilePhone.ShouldBe("2de2121d91f74f70a1298c0e6847d97978d51d3c145c417db9");
            result.UserMainLoginEmail.ShouldBe("a53528213bd54713ba1746ef949dff4d93a783fa98114cf2adc60fecc88fa20351755148436b4d109986b7409a282765dd84b6a6909b461783626efd54ebdcb82e41cb5fe0b0410280c12d39102bedc267a9c38d4f154c1fa9f185bb9fdccb6360785efc");
            result.UserMainLoginIdentityNo.ShouldBe("5d4eb252b2f940258613ac01536e0110c3bf8ede01b144f9b7");
            result.SendTypeCode.ShouldBe("05ac5d7abe96437dbe56590580a0468a4f7b7b7ebebf403eb9");
            result.SendStatusCode.ShouldBe("68498503177a4df5be788cd2601f7d74db88443095584b4e85");
            result.ResumeFlowStageCode.ShouldBe("9968d23b1f1f4e249b4934ddc5741bfc717d5e44dc4f4c03a0");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("32c4801b-79a3-4171-bbdf-4c61d5f839ca"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("6ea0b888-4af6-425a-8038-3edda686afcc"));
            result.ExtendedInformation.ShouldBe("d2a4dc065a004b629dc3410cf9359797a524e565608741b786d49f1a52299cd314b22a01daf14b3199940618445928284a2029233994401f93d2afb6312f33a8ca4cc25b68a1458aaaf1324be329b96bdcab7819cf11408ab503ae2e5e1545cc08d571e1407745489a9dbcb539ee806543469b10222d436f9ef613ff290a40a76d7ae0bfe867430389c469fbdd37478c90ab61d9b27f4ab3b944901548d859f3f86289c03c684356816e7afdca50eb2234a82184b6dc440993bd6dc11500156c3e6ad41b0f9d4cc5b8bfb9ec17c0c94aab69173da9cf4ce485fd4c6111dd9915d234b645dda04599b8436eae59a8ad2b6633f574cf4749c29337");
            result.DateA.ShouldBe(new DateTime(2004, 3, 11));
            result.DateD.ShouldBe(new DateTime(2011, 3, 21));
            result.Sort.ShouldBe(2078908310);
            result.Note.ShouldBe("a6c41aa4f84b43cca3d53843e727d91af4439cbc177f4c62b10416cd4f85bf3d4b7f1c48f7004f4b831000ff2da494680c70ed8e812a43b5bbbf73c0576d882a4ceed79bdec84b8b9835d97109fd906bfbd3e685f9784115b60e3aa7f7ca681dc2ebb4aed2644bb884fdcae2a4d41314c30262463f5a42368b8e4ddc61ea50f82a3cf14d80dd4a92abaecd6319ce44ac564ed0d81b5b48fd818fac3ee23ee87018a40ddcc0e74e80816a84e201760521ad1f95eb3d454e25bdf92879247a4fdc4fb2e08d7dab43b69e7d5a0cedc66ab27ced40fe94574164a0e9b00db759d9418adaf64a0c77411aaedbed94b344e6ed3f16a5abc647445d8c0b");
            result.Status.ShouldBe("bf95b59dbfa143a6bf583ae18a1614d33e808ee55eea48938d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsUpdateDto()
            {
                CompanyMainId = Guid.Parse("c489a6e9-f85a-470f-8d19-2ba89edf43e7"),
                CompanyJobId = Guid.Parse("868887f6-191d-4a50-a935-530dfcc061b4"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("7602d11b-b629-4605-b452-596e6fa1baee"),
                UserMainName = "0abf66cd7aa94fb79c5676900430c5bb7293cd90f0e5474199",
                UserMainLoginMobilePhone = "58946bb6e1854f309bcffa52e98731f9079087eb17e14ab087",
                UserMainLoginEmail = "ecfef56b2fa54776b849b23062a65d163abd8943401f4d3e90e7105e3ec6ab86db37833a03cc4cdc91b57e4ce197f38cae6b6b06ffde4f218688cecccdc5fbce12db325aede642beb4fbfcee91fe5cb09398458609d04ac3933039fb307a55b3adcb904a",
                UserMainLoginIdentityNo = "ab24deef6538438d90b1d018c82a70390a02ee5b07a0450bac",
                SendTypeCode = "fa4bde708d8a4c2cb393123da9315cd053fa425ac085437087",
                SendStatusCode = "d8b7ff6a03f34c7b939c16e343928381ec76a829cf5b49ffa4",
                ResumeFlowStageCode = "3ef8766240c2425c8deeecf2df79ce310648caf3c0e549ca87",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("eabe176c-7ac7-4dcb-9f32-dad1da5ac493"),
                ResumeSnapshotId = Guid.Parse("e389e22c-00f5-48fe-9258-0b9605f3e205"),
                ExtendedInformation = "4687f20d368049ada2721d39681954a8f63417f3e22545bcbbe13e6fe84ada249236d77c23474023a278cccb04e3ce23376f0a2ff31642f0b01d49ad34044074014cc6c105484b28ac470b80990dbb124fc547a07928448685bd2313d77e8c1ae459f8586a9244fda8136acd8e25c860dd2ce151db29489b9a61c3bf6b15c917230b9d4326884fa2ad90e5cb79f0d24b16b238f037224c24a82f684e13023164c0a9feb91e3a440094049c65a5b9ff1a5781700a19024ee3b6c080ad8c199f6b732e317eb938473cb34da0cca337cf8f6aa6644f335146ff99633309d94cce9a83c934dfa93f4244a82ba8aff767d2e711d3948b72c64c40a55d",
                DateA = new DateTime(2012, 4, 25),
                DateD = new DateTime(2003, 9, 12),
                Sort = 1581464992,
                Note = "38beb93c033a41279ccdb0e128cfc30329fda51e92ab49d4a4efbcfc42fe0cc9a915f654588144dc8cf1a18a79f57635ee411d9623b946fead0894da6c1b93204e72059bccbe4090bdd2c962d738367015aa09d2a28045c1980bad1fafbeb85ca2cfc218a2c942b7a11a0d94eff6f0e1deda916b2f6842639d083fb4574a55238ea14827e5bf46a8acf253aad2c170049127850080934453a0e8208ad47ebedc2af9b27ad5b44048b14df11b00ab60a19386a1d68dff4d878f112047f42563a4ec7c565b710645b6bdcd100a397848757e9b58c6b38346919a7f56997bcb6f59adbaa2b283154deca262786f546e4b6612cb6b93bcbd42839430",
                Status = "76c2a6c926884b0fa3e2736614b661d0761cb6afed814d8f92"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.UpdateAsync(Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"), input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c489a6e9-f85a-470f-8d19-2ba89edf43e7"));
            result.CompanyJobId.ShouldBe(Guid.Parse("868887f6-191d-4a50-a935-530dfcc061b4"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("7602d11b-b629-4605-b452-596e6fa1baee"));
            result.UserMainName.ShouldBe("0abf66cd7aa94fb79c5676900430c5bb7293cd90f0e5474199");
            result.UserMainLoginMobilePhone.ShouldBe("58946bb6e1854f309bcffa52e98731f9079087eb17e14ab087");
            result.UserMainLoginEmail.ShouldBe("ecfef56b2fa54776b849b23062a65d163abd8943401f4d3e90e7105e3ec6ab86db37833a03cc4cdc91b57e4ce197f38cae6b6b06ffde4f218688cecccdc5fbce12db325aede642beb4fbfcee91fe5cb09398458609d04ac3933039fb307a55b3adcb904a");
            result.UserMainLoginIdentityNo.ShouldBe("ab24deef6538438d90b1d018c82a70390a02ee5b07a0450bac");
            result.SendTypeCode.ShouldBe("fa4bde708d8a4c2cb393123da9315cd053fa425ac085437087");
            result.SendStatusCode.ShouldBe("d8b7ff6a03f34c7b939c16e343928381ec76a829cf5b49ffa4");
            result.ResumeFlowStageCode.ShouldBe("3ef8766240c2425c8deeecf2df79ce310648caf3c0e549ca87");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("eabe176c-7ac7-4dcb-9f32-dad1da5ac493"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("e389e22c-00f5-48fe-9258-0b9605f3e205"));
            result.ExtendedInformation.ShouldBe("4687f20d368049ada2721d39681954a8f63417f3e22545bcbbe13e6fe84ada249236d77c23474023a278cccb04e3ce23376f0a2ff31642f0b01d49ad34044074014cc6c105484b28ac470b80990dbb124fc547a07928448685bd2313d77e8c1ae459f8586a9244fda8136acd8e25c860dd2ce151db29489b9a61c3bf6b15c917230b9d4326884fa2ad90e5cb79f0d24b16b238f037224c24a82f684e13023164c0a9feb91e3a440094049c65a5b9ff1a5781700a19024ee3b6c080ad8c199f6b732e317eb938473cb34da0cca337cf8f6aa6644f335146ff99633309d94cce9a83c934dfa93f4244a82ba8aff767d2e711d3948b72c64c40a55d");
            result.DateA.ShouldBe(new DateTime(2012, 4, 25));
            result.DateD.ShouldBe(new DateTime(2003, 9, 12));
            result.Sort.ShouldBe(1581464992);
            result.Note.ShouldBe("38beb93c033a41279ccdb0e128cfc30329fda51e92ab49d4a4efbcfc42fe0cc9a915f654588144dc8cf1a18a79f57635ee411d9623b946fead0894da6c1b93204e72059bccbe4090bdd2c962d738367015aa09d2a28045c1980bad1fafbeb85ca2cfc218a2c942b7a11a0d94eff6f0e1deda916b2f6842639d083fb4574a55238ea14827e5bf46a8acf253aad2c170049127850080934453a0e8208ad47ebedc2af9b27ad5b44048b14df11b00ab60a19386a1d68dff4d878f112047f42563a4ec7c565b710645b6bdcd100a397848757e9b58c6b38346919a7f56997bcb6f59adbaa2b283154deca262786f546e4b6612cb6b93bcbd42839430");
            result.Status.ShouldBe("76c2a6c926884b0fa3e2736614b661d0761cb6afed814d8f92");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationssAppService.DeleteAsync(Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"));

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == Guid.Parse("5c7012d9-716d-442d-ad79-ce1c0907b86d"));

            result.ShouldBeNull();
        }
    }
}