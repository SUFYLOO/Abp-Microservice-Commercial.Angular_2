using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyPointss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyPointss
{
    public class CompanyPointsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyPointsRepository _companyPointsRepository;

        public CompanyPointsRepositoryTests()
        {
            _companyPointsRepository = GetRequiredService<ICompanyPointsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyPointsRepository.GetListAsync(
                    companyMainId: Guid.Parse("0b04b41b-021c-4f1c-abb1-57514c79494f"),
                    companyPointsTypeCode: "51ca1be2c8e34795af1089ba4c69ac69da928e3812ad4c0e95",
                    extendedInformation: "43c861558c144cea8d03f1a6d1a03f7b8f17f144070e49b2b039df68d50596dda4e1a68eb33a4a708e047bd6fd171c38ae6d2494aaf74f4283ca08b8258a2347cd62d60a47064d0a93a8ea388a27556b0d031e535413408aa1ce3bd7b3fad31059bcd2827b2b4da9b2e285d1ec204a44e01ed9a3c0d44634abfe11c457f346234f175cafbf384b3c90822eb1ce5c0e0a4d2b3c1cb6244d2892c0069eec4ba3512b1cde2bec2a4740a3fc226bee817cab68a3a84670304d739da48ea3b5f0dcfb35ddeb68de9c4d8c9fa201068680ddc996ea7a87d12e4f9bb56958484944991a8057adac8b134282a4645b25bb0738be86dacfdc12874160b569",
                    note: "6ed6f6effc6f4b5c939383c285e0840d856990d1e2d5478da14c21b627eae0a8d7f71a362a7b4163bb0308c21c66cf8c5343ccdd61d4467a8b2f0839fc8958ed3157f05f9519429fa690f9a5663ea4a918ff4eff98d44caf9ff9b3ee92f0364f98460a4e49254ba08e3cd022ba3d833c85e4480149fb49ef98d7c036db3d0a573b68466c933f4fe28cde8de4d9256d27c0fcb61a25aa4794bebc72a87cd1d90deea95690bce7414db253ccc26d1bfa96b77ceef5c46c469da64b023c23b49456e76f8f56dd964cd29348c56b49267e65c8166354ca784cb8b20cf21028294fc7a85729648aef48efaf04e5d1e005fc979a8c03e92ccc47a381cc",
                    status: "442aed696c5d46e58f3b2e727a2c90e9e7db4ac375124b08a7"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyPointsRepository.GetCountAsync(
                    companyMainId: Guid.Parse("5ae0e68c-eed9-40f2-abd4-d3cf3f54979d"),
                    companyPointsTypeCode: "e72715200b794c14a0d0bf76031c7df90efbe4ce1ab44b5b83",
                    extendedInformation: "87855ecb7cf8442bb60e045e7d8ebfbef361ea7dc1544df4a88d28ab91cb9d6e218ba5e5f2da4891b5862f5acc73717b3ffe37244b4845909974663179c6e45262cf167b933745f5a2927cc9d0bda51c68be091970ec42f3bce2cd5361793aac97fd6fb2d0344a84b493ab68c6c506f9615137cded154bbc93e54b6e71edbf503f8f3a4d08de4c169bbe20368859e046dfb54907afa94cea9c52132dbf7b5745cac5817cd59542988ed38ade516f01e42451362ea44945448a24c478421164a1e1c63b5a08484baea3641ae3e3479ad933b8f54e137a410b80b255c5a66cbbf19ff0bdfabdc44305a151bc1b8d9bdab4032b73068dc64560a70a",
                    note: "14d037dffaa4401dabcb730c720a28605c4ebc9d02624129bb87bddaf27a6890d412e3ce0ea443a295af8c594857c3959774a68463cc49588bbe19a7de6f657bd50158df9c1145e3bfb39fdabffe88c0fcda405cc13645c39d168dcb82c52ed3e2095fde4b81497c928d701d77d3c3de077026eebb454feea027d5be022959b9a2d23a29a5fa474c8221dcc4ef0b10dfa849748445834627911460c4276b90fffb2aff7da5a84f1193d13705f671f24741fb8ecdad014cde812895998ae93a52ccdf19ea968d458f8e60346fed6f6ff5d6d00df530b346ff8c9ba689d36e4c53d13fb9183e4c4a73a2f84e00b0ec29e5b50de9798c304cc0ab71",
                    status: "ce24a02ed05744ef90cba309cc3aa016e28ded6d8e4545ab96"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}