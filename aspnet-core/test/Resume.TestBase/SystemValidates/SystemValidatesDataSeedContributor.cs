using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemValidates;

namespace Resume.SystemValidates
{
    public class SystemValidatesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemValidateRepository _systemValidateRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemValidatesDataSeedContributor(ISystemValidateRepository systemValidateRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemValidateRepository = systemValidateRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemValidateRepository.InsertAsync(new SystemValidate
            (
                id: Guid.Parse("765cd66f-9162-404f-81b0-2e535edfafb9"),
                param: "31c117b40759405bbc0cd94fbfab04a79a617a307eaf41bcb2029995d29d8095cb32bb8498994a3db6a3f4f53c4b99ef6c371fa70bbf40d1ade856e9d97c35cd050746c10cf54c8096a09b8942e2e056e4c3a486fa9549e5bbc4d56f5aa6d02eb770f2b8",
                dateOpen: new DateTime(2020, 8, 26),
                extendedInformation: "170b4937643b4f8f945baa3ef4126f515671816e80f54b808e83752d05d5e41b89783dc08e974fdfafe0af92374bbad53c6fbb8a49194d5b99d35e8adbd09f309415325ce19244bdb5b689cc2ce0b9aa2f6d5fea1fe1496893bc1f4fc16786d280662b993e4a4c969b02efbd9f4d0a21e0d8c6f25eb24977914c1f642c96f92564a57ca9dc0a4c97887564e7469536752dc4a99e578d4661a1d11dae73ac4ba87bd245b356784269afec91e5b1d660cbfe56275dd5be4992861721433abba84544847e5af76e41edbec32e6353a4b891a31c3e41b3564e949d9fc77bf120e02d855780fd83e24ebc9d9bca9081bfcd614dcae99303654c5ca204",
                dateA: new DateTime(2021, 3, 5),
                dateD: new DateTime(2022, 2, 13),
                sort: 779663484,
                note: "4860a5cd53c94aeea4a1790ecf7662d8fd4209f396ce460f8ed82bd80170c4b3914a283798d94745a462c26cd4aa72187e7806d493844076a067f6d8e5a2001b1377b260f8f94b8a827e128577f4a9e8dc2373717da746ccaf16c93d544acb9bb560cf16ee904b858617ee4dcc5cb4ac2e76abc2a9064c7288e743ab7a7e9297b239768d5459497d94829ac3906b2923dbfb29fc341248908be37676f897fd7592de04c96e704bbb91632d9dfea02fc3f95d2ea043414ed38c56f496092f6c1dc0edd42c10774b439e14bdba6aed94baec03ab257f5343dc8eca30cfba89b6ff8d94bdedc55c4216af3ef3da4d651360a9c2eb52f2f845a98277",
                status: "c0cfde8ffed94cb9a5e58e8e88eb2d64cf7fbcaf510e443593"
            ));

            await _systemValidateRepository.InsertAsync(new SystemValidate
            (
                id: Guid.Parse("26914dc7-65e7-44d9-998e-9152ca1bcff7"),
                param: "4eb583b125fb41cfbacfd4864222fdf6eda3e7cedd0d4993ae9a335d987869b6ffdc68c74e2c4aec82eac22d0a6464f6ec4daf236b3248d98c92b2cc3cd1cda62081c4ce57b442aeb35680d9953b0017d191c06197454d309b5c80c15a10017aab22a091",
                dateOpen: new DateTime(2014, 8, 6),
                extendedInformation: "346c079bb40b4a40b0b0283621a98f9ba7e4d72eb3de40aa85099a94b8586552c8c56e6d5da54170b7733bd01ceadef66356d725e4a44ea69674d29df1f9655c99cf76e331e04492a50b68b86afc120ed660589b01e94c51aad8761ecc95b81c5dda274c10584fb39726ee23c8d4ce592185d12fe93748e8b4d80bb519d410b453cf5f55fcf8420992af853647e414cbe3b0c7887758434295f1bce5987e8d57915ca0c9f620451f841ecda07e4acc5f810236bfaeaf44f988ff4bd1620b2bb421cf70476282483f9aadff0eff8507328b7e6098d8314a20a7e3db0d26a35d430a09b342a43a49a18a89658cb605c6f930fc98b80bf74fb89830",
                dateA: new DateTime(2008, 10, 16),
                dateD: new DateTime(2021, 10, 15),
                sort: 472700680,
                note: "923f33dfe5584b7cb0f3fb294fbf41e3e55fb56d75914832b5ba856a895d7155466a19183f284255b48399c2f0c1b8b67cfeb2538bce49e9a04c50798baebc49118fb0e8c3df49ae9561f0f614e8de504db33126431a4f1c8a5e598e0a1d2fd372e11066b4534770b25257ce6501f21b9036ca8914834586a4b9789356ca7214f40523bc67b345729b5cb5edab15cb5fce50c045821c4feeace4485c4553a8d9d188e9de3a004a398652e137dee14f420ac53f39a87d4ba48ff999b9e3e471fbb5c490d982a341fa93c53cf1b0e0333163a9ab63eefe4e75a90cb67cb6b5d1d5ab9963290e504448b1394b5f5afbcc41f6d2e787c7454ddf9cf5",
                status: "499a3bf118364415965ad82908168b455047d219e4fc4cb9be"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}