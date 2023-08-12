using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserInfos;

namespace Resume.UserInfos
{
    public class UserInfosDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserInfosDataSeedContributor(IUserInfoRepository userInfoRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userInfoRepository = userInfoRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userInfoRepository.InsertAsync(new UserInfo
            (
                id: Guid.Parse("f6582a9f-2bbf-40d6-bd99-70d72f01a655"),
                userMainId: Guid.Parse("87bb7c53-bfe3-44ab-990b-30c4a016d10c"),
                nameC: "78beb26209064039b284c6201bfc59f8e81ff99b572743c0a8",
                nameE: "6c2679f5623741a6a85473f7b9e8888fb6b23e1cad8545f3998e461a2c5e91b4be09ff58b42e4b25aaa22e02cb5664d82493d749d99742f19d071bec9da59be49c8b6ad001f642bd85bcf9155d3b2b7c4000a953a4ce4bada0cb545e89f89aaa1b220e4e",
                identityNo: "3cfc336a8feb4b199c805e65ce29cc848aef9f47e2db48f697",
                birthDate: new DateTime(2009, 9, 2),
                sexCode: "0fbf4d43d88e48a8ba24e688432ef16e866ab0e5e840430781",
                bloodCode: "979b908f0b34456392e6014cfd9cecfc0918c6b525df45f5b9",
                placeOfBirthCode: "8a2534c1c8344f938f1b9fb328969d27c966e2dce3fe408795",
                passportNo: "f6802adc0d774309a7743c8ff34b2e5a812d6c86efde48fa82",
                nationalityCode: "d7706f0b68774194a8c0fa6353342c814f0607bfb4f64b889d",
                residenceNo: "5ac5615d6f2449138eaaac4e871aa2e887246acd94b44f12b1",
                extendedInformation: "1ec6f6b5eb62433cbf21ef26763eb2dbfaeb06bc15094a46860b4c58f0d805ae3fa093a3a1a24b49b0522b3e10949c5456ebd26d996543b69f3f68681898e3fbed55cde412fe4d4c88babfb26513eff45798f21db7f9421e89d7c2369ab9de68917045f66e754ae6accd668b266579d963957f6641a6411ba34b45f82a647f020a8e42aa09d544c5847521d1bf494c1d04ca51c0ec0a452a8e75635c15ae504855725c0570524db1ac61693f7e461cb8c8b120113ce948988311417da36780f6dcb07e482b6340c7a053a3cf13e7a3bbc1d2b67aa4d94544a9468943f9fd29516f3bb27ece7c46b2a884a6d96b7d0cd6e4c1e58053fc41d98f53",
                dateA: new DateTime(2008, 4, 14),
                dateD: new DateTime(2004, 10, 17),
                sort: 104464868,
                note: "03de41df94a94d0c82ca5a6cd5149e252650c492ee494599bd4df60906d14282f363a2706f79493981ffd5b43975037a1a41f90a5cc046f58df0fab087b896a2031bed05552f4e9ebed112bc7838faa04183bf3e308d427da69a55202f3b37c7d83c40c0adc2456094a37c0960dee9d474f772c037044b02b00b60c3a4b77aabb46b5428547945d4b072784194a24ab160344d1ac6104cb6978b57f357df8f9fc79303d0f72c4e8fb58d12a0ac98c540a2631a4008f94972ba147bc1ebd78a94d9841dab10d34a639b607081981ea3690e1664e7e1ce40fab72d03efb1c7f1a9d19b452f9dda4858b7f6f5e212069c65dac14e3f9c3c4361af00",
                status: "d05682c7e8b44f0882aac4573cff0344fd9ce6614a74415e92"
            ));

            await _userInfoRepository.InsertAsync(new UserInfo
            (
                id: Guid.Parse("8eb957a0-6b33-4b29-9392-02d6de5755f5"),
                userMainId: Guid.Parse("5ee1a3bd-1267-446a-9f62-d37848bc9cda"),
                nameC: "a3e647ce467b4ec69f2804c648378a095d04f42259034a32a5",
                nameE: "ee914ef71871439789c1e1277e36f0ec30e282ab12a84c3b9fee8ce6585ecde9a8a10ea39cb14a879f4e1c73ae7b4ba234da0fcfd31d41cbb5a56b5aced6ec6830b8303ee378490ca03a99ac7459e292c1314c8bf3ad4f0381454cef34cc98b084187679",
                identityNo: "fc6de11da5b64bf09300cd5aec101403301e6c19b9fa4d7386",
                birthDate: new DateTime(2007, 1, 22),
                sexCode: "26996172b0844443a4f051b85d11fca74156b5c3640243f5ad",
                bloodCode: "ef0deccf5d684ce0aa5457cb22a0dac5e29a96fe34ff4400b8",
                placeOfBirthCode: "9fdcc69653c349879e5f339c59177dca9a4d6ea5a29d46f7a9",
                passportNo: "6d065eae68ee40089e021c08b998f2677685b0a74437423b98",
                nationalityCode: "fce391070ef64ea08a43c09173bdeae0ff0c453575d24d1ab0",
                residenceNo: "166144cd91b14ea28e38ddfd52fb483069e23b54cd24465a8b",
                extendedInformation: "cbf38ce8f350437db92a50f87f79dc0cf94b492286cd4829a1d5b84ac80ba1ee17ac865a97194ecb8c3f94fc7839e629d882b86325604b8f9e6573a3d8db075c9e3b4198951d47f7a21e89477d0222492365de8f32664509a6ea867b26b29e846dcf0bc2f1fc4e329cf311117e99f10f1aea7d5b2e82464780a056cce03ffc41a737f7362b0e4bd7a4ac3b008fe7e26196c9d93c4dd844349903ce143c4c186e10d21a7408c24831bbdd978715e662d5e5774e3e612c46169c5d266cdda77ac001d027e0af874f1eb8848adff72a6d096bd63303f55b40d998ecf1189b67cc73b4dfed943ec244d48385adcef7296d4cb0ca681a8fc6421c86a0",
                dateA: new DateTime(2004, 10, 5),
                dateD: new DateTime(2008, 9, 23),
                sort: 318616859,
                note: "6f6ab0ddeeee48cc876ef7d67eb4e1996ebd4fbd4f104023835f21dc10fca8754ce76a25467e4444ac5f4cf3bad0cb955015e2f678f9419583e3020ebbd5650799cc6cd6215a4bdcb5d44c4f0ff74363ba051ba2ad884b1597f2b71050f141bc0b9a917bd61e4791a944dc42274fbbd84be8f3dc58d342a38db090c08b369a3c2955beb8c923440f99de5255b2e8e842eecaf9ecadf948c099961e08f6e10f65dd00378e4def47968db5d28cbe82b0e5f86875e067274756bb4d69586dd2a8ac780a20117ec5486bb4906163e2e00e8685a2870bff274e15aaf707c7766535b561deed0e29b046f39fab69d4f60464ce34033b44bc5444e4a4a4",
                status: "5d38bfba5f7c48368dfc920115e8af73c5999cf1a3ed4cbd99"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}