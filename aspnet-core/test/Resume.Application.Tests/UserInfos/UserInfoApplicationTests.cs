using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserInfos
{
    public class UserInfosAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserInfosAppService _userInfosAppService;
        private readonly IRepository<UserInfo, Guid> _userInfoRepository;

        public UserInfosAppServiceTests()
        {
            _userInfosAppService = GetRequiredService<IUserInfosAppService>();
            _userInfoRepository = GetRequiredService<IRepository<UserInfo, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userInfosAppService.GetListAsync(new GetUserInfosInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("8eb957a0-6b33-4b29-9392-02d6de5755f5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userInfosAppService.GetAsync(Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserInfoCreateDto
            {
                UserMainId = Guid.Parse("7d9fe03c-fed1-406e-933e-cffe2e7dda42"),
                NameC = "51d3d7cbe31345c19cf74bfb1f20bc27feaddf539824452fa4",
                NameE = "bf19853b6ff24c68acd09291f2f4ce83151c201e96354139aa3505493a4e3c04e3d4f75dcb244eada35606eab7a1db794f10cc59866547909d8f1e10fba0a85cd914a743b2274c4c99a24e73c714ea583de380dec53d4f808d98dc593d8126a33f4766ca",
                IdentityNo = "c9d51a640b6b4c53ae3f6446344f95e2771caf75a3dd432ba3",
                BirthDate = new DateTime(2019, 8, 6),
                SexCode = "293d81126a9844d3b63bd76eb559c41fce49acd94dd9469e82",
                BloodCode = "3db438cd23a24789bcb51de87f648f4b57565f60c6d24c9182",
                PlaceOfBirthCode = "a27a5cdfce2e4f8ab59a3112e472bcaaa7c09b5f6b4f4fbbb9",
                PassportNo = "24e577c53b9f49afb03b0a33fce00f43c78ada2591254eab90",
                NationalityCode = "3a970b08857c469885253f36236b07f52dc066abdb874aefa2",
                ResidenceNo = "e8affdbce0c54443b0f68c8df4e0a5e803fbd361102247b5b9",
                ExtendedInformation = "d9343817a7b54ca0bfd237bf204c0130e3a2a29028864b7894e7b1e9651404a1871cb5ec6c5f424a86a80d31c20c8916385377b5c10646f0918beb2dff0f0829a4f09cb02a9940a9943cb5d7edf8e8e3208533f581fc4c83ab25715ac6855301386e4487353841d3ac5ad835b8a0058a4f7151958f474868b011c8a24d6f2ad5ec568b018ed74c4cb3285006f36d5c47d7a3a663fd2e4230855e6fda4c5db72e1b4af43b372b42cba160973c442d07f72d7b62e0f738440492cfe1125a4c0f8ad9fdfedc3a2b4d49a8a0f91e077e77a083cfc9d6688c4e2a8ddf15fdcdfbf182e3b8b6437a564de6bc68e6e231a1455a341d561fb5814125912d",
                DateA = new DateTime(2007, 1, 8),
                DateD = new DateTime(2008, 5, 2),
                Sort = 824116253,
                Note = "685a76f96358418cb0704fea3e2befb36cce3cd16292464cabe66f0db5f26abcf282ef383d2f46baa972f1dd406e1844708dcf051f034e0d85fcf2e815a01958509aeb3235844994abb0a8f3742122796f8cccc41b8242898fa5f9ed7a3e6b8f18d2d8c12b8345d0b482fdea1a034d38c53b141821324eecae3290a73776a13361af998b79b342659ca9e079e76f4f1ded2c45c5aa3643349c9ea59c76975ae24fa1d6f89fd9474d992cb6b1a2e42964f34e835f1123451ea3d2fc67b72ff056989cbe9ba9c14297a9890f521d44f1138ffdef535b194f7f8481eed71dddbffe6c9bdba9d1a54fd5ac50c4dfc7ae3904d90e233eef5b40fe83f3",
                Status = "f52b0f05bc5343298afa842a2f3efce45d506c7022644712a6"
            };

            // Act
            var serviceResult = await _userInfosAppService.CreateAsync(input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("7d9fe03c-fed1-406e-933e-cffe2e7dda42"));
            result.NameC.ShouldBe("51d3d7cbe31345c19cf74bfb1f20bc27feaddf539824452fa4");
            result.NameE.ShouldBe("bf19853b6ff24c68acd09291f2f4ce83151c201e96354139aa3505493a4e3c04e3d4f75dcb244eada35606eab7a1db794f10cc59866547909d8f1e10fba0a85cd914a743b2274c4c99a24e73c714ea583de380dec53d4f808d98dc593d8126a33f4766ca");
            result.IdentityNo.ShouldBe("c9d51a640b6b4c53ae3f6446344f95e2771caf75a3dd432ba3");
            result.BirthDate.ShouldBe(new DateTime(2019, 8, 6));
            result.SexCode.ShouldBe("293d81126a9844d3b63bd76eb559c41fce49acd94dd9469e82");
            result.BloodCode.ShouldBe("3db438cd23a24789bcb51de87f648f4b57565f60c6d24c9182");
            result.PlaceOfBirthCode.ShouldBe("a27a5cdfce2e4f8ab59a3112e472bcaaa7c09b5f6b4f4fbbb9");
            result.PassportNo.ShouldBe("24e577c53b9f49afb03b0a33fce00f43c78ada2591254eab90");
            result.NationalityCode.ShouldBe("3a970b08857c469885253f36236b07f52dc066abdb874aefa2");
            result.ResidenceNo.ShouldBe("e8affdbce0c54443b0f68c8df4e0a5e803fbd361102247b5b9");
            result.ExtendedInformation.ShouldBe("d9343817a7b54ca0bfd237bf204c0130e3a2a29028864b7894e7b1e9651404a1871cb5ec6c5f424a86a80d31c20c8916385377b5c10646f0918beb2dff0f0829a4f09cb02a9940a9943cb5d7edf8e8e3208533f581fc4c83ab25715ac6855301386e4487353841d3ac5ad835b8a0058a4f7151958f474868b011c8a24d6f2ad5ec568b018ed74c4cb3285006f36d5c47d7a3a663fd2e4230855e6fda4c5db72e1b4af43b372b42cba160973c442d07f72d7b62e0f738440492cfe1125a4c0f8ad9fdfedc3a2b4d49a8a0f91e077e77a083cfc9d6688c4e2a8ddf15fdcdfbf182e3b8b6437a564de6bc68e6e231a1455a341d561fb5814125912d");
            result.DateA.ShouldBe(new DateTime(2007, 1, 8));
            result.DateD.ShouldBe(new DateTime(2008, 5, 2));
            result.Sort.ShouldBe(824116253);
            result.Note.ShouldBe("685a76f96358418cb0704fea3e2befb36cce3cd16292464cabe66f0db5f26abcf282ef383d2f46baa972f1dd406e1844708dcf051f034e0d85fcf2e815a01958509aeb3235844994abb0a8f3742122796f8cccc41b8242898fa5f9ed7a3e6b8f18d2d8c12b8345d0b482fdea1a034d38c53b141821324eecae3290a73776a13361af998b79b342659ca9e079e76f4f1ded2c45c5aa3643349c9ea59c76975ae24fa1d6f89fd9474d992cb6b1a2e42964f34e835f1123451ea3d2fc67b72ff056989cbe9ba9c14297a9890f521d44f1138ffdef535b194f7f8481eed71dddbffe6c9bdba9d1a54fd5ac50c4dfc7ae3904d90e233eef5b40fe83f3");
            result.Status.ShouldBe("f52b0f05bc5343298afa842a2f3efce45d506c7022644712a6");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserInfoUpdateDto()
            {
                UserMainId = Guid.Parse("3cd1fbe6-8a11-4869-8a02-c50b0451ae78"),
                NameC = "06d3610c8a3a40ab96b8680dd6ae42e80e96ff765aae4da494",
                NameE = "b7117068d3c6457494e62d5274196addcd50d177d9dc46e0afc2891b99c6bb48b9c1e865ffac41298714d3e08839c4020ca051c92d7d439e963f437f77220e6ca9ea790113dc4683ba8fc8b7af09ab3c67f3a6599f1a418b86274f19a60afa2a88a9dd9a",
                IdentityNo = "f61960ab488545aba2f1b137dc8fa9e582181ef18e614e7cbc",
                BirthDate = new DateTime(2015, 3, 2),
                SexCode = "e497954029a94fd29b49e01ca8fdd5df2e0e3ac734014e819a",
                BloodCode = "f4fef081e98047e69d3e31fbcbe0aad3b09f0c3619994fb685",
                PlaceOfBirthCode = "6bbb845ee39c439ab6cac37a1e1dd0d74597de02c4b24ff297",
                PassportNo = "aa1661d1de9c464faff7cb7603093b64edf6f99a5d3441a596",
                NationalityCode = "d41e6c789b3c43d3b0bcc2cd0adc0da9bbc468f7d1814123ba",
                ResidenceNo = "86ee894f49834ccab83811616768f188be4bef84da6845c585",
                ExtendedInformation = "ba637fb1c7f3445c86e9473d74fd24f7c20427b059a4415bae51ed7e5fdfe4a1d465d2a5df3e40308a83af23149ab425e65467d1d7ad4e33929e8fb7d01c7ccd4f449f270d304d5d917b56863bb23a03b17a9472b9f34f65a1ac32473d33403f0605903427874af086a98b8efb907c3864c8b46203774c4f9245680883df27b1a2c3cf92726448e2970a67a5212487d2c5a5219f875d41f0b8c218e9191beda576ba8e6e41564b2c96a9677b9cb416849de6bd7fc8ad4d2ca74f9fd3741c36d7f083a20400d8489982086dd35bcaded71b09132720c847b7ba52df3b65cf582b353fa0a886d94c938227da5acad51e85795a9eac106241d3bf5c",
                DateA = new DateTime(2000, 7, 27),
                DateD = new DateTime(2007, 6, 13),
                Sort = 1208065159,
                Note = "113a85e38f1a4aa9957f2d35eb40110616d5abc67439490182d6b6257a7cef7f771a1c88e59c4abf985c334c3b5da61b8cca1d4d61944fb9aef3050d0ef3d185438520896ecd4eb6a16aafe75882be757724772489464f7e86a7b0425cd500c512496ce8bf9f4e849790fcef5242bf30c08e6e64694f48f5973c10b3c9b5fc6f0313ba353fb44c719addab28a9e56139a426478e80cf4613a2b04153bb68d97241ff91210c6845419122e8dd5975661d92574955eb8d49bd8ba07a5ae22114934a805b6f62c94ee28f323f29753c037992699a04497c44fcbe540c74f0f70c99992f51298d084e8184b248ad8862d9bbf1af94708b75439185db",
                Status = "062ed279f950459ebe6c3374f875365e19b4d70e37e04799aa"
            };

            // Act
            var serviceResult = await _userInfosAppService.UpdateAsync(Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"), input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("3cd1fbe6-8a11-4869-8a02-c50b0451ae78"));
            result.NameC.ShouldBe("06d3610c8a3a40ab96b8680dd6ae42e80e96ff765aae4da494");
            result.NameE.ShouldBe("b7117068d3c6457494e62d5274196addcd50d177d9dc46e0afc2891b99c6bb48b9c1e865ffac41298714d3e08839c4020ca051c92d7d439e963f437f77220e6ca9ea790113dc4683ba8fc8b7af09ab3c67f3a6599f1a418b86274f19a60afa2a88a9dd9a");
            result.IdentityNo.ShouldBe("f61960ab488545aba2f1b137dc8fa9e582181ef18e614e7cbc");
            result.BirthDate.ShouldBe(new DateTime(2015, 3, 2));
            result.SexCode.ShouldBe("e497954029a94fd29b49e01ca8fdd5df2e0e3ac734014e819a");
            result.BloodCode.ShouldBe("f4fef081e98047e69d3e31fbcbe0aad3b09f0c3619994fb685");
            result.PlaceOfBirthCode.ShouldBe("6bbb845ee39c439ab6cac37a1e1dd0d74597de02c4b24ff297");
            result.PassportNo.ShouldBe("aa1661d1de9c464faff7cb7603093b64edf6f99a5d3441a596");
            result.NationalityCode.ShouldBe("d41e6c789b3c43d3b0bcc2cd0adc0da9bbc468f7d1814123ba");
            result.ResidenceNo.ShouldBe("86ee894f49834ccab83811616768f188be4bef84da6845c585");
            result.ExtendedInformation.ShouldBe("ba637fb1c7f3445c86e9473d74fd24f7c20427b059a4415bae51ed7e5fdfe4a1d465d2a5df3e40308a83af23149ab425e65467d1d7ad4e33929e8fb7d01c7ccd4f449f270d304d5d917b56863bb23a03b17a9472b9f34f65a1ac32473d33403f0605903427874af086a98b8efb907c3864c8b46203774c4f9245680883df27b1a2c3cf92726448e2970a67a5212487d2c5a5219f875d41f0b8c218e9191beda576ba8e6e41564b2c96a9677b9cb416849de6bd7fc8ad4d2ca74f9fd3741c36d7f083a20400d8489982086dd35bcaded71b09132720c847b7ba52df3b65cf582b353fa0a886d94c938227da5acad51e85795a9eac106241d3bf5c");
            result.DateA.ShouldBe(new DateTime(2000, 7, 27));
            result.DateD.ShouldBe(new DateTime(2007, 6, 13));
            result.Sort.ShouldBe(1208065159);
            result.Note.ShouldBe("113a85e38f1a4aa9957f2d35eb40110616d5abc67439490182d6b6257a7cef7f771a1c88e59c4abf985c334c3b5da61b8cca1d4d61944fb9aef3050d0ef3d185438520896ecd4eb6a16aafe75882be757724772489464f7e86a7b0425cd500c512496ce8bf9f4e849790fcef5242bf30c08e6e64694f48f5973c10b3c9b5fc6f0313ba353fb44c719addab28a9e56139a426478e80cf4613a2b04153bb68d97241ff91210c6845419122e8dd5975661d92574955eb8d49bd8ba07a5ae22114934a805b6f62c94ee28f323f29753c037992699a04497c44fcbe540c74f0f70c99992f51298d084e8184b248ad8862d9bbf1af94708b75439185db");
            result.Status.ShouldBe("062ed279f950459ebe6c3374f875365e19b4d70e37e04799aa");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userInfosAppService.DeleteAsync(Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"));

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"));

            result.ShouldBeNull();
        }
    }
}