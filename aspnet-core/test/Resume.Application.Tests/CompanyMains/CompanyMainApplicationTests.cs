using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyMains
{
    public class CompanyMainsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyMainsAppService _companyMainsAppService;
        private readonly IRepository<CompanyMain, Guid> _companyMainRepository;

        public CompanyMainsAppServiceTests()
        {
            _companyMainsAppService = GetRequiredService<ICompanyMainsAppService>();
            _companyMainRepository = GetRequiredService<IRepository<CompanyMain, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyMainsAppService.GetListAsync(new GetCompanyMainsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("dd7ee00e-4789-4b98-8c35-d8adc877832e")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyMainsAppService.GetAsync(Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyMainCreateDto
            {
                Name = "ba17117f06e946c99a4709725d20e4c5012886f0536c4f32ac",
                Compilation = "482747cf9ba24c2b82eecbcd6c1f890eca7afb9aa0dc4a72b4",
                OfficePhone = "6ecacda764b4474199bb6b7e7116f4761e870cf097c443b3a7",
                FaxPhone = "c0530d7a5ec447359612e2f971ee303607fdeb5619b949d493",
                Address = "8f7600e0c7ef42e7b454901c86441c93e3106bd0e4b34401a6",
                Principal = "3e06e79b56434f92b4b1240935b3f0fdb54ff1c01e414bdd89",
                AllowSearch = true,
                ExtendedInformation = "0de7afb6cac8496fb2f0459708f6e0bbc7f71e49db0647a1bd4c8d461ee49546e9a3c9bb14354920913f883a550e711b82a82d9718c54cf5a287f107ad0c19b287d0d9237aa144289adfe543101e17d64e1bb7cdeab547eba88bdf98469dc67874b8bb4b81d044b499d86245acc52fa614cae8f87d844cdbb8be7989f31c547a2802749d783640728b823edfc1d62fe2194cf4fce5d94d2c9057a99672bb79761b627ab018ae4bbe8037f6eac575a4c8ab09eecfae454c09b68884cc8dfb1e942904900be0a640ada6d956dff700ff50041975b7a2404403ae87209b90635c1d3e766cc5e11344488104764d32bb78fd1611a0f1081f4915a8ba",
                DateA = new DateTime(2008, 9, 22),
                DateD = new DateTime(2020, 1, 18),
                Note = "890acfd7739b4844baeb195d25ddea9678578479341047218e4f5852c18043b34e7516d7aef6402082b209544674c5668607e34fff5c4307a9a4e070ebc861d8cfcefa3960144319805a211bb831c128d58f2925637b457383be2fe559d6c7d6b57458e86a0f4ce3a1929d9e50b28b403a9ace980f644fe08256f8460f2664c0a2538f9c8cf643f5b59579789cf6a7fa1af1b5090d2e465693d9b7ad498d6aba5fb5e53cc07f45eea6947b4ded7910c77c4cdde3b7d24073b73664344eb99de56cf58173a08e4773bb3bb7f8267c4bd619740bef5f074b7ca0f35817af376db45a82d837ca934873b6886030e7103f934e6fdd5f8ce2441685bb",
                Sort = 432247524,
                Status = "a8414f56ade044db8a049889768dd166726f64a9400f443ca9",
                IndustryCategory = "cb2653fdbdb24b0bb2e3cae55116bac8303de70de1ac422595fb5a6f74c85b2bdfd4ae3eac9546408c2438964b99447338eed56b99284e2b9780cbaed155f8cce055f2a6383745ee9861363552760f0f73e76fb3af3942aabb15ef64b97594d3eb90595e7ce44dcd9a1a204422dc20f40b2ba7b055be40fe9c595e7666c386018e1b9dcfefad4ce4b4b75d2820c4515d68d44021b546424fadcdfbade166e3000975d1a14b554d5b8ac8f7757a4c6c6a1a9e254466eb4a21abf334d9a90f1f0b18fff241112e4b3196bd654449271b8e4a9a0f416e22481c8bb1a791c2760975f220edcf7fcf4452b57a0f2aa05a5d81234b8aefc3614401bad5",
                CompanyUrl = "0e5e04c331a3485e863ab1e1754389d8a6fb3ae84e8b42b7a9a915b2ccd60681148cf95add0e4bfeb7c770ee0eb083aee4141d15f2cb4cbeb49bbb7d356b7773df89dcb8527044029b4517adc1d6c64eedc7d872aa4d41f7bac7ff72a771fb4f0ad054aa",
                CapitalAmount = 226982864,
                HideCapitalAmount = true,
                CompanyScaleCode = "0fdd021d52b14ff5a31aeef55cee7b55501a21914d1f4e05af",
                HidePrincipal = true,
                CompanyUserId = Guid.Parse("97e487e2-9dc6-42ed-a7c5-ad0f6ca2712d"),
                CompanyProfile = "7f2baf7284b54896899a723c96b7e01ea5a963baa9734e029bb3b47c2d54045b6c3ccd51ea844ce39ac647114f1746589cba86eaf5f843ce9d71156cbc244ee3c554c07096ee426db2f2a9ae7b3d8153e040e0c6e6fc455880443ea1ef6723e129f02fcbf119494b9e0dfd8810f46bf64f0d969e59214e29bb9fd5eba7efd5d90b8a4ab7825645ca957e81b370d7d24b678cdd869f5e41b6b29224b7ceb32c4f953d733e9a9a4cc58b59f1780bfb850454912cb910c24d8f934f0e7d856aff115dcee45e39d24386960bb500ec2e2607ebe64bb567d94952add01760b056e32bd6c7d18963274267944c5237dc2993ee07fca691051d4e1593d2",
                BusinessPhilosophy = "445803c344274aa39160e4550369e4ca295a619f7d024301a825f9acbc3af4ef34163c2dfdd74096a98e18e2f8b3a0fe6169a6f94353486496642a29e5a708c50c5c863a5a03490fa0aa205f629ad44e98111cc617f94c1381409ea7a4d42e0b79b98fc2f1c145d9b3b39b7e541757ddfeff0c3bd4c24dff9c046b1ddd5dd36a980f1ecbe86e492d97821a8ab0f825fbe302254fc57d4835ad2613c3f5ca2530cbdb55d826b747e0bf7998bd8f5e3fb8f210e12f81484b4f98661d38e0f2781888bbddd591e543e89be4930e47e09150ac1cc4ffeb3f4581beb7c4de648accb63484fadc95cf4080bcf3513051d2058cc9b084c647c7473ebfff",
                OperatingItems = "9e264cec98c14636bb16df10792f33ec3abd1273c7aa41b0879de3713bfd51694f9b3630f16641239bbeb97129a5cf300ef797faa1b143dd8428f23616bcae940c5eadc063284d75bd5f9d3dbd59c29c750b879340b54a05be9f31b0279fb4d7de9031cf12ff45ea95fd2530b3c507f7c968c5808f14413bb66da1a2235dfabd8d338861d13643cabf69cffc1c2f5095419882202c8d45feb93f39472a6e4a0b66c6a4071285432c9422032edf19adb4bd3bb33462b44b49acc269e14081edc22ccd64e4ef0947ee8b9faea8d1684fc2cc13b04fda554ab8a0257bcd345a0225919c6dc222fc4e3ead78806c0be89f4c9a35bb9a20fc417ca4a8",
                WelfareSystem = "5821da3876354d8ba90b9ca8e2bb9285e32526c05f6e4703ad676ce7e08934cab6182732dab3412e9b8c0ddd02b7d74e09ae5ca675d94252be82621cb27d0a56a39816174f6b48a7b171f7262178124d241c3f0cd17e4826ab0e79232cb14472d88e7774f6f54f9a8357995c9e976f2aa000c66d648447fe87cef9ed7d1a4278c6390779c845463a979ae93c7825fbfeda6f7426722a437b9f2a25067f61bd8ff7b9507145a34c0187d430176499afaa377ebeea4cdc46efb23b2238a3d27d0a62e26b0fa2924136a262c3fa4b289325d015de75e732459c8e639be0928a5901ee14279280274a76b2cfcaea154c50cc351537c78bc04d8599c5",
                Matching = true,
                ContractPass = true
            };

            // Act
            var serviceResult = await _companyMainsAppService.CreateAsync(input);

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("ba17117f06e946c99a4709725d20e4c5012886f0536c4f32ac");
            result.Compilation.ShouldBe("482747cf9ba24c2b82eecbcd6c1f890eca7afb9aa0dc4a72b4");
            result.OfficePhone.ShouldBe("6ecacda764b4474199bb6b7e7116f4761e870cf097c443b3a7");
            result.FaxPhone.ShouldBe("c0530d7a5ec447359612e2f971ee303607fdeb5619b949d493");
            result.Address.ShouldBe("8f7600e0c7ef42e7b454901c86441c93e3106bd0e4b34401a6");
            result.Principal.ShouldBe("3e06e79b56434f92b4b1240935b3f0fdb54ff1c01e414bdd89");
            result.AllowSearch.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("0de7afb6cac8496fb2f0459708f6e0bbc7f71e49db0647a1bd4c8d461ee49546e9a3c9bb14354920913f883a550e711b82a82d9718c54cf5a287f107ad0c19b287d0d9237aa144289adfe543101e17d64e1bb7cdeab547eba88bdf98469dc67874b8bb4b81d044b499d86245acc52fa614cae8f87d844cdbb8be7989f31c547a2802749d783640728b823edfc1d62fe2194cf4fce5d94d2c9057a99672bb79761b627ab018ae4bbe8037f6eac575a4c8ab09eecfae454c09b68884cc8dfb1e942904900be0a640ada6d956dff700ff50041975b7a2404403ae87209b90635c1d3e766cc5e11344488104764d32bb78fd1611a0f1081f4915a8ba");
            result.DateA.ShouldBe(new DateTime(2008, 9, 22));
            result.DateD.ShouldBe(new DateTime(2020, 1, 18));
            result.Note.ShouldBe("890acfd7739b4844baeb195d25ddea9678578479341047218e4f5852c18043b34e7516d7aef6402082b209544674c5668607e34fff5c4307a9a4e070ebc861d8cfcefa3960144319805a211bb831c128d58f2925637b457383be2fe559d6c7d6b57458e86a0f4ce3a1929d9e50b28b403a9ace980f644fe08256f8460f2664c0a2538f9c8cf643f5b59579789cf6a7fa1af1b5090d2e465693d9b7ad498d6aba5fb5e53cc07f45eea6947b4ded7910c77c4cdde3b7d24073b73664344eb99de56cf58173a08e4773bb3bb7f8267c4bd619740bef5f074b7ca0f35817af376db45a82d837ca934873b6886030e7103f934e6fdd5f8ce2441685bb");
            result.Sort.ShouldBe(432247524);
            result.Status.ShouldBe("a8414f56ade044db8a049889768dd166726f64a9400f443ca9");
            result.IndustryCategory.ShouldBe("cb2653fdbdb24b0bb2e3cae55116bac8303de70de1ac422595fb5a6f74c85b2bdfd4ae3eac9546408c2438964b99447338eed56b99284e2b9780cbaed155f8cce055f2a6383745ee9861363552760f0f73e76fb3af3942aabb15ef64b97594d3eb90595e7ce44dcd9a1a204422dc20f40b2ba7b055be40fe9c595e7666c386018e1b9dcfefad4ce4b4b75d2820c4515d68d44021b546424fadcdfbade166e3000975d1a14b554d5b8ac8f7757a4c6c6a1a9e254466eb4a21abf334d9a90f1f0b18fff241112e4b3196bd654449271b8e4a9a0f416e22481c8bb1a791c2760975f220edcf7fcf4452b57a0f2aa05a5d81234b8aefc3614401bad5");
            result.CompanyUrl.ShouldBe("0e5e04c331a3485e863ab1e1754389d8a6fb3ae84e8b42b7a9a915b2ccd60681148cf95add0e4bfeb7c770ee0eb083aee4141d15f2cb4cbeb49bbb7d356b7773df89dcb8527044029b4517adc1d6c64eedc7d872aa4d41f7bac7ff72a771fb4f0ad054aa");
            result.CapitalAmount.ShouldBe(226982864);
            result.HideCapitalAmount.ShouldBe(true);
            result.CompanyScaleCode.ShouldBe("0fdd021d52b14ff5a31aeef55cee7b55501a21914d1f4e05af");
            result.HidePrincipal.ShouldBe(true);
            result.CompanyUserId.ShouldBe(Guid.Parse("97e487e2-9dc6-42ed-a7c5-ad0f6ca2712d"));
            result.CompanyProfile.ShouldBe("7f2baf7284b54896899a723c96b7e01ea5a963baa9734e029bb3b47c2d54045b6c3ccd51ea844ce39ac647114f1746589cba86eaf5f843ce9d71156cbc244ee3c554c07096ee426db2f2a9ae7b3d8153e040e0c6e6fc455880443ea1ef6723e129f02fcbf119494b9e0dfd8810f46bf64f0d969e59214e29bb9fd5eba7efd5d90b8a4ab7825645ca957e81b370d7d24b678cdd869f5e41b6b29224b7ceb32c4f953d733e9a9a4cc58b59f1780bfb850454912cb910c24d8f934f0e7d856aff115dcee45e39d24386960bb500ec2e2607ebe64bb567d94952add01760b056e32bd6c7d18963274267944c5237dc2993ee07fca691051d4e1593d2");
            result.BusinessPhilosophy.ShouldBe("445803c344274aa39160e4550369e4ca295a619f7d024301a825f9acbc3af4ef34163c2dfdd74096a98e18e2f8b3a0fe6169a6f94353486496642a29e5a708c50c5c863a5a03490fa0aa205f629ad44e98111cc617f94c1381409ea7a4d42e0b79b98fc2f1c145d9b3b39b7e541757ddfeff0c3bd4c24dff9c046b1ddd5dd36a980f1ecbe86e492d97821a8ab0f825fbe302254fc57d4835ad2613c3f5ca2530cbdb55d826b747e0bf7998bd8f5e3fb8f210e12f81484b4f98661d38e0f2781888bbddd591e543e89be4930e47e09150ac1cc4ffeb3f4581beb7c4de648accb63484fadc95cf4080bcf3513051d2058cc9b084c647c7473ebfff");
            result.OperatingItems.ShouldBe("9e264cec98c14636bb16df10792f33ec3abd1273c7aa41b0879de3713bfd51694f9b3630f16641239bbeb97129a5cf300ef797faa1b143dd8428f23616bcae940c5eadc063284d75bd5f9d3dbd59c29c750b879340b54a05be9f31b0279fb4d7de9031cf12ff45ea95fd2530b3c507f7c968c5808f14413bb66da1a2235dfabd8d338861d13643cabf69cffc1c2f5095419882202c8d45feb93f39472a6e4a0b66c6a4071285432c9422032edf19adb4bd3bb33462b44b49acc269e14081edc22ccd64e4ef0947ee8b9faea8d1684fc2cc13b04fda554ab8a0257bcd345a0225919c6dc222fc4e3ead78806c0be89f4c9a35bb9a20fc417ca4a8");
            result.WelfareSystem.ShouldBe("5821da3876354d8ba90b9ca8e2bb9285e32526c05f6e4703ad676ce7e08934cab6182732dab3412e9b8c0ddd02b7d74e09ae5ca675d94252be82621cb27d0a56a39816174f6b48a7b171f7262178124d241c3f0cd17e4826ab0e79232cb14472d88e7774f6f54f9a8357995c9e976f2aa000c66d648447fe87cef9ed7d1a4278c6390779c845463a979ae93c7825fbfeda6f7426722a437b9f2a25067f61bd8ff7b9507145a34c0187d430176499afaa377ebeea4cdc46efb23b2238a3d27d0a62e26b0fa2924136a262c3fa4b289325d015de75e732459c8e639be0928a5901ee14279280274a76b2cfcaea154c50cc351537c78bc04d8599c5");
            result.Matching.ShouldBe(true);
            result.ContractPass.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyMainUpdateDto()
            {
                Name = "d344f1a64c974a75b4e138153672babd1280c51ded3e4324a0",
                Compilation = "4ee4f6e01aea4a058d04c0635c137a4dd6e40c34a382434991",
                OfficePhone = "7c154543fe4f4faf9a50279929bc86e0a9fa522e06624655b6",
                FaxPhone = "c3d58d34fddd4af987c7011444e44a5e3030b56f1a1a4f1686",
                Address = "f04c7535ac28496488e29a889081ac7009072242912749e597",
                Principal = "35b446320dfa4399aa851aa340d25d33bd71bb4807404517a4",
                AllowSearch = true,
                ExtendedInformation = "dec29b90574b4bb38016939e3794b04aa8ac8e8d8265458b920985609fef62d6615327bc487a4c55a6436dd010881f62d280e60bf9d247e78e81ab74b727aa74547b2d5ac22048a99299b039938e96416958a37ccda24a8382f0e46f3b32cf8abee9dd56d07446c6951e20084465cd7e11bb76df408a45cb9b11e1485f93998c1d4d97b986684c83b5b752a18df399984b6ef440f36145228ae8bb15757aaea651c359b399cd45ce9bc546af2932e7ad9e89ef4090234c4eb0cffc3e787a220dedb10b596bcc47c29bf2a2b4908a494bd2fb786dce6f4f5a9acde595536be213cf2b47a77bae4c86b6a2b3886428e0654b32ff033a1948319c45",
                DateA = new DateTime(2016, 2, 26),
                DateD = new DateTime(2004, 4, 2),
                Note = "e62d68ae3873438698dbc016dbc6e6d35236f0de27f1403a8a529a7ba1d782debd400d47b0ad47c682ef66bac4fcf8e181d4853a622a4d74bcafb3328e58cc98a303a39cddf848b48937b6af3fdac382794282254bef459281c940789515ecd0a2e67f1804c14b519b03d49fab851f8a342b86d4642d40fc96440df56983b9b3261d713db74441d58ad5b3eef4e817b1049d885c79114a9990ce10f5e8289e715ee70d66ef61455f97082c95b8373f04729870c3316942feb37871c47c2a4fb6a4684a5305b143299f7f13f71a06ab8142ed6b2ecd71435ca5ae32c3dd1ce5c4782f136b01c64362b0b0ebf315bcbfc106be8dab9e1d43798e77",
                Sort = 1568456001,
                Status = "80e6b5b4bc4e4661923ab3f7ea4ae6ef97cc822e8f42479087",
                IndustryCategory = "575674b3c8504d03a8538f840d99240554f0570979024eacac4de7d729cda51a86bd901d0d5b40d2a34dbf93e35876760759018879744e8fa178fa745f8adb581202941f51b145fba8d2beceecf8114b2e0964ec0a85465e9660a1b77c0097f26bfb8a808afc47d8909191af764f5881ec66f865761f4e789c9b0598cced9a819c4cd10a3ec248028b674e5aa5842205fe466a834c9d487690d033d12b697caf0876868df25843978ec3a0ed3ad4e7424fc472d6219b46a39d6fdddc70ab0b6a74eee551c02b450ab20b9857a6cffe83828e6e754a6b44ffaf34814a678152649d6c2653731148fda896a53f8570e4da4623a0cbaeaf4ba1842a",
                CompanyUrl = "7162f709b25d457d9c64491990a24872279c0c3101a64606b4f3941d351492ff1be865863d5a4c909ee992f52e03d304e92ff7b5d6184c77bd36ab8f363d28a3649ba01522b14e1fab9c1bffec6022ff56853d9c72f048789b84b3eb5d21cb9b9d6d1b05",
                CapitalAmount = 436125154,
                HideCapitalAmount = true,
                CompanyScaleCode = "4a2aadcb1d6745058a62096791a0c51d19fd12078c714afdba",
                HidePrincipal = true,
                CompanyUserId = Guid.Parse("89f38851-c7a9-45c9-9133-a6729ccc7533"),
                CompanyProfile = "24338bc823494e0db3be59cc80587ca28e1ff91cddb649d096b08f4078b8f8462a470d39fc3641ceaf5c09bd2bbc4c23b284547a3480408db3b55a599589d1920b586c82f5254ce0a3bbb9008efc781745020aa2842441eb8b541b59c831bfeade2d6051ca71499e95f1dda5f0702b26a4f13400d34e4540af0220c640437bba9646e5f00c634633bf27028735d17d2b07f072fc16ea42c9bc3b9f457a68080e04498586135d4894b20834fa071ad50879d280b25e5f4b8fb8e152a9d89ecfe6cd74fb5afbf644018d0943fc0fe4663c23327811bc964bff9cb067ca0f2712522ebde901fe394436b92d8d4b915177802d4939bec2b648ebbaf3",
                BusinessPhilosophy = "20061ad0a52d468994fc5469b1a69f1b627070aeae0947129b903686da1a901f195951b8659546fb8511e37b86b70810d527597a791045e6a9371b2f79320a7cb8aecc6b5f9e4df2b69b6a5cfcac9288c873fdb15030428189503cddb61a3d483003f4a2f38c42cd945521940c0224c1254aa51964ba47359ee8274ccfb590ce9090634b2f8942698980c899a00cb97c8337c1c7b4784542a5e10ab4cdc6847047e574f4668a44b3af6ca421743ffe4a6f9946574ee24592b177cb41fc6b95db73075d7c6fa94d07af70c8dcdac586f78e7287879d3543088892f723b69f7503fe8f997c43e24ff2b8ba0fd3de9bedc27c70f0fd9d534919bddd",
                OperatingItems = "c6ec95e58ba0420ca57c8038ed591609305c31fc121e4ca4912e62917111b9f4367f3fd671784b25ab1ba943286db3d5940ad97e379e48b197675d7127dec607689b50bf2dab4f69ba10193bb10c66438e17fe421479447aa8b58f2e852b89a4b579d68d7ef048018ca586f9dc93f567e23b2679086e4697b1a2f59af4f70d0a16de89b37b3744a9aad24e156c3093682bf9c102ea8042338e37e62223224ee0309fb7f7a6224f58bd5de6349af42c202fe324b806754867b5dfe1ad5a28c1572c556ce86f944a75ab49b0c314cde8516d792012fabf478495f4e6255d1c5ddd64dbd47b54e3406fb3af882b452f7a9b5d6ab44946be419a9dab",
                WelfareSystem = "2095f1fce41f44b8b3bd24398df6b594db6c4655c2934302ab3b8d1b4485143740945d91fd8b4276b8479e24678d3d32f9dfeaee0e4b448b8a086b9f26b67f420608da05cbdf43ffb922b3396f5ceef6b1302d40b576400ca4652f8183004cbe4bc61f66d630495b935aeb187c83106f84366965c7594d0ba2dd4eb717adb874813f55e8efdb47648524d284c439cac525c47b3d2402492c95e7a8c4bd0b01c445fb03370c654cbb8965053c778fae1b2ca0015a392e43d885e51198229acdee7b281c96d9f1457ca9d74ea256628b9147cad2194a8640a3899173446849087e7b74c37ca1d8469c8af678dd69c7b010030b358cf4184ce5b47a",
                Matching = true,
                ContractPass = true
            };

            // Act
            var serviceResult = await _companyMainsAppService.UpdateAsync(Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f"), input);

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("d344f1a64c974a75b4e138153672babd1280c51ded3e4324a0");
            result.Compilation.ShouldBe("4ee4f6e01aea4a058d04c0635c137a4dd6e40c34a382434991");
            result.OfficePhone.ShouldBe("7c154543fe4f4faf9a50279929bc86e0a9fa522e06624655b6");
            result.FaxPhone.ShouldBe("c3d58d34fddd4af987c7011444e44a5e3030b56f1a1a4f1686");
            result.Address.ShouldBe("f04c7535ac28496488e29a889081ac7009072242912749e597");
            result.Principal.ShouldBe("35b446320dfa4399aa851aa340d25d33bd71bb4807404517a4");
            result.AllowSearch.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("dec29b90574b4bb38016939e3794b04aa8ac8e8d8265458b920985609fef62d6615327bc487a4c55a6436dd010881f62d280e60bf9d247e78e81ab74b727aa74547b2d5ac22048a99299b039938e96416958a37ccda24a8382f0e46f3b32cf8abee9dd56d07446c6951e20084465cd7e11bb76df408a45cb9b11e1485f93998c1d4d97b986684c83b5b752a18df399984b6ef440f36145228ae8bb15757aaea651c359b399cd45ce9bc546af2932e7ad9e89ef4090234c4eb0cffc3e787a220dedb10b596bcc47c29bf2a2b4908a494bd2fb786dce6f4f5a9acde595536be213cf2b47a77bae4c86b6a2b3886428e0654b32ff033a1948319c45");
            result.DateA.ShouldBe(new DateTime(2016, 2, 26));
            result.DateD.ShouldBe(new DateTime(2004, 4, 2));
            result.Note.ShouldBe("e62d68ae3873438698dbc016dbc6e6d35236f0de27f1403a8a529a7ba1d782debd400d47b0ad47c682ef66bac4fcf8e181d4853a622a4d74bcafb3328e58cc98a303a39cddf848b48937b6af3fdac382794282254bef459281c940789515ecd0a2e67f1804c14b519b03d49fab851f8a342b86d4642d40fc96440df56983b9b3261d713db74441d58ad5b3eef4e817b1049d885c79114a9990ce10f5e8289e715ee70d66ef61455f97082c95b8373f04729870c3316942feb37871c47c2a4fb6a4684a5305b143299f7f13f71a06ab8142ed6b2ecd71435ca5ae32c3dd1ce5c4782f136b01c64362b0b0ebf315bcbfc106be8dab9e1d43798e77");
            result.Sort.ShouldBe(1568456001);
            result.Status.ShouldBe("80e6b5b4bc4e4661923ab3f7ea4ae6ef97cc822e8f42479087");
            result.IndustryCategory.ShouldBe("575674b3c8504d03a8538f840d99240554f0570979024eacac4de7d729cda51a86bd901d0d5b40d2a34dbf93e35876760759018879744e8fa178fa745f8adb581202941f51b145fba8d2beceecf8114b2e0964ec0a85465e9660a1b77c0097f26bfb8a808afc47d8909191af764f5881ec66f865761f4e789c9b0598cced9a819c4cd10a3ec248028b674e5aa5842205fe466a834c9d487690d033d12b697caf0876868df25843978ec3a0ed3ad4e7424fc472d6219b46a39d6fdddc70ab0b6a74eee551c02b450ab20b9857a6cffe83828e6e754a6b44ffaf34814a678152649d6c2653731148fda896a53f8570e4da4623a0cbaeaf4ba1842a");
            result.CompanyUrl.ShouldBe("7162f709b25d457d9c64491990a24872279c0c3101a64606b4f3941d351492ff1be865863d5a4c909ee992f52e03d304e92ff7b5d6184c77bd36ab8f363d28a3649ba01522b14e1fab9c1bffec6022ff56853d9c72f048789b84b3eb5d21cb9b9d6d1b05");
            result.CapitalAmount.ShouldBe(436125154);
            result.HideCapitalAmount.ShouldBe(true);
            result.CompanyScaleCode.ShouldBe("4a2aadcb1d6745058a62096791a0c51d19fd12078c714afdba");
            result.HidePrincipal.ShouldBe(true);
            result.CompanyUserId.ShouldBe(Guid.Parse("89f38851-c7a9-45c9-9133-a6729ccc7533"));
            result.CompanyProfile.ShouldBe("24338bc823494e0db3be59cc80587ca28e1ff91cddb649d096b08f4078b8f8462a470d39fc3641ceaf5c09bd2bbc4c23b284547a3480408db3b55a599589d1920b586c82f5254ce0a3bbb9008efc781745020aa2842441eb8b541b59c831bfeade2d6051ca71499e95f1dda5f0702b26a4f13400d34e4540af0220c640437bba9646e5f00c634633bf27028735d17d2b07f072fc16ea42c9bc3b9f457a68080e04498586135d4894b20834fa071ad50879d280b25e5f4b8fb8e152a9d89ecfe6cd74fb5afbf644018d0943fc0fe4663c23327811bc964bff9cb067ca0f2712522ebde901fe394436b92d8d4b915177802d4939bec2b648ebbaf3");
            result.BusinessPhilosophy.ShouldBe("20061ad0a52d468994fc5469b1a69f1b627070aeae0947129b903686da1a901f195951b8659546fb8511e37b86b70810d527597a791045e6a9371b2f79320a7cb8aecc6b5f9e4df2b69b6a5cfcac9288c873fdb15030428189503cddb61a3d483003f4a2f38c42cd945521940c0224c1254aa51964ba47359ee8274ccfb590ce9090634b2f8942698980c899a00cb97c8337c1c7b4784542a5e10ab4cdc6847047e574f4668a44b3af6ca421743ffe4a6f9946574ee24592b177cb41fc6b95db73075d7c6fa94d07af70c8dcdac586f78e7287879d3543088892f723b69f7503fe8f997c43e24ff2b8ba0fd3de9bedc27c70f0fd9d534919bddd");
            result.OperatingItems.ShouldBe("c6ec95e58ba0420ca57c8038ed591609305c31fc121e4ca4912e62917111b9f4367f3fd671784b25ab1ba943286db3d5940ad97e379e48b197675d7127dec607689b50bf2dab4f69ba10193bb10c66438e17fe421479447aa8b58f2e852b89a4b579d68d7ef048018ca586f9dc93f567e23b2679086e4697b1a2f59af4f70d0a16de89b37b3744a9aad24e156c3093682bf9c102ea8042338e37e62223224ee0309fb7f7a6224f58bd5de6349af42c202fe324b806754867b5dfe1ad5a28c1572c556ce86f944a75ab49b0c314cde8516d792012fabf478495f4e6255d1c5ddd64dbd47b54e3406fb3af882b452f7a9b5d6ab44946be419a9dab");
            result.WelfareSystem.ShouldBe("2095f1fce41f44b8b3bd24398df6b594db6c4655c2934302ab3b8d1b4485143740945d91fd8b4276b8479e24678d3d32f9dfeaee0e4b448b8a086b9f26b67f420608da05cbdf43ffb922b3396f5ceef6b1302d40b576400ca4652f8183004cbe4bc61f66d630495b935aeb187c83106f84366965c7594d0ba2dd4eb717adb874813f55e8efdb47648524d284c439cac525c47b3d2402492c95e7a8c4bd0b01c445fb03370c654cbb8965053c778fae1b2ca0015a392e43d885e51198229acdee7b281c96d9f1457ca9d74ea256628b9147cad2194a8640a3899173446849087e7b74c37ca1d8469c8af678dd69c7b010030b358cf4184ce5b47a");
            result.Matching.ShouldBe(true);
            result.ContractPass.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyMainsAppService.DeleteAsync(Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f"));

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == Guid.Parse("2221319d-c4fb-4a17-a2cd-f77b446cef1f"));

            result.ShouldBeNull();
        }
    }
}