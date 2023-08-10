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
            result.Items.Any(x => x.Id == Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("37739f95-ef39-4a4f-88fd-54e814cbf743")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyMainsAppService.GetAsync(Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyMainCreateDto
            {
                Name = "eb837f05c17340cbb914a40e7534848ef1f555039fa245308f",
                Compilation = "addc01374b3a43ac94f0f9ff16536d6dfb387dac9c414bdcb3",
                OfficePhone = "b2eca807508e47a2b97a44ac2b2e952d28bcc4580e484994a4",
                FaxPhone = "ac49b9a1399f48b89d461b41fe5aa5c08de4714b6b854351a3",
                Address = "d5033bf940764e00b1b053169051224be696caaa5c6f462982",
                Principal = "18cb6ae7df70473eb005cf49eae84b03e022e6959cf7487d9a",
                AllowSearch = true,
                ExtendedInformation = "7a487e78a18c4f1ebbaa6cdbc25e8791bf1b44375ea74f6ca3050331af685178174fa02728b74e76891a5ea36e82c231d4d0582c594d42598af1f4eb90f2b3c32ee33724f077482686a4af22786893a4a1b7015b9d134003a28c2ccd48f6ac1512c31d78c10147f7881f6df749469f2e456b2c74cc0b4d24852c7fa46f02054748026d7e30ce434198820418bef5de5c46b194a7dce14b938ca00313ab66935623a4eab25c4e4bed9e79d33f978f58ced8288a698b6e40bdabfce2aeacd77fa37bb52926b01f4e81ac7e83d6daf33379641d4d10c20540f6bafc0eb2db5f1a8e3b98883c99db4976afcd2df128d0f57e4805d9b9b2e949d39cdd",
                DateA = new DateTime(2010, 1, 5),
                DateD = new DateTime(2022, 9, 11),
                Note = "186b0bc4fe264e599987acf3bfd942a7d4bae51e3414439f979e70ee7f783fd29625da37387745c3b04c69fc0d0f680a614c30035dc54372ac460aa75b55569c6c74815aff694904b41b793b9e91a3583f307f4b5075485bb4aa56f9647bf8748128a206744a4fb79cc2de7f67eb4faacf739b2e99e143b99fdfe4608b05489659e4f4fc83674a0f972374ce4d0aa4247f037e17e85547fd88dc7f7886c0db88f42594f4bd9d40e3b82b4ae258f8f2157c4a731279294c9e9e3a6eb36f255e0ccfed775da3ab4560b6e09314745da4733b118f48a83241e18671c25a222edfd1638768eeb60f4c4193aa98eb6b7b31aa24392c7ae7d84cb1b5ba",
                Sort = 2146045210,
                Status = "e18c0ae19a194cf0883b098fbfbde70d77bf77dab4894c2987",
                IndustryCategory = "dd75745f14d74f18b5263a24b13c9e698b77af1032234decbb5f65dadce9be025ee8d01732704a8280bc14714087ab50b7416fa4fda54c8bad70ad51458e95a3655f4c46ed49421faee98422aa33adfe39511bccb22e4d0fbe31032d45977c4185d52a6102ae46de8193da6fd64ada91d13c11d12f23469fba3ea215e967dc02289360bf7b744a0e846b8d9ddd7441e3574c9f3ceed942728d9b43ae8278d0ae10c161424eba4848916ecc3b66a1b9716b72fb327cd2451585d8a1c075a469443e17713d4a394c289a2f29c4f40c63114dfcd512349748e19bd0794fe5872d7dc8cead098abc4599ad48e5947c7e418ebb28407331d84f90a8ae",
                CompanyUrl = "50af6ccd5fb34cc7b16a6d31f9bf4a9c0d3959f1cd8a47539649a88c13f4d5f471e2eda666c84b439af9bb414fa08d9d7342790e3e864267a9cc82d87f27b464a383fe15ab37427485f5327833897aaa0b6dffdcabac4622b8a20f23acba8ee87bb52cde",
                CapitalAmount = 1166921870,
                HideCapitalAmount = true,
                CompanyScaleCode = "e477212de4c24ffa857612f67a92ed945a60723d2a4f4a0bbf",
                HidePrincipal = true,
                CompanyUserId = Guid.Parse("33130b81-4b37-4a61-ad90-3295a3f290a0"),
                CompanyProfile = "b30cc18004a543b280bd47be66965ebb44915f4812a7484d9bd9747ff4b31ebd7459b14b0a114979baca6a0850791ca2799a47135bf140118a9434019291c7d240aa483656264dbaab0d8285cd6fef387351a1a136f746248784509a753794553bfe24da26214e60b99f30c2d77c78f3a4ffa97ab53641e0898a72b96deb548b6c5f3d2ab695415390660b8426a633501d4849a49a354ed1855449776f0c09295a45c6869e4f499eb6c000183daa5c7817daddc68e2d40cd8120f92e8ab0e834d23952e5badf48a9817bc483e9d831a6e79c98a9c0684d61b41ba4c76b0da98a3a695b22a98b4f79bcb16230ce75d569e5b76ff9763444259787",
                BusinessPhilosophy = "87f1f55214394d5b95782783ef84d8c23078ca102d1d40e8b16ce17d9aca6bbaca5f8f5148d84b08b62e91ad96e19f988ffa3a3ae5e24fba831ebbbec9e197ddb0d4e35edf324318bf6c7dd9a54b3a617a6a63c10d094626884bd20481221f7b58379a55d3d34ec596f4fbb4ecdeb46a1aa0e4e9e99a436089d32af90c431232b1080ad605914593987cd8dbd666983a9d615680498342f0948d9d0e5962bc0a2be0d32ce98b4a2fb8cb18ef6db9bbf1668b73f33a6644e1a5a4756f6f4de94cd61e795edd104da5bccced5df76701382e754eed52214a07afe75cf15ffa55eb666435fad9aa4c99ab4eb9cbb9dfce9357368ba15c4b42f1aa2f",
                OperatingItems = "96716ef8f99645f6a016d5a791cf04685b12e7cfd0764d57a8c417827dae6547e643eff9f38e4fa5b0f584167a8089231c3c2ee9caf0415591cba40de568d20c7bcc59754f544dcabe26cd7411314561b9bfe67093304de4a72585bd995e53a1bc8ea6bcc4484acdb230318b5dd7971dd2fb9ce7397448b7a1609bae6e042c9296759d3d3ccb4018b0f2e447cb454b1b23258e014d9d4b77a37b3873f525c9cc1a51d1a0cc0a4579a1c2aeb4f66af40eb0fc700c22444c6e910406abb4e3222794f3a081582343abae2ef669ca186633b08ed82b897d4a55b0ae8062f446bac69d54ddf3c6f64966b3485c1b22d00daa1a3bfe8f1e7940e2841d",
                WelfareSystem = "858079e920584b17a8581baec2aede92331c47a8b69a4defbf6f7dd73aece74e871f2066eecc487895585cd3e471aa45c8c771391c05426dbc56a48a2612453a011ff5fc8c7748fb949c0b1b5647ee734bcabda7f2c54436bae1eca996de95d5b2016436d35a4053a895adcfd24e196f016c3c2503e446d7857847f7628a5989b8dd8be3733a43f4a084d0f94d2fa654dad7cf4e02364d4e872243f5580efd85ab84fe27dfdb402288dc29a94b4519913b0a2f1c1c71443da99dae392a34d01a4068817a7ccd40bfb0a81606130648620fa1c79e2c894a819ac5f50945b8f353170b5ebd662146da8bf28046a02ff695151376d6490449009f26",
                Matching = true,
                ContractPass = true
            };

            // Act
            var serviceResult = await _companyMainsAppService.CreateAsync(input);

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("eb837f05c17340cbb914a40e7534848ef1f555039fa245308f");
            result.Compilation.ShouldBe("addc01374b3a43ac94f0f9ff16536d6dfb387dac9c414bdcb3");
            result.OfficePhone.ShouldBe("b2eca807508e47a2b97a44ac2b2e952d28bcc4580e484994a4");
            result.FaxPhone.ShouldBe("ac49b9a1399f48b89d461b41fe5aa5c08de4714b6b854351a3");
            result.Address.ShouldBe("d5033bf940764e00b1b053169051224be696caaa5c6f462982");
            result.Principal.ShouldBe("18cb6ae7df70473eb005cf49eae84b03e022e6959cf7487d9a");
            result.AllowSearch.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("7a487e78a18c4f1ebbaa6cdbc25e8791bf1b44375ea74f6ca3050331af685178174fa02728b74e76891a5ea36e82c231d4d0582c594d42598af1f4eb90f2b3c32ee33724f077482686a4af22786893a4a1b7015b9d134003a28c2ccd48f6ac1512c31d78c10147f7881f6df749469f2e456b2c74cc0b4d24852c7fa46f02054748026d7e30ce434198820418bef5de5c46b194a7dce14b938ca00313ab66935623a4eab25c4e4bed9e79d33f978f58ced8288a698b6e40bdabfce2aeacd77fa37bb52926b01f4e81ac7e83d6daf33379641d4d10c20540f6bafc0eb2db5f1a8e3b98883c99db4976afcd2df128d0f57e4805d9b9b2e949d39cdd");
            result.DateA.ShouldBe(new DateTime(2010, 1, 5));
            result.DateD.ShouldBe(new DateTime(2022, 9, 11));
            result.Note.ShouldBe("186b0bc4fe264e599987acf3bfd942a7d4bae51e3414439f979e70ee7f783fd29625da37387745c3b04c69fc0d0f680a614c30035dc54372ac460aa75b55569c6c74815aff694904b41b793b9e91a3583f307f4b5075485bb4aa56f9647bf8748128a206744a4fb79cc2de7f67eb4faacf739b2e99e143b99fdfe4608b05489659e4f4fc83674a0f972374ce4d0aa4247f037e17e85547fd88dc7f7886c0db88f42594f4bd9d40e3b82b4ae258f8f2157c4a731279294c9e9e3a6eb36f255e0ccfed775da3ab4560b6e09314745da4733b118f48a83241e18671c25a222edfd1638768eeb60f4c4193aa98eb6b7b31aa24392c7ae7d84cb1b5ba");
            result.Sort.ShouldBe(2146045210);
            result.Status.ShouldBe("e18c0ae19a194cf0883b098fbfbde70d77bf77dab4894c2987");
            result.IndustryCategory.ShouldBe("dd75745f14d74f18b5263a24b13c9e698b77af1032234decbb5f65dadce9be025ee8d01732704a8280bc14714087ab50b7416fa4fda54c8bad70ad51458e95a3655f4c46ed49421faee98422aa33adfe39511bccb22e4d0fbe31032d45977c4185d52a6102ae46de8193da6fd64ada91d13c11d12f23469fba3ea215e967dc02289360bf7b744a0e846b8d9ddd7441e3574c9f3ceed942728d9b43ae8278d0ae10c161424eba4848916ecc3b66a1b9716b72fb327cd2451585d8a1c075a469443e17713d4a394c289a2f29c4f40c63114dfcd512349748e19bd0794fe5872d7dc8cead098abc4599ad48e5947c7e418ebb28407331d84f90a8ae");
            result.CompanyUrl.ShouldBe("50af6ccd5fb34cc7b16a6d31f9bf4a9c0d3959f1cd8a47539649a88c13f4d5f471e2eda666c84b439af9bb414fa08d9d7342790e3e864267a9cc82d87f27b464a383fe15ab37427485f5327833897aaa0b6dffdcabac4622b8a20f23acba8ee87bb52cde");
            result.CapitalAmount.ShouldBe(1166921870);
            result.HideCapitalAmount.ShouldBe(true);
            result.CompanyScaleCode.ShouldBe("e477212de4c24ffa857612f67a92ed945a60723d2a4f4a0bbf");
            result.HidePrincipal.ShouldBe(true);
            result.CompanyUserId.ShouldBe(Guid.Parse("33130b81-4b37-4a61-ad90-3295a3f290a0"));
            result.CompanyProfile.ShouldBe("b30cc18004a543b280bd47be66965ebb44915f4812a7484d9bd9747ff4b31ebd7459b14b0a114979baca6a0850791ca2799a47135bf140118a9434019291c7d240aa483656264dbaab0d8285cd6fef387351a1a136f746248784509a753794553bfe24da26214e60b99f30c2d77c78f3a4ffa97ab53641e0898a72b96deb548b6c5f3d2ab695415390660b8426a633501d4849a49a354ed1855449776f0c09295a45c6869e4f499eb6c000183daa5c7817daddc68e2d40cd8120f92e8ab0e834d23952e5badf48a9817bc483e9d831a6e79c98a9c0684d61b41ba4c76b0da98a3a695b22a98b4f79bcb16230ce75d569e5b76ff9763444259787");
            result.BusinessPhilosophy.ShouldBe("87f1f55214394d5b95782783ef84d8c23078ca102d1d40e8b16ce17d9aca6bbaca5f8f5148d84b08b62e91ad96e19f988ffa3a3ae5e24fba831ebbbec9e197ddb0d4e35edf324318bf6c7dd9a54b3a617a6a63c10d094626884bd20481221f7b58379a55d3d34ec596f4fbb4ecdeb46a1aa0e4e9e99a436089d32af90c431232b1080ad605914593987cd8dbd666983a9d615680498342f0948d9d0e5962bc0a2be0d32ce98b4a2fb8cb18ef6db9bbf1668b73f33a6644e1a5a4756f6f4de94cd61e795edd104da5bccced5df76701382e754eed52214a07afe75cf15ffa55eb666435fad9aa4c99ab4eb9cbb9dfce9357368ba15c4b42f1aa2f");
            result.OperatingItems.ShouldBe("96716ef8f99645f6a016d5a791cf04685b12e7cfd0764d57a8c417827dae6547e643eff9f38e4fa5b0f584167a8089231c3c2ee9caf0415591cba40de568d20c7bcc59754f544dcabe26cd7411314561b9bfe67093304de4a72585bd995e53a1bc8ea6bcc4484acdb230318b5dd7971dd2fb9ce7397448b7a1609bae6e042c9296759d3d3ccb4018b0f2e447cb454b1b23258e014d9d4b77a37b3873f525c9cc1a51d1a0cc0a4579a1c2aeb4f66af40eb0fc700c22444c6e910406abb4e3222794f3a081582343abae2ef669ca186633b08ed82b897d4a55b0ae8062f446bac69d54ddf3c6f64966b3485c1b22d00daa1a3bfe8f1e7940e2841d");
            result.WelfareSystem.ShouldBe("858079e920584b17a8581baec2aede92331c47a8b69a4defbf6f7dd73aece74e871f2066eecc487895585cd3e471aa45c8c771391c05426dbc56a48a2612453a011ff5fc8c7748fb949c0b1b5647ee734bcabda7f2c54436bae1eca996de95d5b2016436d35a4053a895adcfd24e196f016c3c2503e446d7857847f7628a5989b8dd8be3733a43f4a084d0f94d2fa654dad7cf4e02364d4e872243f5580efd85ab84fe27dfdb402288dc29a94b4519913b0a2f1c1c71443da99dae392a34d01a4068817a7ccd40bfb0a81606130648620fa1c79e2c894a819ac5f50945b8f353170b5ebd662146da8bf28046a02ff695151376d6490449009f26");
            result.Matching.ShouldBe(true);
            result.ContractPass.ShouldBe(true);
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyMainUpdateDto()
            {
                Name = "4f23779fff154e5286355e90204f737d65ad67b41a9f4c0b97",
                Compilation = "d2b17899a38e4f9585dfd8f1bf61b783c9bacfe9f18944619f",
                OfficePhone = "423916d573f14bfe8f1022fcff924556881f26de9e7e412a9c",
                FaxPhone = "b4f55ece09e6481281cdd766ba73880de3ca47b114fd47889c",
                Address = "311952337a5b4990b3dae0493fe99174cd6bc37827e747d3a1",
                Principal = "e5d429cb27db49b28e844ed88d093065ff8abb3649834ccc94",
                AllowSearch = true,
                ExtendedInformation = "68ee986a30214982b53b9272cfa2f4accdca3acd196e43578133ef2ebfd69cae64466535e17d40cba3fd2330f49cbd2edd6d330e38d6455d87288853e6556503ab2f8c6aadc54e2390731526253dac07f4a48e2cc5dd4ebaad407b59fc8ad2c6ca8309a6175c460684c88080e6be15225804aff0822e4a45bbfba432d4b57b6cd4a549b0f5884ec8a35e052d82043e6c9aa2dd4f78f340d89dfff27b04173c0ea2c105cfa9a142e9b811580547d499ed884084684509483fa8509992594be6949a1c3c3944e24004bde780eaf5acc5ee04d7d6678edc4de987332daa5663352cf4e641c3b4054a65a6f3658cc0947859a67ac63b3fbc4655be1c",
                DateA = new DateTime(2018, 6, 4),
                DateD = new DateTime(2011, 4, 3),
                Note = "7d0369cade51440f951a083f76e39c7446a9261630214d63a02aeb59995fabc3ea47aa24ff334159a9411be70c3d6d0469339c64dee242249e9368756aa3729e15a6b3c13e3544cabc48588e37cce37b5feb8a48c2aa43ea93b1bf68bbde4fbf515fab9110044ce9a1e56fcb8e59f41389ef002da72947db861ef4398eefd9d8080c14c530924cac88d22491e40bb41d0de599ce5fa34b93aee5a7fc78a6d070a2152764e5b34ee9abcd8691301441d2fe4d9da79be649deb90d0b21e4c3318620334a6268fe4f389e1e5a62ce5240ac027564eb308841de8a4ac7044f479bf96202890fbc134c2581a6d5a45017305f6404fb59364d4b47a66b",
                Sort = 1862618799,
                Status = "04d8535115984a3db1c181277d0f84c244590898441e4d45af",
                IndustryCategory = "342c08a75f16490ead5517b2dc462cf73126fb70ec9b4ee98a2331fed8c402c79913be6712c346b8842f0d123850ac8f4013ad1bf84a48a8af80eba91a0dfcde5195f1fbe3c34ae7b2dc39384325b9486f15e4fb81794bada7b1b9bf57d92b938ce1a637e13c49d394bdb2f4e4e28bd83b6ade7bc8d84e13a28c1f4d0dc9551a312b892a1a414c129ca754e2a2fb2f985810388df69249eb97c9ddaee6291e444be6ae16037447ce8c4338adee53afd2cfd9bc4061324b48ab957f4cd626ab9c8c4b7a2834424bfb8bbd1f0b58513bdd8fb603fe88b943a998fb858a7e4836af0f1f0aa7fcb0412aa6cdf67860c37d0f884cd032314a46959094",
                CompanyUrl = "807707bdca7c402cacd25005dd7957d875405a1d70784a8680c731e7b065cb6e679ec91a952247839ab3aa9b17edfec5b0d32539b11d490cbfd5b7d2296bb001f41987f9a5a9459bab5a7c3e9c52da109f36972aad6e45b6ba4100a7e85f4d1976d84516",
                CapitalAmount = 3663958,
                HideCapitalAmount = true,
                CompanyScaleCode = "1b77994c863f438683a30bf4a4fcc418426b829cd15842bca7",
                HidePrincipal = true,
                CompanyUserId = Guid.Parse("78aa87de-acb8-481d-89b4-be0b47a1d060"),
                CompanyProfile = "85604de280b04e71b84eff93a5377065eb6164f250ff455d9e41f0d152f3741e1c29185d45824ce39e46be83734b6e4f65e0a4e1d5994e2581e1bf4da6fa801010f5d9f3d54a4cffa087df57efa236a959d83e309a7b4c7daae1e7094d9691cc9090d63ff5d0493d87478d40e94a56569fbcaf1b48a94e3e99c6cccd7deaa0345eab7359c06f4f0e8a06419365c0a09691ac3e626ffd41598e1c9b6c4c324095ba432f30578c4d87b877f4b90b454f2252b5c69c826a45b0bd872f25ed9147747bdb0965e871401b81c8f5e622c6d69a70f0b9b2b33b4bb7a8209297e9f84a7f63fc5705fa924055b55deabe1b5f1f4dd012e081d2374094afd3",
                BusinessPhilosophy = "74f2a0ba6bfa4f4e8b23f313f1e62dcaf122e85bcd1d4545871254e1ade2ff6bbd0708f53ce84c5ab67dd5b33d3ddaa339e4606e6b9e4f11a864e416ba962a95cd0818ec1b694c98bebce406d6a370bea3eea05e3c2a4874b1a2fbc03328fce77caece38d95149c7b34f949fc33472c6d08cb5a6a3774337834468fba0f83bb692e6f7e47ce44cdeb113dac25c575700cf299e18af37447abaf1f7732986b47c2319878de9a2470b8e427388ef3541c0c50f90ef93ca43a2846ae1242ce1c4fee48defc103a2482ea9e14bb8d80a20cf5a968158cd77469fb93dc99d62b626a111482b9d69cf49d5aac76ca26e2e6da477bf8c6fcb71416bb402",
                OperatingItems = "5212d380a8a94696b031f2395ef7ac3b4bf9bf41d7a14d238f6e57e803471262be4d6c36fc3e4049bd5c3bd03c34f3434cef53dc2eba4dbe9cc3d9cc70ca3a13f820dd9131284ba39000486503e5aea772c40fd6e03644c687ba08b4a17718f1fe4c7cdbb41b4cdfa92abe8691b4c098acd14d557f9b43efb1831e2db7a536b041a300a400d44195870204c928266dd274fb35e5306840e4bfe3332664351fdb8084dc4d79164519bec8359e1f751ea2e519a087d1a9411789b51628f86e4681fb5261bee2e540ee9f40166cd7958b30a719d3b6863e45b8b7bc5b123a7514d7935c3870ead64eca85ab27de9c1f0cdaeb0a242c17c04c419b8b",
                WelfareSystem = "b474bf586d54436abed874609cfa6fddc61cdf107731444691d381d676bbd4d5c14a621727e242cf95ad64c652dbe4604c1e6d7e480941dfb68d95b598ac333605781c40a1d341a9954a344c2834a114c626cae23c1a4d3f844956f55eaa2aca5f67e4a5e0ef4667add93d4e63f12e8fbc84f29fa930478382005cc04ecf40429764af8821f74a92a6621466416b2fde64fe2d3c4ca346c89dee0cb7ed76030c93acd11147af4d9887ec8bcd1037eecd7715e9c366c84f8fbf8807aabd8c4b0d82c3ec8024274d55828f3ae72c354017f0076e82724b4c70a41ae8977e56a35158fd30976f364923a558b38a33f84ab9f45868488cee4bbbb46a",
                Matching = true,
                ContractPass = true
            };

            // Act
            var serviceResult = await _companyMainsAppService.UpdateAsync(Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f"), input);

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("4f23779fff154e5286355e90204f737d65ad67b41a9f4c0b97");
            result.Compilation.ShouldBe("d2b17899a38e4f9585dfd8f1bf61b783c9bacfe9f18944619f");
            result.OfficePhone.ShouldBe("423916d573f14bfe8f1022fcff924556881f26de9e7e412a9c");
            result.FaxPhone.ShouldBe("b4f55ece09e6481281cdd766ba73880de3ca47b114fd47889c");
            result.Address.ShouldBe("311952337a5b4990b3dae0493fe99174cd6bc37827e747d3a1");
            result.Principal.ShouldBe("e5d429cb27db49b28e844ed88d093065ff8abb3649834ccc94");
            result.AllowSearch.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("68ee986a30214982b53b9272cfa2f4accdca3acd196e43578133ef2ebfd69cae64466535e17d40cba3fd2330f49cbd2edd6d330e38d6455d87288853e6556503ab2f8c6aadc54e2390731526253dac07f4a48e2cc5dd4ebaad407b59fc8ad2c6ca8309a6175c460684c88080e6be15225804aff0822e4a45bbfba432d4b57b6cd4a549b0f5884ec8a35e052d82043e6c9aa2dd4f78f340d89dfff27b04173c0ea2c105cfa9a142e9b811580547d499ed884084684509483fa8509992594be6949a1c3c3944e24004bde780eaf5acc5ee04d7d6678edc4de987332daa5663352cf4e641c3b4054a65a6f3658cc0947859a67ac63b3fbc4655be1c");
            result.DateA.ShouldBe(new DateTime(2018, 6, 4));
            result.DateD.ShouldBe(new DateTime(2011, 4, 3));
            result.Note.ShouldBe("7d0369cade51440f951a083f76e39c7446a9261630214d63a02aeb59995fabc3ea47aa24ff334159a9411be70c3d6d0469339c64dee242249e9368756aa3729e15a6b3c13e3544cabc48588e37cce37b5feb8a48c2aa43ea93b1bf68bbde4fbf515fab9110044ce9a1e56fcb8e59f41389ef002da72947db861ef4398eefd9d8080c14c530924cac88d22491e40bb41d0de599ce5fa34b93aee5a7fc78a6d070a2152764e5b34ee9abcd8691301441d2fe4d9da79be649deb90d0b21e4c3318620334a6268fe4f389e1e5a62ce5240ac027564eb308841de8a4ac7044f479bf96202890fbc134c2581a6d5a45017305f6404fb59364d4b47a66b");
            result.Sort.ShouldBe(1862618799);
            result.Status.ShouldBe("04d8535115984a3db1c181277d0f84c244590898441e4d45af");
            result.IndustryCategory.ShouldBe("342c08a75f16490ead5517b2dc462cf73126fb70ec9b4ee98a2331fed8c402c79913be6712c346b8842f0d123850ac8f4013ad1bf84a48a8af80eba91a0dfcde5195f1fbe3c34ae7b2dc39384325b9486f15e4fb81794bada7b1b9bf57d92b938ce1a637e13c49d394bdb2f4e4e28bd83b6ade7bc8d84e13a28c1f4d0dc9551a312b892a1a414c129ca754e2a2fb2f985810388df69249eb97c9ddaee6291e444be6ae16037447ce8c4338adee53afd2cfd9bc4061324b48ab957f4cd626ab9c8c4b7a2834424bfb8bbd1f0b58513bdd8fb603fe88b943a998fb858a7e4836af0f1f0aa7fcb0412aa6cdf67860c37d0f884cd032314a46959094");
            result.CompanyUrl.ShouldBe("807707bdca7c402cacd25005dd7957d875405a1d70784a8680c731e7b065cb6e679ec91a952247839ab3aa9b17edfec5b0d32539b11d490cbfd5b7d2296bb001f41987f9a5a9459bab5a7c3e9c52da109f36972aad6e45b6ba4100a7e85f4d1976d84516");
            result.CapitalAmount.ShouldBe(3663958);
            result.HideCapitalAmount.ShouldBe(true);
            result.CompanyScaleCode.ShouldBe("1b77994c863f438683a30bf4a4fcc418426b829cd15842bca7");
            result.HidePrincipal.ShouldBe(true);
            result.CompanyUserId.ShouldBe(Guid.Parse("78aa87de-acb8-481d-89b4-be0b47a1d060"));
            result.CompanyProfile.ShouldBe("85604de280b04e71b84eff93a5377065eb6164f250ff455d9e41f0d152f3741e1c29185d45824ce39e46be83734b6e4f65e0a4e1d5994e2581e1bf4da6fa801010f5d9f3d54a4cffa087df57efa236a959d83e309a7b4c7daae1e7094d9691cc9090d63ff5d0493d87478d40e94a56569fbcaf1b48a94e3e99c6cccd7deaa0345eab7359c06f4f0e8a06419365c0a09691ac3e626ffd41598e1c9b6c4c324095ba432f30578c4d87b877f4b90b454f2252b5c69c826a45b0bd872f25ed9147747bdb0965e871401b81c8f5e622c6d69a70f0b9b2b33b4bb7a8209297e9f84a7f63fc5705fa924055b55deabe1b5f1f4dd012e081d2374094afd3");
            result.BusinessPhilosophy.ShouldBe("74f2a0ba6bfa4f4e8b23f313f1e62dcaf122e85bcd1d4545871254e1ade2ff6bbd0708f53ce84c5ab67dd5b33d3ddaa339e4606e6b9e4f11a864e416ba962a95cd0818ec1b694c98bebce406d6a370bea3eea05e3c2a4874b1a2fbc03328fce77caece38d95149c7b34f949fc33472c6d08cb5a6a3774337834468fba0f83bb692e6f7e47ce44cdeb113dac25c575700cf299e18af37447abaf1f7732986b47c2319878de9a2470b8e427388ef3541c0c50f90ef93ca43a2846ae1242ce1c4fee48defc103a2482ea9e14bb8d80a20cf5a968158cd77469fb93dc99d62b626a111482b9d69cf49d5aac76ca26e2e6da477bf8c6fcb71416bb402");
            result.OperatingItems.ShouldBe("5212d380a8a94696b031f2395ef7ac3b4bf9bf41d7a14d238f6e57e803471262be4d6c36fc3e4049bd5c3bd03c34f3434cef53dc2eba4dbe9cc3d9cc70ca3a13f820dd9131284ba39000486503e5aea772c40fd6e03644c687ba08b4a17718f1fe4c7cdbb41b4cdfa92abe8691b4c098acd14d557f9b43efb1831e2db7a536b041a300a400d44195870204c928266dd274fb35e5306840e4bfe3332664351fdb8084dc4d79164519bec8359e1f751ea2e519a087d1a9411789b51628f86e4681fb5261bee2e540ee9f40166cd7958b30a719d3b6863e45b8b7bc5b123a7514d7935c3870ead64eca85ab27de9c1f0cdaeb0a242c17c04c419b8b");
            result.WelfareSystem.ShouldBe("b474bf586d54436abed874609cfa6fddc61cdf107731444691d381d676bbd4d5c14a621727e242cf95ad64c652dbe4604c1e6d7e480941dfb68d95b598ac333605781c40a1d341a9954a344c2834a114c626cae23c1a4d3f844956f55eaa2aca5f67e4a5e0ef4667add93d4e63f12e8fbc84f29fa930478382005cc04ecf40429764af8821f74a92a6621466416b2fde64fe2d3c4ca346c89dee0cb7ed76030c93acd11147af4d9887ec8bcd1037eecd7715e9c366c84f8fbf8807aabd8c4b0d82c3ec8024274d55828f3ae72c354017f0076e82724b4c70a41ae8977e56a35158fd30976f364923a558b38a33f84ab9f45868488cee4bbbb46a");
            result.Matching.ShouldBe(true);
            result.ContractPass.ShouldBe(true);
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyMainsAppService.DeleteAsync(Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f"));

            // Assert
            var result = await _companyMainRepository.FindAsync(c => c.Id == Guid.Parse("993fe6b3-e9ea-41d9-a326-4adbaceb353f"));

            result.ShouldBeNull();
        }
    }
}