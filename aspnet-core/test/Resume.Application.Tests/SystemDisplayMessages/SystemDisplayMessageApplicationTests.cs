using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemDisplayMessagesAppService _systemDisplayMessagesAppService;
        private readonly IRepository<SystemDisplayMessage, Guid> _systemDisplayMessageRepository;

        public SystemDisplayMessagesAppServiceTests()
        {
            _systemDisplayMessagesAppService = GetRequiredService<ISystemDisplayMessagesAppService>();
            _systemDisplayMessageRepository = GetRequiredService<IRepository<SystemDisplayMessage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemDisplayMessagesAppService.GetListAsync(new GetSystemDisplayMessagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8ac6c11a-d263-4d5b-9855-5541162ed092")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemDisplayMessagesAppService.GetAsync(Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemDisplayMessageCreateDto
            {
                DisplayTypeCode = "b10c4c051b61484aae424b83e8bd6496c5f1f6725e4c4fd7bd",
                TitleContents = "bebcd72380bb4e0b9be85d94d2308b4fbbf91dd8a9fe4221bb7467916cf26244ff5ca0a3c43e44a8829466a08dd8bc059ffb8c96546345508498370bc6b474894a93df48188f453d9f295fccf214013d5d4641a0d0b045e7b05ae884e3ed04e0c2bb296cdc654b0eb8e4b70c6ec50f821c2eeb2eaaf641b49400b09ebf6b11a314845e0b063d4b1bb02db6e1cf9beafa529a3faa811f46f7be56951b37e4971a9b2d3a9d010947a7a7cb59dc60a1f57a33f1af0cfdea46838ec61a0a02b996b81c02fbcec2ac4d3b943a91bcda965a2933d2c825464d42dfa8cb25184d20863cbcf328519b4549aba3b931ff0b40043973ab4236356d4b4eba6e",
                Contents = "e7ffb464b7234dc3a12d670542b99c0d1a7ad5d2eb5b4a80963be59335f34c415b332b38eed5493299069a5e9d307a02c4f64f34806249e7b691526d3405b0f081034bf67bc64a02a0aca698a8abb0b215b54e1960694d28ace27543272918d67ab54489656944cc949c99c82bd8ddf1f4151c5e6308475d8fdb862891452c01bf3414e6349344afbd1f97641af9961bb0a3fb01a53f48c7959ddaff285c6536da493dac93b645f084630132e16fb564d4756a93b5b342d98e6daa1bed54660023362b6870dc4339b2a1deb27a2797d5d47f773b7b4a4be1904ca014d51782a520bbfe2b8c5d403e8792743bf2cca9eb3711caec93e84e748c30",
                ExtendedInformation = "448f65c9eb66454daeaf008aadfe960176a2f2beb24d4ac585677e50547fcdfbd7b9bf4e47f543fa9d3264210e2ac14dd5abd2bcdb9940c69bd572ba4e7f0d321331b35eb7174ac49f9fbc26af27e5560ac9dc23011a4e03bcaa9ec3998fa959a7d92544bc86457dab8eec5d941b6aaf0f53d87b95984d16bc370894b7fbbf5185431d4b3d5b4f7c921075ca824100a7aa82465a7f294a55b2b5148e2b563321fea5c29e0e2e4aaeb735fba29a1205555f0137894c244db7957845adf7bc14b15adabed938a148bdbd8a5b09de5d925d9258ed3fbc9c4d21bc1007a9de34a8c3636809fd0d08440c9b31c33f69fb73f1acd8f519dad545058e85",
                DateA = new DateTime(2001, 11, 10),
                DateD = new DateTime(2001, 10, 26),
                Sort = 1262491292,
                Note = "66e6d6ccc7b141f69228d24af0d1e643497cd8fe4bcf40ac91f9eaf41e5583c8c14b83ca606244789866e690262dec936d4431120cc04072bc972b2c9cb79c53505671b3d4e54fd0a5038d4f58701a919a0e0613fb924f3ba5556d94f5631b528971f236ab224967aa884877cb8439df8278feab196d423a8a9ae065d0e94a19ec07f3d0a3684e20aaccc397582eba84fdd80c91fe1e4261bbd76282ca30db774164424a0e18482b91a482893cd4812214cb818db43b4fd78aa4a74f250068dc076c870e4d834f788a1e3c0d77dc71443f41c831b6344b1181f853c28534cffaa6d96575dd10414eb968dca2947f72423e00a278b4ea4c4487c6",
                Status = "ed5bc152e8bd4fafab755a7ca79ffcb5c48076c5b9e04a97ab"
            };

            // Act
            var serviceResult = await _systemDisplayMessagesAppService.CreateAsync(input);

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.DisplayTypeCode.ShouldBe("b10c4c051b61484aae424b83e8bd6496c5f1f6725e4c4fd7bd");
            result.TitleContents.ShouldBe("bebcd72380bb4e0b9be85d94d2308b4fbbf91dd8a9fe4221bb7467916cf26244ff5ca0a3c43e44a8829466a08dd8bc059ffb8c96546345508498370bc6b474894a93df48188f453d9f295fccf214013d5d4641a0d0b045e7b05ae884e3ed04e0c2bb296cdc654b0eb8e4b70c6ec50f821c2eeb2eaaf641b49400b09ebf6b11a314845e0b063d4b1bb02db6e1cf9beafa529a3faa811f46f7be56951b37e4971a9b2d3a9d010947a7a7cb59dc60a1f57a33f1af0cfdea46838ec61a0a02b996b81c02fbcec2ac4d3b943a91bcda965a2933d2c825464d42dfa8cb25184d20863cbcf328519b4549aba3b931ff0b40043973ab4236356d4b4eba6e");
            result.Contents.ShouldBe("e7ffb464b7234dc3a12d670542b99c0d1a7ad5d2eb5b4a80963be59335f34c415b332b38eed5493299069a5e9d307a02c4f64f34806249e7b691526d3405b0f081034bf67bc64a02a0aca698a8abb0b215b54e1960694d28ace27543272918d67ab54489656944cc949c99c82bd8ddf1f4151c5e6308475d8fdb862891452c01bf3414e6349344afbd1f97641af9961bb0a3fb01a53f48c7959ddaff285c6536da493dac93b645f084630132e16fb564d4756a93b5b342d98e6daa1bed54660023362b6870dc4339b2a1deb27a2797d5d47f773b7b4a4be1904ca014d51782a520bbfe2b8c5d403e8792743bf2cca9eb3711caec93e84e748c30");
            result.ExtendedInformation.ShouldBe("448f65c9eb66454daeaf008aadfe960176a2f2beb24d4ac585677e50547fcdfbd7b9bf4e47f543fa9d3264210e2ac14dd5abd2bcdb9940c69bd572ba4e7f0d321331b35eb7174ac49f9fbc26af27e5560ac9dc23011a4e03bcaa9ec3998fa959a7d92544bc86457dab8eec5d941b6aaf0f53d87b95984d16bc370894b7fbbf5185431d4b3d5b4f7c921075ca824100a7aa82465a7f294a55b2b5148e2b563321fea5c29e0e2e4aaeb735fba29a1205555f0137894c244db7957845adf7bc14b15adabed938a148bdbd8a5b09de5d925d9258ed3fbc9c4d21bc1007a9de34a8c3636809fd0d08440c9b31c33f69fb73f1acd8f519dad545058e85");
            result.DateA.ShouldBe(new DateTime(2001, 11, 10));
            result.DateD.ShouldBe(new DateTime(2001, 10, 26));
            result.Sort.ShouldBe(1262491292);
            result.Note.ShouldBe("66e6d6ccc7b141f69228d24af0d1e643497cd8fe4bcf40ac91f9eaf41e5583c8c14b83ca606244789866e690262dec936d4431120cc04072bc972b2c9cb79c53505671b3d4e54fd0a5038d4f58701a919a0e0613fb924f3ba5556d94f5631b528971f236ab224967aa884877cb8439df8278feab196d423a8a9ae065d0e94a19ec07f3d0a3684e20aaccc397582eba84fdd80c91fe1e4261bbd76282ca30db774164424a0e18482b91a482893cd4812214cb818db43b4fd78aa4a74f250068dc076c870e4d834f788a1e3c0d77dc71443f41c831b6344b1181f853c28534cffaa6d96575dd10414eb968dca2947f72423e00a278b4ea4c4487c6");
            result.Status.ShouldBe("ed5bc152e8bd4fafab755a7ca79ffcb5c48076c5b9e04a97ab");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemDisplayMessageUpdateDto()
            {
                DisplayTypeCode = "38f4c8f6876e414c9f1eeaa0a599760405ca0a08b2944560b3",
                TitleContents = "14efb9e89d7c4d2f9b04b943ac5ea0a0ffcd867e2e0d4f019bdc591192ec6370609dcf5dc8104cabacab6a3b22f9033ec2588c2eeae249118c79801af03408be4019d86c9c7c4a358bfa1f3f182025ad1bda8352496d4e27b3492f0aa6b50ad3a1e891e4776944fdba80ddbfa86c887180894caae9bd4c338844b54a04c75296ab1f27dff4294e9590bd7a8e24a04aa7575f1228a29148fda79341a30e7f3597cd46001b4be844b389ef0479f7d24d1c2ad7d8ecddc2447b89843bf1b7ead9bc0852b668cd744df9862b199cee3f39814af2de548d884c1aaf8abc6dd80e648c325b81c78a4248ddb18fdf913d049c462931b4bf188e44818f90",
                Contents = "e076b729240544f2bf474ba10babf4c33cb7e8a951904690bf37a1cea9be2a3549ec23ae6d434211b2f461e362899a9d8040b4ffde9140bcb348fa7fbcafe2524b4c883698ca4293911169e1ecbf1db054d94dc3178144a89fd0281a2b3b5c65248de0a816ef4e46b1ac3cf78814cd17352b24807a734018a5f3f0e3aeefb11ccc05670c8d8d41608edf94f0a0966354f56273197706494fa46dff4ac68715400af646161c944494b3e9d2685c5593ce4bd3bfc81f3446b0a85f8eb1011f94f2ad4927463ea7459ca381498ca0f6e8510a00eb2bb33b4eee868fbaa99ce340534e171077a5ff4e2ab8fe8f4e80a6fa3463a21358ac13449b8b55",
                ExtendedInformation = "a0a3c99603974fdd8ec3b88cfa5582cf9883758f10474bf1898a70b66facfdbeb77dd0c1bf184409b18702d6a5cacda6ba87008882f34240813890e0e74a42963cafce4bbe9c4f2c97896739a655a3ecec59681394bb44de85c6b22037c68c418ee0f0f28468413ab1729a79c19c712ebedca6dd38ca4feebefc84830ae8f600cd6ca88d840845d28fb8163d2621bdccc79b0f2c74964572a29af824886295c93e7042823b8c492cae2e1dd280a7d30ef681e0ea51044d6493dfe505fea21a4372be81a0a879401cae349c04c314d56655a23f4d01de4f23901a430f8d4bc233dd659699bfcd41c7b57aa308685dbd758f55ccad94e648bd8b22",
                DateA = new DateTime(2010, 11, 6),
                DateD = new DateTime(2021, 7, 18),
                Sort = 1646495752,
                Note = "b862b09e64bf4bd686c2ca7ddf71e8e45456a99348454010afbaba11ff34c92bb7b36986179a4d909abad2242378d766abddb15a55d64d478671f8bc89b8cf4e74967bb3d02744439c34db4b9edfc22389e1a612a71c48589d4ddb5d933d13e6fe37d0346ea84d078b48031782ca0f233f02bb8eb7ce478f92f97ee7fe4939a28b377cd37ee549b687fd78f760241dfc4bdcaa7081084ba6be6d64f217f42610a58d251ce5684fdcb6095457db288a8004311d308dcc412793935ba3afa302dca439f0941b594e27ac1a00271880f2cc8f7a5798b06c4e7fae5b8ab199f73c1ea4d047e8a3e2440ea1148926afdacc35ffd2ee97d5fa48ae9759",
                Status = "c7dc0d4ebd914312a2c99698af1a349ef7273a1951814a3a8f"
            };

            // Act
            var serviceResult = await _systemDisplayMessagesAppService.UpdateAsync(Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"), input);

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.DisplayTypeCode.ShouldBe("38f4c8f6876e414c9f1eeaa0a599760405ca0a08b2944560b3");
            result.TitleContents.ShouldBe("14efb9e89d7c4d2f9b04b943ac5ea0a0ffcd867e2e0d4f019bdc591192ec6370609dcf5dc8104cabacab6a3b22f9033ec2588c2eeae249118c79801af03408be4019d86c9c7c4a358bfa1f3f182025ad1bda8352496d4e27b3492f0aa6b50ad3a1e891e4776944fdba80ddbfa86c887180894caae9bd4c338844b54a04c75296ab1f27dff4294e9590bd7a8e24a04aa7575f1228a29148fda79341a30e7f3597cd46001b4be844b389ef0479f7d24d1c2ad7d8ecddc2447b89843bf1b7ead9bc0852b668cd744df9862b199cee3f39814af2de548d884c1aaf8abc6dd80e648c325b81c78a4248ddb18fdf913d049c462931b4bf188e44818f90");
            result.Contents.ShouldBe("e076b729240544f2bf474ba10babf4c33cb7e8a951904690bf37a1cea9be2a3549ec23ae6d434211b2f461e362899a9d8040b4ffde9140bcb348fa7fbcafe2524b4c883698ca4293911169e1ecbf1db054d94dc3178144a89fd0281a2b3b5c65248de0a816ef4e46b1ac3cf78814cd17352b24807a734018a5f3f0e3aeefb11ccc05670c8d8d41608edf94f0a0966354f56273197706494fa46dff4ac68715400af646161c944494b3e9d2685c5593ce4bd3bfc81f3446b0a85f8eb1011f94f2ad4927463ea7459ca381498ca0f6e8510a00eb2bb33b4eee868fbaa99ce340534e171077a5ff4e2ab8fe8f4e80a6fa3463a21358ac13449b8b55");
            result.ExtendedInformation.ShouldBe("a0a3c99603974fdd8ec3b88cfa5582cf9883758f10474bf1898a70b66facfdbeb77dd0c1bf184409b18702d6a5cacda6ba87008882f34240813890e0e74a42963cafce4bbe9c4f2c97896739a655a3ecec59681394bb44de85c6b22037c68c418ee0f0f28468413ab1729a79c19c712ebedca6dd38ca4feebefc84830ae8f600cd6ca88d840845d28fb8163d2621bdccc79b0f2c74964572a29af824886295c93e7042823b8c492cae2e1dd280a7d30ef681e0ea51044d6493dfe505fea21a4372be81a0a879401cae349c04c314d56655a23f4d01de4f23901a430f8d4bc233dd659699bfcd41c7b57aa308685dbd758f55ccad94e648bd8b22");
            result.DateA.ShouldBe(new DateTime(2010, 11, 6));
            result.DateD.ShouldBe(new DateTime(2021, 7, 18));
            result.Sort.ShouldBe(1646495752);
            result.Note.ShouldBe("b862b09e64bf4bd686c2ca7ddf71e8e45456a99348454010afbaba11ff34c92bb7b36986179a4d909abad2242378d766abddb15a55d64d478671f8bc89b8cf4e74967bb3d02744439c34db4b9edfc22389e1a612a71c48589d4ddb5d933d13e6fe37d0346ea84d078b48031782ca0f233f02bb8eb7ce478f92f97ee7fe4939a28b377cd37ee549b687fd78f760241dfc4bdcaa7081084ba6be6d64f217f42610a58d251ce5684fdcb6095457db288a8004311d308dcc412793935ba3afa302dca439f0941b594e27ac1a00271880f2cc8f7a5798b06c4e7fae5b8ab199f73c1ea4d047e8a3e2440ea1148926afdacc35ffd2ee97d5fa48ae9759");
            result.Status.ShouldBe("c7dc0d4ebd914312a2c99698af1a349ef7273a1951814a3a8f");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemDisplayMessagesAppService.DeleteAsync(Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"));

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"));

            result.ShouldBeNull();
        }
    }
}