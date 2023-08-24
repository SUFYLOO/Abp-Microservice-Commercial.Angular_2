using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobEducationLevelsAppService _companyJobEducationLevelsAppService;
        private readonly IRepository<CompanyJobEducationLevel, Guid> _companyJobEducationLevelRepository;

        public CompanyJobEducationLevelsAppServiceTests()
        {
            _companyJobEducationLevelsAppService = GetRequiredService<ICompanyJobEducationLevelsAppService>();
            _companyJobEducationLevelRepository = GetRequiredService<IRepository<CompanyJobEducationLevel, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobEducationLevelsAppService.GetListAsync(new GetCompanyJobEducationLevelsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9c3c1687-b8e1-4b0b-b199-a762a631d291")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobEducationLevelsAppService.GetAsync(Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobEducationLevelCreateDto
            {
                CompanyMainId = Guid.Parse("4a1b7d46-9925-4e83-b99d-30ad4dba58d1"),
                CompanyJobId = Guid.Parse("f03db927-ec4d-47d6-9f8d-10651a0439d3"),
                EducationLevelCode = "2149e179ca5646cd89b515f9de87cd43978435f0164e4fb4a7",
                ExtendedInformation = "9c0ebbe1c13f44fa9d93d08f4639d37893257bb962d34b7a9eef75ac474259f8162ff3e2774a450290e3901f61493e4f2cb503348bfc44db9f735451ff2314c55f031fd327d34e7f964e7ae6f8f292dab78d72a5ad2a4ed496de58092d3f2a94d61222b0d5574d26b6ddeb66477f185ac999340d9e16444ea7be40a106a11d2300d6abb1b6c54a7eba891387e02f1a536c0770014a7f4a028b4c2776a55305bbaa8cb7d9406d4388b29db7d58a6daa711c0621bb249d408b92ac56228d2dafae3518c39535f64f23ba3963bf13ef7056ee18a5333b5f4614863d6a0fffd3d669783ae355b6ce408897687cd95b69aad9d904e44125a34e92ab08",
                DateA = new DateTime(2005, 7, 22),
                DateD = new DateTime(2009, 7, 3),
                Sort = 778932360,
                Note = "2ef118d582384a4bac7d02fafce7950318bb50cec6e146629a76c73103188f50b47551436a8e4162b9283ca8d35ac1cfeb7e7e8dc7da4270bce0e6cf88811897bf526ca4a06a4a4897e1392d97c2d2d5222295d1d163413c966405918097e5b83c98398c0a3841678f6b15ae59bce24349039b25ef3347a28e791ce78b4db184cb01ed5c69c1499bbe69765eda0d5322cb71b8dcbd0345918596b7a28e0db96f856160e054cf4924af048d87786a6c8e69e4983aa54b4529acf47b21f451dab04845054b60db493a9fb366ef96260cd99e91aa1223e840ccaaf7364d5dd3858092f0ffb08aa742f3b12c1368849ed8384c71ff06ae7c4d22ac80",
                Status = "59bad029eedd4409bc9e0fc4f81b8424f74b728110f54639a2"
            };

            // Act
            var serviceResult = await _companyJobEducationLevelsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("4a1b7d46-9925-4e83-b99d-30ad4dba58d1"));
            result.CompanyJobId.ShouldBe(Guid.Parse("f03db927-ec4d-47d6-9f8d-10651a0439d3"));
            result.EducationLevelCode.ShouldBe("2149e179ca5646cd89b515f9de87cd43978435f0164e4fb4a7");
            result.ExtendedInformation.ShouldBe("9c0ebbe1c13f44fa9d93d08f4639d37893257bb962d34b7a9eef75ac474259f8162ff3e2774a450290e3901f61493e4f2cb503348bfc44db9f735451ff2314c55f031fd327d34e7f964e7ae6f8f292dab78d72a5ad2a4ed496de58092d3f2a94d61222b0d5574d26b6ddeb66477f185ac999340d9e16444ea7be40a106a11d2300d6abb1b6c54a7eba891387e02f1a536c0770014a7f4a028b4c2776a55305bbaa8cb7d9406d4388b29db7d58a6daa711c0621bb249d408b92ac56228d2dafae3518c39535f64f23ba3963bf13ef7056ee18a5333b5f4614863d6a0fffd3d669783ae355b6ce408897687cd95b69aad9d904e44125a34e92ab08");
            result.DateA.ShouldBe(new DateTime(2005, 7, 22));
            result.DateD.ShouldBe(new DateTime(2009, 7, 3));
            result.Sort.ShouldBe(778932360);
            result.Note.ShouldBe("2ef118d582384a4bac7d02fafce7950318bb50cec6e146629a76c73103188f50b47551436a8e4162b9283ca8d35ac1cfeb7e7e8dc7da4270bce0e6cf88811897bf526ca4a06a4a4897e1392d97c2d2d5222295d1d163413c966405918097e5b83c98398c0a3841678f6b15ae59bce24349039b25ef3347a28e791ce78b4db184cb01ed5c69c1499bbe69765eda0d5322cb71b8dcbd0345918596b7a28e0db96f856160e054cf4924af048d87786a6c8e69e4983aa54b4529acf47b21f451dab04845054b60db493a9fb366ef96260cd99e91aa1223e840ccaaf7364d5dd3858092f0ffb08aa742f3b12c1368849ed8384c71ff06ae7c4d22ac80");
            result.Status.ShouldBe("59bad029eedd4409bc9e0fc4f81b8424f74b728110f54639a2");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobEducationLevelUpdateDto()
            {
                CompanyMainId = Guid.Parse("132cb30b-4481-4bd3-9466-eddc4ea47d2a"),
                CompanyJobId = Guid.Parse("4223fca1-bcfc-4f9c-9998-dc1e766fd611"),
                EducationLevelCode = "cea106918dfb4aac9a87864b7d6fe0b8197cff5086bf485995",
                ExtendedInformation = "c4851e801d7949c5becdbc8bcc12b2511dbdfb80a58a4cb18bf07c21354b8e4d20907d6ff8fe46119063f1203db61d902516097b7bb645c09f8ca9b67a9a9685c46eda34de9b4c7a8c2bd4a96d0757967b7aa59663d242e7bc77212e48c900a5b508bb79bb454c30b9123de0c3922ce5c043c5d0f74643bba5f6d945c6dbbb0be5ff8813891f40b8b8dc498775381fcc4c3335aa2a6144bca69706c0f19f7ac9c4bb249d3a224bc28dd1d8c35b4aa4b96b75e372af2943a79cc39fbfa40f03c199c2225c01d944839e89280e9be14ec592f0d6805a2d478bbbb12e32caf2ef7cf60dc90c6b96412f89cfb6d72b00ed830c05589377074d04ab23",
                DateA = new DateTime(2015, 4, 5),
                DateD = new DateTime(2006, 8, 12),
                Sort = 2093449011,
                Note = "01560bd15a954c16b65650b527d74fd10dad25c8240a493c893e02c071f82e6073e86fc8717b49e19b34af21f539fe5d7965fe2aafc1499aadd31e8f8fc056315b374a623e954cd0ab5deb9e914256f1d96aad6d87a7408ab8579b111cb6da743c15f6c2ad0e4649b18e70157d0cf0e97e067e3b910348c38a0db3a0e371f5246d6b209322a149e2a385811c974781df81b5babdcefc4f0d8b3a0275b8f2a86388ed0fbb97c84ffc8395c9caaa0ea21316aba0c192c54042829bc92187eb49bcc544771b85dc43b6949bc5de0691eb91398340ac920e49e78b7ba8ec44df1797f19d4172d8e24c57b8ca6a292bb9af15a1942fb758704c00b9ad",
                Status = "23c7f11fbe734614a9a6d7d1a9ff6bf133558ce7e5534dfe8d"
            };

            // Act
            var serviceResult = await _companyJobEducationLevelsAppService.UpdateAsync(Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"), input);

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("132cb30b-4481-4bd3-9466-eddc4ea47d2a"));
            result.CompanyJobId.ShouldBe(Guid.Parse("4223fca1-bcfc-4f9c-9998-dc1e766fd611"));
            result.EducationLevelCode.ShouldBe("cea106918dfb4aac9a87864b7d6fe0b8197cff5086bf485995");
            result.ExtendedInformation.ShouldBe("c4851e801d7949c5becdbc8bcc12b2511dbdfb80a58a4cb18bf07c21354b8e4d20907d6ff8fe46119063f1203db61d902516097b7bb645c09f8ca9b67a9a9685c46eda34de9b4c7a8c2bd4a96d0757967b7aa59663d242e7bc77212e48c900a5b508bb79bb454c30b9123de0c3922ce5c043c5d0f74643bba5f6d945c6dbbb0be5ff8813891f40b8b8dc498775381fcc4c3335aa2a6144bca69706c0f19f7ac9c4bb249d3a224bc28dd1d8c35b4aa4b96b75e372af2943a79cc39fbfa40f03c199c2225c01d944839e89280e9be14ec592f0d6805a2d478bbbb12e32caf2ef7cf60dc90c6b96412f89cfb6d72b00ed830c05589377074d04ab23");
            result.DateA.ShouldBe(new DateTime(2015, 4, 5));
            result.DateD.ShouldBe(new DateTime(2006, 8, 12));
            result.Sort.ShouldBe(2093449011);
            result.Note.ShouldBe("01560bd15a954c16b65650b527d74fd10dad25c8240a493c893e02c071f82e6073e86fc8717b49e19b34af21f539fe5d7965fe2aafc1499aadd31e8f8fc056315b374a623e954cd0ab5deb9e914256f1d96aad6d87a7408ab8579b111cb6da743c15f6c2ad0e4649b18e70157d0cf0e97e067e3b910348c38a0db3a0e371f5246d6b209322a149e2a385811c974781df81b5babdcefc4f0d8b3a0275b8f2a86388ed0fbb97c84ffc8395c9caaa0ea21316aba0c192c54042829bc92187eb49bcc544771b85dc43b6949bc5de0691eb91398340ac920e49e78b7ba8ec44df1797f19d4172d8e24c57b8ca6a292bb9af15a1942fb758704c00b9ad");
            result.Status.ShouldBe("23c7f11fbe734614a9a6d7d1a9ff6bf133558ce7e5534dfe8d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobEducationLevelsAppService.DeleteAsync(Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"));

            // Assert
            var result = await _companyJobEducationLevelRepository.FindAsync(c => c.Id == Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"));

            result.ShouldBeNull();
        }
    }
}