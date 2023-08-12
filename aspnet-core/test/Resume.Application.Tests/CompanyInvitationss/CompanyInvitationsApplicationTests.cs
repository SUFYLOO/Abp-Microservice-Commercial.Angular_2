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
            result.Items.Any(x => x.Id == Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2498b276-4509-42c2-9eac-d3defd3d2d4a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationssAppService.GetAsync(Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCreateDto
            {
                CompanyMainId = Guid.Parse("517e1773-0425-4388-8629-73e492985489"),
                CompanyJobId = Guid.Parse("68afb100-fbb2-4662-bde2-15dc96998cb3"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("c7df1a66-760d-43f2-a0cd-fd4b754e0fa8"),
                UserMainName = "9c3feed8b17c4f00b932fd9ebf763b87198e7d67d30e4ea1a3",
                UserMainLoginMobilePhone = "9ebe39f599a54d7699330f9d258127e7ba6d9de5e118459bac",
                UserMainLoginEmail = "5f3094ddf6d14d59b86eeded6d49c31c31a7f394011f4cc19d3a82e5574e66ada9b56d757b69472d82fa99b058bdfd9fa12bc6a279004544960034872b7fbfd9d36697e61e9240d1977b6b94a664f65ee5fb0f45f5db4f95a1fa3cc349ef362428c0ea69",
                UserMainLoginIdentityNo = "6b062b601ad340a5bacda3e799726eceabc05a0ab23a409eaa",
                SendTypeCode = "451d863b69cb4c7ca98a3e3d0970a01fdca7575ec03a487ba0",
                SendStatusCode = "0e432927bb5147afabc2c9f4329d203a3edf25987f184007ac",
                ResumeFlowStageCode = "d1683896a0ae4fdeb9655b1233aed4e844d534da4f20424993",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("11a116e8-9bf3-4fd9-b1d5-0615d634068d"),
                ResumeSnapshotId = Guid.Parse("6b7e934b-3585-4e3b-a99c-9786ab2456bf"),
                ExtendedInformation = "0f1142ebbfc24f7bbef58c1fa17f75ae3f1a6168f2e94871860da7b8bc25ee48aafbdd63ecf24c638434c545071e992fde4820dbda9345ec829ae92d5f7af6d60e8851a84ad84503a217c140a28dc43973e84144201a429998dfc060ae30690e675c284477a94c18b81fd948f374d09416922463c77445fcb4693c22c93d81260664d3e7d00f4987868ca00aff6a50bfcf244ee7c874490882c63f676c12b2c5f48dccb711de4698a5bb7c7500b3a2d7df179ffa6d594e29a09ebe76ec0398ccd643198fa033480c80c80e30ec27b96d69cf5212feb643909cf769147c3967e197165c02aeda410b9706d88a88a201b17f97914feffb43cc9702",
                DateA = new DateTime(2020, 8, 26),
                DateD = new DateTime(2006, 7, 7),
                Sort = 431793906,
                Note = "723ba671a84a4953b46319fbd19c5a5547361805d22541c395fdb116da7ab199957f9e96305d4a43918c0bb5436d818d45f339a69bf54f089c539cdb3f483b6bb01c903fd97b4cc5bc4b1d7ee691dc9b39d33a402a364876a156a2e4d2e30ca6b0cd35c154344d868fd6a9b8f3ae783283695def53964b818147564d85105a21a3d85761ceac48bda52503df7a013855cda5ef293a1a4be9923aa1454b936537b998d56d0bab4070911dba625dfe94e6f6724bc86bef43e4802474bb2f3114b1ce098a5efe6541af8d40b40887c133e8619b8df71399411988b1c49fddf791e06bab1e6fce2e48428f4d77a09ac43de6b2da21aa105b4280a23a",
                Status = "82dc0370886041b1b4743a078a8a13c2798a89e69d0d437b98"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("517e1773-0425-4388-8629-73e492985489"));
            result.CompanyJobId.ShouldBe(Guid.Parse("68afb100-fbb2-4662-bde2-15dc96998cb3"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("c7df1a66-760d-43f2-a0cd-fd4b754e0fa8"));
            result.UserMainName.ShouldBe("9c3feed8b17c4f00b932fd9ebf763b87198e7d67d30e4ea1a3");
            result.UserMainLoginMobilePhone.ShouldBe("9ebe39f599a54d7699330f9d258127e7ba6d9de5e118459bac");
            result.UserMainLoginEmail.ShouldBe("5f3094ddf6d14d59b86eeded6d49c31c31a7f394011f4cc19d3a82e5574e66ada9b56d757b69472d82fa99b058bdfd9fa12bc6a279004544960034872b7fbfd9d36697e61e9240d1977b6b94a664f65ee5fb0f45f5db4f95a1fa3cc349ef362428c0ea69");
            result.UserMainLoginIdentityNo.ShouldBe("6b062b601ad340a5bacda3e799726eceabc05a0ab23a409eaa");
            result.SendTypeCode.ShouldBe("451d863b69cb4c7ca98a3e3d0970a01fdca7575ec03a487ba0");
            result.SendStatusCode.ShouldBe("0e432927bb5147afabc2c9f4329d203a3edf25987f184007ac");
            result.ResumeFlowStageCode.ShouldBe("d1683896a0ae4fdeb9655b1233aed4e844d534da4f20424993");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("11a116e8-9bf3-4fd9-b1d5-0615d634068d"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("6b7e934b-3585-4e3b-a99c-9786ab2456bf"));
            result.ExtendedInformation.ShouldBe("0f1142ebbfc24f7bbef58c1fa17f75ae3f1a6168f2e94871860da7b8bc25ee48aafbdd63ecf24c638434c545071e992fde4820dbda9345ec829ae92d5f7af6d60e8851a84ad84503a217c140a28dc43973e84144201a429998dfc060ae30690e675c284477a94c18b81fd948f374d09416922463c77445fcb4693c22c93d81260664d3e7d00f4987868ca00aff6a50bfcf244ee7c874490882c63f676c12b2c5f48dccb711de4698a5bb7c7500b3a2d7df179ffa6d594e29a09ebe76ec0398ccd643198fa033480c80c80e30ec27b96d69cf5212feb643909cf769147c3967e197165c02aeda410b9706d88a88a201b17f97914feffb43cc9702");
            result.DateA.ShouldBe(new DateTime(2020, 8, 26));
            result.DateD.ShouldBe(new DateTime(2006, 7, 7));
            result.Sort.ShouldBe(431793906);
            result.Note.ShouldBe("723ba671a84a4953b46319fbd19c5a5547361805d22541c395fdb116da7ab199957f9e96305d4a43918c0bb5436d818d45f339a69bf54f089c539cdb3f483b6bb01c903fd97b4cc5bc4b1d7ee691dc9b39d33a402a364876a156a2e4d2e30ca6b0cd35c154344d868fd6a9b8f3ae783283695def53964b818147564d85105a21a3d85761ceac48bda52503df7a013855cda5ef293a1a4be9923aa1454b936537b998d56d0bab4070911dba625dfe94e6f6724bc86bef43e4802474bb2f3114b1ce098a5efe6541af8d40b40887c133e8619b8df71399411988b1c49fddf791e06bab1e6fce2e48428f4d77a09ac43de6b2da21aa105b4280a23a");
            result.Status.ShouldBe("82dc0370886041b1b4743a078a8a13c2798a89e69d0d437b98");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsUpdateDto()
            {
                CompanyMainId = Guid.Parse("d3623fd9-6e46-42b1-bb54-6a6eb42090c8"),
                CompanyJobId = Guid.Parse("e7b68579-7736-4bc1-81fa-dd3c4baac753"),
                OpenAllJob = true,
                UserMainId = Guid.Parse("147e2435-4a4f-470a-a490-de139d7dfd64"),
                UserMainName = "01268e458a71423d8338c54c8aca1a0a89b2bfc4a3c9492d91",
                UserMainLoginMobilePhone = "ebd7497930ee45aa8af440788604ec5f800cafa5831343548d",
                UserMainLoginEmail = "203c24d39d0042c48988d882684c983d449455daa4344570a1beb615ea1eb38081cf86c7b3fd417e8d6cdb213892d2fa0d8c0ff0a89d41348b83b7b8ba9ce1973d2230a90fae4225a9f85e0d404fd8db8660c172cba54affb2ecdec0b2af901a27ae2255",
                UserMainLoginIdentityNo = "7b7fdce910964a059e1c90f8cfbe22bb9d498af7bed04b46be",
                SendTypeCode = "e6a3f8f081914f128a380f8b91cea54591c0f620460f4d43b8",
                SendStatusCode = "2002d651dea147bcb00814d7c44124232a61cd91bce142b6af",
                ResumeFlowStageCode = "237cdc24fe954c4f9dbc5793b20e1d3de1b2456b938f4c05b6",
                IsRead = true,
                UserCompanyBindId = Guid.Parse("78600c49-ee16-4791-acdd-2e9e789d1590"),
                ResumeSnapshotId = Guid.Parse("e48924ba-eaf7-4f43-86eb-1f6cf07bef45"),
                ExtendedInformation = "735892e4cc0f491eae7ff34fd606b56e5e37a0353d454112aeacd7b11df99a2ec1c7556358b54c5aa870207ac97c71c304a974d5ce5c4c84b639bde860644314af3dc57f0dcc48f4bbeee0ea7568544c379b0f83b7b24f638ffc6a975494ba57f084b05554e04e86a70938cb4c31bd003e27e5c7a24447789ce870c58f34141b3e26487acf6e48828472bbc3a9607671b08717fb8ea54a75ae0fc25abe930084e14f02858fac44bb9b4dd8d5d4e5f9fe32ac6ab5e3d848fa8786076466c7b08d4988a681d4ab4b76a42603030848a290828f9ca0d2214612857ae469d66ba16424c5f763276b40f7ad725fe33a7efbbec99ec5c5d906487b9e1d",
                DateA = new DateTime(2015, 11, 1),
                DateD = new DateTime(2009, 1, 6),
                Sort = 587876683,
                Note = "01aa260a7bd7408b85ced972f6c645fd1c71ff0f8be0459c9f344be45549675512e56a452b97418b94d0b41c34f6e572034a3e9ade614fc4a615984a1070fb8217176b1be694461fb236434c336c0329fba63b861c514a8db9e0d11979381074c7b262b3d9da4f53ae3096aba8c4db8e061e9132357d4d1786aca92a0702224a0fb5c2f6dd014ea1bac4e494aaa8282aeeabb2038c2546b1ba7f9fffffd26e94a798b55531f04a498e97e6acdfcf45f0304e1fcf1500418dad2006bbbb8bec80aeceaebe0bc147c2a1133f4f56eef9eccb64f8b2aa354f969230603f474dbc524c3646e0aa8548ef9d8aa0956cd28ed2da25085f23a941d4974a",
                Status = "16d08319539a4b62b53154b6297f073d029f6399382242d784"
            };

            // Act
            var serviceResult = await _companyInvitationssAppService.UpdateAsync(Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"), input);

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("d3623fd9-6e46-42b1-bb54-6a6eb42090c8"));
            result.CompanyJobId.ShouldBe(Guid.Parse("e7b68579-7736-4bc1-81fa-dd3c4baac753"));
            result.OpenAllJob.ShouldBe(true);
            result.UserMainId.ShouldBe(Guid.Parse("147e2435-4a4f-470a-a490-de139d7dfd64"));
            result.UserMainName.ShouldBe("01268e458a71423d8338c54c8aca1a0a89b2bfc4a3c9492d91");
            result.UserMainLoginMobilePhone.ShouldBe("ebd7497930ee45aa8af440788604ec5f800cafa5831343548d");
            result.UserMainLoginEmail.ShouldBe("203c24d39d0042c48988d882684c983d449455daa4344570a1beb615ea1eb38081cf86c7b3fd417e8d6cdb213892d2fa0d8c0ff0a89d41348b83b7b8ba9ce1973d2230a90fae4225a9f85e0d404fd8db8660c172cba54affb2ecdec0b2af901a27ae2255");
            result.UserMainLoginIdentityNo.ShouldBe("7b7fdce910964a059e1c90f8cfbe22bb9d498af7bed04b46be");
            result.SendTypeCode.ShouldBe("e6a3f8f081914f128a380f8b91cea54591c0f620460f4d43b8");
            result.SendStatusCode.ShouldBe("2002d651dea147bcb00814d7c44124232a61cd91bce142b6af");
            result.ResumeFlowStageCode.ShouldBe("237cdc24fe954c4f9dbc5793b20e1d3de1b2456b938f4c05b6");
            result.IsRead.ShouldBe(true);
            result.UserCompanyBindId.ShouldBe(Guid.Parse("78600c49-ee16-4791-acdd-2e9e789d1590"));
            result.ResumeSnapshotId.ShouldBe(Guid.Parse("e48924ba-eaf7-4f43-86eb-1f6cf07bef45"));
            result.ExtendedInformation.ShouldBe("735892e4cc0f491eae7ff34fd606b56e5e37a0353d454112aeacd7b11df99a2ec1c7556358b54c5aa870207ac97c71c304a974d5ce5c4c84b639bde860644314af3dc57f0dcc48f4bbeee0ea7568544c379b0f83b7b24f638ffc6a975494ba57f084b05554e04e86a70938cb4c31bd003e27e5c7a24447789ce870c58f34141b3e26487acf6e48828472bbc3a9607671b08717fb8ea54a75ae0fc25abe930084e14f02858fac44bb9b4dd8d5d4e5f9fe32ac6ab5e3d848fa8786076466c7b08d4988a681d4ab4b76a42603030848a290828f9ca0d2214612857ae469d66ba16424c5f763276b40f7ad725fe33a7efbbec99ec5c5d906487b9e1d");
            result.DateA.ShouldBe(new DateTime(2015, 11, 1));
            result.DateD.ShouldBe(new DateTime(2009, 1, 6));
            result.Sort.ShouldBe(587876683);
            result.Note.ShouldBe("01aa260a7bd7408b85ced972f6c645fd1c71ff0f8be0459c9f344be45549675512e56a452b97418b94d0b41c34f6e572034a3e9ade614fc4a615984a1070fb8217176b1be694461fb236434c336c0329fba63b861c514a8db9e0d11979381074c7b262b3d9da4f53ae3096aba8c4db8e061e9132357d4d1786aca92a0702224a0fb5c2f6dd014ea1bac4e494aaa8282aeeabb2038c2546b1ba7f9fffffd26e94a798b55531f04a498e97e6acdfcf45f0304e1fcf1500418dad2006bbbb8bec80aeceaebe0bc147c2a1133f4f56eef9eccb64f8b2aa354f969230603f474dbc524c3646e0aa8548ef9d8aa0956cd28ed2da25085f23a941d4974a");
            result.Status.ShouldBe("16d08319539a4b62b53154b6297f073d029f6399382242d784");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationssAppService.DeleteAsync(Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"));

            // Assert
            var result = await _companyInvitationsRepository.FindAsync(c => c.Id == Guid.Parse("348a2661-4df6-4891-ba6c-04528bed40de"));

            result.ShouldBeNull();
        }
    }
}