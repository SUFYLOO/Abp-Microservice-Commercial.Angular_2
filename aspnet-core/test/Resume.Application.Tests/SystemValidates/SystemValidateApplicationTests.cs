using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemValidates
{
    public class SystemValidatesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemValidatesAppService _systemValidatesAppService;
        private readonly IRepository<SystemValidate, Guid> _systemValidateRepository;

        public SystemValidatesAppServiceTests()
        {
            _systemValidatesAppService = GetRequiredService<ISystemValidatesAppService>();
            _systemValidateRepository = GetRequiredService<IRepository<SystemValidate, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemValidatesAppService.GetListAsync(new GetSystemValidatesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f39cfc47-3dbe-4b74-a654-f8b729ef0c43")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemValidatesAppService.GetAsync(Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemValidateCreateDto
            {
                Param = "a07a26d4eb7745c1992695d5886a0040b97919b7353240bdba2c164e189465ac73b1f1c6ce3e426abab4bba797a9f5680fa6b4e5678e4f359098f6c15eb57a2d9177c84f3951401685368557bdb1bd774a1d66a911a446d3a642cc3ab7897a274403c796",
                DateOpen = new DateTime(2010, 9, 25),
                ExtendedInformation = "fe08fe42048c4f5ea7aaba93cef9ecf6f6a3371afbe4481c94d1679d30bf6d0b9d58d201795a477c95be7039a8b59363c6076bd0d60f447f85ebc04b560f4a37a5aadf5b03da416a9f005a401a5755f8161c8eca08b7439cb4fba2ac60a3e431359422d1bc0945a88d67c12364fd687db6e5d68a84e74f0cb11b24b800262554eca175ec7fb34494bf892c4e724018ea103152811d194f64993b319511220976e32c754145c94892a741154c79f66c0b948d80ed1c434edfa2150d432cf01d741268164dbedd4316aa14c968c93ebca83aa6b34a54b64414bc3a428018275e196d5958054c4143389eb9cbd3c2a0256cad6f71f95a1d4a5ebca3",
                DateA = new DateTime(2014, 4, 2),
                DateD = new DateTime(2016, 3, 25),
                Sort = 1971481889,
                Note = "ca2a17e8cdfc4e678db4bb22be243b2e4145ae7dcf9349709cb0f8b5e5f6db31cc7fb87bfe1f4720bb1a5a9704d42271688d9c2e789b40948317fe47a3877eab941a77c81fa34e7bad308ad4f34b5cad6ebe2f9b1ed4452a8edeb526be44933e56a9f94b4cbf47c1b5cbf7df3fe6df5f67d14fbfbcc640ca9191e04b1ced0aed204de89430334036aaa678f0d1c4a75ff5c4b95d121348e68b6299066ed983b86decfdcee0484a239a2eeb97dec2314d798ed226bd194b84b806e77b044a6720f33248217823467a985f7d8cc6020a96d06b8f9165b341b09afb0e777422abb487c080cbdd274cdfa20dcba0e019aad247e8454fa4da4c5c9769",
                Status = "0221af90c1a04059a828a5c3630bceef5c31576625944e22b3"
            };

            // Act
            var serviceResult = await _systemValidatesAppService.CreateAsync(input);

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Param.ShouldBe("a07a26d4eb7745c1992695d5886a0040b97919b7353240bdba2c164e189465ac73b1f1c6ce3e426abab4bba797a9f5680fa6b4e5678e4f359098f6c15eb57a2d9177c84f3951401685368557bdb1bd774a1d66a911a446d3a642cc3ab7897a274403c796");
            result.DateOpen.ShouldBe(new DateTime(2010, 9, 25));
            result.ExtendedInformation.ShouldBe("fe08fe42048c4f5ea7aaba93cef9ecf6f6a3371afbe4481c94d1679d30bf6d0b9d58d201795a477c95be7039a8b59363c6076bd0d60f447f85ebc04b560f4a37a5aadf5b03da416a9f005a401a5755f8161c8eca08b7439cb4fba2ac60a3e431359422d1bc0945a88d67c12364fd687db6e5d68a84e74f0cb11b24b800262554eca175ec7fb34494bf892c4e724018ea103152811d194f64993b319511220976e32c754145c94892a741154c79f66c0b948d80ed1c434edfa2150d432cf01d741268164dbedd4316aa14c968c93ebca83aa6b34a54b64414bc3a428018275e196d5958054c4143389eb9cbd3c2a0256cad6f71f95a1d4a5ebca3");
            result.DateA.ShouldBe(new DateTime(2014, 4, 2));
            result.DateD.ShouldBe(new DateTime(2016, 3, 25));
            result.Sort.ShouldBe(1971481889);
            result.Note.ShouldBe("ca2a17e8cdfc4e678db4bb22be243b2e4145ae7dcf9349709cb0f8b5e5f6db31cc7fb87bfe1f4720bb1a5a9704d42271688d9c2e789b40948317fe47a3877eab941a77c81fa34e7bad308ad4f34b5cad6ebe2f9b1ed4452a8edeb526be44933e56a9f94b4cbf47c1b5cbf7df3fe6df5f67d14fbfbcc640ca9191e04b1ced0aed204de89430334036aaa678f0d1c4a75ff5c4b95d121348e68b6299066ed983b86decfdcee0484a239a2eeb97dec2314d798ed226bd194b84b806e77b044a6720f33248217823467a985f7d8cc6020a96d06b8f9165b341b09afb0e777422abb487c080cbdd274cdfa20dcba0e019aad247e8454fa4da4c5c9769");
            result.Status.ShouldBe("0221af90c1a04059a828a5c3630bceef5c31576625944e22b3");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemValidateUpdateDto()
            {
                Param = "acd6a6cbf9d5469fa69f6fec94005b89367dd2f6b75e476f9374d4f7954f049315624ccdf11645a6a0dafee66f2500c481823e657e4548a3aa1d328b90070211cf7b6a46629545d4bbe0a4038e91b0f1fa39f952697a447daeb2d28e49fde808f163cefa",
                DateOpen = new DateTime(2002, 3, 25),
                ExtendedInformation = "34ee56f6a53744ff919c6ed6dfb982d5539e3a77cf51424287dd0d731ef8268f915529a25ded4be1ae36878d3098e18ca300ed7eefad43069f21616e704ff70e2413d27754c8431aa472e6b7d4025ce913aa64c31efc44f189eb2f7f2b3771e3086b299944cd472bb6185bad74c5b90d5391cf810d014266bbe61f3cdad538910b21a3cf9103481795bce7e9d5e6f89ab4b7f4c5d4154a64a37e5655ca5ee81e72e36449f37f42dc8a9f762c1d67c32f522e1eb0a8904bc6b3af0a99978a19dfc2feff8988d24d8d94081f150f1cfa5868f0e5cc512f415f827160561c4e13c618f4ecc9a77347bebc6905b70c0b9ec0a5a53d5edccb426aa7e4",
                DateA = new DateTime(2006, 1, 19),
                DateD = new DateTime(2016, 3, 11),
                Sort = 960526370,
                Note = "b1a34b7cd4eb4c6e9b2a004baf23b127bc278ab338984cbe89bd1695fc91ea9e5dda0c92537343c8b9ec447a14ff8863b26454b461204e0480a0cdab8bf6555b3e794e5f483d4319875f600b1fb9b33a79180fff9c924038a9e8bac839bd544d54aa15b2544f4a91a0e99504cc6ef8c3984b2791027a43e9b5675284caa2245e071e532bcff34731b1dbcd441ef23a040afb9bf8e54c448e88e43be255217539809a3f7303704c66930a92eaca0b1ea9344bbab4fbbd4652939a799e31bfc1c219d75dd75bb9491cadd23152841f1af9b22615f396d24af68865c08c651e988175e4f60407f241bd83c3a80898893b1128c0179c821d47a89608",
                Status = "4444e6c30c9942d28325fe174d7a4a159fb9295030af4d3188"
            };

            // Act
            var serviceResult = await _systemValidatesAppService.UpdateAsync(Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"), input);

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Param.ShouldBe("acd6a6cbf9d5469fa69f6fec94005b89367dd2f6b75e476f9374d4f7954f049315624ccdf11645a6a0dafee66f2500c481823e657e4548a3aa1d328b90070211cf7b6a46629545d4bbe0a4038e91b0f1fa39f952697a447daeb2d28e49fde808f163cefa");
            result.DateOpen.ShouldBe(new DateTime(2002, 3, 25));
            result.ExtendedInformation.ShouldBe("34ee56f6a53744ff919c6ed6dfb982d5539e3a77cf51424287dd0d731ef8268f915529a25ded4be1ae36878d3098e18ca300ed7eefad43069f21616e704ff70e2413d27754c8431aa472e6b7d4025ce913aa64c31efc44f189eb2f7f2b3771e3086b299944cd472bb6185bad74c5b90d5391cf810d014266bbe61f3cdad538910b21a3cf9103481795bce7e9d5e6f89ab4b7f4c5d4154a64a37e5655ca5ee81e72e36449f37f42dc8a9f762c1d67c32f522e1eb0a8904bc6b3af0a99978a19dfc2feff8988d24d8d94081f150f1cfa5868f0e5cc512f415f827160561c4e13c618f4ecc9a77347bebc6905b70c0b9ec0a5a53d5edccb426aa7e4");
            result.DateA.ShouldBe(new DateTime(2006, 1, 19));
            result.DateD.ShouldBe(new DateTime(2016, 3, 11));
            result.Sort.ShouldBe(960526370);
            result.Note.ShouldBe("b1a34b7cd4eb4c6e9b2a004baf23b127bc278ab338984cbe89bd1695fc91ea9e5dda0c92537343c8b9ec447a14ff8863b26454b461204e0480a0cdab8bf6555b3e794e5f483d4319875f600b1fb9b33a79180fff9c924038a9e8bac839bd544d54aa15b2544f4a91a0e99504cc6ef8c3984b2791027a43e9b5675284caa2245e071e532bcff34731b1dbcd441ef23a040afb9bf8e54c448e88e43be255217539809a3f7303704c66930a92eaca0b1ea9344bbab4fbbd4652939a799e31bfc1c219d75dd75bb9491cadd23152841f1af9b22615f396d24af68865c08c651e988175e4f60407f241bd83c3a80898893b1128c0179c821d47a89608");
            result.Status.ShouldBe("4444e6c30c9942d28325fe174d7a4a159fb9295030af4d3188");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemValidatesAppService.DeleteAsync(Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"));

            // Assert
            var result = await _systemValidateRepository.FindAsync(c => c.Id == Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"));

            result.ShouldBeNull();
        }
    }
}