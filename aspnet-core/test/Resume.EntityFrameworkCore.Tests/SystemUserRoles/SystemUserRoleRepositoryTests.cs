using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.SystemUserRoles;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.SystemUserRoles
{
    public class SystemUserRoleRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ISystemUserRoleRepository _systemUserRoleRepository;

        public SystemUserRoleRepositoryTests()
        {
            _systemUserRoleRepository = GetRequiredService<ISystemUserRoleRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemUserRoleRepository.GetListAsync(
                    name: "284aed0e24d34af584077d1a83bca61b5bb40ffa079842ea9a",
                    extendedInformation: "256b73af13cb4479b0838552084041a6d073e889e1f94685b3a436941b1627c8141876536b8e44639673fc8b61514171a0bc20f41d3d41c1bcfb2f4a1fc85ab1aed9992bcfdd4f06a25dcded019259133aad90a3628a479c85fa5c5e7ad97acead9ccdd2ec884c0aa1ea4826951268c215709fc6f8004ebaab09890096810a70f8c29d13cc2541a0b1a140439d1ea77816e7073687754aa3a7367a9087abfd8865f74a776ae24815b22d1ec72475f4bf106093a7c076488bab9e924def58bf21063d55675c0f43699db94b5031f264f3cde4731a53ac4bd99559ffa9f13b6986c171f24daa044a8ab0e605d6f5b84203519898a633cd48c9b91b",
                    note: "84d2b8ce3b5c4b3bb186d55a0d2963dc4e04c34ade4e43aa88b7bccef47bc98cd552e31a2fdc49b39627c9982dc95e74e6377ed8463a4301918688640b542ad93f3c4d385ff44bf286c5f3a395360d78f8c5d9d5d85346a49e7db905c07a7bc5e74884455c36461b8214cbd3eed4da557e079bd8dd11453c926f8ebf9be8285849eb0bc8849646e78c606eed2a3f879ff08e31a4082f444caf946f4b0ca4ec5bb0c6a102ad3743eeb79c321c0f2d5c1c45e763a26750485497b83aa153774231457aee41370a49f89b671407038f08d082be1d67657c4cbf8191c7b2abe43ee1f15cb47d393b4e849f4a2c13cd75df301212a42048d14024ad5f",
                    status: "0e62d48492b8495984eafe1bb4de8a5d9e15e2c7d67743b297"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c537b127-dce4-451c-aaa7-4af998dee557"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemUserRoleRepository.GetCountAsync(
                    name: "db13cdb843a9431393604a35625ab9660f6d3d3cc59c428e95",
                    extendedInformation: "bb28617351de464cadcfc403244b7e208dae373690dc451cb58b2bf066c63623b27ab39913c041d09e0bf7082b1b12d183800f868f4c4395a539f7abbb743ad25b110a7920944329bf0f16bbf77dad3f60105679116247caa477b658254e05e9ac95e7c7faef46a09871c89db076e6cf3722ca8f8297417e870f1ff01b58be5e27e42d6277164fb1bf5deca098e11ca23528b4897e3546d8a9f36f5c38cf68ea5040d5c1155c485094f638e855cb01b020519d6b74a140b3bed4ae8c30df808c6942cf06e7d34bf1a0d7d25be992857bc3eb7ed12d2747438deadb80e2e568b83ef62a19410f477e95291d70346b5d0e6b3ac88473274f319dfb",
                    note: "2f2ecc5ade5640529727aa5c42cdf4d658aa432b45c8489fb93f18644f3ce99d0d45a6c127174d32b7058cf28fbf5e273c3a7cbf25c443a48b8e336d2cb62251d400a0112f32478ab6bdce8c0a7ffaf525137331475d4c74aad4442db322fc38b733a5d3066d4980a035d0e74f9ecbae612c8a9c34b24168a0b43432587ad5d2abf4cc062fb24bf7825ab654884702cc397ccf275d29463499a359d2ef1e60392df86fea9f304f929ee647e822f4cf4573382f076d154ecfae1c3f2c15b59251d368517e64ee4bd3a6bbbd58b33c8fae78fce878312f4757b7a11dd53f20e52b14b9c7ce70ab4239a5d01456be5b4afb7b6043fd32d040a4895c",
                    status: "c4ba223ebed249208d83157d187f48f166ebb760cb4e4ea6a6"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}