using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyBindsAppService _userCompanyBindsAppService;
        private readonly IRepository<UserCompanyBind, Guid> _userCompanyBindRepository;

        public UserCompanyBindsAppServiceTests()
        {
            _userCompanyBindsAppService = GetRequiredService<IUserCompanyBindsAppService>();
            _userCompanyBindRepository = GetRequiredService<IRepository<UserCompanyBind, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyBindsAppService.GetListAsync(new GetUserCompanyBindsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("72bfba03-d94e-4542-9b44-b9481a7e8a5d")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyBindsAppService.GetAsync(Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyBindCreateDto
            {
                UserMainId = Guid.Parse("26d38346-57dc-4e8b-980a-e2eec9e4c46c"),
                CompanyMainId = Guid.Parse("952c978c-62d5-4c97-b0b1-53adccb60acb"),
                CompanyJobId = Guid.Parse("01894fa1-763a-4ed3-a5fb-e821331056c5"),
                CompanyInvitationsId = Guid.Parse("9718c1cd-f7f2-476f-bd87-fa753ed8289c"),
                ExtendedInformation = "6d0d4a79de9842669e1204c65a4b921206259882109142c4bdec72c0e1917e2c61b39f8ace2848089c0f0c7244bcee971969cba4831e4f38bf03696a549c612033009b41544e4f7b883ff0e9d86882caccb9b3fe5f67424093bde26901907247a20e060b020e4fbfa562a740c883f1eadc5681a42879483f9dc1a4b4205a1fd0cd39f0eb4c4c4c00a43bf4d4a9d5ee43d5b44a4d976d48febebca6fb0358e03a47fdc582bd50483f8d43e42486f8b95ce19b169259694fa19484bd712762f51c35a25ece7b234de18a5a55111cb7d3fcc41f7d75e2874b5bacb2f8a60b58658fc738de9c240d4120bb6dcd7c04912c76f2bfaabafb4f40878a34",
                DateA = new DateTime(2019, 1, 12),
                DateD = new DateTime(2003, 7, 5),
                Sort = 823951993,
                Note = "021fdd1659cf48198180f7e6c704262218f1d574e1c34ca68d10010a949c987a22a92b8f248d4aef93b88c3b376d645e927e8b054cb04240a03a2208a74be6466beec8d87d6942b28b8d2d3421e625c2eb27f0ee9f944a86a450ed86db4f8f6be7013a2d34c2493b81f18b2824fcaadccb0530f0e956410aa79d313670e1d9ec7f6e5927b1364718a6ba51a9b46976aeb45a1082d80b41d4b50a802c138a0378524bae8b1c794db2a2b3667483922a0410fa1a50790d4326865a4fcec924b6481e73b252b6524d95a9d788c8dbe2809cc01ecfc9cb5a4a04ab13bd1253b2d545ca8b8f6ed29945afb776404900d13a3fc7e46af6a7b2495faa31",
                Status = "f7bc2a43cd114279ac2f0a12506a5d76c4490ed2772c460fb3"
            };

            // Act
            var serviceResult = await _userCompanyBindsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("26d38346-57dc-4e8b-980a-e2eec9e4c46c"));
            result.CompanyMainId.ShouldBe(Guid.Parse("952c978c-62d5-4c97-b0b1-53adccb60acb"));
            result.CompanyJobId.ShouldBe(Guid.Parse("01894fa1-763a-4ed3-a5fb-e821331056c5"));
            result.CompanyInvitationsId.ShouldBe(Guid.Parse("9718c1cd-f7f2-476f-bd87-fa753ed8289c"));
            result.ExtendedInformation.ShouldBe("6d0d4a79de9842669e1204c65a4b921206259882109142c4bdec72c0e1917e2c61b39f8ace2848089c0f0c7244bcee971969cba4831e4f38bf03696a549c612033009b41544e4f7b883ff0e9d86882caccb9b3fe5f67424093bde26901907247a20e060b020e4fbfa562a740c883f1eadc5681a42879483f9dc1a4b4205a1fd0cd39f0eb4c4c4c00a43bf4d4a9d5ee43d5b44a4d976d48febebca6fb0358e03a47fdc582bd50483f8d43e42486f8b95ce19b169259694fa19484bd712762f51c35a25ece7b234de18a5a55111cb7d3fcc41f7d75e2874b5bacb2f8a60b58658fc738de9c240d4120bb6dcd7c04912c76f2bfaabafb4f40878a34");
            result.DateA.ShouldBe(new DateTime(2019, 1, 12));
            result.DateD.ShouldBe(new DateTime(2003, 7, 5));
            result.Sort.ShouldBe(823951993);
            result.Note.ShouldBe("021fdd1659cf48198180f7e6c704262218f1d574e1c34ca68d10010a949c987a22a92b8f248d4aef93b88c3b376d645e927e8b054cb04240a03a2208a74be6466beec8d87d6942b28b8d2d3421e625c2eb27f0ee9f944a86a450ed86db4f8f6be7013a2d34c2493b81f18b2824fcaadccb0530f0e956410aa79d313670e1d9ec7f6e5927b1364718a6ba51a9b46976aeb45a1082d80b41d4b50a802c138a0378524bae8b1c794db2a2b3667483922a0410fa1a50790d4326865a4fcec924b6481e73b252b6524d95a9d788c8dbe2809cc01ecfc9cb5a4a04ab13bd1253b2d545ca8b8f6ed29945afb776404900d13a3fc7e46af6a7b2495faa31");
            result.Status.ShouldBe("f7bc2a43cd114279ac2f0a12506a5d76c4490ed2772c460fb3");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyBindUpdateDto()
            {
                UserMainId = Guid.Parse("9c15f3de-1c9b-4584-95f5-b2ebee60cc2b"),
                CompanyMainId = Guid.Parse("9ac9fcf1-8b1e-4ea7-98ed-4bfc01f993b4"),
                CompanyJobId = Guid.Parse("95c9d645-bfb9-4e05-bcba-86a562302a47"),
                CompanyInvitationsId = Guid.Parse("1a725bd1-4106-45ce-bede-01613a4863ea"),
                ExtendedInformation = "ac1fac2c37a548738c5584703a6f170916a0bf2b9e25454bb6d0ededccbb87ab0168833f175e48208e1b94652683a5f82a7239df0e844d00b53103008cbb7fa935b6f2f2c5da47fda521e0fac545a9699390031239144b50bdf4b9ed308ced259903c6f7ec7f4a4eacca252d0d9195dea41bf5c802d7418199065a19a70e99b02dcd8d217ece44e3ad4729247d383eaf42160ffcbf0141758b57b403ff8df5d32ab6b7e9a29446288300118dc612b8f156f2ebc44d8d44948ceb692a4dfab84cb53c2afd86de4a45977391a87fd89b00503d164a14584764be6790207ffddc125c93e5cb93c04dc7a989ad6614dbce3d7c1cfb8f2a2b49039b4a",
                DateA = new DateTime(2019, 8, 2),
                DateD = new DateTime(2009, 8, 1),
                Sort = 2074908005,
                Note = "948893ea3a79478aa42471946a2acbee8c927d15103746b6a4dd3485a77d469b27a40f1b3838436ea6615940e54509bb49a9860cc9e94982abcb569af88a9a795e6b104426c54bf48cf8dba7a9ee95b8ad30f763454946fb9ab9c9c0340e41ec383a252becaf48e4804c38f612ebbd944d7aa03896d64546a13d3cfa48aa6a5885275e1dc1714a68b370ad4363e30a2e3a4225a2c7484b49a277b96e071f3abe841b470040f34d1280f91b2a34acfe70eebfac097a034926a7b4948c2250cf0fd9f49ce7ffbb412e9971e75d8329dcd47a02af22b67f4631bc8db7a05eb533fda1825b3247814497a996b529b16b01fd6e14fa44b24b4eed879d",
                Status = "66158d8b41c6417ea4c560177423884bdbefd97770cc4fc1aa"
            };

            // Act
            var serviceResult = await _userCompanyBindsAppService.UpdateAsync(Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"), input);

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("9c15f3de-1c9b-4584-95f5-b2ebee60cc2b"));
            result.CompanyMainId.ShouldBe(Guid.Parse("9ac9fcf1-8b1e-4ea7-98ed-4bfc01f993b4"));
            result.CompanyJobId.ShouldBe(Guid.Parse("95c9d645-bfb9-4e05-bcba-86a562302a47"));
            result.CompanyInvitationsId.ShouldBe(Guid.Parse("1a725bd1-4106-45ce-bede-01613a4863ea"));
            result.ExtendedInformation.ShouldBe("ac1fac2c37a548738c5584703a6f170916a0bf2b9e25454bb6d0ededccbb87ab0168833f175e48208e1b94652683a5f82a7239df0e844d00b53103008cbb7fa935b6f2f2c5da47fda521e0fac545a9699390031239144b50bdf4b9ed308ced259903c6f7ec7f4a4eacca252d0d9195dea41bf5c802d7418199065a19a70e99b02dcd8d217ece44e3ad4729247d383eaf42160ffcbf0141758b57b403ff8df5d32ab6b7e9a29446288300118dc612b8f156f2ebc44d8d44948ceb692a4dfab84cb53c2afd86de4a45977391a87fd89b00503d164a14584764be6790207ffddc125c93e5cb93c04dc7a989ad6614dbce3d7c1cfb8f2a2b49039b4a");
            result.DateA.ShouldBe(new DateTime(2019, 8, 2));
            result.DateD.ShouldBe(new DateTime(2009, 8, 1));
            result.Sort.ShouldBe(2074908005);
            result.Note.ShouldBe("948893ea3a79478aa42471946a2acbee8c927d15103746b6a4dd3485a77d469b27a40f1b3838436ea6615940e54509bb49a9860cc9e94982abcb569af88a9a795e6b104426c54bf48cf8dba7a9ee95b8ad30f763454946fb9ab9c9c0340e41ec383a252becaf48e4804c38f612ebbd944d7aa03896d64546a13d3cfa48aa6a5885275e1dc1714a68b370ad4363e30a2e3a4225a2c7484b49a277b96e071f3abe841b470040f34d1280f91b2a34acfe70eebfac097a034926a7b4948c2250cf0fd9f49ce7ffbb412e9971e75d8329dcd47a02af22b67f4631bc8db7a05eb533fda1825b3247814497a996b529b16b01fd6e14fa44b24b4eed879d");
            result.Status.ShouldBe("66158d8b41c6417ea4c560177423884bdbefd97770cc4fc1aa");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyBindsAppService.DeleteAsync(Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"));

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"));

            result.ShouldBeNull();
        }
    }
}