using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeCommunicationsAppService _resumeCommunicationsAppService;
        private readonly IRepository<ResumeCommunication, Guid> _resumeCommunicationRepository;

        public ResumeCommunicationsAppServiceTests()
        {
            _resumeCommunicationsAppService = GetRequiredService<IResumeCommunicationsAppService>();
            _resumeCommunicationRepository = GetRequiredService<IRepository<ResumeCommunication, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeCommunicationsAppService.GetListAsync(new GetResumeCommunicationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("967c4913-2692-4921-8c73-796a944166a9")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeCommunicationsAppService.GetAsync(Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeCommunicationCreateDto
            {
                ResumeMainId = Guid.Parse("c987584f-5191-4371-a22d-be0bfa09f405"),
                CommunicationCategoryCode = "d3e9fa702b3745958febc75752e25210b96525367a614f8bb5",
                CommunicationValue = "e29bfb8306be479190342138f9d935da95a1f13237024099a2ea6f8090022d2517a0f31e80ab4af5aba1886dc4608feb1d74fd5d05494882b5bbc57e683039ce3454667f69544917b38309810bc66ac6d524a308b7a143cc892f399b426ce52ee6930646",
                Main = true,
                ExtendedInformation = "c989f27d0da240ccbc997a9c3bef84341d69d442054c4bcc9170cab755df1d78cb7d64887d804027a99b2381bf45ee4de715b6460762432993225c9aa69a36ff5ab4ff9f6c6849848ffa696b703a23b20bf73f0035d349fab26629b192bbbc630e850dc77d4a4d1b8e3c47e7ca0eeebb544e396730924e94a11b39313ca899e4902f2debb3d441f99b4c92a7ee4bd36db44d2f760a754856a698c494c14cec2358030b87468b41eda8e9bb0560a9f3aabb026ae0eea2429593fbb7f00fb50700ee1a79bae8944e0883c1dd87fba81361a5b28a2349ec4a4cb5bf8659378a322b3a34dfc471f04ddcb070cf764def7ddd3c11a02524ff4c00b64d",
                DateA = new DateTime(2010, 11, 18),
                DateD = new DateTime(2008, 3, 22),
                Sort = 429403648,
                Note = "f98302d38dfd4493b2f3900a4b446ebcab87ec21958d48298804ef7fb2818b79daa34d7a03c94ee788c907d3743792733bbc9dd4ed044d7197fa18521d4b6271b5da6acb8a6f49abb61fbaff3e9b5e07c0580105d7074cde895cb5640e94e37e144fff4c30cc41bd93af082eae6e8a7ab66ac7df5e27426cb8941780b414f3c3fba786384ccb46c88538f38f395ac102cef8e78f02764943bedf2be7c88742f25226f617b9a14f9285ef00bb1af7c6179eefd3d7c7d14bd18a8c163ce12a0d24a8e7ce11d2e34c72a728d7a5d0772417dfb3cd0730a5444689df2323b9bcde66a8d81b83e3294d5ca152298081950dbf89f02db0f72644fbafd7",
                Status = "ce9c08dea3e54cfb9f90f1441aafdfcabf3e3243d0464a17a9"
            };

            // Act
            var serviceResult = await _resumeCommunicationsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("c987584f-5191-4371-a22d-be0bfa09f405"));
            result.CommunicationCategoryCode.ShouldBe("d3e9fa702b3745958febc75752e25210b96525367a614f8bb5");
            result.CommunicationValue.ShouldBe("e29bfb8306be479190342138f9d935da95a1f13237024099a2ea6f8090022d2517a0f31e80ab4af5aba1886dc4608feb1d74fd5d05494882b5bbc57e683039ce3454667f69544917b38309810bc66ac6d524a308b7a143cc892f399b426ce52ee6930646");
            result.Main.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("c989f27d0da240ccbc997a9c3bef84341d69d442054c4bcc9170cab755df1d78cb7d64887d804027a99b2381bf45ee4de715b6460762432993225c9aa69a36ff5ab4ff9f6c6849848ffa696b703a23b20bf73f0035d349fab26629b192bbbc630e850dc77d4a4d1b8e3c47e7ca0eeebb544e396730924e94a11b39313ca899e4902f2debb3d441f99b4c92a7ee4bd36db44d2f760a754856a698c494c14cec2358030b87468b41eda8e9bb0560a9f3aabb026ae0eea2429593fbb7f00fb50700ee1a79bae8944e0883c1dd87fba81361a5b28a2349ec4a4cb5bf8659378a322b3a34dfc471f04ddcb070cf764def7ddd3c11a02524ff4c00b64d");
            result.DateA.ShouldBe(new DateTime(2010, 11, 18));
            result.DateD.ShouldBe(new DateTime(2008, 3, 22));
            result.Sort.ShouldBe(429403648);
            result.Note.ShouldBe("f98302d38dfd4493b2f3900a4b446ebcab87ec21958d48298804ef7fb2818b79daa34d7a03c94ee788c907d3743792733bbc9dd4ed044d7197fa18521d4b6271b5da6acb8a6f49abb61fbaff3e9b5e07c0580105d7074cde895cb5640e94e37e144fff4c30cc41bd93af082eae6e8a7ab66ac7df5e27426cb8941780b414f3c3fba786384ccb46c88538f38f395ac102cef8e78f02764943bedf2be7c88742f25226f617b9a14f9285ef00bb1af7c6179eefd3d7c7d14bd18a8c163ce12a0d24a8e7ce11d2e34c72a728d7a5d0772417dfb3cd0730a5444689df2323b9bcde66a8d81b83e3294d5ca152298081950dbf89f02db0f72644fbafd7");
            result.Status.ShouldBe("ce9c08dea3e54cfb9f90f1441aafdfcabf3e3243d0464a17a9");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeCommunicationUpdateDto()
            {
                ResumeMainId = Guid.Parse("eefbcd88-7813-476f-a47c-38d0c1d3a5e6"),
                CommunicationCategoryCode = "57d5fbcd282a46eca59e7c99d76eb5e041819e8a519842b4b8",
                CommunicationValue = "fd52d1abec9841988fa613a262a42489168bb59556774d78a14f715be40e2c613061f21dcd17407da9842048fe33adb2fa5b66e9202b46e8bc3b74ed6b4b1dadd32aff5c0be24c6380da9bab6aa393542e90191954e64b72aa7a0acbbfdd930f6af06256",
                Main = true,
                ExtendedInformation = "1c48cfe1993448caa5050d01afa39d9368d594c6a3fb405aae61efae5c276048ebef6a60eb304128a6d2509a371eb32333035c12c7754dae830f4e475cc856a368bdd01efe764152bffafc7c49b40e2a7227cbfc4ab3430fa5476c02924771c599132608daac4226a7a5fa6ed702ab5f37f720c568fc4d2db7d3d6c27a342fac14331bd80caa474990540130feeba958585ada2bd54e4cf7adea37863132b7f245a4c4f50645448db0dcadcb333382f29691ec8b838f4d1fbf5b2ca4578023fdbed8a5ad8d744989b16400a416a9b43559c478c7e68d4b568838b7e45f12c8beb6b899886c634744abfb289ce5abcbf8bf8e255c2b69485e84da",
                DateA = new DateTime(2001, 2, 3),
                DateD = new DateTime(2016, 10, 21),
                Sort = 2135642126,
                Note = "b404e508777c4fa1b352f25324504b669f63682fcdec4cd48d55436e2463a14f7e4ea0dff6a7451a9a3d0d52e1570e490cb29caefc7644b6b337c4bfde816b21df53902321e44d8a987e9e48ba595a2a8a9bb8a936b948c6b8b58fc7f05e2d6f68a8d780c73e41378dd73b000cde3698379286b06c004dae9c8a40d61bac33d0e4fdf5f75aef4bd18a0670cecb99af350b5df0d060694e8b9361f36e71a95d25b8e4fd62f52b4459b96136fea5fe7bd74f909771785d42a4a5e6522b8b65c07f5753fa3c954f4735946924a0c936284abd88067642154206be4085d6de3cf4812b73f7cca7974322a1db04848207862e632741764d174d59a836",
                Status = "d43477bd88834d57b5392b848e791f8766aa9584e8db4590b7"
            };

            // Act
            var serviceResult = await _resumeCommunicationsAppService.UpdateAsync(Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"), input);

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("eefbcd88-7813-476f-a47c-38d0c1d3a5e6"));
            result.CommunicationCategoryCode.ShouldBe("57d5fbcd282a46eca59e7c99d76eb5e041819e8a519842b4b8");
            result.CommunicationValue.ShouldBe("fd52d1abec9841988fa613a262a42489168bb59556774d78a14f715be40e2c613061f21dcd17407da9842048fe33adb2fa5b66e9202b46e8bc3b74ed6b4b1dadd32aff5c0be24c6380da9bab6aa393542e90191954e64b72aa7a0acbbfdd930f6af06256");
            result.Main.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("1c48cfe1993448caa5050d01afa39d9368d594c6a3fb405aae61efae5c276048ebef6a60eb304128a6d2509a371eb32333035c12c7754dae830f4e475cc856a368bdd01efe764152bffafc7c49b40e2a7227cbfc4ab3430fa5476c02924771c599132608daac4226a7a5fa6ed702ab5f37f720c568fc4d2db7d3d6c27a342fac14331bd80caa474990540130feeba958585ada2bd54e4cf7adea37863132b7f245a4c4f50645448db0dcadcb333382f29691ec8b838f4d1fbf5b2ca4578023fdbed8a5ad8d744989b16400a416a9b43559c478c7e68d4b568838b7e45f12c8beb6b899886c634744abfb289ce5abcbf8bf8e255c2b69485e84da");
            result.DateA.ShouldBe(new DateTime(2001, 2, 3));
            result.DateD.ShouldBe(new DateTime(2016, 10, 21));
            result.Sort.ShouldBe(2135642126);
            result.Note.ShouldBe("b404e508777c4fa1b352f25324504b669f63682fcdec4cd48d55436e2463a14f7e4ea0dff6a7451a9a3d0d52e1570e490cb29caefc7644b6b337c4bfde816b21df53902321e44d8a987e9e48ba595a2a8a9bb8a936b948c6b8b58fc7f05e2d6f68a8d780c73e41378dd73b000cde3698379286b06c004dae9c8a40d61bac33d0e4fdf5f75aef4bd18a0670cecb99af350b5df0d060694e8b9361f36e71a95d25b8e4fd62f52b4459b96136fea5fe7bd74f909771785d42a4a5e6522b8b65c07f5753fa3c954f4735946924a0c936284abd88067642154206be4085d6de3cf4812b73f7cca7974322a1db04848207862e632741764d174d59a836");
            result.Status.ShouldBe("d43477bd88834d57b5392b848e791f8766aa9584e8db4590b7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeCommunicationsAppService.DeleteAsync(Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"));

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == Guid.Parse("e229be8c-dc67-450d-a123-0c0c1c7c7bb5"));

            result.ShouldBeNull();
        }
    }
}