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
            result.Items.Any(x => x.Id == Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("17ba6b01-ffe9-44fe-bc7d-8b689b71b3d2")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobContentsAppService.GetAsync(Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobContentCreateDto
            {
                CompanyMainId = Guid.Parse("314d52ce-d44e-4b06-8d25-86d76cb8b3fc"),
                CompanyJobId = Guid.Parse("b92fe79e-b5cb-4da6-81a7-ae3de61835d4"),
                Name = "59ef5bcb9c3049d4905ffdd5236ceade208440c9970b42a395",
                JobTypeCode = "dbaa492c7b2744b5aee9438c3f766597e3a7351859c34bb0af",
                PeopleRequiredNumber = 1454822943,
                PeopleRequiredNumberUnlimited = true,
                JobType = "2d63cceab7064ba1a111e963bef58e23a106765c4c6f438bab4f1c27f062e7bda22df3f484394f12ba0fe3595531bbbde06924badf5e4de7b6fb3edc9b3836fcdce5c5dd6ad4405498a338ce7911f352218f69fd15114f75bd0abbba02f901b5295728c0",
                JobTypeContent = "00151960cb58449398cb07e6195e17caa53874b01ac2475f925d0ab76f29bdcb88",
                SalaryPayTypeCode = "91d3c0bed1ad41cf993c4bd4bb41e75fafd8fc5a3e42486486",
                SalaryMin = 1130662716,
                SalaryMax = 648623343,
                SalaryUp = true,
                WorkPlace = "811d0fa6c2dc47288d3f006dccd19fc7dec17ba5be794fbfbf3027fc2998070948b1f1183bd94b929e72cdd8b2e2130988a0212841ae4856bffed236b95a04c6411af758e05d4b43995960daaeb7cecb237232093a664c05b062bedc33dc5908d379a620",
                WorkHours = "61bea5e794c84c41b63a29daf188a6ae7deab2b3580c45f4a99cf1dca491e1fa39a6905f02f6437f9d515c730730e7301c0c67a372d4455bb16a33907d9607805bd9ef1a10f1485f9ac6a8dab19d63816f14b3b099f74f009cbf6aa536374b56c22ac971",
                WorkHour = "41d03e898e964b8a90a4f443cc1cad8ddc233e5472e449a8b75602221b5d0241bca23aee50f54b06aea44a455f9c962fa93443d483194b718c66052aaf4d86db0d8fa4cc34e745aea0b814df4ab8b799d583809c13c94602a68a611433952d4615964423",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "7482233d0f574c449e565748c78ee3960b6983f6cfed48e1a5",
                WorkRemote = "ce2d425057404f2b860c65b4032dc0338d91876789984dfca914fe77833995c8be2e092a538c4a47b087426ff5683188cddfa5ae7c6b412da6b4dacbe60a3d1ab2cce84f459b4a77a8c40e72af3a87e43ca0c98ef29f4bcf9d4b91cc7ca7e58094fb8adc",
                WorkDifferentPlaces = "4217cb76f46b45d3bb44a502e6ef6fdb27a18c62b31d482ea8620a8d60636d93064603217cf845af8e51f1a952cd8547a9e2bd2a52c04a75864e5d0fbe20f023080cb979bcb9403da7a7fb9774fdad55b058e9cf1c7f4e2ba089fe63c7f80af81ec6a873",
                HolidaySystemCode = "8cbb018883f54ed09d424b1d4ea344195e5693453e84420091",
                WorkDayCode = "367651bf371840ba9d1b49eb831745453ff20ea361af4969b8",
                WorkIdentityCode = "6fa97c9f31d0424388617588a0df7266a7406a89e0dd4799a701131fa0bc9dad6543d3b82a664a09a93f07cc7b005b434022fef815a3407e97f00714fd289c36d8dfb0f54ce54f668b5c0c6f945ffbe6fd0febd0a50a446d9a9a807203ad6579e7cce3fa",
                DisabilityCategory = "5e89101df3fe480989f86c2296a27afe55a91ee90a9c4caaae55015a569c3c8207e2691e79354ca9a8e24d47718ceae2bbc26109fe0f4b3b81c16f2b0df7919f358043d5844940be87ed95ff4753d257b37ba38f002743ba9503aef7838cc7b08a0e3432",
                ExtendedInformation = "3b375e1f85eb461db8e3e4c69cbb974ed22207c661084369b92f5f3dd64cffbf713992f3d9ce4be78c1822072ebb73246c7e3725c4664551a621f037a05907ff22e621741b764499a9ef3d2619bfad5fe68fcaf8beab4ac2ad231c2fb03f7866ccf4d60733b941e0873e444512ca0a4bf85c5cc819134fcbb0a25aebb77861c891de2f64a10f4aec95ab55b80fe7f75b76ba0e7752f045228b96f849cf55faa4ca670f5bad7843e5b13805acf5b6a0341613aad4c8a44f5ea4698b9866331517debac1bbd65f4345b1662eb63119b6abeecd9450a60a4ac184ba89208fa24f0cc63ab367cd5f4db4a4b378ba293559c2ec68f85d8b9b45158afd",
                DateA = new DateTime(2002, 4, 3),
                DateD = new DateTime(2003, 7, 17),
                Sort = 1656102709,
                Note = "2eb342c5a1b3437bb02e0e20ad37386768ab67153ddd4558aa7404ea20e9cf60f102b61b93d647c3a97b58d184f51b85b753e7f3cbc441288206ec60c785bd5433496ff6df314de2affcfad44d090787938473788eb1499daf994c7fbec6334a52ddf605333e4ccb89eb37e855e215d6689bc137bfd146d698d20feb1a1ba94fba9844b95019413bb42bf461599f9a04c018a6f9b2a44c12b645ed5052e0a57e08c8280acbde4aa993f0706fcb4c797a4e658708b0c847008ee8d261306160b84869f9c2b89d4577b5301b4cebb77fa063d5bdecfe6a403fb8d172280ea4d6b3cd855cdd882042259c4494be0c9f7cd8fc6d5e26bba64cd7bf96",
                Status = "151e44c62f48444895bff1b1ccdb3cb97b98596c3ad045b9ad"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("314d52ce-d44e-4b06-8d25-86d76cb8b3fc"));
            result.CompanyJobId.ShouldBe(Guid.Parse("b92fe79e-b5cb-4da6-81a7-ae3de61835d4"));
            result.Name.ShouldBe("59ef5bcb9c3049d4905ffdd5236ceade208440c9970b42a395");
            result.JobTypeCode.ShouldBe("dbaa492c7b2744b5aee9438c3f766597e3a7351859c34bb0af");
            result.PeopleRequiredNumber.ShouldBe(1454822943);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("2d63cceab7064ba1a111e963bef58e23a106765c4c6f438bab4f1c27f062e7bda22df3f484394f12ba0fe3595531bbbde06924badf5e4de7b6fb3edc9b3836fcdce5c5dd6ad4405498a338ce7911f352218f69fd15114f75bd0abbba02f901b5295728c0");
            result.JobTypeContent.ShouldBe("00151960cb58449398cb07e6195e17caa53874b01ac2475f925d0ab76f29bdcb88");
            result.SalaryPayTypeCode.ShouldBe("91d3c0bed1ad41cf993c4bd4bb41e75fafd8fc5a3e42486486");
            result.SalaryMin.ShouldBe(1130662716);
            result.SalaryMax.ShouldBe(648623343);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("811d0fa6c2dc47288d3f006dccd19fc7dec17ba5be794fbfbf3027fc2998070948b1f1183bd94b929e72cdd8b2e2130988a0212841ae4856bffed236b95a04c6411af758e05d4b43995960daaeb7cecb237232093a664c05b062bedc33dc5908d379a620");
            result.WorkHours.ShouldBe("61bea5e794c84c41b63a29daf188a6ae7deab2b3580c45f4a99cf1dca491e1fa39a6905f02f6437f9d515c730730e7301c0c67a372d4455bb16a33907d9607805bd9ef1a10f1485f9ac6a8dab19d63816f14b3b099f74f009cbf6aa536374b56c22ac971");
            result.WorkHour.ShouldBe("41d03e898e964b8a90a4f443cc1cad8ddc233e5472e449a8b75602221b5d0241bca23aee50f54b06aea44a455f9c962fa93443d483194b718c66052aaf4d86db0d8fa4cc34e745aea0b814df4ab8b799d583809c13c94602a68a611433952d4615964423");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("7482233d0f574c449e565748c78ee3960b6983f6cfed48e1a5");
            result.WorkRemote.ShouldBe("ce2d425057404f2b860c65b4032dc0338d91876789984dfca914fe77833995c8be2e092a538c4a47b087426ff5683188cddfa5ae7c6b412da6b4dacbe60a3d1ab2cce84f459b4a77a8c40e72af3a87e43ca0c98ef29f4bcf9d4b91cc7ca7e58094fb8adc");
            result.WorkDifferentPlaces.ShouldBe("4217cb76f46b45d3bb44a502e6ef6fdb27a18c62b31d482ea8620a8d60636d93064603217cf845af8e51f1a952cd8547a9e2bd2a52c04a75864e5d0fbe20f023080cb979bcb9403da7a7fb9774fdad55b058e9cf1c7f4e2ba089fe63c7f80af81ec6a873");
            result.HolidaySystemCode.ShouldBe("8cbb018883f54ed09d424b1d4ea344195e5693453e84420091");
            result.WorkDayCode.ShouldBe("367651bf371840ba9d1b49eb831745453ff20ea361af4969b8");
            result.WorkIdentityCode.ShouldBe("6fa97c9f31d0424388617588a0df7266a7406a89e0dd4799a701131fa0bc9dad6543d3b82a664a09a93f07cc7b005b434022fef815a3407e97f00714fd289c36d8dfb0f54ce54f668b5c0c6f945ffbe6fd0febd0a50a446d9a9a807203ad6579e7cce3fa");
            result.DisabilityCategory.ShouldBe("5e89101df3fe480989f86c2296a27afe55a91ee90a9c4caaae55015a569c3c8207e2691e79354ca9a8e24d47718ceae2bbc26109fe0f4b3b81c16f2b0df7919f358043d5844940be87ed95ff4753d257b37ba38f002743ba9503aef7838cc7b08a0e3432");
            result.ExtendedInformation.ShouldBe("3b375e1f85eb461db8e3e4c69cbb974ed22207c661084369b92f5f3dd64cffbf713992f3d9ce4be78c1822072ebb73246c7e3725c4664551a621f037a05907ff22e621741b764499a9ef3d2619bfad5fe68fcaf8beab4ac2ad231c2fb03f7866ccf4d60733b941e0873e444512ca0a4bf85c5cc819134fcbb0a25aebb77861c891de2f64a10f4aec95ab55b80fe7f75b76ba0e7752f045228b96f849cf55faa4ca670f5bad7843e5b13805acf5b6a0341613aad4c8a44f5ea4698b9866331517debac1bbd65f4345b1662eb63119b6abeecd9450a60a4ac184ba89208fa24f0cc63ab367cd5f4db4a4b378ba293559c2ec68f85d8b9b45158afd");
            result.DateA.ShouldBe(new DateTime(2002, 4, 3));
            result.DateD.ShouldBe(new DateTime(2003, 7, 17));
            result.Sort.ShouldBe(1656102709);
            result.Note.ShouldBe("2eb342c5a1b3437bb02e0e20ad37386768ab67153ddd4558aa7404ea20e9cf60f102b61b93d647c3a97b58d184f51b85b753e7f3cbc441288206ec60c785bd5433496ff6df314de2affcfad44d090787938473788eb1499daf994c7fbec6334a52ddf605333e4ccb89eb37e855e215d6689bc137bfd146d698d20feb1a1ba94fba9844b95019413bb42bf461599f9a04c018a6f9b2a44c12b645ed5052e0a57e08c8280acbde4aa993f0706fcb4c797a4e658708b0c847008ee8d261306160b84869f9c2b89d4577b5301b4cebb77fa063d5bdecfe6a403fb8d172280ea4d6b3cd855cdd882042259c4494be0c9f7cd8fc6d5e26bba64cd7bf96");
            result.Status.ShouldBe("151e44c62f48444895bff1b1ccdb3cb97b98596c3ad045b9ad");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobContentUpdateDto()
            {
                CompanyMainId = Guid.Parse("b7462e8e-faaa-43af-a0f5-3969d9f855c7"),
                CompanyJobId = Guid.Parse("9266ca9b-3111-4794-8674-3f84063340ce"),
                Name = "e16bf8dd68e0469a92432de3c2ed5e5e770f475cf4d3445e96",
                JobTypeCode = "c79887544eca4d4cb99430e65e415964f790f2ed72414ef18b",
                PeopleRequiredNumber = 2142316136,
                PeopleRequiredNumberUnlimited = true,
                JobType = "576eca8827d243028244354010e459b0f8a0a8651d834def87dc0ea5686426912f23fa308b2c4ba5b2fa07dbaef1895f5441b6597a1b423f81ffd0dc772c0afddff4c7a49acf4c42b8dcfa1d1cd3927f2038a509a579423e8678c8f73bc4cd95636b0337",
                JobTypeContent = "5687c05dd",
                SalaryPayTypeCode = "916afa1d8c5c49d39fead7fee89982fcae08a49cb6c64667bf",
                SalaryMin = 2139015463,
                SalaryMax = 1189827288,
                SalaryUp = true,
                WorkPlace = "8b51c7bf85b04448b4440d7556d0b17ad26febec658947e1b06dc358387b0a9c3c0794edd3cc489f82cdd2422b17b979d8e9d2cf7890431bae80e3f5fb3816e52efba52b929243c6bf7f40d3ab41420425061cd4f1e24f358d0eead7d91af27dd320627a",
                WorkHours = "d4da8864aebf42fd8359e58beab64b15a16863279dfa49ea8eba9b0fb2a47ad2b80d0c05bebc4545be7085175fbdff8adf0f0e741b0142ee9f3d3b68c2bf194f3160029fa02840a1a5cabfdd99424e2a8f464cde2ae04421b88cce23d196f111f63c4276",
                WorkHour = "2165a9547d3a4fc3a1a61578a98512ec4a2adcefb53d44c1b9ce6a8d0325ed7be1eae26b88a44648af79d887c8e20f8cc610f2f5e0794666a634867ffd54960a60feb5f22cb343c8a51bf17898a0eb8a53cb5e9cd3d1444d84790340d71a4b7ad08f26b0",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "0c4f3af044934e41b5249b65297dd4bd98d5ed51679340ddac",
                WorkRemote = "ee0560232d08456c825f95196e80db34662e9282d82d4aaaa53e487b7e5239bf09f6380aefa740af8c7d6e83c62ae7543fc765eb7952472f8086d67a7849c2d3110ccce1e2d141b8978dbf562546ab67250e235bdb684897a24892828651a5671555b5e2",
                WorkDifferentPlaces = "887e28c22f9046ce8551395f1149e7ea0930b68cdb27472986b6424c5547c03566d689f9b3f440f397a20e90f182c8dde11c765bab0f40639a5b467cff9f6fd71bac38b33c0c4a36ab45da1a1bdef908d3d626bb5fed49089a74010cbb2faba58b4c5c72",
                HolidaySystemCode = "525404be986340b4a085a295a8966e4846504b5d49264d8eb6",
                WorkDayCode = "8327199eeb1f476980df692e5906f93016fb8aa21d05469e91",
                WorkIdentityCode = "8dc36941b3404719ae3dd4c308af305fbf0c6bbea9e646bdbbad6a18022e3c9bde867bb35061426e9eb548a64c8a53f030ab031a3c1b497aaea4f14e2d26a16b1bcf4bd05b3a4588a03bf43462505e105fc02efc2a3e4d2990d017f0eb44f38906b01296",
                DisabilityCategory = "041d5135aa424659903b38cf5d39c3241745c5dc12c044aeafa64ece74f4dfc83626758434294ba2b3ba5b7eeaf1560189bda8cc19d847c99340bab13b00b51ddd4126288d954bbca9b00e85f59ec370c48216632cc94c14a5dc43c6cf1cd33810c6215c",
                ExtendedInformation = "334df849aa6f473e9ccd563603d8ba28df04bd9448ce4087b47f1bbbc3f4157fd9abb7628d314267b299dc3e4abad8140f4650a9fb52472ab455ba4592ade2c18259d5d518f948cf878fc5596a3e30d27a5299c40ad247eda5b2f0016582ad5c85c8890bb4134f898b6fda32fc2f70baf0213ce5634f45bdaee2d0ad7ec6e09819296c92ecbb4f53be6dfe079cc0d51a8a7addae05c240d78a3c5b86aa712f38a9bfd7d0323c470792a790b4a6d431aa247a29f912fe4304a4e7bbe18a09840741f38c146d334f8787921208782788b6c4c0aae9628341209fbdc79cdc91877a64d79ff0af15452eba2b22673e444b5bdd2e1f9f91d9422c8bef",
                DateA = new DateTime(2018, 4, 12),
                DateD = new DateTime(2003, 11, 11),
                Sort = 1475366209,
                Note = "95eb7f13f4194708bb7176b30470eaa889f32906475942879c4b05407adc9e42fb0a28f2ca634a0f8e1f2d25f8222dc0dbe901d4c9e2464a862ad79be857c63ed30dcfbd56ff4ef395b2d5ce181ba1a810a99523b54d40dc97f84a1695af4744d280e55c27aa4ca7898f5d84b2ccd9b77c96a21c3f274bb084070f2b4a2135a5c85eacc2ee29462497e93ce6deb41b750a8f99a8192e478b955946e50a9a7d9997bd57ded0c347fe8651fcc566d4bfa21f577f2d0276495bbfd198e4a62f6b7e42f52dc50ac242fca224732a58955baf9ab56a7f0c0f44c8a1c3edebda642a8b30c041cfeb4c4e15a369ff245e3824ca56cd42c3c2e54c8b9157",
                Status = "7aafea4f772147ff8a0cb83954b8e5c1f6312a3df8b64dd5a4"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.UpdateAsync(Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"), input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("b7462e8e-faaa-43af-a0f5-3969d9f855c7"));
            result.CompanyJobId.ShouldBe(Guid.Parse("9266ca9b-3111-4794-8674-3f84063340ce"));
            result.Name.ShouldBe("e16bf8dd68e0469a92432de3c2ed5e5e770f475cf4d3445e96");
            result.JobTypeCode.ShouldBe("c79887544eca4d4cb99430e65e415964f790f2ed72414ef18b");
            result.PeopleRequiredNumber.ShouldBe(2142316136);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("576eca8827d243028244354010e459b0f8a0a8651d834def87dc0ea5686426912f23fa308b2c4ba5b2fa07dbaef1895f5441b6597a1b423f81ffd0dc772c0afddff4c7a49acf4c42b8dcfa1d1cd3927f2038a509a579423e8678c8f73bc4cd95636b0337");
            result.JobTypeContent.ShouldBe("5687c05dd");
            result.SalaryPayTypeCode.ShouldBe("916afa1d8c5c49d39fead7fee89982fcae08a49cb6c64667bf");
            result.SalaryMin.ShouldBe(2139015463);
            result.SalaryMax.ShouldBe(1189827288);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("8b51c7bf85b04448b4440d7556d0b17ad26febec658947e1b06dc358387b0a9c3c0794edd3cc489f82cdd2422b17b979d8e9d2cf7890431bae80e3f5fb3816e52efba52b929243c6bf7f40d3ab41420425061cd4f1e24f358d0eead7d91af27dd320627a");
            result.WorkHours.ShouldBe("d4da8864aebf42fd8359e58beab64b15a16863279dfa49ea8eba9b0fb2a47ad2b80d0c05bebc4545be7085175fbdff8adf0f0e741b0142ee9f3d3b68c2bf194f3160029fa02840a1a5cabfdd99424e2a8f464cde2ae04421b88cce23d196f111f63c4276");
            result.WorkHour.ShouldBe("2165a9547d3a4fc3a1a61578a98512ec4a2adcefb53d44c1b9ce6a8d0325ed7be1eae26b88a44648af79d887c8e20f8cc610f2f5e0794666a634867ffd54960a60feb5f22cb343c8a51bf17898a0eb8a53cb5e9cd3d1444d84790340d71a4b7ad08f26b0");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("0c4f3af044934e41b5249b65297dd4bd98d5ed51679340ddac");
            result.WorkRemote.ShouldBe("ee0560232d08456c825f95196e80db34662e9282d82d4aaaa53e487b7e5239bf09f6380aefa740af8c7d6e83c62ae7543fc765eb7952472f8086d67a7849c2d3110ccce1e2d141b8978dbf562546ab67250e235bdb684897a24892828651a5671555b5e2");
            result.WorkDifferentPlaces.ShouldBe("887e28c22f9046ce8551395f1149e7ea0930b68cdb27472986b6424c5547c03566d689f9b3f440f397a20e90f182c8dde11c765bab0f40639a5b467cff9f6fd71bac38b33c0c4a36ab45da1a1bdef908d3d626bb5fed49089a74010cbb2faba58b4c5c72");
            result.HolidaySystemCode.ShouldBe("525404be986340b4a085a295a8966e4846504b5d49264d8eb6");
            result.WorkDayCode.ShouldBe("8327199eeb1f476980df692e5906f93016fb8aa21d05469e91");
            result.WorkIdentityCode.ShouldBe("8dc36941b3404719ae3dd4c308af305fbf0c6bbea9e646bdbbad6a18022e3c9bde867bb35061426e9eb548a64c8a53f030ab031a3c1b497aaea4f14e2d26a16b1bcf4bd05b3a4588a03bf43462505e105fc02efc2a3e4d2990d017f0eb44f38906b01296");
            result.DisabilityCategory.ShouldBe("041d5135aa424659903b38cf5d39c3241745c5dc12c044aeafa64ece74f4dfc83626758434294ba2b3ba5b7eeaf1560189bda8cc19d847c99340bab13b00b51ddd4126288d954bbca9b00e85f59ec370c48216632cc94c14a5dc43c6cf1cd33810c6215c");
            result.ExtendedInformation.ShouldBe("334df849aa6f473e9ccd563603d8ba28df04bd9448ce4087b47f1bbbc3f4157fd9abb7628d314267b299dc3e4abad8140f4650a9fb52472ab455ba4592ade2c18259d5d518f948cf878fc5596a3e30d27a5299c40ad247eda5b2f0016582ad5c85c8890bb4134f898b6fda32fc2f70baf0213ce5634f45bdaee2d0ad7ec6e09819296c92ecbb4f53be6dfe079cc0d51a8a7addae05c240d78a3c5b86aa712f38a9bfd7d0323c470792a790b4a6d431aa247a29f912fe4304a4e7bbe18a09840741f38c146d334f8787921208782788b6c4c0aae9628341209fbdc79cdc91877a64d79ff0af15452eba2b22673e444b5bdd2e1f9f91d9422c8bef");
            result.DateA.ShouldBe(new DateTime(2018, 4, 12));
            result.DateD.ShouldBe(new DateTime(2003, 11, 11));
            result.Sort.ShouldBe(1475366209);
            result.Note.ShouldBe("95eb7f13f4194708bb7176b30470eaa889f32906475942879c4b05407adc9e42fb0a28f2ca634a0f8e1f2d25f8222dc0dbe901d4c9e2464a862ad79be857c63ed30dcfbd56ff4ef395b2d5ce181ba1a810a99523b54d40dc97f84a1695af4744d280e55c27aa4ca7898f5d84b2ccd9b77c96a21c3f274bb084070f2b4a2135a5c85eacc2ee29462497e93ce6deb41b750a8f99a8192e478b955946e50a9a7d9997bd57ded0c347fe8651fcc566d4bfa21f577f2d0276495bbfd198e4a62f6b7e42f52dc50ac242fca224732a58955baf9ab56a7f0c0f44c8a1c3edebda642a8b30c041cfeb4c4e15a369ff245e3824ca56cd42c3c2e54c8b9157");
            result.Status.ShouldBe("7aafea4f772147ff8a0cb83954b8e5c1f6312a3df8b64dd5a4");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobContentsAppService.DeleteAsync(Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"));

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == Guid.Parse("766d6363-567e-4af6-b2fb-16fb6edfa4f3"));

            result.ShouldBeNull();
        }
    }
}