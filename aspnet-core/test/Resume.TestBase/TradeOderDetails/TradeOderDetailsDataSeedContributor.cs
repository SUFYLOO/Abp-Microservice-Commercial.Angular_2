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
                id: Guid.Parse("62e925f1-1bce-40b7-8b67-fef6c7e23393"),
                tradeOrderId: Guid.Parse("fab42f0b-59bd-4a99-ac30-f078713c943f"),
                tradeProductId: Guid.Parse("b0ca9140-ebf5-4007-9555-393c74153bbe"),
                unitPrice: 1626049157,
                quantity: 256325325,
                orderDetailStateCode: "54559be2e062483d887b760d3ae8636a6faec25ca17d417ca3",
                extendedInformation: "42d75a35170d43e8ae067f91d8dc895eabd19ce320924d19bf02a4ba28715f569dd9ae4ec4ec41c78ed0111f91e570a5deee54acd2f54ce3b21ca41fe7ddff44253446bb6cdf41fa98855c9603e8dc55681cc3ee22bd4adab3873ff775e17d15e81cdc993b0b48d49aea6378419336dca786cadccd394a79be1af6a8288170242ae43fa4aabc4bd5befca902df9c6deee5836fc6326047689d6bd160862fcecfe659d7627f28445d9df4553e8d01b6d3f62f244730e944a6a81134c8fb04b6dac481ee129e044de1a9e5d3373969349cfed25e4f5acc4275bba1e416b7b530c7612adfc0446a416e911f1b5e9b70acbcc73b0b3b89344e7bab44",
                dateA: new DateTime(2008, 10, 14),
                dateD: new DateTime(2015, 5, 25),
                sort: 1105656464,
                note: "697d9e5fcee347cc89be0f424c66636ad478c52ea8fe44a5a734fc8d9a3784fd5abf8152476b4d6aa5ecb62fc453a7a1e0d0b7cd53594e42b06d16bce2d4bab1d3dbc4a52dd64b3e9e997981e08ebfd4f30ac5afc9704dd2bfec1d0fda6aa26616a6968444654a96a6845a67b1a72dd270b3e9e70cdc4ecca70938c400a8d436faed89faea434fc1b1bebf4383651c2b89727f4663ae495a9fb313231573ba4a7cd64d368db4469d978cf03a08b6ff14113db8e75a4847e2b2b1a1cf9f8ce0053c34534beb9e48b489f05956c6d13cba8f83bfc56b9740c4a72c1b7384a144f9f4a6807eabf04564836059485b0ff7e709bc58b8562249c59d47",
                status: "e1e83a99327349abab429f8c4cae52bdae725ba691da4c2ebb"
            ));

            await _tradeOderDetailRepository.InsertAsync(new TradeOderDetail
            (
                id: Guid.Parse("b508e74c-5247-476e-983d-71b63229e5a9"),
                tradeOrderId: Guid.Parse("d99851d3-62ef-44e2-b387-3fc27098b60a"),
                tradeProductId: Guid.Parse("e2e42f76-b67d-4f7e-bdf4-a2d416fdeacc"),
                unitPrice: 1340051948,
                quantity: 1411389050,
                orderDetailStateCode: "9cc4208029e0430687fa4554255b23c0fa339e168d9248ce8b",
                extendedInformation: "f699d9d9ada146c593bcb7546ee440ec84fd6e433ad2400d95263e31d4cce9c53eb414d00e764d78922537064eb8dc63b27de009733840ffa71ae6187bcaf7bbce45d432d1a7460e879f8ca36375e06eada4888398fd4c2a9a3e79731bee3cf346e6cdaf080f4794bfe60ab49b5568854d145dd49f1440a39fa86d375f7aba1c5a2d5062d5fa47628bc18857e61c5c3c647be7285f91453db10b0006fc59cc3a99673198709448bda623904e7105fa7942bd9771dfc14ca98d88de959e803356911f24d18549447f82a45e9df70498fc960fe26beb4f43f3b0abde52d0b51458e665530e16944ea6ac5237d191d47361538193dd38be4319a1cc",
                dateA: new DateTime(2015, 11, 7),
                dateD: new DateTime(2015, 11, 2),
                sort: 168276310,
                note: "66e7108b9e6140ef94ebf8cd350331bb4cca5c731deb48c3a7247916c64ae0357076a56700fa400e97fe2e1e35f6e9f7536e2837f41d4ab2bdb2978b815257dd5b3d8f5e13c3407a817bf067f2d5ccf4a73e248157394f94b83691840ca8c40205d118b1d7fc47f7b919d87e57b3a7bedefb420fc6aa42c48db7cc4d30377066fdb0ac3589bc4b1ca23649e6adfbb4af86c91f1424fd49388d983557f37379e137fe9cdb7cde4a94b3d494a777bb33ab75e51ae8af6842ac9ae0d06bb5ed4c525f0606e1ef94401b84a3cf14b0114fcf5e6bfaf29bb04e99812601c460e557120b6c8060c98f4a65afa324ad8cd9e75f27b56a2de10b4d7fa824",
                status: "6e7eaea37b5541b3a23b45b036af5a166ee239483f0140dd82"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}