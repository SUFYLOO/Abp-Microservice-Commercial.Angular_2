using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyBinds;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyBindRepository _userCompanyBindRepository;

        public UserCompanyBindRepositoryTests()
        {
            _userCompanyBindRepository = GetRequiredService<IUserCompanyBindRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyBindRepository.GetListAsync(
                    userMainId: Guid.Parse("3174d81a-2775-492d-9e15-fd80f564afaa"),
                    companyMainId: Guid.Parse("2eece48a-c3bf-4d6e-b121-2b2e36b05c15"),
                    companyJobId: Guid.Parse("2cd202bc-2b67-4e62-958d-392d0880d567"),
                    companyInvitationsId: Guid.Parse("a33f912a-b63d-4742-b0ed-a4acb8cceed0"),
                    extendedInformation: "80316178133d4c97a1681b795448075bc2e6ff247a914e09906feca50def0f5a361eccbaad4c4a349921a2924bb2ae5f07429aefd8504184b3546e92fd1f2928df56b1017b7b4cbb802473cc0d2712476b07dd522b994ae79983ebdbfb5a6e53997ddebc8dfe44048e460aa8d81bab126cd635993ead4221a0fa77778bdeded45bf359d5da644a08a0583be3bbf8ec95a6bad528881449c2bbff55734d35cda03ad7c20202bb43718350678fa226a2344f1419956c684b8588b6f51a3a004aaa47181a979ed5439c8db13d5ca68bc2be4b5619ed88f542a8ac022ae228e64fbb8934ae75b75247609324b1891285fee72bfb2e732ee04cdbbe7d",
                    note: "fbf02774e949455c8994f6c4d01f731c2a5f8c40ce4e45feb6d1ded7c443963d4f80612ec1604984b7b0b01107bd7b772e8baa24a4e64016b53f7693717e43c931cf3d22350a4b4f84dbdae0ee37c94fae5c481d5a1541128c2e54d04ecf184e17beddadcbbe444cb0741a4d7ae771447b450f6db2864d3794b294e6693f68811774db8ffbc64bd3b8a470003396952a1b3d15a527ad45b5bcad3e126df57f1d0999434ccdd945a4a518cbd7aac3411cc02fc5dc72fc4e46a7a9bb13051faf881cca679cce59401d80fa560c92b216c3ca031cd5adaa43fb8ccb9985102ab504385829c0aae546c288820b4ea1efae03f7164975cf9547d39c11",
                    status: "d40eb0e9274849d3b2b2b64fb5acc50bfef3f4f6645b4a0e95"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("195d488e-20b8-4dad-aa25-9ec64553b538"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyBindRepository.GetCountAsync(
                    userMainId: Guid.Parse("941deaaa-dab6-41ce-9822-6c1e4a7ba817"),
                    companyMainId: Guid.Parse("1f8973a5-5782-4bc6-9646-59baf8580654"),
                    companyJobId: Guid.Parse("cdf2111c-1171-4d89-aa7f-78eda0986916"),
                    companyInvitationsId: Guid.Parse("968c749c-6581-4159-b8d2-e1922ce0b5e6"),
                    extendedInformation: "03aa477229d74116a7c7410c1f2e80a7dc48a6dcae8b46d38ab1ac9bb98b8e3abcb3c81fc2eb454eb45520c26fe76d449e58d8e871b448e0a24c1a160b71d64b2d3218ba03224481bb9c748bd54445c16983b90981c3460ea9eb393b0f225b7c37da86168d784929a1dc12775054824869fb020b57dd4459ac78b2c9736f915e9caa1749497f454d9968e327dcb4517fb265e6d3efe04ee7b60d0c06d947d4b676da658980d9459fa647c70030d58bd67cb4f57452a14aa3b5eff37f3be26dd10c7bb193d7b048b88760121615ef4f73b67e70159f5c47eaa5bb3670e7ad803271aba6d6c39f4b01ac8502057a14c30636c0dff4fc3644899245",
                    note: "f09d607383e347099883fe375711ad88820cb8740015466189d095073b70c6fffcbf51395be84e84a00f52d9de450edd99d30d6fb34f4d36a021db2b4a6a07bc9e3b52936b2749f99f1090dd23e311d57cca99ad84d2414eb806a06b5b11ad4476d6135bb8ba42aead94fbc6860ecec2ebaea7e7f3784e5280d2b4256fcd77f0cc554635a75b482c8aef0fa331ced91c772a7d7800634acb8085e0e9598727fa1a0f8a15f3204469b5efaf66cabb0a716197d371f0314f28b2c65bcc45efdd4e78ee4d0ce5a04a6aaf5fab49fe4184042a1ad66987c645478742020f36083c7dc0bf572e92074197b5987d2e2b75866f6a2572d0744f405e8708",
                    status: "46543d404a6a4a0fb225db0992216ebb08de0b993d0e4710ac"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}