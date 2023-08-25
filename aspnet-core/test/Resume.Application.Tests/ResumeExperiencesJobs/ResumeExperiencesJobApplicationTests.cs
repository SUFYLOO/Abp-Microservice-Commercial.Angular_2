using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeExperiencesJobsAppService _resumeExperiencesJobsAppService;
        private readonly IRepository<ResumeExperiencesJob, Guid> _resumeExperiencesJobRepository;

        public ResumeExperiencesJobsAppServiceTests()
        {
            _resumeExperiencesJobsAppService = GetRequiredService<IResumeExperiencesJobsAppService>();
            _resumeExperiencesJobRepository = GetRequiredService<IRepository<ResumeExperiencesJob, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeExperiencesJobsAppService.GetListAsync(new GetResumeExperiencesJobsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("bef1c89c-664b-496c-a20b-0c5838ad6ddc")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeExperiencesJobsAppService.GetAsync(Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesJobCreateDto
            {
                ResumeMainId = Guid.Parse("468721dd-27a8-442d-ae33-1b3a4c50795c"),
                ResumeExperiencesId = Guid.Parse("826c0d62-9ccb-48bc-a2b2-1c04b72bb658"),
                JobType = "282978323291437f97c061defa6d00e11846ae05e7524228957ee06e99872dcd51627af7163b44bfa265b80141e6847ea556f98383fb4e539a72ff67fad7d9cc62123ff359204dfc8f47c485e9375d7757eb31d5c98745ebb9ed617b605e0f582d93625141f14a90a61d30ed3e698ad33075f14e9bda460b8a7dfc237298009bc28863c220654ca49dcc27c350dcaad0844caa451d254beeb0785123b1e48a4359c2dedc54ce449eb722c78e2cc9059c6fdb6178250f487fac69720427afa3fd5e46958b7ce24e2b95a045deb0ecf9e0fffeeb71737442de91b6633b8fdd7d8a993e9ac0862841d7bf4b7a83adf2b107cd7017e73c9f438ea860",
                Year = 964165112,
                Month = 57136319,
                ExtendedInformation = "152a6428990c4af88ee4db07970c882004b14c629c974108966fad5f32489d454c001b8b5151452e9699ad407cb2b6e31304e1a1c05b41bbbe357832abdb16e882e6444afe3a4e0c8667d7c2ce0e614466abdeaf00ad410aaa0816b3d44a294704eefa76a0d04b20bd3f47351b50b9a3fa21f9b88c514947a727a279284ace97c145b93f39e043d8bdcafb8327060652712cb348b12f4cff9ddbdfaf66937369e87a590819264508945ac6244543d76f8bbdd0ec484e4823a2e3d7db7dbfdfab4b46d72882264a03b26adc7f29bc2c68827f9e948f484d4caaaaefe276bc9b9dec8f565049b94ff6b9152272fc45d869487ea53462a64eecaf11",
                DateA = new DateTime(2001, 2, 22),
                DateD = new DateTime(2005, 10, 17),
                Sort = 947016985,
                Note = "0547a1c8551a4501b607f843d445feb6e329b5e31e1d41689633581fc80d333265a76567bc1d4fd499d27e05e396b0ed29e49173392b411983c5ef6183b543e2fe590d98e2294a13b49eabe2c12002ecac38e36143dd414aa79b6d8c707c98fa5ff59af07f3b4621ac8f79877b15d1113a4aee8a295c4794b9dee628938d795ef6455a047c4b4f6c8d4d475f8f5195c1edee26137a9b477ba50e6778607b44999e085c4115e745eca7898921a585788df70cf896231f4735bb7dc00522636c308e725591dbff4a13b5e49760f1bcc514fd188f325daa46ab9a58314e733fd8920be96812a7634e97ae810e1b21cb73897a641856bba7401392eb",
                Status = "2e5bb6768c0e4ab5a406df3eb61936fa421ba227f6974b0195"
            };

            // Act
            var serviceResult = await _resumeExperiencesJobsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("468721dd-27a8-442d-ae33-1b3a4c50795c"));
            result.ResumeExperiencesId.ShouldBe(Guid.Parse("826c0d62-9ccb-48bc-a2b2-1c04b72bb658"));
            result.JobType.ShouldBe("282978323291437f97c061defa6d00e11846ae05e7524228957ee06e99872dcd51627af7163b44bfa265b80141e6847ea556f98383fb4e539a72ff67fad7d9cc62123ff359204dfc8f47c485e9375d7757eb31d5c98745ebb9ed617b605e0f582d93625141f14a90a61d30ed3e698ad33075f14e9bda460b8a7dfc237298009bc28863c220654ca49dcc27c350dcaad0844caa451d254beeb0785123b1e48a4359c2dedc54ce449eb722c78e2cc9059c6fdb6178250f487fac69720427afa3fd5e46958b7ce24e2b95a045deb0ecf9e0fffeeb71737442de91b6633b8fdd7d8a993e9ac0862841d7bf4b7a83adf2b107cd7017e73c9f438ea860");
            result.Year.ShouldBe(964165112);
            result.Month.ShouldBe(57136319);
            result.ExtendedInformation.ShouldBe("152a6428990c4af88ee4db07970c882004b14c629c974108966fad5f32489d454c001b8b5151452e9699ad407cb2b6e31304e1a1c05b41bbbe357832abdb16e882e6444afe3a4e0c8667d7c2ce0e614466abdeaf00ad410aaa0816b3d44a294704eefa76a0d04b20bd3f47351b50b9a3fa21f9b88c514947a727a279284ace97c145b93f39e043d8bdcafb8327060652712cb348b12f4cff9ddbdfaf66937369e87a590819264508945ac6244543d76f8bbdd0ec484e4823a2e3d7db7dbfdfab4b46d72882264a03b26adc7f29bc2c68827f9e948f484d4caaaaefe276bc9b9dec8f565049b94ff6b9152272fc45d869487ea53462a64eecaf11");
            result.DateA.ShouldBe(new DateTime(2001, 2, 22));
            result.DateD.ShouldBe(new DateTime(2005, 10, 17));
            result.Sort.ShouldBe(947016985);
            result.Note.ShouldBe("0547a1c8551a4501b607f843d445feb6e329b5e31e1d41689633581fc80d333265a76567bc1d4fd499d27e05e396b0ed29e49173392b411983c5ef6183b543e2fe590d98e2294a13b49eabe2c12002ecac38e36143dd414aa79b6d8c707c98fa5ff59af07f3b4621ac8f79877b15d1113a4aee8a295c4794b9dee628938d795ef6455a047c4b4f6c8d4d475f8f5195c1edee26137a9b477ba50e6778607b44999e085c4115e745eca7898921a585788df70cf896231f4735bb7dc00522636c308e725591dbff4a13b5e49760f1bcc514fd188f325daa46ab9a58314e733fd8920be96812a7634e97ae810e1b21cb73897a641856bba7401392eb");
            result.Status.ShouldBe("2e5bb6768c0e4ab5a406df3eb61936fa421ba227f6974b0195");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesJobUpdateDto()
            {
                ResumeMainId = Guid.Parse("da26fead-12b8-41b5-9023-42f234530d6f"),
                ResumeExperiencesId = Guid.Parse("4678099e-a3bd-4d5c-bc19-9c1838238424"),
                JobType = "5060ed3cff02406cb08f00cd16d70c9c9d77cbd8b5db4178bb742d0e0f391aa87c2768e85cba4aac990b567a2b39c35f0ef2dd8bdaf345448ada51a41f2bb4624eac48f02bc142adb5e6c49c1874dbbfd7f18591b79a47a98c511153a8d6494c1e201bd495ff4529b49a4f051926505cf26dbbfc373c40e49c233b302eb6ac4de85510f0fb58460793acab804b251e58b39d11df91684efa9d93dc813c2258af8a14834e93c048dc8586ebe38fb5bd1a9436e0cd5ec2405a920b30d5ecd10266cfeeb7e217d14ea6a3a6994c99c6f6fc6ff4bba752a44a1c945ffe60b26f90ab6a1935409cf84e42b597e63a0eb94fb3e7940773beb349398f8e",
                Year = 616038982,
                Month = 1147158033,
                ExtendedInformation = "b10dfbc8130241558b972a9301b793e587b14369ec8c45dfb7a429f1e8a0db469d05dd1d7b0545a79b05ba47b48a4a86e430735c5fee43fa994bfb55cab2497f91d38d0e2310442a954a50e52b8470468ee2f4a7dfaa4dbea4d0ac9dca553c259b40b3d766d746318872e9271a454493bc65fb1b3237421c8ecb715efe0646bffa9d41c6c21548429d3a496dd981e5e73ae72a1b833c4cd18dba198abcad526f9e8fd2562e1141ee9dfe0f0e387e3d0e6d16fb622ebc4688831b7c34483a9b45cdfc6a37d3ce44b497f773d8e4f9a2288026fcedefba42ba93b918ca439fa08b90cdcf20e0cc49c0bcdfd95000128e26e6d1cb6a42cc4b24a075",
                DateA = new DateTime(2006, 1, 21),
                DateD = new DateTime(2004, 6, 11),
                Sort = 236352607,
                Note = "99df46bd98e44fb4b7f1f33c8059f31ef529f741a4cb42ec950c80a4bcf852686e0e2b29fc8c411f917d23734a828390c826e877bd0c4df0816cc7a0da029f3147bfa79fbaf74dd18ccd56d2a98086b2ffab0fee55694223ac05379497596ecdb7ce348994ad4e33a4e5726c901568b69c43936c8742458f972ec6869d60568278ee6d0d61aa428bbc9030d1126fd5406571eb0047ee4f30a537a1b80af27c609d9d182e3c8943a697b56e65e76b208a61e44a0de2a34209b947f93bb1ed1b65976b1e31067e4ab69cf8d9647caaea908868a4751f6d4a9cbbd150bb7e2cde035f6ba75a6fa34e8594e0cee547a69d5576ad69e67b7349eaa49d",
                Status = "24f5a8845971419690bdd4d49d922689f3596f45088b4051b2"
            };

            // Act
            var serviceResult = await _resumeExperiencesJobsAppService.UpdateAsync(Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"), input);

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("da26fead-12b8-41b5-9023-42f234530d6f"));
            result.ResumeExperiencesId.ShouldBe(Guid.Parse("4678099e-a3bd-4d5c-bc19-9c1838238424"));
            result.JobType.ShouldBe("5060ed3cff02406cb08f00cd16d70c9c9d77cbd8b5db4178bb742d0e0f391aa87c2768e85cba4aac990b567a2b39c35f0ef2dd8bdaf345448ada51a41f2bb4624eac48f02bc142adb5e6c49c1874dbbfd7f18591b79a47a98c511153a8d6494c1e201bd495ff4529b49a4f051926505cf26dbbfc373c40e49c233b302eb6ac4de85510f0fb58460793acab804b251e58b39d11df91684efa9d93dc813c2258af8a14834e93c048dc8586ebe38fb5bd1a9436e0cd5ec2405a920b30d5ecd10266cfeeb7e217d14ea6a3a6994c99c6f6fc6ff4bba752a44a1c945ffe60b26f90ab6a1935409cf84e42b597e63a0eb94fb3e7940773beb349398f8e");
            result.Year.ShouldBe(616038982);
            result.Month.ShouldBe(1147158033);
            result.ExtendedInformation.ShouldBe("b10dfbc8130241558b972a9301b793e587b14369ec8c45dfb7a429f1e8a0db469d05dd1d7b0545a79b05ba47b48a4a86e430735c5fee43fa994bfb55cab2497f91d38d0e2310442a954a50e52b8470468ee2f4a7dfaa4dbea4d0ac9dca553c259b40b3d766d746318872e9271a454493bc65fb1b3237421c8ecb715efe0646bffa9d41c6c21548429d3a496dd981e5e73ae72a1b833c4cd18dba198abcad526f9e8fd2562e1141ee9dfe0f0e387e3d0e6d16fb622ebc4688831b7c34483a9b45cdfc6a37d3ce44b497f773d8e4f9a2288026fcedefba42ba93b918ca439fa08b90cdcf20e0cc49c0bcdfd95000128e26e6d1cb6a42cc4b24a075");
            result.DateA.ShouldBe(new DateTime(2006, 1, 21));
            result.DateD.ShouldBe(new DateTime(2004, 6, 11));
            result.Sort.ShouldBe(236352607);
            result.Note.ShouldBe("99df46bd98e44fb4b7f1f33c8059f31ef529f741a4cb42ec950c80a4bcf852686e0e2b29fc8c411f917d23734a828390c826e877bd0c4df0816cc7a0da029f3147bfa79fbaf74dd18ccd56d2a98086b2ffab0fee55694223ac05379497596ecdb7ce348994ad4e33a4e5726c901568b69c43936c8742458f972ec6869d60568278ee6d0d61aa428bbc9030d1126fd5406571eb0047ee4f30a537a1b80af27c609d9d182e3c8943a697b56e65e76b208a61e44a0de2a34209b947f93bb1ed1b65976b1e31067e4ab69cf8d9647caaea908868a4751f6d4a9cbbd150bb7e2cde035f6ba75a6fa34e8594e0cee547a69d5576ad69e67b7349eaa49d");
            result.Status.ShouldBe("24f5a8845971419690bdd4d49d922689f3596f45088b4051b2");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeExperiencesJobsAppService.DeleteAsync(Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"));

            // Assert
            var result = await _resumeExperiencesJobRepository.FindAsync(c => c.Id == Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"));

            result.ShouldBeNull();
        }
    }
}