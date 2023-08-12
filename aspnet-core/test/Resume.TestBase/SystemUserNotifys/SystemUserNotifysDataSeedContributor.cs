using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemUserNotifys;

namespace Resume.SystemUserNotifys
{
    public class SystemUserNotifysDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemUserNotifyRepository _systemUserNotifyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemUserNotifysDataSeedContributor(ISystemUserNotifyRepository systemUserNotifyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemUserNotifyRepository = systemUserNotifyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemUserNotifyRepository.InsertAsync(new SystemUserNotify
            (
                id: Guid.Parse("a8081e2e-2fda-4528-82a9-437ba2b6416b"),
                userMainId: Guid.Parse("1395ccf2-2f09-424b-8885-c049558a6018"),
                keyId: "5069e9c89bd7446b80077d9cbbacbd193c829163f3f442faa3",
                keyName: "b4f84badc3cf4ea2a3de8de6d4aae9cc883347a54b154fa589",
                notifyTypeCode: "1c1283a0b4b545018c3db2fd524bda292dc48ca8d60e4027a4",
                appName: "ede23afa801a4195a52dc16c964b974b32effa46269d41ffae",
                appCode: "decfc19edc1e4b49b70eae664f1eaba449959f93cf9f487e95",
                titleContents: "1174926e6e2f461d86225938360e44e1ca554740733f4cef8628c8321146af1fec454c49948640b892e9904539ef173b5cddf2b4fdc141a3862a488f9972a9a091956becad1a473891e150067fb39646b8043c6ed2f34548b64550770ead19798ab9347d89d84d638b137aa08e927e64ba4ec0c3c32a4d2c97a7c0a8de9c2865e55ea38349f1471c892dff29fb263d16b5cba7e345544e0c8d2bf0c5b77a4a88185cf03721e34babbe26f614e0dfa04411c173fb76364c109d38735e0b49bb1b4738311629944294b2a3ab06d7809093c8b2a45ee172409895bf07cd8037d407714e15e2838a4fdb99586f82e2eabb613e8675a3f92a4085b7b0",
                contents: "dbfd07be067b4af1b15a7dad968025f9fa649581a93d4a60a5184b4aa713f2956013c56102a64a1ab3062cd41b23efa328b60eadf62d4ed9aa3a41c7e4454bf4283900824cc144bfb16cb80cf0effea64b6d83ad7b3d42edbcc803bcb7333f5cd8e17f2e6c4b48eeb4a86047260a6030dcfafad890f242e8a291c494325bd7efad6da794dc514d4e93a9b51f0192953e90a4a911e8cc475fa8c4c41628881951582a5e7711954fd5b531c3f5614a0bc2f8a17bc7b51d4405895986b689f57de4121bcc36772140b983572a7aa2f55bdc633fbe6cf01b4e9eb6b3f89df6caa809a2d004456a48473e9968f8a4324df6581ac96d39edf44c01ae89",
                isRead: true,
                extendedInformation: "57594237a84f45278fb0a7506e83d4b04eadba9298074768b286f2d6471d1c43fd35f24213d64367b2ac8b19904274913d5c2ac4ac1c40ce83010ff4175e8fbdc3cae23774d9464eb1b7bad004af2f497fdff38bf2d54db3b7139ebc94ac977af71a0a3e735a444296c392560ec9503708ed21b465444b2f9d85ef3ecc9a20cd7ecfdfe83b8c45589fd0b87fbafec872a9185c2f6bce4576901424f7c35cebcf00592d4f00124168a6e5dbee6ce517f970c57c1b799d49b3be49d7084bb8c5f0dc2afed6095d42979e5ecc022ca3997a143990f0703745289758efea1a85e02a135a960e87e04919ab703b13f1babb1ecab28c70569e476eb5fd",
                dateA: new DateTime(2017, 4, 4),
                dateD: new DateTime(2016, 4, 18),
                sort: 338725689,
                note: "91a416b8618e4177ab895a8ab8057d35289b768ac23446ab9ca2efe7c031504f8cc53f69fd0a42209beb7a395f6a8dca039e96fea97f4fa9b4ab18bcbdcc83e9a4ee8d660dcd440da5dbc3112a1144d5aac38f3de96d4d39bde572ed5e152218785137b7edc141ed9916226b8e7b667b15ef71ad3528472c8f23d07cacad973e45f198cb7ffd4b5aa5bb82152bca3b616ebc59270904421689cd1c7c5972facbd741ccda42db4bb6b0cc1914b17758045e71686ddcda4abbb6a381537dc65d1bdecf3cdcee1e4f41bd7c277cb559028387bea05d7d3c435283b940658e65f0df78d7b9ba575b464a95544c5235bfec3b9fde9cde83874b1b83c3",
                status: "b6363492f9de4d868b290125c349dc917a0418d0ebaa409999"
            ));

            await _systemUserNotifyRepository.InsertAsync(new SystemUserNotify
            (
                id: Guid.Parse("2dd023e6-4c20-427a-aa09-c54bc56a3b24"),
                userMainId: Guid.Parse("ffe22b9e-c638-4c35-b7eb-a6a205dc9141"),
                keyId: "81eda168db7c4d94998b3466bd4fedc695ebf54ba0d749c79a",
                keyName: "c7a3d63465cb4c9ea4afc40c893d1b25a5727b0182d74581af",
                notifyTypeCode: "ea87d42aa3d54deeb7869e2ea1426d61e645d2f09bfa43c5a6",
                appName: "19f4f907ba3a4b628a90ae295222ab7225b2b6aff89344ec96",
                appCode: "a7ae2f1100db452195745ab919e0ed84f58253b25bfc47aaa5",
                titleContents: "386870cc6c424115acc3b57836e931e0b26cc997b4364dd6a05a44414f27c5d6b42a91865d6843d5b6b17b5ee6ebe6b18b6e51caf7d149b8b6e1f6da8bbbb70f87bc0e60903a490d9547bb3f75801d7aa472d7ec40404dd2a6e462f3538743cfe3ebd21ac978496787df78c20e620b8a121629bc678a4145b4182afe9a4390786861e84cb2544f529c66e0bd24ace3008309be486c2d48319cd96d1bf882c7f15bf812d111134115b18240e36478a18bc8ac3c66daa74543a7453ab7f0b2b8c952b3c3f2093841bebd83b581fd2aa5c0ec4bd949f85643cbb8b58511d8ba1f0200fb8267d73745929dfe21f5890b3e1ee4b9d94af8c64ac794ae",
                contents: "1a692ce0c61f40bdb6d0f691c9779ead8174be998635484fbbfb645343e47a04739d3be266a742dc8a4cfa5cab30126a9a5649ca31e54a92bb7d333d430f71e1fc7b957ab04e462cb79b46b5759fd345ec80c5f3ae944f0e8eeceb23abab3d0a81507e50fd414c3e88c14966e6f86b301ad78a57d2fd43ffa2707833f913425f57ca05c39f734a6faf1f0f3bd5ffb7277d069b7dad5049bd897fb7b0d902d14617d8567b21214be8a46a1661e6b5f207f127253ddce94db08ea90baf44adba06db7fdaf9c9d74972ac2a112b1e3384027c234bc386f1466c856b7f9c59ce90c528febd5ca7f3437297d96d8770f6290fb8d18f77b0584e578c22",
                isRead: true,
                extendedInformation: "4b5d4abbc81d4be893301b988df75c4503c7055f40af469ba03bdc23269d3e3d05c437044ab54a4385ccd593fc8f011e5875ad718b3c4206a16defd842fb761a52cba358e2a54ad2b701af408d3eea15d7a44acb3ce7454896107902dc082eba80e2c91b9f7646e9b58c952787a12fda8936c57c28cd4ee783dbaa68fed6279633edd31be1d24e6fbd2cfcaabab9d32582c829d5345149d28b8b5ff29d97ed654c0ccec87df44a4e8573db1a0596c644c3a74a6430554aac9c5ff1fbbf1a990ca93ef5c44ca74c9e90101c7c1b4e378f3df00502aa004e5ea58234abbee8e2ba991f0f51ae1541d2828c8c439815179af01c6a5c82d64421be6e",
                dateA: new DateTime(2011, 8, 9),
                dateD: new DateTime(2011, 5, 19),
                sort: 2077237494,
                note: "ee950ba21fd645e4a8973fdf2dcaaeec4f3a327a28474633a7ca593f74a6aff930b1a20a74a4438787e7d6c7f23f69f3d66e558fcf8a44c6af19bc7159fb05c268d325451aa741c4976d11350fed9720925f35ee5f7e49c5b991a26186660f36a753a0e1ef2541959bf1e1e64a8b27e828551915f01b43ea8f966d93e10db4726cb6e27389a249a28eaf1281e7edc3624ad19925ac3c4bce9bb7fa492453424be4ed8e35f9274cabbde9d3f82073a3d15d3e6e41acdd4e95b17cae2a1411790845ce5f4be560408b961c8e8f45e618a894a5691f12b049e89c8b5b30f8d68d61561da9ae20ed49d586aace6b2f83492bed854cdbca814ade95b5",
                status: "8ee76f1c39fd40a49616eb704aff24b5d9a95ddd48014abb93"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}