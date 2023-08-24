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
                id: Guid.Parse("36d96305-8706-4aba-a92a-aa7ac11db346"),
                companyMainId: Guid.Parse("898f12e9-22e0-45d2-b041-9538572c4e97"),
                companyJobId: Guid.Parse("7c89a8a7-99d2-4a50-a0e6-dbde3af424c8"),
                educationLevelCode: "3830d91e997d4f4da4a0e068150de67f8104b973848c458bbb",
                extendedInformation: "de11922c4384483db650c2d8ec56286b7aa2e63690204214bb4f5e18dd992bf5d69341e614ed4e0d819329d4a2cf67ff1f078ca4cdfe469da9daf2071ae0451b7b4602017864482891b6ce196ea3952de4e4abfbc0b94da5812ba49f0b0611f632f090612b6f4e8a8b00e3704eb50a8f8ea5b4eee2eb4331a4aefd4e2a0548c44aacc92b893743c7a446097786763a63af355e1c62cd42c4ac6feb9097fb05c362cea4944355481d96718d0bc968cbbf00b20b1ea5174febaa9eddb1c10b67abebd604f812f7424a9ced0f290ea7a6113e94d690cbb34bada0feefe704b193c44dd71cfcc7604c81820125decb16257f7f1bd82c1d5e4bf6a5a3",
                dateA: new DateTime(2013, 1, 24),
                dateD: new DateTime(2005, 9, 1),
                sort: 466805725,
                note: "23afe3a519764a90a69bd3bc824e87e1e7362eaf482f477db490070c48c246d0029b892787f74f2fb4423e9f82c0c85ea85421e77e354f37a70df71ad9b2350a62653a2975294f2d8fd179384c2c87d07693376829de46a7aa07289bfe64eb9fd58cd78b5d0f4ccb97d2820c3c44dbc28aa4e21b1ba74f919b55494ea6d6e368a3e1a3e7436041b2bb3a2b74c2faadcee720f0158ad44f2eae80296eb035401bd405f34669df451b93f7897ea94eb019db95dca0f16b44c78e7bce501925ae0bd52f9028ec3f45e2b950bd5e036de1735b553899d7d94746a41874e90e38251117295c2e06a048b1baf80d862dbf98cc99f95357ec0d4f96ad63",
                status: "0af5fd674703414090d9ed1ec3d3e87dfe73b5fe2684408694"
            ));

            await _companyJobEducationLevelRepository.InsertAsync(new CompanyJobEducationLevel
            (
                id: Guid.Parse("a1fddccf-defb-4419-b7ad-759cfc295833"),
                companyMainId: Guid.Parse("d96b6f0a-50e8-4734-9d5c-622d946ee893"),
                companyJobId: Guid.Parse("8c7770c1-5545-4e3c-9d81-6f1b397046f7"),
                educationLevelCode: "c8c20ad2039542dd992724b43f38c521a73287a86eeb4f4390",
                extendedInformation: "c433d87a826c4a45a8009d1f21b837779acd9e021d024732acc4bbb3cd3cf02819db6131743d4375972ede25ec6fa15626f0f050a0d242c8a2b80b81c52debde434f7eb7a12b420089e1bb761bbdda0af22c1ae0bd964121bfd7b43082c2c40d8b2fef1772eb4d3f800c7d133940f41866e1893bff604260b91dcef175a956fd683901cebfdf42f6a94be926473490275e89f113a9374fd1aff05c39259471145dedbd951ab94d68ae70bd126054b048cee27845cfe640a99e396d9dc243c926139ff57b0d2e4f0ba0ce2bfdf75fd0fa23a11f5786fc42fe95d82263cb8dcf096cf3e8dfdc514322bbe61ac78c5ae33028a023dc11004351a73e",
                dateA: new DateTime(2005, 9, 24),
                dateD: new DateTime(2022, 10, 13),
                sort: 15280634,
                note: "c5586f8993164d02a07d299c25ed3442b826904ce5f843fa8610318aeda4334ff781c1862abf4f5b88e9519eabd8f00bf0445d87731742919eac085131d5f514f0cd893528f84567b8ed29e777dbd351c1a53cdbae664395a2a88d88dc7c0d6863c1c8ce67e648eba0b885010b80724c7d946ddbbe7c4e8dbef0f3263718a194e98b1703c3754c1b9068464111ea662917cb75c54b574d4abc48dd253aa213bf87e9207f37574dae9066897ff87fea12d2206b7ad5294ba692194fb244a6c0313417626c48bb429bb59e806ef3f522d27ed14d1357fd41d4856ba8b7d020e7fc2785a92a42ac4107ab22cc636f282f20334df4f37ad949c8a311",
                status: "00b44d2a43904e6ca2bb03e6daee2e116d07d362f8b148e5b3"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}