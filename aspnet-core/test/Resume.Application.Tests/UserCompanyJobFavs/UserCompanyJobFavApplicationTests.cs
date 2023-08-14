using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobFavsAppService _userCompanyJobFavsAppService;
        private readonly IRepository<UserCompanyJobFav, Guid> _userCompanyJobFavRepository;

        public UserCompanyJobFavsAppServiceTests()
        {
            _userCompanyJobFavsAppService = GetRequiredService<IUserCompanyJobFavsAppService>();
            _userCompanyJobFavRepository = GetRequiredService<IRepository<UserCompanyJobFav, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobFavsAppService.GetListAsync(new GetUserCompanyJobFavsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e4c8c14c-bbbe-4b89-b183-d898f1b5d612")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobFavsAppService.GetAsync(Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavCreateDto
            {
                UserMainId = Guid.Parse("a720f55c-58e5-4060-8434-fc34ba72a4e7"),
                CompanyJobId = Guid.Parse("58091b41-866f-4cc9-b8d9-04979cd82ade"),
                ExtendedInformation = "67dd0063f4ca42a0a3466a9bc63b23799b74f4141311466b9cd5ea62cebdd66990addafbbe8649f2a3eebd614e47690f04c7b5edd8474edd9df546bf3cb6cf93dba0a4978b894ed49eddf4dac60c0260de5e9ab0cfe2428c9a3179f62fcdbf2051ef2c3178ff437e9fd69b1dde9d6a298bf2700a54b74eb5b5b285a1104af0d0def662f3988b4c0f8061653c95a64b4bc7650924a62e467cb687bb6ec94f8282ab3fe8ae0acd4e158a6f3e351d478bc9a2186b25b8e04702a25c68bccac707593ec713f09bfd4d908bb63f1179acc0a885169e388af246ab817aac89ab24af4a819cda6073f0424a969debbebbc4e5b9b53a9b020cfc445c9f71",
                DateA = new DateTime(2021, 5, 13),
                DateD = new DateTime(2010, 11, 8),
                Sort = 920926294,
                Note = "32607a184c5842c1a06363d5c4b24686ac25d0c0a883446687c29322c490092febdaadf1718b4973a74b255faf4fdefacd0b37d255284275b8609dc0d1c80995bde2e3e7fc1b45ba8591db4ae969bee812f894f02358467dac662ea13e07ef7f216935d6aec04d0d82e0cbd0694c6f14569f29720693493099f01e1cdc30ee01c6f1a4bad8b3438bbe32cae174324d17ef9a198864144c1d80cb69be66e63bb60c811deb94534941a773e771b6f5bba60e59632b00af4b10b5a2805f66d86563e4c2f2e7a71340a29f43ee3cfa02ed1284fec3d0936c467daef5b64519bb44a7fbc08c3d27fe4455ab4beee7c1a483e7b9371b1e3762449e9918",
                Status = "67d5bacd00364b62bc21cf8f2e211010ed213f5dba0f4075b3"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("a720f55c-58e5-4060-8434-fc34ba72a4e7"));
            result.CompanyJobId.ShouldBe(Guid.Parse("58091b41-866f-4cc9-b8d9-04979cd82ade"));
            result.ExtendedInformation.ShouldBe("67dd0063f4ca42a0a3466a9bc63b23799b74f4141311466b9cd5ea62cebdd66990addafbbe8649f2a3eebd614e47690f04c7b5edd8474edd9df546bf3cb6cf93dba0a4978b894ed49eddf4dac60c0260de5e9ab0cfe2428c9a3179f62fcdbf2051ef2c3178ff437e9fd69b1dde9d6a298bf2700a54b74eb5b5b285a1104af0d0def662f3988b4c0f8061653c95a64b4bc7650924a62e467cb687bb6ec94f8282ab3fe8ae0acd4e158a6f3e351d478bc9a2186b25b8e04702a25c68bccac707593ec713f09bfd4d908bb63f1179acc0a885169e388af246ab817aac89ab24af4a819cda6073f0424a969debbebbc4e5b9b53a9b020cfc445c9f71");
            result.DateA.ShouldBe(new DateTime(2021, 5, 13));
            result.DateD.ShouldBe(new DateTime(2010, 11, 8));
            result.Sort.ShouldBe(920926294);
            result.Note.ShouldBe("32607a184c5842c1a06363d5c4b24686ac25d0c0a883446687c29322c490092febdaadf1718b4973a74b255faf4fdefacd0b37d255284275b8609dc0d1c80995bde2e3e7fc1b45ba8591db4ae969bee812f894f02358467dac662ea13e07ef7f216935d6aec04d0d82e0cbd0694c6f14569f29720693493099f01e1cdc30ee01c6f1a4bad8b3438bbe32cae174324d17ef9a198864144c1d80cb69be66e63bb60c811deb94534941a773e771b6f5bba60e59632b00af4b10b5a2805f66d86563e4c2f2e7a71340a29f43ee3cfa02ed1284fec3d0936c467daef5b64519bb44a7fbc08c3d27fe4455ab4beee7c1a483e7b9371b1e3762449e9918");
            result.Status.ShouldBe("67d5bacd00364b62bc21cf8f2e211010ed213f5dba0f4075b3");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobFavUpdateDto()
            {
                UserMainId = Guid.Parse("2e675f09-0a6c-4b0c-b78f-965123097012"),
                CompanyJobId = Guid.Parse("70169500-a9fe-4639-ae20-4fb941494071"),
                ExtendedInformation = "db74f45d9de04905a199ae4769da0a99e2aa3a102403445390416da3d2237367b6a60e4252f34efebd2c8ce409f2c0fbee23f73d423844d1845cd28748081f33c80d67c8b39d41d59e3e12806f177067a8e2389e84094e07a7e166f64baff257085df2de40fb40ffb813352688cf1694f484d01b12a04d5b851565b1a1101de8468e6675610e49578cf7677c8cb4cbacf8a23fc2742f409fa34a1eed542b2f1c73453c9a6caa476e8d07da90f6bd76e5cb176983ea8a47c39f7ab76e89059511f90e12673d1c434f91ec49828c2f020c458db94e566e43c1b899fd70afa277ec0468100bd7904377b2e0de2affa9ea020596b23a05024301a2c8",
                DateA = new DateTime(2018, 9, 22),
                DateD = new DateTime(2014, 3, 22),
                Sort = 363621352,
                Note = "8cc3d636e38f496b83a14f534c827df8d4a2f8112f4648a8a54bf0baa1c8d7e66ee115dd327749ca9417d8ef128209f054d0d748d1df45398084ad801f17ddbd0319c9063ed94e6d93062159b3f485a9abfa65d5b6294306a9b0e169652e19dfc8be4f5f2b8443579f3651eebf33c4859107900f57ff4649b6adb5e6a4cbbd472c6c36ff1f3e4469a5b0032c549a193ffc1dd860a0274abea8845c1c3d2c7fd2f325edef6358401db8c0743da1d0bc9b65cbca28cd2146f9a06b61a9dd58105209508839d15c418cb03f5f8baa01b598d84dbd268b0248bab93629dc9298c926e51f9bdf14e94c419a53fd15791fe6264f0d8bb419cc4f51b63e",
                Status = "61ba6c3bcd014033921bc8580a16f1964d9c3b5e9e9c448ab0"
            };

            // Act
            var serviceResult = await _userCompanyJobFavsAppService.UpdateAsync(Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"), input);

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("2e675f09-0a6c-4b0c-b78f-965123097012"));
            result.CompanyJobId.ShouldBe(Guid.Parse("70169500-a9fe-4639-ae20-4fb941494071"));
            result.ExtendedInformation.ShouldBe("db74f45d9de04905a199ae4769da0a99e2aa3a102403445390416da3d2237367b6a60e4252f34efebd2c8ce409f2c0fbee23f73d423844d1845cd28748081f33c80d67c8b39d41d59e3e12806f177067a8e2389e84094e07a7e166f64baff257085df2de40fb40ffb813352688cf1694f484d01b12a04d5b851565b1a1101de8468e6675610e49578cf7677c8cb4cbacf8a23fc2742f409fa34a1eed542b2f1c73453c9a6caa476e8d07da90f6bd76e5cb176983ea8a47c39f7ab76e89059511f90e12673d1c434f91ec49828c2f020c458db94e566e43c1b899fd70afa277ec0468100bd7904377b2e0de2affa9ea020596b23a05024301a2c8");
            result.DateA.ShouldBe(new DateTime(2018, 9, 22));
            result.DateD.ShouldBe(new DateTime(2014, 3, 22));
            result.Sort.ShouldBe(363621352);
            result.Note.ShouldBe("8cc3d636e38f496b83a14f534c827df8d4a2f8112f4648a8a54bf0baa1c8d7e66ee115dd327749ca9417d8ef128209f054d0d748d1df45398084ad801f17ddbd0319c9063ed94e6d93062159b3f485a9abfa65d5b6294306a9b0e169652e19dfc8be4f5f2b8443579f3651eebf33c4859107900f57ff4649b6adb5e6a4cbbd472c6c36ff1f3e4469a5b0032c549a193ffc1dd860a0274abea8845c1c3d2c7fd2f325edef6358401db8c0743da1d0bc9b65cbca28cd2146f9a06b61a9dd58105209508839d15c418cb03f5f8baa01b598d84dbd268b0248bab93629dc9298c926e51f9bdf14e94c419a53fd15791fe6264f0d8bb419cc4f51b63e");
            result.Status.ShouldBe("61ba6c3bcd014033921bc8580a16f1964d9c3b5e9e9c448ab0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobFavsAppService.DeleteAsync(Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"));

            // Assert
            var result = await _userCompanyJobFavRepository.FindAsync(c => c.Id == Guid.Parse("54ac7130-2d5e-4f45-aa4c-4faa1c552397"));

            result.ShouldBeNull();
        }
    }
}