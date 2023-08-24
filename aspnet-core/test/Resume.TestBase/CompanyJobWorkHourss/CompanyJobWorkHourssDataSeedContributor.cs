using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobWorkHourss;

namespace Resume.CompanyJobWorkHourss
{
    public class CompanyJobWorkHourssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobWorkHoursRepository _companyJobWorkHoursRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobWorkHourssDataSeedContributor(ICompanyJobWorkHoursRepository companyJobWorkHoursRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobWorkHoursRepository = companyJobWorkHoursRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobWorkHoursRepository.InsertAsync(new CompanyJobWorkHours
            (
                id: Guid.Parse("d42c5a2c-4a4a-4070-bb70-723e224cab7f"),
                companyMainId: Guid.Parse("66b496f1-5d49-4ac5-9eb7-066fc58720f1"),
                companyJobId: Guid.Parse("4d8162ba-c5fc-4128-9a44-f6868df82aed"),
                workHoursCode: "4c23b26edc3646d9955d518aa5219a854a126dcaa9eb4201a1",
                extendedInformation: "b5b0079da27d4803a3aa08d29e",
                dateA: new DateTime(2016, 9, 20),
                dateD: new DateTime(2010, 3, 2),
                sort: 147016614,
                note: "501eceb94ded485ba4733d9ceb503f4a945e4ec926194c24841892ffab5f47770f391d56ff58481596bfe379823831e237d9516f295641fdb5adc9134f6ce4b05d2b71b175d740e7b8a66931dfe7eb9fb7b6e735c6dd4d26a131c3db2dd88ebc0eb024b5e23a42dba06ae5321c24394c8b2c0747ff5545a89c6690b136f3a6b47770c35c611c4792b5c1d45d1a1885b64fda02c5356a49fabf4dbc45423cf72717a5e63e76b241aeb6f47e25087aa2de02a2e9bd6c7b46cc955f966a317461699d73f4f51c9e4cedb423b87d3e0c820eb69cc70e5e914cb794dd03494e1164ce131086aa8c3748d699fcdbe54b77958f072e2f7c227d41038ba8",
                status: "f86014ee05504cf0baf9c0f521f598079a9142654ec848fb8d"
            ));

            await _companyJobWorkHoursRepository.InsertAsync(new CompanyJobWorkHours
            (
                id: Guid.Parse("9037955e-0dc1-4cef-9ed4-10ac8e86ec50"),
                companyMainId: Guid.Parse("042d1ab9-1590-43a8-aef9-cfc05baec218"),
                companyJobId: Guid.Parse("cdc0b734-9541-47dc-aa1e-d483afc57897"),
                workHoursCode: "aa3409d172a445ccb791032636610187230fa7bc758d429fbd",
                extendedInformation: "95a4651d3d45406189f198ac8d5443bbeb4",
                dateA: new DateTime(2021, 9, 2),
                dateD: new DateTime(2019, 11, 8),
                sort: 535548221,
                note: "fb80e050385c4ec99aa1722e69c924a2a682417dae13488abc261e12de328e476af48116f948475291b82fe3f6e9369c983c364eb85f45d4a5fe089452fea446fdcedbe85c724b0e9fbafc8f9a84af771f89f48a155e444586974577fef8e8f43eb6a1f6847749be902e2aac99738e645cc98c3b3dc64960a3d4b7cdf60620e7e16e950c0709403c9796da8e5adb3d7f0cedd9ff8eb74ce7a89cdade3d3530d69d933a27818a4ccbb6ce42cf2f0b3f6a18408afcb6ee49b0bbb15317cdafdbd76c995516ea9d491baefe3062761eb332062ee7ce1ef5446881406f9e529683c9283528c13d2b401189bbbd65cc84533689cd1762d5be46e28810",
                status: "3379ebda5c6d49c8a8f86d41a04081357265a2064f194cd8a9"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}