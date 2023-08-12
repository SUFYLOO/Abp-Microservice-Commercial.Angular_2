using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserMains;

namespace Resume.UserMains
{
    public class UserMainsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserMainRepository _userMainRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserMainsDataSeedContributor(IUserMainRepository userMainRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userMainRepository = userMainRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userMainRepository.InsertAsync(new UserMain
            (
                id: Guid.Parse("5ca3d1be-a829-483d-bfae-2e3039ed3ce8"),
                userId: Guid.Parse("f1756982-9675-4453-82a9-2fb7c74bbb23"),
                name: "001c3520855e4ae59ce0e217a2a3ddd394ead81a05d8419ca0",
                anonymousName: "7be5cfc8913f4f538431c63aaced12d32772a0a7f4ae4101bc",
                loginAccountCode: "1ad1f1f820dc41ed8d617954b9f63b48e2357c15cb0e4e0aa2",
                loginMobilePhoneUpdate: "9d6c0a5fbb1a41eb8fb820f45a12050b2be4045c022e40d195",
                loginMobilePhone: "9cd84d0303e844d1b9081e5f719b037f008ea762e1a34401b5",
                loginEmailUpdate: "d38bc96d375f4e59859fea109c59fcdf135722d82ca34b75a075916a6c5284d0addd28008320464686bf91e681a90c4e41d5643e28a140599d61d9dcae59f7f1f0777c0a0a4d4b48805c090902f3d74700de503fb44d474f81e46ffe6aaf55e7b14e1674",
                loginEmail: "b9f37150b56a4e0fb8cefc5b43d63b7748487c7707244e27be6cfb6479484b8b95bc17b41bbe4721b6c4e4d7bddda2c9be45f58ac4c84fff955c2fc0eaae9ba1f43c8da895d44c9ea638eeae9657ee13d7f9500a611745b5916c3c384840a1da7905d0ba",
                loginIdentityNo: "4954ae1bdf5345eebe5bc8d760e9ff2e4d85b56065ab4305b3",
                password: "a4ff4e448fa449009c2041b25d6e7808bd48a169c3414c808839a3469e68bbd569ed73785e694045a951200577493ccc3af86339377e4adca8ade8c3c2146077c4297cbb013647a18fa45e20f6f04163959de351302d48ee94cd49d177fc355dd54a9ddf",
                systemUserRoleKeys: 895167167,
                allowSearch: true,
                dateA: new DateTime(2017, 4, 9),
                extendedInformation: "87b98606b58e49fd8a304b7bb693abbe5b4e8bd6b1b548abb809ce48931a9f46451a784887e5409abba00c005eb1aaf450af0dc5b0d54a9da6d905c16d653743e73322cfae16455fa04bbbd0868762980296cb5dda9a4062b0eb7aa21d4bbeb3e78736a6bc224590b138bf83cbecfe69ea6a9ce3546e4d98bb11c86c3e0a80665da73a49d60842058ab0f06aec2f9cab9f0c5916d08b4da99aec43642f5a218263bc4ef8b46c459d82f90589c8f65d31de27a25fd0f948848cd4e899b7811658f8c2965c989049f7af4056be46a38aa89935c400594a43e49c43d412dc6563566e26f7829b004279b8416e299f53d52d7f6b15f64e2944a2a165",
                dateD: new DateTime(2016, 10, 18),
                sort: 680642744,
                note: "39eabbb7f79048b5afff9140baa30b00ce67ed0bcb544b9183e1a3b1fb08275eb7bb647d1d734019974c925cce21c8539ed5c2727cd94e5ea884863110d6460c335469f94e3b4764a8c0d6c8a389cd89c6a8025a59f94fd5b8335a6b0b3785af291e3b0db53544519be12c0e177b0b7be07e690aada04817ab1ce1608c0c11f34ee993f696a845bc923440c41399bc4326808d7d7cfa4c36ad27917b773f8cf22f59dd9b67754726adcfb480eea2e8d63942d679b4b945f9a062003e9fa8420a65510dcdf9ae4628ba92b18943c8055fc106290bca0346ada67d493a035adffbbf07fd30257b402d8f4a4a753b83e5b4b4f7c5b8b2e449de906c",
                status: "1d1a7d4f8f654869889709129262121a7cbcef8eeb164861a2",
                matching: true
            ));

            await _userMainRepository.InsertAsync(new UserMain
            (
                id: Guid.Parse("0ce3b2f9-ad1e-4fbf-982c-a9fbbfaf4fc9"),
                userId: Guid.Parse("8d7b4820-6e8d-4275-a68b-29d6763a0e23"),
                name: "907ac8c4585a4b9387131af80ec9aeae07105d81bb3d46bba4",
                anonymousName: "d7ba6024bbf142e8b162618916dcaf06da52167ff0064198a4",
                loginAccountCode: "8d5386376130482e9b31f67f567330c995176a6916e2466684",
                loginMobilePhoneUpdate: "623de56656e24b1aaf184e142ae48fe4087eede5341445b0a4",
                loginMobilePhone: "386f56235a1d4dc5914ba445ce29bccfcb993f34be0a4c098d",
                loginEmailUpdate: "74725f9815e34565a5b9bf3d902be42b8a44e4277f02426aba608517cf4de1eab7f1eccb5f3741ec8bbaeb41fc6b4481f044bd68341643e8bac81dd44ac9f83dffc6860a9bc043f7865180fbd3ef2a31a08808ff407443118955f5431b6406f787fdbca0",
                loginEmail: "b3928ae292184667bf3a60c53e1d1b238af13a6708d243ccb08e6fb2d6c6392f787426c1f83246a3a420bc80bafdf398d4c834a3e20044019794d617d5e20a637dffc1ab9d0f415995124cf4fa962109187cf256b7af4acc89e222c5ce7ee252afe1d2da",
                loginIdentityNo: "fdbb933e8f2e44d6802a85e29d7f3cb4ec6a18f91f694947a1",
                password: "6d11dc7e8f7249278b6da3d559c4c170f02d7099d98f45299cdebca3592b39158c2c17f98d2c48e69c6dba38a51501a96d65aaa2c3f745889f757ecd32ff75050438cfea0a3548ae998ddae1ef02f4734d52f281a4a9437b8d94c4e9972ff3f7cf81b587",
                systemUserRoleKeys: 157805157,
                allowSearch: true,
                dateA: new DateTime(2006, 2, 14),
                extendedInformation: "637ac5667479496f991619100e78f38a1f87bc4b63904b90a60220be872fbaaa929bfdfb51cc4a0eba3306e6dd17caaab3b3e02a850d4c3899bb92ef75c34e74b6dc3d7b84e040de8c79b014ba4c8bf1348eb16fbb924b3fa464b2bfed42a85982db1c9a8cfe4b529ea65d407523d86bcb552e9b4f2844fbb392be7b8c56cdcb68d32e3be2db43cbb2832cedbfcf01d338def34cb1444f268ccc400f48534b33338bec6df2bc4a758f14e612d0a9a3a5db4d3f24dadf45e99ae6f7ffe9bc70543098f582d133474487fff37e976471e403671a93b89a4a8a9bffb8175ec2e2c12b6a8db09556404eaf2325921c42ac285078b90a7198499bb66a",
                dateD: new DateTime(2007, 10, 16),
                sort: 333015040,
                note: "248ecf8404804c49a4305c4dfd746b20473b42970b454e1f87cbf2e5a2a7efc0bde0cff4f70745f59c2d850e5dabc2d307ce7698c393400d94f10976fad2a45783540a4970ef43f685678d757b70f12c581fe77e7b644ddfa98795586c18ceae5d6b795795e9469cafefa420e5350503564eac62be8a408b99e2a4ea582a04abb4212e32cd4a4909aa387d1139c6daf4b16147357c2847ef897aa3aebc32f23bdefca1c71b774570b5af3dfc6606d2fafd48ed0b064941d4bfb8e6949f0ac995783ac439207c4b1e8c088df7ad14f382b570ccce06b448089882d35427d293cc92aef41e60194a658ecbbba67f32847042ea855e7af14e9e9c7f",
                status: "20fa5d222ac741caa798308665476d0540726795e4544eb3a2",
                matching: true
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}