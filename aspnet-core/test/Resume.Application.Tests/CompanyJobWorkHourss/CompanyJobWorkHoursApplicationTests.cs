using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHourssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobWorkHourssAppService _companyJobWorkHourssAppService;
        private readonly IRepository<CompanyJobWorkHours, Guid> _companyJobWorkHoursRepository;

        public CompanyJobWorkHourssAppServiceTests()
        {
            _companyJobWorkHourssAppService = GetRequiredService<ICompanyJobWorkHourssAppService>();
            _companyJobWorkHoursRepository = GetRequiredService<IRepository<CompanyJobWorkHours, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobWorkHourssAppService.GetListAsync(new GetCompanyJobWorkHourssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9037955e-0dc1-4cef-9ed4-10ac8e86ec50")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobWorkHourssAppService.GetAsync(Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkHoursCreateDto
            {
                CompanyMainId = Guid.Parse("515b1d02-5124-4777-9b38-f99861b7f031"),
                CompanyJobId = Guid.Parse("663834c6-19a9-4225-b33b-7189ab59cb58"),
                WorkHoursCode = "d80e0eac53ea4d0593b16b397c9b28a3b1fe3522d9c84992b1",
                ExtendedInformation = "7db623575e134b7282d7cd0375a474513fa1313a847a42cab2",
                DateA = new DateTime(2016, 10, 24),
                DateD = new DateTime(2008, 2, 14),
                Sort = 1462003331,
                Note = "282f8ae799f54dcba4966a836665485efabd50048bf7499cbabe005ef785eae566d0b2f0df5149c2ab6b7f8f802629174d48dc3832034066885408b8f79a35bf639a9fe54a814d9c9de753af9b9fa45da4b5f8273f71480cae232a296ce4607b260fd3e979844bbc8eb39c914429506fc99152f52a9848ca8d1cd526835d8a1b9520aeed1530452a9f12ebc8f26f5d062892a629179c43f49ec4fe78fc1e19cbf1611ee28bd1402d95dc57c69a2b90605f67da862d79422e9f3126ccb9fa02571e88a2ec800247b3a9af1e99016855956c6e239ca60f458ebe0a7e960293a6f74c480ec39ee044f6bbeb851ea16a0425f80d42a43066488bbcc9",
                Status = "3f6cbfec3f724bf0aa869a9980ccc2e863fbbfbd94f74de88a"
            };

            // Act
            var serviceResult = await _companyJobWorkHourssAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobWorkHoursRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("515b1d02-5124-4777-9b38-f99861b7f031"));
            result.CompanyJobId.ShouldBe(Guid.Parse("663834c6-19a9-4225-b33b-7189ab59cb58"));
            result.WorkHoursCode.ShouldBe("d80e0eac53ea4d0593b16b397c9b28a3b1fe3522d9c84992b1");
            result.ExtendedInformation.ShouldBe("7db623575e134b7282d7cd0375a474513fa1313a847a42cab2");
            result.DateA.ShouldBe(new DateTime(2016, 10, 24));
            result.DateD.ShouldBe(new DateTime(2008, 2, 14));
            result.Sort.ShouldBe(1462003331);
            result.Note.ShouldBe("282f8ae799f54dcba4966a836665485efabd50048bf7499cbabe005ef785eae566d0b2f0df5149c2ab6b7f8f802629174d48dc3832034066885408b8f79a35bf639a9fe54a814d9c9de753af9b9fa45da4b5f8273f71480cae232a296ce4607b260fd3e979844bbc8eb39c914429506fc99152f52a9848ca8d1cd526835d8a1b9520aeed1530452a9f12ebc8f26f5d062892a629179c43f49ec4fe78fc1e19cbf1611ee28bd1402d95dc57c69a2b90605f67da862d79422e9f3126ccb9fa02571e88a2ec800247b3a9af1e99016855956c6e239ca60f458ebe0a7e960293a6f74c480ec39ee044f6bbeb851ea16a0425f80d42a43066488bbcc9");
            result.Status.ShouldBe("3f6cbfec3f724bf0aa869a9980ccc2e863fbbfbd94f74de88a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobWorkHoursUpdateDto()
            {
                CompanyMainId = Guid.Parse("69fd6dcf-6528-4873-935c-198c6fbd45dc"),
                CompanyJobId = Guid.Parse("4a770a69-b659-41fe-b7a9-3fb684a00998"),
                WorkHoursCode = "5690381f1faa48bab9627ed6bb2f0c5ffb011e4df95d4ea0b1",
                ExtendedInformation = "3a80c21984ae4ceaa7ff122e108f0747d143ddafe40842c49bc86a06ebf89654c0bcf2a4a71b4983928585d4b7",
                DateA = new DateTime(2016, 11, 24),
                DateD = new DateTime(2007, 11, 24),
                Sort = 2075003064,
                Note = "8c07ef4b651144cd816bf33625cc1f6de5d43252964b41db8e1ebfe05f47b464483502ab8dc741f1bdb27e21d38fb4ac2880d838b5e54a628ee8d2846942d1c2017989e841b64b5484570e6003dd8a0105da7d1350b14344ba11e5ab25458faa64cc958683ed44769eeef8049e225ada62e7bde378414a9ab35565893c2ee407674813703001489a8f5af0b29b9f6f53db65792bde5444658fcadb5a2a0341afba3e78ec23d942de9d09f109c0dbdd465e867ba5f9584e79a7303adfb032356632f42250e6b2446ba81cbd17d5de9b318a54860d19534065933de4d2ae6393d2d09bf77e55964c47ba0fada1f04f4144a421ab07c8f045d2a402",
                Status = "95c04ceebf154626a45c6474e590bb770a92cd0a8aaa4ddf91"
            };

            // Act
            var serviceResult = await _companyJobWorkHourssAppService.UpdateAsync(Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"), input);

            // Assert
            var result = await _companyJobWorkHoursRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("69fd6dcf-6528-4873-935c-198c6fbd45dc"));
            result.CompanyJobId.ShouldBe(Guid.Parse("4a770a69-b659-41fe-b7a9-3fb684a00998"));
            result.WorkHoursCode.ShouldBe("5690381f1faa48bab9627ed6bb2f0c5ffb011e4df95d4ea0b1");
            result.ExtendedInformation.ShouldBe("3a80c21984ae4ceaa7ff122e108f0747d143ddafe40842c49bc86a06ebf89654c0bcf2a4a71b4983928585d4b7");
            result.DateA.ShouldBe(new DateTime(2016, 11, 24));
            result.DateD.ShouldBe(new DateTime(2007, 11, 24));
            result.Sort.ShouldBe(2075003064);
            result.Note.ShouldBe("8c07ef4b651144cd816bf33625cc1f6de5d43252964b41db8e1ebfe05f47b464483502ab8dc741f1bdb27e21d38fb4ac2880d838b5e54a628ee8d2846942d1c2017989e841b64b5484570e6003dd8a0105da7d1350b14344ba11e5ab25458faa64cc958683ed44769eeef8049e225ada62e7bde378414a9ab35565893c2ee407674813703001489a8f5af0b29b9f6f53db65792bde5444658fcadb5a2a0341afba3e78ec23d942de9d09f109c0dbdd465e867ba5f9584e79a7303adfb032356632f42250e6b2446ba81cbd17d5de9b318a54860d19534065933de4d2ae6393d2d09bf77e55964c47ba0fada1f04f4144a421ab07c8f045d2a402");
            result.Status.ShouldBe("95c04ceebf154626a45c6474e590bb770a92cd0a8aaa4ddf91");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobWorkHourssAppService.DeleteAsync(Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"));

            // Assert
            var result = await _companyJobWorkHoursRepository.FindAsync(c => c.Id == Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"));

            result.ShouldBeNull();
        }
    }
}