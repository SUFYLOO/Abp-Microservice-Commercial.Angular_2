using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeDependentss;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeDependentsRepository _resumeDependentsRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeDependentssDataSeedContributor(IResumeDependentsRepository resumeDependentsRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeDependentsRepository = resumeDependentsRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeDependentsRepository.InsertAsync(new ResumeDependents
            (
                id: Guid.Parse("8a168aae-00c8-45df-8680-ee3cb4c1d6b8"),
                resumeMainId: Guid.Parse("32eedb83-a7fa-4095-86af-66d6edfe3179"),
                name: "4844351bb17643cdbd1d0b89b3c85a07947391cd1e7a46808b",
                identityNo: "860798ee21a74bbf89f3210ac6871818e6ce1fc617c64ad18d",
                kinshipCode: "0a0f481d2dbe425aad5cebc5568f905176683da2ae1d48d29c",
                birthDate: new DateTime(2012, 5, 26),
                address: "da1dbf4f75654bc782fb8cce88df6c2f87b8084f42f84ea0b35955573c6d76635b66e2a1e43e42cdb34bb55b90937db62b61f242bf564d3092a0931c7c29d9c70304fcf44b5b44ae8625dae3d08cbfdf74c0027857984c1e943c6ad8ac2250cb22538518",
                mobilePhone: "1a1489f9c67f415fa349a87a93d47425bc3b7b4e71ba419a83",
                extendedInformation: "2e1b10174e6b43b6b7b3dcda35fcecd3205eec8fa5a8462e8ac432d7e43e0d19e78813eebdc14344aa3a2dcd002f3a91036c547c77c54bee8f56352d1b7d24126fce113bd1494fb1bcf6f8c6835051c128029e8f94c04ea5920230bd464a126d3c6d16e2f8a347348673aa45307551a67fefe69fceda4c3f88d96f2c229748a092c71e4b235846729210f8f63f2e9e1aaf020425f3ff42368be4663fd472c66b2474745046574ad1bf283fd7197bf535fa29e916d1b24078bb1dc518a92f0ef45309db18f9774b01b848a0a5650dfe27196f885712e748b2afe422763c01d049b3e8c21d924447468740740e456d7d476af183cbd6c84c9ba870",
                dateA: new DateTime(2005, 8, 8),
                dateD: new DateTime(2014, 4, 26),
                sort: 1456757537,
                note: "43e2e2acb52b40c38f6c6149fef71665f0672b0ca7a14172b56feb5983a8bded0a5294f26d324133a676202e051c3a63e5158a2aada849d0898455f9443fbc91c32baf76155f4ee7bd3e8b52584db75f26ffea298c554a90aac03cda208654809243043b5c804947b2c7de24386086e3db78121dc77340d7b8933629eb5887abe06abe4efc984e1e8201def41c8aafc5c914f7f4844a4e71b52a14a86403c078d0edfcccda5b4ad0b73b61930b2c71ca4d0a4543442c47bca175655968688564ca0cda97dab640cda4efa724cf96ded836340368e3ea4edf88679d640b665e16a7cb7ef33d404a6f9a3586db5ed28ca64132cfedff0f453499fb",
                status: "212c76a47f3042f4b5a1862ff45133636756835788074cecb7"
            ));

            await _resumeDependentsRepository.InsertAsync(new ResumeDependents
            (
                id: Guid.Parse("f2e47ea1-6500-4d50-879d-6af25cd3002d"),
                resumeMainId: Guid.Parse("019c01d6-a84c-480f-9049-bb3cb690f771"),
                name: "568553a82a0f4e5aabcdeccb569df488acd3e912baae4c2b9b",
                identityNo: "764523159f7e44e1992f89e1e40aa44f6109cf8a56d74e27b8",
                kinshipCode: "444e3a9975f142e0b292847a90636472e62c4b7188c349048b",
                birthDate: new DateTime(2009, 10, 18),
                address: "0c28c3f4c7574eaf86dbba2446d9c2735c81babf722a4ab3800a8ecc8f4f37c9180e7de5d69e4ce2aeff5ba6fb920e03058a3e464b9f4629a27d81967f214afdad3bae4f18744481942e11a4cf05f2a41672654fed70444cb5980cd51add7a564f73181a",
                mobilePhone: "63659c074493462e8ea8654c20a19abb26b326462c8e4fbc92",
                extendedInformation: "32dc5b02515d471985f1a95c63e140edcb2e5fe5822f4f04907282cc3051fe01523149b3d11f4453b67a7acd9d9b5455dad9fde9972c4f53ba2e23bdb2ac218cf250faef6c2147b8a5a7ba7065c0d01bc09a053d8450419fb26631767165edc8e4170fd9f24041148e30c5bef319d524fc90e4a472c84ae6a9310679c2730dd6f4482a7ac94f4ec29a0da1980b24f342cf52e2b7aac342828eede914b33a17dc296072171dd04320adc28d16dcab1baf26d507f93d2740839b1c55827144784172e70a8841164cc09a4cbf5513fa062c6f7b9a9436644cfeb8f65e0bd12ea742956804b1b1424b1aaf1db548246d1964840961172435433580e9",
                dateA: new DateTime(2007, 11, 18),
                dateD: new DateTime(2000, 7, 15),
                sort: 1406189097,
                note: "5219eed304ad470c85b539bef05c46687f3d6bb502bf4fdc904693397f9ebc07016a24155ccd45e2ade2a82ea1ad8a7983c074dda4ec48e5900d37eafda18639d4d2cb28458a4b17a36a4cd4882bea5ab148e5af55f3415eb048b24288455c2f0789e5836974458486fe9cae9b1b73899ff6004aa0d34e37a493f39bbd468e33e661cf89276941da9e31503469c046e81384423e222f4a3ebf35254a67253b5845abb2a9ed314da7b7d8b7f3fe2dde26dc91533500e04e938975c0191a680cf050df3fb2ce8848998b638d796d6fbd1d02c81625453044c8966f48a2f31e6f860c85b37c38f0482ba1b499f543b8de528482a89270f4443da9fb",
                status: "47bdb691d67f4e918a3195d502bbdb5311159a356fb54d38ad"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}