using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobPairs;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobPairRepository _companyJobPairRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobPairsDataSeedContributor(ICompanyJobPairRepository companyJobPairRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobPairRepository = companyJobPairRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobPairRepository.InsertAsync(new CompanyJobPair
            (
                id: Guid.Parse("1442b59e-0be1-4518-aa06-c4d34f732cdb"),
                companyMainId: Guid.Parse("bb06bba1-d2cc-42a0-be07-d006593e79bf"),
                name: "0e86557a03d34462bd08e5232a05d85f86b001f7cc3145f68a",
                pairCondition: "384916f7f9e44e5180b4fb53bc383ff667bc0a0db3534a7fb3ccb99348250aa05dcdffe6717e42f586485c44361c64f7fd31a5efe71e46f7b082fc5c6d603310fb039a0fbc7f4bfbb58e5844712eb159b7aeb98436c240daa6a98bd63a8514428203de902c24469aae722bdce7b6cbfb049e5c947f2649169bc8e5044735a080c7003bc695854136a883bc2e6ead5efb602a74fe6dbb445ea7318b7b8de819f2215d0d7bbdb243c792eddb5bb7719add31c6a899bca3439fa090abf0a59e3d4fa2b31723673b484abda22b664db53a5f751c9ee59b8c4c348b77ec42a1c5c6ac538dc3444e894b24b18c20c911287c170657c57d2202406f91a6",
                extendedInformation: "b11e4941c4f2458789883d26aec3928400fa831d6732474c8d79e81fd16d9b8b01d26e515c0248b189c451de0285eb921aa2d30a741c4c308044ba0de409b5db78980f124a3b4af5b0128631107fe9a41955c71416f4412f85b26283eeb559bc0dcea9b3624d472eb9b176ed7ec177eb663f1d96784346a7adb95971b7e07cff27f5d92699ac4c08b9db34367594640de4daf78c92d542678bac47f7ebe1349d1eaec1b2dcef4ff7a008f44403e01711381fedb591364065a17764d1d175c7267a18cb83c8d945e1935fa3e3d6c16a830fb1df74af134197a5fc2a84bdd8b6ea18c5578ac5544b3d9fe50e113fc860f17fecb26004e44dddb399",
                dateA: new DateTime(2001, 5, 14),
                dateD: new DateTime(2003, 11, 5),
                sort: 487162405,
                note: "87e10bf5e96a47c494a34ef39c551811c990665076b8487b9b5d082d3df9ca4ea7014111d38944ab95be2fb13adba0545b75978bd45f415c8fc95a63df5961aff1153a1971964c9f8faf6cf1006668b8ed8503be63524ece973be6cb94019ebd5024d52f324046dc955efb175cff9b5451303742b69a48f49f8a4d17b21fbb0b0b0f447f41d04040a9ef0f360eae4bf54fccfce7340a497d980323bb69f96db74b1d8b5397de41899ead3ce0c71b76cc5e60dcca9dd94f75be33a50192dbb4b544ed2f8d55fc4e87a2e679c5300ccaff7b832b01d7c24351a7064c6f8d30810088c429e779674ca58262181f8d4b1a49cd3c0b1bfe904c97904a",
                status: "aa4bef49dc9e4874a8a00c43aba1e9612c63862bf8e5445ca3"
            ));

            await _companyJobPairRepository.InsertAsync(new CompanyJobPair
            (
                id: Guid.Parse("95a3b9dd-d316-4aff-8f37-aaa6ac6c6fe0"),
                companyMainId: Guid.Parse("9903439a-1dbb-4afe-97bc-69776a3d9696"),
                name: "7cbc8e50c0f04c0aaaff7c99a079d141155271a080bb480bac",
                pairCondition: "51a89e1c7fe44461a8a16abb7014bd224c4c461176604ba6b083725ff29048f68a3f40f6a49c47019917ae9e2af2396d69880ca301f842a9853c901eba4f70a303c1c6127f9b4239be913fde7e14741456e01dc2d0d54a20bf914bb9f5f8e154aec7c477f9e149e9a2059dfb9d0e1180df112bdf199e4db6a9247072287fe93d443246eeb4b0481ea90b387b684de2504516f9c0fa1d4615b82aa706e6b8c0f47eede55a205642fcba14b3068ac8588c65c43b6743b14294a4c6ad43a4180728b5b5a592191d4edd8031dcff66474f2f50f3927b10254eeb93687ad333d528a2969e83ec4c834b6983a0d5579490c8c1997d00c1e4d345f1aa29",
                extendedInformation: "9683d36854544a27a0f5bd851583a40e03e483f05d374a4dbeef56dda3473e3b64f12de584134f67a0fb7c7b99e355a985b7295cb1594c8190d5ad6bff171fc40fa5993f3fe142eba4d93297cd48c1783d62f788d36b46a6a82a4436a3a574ce81d0e3a85f2b45b59e936f9751f5e9a0b1bc0ae4cac94fea8c46497ae5311e2e371a8944a18146c19f5cf9c312f1a04bbbfed184e2fb48f881c90283e41d4b055044c86dddb2405c8e87e6e39a11cdaecd1c8a7f19e44e1187e30356a6586a97b1d2d333392f4e7ca617eef7ce5cb5c27188ac88983249778e0fc5296472bb8b750a5dc44c594b25985ab3997f2b8638c7c9aced5734492fac3e",
                dateA: new DateTime(2004, 9, 9),
                dateD: new DateTime(2010, 8, 19),
                sort: 1608014923,
                note: "b51ff769a1e7477c805678bfae4534f92e3cf93bb1e8477893e0a7e8b434bd505b8a2b1dc7af48a69af346be175c84076c11f88c13d4496a8622397c3a8cdaee877dae40b5234365a74fa9f73f5f7087f560aedfe1844ea69267f638df4121de49e527e4cb364b24978ff8a9c8a3ca6858f2c3bf3dca4394a21ab3efd8a4d22423493ddea0ec4a009a0ef0df62834b37a478968eee8d45d1bb7a4850c02b77cea480f4609c824cbda8e211ffd1a202ecd099ff8b97404fffafea4642b8d694d3882082932a0146669fa7087345dbee29b46a43c961a846eca97263f8202befb0eb1cb372ad5142f49465dc536532fffa823058f78d924409862b",
                status: "fbf7c885db9b4849802bffa15909dd1c06a1d4dfa95944e7a6"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}