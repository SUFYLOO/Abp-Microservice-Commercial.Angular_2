using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyJobApplies;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobApplyRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyJobApplyRepository _userCompanyJobApplyRepository;

        public UserCompanyJobApplyRepositoryTests()
        {
            _userCompanyJobApplyRepository = GetRequiredService<IUserCompanyJobApplyRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobApplyRepository.GetListAsync(
                    userMainId: Guid.Parse("541a6408-c5b6-4655-919b-b2e1ba0c037f"),
                    companyJobId: Guid.Parse("270b2d2f-98ee-4468-9fd2-8667ea752068"),
                    extendedInformation: "f80c586e5e584996abdd7bfdacfcfc4d63692f6658cd4b0da9df09568dc5442176113181f1e84bf49eef74375e4fabfb18245e16ad094ce1bcd527d4172eb172a855de0fced4435483ed9dc6e8536e143a22380cee4a4efc832ae829b16ae2d12a414cd6c1f94d14b0d226182891a35174a35e318bb14e59ac82c12ebcfa3f8e73ea4ef0cd2b40a0873536d4f8452e7dbcb0bfa5e8eb4970a500c360ace09ac134908d454c204a3fac69d0453e9205c620d3e1b5f8fb4f92b39b575ab5e0fe66ae88e98d8ecb495f90b177a82ff2c9e9d3142aa58e384ca6b961bcdc678bd3b19faa366f6360415cbf9ce4b2c043446ac386c210a21b43a9890e",
                    note: "c8350accad994cc4bff1188cefb72256a0bd5d285d3f467ab9e0d07c2a95b99cfc584f4d7ea64ab4beff3eb4cb12a52ce33b57b0796e45e4a31c190bbbe89b0611452360a6624ff98eda429489cb048d7fb4b2de86e647aeafa0c4b6c04a88b77ef7eb2b54a14b32929763c3a92fcb43ce7b24353bd541fe85c44205b014f79c9e138f52fff14c9e9c2b780baae10759a27c5cfc664c45708bf8963f18da6b4a4da88d00e856449c9133cefc2593b6372720389d12964a0eb7a3e3eee09ec7e642b26b09fc644b5183e4ec2285f1cf7612b02e30dd6440e791dde0521c01c96e58566b8732a34a33812d805f31c082197afa344ef7a841abb38b",
                    status: "56d89eab512f4926bb76b2c7339f549e2b5e4022a4684edbae"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("f6a1a0ed-6afd-4865-99d5-c4f429e82b32"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobApplyRepository.GetCountAsync(
                    userMainId: Guid.Parse("d62cd9d6-6448-4032-8e62-2544abc895d7"),
                    companyJobId: Guid.Parse("f7dc9950-741e-4e9e-a368-1fde356d9209"),
                    extendedInformation: "203a98eff97940309a95aa12580a6f095bcaa6bd58044deea21773ac5cbf5e54b100f8bc86c94ba182bdb9d793d39d170c29c0533e2848b492ec61db6de33a5525e7f2d3d29145538687d9eb483f01cf71ffb17754da488090dcead312f671d451db91fdd8c84cdb98f7fb0c7e31f33eeaf34406677d42d1a36189694fab79e7125b2c54e5024835bf3dd916082da35b775879d58fd046fdb9d07a0ce7a5a4e9341a74ca6a514c7e9011ecfa5c4609a66fbee2cb45c74358afe8e2ec55f8bbce33344caccb214659ba8cabbaf3205185fd16abc62cad4d5a9042862ede43d9edf7a10daee49e4b93ac9444e77cfbdfc9a7cc61e0486a48a798aa",
                    note: "7e1e04e092fe4597b290e1591471507ec4148a98e2b44a7895ed5129d5a05642912e9923f17749ffa6947035035d7a53bb9ba25598fc4e8f99201781b4a5774e28b1ffbe94af45a09677ed1d8a9adf0212835a3288c54ecdad1d76db5b5714a3473aa0ff71cb4de4b5e35f9084c30b922105f3f708544fbd9263678c60d82ff89e5316ed42744cc5a61a6f0acbf106a76fbc9c16e95b4d3f87ade9c6e7196cb192965d08ddf74f91bfec37a3965574c345d1deab7b7d41e6b2967b0ae1894bcb568224e832cb4fdf9905dd0561ff0a88df0365a402ba4b2c8cc9b06be1a0b9dd7cdaf096ab454c229f17f9ea8a66fd9d0df51a18aa0d4b7d984f",
                    status: "17c986fbb86547dda6554ebf8b46e31cad72afd925d44124a1"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}