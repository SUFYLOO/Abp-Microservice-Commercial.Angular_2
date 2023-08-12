using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPaysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPaysAppService _companyJobPaysAppService;
        private readonly IRepository<CompanyJobPay, Guid> _companyJobPayRepository;

        public CompanyJobPaysAppServiceTests()
        {
            _companyJobPaysAppService = GetRequiredService<ICompanyJobPaysAppService>();
            _companyJobPayRepository = GetRequiredService<IRepository<CompanyJobPay, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetListAsync(new GetCompanyJobPaysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("30cacfdc-f173-4c11-a040-798b88041d7e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPaysAppService.GetAsync(Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPayCreateDto
            {
                CompanyMainId = Guid.Parse("b98eb96c-d9b3-483d-92e5-0fadcb9313ec"),
                CompanyJobId = Guid.Parse("e442ac49-2803-483a-8fe9-4de91a79df88"),
                JobPayTypeCode = "c361bec635a644d9a142024b9f231f71abe1d000164245b8b4",
                DateReal = new DateTime(2018, 10, 18),
                IsCancel = true,
                ExtendedInformation = "b173046080234f8484f3f746bab9cbd9bec737da9a7240fd9ebd756c6a6ac0654a3627cd7ae24dfbaf5032543a15e95370c14f27f23f4b8a8f00484a18863ad64ce58a0f07d5430aa4cdabc28217dc3fa0c690e3af504be681022efb18c9c712eda531c1303c4fc9bbee9471f81ff6de18ec50b8ef9145b490481d89671e5e96be2bbb78e2124ab280de3dc2ec31b0489c3c052c244e4b388edba79fc9e8f3ef6ff36245a0c247ccae24cb9997fde9da8ed6dd775979432085c923c0b8669243d127b28aa5834a9590f6f8fe6572a73ea8161838d5274c06b9b63aea64e6ecf7fc3751f00dd3495597b9dc49c09d7295cee68f4ecde2484cba06",
                DateA = new DateTime(2018, 9, 8),
                DateD = new DateTime(2013, 2, 21),
                Sort = 356358874,
                Note = "698b564c5db84964b362b01f91043503d056da759d8341e79f6a5fd00b58234a3b235eff18fb45b9884b089179a3c797fbaa2cd8796147d1b9ce7a28a488a9ef1792ffb2df3f4643831eba118d6ec3c03ed1395e6ad745b8bb10ef45ba8d4f1bb394ca5b85524dd09a46205ca34d3c941bd1121d26104a568c8ad8428f5f59ea381f96c729764cdebf553a643c866f8d1e7117deaa54488cb306d87126e0ca8c758115a300994c8c86a12e60973c59189dce7a8d63ab4e75bd257881dddfaf48f5391958045f446cbc283907f2a864e59579ac56c4e742f1b17e493927e049613c6818c66f274c12a6231d42c595ced3ad29a3772cfa466faf2c",
                Status = "600562fb21594c31921154a7767bd1ea90008634acea40f596"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("b98eb96c-d9b3-483d-92e5-0fadcb9313ec"));
            result.CompanyJobId.ShouldBe(Guid.Parse("e442ac49-2803-483a-8fe9-4de91a79df88"));
            result.JobPayTypeCode.ShouldBe("c361bec635a644d9a142024b9f231f71abe1d000164245b8b4");
            result.DateReal.ShouldBe(new DateTime(2018, 10, 18));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("b173046080234f8484f3f746bab9cbd9bec737da9a7240fd9ebd756c6a6ac0654a3627cd7ae24dfbaf5032543a15e95370c14f27f23f4b8a8f00484a18863ad64ce58a0f07d5430aa4cdabc28217dc3fa0c690e3af504be681022efb18c9c712eda531c1303c4fc9bbee9471f81ff6de18ec50b8ef9145b490481d89671e5e96be2bbb78e2124ab280de3dc2ec31b0489c3c052c244e4b388edba79fc9e8f3ef6ff36245a0c247ccae24cb9997fde9da8ed6dd775979432085c923c0b8669243d127b28aa5834a9590f6f8fe6572a73ea8161838d5274c06b9b63aea64e6ecf7fc3751f00dd3495597b9dc49c09d7295cee68f4ecde2484cba06");
            result.DateA.ShouldBe(new DateTime(2018, 9, 8));
            result.DateD.ShouldBe(new DateTime(2013, 2, 21));
            result.Sort.ShouldBe(356358874);
            result.Note.ShouldBe("698b564c5db84964b362b01f91043503d056da759d8341e79f6a5fd00b58234a3b235eff18fb45b9884b089179a3c797fbaa2cd8796147d1b9ce7a28a488a9ef1792ffb2df3f4643831eba118d6ec3c03ed1395e6ad745b8bb10ef45ba8d4f1bb394ca5b85524dd09a46205ca34d3c941bd1121d26104a568c8ad8428f5f59ea381f96c729764cdebf553a643c866f8d1e7117deaa54488cb306d87126e0ca8c758115a300994c8c86a12e60973c59189dce7a8d63ab4e75bd257881dddfaf48f5391958045f446cbc283907f2a864e59579ac56c4e742f1b17e493927e049613c6818c66f274c12a6231d42c595ced3ad29a3772cfa466faf2c");
            result.Status.ShouldBe("600562fb21594c31921154a7767bd1ea90008634acea40f596");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPayUpdateDto()
            {
                CompanyMainId = Guid.Parse("47c08c16-b2af-4643-a8a3-9a64e3ffaf89"),
                CompanyJobId = Guid.Parse("30c0f849-9991-4d92-9afd-be32ad2dda71"),
                JobPayTypeCode = "8e0b86989aea47ce9c041701950c2ea6d69063e287214458bb",
                DateReal = new DateTime(2014, 10, 19),
                IsCancel = true,
                ExtendedInformation = "73a0b90f51b643bcaa577b36d72fcdae2c83e15cf4b54fe2b20f2b3dc8ed2da9cf133e8829d740098e97937e0593cacaeeaf78c262ce4e1d9082424001f4ad7197d78d9d4fd24aae88d5cf5113076447ebb37965c55c4f90889ae7090ca410ef42e8195eb7c64fec99fc7c52cdbe455375b1c651a7634bdbb44bccb5290826b4cae86f30e5f9401e98d7cc1425f6fee86b10910029754a3088617822876ac0bf8bb4847fa7194e0cad94f4e75dbcbd273867c5734b0f46aa9f509622e7275cbef364b925f17d48f0a37e81901a37b4ff79ba63bf51d74b2ca192a937588504ec2f348c812b51432e99d115085d716a70a5af7ca6abd94976bf15",
                DateA = new DateTime(2011, 11, 21),
                DateD = new DateTime(2009, 3, 17),
                Sort = 1996439392,
                Note = "75dbeb0dab854a65b1c6bd4afc02aa27ec05aa7bd2c8401c9d4bfefddb291f237c3498e2d57449b68f799341a385f54915de5b27fd6146e99e413f2c1e05c11f11779f1874e74155bf5aec83ede898f5b9710dd8bdbd40528c4b08965d5052c98548bda6f5f04601a5da3161f9b3c4b38448b357533244af9d4715562e786684ba3f2c03107d4af7894fb7435a69a9269c948bd8250b423497aaf98223b8ec867f03fdd4ec3f46a9a56af8a06f781c610bd655bc610147eba516975e109b483b34a7f266907a4ddea699a2087799265efcf53f08fab942c0be4d77dac6b54c270c3a0907a9d44a3ba08a85bb915712ff34e2af8da9c144b5a409",
                Status = "efe3a1a3fb464a1ba3105f345a0c141eb047d36f6e114a7ab0"
            };

            // Act
            var serviceResult = await _companyJobPaysAppService.UpdateAsync(Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"), input);

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("47c08c16-b2af-4643-a8a3-9a64e3ffaf89"));
            result.CompanyJobId.ShouldBe(Guid.Parse("30c0f849-9991-4d92-9afd-be32ad2dda71"));
            result.JobPayTypeCode.ShouldBe("8e0b86989aea47ce9c041701950c2ea6d69063e287214458bb");
            result.DateReal.ShouldBe(new DateTime(2014, 10, 19));
            result.IsCancel.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("73a0b90f51b643bcaa577b36d72fcdae2c83e15cf4b54fe2b20f2b3dc8ed2da9cf133e8829d740098e97937e0593cacaeeaf78c262ce4e1d9082424001f4ad7197d78d9d4fd24aae88d5cf5113076447ebb37965c55c4f90889ae7090ca410ef42e8195eb7c64fec99fc7c52cdbe455375b1c651a7634bdbb44bccb5290826b4cae86f30e5f9401e98d7cc1425f6fee86b10910029754a3088617822876ac0bf8bb4847fa7194e0cad94f4e75dbcbd273867c5734b0f46aa9f509622e7275cbef364b925f17d48f0a37e81901a37b4ff79ba63bf51d74b2ca192a937588504ec2f348c812b51432e99d115085d716a70a5af7ca6abd94976bf15");
            result.DateA.ShouldBe(new DateTime(2011, 11, 21));
            result.DateD.ShouldBe(new DateTime(2009, 3, 17));
            result.Sort.ShouldBe(1996439392);
            result.Note.ShouldBe("75dbeb0dab854a65b1c6bd4afc02aa27ec05aa7bd2c8401c9d4bfefddb291f237c3498e2d57449b68f799341a385f54915de5b27fd6146e99e413f2c1e05c11f11779f1874e74155bf5aec83ede898f5b9710dd8bdbd40528c4b08965d5052c98548bda6f5f04601a5da3161f9b3c4b38448b357533244af9d4715562e786684ba3f2c03107d4af7894fb7435a69a9269c948bd8250b423497aaf98223b8ec867f03fdd4ec3f46a9a56af8a06f781c610bd655bc610147eba516975e109b483b34a7f266907a4ddea699a2087799265efcf53f08fab942c0be4d77dac6b54c270c3a0907a9d44a3ba08a85bb915712ff34e2af8da9c144b5a409");
            result.Status.ShouldBe("efe3a1a3fb464a1ba3105f345a0c141eb047d36f6e114a7ab0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPaysAppService.DeleteAsync(Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"));

            // Assert
            var result = await _companyJobPayRepository.FindAsync(c => c.Id == Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"));

            result.ShouldBeNull();
        }
    }
}