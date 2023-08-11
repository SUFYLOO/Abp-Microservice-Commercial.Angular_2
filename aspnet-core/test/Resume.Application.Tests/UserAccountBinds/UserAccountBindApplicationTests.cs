using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserAccountBinds
{
    public class UserAccountBindsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserAccountBindsAppService _userAccountBindsAppService;
        private readonly IRepository<UserAccountBind, Guid> _userAccountBindRepository;

        public UserAccountBindsAppServiceTests()
        {
            _userAccountBindsAppService = GetRequiredService<IUserAccountBindsAppService>();
            _userAccountBindRepository = GetRequiredService<IRepository<UserAccountBind, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userAccountBindsAppService.GetListAsync(new GetUserAccountBindsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e8dd1652-9534-47ac-ae5a-62500ce2a943")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userAccountBindsAppService.GetAsync(Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserAccountBindCreateDto
            {
                UserMainId = Guid.Parse("d14c9370-3cd7-45b5-9908-a13dcfdb5064"),
                ThirdPartyTypeCode = "3eabbec5e66a49b0ad6b0bbf9bd7a9f0c09ccae6ffd347d193",
                ThirdPartyAccountId = "d2589d2bc739461fa276dc0fe0e93bbc42182e4c1db34611be",
                ExtendedInformation = "67a6c257190c44acaf9b507a7e117810e3b1188823e34ce592a4955e241e8ec9429747a02f574be19f38a2fc2b3b1ad683abeb772bbd40ebac61179def8bef302766c0f918a84666b1e4b779e6478b892d136df1d4f04afdb78450bea2e89889e718d0fd70db4e768e1406c73a1f71420ca725a7aea547669edd4d3eb05dba49521c7133c78147b5a4b94ad5d137f1cabfb8c924ee7f4b22a4e78e4c53e98268ae11c582fc274c768af5a7ad0e9c366f700a1e8810384f9eab5ebeb1ec6ac9b24f6e7b9e9bdb4bc79962f58f30c6a1eeb25e6f1044da48f7be26ee64a2e1e1669d97458253ef46dbb10a02f3fca361ed3ae619dc7e3347758de1",
                DateA = new DateTime(2000, 2, 20),
                DateD = new DateTime(2006, 9, 19),
                Sort = 1512745464,
                Note = "3323cf42567f4a19929e1ab3ec2454479165fd2853014889b8c7318b50140f5aa9e8c46296f64cea944d66346cedd2509e2415509c004bdf847713fb1565f05dea441f505a054b2aa788ce9024b4d8e904662b84ecad4b3797c459d121be77f71ada19dd3c884bc39e1396fcf39003aadcc38bdb4c42483b993858a03d8fb8f75e68065f6e6942679148777b42e7e02a085345d9006e4cccadda9537194961647d6b2d6419af46948632f53fc3f734a4733b6a1f842d43e9bd61035fb815c318ae2f80a6dab24c0fbaa91edde6845099212625e090c649e9a801a1c4fde111028aa24bf94f19463db6689bd87cb9d5f78755e6ecf452408daf47",
                Status = "b64c281525b34863aab9c8222e33d22348450f6dc7ca4e09a1"
            };

            // Act
            var serviceResult = await _userAccountBindsAppService.CreateAsync(input);

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("d14c9370-3cd7-45b5-9908-a13dcfdb5064"));
            result.ThirdPartyTypeCode.ShouldBe("3eabbec5e66a49b0ad6b0bbf9bd7a9f0c09ccae6ffd347d193");
            result.ThirdPartyAccountId.ShouldBe("d2589d2bc739461fa276dc0fe0e93bbc42182e4c1db34611be");
            result.ExtendedInformation.ShouldBe("67a6c257190c44acaf9b507a7e117810e3b1188823e34ce592a4955e241e8ec9429747a02f574be19f38a2fc2b3b1ad683abeb772bbd40ebac61179def8bef302766c0f918a84666b1e4b779e6478b892d136df1d4f04afdb78450bea2e89889e718d0fd70db4e768e1406c73a1f71420ca725a7aea547669edd4d3eb05dba49521c7133c78147b5a4b94ad5d137f1cabfb8c924ee7f4b22a4e78e4c53e98268ae11c582fc274c768af5a7ad0e9c366f700a1e8810384f9eab5ebeb1ec6ac9b24f6e7b9e9bdb4bc79962f58f30c6a1eeb25e6f1044da48f7be26ee64a2e1e1669d97458253ef46dbb10a02f3fca361ed3ae619dc7e3347758de1");
            result.DateA.ShouldBe(new DateTime(2000, 2, 20));
            result.DateD.ShouldBe(new DateTime(2006, 9, 19));
            result.Sort.ShouldBe(1512745464);
            result.Note.ShouldBe("3323cf42567f4a19929e1ab3ec2454479165fd2853014889b8c7318b50140f5aa9e8c46296f64cea944d66346cedd2509e2415509c004bdf847713fb1565f05dea441f505a054b2aa788ce9024b4d8e904662b84ecad4b3797c459d121be77f71ada19dd3c884bc39e1396fcf39003aadcc38bdb4c42483b993858a03d8fb8f75e68065f6e6942679148777b42e7e02a085345d9006e4cccadda9537194961647d6b2d6419af46948632f53fc3f734a4733b6a1f842d43e9bd61035fb815c318ae2f80a6dab24c0fbaa91edde6845099212625e090c649e9a801a1c4fde111028aa24bf94f19463db6689bd87cb9d5f78755e6ecf452408daf47");
            result.Status.ShouldBe("b64c281525b34863aab9c8222e33d22348450f6dc7ca4e09a1");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserAccountBindUpdateDto()
            {
                UserMainId = Guid.Parse("9dfa3b92-8790-4eef-979f-ab1ccba1b6ef"),
                ThirdPartyTypeCode = "c56f6057be62478f943b6fc71dcde3aae9b238d06b704ea68a",
                ThirdPartyAccountId = "e80b20e466e443729a9c56fe62fc35f81548126912b246ceaa",
                ExtendedInformation = "e1e4f4316b724e07ab498efdb19c0be84cf953237a0f40efb8dffc270c1295438422273190754353994471ba5c9584fe13eb1e353ada4c109c58846792c0390628ac84e92e3b4bde90ed343a1a907c95238f25eb9d5644eeb20a83cd2dfd7b23b0f1fee51cdf430fa3e8bda871ed76241c6663d01e21410192cddb2776a9b7cc0179b892d4094590a93a151e999bafe692b837226ba6491f8914cea4f47b19be4b55a62fb6364845bcefe8e65d033a74fd6cfb2c8e464f1a8328d120b2027624ac76f7e95bbb46988cd588705c4b8bb790e841e9dfbf4e478595353277acbbce65d4dcc2ac28403799337feac2c70d98a6aa26026bda416faab3",
                DateA = new DateTime(2003, 1, 14),
                DateD = new DateTime(2003, 8, 26),
                Sort = 1876909649,
                Note = "87453f0ccab84311a864723cf826bd6eedabbb954e6f4b8e94cbf3279292dfa0a37974a778b74bd7a2d01e972b795309b32f84cd1edc4393ae0b3a7e1f5d0925a1e6ba2adaeb47d8b2c7a8370596b88f1ed08d0865d842c4bee595aad8326c6531f29c3785b647afa87c730a27801b0a9251392d867d4a649a947f55386ccf0bc540c22ceb3848f0aa4f618e3139032cd705ada25bde4b66abdabb1c5b9dc25f2fcc56eb6f48416e9cbb5388daa44f5a7dae0110624045cd8f2d0b625ac972aafc3043f550f84c50946d0f6ad6d2f4bf07737ac66ce746309bdda28b076b952535d9a4d2dc0b426dbe2561fc95e230e45ddee6c0e7f441b5912a",
                Status = "a740b6df7f894ad182914472678565efeb9c2ebed1df411ca9"
            };

            // Act
            var serviceResult = await _userAccountBindsAppService.UpdateAsync(Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"), input);

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("9dfa3b92-8790-4eef-979f-ab1ccba1b6ef"));
            result.ThirdPartyTypeCode.ShouldBe("c56f6057be62478f943b6fc71dcde3aae9b238d06b704ea68a");
            result.ThirdPartyAccountId.ShouldBe("e80b20e466e443729a9c56fe62fc35f81548126912b246ceaa");
            result.ExtendedInformation.ShouldBe("e1e4f4316b724e07ab498efdb19c0be84cf953237a0f40efb8dffc270c1295438422273190754353994471ba5c9584fe13eb1e353ada4c109c58846792c0390628ac84e92e3b4bde90ed343a1a907c95238f25eb9d5644eeb20a83cd2dfd7b23b0f1fee51cdf430fa3e8bda871ed76241c6663d01e21410192cddb2776a9b7cc0179b892d4094590a93a151e999bafe692b837226ba6491f8914cea4f47b19be4b55a62fb6364845bcefe8e65d033a74fd6cfb2c8e464f1a8328d120b2027624ac76f7e95bbb46988cd588705c4b8bb790e841e9dfbf4e478595353277acbbce65d4dcc2ac28403799337feac2c70d98a6aa26026bda416faab3");
            result.DateA.ShouldBe(new DateTime(2003, 1, 14));
            result.DateD.ShouldBe(new DateTime(2003, 8, 26));
            result.Sort.ShouldBe(1876909649);
            result.Note.ShouldBe("87453f0ccab84311a864723cf826bd6eedabbb954e6f4b8e94cbf3279292dfa0a37974a778b74bd7a2d01e972b795309b32f84cd1edc4393ae0b3a7e1f5d0925a1e6ba2adaeb47d8b2c7a8370596b88f1ed08d0865d842c4bee595aad8326c6531f29c3785b647afa87c730a27801b0a9251392d867d4a649a947f55386ccf0bc540c22ceb3848f0aa4f618e3139032cd705ada25bde4b66abdabb1c5b9dc25f2fcc56eb6f48416e9cbb5388daa44f5a7dae0110624045cd8f2d0b625ac972aafc3043f550f84c50946d0f6ad6d2f4bf07737ac66ce746309bdda28b076b952535d9a4d2dc0b426dbe2561fc95e230e45ddee6c0e7f441b5912a");
            result.Status.ShouldBe("a740b6df7f894ad182914472678565efeb9c2ebed1df411ca9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userAccountBindsAppService.DeleteAsync(Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"));

            // Assert
            var result = await _userAccountBindRepository.FindAsync(c => c.Id == Guid.Parse("21e28c73-20bd-453b-a731-422fde5b0ebb"));

            result.ShouldBeNull();
        }
    }
}