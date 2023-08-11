using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobPays;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPayRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobPayRepository _companyJobPayRepository;

        public CompanyJobPayRepositoryTests()
        {
            _companyJobPayRepository = GetRequiredService<ICompanyJobPayRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPayRepository.GetListAsync(
                    companyMainId: Guid.Parse("45ebb582-3377-4b96-a92e-144aa684341e"),
                    companyJobId: Guid.Parse("31a18006-68c8-48eb-93c8-b98046f1f8bd"),
                    jobPayTypeCode: "eddc1d6c13184f23bdba02296d1232071292f591996b49d28e",
                    isCancel: true,
                    extendedInformation: "96c3fcbba4bf42bfbb5e1e1c45f76efd2b8304a67db34c4585a58a3bbc9cdbeceaddf21703a64b4a940c7a146477e1b28e41e9be033e4bdab3c5e5032f0b279d58b0b18aa6584e8aa58176bd52772c404558178ea8cb4bd8be8c7a5232633840bb82bc303dcc4e9692d197c2d97f289959b6606be7d240c3b78167549247d67dfc045f5e991648239f597778e5de4726fcdc89cad0c043d4968a8fddf81f90d4445203aa3c934526bae3fa6b5399732d95d3f5c298fc47c5a4f7ccb0220e7fc97fa651c1f0fc475bbb70b8230c4c82b8c8b32dec99b846489b260ed9d09603d7142fb17d761d4bd1b4c224bd80b41b49b97626149a8b41c7afd6",
                    note: "470b966ed57a4e7f84419b89ec97edecaf104afd3bd540b4ae75ec7fb6b23cf638e730f7030e47dea47f8275aa2f086785a0377b33d74a09b19f671b15f76902954ffe72a6a943709a590b5b4bf35f0bb55611cdc01d4109aa3af71ba235db941750b11d92824ae499d775fdd8553baf3c7e88bf3bf24f5687c3587264a7085ef40d17e7b6d14245a23b4ddf76e5990fbe63ea02eb67449d99867ed3baccef0d41dcef73cf0c4a5b9b24ae5f92eb3ba20604e4a983194489855bd562068cd7d025109790318a4581b56bf467a9c172f220e53ec7740a48dd9c7ca4dbad3c9a2dbf60990d822a439db019f73fac45b65579568d8dd32748da9966",
                    status: "2cfb3d355e5d4e1d9cd43395d1157f1c6645ba2c4674429d93"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("962b796a-276a-4d08-8aff-6f8dfa637d07"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobPayRepository.GetCountAsync(
                    companyMainId: Guid.Parse("396d8d5e-1e0b-4efc-83e4-43b734ea66c7"),
                    companyJobId: Guid.Parse("dcad4b95-e122-4b19-8a58-912fc473d0e4"),
                    jobPayTypeCode: "f1034676c4d84986acd8a47b8ee9a7974cdbf4d92d434500a5",
                    isCancel: true,
                    extendedInformation: "cbf44d0e08fb4b879688ef57a07003c09444a6aff74941a2bb5973512af0f0765d518807959b43029543781a6205545f6a16d05a6b124ee08a9744eff94bae92553fc863f3ff4536b2ca2f096314fad3668b9785270947be91bbfd6adb5107d550e97aa03801454f95ab96780022031d7dbdcc9584ff40b09b79b4dffb03e8854bf486af346b407a913a27eb940b7a77b1f14129bdc54631b4d58034f81fef994c3fc2c982c44c71a8546f826aff4dd256b9bbc281554c8a9c39eb21af69423326d1eb93834d46cca755929e7c9ca2415bf22bae227f4dc38d5fbd00336f02de6ee6e21f6c3a4aca9d956a4597361d6c547f52771c5f42a5a5c2",
                    note: "df11f1091f7a45f5a1969ecaa68f084737ac820b15884325b771e35ae5e55d0bc41b41617104491e9d595e7070a412d1c65e10bf141a4154b12f18c47288fe574b6174b12ef44c48a1637b1e451a465c4436357e807d429da12e658edd721873d86b6a2a5d7e4ba3af6130950b2f1d2b81cecf4e9ef742baa180e5ff8854ef5a627875f997364128bdc304b558ddb4d099321201477145eebb909bbfe9c0caa0f847701823b24c11ae4b3ac75ba4d49783a608d36f0248e2ae2b95ed487df4be92ee21f84b3c4f818d72e014196b9a5372e84c0917f5421db327e7865801625b393c5b29d0db4c09bcb95486c5a6045a3b37cbda09964c8591a4",
                    status: "63685872c87a4fb0b09220926c55b6058a63295821e74da3ae"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}