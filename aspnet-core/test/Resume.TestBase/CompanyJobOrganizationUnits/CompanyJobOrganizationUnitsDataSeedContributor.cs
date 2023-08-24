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
                id: Guid.Parse("80d7f9b6-95b9-49c9-9fae-2186b4457224"),
                companyMainId: Guid.Parse("fb812725-d9f5-40d5-8315-026377c485e4"),
                companyJobId: Guid.Parse("a81a7d3a-138f-4333-9c86-0b5c28f079f4"),
                organizationUnitId: Guid.Parse("a4faacdc-5471-4db9-ad0d-53cadbac8fe3"),
                extendedInformation: "efeffbbd5c55405c9f2ce9ae650ed84f008af65c642a4b57b8fa26e66a166c888c6b64a5fe9044fb827faf837fb631529432a9786b1349af89bc6fd4885cccd9b8d4abe0e1dc4289bd2fb2cde5061d5c97739fd652c94d248560a9db3ba0b55cd045d27a628b4492aa9c58ff75875b7e9fc756ede52f4f698201b27d5663fa3d8f5092777602442f862fd783af0c957d50f51aac3c394477b898f5030d7b232754cfa1efc4224018a5f5911c258c4dae841b63375e5949fe8338719d2704036b8ba08887e74e48398d61bdc98cad3704a0b2c43d2950430caeae91bc7d0adf92d365a7084c2c4f8fabfddc9cfa48fc330b8bab3e65c045b1aaf1",
                dateA: new DateTime(2008, 8, 12),
                dateD: new DateTime(2021, 9, 24),
                sort: 1177790771,
                note: "f32848843f464b0aa4d51ba9e12bc21aa42a049f71ec4e79911222e4e5ef68b3b8deef57e93c4e25a44c60d106b8bad4c87633e01b3647d498c4ef97e6e3a1b9be86b6f3f93a46b0a9a12b8f360906cbb77d6699a6fe4205a6f56b3afab771f29460378961bb4f3cace488da0342178d368ad9997f1843f1b1ae01c59f75b7927fd6d5c3d8454d7b8d2240e29ff498f707e306e3fb684b6dbaa52cf0bfa4469375edcee427734c3e9600b59a3a34920f7da4db331d0a44c3847f796faf7dde6fe5c4968b548d40c4867b6eaa19706a33fed37f487d1144a29271c141ae3e8e5f15afe594f96f44c7824532fccd6f4bebdfcd51b446754dd4abee",
                status: "41db48a6b15a40a7927c79d5fa18856e1ea638d885c044adad"
            ));

            await _companyJobOrganizationUnitRepository.InsertAsync(new CompanyJobOrganizationUnit
            (
                id: Guid.Parse("046db552-8a63-401c-ab7e-c5676124666a"),
                companyMainId: Guid.Parse("26c9ab9f-44fd-41e3-ba62-2b1a604d9842"),
                companyJobId: Guid.Parse("61897583-44fa-4230-b927-126f3fd0711a"),
                organizationUnitId: Guid.Parse("92b8596c-e0a8-4514-9edd-c5d4431ea4bc"),
                extendedInformation: "612f6a8ad5934224845870c9ae860c522c48b18f60094c288f9b08271050f46b41caee01de994b578ad35dd1b8a5d6bbae16cde5fa504747adea37953d78d4d8dcdc3bd4fb424a85bbe12f0869323b2b5bf3dc2bebed4c0b8fb4bac4f78b8df678e1a425dbf046d9b74a48ab1dec8506a17f85fb43f24ca4a09a2dbc3a488807744d8cbcf3b2496494c83bae63ebe17e610fda5fa2334bdd8ef4634f24cdbd84f1e09f88811f4c6eb93cb71d8f4a05c93708ae6bf92a4fb296ae476b28686e9119cf0f36da204d2389eb12f6b61136140948fd16fc3145ff9b16254a6f9b244a269527e68fbc4acaa015d3aa408bb9a671956925feaa4feda428",
                dateA: new DateTime(2007, 5, 23),
                dateD: new DateTime(2000, 8, 23),
                sort: 700712755,
                note: "90572f6173b0495f86798533d645052e6f5ca46ed69247fd9ae825588afa3bc8178b0c53121b43d89877c3eb8cb5b572ce10aa2a7e71427d84e82bc9631d2a43e1cf2d8eca1a48a0ace94e8a0635d8c13ddda0d32c7549ab80ce516ac93711bef726655dde5046ebb01b8cd53b3495ca6ba05c22c4d74cd49163d0811c8b10138cc3b5986cb541deaf8bf60c36d09300dd484281d02b4b2cbf26dfa1307e2679de4214939fc84c1494dd24f72e85011a3004c98af41a48989decc4255cfc903f7a278bbb994c49b49e49ece3b9765679be0c520fd819486e81e12c405e08a2d80560f40c5d4b4bb5b47f1a43dac3d60382c2e5c6ae4740ae86e2",
                status: "226622758db342c982bb14f3bc291b9e8e2e0db7d1344e5fa0"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}