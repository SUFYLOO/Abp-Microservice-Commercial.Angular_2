using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobWorkIdentities;

namespace Resume.CompanyJobWorkIdentities
{
    public class CompanyJobWorkIdentitiesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobWorkIdentityRepository _companyJobWorkIdentityRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobWorkIdentitiesDataSeedContributor(ICompanyJobWorkIdentityRepository companyJobWorkIdentityRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobWorkIdentityRepository = companyJobWorkIdentityRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobWorkIdentityRepository.InsertAsync(new CompanyJobWorkIdentity
            (
                id: Guid.Parse("277f9a57-04ba-47bd-aa76-5c928e88949a"),
                companyMainId: Guid.Parse("748e0d54-a8c2-4584-b31a-cd7123a5c630"),
                companyJobId: Guid.Parse("a7e42031-871e-4f4f-8861-60be1fcdf557"),
                workIdentityCode: Guid.Parse("ed8c106c-c4ca-4397-913f-70891066c349"),
                extendedInformation: "13935b7dd790472b86a7dd652e0b76ad23cc15498e234bee8314178468fcc057049dbbc77a984b9b9aa1bdd27189cbcf017a85b71e144875b7929205c64ed72e3f0f765f37574cbdaf14ba8885ea4ff793b70a7d60bb4e56b208fba4d854943211e851e3c90f46a68f7f20caa4e6ffce66d397bfb6164071a53fc3c15ca43a30202f9d3fd38e4cda95647b3882a3ffc0c3634709dc8a45fb9bb1b6690997929abb587ad11aed44e9b6314823f16fb92a18c2e4d0286444dc968649fb0862fc97a300166eb9314b71baa770ad1762520621a65633a55b47d69c4e884abe362fb8151f67cdd8e54b9b8a7b02d05cdcd792f21969f26f6a4b688fd3",
                dateA: new DateTime(2020, 4, 14),
                dateD: new DateTime(2016, 8, 14),
                sort: 962121596,
                note: "617b130c4061488d96a0c78f1a02b4f0dc28097f1496464789e294a38baa910c6402d821370141b681465433a592bf6fd668449c4fb740c48721b640b4df231cf5ca2a6e69c54f8b8ebca55c8f9d5df50449a8920add48459bae478736a8edd8c5ddc28784e94effb90fa37e1250819dce1a6c051e384ca0bf633cbaf07144d7b9731e61aba54d0f8f301d143abb7c2b6fa0cbd5cf9e43688c77f07b39ecb2f35fc28b6a7f1046c0accb326e112dfa52baf02a0039714a5c9faa510e5697ca5b31712b45114e4b05b9db1686c9dd97d696fbf46ed3fe4cae9fe86d56467de967ee8a8f6b7977425cacd4f68f5c751a9d1cc7d9ae4d2947568a54",
                status: "ae31eaa6dbdf473180f686789436cfbf789b3d59ef5e44d2b1"
            ));

            await _companyJobWorkIdentityRepository.InsertAsync(new CompanyJobWorkIdentity
            (
                id: Guid.Parse("2b330fdd-99cd-4fc3-b542-56b7ec20a9ce"),
                companyMainId: Guid.Parse("dcf88974-87bb-43b2-8264-f39ef3fd47ba"),
                companyJobId: Guid.Parse("4ddbb7af-4295-4cac-a061-740f02f302f9"),
                workIdentityCode: Guid.Parse("011bd5ca-2d82-4f4c-a53a-92cc7ad9c4d6"),
                extendedInformation: "32721edfe8c14c4aa1086061d86f02145f2e99bd9f6a49299eadeab727b7356a97818dd8e95249e58eee60c9e87c212ff84e5d116e1f400397434fef0b1055e924d87a37ccfe441f8ebe81035b3b3d765b4fa09c68544205a279645208365006cb2cf1c80781456da4786481389d5785b500f55d16d44f7497a3debefc4bbca6f073cdd80c774204829c9b006bc953ef35e808fdaf1249cd926609478c6e6b1fc0ac6a7ebf90417c85ff32249b39225357c5b2be7a2e4ca8a4058a875e276040d9013df14fd143d3bb5fccbc70c3e69bbb638073282c4341b30f28f36013de80ea574645b03c441a86a8b3fc0e13be14dfce5b04dde740d28b88",
                dateA: new DateTime(2010, 2, 4),
                dateD: new DateTime(2010, 6, 20),
                sort: 857229747,
                note: "f83bb0ea769c47228bc6d5c486e8181f2ff0a368713e4bd2b4fd82568c78d0f7d8d44444d6b943e3a96b9e60900a5cd391e25b2b81f349b4bf74bac4aa7f3ad84abe74df5c854e88b5170d7f57ab7e9ae2e3613fe0c740c3b2abbdb1f229633bc004c9b7a7b14de78617f88ead8432a2f14740e815494867b6093ee6c2cc659672c94311714b40b3866445f8dacdf92313498addb52545e7a5978f7306fa9323e60cb8977a3044da85ce85aad43d411f902df1780e7842508977b49bded0041b43952209e859407087778faa91da30a534999b51887c41428f9b218927bb020173d9f23872d9452a9f487fe5d84a7ad15de08e8dfd784aea96b7",
                status: "a857dbcf3d2f4ab6a31a91cade7697e13a3b31674cc84d6d90"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}