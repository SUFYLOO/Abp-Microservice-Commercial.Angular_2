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
                id: Guid.Parse("fc32c3f6-d303-424c-a489-da234ba6e88d"),
                name: "e3c4fa0f07a24f4797e2a5ec76c9f79e78e36ecb9d3d41a7be",
                extendedInformation: "1eb3143f2a984b6bb6b38d41065e420da942bbcdf77445fd996f331a8dbf7193b641c0079e4342a3bcc32ad5a199301257ff50bc47ac4c04974033b0d20e3ce1884c36fe265d404281cbf2c73bb135e482594f59c551476ba9d41132a54d8f261e52860e00894187b1f7ef91af1a49558d732058ab704ed08113de288cf62c97dfe07154ad944110bb7ecbcbc57aa8204e6fc7cd32d6440cbb4c5a364f5f27622e87b9f48145415cac1b8e60dc423b7867cac4e81c0541daa1c842212c9750a1ea1709cc6f554111adb77ce45ccb6ca6054ced3da02c4fde88c7492f621b985f5e0ee67d5bc44cfa92c66e824f1605d10ea487b1a8f24d51908d",
                dateA: new DateTime(2006, 4, 8),
                dateD: new DateTime(2007, 5, 21),
                sort: 1521150913,
                note: "fd61532e75f64bd99c688224f01009616dcad7631a2e42d681cb3e14dc77a64af081c60396ec405ca9faa34b63c7df3c091373d79c71433da983e0705aaf4cf7262818fe0e0647009a67018f5f23cfa06f32a49b4af346b494a19fea8065801a74fd18d66e9a43caa60ebbc0f06b929664b6af816781461db13a35d26c709dc77f482a0eb5fe44e1a056fe692d0e65fc1506ad9fada9472b9b8d7e8d6d1fe7fed3d61a4336514ce2ae164c103b6ebf9e19d652cb653549b99aed4f84e6b04176e97425c5e1474429991c98e66d5ec09bbdf1452a09a549f099c80c803b93d94b48ed65bac28d4f19a49e791759299a63823bd27dcdb541799ee4",
                status: "3ab64ae59f5841fd9d4489df56a7afbe643bbd6d78f24fdfae"
            ));

            await _shareLanguageRepository.InsertAsync(new ShareLanguage
            (
                id: Guid.Parse("1a6592c6-5afa-4cf6-9f08-d95641ba4765"),
                name: "7a4a13cc73824123a97e458e4b21e04cde559c67450940a8ae",
                extendedInformation: "305e7c75543b45baae098b82d5bd63d3b8ed70b020904d18894a6ddc4c7ea97f674210768fbe4d308fd0a422ad45889f447a4148d6a3429e825140783e38b3bf98950954d1f640bda27fe4c5f7d11a2b5b7dfda8f9ef42a79d1c26472704f07ba0c250ebb00d49eb8900cc1322b81819ca3dfb9c24a74985932bbafc7bb64a02a762dd0636d7403b8492b9908d04a78b937a960571d64dbc83b1b46b96ac120c07f3cdf328f743b3a7f1dfa2226b9923ecaf7296c9ba4ffebfc0591828e80c4a4896efcf2b4f49fdad3e5ed4032b940a7bd529963b2b435cab39b0d1955a8bec2a3c5af1ff3e49c2bc1943fcc80ce3f3ca1b903e8a4a4026a75b",
                dateA: new DateTime(2014, 1, 15),
                dateD: new DateTime(2012, 11, 6),
                sort: 351244103,
                note: "75873730420a4dda8b24214253d7a7b57cdacf156e81451aa8c70b810a1294c9c1e89e38904e4a53bf38101e72ce17e0140e360dbc544488b3c79e639336279edcf46a249c794a44b4225fec78688be39e6d753ad1e84eb094d75a997db2ab1f68124ff49d994f509c6f473987c19336d932c579805d4fec8f10ecbfead1f82ececb3c8c96f34b9c92c2eb79b1a2ac184310902b12c34e2783f1dc67d3256401057cc30dd0de4fde8dc63725dad061022039a68e2bf84571be61c980b4737dd1078888236ab145afadde64a8f49b48806aa267dbdba641beaebd29efbd2a1b47198da9ff26b74b7cad4a6513f18c21745b2be11084d9429fb1a4",
                status: "737f5adaa11444369897fc9e92cd12bec518e3b127a044609c"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}