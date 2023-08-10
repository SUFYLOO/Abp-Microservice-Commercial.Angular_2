using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeWorkss;

namespace Resume.ResumeWorkss
{
    public class ResumeWorkssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeWorksRepository _resumeWorksRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeWorkssDataSeedContributor(IResumeWorksRepository resumeWorksRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeWorksRepository = resumeWorksRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeWorksRepository.InsertAsync(new ResumeWorks
            (
                id: Guid.Parse("b8cc966b-2b59-4aad-aa17-40b4339f35e5"),
                resumeMainId: Guid.Parse("709c2e9f-c2c8-45c6-92de-8c4ebcccb549"),
                name: "7f40e53830534d369d1454fbf18bcee366b6ae4756f84836a5318a6ed42aaa94a389d0ee8bde43beb6526ac04d13e526dc9a4bb48a2441d9b0350d19c155ab97903ba116c5d44b71ad65aaca66cc6952f7c009cf592941f1bb7ca0dcb72718bc24adbb87",
                link: "332fb8142d924309ab81bc65f69abf11d2bbdf76b2014eac9a5241ef49fb78697470906f2ba84404b36d992c7617d95c6cfa94fead6e44b0bfae958dc1a1f831dd9209ed638148518468b1804b1b1f60dde6184d1d184125a1532f059599e96dad4c739632a840dd9fbf11acbea3cb7ad4933328b06b437ba92f2ba2ccf5254a317bbf739d9d4daea46fe86654178d63f804820618494def863fc76bfe91cb8282ea7c183de14f7eb9442a5c934e844fa70490c907804c318d6035bc51146066d26e961dfad84fb0bb80fee5d4208b4c690b8e04f22c4260ac6a027b259e2a12830d54d5733c40ad8efe13556904ad54440561052cb0495d8ddc",
                extendedInformation: "38facab6243c4db3a1e7642a0c9a0cf92930049ebec54265963186f85d569f747c14beeb89714729bc18f6954389d0ac55605244a0fd4046af2806733ca32f474b8e1084c7c84ebf9e8a6b83402484faedc2c097bfc744eb87997dfbe4a992eb8fca7b48cd77462f9c3462438c16ce802d5611773df94e6ba3e23f81af60df0f73d8301501824a2697781781f88703975c6e90dd9df24ca2848c5c713e92ab2d1988fc8504d449399a80e22df5a12de38a21cf092af14ea981615d00a388238cb297e827a4e44644b842bdb8d18a0fcb2bffd749e7254e378fd44ff445a37851548123bab943480a8771181c36e2c1191f2f09e57bff45f383b5",
                dateA: new DateTime(2011, 5, 5),
                dateD: new DateTime(2016, 1, 1),
                sort: 2072505544,
                note: "254112fc395247f58510ab6c8e2773044e59c338722d4887946b7441fbaac8d249591123961643d882b4d3d0056aa7b6347cb20e513d4c57b04c9b35f5a1016c765e491e672f4008880c61922c0361efd42577bcfa334811ac6a5564521a06a33ebf6ed0e0884766b3d73988f9b5bfc5f9bb5167a4654974ba309d0da9fe63d2b9424720dba24a63bd41998b61c689e7cbda9d2d1934447682cab4ea642a736eddabde6642c74fa19245f77b7246e3f153ee3d28d69b4ee1875326c857af0c661c6e914d1d7d421eb76449a9afc2eb647162b0e2502349b58db2163b51b3e8c5fcd0fb94ef0c4805a6c626552341993abfb0ee364de04c77bb36",
                status: "b506b9befd284d3f8a59f14b580d6f6bacf70754feef4765af"
            ));

            await _resumeWorksRepository.InsertAsync(new ResumeWorks
            (
                id: Guid.Parse("0b94fa65-2c07-4070-854e-3dca34b861e8"),
                resumeMainId: Guid.Parse("495617cc-cda7-4717-bac6-9603bfe71527"),
                name: "5fca5d4205ee4d97beed5a2c32c1623330119397f24945f1b4bcc5d8f1e8ea6e0704bf9081324db8a40d2566c7e851676b194f5868fb400089064a6e136cd38a21a9d01a293c4fbead3243e1f1805a5384216e4fd37c4912b6066702b78423b6ca330e4a",
                link: "ed0a4c7d791e4647866946400fe43fbafb866ca4242e4bbbb36160d4f51e0c33af16bc5f464244a79b35dc0a72e29e51a65e712b327c4ed88b9f404a5fc9512635a90737cdc84b748ad5c30a01e8c4bdb8185ec0fdd34756ad71e0c03189330bf5c67194ba5d435e9315c2025966528f37ecbdae21c24ad5995633d13be72278668e8b691f6a435db2714f9e591eb07712981001567a4fd19898e24bcfc30a4c7ec8ff2bb9a04cefac64bb5d4c008db9d3a3adc3580d4761899e93e36508ba4c6201d656027c49e692b60dad17e6191a80dde91a59aa42a2ab0925e4cbf4fe072d3e64d0f6ca46dd897975b244579a1a5eabead270e042b3a568",
                extendedInformation: "9f623445c8d84f598a61de44f38a54804a30af060861450095583028122ee4c7c68de3f5ca9d4737b453d40d13f05d1b9f6e45860c2341f6a6bfc14a9ecea74a8bfb584ff10845fc9d0f0a904fb5854a606d365277094c0f803518eb674b20798480687ffeeb4e5daaedf77ea5d856bc7d36878369764942a4f831efd193033eca4576751516434191e5459e39aaa516e131d5d9cd3247fe8e571d06e0a209bf7849bde1edce441db6e261e4df5dd2db20804c8792174cd2a2a45201dc9b82b0a9256a2d9d3d4c20bc7a2661677cf3b03584b9dbdbb14be79a67186f85b70e73293f93dd48f642a184796759d1ebbb776dfbbfbfbf4d4e5b9325",
                dateA: new DateTime(2009, 11, 8),
                dateD: new DateTime(2017, 3, 11),
                sort: 1733343300,
                note: "d2116bc2ebcf40289d515e1de64cf334c2a20a006ce3479f99dc336a00262f4c4017879f462b4b2aa38404733fd4e62198a595eec7d6439683c155780a77802c56ec7dfb5a124aed9761a7a1d488c8ca764bd7a8b8a6419cb56f05445c77c565919961f3b76f48179d50a05826663fb392b39c295ef94958afd16cc634f7fbeae4f18a17418a4de4a24cc6bffda879f51e2d177b39fe4f5382474fc117eff365ae3d9cd5744e437298f681c60972c61eac5d69d69c6741f7bd77d4e1aa75c4eff253e62143d84d42b1573c3235a570124b0bc5f7a7b7478cb17f0fac1a58cb2598916b871a82402abb773d21ed27436af318829328b14d338cbb",
                status: "656f1b1fd7ca4f128a1f033fcf3da7d1d54e297ea5d74bc78a"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}