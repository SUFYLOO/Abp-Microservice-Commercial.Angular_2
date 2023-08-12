using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeRecommenders
{
    public class ResumeRecommendersAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeRecommendersAppService _resumeRecommendersAppService;
        private readonly IRepository<ResumeRecommender, Guid> _resumeRecommenderRepository;

        public ResumeRecommendersAppServiceTests()
        {
            _resumeRecommendersAppService = GetRequiredService<IResumeRecommendersAppService>();
            _resumeRecommenderRepository = GetRequiredService<IRepository<ResumeRecommender, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeRecommendersAppService.GetListAsync(new GetResumeRecommendersInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("d47dfa62-37c5-4ee0-8736-d17ec9511995")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeRecommendersAppService.GetAsync(Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeRecommenderCreateDto
            {
                ResumeMainId = Guid.Parse("6981e05d-ffb9-4258-9eb6-10b3d5e1d7d9"),
                Name = "5e5617db68964f479860f7fb16c707575e2d9623337742a1b9",
                CompanyName = "9cb33514c1f54614b8c643fc9622a102c1cfb11b4a2749fb8b",
                JobName = "ce1d30090e2148708f874f24c7fe00b4d7a999ecc48d4ed494",
                MobilePhone = "ed5db1552c1f45fe88c8b7ef17690120188457084b424b249d",
                OfficePhone = "32eb644d68de4db98650dba33266292a567fceddaa06401fb8",
                Email = "48347f0137f4492e852da8776e73a9aee35517680d0448eb9d72c852873483be0d1b472218e143b2b9159009e6508e39aafbcbfd7c044299b9060ebcf3bea1da2ccf55d90de64bc88858452a482ed75bda0a4502581f426a8be1a9284b0a5aedb364997f",
                ExtendedInformation = "900320cef68a466c82ec20afa7271dec7eb412fd9f0542b4a6f90c945609f94416e50669a6c146f6a44d8524245360a01675eae85b9f4746b7beeac7e65175842a1df2be97d14271a28c3cf483773736144f0232f9f94bfcac8cdd932600f8f9a714ea2407be4150a68dd54cbe43a6e72770d8ef83fc41febb8f88b89c8528720340dd0579184a63b5a3efea5fac7b3a0a25044492cc489ab10b24818444f6abae8e546546c24e8f8941b2acacc8816b31f8f499206b42b29c9ee1e35b3904c67aab94c23b054571ae3df8616a6b5851c0395506773148abb46a1935ec9b7b78d396d882c34b43088c904407532124451d5f85f2cb2a46528ec7",
                DateA = new DateTime(2000, 10, 13),
                DateD = new DateTime(2003, 7, 10),
                Sort = 1598869004,
                Note = "7889b2796c594358ae96ab96da8b25ee550036be0b0046879d122a89d60f6fbd9be88babde4f452a81f1e3aef348791bc8ec1906676447479dc5a7387d2b8264bce5692d45bb462db83ddd8999d687999194e103400742a396c90f9ca9c19bc2eb229d8444e4441eac4c08d9b73b45115976de35bf364fa4ab35338e59679b2cc9f34c2e89a34f8f96c2dafd7b4fdc006984ccc709f24ea0b731976dff5414ff1092d407b9a543379bbd0fe351da1ccf79ed0a48bcc14230b8ca8110e09e354b5b90f843888143129cb8b4dc72e4cded562a4808cb614df8bded94fca9b8b608c61bca6566674959971ab9f853af8add5237d7af8f2a4b19bf00",
                Status = "22f20548559a440a88bcf1454aa15e4b978e9d154c354757b7"
            };

            // Act
            var serviceResult = await _resumeRecommendersAppService.CreateAsync(input);

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("6981e05d-ffb9-4258-9eb6-10b3d5e1d7d9"));
            result.Name.ShouldBe("5e5617db68964f479860f7fb16c707575e2d9623337742a1b9");
            result.CompanyName.ShouldBe("9cb33514c1f54614b8c643fc9622a102c1cfb11b4a2749fb8b");
            result.JobName.ShouldBe("ce1d30090e2148708f874f24c7fe00b4d7a999ecc48d4ed494");
            result.MobilePhone.ShouldBe("ed5db1552c1f45fe88c8b7ef17690120188457084b424b249d");
            result.OfficePhone.ShouldBe("32eb644d68de4db98650dba33266292a567fceddaa06401fb8");
            result.Email.ShouldBe("48347f0137f4492e852da8776e73a9aee35517680d0448eb9d72c852873483be0d1b472218e143b2b9159009e6508e39aafbcbfd7c044299b9060ebcf3bea1da2ccf55d90de64bc88858452a482ed75bda0a4502581f426a8be1a9284b0a5aedb364997f");
            result.ExtendedInformation.ShouldBe("900320cef68a466c82ec20afa7271dec7eb412fd9f0542b4a6f90c945609f94416e50669a6c146f6a44d8524245360a01675eae85b9f4746b7beeac7e65175842a1df2be97d14271a28c3cf483773736144f0232f9f94bfcac8cdd932600f8f9a714ea2407be4150a68dd54cbe43a6e72770d8ef83fc41febb8f88b89c8528720340dd0579184a63b5a3efea5fac7b3a0a25044492cc489ab10b24818444f6abae8e546546c24e8f8941b2acacc8816b31f8f499206b42b29c9ee1e35b3904c67aab94c23b054571ae3df8616a6b5851c0395506773148abb46a1935ec9b7b78d396d882c34b43088c904407532124451d5f85f2cb2a46528ec7");
            result.DateA.ShouldBe(new DateTime(2000, 10, 13));
            result.DateD.ShouldBe(new DateTime(2003, 7, 10));
            result.Sort.ShouldBe(1598869004);
            result.Note.ShouldBe("7889b2796c594358ae96ab96da8b25ee550036be0b0046879d122a89d60f6fbd9be88babde4f452a81f1e3aef348791bc8ec1906676447479dc5a7387d2b8264bce5692d45bb462db83ddd8999d687999194e103400742a396c90f9ca9c19bc2eb229d8444e4441eac4c08d9b73b45115976de35bf364fa4ab35338e59679b2cc9f34c2e89a34f8f96c2dafd7b4fdc006984ccc709f24ea0b731976dff5414ff1092d407b9a543379bbd0fe351da1ccf79ed0a48bcc14230b8ca8110e09e354b5b90f843888143129cb8b4dc72e4cded562a4808cb614df8bded94fca9b8b608c61bca6566674959971ab9f853af8add5237d7af8f2a4b19bf00");
            result.Status.ShouldBe("22f20548559a440a88bcf1454aa15e4b978e9d154c354757b7");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeRecommenderUpdateDto()
            {
                ResumeMainId = Guid.Parse("10bee86c-34e4-4768-a436-4ec99c2036c8"),
                Name = "e12d4ff9e3ad4c9b9f1d69c2ef6e94a1ad41c8e48307492c84",
                CompanyName = "9f5fb2750b304b1eb46bd6e7fba0644858512c5fffe240c4bb",
                JobName = "27454920d3804d559da4c9b5eb059e647dcde472fc3948b286",
                MobilePhone = "a0f2366ce74542e0a1f4bf93086e9d518f84425f800944a294",
                OfficePhone = "f421645f7ea040b9ba04b36527bedc21b51559cad62b402baf",
                Email = "07446dbe81464b68a3b1bf16f336b349ace6d9b622e6497aac1af7f6c069714083eb600283414773aa9d686263e6cf3fc17bb7b8fda34b74b3a17a186628da24d98d46bfcc9745feb53e6f1150926c0c8e26f84a28354a88b5153f6a7a3f2f8f916f1473",
                ExtendedInformation = "a6949d7323d54ddcbfbe753431981bfd24d3f5ddbaee4c35a7d507a150caed936e164907f0014932b6d01e8ba293caa522d2c175766043498ac76be2a280dc1449905f0dee2049d78878a54e2257b321233bfba7685c46b9a0eaa9b78f29459256f38a886f49426988a34a15c73dd62997c51c98857f45d0a5da25efc8469418167d4b7474d6432f94ff29cdf66530c380ba90f03d9c43aaae7a31b23754c6735acb74d230d645deb77e72d7892d4ba4e35070075fac423085aae95eb51f537b8449c70a0abd46c3a7c11f282e169dcfb364d4cd9ddc45ec9c03425058ec5030da2132b413004a4f8470bfb2a5c68eb2b7f0243f3b2a4425b176",
                DateA = new DateTime(2018, 3, 27),
                DateD = new DateTime(2019, 9, 26),
                Sort = 73230522,
                Note = "4eeb6202ad5942428c8ef1b7a0249c057140233e445b4a8fa758eb95867ea448712b25c01a8e46d59aeeb22dc900702cc716eb9a9d6645e6b5cd54d3070aeee700230a63c06844cba160a86abfdb55153040f06f450d4dec9efe511096e877e446d98d36bf37445595f73f1ae65e520a26bf1a64a1914e2cbc95d00c969f9f6f7fb40a7545864cfcbf07b5b2a4907603e47a0000bfbb426895f2ad12e228939c1560b8244db1442383fed0df27e2d5d7a6d5f7e675ba49ad8b619fa4d4c8f91247d76ce2c73644598e7b878202c27b24146398c1bbd0437885924f989bf761a58f6dd55b0896414daa90314f82a32c8fcea8ea0cb2ca4f9cb854",
                Status = "4dd8f1efac4f4085ac2b3db4333ccc00341fa490a66244f6ab"
            };

            // Act
            var serviceResult = await _resumeRecommendersAppService.UpdateAsync(Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"), input);

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("10bee86c-34e4-4768-a436-4ec99c2036c8"));
            result.Name.ShouldBe("e12d4ff9e3ad4c9b9f1d69c2ef6e94a1ad41c8e48307492c84");
            result.CompanyName.ShouldBe("9f5fb2750b304b1eb46bd6e7fba0644858512c5fffe240c4bb");
            result.JobName.ShouldBe("27454920d3804d559da4c9b5eb059e647dcde472fc3948b286");
            result.MobilePhone.ShouldBe("a0f2366ce74542e0a1f4bf93086e9d518f84425f800944a294");
            result.OfficePhone.ShouldBe("f421645f7ea040b9ba04b36527bedc21b51559cad62b402baf");
            result.Email.ShouldBe("07446dbe81464b68a3b1bf16f336b349ace6d9b622e6497aac1af7f6c069714083eb600283414773aa9d686263e6cf3fc17bb7b8fda34b74b3a17a186628da24d98d46bfcc9745feb53e6f1150926c0c8e26f84a28354a88b5153f6a7a3f2f8f916f1473");
            result.ExtendedInformation.ShouldBe("a6949d7323d54ddcbfbe753431981bfd24d3f5ddbaee4c35a7d507a150caed936e164907f0014932b6d01e8ba293caa522d2c175766043498ac76be2a280dc1449905f0dee2049d78878a54e2257b321233bfba7685c46b9a0eaa9b78f29459256f38a886f49426988a34a15c73dd62997c51c98857f45d0a5da25efc8469418167d4b7474d6432f94ff29cdf66530c380ba90f03d9c43aaae7a31b23754c6735acb74d230d645deb77e72d7892d4ba4e35070075fac423085aae95eb51f537b8449c70a0abd46c3a7c11f282e169dcfb364d4cd9ddc45ec9c03425058ec5030da2132b413004a4f8470bfb2a5c68eb2b7f0243f3b2a4425b176");
            result.DateA.ShouldBe(new DateTime(2018, 3, 27));
            result.DateD.ShouldBe(new DateTime(2019, 9, 26));
            result.Sort.ShouldBe(73230522);
            result.Note.ShouldBe("4eeb6202ad5942428c8ef1b7a0249c057140233e445b4a8fa758eb95867ea448712b25c01a8e46d59aeeb22dc900702cc716eb9a9d6645e6b5cd54d3070aeee700230a63c06844cba160a86abfdb55153040f06f450d4dec9efe511096e877e446d98d36bf37445595f73f1ae65e520a26bf1a64a1914e2cbc95d00c969f9f6f7fb40a7545864cfcbf07b5b2a4907603e47a0000bfbb426895f2ad12e228939c1560b8244db1442383fed0df27e2d5d7a6d5f7e675ba49ad8b619fa4d4c8f91247d76ce2c73644598e7b878202c27b24146398c1bbd0437885924f989bf761a58f6dd55b0896414daa90314f82a32c8fcea8ea0cb2ca4f9cb854");
            result.Status.ShouldBe("4dd8f1efac4f4085ac2b3db4333ccc00341fa490a66244f6ab");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeRecommendersAppService.DeleteAsync(Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"));

            // Assert
            var result = await _resumeRecommenderRepository.FindAsync(c => c.Id == Guid.Parse("836e302d-01b0-4f94-8624-38c6d0f0aeff"));

            result.ShouldBeNull();
        }
    }
}