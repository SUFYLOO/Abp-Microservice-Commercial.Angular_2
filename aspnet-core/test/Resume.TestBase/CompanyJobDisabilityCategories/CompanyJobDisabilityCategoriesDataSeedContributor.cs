using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobDisabilityCategories;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoriesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobDisabilityCategoryRepository _companyJobDisabilityCategoryRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobDisabilityCategoriesDataSeedContributor(ICompanyJobDisabilityCategoryRepository companyJobDisabilityCategoryRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobDisabilityCategoryRepository = companyJobDisabilityCategoryRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobDisabilityCategoryRepository.InsertAsync(new CompanyJobDisabilityCategory
            (
                id: Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"),
                companyMainId: Guid.Parse("8730524e-dcc6-4958-87c4-5dd90fb393e8"),
                companyJobId: Guid.Parse("3f686d5f-0731-48f5-bd1d-d51db25fd6c0"),
                disabilityCategoryCode: "2bf545f06cb843f1b04856e063bd3abfada4f3d16b94457b97",
                disabilityLevelCode: "7ba5edc920174015b4db34e3091031b1a9dbb6d14d6043eca5",
                disabilityCertifiedDocumentsNeed: true,
                extendedInformation: "7121d8502aa54393ac3e37675d40371544724f2d66c447b6b759025225c12033a09f4f319b5b409386c79bbaf8675c0854c9b7be624c4272aa2b4c755c1d599647b25a606449463b832283867dc63146c3deb16cad1647a1a447531ed1ded5c9d537c1b28fcb442c8a605d9cbdf2ac0659a7f92d991f4afeac7947528348136cf2c4ada2b32041f3b6dfb58ce7bc259db4c27124ec0743e486a8d7569c04350396d312122a074b9093690e78e23554586f982359a3a944c0931c6e4cbd851bb5a59a3a39bc29461f9b49001546fb3104d2b23a44745a42358b77f06e025f9c9910ba227e7f8f4b128f48b84d62e6b6d1be975ed89b1c4b37b3cc",
                dateA: new DateTime(2022, 5, 4),
                dateD: new DateTime(2020, 6, 8),
                sort: 147502255,
                note: "f6f91bd3baf04cdf8a4e4321f017689c0952489689304ec4b568357629eb9c5af80b4138139d4b828e237c82269c0011c48db7d5a4f04fed823e215a41ad6a58aa2cee1a9873488bb6d591008fe348cca95052e819e741d0abe606fa7096c484e86ccac0daf04f4a82e0b16787abaf098a17572b3dbc4115b6ea1b2ed1ba6e383d9d66c23ad14231baba8bc1e19cf536db6912f80a0c4d7e980f83476c1a2beffab1827af1d34e87a6c9154b5c43f2cdc5bedef63123411e8c3cac08160b32d9fde101a786234d4b926cab23f4582539e4504a5557c84cbb987be4156470a1a0f94d7d09c3e64aa59bcd32c4c667e1e8739ab7c447ba47009b6c",
                status: "a00333fc94434a4ca2e1a19083120639cd2b373f9561490db2"
            ));

            await _companyJobDisabilityCategoryRepository.InsertAsync(new CompanyJobDisabilityCategory
            (
                id: Guid.Parse("33e681ae-f6b9-4d15-92b3-10ff6b538f2a"),
                companyMainId: Guid.Parse("d9f72f96-36d2-4c54-93f5-386fd7842d43"),
                companyJobId: Guid.Parse("87121958-73e9-4b86-859b-b7271d170b14"),
                disabilityCategoryCode: "7654e9ea7b204bdba8059bf551cd4ec487561c6570e047f1af",
                disabilityLevelCode: "be2ca8f40282464f8c8fe694f4ec726449f7efd609c043c0aa",
                disabilityCertifiedDocumentsNeed: true,
                extendedInformation: "cf2d6574e3194382b20921d3c8e43ef9252603059dec48b48c604519f08379b4a1f632fa19c843a4916d026b342b3a1a08e5e48db0644d0dacad8991f9631fd14dbc18111ce84f19b3d24454c369c39ef5c914580dec46f4aa60d86466a8b9788750c949c6fb40f4b2519b4f3d0498bea164c7e7d49e42488ae997aaf12227aad7fc2779bacc47b9bd31d854c0078301532cbb9f02ad46fcb91fa93d148d1117e3cab68a30cd488785329b2b771b02c19bec1c8acd334db6b7253f4b8c42673356a8fd6a4d50428baa0f2cd5301e81e947e03526416b4415b441386778b5ff154b61e93fd78e40bd95a0f258e6d126ed8dabf769a20741928563",
                dateA: new DateTime(2009, 2, 9),
                dateD: new DateTime(2005, 3, 24),
                sort: 23177442,
                note: "61d0261682c04855b308afdcbe8f3a35223a584fd9574839a8025f93fd6c236bea49ec254b5a4771bd13f6b72ecda7408593f49e85cc46a786c3126cd4ed70d8cc5b6549738d477cbc9712e518ee1c50161e05f68bb0464bb2c23f4f8bb73a52bf906b11b3d04a31abd666ce7c35969b001a6c3cd97e4237aac41ad9e24107f554449c9bc82e41ca812a6cc4f19093754df3bd0f2a904bd5bea7f0b476abba9a82bd5c3fe20045a48428d6ce83d74ad92c1de588f7a64f0d94e92db0bad3e158a8d1163655f048e9bedc387086ca618066c27d31295a4b94a74b8fd2ae9e39b3c774dedb0beb47e59168536d6d775cd5c1e669b8f2ea486297e3",
                status: "b9d8f3e5373f4517a723f765524f5a55072cf59b013b4240b2"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}