using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeDependentssAppService _resumeDependentssAppService;
        private readonly IRepository<ResumeDependents, Guid> _resumeDependentsRepository;

        public ResumeDependentssAppServiceTests()
        {
            _resumeDependentssAppService = GetRequiredService<IResumeDependentssAppService>();
            _resumeDependentsRepository = GetRequiredService<IRepository<ResumeDependents, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeDependentssAppService.GetListAsync(new GetResumeDependentssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("4d423bad-e63a-415b-a198-4485d0faf423")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeDependentssAppService.GetAsync(Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeDependentsCreateDto
            {
                ResumeMainId = Guid.Parse("33779d6c-7ba2-4d2d-a6a6-0a8c9f16a8d8"),
                Name = "b4d05d74b683459090dcefb25f0c3bd35b849028336f499c91",
                IdentityNo = "df3dd40beff24c328784d58900646cb74af96ed5d3c7456aa0",
                KinshipCode = "10e44731bfc94365a47e558fc49555244fb528340b394686b0",
                BirthDate = new DateTime(2012, 5, 22),
                Address = "d3249256f5cb4c4f892f403b2cc73385769cf3c4fd014ae6a902bd4b27d63d7a77f1824087984a9c832bbcb5e748a84f47a5a79d953547bf97e173e3b2738ad8376c653b060b4feaa297e238ad309a8e6088f06e45e34ae3bc18f064036b8254d2c911ec",
                MobilePhone = "5380c216ef2e48abbe297c4c4d869f1e20cf4a5c755c4282b9",
                ExtendedInformation = "15dbdf9fb39849b08920a1f3e5bffc7e39bd1a52f72e45109ef96f25164f74494a5c6fb9999143deaca07fea5b8136b4815b4761172e4b29a124b1b9a004a229f1560c78130a482cbb07b209d022d31fa8ee3b31b3b044968e476fdd4690a37e4f305f2fab994deaa1a852e5c377e3547d9e96e11964484c888a7d8fb3bc4942c89ceb6fa11b41a880703156a6a40f9448084ab4904c463b825278987eef7d99fcdd1620912944a5b0e25d3ad592ba8146c2929a5f5a41f087f2da3179fb20d56256cdc3bf414d109be7d916ff361534d841a81bf254447d858c6ca348bba587515dd7ae85334ca2a599f3fa0371367580e44b375df04cc583e5",
                DateA = new DateTime(2009, 8, 2),
                DateD = new DateTime(2007, 10, 8),
                Sort = 494991648,
                Note = "b4c395ccb6cc482fbe583038ad47723421c80087ee6b446b954482840ce5ec366a33356503884425b8750fa93eb2b35a282438a08e954bd6bab22cb451a797a0fafc2a75231b4ec0a3c98bb9f4038cfa0a19d87817da4e599ae939b39ed357796d2efbcf3a694bd3a8c8fc5753451f9289f53c887eeb48bebe00aec86ab3ede39fb97f6593964f68a4b536cd7e4d6662a7b7f736285d4440bc7db1bd06bd20e2f1022f5e87c04a9b8f103c0a17547f45c5947fa3beb24d72a17bcebf944b1f328bba6c308df44b938cb66b5fdb80597b56f4c1f1c19747c3a15c3a0fbe986c92a0a9da295c4e4ae8baf10ba33209b55ea5c609ae1b0b42cbb337",
                Status = "7fdf13adf698407796e32c24a0e9aa511bab4029d7fc4004a2"
            };

            // Act
            var serviceResult = await _resumeDependentssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("33779d6c-7ba2-4d2d-a6a6-0a8c9f16a8d8"));
            result.Name.ShouldBe("b4d05d74b683459090dcefb25f0c3bd35b849028336f499c91");
            result.IdentityNo.ShouldBe("df3dd40beff24c328784d58900646cb74af96ed5d3c7456aa0");
            result.KinshipCode.ShouldBe("10e44731bfc94365a47e558fc49555244fb528340b394686b0");
            result.BirthDate.ShouldBe(new DateTime(2012, 5, 22));
            result.Address.ShouldBe("d3249256f5cb4c4f892f403b2cc73385769cf3c4fd014ae6a902bd4b27d63d7a77f1824087984a9c832bbcb5e748a84f47a5a79d953547bf97e173e3b2738ad8376c653b060b4feaa297e238ad309a8e6088f06e45e34ae3bc18f064036b8254d2c911ec");
            result.MobilePhone.ShouldBe("5380c216ef2e48abbe297c4c4d869f1e20cf4a5c755c4282b9");
            result.ExtendedInformation.ShouldBe("15dbdf9fb39849b08920a1f3e5bffc7e39bd1a52f72e45109ef96f25164f74494a5c6fb9999143deaca07fea5b8136b4815b4761172e4b29a124b1b9a004a229f1560c78130a482cbb07b209d022d31fa8ee3b31b3b044968e476fdd4690a37e4f305f2fab994deaa1a852e5c377e3547d9e96e11964484c888a7d8fb3bc4942c89ceb6fa11b41a880703156a6a40f9448084ab4904c463b825278987eef7d99fcdd1620912944a5b0e25d3ad592ba8146c2929a5f5a41f087f2da3179fb20d56256cdc3bf414d109be7d916ff361534d841a81bf254447d858c6ca348bba587515dd7ae85334ca2a599f3fa0371367580e44b375df04cc583e5");
            result.DateA.ShouldBe(new DateTime(2009, 8, 2));
            result.DateD.ShouldBe(new DateTime(2007, 10, 8));
            result.Sort.ShouldBe(494991648);
            result.Note.ShouldBe("b4c395ccb6cc482fbe583038ad47723421c80087ee6b446b954482840ce5ec366a33356503884425b8750fa93eb2b35a282438a08e954bd6bab22cb451a797a0fafc2a75231b4ec0a3c98bb9f4038cfa0a19d87817da4e599ae939b39ed357796d2efbcf3a694bd3a8c8fc5753451f9289f53c887eeb48bebe00aec86ab3ede39fb97f6593964f68a4b536cd7e4d6662a7b7f736285d4440bc7db1bd06bd20e2f1022f5e87c04a9b8f103c0a17547f45c5947fa3beb24d72a17bcebf944b1f328bba6c308df44b938cb66b5fdb80597b56f4c1f1c19747c3a15c3a0fbe986c92a0a9da295c4e4ae8baf10ba33209b55ea5c609ae1b0b42cbb337");
            result.Status.ShouldBe("7fdf13adf698407796e32c24a0e9aa511bab4029d7fc4004a2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeDependentsUpdateDto()
            {
                ResumeMainId = Guid.Parse("683f280a-c37a-4ad2-aad0-113e4d0a1c7e"),
                Name = "c4aac147ba9f47a68412807a8b2dea56705cbedfea6648a6a4",
                IdentityNo = "f6de2afc51364d9ca4c39157230721a9954a07fa746c4b4282",
                KinshipCode = "e29c1f1d20be4f4d81e1aa6aeae5923e77bed46717bc4cf7ac",
                BirthDate = new DateTime(2004, 3, 6),
                Address = "12908060b9f24114ba43791c82c5ab3ee0d73cc83bce480080b97b8830ba27a902a506d67cf8445c8979b827e71e35f12f6f886a6fe9482dacbe09f03165bfc81de84920508d436bbdc1e755c8b815bca5a3fa557aa14e72a5d23caef38954d2864965b0",
                MobilePhone = "c5a4c3d3ac754652b06892675838615887af6fe24d0c4e229e",
                ExtendedInformation = "9ae6f6e57c9747b08c08802e8a62c279a48a8b23b09349048951d02a648a422e3e38270938e140ed9ef2681d4f7ae6491fbd0a52747244dcb7aa1dc9dbf65280a126c19a608246958500dda819b585583418d66914b3453987020e66526e7b522d20bb3fb3eb4bd1b62c7ab9ae912c34922434bfa60747a2920d2582c06b5ccc74345d1c1bdb42118cd0abda3edfc0db39ebce7715c74b7aadfb9ebb759f28eb219b0850fbdf413ca40d8b46cf77b9d4f87ec58864be4f049a4489e0062fa43b88b7c65cc73c4283bcc3c0b12421b38967c0867b328e4edaae5abd4531bc2b02762ebccddeb04a47b9bdcf6baa069227b59a1385cd0349e295da",
                DateA = new DateTime(2021, 1, 17),
                DateD = new DateTime(2014, 1, 3),
                Sort = 399685784,
                Note = "e1a972f3d475424cbb30d24da355d6253881df183ca04a92b2d6556e83b51f6973ffb7371a2a4ec580bbdb780ae60783cc89ffe462864e179f6aefb8a9d354c3df0ac1e1e1344e68a397cf1a751e2542cebf0b266b7a48979b99aa108711033ce731c831fd554692a8eaaf1460fd52ba3d21a4509f8f48efba8dfd9399be33562372e734f0924c12b97ac646dc8988a787ddc4eaedee4cfcb08885453a48d822695ad7ebd02343edb2b812eb067803528be743a5c00e4bf899888cdfe08b8946f59cf59ccde748cbaeca16dab640ea4ae494ae0fdaf64e79b2e9d7f91a686277f7cb3d52291b4c639451c1e82d5a17741f982fed889945a68385",
                Status = "1025d76a3a454065954b04a88c2c521239899072c91a48df94"
            };

            // Act
            var serviceResult = await _resumeDependentssAppService.UpdateAsync(Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"), input);

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("683f280a-c37a-4ad2-aad0-113e4d0a1c7e"));
            result.Name.ShouldBe("c4aac147ba9f47a68412807a8b2dea56705cbedfea6648a6a4");
            result.IdentityNo.ShouldBe("f6de2afc51364d9ca4c39157230721a9954a07fa746c4b4282");
            result.KinshipCode.ShouldBe("e29c1f1d20be4f4d81e1aa6aeae5923e77bed46717bc4cf7ac");
            result.BirthDate.ShouldBe(new DateTime(2004, 3, 6));
            result.Address.ShouldBe("12908060b9f24114ba43791c82c5ab3ee0d73cc83bce480080b97b8830ba27a902a506d67cf8445c8979b827e71e35f12f6f886a6fe9482dacbe09f03165bfc81de84920508d436bbdc1e755c8b815bca5a3fa557aa14e72a5d23caef38954d2864965b0");
            result.MobilePhone.ShouldBe("c5a4c3d3ac754652b06892675838615887af6fe24d0c4e229e");
            result.ExtendedInformation.ShouldBe("9ae6f6e57c9747b08c08802e8a62c279a48a8b23b09349048951d02a648a422e3e38270938e140ed9ef2681d4f7ae6491fbd0a52747244dcb7aa1dc9dbf65280a126c19a608246958500dda819b585583418d66914b3453987020e66526e7b522d20bb3fb3eb4bd1b62c7ab9ae912c34922434bfa60747a2920d2582c06b5ccc74345d1c1bdb42118cd0abda3edfc0db39ebce7715c74b7aadfb9ebb759f28eb219b0850fbdf413ca40d8b46cf77b9d4f87ec58864be4f049a4489e0062fa43b88b7c65cc73c4283bcc3c0b12421b38967c0867b328e4edaae5abd4531bc2b02762ebccddeb04a47b9bdcf6baa069227b59a1385cd0349e295da");
            result.DateA.ShouldBe(new DateTime(2021, 1, 17));
            result.DateD.ShouldBe(new DateTime(2014, 1, 3));
            result.Sort.ShouldBe(399685784);
            result.Note.ShouldBe("e1a972f3d475424cbb30d24da355d6253881df183ca04a92b2d6556e83b51f6973ffb7371a2a4ec580bbdb780ae60783cc89ffe462864e179f6aefb8a9d354c3df0ac1e1e1344e68a397cf1a751e2542cebf0b266b7a48979b99aa108711033ce731c831fd554692a8eaaf1460fd52ba3d21a4509f8f48efba8dfd9399be33562372e734f0924c12b97ac646dc8988a787ddc4eaedee4cfcb08885453a48d822695ad7ebd02343edb2b812eb067803528be743a5c00e4bf899888cdfe08b8946f59cf59ccde748cbaeca16dab640ea4ae494ae0fdaf64e79b2e9d7f91a686277f7cb3d52291b4c639451c1e82d5a17741f982fed889945a68385");
            result.Status.ShouldBe("1025d76a3a454065954b04a88c2c521239899072c91a48df94");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeDependentssAppService.DeleteAsync(Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"));

            // Assert
            var result = await _resumeDependentsRepository.FindAsync(c => c.Id == Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"));

            result.ShouldBeNull();
        }
    }
}