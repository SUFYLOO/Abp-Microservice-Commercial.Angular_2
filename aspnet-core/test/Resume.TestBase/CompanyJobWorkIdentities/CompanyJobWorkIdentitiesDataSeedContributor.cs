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
                id: Guid.Parse("83571cb8-40a3-4644-95ac-640f6f19f559"),
                companyMainId: Guid.Parse("25c41399-a6ad-4810-9c59-5319260e06bf"),
                companyJobId: Guid.Parse("b3e912a6-bfc8-48f0-9bc0-2d464baa83e5"),
                workIdentityCode: "a93a8a60210d4e8e9d121e49fd2e7d696efb9ad7f32b4c5daf",
                extendedInformation: "e775333f2ecc45e2ab6a6c3ee322d6ccebe5df95269347748cc94bae7177ef1ef1a0a12336ac4ad0a4093abb8f8cbf85c83f3be703424775af5df6bd94aded1ea953fc66f6614880b16f405ccc864f6e03d506e95f29485380812505863a86cbdb200ca93deb4c5fba3a4b65b8548743fd2cda3c59db4329a269ba7884f7331f61b51d6456fd4ce483f09078b5a301aaa90fd6e263ef43c997af7432dcc839f7cbf758ab06ea46a68f9d0061434dababecb50a2742a44addb7c30d8ff3cebaf9511247cf25a8425690bcc3bef1b0e652d4d1113ad62e4641869830dcbaff077c8bcb37d8dc2648108157fd9723ca3d92f1f846a808dc42cb9428",
                dateA: new DateTime(2020, 6, 16),
                dateD: new DateTime(2004, 7, 9),
                sort: 1597142516,
                note: "5125df539d614207ae8c9e07020fd86fe7d17f90884d462fa33e8abab7f863192107c7e75ae94a5fb64aee3e65dfab2a7257aa706fff4fc28ca89e87b3e69439cfe7ea0907ea421a89dfd3412691d09c8d5c7ab21fd44ca6ae1e204e0df157098eabaa720bfc493a8ed8523e68aa83d1ec4b6063700b458fa5d55a4c7813d2c565f3276fd70a4fe6a3bd1e5b50b272fed10acb6ec5cd4cebb4d1f1ab19056108bf86b3544bc940f480b70bab79e18d1a0aa96c53060f4b5f941757c5c5866e9322d7d20c34f145dabd767c3bb4487665aaa3b672ce014402bb89a307deff777c2b27e8573dc44e279b39c1ecaf263469d86619bf44ea4d9eb680",
                status: "ab91505fab22439aa27f89083194deab387c85174d314bb9a1"
            ));

            await _companyJobWorkIdentityRepository.InsertAsync(new CompanyJobWorkIdentity
            (
                id: Guid.Parse("80fef142-4fa7-4bd8-bbf7-5abd97e2e7df"),
                companyMainId: Guid.Parse("38a88ec0-62d4-46be-b291-a6dec79aaf82"),
                companyJobId: Guid.Parse("3bf17187-275f-4e54-9e3c-a41e327b918c"),
                workIdentityCode: "476c07b700a14a12a67847db74ccfcfb173f4a2fa79342b38f",
                extendedInformation: "7625e68189694732895af203682c0716800389dbd9de43fea8e154626e08c21d9cbd989478864b9fb04558e9ee80beab64f8504ebcb24e91b5d6754e3d5468bb2cace40fb1ac46d1bbe650ac3e91a67bf45633192acf4468b54f2646588b5dc0d6b2b51886774f12a4ee4ccf55b78ce06b935d8d39ce414fbca1c216ab4364598e6dc7f035f5431497429e144be88640c5220b1788ae4aebacb696164afdefa2fbb8513a55e24b89bbf21116e875bfe20374f3baadd745e792cbbb39ae6b376c4c500a6e298343d0bc50aa7a085d0479855d79a6ad7842f5aa65e026e5a9adde446842b273f741b7bcb6acf2e6266e962a72a64ca53547fcacd1",
                dateA: new DateTime(2011, 2, 24),
                dateD: new DateTime(2003, 6, 8),
                sort: 1155517943,
                note: "2b1d2a005e8e4a4f949a5d9dd5d4c4ddf23ee5b11455404f9038add5cf80754c4f74e7b0037b487a98a901fa24906901c6f7a00c902d42b78562f7e77d2d0fa965bf1ebed0e54ff091e8554936fd829222be7b2ebc1d4c009eb9505824fbca3857bfedbcba444178b22663abceb9b3b082be294e497b4f2a859c00a5f74589de8d4f1a7713c643fa947fb2418e0da846e4ab1c7ae6844edaa6d6388af1be75900267c310fcbd4d49aedada3dec5d0f6bd8686bdb7f654fcc9744a4b9a22b29f0a41f3f3a0e0449ce926da81849f33ce80397333f48e4456d94a4ca3e4a618832af2d6e95cc494afca837df666a4599c0c7611330d20148859adb",
                status: "9cb70f72faa14711ad3b51b772117446b8845e7c503744c592"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}