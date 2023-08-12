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
            result.Items.Any(x => x.Id == Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("7f6dfbf2-c1bb-4824-8f7f-c1987229524f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyBindsAppService.GetAsync(Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyBindCreateDto
            {
                UserMainId = Guid.Parse("a5ff646b-4cad-426a-993d-392b97413c21"),
                CompanyMainId = Guid.Parse("a3ee8b8f-1072-4278-9bcb-6bc5021921c4"),
                CompanyJobId = Guid.Parse("1c1cf91b-a9e7-4088-9463-aa178183cd13"),
                CompanyInvitationsId = Guid.Parse("27269ec0-a433-4826-bdd5-4f144e505344"),
                ExtendedInformation = "86e5d2da60564edf89c5c5593131b194a9851dfa406149f3a72d37ffec1492654aadc342c4eb4cfc9f6496770a508c94fbdb015b99af46a59aea0d9785a8421ae5b2902814634b6387da28674946df56ac7aea19d10f4fe8a4ccdc81fbf15e36355250aca8f6461395ec646cd108a9ccbbe3439bfe27408ea62fbcd5f81d229fec649049a7ab4174a2c5fadc693e00a42e1ffc69ec2d4cdd96217eef118f5e8aea6665a2a8f4418baee246420c9f6eb9f46c3e5e16c049bf8e92d7dd8501e9977fe1e5f34a90456a86c4be963d94c96a8656c83cb2ff46c49bcf6c0a9c9f931fe250cd2898a04b238e557b188f7471ae7c368435028042ceb3d7",
                DateA = new DateTime(2019, 7, 20),
                DateD = new DateTime(2000, 11, 5),
                Sort = 1143303162,
                Note = "8b409b68389e490eb8dc945acf8e2d9c2209c752f97348ca84c372c17b4db2c128af39410875442f99116fc5b52efab93969b2a6a68041388ccb1d0681020c89b9c6917f1e764ca9b187058bc8974fb2e7bc802982b9491993071112b64e40f9b11982c97bf84661842583f4ec75d2e3d8bc4493278c486596605ca307a2200e1ac31450c25b4d9d9b44a9fa5a60a305da6b8806a13a4b4ebca9c9bd667737d4e4814aab556c4acc8df642626d6256ef4a13b27a82424a04a1580e591da1805c08ddd08519a94aa3bbd9b3b40e667c2555b8fa89019940f8aa811a31b45bacfc87e2b7217e5d4d4db0de5c08fe8295ac6a18f5eb6a514cf8852c",
                Status = "2ef548e6aee146a592496ea765c98173bf3579d096814c79bc"
            };

            // Act
            var serviceResult = await _userCompanyBindsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("a5ff646b-4cad-426a-993d-392b97413c21"));
            result.CompanyMainId.ShouldBe(Guid.Parse("a3ee8b8f-1072-4278-9bcb-6bc5021921c4"));
            result.CompanyJobId.ShouldBe(Guid.Parse("1c1cf91b-a9e7-4088-9463-aa178183cd13"));
            result.CompanyInvitationsId.ShouldBe(Guid.Parse("27269ec0-a433-4826-bdd5-4f144e505344"));
            result.ExtendedInformation.ShouldBe("86e5d2da60564edf89c5c5593131b194a9851dfa406149f3a72d37ffec1492654aadc342c4eb4cfc9f6496770a508c94fbdb015b99af46a59aea0d9785a8421ae5b2902814634b6387da28674946df56ac7aea19d10f4fe8a4ccdc81fbf15e36355250aca8f6461395ec646cd108a9ccbbe3439bfe27408ea62fbcd5f81d229fec649049a7ab4174a2c5fadc693e00a42e1ffc69ec2d4cdd96217eef118f5e8aea6665a2a8f4418baee246420c9f6eb9f46c3e5e16c049bf8e92d7dd8501e9977fe1e5f34a90456a86c4be963d94c96a8656c83cb2ff46c49bcf6c0a9c9f931fe250cd2898a04b238e557b188f7471ae7c368435028042ceb3d7");
            result.DateA.ShouldBe(new DateTime(2019, 7, 20));
            result.DateD.ShouldBe(new DateTime(2000, 11, 5));
            result.Sort.ShouldBe(1143303162);
            result.Note.ShouldBe("8b409b68389e490eb8dc945acf8e2d9c2209c752f97348ca84c372c17b4db2c128af39410875442f99116fc5b52efab93969b2a6a68041388ccb1d0681020c89b9c6917f1e764ca9b187058bc8974fb2e7bc802982b9491993071112b64e40f9b11982c97bf84661842583f4ec75d2e3d8bc4493278c486596605ca307a2200e1ac31450c25b4d9d9b44a9fa5a60a305da6b8806a13a4b4ebca9c9bd667737d4e4814aab556c4acc8df642626d6256ef4a13b27a82424a04a1580e591da1805c08ddd08519a94aa3bbd9b3b40e667c2555b8fa89019940f8aa811a31b45bacfc87e2b7217e5d4d4db0de5c08fe8295ac6a18f5eb6a514cf8852c");
            result.Status.ShouldBe("2ef548e6aee146a592496ea765c98173bf3579d096814c79bc");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyBindUpdateDto()
            {
                UserMainId = Guid.Parse("c22b8c34-f0a4-4476-86f5-a309f326687a"),
                CompanyMainId = Guid.Parse("7cc5ac57-125d-4ff7-beff-935bd36bd8e8"),
                CompanyJobId = Guid.Parse("7a32a61d-90a9-42e8-9656-10cd098ae25d"),
                CompanyInvitationsId = Guid.Parse("be5a71a5-2b2f-46b4-a3e9-a312d40293cd"),
                ExtendedInformation = "33a677567a7a485fbba31f2bd0c32dea7dde530457c645ad919af170f438a37a87e3711dbaf148b39047d1b39a13d70fae5351c5a9fc4c779f3fe0470fdfe3e59b747f4d16f74fd8a96201ac8d2bfa3717a1168de3f64bd8959130e6b0cc60ee7ca0a3959d474d008339c018b31e456e836fbd4f180f49238c4442d34a23bff45d4e9557045f4a65a54e101fcd740e91d34522a2476b4ac89a64d4532a4f5b1fd69c94fd29174db7ac53353cee88033a181db3f30923432394159ebb6d67a7f53ec6d2d673d24686aefc2e71b3e864b0eefcb58af03d499684e379f29c897d4a9c56b157f30f4e72892331903b1c728ee9ab00305a054be08ab5",
                DateA = new DateTime(2018, 3, 27),
                DateD = new DateTime(2017, 1, 26),
                Sort = 830798950,
                Note = "b5ecefa5992f4404a94b807ea036b128f007e9d3d7dd434b9d2f43abfde4ef011ad024869d6f4b85af9877494969da2931ebd02d7fb7475ab686c4bcb8bd6e668be87b2878de4fafbbb79c017f8edffe66d2341cce5a4b69b137856dee6efcefac8dbfdf143b43ecb6d8e4bd8595b716d8e134813fbd4b3499d1dc667aa1aa56758ec2fad7b340b8a8e7e43383600848ef7bb91910674ab19fbeb791c780addc85a86fe9f2dd46e595722a132f59923d93a20ac1190c4b30bea778912edcd4d206cfc78f04df4da89d54a689dc011655463ebd55eaa64a87a17186dfad3b45c6337b46d2a1944e19b1934c0db1034b18b3b0851e063c4ccc885f",
                Status = "113a403bc99d4ffa8e6ee718531826480ad0bd9413af43a79a"
            };

            // Act
            var serviceResult = await _userCompanyBindsAppService.UpdateAsync(Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"), input);

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("c22b8c34-f0a4-4476-86f5-a309f326687a"));
            result.CompanyMainId.ShouldBe(Guid.Parse("7cc5ac57-125d-4ff7-beff-935bd36bd8e8"));
            result.CompanyJobId.ShouldBe(Guid.Parse("7a32a61d-90a9-42e8-9656-10cd098ae25d"));
            result.CompanyInvitationsId.ShouldBe(Guid.Parse("be5a71a5-2b2f-46b4-a3e9-a312d40293cd"));
            result.ExtendedInformation.ShouldBe("33a677567a7a485fbba31f2bd0c32dea7dde530457c645ad919af170f438a37a87e3711dbaf148b39047d1b39a13d70fae5351c5a9fc4c779f3fe0470fdfe3e59b747f4d16f74fd8a96201ac8d2bfa3717a1168de3f64bd8959130e6b0cc60ee7ca0a3959d474d008339c018b31e456e836fbd4f180f49238c4442d34a23bff45d4e9557045f4a65a54e101fcd740e91d34522a2476b4ac89a64d4532a4f5b1fd69c94fd29174db7ac53353cee88033a181db3f30923432394159ebb6d67a7f53ec6d2d673d24686aefc2e71b3e864b0eefcb58af03d499684e379f29c897d4a9c56b157f30f4e72892331903b1c728ee9ab00305a054be08ab5");
            result.DateA.ShouldBe(new DateTime(2018, 3, 27));
            result.DateD.ShouldBe(new DateTime(2017, 1, 26));
            result.Sort.ShouldBe(830798950);
            result.Note.ShouldBe("b5ecefa5992f4404a94b807ea036b128f007e9d3d7dd434b9d2f43abfde4ef011ad024869d6f4b85af9877494969da2931ebd02d7fb7475ab686c4bcb8bd6e668be87b2878de4fafbbb79c017f8edffe66d2341cce5a4b69b137856dee6efcefac8dbfdf143b43ecb6d8e4bd8595b716d8e134813fbd4b3499d1dc667aa1aa56758ec2fad7b340b8a8e7e43383600848ef7bb91910674ab19fbeb791c780addc85a86fe9f2dd46e595722a132f59923d93a20ac1190c4b30bea778912edcd4d206cfc78f04df4da89d54a689dc011655463ebd55eaa64a87a17186dfad3b45c6337b46d2a1944e19b1934c0db1034b18b3b0851e063c4ccc885f");
            result.Status.ShouldBe("113a403bc99d4ffa8e6ee718531826480ad0bd9413af43a79a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyBindsAppService.DeleteAsync(Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"));

            // Assert
            var result = await _userCompanyBindRepository.FindAsync(c => c.Id == Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"));

            result.ShouldBeNull();
        }
    }
}