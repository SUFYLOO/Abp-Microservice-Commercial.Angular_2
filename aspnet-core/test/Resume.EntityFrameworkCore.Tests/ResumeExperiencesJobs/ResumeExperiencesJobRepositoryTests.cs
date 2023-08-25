using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeExperiencesJobs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeExperiencesJobRepository _resumeExperiencesJobRepository;

        public ResumeExperiencesJobRepositoryTests()
        {
            _resumeExperiencesJobRepository = GetRequiredService<IResumeExperiencesJobRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeExperiencesJobRepository.GetListAsync(
                    resumeMainId: Guid.Parse("23f3b20d-b51e-4312-a92a-a2bcb70eb66b"),
                    resumeExperiencesId: Guid.Parse("d70523a8-b0f5-4d54-8597-046c027f8868"),
                    jobType: "4b9e26f0d2d648008d0b4f71cb6821aae43621c6e2314666b0c10116d40bc49d835679e79af042c1b270ac767df066f6db64783234f342e18932b31a9534a135562911d49cd34c08976bb7d7c32226a91c9afe2069d340d6b2afcf6f1302557327ab630210664793adf9e51269abbf0a948ccf8315af46aa9b971ccee4c42e60bd1a65fb4e7242b19edc446522395683987d9a659d324caf8b4d7489a7f59070c2cfb967944c40f8b2cb8109ea39454143175c8502514c3692df477e6ec8f2fb1e5113dac30c473fa603e73cde2a830ed213e4f85c2e4a118e8debf545303b7475ebdf1937da4d2ea693781a56d9bd02397c94cb8b5b4f00b597",
                    extendedInformation: "ebf7a883bade48daa01510501306307013d913f4ce954c90a83270a07246f06c564eba08acda4036b74d123137c7618ae79c4e4ee227469099dc7c8e521a12d61e55b2af76c343c29b15cb425dad5a8e1d636aed1f5a474c97d8fc8842e5068ab60254e0ea924da8ada3f3f12c9990d341968b57f17b4c349315c66779d7b6275c9e9d16949a44b583e6ffb6a2a0ed226ec4eb68f1c94735a9a0a62a94c0756e11b4c84708f148cd849bce877846a2cb9b61ba2f373c420c959c421301ba910dd8e6ce7c56a24713ad40e8de499b116e78c36ca243f144f7afdb60d0c9ea48b0413bb0fb0fa245b2bb12753d1f49284641773eff129b454bbd70",
                    note: "e53ad8a5064240f287f7d999534a316b96c5ca45d7b8415a936ade14451eee43c59adfa0042444e58e8bf30e05dd280177c1b867b968456494ddb1ece69d3fc07b7711ba688f454aaa0c15194d7e481e4d050a58ff0e46d38898315c5e4431133956a970e5874d0b9ebf102e01da16a5b843491a943443798c95b778fdb2d2a6c3321321d37a46dda683c8146dd1cba52c3aba40b8d64c979c1866f4ea845057afe66a3c959c4a28a5305932733fd771439e4072bda04574a27bf5f585a7cb32804f46c5d59a46ec856005ff6bc2e71e62e3747a2cb248f4bdca4b64bcbc5862953e9b68195943f4b3baa434529ef8d0317fa3d8e9054c8b8315",
                    status: "55d3a13d80b84fdbb036f7e5467a641db084bbe59b62430181"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("e57d262d-5c13-4a85-96fe-9387d2680415"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeExperiencesJobRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("029ec64a-e750-415a-95a1-8e2841d72a3b"),
                    resumeExperiencesId: Guid.Parse("fe022bf7-39a9-413f-8e11-a9e553a009c7"),
                    jobType: "0125924ecdff49478d9d3a95b97c00c5b8ef4e5acaa24542994fa3c28f6933e7a23da215bbb348d58be77fa5ba6567e06fbf3219b7d94ed491cbb0244b1619c8556370aaf3c944d0b4d212fbb255ef6920fe5f6e23b14c0480ce336b87e80dc22537a6ccf58142798db9fb761180dfad7c61f0ebadbb4e389e4f8a02801218df72392dd8468e49c1815e3799433c75c10114d09e1c6d4888a9ff8c01c31c48aeb1c827a562264dd981e5e9a0605dfb01fa753a43509d43aaa7c12c527cccc3527f6445fcdd5d4fcbb9008a61f02b087a7c6269f86398420f9ba2e048334269cefcab290c02fb42078c1d9125ce58e9b69031f71f87c84e06aba6",
                    extendedInformation: "0e2e5037f8544cf8b5c7ea9dc8d4a27e828a2123ebd948e0a775bcba07820993f766d55e0bad4fe8afb27039b9d82f242f2e1e3d405141ea89f272d47c14199b843ea27fcc0d4b7ab9fb7c68f221ec00260d8ac551c34d6d8462788530d86d21585345aae0994930a803c014eabe59f8c18d3961096b4038bd897108664222c7cbd93f1b6b1c4e91acaf123d1bed50fb27bd9cf530394c83aea4df9f5935429f8f2658d8f7b442f4a4a191e6dc0ee285e3ca4dab650943ada993e483a62627b03bcc25b3e21344c8be9cb2a7092676e64b193b2e01bf426da8f4df3d8537042d780320d21113432288d3da401312824c7bd893d1124f4af6aa87",
                    note: "ff2cdda8446d4893bccabd7deb27ee79a1ba0da1246145d5b421b19e5d71f7b721091c5adf30482c9eb8d5189b22bf1970c11a74beee43138ad1cc2e7587ff70daac324eacfd4238a8fc18767041f2c3d2a6c82b623146afa963f57bd614a4f385625d45750e4bd8a0766939a23344a0e65e5ec1d0a84e22a6b2563c1da85717c6d8769876d341f8ae4c3c565cf1182aeb427b2b81e540868d1c48c8de57374e21ca35ad502d4fc6872a3fa9a42c0f0ed486a5502e4444109ddf6f359c40d7e1aa0a57c6b97642ed8d65d47c467de44c5e09c9b28add49b18ab0e9cbef9110f8e4bac810257144e09b1145cc4ad102c96b14c8717a134f2c8704",
                    status: "8e146807b1d7404c9fb8107bb64f47ef098eb3aa2f6945f382"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}