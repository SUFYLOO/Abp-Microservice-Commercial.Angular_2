using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobLanguageConditions;

namespace Resume.CompanyJobLanguageConditions
{
    public class CompanyJobLanguageConditionsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobLanguageConditionRepository _companyJobLanguageConditionRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobLanguageConditionsDataSeedContributor(ICompanyJobLanguageConditionRepository companyJobLanguageConditionRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobLanguageConditionRepository = companyJobLanguageConditionRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobLanguageConditionRepository.InsertAsync(new CompanyJobLanguageCondition
            (
                id: Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"),
                companyMainId: Guid.Parse("eff4258f-f08f-47ac-affd-cb455441794c"),
                companyJobId: Guid.Parse("283022be-7f40-41d0-9a4e-520fb4952e71"),
                languageCategoryCode: "dcb0e36d03f748b48c39f618a44a6241eee55533225b4af886",
                levelSayCode: "5e002915c07d4c8b8ea80705bfa19a943d7d5d6fff6345dbb5",
                levelListenCode: "b4b7744c251945029afac9fe87dcc16127b6ce09cca7491ead",
                levelReadCode: "90544e2f7a424b77a2e0ebf958149d7ebbd287b0b05c494ca5",
                levelWriteCode: "ae6bfc63d1194e39950a8b87daa4d2a2ed5af1a8a76f405e89",
                extendedInformation: "54be706745d743cab056e3accffe4d01d07733d6fffc4991b70b00903a8c884926f8d74ad4ce4b5b862ecc9aab34abd01278a62c2b8b4e2fbf9e06a0c81161a3a8a748b07e564863af22b62bf39b6dafeac9e74b84804db7b04ccc4a5910f70c0eaa3139338a4d1592b115484d450f7aa72d80a68bc14f2cb3b2a50868685dbc76da0ea3690f447195ea3973c8383ee146534f7af636425e9523a3f598794125fc8af935ae3a4cf7bae1b0cc1e6cc5cd18f5052a1c6f4212bb8316ed1df476628c7a70add23047a3b70b89acd9610801025ec08bb6c0464cadc7dd6b7d232de38ea2ce119af941e6859e8fc0231a06e3d603087339604446b65f",
                dateA: new DateTime(2002, 9, 22),
                dateD: new DateTime(2005, 11, 14),
                sort: 1184071362,
                note: "1963cac624f6406d87d91df0996a9ba8dba9cf140d7046dc812213f48637a8d54e37e7f93e6a473db5c3a83488e8ced78012dd0dd61b4579853995d9a6b91d67a1b4aef18fc1421a9045781465ddda173d790725ee794f018130c6b9300b22ea1950e779ed41425c940b8116d80ea49119e7a0364af64b2dbcd926776f3eb30815d1bf3f227545ea9cee8f9f19351a5b1db85b75425848a394dc4063323903a8c5c562862c924492a6c6045edd68947dd5e72b331e2448d1b120a94556626a8638541c56c0c746529b00bc59f8a1275b4d12444918f246baa989a3d8de4c51a877c80e7aa72c4af8af8e887e844be2db4f021d1f1a1442fbaaa2",
                status: "834ac63c07e74d93816cb55feaad64d78862a0b489c2420981"
            ));

            await _companyJobLanguageConditionRepository.InsertAsync(new CompanyJobLanguageCondition
            (
                id: Guid.Parse("277c778a-c6fd-433c-9753-d46aa79c9c85"),
                companyMainId: Guid.Parse("3cd35676-c22c-4a22-9936-544837d01ba9"),
                companyJobId: Guid.Parse("2c4b4492-d634-48dc-8776-785575e4bce4"),
                languageCategoryCode: "775272a6061249c78bfeeb6272f3cd756e7629c6da784a24b9",
                levelSayCode: "4e90c584f5d44fd886a289764490d0f4fc9c14f5a33b4abebd",
                levelListenCode: "dd61ab18b117448990ecc354b71d496440303ec26e8741ffb1",
                levelReadCode: "d853bd0842a34d878ad14e9b7957f9dcfe7729dc972f4067a1",
                levelWriteCode: "6766efcce4ad41be86e13c98d3f50f18d46aa55bdffa4423b5",
                extendedInformation: "d9abd6bb8a5b47dda6b63236d225c0f28ad8b1ea59fb4211af7a875da8f4480296fa23d5f9cb4e3b9ab11b50f532114c7936f74a05454be4a9eda9558a1df0be26fbd20756b34f6e9e1af03b11363499fe27b1e4265840bd897aa953ec6c9571e3cf324e473d40c087ec08c56c350f95c86010a790cc440e8339ef5659dde79df0a5a8224ad7465f918cfaf9c3fe83b7646ddd0326d243a29d2831ea02db81c01a7bef4eb8134fbd841389602bf97310283eaa8d5f354633925ce6dd5a18b631caf9499859fe4c7b8a771ab593756b7a9bfa95b429cd44cba3c1f0c4f457906846b87d29e0c84c4b952bbcdebfac242187cd2ae0248f4291acb1",
                dateA: new DateTime(2011, 1, 15),
                dateD: new DateTime(2003, 3, 8),
                sort: 1924395406,
                note: "65cb086d9ccd4836935dcedfe872a6fe0a125b5fd60c4d548f8bc33a607566ad5b11f2c5a47b4aca838d71fa9b6062a0ef6e7eeaae7f41db82fdbeeaa3b6a9cd1e008ae373184c498dd88d59828cc99d573a53566ce8423c941b4053c93ca35c615960d0555f4812a19719b808ca3510eaa8d173873348c48b7051cde1db4e72d2bb76f3b5ff4422acbbdffcbf25ce5710785846025741238dd933ad81542a181c963fcbb0744f56bb2421f67c84fbfd0e25950f802b41108027c997c745577135150fe2776d4bb69f7b47cab35ce5e66bd64b33a0614e13ae37c05322642d70286ad75074a5417c843db295724a54d59dfe8a2f4d7448659929",
                status: "3645a08221024716a6bc6dac9503e2a91559c67ab9ef472290"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}