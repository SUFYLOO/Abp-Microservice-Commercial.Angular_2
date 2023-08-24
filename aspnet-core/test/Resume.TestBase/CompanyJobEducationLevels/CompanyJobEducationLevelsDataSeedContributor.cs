using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobEducationLevels;

namespace Resume.CompanyJobEducationLevels
{
    public class CompanyJobEducationLevelsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobEducationLevelRepository _companyJobEducationLevelRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobEducationLevelsDataSeedContributor(ICompanyJobEducationLevelRepository companyJobEducationLevelRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobEducationLevelRepository = companyJobEducationLevelRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobEducationLevelRepository.InsertAsync(new CompanyJobEducationLevel
            (
                id: Guid.Parse("721692ee-cb5c-489b-835d-1a9483a92b2a"),
                companyMainId: Guid.Parse("88bc8dc4-0c14-42d2-90b7-af1263ae029e"),
                companyJobId: Guid.Parse("423478a0-7942-4de5-aab7-5f9bb8fd21ef"),
                educationLevelCode: "a2bb78de2efd449a957e476534440c1c260ec446983e476ebe",
                extendedInformation: "5fc217756d9f4b66892a8fbaca9035adb1e56cd100f44567a135eb6de972d9b6eb0c67759f2648948c6901fcf4d64049cc7a8f8201a24e50bbd7ffcbb56b8090d7e9b9553ef649d1a9c399919898409e6e25f4a39de44e5583a22a5f09b642601e28bf759fa04e819ba588f150fd580c94f125c48c514bf7b595297bb132f8ed3272fbda274d465f9fbf819add724a42b726810faa074b09ae36f02ac13c8cb29d7d8cc8a4d843bcac26b743e0b5af1f6bd9937edd1c422b8df8e386a412acea45429270761d42d3895e42551599cea97be0d7b97ccf4856a99d3ede9800491e86789886b008451fb3f24a48f679b8b4201421218e1a418a84db",
                dateA: new DateTime(2004, 9, 15),
                dateD: new DateTime(2008, 9, 20),
                sort: 1070689707,
                note: "db825cb8f48d4b61aa6229917c1a455c4459fccd83074c9fbcbec5377b5451803f4d3d3d076544289b5e65cfe77df81cded02333146d4b488464b31cdfd14335c2028658323c41cda4a216f2cb48fe2bf90a94eeea0d45c7b32d2f073c242aed54cb5f6b772c46319d046f375050cfbc701ba3926cf84b4a8c4d70e23586e456fb7d57911fac4bfdaca8f62843e88850ad442dd67e9840aeac4f5cd1d09b26639fc4fb32c5d848e9a6e8d9b1e4e84c913b70e79a276c41289bd62e03aab89d55f51b7c4dc4634ca593aee9f68fc0ae55dad907d3d2334e45a01b247c933561f856a18c5b5fe44c9f9dc7664af9447bbb8a3f489d905044bfb59f",
                status: "5cb61b7a2780467cb159762440403506a1096b1571b34c9b89"
            ));

            await _companyJobEducationLevelRepository.InsertAsync(new CompanyJobEducationLevel
            (
                id: Guid.Parse("9c3c1687-b8e1-4b0b-b199-a762a631d291"),
                companyMainId: Guid.Parse("7d93ad3b-d901-4c3d-9c5b-3707fb5dddc8"),
                companyJobId: Guid.Parse("d9ef1811-56c2-4d27-81f8-c62a261d077e"),
                educationLevelCode: "dc157000b03647e483c3ebbc6110c9fb18006cf5d0b54fa1ac",
                extendedInformation: "86a3959c0d7745a7a797adc2b4fcf61f459922c4ce564aeb8a20cb7c8346a34ba81e1ba7bb9d4a9a8cf8a17a5546ab3e70f4143cad3e49ce80f74dce1c1dff1bf62fefdd01514264b39acf8ab3ce8555520dea09f73a4d5aa95c9308c705ab2d7ce38f4404f84ec3af56c4789a42e4dcb546530989dd4b4481d7c71adc5b5f83cfebd40f61a04fd9a9e640a08bb76ca3807fc19fda604519a6184dc383d9e768f69186ef53a841669e691784b3779be0312c6148354b48c4aea5f8304dd76b2f72675f27bbe941388a79203d5297ac0b587dd85332e140b696ad6be49d2c4acfd23ddd6ee1df400eb8362c56ce3be20c96ac060ef6a34f5199ed",
                dateA: new DateTime(2016, 4, 12),
                dateD: new DateTime(2012, 3, 20),
                sort: 677490774,
                note: "4423450592094a62b5313235e1d2aa40ad73627ef625492292d3ee4f88f3394dcb94b3e091ea4138a1a415bf3e9262fad9b92ddaecc74b6190ff2bc6d3e368f323b7d95d803e4a36a9ee68c7e25c20f9243422f9b5a2481a9056b7d25037dfe8b459b58184a14852bc2b324f91bcb989a7bf1deb82434bf19b988726323d003b8c52bc7252b34dcfbeafe38cc296f12ba1f97365f283497bbe95666e491dc7211db4d32a8d4642f3bc1910e51b3aa6da5b63acb545e44968aa1e12b2dfaed0fcef9d4f5f42104cfe9d14631ad5295c5bc891fba7f2b6480482cf4e2e4a726ac288df1864fec04f3e8d8b8aa19b3342f89758c5a53d834f27b41f",
                status: "829c154435044508be377202f57a215879f9f238001442858f"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}