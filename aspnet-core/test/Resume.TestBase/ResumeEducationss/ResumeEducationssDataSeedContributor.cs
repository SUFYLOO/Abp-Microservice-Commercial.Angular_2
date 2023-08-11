using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeEducationss;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeEducationsRepository _resumeEducationsRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeEducationssDataSeedContributor(IResumeEducationsRepository resumeEducationsRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeEducationsRepository = resumeEducationsRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeEducationsRepository.InsertAsync(new ResumeEducations
            (
                id: Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"),
                resumeMainId: Guid.Parse("35ff9da9-e81e-4eee-a9e4-dd8d84363fae"),
                educationLevelCode: "9050f74fcca7478086c36244acdf7315ec14d7aaa3d7488280",
                schoolCode: "a18998a2650d4640b2acc2f13a83a75c7f8d2458f8254ef898",
                schoolName: "75921b441f184336a2b3ea9c2dc484755fba6063fdbe4874a45d27683f417127f568813a35604037837fe79a03d20e87b5e8649ab5a54828a19115c75c7c6f4fc34c4d34c7a74e6d9de4e99f21ac4573102f86b437d44ea19eab7c53721cbcdba1a4592e",
                night: true,
                working: true,
                majorDepartmentName: "2748511e6d2f420fa517a236b139dbd41c6e2d474c604127b7",
                majorDepartmentCategoryCode: "df1c81f56b42462f91f056c9514e676fd8e38cb4affd4b2fbcdcd5b2307d7bb0b1a6f7d1c9904fbfa237a734a918889ae68e4b34af0849c6b866d067072668da270a74f71cc143a49150ca6c4d235a6b0dd5c2a0b51e4d91b1596360671dbacd4123b846b3374c0fb989621dcbc2ba58dbee52c7fb844084904aeb616e159c7348aa32bb15904e14870334817d514d1089ec9374ca7e4af79d15444c06a98681247963539fe34c23856127abaaf97515a3e1f9781d5b49ec90769864212a4a18048142171f7e4cafaadb86e4d3e7e1bc6c3a10e76f0c484783e2010c405666b0c5d3ab4b24df4d0a875858ad02d936a79fd423ea57dd4e54b3e4",
                minorDepartmentName: "e9fd124688e14ccb8db2a6251cd46884dd2a5811d1a4494a99",
                minorDepartmentCategoryCode: "2b7cff83241641a2a222bcffedf1489d92d212d4799f422c89b9dccbdc6476a3b73e41590e0740f09e305b99c6d05dd2db94120f83c94a58a8ad223105e9b3cb80b90cdce16346e2a230953204bd6f9b1c5335a4948045328a15b6ea2a5f6bc1a508872fc1ac4e5dae280a3156c38e619d3ed947a2504b319767a88bb9a82580cc03f114639b43ab862f225ecd4a6d6ec38f6c9329264fb1a61ca6abfcacd4a315c760309dd4400193c5a36852d08987c12dec3bd6e24438a060a93f132af4bf7cafb77d5bd44160a38e203875907ae67308c06bba7545fbbc081e524c0c0ed0c1595e8c1f2a41aa8875f481086971f3da9a7e81a53440658fe8",
                graduationCode: "b20d9a8d5ef64bf78fc22d36715e7d24be6df3aa43b84bdb8e",
                domestic: true,
                countryCode: "256d6d929ad64749806c3feb3b7be8571a67400d9fd54176b4",
                extendedInformation: "556240054684448282a320093ffa80754ee94357da864545bbc600dce5962ff038dbb06a5ef144bd91c84784fc69d546ce99d38bb2e94eb49839f28608b91f6d7bcb0c02a5f0430081021dd577e517a3bb298d4f82ef4363b68ce7ab83cdbd384787700b6c524a4f9acb1ac598c0e9cf8d56ba7a8b8b40feabcdc80559dbc437aaf5715bb4814671a35d52290b66ba93efcafeec366140409e87861c3491575ef0d8290459f240d88a33ac2dde0d44700d6f43f5f54e46ae9a4718735ab2c1f0a49e23a943a54843873c3d17dc663ba7305d78db9572443fa2e494c88e2d3a0c5d9108def3284c52a09a703ecf9c04931308255261444958adac",
                dateA: new DateTime(2011, 7, 15),
                dateD: new DateTime(2014, 1, 6),
                sort: 87100759,
                note: "8eb7ff3593b64d97bc8502cc8625bbaba1938444aec44d839df72be5ca0bacf654dd9eae508d4fe3a1e78abde8ca8d134ddc3ad3168a413fbb32102ab23df5beaba6956cb48746e4981a8b94f0b939d0a964628018bf441ea2d698dc00df86a62f8395b5b5c443aba866db5db978ea0f5586d7c7932343b68aa51684bd360c107eb362b800de46d08774749b863953152ec6f88e885848e5b638c50869b649cc26f9a42ecb044223b6b1eb326a432503f4d2fe4ecae14751b58363ecb8d813a335b28e3c728b443ca331e330d896db6770fdec0da3924d9eb0c2b13ed2ca2ba3ad70ee4ae4844226b4fc7206dbdd7a1a691bb367fbba449195b6",
                status: "36d7676547694b839a130ffef843ced50040425c69644fd5b9"
            ));

            await _resumeEducationsRepository.InsertAsync(new ResumeEducations
            (
                id: Guid.Parse("10c3cc5f-1a8f-40fe-81ad-58270ce868ab"),
                resumeMainId: Guid.Parse("1f17ed5e-3cc0-48b6-873b-890f9c1a3c2b"),
                educationLevelCode: "3f11cb47c7284642ab8fee36908ef16129a2cc2bd27f48bea6",
                schoolCode: "a2a564ef87ba4400bdb18232e0e5135394336ae79d534da883",
                schoolName: "dc65d683812f4784953ec5c3e4b7217f26bc48fb33e44622986374e8de6226af6913a04944e94b05bec2e8a8a271b2f4669c5ffbc012420699f6e4f6351ce62ff28d0e7039504d45b1453d63b15162776c689d49d64449fb9f64ef8bfffafbcacc75674d",
                night: true,
                working: true,
                majorDepartmentName: "efdfc92a25e1445f99581551073230ce61cfc5908dd649d68c",
                majorDepartmentCategoryCode: "d35dab6cc1ad425fa20eece649c508d9798ecd29d38c499e9993eabe62c4c43b886b836fc4cc4c958533624217e1e3e63f6b29de426140f1b98f117968a83b5df3ce907e97ec4ca7948fd7e14f170cab57d4766dd1dd43ecb0c9b92ed864b15dbff0c740541e4f2a9e811e4d5488fe227091adc4d99343469faeb455d126a6fb0dae68c7fa674a7d862f7fa56a5e71b2a14e144d461d46789926c7f56f7d2036da7ba1df976f4a679112f5497da82749f934061e3c7f4d178ac3fc53bd9a195b8a3a12db74e648f381fbe5ce820d7ade4b29ac8ecfb04a10985460aee8e32afc4411b793baae4dda9bd3fc2442867fc3adbe8be9c88745fdb821",
                minorDepartmentName: "2d5d2844208647b0a53efcf38554f4fa6972f8938900462383",
                minorDepartmentCategoryCode: "f51eb2745e9c4db59dd3d12b44a6cbf3bf9bb92e102b49f9ababb24b13d55269e7e4d446b1eb4d9c85c46887c429c61c171588ff63884b6bb33c308fc14850d39dbab9cb7a7e4ffba2d921e8983b22ded9673512e93542ec817390fc2f05fb1570b69a48b14b4ef19823a7fe2f7fd7bc925559483ed44c868d5262cad5bfa5632e86499668654d70a336db2ed350e80ccc51872dd8a14a29b6b934ec669b3d88afe24d83589644d5b594a083c2796b893a491f783cec402ea18db9285a04bf41a2e89b0bc92b4f528d51ecee8d5bc51a3b57a99346e4448f88f3aa2221d40ad15eac0c77686a40fbb76bdb63c0762fca39d9ea3270ad451b8599",
                graduationCode: "656648bf87b740428136ac87bc4a3e89ef6b0881e7f2487185",
                domestic: true,
                countryCode: "7675194ada3744d2b3b5ebcfdcc15844fe1baf25a8b746b1b7",
                extendedInformation: "c6d13ee3059e449ca3dcd70099dd96594b377251049c449abe869fee877fcce63a010f03a7344f8d889def71ae995de518db594e8a32481c93a4382a5981ff938dec19ef1195485381977177a08525985e72e017315043f79cbd485a783c41056373d6432ff64cc7927020b332baf918c906fe61ff14480bb4d0a1795c02398bfc624e9b238b4246b112d3860df69fe960c4c05475954632bcd48f35e4b59c254c19539519a84926a6b0360e46457e7e61a08ff485ae46c09648759c07f829fa503dc3bd828b44d58a910440bfde57df79ca9839ad1c42f5844786fbb30d59dfab2f69c7877248faa66e41c24dcfbaa119aa10996a0443648e72",
                dateA: new DateTime(2021, 9, 12),
                dateD: new DateTime(2009, 7, 25),
                sort: 1260331441,
                note: "cd96b390ddff468fb0c7a52ff4392950c92307fb278743c9bebdff7207c04330d43c7433e14f46fd9cbaa93894b34fac4d636ed5b4454884be224dcc2e4a49d47fbf3b9230fc4e4694765f8440e4cf0ca3a8c8688aec4976bf6838c78640f0b34b37f06b766441579b7ab614afacb798fd2ac1b5f4bc433da25b0e2e0e35f6eac87c08d35098407aabf2f31642db31ad679343b578fa4dc1b464f5b5625645dcdb9fdbcd8d0b4a1e830ce1bd6e51717a6fecb5ba65d742a19a615671664d4eb1a9b13a3ea07640d69a9dbe07331fdb65090e00518e334c3aa9472b5953b9e0cb423acbefd7334362b4dce40fe852079d24f53c0abed843ba9436",
                status: "574177108f2c4776833c6c4f4957de09cc6b955859a94a59a8"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}