using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.TradeOrders;

namespace Resume.TradeOrders
{
    public class TradeOrdersDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ITradeOrderRepository _tradeOrderRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public TradeOrdersDataSeedContributor(ITradeOrderRepository tradeOrderRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _tradeOrderRepository = tradeOrderRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _tradeOrderRepository.InsertAsync(new TradeOrder
            (
                id: Guid.Parse("44f9aacd-96b7-4515-8d56-302eff79c73a"),
                keyId: Guid.Parse("74eaf475-4f01-462e-acf6-55b945cc9b3c"),
                orderNumber: "62f4e51447d849009de59ac73098599de5c8eee70a8a4014b4",
                dateOrder: new DateTime(2010, 10, 12),
                dateNeed: new DateTime(2019, 6, 5),
                dateDelivery: new DateTime(2014, 4, 8),
                deliveryMethodCode: "34e2aeff836d4b0eb15f0a20a90525001d89a448a6c24d64a1",
                deliveryZipCode: "159597cb51e44b7cbf494bba44d06f657968268cdd04476984",
                deliveryCityCode: "54032fc5078f465db90f42ee67a85d8b46d7d8ef8a82482488",
                deliveryAreaCode: "207d0aeae9e443c4a57fc161f03d98615f717a5572fe4d7090",
                deliveryAddress: "801ceb3681b8417a8b9c96c457bd8881ed50e74b555e459e9f",
                deliveryFee: 997316260,
                userName: "c627494424414bfd997e8063c3004cd95314a44f520347ffab",
                orderStateCode: "7646004d0906477b9a0a5eb03c8df78d55af576c44ec4d7b9a",
                extendedInformation: "0dd8e16de01642a6bb1bac55d6c5375153640c56a6ed48f9ac4f489b9866ff9ee9f8188267744a5d80fafd22ea3738a4d214a06f1a344b36aa0c3668eb926bbd3f26645c15c74b26993f458844414afd25307866b2a241c78ed6d71ef684c6bfdfd0e647cee940bfaae0f4e2bcc462a5e22c047024dd4c93bc6e09724fdbc36c56c55928a1ff46a8a22b5ea713136a693ad4b355d8324d99b4435e61637788e3d9ddd30b2ee14f1bbd77fd2494e6330e78deaa7c9b474b668fddc5f4d2c43c917ad7cc263a604281a55f89d5b8e60b742c80e36b9aac4ffab8b93855533017a7e8e6e63c7e1544699335336a31e84a92c3b9767169c047339361",
                dateA: new DateTime(2016, 3, 25),
                dateD: new DateTime(2018, 3, 20),
                sort: 362361620,
                note: "f11d101436ec43b69878a9c493c02e002c553ffa804b4581aa1eec063bd776fc0a1e6af4defb41239993213eee4f6530d7c1fa8fa9564922b4446f948350d0e8e46bc78172604ffeb5a1ae17e7c90587d6df93f2453641cd8800fbf4f93e551c94f3802061944f6db9504bbeb69869845d47e125b4ed4e0d95f88a9b3b98d99f16533c7ae33f4829930e1118887252f7b5db7cc96d3e40be81f21d2708854ba07ac023cf8d5c4d8fb351a0aac1d8e6890f2710731c6a423d8ede7155ca6f02efeb7ff887db5547229ead90f0ed3509274d7115c60e4a46c38ab2c542436e13c7e2ef44c9831a4649a13d31f94b7fefaa1ce705846a7148e988ed",
                status: "05e1f36560114d439a7a529de33bd6bd716192f7aa6a4221a6"
            ));

            await _tradeOrderRepository.InsertAsync(new TradeOrder
            (
                id: Guid.Parse("a509286d-15cf-4671-80e6-9c157ebfc3cd"),
                keyId: Guid.Parse("591e6a63-e472-4816-b0a0-80466287f38d"),
                orderNumber: "796475b2ddf343f4b64302639537e28078621a786aec4d9cac",
                dateOrder: new DateTime(2000, 10, 13),
                dateNeed: new DateTime(2009, 9, 18),
                dateDelivery: new DateTime(2012, 3, 6),
                deliveryMethodCode: "741e1ac3639e436380ab95e3cf1d885afc0483cb605e4c458e",
                deliveryZipCode: "91714c525b1d4a2d9d44a3ce1a0b340d7ea4c16821f1462abe",
                deliveryCityCode: "696a0086abda44bfb76caf719509ee8789a26af20c4d4d2591",
                deliveryAreaCode: "11a2938737a641829dfa5b40f2d5db931581dd17e1e443559d",
                deliveryAddress: "3d4be0686db1448db97788c8d675feb6747b9095e56a49108b",
                deliveryFee: 1691559050,
                userName: "1db6b8c43f854a09b99864f72113c19702d7083aa3f648649d",
                orderStateCode: "b74c94d81a64467bb36d6a00e61f56d3b656066fd92c40ec84",
                extendedInformation: "5872c336e7fa4693b7790b9f76bd87abc42ed00c88c64b49b4ef46d73277f208883697c4218846c5a5b9bea03815b226851a3fb268574289ab84643222c264e2c9cbe2fae2dd48408021dae2671296b305e22107742045b1bf715fc139659f65d4cbc6ea9c4d4a3eadb43386f33367a487c8bd57fa3543348c7ce34c1a4b7ec9a22b5a31e0574505ad19543dbee57e8b37fa346df4df42eb99cee00d5bdd3f89688ebfa5e05b478097e8e23e3fec233f0b7dfa8bca1e49359f487e1c0d2d294fa2353bb3e2824a84aed6a29ca834812d50eda866132a4aaa90c801177f7d614e85a7ff2462e04104bf22342234ccac54743b6a9deac945ff9ac7",
                dateA: new DateTime(2013, 1, 23),
                dateD: new DateTime(2009, 7, 27),
                sort: 58519380,
                note: "8e309ce9e8bb4a7680309bdc9e8ba68e47b05afeeac2496a8c4e69094585fa6a5b8e71528c11416289a58876ac837faa7b9399fff8f24f849c34f747ec0f207bda46b3601b7e429bad8f18b4558c6fe0b5f8a6a9ca574d18ab8a72bbf9f9a051dd3de1ee436f4a36b513c3e0faeae0f28e49a994594a46cc8ce45fa8a9ae0b417ec52f23241543d4a0f03a74e9f09e6622aa826cfbfd4f54a572a33f8e12c7d54118ecbfae364761b891eeb5694c41a674e0a912a4c048e3bae99a872a009973b5f465e2079841bd8f042e5000bc641c0efd4208dee04723bdb1f33c91c484e453580306052b41e195f3118812b4db0e7cf6239db1db4b8984b9",
                status: "c9f57f1a502a40cf87903301186b8a5fa6fd11c836344eb197"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}