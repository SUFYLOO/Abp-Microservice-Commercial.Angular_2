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
                id: Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"),
                systemTableId: Guid.Parse("810e0132-93c8-45d6-b1c0-163bf271d4af"),
                name: "8491826c09324ec4962cd164233d343480be793841494e78ab",
                isKey: true,
                isSensitive: true,
                needMask: true,
                defaultValue: "7949d7902b0c4f8ca6ffddaec2b60b8f697e2fd2fe074fd290",
                checkCode: true,
                related: "7cf6311d6ba34187a78dc361ea3af851c242cb76c7b149a8983e7cd172865c071b92e16d688949679ef9c69a7e0d9555c7fa097d112149c5a19e8ae8dc07666fad3dbdf2a78444f9aad72dd9df5c463d8c8c462f384f4f1d89e4f790aa40b2796f43324b",
                allowUpdate: true,
                allowNull: true,
                allowEmpty: true,
                allowExport: true,
                allowSort: true,
                columnTypeCode: "526d34a753f44b82a301f832a8144c5f2a5130ba852c4ae595",
                extendedInformation: "eaafd5d63f4c43b988411602ffabce9242613b83085d4625ac85a5245f0a2543fd6f62d7204746af8ce8c472161e9e500a0edf2e28bf45c0b28ae793344f7870f2b8d465ad8a459cb18684009c23abda9663b7ca50a94970bb4beeecc42d6b4c4edc3cb89691407ea2fbe87c1b2d2f0ac318926a905d4c6dabc0fa8045e7036253770ee7ebbb4e109cf622db59b8fae19dca9467479e4e9fa25c42ef95f106843aa077ffaee34a69999e88d3a76fa1a260a645e487cd47c69a8ac8af15c8adda647890f1effe468d94f1309f30f3667ae295a68c3dce4df0a6003552d6f3077d09046df6ddef4cf8a587e19f9b697931d7019696bfb64339a2dc",
                dateA: new DateTime(2022, 8, 24),
                dateD: new DateTime(2013, 4, 25),
                sort: 1850021623,
                note: "6123742356ca40cf94ba0dac72b8954407f7c2b73ff14bc387caf3f3b2ad1feefc63f16811fa46d6bee3d15e8f6c1871750531138abb465e83be0ca5e58c25d878045d4f2b974397a981bc0e6a1287351397b04cd22240b78a8cd7d4e030f07b44ef3d02d3b6486c9f6cc5b0d614eba22132e5be32cb49fc89c552c271679492a9687fb2ed3f47c7854006945e904411b665b5a44cdc49f9b5e58efb915736f5db40eafb1cc44c968fd41b815d1e595d9d64c8ce92e049b8bad716a8dcd88753071018bf0522479c988f1d434a9682bb7f4d06229f5b425996b858c2cd17db64883af4bde5b7496eb9decc8f6967e67fb161e02aae644068a9ad",
                status: "259f48f772084dc3802c9a7e36451c9fef670246cff748429c"
            ));

            await _systemColumnRepository.InsertAsync(new SystemColumn
            (
                id: Guid.Parse("bab14eb0-7273-4588-b219-b4f11e79b0e3"),
                systemTableId: Guid.Parse("bf1944ca-abd0-4456-8432-0b08d683b001"),
                name: "35c2acb5f6e44fdeb6b0ee1229db303afb3ddb8e3824479cb5",
                isKey: true,
                isSensitive: true,
                needMask: true,
                defaultValue: "52dcd2ed56304f528343463769894d5ce5df535ee1f148e3ab",
                checkCode: true,
                related: "0e8334fd8d004678a2e299814bc4322cd43fb8eb66774306977fd1ab613f75252f2bd3710b7b41e695839bd74f1b2caa26c5cdc12eec48df8ef59cd0f2aca1b73ee3d2f111544aa2b6908aba10840f585e585fe8bc5d430ca3c553ca66052cebc17cd4ef",
                allowUpdate: true,
                allowNull: true,
                allowEmpty: true,
                allowExport: true,
                allowSort: true,
                columnTypeCode: "1804ae3e7589406792146b5fcdce1768f31b0564baf141199f",
                extendedInformation: "e23298d3ca034719a87a6bbcceb115b912dbf1ed06ce406199e3d4deb1f25e1df33495049fad45548ac498dcf1db7a695bb506bc35214cfaafc6b70d52033a8c844770f4069146cf96191ac9fc03107560d366eb69104d1c9eac75172773aad4f5c47a1440da49b4a0361077ae681271b1ec483dff574d73a1b9b29450bfae6bd4465e7c72fb44808a22c928ba44485b5c8c5503b90044738242136f09bba61f66b126a317da424fba09211139bb8eca732333b8031240399e33bca25e2d30625b88a135b7e14cf881fbed2eac6556918942216ea06d4e9899af3604d31ad531acc2276c51bd4452ad003ba127d744c54e1b85da3cd8481b8dd5",
                dateA: new DateTime(2009, 10, 15),
                dateD: new DateTime(2017, 4, 3),
                sort: 1586810544,
                note: "60d28af026444d1ea0f4b733bc48ab76704c5714e90f405a823b9dc6413d9877775f0fd404b1497fa8d12cc18761f18222d171a1af1748cd99b7713e6a090eb17cecb039a6d845f29bf394dd153f7c43d83f61559bf04806836741e573dd894c1892ead1c2f04f359161a448c3282a401ad4b3fcba4b45be942ea3023bceb34f7c2a1bbb07ea4623b8b7a5c3aa16b08972c8d2c776c5497e9847262015cbd528b3ad3d1ffdab449cbeecad2f3254662712b235e6272e41ac93d69465f6cb1430a7e18a433feb43d69afbebf363ba1f8148e10f920d9b455caa20d5e110cf5bc1708530ab3c00430db22482d502a3c089948e8580d2cd40ce80d7",
                status: "29a43396e2334ee29b326b4341544e4d56e3a2ca3c1a493291"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}