using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeLanguagesAppService _resumeLanguagesAppService;
        private readonly IRepository<ResumeLanguage, Guid> _resumeLanguageRepository;

        public ResumeLanguagesAppServiceTests()
        {
            _resumeLanguagesAppService = GetRequiredService<IResumeLanguagesAppService>();
            _resumeLanguageRepository = GetRequiredService<IRepository<ResumeLanguage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeLanguagesAppService.GetListAsync(new GetResumeLanguagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("5ac5c550-8d36-4564-af97-419c0bcd3d90")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeLanguagesAppService.GetAsync(Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeLanguageCreateDto
            {
                ResumeMainId = Guid.Parse("f4ab60e6-8b36-432b-8a37-67558a293c32"),
                LanguageCategoryCode = "aa9a0ab8f87e4a148740ef10a3eeb178b5ebe67f185f452a96",
                LevelSayCode = "f652c2b9039949c5b0b6a43259eff17848dd165375cf46fdb9",
                LevelListenCode = "23d3105441f746a2999fdd9d207d769a36dccb1db442453fa9",
                LevelReadCode = "82688cff1c644d05ae96292b59c2ec1411873cc1f0064719a6",
                LevelWriteCode = "ab1b4887eb194d20a5ce49be68fe103d1fef96c01f274efca8",
                ExtendedInformation = "991289bc3e214bd5a5d3825a02929d46ce1f63a9368d4a12884abe903aafe01a7fd2124886434926b6dda14aef2913ca37d071c02c704e6b828feb9732226bd8e23bf6d3f3e34f15a95a59651ec7e3cf8fca33b9e0d049a988f219aaaef678c7b6b54b5a7c484038a8475056d991d5e63a9d5171c5c54e95bd3f7368e1464be9b73c3b4312a340429d46e2b6c4b1e6fe69380358991e451085429462f277ef7768e2522c777f48bf9e31a58cb0096ef5e50703a23d624a76acbdf4161eb32e5ddebe2b2d9a8a464abc7560455e6fd1699360d255ab214bf98aefbd1c5208fb7d74e86e27c3824a3eb1c4443450ce6b40a0ce6c2369f64bb4909e",
                DateA = new DateTime(2014, 6, 4),
                DateD = new DateTime(2018, 7, 25),
                Sort = 1033930296,
                Note = "5b97865b0c8b4a8798acb68e0ef8a75baf262e6b838947b1989bb9eaa191197b468b2eb714aa4f35b6fed758ac2f75cde87585503d4642de9d1d8f32be30f273d2ca2cece6fa412ca223f69ca6e3d5d0f9b3181cec8f4ba69a6cea77b22c1795b92442d96d7648699ecf45fb7585d369c6bbc6c0e9704aa197f28d2bccf59d15f51df78a367e4967b34321d86d8db172a0982c4e399e494a9e74d1f03044a25cbcdbe7ad76df44b690e99674eedc12de4b13b76c63ba40b9a1bd7334a604ac957059c5406b8b4f6eafd8ac13cad3d834ed5b9910166d4ef4bcca92a28d4e895f0f5956178fdf42dfabd795a71615e8db275c16e1b2124ffd804a",
                Status = "0239b3b35a1e40b594ee38f5853650e4877f1204bb3e472db4"
            };

            // Act
            var serviceResult = await _resumeLanguagesAppService.CreateAsync(input);

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("f4ab60e6-8b36-432b-8a37-67558a293c32"));
            result.LanguageCategoryCode.ShouldBe("aa9a0ab8f87e4a148740ef10a3eeb178b5ebe67f185f452a96");
            result.LevelSayCode.ShouldBe("f652c2b9039949c5b0b6a43259eff17848dd165375cf46fdb9");
            result.LevelListenCode.ShouldBe("23d3105441f746a2999fdd9d207d769a36dccb1db442453fa9");
            result.LevelReadCode.ShouldBe("82688cff1c644d05ae96292b59c2ec1411873cc1f0064719a6");
            result.LevelWriteCode.ShouldBe("ab1b4887eb194d20a5ce49be68fe103d1fef96c01f274efca8");
            result.ExtendedInformation.ShouldBe("991289bc3e214bd5a5d3825a02929d46ce1f63a9368d4a12884abe903aafe01a7fd2124886434926b6dda14aef2913ca37d071c02c704e6b828feb9732226bd8e23bf6d3f3e34f15a95a59651ec7e3cf8fca33b9e0d049a988f219aaaef678c7b6b54b5a7c484038a8475056d991d5e63a9d5171c5c54e95bd3f7368e1464be9b73c3b4312a340429d46e2b6c4b1e6fe69380358991e451085429462f277ef7768e2522c777f48bf9e31a58cb0096ef5e50703a23d624a76acbdf4161eb32e5ddebe2b2d9a8a464abc7560455e6fd1699360d255ab214bf98aefbd1c5208fb7d74e86e27c3824a3eb1c4443450ce6b40a0ce6c2369f64bb4909e");
            result.DateA.ShouldBe(new DateTime(2014, 6, 4));
            result.DateD.ShouldBe(new DateTime(2018, 7, 25));
            result.Sort.ShouldBe(1033930296);
            result.Note.ShouldBe("5b97865b0c8b4a8798acb68e0ef8a75baf262e6b838947b1989bb9eaa191197b468b2eb714aa4f35b6fed758ac2f75cde87585503d4642de9d1d8f32be30f273d2ca2cece6fa412ca223f69ca6e3d5d0f9b3181cec8f4ba69a6cea77b22c1795b92442d96d7648699ecf45fb7585d369c6bbc6c0e9704aa197f28d2bccf59d15f51df78a367e4967b34321d86d8db172a0982c4e399e494a9e74d1f03044a25cbcdbe7ad76df44b690e99674eedc12de4b13b76c63ba40b9a1bd7334a604ac957059c5406b8b4f6eafd8ac13cad3d834ed5b9910166d4ef4bcca92a28d4e895f0f5956178fdf42dfabd795a71615e8db275c16e1b2124ffd804a");
            result.Status.ShouldBe("0239b3b35a1e40b594ee38f5853650e4877f1204bb3e472db4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeLanguageUpdateDto()
            {
                ResumeMainId = Guid.Parse("c7fcb62f-ab9e-4792-b1a2-d0daedd57070"),
                LanguageCategoryCode = "d72651a411544197a33a1948b003ad195573236fc7ea4081b6",
                LevelSayCode = "334478145f204d468874c63fde7e8eaee7e08acc7b2c4d7f9b",
                LevelListenCode = "378ef9a4fded4081bc48783351140930d31b016950b44abaaf",
                LevelReadCode = "9a3701a813724558bb0be300462ea02fc2310b5cfa0444069b",
                LevelWriteCode = "200101bf3e494465bbeae3fbe945c1c49417c57918554967a9",
                ExtendedInformation = "53fefe6986734f8eb115f1999c3766dcb985b769e0db4703848d2745f44d7c7dbe7ae1c1ad104efe8fda76423e6faa300d0672ce59794174aec78ed6a9806e10af1b9933c2544ad0a6a0ca575f407b9211205fe0684d41c8a8641380e495be2174245d7643ae48f1887e18b173f1f11d02d05f8960f14312a49fba81d9e514ae6f39e0b9a8994c21a2fadab1eca276aca44adaf29acb48a19e54771531344edb94b990bbaca4459284ab2568afc6bf75cdd220a858dd4a27b7bf747e7abb86ce90022536e3164d82bdd7cf062a361e378df04c4131b949d3bec9173edd3be6a8973ac1781f8a474e8b1dcebb7851fda155cd59bb53c44a4da032",
                DateA = new DateTime(2020, 4, 4),
                DateD = new DateTime(2002, 1, 19),
                Sort = 91699630,
                Note = "7b875ebffa55412d8f67551757dfc5d1acbcff5f868c48c3b3f820a3d30447f8ed9aa360c8c146c399731b44c374abba8fa35b42d830468195784f603bcf27ba5c4bcc666cd54572aa1dcd1fcfda7083414e2948c7864fceb4d72b9cac2e22d6aff32644430f49cbbe2a9464cff9134d4cf83a88d6024791bc55062b956d8989c3563fcdcf60440fb36710b955cc366392bccd6a9dd741798baa33e6592f944cae8c922b87df47a89be8bb6ee938852f673b53b8de1a4888af1891506f00be5284da2e2a2ec34789a6874e4c6c2eb7a45cd282a1ad4c4f9f887e93eb195b39d9d729d075b464436f9596bf8bed00dbef611d4dc1b8bf40ea89a9",
                Status = "f6baacd54cea4640a529007b8a0453e6984a8a3f0206412186"
            };

            // Act
            var serviceResult = await _resumeLanguagesAppService.UpdateAsync(Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"), input);

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("c7fcb62f-ab9e-4792-b1a2-d0daedd57070"));
            result.LanguageCategoryCode.ShouldBe("d72651a411544197a33a1948b003ad195573236fc7ea4081b6");
            result.LevelSayCode.ShouldBe("334478145f204d468874c63fde7e8eaee7e08acc7b2c4d7f9b");
            result.LevelListenCode.ShouldBe("378ef9a4fded4081bc48783351140930d31b016950b44abaaf");
            result.LevelReadCode.ShouldBe("9a3701a813724558bb0be300462ea02fc2310b5cfa0444069b");
            result.LevelWriteCode.ShouldBe("200101bf3e494465bbeae3fbe945c1c49417c57918554967a9");
            result.ExtendedInformation.ShouldBe("53fefe6986734f8eb115f1999c3766dcb985b769e0db4703848d2745f44d7c7dbe7ae1c1ad104efe8fda76423e6faa300d0672ce59794174aec78ed6a9806e10af1b9933c2544ad0a6a0ca575f407b9211205fe0684d41c8a8641380e495be2174245d7643ae48f1887e18b173f1f11d02d05f8960f14312a49fba81d9e514ae6f39e0b9a8994c21a2fadab1eca276aca44adaf29acb48a19e54771531344edb94b990bbaca4459284ab2568afc6bf75cdd220a858dd4a27b7bf747e7abb86ce90022536e3164d82bdd7cf062a361e378df04c4131b949d3bec9173edd3be6a8973ac1781f8a474e8b1dcebb7851fda155cd59bb53c44a4da032");
            result.DateA.ShouldBe(new DateTime(2020, 4, 4));
            result.DateD.ShouldBe(new DateTime(2002, 1, 19));
            result.Sort.ShouldBe(91699630);
            result.Note.ShouldBe("7b875ebffa55412d8f67551757dfc5d1acbcff5f868c48c3b3f820a3d30447f8ed9aa360c8c146c399731b44c374abba8fa35b42d830468195784f603bcf27ba5c4bcc666cd54572aa1dcd1fcfda7083414e2948c7864fceb4d72b9cac2e22d6aff32644430f49cbbe2a9464cff9134d4cf83a88d6024791bc55062b956d8989c3563fcdcf60440fb36710b955cc366392bccd6a9dd741798baa33e6592f944cae8c922b87df47a89be8bb6ee938852f673b53b8de1a4888af1891506f00be5284da2e2a2ec34789a6874e4c6c2eb7a45cd282a1ad4c4f9f887e93eb195b39d9d729d075b464436f9596bf8bed00dbef611d4dc1b8bf40ea89a9");
            result.Status.ShouldBe("f6baacd54cea4640a529007b8a0453e6984a8a3f0206412186");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeLanguagesAppService.DeleteAsync(Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"));

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"));

            result.ShouldBeNull();
        }
    }
}