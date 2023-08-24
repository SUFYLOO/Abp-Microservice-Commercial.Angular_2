using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyUserMainFavs;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyUserMainFavRepository _companyUserMainFavRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyUserMainFavsDataSeedContributor(ICompanyUserMainFavRepository companyUserMainFavRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyUserMainFavRepository = companyUserMainFavRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyUserMainFavRepository.InsertAsync(new CompanyUserMainFav
            (
                id: Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"),
                companyMainId: Guid.Parse("5cb23cb4-cd8e-4ed8-9e13-cbf593e1ebba"),
                companyJobId: Guid.Parse("baef305b-6983-4f66-8f4d-d7967e8523c0"),
                userMainId: Guid.Parse("81524ad4-3bde-41e3-b07b-e4bbd5ebaf46"),
                extendedInformation: "12af2c019aa64c7298fe0f22ee4219717069698e76254df7a769d6fdb492e93a33eb5eb0a0ab47dd901559f6271b83b6687ff73cd2634a24ad000ead6bd14a6a421a890ceea7424ca66deb61b7f09bd0923c8527b9584b829c2872c6ce1154bcca0e4931deed46638ac2e883b7101ebe9269ed25defd47b58dadb4b40505573d07874087c1a141c9ab202fdefecac5269f142429efbd4bcfab4f6b7c20dc41d6b31306133c7440218170082d731ea31c3f74ee73600944e0b1706fbba746d8ea1853cf2b22b3444abc74cd51ecc4678482613c72ec9c4562a0f366e9983b82351c05c36890214c64a6a6790866bbe331223473144c7244b49ce3",
                dateA: new DateTime(2007, 1, 14),
                dateD: new DateTime(2008, 5, 18),
                sort: 764361784,
                note: "93bb639a99f44386b5c8129f8e35969f3fd7a337ca3349beaaa607b4ba8f73739b3af88bc1b6414ebf611c1b87b16f846e90dd10d8b34d97a62ccb246ea7de50d23d71364a9448a6a20ea8372ca04d59b7db107a8fc24625b1d613aedb91707de2d1da1a9b034e4cb6a85e7ed4a43ba111285302e14f4478952b4b693c5b0b873934fd76c55b4dbd859687477ff8d725ef44e36a8f5a488cae9b47c00df29dddf13a7791172a49dfbb02a30f6ac24f64fd2889b759a64d7da404c14240a50685a1732dfdcbb1417fb8d820eaa44541d19dae751c49bb44bbb6aab4a34e3cb25ecdb5573f0f524122af1e717d0bdd9d3386d3e2f6cf214fafa8f0",
                status: "3f2745ae30fa4259b7f75d0143300615db1310b84a234297b1"
            ));

            await _companyUserMainFavRepository.InsertAsync(new CompanyUserMainFav
            (
                id: Guid.Parse("2f20f2ea-ee8a-42ff-9950-f1da774130c7"),
                companyMainId: Guid.Parse("0e39756e-a046-4ac7-adca-108f14a4cd79"),
                companyJobId: Guid.Parse("7ae882bc-07e0-4177-b07d-e17ca57d4486"),
                userMainId: Guid.Parse("c163215f-03db-4b5d-8660-00730aed872e"),
                extendedInformation: "3d7f1f826bf74a3da9567b0ce5895708bfe0659f03734af9957085dec6680d5fd83cd8d21cab4e76a9c0e011b827bf49758104d9fbbf4a90b3fcc6b555bb7c6d05996766d5534187bb0c224bf32f83031856edc3b7194218aef796709be49238a11d133299144186ad5e04d6458c5f6f68eaa825923b4358a934beda042ffe18f56dd1b20b9848c4851b60af6b2534b6b6f0d80acf70462eb94efdd3d1ac159f4f1e7b68411a4a61a175b0ae7632ed59e6e64f1bbc3f4411b610aabd584fd7dcf39118dde84047a4810cace5ea351403376f02b014c24a6ea41091822407ddd8a1a5e0c2e5414469bb988e039f68695e5232efa3dfa14502abf7",
                dateA: new DateTime(2006, 11, 23),
                dateD: new DateTime(2009, 5, 11),
                sort: 1475996029,
                note: "1ba92d0591d64f1282250baa352a4ebd8af922648b18485e8f08d99a459f8419abbc50c7eabe41268dd3a6a277ad5aa926d872518ad54b84b8efb28a14dc927ecff6c56d1538456687171c1d3d33bd3ed8141f7c1bbd4e30bc6c3162a1ce16118da75bf82ecd41718b6d479a08c7cbee5f09e15fb8864084af59622dfa0f0320ccf975e68251463da7acd514a9cf24998afa160bb98d4c5ba9fc6bb739f7b1d0eb0b804a36c14fc7b11bf140c02062c8e373c528c49d408e95b7888b196a070ad0e9f46aa3384884a0f2dd82889dd2e89f4d094a33194f5bb99c23af2499511b52f8a3f1737a43b08d00c9f2418fe4da80e4a860be364c02a11a",
                status: "1e2e1192868a49d7ba2c45b6c6149a38c04d69394a2c4d308d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}