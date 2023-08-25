using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobDrvingLicenses;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicensesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobDrvingLicenseRepository _companyJobDrvingLicenseRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobDrvingLicensesDataSeedContributor(ICompanyJobDrvingLicenseRepository companyJobDrvingLicenseRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobDrvingLicenseRepository = companyJobDrvingLicenseRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobDrvingLicenseRepository.InsertAsync(new CompanyJobDrvingLicense
            (
                id: Guid.Parse("791e00c7-efa9-4636-adb4-eaca2b567603"),
                companyMainId: Guid.Parse("9bce6c8a-5d41-4872-86e2-7579e8fe4862"),
                companyJobId: Guid.Parse("061c4b90-c7a3-4167-b981-fa692b381b87"),
                drvingLicenseCode: "1cd852aa282e4096a09370b64f0d54f1d5631660cfb64a049a",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "b6a2be5f0f9a4bb18fc61105251e6b9b87d4608b0284400bae2fba66c15787a628907b0ee2fc4a15bfc585e69a681c188d43abb2298345ffaf3d80f5afd3646cf53869623b354d6fb65a9198758fe52271ffba71b38e46b19d7178706762ee513def1aff6c7941d883e43c6e738dc975cc89d06ab73b410b9f6577330b279127d86fc773b2df44fbb56097569d8590859c75af83b8d44ab4aa7d31342c28163421acf712f3fd4745909794ab4209e66d0724ee3ce4e34c43bdcde2e5a6306a958a6e2724b8144d379341d3296e4d4abdafbbbcb16f16425f83b69f3aed3787530464736d0aec4e729a372c727e3f9ae7aa621a511739434b8484",
                dateA: new DateTime(2020, 5, 5),
                dateD: new DateTime(2011, 8, 9),
                sort: 1891308497,
                note: "9818604005cc45dd863b030baa954306fbb392f2399d40fe8953b011f0dd84e3feb25c61db754772bc89762ceeaea979bfb7cd50e20d4a7f8582b10b02c9b77e95f38474e0cb4c388994a4c16ea57e946501c9677c6846c4b41fb0806a5e05f5437e8da622d744d4b3fc872e93c4d0e83e5ffaebcc0e4594bbaf9d9dd50d3c5cd1bdf7e1f9e14d2b9df3c85382afbf8fea62d1b5713d419d8d594fd6ed08a059bad3632a07f547ce810f9e75f316c3f96e56b2a34e2a47c5a5310e588105836854cab41b62d845caa2af27227e418467cd84adf58c504d859ac6bd9aa229994d8863ede74e3b4987a2035c84ced50dfc04a77db645ba4762af3e",
                status: "e918e0139f764fcca117fdf1c94fc47652405408bb534ec683"
            ));

            await _companyJobDrvingLicenseRepository.InsertAsync(new CompanyJobDrvingLicense
            (
                id: Guid.Parse("dd8b2fc5-e4db-4547-9094-3ff52e22b165"),
                companyMainId: Guid.Parse("8d15315e-7aab-45c8-9732-2efcfeb63a36"),
                companyJobId: Guid.Parse("8aa37e29-4bf5-4e91-a7fe-e9898071c453"),
                drvingLicenseCode: "4ee4dea415cd47fe81611658957d9e53d496469ad71c4e44ba",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "69ebbc13c7974482b5baf00bdc03e965e5305a3a9f89401b82bf8fec28d1e7be7859c39f85e94b7982848a2b450a9d4d05c2fb79c6934a948a521a8bae143c52b37be7a26bcd4808b814367784b08aaf61687b2f816c4d64949b08209ecbe677a27f848846ab453183a355ead6ca9186a4d862def03f46a6b23f94f1a66910f07899e9a82e8646a6a36c84170b33c341fc56f2e8a82c44cb93d533dff1fb6bae59bacdf612d44d6fb9aef07e2ff6c370801fb2a25578446d81a4a768e15704a72e157b3d30b547f9b71995c598009262bd6f5298aca4496aab20ca511feea79b884662b1338a4c288211b8c12d92346738fd7646d4474d7b9898",
                dateA: new DateTime(2003, 11, 18),
                dateD: new DateTime(2003, 2, 23),
                sort: 2132890277,
                note: "b06c7a51f4344c89a8de087dbf3855c5ae3ea67eebe44bf68635640b6ec5d9a53fa0c0c2479d4a5c93f05715ff53bb1a51519f59e54a44029d686692e5fc520fc0ff151bb8ca4f8ea59ede636722a3f5f1f87a78f8fd43caa41b9ea4a7d880fd22122fea840143a4921a828975c831a7221ebfec5e394d58b182719be46c27d01b76caf17d0847b6aa960ab13d49c78b1c6281ccf55f45378ac6545d27ef1d96248ba69335aa4a04b1bab6e651b9ae7d4600b6832fd54b61a938d23531e3f484506f99cf3e5f4cbeadd444cc1e04967c1148f36262fa44678407b65b7181f7718a44bf90e41c47beb81cc36a4da541842867b7bfb542489284a4",
                status: "ef1b6d5ad5ae4841b647ab8f77bf5831cb14850473644455bf"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}