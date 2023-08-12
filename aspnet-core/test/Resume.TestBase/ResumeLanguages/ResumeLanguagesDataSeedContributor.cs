using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeLanguages;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeLanguageRepository _resumeLanguageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeLanguagesDataSeedContributor(IResumeLanguageRepository resumeLanguageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeLanguageRepository = resumeLanguageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeLanguageRepository.InsertAsync(new ResumeLanguage
            (
                id: Guid.Parse("ab71f01e-45be-4326-9b65-e19d5fa8d996"),
                resumeMainId: Guid.Parse("917e0995-5eab-4498-9c3c-54439e19da4b"),
                languageCategoryCode: "5b632075a7fd4cd1928a3530333109f1bab35ecbb53745dd8c",
                levelSayCode: "e6e4108bc78f45e98bc3fa57f839bbd2d368ced20ede46b9bf",
                levelListenCode: "31c03d80b53e49d0adde169d132bf71f1c75859328d2471bb2",
                levelReadCode: "4bcfc3f518714a0aa6421fed86a5a5085d27f2ceba1440f1b4",
                levelWriteCode: "096cade3f5b84a98800ad545b60b1c0d5641ab18f4b34f0cb0",
                extendedInformation: "92f276fc4b264b7980cbf48653912443116ec059d0a342ec885fcc413e769095b3dc24bf24974ef5b29cff74da0de8068917d2ece11e4181b12e712d3a7f455cfd1a226e4b844de2aa99c9fa252171436a6fc42226cb467c93b87fb128868bf526e65edd6395457cb889619b71cc5d05ed8df7d664044f2aaa184c92b1f902226b380c8eb8ce44d488544e620fcd2c461c2a660b46254806ae76f133633d0d4d003503feb08747cba3760aa5f47ce5d6af9620fbdc1c4bc2bc781b96c596acba750b7c49f33742ca95c03728cb980a47626bd6754a544544ba9c0ffd7a7b9346eaaa046407ec4aba8bea73bb34827a4449ef7c388b0040c49fd8",
                dateA: new DateTime(2002, 4, 12),
                dateD: new DateTime(2000, 6, 22),
                sort: 634102242,
                note: "cebb53f0c71a4b69832762e4b477284743efff1db16d40a5a0a67755e5e12ef95900c8b892c7416c8b8666a22b9be19117d116d1088c4c498299b02cf4c767d6c5e7a6f68d7742e1b9505fb11b159c90a9895baeff5b4ae793a7fec62186137e9e9da9cc7cc4411f8ffcaca8b51a8cbb74f5fac509b349b68a0a976bde8729810d884fd11b93467ca2a184e8db984f3ec1b5e3561eb142d0b620b6c7181f8ea4c7161bc33169451cbe1a17610002281625917f1e772f4c308fa226019c8af973db072dceaf4f44859a2d389508afd8861b085d7d05614d35a22022206c4e6c231acaa2c4bbbc49e0a32c27ca6769f1472a208e1301674570a10d",
                status: "d520c9674ce942ce9da2e731417758886579b73d8b344b2fb0"
            ));

            await _resumeLanguageRepository.InsertAsync(new ResumeLanguage
            (
                id: Guid.Parse("5ac5c550-8d36-4564-af97-419c0bcd3d90"),
                resumeMainId: Guid.Parse("c5dfc375-f67b-4b7d-b167-96025698a166"),
                languageCategoryCode: "bac2960293244f13a1ba3ee0df6897aec57e2d56c44a4d5a94",
                levelSayCode: "c4de7d7470c1475c929ae1a49c9d3af4379db49d6081430594",
                levelListenCode: "ca490db4e4da4d7eb0bf8b8010900233ca68382a57704f9b96",
                levelReadCode: "9abc3ed0c22c4e4aa256a2542244126665ce9e281a3d407497",
                levelWriteCode: "89377eeed17949118feffb590801e7d2ed41f269351145c4ae",
                extendedInformation: "335cabe2903044f29d4e05d5ecbf4a1edd97e717986742baa9f8b4190307d5ed5f87a686bb9c451189a27077f6c287db287ae87300464db6b2ee28eccd088f2ba4d787d4f9544231b18089fbda3c96c14c7212ad14ee4b13b63b3435e636fdd8929830f31a8a4c36ba69f11b8cf1878b3aedf0859db34eb99d246cb1b25e943c9b5e46c2dd49414d9fdcc0204de68c49a049b707140b4e02850430d5848a20d25e3953823b3c472eb5f82180a00fd3815de78ebe321d4da380d8ed4cdc732d4e7ad8ad13466143c997cb0fd05c2af51b5aca949262924619846b618eac72c992d6585d005ff6415a8ab2db4c7e3bf5047e92f9924d1a4daeacf6",
                dateA: new DateTime(2016, 1, 10),
                dateD: new DateTime(2017, 9, 11),
                sort: 455240008,
                note: "511beed3d0594916990588de2696bd0750df04f9af1142d6b54927cf7f85742a7eb3d00993f948eca435c86c0ba149246158d5afd9ab4c7daec6662110e15a77e6853cc36b104fc387e60d0eac5bc571e6e1e166cfa24f419960a35987be51e10dfc687439574a2884ce077a63a3903179cae7bea38345eaa2da36f6b2e6c97c61ee9ad4db544f8fadb192275de1fad3a0a7878723ae482f9eaa5316b55b2033f65cd9f7d6a84c3180b86b2c39fedb2d72646bf336274dfb9f605f627d115acedb473e26d8ec40eeb41c753d71cbe9fd6cbc9e35c00c453fac1ffccf9ad2ccef22c1e12b34e346c3bfbbbae4b8e7b8142d46c0102cb6431bbec4",
                status: "741d022633c54ae8b7e57401964f16b6bef105589762400fae"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}