using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserVerifys
{
    public class UserVerifysAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserVerifysAppService _userVerifysAppService;
        private readonly IRepository<UserVerify, long> _userVerifyRepository;

        public UserVerifysAppServiceTests()
        {
            _userVerifysAppService = GetRequiredService<IUserVerifysAppService>();
            _userVerifyRepository = GetRequiredService<IRepository<UserVerify, long>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userVerifysAppService.GetListAsync(new GetUserVerifysInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == 1).ShouldBe(true);
            result.Items.Any(x => x.Id == 2).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userVerifysAppService.GetAsync(1);

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(1);
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserVerifyCreateDto
            {
                VerifyId = "3134fcd22a074c85b4d3a6bf1fdd5bedc077fba1340f4574a87d00f1cb4d398d4356a7b099344f67975935f0f048b656b904aaea4ecf4741855c125bda7d2ace50f7436149c34e50bae5a96223769d824dc9eda840884b899b0023f78a485d70e62cb92bdbb744ffa2cb4fca9caf8bbb79c439686c38439ca781b327d8b37db82a39ce328d5e461a96ca4dc3617bbcd1f84d7e5db57b4b8d8fac848066a399f325b40730ccca478caec527e9f08dd0722a72921ce8f74b2ebc37df44b9f61431a59ccc8cba274cbc80d0c16caefff1827ceede38fdd64b16a2cfd4912b5b07c9d478bb47ae5c407eaa5d53c05b7038b924b38525369e42ac89f5",
                VerifyCode = "ceab7fc312a94e73a6c0417a4a7a352d6cfb418457e049fa9c",
                ExtendedInformation = "522c2ddd8cea495890eed31e3cd3acc09d80cd6f270241cd97d4e7c0067377f9c3f1c443841f43b280efcd51072f248324d8b0798401476fba910924342d80d79bb6e08836d14cee990526d803a99796e89e17e95a22431e85d333b9801c503416d8a46a56a540299988d7cac45d5e164266d266c9f94d839f71b8f6f9e40fda3257fcbc561a43688921857565d67b77953c726275094a60acdc473970841e6f791efbb5b7734e568b78ac695eebb53ef0171f449b1947f1964925f17fb8481c1fe3dcf256474839b188690d69b0cae3f862f1c84b69494188a9df3703aa85a1670d0d8d549641508448429438494a44ab4931ab01cc4366b723",
                DateA = new DateTime(2014, 6, 23),
                DateD = new DateTime(2007, 9, 6),
                Sort = 579522827,
                Note = "d95b96ec81394faa9372bfd78a95d87bf1e933fc83394794aacad7a3e26bec488d30af9554bd4c49a74f176884f02313297223f0f07a4beb81c553082b2b04d49f98b0787c2e48e283c3c1a0f3b3d4a5cdef6657375f47899438a418d7bf930f6a6aea34d0cf409eb388b7cce94ff377cdb0f99a6e1244e187fb663f57e9caf2c6014a0f046f4beebc01e071f171d3f413a822b3cb6c487a8aba86a821a9f8e97a036137736e48e4bfe01e90ebd873b6ea467f6093af48dfaff8a4ec6bc884f962de5e51bff8436694ab6ff144feece7d28ed789c48e4bd3b1222a86d6cf0b56abbb648ebe884c07bfe4a0c060ad78592f7f727bad754862b8bf",
                Status = "cf3f611200c64bed8f9bdd1570f08c7cef95a00ab707446eba"
            };

            // Act
            var serviceResult = await _userVerifysAppService.CreateAsync(input);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.VerifyId == serviceResult.VerifyId);

            result.ShouldNotBe(null);
            result.VerifyId.ShouldBe("3134fcd22a074c85b4d3a6bf1fdd5bedc077fba1340f4574a87d00f1cb4d398d4356a7b099344f67975935f0f048b656b904aaea4ecf4741855c125bda7d2ace50f7436149c34e50bae5a96223769d824dc9eda840884b899b0023f78a485d70e62cb92bdbb744ffa2cb4fca9caf8bbb79c439686c38439ca781b327d8b37db82a39ce328d5e461a96ca4dc3617bbcd1f84d7e5db57b4b8d8fac848066a399f325b40730ccca478caec527e9f08dd0722a72921ce8f74b2ebc37df44b9f61431a59ccc8cba274cbc80d0c16caefff1827ceede38fdd64b16a2cfd4912b5b07c9d478bb47ae5c407eaa5d53c05b7038b924b38525369e42ac89f5");
            result.VerifyCode.ShouldBe("ceab7fc312a94e73a6c0417a4a7a352d6cfb418457e049fa9c");
            result.ExtendedInformation.ShouldBe("522c2ddd8cea495890eed31e3cd3acc09d80cd6f270241cd97d4e7c0067377f9c3f1c443841f43b280efcd51072f248324d8b0798401476fba910924342d80d79bb6e08836d14cee990526d803a99796e89e17e95a22431e85d333b9801c503416d8a46a56a540299988d7cac45d5e164266d266c9f94d839f71b8f6f9e40fda3257fcbc561a43688921857565d67b77953c726275094a60acdc473970841e6f791efbb5b7734e568b78ac695eebb53ef0171f449b1947f1964925f17fb8481c1fe3dcf256474839b188690d69b0cae3f862f1c84b69494188a9df3703aa85a1670d0d8d549641508448429438494a44ab4931ab01cc4366b723");
            result.DateA.ShouldBe(new DateTime(2014, 6, 23));
            result.DateD.ShouldBe(new DateTime(2007, 9, 6));
            result.Sort.ShouldBe(579522827);
            result.Note.ShouldBe("d95b96ec81394faa9372bfd78a95d87bf1e933fc83394794aacad7a3e26bec488d30af9554bd4c49a74f176884f02313297223f0f07a4beb81c553082b2b04d49f98b0787c2e48e283c3c1a0f3b3d4a5cdef6657375f47899438a418d7bf930f6a6aea34d0cf409eb388b7cce94ff377cdb0f99a6e1244e187fb663f57e9caf2c6014a0f046f4beebc01e071f171d3f413a822b3cb6c487a8aba86a821a9f8e97a036137736e48e4bfe01e90ebd873b6ea467f6093af48dfaff8a4ec6bc884f962de5e51bff8436694ab6ff144feece7d28ed789c48e4bd3b1222a86d6cf0b56abbb648ebe884c07bfe4a0c060ad78592f7f727bad754862b8bf");
            result.Status.ShouldBe("cf3f611200c64bed8f9bdd1570f08c7cef95a00ab707446eba");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserVerifyUpdateDto()
            {
                VerifyId = "1bf50677a56441bba0f882903da67d5046e81c17885345599fb93f6618003e7aacf74b7d51914a8c934d8acf89e39bbae2982114eb6746d7a705114d9dd246d2280487bff52540ed9fc5e056f61275b45ac7750b8ef4498bab331694120b13799d05907d527948309c02af09f01c756924c53e8500024f409e14f1d9b8ac27af8c789bbaf6834afdb8b1eab05ff95b4cd7eef1200db049deb6e4419af3c3b23fe47c8916856f4f5a9970e1c83d32c209b1eebc63e54c4e10a4c660849b4bd0cf83fa3977997641298497e30dbbadf9a746451ace87d04939affd1e537df565852825bf675e5548499c9a516ee6693bed1cb45b3473fd409286ca",
                VerifyCode = "5aee81da3f5c46bba524bb63b8802bcc86c01e6dcbd9400ab7",
                ExtendedInformation = "070ddce3c11945ee982330b750890037012eafc1c9764ca49cf94549784908769703521b989f457c8f0ff42f725634487e5c667fa21949d6adc4d80e193a98e7d24528e9fa5d44b3933a587c1c9057b7f56039e76cd746e98b4be943feaf67585795d1b3d70447518af7ffdd512f3542f3ec65e5a1254288aeec31e912afc293a6f8807ef34b427b91efbe20d41df2296c230078ff6d4d73b04ced4fbba5fba19c0248a23ca44ebe94be963cdd89107381f83da04e6245bc975a35bf19f91c72465fc3ca8140446fa49faed2b95cd557bd8e726c5da04c2987a85c3d1b9420b1ef56191aea95405dbdfe90728d1519485e8ee4b571874162a8ef",
                DateA = new DateTime(2017, 4, 5),
                DateD = new DateTime(2012, 4, 23),
                Sort = 333325953,
                Note = "cce2c73bd5e24c9eb50b6b3b179435bc7b2ab524eb844fe3be32be66e03691ba46237d97ee004dd18e50dcc472d4b10d6add4f743f1747cd8679f32c0d41feab6b2c989da8104d1d89fae447c273439bc022359625eb4f4cbf6adb8fe71f4b690e5af35ca2bb40cb92c15b30f68ca94b19176154087f46fa9057c250a8a7ccdd14fe95bed5ad4946928ab0f694a8f54bd771b395e8dd4db5b4bfc0239d412ecb7c6929dcbb66406884ac70a16feaa3b0e142eadceba74cc6806a689d30dda696a667feb28a0d4b8f9f935d07daee32c5c21219b149c24e08b740215beb3e77c143b7750cb8ef4740a29b6bdc70201de52e078b28125d451dbf68",
                Status = "8e15b9f8f01d43efa3cf80abf98b9783bfe19d9a13ea40d0a8"
            };

            // Act
            var serviceResult = await _userVerifysAppService.UpdateAsync(1, input);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.VerifyId.ShouldBe("1bf50677a56441bba0f882903da67d5046e81c17885345599fb93f6618003e7aacf74b7d51914a8c934d8acf89e39bbae2982114eb6746d7a705114d9dd246d2280487bff52540ed9fc5e056f61275b45ac7750b8ef4498bab331694120b13799d05907d527948309c02af09f01c756924c53e8500024f409e14f1d9b8ac27af8c789bbaf6834afdb8b1eab05ff95b4cd7eef1200db049deb6e4419af3c3b23fe47c8916856f4f5a9970e1c83d32c209b1eebc63e54c4e10a4c660849b4bd0cf83fa3977997641298497e30dbbadf9a746451ace87d04939affd1e537df565852825bf675e5548499c9a516ee6693bed1cb45b3473fd409286ca");
            result.VerifyCode.ShouldBe("5aee81da3f5c46bba524bb63b8802bcc86c01e6dcbd9400ab7");
            result.ExtendedInformation.ShouldBe("070ddce3c11945ee982330b750890037012eafc1c9764ca49cf94549784908769703521b989f457c8f0ff42f725634487e5c667fa21949d6adc4d80e193a98e7d24528e9fa5d44b3933a587c1c9057b7f56039e76cd746e98b4be943feaf67585795d1b3d70447518af7ffdd512f3542f3ec65e5a1254288aeec31e912afc293a6f8807ef34b427b91efbe20d41df2296c230078ff6d4d73b04ced4fbba5fba19c0248a23ca44ebe94be963cdd89107381f83da04e6245bc975a35bf19f91c72465fc3ca8140446fa49faed2b95cd557bd8e726c5da04c2987a85c3d1b9420b1ef56191aea95405dbdfe90728d1519485e8ee4b571874162a8ef");
            result.DateA.ShouldBe(new DateTime(2017, 4, 5));
            result.DateD.ShouldBe(new DateTime(2012, 4, 23));
            result.Sort.ShouldBe(333325953);
            result.Note.ShouldBe("cce2c73bd5e24c9eb50b6b3b179435bc7b2ab524eb844fe3be32be66e03691ba46237d97ee004dd18e50dcc472d4b10d6add4f743f1747cd8679f32c0d41feab6b2c989da8104d1d89fae447c273439bc022359625eb4f4cbf6adb8fe71f4b690e5af35ca2bb40cb92c15b30f68ca94b19176154087f46fa9057c250a8a7ccdd14fe95bed5ad4946928ab0f694a8f54bd771b395e8dd4db5b4bfc0239d412ecb7c6929dcbb66406884ac70a16feaa3b0e142eadceba74cc6806a689d30dda696a667feb28a0d4b8f9f935d07daee32c5c21219b149c24e08b740215beb3e77c143b7750cb8ef4740a29b6bdc70201de52e078b28125d451dbf68");
            result.Status.ShouldBe("8e15b9f8f01d43efa3cf80abf98b9783bfe19d9a13ea40d0a8");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userVerifysAppService.DeleteAsync(1);

            // Assert
            var result = await _userVerifyRepository.FindAsync(c => c.Id == 1);

            result.ShouldBeNull();
        }
    }
}