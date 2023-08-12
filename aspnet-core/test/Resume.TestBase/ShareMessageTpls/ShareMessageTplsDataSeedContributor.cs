using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareMessageTpls;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTplsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareMessageTplRepository _shareMessageTplRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareMessageTplsDataSeedContributor(IShareMessageTplRepository shareMessageTplRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareMessageTplRepository = shareMessageTplRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareMessageTplRepository.InsertAsync(new ShareMessageTpl
            (
                id: Guid.Parse("65862f0d-c6a2-43f7-bf65-71fd77c77228"),
                key1: "fa9941a9d64f4dd5999f7025ae808f05033423a7334144279b",
                key2: "2a5be89162774d05a061cdd3af82aa185104037e50524f10a2",
                key3: "347d6b353e874f899d07543238c118d875977c20037649538b",
                name: "33d60fc52af44112b821ad69ec26b237e2e0993d1c6f4c2e9b",
                statement: "94afd35fc7b2463fb94843d07ef5a4870c495c281cf346deae006b57a64da5a76164988d03fd4d8ab2b5952beb343d6ad09e27528fa444c98879a0ff698b18a9a5ed845693414c0e84a6f7796a26fb887a5ab219005a4a4f980e8b1449ba00ccbda94c8f5a5e4e368b49b796bf6f5255c48c45144cbf4e399dfe43af6f50646eb4a8ffcd8f76446c910bb889deeeef936d91a961f0064395a72273a0f04395c0b054cae7fead47b6ac0c8bbdd8e567c3560fae135d6c41edab918a0385fee9f1252196b261dc4ad1a5563cff504ea67ad94ac792c92246ad8881de699bd758cd514868a73db947e8bace119e2ab50a16dcf1d6826ede4549b194",
                titleContents: "38d484fc1be044278ff05165cead5e7f83e94a61261244df89385e6447b7a35980dac2fbf6da492a975511cd988fd81e907f0213432e4e9bb37412800e826bdf04e2d1c2c8f944adac937d6287d0700a517a52c4060349db85a56ec2d3081cdf90c64ce40d7a40fcbdea7a5e5c32c8c503d75f5795d9400ba725f19757f3534d398d2e2bee2746d3a9c601d67ba5fca09c0271cdb315401db0462d711c14297d856cfa79e82f4b29897e73d1ce7dac5df7513ba82af242299abd0ec7572b1e5ac9be76b7d4be404a957d7d65b3aa97a79b084a6294cb49b399c9a60639f6e8bc945aacd320e3416485a194fba2219cae5b9c6f90eca747b6b934",
                contentMail: "07f30d609d3e48b0b590f894fd1fcd2c48c4c797a0a941a",
                contentSMS: "debcfc50c9774cb3a02113ba961e8b1e831f289e650342d5b236d2452c4e875bbc147e47e538449f8ef71e6ac854cd708f7be67f3d644ba6a0e25964683208fce39e5b57691c428e9d0f92cfc2b0a3468f9027159a1c4b3289af63dd464015bbc07e2e982a06488597138d4ecd13192c23b365533a1941c2b4d734b01525f114fb8a6ce304c34807b3e19adc42008131e51de9846da24de1acc6e6e56b34d208531d067d852e457c9b512e383b1197157e83565f978946f0a6723b18b60231eb6e0664f2f46c42a5b21f6b1aecaae747135086372f49420da5862de1c6521f98ec9573280e7944e6b106b96105042b7ee919263d51e3448bbac3",
                extendedInformation: "1e5e139da42e46aca062bbf43b4d2c5b51a1bea441344f4fabc7472666891a701ebf50ff41a9492ba5a305fbc18f85ef54c0b020878948be8e679e43e6096ce7cbebcfcc2fbe408fb7224a907b81f5d316d1186bc35c4e54a04f7949a474ffb39a25f4cf1d764aa9b48f1690a5000673925c8c89f5c44b289d3225ae7683877f35ba634a260941ebb54611df8d8138e797bc1e61d675464ab748135ebf2f527e997b71a83dac45d5b6e7c96931b0ff71361a4d3ce3194740b4d32b38fa1ce26e97346bdfb0ce4a87b0a2e84a5ccc08a349b198307b2f4a70a19e894615105fb8c2e75b40e76f442db1a32b60fe99bdc6a900b7f840c5408f9aa4",
                dateA: new DateTime(2006, 6, 9),
                dateD: new DateTime(2022, 3, 11),
                sort: 1137666506,
                note: "eead7050c75b489ca8f5f147debb7e41cc40c0a95a364f359c309d00cadd78f004c63e0a6d4348d499f553633261a386daa801a3d06e430db5dd155dc012d3762abda30174c944f1b670ac2486fadf553c1c1913fef346e3bc25147d01f1c3978c12861fd3f54ccab209d5cf5ddc0e4cd4fd97a61ee64e0482dccb274b822678fa54c9a208184a04bde896543b59aceac63895901909497f82c0bcf843225aee38e13151ad4a47b3a9dbcd9b7e69117f83ee2c2b51eb4eea9c3f7f7ca92b5f259fc69b3c892b431dba20a9616cc9d681b72c4a189344482faca41abfeb4b2a805b9131c3f5b84f1ea0f6be9632444a70de18525a5b28469cb19e",
                status: "eb2387a73a97453da82527c51872db9cfad27529f9e64b1090"
            ));

            await _shareMessageTplRepository.InsertAsync(new ShareMessageTpl
            (
                id: Guid.Parse("46feb87a-0b6e-4c05-85ba-f85d5a1d0f94"),
                key1: "e83161f3147044faa04fdbe88ec3324c50c7e4317bbb48e899",
                key2: "bc9a9f7314844ccf8b0bacf88eb16e7e52119b940a974a48a6",
                key3: "2150c5ce0419473285882b44a39c6132196364a141ca413dbb",
                name: "093c4fb1a7f84fb7b58bffdab1cc399e8572e46d0e6641a48d",
                statement: "1e35857dcfc34f1aab7595dea94e10baae37f14a50774aa7905d629dd44d28f346f168a754934500994cb86dab97dd22dc0cc7531fdd453fb376a6f00c16c6effdc29a5880cd485497cfd8af39120743e13582f4a56143179193bf05e6167e1f632775daa31c406aa5427231744a62cb32fba5a375a947a99fe596b34fde9dc5c5ea0d39c81546d1ac7db037831b4b76b963da06bb0f4c58b4f4dfe639212ae1b7e0e4fc0c7048aca57f9d4cfbe944c0d8ff953b0ca64449b345f7f9fc82a3e5a73b4d41f0e74d02b1b62948cb32467c488b8a63f8ff47f881cce0a24015226ceb83e555c5d4469aa56c5e9e74ebf9e2a5d0014c4ab24006867c",
                titleContents: "e0db65778b9e4773908b1ff169058ccb00fc191f18434cafbf3e153d70ed5349aafc93fb56e043efb8b60eb14b2862f3d82962b1dee54be5ab38e941efedcfec5f6b36f2999646be9b50845f0d0b0b68401ee4e140194ed7a0cc7d432bed3ddadf6047e1f59644d2a6290cded1b07b35899c767b2df9406e8aac539baee65db5fcd99e50632445d1a0bed2224d5556e43db4fd1e466743d1ac72b1833a13cd5fc461b9d83adb435794284275c783966957a3abe2affa47148966c0f9b1ef98f5c81b8f0a6f174b30b339f2a26cfe92bb8ddfecc1fb184ce29e703ea55f21b94bc9f0dbd324b74925b5b577252baf3aa5855e71c39ed14c588ee4",
                contentMail: "b54e719d9cf145bd95ad510c03a0f94db21c3824a5f94827a60c51f2b50b",
                contentSMS: "e66d90ea379545c0a30b500d47a8182e4cdc20cda98645d1a175720962582fa89cf9f906a59c45c0b2de8bd67cc4f95cccf835bc8019481f8b13d4a7cd20320175a9b08646e6455398d0847a7152ba09952a6e4e8fd2486890dc8bea11f6aad7dd3d669729e94d46a4658f4f7c5b0f74430aecb65fbc4898b6797966a4883bb716ded91a114e40cc85842d299cb04aaa637e9c043f5b4b14ba9d7171207e7dfe71845f36b82340388166422f2ac30028688c473a6b9d4d9fb9b2252d949d274eae6e96ad26144bd0a05232d481118cbffd204d13a5d645e08c717082b87c9eb4c30f626edda449d38796a066a7b9cf3b7b6e80d6ccb74edf85de",
                extendedInformation: "2dc122aa821346749d99a14110d66baf76a617cd289f461ba2ce65343e3dbfe16df93405eb9d4310b82c2cef94a6afef49cc994477e74eb39292b7d48ed0771f2a3fd9f3aa0a42519d4ba4070cfc03f7bf190ebf9bfb447a8a62c42c96706d5c7469dfeb8bce4669bbff3a88001d8271bf6864dfac074cf8941232d41c7bf33d0f6f91f136ae4dd39c047e07129f6b44565012e5f7ae49e3a7668722ee2129a6163a9ca1f9e14134a1f8774641d29e07717352be114f49ceabf68d1e15c60a0423e5ec2266bd47ffaa00183cecac1c4611ab340a2c424c09b594b7bbd39d31a0c0038a3277cb4f11a5b447843abf2002c6777071d6674c77a04f",
                dateA: new DateTime(2018, 6, 7),
                dateD: new DateTime(2006, 1, 23),
                sort: 236991760,
                note: "bdedff66ad2840d880f56df89c8e56cb2b4fac6f2c2e4bea8f9969dbceddbad30dacad8271714751b5a723452ac61004e64261ddd3a1434fadad8e3a65eaa2a92af2e2bd22b34843965f1b7a97f2eb026b41475d96154a2683c32977dbb8d62b25166d84aa764c2899b7826d15a5d70043b2d82b40c042ddbec25309fdeb9e123286732fb7d84508825b5d6cc76492769e0008a62d3346f9b36b0648b333d6ec95319b71af8b440fa8c79d01a0578d2e60cba2d58a924ad0bfe4a8ce0b615b34892c2db13815411698a0c96ef45d834f65f43d87a1b64eceb524f4adbb2be844227274bcff604c2b86cf419c6ecc4532c2158da6dc3041128f96",
                status: "340779b5af5b441d8defb06a8450ffb267b22f9898d84b279d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}