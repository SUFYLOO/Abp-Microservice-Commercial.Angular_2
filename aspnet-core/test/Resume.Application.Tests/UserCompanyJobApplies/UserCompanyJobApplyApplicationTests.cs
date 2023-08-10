using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobAppliesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobAppliesAppService _userCompanyJobAppliesAppService;
        private readonly IRepository<UserCompanyJobApply, Guid> _userCompanyJobApplyRepository;

        public UserCompanyJobAppliesAppServiceTests()
        {
            _userCompanyJobAppliesAppService = GetRequiredService<IUserCompanyJobAppliesAppService>();
            _userCompanyJobApplyRepository = GetRequiredService<IRepository<UserCompanyJobApply, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetListAsync(new GetUserCompanyJobAppliesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0a3eca8e-4dbf-4616-a977-0262b438a1b0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobAppliesAppService.GetAsync(Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyCreateDto
            {
                UserMainId = Guid.Parse("6583ee68-7ca7-4f32-bf9e-53a684c3d89d"),
                CompanyJobId = Guid.Parse("158fe5e8-cc20-4c9c-a850-3ec627fc1fdc"),
                ExtendedInformation = "03e5283503b743aeaaf946ab1ef1364c9aa816eaf416465b9fc300db76e3608e89b6e92ebc274c7a94c0d40ad44dca370622ee4f09d649df8d634a72624c1178eee1a2696ee6497a814a7485c20f4626e7f7d75141a6469e9864b0811d8a5e54bf7ccb2fdd88458bb22a61e3532f3b1e0855cf4b850642a98bb01831858b98debecf751f9a554566958708d4018faf1ac9b6a8881e744a37b1391370d9deed5cd20abadad27b48c9bde7eae729e21d31f03479fa4b354ef8b7f8c40c14713555ec77eede370c4f24ac3604f6b8e915fa6407c6375377432d82327d788480b6f993ffb24862734a2fa21fc1ade603d19ab8153c4c72324ab2870e",
                DateA = new DateTime(2002, 5, 5),
                DateD = new DateTime(2019, 3, 22),
                Sort = 1112956181,
                Note = "37fe47e30fd14a579d80c839989453fb12f72a26c9a347cc9c4ee5dd126a5c6b6dd4e3984c344c5f8741cc55e69d856ff05347692020401097122f69238c8e46a722388a2f154b74b836d6916ca26cbd6dbbc1f6f2834307b4640a2264bbe4cc0f88868ebdae4f7197413f174d1362e2e367a01ea93f4a4abaec544c3e0067c085abade017df4ffbb47a86753571cf009ea636ad9344404bbefe0d1f82358f5ee46dc412ded444979597d2e41a17bfbd66d73af665bf400e843c36c20db473777a408dd999c241bc815fc356b14657707599a7207aad47d2bbd2f171a4537af0aa27cd28952e4889b41c238123218e1aa7e332d646e548aa8c24",
                Status = "29c86fe0a5c8443a90e78363cb6bc7f2831641b323eb41469b"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("6583ee68-7ca7-4f32-bf9e-53a684c3d89d"));
            result.CompanyJobId.ShouldBe(Guid.Parse("158fe5e8-cc20-4c9c-a850-3ec627fc1fdc"));
            result.ExtendedInformation.ShouldBe("03e5283503b743aeaaf946ab1ef1364c9aa816eaf416465b9fc300db76e3608e89b6e92ebc274c7a94c0d40ad44dca370622ee4f09d649df8d634a72624c1178eee1a2696ee6497a814a7485c20f4626e7f7d75141a6469e9864b0811d8a5e54bf7ccb2fdd88458bb22a61e3532f3b1e0855cf4b850642a98bb01831858b98debecf751f9a554566958708d4018faf1ac9b6a8881e744a37b1391370d9deed5cd20abadad27b48c9bde7eae729e21d31f03479fa4b354ef8b7f8c40c14713555ec77eede370c4f24ac3604f6b8e915fa6407c6375377432d82327d788480b6f993ffb24862734a2fa21fc1ade603d19ab8153c4c72324ab2870e");
            result.DateA.ShouldBe(new DateTime(2002, 5, 5));
            result.DateD.ShouldBe(new DateTime(2019, 3, 22));
            result.Sort.ShouldBe(1112956181);
            result.Note.ShouldBe("37fe47e30fd14a579d80c839989453fb12f72a26c9a347cc9c4ee5dd126a5c6b6dd4e3984c344c5f8741cc55e69d856ff05347692020401097122f69238c8e46a722388a2f154b74b836d6916ca26cbd6dbbc1f6f2834307b4640a2264bbe4cc0f88868ebdae4f7197413f174d1362e2e367a01ea93f4a4abaec544c3e0067c085abade017df4ffbb47a86753571cf009ea636ad9344404bbefe0d1f82358f5ee46dc412ded444979597d2e41a17bfbd66d73af665bf400e843c36c20db473777a408dd999c241bc815fc356b14657707599a7207aad47d2bbd2f171a4537af0aa27cd28952e4889b41c238123218e1aa7e332d646e548aa8c24");
            result.Status.ShouldBe("29c86fe0a5c8443a90e78363cb6bc7f2831641b323eb41469b");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobApplyUpdateDto()
            {
                UserMainId = Guid.Parse("c18b3d4a-dc71-474f-9ec5-b27a86afd447"),
                CompanyJobId = Guid.Parse("b3d645a8-1ed7-42be-bd33-c6eeab02d5f6"),
                ExtendedInformation = "cfe64bb691fb468694845bf23a5285f931a28024143844f39e039cc3c57a39fa86d9cc01c5774693bdae2e0abd1ecc945c3dcaa0865a48a3b22c7209de993e703fe5c73597a240ee9de9093959e048c05843bf30716243f692e0785910fb607f3fa0bf9eadc6423f89e7ef6b7681e0c3effa1d5fd1154595b14b8f0582d134c196887c804f0b4009b7e4d0db18e44bdddf6c97ddfe8443dabf40d3878fc7cf4e9c27e80a7281421f89c47f3e69ff3877e9620209fec5406c9d34f9fc9eaf21bfdff2e28cd5d944b1bf97a87d059ee3b8760ba848f7354e348fd3bb8aa39ac2c0cdd1e9d981b34a50b9282644374c5166ea29121c558841f69eb7",
                DateA = new DateTime(2005, 2, 24),
                DateD = new DateTime(2011, 3, 16),
                Sort = 1051717660,
                Note = "fe7229f6ee7342d28121aa3d77a3a8bbba5d5b45ff27447998e76dfb5a023b428c1308fad3be462ea7c2be2fece5ac5cf75edfa324dd428f826cf0a5cdb29fbb69a57428dd78447cba2081090b4fd228cb0d2e2f17304e259b4ab2e75c44d91bbb4fad343e1447a68b0089d4383aaa076d872046355d4639a1c74eb5299655a2e7b64cde0db3491c81e441b83c202f38993275a0603b4820b0a3c2546053a9552099eaba336343318fcaddc54fb309a26297d9583ae443c8a8c76ffbb90372a9436946dbc72242b89c5b0a639ad6521ae201f9b8fd724b528141173bb46bbc58cd7f6386073f4384a7dc5bf63bd6c7284613065574b8484cafa1",
                Status = "9e17e54cdd644cc195c672311637b5107c6429d64ba24e159a"
            };

            // Act
            var serviceResult = await _userCompanyJobAppliesAppService.UpdateAsync(Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"), input);

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("c18b3d4a-dc71-474f-9ec5-b27a86afd447"));
            result.CompanyJobId.ShouldBe(Guid.Parse("b3d645a8-1ed7-42be-bd33-c6eeab02d5f6"));
            result.ExtendedInformation.ShouldBe("cfe64bb691fb468694845bf23a5285f931a28024143844f39e039cc3c57a39fa86d9cc01c5774693bdae2e0abd1ecc945c3dcaa0865a48a3b22c7209de993e703fe5c73597a240ee9de9093959e048c05843bf30716243f692e0785910fb607f3fa0bf9eadc6423f89e7ef6b7681e0c3effa1d5fd1154595b14b8f0582d134c196887c804f0b4009b7e4d0db18e44bdddf6c97ddfe8443dabf40d3878fc7cf4e9c27e80a7281421f89c47f3e69ff3877e9620209fec5406c9d34f9fc9eaf21bfdff2e28cd5d944b1bf97a87d059ee3b8760ba848f7354e348fd3bb8aa39ac2c0cdd1e9d981b34a50b9282644374c5166ea29121c558841f69eb7");
            result.DateA.ShouldBe(new DateTime(2005, 2, 24));
            result.DateD.ShouldBe(new DateTime(2011, 3, 16));
            result.Sort.ShouldBe(1051717660);
            result.Note.ShouldBe("fe7229f6ee7342d28121aa3d77a3a8bbba5d5b45ff27447998e76dfb5a023b428c1308fad3be462ea7c2be2fece5ac5cf75edfa324dd428f826cf0a5cdb29fbb69a57428dd78447cba2081090b4fd228cb0d2e2f17304e259b4ab2e75c44d91bbb4fad343e1447a68b0089d4383aaa076d872046355d4639a1c74eb5299655a2e7b64cde0db3491c81e441b83c202f38993275a0603b4820b0a3c2546053a9552099eaba336343318fcaddc54fb309a26297d9583ae443c8a8c76ffbb90372a9436946dbc72242b89c5b0a639ad6521ae201f9b8fd724b528141173bb46bbc58cd7f6386073f4384a7dc5bf63bd6c7284613065574b8484cafa1");
            result.Status.ShouldBe("9e17e54cdd644cc195c672311637b5107c6429d64ba24e159a");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobAppliesAppService.DeleteAsync(Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"));

            // Assert
            var result = await _userCompanyJobApplyRepository.FindAsync(c => c.Id == Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"));

            result.ShouldBeNull();
        }
    }
}