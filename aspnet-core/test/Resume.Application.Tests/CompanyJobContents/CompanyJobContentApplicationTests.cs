using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobContentsAppService _companyJobContentsAppService;
        private readonly IRepository<CompanyJobContent, Guid> _companyJobContentRepository;

        public CompanyJobContentsAppServiceTests()
        {
            _companyJobContentsAppService = GetRequiredService<ICompanyJobContentsAppService>();
            _companyJobContentRepository = GetRequiredService<IRepository<CompanyJobContent, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobContentsAppService.GetListAsync(new GetCompanyJobContentsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2d4a95d4-5c41-4c72-9998-c08f901162b6")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobContentsAppService.GetAsync(Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobContentCreateDto
            {
                CompanyMainId = Guid.Parse("a5d25e89-b110-4074-9f05-6d74d92b8984"),
                CompanyJobId = Guid.Parse("2ffd52ea-49ec-49f3-a5ed-5011e667f16a"),
                Name = "c2d46245cb8541519ae31e11ce3c3ef088965e00da5f4e4994",
                JobTypeCode = "886676588b4a4d4cb1c8265bd6ffba3b944537d751d64b10a0",
                PeopleRequiredNumber = 804178311,
                PeopleRequiredNumberUnlimited = true,
                JobType = "47c3a79633174f3998588d056a28ca8f5618b3a906da421eb4b74305df61a27e405629ff7ec94286b40155ae93351171449e6bec17694a0eb625dab8a21208789c190d7ce734480aa98c5d263c0c549956110820c6104d49b52307edfb1202d2bbde5da7",
                JobTypeContent = "0f8cfb25d41b4e8e8e3a1091c973b72840f916f7e3c04fbeb63f6571833d4c57551d4647a5e34d08",
                SalaryPayTypeCode = "bcac9f8bb8044287b4635da2650d3ac268fa4f18ceb449aa9c",
                SalaryMin = 1319386940,
                SalaryMax = 1738943146,
                SalaryUp = true,
                WorkPlace = "5d95cb5041df47cf89c1d0913b362d1576dddf9db95e4950be92e85e40196dcbcf18c49b2b1f4e56b40da2091c75e75328f2a034a1b94420812500dc4536755eb92b17b7f2b54716b9b7914f74de3e0baab486bd1ac7473380cd9e1e55365d8953a79938",
                WorkHours = "544b589515dc4093af1a21fa281f2ed23e18e43e49f244c88fcf6acee2363202b1a56f0ff0f54d1e9e38248534b50c530802d0b8f7db4566a81f68f60fcecc47cd36a591bf5c4f06ad768c1d3875511db0632d5aa2f143ad9654054080830dd7ddc81650",
                WorkHour = "3bd9cbd338be4152948870939de4c2df53efdda920c8419ead78f90f8744c0899a9f1815600648d9ba99fbeac7435adffc83250d330c449197f1d5c0ae105f1be6a6c44318a54a1cb894c3a36f56519285815c4ca3ac45c2ab636e0823cf98b4a60e4a68",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "44bc5777718c4af2b186074b23aa0812ed9f0503ac064b7db7",
                WorkRemote = "7723b7ff1dd94b68a2bb6adf47528abd5bf368f854cc4fb0adde56b696b00242e2364b1d86b04136bd441101321c491e464de4b92fd9487f9c0a848ebe9e1f5f4275816e9b3c48449a915859df23f16bc5e461f567d04b60b947b1204b786e07e8f540e3",
                WorkDifferentPlaces = "a883c976bfe149629d8250b2f8743a8c39a30f4e6a3f4e83946a251a81d2c0a8f689ef9e9bec4359b0d63a1508db72192f932084fc6b4a83bcce85aa44cea5df45710b7858b6408c8a6f32b28387957437321e252f014d8b948c3130ef8abe9a39b89ce2",
                HolidaySystemCode = "6008c1255dea448398a1277c5703b38e009e3bc228a54b5e93",
                WorkDayCode = "ea9d57c80dc24c93b1470826501308e989b080467d5f4c4799",
                WorkIdentityCode = "bc88755617c441d49233b6018e84547cf5d6fb054347438e959b65ce3a1273799f8b8980035841d399da6092e349ee0b3b8ceb76158f400282e74d185c1f9cd9c0bb9e5547d64184869e0a7d4c924778c7f3475e900a41d696d39ebeee607df897b9c761",
                DisabilityCategory = "8a980a6842c1416988eca7a64fc980640b7a5916cfe54a98a3516a4ec00b6159aa3b93a0721a40dbabf3b05aa6056e5196b2d92a292f41838a017d0c62b7b4a1d3405c4eb3b943d9b660f49e621c89a05ff5c774561b4e48a900187fff973503615a099e",
                ExtendedInformation = "98482720e1504c338bf582955731fdb1c804ec499ff64f11bc00b8df968792da0caa092c86054145a46f69819f85520443134e4f2cd34fceb61b1a88999a5b9b726d85ec2cf84e53b69c28602482e279390d393037a84b7da529aca609226bd3e981de5c7cd04308b8be1cd016d78a0ca8758b964e184259bd364765c87c8c1c4cba2069836640989d94b0dd5835d070b7e4fbd2ec9346e3b0576dbf693e12100a3d44bbd6b0493c80dd6f892df77f00ab83fc8d0ede437e8bdaa12a28ec3e81a89dbabff5a04a6888c69ccecb02e61cd99e938365dc450a8c04fd72b3bf6fdd1ae196b620da4bdaac493466435e3ceabb5020a056b045ceb44a",
                DateA = new DateTime(2000, 2, 2),
                DateD = new DateTime(2016, 5, 12),
                Sort = 868057912,
                Note = "8a3ecea8323c44a0adf1a8bb1e40138984ff88b4e5844ee59767f3aa1eb73911dc56d463d9ca4d30b02eee9b10ae0cf2ec7ba0c409294ff29f4aa94768a83136e0410533f05e42319a172f81e2d6d6f5b98ce7032ae44d138fe0eb3c37cff865a68ca1bc822b402ca6b5d04412a2954478606b51370f4e1385331b0b8b27956efbad388023c649b1b60e7ee5ae42dd4560745df56c1a4de2b7eeddd6e267da30f32d5bd6a9d74ec6b3762e590ef061d1e6472769514144bc8fa8a5797d3f98dc53ac267046f04755be25ba46fae196858c098cd885c545de8792ef5f77d4a8cce577299233bc4c07903a8fc0ba08e6ff0cf25b5e7e52488c9dcf",
                Status = "f2e18417b4bf423ca144737fdbba0220f9f3bc7315a2489f97"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("a5d25e89-b110-4074-9f05-6d74d92b8984"));
            result.CompanyJobId.ShouldBe(Guid.Parse("2ffd52ea-49ec-49f3-a5ed-5011e667f16a"));
            result.Name.ShouldBe("c2d46245cb8541519ae31e11ce3c3ef088965e00da5f4e4994");
            result.JobTypeCode.ShouldBe("886676588b4a4d4cb1c8265bd6ffba3b944537d751d64b10a0");
            result.PeopleRequiredNumber.ShouldBe(804178311);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("47c3a79633174f3998588d056a28ca8f5618b3a906da421eb4b74305df61a27e405629ff7ec94286b40155ae93351171449e6bec17694a0eb625dab8a21208789c190d7ce734480aa98c5d263c0c549956110820c6104d49b52307edfb1202d2bbde5da7");
            result.JobTypeContent.ShouldBe("0f8cfb25d41b4e8e8e3a1091c973b72840f916f7e3c04fbeb63f6571833d4c57551d4647a5e34d08");
            result.SalaryPayTypeCode.ShouldBe("bcac9f8bb8044287b4635da2650d3ac268fa4f18ceb449aa9c");
            result.SalaryMin.ShouldBe(1319386940);
            result.SalaryMax.ShouldBe(1738943146);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("5d95cb5041df47cf89c1d0913b362d1576dddf9db95e4950be92e85e40196dcbcf18c49b2b1f4e56b40da2091c75e75328f2a034a1b94420812500dc4536755eb92b17b7f2b54716b9b7914f74de3e0baab486bd1ac7473380cd9e1e55365d8953a79938");
            result.WorkHours.ShouldBe("544b589515dc4093af1a21fa281f2ed23e18e43e49f244c88fcf6acee2363202b1a56f0ff0f54d1e9e38248534b50c530802d0b8f7db4566a81f68f60fcecc47cd36a591bf5c4f06ad768c1d3875511db0632d5aa2f143ad9654054080830dd7ddc81650");
            result.WorkHour.ShouldBe("3bd9cbd338be4152948870939de4c2df53efdda920c8419ead78f90f8744c0899a9f1815600648d9ba99fbeac7435adffc83250d330c449197f1d5c0ae105f1be6a6c44318a54a1cb894c3a36f56519285815c4ca3ac45c2ab636e0823cf98b4a60e4a68");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("44bc5777718c4af2b186074b23aa0812ed9f0503ac064b7db7");
            result.WorkRemote.ShouldBe("7723b7ff1dd94b68a2bb6adf47528abd5bf368f854cc4fb0adde56b696b00242e2364b1d86b04136bd441101321c491e464de4b92fd9487f9c0a848ebe9e1f5f4275816e9b3c48449a915859df23f16bc5e461f567d04b60b947b1204b786e07e8f540e3");
            result.WorkDifferentPlaces.ShouldBe("a883c976bfe149629d8250b2f8743a8c39a30f4e6a3f4e83946a251a81d2c0a8f689ef9e9bec4359b0d63a1508db72192f932084fc6b4a83bcce85aa44cea5df45710b7858b6408c8a6f32b28387957437321e252f014d8b948c3130ef8abe9a39b89ce2");
            result.HolidaySystemCode.ShouldBe("6008c1255dea448398a1277c5703b38e009e3bc228a54b5e93");
            result.WorkDayCode.ShouldBe("ea9d57c80dc24c93b1470826501308e989b080467d5f4c4799");
            result.WorkIdentityCode.ShouldBe("bc88755617c441d49233b6018e84547cf5d6fb054347438e959b65ce3a1273799f8b8980035841d399da6092e349ee0b3b8ceb76158f400282e74d185c1f9cd9c0bb9e5547d64184869e0a7d4c924778c7f3475e900a41d696d39ebeee607df897b9c761");
            result.DisabilityCategory.ShouldBe("8a980a6842c1416988eca7a64fc980640b7a5916cfe54a98a3516a4ec00b6159aa3b93a0721a40dbabf3b05aa6056e5196b2d92a292f41838a017d0c62b7b4a1d3405c4eb3b943d9b660f49e621c89a05ff5c774561b4e48a900187fff973503615a099e");
            result.ExtendedInformation.ShouldBe("98482720e1504c338bf582955731fdb1c804ec499ff64f11bc00b8df968792da0caa092c86054145a46f69819f85520443134e4f2cd34fceb61b1a88999a5b9b726d85ec2cf84e53b69c28602482e279390d393037a84b7da529aca609226bd3e981de5c7cd04308b8be1cd016d78a0ca8758b964e184259bd364765c87c8c1c4cba2069836640989d94b0dd5835d070b7e4fbd2ec9346e3b0576dbf693e12100a3d44bbd6b0493c80dd6f892df77f00ab83fc8d0ede437e8bdaa12a28ec3e81a89dbabff5a04a6888c69ccecb02e61cd99e938365dc450a8c04fd72b3bf6fdd1ae196b620da4bdaac493466435e3ceabb5020a056b045ceb44a");
            result.DateA.ShouldBe(new DateTime(2000, 2, 2));
            result.DateD.ShouldBe(new DateTime(2016, 5, 12));
            result.Sort.ShouldBe(868057912);
            result.Note.ShouldBe("8a3ecea8323c44a0adf1a8bb1e40138984ff88b4e5844ee59767f3aa1eb73911dc56d463d9ca4d30b02eee9b10ae0cf2ec7ba0c409294ff29f4aa94768a83136e0410533f05e42319a172f81e2d6d6f5b98ce7032ae44d138fe0eb3c37cff865a68ca1bc822b402ca6b5d04412a2954478606b51370f4e1385331b0b8b27956efbad388023c649b1b60e7ee5ae42dd4560745df56c1a4de2b7eeddd6e267da30f32d5bd6a9d74ec6b3762e590ef061d1e6472769514144bc8fa8a5797d3f98dc53ac267046f04755be25ba46fae196858c098cd885c545de8792ef5f77d4a8cce577299233bc4c07903a8fc0ba08e6ff0cf25b5e7e52488c9dcf");
            result.Status.ShouldBe("f2e18417b4bf423ca144737fdbba0220f9f3bc7315a2489f97");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobContentUpdateDto()
            {
                CompanyMainId = Guid.Parse("082c88f9-7425-4f68-9716-d6aca1746da1"),
                CompanyJobId = Guid.Parse("d116b0b6-c18d-464d-8eb1-27742a55517f"),
                Name = "fe2eb57410134f70be31ba6aaaaacfe6fe0c1cf6ba9c4357b7",
                JobTypeCode = "0da869d3fc274f4faca7a25b5ec63a17e00d44b0cfc7455181",
                PeopleRequiredNumber = 1466438249,
                PeopleRequiredNumberUnlimited = true,
                JobType = "6f16680d3ed9463f9384f269ddd7e07966cb6d2e601c4f22a3f85429f178a7cc2be4f24b2cc84944886e948812a436cf1618a2b9d74a4a3889be38f0816c4ede070a44ce8d2a4ae6a3a555d7039c0aa51a1b109207134886a4d73f677e9eea4da78593e5",
                JobTypeContent = "4dc8664a9a504e1c8ae5f8fe68b04923203d437c7e0a426a96027d",
                SalaryPayTypeCode = "458d8c226de94478b2d39592ec9d0c2176c31be7168b48d58d",
                SalaryMin = 514789797,
                SalaryMax = 2099740269,
                SalaryUp = true,
                WorkPlace = "b091e1f198c244c4b4a893606720b544fbb5343125d842608991516bd9ff4447762e4a7a751e4586afddf295d72bf0e7a9f39d70f8324f78a09ac00ff4e2784b19b9d9a5b40f4ce7b7c10b83ad1befa04b20bb4f65b44eb68660d37c8f65f9a0861668c4",
                WorkHours = "c3ca474706254f7da1a58cd50ae9a431ddd9c74377f345d4af6816f00ab6551b1c80f96ded104cafa8d0a146cc5bc21779944e8c171f4c0fa8f50cf3512423c1814e6d1a5b5c4c32bc675c9a0abe76462b7edbd05dc04a70b8f0d67add8139f94c9ad3f1",
                WorkHour = "a2389b592bf5405c9e0a2dba8483276fed8d9a4e88774388a0b9420717cead125dd3e910619b47b48f9e13f410fcca64962563db064a4af996b8aef16a93e737cff58fd9e5c44e51a3166472ee04b099bf2797c8cab24a8ba8e22a2a7735e49f6063459c",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "25378a65346d45fab39ade40c519d82579b9fe5722584e6b90",
                WorkRemote = "168250fb86e642878ecc549e6f1cf190ec7c8467abc84a74952b3b271c07f5a2ce62c9aec2864fedbaa73b4fe3f940467f842709b0ff4ee7a2c8275a3e81ee8a29e556c9067141d88cfeb22b7d6456ec670e766937714d95bb9fc054b35efa5f570c344b",
                WorkDifferentPlaces = "924526ad89be4c9e908c7779e7eb395461b3aa2546f74bd28d5594749a482f85bef02bf620c640afb28c2335a13a212ffc12e18f2f3e482fb83ed623b7d3cbd3a553fd20488d4c029946f019d45f6ae8e2e3d7a76a3f43f0abdceac2923fdac851912fda",
                HolidaySystemCode = "cea11502e1424d4186efef557de480a74341f8b26e9b45e1b8",
                WorkDayCode = "6a97625e51cb4d6c9cf1b4287c7b4bd135d2359156834437ad",
                WorkIdentityCode = "f70d461712c54a2e916c32498bb55551ccc7e6326135426d87010745f9d68b724afac3406f3c451582fddff6508ecd8e5193ee1430de45cdb25b490472284f3211aa84b88abf4b5e944dc260e34dd3380af3229fdcc84fb19f72af0e7542dc04ab593c63",
                DisabilityCategory = "c87e225837c14a10954a287968a0075c465d17e485324263b6a58a639191063d94ee3529ca0e4b908132dcd5234a682f661789b1258c4293a5d266e0dd367fdb2bfb94c8b6d6428f9a3d70ef5daa11872c895dcd8e614acba0c2260102a46dc09fa51b7e",
                ExtendedInformation = "37490f4a3e3f49b79d549eee262fd182627e74a0b2644f7eb5b94d6e8adb90913c04fa8d5e3e4764977d8f9ba0da4a77c7043042950f4577a4b98c6b7b5f666d637aae83c6a64e5cbce99974ecc0ebba414bfe4350d1448f94db5cd050ab90dd52872d0a114d45ec8eeded81b6e551602cfa1ef2a80d4f40859cdf3656f31fd259213e00080b4193b145b55b575a99525efd3a7bc22241d0a13699f284cacbd1c8c01ad3cd51441fbbce68fb666448d2c379bef6b3cf4f8cb82e588719fa5d9ce6ae1303a14f4c6d95bd6bef8adae3eec415402d067744da9201c1eea45f5383545007e9c37a443c996e05875d0d4b60876239a57ad249a9ba38",
                DateA = new DateTime(2007, 4, 27),
                DateD = new DateTime(2019, 11, 3),
                Sort = 1256294861,
                Note = "6aa7a1c46b4440f79d97346bf03b6b8c2911e1610efa4a8ca4b476a7e60525126f3849bcb2534f64adcd4ef156e86ca89926d74e8ee547688146056aa514723855d23dbda46648d2ac640da3526aa71ddfeaf8ee78ef452db5c63cc107aa6b68088252e902d1407fb1dac80139ecb0599f9416beca1449098d8500b308a22c10a9b64396e5ed418aaa77c4bffb28186696ffedf59d1948bfaf0b0ec33e9633cd361c57074d3d47dda0592d077faf7428e02ace1f48394b999d3c4e259d00c4d8f1ac3d78d05448a48e0be10f084f6fa2eed4168d549d43419e471c89becc93425824b61dec1f48dabec55f7036a9126c8e035aca01b342679bfc",
                Status = "38ee08d1e0814e74b032ad693e07dadab387261e84a64156b2"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.UpdateAsync(Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"), input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("082c88f9-7425-4f68-9716-d6aca1746da1"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d116b0b6-c18d-464d-8eb1-27742a55517f"));
            result.Name.ShouldBe("fe2eb57410134f70be31ba6aaaaacfe6fe0c1cf6ba9c4357b7");
            result.JobTypeCode.ShouldBe("0da869d3fc274f4faca7a25b5ec63a17e00d44b0cfc7455181");
            result.PeopleRequiredNumber.ShouldBe(1466438249);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("6f16680d3ed9463f9384f269ddd7e07966cb6d2e601c4f22a3f85429f178a7cc2be4f24b2cc84944886e948812a436cf1618a2b9d74a4a3889be38f0816c4ede070a44ce8d2a4ae6a3a555d7039c0aa51a1b109207134886a4d73f677e9eea4da78593e5");
            result.JobTypeContent.ShouldBe("4dc8664a9a504e1c8ae5f8fe68b04923203d437c7e0a426a96027d");
            result.SalaryPayTypeCode.ShouldBe("458d8c226de94478b2d39592ec9d0c2176c31be7168b48d58d");
            result.SalaryMin.ShouldBe(514789797);
            result.SalaryMax.ShouldBe(2099740269);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("b091e1f198c244c4b4a893606720b544fbb5343125d842608991516bd9ff4447762e4a7a751e4586afddf295d72bf0e7a9f39d70f8324f78a09ac00ff4e2784b19b9d9a5b40f4ce7b7c10b83ad1befa04b20bb4f65b44eb68660d37c8f65f9a0861668c4");
            result.WorkHours.ShouldBe("c3ca474706254f7da1a58cd50ae9a431ddd9c74377f345d4af6816f00ab6551b1c80f96ded104cafa8d0a146cc5bc21779944e8c171f4c0fa8f50cf3512423c1814e6d1a5b5c4c32bc675c9a0abe76462b7edbd05dc04a70b8f0d67add8139f94c9ad3f1");
            result.WorkHour.ShouldBe("a2389b592bf5405c9e0a2dba8483276fed8d9a4e88774388a0b9420717cead125dd3e910619b47b48f9e13f410fcca64962563db064a4af996b8aef16a93e737cff58fd9e5c44e51a3166472ee04b099bf2797c8cab24a8ba8e22a2a7735e49f6063459c");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("25378a65346d45fab39ade40c519d82579b9fe5722584e6b90");
            result.WorkRemote.ShouldBe("168250fb86e642878ecc549e6f1cf190ec7c8467abc84a74952b3b271c07f5a2ce62c9aec2864fedbaa73b4fe3f940467f842709b0ff4ee7a2c8275a3e81ee8a29e556c9067141d88cfeb22b7d6456ec670e766937714d95bb9fc054b35efa5f570c344b");
            result.WorkDifferentPlaces.ShouldBe("924526ad89be4c9e908c7779e7eb395461b3aa2546f74bd28d5594749a482f85bef02bf620c640afb28c2335a13a212ffc12e18f2f3e482fb83ed623b7d3cbd3a553fd20488d4c029946f019d45f6ae8e2e3d7a76a3f43f0abdceac2923fdac851912fda");
            result.HolidaySystemCode.ShouldBe("cea11502e1424d4186efef557de480a74341f8b26e9b45e1b8");
            result.WorkDayCode.ShouldBe("6a97625e51cb4d6c9cf1b4287c7b4bd135d2359156834437ad");
            result.WorkIdentityCode.ShouldBe("f70d461712c54a2e916c32498bb55551ccc7e6326135426d87010745f9d68b724afac3406f3c451582fddff6508ecd8e5193ee1430de45cdb25b490472284f3211aa84b88abf4b5e944dc260e34dd3380af3229fdcc84fb19f72af0e7542dc04ab593c63");
            result.DisabilityCategory.ShouldBe("c87e225837c14a10954a287968a0075c465d17e485324263b6a58a639191063d94ee3529ca0e4b908132dcd5234a682f661789b1258c4293a5d266e0dd367fdb2bfb94c8b6d6428f9a3d70ef5daa11872c895dcd8e614acba0c2260102a46dc09fa51b7e");
            result.ExtendedInformation.ShouldBe("37490f4a3e3f49b79d549eee262fd182627e74a0b2644f7eb5b94d6e8adb90913c04fa8d5e3e4764977d8f9ba0da4a77c7043042950f4577a4b98c6b7b5f666d637aae83c6a64e5cbce99974ecc0ebba414bfe4350d1448f94db5cd050ab90dd52872d0a114d45ec8eeded81b6e551602cfa1ef2a80d4f40859cdf3656f31fd259213e00080b4193b145b55b575a99525efd3a7bc22241d0a13699f284cacbd1c8c01ad3cd51441fbbce68fb666448d2c379bef6b3cf4f8cb82e588719fa5d9ce6ae1303a14f4c6d95bd6bef8adae3eec415402d067744da9201c1eea45f5383545007e9c37a443c996e05875d0d4b60876239a57ad249a9ba38");
            result.DateA.ShouldBe(new DateTime(2007, 4, 27));
            result.DateD.ShouldBe(new DateTime(2019, 11, 3));
            result.Sort.ShouldBe(1256294861);
            result.Note.ShouldBe("6aa7a1c46b4440f79d97346bf03b6b8c2911e1610efa4a8ca4b476a7e60525126f3849bcb2534f64adcd4ef156e86ca89926d74e8ee547688146056aa514723855d23dbda46648d2ac640da3526aa71ddfeaf8ee78ef452db5c63cc107aa6b68088252e902d1407fb1dac80139ecb0599f9416beca1449098d8500b308a22c10a9b64396e5ed418aaa77c4bffb28186696ffedf59d1948bfaf0b0ec33e9633cd361c57074d3d47dda0592d077faf7428e02ace1f48394b999d3c4e259d00c4d8f1ac3d78d05448a48e0be10f084f6fa2eed4168d549d43419e471c89becc93425824b61dec1f48dabec55f7036a9126c8e035aca01b342679bfc");
            result.Status.ShouldBe("38ee08d1e0814e74b032ad693e07dadab387261e84a64156b2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobContentsAppService.DeleteAsync(Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"));

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == Guid.Parse("cbda65df-3477-4a38-a9a5-2e004632c0a5"));

            result.ShouldBeNull();
        }
    }
}