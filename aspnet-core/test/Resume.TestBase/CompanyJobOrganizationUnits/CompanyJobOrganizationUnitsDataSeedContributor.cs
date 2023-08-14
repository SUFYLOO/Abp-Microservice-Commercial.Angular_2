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
                id: Guid.Parse("b195e285-50e1-4ed9-a91e-17cf53383e50"),
                companyMainId: Guid.Parse("dd2b9122-df6a-4997-985e-4e9c59d408a4"),
                companyJobId: Guid.Parse("41171708-26b4-4666-92b8-f3034f0b3fc8"),
                organizationUnitId: Guid.Parse("25f5dc99-7064-47f1-af54-213ba58a038a"),
                extendedInformation: "8c842033165449198755920a845d189eefc69435f1534aea9e10adae3c485007490771d92654477d9177b76c1d880b2933b9c2b3f4fc4c6a9d7cb51563b984369cf8f23bc3da4b06b6cb1eab8fb808b1f7b4ac5ae9a24dc0898956866c058b80b1c31b9868404b6495cba354a0c3f8706b7b550e98a6491ea52972aecd99bfcb47e6584eae1b4c20b97f952b3fbb4b7934f280820c2a402a93c5446bede92d1e24adf7cc766b4dc68b6af278527557a23062e84dd1ea43469f0ec7d3cfc91cf567b6bf922ff543a2b5ac1bae69907c0d8a996cdbbcc84f30a3df0cbbf7ecd1c39a81d6b0e8b7476eb90b8861a1451db3f0d923b850ed41cf98c4",
                dateA: new DateTime(2018, 8, 5),
                dateD: new DateTime(2012, 8, 6),
                sort: 440186474,
                note: "70fa83847af54a6db2b701917b7c9d833715722f79f14386b0e0b1e0d2035ebec5d8bcb648a64e6d97de02c1bdb310380269b8bf82864a1683e4809827ebd0a45aa847fbc563466a8c894c917680e313f88edd93fe524d0298e010abc5d010476af41a12f5ec4fa4b06e7c7cf3c1c1125fe60447aab34f19bc61a000b8f0e8fe2caee829964846278d8283e048827262637b01612c6b4680b4a930a8d5e6af15f5ea3b5db83f464895287c4c0677ac471d8a03e1492349b2a64457f621c6eb5a0962208ada4146d6a1e8ed9280c2edc3ca9edaafc99c49369f3a54a733ab4cf02769bc6a096048fba8100e97ce825bb32723147a3b414a9db694",
                status: "d2ebfa7b0f6743e8903b6f20cf51c690049cb6c84594465c8b"
            ));

            await _companyJobOrganizationUnitRepository.InsertAsync(new CompanyJobOrganizationUnit
            (
                id: Guid.Parse("91b29225-a219-4df2-8b21-c47eafb009fb"),
                companyMainId: Guid.Parse("a055a33f-6a8c-4934-9d8b-e8da609e1c82"),
                companyJobId: Guid.Parse("d93de078-8cd4-4c1d-b4c4-b34dcd3fdbdf"),
                organizationUnitId: Guid.Parse("172091d9-3f4a-4816-b2f6-06f2f04af041"),
                extendedInformation: "737aed7c773a4fc7b0fbad9f228440768bee757c8905436781d9292a1243246a2fd2fbdcaded47d1bb4743b15985f1423b2a4a42c13a450882cbdff5daf374da7d6c4b5a481940c0a1dd10ad366f4c53505d7a9840544abe8f79acddf354f50e661d879f788d477c91200c7dfaf945eb4fe2b71a0b4d4731a5c23cfd2f5ae7d31fa2a3db6bed46e28f80463600d46b5bc62c24cbe1404ffaa141fd6491de4a115504db1d825440a7a936300faa7eff7dcfa0136a54b548a2a922ac78d686c936218a6c41311f455697cb98d132d405232fb20fabc92d45318fea81a1a1808e767a652df8459741cc8b71b83677c72dd27e037cfcda4148a5b5ca",
                dateA: new DateTime(2003, 10, 23),
                dateD: new DateTime(2020, 8, 5),
                sort: 107784571,
                note: "452556011283411c8e81bf8daa549265013c9eb3650946c1a6dff3b650bfc9b2aa99accb42684b5d8da75cddfc3ddcb4a5cd1a8da249406ba0f36b0366e19fb74f122f016e8d410ba25f3381f32cd8e5163ba6142c0f4900ae2bfe5b97cb3301cf144218b530458a94eb5be458ed117769f8508200234e519ec9b9a43c07daace900e0fb72ae4b66ac8de98da1275e03f0691daa927b4756a2f2998f9ffc7edd32e12a9ded09449c9bdf47eda98b05de4642b6332ae44466b636fedf3ac7af3950b4ef47f03746fcb5345b9ae4761c44d630314169504aaf9991ff31ad0dbc648608f6da096a4bbb9ddfaf986488afa4124d51d3426447d38c59",
                status: "b51557bffac84780ab52290b6428c748ecaae43b29df44dd9b"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}