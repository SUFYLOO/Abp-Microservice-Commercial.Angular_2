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
                    companyMainId: Guid.Parse("c01a22df-21e7-4e1d-8f16-b1c38b2a3d7d"),
                    companyJobId: Guid.Parse("4c50e369-7e10-4fc8-82b0-c3a5183c6450"),
                    jobPayTypeCode: "5888987b386b43e1a40c47a246540e18ae11600719a64596a5",
                    isCancel: true,
                    extendedInformation: "060fc3990571452c883610e23c8b62d613fe8d26b069460b8b628091063c143f40c7a838212e43a7a899891a67fe19c78ff6cef2a15243979f2519c538ef136192196744c46544fa9d4e4c73a6b3c66f1e4fde3de3734e38afd795dd545e639293251565763247b9bb0263baa11f67cfc3e8a5731d324953850ac44bbaab5db2ecad0e0a12a1414b879a7de222072aba691ccb4282ca400cb9a984ce217a13a84689f5fb03e04caba2dff0323d3f9c6d7b86951c655f404d9d425354a81e66c56b4f4f6fdf8e41efa8511fb1fefa197352ce161d3fe44f3aa76c01b0527e00a9ce84aee14c54493ba38e5d55816fb6d112515acd165b4ce5a407",
                    note: "093b781c783e428786ef6cf0cbdfa838f66278348b654412b36790f25e391272cbd44cb5e769437391cfafb09dfce0003ce8e8171a8d443a9595caaf740fb6a973fc4a2f43a841ed9dacd5a1071766ece8efe66eb0214ce5baea609e967290a5aefb3288338141dcb5d2c9299099757dc7369c9860ed40fd9b48e17b92a07e18f2653a13560243e2bc6443fe5afcefe9a7bc3c2a38484ae28de49f5c596e91ddbf12b56d11b5448e99d42d6d4bc66dbb0fe0de2e329f4bab9629a0111e7383efb36b27f2e6064e23a64977b9a8c879c77982cb11f99941b5aea2cb8f178a0b7ae7397e9793d44c16b0ba314e567096ac50969dd1d527414eb328",
                    status: "fa229925905d4f5d84b6cdc6eea1cae524e2a01f864146ef87"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c3d4d298-9677-4a4b-81bb-9d52f1940af7"));
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
                    companyMainId: Guid.Parse("a9f13686-335e-4614-a54f-0b4967f63e42"),
                    companyJobId: Guid.Parse("f3598fe7-3d98-4261-83c4-3c6d93914613"),
                    jobPayTypeCode: "c09837600bfa4da99418a34a013275f7038aacf672af438ea6",
                    isCancel: true,
                    extendedInformation: "d71be051fb0e4e37893d384dd0d7fbf46a3f76e7c8b9414492319ae9a6688494b29a9d4138ae450eb1e2493667f927fec66f8d4ec0e54c9c8fda59c8ff65ecd71948bb6c926741f79eded029ef6eaa465169afd7d29c49109c4467d363b63dbd97fdd341f74a4bf18618b456ef82d493523c794085194224a8901f1b44af3ae02b3223d1bcf744c79453b83a7084d0f9a28e171e79a840bfb778c55fb00413ef1760625ef7354ca5b4b40d91c6a7f8ced1fe7981171c4bfd85bda077e9ba23c4d97939c689834181a1e073f1fc480609c2f3de6dcff3416eafcf449fd30fae1f64a52741d5c841c2a19265ab2ba32bce5540ed386a804456970a",
                    note: "b7f1ba6b1b8e45f4900e4a29527fcce222290a19faf9462a8988d7cb423e1a3f406065eee3cf4ec7982deb497916de9790d222f9338a431593bdf3b8b510cc82b0cdc4a7ae064c7488cc608dd33f7c1da8f369b75a394b4287327e08b5129d9e2260abd8ac0c4fb4ac7767e70692bb42708a71cbc74f49068f37633e25074c7f2c6325f3333e45d9a24fe224905497d68c62e669e9704abeb7516980b37e7a589df2d4420ec34d6187a2f731aec8d3b19954c399477d4ea2876381e6a038904d5d9c47a8d3f74209968b57acf32f8b01a9a199437a054a93b97eaca44802afd1b34e285120964c6eb9a1b8cd907b18d74201d71898204acfab29",
                    status: "dc03ad5cf15f4df0b515f6503916f2689e9e2964ffbc4c2bbf"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}