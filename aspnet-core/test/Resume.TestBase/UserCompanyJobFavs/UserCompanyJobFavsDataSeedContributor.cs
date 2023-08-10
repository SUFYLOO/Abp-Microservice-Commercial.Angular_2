using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserCompanyJobFavs;

namespace Resume.UserCompanyJobFavs
{
    public class UserCompanyJobFavsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserCompanyJobFavRepository _userCompanyJobFavRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserCompanyJobFavsDataSeedContributor(IUserCompanyJobFavRepository userCompanyJobFavRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userCompanyJobFavRepository = userCompanyJobFavRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userCompanyJobFavRepository.InsertAsync(new UserCompanyJobFav
            (
                id: Guid.Parse("67731f4c-a914-4988-b608-3eb3a53ae922"),
                userMainId: Guid.Parse("3f6dd9c8-fc2e-4ab9-a855-bd81ea17cfed"),
                companyJobId: Guid.Parse("ad48b319-1db4-4622-a730-c065074c917b"),
                extendedInformation: "ce24ebbab39d4f24a705055aabb38ea9f2b3a56388a84e0a91a4eaea94b87cda07f6a960b6104228be7074ad04f1cede6af0827f682a489da8bb2a5e95a9233929b593adef724158b6d1cd8afc069f8b3ab9465f60234b65913f29514713452cd5282058a2a24d56baa84b932ec234771b4a9473007d4a898960e2476775123bf25f2d5f23fe41b88f650381023e8aa89e20a79a01cd4828beabb9d3c614f9c9fa60e5e499a04718806e50477450c67de9df5c86a84e4af3aaf8ce5e8086b8fb9b337d91099141b39aee5929377eb178bba4477f377e4046ad2ac48099b051821dbc80702c2e4c8e9040e8b52cad174bbcbce4a61c54414e8022",
                dateA: new DateTime(2012, 3, 11),
                dateD: new DateTime(2017, 5, 13),
                sort: 2138696950,
                note: "b755ef89c9d047e1a1f0749566dc30bf4be344aa09ad46c8bb38696608f8f7f59baf40b0effa4a05b51f67e3220444d57b51baa0bad5426c9cbf2fe5779522533addc84b6f0a4af0a98764e56e59b12c1696d035cf11431cbc1decd6df23db61dca3c6deced74c3ebee3922959b6d359c4515b5423f9410382ef9b8fa1fd9ba9cb76262324b243868e4195793197cd26603f629a4aec4fe598f89ed925a20597c05a06db55734ecb97a8bd445f1b66134a5268746c0141b9b4bf23bba9b6cfb8611b9f79a9674cbbb1a32e9ffe7271869bbb610da4a3435aa2d032df86d2615e7a5b248f868f41ce9fdd59bece91a24b87b270ab1295478bae7a",
                status: "328bcdbca4384b6a9bc1c50c710081c245675ba0316f40bcb4"
            ));

            await _userCompanyJobFavRepository.InsertAsync(new UserCompanyJobFav
            (
                id: Guid.Parse("bdcc6eba-cd62-49d4-9edd-afa20c82a48d"),
                userMainId: Guid.Parse("a5debe4c-6287-4022-8a1d-c9fc80b5be47"),
                companyJobId: Guid.Parse("a022c8a7-26e3-4638-92ed-69dd80b7e572"),
                extendedInformation: "e4b3a02a1a504e6d96d6708c3892b11342f7097f966c4931a49370a235e7ffdb363ef65ed73940f9a7e88da8ef066de4759f7f0d2dcd465696b0ef353e3d8aabe48862401fb44afcb679c7d8c94bd802476bc8e444ca42fe85b3cd55351e5d2f5bc131e9fbdc43fcac0bcda4f4ead53f89b700e2c97b4cd09498533d93e4b55d4ebb9bea324c465b906bfdcd4080bbe2018706b107574206b13b5ace1af16938e4a8080c6bc7407fac0c221dbe448ca2aed2ee39c739486094ca6ec3f3873db528f9be8b285e4cc7b06681f829ece3ecde5f57e146a7458ca5b4e956c2208005db764414c05645bd90ee8282c7e4d8b360b0edef4fe6451ab9cf",
                dateA: new DateTime(2006, 11, 1),
                dateD: new DateTime(2022, 7, 14),
                sort: 1253995842,
                note: "1a7777033dc74d579a6777d4b0a7b3b619d788d7ba4344bdb794881bb082323e38c5c083761d4f74b6634ad1aa0daffa283271ffbe224918b8deda25c01cabc757d47e9f53f5454aa19f527564f8b16cd77f31eabdec4eaba848223462e088ed0adf30c36b7a47d9bbb128783949b0347f9c3973d1f845e493dc40023ff4f0dc3949e5adef344264b233e0e9163e80f12b1b3e721ee84707913a9c3ac570f075edaf800bb9184ea38149c4fbcd29d5b0980169c9874240728582b1544f6992b1b9980d02e57447d8b1a1580f15346603b876fca294534e41a393bfd913533f786a49795d8ac34e86b1816626ed6cf579f4dc9281ff35411faff5",
                status: "4205f74cb50d4de08ac04fc02f6762cd836d53e817754dca91"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}