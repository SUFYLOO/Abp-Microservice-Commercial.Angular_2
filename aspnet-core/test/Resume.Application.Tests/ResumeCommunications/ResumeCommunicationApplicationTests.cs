using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeCommunications
{
    public class ResumeCommunicationsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeCommunicationsAppService _resumeCommunicationsAppService;
        private readonly IRepository<ResumeCommunication, Guid> _resumeCommunicationRepository;

        public ResumeCommunicationsAppServiceTests()
        {
            _resumeCommunicationsAppService = GetRequiredService<IResumeCommunicationsAppService>();
            _resumeCommunicationRepository = GetRequiredService<IRepository<ResumeCommunication, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeCommunicationsAppService.GetListAsync(new GetResumeCommunicationsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("0667892f-9b7f-4689-afcf-abbde4c8d044")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeCommunicationsAppService.GetAsync(Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeCommunicationCreateDto
            {
                ResumeMainId = Guid.Parse("c77caded-305c-42d2-8116-d70031fa897f"),
                CommunicationCategoryCode = "7fd67bc8474f403087da68a24b93b0fe7db048ee8ed442d6a6",
                CommunicationValue = "202a29052b23457f884bcbeb8086de541a2425b32a6c4badab8c2118b653f0419db1221f93fa4d598e21dcdba68deedb019452fb8908437fbd122db650e45dc3beb0ea8b59bb44d98ee07b977cb178059183aeb618ca4c90ae97aeba8b9c2ab57702bde3",
                Main = true,
                ExtendedInformation = "369ef6ec21794a9b974beb993119946239b9089de2d84d68b9b860b2382b1f2a9f35a12693cb4978a8954a6896a698c1ba1b7ecf33ac433f8d253a26987aac34d256cebf2fe54d9aa85b7cb96160577888d7277bac484a8f86e899f910b91c099816d45f78cf498cbbc735800c7eea1a538541a336404555bf74b38ef0eef64855105a5f9a304672acd08726c4c92d2b539d45d791a14f159f51d47815a085096b65b7eeac944902922ad57196b726f1e6c863465bfb4324b18d1c6d6e06cd522c757224b1e044e49d4a1b6a4c43ba4262bf34d9888d4db5b432e44838fc7191979b918a82704cdb870627d98956e2760deecb84acfe4926a8b3",
                DateA = new DateTime(2011, 4, 26),
                DateD = new DateTime(2011, 10, 7),
                Sort = 152788485,
                Note = "341729fed3b24f10b0c1d4c3a6d08121a9af807e95fd4a39a83012a43143b676b6680d3740fd43c49a1e941ca8b94e5f8804a9d4152247158d09c95a1528950bae2e1f3eec31440ba702867fb0cdfb67a112e0ee1cb64349b2d28b3dd63b2d0f0c16bf1b31fb4f82802ef0cd6c12fafdecdd57cf77274c409b22ed3029acd2acccfb94deea724219a089dfe3733f5147ee052ca7ea924537b08f9ec8b6271a1516132a4464094fcc9abb22f73146594934f9b705e22d416b857776b77650598ed2a74a7cd7064369852c0834731b9dd68b65a65a3c4f4a4c95e8198d1c328a260e7e1013e42e4f99b5bf7c3ca19506f27e95ed4e4c964864a91e",
                Status = "3729136970d74500984e9e9978eec5df256ad11190a24cf0ab"
            };

            // Act
            var serviceResult = await _resumeCommunicationsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("c77caded-305c-42d2-8116-d70031fa897f"));
            result.CommunicationCategoryCode.ShouldBe("7fd67bc8474f403087da68a24b93b0fe7db048ee8ed442d6a6");
            result.CommunicationValue.ShouldBe("202a29052b23457f884bcbeb8086de541a2425b32a6c4badab8c2118b653f0419db1221f93fa4d598e21dcdba68deedb019452fb8908437fbd122db650e45dc3beb0ea8b59bb44d98ee07b977cb178059183aeb618ca4c90ae97aeba8b9c2ab57702bde3");
            result.Main.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("369ef6ec21794a9b974beb993119946239b9089de2d84d68b9b860b2382b1f2a9f35a12693cb4978a8954a6896a698c1ba1b7ecf33ac433f8d253a26987aac34d256cebf2fe54d9aa85b7cb96160577888d7277bac484a8f86e899f910b91c099816d45f78cf498cbbc735800c7eea1a538541a336404555bf74b38ef0eef64855105a5f9a304672acd08726c4c92d2b539d45d791a14f159f51d47815a085096b65b7eeac944902922ad57196b726f1e6c863465bfb4324b18d1c6d6e06cd522c757224b1e044e49d4a1b6a4c43ba4262bf34d9888d4db5b432e44838fc7191979b918a82704cdb870627d98956e2760deecb84acfe4926a8b3");
            result.DateA.ShouldBe(new DateTime(2011, 4, 26));
            result.DateD.ShouldBe(new DateTime(2011, 10, 7));
            result.Sort.ShouldBe(152788485);
            result.Note.ShouldBe("341729fed3b24f10b0c1d4c3a6d08121a9af807e95fd4a39a83012a43143b676b6680d3740fd43c49a1e941ca8b94e5f8804a9d4152247158d09c95a1528950bae2e1f3eec31440ba702867fb0cdfb67a112e0ee1cb64349b2d28b3dd63b2d0f0c16bf1b31fb4f82802ef0cd6c12fafdecdd57cf77274c409b22ed3029acd2acccfb94deea724219a089dfe3733f5147ee052ca7ea924537b08f9ec8b6271a1516132a4464094fcc9abb22f73146594934f9b705e22d416b857776b77650598ed2a74a7cd7064369852c0834731b9dd68b65a65a3c4f4a4c95e8198d1c328a260e7e1013e42e4f99b5bf7c3ca19506f27e95ed4e4c964864a91e");
            result.Status.ShouldBe("3729136970d74500984e9e9978eec5df256ad11190a24cf0ab");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeCommunicationUpdateDto()
            {
                ResumeMainId = Guid.Parse("1082f729-4bfd-4a61-b4a2-047056818fa7"),
                CommunicationCategoryCode = "ff11fb982f6e419fa14882fae4555b826856e23ab666402abf",
                CommunicationValue = "c530cb7894a34082bc9fa9cf4d752dc9dcd66b0af1574e6ba68290ea838af51a872e8b80a913438685c650906b17e225c06f03432e804237b1c290a94e4f74f2c236656ece6f42118cbecc88746472cc1cf768174ac44a39a4f124d35cb1aa0d46e6cfe9",
                Main = true,
                ExtendedInformation = "d353e86ba09846e39ee2cd2caa032c5f19e797ee9f7745d989da0478a80577522e7e2b1f49ca41f8a17ca00c9e283905506fe5718a2f414db80e02f63daf0173f8adf5d64c494c89a92a225b489aa34c706dda1613d045528aa60284f2ea24def0695155c0e1411b8d72693b805a6a21c704b39e76544acabddc59b91006e05f5f27f29b907e4da7a662c21a7b7b57e66380a89c1cd64c87b83b1969f7f6ea6b324463cb8a2a43f3ba2bdfae853c66e288fc1479e9cf4e22bd2b39155a5a15b7f023a30559c84ed6acf0cca0290d6ce6ddb9f7fc153c446493fd5df46ef020dde1d63b4d4ae740a18cd586cd84329f9a17dd7df9845b4829aa00",
                DateA = new DateTime(2012, 7, 17),
                DateD = new DateTime(2013, 9, 15),
                Sort = 790811989,
                Note = "0a92f501667e4a0fb5efcc7d5c270b12ebe8a6915f264131b464469e747f8df715a2cfa523f94ee28f330261a3252accad3cc4901c45433887e16fb9f7827b42d4d4edccf5584d7484707a7483024345b2cfb0aace39448cbdc7079994c7dc6c162b316a0766406f9f10108cfdd17ce05cd163af8149497eb8f2af181d0008cca2316fe3d1e44c3ea75fbb26433459df0346385e56d842858b88a1e112c2eae7d05bcd16c3464c15ad5436fa062fad865233fbbb05204965be85b8d04abe9cdb7b52483abb2840ed9049363634527e780050f725778d48539c603a118c3ea803fdb6c05247854488b4f36d016d0c80360f760b6bf88a4599937f",
                Status = "1f9065d3bff441d582a7848c0024a9cd149f2c780dc44506b2"
            };

            // Act
            var serviceResult = await _resumeCommunicationsAppService.UpdateAsync(Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"), input);

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("1082f729-4bfd-4a61-b4a2-047056818fa7"));
            result.CommunicationCategoryCode.ShouldBe("ff11fb982f6e419fa14882fae4555b826856e23ab666402abf");
            result.CommunicationValue.ShouldBe("c530cb7894a34082bc9fa9cf4d752dc9dcd66b0af1574e6ba68290ea838af51a872e8b80a913438685c650906b17e225c06f03432e804237b1c290a94e4f74f2c236656ece6f42118cbecc88746472cc1cf768174ac44a39a4f124d35cb1aa0d46e6cfe9");
            result.Main.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("d353e86ba09846e39ee2cd2caa032c5f19e797ee9f7745d989da0478a80577522e7e2b1f49ca41f8a17ca00c9e283905506fe5718a2f414db80e02f63daf0173f8adf5d64c494c89a92a225b489aa34c706dda1613d045528aa60284f2ea24def0695155c0e1411b8d72693b805a6a21c704b39e76544acabddc59b91006e05f5f27f29b907e4da7a662c21a7b7b57e66380a89c1cd64c87b83b1969f7f6ea6b324463cb8a2a43f3ba2bdfae853c66e288fc1479e9cf4e22bd2b39155a5a15b7f023a30559c84ed6acf0cca0290d6ce6ddb9f7fc153c446493fd5df46ef020dde1d63b4d4ae740a18cd586cd84329f9a17dd7df9845b4829aa00");
            result.DateA.ShouldBe(new DateTime(2012, 7, 17));
            result.DateD.ShouldBe(new DateTime(2013, 9, 15));
            result.Sort.ShouldBe(790811989);
            result.Note.ShouldBe("0a92f501667e4a0fb5efcc7d5c270b12ebe8a6915f264131b464469e747f8df715a2cfa523f94ee28f330261a3252accad3cc4901c45433887e16fb9f7827b42d4d4edccf5584d7484707a7483024345b2cfb0aace39448cbdc7079994c7dc6c162b316a0766406f9f10108cfdd17ce05cd163af8149497eb8f2af181d0008cca2316fe3d1e44c3ea75fbb26433459df0346385e56d842858b88a1e112c2eae7d05bcd16c3464c15ad5436fa062fad865233fbbb05204965be85b8d04abe9cdb7b52483abb2840ed9049363634527e780050f725778d48539c603a118c3ea803fdb6c05247854488b4f36d016d0c80360f760b6bf88a4599937f");
            result.Status.ShouldBe("1f9065d3bff441d582a7848c0024a9cd149f2c780dc44506b2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeCommunicationsAppService.DeleteAsync(Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"));

            // Assert
            var result = await _resumeCommunicationRepository.FindAsync(c => c.Id == Guid.Parse("0ffb99ff-4942-4b72-9007-e1e200fdf9f6"));

            result.ShouldBeNull();
        }
    }
}