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
                id: Guid.Parse("e14c0c92-e195-4706-bed1-22cf7229428b"),
                keyId: Guid.Parse("edb0be41-c9b5-474f-98ca-3cc2dd466462"),
                orderNumber: "1a467b57ecb548e692c5da39f023bc8ff76e22f9820d433e90",
                dateOrder: new DateTime(2013, 6, 10),
                dateNeed: new DateTime(2021, 7, 22),
                dateDelivery: new DateTime(2001, 7, 19),
                deliveryMethodCode: "576d79c898e54ef4a43c189acb71255b800d3759b77d4c5a92",
                deliveryZipCode: "5c5bf6efd4f84c86b5c274010b150a9659a7d5f737b94ab4af",
                deliveryCityCode: "c60236130696427fbdaf62fa688287ba7460c159373140cba3",
                deliveryAreaCode: "143437da6e554b21809ac78cb3e6007b4f9b74c571fd4797be",
                deliveryAddress: "f293273ba3dd43adb7d553d933c5c885b2e20728fcc142e39e",
                deliveryFee: 976020096,
                userName: "df35e88e77434b39a9d0ac66ccef6b8bf33a9466e86245c7b4",
                orderStateCode: "0e385a12483e4e1a928e965ecd0eb8d829d46fbf866c451bac",
                extendedInformation: "925ad4c49c48411686013d84015a9532b88979b2a4d84bf9a15002adc483a353c2d6fd2e14bc4d269dd53eefd2d40f4480c6339597994a86b23020e2dc4d38ae8c28f170df544efaa772ddcf593cccbed614dff65fd040fd98b618e7cf1c63a36d9078ec722642b1a8cbb9992aeeb2525544599ef6d84fd6a8fe63f58ae73b6a9a404ab7fdf143bfa0553b492c25847d34c96fdf5de74987a733d18bc9a29ba861af08f252ae4cd3ae17753cab4f36abd5a44b46d0a94f76a36275622865d03efdbe2bbf13774e989c272c3354c13d1c0515fa096ba84feaac20c40c6dfd08d68fff822ce44848c18013140cf9623ccbb6d64221c98349218957",
                dateA: new DateTime(2000, 5, 25),
                dateD: new DateTime(2007, 8, 3),
                sort: 292358006,
                note: "a545ec6d600444ee9311d6b683760f07f964dd973776467d90eebd1aa2db7398e26f185406fa448e92321214d4d9f3a1173c3057046e4752aa07bd649de1a8548265fe00da6d462cb6f5ef1600903d611b54b3662b7e4d5a9eaba0709c8aa4f0e50e6cfb5dfa4e3080a02322f89cad0d182dae07694a4f189792ee1cefabc34b9e949ed8ef664c0992ca597e2f03e586f86c2a52640b4d83955d4bc4a513d6832474b403ff224c67baf951fcd1b4ccd055ef2934f8ad4348b1fd9054cffb93eeaf585d31020a448b8082cbabcd5df5ebf5e00be7fe6b46f58c69658c7719a382f5c91fe678844d2b9c4f7b5b484288475f3d92dc14e744578e3b",
                status: "b01cc954ff37414cba3ee6a025e1d6a960be94a9625d4a11af"
            ));

            await _tradeOrderRepository.InsertAsync(new TradeOrder
            (
                id: Guid.Parse("f49076a5-cb97-4494-b23e-213de50229a3"),
                keyId: Guid.Parse("60d0a972-586f-4945-9662-bab5f9a593ee"),
                orderNumber: "d2d1d026af0f427fb8e3d8b8593db29582cc721f24814b04a0",
                dateOrder: new DateTime(2003, 9, 3),
                dateNeed: new DateTime(2003, 1, 21),
                dateDelivery: new DateTime(2003, 5, 26),
                deliveryMethodCode: "f15aa7fedc3542bfb8b230683dcf9d3fe8ded4d7835f488a9c",
                deliveryZipCode: "bfe33734d6ba4d40bee4091a8a574431fe937e04639a468a99",
                deliveryCityCode: "0b4837f94eb44319a94c3f246f4b2338edc1202ff5d049bd8e",
                deliveryAreaCode: "ff6364b2d119407ba5cf85cff8ba3cca38fa25dad99e4465bb",
                deliveryAddress: "6521f1d34a964a398eb896b0834716b748be5410a24949568e",
                deliveryFee: 215341682,
                userName: "08dfceab278d421f9ad843ca369c5eb98b91c48c47cf463191",
                orderStateCode: "53043cc196d943879bc2b04d809a9547b5239f9139bd40518d",
                extendedInformation: "7d4577b72aa24b78a82f1ed08b0caa6267e0dcf4a93f44e4a8f0aefe9fdeaadfcfb94b3463c34dd8863d939b4219da1e41e3ecee193f448db3b1181de722f15116c7c37723dc43dea996743ab559bb9e93321baf7ad345c3a8b809c35743b6f26cae839eec5d428dacf190a8a3473df85c4f0a497dca47458219396eb36501b3dc5c92d4ac414e6dad3d3a3083796b6fbf15f9c6837147dc83474818ef30937606a5d1e941b2402d8adf14842fcc5b037cc1dc5b514441bcac7d78895b9e464dab958e00685740a4ba22fe019b4801fa38f98c814ce54ae28deec150389479a878576a43b376410bbe8083df612262e29c67e00e5caf4c5881bb",
                dateA: new DateTime(2000, 1, 6),
                dateD: new DateTime(2005, 7, 5),
                sort: 955681672,
                note: "c325366e613c4ef8b1a5b799747b4f14e769a80ba7f1438c9a3751a9ba73e749fd0e576bd2d94c6981820b119f312d980ff0df0267c14f5086c206b4db69d534c3272734cbda4afa9da77a0d75654fdb749a8de4e5f34dd5977c05bbf5c9851af206f69b595a4749b941338971f2e3d9cca74ab10edc40a6b6c19420c54caeee241e12cff798431b85e23c1b9f39569e049e6e3337974b3aa608dabbc80036c28f9d5bc72061406598b944e65a0432f5cdfbc73263ce485a873676d7876ab77793fc061cf604410485760632fcebc0edb08c6d90f28e48d994e562603b4a5d9918dd3a170bb242caac6c938b9b5d466391a3c707e4bf498cb611",
                status: "1f2a3306e57a4fdc958de89bd99b5a42995041c2a86b4b0bb9"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}