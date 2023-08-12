using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemTables;

namespace Resume.SystemTables
{
    public class SystemTablesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemTableRepository _systemTableRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemTablesDataSeedContributor(ISystemTableRepository systemTableRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemTableRepository = systemTableRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemTableRepository.InsertAsync(new SystemTable
            (
                id: Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"),
                name: "6d0e4491c7b149599acb03ddfd12c34487ac625f3e4b432fad",
                allowInsert: true,
                allowUpdate: true,
                allowDelete: true,
                allowSelect: true,
                allowExport: true,
                allowImport: true,
                allowPage: true,
                allowSort: true,
                extendedInformation: "08714ed96e8e4785863d46353f02337b0e28fae2bc0d4087a78dd66b1a3b1b56655c4338c59c46509000211fdc06c84e6ac6429902e94201bd8d87ed6d3abb5b18ec870b741942e485e81147addedc324cf3439eca68484b83157a0da1b130dead626d0d203445518bb0926c2df9ad192d28a835ab1b4cad967762a15582628c6de69b93e6f54d73b478ca2b4a187326a1c4bd8a656848f29fe623dea0f0e343667c8ca9ca9d4bc5b4ae71c382b95253a8c6b553c19e40e3b7e1de780662133e18b96edc9b5a4e4093a692f0071a1fb33e7483872a224438a1f972574092d812efd1f7b65a0640cfad928dab5ff7caf3f2cd5b56b0674d4d9876",
                dateA: new DateTime(2008, 7, 23),
                dateD: new DateTime(2009, 7, 8),
                sort: 511828153,
                note: "bc29d964b808453f9682ffcb1103bef658960ef226d54741a849ae2d9f76f4f6f659333b7fbe4215959b881a08e51d31e1c898974c61407eb7a3722dfc3d338bcc2d09c70f1d40469cf68b3c3e96933dc39b889d0d9e495fa885390b1ac44bf882d78f3092524661b879899b8f7ce5c79da130cc739d4aa0af8a5edd189ce3f08ec17d5994724fcdb4605d26eb088a736b97ead4675e48d8beaa1361403cca22c9f7096ec39f4732909fde7790c1ce495f1e3d66a6804e9894d794286be16b764f645f0ce6134f1aa455954eba4c112f62b9cace3f73461a8e45402696dd06e371d0dcb0a17e46faaea553d3d7929ab39710a34cccca4ae19575",
                status: "d81e503ca00a460d8cbbfdfc72ee526a30009b1a6f234b50a8"
            ));

            await _systemTableRepository.InsertAsync(new SystemTable
            (
                id: Guid.Parse("42736999-cba3-4be9-b701-ab1ec8497ebb"),
                name: "65680b4fb9b2437fb74680784cd65ac23c727b13269a47ab95",
                allowInsert: true,
                allowUpdate: true,
                allowDelete: true,
                allowSelect: true,
                allowExport: true,
                allowImport: true,
                allowPage: true,
                allowSort: true,
                extendedInformation: "33e0377d8ec642cf8082b567284c3a2dcf0cb58a69444b7ebb470309092a380da19357691f6c443a8edbc44991a9712a9f270fd5d33b48aa96a2a9688df93817770db1b26966445a9149ef75fbdc9ce721b8f8528cd64ead8bfbc0cb63131d837f4f0dbbbf304413b868cec73e5f9148acfe09351401483c85b59602184466aa73660c354e3040d39139fa0214786cfb2918c4a7acdd41b789ab353d8b0f5a92cbbaa27a4c184d07a350cad5d9e0ed50a63d320a120440619601be013ee5e3a0757831eb387d4768b8d1c9e92bc6a9cf8b336f3b28394b9eb08d084bf81e1cadcd95b84f8d334c57872d1432c12eeffd3ca8c05a4e93469ea749",
                dateA: new DateTime(2010, 3, 16),
                dateD: new DateTime(2009, 2, 12),
                sort: 919152598,
                note: "a4513a3d715a430ea2e4642a45c482a79ceca925905f49feadcdeba940dff286f569254f95e844fb90006338a80c484ccd940f3e18ef4238953c2ca065648141d84c54d7bf2c4e2a949b8a14771171286a151f798f5c42d49182551a0298ffa9db498e6c2bdb4d46ac3cefd7ca54106c1b80d51ff5d64a2e9b9c02ff09fd6945175e7c0b51b64c52a7a5b5a8185d1a9fe21562b1501d4592a6ee3ac3a684766873c498c3c0534ad7aedc1566301e8127a2209019ed2c4935a89afc75e4091b6c99c10709aabe4fc9a0ee77be8c1c6b9595d1f68754474804ae12eb1cc5a8679a7c7e323f536841af930a92df277d3ccd526cf48204644bbb906d",
                status: "bf03e9d202fe40d38abe7a2010ea4dd8798c4a0c14a7441596"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}