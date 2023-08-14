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
            result.Items.Any(x => x.Id == Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("04945beb-0932-4223-8f3b-164de24900b5")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userInfosAppService.GetAsync(Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserInfoCreateDto
            {
                UserMainId = Guid.Parse("a41c3971-f9ae-4073-9ab1-ebd55deacf88"),
                NameC = "4152416525dd4abfb6db4509519efe1d4f1ed56172bc4d46ac",
                NameE = "b27a541cdc6f4eae9d851acd0ec9eaad6463a9d4199641a0b6f4b25a5d42d9edff1501aa503644919cb723b0933c2df8303599418bc64f1e97f256ffa6911e8f76ea9ab2cdb242159638c46ad2e3d03f14a7cc9ebcfe43b8b4b854bcaba58c6c2504b107",
                IdentityNo = "99139ac37b9542b9aa315e7536efc20b41d553f4b9b041888f",
                BirthDate = new DateTime(2014, 11, 16),
                SexCode = "fcb2273e803041e4a5efebfb6050ecae075b80894f7040d98d",
                BloodCode = "9040b4b4b7f0492ab47cc420ba56dae3f99a0ea4a6dc4195aa",
                PlaceOfBirthCode = "b144c210792c4851a5c314dff387320e339c95a0379e485bbc",
                PassportNo = "6ba1b05861c941c1bdfbe646adcaf61e30aeda9515b741aa90",
                NationalityCode = "61f5d20ddb9b4365ae050a57b50ded298bde0041034e4408b9",
                ResidenceNo = "bf5b28f559694fe2ab913176ed4bea8f8bbcd288d48742eb80",
                ExtendedInformation = "44afd756ab884970acd7773dc620ca16387be64308ec47338ac0cb27823a08fab4e9334889a84ff29a0fe2c61c02c613c3a6ea02f1d24cc4a97b0155b380f11aaa9b07761ab04b97b70da2a07d76a0fec70359f1ac234502b0d132b99bf2365802f488094e2844618701606793197e8db073c542ecab4781b991a40cce83a66e78957359464846dfbc5ea345534340a585cf9637649a4f3e8ac44f402528fa6ad8374c03c2ef45fcb31fce65ef104c0f463fcc6490d6428296ff44dad0668dd71a109c41774c4fd59bb48e5c96c453c460caae864e8048fab0815ecf2b303c1d5e7f5f36311644398403ed7e4d0edbb8b8e3e99ebc3949c89721",
                DateA = new DateTime(2003, 1, 2),
                DateD = new DateTime(2021, 7, 16),
                Sort = 606954612,
                Note = "6d9d09a46e86440e8a67e9f6d6076840749ae70f6cd5479bad40dc45abda9d24a6ec8687b14d4b65a4494598f05185a367efb4848fbb40b1958da800a2e3613604d4d99a4b8949379880d07e2ffd325f9bb09abe93794e2fa129cf57e65d7a6049161c51651d40c78b9b7d84f64da354276b17b126fe4683b551c99c5d03a27fba48ac05215e44dfa2b289854d63541b84071c9126fc41c394075686ff74ec2c3b4e2a048f5f421a97dc2dfb705af9841679749ded43460eb1540962b811e1ee2620c4f52d7a42929a322c67676b997ee437de9301454908beb7c4fcd1e0cebcf80644362d6d4eb48bacbcf7435b09deebf10d3569f040c5ad5b",
                Status = "e87ef39b7b0d4d03b45055ea068fa437b1eb22161ee4481a94"
            };

            // Act
            var serviceResult = await _userInfosAppService.CreateAsync(input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("a41c3971-f9ae-4073-9ab1-ebd55deacf88"));
            result.NameC.ShouldBe("4152416525dd4abfb6db4509519efe1d4f1ed56172bc4d46ac");
            result.NameE.ShouldBe("b27a541cdc6f4eae9d851acd0ec9eaad6463a9d4199641a0b6f4b25a5d42d9edff1501aa503644919cb723b0933c2df8303599418bc64f1e97f256ffa6911e8f76ea9ab2cdb242159638c46ad2e3d03f14a7cc9ebcfe43b8b4b854bcaba58c6c2504b107");
            result.IdentityNo.ShouldBe("99139ac37b9542b9aa315e7536efc20b41d553f4b9b041888f");
            result.BirthDate.ShouldBe(new DateTime(2014, 11, 16));
            result.SexCode.ShouldBe("fcb2273e803041e4a5efebfb6050ecae075b80894f7040d98d");
            result.BloodCode.ShouldBe("9040b4b4b7f0492ab47cc420ba56dae3f99a0ea4a6dc4195aa");
            result.PlaceOfBirthCode.ShouldBe("b144c210792c4851a5c314dff387320e339c95a0379e485bbc");
            result.PassportNo.ShouldBe("6ba1b05861c941c1bdfbe646adcaf61e30aeda9515b741aa90");
            result.NationalityCode.ShouldBe("61f5d20ddb9b4365ae050a57b50ded298bde0041034e4408b9");
            result.ResidenceNo.ShouldBe("bf5b28f559694fe2ab913176ed4bea8f8bbcd288d48742eb80");
            result.ExtendedInformation.ShouldBe("44afd756ab884970acd7773dc620ca16387be64308ec47338ac0cb27823a08fab4e9334889a84ff29a0fe2c61c02c613c3a6ea02f1d24cc4a97b0155b380f11aaa9b07761ab04b97b70da2a07d76a0fec70359f1ac234502b0d132b99bf2365802f488094e2844618701606793197e8db073c542ecab4781b991a40cce83a66e78957359464846dfbc5ea345534340a585cf9637649a4f3e8ac44f402528fa6ad8374c03c2ef45fcb31fce65ef104c0f463fcc6490d6428296ff44dad0668dd71a109c41774c4fd59bb48e5c96c453c460caae864e8048fab0815ecf2b303c1d5e7f5f36311644398403ed7e4d0edbb8b8e3e99ebc3949c89721");
            result.DateA.ShouldBe(new DateTime(2003, 1, 2));
            result.DateD.ShouldBe(new DateTime(2021, 7, 16));
            result.Sort.ShouldBe(606954612);
            result.Note.ShouldBe("6d9d09a46e86440e8a67e9f6d6076840749ae70f6cd5479bad40dc45abda9d24a6ec8687b14d4b65a4494598f05185a367efb4848fbb40b1958da800a2e3613604d4d99a4b8949379880d07e2ffd325f9bb09abe93794e2fa129cf57e65d7a6049161c51651d40c78b9b7d84f64da354276b17b126fe4683b551c99c5d03a27fba48ac05215e44dfa2b289854d63541b84071c9126fc41c394075686ff74ec2c3b4e2a048f5f421a97dc2dfb705af9841679749ded43460eb1540962b811e1ee2620c4f52d7a42929a322c67676b997ee437de9301454908beb7c4fcd1e0cebcf80644362d6d4eb48bacbcf7435b09deebf10d3569f040c5ad5b");
            result.Status.ShouldBe("e87ef39b7b0d4d03b45055ea068fa437b1eb22161ee4481a94");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserInfoUpdateDto()
            {
                UserMainId = Guid.Parse("9d78f055-74f9-4512-99e6-1eae3e8b82b9"),
                NameC = "bb9ed79ab7fd4c80ad87d38eca24f3b5e86dd3df37bd418f97",
                NameE = "05e3bec72d0c477e81ba77432ac0b10b2e1ab55c75154b60baf3fdc457996f3156aefa21154b40fe95674c3caac54c5fe5d9541ba439401eab334fbcad65718e6df530d2a00f4a48a0e7224095eb771c12480864076342f1b261bcfa321fe32226edf2b2",
                IdentityNo = "eb1ba87d520c44548ee15191fce7657a5c2e21df0d6c47f59c",
                BirthDate = new DateTime(2010, 7, 5),
                SexCode = "26913b2ebe034bd6a1fb6e4d4838a4c24fb1bef94b12447c98",
                BloodCode = "71d72f3a31014e43a54566f405d5fd9b7ff593fc66824f93be",
                PlaceOfBirthCode = "48d842cb1b004304a36d3d130eb38c86f07b0cbc67fb4fcca8",
                PassportNo = "d21da6443483418f817c1367cb73153f89ef6634173d41dd98",
                NationalityCode = "92475b8c214940e7b661dd44ee0c3eaf459002a851974063b1",
                ResidenceNo = "1a5bddf34eff4908afeebb2f3c317bcbebd239ad5642429daa",
                ExtendedInformation = "7e0adb916b824bd58badfec238ef73cf372d8873323d4593ba8137f597765bd1614904667cb54b9bb3fd843a5e800aff36cabca0630840069ae3c2f1302d05524e3eb0cb0d0644d293d90f97b34b612ea709080c2b8a48d293090702507ed7a3faf260b67347412c8daea5c17826a397cdecd80115d54f30b47229fe86fdfcd22bbaba83c63f49f989f5b9cc948b77bb270ca3d668694b5f9e1a67530f47d563a45299cff46848f0895da2b638ffa2653e01e264c445485394c53441b19f2aef152ea826a16143569f39536864935cf4b4fb6af427b04a6b9095909a94e612370df73e140be748478f7d05fd40605b2c1cb45d909d724d8b9ec0",
                DateA = new DateTime(2002, 6, 9),
                DateD = new DateTime(2006, 5, 25),
                Sort = 272920913,
                Note = "79be7c3db1e142d288165744cde8874bd0864a30bab64e5ba4432d76854cb033d01bbd496f5e4fefab24b9eb20e1142a0d5050c0c4e54d3784f4a0d6b11676c16af19451e0c84231b9996e1a1743c4122e0152c786de49d8bea75d47fbcbd2ecf9b3728ec2e44442b18f386065cf24355f0c9adefcd74085bea93fcc5607ad58cb84d0b43a8349df826740cdfe1d9b5ecf949f6ebe264ab8abfcfda6a75f5b3218cb3030f7a249e4a9fa15f2586232681229bdc7b87b49588dcab9ca7365f42002eb1628e3254de3b2958e2c71d3c0fcf157b4af878d4d6191772da4d7b10159347a1b0ba08742009e30827c077331c7241309a7bd634786bfa7",
                Status = "8b3bd54bb7de41f3a8627de76b11d38b03163c8bbfa6493da5"
            };

            // Act
            var serviceResult = await _userInfosAppService.UpdateAsync(Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"), input);

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("9d78f055-74f9-4512-99e6-1eae3e8b82b9"));
            result.NameC.ShouldBe("bb9ed79ab7fd4c80ad87d38eca24f3b5e86dd3df37bd418f97");
            result.NameE.ShouldBe("05e3bec72d0c477e81ba77432ac0b10b2e1ab55c75154b60baf3fdc457996f3156aefa21154b40fe95674c3caac54c5fe5d9541ba439401eab334fbcad65718e6df530d2a00f4a48a0e7224095eb771c12480864076342f1b261bcfa321fe32226edf2b2");
            result.IdentityNo.ShouldBe("eb1ba87d520c44548ee15191fce7657a5c2e21df0d6c47f59c");
            result.BirthDate.ShouldBe(new DateTime(2010, 7, 5));
            result.SexCode.ShouldBe("26913b2ebe034bd6a1fb6e4d4838a4c24fb1bef94b12447c98");
            result.BloodCode.ShouldBe("71d72f3a31014e43a54566f405d5fd9b7ff593fc66824f93be");
            result.PlaceOfBirthCode.ShouldBe("48d842cb1b004304a36d3d130eb38c86f07b0cbc67fb4fcca8");
            result.PassportNo.ShouldBe("d21da6443483418f817c1367cb73153f89ef6634173d41dd98");
            result.NationalityCode.ShouldBe("92475b8c214940e7b661dd44ee0c3eaf459002a851974063b1");
            result.ResidenceNo.ShouldBe("1a5bddf34eff4908afeebb2f3c317bcbebd239ad5642429daa");
            result.ExtendedInformation.ShouldBe("7e0adb916b824bd58badfec238ef73cf372d8873323d4593ba8137f597765bd1614904667cb54b9bb3fd843a5e800aff36cabca0630840069ae3c2f1302d05524e3eb0cb0d0644d293d90f97b34b612ea709080c2b8a48d293090702507ed7a3faf260b67347412c8daea5c17826a397cdecd80115d54f30b47229fe86fdfcd22bbaba83c63f49f989f5b9cc948b77bb270ca3d668694b5f9e1a67530f47d563a45299cff46848f0895da2b638ffa2653e01e264c445485394c53441b19f2aef152ea826a16143569f39536864935cf4b4fb6af427b04a6b9095909a94e612370df73e140be748478f7d05fd40605b2c1cb45d909d724d8b9ec0");
            result.DateA.ShouldBe(new DateTime(2002, 6, 9));
            result.DateD.ShouldBe(new DateTime(2006, 5, 25));
            result.Sort.ShouldBe(272920913);
            result.Note.ShouldBe("79be7c3db1e142d288165744cde8874bd0864a30bab64e5ba4432d76854cb033d01bbd496f5e4fefab24b9eb20e1142a0d5050c0c4e54d3784f4a0d6b11676c16af19451e0c84231b9996e1a1743c4122e0152c786de49d8bea75d47fbcbd2ecf9b3728ec2e44442b18f386065cf24355f0c9adefcd74085bea93fcc5607ad58cb84d0b43a8349df826740cdfe1d9b5ecf949f6ebe264ab8abfcfda6a75f5b3218cb3030f7a249e4a9fa15f2586232681229bdc7b87b49588dcab9ca7365f42002eb1628e3254de3b2958e2c71d3c0fcf157b4af878d4d6191772da4d7b10159347a1b0ba08742009e30827c077331c7241309a7bd634786bfa7");
            result.Status.ShouldBe("8b3bd54bb7de41f3a8627de76b11d38b03163c8bbfa6493da5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userInfosAppService.DeleteAsync(Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"));

            // Assert
            var result = await _userInfoRepository.FindAsync(c => c.Id == Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"));

            result.ShouldBeNull();
        }
    }
}