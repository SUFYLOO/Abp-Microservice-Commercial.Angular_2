using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobPays;

namespace Resume.CompanyJobPays
{
    public class CompanyJobPaysDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobPayRepository _companyJobPayRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobPaysDataSeedContributor(ICompanyJobPayRepository companyJobPayRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobPayRepository = companyJobPayRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobPayRepository.InsertAsync(new CompanyJobPay
            (
                id: Guid.Parse("d542bf1d-b728-4c16-9c06-a9e717d70117"),
                companyMainId: Guid.Parse("20290bd0-c4a8-4263-953b-7853b23d9371"),
                companyJobId: Guid.Parse("70911ff0-bb0d-4dd0-8fab-5c10e161c7e7"),
                jobPayTypeCode: "b03aa0b766b140acae161945cb0ebbc8d5521ee795284942b0",
                dateReal: new DateTime(2004, 6, 18),
                isCancel: true,
                extendedInformation: "cbf9ab5f2368470484118371a9d35759054dc635e00e4daea50ab413b1379c28f00c1e97e8974cc8a5ff7ffc4f721abcc89e228b325c4382a8989f6536662ab6b4b66fed0b7a490ab06b26dab7b684f65091053c07424dbfa721b532d2b1927ed35a7b3891fd4f24bc2a7764a4bd69039d31b304518045cfada67cf851bd914b0ca98c71e026480c9554dbe77469112f1d0d658236b34a7cba571fa202181886bf6bdc11f98d4e4b8c82910fc8de9dd73f8627b290e64cdf9b879677fb243afebb1e0669bf854f4cb15cfe77242b4b18e65126b88fa4426486533c78fa5186c4e24dcf977b2241c18719b2bfdbbe9b336117865f40b84b379c52",
                dateA: new DateTime(2012, 11, 24),
                dateD: new DateTime(2016, 5, 16),
                sort: 478948270,
                note: "3ee5d92dbf7b4dfc86efa1d193f4e770d65e0174c81d48a5a3a55460507ef43e6b782f46053141bdb4bc157e463b5a4df790d1baeb7b478685ca4efb4bf9e25a8b98115f7f044c54aa73cc9a3c9040b82a35e6e46997413b813804bc098d7d59427284c7038d4320bbee50601fa7f64b36d4dc651d5646e19fbbcfba766d7c07a432f61c61ef45bd8ed255c6fc313a718f7a4b6c2c4b4cf8a0d02f306532dc421b09083b72e5474285e93808fd4c919fa6c7ee46e0454b11a07a3fd895a1392abd947abebe17498d8332390b5121dfcb756183358ff04403a35c10c941070b86d7a6185ed1f6411ea2d985f42b21389aae925d2119e142c0930e",
                status: "bf98c10687c7460bba499143c5c9797fd7fa29bdcb2e453fb5"
            ));

            await _companyJobPayRepository.InsertAsync(new CompanyJobPay
            (
                id: Guid.Parse("9f1f48c6-4697-4bf9-8792-668370d2c4d5"),
                companyMainId: Guid.Parse("ee662bb4-8395-473d-9933-808cdca9c48e"),
                companyJobId: Guid.Parse("9c4c1955-6791-44ff-b128-c104ae763fc4"),
                jobPayTypeCode: "7c267e3928cf4b63bc37d7c71289045e65082f0d71d6437e8c",
                dateReal: new DateTime(2009, 5, 5),
                isCancel: true,
                extendedInformation: "a20279105c6e4c7eaaaba2f416a7951c5dd3b2f837674486a259b0309c8829dc8bb438d49e3947d5a3f3bc382490d76b82151475fa104b41ba76b7ba523b267011f1b9b757504c2eb74a21d4e7a268669b68d07fef9945868bb28b7a254583b65defd90f3a644a92b0735c445c9f07fa4aea2cbb131f4a87a7c337a04c6e849b454c6a133b7b47b6930c8edf6351742f7aa3e85f0a4e48e68cf8fa1a396a52542c127c0f50de445f87d62659b45a55fdb52589ff8f6e441db797e10c827d627a587e8f2969be415198c11935b087ca8663b33d3343274748967ac480f2487ec28bcf117bbb444cf1a5c0e865c44245b8758ab82c9cd14995a2e3",
                dateA: new DateTime(2021, 6, 19),
                dateD: new DateTime(2015, 9, 25),
                sort: 1266324666,
                note: "39bdf30845544513b5a9cc00b35d7e1904f23a3cc5ff4eabbd1580e1649f8fcc845190e034134c168f55ebf2332bf418f2a1d839f66d4d77ba2aa674d84e06ab0c1e3cc7d870484cae8da4137feef9efceb1b420a4894d2486cbf5cb7f895846d16cbd83b7ff4db6bc446f2b75f751717e74164cf4c24c8e9863ff0488b7411a7cf592f5a1814bb0937e6590c8b6d77ba9b82932305b4bd7bbd9d575a5395973c3d8fc88415f48eda6010b648b0b41b17226698c10604a03978f6fb83472bebe56ee41add7d1400082ac447eb6a5159a8169c6128d2d4f3285f07ead5ea5665e5bfe12c6f7c14913892419c20b2624fd9947522728ca4e919fda",
                status: "658ed3be8de44fdabee0de5f3129bd344dff0543e407401ab1"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}