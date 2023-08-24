using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicensesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobDrvingLicensesAppService _companyJobDrvingLicensesAppService;
        private readonly IRepository<CompanyJobDrvingLicense, Guid> _companyJobDrvingLicenseRepository;

        public CompanyJobDrvingLicensesAppServiceTests()
        {
            _companyJobDrvingLicensesAppService = GetRequiredService<ICompanyJobDrvingLicensesAppService>();
            _companyJobDrvingLicenseRepository = GetRequiredService<IRepository<CompanyJobDrvingLicense, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetListAsync(new GetCompanyJobDrvingLicensesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f553a2a7-bd1c-4f9f-bc44-04308ccd4c89")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDrvingLicensesAppService.GetAsync(Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseCreateDto
            {
                CompanyMainId = Guid.Parse("2b2a5a6c-5620-425a-afdd-f4ca5467bac9"),
                CompanyJobId = Guid.Parse("0e3344cc-cb0b-4e8d-bb24-b22c3e0f28a5"),
                DrvingLicenseCode = "a7cb79b87fdb464e91ab10c21af9af3658d38d4c00c34acea4",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "9b14b1f67c504ecb866cfbfb8563f9170f4ddb67a4d44229832e4a98a8a87b396562ae034b7a4f5baef31ac905096a5d9cdba25fe8f14072bfeeed7089a5691c91979179af8643368be71a544acf1a96de4bec3d500e4834bc0b6ee5478935df19b4f22f0f65462f9e12721fff8428443ddc37bfce694837a80ac48fdbe7b39c66cc428012cf4e66be3cae6721446bfa0a6e43ed50884d1c8be59457a64dd29d9acfc360703e438e824f04830bffa6fd409beede4705494ca3d609a418a6f27ab4126822b84b403aaccdbd08de61d7eaf4ce2c88c5004f2da8fa19283dba463861cbca8fff7b46d6aca0bcc672a112c1853203936565489ebe55",
                DateA = new DateTime(2018, 2, 24),
                DateD = new DateTime(2014, 8, 4),
                Sort = 817965522,
                Note = "f52d44d77edb45e2b511fc5ac1da3de3a0afc51bb30949d98abc24003936f158bf04a29bd1b94969bc613883af8ad42c9b919b7088234df38e02c5481f75454a9e0aa92e43c74047a49ea5279a1c2ab34307164a2ade4b88bf73169812008402c7f1496430c24bd78a3a08a459b0f2f45b26fa44a4b542ffbc79d398fabfc1091c68bf86c14949bea1ceb7dc1c02682ccc6324da14eb4a9f819509a8d5d4c659fca3c576cdd846f38c4da8c6134604a67866c8f3a06f46369b84a8dfbe0cd2d0da18ebcca93544f2b603d554574ce106e880d5b01e154ae0af8fd1913fe7f2bb3f8cd57ae7a3407ca57912bcd0eeb02d46421a50e8834b3db46b",
                Status = "5e9c52cc5bb64153a7356a8b42e42d0ac79bc97b83854dc68c"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("2b2a5a6c-5620-425a-afdd-f4ca5467bac9"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0e3344cc-cb0b-4e8d-bb24-b22c3e0f28a5"));
            result.DrvingLicenseCode.ShouldBe("a7cb79b87fdb464e91ab10c21af9af3658d38d4c00c34acea4");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("9b14b1f67c504ecb866cfbfb8563f9170f4ddb67a4d44229832e4a98a8a87b396562ae034b7a4f5baef31ac905096a5d9cdba25fe8f14072bfeeed7089a5691c91979179af8643368be71a544acf1a96de4bec3d500e4834bc0b6ee5478935df19b4f22f0f65462f9e12721fff8428443ddc37bfce694837a80ac48fdbe7b39c66cc428012cf4e66be3cae6721446bfa0a6e43ed50884d1c8be59457a64dd29d9acfc360703e438e824f04830bffa6fd409beede4705494ca3d609a418a6f27ab4126822b84b403aaccdbd08de61d7eaf4ce2c88c5004f2da8fa19283dba463861cbca8fff7b46d6aca0bcc672a112c1853203936565489ebe55");
            result.DateA.ShouldBe(new DateTime(2018, 2, 24));
            result.DateD.ShouldBe(new DateTime(2014, 8, 4));
            result.Sort.ShouldBe(817965522);
            result.Note.ShouldBe("f52d44d77edb45e2b511fc5ac1da3de3a0afc51bb30949d98abc24003936f158bf04a29bd1b94969bc613883af8ad42c9b919b7088234df38e02c5481f75454a9e0aa92e43c74047a49ea5279a1c2ab34307164a2ade4b88bf73169812008402c7f1496430c24bd78a3a08a459b0f2f45b26fa44a4b542ffbc79d398fabfc1091c68bf86c14949bea1ceb7dc1c02682ccc6324da14eb4a9f819509a8d5d4c659fca3c576cdd846f38c4da8c6134604a67866c8f3a06f46369b84a8dfbe0cd2d0da18ebcca93544f2b603d554574ce106e880d5b01e154ae0af8fd1913fe7f2bb3f8cd57ae7a3407ca57912bcd0eeb02d46421a50e8834b3db46b");
            result.Status.ShouldBe("5e9c52cc5bb64153a7356a8b42e42d0ac79bc97b83854dc68c");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDrvingLicenseUpdateDto()
            {
                CompanyMainId = Guid.Parse("1b8b3742-2e25-4b14-b9f2-d72e60814041"),
                CompanyJobId = Guid.Parse("12399cc4-c014-46c9-a27f-e4bb41b896df"),
                DrvingLicenseCode = "b315a54c9b5a4c609f22d3773036ed99d960416369a146b8ae",
                HaveDrvingLicense = true,
                HaveCar = true,
                ExtendedInformation = "67e54569247e4189b5a71085971151cc324df3b9ea154fd38ad35f382301d49fddc8768a6e7c408982343619d45b62f273814b5cac2b4953806ad35e2c16d05cf2e43d3cb87446e581a150622b6d65b426fe523bc17744fe85f376a8a30598ab1c28e4a086bd4677a1ac94d545762dad350f70dddb134a7392ebfa41bfc2a97f417137132e4e47dea396570c38909c8f0258b823de1a4fef8d16d75b4e38146b0766f5d4664248e8b8a2279fb676b3dc27eba455dad6464eb0625f120bf1161d4145ce87c85943c085f231302a611edd9593ad2e1f8b404ca0ab6a512d8e14b370466d6d1725456bb97736cb31176f25a5e70ba48a9f40858c0e",
                DateA = new DateTime(2014, 2, 15),
                DateD = new DateTime(2022, 7, 6),
                Sort = 932120279,
                Note = "5e60f516c868454296a6fcb26cf06a6d39f5726661bf49bca92c6a78940019621d932f41a4504568819643c141046b225651e83b5fc044b884b56a05f833b3e8b272a4f8723b4bafb8853d9f418dc2815cc2965258984500ab152f942fff53e2c5f0fb3cae5243d5b3f16a5a92584af480f8dc18a5504a0e8c19aff44ed20ff9ec1d5b5b2b6f48fe965f2a04f96d1bb0a8ea234798f74d72836523cccf12271adc5d77dee17d46f39b292fa59f293b6450001bbb5b0a44768f61a3104d67bafa0948a27a46ee42a1b7a434890bff7570dce28bca59824a3b9873c3dc29f3dd4e62c74f92b0124aef8ecb5caf3824f8a84af8d2bb397044c8960b",
                Status = "dead943f5539402a86a2e01f634549580ae0a76ec8df480da7"
            };

            // Act
            var serviceResult = await _companyJobDrvingLicensesAppService.UpdateAsync(Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"), input);

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("1b8b3742-2e25-4b14-b9f2-d72e60814041"));
            result.CompanyJobId.ShouldBe(Guid.Parse("12399cc4-c014-46c9-a27f-e4bb41b896df"));
            result.DrvingLicenseCode.ShouldBe("b315a54c9b5a4c609f22d3773036ed99d960416369a146b8ae");
            result.HaveDrvingLicense.ShouldBe(true);
            result.HaveCar.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("67e54569247e4189b5a71085971151cc324df3b9ea154fd38ad35f382301d49fddc8768a6e7c408982343619d45b62f273814b5cac2b4953806ad35e2c16d05cf2e43d3cb87446e581a150622b6d65b426fe523bc17744fe85f376a8a30598ab1c28e4a086bd4677a1ac94d545762dad350f70dddb134a7392ebfa41bfc2a97f417137132e4e47dea396570c38909c8f0258b823de1a4fef8d16d75b4e38146b0766f5d4664248e8b8a2279fb676b3dc27eba455dad6464eb0625f120bf1161d4145ce87c85943c085f231302a611edd9593ad2e1f8b404ca0ab6a512d8e14b370466d6d1725456bb97736cb31176f25a5e70ba48a9f40858c0e");
            result.DateA.ShouldBe(new DateTime(2014, 2, 15));
            result.DateD.ShouldBe(new DateTime(2022, 7, 6));
            result.Sort.ShouldBe(932120279);
            result.Note.ShouldBe("5e60f516c868454296a6fcb26cf06a6d39f5726661bf49bca92c6a78940019621d932f41a4504568819643c141046b225651e83b5fc044b884b56a05f833b3e8b272a4f8723b4bafb8853d9f418dc2815cc2965258984500ab152f942fff53e2c5f0fb3cae5243d5b3f16a5a92584af480f8dc18a5504a0e8c19aff44ed20ff9ec1d5b5b2b6f48fe965f2a04f96d1bb0a8ea234798f74d72836523cccf12271adc5d77dee17d46f39b292fa59f293b6450001bbb5b0a44768f61a3104d67bafa0948a27a46ee42a1b7a434890bff7570dce28bca59824a3b9873c3dc29f3dd4e62c74f92b0124aef8ecb5caf3824f8a84af8d2bb397044c8960b");
            result.Status.ShouldBe("dead943f5539402a86a2e01f634549580ae0a76ec8df480da7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDrvingLicensesAppService.DeleteAsync(Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"));

            // Assert
            var result = await _companyJobDrvingLicenseRepository.FindAsync(c => c.Id == Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"));

            result.ShouldBeNull();
        }
    }
}