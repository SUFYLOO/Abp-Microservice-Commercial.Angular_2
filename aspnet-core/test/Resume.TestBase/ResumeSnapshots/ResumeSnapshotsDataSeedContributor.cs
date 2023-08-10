using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeSnapshots;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeSnapshotRepository _resumeSnapshotRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeSnapshotsDataSeedContributor(IResumeSnapshotRepository resumeSnapshotRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeSnapshotRepository = resumeSnapshotRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeSnapshotRepository.InsertAsync(new ResumeSnapshot
            (
                id: Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"),
                userMainId: Guid.Parse("2a988c27-0ce0-4553-9e55-a567f5d6ab74"),
                resumeMainId: Guid.Parse("98856d37-465a-4ebb-8546-89f47c01f45f"),
                companyMainId: Guid.Parse("9f517962-d055-403d-abb9-5b5ea1c1e648"),
                companyJobId: Guid.Parse("888b3fc1-1203-44f7-b07c-ea5398a78db1"),
                snapshot: "cce69b",
                userCompanyBindId: Guid.Parse("19bd0fcd-7b1f-4796-93c1-43cdbbb028e0"),
                extendedInformation: "bc4b8fb9db1040e399955f35059d615fa0e5d1e01b7b448dac4a3c052ece66cd292e85fc1a1541d297c89e1fc98d4cf0fd0750e3485c4a709fffb116c3e6a8f6f6a41b7abfb74cc49eba09c8e04eb7abef153ebfd3254f48bd98f187a7e011303093ec135215467e94b146b6a4f677e7d76734e7f0dc4eb58e92342cddf275037350cc63fbb0455e94108b9559a4b3a288e5881c77334e918fee9df6e7b57124b3cfa2463ce44598920492a0c032ac4d70b85d1180944eb0bff60e0ad6383c7b3cde24e85ecc47d098fc3f65fbf6fa65da03b597f6fe44838eeed6057dc25f5cb8c944db84e4434dae0f1767bec0b99812358349ea9044dc9935",
                dateA: new DateTime(2018, 5, 12),
                dateD: new DateTime(2014, 10, 4),
                sort: 1295102379,
                note: "451076bdae7742ac8880f53d39bc228474a2e20994724cf9bbb7143a6aa79ab71ec1c2a83a6045c9affcde9302652f9f8fecc8928b6f40edaf5880fc3118142026cd9a0a7625403c9c71162005b0dcb055117600e1454be2a1d78386aaae0ee308ed462307b24f91a60507e1947844f07ecb398678ed41e6baffa5182fb6618fd01f169b8acc44b8978ab9a119dba007cf60670a363244d6b18530dbbac9fabddb4b784e35604c77a2b491e64ad35174a815676903e74a21af981dc7079966f311b1c00afdd34b72a943b086383a16026b3c02a4339d40f79502fae7d600b13d9ac7da72404544b8a5e7ecdbdb3c692e52fe921c382b4473802a",
                status: "fafd0be0794c4b1db7abd9281e462dfb12166150f68442c1be"
            ));

            await _resumeSnapshotRepository.InsertAsync(new ResumeSnapshot
            (
                id: Guid.Parse("446163c3-feed-4e73-b651-5f35ed56f49a"),
                userMainId: Guid.Parse("ed0638e1-61cf-4bad-8fbb-a7c5d9c4adc2"),
                resumeMainId: Guid.Parse("d8c7241b-4d08-472a-81d2-87bd555c4638"),
                companyMainId: Guid.Parse("95e64d43-3715-48d9-9e6c-dfe346cd138b"),
                companyJobId: Guid.Parse("f9a03fc5-f447-4399-bc76-b126143bf1dd"),
                snapshot: "419271b7e1624677ac7ed962d343bf2ced23898a25e642d39",
                userCompanyBindId: Guid.Parse("1d870829-8ec5-4309-ab2b-53599874384c"),
                extendedInformation: "32af4e6dd221495eab3eb75ae7213bf4bce889eb881a42fe82eae283bfb1416aa177993bd43e48789d2b6ff2909ea42d943a0078cd1d4af392483ed32037b7629c0bb22087614fb8b5cf619f934bcaab5a7b4f1366e84873843ebfc1d958098657d316659dcc4454a6c64a1d5f33c3cf4ed5924ac38b41a382db8b395b5c2bf012805317b6514fa5a105cc072781d2d09ee6f2f7346b47c0b6117bdccacd8286e0e04407cddb4137b20e7893f28fc4a7bb76b9195637448c8e0049f8323e1aef7b15e024d83049b4bdd7065c07cccc1fc5bde9ea5fc747abb834837b20345201b1a0ab73a11143f88163755faa26e237913d1f5620f14c3f8f02",
                dateA: new DateTime(2006, 8, 23),
                dateD: new DateTime(2002, 5, 15),
                sort: 1361167682,
                note: "9108eded8c3b4d7faffb94b96bb5829530771ca0d77249c5b2b238b193862b83d7f6a7ba6103475a91639ee7353e92f15caac79efe764cd393a47d97b3cb299abee8f0d57c904a248c13f91d3a217fc3e6ab111520004b2280578c0170e99d1e2379ca6262904701b9838793546c6cab3b958d1d518946348e8332bc6a41a057010aa54caf5a4c678a830632e35d457511f79de08c4d4134b938ac1c8570b85660016e0740034f4a8a0a37bd2a8278ac0db00ef8dae149eda35acdf4459c132b5d9355a1d8274bd5b1dcf82b9cd97da372213c942b6140008e4e294c2439a13d0dcbd1d810aa4fb38a44ce843837f5ff436b90a5db704fa5b1de",
                status: "4edc978ceb1c4ce19df597d3daefbcb48d77d17657a6408b9b"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}