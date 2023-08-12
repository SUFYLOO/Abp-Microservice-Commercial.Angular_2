using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemColumns;

namespace Resume.SystemColumns
{
    public class SystemColumnsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemColumnRepository _systemColumnRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemColumnsDataSeedContributor(ISystemColumnRepository systemColumnRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemColumnRepository = systemColumnRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemColumnRepository.InsertAsync(new SystemColumn
            (
                id: Guid.Parse("f2520c54-cbb1-4944-9daf-d0a42ebe8a5e"),
                systemTableId: Guid.Parse("7470f32e-050e-4ae7-a471-50da228083f4"),
                name: "d195c083cc2e482cba31b94b544f3759bb0cd779c3fe40699c",
                isKey: true,
                isSensitive: true,
                needMask: true,
                defaultValue: "f550f0119e334aab8237aa32a5d30f031e7df9fb8e554cddaa",
                checkCode: true,
                related: "f7098722e52a4fc9b857419b61b86129c3a10b99235a42b8bd2d84f171b5362828eebff10aea4091b4379bc0516b2c9cecb90b1cea574253869d2a385f5027f9b5cec953e3c44f6d89cd2a40a158ad655a01309085fd49ad90f558e39ff1b1b81530939d",
                allowUpdate: true,
                allowNull: true,
                allowEmpty: true,
                allowExport: true,
                allowSort: true,
                columnTypeCode: "0724b932ca73442397f409006b7fb49b446f76955cb74620bf",
                extendedInformation: "27dbe759476e44f2999550b58848e6b41fbd397f38924d7dba07565cc48153ebd98928a0ea694a26a81a35ef5cbe8d086dad1a0c786942d698b56cfec5cdee2f26d4a73ad34045af8337e7a29fa343ca1617d4edb40f4f508786a6a5aee7ae014fbc59b565d948e2807dca2144c2241c026edb2546124315996924f3338ef01b723b869962434902b5c6c66947d20d28b17a05bf1192461dbbbf7c9e872edd889b894b5377c94a298e7799a28277eda3267d3ca723884cf8a6a4a79aa934c16c1e6f240511394d338ee2e4e473089d0fd41c3ffc59044e56a4626fca4f9b2e603b40fe564c6e4f999f5d9aec8b713d924c40a5c58c13440d951f",
                dateA: new DateTime(2019, 3, 24),
                dateD: new DateTime(2018, 1, 17),
                sort: 138683043,
                note: "3efdc3963e2c490ab9ff9ce1cc88c63d7ae4bd4a0b7f42ffa9d6af8c904dde711e68e616a78f49dea1315221b0241c9319750998d7f14e01b700d713577fb1bdc00e9f7caf9348b48c9d8a994fb65025304668d5e4574988b1b062ff0289ad695dc18e1e92af44f29aff6a373ff093d8d6f9effc19d64b2c836bb292ae81699635771002ee1f48319ebadb2268bed2e06f6c8528bfa349ab806066e34da3ec2c485a18b37d9b40b69db7c9a7873fd5c96093b43a6e8e470ca6db6a93d37b76e5c89ed0146ac64bccbf24f9a490910875db73612fb67e4f5080e85eca2617490a672e11211c364d43973056f06e7d2fde4266a35f02ff42219be1",
                status: "93e1580914ab4f97b0ea3efd165c9e4de23c9598d1c549d38d"
            ));

            await _systemColumnRepository.InsertAsync(new SystemColumn
            (
                id: Guid.Parse("2da20364-012f-44ae-ae1d-c0c158d36e37"),
                systemTableId: Guid.Parse("4bf90dc2-56ae-48fa-a2f6-46a5608fcfa4"),
                name: "cf4144ff4fb948ca9d488e90c5ca9a83bcc51d59cbc349cbbd",
                isKey: true,
                isSensitive: true,
                needMask: true,
                defaultValue: "7355da7dd6fc4efdb99a83c685fa1d4e004e2eff15594d31b3",
                checkCode: true,
                related: "f33ebdae617a41a292c0035295a5e35baeaf217a1682462f9bafe64d548f659ff2a45b254ffc48dbac55db09f92cc284e4cf31a5cdeb43479ff36c99f8dc2d2b08f175fa65344f98b7bd4b820d8bd54eb26d4b831cee427c9516d631d3ecf262fc8b1659",
                allowUpdate: true,
                allowNull: true,
                allowEmpty: true,
                allowExport: true,
                allowSort: true,
                columnTypeCode: "8307122ff1ef4e3781b20633916ae76957fb1850be174b3a9d",
                extendedInformation: "c790d26f5e9142d5b60d73dc99c1695efa5acb1522bb4cc19e7446f223312baeb69bb08c6a8243db82eaa8700a4f203918398d5de09841d1801a34e99b4f0867108ba67142834b44ab3523edc24b4f02eb222a0e9f8f44498a522c0aab5a19126e5956f450de4844b425c0d98b26434f56c15d262c014da19bd6ed520a6f25c4176392a50003424a81533aff8980709241a05b2c0e3a4f2da586f18a988459653fc232c213864e32be149c3038c8c68ae81ffb3c923b4bdd95040ecde68149808fc839a34b6249aaa0c1b959e8d049c5780addd998b84758b890c6b0088eb3991c0290cff55b4761a3b400f3e2ac84aeab65836d399e4a019bdc",
                dateA: new DateTime(2003, 2, 27),
                dateD: new DateTime(2003, 2, 12),
                sort: 1188585750,
                note: "d51700bb014b41c1b904f3e9b04589cd61cbd9911d4c4936aad80b762f8ccbb7ae66fc75e57c4ae382c1bedb714f7494d30ffe6083ee45a6a62db8c9c048d0bebdf965704e6d474097a56f91c5890d3ef9b4b10454b84f61aac0fcf402f29b91d5fc9eb8b5fe4c29afc1441f8b5be0f57f73a826ab944e2f87b643ed93c28104c44e30b937d24cc8b3a8b12b1fb3a4fbd585d12522824f35ac0cd9c94a3aea62ccf369f5267842e1b0ccdb56b6a99a1eef91255bf1dd41de9e86d38546dfe09407d209a01672496cbadbc8dd5bc5a9628114e9b8a0af43c497795ddc5b6a2b3e62719d15302447119b8c99d4e24c435f1c781501f716498ea5a6",
                status: "970198a33a8d462c9ecd204afce41ff244a2afd3f82b48f695"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}