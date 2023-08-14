using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserTokens
{
    public class UserTokensAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserTokensAppService _userTokensAppService;
        private readonly IRepository<UserToken, Guid> _userTokenRepository;

        public UserTokensAppServiceTests()
        {
            _userTokensAppService = GetRequiredService<IUserTokensAppService>();
            _userTokenRepository = GetRequiredService<IRepository<UserToken, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userTokensAppService.GetListAsync(new GetUserTokensInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c4021092-2dac-4e7d-bf85-9bfc9de8b36e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userTokensAppService.GetAsync(Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserTokenCreateDto
            {
                UserMainId = Guid.Parse("d63c04c5-ccf2-4aae-9744-367819856e9e"),
                TokenOld = "46deec16dceb4b8c8ed3ca191fe49fe8b879dbf038e540e4afe5b628c55c847876fade08d32e4336",
                TokenNew = "518c80ec6460471fac5cd50af5c2101e",
                ExtendedInformation = "656e5a1516204e80b338e5f704c7410a74ed9b9d2e86453daaabfd456ac6fb96813a60f1fa984b1cae74b328772ced8e06f134ade18f423f8278678ae133f1e24230256f567d4e429e7d9fde29f423b995459c54b18840de9f62883444c75f2a7551db0915f3471989aad7c17405ed1b41eb684e53f64dc984d854b023944dcd5202d9cb22db4dbaa9a72ae9ab3097633d6e6f088fdc410ca7952bf160edab23bf1504c682e04d7ea99e743574385a47cd9a842db0f0413188275958ecb999f1e1440bd8c30f43749241d4706ec7322736c3e4e7af7940b79341178aeeb189b645961602eae444c5acec74eb80cf7c5a3ef149c316fc4ff69b6f",
                DateA = new DateTime(2013, 10, 21),
                DateD = new DateTime(2009, 3, 15),
                Sort = 1045145496,
                Note = "315e003f65af4c6c81de773b09584ed36440ce1e34f4433d92fae2f4bc126e81cfb78089fe604e4e9b6c6fda86b32bda9a6227e9512f4c2ea83998906e43217eda8f2f425df640e1a3ba77620be2deac0fa0fa230d6a431ea59d63111bd70b266616474e575f4c54a94d864cc86ec744e1dc0810adf84facabb1ea0079d51db6d42ba8b3d46846f4bd20de6418bb56d9e3c24ca701694b968a92c1a087233d55f764aed2a421420ea4ad731c0b27c9d96ecf719b60064027a8e8bb49c3836cd0d6a55a265ad349dfaa1dff24ee162ae11d44572e115d454ea75302f98699ac6116c2e60afa584273a065f64d5594499f5df1b95fd88c4d49a6f9",
                Status = "a2cb622390ec471a90481ccc0947e86f826ea8294e584d1d8d"
            };

            // Act
            var serviceResult = await _userTokensAppService.CreateAsync(input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("d63c04c5-ccf2-4aae-9744-367819856e9e"));
            result.TokenOld.ShouldBe("46deec16dceb4b8c8ed3ca191fe49fe8b879dbf038e540e4afe5b628c55c847876fade08d32e4336");
            result.TokenNew.ShouldBe("518c80ec6460471fac5cd50af5c2101e");
            result.ExtendedInformation.ShouldBe("656e5a1516204e80b338e5f704c7410a74ed9b9d2e86453daaabfd456ac6fb96813a60f1fa984b1cae74b328772ced8e06f134ade18f423f8278678ae133f1e24230256f567d4e429e7d9fde29f423b995459c54b18840de9f62883444c75f2a7551db0915f3471989aad7c17405ed1b41eb684e53f64dc984d854b023944dcd5202d9cb22db4dbaa9a72ae9ab3097633d6e6f088fdc410ca7952bf160edab23bf1504c682e04d7ea99e743574385a47cd9a842db0f0413188275958ecb999f1e1440bd8c30f43749241d4706ec7322736c3e4e7af7940b79341178aeeb189b645961602eae444c5acec74eb80cf7c5a3ef149c316fc4ff69b6f");
            result.DateA.ShouldBe(new DateTime(2013, 10, 21));
            result.DateD.ShouldBe(new DateTime(2009, 3, 15));
            result.Sort.ShouldBe(1045145496);
            result.Note.ShouldBe("315e003f65af4c6c81de773b09584ed36440ce1e34f4433d92fae2f4bc126e81cfb78089fe604e4e9b6c6fda86b32bda9a6227e9512f4c2ea83998906e43217eda8f2f425df640e1a3ba77620be2deac0fa0fa230d6a431ea59d63111bd70b266616474e575f4c54a94d864cc86ec744e1dc0810adf84facabb1ea0079d51db6d42ba8b3d46846f4bd20de6418bb56d9e3c24ca701694b968a92c1a087233d55f764aed2a421420ea4ad731c0b27c9d96ecf719b60064027a8e8bb49c3836cd0d6a55a265ad349dfaa1dff24ee162ae11d44572e115d454ea75302f98699ac6116c2e60afa584273a065f64d5594499f5df1b95fd88c4d49a6f9");
            result.Status.ShouldBe("a2cb622390ec471a90481ccc0947e86f826ea8294e584d1d8d");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserTokenUpdateDto()
            {
                UserMainId = Guid.Parse("d63f5411-3029-418c-87e0-872ab0d3d055"),
                TokenOld = "bd8717ca91e3486eb40f42ab17457e1ec03",
                TokenNew = "946b3a84ae414d78b4d4f916e0d76c0f2b514b7dbcf2481c90d497fb02f38dfec80569",
                ExtendedInformation = "d323b3431ce24c318da34fad08a159848c50f81ad25c4bcdb9b95c6627f581eb18502e930612427b83461a2addf360a39345633a9f7f491586c8b64f57166c45236d15f92e584be9a117d28c1562cb3f87d4a39fb2734e42a6752aa52fba79aa82d17d5e4ad843d3b00fdc933f4d31d89e2fa39513ba4c42bfd94c333cddbc5e41e08d1a6a89467ca7956a26ef6235b536d0d222b44d4cf0a17db458cd32a0980c7cc7eaa591498d8411c76af4db49e45a251e94d7e0446ca6d5ad14e26ac5e85cda17ea18cb4cdab15917c8c903a2442b41f197202a47d7b9e7c1011f225dc751809c9f9fd341fe90be246a9104e6e60f89563953d0487eafeb",
                DateA = new DateTime(2006, 3, 10),
                DateD = new DateTime(2009, 5, 2),
                Sort = 865364980,
                Note = "842b31591c024e20ae07dba9d2dfc2a993a522cd5ccc409a8d940d5c64e60dcda42dec7cfe3d4d07b27f94c3bc05f0c22f79f03980e94d8bbe327a340190b80552736a0cf40b40bfa91710ebb878f877cc5a66d5d8544bd49ada9658b8b2c7eaceea67f2044546f7943a8b0a292562fb849f84af928d4de795581f40b9a7c104b2990da3fd714bba891e1c91d3f07319f713dcbd5a1c46b3ae1dd541a689fb9861fd2d52dbc841c6860eaa48282c771882ab29736c0148e4ab26c27066a57747074ec9bb0ba04c57abf3baae8f4b585e7915878f4b19448eb3b795b57c3735f5853810dbbdca4265aa53fb3a858fc09c46199f18f7e04f16a212",
                Status = "64c2bf53edbc463c8aaf7402a1b7f6140f43404bd42b41e692"
            };

            // Act
            var serviceResult = await _userTokensAppService.UpdateAsync(Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"), input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("d63f5411-3029-418c-87e0-872ab0d3d055"));
            result.TokenOld.ShouldBe("bd8717ca91e3486eb40f42ab17457e1ec03");
            result.TokenNew.ShouldBe("946b3a84ae414d78b4d4f916e0d76c0f2b514b7dbcf2481c90d497fb02f38dfec80569");
            result.ExtendedInformation.ShouldBe("d323b3431ce24c318da34fad08a159848c50f81ad25c4bcdb9b95c6627f581eb18502e930612427b83461a2addf360a39345633a9f7f491586c8b64f57166c45236d15f92e584be9a117d28c1562cb3f87d4a39fb2734e42a6752aa52fba79aa82d17d5e4ad843d3b00fdc933f4d31d89e2fa39513ba4c42bfd94c333cddbc5e41e08d1a6a89467ca7956a26ef6235b536d0d222b44d4cf0a17db458cd32a0980c7cc7eaa591498d8411c76af4db49e45a251e94d7e0446ca6d5ad14e26ac5e85cda17ea18cb4cdab15917c8c903a2442b41f197202a47d7b9e7c1011f225dc751809c9f9fd341fe90be246a9104e6e60f89563953d0487eafeb");
            result.DateA.ShouldBe(new DateTime(2006, 3, 10));
            result.DateD.ShouldBe(new DateTime(2009, 5, 2));
            result.Sort.ShouldBe(865364980);
            result.Note.ShouldBe("842b31591c024e20ae07dba9d2dfc2a993a522cd5ccc409a8d940d5c64e60dcda42dec7cfe3d4d07b27f94c3bc05f0c22f79f03980e94d8bbe327a340190b80552736a0cf40b40bfa91710ebb878f877cc5a66d5d8544bd49ada9658b8b2c7eaceea67f2044546f7943a8b0a292562fb849f84af928d4de795581f40b9a7c104b2990da3fd714bba891e1c91d3f07319f713dcbd5a1c46b3ae1dd541a689fb9861fd2d52dbc841c6860eaa48282c771882ab29736c0148e4ab26c27066a57747074ec9bb0ba04c57abf3baae8f4b585e7915878f4b19448eb3b795b57c3735f5853810dbbdca4265aa53fb3a858fc09c46199f18f7e04f16a212");
            result.Status.ShouldBe("64c2bf53edbc463c8aaf7402a1b7f6140f43404bd42b41e692");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userTokensAppService.DeleteAsync(Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"));

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"));

            result.ShouldBeNull();
        }
    }
}