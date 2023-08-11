using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareLanguages;

namespace Resume.ShareLanguages
{
    public class ShareLanguagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareLanguageRepository _shareLanguageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareLanguagesDataSeedContributor(IShareLanguageRepository shareLanguageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareLanguageRepository = shareLanguageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareLanguageRepository.InsertAsync(new ShareLanguage
            (
                id: Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"),
                name: "5501a406c45f4c86ad90a73a01a5305f721bab82005c4cfd87",
                extendedInformation: "6ef41726b57c429b8c5a7a19eaa6ca85b06686f592214b959c41cf3b00883ea6c71ef15ba89643ffb1471b954de6de83f994016babdc42bca0bcea76ef6cf8f420f239b6c7784f50b5d7b7a41c4fe0271f54186a9a8f489d88ba8d8aaea827ba460fce6e85704b3696ddb552a3deaca20452795b449949898eb57ed4d662c192cf8ea7e5573e4b7bb1914c0ae1b3559a6f572b9dd99e4c5f81876b781a00be02ebf97354ecf14bcfbc62a2fa72cf4f3bcddddb86b09f4be79f0054151a156caeffe0194f64f04e4688bc575b2345f11efc65a56edeee4ba9b1df8abaac7cc37e5ccaa6f48a11447097095ab384da317027ea049809ee488d9a6d",
                dateA: new DateTime(2010, 1, 22),
                dateD: new DateTime(2000, 3, 5),
                sort: 1895827427,
                note: "648764da59db404f8d647dfd7d1574f457ed1889e0e142c79d1a08afd7db7f9227249343dc434760990533e1acc5276a5da004ca54b84390b43bc30a04bb381a67b98f8fe9d94273a8c5e8ae99906d8aec328a5974754288be75c42acc4c7071f596706c0f604062bd0d41e095f14676b435f53884ed45699cc1b7827cbf09a55d6b3eebb6384aa783392e8df074fc5115458aeb17f148bea03c6af6182f50c991abb1b7d43547f883eb3b2ca12cb9cd40b5d0497a204d08ac52790e8eb9026865ed0390e6ac4ec79e6e76f45529c99972bac25568d64bbfb6233c8189f5e01430efdca65d17423c82776d28a8576edaccc7bf90c63745879d5f",
                status: "3a4bcf67e47844a8ade4b7b050c359f3d7e89c6a587348a188"
            ));

            await _shareLanguageRepository.InsertAsync(new ShareLanguage
            (
                id: Guid.Parse("cda9d92d-7803-44f7-bf77-023a3e22494c"),
                name: "a9c4c0ac37be46cbbdbd3a71a9f09c50b7d6e75082e64c98b9",
                extendedInformation: "720e8569ab6d4a458a90982eacd7a9a412898c9f13884f298939982d74342aa3d70217d8ace54e4aa268d9103ba8f8a44dc0c6232ca74149bdcab76c6577e23246629862c4cf40709ca0879643a042a96a3bd4ca095b4284b2570d9b1ee23e3c09e562ec53b4499aa3bb5f334317bc854b1a501bdf9646e78a5ec81d9b504746bee378694c674d04acf69cb27e8ccac18d709d99c77a4909b9033cfcad43a89599cfd58818294358b1f86210f13732ec4c63e1ecba0d46f1a96bfb65972015b5ae5f8bb12fd744729a965d08d0e0690c025714aa024c4223b86ab540d30ecd0f30fdbb0c8ffe47469bdafadb91bd0e0eafac3d9efee04545bcfb",
                dateA: new DateTime(2017, 1, 4),
                dateD: new DateTime(2016, 2, 23),
                sort: 1630087802,
                note: "422de2d481ad43269527ba74612e60edc6e06693f793479fabf3a9092342d79a30d95f9f02af493fa37c37855854d048da889541b2a24fb687af91c73bdc5832fbbf546adc054dd098676ac27731716b2a451021f0634a7db8f75ed6e0bfc63b4b0affc84920465d8d71ad5222a10dbb7af5c26b4c354de3a0128a5f85233abef2eed16423b647c99361a19b9aae488005f92d65c8474996b43de5ab99d6e7cc6ffb9302864e4666bb6261dbda2a40f7dcc7136bea1645fca5caafb4de20e232331649bca3c445e8b41118093248c8aebfc448e219f6477d8ffe60972fca40e5f2641174b7d145e484a4fe4e14bc67ba769f3911cd264676a1cd",
                status: "38239306cc2e4f788cd8b1f9b18817448d060b364a8740588e"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}