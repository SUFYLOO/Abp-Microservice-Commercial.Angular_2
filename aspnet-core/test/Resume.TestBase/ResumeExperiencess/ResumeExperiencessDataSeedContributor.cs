using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeExperiencess;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencessDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeExperiencesRepository _resumeExperiencesRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeExperiencessDataSeedContributor(IResumeExperiencesRepository resumeExperiencesRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeExperiencesRepository = resumeExperiencesRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeExperiencesRepository.InsertAsync(new ResumeExperiences
            (
                id: Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"),
                resumeMainId: Guid.Parse("4f8d40db-1cab-44a8-9374-ab1a6c91279c"),
                name: "affbae0f79194b03bb02effb29a1268eeeb679183d084ac487",
                workNatureCode: "c2521920f2484c06bcb984612acca0e91ff652380cbb409e93",
                hideCompanyName: true,
                industryCategoryCode: "0242aa595c0f41d991446aedf383d756772b1298faef4d138f7bb5f6f5481c92ed007336e9314845ba6abfc8ca9f256b5343ebf473fd427a99e7947ec8de980eac7d68946d134188b4c808d32840798f39b31120d69b4830b61c6093555c3e56b2206627aa10468986175d24e684aa1659d4f436d3a44670879767e706d7519d0e18c9c7a80d4e439a618ed6c64df354fe2d6a35d9b24a36b97f110bec71987d069f0414eaf642ab864be6d3c24dbaace8b01a35ca864cbab1a00e5764b6d10cc840ecb417654be3bad8e91c99250388c055ea38de494d6db3a0c29a47f1010c2ebf8f309492482c8b376ba16f8253b1079a7f5a604049fdbe2b",
                jobName: "293d88fa227c48ae93140f9440562c1b66f3ea6ca3e94b5685",
                jobType: "8de29448275e4872899938a575089ea1e2c444bd6f964d529e3506f86326f9c2daa052ce36e44b63907baaf6d69a3f54b314b3e1c3e04cdea6ba7238a2fd78daa56bea30af764deca98155f2a0ee6f8e8d8f561d8b6d4889a207bfacef4da33328cbff9919674c308aa966784c416adaa9d1371c3dd44117a452dcdd92116463a983aedd03b24c82a01c992906f12d94a52bb2bb900a478eae76542f56830e80fe19bef24aaa47b38393bf803215d55a39e589475f074f87b9b1430335e4b8407153969b95f44acfa4557521d3db904ef2db9257244a40529776ff20b48987fb612a68ce5d98411bb03f234cf3bfbc211af7c43fb5424ced9e93",
                working: true,
                workPlaceCode: "a07c5da3f7d548daae0cb73bc195a9819c703c72b1e644ec9dff8799220077c7bfbd18468e494cfda6487167f939a7b0fbbc22e2a0b54af7a47f61ddfde3adb0c6ebd904970f41c5b79cfcc2e84b2ee01e6af2bc3d484cc2966bce012e7943c65183704920774f69b06b3123a99632e28eba3e7670714a89aad55a7884197d3c283fd0a583624319b142ec1fade10d11b35009200afd41688e9c86ec00c5211e1df1bec1ff8144da957adc549627afa9c31954f519e84654adc84f9159645b7009f696217d154fe9beb872a285dbb874f4446a97035a42daa4e2f106528c07829b063bd81b7046bc99870e88d5546334400c87211cc44ce8a06a",
                hideWorkSalary: true,
                salaryPayTypeCode: "4c3fa48a607b4df381ceece751a7c30fc826b591f8ff4197be",
                currencyTypeCode: "354bedc165f447cc9a95cdf50ba8844f05543732a95b417595",
                salary1: 1022568934,
                salary2: 1695398152,
                companyScaleCode: "7c4fa7f1dff74e06b57c3c5b0def1c27f5ade22539ba4ae691",
                companyManagementNumberCode: "27dc327f83c2473a80830d28e480897d1bdd098523964dc689",
                extendedInformation: "dab50fd287cb43039e9813847a3dc125ff6026e6caa14aac9a94e776b143dc79f800144901a84aec87592f45081ca73773a00747aed34f388d1e60a61743dfa89ff6e77115e34c36b7a92cd936e9e4f67701fc4c2f064d3da85f60d8ee27490a4a557c5f78a542b98e482771297cda66d36b361895ca438d868c7d74f02f0066c6c7f69a52ba480da6bd0a9b18de9b0a626ff57151e640e5bdd0ab4689a9f5bf2df3cb1da2ce43279348579236ff445e5e84c50d2e884b55aaf6d43276e26eb88b56aff3379f4705b5fdc60e0218f37b2898dcd41b0e42058b131c6444d426c706478f79977945d88e6a3ad6bc905a2f381ae8fb34da47b2ae57",
                dateA: new DateTime(2006, 4, 10),
                dateD: new DateTime(2019, 5, 16),
                sort: 1407684673,
                note: "81a9320d5b7c4480bd28dac59dbfacd977e737af8d71424198a37c5e1142ac732061e8bd94b7490bbc05e2015eeb34536b0bc7c9f6de42ffbe5efb819c382ae041538678a46b4371a43320350a01cb6495392a4566c64f9da652e5515e1f39b53fa29434a3864e4ea11bc1525958bcf36fb8da8972a641ac94fcd6819caacb66fb4afe002a2f47bcbfc99eb95c9b2a25b8e964c739844a6c8925973a5b786cc9ca28a2ca431d4fd1b5649d2a80782f5370de6d11378a40eaba9e4261a8d1b7883d12d63499e24fd88e0214aa8cc8aa6b44c146b00848427696664e8200d10f7bf3e89efea18d46a39ce77c9b30525c3e4e3d568f79a741c49ebe",
                status: "e7078b19644b418aa6d569a9cc8759a0c07ee24cbc37472c98"
            ));

            await _resumeExperiencesRepository.InsertAsync(new ResumeExperiences
            (
                id: Guid.Parse("010c82aa-6d7a-406f-b088-b7b8099b79f8"),
                resumeMainId: Guid.Parse("736ec002-5da5-4a48-9cb2-5a939981fe31"),
                name: "00cf0ca11116476ba4b9b267920cbbccde5bf77f1dd94f36b9",
                workNatureCode: "ce1b639de501489694ba7a71ce331458a8253bc2567a4d4392",
                hideCompanyName: true,
                industryCategoryCode: "8650a78022264f9baa5f1046ad9120e13489a590ad104c96932d028076dcc7d3adf406afb1e34cdd9de1d5922005a78eb5209102528248e48ff1c9c0089592de8a2bee44bea34c038860f31d853defa603147622b66f4bf8a40d1c972d7527d7963254a0900d42b79a1ae28d149481f0a989b4b204de4268bb9ff7b9f294453f8aa57a1a77f84153b1bbeeb1f4ff27f8503f18b58741401e9d0c91be132388108b56a46c2321457d8323c1b676ba5560479d42b138524019b8bddfb901805e62f6b3da66a89343b68f5c23ed20fa13eb5c61d947c11e49bb85e39ebdd3598e3fac0e2f8266b84ab8aac99a55e2dd63247756405d79a54b37a22d",
                jobName: "321761878c0f46de941c128e4bb52a2004846c28f0514c09b0",
                jobType: "e7c0f18d7e574c58bf32b6618e1199b3e8257a3dd6e1412b935a5b097f745fce0494e2781d3a45e5a1f94329266bb18dfd092c54b1ff429e80585fa644064581cf9e61f03f2e4cc294b62ca6623b2533a3b08df7deeb44dcbdec2a2bf19bc73abb6c9314ae1d4b93a6052307bcc0c57bbc4dcd9915094c8cab6d21a9d1ca350a86b39445880e425792fa49b780ad0b2ace3a09dd87284aea9b045b837e3ecffe1bda1c189923464cb549fdfad7c307112331701875fb4946949a99dbf4af7823515cf303d2354b7b80d30cedfd88dc2a6cbf9e4fd0864fe9a906153d884a5d0e74d52949e6a24115b19bfb9e7df3315bebc6f24a61e64c6eb1c2",
                working: true,
                workPlaceCode: "222ae08921b6468bbd08547e1102609392010811a15e4083a565a0a30acdb00cb8c32565bf984e97bc8cf51250a1fd7b89b95412f9b647a6a6b837e2c658d8a2f49eca29275b4f8db379a0bdb7e389a9a2f2c0e4487f47269b635a40d00003eeeeaf1d95db154323a374733f2bacebd4dc7526f9735740ab9c1c19c762d58f6da9ff24b14c344bb0a2878a6ce34d7c93f7bccebf18a8487092dae1d8959bcff0f23bb6844b9340c4bbfc516f677541e2e42623d7278a4e1fa27fa53d1b22afc39d8f55a0eb8d4274951517fd5f9458377b972483d09742ee848139bb6239e053662e242aff9d43d38dedef10822f551fee638af9d6054e87af0a",
                hideWorkSalary: true,
                salaryPayTypeCode: "75aec3d344e94934a72a0ac71a88c13dffd1d7fa80f64c35bc",
                currencyTypeCode: "11e693cd0f264b14a7154d59b1d2b4106b02ac1bc9f240bdbd",
                salary1: 342141777,
                salary2: 829947600,
                companyScaleCode: "d6b6a5fb463046fb890166127bfe18d31d5e532734624096a6",
                companyManagementNumberCode: "d5e08b73b6ef41688a0df0c5b7c1962d7eaaf349b0f64465a7",
                extendedInformation: "2e7e2af975a84241a8cdd4069c45e46c642056c8e80c47f78cfca5ea1f4c7ad373d48c2feed641298019e3c0515c538b2ebf99a9c39c4cb0aad32d6e1bfb23a7bbd614e5fbb34ba28b33d9e391e1c934d77ccf662e224f2782e57a51dc586eef546a71cd9a7d413a90ed8b90c5902a9de29e6f77b1774854bc9863857f290e26bd30b9f4b4dc40c19429f606953568934b20f610fa8d4e04989004f4a8b41f54be6100080f6f4a3884e86d632bd9975d0d5bb7387c5240399cfb6321547ef1bd57819825ff4c42bcb693a0fdac614e07bf24e9742c324a0eafea96ead5da6fa94cc2c2b6c7114eb88f7a9481a7e2ad29c398df9be7164df59e54",
                dateA: new DateTime(2003, 9, 22),
                dateD: new DateTime(2005, 7, 18),
                sort: 332739896,
                note: "99dfaaabb50340a0b1448c746dfafad9575a386461e94f0eb4ad79c786082fbe3fc5560458c74892bdfeb46fc6e2905d5396140a69a9453d9502ae0b2ca7ffce6dbabd4d69604abebcb1166888cc026037fe032c268648448c8a14680a16ba33dbeec0bfd9454e8a9451d100fcdd5ad5a44c48af1aaa48edad3ef8f57527c28ad5c0d09894634488be91d255eea9277c5a997ed401a247d2a254f6af3ecdbe53710e913337dd43cbb820087c820212078db22a1b982c49cc8829450b80281cbdfbde47d5df9541afa1a3c563f71f5215397caf03a0b548d391031a89a4487109c7269768dc8d4b729a17eb7e492f8dce02781db46a7541019a33",
                status: "9a0c317ce7624e68a8453ce9252fc52a7d43ff0c0ee044b592"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}