using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobOrganizationUnits;

namespace Resume.CompanyJobOrganizationUnits
{
    public class CompanyJobOrganizationUnitsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobOrganizationUnitRepository _companyJobOrganizationUnitRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobOrganizationUnitsDataSeedContributor(ICompanyJobOrganizationUnitRepository companyJobOrganizationUnitRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobOrganizationUnitRepository = companyJobOrganizationUnitRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobOrganizationUnitRepository.InsertAsync(new CompanyJobOrganizationUnit
            (
                id: Guid.Parse("e96d8376-0604-4ce2-bc33-0907aebfbe5d"),
                companyMainId: Guid.Parse("b960baae-dc99-42c0-9685-b1fce6e66c23"),
                companyJobId: Guid.Parse("91d95562-55b0-4c0d-9846-2a0e2b28bdd5"),
                organizationUnitId: Guid.Parse("eb43006b-2c50-479d-8288-9be94a1e2a87"),
                extendedInformation: "86fd25eff6a64ed19e046a1f3e4781522df2c0e1a74b4f1fa00f4e97fe4d65c791fc6ab424c54412bcb60015faa264ca09855a90e8194837bc5c29e613d71c924918bb7e25d04639aa2feb1680a34f74fa17ccff66c74f9aa2c51ae0eaba1045ad5e761b673a4e489b893b4cec0fcb9e7adf0782bb694a33934dac12ebc5bd5713587c438dfd4b4489eda987a0fbb62f0adf50e13531474085cb3690ae635c2599a69268df354f0bab6bc357dceef87872c765de636c4af0a062eb6943556168a7507ec8b92f4dc3b391713fbd5626e445fb49d41bd547bd9d93b12c3fe0a78da3498389c54d4392ac34da9a2d157063ab23345bcb2e45b4816a",
                dateA: new DateTime(2005, 5, 25),
                dateD: new DateTime(2014, 2, 4),
                sort: 1662114089,
                note: "972c2b7dd5f646c9ba6abd7b7946c1c778fdb5b466a4424b9f9f186dad1e341fb73ed7c372414752a2934ac92e04309aa75a92bc80a44a00b566065fc05fd91e71210cbe52a540c694e5b818e31e0b6243c4eeb7abc84d6eabbebec7ca9e8fff47826f204beb488c893905a3a66f445848521e6248b247d4b44967e81b1d40c7c95612fd8ace48c087ec8bbc959a5a23f917152004ab4aa0bb5de1d2e95944b1faca374fa0764b3cb35ffd6ce6a4f70414caf9a1116048ab814d235d7bf45de191f311ffd02b4d1aa5e6be15eb90982b7de9ed94509a4f6a93626488d16fc628c19c4e61c6bb491091192cff59749460d5c6932f91484ae491ff",
                status: "5cf744a0f28a42c6af4f177a572bdf4ead3e0a5f767d4e7b8c"
            ));

            await _companyJobOrganizationUnitRepository.InsertAsync(new CompanyJobOrganizationUnit
            (
                id: Guid.Parse("4e35ba27-9e18-4c68-9074-9f5794732132"),
                companyMainId: Guid.Parse("8c366a06-5400-4374-b1d7-213683c1c0e0"),
                companyJobId: Guid.Parse("196eb635-cf47-4d5b-a1ce-1eb8e800e5f0"),
                organizationUnitId: Guid.Parse("50f5e04a-12ee-41ae-ad68-52897b87de77"),
                extendedInformation: "27139fa35f024a2bb4cd66a9f81c6c24bf1a37a99dd64f77af0e4b59d8d96d8678b369e7808348d399bb312768e978501535cf6d3d1246cea08f1862fda28cfb53ff91e239d54f6c96f695d78954c085808f01f0f4b6460283d8a4238da661babdf7e88b3126437491bb11e109e081c54014162aa999414b813bea65498190045e1687b0e4724580ad0d0debba16cbfc217e6f2bd6b64af4a9a234c739f1a5c4e59cb43104634837bf2bd6e164b9ad0ea7d2abf36f3346a2a7280c6c705d62d1dec1c03a83854567a76f5ee75dbd5fbc676ccaaaeeea4d778afac33018a31f8b7b59f91492d841d793a0eb08bbf7e35f0d75a2f6c7894d80ac7e",
                dateA: new DateTime(2005, 7, 24),
                dateD: new DateTime(2004, 2, 15),
                sort: 1035768858,
                note: "3caf0fd7b79b4e26b7686b1e42dbd409ca2edf6ebfd14800832e5dcd81570e99980b85c50ba047da8c60ec16fc9815439c7c15065adf45f685dda2a9e1d88fb2f3c4e030c6824e2db85798540fa02edd02810fa3d40c4cdf9a0eff8c433ddb34f5ba3e184d8440c698be049cfc7515449add3e64b93745e9aba44df8ed5c932273073eda29f74504a57a1ebbdb7067871dfa4ef9e92346e38d50a1bdc912e92153907d0f43da4b6f8544b05ae4960d2d7bcba1efa99147c38ce4d625632452c2899a7bcba7e648b7853812dd534b4e2d89310fb488cf48529e723ffd5e919967e4e0d6ba2fd94b7e9e664d6f173e3ddbac927b7bcc1042239932",
                status: "e70b81e90b9c4e569e67f214c5ac299a2878f2f6f77345de82"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}