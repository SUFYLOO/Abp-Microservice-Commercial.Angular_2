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
            result.Items.Any(x => x.Id == Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3952d736-e13d-4130-8668-67ae52fa4183")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationssAppService.GetAsync(Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCreateDto
            {
                CompanyMainId = Guid.Parse("b48201d1-b3e8-44fa-be47-c4e00d80fd08"),
                CompanyJobId = Guid.Parse("0cdba553-aec5-4fb0-b197-2369c963633d"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("a22699a9-50d1-47b7-8c29-577418bc1c28"),
                UserMainName = "b3ef1c03748d4f15930a1910238923f7eb0a2455ee8142aab9",
                UserMainLoginMobilePhone = "9b3059b01bc144a5b303dc744489d7d6b256ea1f425242f1a3",
                UserMainLoginEmail = "9522f90b4b884dcca1e8112855c08206276aefd283b84fabbfa10f099d2c320daec131c8cf1f4dc48c139736e05f7cb8a8a73006c104492d99aa0ef9d48b1d250a4882cc580046bdb8efdea98534475ce57f486a79cb49bcbc7417ca135773104c914c3f",
                UserMainLoginIdentityNo = "7649ac08df684e42879295ccea902ee21bffcba29b5346569a",
                SendTypeCode = "018a05c05ff04850880d4d85315644cf176ec1f56bcc49cca9",
                SendStatusCode = "64662d870b9640879f9790a933909cc805b362bc2cfc4aadbe",
                ResumeFlowStageCode = "3c8f18f5ed7946de8477d05b0398fa0634eda97c2c8444fcb3",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("c9b22c1d-b45a-4464-8d00-28c19ee7ea7f"),
                ResumeSnapshotId = Guid.Parse("e6d4a218-cde9-4ffa-817a-5012bb6282b8"),
                ExtendedInformation = "2cb44d946b164fc692719a0dc4279c5819571b38dad145ae958afefa6bc6f096252b79e7e9d24b0c9b18e975d1e94b36ecf5f493c28943aea504cd25c5134bb6fbc69cd41e8348e5bf5e7f4d0cb16ca97ac0727279544012996c904ae121e1615be93eef7de54a2f8d41dc6e2bf77b3c465f5418a3964b3e979cfad4c14ec719237a5cd35426456fa305679b0932e5ae3ca0919bacfe46bf89b14013f32e4c9e3278b1f3a2974a3db0163d2a6d83fc25bd685e85ca3a447eab419c8151ed00523f58dc42889944e3b785707ddf737b0ffcd23b53a58548659d93298eaa6a4b33d50946d1ec5548529af77769b5c123c1f09881a814bd45f39871",
                DateA = new DateTime(2021, 2, 16),
                DateD = new DateTime(2016, 2, 12),
                Sort = 1908422476,
                Note = "16607e0ec4de4fc798b7279d986a6f1af0d561c68e894bd3a1ba3990c1ac3f61f3ea65b482c84da4ab4cbd2d7b08de91200ce4727fb64dc898449c447e39996987b4bec6a1fe4868b00d2e40685a3a5d490eeb9c8fa94e899ec38a615ced555016350a8df889412fafb3a2f88e562c17aaa3dedb189b4971a7cfcc32e7b04c3024ec8407382240c29cbeff8656889d545084e818025a4710aa2b8c928854c12334170cbc490844b5bbd6ab41a8a89a756c5cd90c3f42474980b776ce8b5370300f38c5d25fa241a889a176d5481864a16452177d099c4d3a8e3a8137eac753373dc5898413a142c080e02b358c6657574cbe351150e74dd6b939",
                Status = "10bb07a6f3294704965af64632ead1ac66276dc1bc7440b588"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("b48201d1-b3e8-44fa-be47-c4e00d80fd08"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0cdba553-aec5-4fb0-b197-2369c963633d"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("a22699a9-50d1-47b7-8c29-577418bc1c28"));
            result.UserMainName.ShouldBe("b3ef1c03748d4f15930a1910238923f7eb0a2455ee8142aab9");
            result.UserMainLoginMobilePhone.ShouldBe("9b3059b01bc144a5b303dc744489d7d6b256ea1f425242f1a3");
            result.UserMainLoginEmail.ShouldBe("9522f90b4b884dcca1e8112855c08206276aefd283b84fabbfa10f099d2c320daec131c8cf1f4dc48c139736e05f7cb8a8a73006c104492d99aa0ef9d48b1d250a4882cc580046bdb8efdea98534475ce57f486a79cb49bcbc7417ca135773104c914c3f");
            result.UserMainLoginIdentityNo.ShouldBe("7649ac08df684e42879295ccea902ee21bffcba29b5346569a");
            result.SendTypeCode.ShouldBe("018a05c05ff04850880d4d85315644cf176ec1f56bcc49cca9");
            result.SendStatusCode.ShouldBe("64662d870b9640879f9790a933909cc805b362bc2cfc4aadbe");
            result.ResumeFlowStageCode.ShouldBe("3c8f18f5ed7946de8477d05b0398fa0634eda97c2c8444fcb3");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("c9b22c1d-b45a-4464-8d00-28c19ee7ea7f"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("e6d4a218-cde9-4ffa-817a-5012bb6282b8"));
            result.ExtendedInformation.ShouldBe("2cb44d946b164fc692719a0dc4279c5819571b38dad145ae958afefa6bc6f096252b79e7e9d24b0c9b18e975d1e94b36ecf5f493c28943aea504cd25c5134bb6fbc69cd41e8348e5bf5e7f4d0cb16ca97ac0727279544012996c904ae121e1615be93eef7de54a2f8d41dc6e2bf77b3c465f5418a3964b3e979cfad4c14ec719237a5cd35426456fa305679b0932e5ae3ca0919bacfe46bf89b14013f32e4c9e3278b1f3a2974a3db0163d2a6d83fc25bd685e85ca3a447eab419c8151ed00523f58dc42889944e3b785707ddf737b0ffcd23b53a58548659d93298eaa6a4b33d50946d1ec5548529af77769b5c123c1f09881a814bd45f39871");
            result.DateA.ShouldBe(new DateTime(2021, 2, 16));
            result.DateD.ShouldBe(new DateTime(2016, 2, 12));
            result.Sort.ShouldBe(1908422476);
            result.Note.ShouldBe("16607e0ec4de4fc798b7279d986a6f1af0d561c68e894bd3a1ba3990c1ac3f61f3ea65b482c84da4ab4cbd2d7b08de91200ce4727fb64dc898449c447e39996987b4bec6a1fe4868b00d2e40685a3a5d490eeb9c8fa94e899ec38a615ced555016350a8df889412fafb3a2f88e562c17aaa3dedb189b4971a7cfcc32e7b04c3024ec8407382240c29cbeff8656889d545084e818025a4710aa2b8c928854c12334170cbc490844b5bbd6ab41a8a89a756c5cd90c3f42474980b776ce8b5370300f38c5d25fa241a889a176d5481864a16452177d099c4d3a8e3a8137eac753373dc5898413a142c080e02b358c6657574cbe351150e74dd6b939");
            result.Status.ShouldBe("10bb07a6f3294704965af64632ead1ac66276dc1bc7440b588");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsUpdateDto()
            {
                CompanyMainId = Guid.Parse("492b1b97-bf69-4b4a-8f18-bc756b86f870"),
                CompanyJobId = Guid.Parse("8a3ec952-927e-45ad-af14-6534dbdde23b"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("8a2b0dfe-3b19-4a5e-915c-082f85758e47"),
                UserMainName = "fc6b6264bbb443cd83de0c56e72f93b978fcbfeed0944bb895",
                UserMainLoginMobilePhone = "255ebf125e0d4659ab254c287a7ef0a9a8f6429aedf043c591",
                UserMainLoginEmail = "d2eb9bccbf5d41f4b45ea3eaab90526ff66c92251a6b4c439d13430d71afdc6c155c9115031b4469a19dae32efe1453151871625693345a79e1809c27e7f89dae07cbdc53deb4a2799426dc3e2fd1ea02abd17f4c9c94138bf5b37254aa4e7cd09d18007",
                UserMainLoginIdentityNo = "d0c3c434a3b64b34901fe70f01fee1cd4061cca8a0fb4311b7",
                SendTypeCode = "ec029e36f5a04853b8cb8b9fd5a9413e41fc359d59ba475386",
                SendStatusCode = "90d9a24b03a34c9497a8a524f05cc250e47273ca1c0f456cb4",
                ResumeFlowStageCode = "94e78292d3f14b1ea26c795a06fd016c3c79a50ea4734779a4",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("e4987045-b061-4eab-8de9-978a0af16ce7"),
                ResumeSnapshotId = Guid.Parse("3e88d261-470a-432c-8b8e-469e2297af0b"),
                ExtendedInformation = "ace6d242d77b4f92b724ef6a6e0d00a78f4ea11702e34c518b750621d2be3937cbbeaeba7a034eb69c1f0dd0e2f5df6122135f400d54437b920a23d1bbad15c45be4ab0db93540e69e4452379f0c54aa35cd3f439a7346c4a9544a188ccfa0ee4569c0e68fe045aba9a76bff0cbe4ebce99ca8eef14a4d8499e0e1a6d45afe814c074ed7177046a6989b5044af88e52929e54cfbfb924567b9060ffe1dd88088ac528718be0546a9a0328e72e83f823b846adc275c424192ad8c3327292542f72de21ab6e4124cd885fb7f5f2e8064676d8380f381b7459c9e2c830171917b4655de4815c5264bb0843f5a45621b577e67c2b3c7b02e4b40b1f6",
                DateA = new DateTime(2014, 8, 7),
                DateD = new DateTime(2018, 4, 27),
                Sort = 2005989446,
                Note = "c046f7280e2149218f29cca5527026bff7610e0f64814f4a906db9150a4530b29583206d780f479195020fbbde66e7c1fa5b39ea827342aea47df91604ebbab60803658a10394f588a2786886b31a6023d94494b28e34510ab97e425a43cdae41e27ff68fa18401c8615c618df7a449d1c77a1630b22437ca6c28df91b122c441f0f81e3b4114e70afbaaeef3419b8f7e879cb50c37e4aca9cfb9eb48b9396f880792eb1a904461fa6e8a522575fedf0fa967d7ddec342c7abb0bb99b0ae1153c82f26178771472f8c603132a6c8d3cb2923b847976c41cb91c079882adc825b21bed2128b6e433e9faa66b0393828e9bfb7369a6b0b418f999c",
                Status = "1132996a44b24db69d964fc5420c4c4e7c2b53fdaa4940b29c"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.UpdateAsync(Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"), input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("492b1b97-bf69-4b4a-8f18-bc756b86f870"));
            result.CompanyJobId.ShouldBe(Guid.Parse("8a3ec952-927e-45ad-af14-6534dbdde23b"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("8a2b0dfe-3b19-4a5e-915c-082f85758e47"));
            result.UserMainName.ShouldBe("fc6b6264bbb443cd83de0c56e72f93b978fcbfeed0944bb895");
            result.UserMainLoginMobilePhone.ShouldBe("255ebf125e0d4659ab254c287a7ef0a9a8f6429aedf043c591");
            result.UserMainLoginEmail.ShouldBe("d2eb9bccbf5d41f4b45ea3eaab90526ff66c92251a6b4c439d13430d71afdc6c155c9115031b4469a19dae32efe1453151871625693345a79e1809c27e7f89dae07cbdc53deb4a2799426dc3e2fd1ea02abd17f4c9c94138bf5b37254aa4e7cd09d18007");
            result.UserMainLoginIdentityNo.ShouldBe("d0c3c434a3b64b34901fe70f01fee1cd4061cca8a0fb4311b7");
            result.SendTypeCode.ShouldBe("ec029e36f5a04853b8cb8b9fd5a9413e41fc359d59ba475386");
            result.SendStatusCode.ShouldBe("90d9a24b03a34c9497a8a524f05cc250e47273ca1c0f456cb4");
            result.ResumeFlowStageCode.ShouldBe("94e78292d3f14b1ea26c795a06fd016c3c79a50ea4734779a4");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("e4987045-b061-4eab-8de9-978a0af16ce7"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("3e88d261-470a-432c-8b8e-469e2297af0b"));
            result.ExtendedInformation.ShouldBe("ace6d242d77b4f92b724ef6a6e0d00a78f4ea11702e34c518b750621d2be3937cbbeaeba7a034eb69c1f0dd0e2f5df6122135f400d54437b920a23d1bbad15c45be4ab0db93540e69e4452379f0c54aa35cd3f439a7346c4a9544a188ccfa0ee4569c0e68fe045aba9a76bff0cbe4ebce99ca8eef14a4d8499e0e1a6d45afe814c074ed7177046a6989b5044af88e52929e54cfbfb924567b9060ffe1dd88088ac528718be0546a9a0328e72e83f823b846adc275c424192ad8c3327292542f72de21ab6e4124cd885fb7f5f2e8064676d8380f381b7459c9e2c830171917b4655de4815c5264bb0843f5a45621b577e67c2b3c7b02e4b40b1f6");
            result.DateA.ShouldBe(new DateTime(2014, 8, 7));
            result.DateD.ShouldBe(new DateTime(2018, 4, 27));
            result.Sort.ShouldBe(2005989446);
            result.Note.ShouldBe("c046f7280e2149218f29cca5527026bff7610e0f64814f4a906db9150a4530b29583206d780f479195020fbbde66e7c1fa5b39ea827342aea47df91604ebbab60803658a10394f588a2786886b31a6023d94494b28e34510ab97e425a43cdae41e27ff68fa18401c8615c618df7a449d1c77a1630b22437ca6c28df91b122c441f0f81e3b4114e70afbaaeef3419b8f7e879cb50c37e4aca9cfb9eb48b9396f880792eb1a904461fa6e8a522575fedf0fa967d7ddec342c7abb0bb99b0ae1153c82f26178771472f8c603132a6c8d3cb2923b847976c41cb91c079882adc825b21bed2128b6e433e9faa66b0393828e9bfb7369a6b0b418f999c");
            result.Status.ShouldBe("1132996a44b24db69d964fc5420c4c4e7c2b53fdaa4940b29c");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationssAppService.DeleteAsync(Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"));

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == Guid.Parse("ba64d3f7-e6dd-43bd-9808-3477e19f7f1d"));

            result.ShouldBeNull();
        }
    }
}