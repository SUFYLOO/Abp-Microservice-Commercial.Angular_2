using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserCompanyJobApplies;

namespace Resume.UserCompanyJobApplies
{
    public class UserCompanyJobAppliesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserCompanyJobApplyRepository _userCompanyJobApplyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserCompanyJobAppliesDataSeedContributor(IUserCompanyJobApplyRepository userCompanyJobApplyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userCompanyJobApplyRepository = userCompanyJobApplyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userCompanyJobApplyRepository.InsertAsync(new UserCompanyJobApply
            (
                id: Guid.Parse("6981f434-d2c7-4aa2-930d-043f0b79bfc5"),
                userMainId: Guid.Parse("5945701f-0638-40fc-93d0-1c30358b80db"),
                companyJobId: Guid.Parse("29d87373-e6ca-4d0d-be63-09c2fd55893e"),
                extendedInformation: "0264156a7d194d0ebd1ca2ceeb39c04eabef6e5824254b9abd20fd48edb800bfbdebceed184243c1a8edb049df157ee23fb666f156a046708700220a362c055640e030298dc74f8c8bf41d5cb1150c07fd5fe19aede14c2c9fc842ea23e19d171f46d530b4d54aa69e0f59dd915b078d363042b4f072465ebad5960d952b36e76612c8563c914dd28718ff183114d2bfc654a0aa2db04edabc7f2f87806229c55dbc71044e354ff2a3f6146c2ab1747a6b083d2857bf4a0781c4f9df95f2834ccd41566bfb8a4bd1b2fb9263fa28b1b76aed0098795b4defbb7da42dfa552c2eb5bbca9c87f147298d06fd99414b15a1161655843f0141908f97",
                dateA: new DateTime(2009, 4, 22),
                dateD: new DateTime(2003, 5, 4),
                sort: 1645487871,
                note: "cff8d627f3f94a989897f38341796bfb0b41494a8c6f4d6bb446cc2ae9686f74e3a75ae683814bacb0d0bb45621b757925307155a8bc4bb4a172247358fb9f36fa5e80259b474f99b2be7e58e33f87656b41b9dea8164e9fbb0b4a52eba59fcd991c445c3530427c9aff3a133f9150f3c5fc2e64ecf4442abdca39ad746202567b1f1dc611a34a1aa89331a47be9a4bd1d3b8016f61944689752314ef7c436d37f25bbfc15d047e5a4a877a77ae8ca4dfeb22e898475425494947eb2f4debee8035ff769219c458898e3853cd38a30b1fee4e05d7e3b48d2ac995cdb3138cbffcebb97ebcd8e4334ab43d288d0d850e060d568f3a23148028b36",
                status: "f4249b65c7a94cf3af9eff2476cbd5db1c203b4a03a54d51b8"
            ));

            await _userCompanyJobApplyRepository.InsertAsync(new UserCompanyJobApply
            (
                id: Guid.Parse("0a3eca8e-4dbf-4616-a977-0262b438a1b0"),
                userMainId: Guid.Parse("9c34b1a5-4301-428a-bafa-6603980d4113"),
                companyJobId: Guid.Parse("73c6d565-3770-429d-be02-f08405e11322"),
                extendedInformation: "e7cda8f9ae1c4668b8aa22597d53a0f88b06cdac6a0147e7826d20893f90c1c2b6466fb838634468896bfd04cb20f31218c5f2afd1d848c5bef8ce5e7f308c178f3ddd789bc341bdaeaa11d56fdf8ff92ce48c8ee1b140f08fdeb1b9284db490c22810272d774c038a5ee2f24f7fbb1a81f1c946655b42c79b4ceaf3b7bc6bcd9b42004a48db4b87acf54b117bba1d076d5fc928146b47298eb1eaf14aee6ea0f3abb90ddaad44fa8966f76fb233ad7ced383dd2e0b44873a756bc8ccca1e3be2cc89b9b50f54dfa9a1d1d0177dbddc53a9aa2ff253d477583dff559f62d19325031a034717d42aea8fa8e495adad6c9c885e36281ef41dda5ba",
                dateA: new DateTime(2003, 5, 13),
                dateD: new DateTime(2004, 4, 13),
                sort: 1786099364,
                note: "c4d8bf2364ee4d18919efd20d94f3887e6e08f7c128649929d6070742ac394ef116b406fc7504ec8a3cd2eabc3c438f354f34dbc2af542b0a9d3df1a7e78451f00562ace989f411282946aa779a7c1d9996f8e7665724f148a6487035019373e18f60ab4170f4bc590a840df011ecd9f0cf0271716ec4fd8ae42af4841900c7b49a4ade78995464688771955235ed810cc459ff2f7f14354a28873c7eb574f0fb5a811929fcf443fa935c9e913cbe63969030ddfc75c49f18678d06345aec262794a06b04d704843b047bf9979f34a0a4dde40a495b448ac85afd23d40d0be3904c0a0fbe1fb4a7991742a45399eb847d56071cda1644fb9a714",
                status: "7114f266016745f4b6cc8234f5954c5609d873476ca5435c86"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}