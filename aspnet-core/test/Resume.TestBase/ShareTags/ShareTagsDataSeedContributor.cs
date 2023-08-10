using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareTags;

namespace Resume.ShareTags
{
    public class ShareTagsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareTagRepository _shareTagRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareTagsDataSeedContributor(IShareTagRepository shareTagRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareTagRepository = shareTagRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareTagRepository.InsertAsync(new ShareTag
            (
                id: Guid.Parse("63ae938c-1a19-4aba-9785-4ac9118e4e29"),
                colorCode: "f303b4c0d0b74ed2824c571b7eacaa080721cfdeb938423391",
                key1: "3da3e6c72c3c4e3388de06a8e69fe739f1f05f7d029244b7b1",
                key2: "aaf584eddcf04d039553a7a5d2d2e16e017f817026484effb7",
                key3: "54635f2dfd9148678cd1450baecc66b6dbca9b3974fc4db59b",
                name: "f0d59f7f63024a8a8068222d919f7a3da3717e1cb874423c9be35faa7895d8937233dc11aa1841ce9886481e9009f44169cad702fc174b2fa358050fd53023d54dccab62de93459cbccaa587452b258b1916626b740a4d9bb945e12bd08244d06e3ff30aa9f24bc8847d66a7bdad00f298df3c6b6b2a45fb99d98339d6d9ed297db45a3f08da4d76aaba88b6250961553df53067c9894f3e92080cb871ac8bae7417e2cc954e4edfbe816f4d5ab080b28cac6fa66f564124984cbd3c9a14d49f0e2dc01a3d3244cdb6b401c420475ecb5c980ae58e84462f909d5d2222b9bf559767b29a522f4b818d338d9c1a6d0cf28fdc8f334a0344868334",
                tagCategoryCode: "077d157150ea4b508d35187c1cfc6b3e7fc3b7de6f2c4fa980",
                extendedInformation: "bb3970b61f5e486ca9530ea1c4d75c4c48913c6d48cd47d2aaa09f4f039243ce71c4026b30444623bc29cff35f9fde6fe40e708d837045b78428456cd43dbc605591e56fd7834172bc81ca86f44075ce561419d952254559aa1e8e4ffdb9657f0ba9d1b28291489faf533ad4e1bbecae0de5a87a820a497b871d2ea3feef71ddb47575613ff64839ba04778299e96d2d2d6a3a1971ad42c8adc8d01c27a82a54abae4986ddb14017b9696adc65323352af2f98d1b9e245998c0d655b9bd1d99d886cd4f5521947dcbd747164faebe8e68ae2ae39964746d58fb6a1027a32cf7bed41adcb45d64954a6655cb01ac2a403a17cfefbb11e4740b747",
                dateA: new DateTime(2009, 9, 1),
                dateD: new DateTime(2016, 7, 5),
                sort: 211711469,
                note: "c3544914d59e46298a091e77df35a0e50e186a15010d4b45a9478f16f7644cf7776fc8d72c26449bb1d72453780c65881a0482ccb796437d84c7be6cee0106493c6030f937eb4c0cac4bcb2eee0c131b6ac1c7eae82041a6a4039d2772c491999d35d9d74415453699445bf40c0b85896bcf9f4c1c424f8c99f9fa18fe017280e79ff548ec08471a80876277095d9355874d6e7d7829473387d96bb58cb2d26327a278725385479db7cbb21bc4698044c583284fe35b4ef8968ab7b464e110867b15594b84094c22b599b6c5a2d4436c31d60463f6b3495483608ebc7f8babc4800eecd63f0a48a9bad919e8151e167b181ce91a79274203a9a3",
                status: "c3155923c65941d2bfd7358eabc8b400ee3184959b5c4ac195"
            ));

            await _shareTagRepository.InsertAsync(new ShareTag
            (
                id: Guid.Parse("bee2c53c-006a-454e-9af6-871eba4282d0"),
                colorCode: "6b8b59aa628240eb831ba5a3394fec76b0d25127338542558a",
                key1: "3d7d4f71cb3d40b990de85cb26a089171508d01324d84c33b4",
                key2: "c95aa07f5dae45ac806f0b3e405631946e83a17d062b4ee2b9",
                key3: "8cd81e5a1a8740a7ada55021ab5cfdce4689fb2599404e09b4",
                name: "865fa9f475214211b0f343a7eaeefeca426b91cdad8c4cf8b0623c5a2835ebe10f4bc7b4fdc842d2aaf745a5ae7fcd5b525fcd31568044e38c44deb1f802a22184c8f79083064fd888dab55e1996ce509e611e60432f4e86823ac1410575d99bd0a2ab9da0f742c78260adb312fe4ae9a559e00e07f043359073d9a689d651a63c5f7c2c25904c7080e1ac42214c68186a07bddfdb474db8a0fbdc5fc40dbd991340e164022a44e6b41637501bb776fdf368c877848c4b1eb82ee26ecf0ac92088b86589a0e14d49bd90eea4a755ed43c9eea8c294904678903a2fb18a649443671a4a8ac1094e41aa9591218ffa6292189e40f9d7d64a38a1ab",
                tagCategoryCode: "f3acfbc13e2e4d548e01677100ada907fc3c93a3ddf044e89d",
                extendedInformation: "8763f972be9f4f14ab92c5378306b4348246d3b4cfca49d2a3b55dd8a15079b8a0f471a184ff462a8191eafb3c6c554ce64a0e15251e41489d6c9b30a23d93a7b99231d62d754095a8a8f48ca079a6ed9913d47c127a486fbf30ed03fc41064c173136f1a97a46fc97206f835d9db8a11c89be5e765f41099f3d0dd1832ad168b7c4fd773af54a2c9260db03c6d26c7168833aecdb544f90b8254aef37cacbc8c625e9fc95324627840e3cc83c0d597ed25e70d26b9646a48e9d50d67a416733739feea5968547bb9ba126e718e5852de3c2cab86e9a4bfda7b2bf1173421bdc188347b5bebb4e0c8f400e48a3c435217b75f4d2822d4e2095c6",
                dateA: new DateTime(2019, 10, 26),
                dateD: new DateTime(2013, 7, 14),
                sort: 2014033805,
                note: "35ca02ab17424ab5a5555df2c0ecf66b83b211bbcde6419db3caaea65debe8830f46026dd3ea4bc2981ee6ffba2f8b6d25f39398430f4b868d0b4d74b348378101d31cd1630f4bfb9f3203b991612375026b27e9a34845f48e9cb8f58ae254944ca34f88b3a5477a94a0de94015edbe53e78ef7f89ae43ba8b00d80be7b9f4ddf5954a4eaf4849f0a18d696d1b04222c738ec8e7d55c4fb595e2e5cb4f9f7ab3fb470311b2d24d7fb11b2502cda7bacc7d232e4730f745098b6b25c7ba1f24dcc7ddd31848ad421c89610bda36dabcb67fabf4907e8a4b66ba7d707c1ffab96ee4c89d8c732543fdb6081553d36fcf5e9097b1f30530473aa3dc",
                status: "5d5bc851e5bd45868df05725c3b05be5aed5098730034cd9a6"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}