using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserInfos;

namespace Resume.UserInfos
{
    public class UserInfosDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserInfoRepository _userInfoRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserInfosDataSeedContributor(IUserInfoRepository userInfoRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userInfoRepository = userInfoRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userInfoRepository.InsertAsync(new UserInfo
            (
                id: Guid.Parse("9b104c7b-9740-4070-b6fc-3fca853538df"),
                userMainId: Guid.Parse("25480109-ea2d-4f16-b51d-6045b223df80"),
                nameC: "cab306ae1e2941fe80cd9c20656838aca53a36ac10cc4e8486",
                nameE: "1e4d76fa1b394fc690e17de2810fbf7cff730b35171d48ccae336827365e34d544dff607b63c43d4a375b4f15260907846f94768eb22401e900ae28b13585312e86ed2b79beb424c8905c820045eda5a74e5c93bd40c4d7db596c979db648f32d63caaae",
                identityNo: "0fb88badf73641dd9c575f2c85d2168f51199bbcfb5348ec8e",
                birthDate: new DateTime(2014, 7, 25),
                sexCode: "fd61c532b8164ca08e1cf774137654b5ac121866a43e4fca81",
                bloodCode: "7d61d0f1c2314ce4818e52f29650c389758579939646471bb7",
                placeOfBirthCode: "d2e16d14b2d0461e86cd6606929e6df877a1de49054f4a4681",
                passportNo: "38623025756d44e3910bb6ba564974979ee5dd9ac94547debc",
                nationalityCode: "2c039cc69b0a4e5d83ed1bcaa993390dd16d9cbc1987441cb2",
                residenceNo: "15ba722f346f4172b93255712c30f9441c46cf314a9748baa5",
                extendedInformation: "2f8fc9f0a40a4cee87f44328b859e22e3904f8a9b76c4eec924dcde30ab403907cf66d6393664fc288d99d003917ae3b53a17f6feaf540ab99e2f25f17d552419e9fe8ef84204776a95c8e36296e1e4abe1555e9f77d40cabba3d8749275664b636bb4b57a0045d68ee23b2c6a20cb9a7fa5b46d2bd343f8b690e3cf946d052e7fd0af3561d9400dae5f88da5935970602c4b01750ce4bad81354175308e1c0283b9637d73384e708584d66b7127def81bc70b0fe7e74186a00d0400b0b497473a8c8b0d05ce4e57a1674a8abd799186b1799323b74b4277bfa4e167429ee536b2fa0f462a5c450da1abae563dc1961ac0efb018caf44c72a547",
                dateA: new DateTime(2008, 5, 2),
                dateD: new DateTime(2022, 5, 27),
                sort: 647329002,
                note: "8cde55c000b146609898ddffad2ddf419a97a4fe65d14ee7828b3c6def7001cf05c2959da0ab485697b458e11ad8583c20a12f55bced42e0967ea8f10f4ee3457d79bf09ec324b92a52fe1f383988cdf5dc379cc6b7b47ccbe1f2c33a3918dd74145c46c9e41452caf31077ebce0dbfff1027d9a43ec4c078a2265c6926ceba21cf70dfa5ba949088f86ac10359287973731c53e11e340fcb7fc6dd5b76973a32997fd30dda44cf4b6045495f4a9f9c1184cc79df64c45608e0c7efd0cc859806552e5dbd8194135a8a3b0cbc0fea9be77cb1d6666d94d7597295e89956ff54b509e8a1688d04832a72c5f9c1df7245086056a0e88e54acd8714",
                status: "6688974b48844d39ac829506a05df281ca89e2dc35484e18be"
            ));

            await _userInfoRepository.InsertAsync(new UserInfo
            (
                id: Guid.Parse("c62ab187-cf97-48b2-8116-4edcdf7ff31e"),
                userMainId: Guid.Parse("e4c611af-85fb-4394-a78f-96375fbf4c22"),
                nameC: "b9a7755d5c9d4fe79beced39dc84fffe6a39a1a9d7fa45e382",
                nameE: "d13e0e4eba60442faba0bbd6c38e888f5fcfba52253d475a89fa17693fbff5b888c19bb507584e77bf38b0a856c8b7769511b8d9cab24523a1f64e8ff2710e3535f576935c1f4dc58dee4bf1dbf3f4b352f4f8b8bdb5470ca8c3f7edbc256cf699bc2201",
                identityNo: "b23ad052cdac4e87b8d73138b9a25dcb879c61e762ea42b79c",
                birthDate: new DateTime(2013, 9, 5),
                sexCode: "ed69269b2eb846d7a0d4a7c7356952a10986c37c55584425ae",
                bloodCode: "6c512653230649fb90b501ed2835428e06b58f4d666e4fd683",
                placeOfBirthCode: "018cc083c6304de59bdd059b8cb5792f0fb98aebef9c47d58c",
                passportNo: "dfe48dc0e98443b790037f7b738902d574f7f61d3a37440b92",
                nationalityCode: "ab8c6ba8f5af4c1c8f501815225bb70eb671c240cfff42feb7",
                residenceNo: "4abde124a22146558999180781b11667d8d050e3f46746ac88",
                extendedInformation: "c831b76eea564894a9d7202d33ff43a9108cc1e95c4142a0984989cfc2bbc59ce295d53ccceb4cbdba2ecdb3ece76d500d44e9cca96c46288db31b8120af7299130c13268c5140cd9c77ab7622d991161b12855a9a6a4ad4ab65f59f42ff5228c52520ecb11a40feb60cc97a7a88fc35c6f1075ad5d54d3ebb7b444e8b3c43910a6c1c49d23a4e5db6c08f31ca3b446c351017b6d9524757bb2f4931807891abf383cbc145884e3792b6f27e76f9abfa173f394096414ebf84bb0957ee6f04bc9b557f596d6b44a5866f5c94eb42f9bf9866f93e0c4247c4b878f40395f9e243d6e3ff561db8430bb831da53f7b35f5fb4c994e1d08f46f48162",
                dateA: new DateTime(2016, 9, 4),
                dateD: new DateTime(2015, 5, 18),
                sort: 1775231948,
                note: "d93f8427fcea43c89bb05602ddfcf33dec2997bad09f4b37b7904b4635aa150b6143760383ec471d84f8b71b34ad866bca1e0dbb372748d2829c1e78c71d1514ab807c68865a4ec68669aad5d191431d435c77e723a64376b02aa87a2a59de94bb18f1eed8ac42a3a6e1887998669655bbaab97c243a4440a26df3dbd01c21995f75772045b74a1ab54ab1bd082537f161dc22a0283443a1bf7b37d949708508c497866647de40b1993966e84bfba778599a9e05c8a3492fbde3565d8bcdddcabaf6a3ee5ccb43fdb0319f2a737cbf32cc5fb18c8c0f430586d3457438a7e35ca1176f1f858b48b3b13ede5e7f31b45b495ce90442b642408ce4",
                status: "dbbce55047484a5c9a2fb1ab45be1a0714e6e001c1ae4340b1"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}