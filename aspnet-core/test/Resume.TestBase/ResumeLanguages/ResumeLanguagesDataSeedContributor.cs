using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeLanguages;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeLanguageRepository _resumeLanguageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeLanguagesDataSeedContributor(IResumeLanguageRepository resumeLanguageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeLanguageRepository = resumeLanguageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeLanguageRepository.InsertAsync(new ResumeLanguage
            (
                id: Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"),
                resumeMainId: Guid.Parse("c37768ed-ebf3-416f-a08f-ce8bfd5c6537"),
                languageCategoryCode: "9ba90936ade748dd8219e8fb2f75394c96f1adce9e304f9785",
                levelSayCode: "17258b2524ea4036b4bd0e16af8ee950dd27577854ad4cdbb4",
                levelListenCode: "58ee0d37f96348378a602fe620fe1856daf47851662446d191",
                levelReadCode: "eea290b8eb1d44448ec034f1c90fdcfbd3a974399e1b461cb4",
                levelWriteCode: "c613aab34dad47759a34dde1a39496cf5234cccc69314e87b9",
                extendedInformation: "0b13646834b447069d3148d5041e619131f6e41186684a4bb7b53f61b3a9e0628a7670ee227d470b937fb4c192c7267f1baffbf821864ff29286db42ff31fa446048370da6c74ec2b4f8406c5fc81badc36a30134d86480684a7e9f85875f7d13216f76891c6404badfd62f132e1edd3f265f6d1cb9748b5b3c883d4470648c92acaac3e67304dfebd79452474986a763bf0e9f94cd44c8c99b02fe87934330753741fbd015441639b40d1f2c0fbf37bb4bfbec5e27b4c04a0923936e30cfdaccf9d2563fe7e451f8556fe0a24fb040ed8991698c252404d884b325c13eaf0d4ee3273a9d97441bbb8288072fd10130b1c40cdf07be344e79bde",
                dateA: new DateTime(2007, 9, 20),
                dateD: new DateTime(2011, 9, 24),
                sort: 1243619515,
                note: "3e3bb2b07d6b44c6a4f6ef0af0bffdb91e219fd2169444fba97de0d4aec9c985928ebc234d7f49fda5dbfb08d39829e9f56bc7c6c1154865a98c17692a3b031c68cac88578bd4261a0f19e3dbd0f0622eb686b9a428d427f8c71fcdc74f32376795ddb60f5aa4227ab6c5b314be604f405c27207440d433b995abf132337e0269129ad22d6bf45cea07a8e8de81b2a7c06b1b1573b2d4626b48bd2c122b33d7a206ed40faf1d49108099042ab1c533e3f839a5e58de84b239c17cc0eb9a337c09ab29fead1be4cbdb2c4b0b09a3a61bba816d42c12f74e66baecb6eb63565c9d4651dc027f3744879551e6969833d91b9995c5543d0d4522bc9f",
                status: "06f89bd32d61428a8e4a98804766f5770700214dafdc419ca8"
            ));

            await _resumeLanguageRepository.InsertAsync(new ResumeLanguage
            (
                id: Guid.Parse("3eb9b099-5da2-4aff-8654-6f943440d5fa"),
                resumeMainId: Guid.Parse("63e6ba57-5514-4682-ac0e-5e9c6bec5c5d"),
                languageCategoryCode: "998936bf07f541f8931c9bbacf3dd81ee0b8fabbb58142cb90",
                levelSayCode: "23dcd525b24e4feaa39395c3745f6b27d9fd405f10244b1ab4",
                levelListenCode: "5fb9b851595446ab9a92f224f65cee61c1a595569f7d4c20ae",
                levelReadCode: "1c5a4240796044c3a2d4bc621b6bf61ad8305d0ffc2d4586a2",
                levelWriteCode: "3ba8d2d848c9427a89900d23138e43682745f586c88d421ba6",
                extendedInformation: "2181bfff9d4e4493a21cb8557f92ceb86340e8b80c394efca27d8087416693bb9e9fadd6f2c94f8493f6bfe4ab960444a292ede7c9d84123a627863f9fec6397147f37cc34274fe3ad413291bcffe172d1422306bb05472ca34b55bb6c4e0108719cb2d0943840bdbfe9ff5878ea0e0a0f72029bba6f4b24b6f2db23a9000d8156ebe675451a4998977088f8054c07b4ec7f6f94aab644b39f73a2771c7f0692274fb27337144bada26cab1feff19952f485f12f008a4508b8cb8791ca70589589a293a416104430a525fb37ab6bda22d57ad984c9204867bf7129df0f0cfa075a674adab1ec465589d67794ec124198749fac57cf4443768874",
                dateA: new DateTime(2000, 8, 21),
                dateD: new DateTime(2004, 2, 2),
                sort: 1801958909,
                note: "be1038261cd3456b990e83e2454491f7786316ffcba640dc94e7ca7b60c110e1641eb7eceaeb4228a50cb68dcb33c91bad52778652b54f1fac284f72683ccddb3984af2da3c74c66be7082c7041e79b461d358c2d1764943956400f1700950980666ed359dd14f0ba3588555b81f8023d4c291a72d504808aa69145decefd056dc11a951f7b54452a1e4c0898575bcb567d25f2197b9407d88ba3b57f6cb45bddb8ad4fffc0b4879a5b928d380a48d8fdf05210bf70744e7b699f9c9e80d1bc84c58776e055949658d2b8f21a10701da835882ce07754a1f8f801550f8446e9131ad43ab40db401488dccd24eab8b9f229e8f002e115421eb542",
                status: "c14503850b924c1a8501aa1b08bb425297fec24bcf0c41c89d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}