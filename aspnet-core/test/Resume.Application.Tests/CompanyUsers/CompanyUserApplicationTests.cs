using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyUsers
{
    public class CompanyUsersAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyUsersAppService _companyUsersAppService;
        private readonly IRepository<CompanyUser, Guid> _companyUserRepository;

        public CompanyUsersAppServiceTests()
        {
            _companyUsersAppService = GetRequiredService<ICompanyUsersAppService>();
            _companyUserRepository = GetRequiredService<IRepository<CompanyUser, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyUsersAppService.GetListAsync(new GetCompanyUsersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6cd2ec68-bd6f-4f06-b9af-2ef8d97b3dc0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyUsersAppService.GetAsync(Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyUserCreateDto
            {
                CompanyMainId = Guid.Parse("0f1cab52-9616-45c8-8058-ca8a4c541376"),
                UserMainId = Guid.Parse("e9eda0d3-cf0f-4089-9863-f0475971cb3f"),
                JobName = "9b17da85a9d64a4087afa39c66ddae86248b1485cdbf4f8896",
                OfficePhone = "177fa25b857f4fb6b05284dfd1b01ed3bfcb1e558ce74d4eb1",
                ExtendedInformation = "86c1285657ab4b3db7171889c843ef80a25a722c1f41418d848d4b59130c59f502facf5a46654487a1f9e04176eacfdd20d9ae074f104ad1a49a094674d3cf00739e5ff951f0466ca44903c9a1c1ffe3b2975d063a3b4088b6687ec765775d067e1e53468af047339f8184f96ee5939b60c798fcde63471fa3d49ab129792cd5eef16ba7449a4656bab72ecadf9bb45b4c00dcb1f55b4973a0b612d7e3a467dae6dab6d414f546d5be52fdab22d1e2e34f166835e9eb4f7490d85b954d3fc035594dcb7b4ed3420399f354b607723a6e6644d830375a4528b93891cf0130a7f54cdf9780b9c743da85ccb7cfd715089dcc55a8df304b468dbd37",
                DateA = new DateTime(2022, 8, 17),
                DateD = new DateTime(2017, 6, 11),
                Sort = 1417613397,
                Note = "c5f64aaa570c44b9996c1c8c7dd598c26b0773d6a72b42df843dd47a3fdc7a5b493459ae9a2b4fd1baf0ccbe4956f4bd3b577a7cc00a4c24accf9220f15f569d1ba2ff513b234c37b734b4c2bba62949ffef0bf8275347599b9e23dcdc73dfb16cf93d9a130f4526abfc2743b71a4f6fdcca84e922ed4dafa7d991e0ec4f130091c74250699a40a1835c1af470012456016c35125f074359a55ee4e3d7c76f3721bda5691d24490289fadd41724ec8275091b0a16d224a92aaff58fd260c7a1bc454a48b6b724367a5885134ac40481c1d521cede2134440b6d4c797753e51a779148a330a58418699c0f7e2c6a6f6c1e13f11bb97b340bb9b54",
                Status = "b8d07fd04c6e4d51bd81a4d2a573908524527e99ea7f4ca7a9",
                MatchingReceive = true
            };

            // Act
            var serviceResult = await _companyUsersAppService.CreateAsync(input);

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("0f1cab52-9616-45c8-8058-ca8a4c541376"));
            result.UserMainId.ShouldBe(Guid.Parse("e9eda0d3-cf0f-4089-9863-f0475971cb3f"));
            result.JobName.ShouldBe("9b17da85a9d64a4087afa39c66ddae86248b1485cdbf4f8896");
            result.OfficePhone.ShouldBe("177fa25b857f4fb6b05284dfd1b01ed3bfcb1e558ce74d4eb1");
            result.ExtendedInformation.ShouldBe("86c1285657ab4b3db7171889c843ef80a25a722c1f41418d848d4b59130c59f502facf5a46654487a1f9e04176eacfdd20d9ae074f104ad1a49a094674d3cf00739e5ff951f0466ca44903c9a1c1ffe3b2975d063a3b4088b6687ec765775d067e1e53468af047339f8184f96ee5939b60c798fcde63471fa3d49ab129792cd5eef16ba7449a4656bab72ecadf9bb45b4c00dcb1f55b4973a0b612d7e3a467dae6dab6d414f546d5be52fdab22d1e2e34f166835e9eb4f7490d85b954d3fc035594dcb7b4ed3420399f354b607723a6e6644d830375a4528b93891cf0130a7f54cdf9780b9c743da85ccb7cfd715089dcc55a8df304b468dbd37");
            result.DateA.ShouldBe(new DateTime(2022, 8, 17));
            result.DateD.ShouldBe(new DateTime(2017, 6, 11));
            result.Sort.ShouldBe(1417613397);
            result.Note.ShouldBe("c5f64aaa570c44b9996c1c8c7dd598c26b0773d6a72b42df843dd47a3fdc7a5b493459ae9a2b4fd1baf0ccbe4956f4bd3b577a7cc00a4c24accf9220f15f569d1ba2ff513b234c37b734b4c2bba62949ffef0bf8275347599b9e23dcdc73dfb16cf93d9a130f4526abfc2743b71a4f6fdcca84e922ed4dafa7d991e0ec4f130091c74250699a40a1835c1af470012456016c35125f074359a55ee4e3d7c76f3721bda5691d24490289fadd41724ec8275091b0a16d224a92aaff58fd260c7a1bc454a48b6b724367a5885134ac40481c1d521cede2134440b6d4c797753e51a779148a330a58418699c0f7e2c6a6f6c1e13f11bb97b340bb9b54");
            result.Status.ShouldBe("b8d07fd04c6e4d51bd81a4d2a573908524527e99ea7f4ca7a9");
            result.MatchingReceive.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyUserUpdateDto()
            {
                CompanyMainId = Guid.Parse("f65bf2ec-a61c-40af-ac86-b33f5dd3854e"),
                UserMainId = Guid.Parse("f8ff5b57-93b6-4337-9b03-a00af88762e3"),
                JobName = "950b21b700654fc0b0f2efdda92db12817c0d7b3c0774b8b92",
                OfficePhone = "6268bf105b8a4f899a298ec4c1e76eeeb2ee0ebc910244f088",
                ExtendedInformation = "261b847afc6d4ea392a3263c7f0750b905daaded851b457bb62ab250720efbd48f3e2e8063454642b6d96ebf48eb9a1021291e2d71fd4f3f8785f27f95bfcb1cf7dacf6927294f9d945e5edcd7dcf64a4c35b3cee0bd4fe8a63069832e9d2b023ad43948258c425bb7e1e4fcdb1362065addcf3a139e4df283da7b34140e583de35419dd237141edab0fcb77d09a652f82de1dd9e2f74e03aa093ef758e460f3131e23c0f40e46c5a57a956d3028e9ff3aadfe976c1f41d7960d31ef2634e390e0c1690deaaa46aa8f4152e2a5becf5c54cba7c1dd6e44ef98720c353b83b92e97bba5faecbc4abe89442e0f9e32045cd537b7bd74254160abe7",
                DateA = new DateTime(2014, 10, 5),
                DateD = new DateTime(2019, 5, 21),
                Sort = 862403090,
                Note = "a88c8d4374034cd6909b1464e8aff392c5da6f795b164a4bb90f3a27f88a3bff1c7fd6e396aa4476955be5caa7b75fbddb6f7a5a4abb443d8702baae62eb4f1d29bd19a9b2c2488d9dd1a7bb33e3e2ad9e5d4a3646664d2f8d45e1e003866257dee8f265259f4430b079af4e98c2cf6001dd0908f9ab4c72b8f2e9e981ef10e98c07063c29e94d4bbbe78949ed153be57167aa6b17e54a6bbb6264304786a2b851237b5aa0fc48d19881535e57652e0172938a665ca640f4b4b91a1416f33c7df9b5acf27c1b4338a5f2c73d2ca17df8c16947934fa445e1972a8658d69e59b1b1fd4dbf2365499782dd3dc554e5a6ec7c6dfce8b51543e98db2",
                Status = "2183713bb6574584beebcdff6a8c86ec8e4897cd38934ad798",
                MatchingReceive = true
            };

            // Act
            var serviceResult = await _companyUsersAppService.UpdateAsync(Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"), input);

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f65bf2ec-a61c-40af-ac86-b33f5dd3854e"));
            result.UserMainId.ShouldBe(Guid.Parse("f8ff5b57-93b6-4337-9b03-a00af88762e3"));
            result.JobName.ShouldBe("950b21b700654fc0b0f2efdda92db12817c0d7b3c0774b8b92");
            result.OfficePhone.ShouldBe("6268bf105b8a4f899a298ec4c1e76eeeb2ee0ebc910244f088");
            result.ExtendedInformation.ShouldBe("261b847afc6d4ea392a3263c7f0750b905daaded851b457bb62ab250720efbd48f3e2e8063454642b6d96ebf48eb9a1021291e2d71fd4f3f8785f27f95bfcb1cf7dacf6927294f9d945e5edcd7dcf64a4c35b3cee0bd4fe8a63069832e9d2b023ad43948258c425bb7e1e4fcdb1362065addcf3a139e4df283da7b34140e583de35419dd237141edab0fcb77d09a652f82de1dd9e2f74e03aa093ef758e460f3131e23c0f40e46c5a57a956d3028e9ff3aadfe976c1f41d7960d31ef2634e390e0c1690deaaa46aa8f4152e2a5becf5c54cba7c1dd6e44ef98720c353b83b92e97bba5faecbc4abe89442e0f9e32045cd537b7bd74254160abe7");
            result.DateA.ShouldBe(new DateTime(2014, 10, 5));
            result.DateD.ShouldBe(new DateTime(2019, 5, 21));
            result.Sort.ShouldBe(862403090);
            result.Note.ShouldBe("a88c8d4374034cd6909b1464e8aff392c5da6f795b164a4bb90f3a27f88a3bff1c7fd6e396aa4476955be5caa7b75fbddb6f7a5a4abb443d8702baae62eb4f1d29bd19a9b2c2488d9dd1a7bb33e3e2ad9e5d4a3646664d2f8d45e1e003866257dee8f265259f4430b079af4e98c2cf6001dd0908f9ab4c72b8f2e9e981ef10e98c07063c29e94d4bbbe78949ed153be57167aa6b17e54a6bbb6264304786a2b851237b5aa0fc48d19881535e57652e0172938a665ca640f4b4b91a1416f33c7df9b5acf27c1b4338a5f2c73d2ca17df8c16947934fa445e1972a8658d69e59b1b1fd4dbf2365499782dd3dc554e5a6ec7c6dfce8b51543e98db2");
            result.Status.ShouldBe("2183713bb6574584beebcdff6a8c86ec8e4897cd38934ad798");
            result.MatchingReceive.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyUsersAppService.DeleteAsync(Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"));

            // Assert
            var result = await _companyUserRepository.FindAsync(c => c.Id == Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"));

            result.ShouldBeNull();
        }
    }
}