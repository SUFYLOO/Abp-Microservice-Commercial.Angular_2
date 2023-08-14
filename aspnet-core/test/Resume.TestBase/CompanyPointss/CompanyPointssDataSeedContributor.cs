using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyPointss;

namespace Resume.CompanyPointss
{
    public class CompanyPointssDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyPointsRepository _companyPointsRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyPointssDataSeedContributor(ICompanyPointsRepository companyPointsRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyPointsRepository = companyPointsRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyPointsRepository.InsertAsync(new CompanyPoints
            (
                id: Guid.Parse("cbb91d82-6cec-4bb7-a867-61950103a6eb"),
                companyMainId: Guid.Parse("40d3f98c-5a6b-4a65-84d0-e1d2d52f59c1"),
                companyPointsTypeCode: "cb366e8203f34a45b5455b9eec90fdb9541a52d8cf48416a82",
                points: 295215930,
                extendedInformation: "a3db2d2d4ef04da38b3bb36841cfc52ad224ef95c1484266aa0d8fcc61590abf558ca19bf531423da9da15c8ad7e59a7b833ba9af4f8435b9c4f85fb24d63797642d9aaa77d54918969e8e7baf20268a9761dc6df54b4dc6aa4af2f555e2ddbc7213a50923d84bdaacc3895c6323fa2b33d1dd363c7040a4bed0e37cf2c3ab370cdbf3e6c4ff47e894d9f87d9d261dfa284a24b2a4ff4c9892d58c6ec32b93e1f01ab36d803b46b7a7c0d8002fca4181fa6fa05b2ea14130be28177df9971d9327fd0336ee4f48b288e341a2e2a7cee524eea98a76204fcd9cb3284d82d1686bd34c0cbc1122400c9504040091c40f5038b1916c3b6a41749e65",
                dateA: new DateTime(2006, 9, 9),
                dateD: new DateTime(2010, 8, 13),
                sort: 310388383,
                note: "3a284161aba24e9699ff81849b2870b4e7a5b05b939c410cada97d8e7096c89f135a17f74c6e4ce09813d42d5bf74a48b5ea6765ac564eb2909632ff99590f707c3e2b1d3c77485794c62918ef1d37f0bbecac99bb7b4dd8bbf45598ff7ad27ce0a37fe137a344f19f7bdf68501b4f747e15bbe2af7a42d1b516fc55899ec024553c0368be2e4467b88905cd2167e8797fbf6639fe8746ab940d5a3c22a366deb133a31aea464ad48c186814113789df020b7fca92ca44b18c42df22ede97099448d1922bc994fdb94d26108bec403dcd7e12095b588470dba0003af8438d080d400be353f994ecd8d9548cd85adb3222b6cb7fd723542508206",
                status: "931e3806efba4679b6985495d04abede92b13c5f5d354d42ae"
            ));

            await _companyPointsRepository.InsertAsync(new CompanyPoints
            (
                id: Guid.Parse("ba1c8e5e-84b7-4797-99db-9d6d173e11d6"),
                companyMainId: Guid.Parse("cf5d4f4d-800e-49e0-b71f-be4844ac408b"),
                companyPointsTypeCode: "43897c09df2f4ff0b637355a7005f41c7113d5639bc3411fb6",
                points: 891611262,
                extendedInformation: "4003d0b1f3f848b09c55121b9c2e97f643a931e1fe78492baca0592e105d8d74aeaaa1b6b398462bb8ac968af605c4d2cf30dd2bde534247a7e17b7dec85e3dbcdcf8da9387e4823bfc05f9d2015d080939eafc18ec2467c93d2b309a4413b3abb9be937339c437b953463b355c46e124b3ca612bcfd4dd6b761b8ee0c2c75d2086543a54d4a4884969213093d89027f5c9125bc376a4227bf9ead96b4a5db69ae69f57eeac9421da7e796b0ae2108f3c07d4d50db2e4b7d8c2ff32de6edad1a9e8aba4f94044b779ebaff0987f5fbf1455c0b288e7d410db544600a3cabca971578dacab52b4af59a4efa1093e4cdd7689764a1e5af4b1d986f",
                dateA: new DateTime(2019, 7, 8),
                dateD: new DateTime(2003, 5, 19),
                sort: 1580724046,
                note: "5e60dfea019d41debfbdfd9be0b336f28ec255ea375746ac937d4bbd51a60bb44be74b570a24407ca98ec74f83c7e4f3fed56422d34548da9508c8f8aec1a210e82f861b3cb842a6807149be0bc321098b7e83b3944e48d984442aad4b721a9a89b3c932484d42b9a17b04f7f2adf96c7a7fd02fa2fb488fba188ee67757e22aed670929415746039799de6f9265a454d7d587715b1749b59c6675520bcb4d399046b1a762d544d3baf49d38acc5e60fd383c00905c54aa4a0e81eb92c8cb3f64d32f4d71807421c8024ec2944f2d8a1acaf081a75b64ff6a280c2b4066df5cd7b6d06b3c5f541348f2883cdae42f1385fe2257cf50c49b0b227",
                status: "29c68b7a055f43e996709f4be3f09072e1617e01e4574e72bf"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}