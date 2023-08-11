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
                id: Guid.Parse("b7f60459-36ac-4602-aaf6-41b56f6908f8"),
                userMainId: Guid.Parse("675db280-fed7-4fd6-8873-a9100e2d3b5f"),
                keyId: "592fc15def9c4f9c874be0d9f99b5f1aacf18f3665b7470cab",
                keyName: "308776732a744a4dafa7b6cb4a41f3ec79697d0f07b440c4bb",
                notifyTypeCode: "e07f85a97ee6492fadf8eb63cb1283f1d4189093397544b692",
                appName: "52299b138d5e45f48268f490edf73880fe028c733ae24aeb95",
                appCode: "7ac7ae340f404d888d2f6271036119331f2e2f622e794aa9b3",
                titleContents: "076eb30dd75743b08641c57684d2cef00d60097207bc494d8d1e8c44bdcadf6153b0a2d2256443e2b4491711ececea9ffbe9561484c94ff5a29d3cb922e86b92c5f85cf66cfd455eac71adb664e7481eb2fa1bb7dcbd4e6f8ef540f3e440d73909fa1d91c69f4e48bcf1d7d40f839054e82102d921444e44a29714dc8c3654f54477d5b02d774dfc9bdd9f6c0f4d9b8d146f5df489e7473e9751f672e25ed1c707378d0e4d384ed9850aabf86c4bb7e3c5765f48ac2c47ad9b6d212a5ac517436bf17999aa0e4c33bccdba26a6284536d2c17cd524734285ab2f91f6c6cdcbd7f7e715f9a90440679a0ad6d0f0d3e1b1e4b17726285c475bbec4",
                contents: "4f1d747835be442287f65467d0a50323f1aee432c41c4194b08c0c52084d594f1d6d302c627147e5bdf54243d27cb8c5f9f6e99664fb4c64806427a2c03c8c697fc300ad2cee47d8ae8481f4e3e40c360af5a1e66f2a41788765ed8d38a0a96f9cf1a8b50d344b82bc77e718e1544305206edf3323b44a539576430a90a737e1f4cd986b8d8b44129f755db05f45e90558c51803b171480f9952b541fa064bf47e7901f120e548938e8ddf24a5ca254347ace0d350e947eba03b7b46027b1cf1f0ea0f85e4844b5abbdae0341e8e8686bbfca78c27094accb2139757864f39896879df4346604670bf5ed2b41e718cc1ca818d308de6447ebc7d",
                isRead: true,
                extendedInformation: "094fb1f44e1c469e99162b7157beb225b7f5f6701ffe44f0936266113b3edd027c03f6a9900f4523b4a962c6c43e0f065c9f8c62188b42d098c1dfef528dda62d82b9ca3d8e846fda2f4e55d4336230506e1966623db4ebabf7b343aa60c04fc1f196d94243a490d94a1ae2ecd231e69306741db0ff6411f87f677cba1af35fc5ecb4de8dd63485b9d7450cd48fb4468399ba1dc78984ebca4a48f2f7c1e9ad45eedb1357d09414e97859d02b2f14bc179c5922575a74158abe1ef7e1213eef149bdfc0013af4f11af0170d4603328056b923b91965a44f781328c601733efd29094825be425487bb22d11067a30b73ea6599b4489944ee4b71e",
                dateA: new DateTime(2007, 8, 27),
                dateD: new DateTime(2011, 3, 26),
                sort: 504341649,
                note: "4b44a19c99ef4fa886a535e47f10ebf2e11b4d0785604c34b7a4d1b15bf9062b2466c9db12ab49da8f82e166e9647de4759626b2ede74cb89718df044c39d5f27da6a43968a548ea831369c9c2ccb187e086a1d9cbe243d4b605418963fca096c08f142f4ed74266bbc542d952d1b7adf9b83ee063ad417fa62a044a68efd17d2467e1f592924873a32e49aaca559a8825975a9247a44bc7906f868a27a46b6cc229519596e44c51bf8fd2d80f3b322c8afae611bebd431396f7a0ddfe5ae36306dbae07794441e184868bd0b12ec4555b36e11febc24a23b4d5f3dd447b9bf607893db577834b519a380bf1fc2f7e6e926da0564ea04930b0b3",
                status: "074e138666c1478e911d23287dcf6579665bce5f245543f9bb"
            ));

            await _systemUserNotifyRepository.InsertAsync(new SystemUserNotify
            (
                id: Guid.Parse("a9f8a7ad-3f64-4a79-8a38-766b7cdd7d23"),
                userMainId: Guid.Parse("bb053a45-ebfe-4090-bc39-fe9e43c95565"),
                keyId: "d2c2eedea0614c4d9aafc47a42dd430ab7ca5d20bf89411ea0",
                keyName: "4e829e8cde774f80822852266ed60b7bd1249fb1c26b4c3893",
                notifyTypeCode: "eeb10c6e0a4044e39f2f90dfd32b629cb0298f5a66b24a5990",
                appName: "8b129ad60fa74beba025d3f4c58295e900f80e1b35164b8991",
                appCode: "da681482128945439bf33546d467c5fd4c903bee032044f8a8",
                titleContents: "df0a7466179a49e6b1e958f497f5ca49451e083fb9f64c269d82e3684470025e2c39614aff8a42748b0d93b4d2d041fc7b19d25b4e124a6a8d6f3f6c8263f01138e94cd62e954c7aba6c426ced6b8418ad31b5ea100149d2bf68c016b61eac42c5555341c69149b0a4afb141c7e179821421911c5e964f36bea50be2dd83a541038f19d9f985434b9e8e4996fea902d8f3bd69a0b8824242a0a0b158090df4d364a291ddde774bb38d446a807df9d83c1c51902511cc4440972f9939bada2f39d584b27359c641409a53586cbaaae233caec3940552c42c2a368c266d6787ade07a81489f99843179d6d4448d21cafffe1cd7d45b36c41329e2c",
                contents: "d47a4a6b53f64b149e268b913c06eda96a5bc57bf4644eecb3ae849a8ca6f71aed471583d8a94bb8ac7f825c462d637982cc1f14b9ec426188bdc408927fd90f51831837fce841589fd7ef1ea1830eeeca5f9c6a05e04f93bd36f9a278cbc4227aa5eb89ebc6459384f343e8a1097960a7023dca0ff34fdba33cf9e97aa8bf35fd02a7be24bc4926a5d5fa71924bae91fbfde8d318a4469c81779fefa5b6a07cf848137019e942d29a1de0297d05249a2644285528464b7dab4228d85f5d9084015d7ce003714b51aaf58b2d60f184c13629966e36a84827ac9627e71067a7fe5857f8365a2b482f9cf2c37035402911e420b034b067451f9e57",
                isRead: true,
                extendedInformation: "fd1a53eb76c14000915130bf3bf1103e5c1537ee744b462cabc616f8a055f677637c0b101588400cafcda783bd4cffa405ebbe83957d4242aa0882c94841d8c7183906dc707745da8664a96486b4e9cb8f40d1d5c6474ef79de8046c745db5aaccfdb0ee3872495d9a4e482823809b9951292570cc59487999b61700ce61dcbe12ca153bf4df4ddf924958ce132f04c52ae5d69d16324212a0172d3e5f89338648480ceb93134f01aacb70e02e64b8e3be06d77739f74e898e51311629d78256ee6e147799314beca679df1aa6a2c5a0fb60cf7d450847bb9131db1fca4566c0244cf690565b42fa995ca0b0a758c23292edd75f038c4df391c3",
                dateA: new DateTime(2015, 4, 9),
                dateD: new DateTime(2017, 9, 20),
                sort: 660893008,
                note: "482f7a8563d24a6591c6451c621151e84bba7326b9ee4fb889cbb1ff724c9ab076b095c4696a472a877e4df644c0054ff4b6c65210354f3a8c636ddfbb2ab1307fb0e89949a5454980ff8ad3ec9d1ef22c250e90880546978004f4d592dead226d8e20db03cd4d8baf80c4c453120a4ef045d7aee7734934a7107ec480deb9e94aa94d53c9fb488289eabdd5acface73f360be8e8c884c5589f62451b6fd16f4f9b8e11397cd49d6a0a4e7ecc55d85a451085d04986c4785ae89d5ec316a3167ab3fae623b8f48269f8962918d4a6edc6233ffdebfe14208aa2eb2b6b2d50b87b8b1cc7c3de04c47ac6e103fa99d6d5a9a951f6c130b4ed79680",
                status: "cbe78ebe993749eb95172c2785232e90f34d8f806b19403ab7"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}