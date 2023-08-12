using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeMains
{
    public class ResumeMainsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeMainsAppService _resumeMainsAppService;
        private readonly IRepository<ResumeMain, Guid> _resumeMainRepository;

        public ResumeMainsAppServiceTests()
        {
            _resumeMainsAppService = GetRequiredService<IResumeMainsAppService>();
            _resumeMainRepository = GetRequiredService<IRepository<ResumeMain, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeMainsAppService.GetListAsync(new GetResumeMainsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("b5451f90-2130-4d42-a75c-ab93074096c3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeMainsAppService.GetAsync(Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeMainCreateDto
            {
                UserMainId = Guid.Parse("0c28e3a3-9dbd-41d0-8196-257bb7f32842"),
                ResumeName = "103cef9c6ea8402c8f422ecfa5a4fe476547bde659544d2486",
                MarriageCode = "436f388e38b64fc9bef256693b2c410aa15e13fe99c3484e9d",
                MilitaryCode = "e0ac58041d5e41fdb0b7a0c1845c0e7a72b883ffc6324fb08a",
                DisabilityCategoryCode = "ce326d9e8536466493e849e47077d70f86212287d4614e288a",
                SpecialIdentityCode = "95c2888c33d24b9a8ee1ff2ebc131580a16a798d1ba54227a3",
                Main = true,
                Autobiography1 = "a6f4b72ee89e4d22a49415fd47e",
                Autobiography2 = "7ecebd01d62f436faf4bfb05636b79b7c692c2b9f60f4aae98f9d27301ff8fdf4",
                ExtendedInformation = "302693277592408291c22a0cfe0903277edcbce6f9df47da94e38fc62670252b19d2cbd91dcf45edb3ff55f45c1d9802e6e412cb5bb849bab4aa3a5d8d8a9482c83bed389b0d426d9a5aa2895e538d99c6e0720b538748b3a0ea192bee69cc87b71455e8b5fc45ef860e54b0c101492fcfc7fbf7f4ee482ca5d636f12c36a613799316edaa094ea5a06a610805675accd4c209e00a6a4ebeb0a16e49b7b4700f838d0e40e2cb45d59e3aef5afced8b8a0ce69b1db0aa439eaeff241aff59734502ff6868385e4559b45a729fb51704afe4731b0c88b2441d85b13cd53919355e248f622d26244ec985dc863a205d7e59b8278dc6c9b04fe0b45b",
                DateA = new DateTime(2019, 3, 12),
                DateD = new DateTime(2016, 10, 26),
                Sort = 1575782995,
                Note = "d66a4bc837fa4faba52b79863332b11a0ff7e4355ee849219705910b34d12003c6b278d683f341ef97c827997d4f00671ec599e0c89e4459991e975a6d558f63cd456af25bfe447b8e37eb3d3fba7f3a3ebff4aa178549b788dce7d3c252372c7293d4a2b182428b9d91bcb92a8adea8051308137f8c48b682e57285623b9c70de6417b80cb34b809c9bb98e9cca6b5d312dd3f3df9e4469a962f3aeb44c7c366791b700fc24416797d37d3fcbdf0a89201190c87f094eee99c690d7c7ec4600488a3316839e41dab2016579338c4d342c3d7c78da3a4cf2a84e32d759d7a7d2bdf68bd654f14da1b33b70d1d7e4d87b44dea814272441988408",
                Status = "c3cf5acdf82241d39bcd21af667f8fb82858e2d7c4b8419382"
            };

            // Act
            var serviceResult = await _resumeMainsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("0c28e3a3-9dbd-41d0-8196-257bb7f32842"));
            result.ResumeName.ShouldBe("103cef9c6ea8402c8f422ecfa5a4fe476547bde659544d2486");
            result.MarriageCode.ShouldBe("436f388e38b64fc9bef256693b2c410aa15e13fe99c3484e9d");
            result.MilitaryCode.ShouldBe("e0ac58041d5e41fdb0b7a0c1845c0e7a72b883ffc6324fb08a");
            result.DisabilityCategoryCode.ShouldBe("ce326d9e8536466493e849e47077d70f86212287d4614e288a");
            result.SpecialIdentityCode.ShouldBe("95c2888c33d24b9a8ee1ff2ebc131580a16a798d1ba54227a3");
            result.Main.ShouldBe(true);
            result.Autobiography1.ShouldBe("a6f4b72ee89e4d22a49415fd47e");
            result.Autobiography2.ShouldBe("7ecebd01d62f436faf4bfb05636b79b7c692c2b9f60f4aae98f9d27301ff8fdf4");
            result.ExtendedInformation.ShouldBe("302693277592408291c22a0cfe0903277edcbce6f9df47da94e38fc62670252b19d2cbd91dcf45edb3ff55f45c1d9802e6e412cb5bb849bab4aa3a5d8d8a9482c83bed389b0d426d9a5aa2895e538d99c6e0720b538748b3a0ea192bee69cc87b71455e8b5fc45ef860e54b0c101492fcfc7fbf7f4ee482ca5d636f12c36a613799316edaa094ea5a06a610805675accd4c209e00a6a4ebeb0a16e49b7b4700f838d0e40e2cb45d59e3aef5afced8b8a0ce69b1db0aa439eaeff241aff59734502ff6868385e4559b45a729fb51704afe4731b0c88b2441d85b13cd53919355e248f622d26244ec985dc863a205d7e59b8278dc6c9b04fe0b45b");
            result.DateA.ShouldBe(new DateTime(2019, 3, 12));
            result.DateD.ShouldBe(new DateTime(2016, 10, 26));
            result.Sort.ShouldBe(1575782995);
            result.Note.ShouldBe("d66a4bc837fa4faba52b79863332b11a0ff7e4355ee849219705910b34d12003c6b278d683f341ef97c827997d4f00671ec599e0c89e4459991e975a6d558f63cd456af25bfe447b8e37eb3d3fba7f3a3ebff4aa178549b788dce7d3c252372c7293d4a2b182428b9d91bcb92a8adea8051308137f8c48b682e57285623b9c70de6417b80cb34b809c9bb98e9cca6b5d312dd3f3df9e4469a962f3aeb44c7c366791b700fc24416797d37d3fcbdf0a89201190c87f094eee99c690d7c7ec4600488a3316839e41dab2016579338c4d342c3d7c78da3a4cf2a84e32d759d7a7d2bdf68bd654f14da1b33b70d1d7e4d87b44dea814272441988408");
            result.Status.ShouldBe("c3cf5acdf82241d39bcd21af667f8fb82858e2d7c4b8419382");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeMainUpdateDto()
            {
                UserMainId = Guid.Parse("87679cc0-4db4-4fbd-b40e-1878df574ddc"),
                ResumeName = "4df3d9142d664ccb9721e8d8ff8da303e75691b4ce74445a85",
                MarriageCode = "b0027e78aecb461b84c02766fc770518a6d58b811e6d48c489",
                MilitaryCode = "8173e22f7f4843b6af9422a709fccc8ff282abcb2afa4b0689",
                DisabilityCategoryCode = "6dfc465bd2604d2ba7528f9827c8f2a4d5cd32a03e5447fd93",
                SpecialIdentityCode = "d818a1313d054cc98acb98ae1690c9be65d6f6f2f1ca4df89c",
                Main = true,
                Autobiography1 = "cc024487cef",
                Autobiography2 = "262905579bf44df68d25376df7f4035a4d88548ab92f41129c8e980262",
                ExtendedInformation = "dce7de258925472dbc3c091f2436be8f8b0caa252249497d893a031700faae4ebb5790e74b7b4488b4cfe56f7a75880c292d7871310d4d1281af644c8fec943485ea6627aaf145ce96e40d65889c7ff801cff1634fbc48d89d1f6ab3b7e9cf554a25fbea81bd471c81298050ef3e111bc04d8a0a421f427b868aa26cdf5b7408c717c77ed94640c69fc9494d617c9a475f6d8d044ef641bb8404fd1ec971814f5653052df6b54c639b4479841d704003215feeb263a74217b9bec7a2c98fbc88de43c842b27c4800bb14af1a7952690e15afa1af803d43e8b897fdf4efeff9e87ce7cb1104644ccf9f17edf3d33bff18f062efd1f9df4ba48c83",
                DateA = new DateTime(2008, 11, 3),
                DateD = new DateTime(2009, 9, 20),
                Sort = 1211740679,
                Note = "0ee005125c7d4c8ba2eeef0ab0ab4dbf746d74fe26e444eb8db6bf33a50a44d556ea87af4c924810a2af238c4e7348a8b0ba96be090e44c8ac5bc27c2d3895c2676486c1405f468b88b548b0de68bad608c472ed9b3c4e67b7b2838412a05f0db4ff433bb4a547ffa4598501a5b99f53e6ae3f55494e4aaf8f71f4e301a645ff5cd3a342132f48d79d345b22916484aa61f318bf997a4835a32473e2c4c9bb1ff418e136602c411d8f70da6670f632e21c576dfb8a7d419ab4013026d605c9607c3242efb109404bb797e7358a9bc22ceee20fc671244b00b0503450b25c436e7d2a54de9ef54b23a946df765aa447a4c3421c823d764ced8f66",
                Status = "76bb7632c0c44fdc9a026d63758f62809e88bee14e2c4d9591"
            };

            // Act
            var serviceResult = await _resumeMainsAppService.UpdateAsync(Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"), input);

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("87679cc0-4db4-4fbd-b40e-1878df574ddc"));
            result.ResumeName.ShouldBe("4df3d9142d664ccb9721e8d8ff8da303e75691b4ce74445a85");
            result.MarriageCode.ShouldBe("b0027e78aecb461b84c02766fc770518a6d58b811e6d48c489");
            result.MilitaryCode.ShouldBe("8173e22f7f4843b6af9422a709fccc8ff282abcb2afa4b0689");
            result.DisabilityCategoryCode.ShouldBe("6dfc465bd2604d2ba7528f9827c8f2a4d5cd32a03e5447fd93");
            result.SpecialIdentityCode.ShouldBe("d818a1313d054cc98acb98ae1690c9be65d6f6f2f1ca4df89c");
            result.Main.ShouldBe(true);
            result.Autobiography1.ShouldBe("cc024487cef");
            result.Autobiography2.ShouldBe("262905579bf44df68d25376df7f4035a4d88548ab92f41129c8e980262");
            result.ExtendedInformation.ShouldBe("dce7de258925472dbc3c091f2436be8f8b0caa252249497d893a031700faae4ebb5790e74b7b4488b4cfe56f7a75880c292d7871310d4d1281af644c8fec943485ea6627aaf145ce96e40d65889c7ff801cff1634fbc48d89d1f6ab3b7e9cf554a25fbea81bd471c81298050ef3e111bc04d8a0a421f427b868aa26cdf5b7408c717c77ed94640c69fc9494d617c9a475f6d8d044ef641bb8404fd1ec971814f5653052df6b54c639b4479841d704003215feeb263a74217b9bec7a2c98fbc88de43c842b27c4800bb14af1a7952690e15afa1af803d43e8b897fdf4efeff9e87ce7cb1104644ccf9f17edf3d33bff18f062efd1f9df4ba48c83");
            result.DateA.ShouldBe(new DateTime(2008, 11, 3));
            result.DateD.ShouldBe(new DateTime(2009, 9, 20));
            result.Sort.ShouldBe(1211740679);
            result.Note.ShouldBe("0ee005125c7d4c8ba2eeef0ab0ab4dbf746d74fe26e444eb8db6bf33a50a44d556ea87af4c924810a2af238c4e7348a8b0ba96be090e44c8ac5bc27c2d3895c2676486c1405f468b88b548b0de68bad608c472ed9b3c4e67b7b2838412a05f0db4ff433bb4a547ffa4598501a5b99f53e6ae3f55494e4aaf8f71f4e301a645ff5cd3a342132f48d79d345b22916484aa61f318bf997a4835a32473e2c4c9bb1ff418e136602c411d8f70da6670f632e21c576dfb8a7d419ab4013026d605c9607c3242efb109404bb797e7358a9bc22ceee20fc671244b00b0503450b25c436e7d2a54de9ef54b23a946df765aa447a4c3421c823d764ced8f66");
            result.Status.ShouldBe("76bb7632c0c44fdc9a026d63758f62809e88bee14e2c4d9591");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeMainsAppService.DeleteAsync(Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"));

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"));

            result.ShouldBeNull();
        }
    }
}