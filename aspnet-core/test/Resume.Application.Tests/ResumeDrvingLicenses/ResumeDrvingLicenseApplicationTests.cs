using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicensesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeDrvingLicensesAppService _resumeDrvingLicensesAppService;
        private readonly IRepository<ResumeDrvingLicense, Guid> _resumeDrvingLicenseRepository;

        public ResumeDrvingLicensesAppServiceTests()
        {
            _resumeDrvingLicensesAppService = GetRequiredService<IResumeDrvingLicensesAppService>();
            _resumeDrvingLicenseRepository = GetRequiredService<IRepository<ResumeDrvingLicense, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeDrvingLicensesAppService.GetListAsync(new GetResumeDrvingLicensesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("cfd2bcec-0fba-4f0c-ac3e-fd882691ea60")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeDrvingLicensesAppService.GetAsync(Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeDrvingLicenseCreateDto
            {
                ResumeMainId = Guid.Parse("d1fc0323-0d4f-497b-84cb-c1bdf0357a64"),
                DrvingLicenseCode = "d4b289acd31b4d2dadd8af76dd7892a50ff1d9477aed45d7ac",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "5dc69cd5dae148bba2d17e3f08ac85b11783c28a9ebb4922bd2e1cc77564071f11ff5258098a4449b725a0b5b610854591d4eef18ac04e8aa2c4a5ac246c33931fb44486573a42c0958cc6acba100e11b817d8dcb290414fb6f1b8377deef926fde583b0584746db88202d105ee412f85f6b9ae870e84591a5e20d29b3da6599989577015fae4155b5ab409c5e8e5af8e84d7365478946c49a8447222f817849628fe153a3104c53a05a6d6d5994e73a2fd418c5217b441d972ddc70c675a98b3d02698f6ac2490ebc9b73ca5aaf8b4b59820868f26c46c5831fd07b380bfb941466b7ba2475491388cd14a54989b29db323f6932a08408b9bb0",
                DateA = new DateTime(2012, 11, 14),
                DateD = new DateTime(2018, 4, 16),
                Sort = 1120083026,
                Note = "ece650a72fd344249ce2eaf8c44b0b4315e44d6d13634e17a00e1686d10dc16d359323ac7a2f429e81d160e6cbf8b6edfb794b46899f479a88a2afb1390b5aeccc2a0900e6864b1bb18a1b2a9e119d7f635f6f2d679149e7820420846c782ecaf8b35bd22f10431b850f62eb93ec972f721fb697106a49688042d4ec5784cd343e4ad6db27174d3ea69243d263cb6f36efbd9615ec5e4029acef3e2117889fcde3b7c13a857a41a88ebf2c209dd717376084774c55fe4feebe4df5750f024b70d15e5085ea624f43a4c845113b6b057edcd518201b4c45159a8a947cd48987d9907a685be5fc441388bf44d088f1eff13f240d47569c4359af6c",
                Status = "9d08b4c1fa084c09aed0c9f58b84a7f7b5b68b8bfb3847fc97"
            };

            // Act
            var serviceResult = await _resumeDrvingLicensesAppService.CreateAsync(input);

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("d1fc0323-0d4f-497b-84cb-c1bdf0357a64"));
            result.DrvingLicenseCode.ShouldBe("d4b289acd31b4d2dadd8af76dd7892a50ff1d9477aed45d7ac");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("5dc69cd5dae148bba2d17e3f08ac85b11783c28a9ebb4922bd2e1cc77564071f11ff5258098a4449b725a0b5b610854591d4eef18ac04e8aa2c4a5ac246c33931fb44486573a42c0958cc6acba100e11b817d8dcb290414fb6f1b8377deef926fde583b0584746db88202d105ee412f85f6b9ae870e84591a5e20d29b3da6599989577015fae4155b5ab409c5e8e5af8e84d7365478946c49a8447222f817849628fe153a3104c53a05a6d6d5994e73a2fd418c5217b441d972ddc70c675a98b3d02698f6ac2490ebc9b73ca5aaf8b4b59820868f26c46c5831fd07b380bfb941466b7ba2475491388cd14a54989b29db323f6932a08408b9bb0");
            result.DateA.ShouldBe(new DateTime(2012, 11, 14));
            result.DateD.ShouldBe(new DateTime(2018, 4, 16));
            result.Sort.ShouldBe(1120083026);
            result.Note.ShouldBe("ece650a72fd344249ce2eaf8c44b0b4315e44d6d13634e17a00e1686d10dc16d359323ac7a2f429e81d160e6cbf8b6edfb794b46899f479a88a2afb1390b5aeccc2a0900e6864b1bb18a1b2a9e119d7f635f6f2d679149e7820420846c782ecaf8b35bd22f10431b850f62eb93ec972f721fb697106a49688042d4ec5784cd343e4ad6db27174d3ea69243d263cb6f36efbd9615ec5e4029acef3e2117889fcde3b7c13a857a41a88ebf2c209dd717376084774c55fe4feebe4df5750f024b70d15e5085ea624f43a4c845113b6b057edcd518201b4c45159a8a947cd48987d9907a685be5fc441388bf44d088f1eff13f240d47569c4359af6c");
            result.Status.ShouldBe("9d08b4c1fa084c09aed0c9f58b84a7f7b5b68b8bfb3847fc97");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeDrvingLicenseUpdateDto()
            {
                ResumeMainId = Guid.Parse("4d44b561-23e1-46ff-8e87-494182c53f7d"),
                DrvingLicenseCode = "f5ddcfad8cf64ab6877ea51a830aa7bec0e386ab4efd48daa1",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "5b9c664416ef4c3aaf936e62650182991219522eb2a3438e854674ef654277741e6e2f0de03f47c29d1b9e3be4004b26bd4fdc8aa29a4a9da9b012d2bed682b02e6d878640d84281bf5e86cb62cdb5815b88355844c142d1a1c5640837c3aba534c18ed239544ffab2e6c510855c9fb2f8c8b9fd46a24ecdb97cf1bf6a599eddb6f0bac90ec64670bbc3a76a04e61cb7044391697f064e2b975193d43f088c446bb05f20eac4451b8feb5119b37e2246309421d63153479b8f32bdddb2bcab398323a001f66e4d1c973820e5352e63e273a51b98714144c8b11b4ff415f86d75e96f1e9da68040d7be78e6f8ad875e657939ee4a5446437c89bb",
                DateA = new DateTime(2019, 5, 15),
                DateD = new DateTime(2007, 4, 13),
                Sort = 2145560322,
                Note = "4259dad3312b4e43a8077e443e88d205b5048b3c7b9a47a8948f93434acb36432a4e5e9ffa0e4864bbc28f3e22a302d6dfead500e7854b85a633200d8d9db691cadd364b5e9b44c28d938bcfa89b702afd3efd67adac4a8ebeac5b72a6bc7d762eefd6e7d5e74c08b7ce4499ef8a3ff839453adf7b15469d8305fbaa382d64d5cd5ff9a85acd4b3db4d8d4838228ab6c472795b453e7401aa7bbf245865102905966ffcd23b1479c897af7111804fae9aae29cd897cb47cb9b17fd5c5d2ec02d1bc5640bb97a49f2995a8179a1f9b4869fa0a2e71eba421bbcd831dc7d092bfb5ab0658ee0f7453a9b059690a20b11108ab61c74ada34809b338",
                Status = "45ebb6a93e90478d88d9a8530e34c788ebc44a8c22164f34a8"
            };

            // Act
            var serviceResult = await _resumeDrvingLicensesAppService.UpdateAsync(Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"), input);

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("4d44b561-23e1-46ff-8e87-494182c53f7d"));
            result.DrvingLicenseCode.ShouldBe("f5ddcfad8cf64ab6877ea51a830aa7bec0e386ab4efd48daa1");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("5b9c664416ef4c3aaf936e62650182991219522eb2a3438e854674ef654277741e6e2f0de03f47c29d1b9e3be4004b26bd4fdc8aa29a4a9da9b012d2bed682b02e6d878640d84281bf5e86cb62cdb5815b88355844c142d1a1c5640837c3aba534c18ed239544ffab2e6c510855c9fb2f8c8b9fd46a24ecdb97cf1bf6a599eddb6f0bac90ec64670bbc3a76a04e61cb7044391697f064e2b975193d43f088c446bb05f20eac4451b8feb5119b37e2246309421d63153479b8f32bdddb2bcab398323a001f66e4d1c973820e5352e63e273a51b98714144c8b11b4ff415f86d75e96f1e9da68040d7be78e6f8ad875e657939ee4a5446437c89bb");
            result.DateA.ShouldBe(new DateTime(2019, 5, 15));
            result.DateD.ShouldBe(new DateTime(2007, 4, 13));
            result.Sort.ShouldBe(2145560322);
            result.Note.ShouldBe("4259dad3312b4e43a8077e443e88d205b5048b3c7b9a47a8948f93434acb36432a4e5e9ffa0e4864bbc28f3e22a302d6dfead500e7854b85a633200d8d9db691cadd364b5e9b44c28d938bcfa89b702afd3efd67adac4a8ebeac5b72a6bc7d762eefd6e7d5e74c08b7ce4499ef8a3ff839453adf7b15469d8305fbaa382d64d5cd5ff9a85acd4b3db4d8d4838228ab6c472795b453e7401aa7bbf245865102905966ffcd23b1479c897af7111804fae9aae29cd897cb47cb9b17fd5c5d2ec02d1bc5640bb97a49f2995a8179a1f9b4869fa0a2e71eba421bbcd831dc7d092bfb5ab0658ee0f7453a9b059690a20b11108ab61c74ada34809b338");
            result.Status.ShouldBe("45ebb6a93e90478d88d9a8530e34c788ebc44a8c22164f34a8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeDrvingLicensesAppService.DeleteAsync(Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"));

            // Assert
            var result = await _resumeDrvingLicenseRepository.FindAsync(c => c.Id == Guid.Parse("7a9d295c-df62-4a93-8392-f2bc31c93941"));

            result.ShouldBeNull();
        }
    }
}