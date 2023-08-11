using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyInvitationsCodesAppService _companyInvitationsCodesAppService;
        private readonly IRepository<CompanyInvitationsCode, Guid> _companyInvitationsCodeRepository;

        public CompanyInvitationsCodesAppServiceTests()
        {
            _companyInvitationsCodesAppService = GetRequiredService<ICompanyInvitationsCodesAppService>();
            _companyInvitationsCodeRepository = GetRequiredService<IRepository<CompanyInvitationsCode, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetListAsync(new GetCompanyInvitationsCodesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("d748a59c-81e7-45c6-925a-c290fbe552ff")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetAsync(Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeCreateDto
            {
                CompanyMainId = Guid.Parse("10cb19a3-7ce7-462b-8b9a-3ed1ccb52fb6"),
                CompanyJobId = Guid.Parse("ed4fd594-3692-49b8-bbcf-ee84b9163bd9"),
                CompanyInvitationId = "e7c7771d38084bbd9f8ef19038a8a29a205f87bc559e4243b6",
                VerifyId = "49801eaa19ad429484f97ef39189226ac68080aa6a7b41558e88436c2266e3ab5ef2c822c18c4c19a5f14e3af37dccf5fa6f9e7e4aab4a28848997d3126d6c05525c2742207f46368f23c7017f0319b88b429c5d0a07436e8a78dbec56123bbc5c8b270347814b13bdac904b34e90d452049c284a8cd415fa34a1c3d6fa10147e6e906ab6b2a4463a5ebccf129f00dc4626468935acd4aa8a6d55a3f9467ccde15761e31d41a4faaab46825284fadcbec0739f1162bd42d0997dff0a0b1da122162c144ef8ed43e2b9373c3f0e73663fdb602cc60f6146f2ab77052ee729f87c87f9d568fe6f4c3985fde7bfc6dade2ae1f3b38b0ee548a0b180",
                VerifyCode = "f5789404537f43dfb0a1b2b11e8177c1476681f357d8458291",
                ExtendedInformation = "0bd857d63af24d3c89a58fa3032de1d936b5c76ca601452f9317ae0a03c0e170b83e6a46a31246048e618ed66fd2980ffc3dba67a53f4f5ebef7bc0d4c64dab3d1c8f235a26744599bdea86643f6df40a224e7ca5a0e418985fd28f052166c1e8a83135bd32e423da7fdcaca17d5953f06af00ccf3c945f595ca9984a7241c92837961cd2f9341479e5586bc96cfba24e88815b25cea4fe78392c11918716ba8e81cea4421cf4bef8785cdb602f88f51b4d7f670de7f44c399dfafd230fb3c1db4306db709a643d1bc69d701309d8d88dc772e2ca3cd4df490bb56920bd61b27c942bde8e905408c8c3cb5157ed940fa81c0a251eb1d4b8cbfd2",
                DateA = new DateTime(2007, 10, 2),
                DateD = new DateTime(2005, 3, 24),
                Sort = 1468908591,
                Note = "a751b322ae7e419e8d98f95330fdaec41bcc1fd01a0a4af6aa0d4b998bb79b884ad08f8bb29148f5b8f184838a0d3490a6cab9511ff04f80b741c9efc7f43fc451238fd9616e4cc588953a469cc60e889de4c7b52f634430b2df06df7af9b905c60d245407424c218f7abea6a93de9cafa69cee92e2b4f419d7bd21835d3c9ac5312242eb201476e87d74f14a07a120267c83eccafc6462a9988070fc86bdc4bcdd64d8d59144ea6bada700dc3c2e2d54738b6e9cb704d4fbb78dbd72166a3611f46dd6a6ac14f279ea0208bf02a42a9f9a40d07f6d449c29e334f13430e9d346fd9602d9af940a7bb1f52c85460d1cd5655cfb94f3c477b947e",
                Status = "58970e1d67174917be640795e0efaecea67aac06b0184c7180"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("10cb19a3-7ce7-462b-8b9a-3ed1ccb52fb6"));
            result.CompanyJobId.ShouldBe(Guid.Parse("ed4fd594-3692-49b8-bbcf-ee84b9163bd9"));
            result.CompanyInvitationId.ShouldBe("e7c7771d38084bbd9f8ef19038a8a29a205f87bc559e4243b6");
            result.VerifyId.ShouldBe("49801eaa19ad429484f97ef39189226ac68080aa6a7b41558e88436c2266e3ab5ef2c822c18c4c19a5f14e3af37dccf5fa6f9e7e4aab4a28848997d3126d6c05525c2742207f46368f23c7017f0319b88b429c5d0a07436e8a78dbec56123bbc5c8b270347814b13bdac904b34e90d452049c284a8cd415fa34a1c3d6fa10147e6e906ab6b2a4463a5ebccf129f00dc4626468935acd4aa8a6d55a3f9467ccde15761e31d41a4faaab46825284fadcbec0739f1162bd42d0997dff0a0b1da122162c144ef8ed43e2b9373c3f0e73663fdb602cc60f6146f2ab77052ee729f87c87f9d568fe6f4c3985fde7bfc6dade2ae1f3b38b0ee548a0b180");
            result.VerifyCode.ShouldBe("f5789404537f43dfb0a1b2b11e8177c1476681f357d8458291");
            result.ExtendedInformation.ShouldBe("0bd857d63af24d3c89a58fa3032de1d936b5c76ca601452f9317ae0a03c0e170b83e6a46a31246048e618ed66fd2980ffc3dba67a53f4f5ebef7bc0d4c64dab3d1c8f235a26744599bdea86643f6df40a224e7ca5a0e418985fd28f052166c1e8a83135bd32e423da7fdcaca17d5953f06af00ccf3c945f595ca9984a7241c92837961cd2f9341479e5586bc96cfba24e88815b25cea4fe78392c11918716ba8e81cea4421cf4bef8785cdb602f88f51b4d7f670de7f44c399dfafd230fb3c1db4306db709a643d1bc69d701309d8d88dc772e2ca3cd4df490bb56920bd61b27c942bde8e905408c8c3cb5157ed940fa81c0a251eb1d4b8cbfd2");
            result.DateA.ShouldBe(new DateTime(2007, 10, 2));
            result.DateD.ShouldBe(new DateTime(2005, 3, 24));
            result.Sort.ShouldBe(1468908591);
            result.Note.ShouldBe("a751b322ae7e419e8d98f95330fdaec41bcc1fd01a0a4af6aa0d4b998bb79b884ad08f8bb29148f5b8f184838a0d3490a6cab9511ff04f80b741c9efc7f43fc451238fd9616e4cc588953a469cc60e889de4c7b52f634430b2df06df7af9b905c60d245407424c218f7abea6a93de9cafa69cee92e2b4f419d7bd21835d3c9ac5312242eb201476e87d74f14a07a120267c83eccafc6462a9988070fc86bdc4bcdd64d8d59144ea6bada700dc3c2e2d54738b6e9cb704d4fbb78dbd72166a3611f46dd6a6ac14f279ea0208bf02a42a9f9a40d07f6d449c29e334f13430e9d346fd9602d9af940a7bb1f52c85460d1cd5655cfb94f3c477b947e");
            result.Status.ShouldBe("58970e1d67174917be640795e0efaecea67aac06b0184c7180");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeUpdateDto()
            {
                CompanyMainId = Guid.Parse("4a89518b-c4f9-4145-85eb-65d7e46247e4"),
                CompanyJobId = Guid.Parse("3dd9270f-3dc7-416b-b66e-04c9f04d8fd6"),
                CompanyInvitationId = "c2d2a26edc0f4923a943de5f38486026457ba51adeb4405faa",
                VerifyId = "81a5f346474c4bd6a5e29133c9a607dd69838965aa674e83af16d2a8dd93bfdab4d43010834042e8b15170b61b5478f667a78b2d24944a258dc1e3251a50c4c8e66746ac4d78441589be5646af7a56b0b9bba746c0ce4fe78bf4a1a402784ddf45d459ff258d4bc28ea996092a7c5b015c7648fb46a24f46b94450138e9a02efcd1e3d35e02a4a4d82da3bebac4dd03a7523490c0fd644d0bc40f9719b22cd1fbf08121c77f646d9afe124fe7dcfb83dc1eba407e3464d3f9933d97710a71a9efe05fc19cd254b77acbe7979e6b1c9a21d210111e394407685081963d300fb9efb1df6f9a16b467fa9aa87fcbc43a678e353fa2c643844119bd4",
                VerifyCode = "bbb96d7135cd4d5cafcefa0120620878841bd20ea42945c3a7",
                ExtendedInformation = "fdf70da0b4474b6eafd4c5c73a50598954a496e74ca64c65b4af7c8552ec6dbb5bf047ff3a6c46b7b005062319309260f607527557154e2daf2b0428bbc34592b9c7357bf0bc4c0f8e0e6d97b2a763a28cc25807d3d144419f583cd818106ca70a0bcf94043f4e4a930dd02e1eed7ff8acb01e5f8cdb4924b3d6df9bb00b47345011fb4dea674e74bd9b1d6138ab7aec1bfd9e60e218414aa2d6a9074885d8f9e944efce348a4273ba21d6d604148530948c596cfcfd4e7282112db139ef4fa8f226ad2bc3894e3c90edce272d5af6561f94d28967b24e28a778027ceb33127d3c1d862e0f814ed688197c1a62f51329091e06894c004fbda32b",
                DateA = new DateTime(2007, 1, 9),
                DateD = new DateTime(2009, 10, 9),
                Sort = 1419878680,
                Note = "81725980655b49db8d23f560b81e8a66a6ba2a23ed114d5086b0cade0ebfd7f5df5b18b332da4ae1b6bba68e06036a67f9c63fd1cd9c42a89195e083790026abdd12ff7cecd14ccfafa0bb353f7bb8a1feb8176b38f64dea98076af0b2a301bc26376a36a73e4064b8ea523a9a8735d4d6bc799344c84e16bfa487a44ae61bb50ac0930210514b7b828763f69bd86d3cd4fabf99371d422080ea30c087d286718276ca284f9a4c9090c1e2263d4f8ecdd5fdafdbce954f059c339703726fdeae1a43a260324449309e07d0cefd5915fa504187a7cada4bac99ccda49495ac58df47d5354cd734b91965064bba552548e7da5b9a66fe345769d8c",
                Status = "d011e50ca59d440c965d03fad4b430dd4219e220fc574b6fb8"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.UpdateAsync(Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"), input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("4a89518b-c4f9-4145-85eb-65d7e46247e4"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3dd9270f-3dc7-416b-b66e-04c9f04d8fd6"));
            result.CompanyInvitationId.ShouldBe("c2d2a26edc0f4923a943de5f38486026457ba51adeb4405faa");
            result.VerifyId.ShouldBe("81a5f346474c4bd6a5e29133c9a607dd69838965aa674e83af16d2a8dd93bfdab4d43010834042e8b15170b61b5478f667a78b2d24944a258dc1e3251a50c4c8e66746ac4d78441589be5646af7a56b0b9bba746c0ce4fe78bf4a1a402784ddf45d459ff258d4bc28ea996092a7c5b015c7648fb46a24f46b94450138e9a02efcd1e3d35e02a4a4d82da3bebac4dd03a7523490c0fd644d0bc40f9719b22cd1fbf08121c77f646d9afe124fe7dcfb83dc1eba407e3464d3f9933d97710a71a9efe05fc19cd254b77acbe7979e6b1c9a21d210111e394407685081963d300fb9efb1df6f9a16b467fa9aa87fcbc43a678e353fa2c643844119bd4");
            result.VerifyCode.ShouldBe("bbb96d7135cd4d5cafcefa0120620878841bd20ea42945c3a7");
            result.ExtendedInformation.ShouldBe("fdf70da0b4474b6eafd4c5c73a50598954a496e74ca64c65b4af7c8552ec6dbb5bf047ff3a6c46b7b005062319309260f607527557154e2daf2b0428bbc34592b9c7357bf0bc4c0f8e0e6d97b2a763a28cc25807d3d144419f583cd818106ca70a0bcf94043f4e4a930dd02e1eed7ff8acb01e5f8cdb4924b3d6df9bb00b47345011fb4dea674e74bd9b1d6138ab7aec1bfd9e60e218414aa2d6a9074885d8f9e944efce348a4273ba21d6d604148530948c596cfcfd4e7282112db139ef4fa8f226ad2bc3894e3c90edce272d5af6561f94d28967b24e28a778027ceb33127d3c1d862e0f814ed688197c1a62f51329091e06894c004fbda32b");
            result.DateA.ShouldBe(new DateTime(2007, 1, 9));
            result.DateD.ShouldBe(new DateTime(2009, 10, 9));
            result.Sort.ShouldBe(1419878680);
            result.Note.ShouldBe("81725980655b49db8d23f560b81e8a66a6ba2a23ed114d5086b0cade0ebfd7f5df5b18b332da4ae1b6bba68e06036a67f9c63fd1cd9c42a89195e083790026abdd12ff7cecd14ccfafa0bb353f7bb8a1feb8176b38f64dea98076af0b2a301bc26376a36a73e4064b8ea523a9a8735d4d6bc799344c84e16bfa487a44ae61bb50ac0930210514b7b828763f69bd86d3cd4fabf99371d422080ea30c087d286718276ca284f9a4c9090c1e2263d4f8ecdd5fdafdbce954f059c339703726fdeae1a43a260324449309e07d0cefd5915fa504187a7cada4bac99ccda49495ac58df47d5354cd734b91965064bba552548e7da5b9a66fe345769d8c");
            result.Status.ShouldBe("d011e50ca59d440c965d03fad4b430dd4219e220fc574b6fb8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationsCodesAppService.DeleteAsync(Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"));

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"));

            result.ShouldBeNull();
        }
    }
}