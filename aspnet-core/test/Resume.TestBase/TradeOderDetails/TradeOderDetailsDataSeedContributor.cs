using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.TradeOderDetails;

namespace Resume.TradeOderDetails
{
    public class TradeOderDetailsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITradeOderDetailRepository _tradeOderDetailRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TradeOderDetailsDataSeedContributor(ITradeOderDetailRepository tradeOderDetailRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tradeOderDetailRepository = tradeOderDetailRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tradeOderDetailRepository.InsertAsync(new TradeOderDetail
            (
                id: Guid.Parse("8f0804e5-0fb3-4312-be5f-be91f1cdbc79"),
                tradeOrderId: Guid.Parse("766685c3-7136-4369-851e-2ca22a258bd1"),
                tradeProductId: Guid.Parse("4aad780c-8edd-4e95-9e10-8dd4295f6e8a"),
                unitPrice: 430895415,
                quantity: 378947654,
                orderDetailStateCode: "c4d69cbd044d42199ba2061a8924002d03aae12322e841838c",
                extendedInformation: "f456e502be984d96926a961c45bafcbf14c406ad1e794181813607829522b53a115674de280a4e54af149e10719244529d8971384ecf490983b989cf6223435eec4d0c1fee7f48a9a79caa4530aaf38d923280bf73194aa688404496bc6feab1166ffb01714c4014a1842eb2434f2fadc8765318b41e4cd5ba3d723fb6537969a1e956f0b8394170803c703bfbd8132ae44c5e8f1e664be5b7f3878214d9e5d5f4b6e0449ce147b59526ea4a3e8783af38644dd1577549e3a2b170082b1b7ef96615b7b4592e4fb28312f0706d951191a56760b6dcd44208854fb921cdc5900f738df668ccef4bca8dde9a64959fac85d81ecba7742b4650a69c",
                dateA: new DateTime(2009, 1, 18),
                dateD: new DateTime(2013, 3, 9),
                sort: 2090498357,
                note: "a810529ad5ab4abd99ac86f93e59bf77e26a184a2efe4c87a433643835c297681f6838690c7f4b5885cb9c663bdb4fd24203dfc9b9bb4768b5ee2e5404f7a4ab522359777fcd41fc870abce7ceed1a86fdd58b2085544141a056c13952b39d125e1d896a579e4d858324ab01267e273b0199618167b64a1dbae5faf976dc95c8ed4ddb2bebe743e89fe21aa5560d7a5aa457a17f18fc41b8826ad8959fba9f3fc2a83336266a4b84b56741beb1e7122fa716b01e823447b29f14b7f14b8e55773da7b5f995754f1bada45e592018a48eb060eeb0a1c74baa9524c5a21fd5e16c2b23164fce09419b8f7fce6dc899e590fdfb5bb3260f4a4295f8",
                status: "8f9853177fa54757804ca17f4941d9584d723b59a93149298e"
            ));

            await _tradeOderDetailRepository.InsertAsync(new TradeOderDetail
            (
                id: Guid.Parse("49b64dbc-456a-4d5e-bb0f-1c1377103e4f"),
                tradeOrderId: Guid.Parse("d07517a5-b444-421e-89a6-2eefbaf5cff5"),
                tradeProductId: Guid.Parse("45870e8c-d23d-4c63-87aa-e126c0ead57d"),
                unitPrice: 1536780874,
                quantity: 481211848,
                orderDetailStateCode: "f4f988917a8f4072b9195505542c33ebcabc5c604e8e4b39a3",
                extendedInformation: "864995bab1084885b6db487d7a5e549e1cd81ecf301043b4ac76bd910262c50305320ed95b53440eb79ca4d97499a1c481824d3ad0bf4cf5b8e1647fddb4e88a3fff3e0fd0414e4a962c4e92f5c75cf8e541dcf473ac4a349792da7dc666a374bf3e6bda5a9d43e6b40a4cb62ca2708ab947ed020ae24944ae333e4514e8c840b354202e937b4d229a43d45021389c05fa66af615a654aa68a3c5b4d0287fa1fcdd19ecaa63744ea92e46314a71abfbd97641346d60b4701ae688ce3ec82bee82e1f3fb0772e4818902c3f8715b94c5678b862260bfa451fa1888234f45fcab41f2c5a7a88384535ab32128fe76649495e73eeaec8284594baeb",
                dateA: new DateTime(2018, 6, 25),
                dateD: new DateTime(2019, 8, 21),
                sort: 181561436,
                note: "9a2286ed131648da93556355756fc50e25341aa7fe21485b8faabe5c9b3fd7503b4e71ff863647bc84211c7135e655999fdd3f972725477cae20842c810a4e8d1574f56668384c17b8008447bb788b813d03d14571814abfa6f3291f0a7d38b7f85df72a1c5743c3958ee5cd07d7c15a2f2c28a458d743a5ad0b5ef215481dbd633312d52c3747299a5fe095879bd422bff37ee7fc4e4b5bb24e11dfa9347232b1b734ef38874c12aeb5baed046faf1f18b35c5971f34906aeb29db45f8f6d721162f807de52492abebda704de617505ea3af628555a4b00af4c1cdc71fe2b46551006b1bdf34c7e9a8a243fad01304ef88f93273ee546e088fb",
                status: "31a6975b6f9841818ac4eff51d17b62ff3a3d158298b4ffbae"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}