using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeDrvingLicenses;

namespace Resume.ResumeDrvingLicenses
{
    public class ResumeDrvingLicensesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeDrvingLicenseRepository _resumeDrvingLicenseRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeDrvingLicensesDataSeedContributor(IResumeDrvingLicenseRepository resumeDrvingLicenseRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeDrvingLicenseRepository = resumeDrvingLicenseRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeDrvingLicenseRepository.InsertAsync(new ResumeDrvingLicense
            (
                id: Guid.Parse("ad4e9d79-9ad2-4064-bd25-d4fb4b012b46"),
                resumeMainId: Guid.Parse("87728d33-fda6-415c-9bbd-dc790646d89e"),
                drvingLicenseCode: "2d145c59a52443a59ce79a557efd9d0af93ae33957c04f328e",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "8aac19c6f6af43358aa9ca71c54de96fffa039093a1b4fbfabc0f2cae790b1b80ee0f0d49db946e7b15f4905e17774349e40ed332732491a953cfefe0a24d8703b0b3d2140f941d4b825bc0c70d5d1c1959ec7df22b149ab84bd7a764693266ec2dfc2361d1646218ac5a72c25d39d1a9ee96d1d8f0a4e0c97a9ced80dfe5d3837301c29736e4aaea87c4843eeff4fc4fb3c453308d642d98ee7f327e9cb86482a2c1b99da4844e8b9d0a2c659ce2469d826daad51204a3dad41656040d3950661a5570303b24aff9e997f8895eae68ee83282bbf87d4de6b32367ae65d668ad8131d80f50b94f4f9a4f1331d4b636256b6ac3750f454bef8b60",
                dateA: new DateTime(2007, 5, 25),
                dateD: new DateTime(2000, 10, 22),
                sort: 1662257719,
                note: "d75550167c574e508664a53ca262c0ec5cdeab9d43194b83a702775b24b20c8b2194b3bddb2e44a5aea5dda46e3e321e06d451e4de534aaf836d1372dd6130959d62a6537a4540cfb9cd1bf12abcf290972c3a804a1b42a49163132124e8b257695f7ae3f19e4ef1ae2719af6fbf9dc84d64de31eccc4b87a37f002c0d2008a1e6b3cf9294f84040a5b76eb8e78c0ce5dad317070ff94a5f8f1c5e13c519a48caf11351c04a64b25a97d4d9b72d18b3b82d4a4acb48a418da33bbc0d5aca6bb72738a8ef10d5444fae7744a911fafd844979dfdca9f04f158c52ebb8e78be2b34377b4a1490d49009a0058101395b0d2250a99972f2242c2a763",
                status: "8a98f50b9693482fa45c62a3adf2fbbc45c7547d610a4f1ba3"
            ));

            await _resumeDrvingLicenseRepository.InsertAsync(new ResumeDrvingLicense
            (
                id: Guid.Parse("75e33aeb-20ef-4435-b703-6c17a668d296"),
                resumeMainId: Guid.Parse("349675bb-0bb6-4610-9770-04a9525e4376"),
                drvingLicenseCode: "b494e8312e1f4d4cb7eeffa922355d179c01e786aa2e4582b1",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "9916cb145174407cbfdd49974a65768f09c5cd2b4ac94c40ba0abece9b5a017eb90959ef8ee94fbbbcd6624acaa9cd4db8bb4dc771d04956a9cc8dc1cfb25226eeca80b68d8b4144b1914d574ef913d821cb6e96f01647e3859461d30bffb833b0722f95b3184349bdc6fd11b4d536ae86f1f5b56b2a4bcdb65818b1344b2f852d23db48c00642f2903c17b991823cdbe8ba5ab6c5f541439ff11ab3fe176df1d2a543c420cf4a25a905e74838f486f2eb740e6e2edc4256b2cf2346b3825c5007c5526716584161ade9fbbd2d45429b71eec1b3dc23438a89d41735d21a13154606feec77d04fc587b45cae05e6c66ab00b387b14444d84aaf6",
                dateA: new DateTime(2008, 2, 5),
                dateD: new DateTime(2005, 4, 26),
                sort: 805900596,
                note: "06a46892c6a741c4b18fc6571e5b8dc4d0552e272a9e43d69e93534ed93c2dcc601087b2c22a4729a818c612359dadacbeb4c63e89da466fbd0387c13ceb1ab65b3a2fb7230b460e807eab4931df79f57daceb03b98d44be94c724da33deceb96d508e5113a14848bd86af9660da8dd638ba010279604eaba6d49e30173100fe0b526b8791264a27a4e0846fafbcb905c7f5b175e5494121acedb79b235d1f4c471923f0a2cf45449a1ace0a1417732249efbb7e7d4443288e756a9d2626c9861504a7d286f1408980c25197405e3d8b5c770651861c4637b343b6771abe9757fc97bd3b500b46698a36545c94c1edd74540ab63ec5e4a92875f",
                status: "00b7b0ecbaf94a02b025514d0ed72b56907caaf5084045f7b6"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}