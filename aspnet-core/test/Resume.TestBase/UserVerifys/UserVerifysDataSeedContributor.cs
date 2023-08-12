using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserVerifys;

namespace Resume.UserVerifys
{
    public class UserVerifysDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserVerifyRepository _userVerifyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserVerifysDataSeedContributor(IUserVerifyRepository userVerifyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userVerifyRepository = userVerifyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userVerifyRepository.InsertAsync(new UserVerify
            (
                verifyId: "82112fafdf30476594287cb94a374e914db2dff29dc54defbebd81fc8c25b88ea87aa906093442ec813842ec468f7daa4171c12bb2d6415996da381d8868ae601ad0e38a0d794e16a825fa13e1caaec8688c3dc070284715bdbc2a42cf228bb7f96ccb426d63492c9ce774c51e31d86f2c2a582c96db43d99cc218103123637a02f056bd0fea457485ec2e609181d229ef38567039ea4d11bd876d8403809e5a40177ea678d043e092df6107c34adec6074b6b743da14be89d0595535b6cfb858c6363ad956044cdba149c0e462b594fec45c2109a104a7c81eafdfedb0973fbca5f8cc3f91e4ff7ba140e9c5c2c55d08ebadcfc39a047bd93e3",
                verifyCode: "c758e308a1334cd6869853857170f46ae350a663ee94469cb6",
                extendedInformation: "7924287991794193ae3a2e6a8e41316e292fccf354f24ae9a7bc3780946be36e2ae86c811f2648428b7180171958b554bfbdfa72c0b8478bb77247ec1522a71c23cb3b9304d343c7afdb9dcaf01e4deb38f252d27a9d4c2c8d5cd2314194f6caeb26967c26f0475d912d44ee7b987d6229c309194f9a46409503c4a7baf7ca3e21149078bf034fd78b008dd0e3c5aaf27b2eaf640b1c4a468169a29ac83ed5f43d44ad73fb4f48178af11b164f7a5afc81106e657d414bc49aecdc8bdf79dcfb570363a29b934444974898e282973662d0fb1e17bda3466f862f841c445f12a56a4fe80c4d604a61bfeac44a06110e7dcccd692bde3045b7a840",
                dateA: new DateTime(2004, 6, 13),
                dateD: new DateTime(2020, 1, 7),
                sort: 1741963143,
                note: "20b74e7fb45c446c95ece23ce79df010e5665524eb25416fb9e810dc8fa202b6148316016a2e4d53a42c8670658171938ea41fede0d5493189dd695cfec84daad8ba790d4de14661a17e62d79a42dbea914445fb791a4749a48f9a450819b64537d570968a0d419d8c9c7321d40d89a2e0058df909ab4af1828a95181b577bb804e82c4f72a34352ac2cbbb97eeb8ab48c5a344e21244b89ad54531333ea8cbbf95116c72ffa4cfcb39bdb94ce51dfd58b193e32e63243a8af79cc9cf1f36f6be6338a4dd1dd4c6a9d331ae79d54082e64fffef9418e47009f7263fd683d7bf1569a37714bb74d6087a5e1b8e192207e1b0d42c05d6c4de3ab44",
                status: "aa90febf34f64ef4b7e3966a84166b264c5ce160223949d89c"
            ));

            await _userVerifyRepository.InsertAsync(new UserVerify
            (
                verifyId: "a926c1d0a98344ccb248fa7577e90af5e69ffe32ce9a4e0083e3671e3fa8b03c2b82a638c155440590f7d625fe589ea288054394392a40abaac42f11609c2e768c938a2b7f6f48fd9c8cef6d0be770c31389f0db053b42e3b60be7d98ca52d51caba1ef6f6a346ae882bef6fa8ddf3b6d69bb5ea58b945d4ac1339d511efff4ff516e9dacc454da4b676961633156fc5e8285cca580245eb9ad4553e60ccf33e6ba791362db049d9ad4c9a6e6aac95ba007129f0d3824cd18db9af206bffa2afae44e81f4dfa4788a159cc314d835a403a64858a483a48febe7f60576dfb3c6afb1cb4e58913436e90e3fa1f4af086cd33d16e985cbc4142a9b1",
                verifyCode: "32d6d00b17e54edc91870ea30a29fb9bda0fbee9995541bab7",
                extendedInformation: "d84a8ba0537d4e13b4ed89afb1d09ed4294acc490a2343c0bbb2a0a3a441298d2d301487e9314576abfba14e035e97f6c3360ad5f4b947b3bb2b5ec0a21babd58235923cc5614be097fe25909a5456698d9a971890ca43a0aa55cf6a87912dc492fdeeebf63d46929d95a28e98d4026ab47c0fcc8fd34e2286b6b77982859acd3a7e78db95174432aeb4152d5b9f06f6db3191ffe2a14bb1964602a687aa19688e09d4998b84415facc4f2cb9259edcb801735932b6740b9a0300d9a2108e2960380f849cced48d7bf50d38394003b51ac5257cb9c204bf0a41f04c86372ff69808135822a7d4e3381b9bb7304a0e4d5921d28de62174ef49e5c",
                dateA: new DateTime(2008, 11, 10),
                dateD: new DateTime(2001, 5, 2),
                sort: 725784221,
                note: "4e7fae98605a47b08dc729558439a35b4446d91e8ce3425ea0bab6c67399a11eb353535fcdca4995b5272effa2b86b9f34b31dacf95f41faab336aef3c3eabecb4c5a5e2816246fb813bfe03839de5410d5a5eee2d3544ac9134a79ba72d11b995fd946b6d70444baa7f7d5a7ab00816a03856b0c1e445ea947888ba3006830be7edf3e812754513a28147f880fbdf0c77f3d41709a946619a37affe598ec78e8d9b0959ee924e35874b133c8028afbc514b4233d8d449d7939cc2662f390e0164a0ea334914414dba57dfc09484e65d7ce2a073308b4a469f5708965ca6faad7e5af23e6b644a4c93ace8faa9500bfa631e92b3535a4ff68c72",
                status: "43099828c7ae4367b781b478a52c142b80d1ef2da2de4275af"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}