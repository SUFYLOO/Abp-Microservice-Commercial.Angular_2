using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobs;

namespace Resume.CompanyJobs
{
    public class CompanyJobsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobRepository _companyJobRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobsDataSeedContributor(ICompanyJobRepository companyJobRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobRepository = companyJobRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobRepository.InsertAsync(new CompanyJob
            (
                id: Guid.Parse("dfb5ff84-6824-4d45-ab3d-11f56cc5cfd4"),
                companyMainId: Guid.Parse("4e3467a7-d763-44ed-a98c-8696d2fd0d11"),
                name: "e69ebf50569d452aa1e1f128fdf5d3dd1118d29a678345e5ba",
                jobTypeCode: "1da788e626894d7bbfad929155886125f047d72d33f44f89ac",
                jobOpen: true,
                mailTplId: "c1bdf142771740b7ab81c904d3ff9abc4aec353645ec48acbc",
                sMSTplId: "77ecad7d127f4123a5ac62429d801681bfe882d29d8149b8bb",
                extendedInformation: "0ad826a608be4fe08b1d31ac2dee19b1f1838c07f87342439fbb168f10af5c95370aef6074d14c02bae483cc6421f7b5a32258b617114b10adc6fa27337889223d77edbb271d447c805d22c93a0df831d3faeb94134d4949b0e8a50026506529ef5c43022a17466ab61e633d8ca945daec12a5330e234c648e3754cda011111eefe0afbb0b5d455dbcb6a4e43ecafb2ce53b770d152544fa89fcfed437a0477af60a2c1fe99b4c53a89733ed2894d6eaf76835e58da54300a60c589d905c0d86ed0dbc3edb6a4582953ec180254b9ade5c9341590cfc4977b1f68005bb3886145cecadf5bf0c431389d4a57a60000196880b53a549064e9c978b",
                dateA: new DateTime(2005, 10, 3),
                dateD: new DateTime(2008, 9, 23),
                sort: 1581641396,
                note: "229f453e79e14b0fa21bf34a6799fb3d68c1ada5de3a4a24a2124dbd01ceec5a2318d6e9278d4b468ebcde7e672e0a1e6a9401e036984f658a541e758f029022dcc86030084d4daaa370416efce13b490d5ee39e5b514f38a201761a99b3912a16e4c5b7c7ae4397bb8a38125c63e419c4a84c73e453418fb54c7d21b07c9630ee6fb34a07cc43d6aeea3a5b863d09c1f693d863c9bd43a2b24fae3e3bed9695e419571e60544256a29f00f0fc72596e6782675e1d5a4ec9b9bbf03b9a3248e7466fd8ed400446ed91cd85b357deb537936bf2ebe09b4238a05b8c3805ebd83c2933a2a32e9a45feb628b0fee2ccc5d813e95ec6908744558e2d",
                status: "340ee65d542e43cab672018ac6100e9c2e397a8665404b0ab8"
            ));

            await _companyJobRepository.InsertAsync(new CompanyJob
            (
                id: Guid.Parse("65c2124a-be3e-49e1-bbd5-d115f87402e9"),
                companyMainId: Guid.Parse("6eb442a3-9ee3-44fd-bd1c-c8acf2993891"),
                name: "18b4084b70ee4dc3a3407f9ee686beadcb47feebaaf44bcc8e",
                jobTypeCode: "7704c1b5e94d400e81f7e1ab2b6e485c30284004bce34cf0a1",
                jobOpen: true,
                mailTplId: "7f61d2e93e4c42acac7f72c4d514e149b5b1a7c1fcfe4546a3",
                sMSTplId: "f1d80bc9cc68420cb1d2bf0c4d90add58b4d2055cc7d4f3b8b",
                extendedInformation: "167b4db3c0a84d5c9d5d913b61f743a86901563841d2438283b1857fb58f137be72c355176ae47bd83ea3a7b01eb78fdf7785f05f3514075ba2012532f5c9b47560f3ca83c1b4cb782cb6f034abbd4795bad713fcd09494da5ab2cf342fcade4fb7b31113c6247e88b9b352fec09fca602f345fe8a644f39828870b4988a854fbf79d4339d534c39a88dcb73c53076371ae278a7232f4a42b5e20a002a15c497ab982b83c24945d18e4e6d83e5c6f155dbfc7d33d7a04cabbd0e3a64f2aced8f2efeaed57e504b2da1a5f664be24fc8cbfb906f8f1204f7fa1e3c39728fa20b4d50f0f17a7d244c5a299fba36a2addcc350fa121666e4f9b98b9",
                dateA: new DateTime(2021, 6, 25),
                dateD: new DateTime(2009, 7, 14),
                sort: 718950467,
                note: "565d5b11fceb4c9d802982d0f039ab2dc997204fdd664ad3ad23f767b3a23ac2d8fc76632d0643ec98d7771164fd4408213b54a7476545d4807ca261d94bc750ae553920824146d9951a08632d3ba8251a7e3198eb974d2c9b9dcdd526b3bb204e20fbb930cb4d3590f1fecec8a5d3ccf5d13cd55a884823a805b86b0f4d0610306be97bb68740808b37ffc1ab26edcab091046e9c3a40a7ac59e2e80171383cefa1178ad6dc4ba7badbee64d983af63583e79fba4104dbcbdf970b1a3690d3221fe289a12ae4134aa8247573f1700296f022c80c64047b69720464d3d29f5364162e08833f3461089025e6271f08d9d8812addbeaf7445180f9",
                status: "da64e345ff634e8dbd353a92a36e23c51ac6fec0774547478d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}