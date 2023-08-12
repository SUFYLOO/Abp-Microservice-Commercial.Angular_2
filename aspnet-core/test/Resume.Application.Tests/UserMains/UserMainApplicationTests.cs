using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserMains
{
    public class UserMainsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserMainsAppService _userMainsAppService;
        private readonly IRepository<UserMain, Guid> _userMainRepository;

        public UserMainsAppServiceTests()
        {
            _userMainsAppService = GetRequiredService<IUserMainsAppService>();
            _userMainRepository = GetRequiredService<IRepository<UserMain, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userMainsAppService.GetListAsync(new GetUserMainsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0ce3b2f9-ad1e-4fbf-982c-a9fbbfaf4fc9")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userMainsAppService.GetAsync(Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserMainCreateDto
            {
                UserId = Guid.Parse("7a775d24-0477-4459-a72e-36fe3e224f55"),
                Name = "5bf993b9b0304c6ca77be191f1f9ca710ca0db6798944f95ab",
                AnonymousName = "170f15d89df24bf2b63c0023448a6bfc02ed7ace5f2840fdb8",
                LoginAccountCode = "2b4d564fc7d6494fbcd9c3f5452101417e5dcb52be574d5683",
                LoginMobilePhoneUpdate = "68059cc449824709a498bbe9b832ea2392dfab4eb6fb41b1b3",
                LoginMobilePhone = "78f8457c363d4428b0a7354184ee9c894d0210b4ba9e4f3ebb",
                LoginEmailUpdate = "ab3549d1270e441490209fbe33287c6563a81ad7dbe24668acba97a0a06f070bdba91a25d0904b0b9c36c97cb37b5a7f6901221355ed4fd082905c8ddac49e45d5a298c171ea4810a37cf1c474c4b70f0447973a45b74655a93075b8897cf59030db464e",
                LoginEmail = "7dac666f0146464a8e4aa0e7f12b8fbef69d90317c7f4116a322b2681e570b7310f8fb9a10f946e6b26615f1c882d176ce925b4c97004f999b89994235608b009f9d8be4f8f54c5495ffffe0b42453f20bbd8fa9eae94d808047902cd771bcdd02d71d63",
                LoginIdentityNo = "fec0d6cffb2a4947a714bf3980287b758b9779968dde4c33ac",
                Password = "a251fef3c02f4082b4be27a8ff20ccc20c5fa1c97e744668aebaac8061fdc0670051a7cca73d42d691fce8a44b76e66f6331ddfaa39040d28388c6572af36b0c4cfab9084fb8483e8e766bac21086ec094451a561e6d49dda5db7714eaab6aa88f93f9e6",
                SystemUserRoleKeys = 1944854759,
                AllowSearch = true,
                DateA = new DateTime(2016, 4, 8),
                ExtendedInformation = "7ced20b32d8e45b38423d0fd64c00ca544d701aff2364e799b817a39932a13283008d689d9e2458da8f9902e893ac4c3daf3c172e2184cb8a5132e4f817b599d0d5c61d5b0f84c29a462a98c802af8d4d7967687535349b4bfc4bbf16ba14e7405e93ea785304ad28115a4e00949eb5b469e7fd6f049457db70331ecc41e1ddf8b0e94a173f54fd0be1497b010d9a2b91746c49e0cd2463e98866faa3d73214c232dce6b4e2f48f79b3535ef2a265d51f8ab767ab8be43f2bccafef299a13335e5ac8f4c09454fccbbbe13d1aa766c13bf81670cf752457fad027087c4eb742649e307a1ac6d43d89c5127f636a5d691f4412fef0cc947ec96ea",
                DateD = new DateTime(2001, 4, 21),
                Sort = 6363979,
                Note = "7361da95036b48bdb032dc2e7133a40a2cf7c30482074f2db4b053bd642672ec3b3b9c4bd61b4327a6b2ad621b622493cc35a6022d9a46f79860e0f3bda748a91f7de28daa1a4ec9b9f1f73ea3bb8615e9a690fe53ce47c68729623420732f5bc79527f823e64ed4a7493236880ddfc2e3a80a7cef394fdc8f531cde0158e4e7511604ff16bb44f99e2bbf93addc03361405ae036b964ee8a1bfc47a4bc52714c6b0ed6595874f68b65ac4a4c064e7ba171c444c806c4b1bb3f04a8a8684445ac2518576038d462daaea0d1a77a6e4361235ba7cd45a4f3db59bd20709d339dffc7430c144e34b598c3b319b14d15cecf7e66b71898a45cf8292",
                Status = "12beeaedaea44e96926fd9d9b2efe5671a67900122644bf284",
                Matching = true
            };

            // Act
            var serviceResult = await _userMainsAppService.CreateAsync(input);

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("7a775d24-0477-4459-a72e-36fe3e224f55"));
            result.Name.ShouldBe("5bf993b9b0304c6ca77be191f1f9ca710ca0db6798944f95ab");
            result.AnonymousName.ShouldBe("170f15d89df24bf2b63c0023448a6bfc02ed7ace5f2840fdb8");
            result.LoginAccountCode.ShouldBe("2b4d564fc7d6494fbcd9c3f5452101417e5dcb52be574d5683");
            result.LoginMobilePhoneUpdate.ShouldBe("68059cc449824709a498bbe9b832ea2392dfab4eb6fb41b1b3");
            result.LoginMobilePhone.ShouldBe("78f8457c363d4428b0a7354184ee9c894d0210b4ba9e4f3ebb");
            result.LoginEmailUpdate.ShouldBe("ab3549d1270e441490209fbe33287c6563a81ad7dbe24668acba97a0a06f070bdba91a25d0904b0b9c36c97cb37b5a7f6901221355ed4fd082905c8ddac49e45d5a298c171ea4810a37cf1c474c4b70f0447973a45b74655a93075b8897cf59030db464e");
            result.LoginEmail.ShouldBe("7dac666f0146464a8e4aa0e7f12b8fbef69d90317c7f4116a322b2681e570b7310f8fb9a10f946e6b26615f1c882d176ce925b4c97004f999b89994235608b009f9d8be4f8f54c5495ffffe0b42453f20bbd8fa9eae94d808047902cd771bcdd02d71d63");
            result.LoginIdentityNo.ShouldBe("fec0d6cffb2a4947a714bf3980287b758b9779968dde4c33ac");
            result.Password.ShouldBe("a251fef3c02f4082b4be27a8ff20ccc20c5fa1c97e744668aebaac8061fdc0670051a7cca73d42d691fce8a44b76e66f6331ddfaa39040d28388c6572af36b0c4cfab9084fb8483e8e766bac21086ec094451a561e6d49dda5db7714eaab6aa88f93f9e6");
            result.SystemUserRoleKeys.ShouldBe(1944854759);
            result.AllowSearch.ShouldBe(true);
            result.DateA.ShouldBe(new DateTime(2016, 4, 8));
            result.ExtendedInformation.ShouldBe("7ced20b32d8e45b38423d0fd64c00ca544d701aff2364e799b817a39932a13283008d689d9e2458da8f9902e893ac4c3daf3c172e2184cb8a5132e4f817b599d0d5c61d5b0f84c29a462a98c802af8d4d7967687535349b4bfc4bbf16ba14e7405e93ea785304ad28115a4e00949eb5b469e7fd6f049457db70331ecc41e1ddf8b0e94a173f54fd0be1497b010d9a2b91746c49e0cd2463e98866faa3d73214c232dce6b4e2f48f79b3535ef2a265d51f8ab767ab8be43f2bccafef299a13335e5ac8f4c09454fccbbbe13d1aa766c13bf81670cf752457fad027087c4eb742649e307a1ac6d43d89c5127f636a5d691f4412fef0cc947ec96ea");
            result.DateD.ShouldBe(new DateTime(2001, 4, 21));
            result.Sort.ShouldBe(6363979);
            result.Note.ShouldBe("7361da95036b48bdb032dc2e7133a40a2cf7c30482074f2db4b053bd642672ec3b3b9c4bd61b4327a6b2ad621b622493cc35a6022d9a46f79860e0f3bda748a91f7de28daa1a4ec9b9f1f73ea3bb8615e9a690fe53ce47c68729623420732f5bc79527f823e64ed4a7493236880ddfc2e3a80a7cef394fdc8f531cde0158e4e7511604ff16bb44f99e2bbf93addc03361405ae036b964ee8a1bfc47a4bc52714c6b0ed6595874f68b65ac4a4c064e7ba171c444c806c4b1bb3f04a8a8684445ac2518576038d462daaea0d1a77a6e4361235ba7cd45a4f3db59bd20709d339dffc7430c144e34b598c3b319b14d15cecf7e66b71898a45cf8292");
            result.Status.ShouldBe("12beeaedaea44e96926fd9d9b2efe5671a67900122644bf284");
            result.Matching.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserMainUpdateDto()
            {
                UserId = Guid.Parse("3592a1a5-41a3-45a7-b9db-d1d2656c1e31"),
                Name = "55253303cfd5453390f6469a4fb0a6cf5d7c9088823e46e0bc",
                AnonymousName = "fc344ecc4b954b2da1e4ff99f3bd009988fc8e56dee94c6c9b",
                LoginAccountCode = "9338cade8dd4464f81c8bd07b1a8afb668e5b89a3c694c61a7",
                LoginMobilePhoneUpdate = "ae92e770f7f548d285a20d13aff7c8d59aea4785dc0e476599",
                LoginMobilePhone = "b50b38c6ad2947c58c76a5bf044ed2a6b3122f14a25f42d184",
                LoginEmailUpdate = "b0d21f11659946e7b9b7f269fb7a4b959489cdf227aa4ababc1ec9a3794d569de0bea68efc4544578eed2bbcd72c2f2ab7f16c2d6b7242069c6ae5ab8bdcbad1f23cc007de70486db07800cc9c1780a874b0881282d04bf4be4ecd9b87b6b89e8fbb661c",
                LoginEmail = "1e5e52363e844a7e8053af4e8f4cdaf0f32cc0c9f1b44afe87faf13f9e3250a88149b2e0a4ad4ae0b10ab0559ce70319dd514b43420d461d9b99aa2ca98111851d824f6770c441c1a14258a78d085e5271aab19ab54c48299f77fafeba19c7e301deb55b",
                LoginIdentityNo = "90baef30339c48e799fdd206fccf06177683e502315042799d",
                Password = "77eb1d4a294540f3825415e3a85a308e007c50d34d41447d85261737ef04d199d1f56d314b8247cc8ec537a15b6c7a40e0fd933fabe64e8c9d98e4b3e73a9b353e0dc6e17ab14c19b61eb25d6385675b64b3da16736b4b6dbd59a4053790baa4da9c77af",
                SystemUserRoleKeys = 334161177,
                AllowSearch = true,
                DateA = new DateTime(2006, 5, 20),
                ExtendedInformation = "6740f516c9e84391a4e681466c52a2570c5af9213de04c0aa574b5919c1548f9b70d459a4df24861b7dad64cf4c36da59bd6fc5656cf46c19fb89c30c22721223f141b2e9b0643f9bce5f644daca344cbe798d5d30ff4052a6f2dee9884fee2ffeec1802957c45e7a91b19d305ac5f2732e2135f64fd4a7da9ca4785b3ea7e4ac8201a644ed4476186478364e3c85e946f1518b88c684e19883164f971b1fefe6d188d558c93482980aeef67f31648cbd082a8f6ceb54682abe756b1bbb5742a431aee7acd3847929e0cb7400a64518d6ae056673e59440bbf9c0826364e0b28b073772e94cd43a1bdf37309a92001403aa57966c021434abb0a",
                DateD = new DateTime(2012, 3, 20),
                Sort = 1841182579,
                Note = "f3ccb8063b2f456c851733432f1aadeab0c1a9c3951b4d5899b205e6f08af9c61d7441c40a3542dc806d4f6cd72d8afa3b4bfa324ab04af0a124f692fea92ee636cf4e2abe0046e3bfd0d0f1e48b487f9b846056cc3d4cd9a32a992616cb0df76dd74dc9f9c44b3d88a65ac121919f47b2f8dd7d765f4973926c0038870530e015237f5a1ff1410caaa7faa571cdc7f3ffc4a5ab90284d9396d02d479635fa5af7f8aaae3ea644c580f3bdf89288e5e1d51c71322dc94bff9543439940ab829517b335ad2dea4119aea23788a62e6447bfd6b259058c4c14bad0eeec3b5cbc01107a99554f9748748786e7919dba3546ac82d286e379440db73b",
                Status = "429c8e7b1c6f4fa98bf9e7fa81c006b7b82ef78052d94b5282",
                Matching = true
            };

            // Act
            var serviceResult = await _userMainsAppService.UpdateAsync(Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"), input);

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserId.ShouldBe(Guid.Parse("3592a1a5-41a3-45a7-b9db-d1d2656c1e31"));
            result.Name.ShouldBe("55253303cfd5453390f6469a4fb0a6cf5d7c9088823e46e0bc");
            result.AnonymousName.ShouldBe("fc344ecc4b954b2da1e4ff99f3bd009988fc8e56dee94c6c9b");
            result.LoginAccountCode.ShouldBe("9338cade8dd4464f81c8bd07b1a8afb668e5b89a3c694c61a7");
            result.LoginMobilePhoneUpdate.ShouldBe("ae92e770f7f548d285a20d13aff7c8d59aea4785dc0e476599");
            result.LoginMobilePhone.ShouldBe("b50b38c6ad2947c58c76a5bf044ed2a6b3122f14a25f42d184");
            result.LoginEmailUpdate.ShouldBe("b0d21f11659946e7b9b7f269fb7a4b959489cdf227aa4ababc1ec9a3794d569de0bea68efc4544578eed2bbcd72c2f2ab7f16c2d6b7242069c6ae5ab8bdcbad1f23cc007de70486db07800cc9c1780a874b0881282d04bf4be4ecd9b87b6b89e8fbb661c");
            result.LoginEmail.ShouldBe("1e5e52363e844a7e8053af4e8f4cdaf0f32cc0c9f1b44afe87faf13f9e3250a88149b2e0a4ad4ae0b10ab0559ce70319dd514b43420d461d9b99aa2ca98111851d824f6770c441c1a14258a78d085e5271aab19ab54c48299f77fafeba19c7e301deb55b");
            result.LoginIdentityNo.ShouldBe("90baef30339c48e799fdd206fccf06177683e502315042799d");
            result.Password.ShouldBe("77eb1d4a294540f3825415e3a85a308e007c50d34d41447d85261737ef04d199d1f56d314b8247cc8ec537a15b6c7a40e0fd933fabe64e8c9d98e4b3e73a9b353e0dc6e17ab14c19b61eb25d6385675b64b3da16736b4b6dbd59a4053790baa4da9c77af");
            result.SystemUserRoleKeys.ShouldBe(334161177);
            result.AllowSearch.ShouldBe(true);
            result.DateA.ShouldBe(new DateTime(2006, 5, 20));
            result.ExtendedInformation.ShouldBe("6740f516c9e84391a4e681466c52a2570c5af9213de04c0aa574b5919c1548f9b70d459a4df24861b7dad64cf4c36da59bd6fc5656cf46c19fb89c30c22721223f141b2e9b0643f9bce5f644daca344cbe798d5d30ff4052a6f2dee9884fee2ffeec1802957c45e7a91b19d305ac5f2732e2135f64fd4a7da9ca4785b3ea7e4ac8201a644ed4476186478364e3c85e946f1518b88c684e19883164f971b1fefe6d188d558c93482980aeef67f31648cbd082a8f6ceb54682abe756b1bbb5742a431aee7acd3847929e0cb7400a64518d6ae056673e59440bbf9c0826364e0b28b073772e94cd43a1bdf37309a92001403aa57966c021434abb0a");
            result.DateD.ShouldBe(new DateTime(2012, 3, 20));
            result.Sort.ShouldBe(1841182579);
            result.Note.ShouldBe("f3ccb8063b2f456c851733432f1aadeab0c1a9c3951b4d5899b205e6f08af9c61d7441c40a3542dc806d4f6cd72d8afa3b4bfa324ab04af0a124f692fea92ee636cf4e2abe0046e3bfd0d0f1e48b487f9b846056cc3d4cd9a32a992616cb0df76dd74dc9f9c44b3d88a65ac121919f47b2f8dd7d765f4973926c0038870530e015237f5a1ff1410caaa7faa571cdc7f3ffc4a5ab90284d9396d02d479635fa5af7f8aaae3ea644c580f3bdf89288e5e1d51c71322dc94bff9543439940ab829517b335ad2dea4119aea23788a62e6447bfd6b259058c4c14bad0eeec3b5cbc01107a99554f9748748786e7919dba3546ac82d286e379440db73b");
            result.Status.ShouldBe("429c8e7b1c6f4fa98bf9e7fa81c006b7b82ef78052d94b5282");
            result.Matching.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userMainsAppService.DeleteAsync(Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"));

            // Assert
            var result = await _userMainRepository.FindAsync(c => c.Id == Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"));

            result.ShouldBeNull();
        }
    }
}