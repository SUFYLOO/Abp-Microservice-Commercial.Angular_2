using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobWorkIdentities;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentitiesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobWorkIdentityRepository _companyJobWorkIdentityRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobWorkIdentitiesDataSeedContributor(ICompanyJobWorkIdentityRepository companyJobWorkIdentityRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobWorkIdentityRepository = companyJobWorkIdentityRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobWorkIdentityRepository.InsertAsync(new CompanyJobWorkIdentity
            (
                id: Guid.Parse("7c25ba4f-31f0-4d8a-9c7b-8c9439e90fd1"),
                companyMainId: Guid.Parse("fc1d261e-a4da-432b-a69d-5590255d4d35"),
                companyJobId: Guid.Parse("a55d3dc7-2325-4ae3-8900-21e5ed31af84"),
                workIdentityCode: "a3046ca1eddb4eaf9d47466e1aeb5c2af7891ace5eb84ae9ba",
                extendedInformation: "2d81114a9c3d40a28a1146fd45e955b2738e560acec642be91f01a62c4c2766ae564014769c44580a5abac6743588784fa0779b9dcc14d83ab5614408ec25dba374bb2ad4323461d83b99fc33a19892d5f6df787f0524398b7bc2909dd5f41fcfd78a26b569743f385ed132e7ed91e3c36954b9d58a44ecfb287a924b5ded7afd3a6b67ed4114f03a9a409c264d3f2a3a472aa12e3114aa5adbcae16fefde41bc2c6351b022d41df99cd705c15bb922c9cde553183f74ffb94f18bc3512eb66f104b1edf7b224059b90cfc1016602b8c1d8527c9f6914117b4455a675eb98ec151892ccfafd24004ac40eac56b470d59e4823ce81c7c42f18232",
                dateA: new DateTime(2020, 2, 10),
                dateD: new DateTime(2000, 1, 11),
                sort: 1232950575,
                note: "bdbf51f3409a4163894a1868e2eb9ad2dfb96cb20eac4917868dae33aa9afc91e62f51ff1e7d41a483ec7214d5da1872c136bb1af0e14d27ba5286b323817b58fc20f7cdef7248228931585dbdfdd46ca144724a96334fe4840d189c6162b7a5c1276663c5f84dd28b2f34584fe69553a9dfdac0b40546c39cfe76f62e5d7bd0e5260ed6a19243bd8014e8f203c163cf262bf6546fdf47d9a6211bb7da8e05b05812db66843c4722b2400c66678f9c784ab40e4f07d345efa76d25011e498e112ddc710172bc49abb76e62afe4de359abf7cba801c7d41d3ac630372a1bbb41990144fafac7348d893b3740672815ac35c866dfc76ba4bf9afc8",
                status: "968c22e930fa4e7dbd5152540cc9b19d07fe8d841cc74cadb2"
            ));

            await _companyJobWorkIdentityRepository.InsertAsync(new CompanyJobWorkIdentity
            (
                id: Guid.Parse("c42e6b9c-d706-4371-9510-be908dbcc2c2"),
                companyMainId: Guid.Parse("60e62ce1-532b-48bd-91b7-ee0872ef7036"),
                companyJobId: Guid.Parse("f9709fda-b4fe-43ac-93a5-3b6e286b74d5"),
                workIdentityCode: "175a0cc078e045a081a44753a68166898f8629ca3cc149b8b3",
                extendedInformation: "05533800ccd24082ae79758855bca9f8b6ab20344553404987ba6c99f9934d8587c302427a944e2e8f1c63fe705a66511e4f1bd15ad04f8cad456460b505b0d77d924a5763a9414db00f723bcaf1901367a31ebf16d543039e79887d67e2113961a78598b9b045d09e4b0be79af987e689779c957b7b41e2a2c6c8bf8f9d5d0d1ce0b78f83d24ebaa062503e3336752350b083994f854217afd540549950d5083c620e99fe7546dd8a927fc941cf3dacf7a9bb9ee27d45a283af237336c5435323362ca0afdb486c981b8da303b3c81b619aff5e0eec496d8f4fc3ac2261f03f6aec8cc71c9142faabd38e107992f366476608e3d45b4bf5af34",
                dateA: new DateTime(2019, 11, 10),
                dateD: new DateTime(2015, 9, 5),
                sort: 777171244,
                note: "c00856a7cf5a4d4193095a336965d3e4ed79ad553ba147189be016c24b80f8629b9086cd38174c8b9fcef3e5afe53493a02338b955124f5e9e3351cc0f30af04be361fb792e3469bb96a4eb1f3447d2a50d5283f593e401885282b37a496534c6b93a01966f147a8a264c84c9ad8f4a063022a463c9f4d2f962d9d189e1bf48ef77fd36fa70e4daa947eb5ee5a1ade4531249796e3934e0ea569d99a83c744cce71751f3e5ba4df28603193e567c96311e53ad3ac9954d9cacba95e5335e7ebf902ad8b38b5b406fb9eb22a27c9b8d26cbfc3a2dfdbb45d1a845e8b106b7d690830344d502504fb9ae7f4a2a3d332501d2be272af60043eabe96",
                status: "a38a1b85d74f469cb2811b59dad6eb2f03ede60b8e0c4688b5"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}