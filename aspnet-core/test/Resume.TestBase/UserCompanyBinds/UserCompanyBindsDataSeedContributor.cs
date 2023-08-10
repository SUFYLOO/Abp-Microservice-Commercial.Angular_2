using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserCompanyBinds;

namespace Resume.UserCompanyBinds
{
    public class UserCompanyBindsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserCompanyBindRepository _userCompanyBindRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserCompanyBindsDataSeedContributor(IUserCompanyBindRepository userCompanyBindRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userCompanyBindRepository = userCompanyBindRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userCompanyBindRepository.InsertAsync(new UserCompanyBind
            (
                id: Guid.Parse("875786c7-e6cb-42c3-8f76-570691e8328b"),
                userMainId: Guid.Parse("88d0dddc-ffcf-49df-8428-869d1c3a30c4"),
                companyMainId: Guid.Parse("f6b66c80-e95a-4631-aede-4bf38bea7211"),
                companyJobId: Guid.Parse("84e76350-59b5-4a0e-b579-eb06e0aae9aa"),
                companyInvitationsId: Guid.Parse("d5dacdaf-e328-4a87-b3e6-23678e0bdc88"),
                extendedInformation: "335e9e00615042d9b4acaab76250c005f1ab5e2258e845c79fdb723f469aa32aacc2411b0bd34421a4b4249077698956be382cc0c39c4c60b7dee6fa541499c84759da2fef3c49a5b1e9e6b8c598fe169e6b089057834c5b9a7c26ff58378020856477ee629841ea98f8d6b0441693e920787cea3a1a4d6eb84ab16e85d7fc5cddb7e853a52b4f75a77ce70f20d8abc354d337140c9c456daa5df4d02297ae2bd9aa598475854a06b51e25d453eb39284757d4419f1d4e77af66651aba6f46bf8b16cbbdbea045cbb617ffbb7bb224f44da0c8705e204db3aa3f67a38e9eaab5f50ecb600dbf4272ad7a68b279323d7b77f87ece677e47a184c4",
                dateA: new DateTime(2010, 6, 5),
                dateD: new DateTime(2011, 6, 10),
                sort: 1077373117,
                note: "3806b7c377d64d24b9807b6ea1b69402559a996598f74116abb91308af5b743880a1e8896e664b8cab6b2f128fdcc0b2b53257e8d1d44ea89ac1b3324686987f858dd20a334d495197970f0fd956e3ad58797baf4eff4f87b4c33d9a6b424c94e2f7af30f42a4aa196640294742d7001988b09a9688b4d7087fa5ebdcd177d89d549c5a158ea4627afd2d897b11470633cec1387f3824ad983ec902d601ca3e5e99b4a6454034c039628832ef0e761d46bc678f7c2ad4eed9b50e8950ae90c6d8db2a8f629984e7e80160a055f1c8da7da097e136b414245b58c04f3c9d104e4b2f5f0ac42164532a717333749045bb88c69d5d5783e4815a707",
                status: "df1827009698464fb12c5b2dbfc96481298679eddd8643ba81"
            ));

            await _userCompanyBindRepository.InsertAsync(new UserCompanyBind
            (
                id: Guid.Parse("72bfba03-d94e-4542-9b44-b9481a7e8a5d"),
                userMainId: Guid.Parse("7566a462-d609-4565-9fa3-ef21378aa588"),
                companyMainId: Guid.Parse("48dda868-afef-4434-85b4-4219defd2356"),
                companyJobId: Guid.Parse("9d06dc7d-2786-43a5-a3c3-244cb0ab0199"),
                companyInvitationsId: Guid.Parse("a5aa602e-cc18-4e44-a6bd-fe4040a396b4"),
                extendedInformation: "0e09bbe8b29e466bb02edafefe82050b1257c1fef5d3441199ee602673c26ec6b7778c3ac80e45eb8642db8bcbb2a2c4ed0f82b35bb5402da8ea0123d3a2b84ac933cfed702c40c7970ecdbc236a2d0f5e5b329061e34a7f9176cef4ecca900a73f03ee684624f3cbe0cd0dd0a18661541c84af78f4847b794dc5b29a5ff1de3ae64f9c67d6c41d7a3bc5272cbdb91575ef61dd150c74c389002f3508d3eec0e0bb18675246a4a909c9f1067c29264e3ebec419457df4ccb9cad89d3185c027c140f2c292ce0471096886610860624d5dcda139826254ca5b761dc1ae58da7223441c51f53b4454aae9d307ffee65f3601ebfd90d77a422294eb",
                dateA: new DateTime(2015, 6, 18),
                dateD: new DateTime(2022, 5, 22),
                sort: 1117202537,
                note: "f529d04075b94c9889f8422c92acb7bd3300999e8ce34c659e6521abb20befd27ed15e1f3f93471195292de08b487e84b990881c45f84da7ac8c4825ddf95bb0d7ddaec6c18e4ce2abf1c8b0cd8e85a46d9f039958724e668958adcf567f65c0adf79c4f3afc49b6a13598cfb1fe14288f11ad3b4b3f487c8c8ce0fbf06ae8b6c188ad7f243e44579332c4f4063ae6dc8a42a18264f44e5e8007a21bba1984191a2280062f574180bc82dc4b9319b6388b351bbe098845f38431b075934b835bb29d9b19e3b643b68bdac490725771d251248b595cfd49bd92f569f7f352c963884461f81282491eb1e2905c2f05e3c6bcff02db7dc4425d9bb0",
                status: "0a8828777e814a11859722894b48d1b7f11370b02c88420fb9"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}