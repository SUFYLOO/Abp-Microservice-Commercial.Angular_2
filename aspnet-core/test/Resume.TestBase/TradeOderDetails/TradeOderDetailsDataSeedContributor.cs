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
                id: Guid.Parse("f72b6b8f-2a8d-4232-a390-fb0fcfa62e19"),
                tradeOrderId: Guid.Parse("7fe581d4-a623-418a-90e1-269865c4785a"),
                tradeProductId: Guid.Parse("af8f0e16-5c2c-4a4d-bcae-8ab25389fa4f"),
                unitPrice: 1650339558,
                quantity: 40037530,
                orderDetailStateCode: "dfdbac81ef78459493759f469812fc8f9b22afd195fc49b8a1",
                extendedInformation: "aa97576042c14c91b37c66eaf6cfca543647ad1416dd4595aed47ac6744a1472854dcba2a3434d0386178998a6a3c95ded66d1d80ce14c2d9b85e510d6b72577853d2c30ebe446a2b1d8eb9e33d3054e6f5f7d5dcd424a31a6b5ae4435a2e02640be1b088f3841c3bf9a38b85dfda009a2f6cb83367342408b91cd1d554dce0076011ece9b834254b57a924c7b44e395b637d216382344039e7ca12f2a06e54c9afa2c9fab624bd2a8dd51473da3e5d8d7c02ce050bc4770ad3885248eab072ab6c6cd46d693407bb4024ed2d9f893dbf5b14a7238784abaae14b6f69a711d358e3f222bc661491db0473b5e4c5e1f6ff3b8dfa83c074f3b88c9",
                dateA: new DateTime(2000, 6, 22),
                dateD: new DateTime(2016, 8, 13),
                sort: 492057921,
                note: "33048a15a7e44edbb22d746aecedeb9bf70a0504780e46bd9b6d1424eeb7400f11b55c02ed724c94be8ef627d52c9bbf319ffc7026424e57ba4abbdfaf1c2b811cdc7e0637004d9b9b0cdbe66f464078dacf7a4add494f9bbe6214a1c35f44cb9e4d3bddc4b64a69ac5b8c40aa279305a97155eb27cf4e149f410f71380c9eb25b8792f6264140c5bf412a7b558cbf89e49e9b41e2ff49cda6e65eb77cfef36c297dfa328e194b0482cee35afb328e951cf74ba6964f4b0cbb5024d15326142c6016c99e8f6b4a7db699f8553f3949774befbf1b03e14be88e03941ede7974dac1a67323a9b74c8ea8e809e0b5133406e8fd42f4cbd349909622",
                status: "caa9959fbabe4a378ad4423585aaaa48b8bfa8e0198947a3ba"
            ));

            await _tradeOderDetailRepository.InsertAsync(new TradeOderDetail
            (
                id: Guid.Parse("5312bd17-4a4f-4d4b-b859-2590fa1cd53a"),
                tradeOrderId: Guid.Parse("708280d9-0d49-4391-95b7-91b53257b6be"),
                tradeProductId: Guid.Parse("d192d28b-3d09-4003-82d9-eaac6a4672f3"),
                unitPrice: 468048627,
                quantity: 267783600,
                orderDetailStateCode: "52574f8a449445c9a0a52cadd2a8312c0e12364744b94e1195",
                extendedInformation: "635b9e340d6c48bd9e94ff96d8a065523c2ede727ba44833ac5ae825154ff367a43364b3a6154cf8b4745f3e453ee209bd2fb20618864dcfbbe7485547641af3f2b6b234c27e4e70a1be35de85df09a69860b1c0563d4e8eba54485d5b4870ca4304d93180fb407da86d5dfbd212adf79157d5fae322495d81cce225f999110b97cf2058dd004444b806230cdb5667eaeab745e4687f470e9381ac5975856d8ddc0b432082b4481689a88e781d21fde72cd3aa1ef5744fb7a1f51551ba843cbf500557813db34731ad50be7f43c7872598bb540931454050aea281342ae0cfc82e92b90f18e04a4790a0dd08bef0596128fe1fd2541c42bab3e3",
                dateA: new DateTime(2008, 1, 5),
                dateD: new DateTime(2010, 5, 3),
                sort: 1948904937,
                note: "c5bf234e59ee4a3e9c54f07058e0fb1726666de95c344507b67f66c6685f79a878549e70ab8b422086092b8a8fba190a1e1588fb2adf4660a35cc02fb1a7606b213c249b9ad3416daba5a6d08f6c6b350c84887ff8b54627a2bc96e2df29ae8c0a3844d1370445d2a64bfe1f22c23808e14e3075284e4b80b61611e939be6913aef27fd7a4c640f89d1137cc01f40c5b27062e5d38cb41619eea2575aa42ba4aac5d40b1d2754fdbaaffb587bdd8e4915d550c19d0e64f418bb2d4c58e4a8222bdd0df075a03491fb64ec82f0fd6b1505e05ef1df2fd4d3aa6291a7567aeaac8374aac00fc6c4285b4348116bb18d02924c2a0d29b1b44209a5c",
                status: "2562ff32c88e43609351240eab6830c25daa576f4116430889"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}