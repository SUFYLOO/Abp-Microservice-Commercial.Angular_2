using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserTokens;

namespace Resume.UserTokens
{
    public class UserTokensDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserTokenRepository _userTokenRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserTokensDataSeedContributor(IUserTokenRepository userTokenRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userTokenRepository = userTokenRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userTokenRepository.InsertAsync(new UserToken
            (
                id: Guid.Parse("78aa9988-2f37-4ee2-bc15-37a9589d7f02"),
                userMainId: Guid.Parse("a9d2dd48-df93-45a4-b715-9b444bd4b5a4"),
                tokenOld: "cdd3a5e068394d03b64fe038293c39da835600a272e34bab9fda7f0202012590b2e4",
                tokenNew: "f440d73d89a242cc815f071afc3ce7dbe7f74f452a2844c2b73f253d5790e1a5167be871ae1",
                extendedInformation: "a5022072a9e444c89c477b157302ca7a46b23d912fc949709a786b7a7579c73fae75b018b6a44a54bb4a16d6d2d6397b9072892055dd48dab5024e823c06bcbcc1a012eeb72646868290af5c5c1bbcd767ca0c7e41af498a930b6f4bc8cd93ad7ecce3d162154215a2667235f6af49cae07aaf689ca548a89f05c787bb9896c36ff75bb22f194d2196beb4dc615e071197840cf22edf4469a86aa2f9597fc12b52fdc2fd6acb4edb9e16fd1fd40afd8999f324f774494fc5a1be5fbbf4ff360f1eb9b3548313497094cce0d81181021226ef1bf865c9425dafb7b9851a0b3584814898d228be4b66bac27642d26e546835b0b4b4ca5c438680b5",
                dateA: new DateTime(2019, 11, 2),
                dateD: new DateTime(2002, 4, 2),
                sort: 575990973,
                note: "e74d47e81ae64544950f3ac6fd2c77966231c562dc43425d876600b9fa6316de7a5d99d64e83408e9be9acee0f7ff17b341fd1c837f64b1fbd187efe4ed22226189455cabfa14f49a3d1184cfd6dd8ddd43a6a92e9c84324b29d6304f1af56c15a92ef9282b44dffbb96cc0101af7efc143a9b47db1b422e8c19c22d07eb7519901c18c2ac2e40b1862e0256630fb56e6bd7f74effd646eaabdc2b1b6ff1ed6daccddf433a004825a389ef8f5ec3c6d6906c8e8a1421463ba8ce811b3a3b1ce3fdb9626d3cdd479a82d001a3c8a5a79ca97deacd973a488a9ad317b8572280146066bf7b8ad94a1cb618693d80e01755a5794193f5774fb88f46",
                status: "bd79a4eecfe549e4a176eb55bf8fa9c06ce7047e1d974382a7"
            ));

            await _userTokenRepository.InsertAsync(new UserToken
            (
                id: Guid.Parse("c4021092-2dac-4e7d-bf85-9bfc9de8b36e"),
                userMainId: Guid.Parse("ef39735e-72d6-4c43-9194-6b9f4dd1b891"),
                tokenOld: "1ee5b39389944d7abe54091cd91f0e12d10f0",
                tokenNew: "241cac0c7cb04308b2e7f4bf03ab106a5a2b3a1d5a944",
                extendedInformation: "2205a09d26664a85a97049409ee5a09438a00a7d9d4340c2bea273164a9af7cbf51bcdf9a25a4513bc06c0959ddf33659258eee52e0b4d7db3b6652cc043fa57fa6eeb005d094f8eba2889bd7959c446b0fda558bc5c4e3eabba2158c89074d2e14122b362e646cb9e26e1e97dee21721e3a2272e4464b0281d7eb43c92b55c021ddf773a90c4c3bb21262279f061bdfa448f15e8f514ed1a0b4402dcffd3cf29f400a6d7f0342099941f73d1769db21b2d4843d5a084d838d2b782934e15c7960a25991d5714eef95a03641304823d4883539717198457486ed8540f396eaa97fc5c47907284c9eb1d1c578693e50065b2325a160fb48a691fc",
                dateA: new DateTime(2011, 5, 21),
                dateD: new DateTime(2003, 3, 11),
                sort: 1507992307,
                note: "6db28ec4f4f5497f904be8c3fc711a38ad318b16a8e943268f46bc05e77b00de6340f56621c04ee8a75b18ad8dbc7ac23b0b6a969a284825af8c492698501479fe167400568f46bbb550b6e7751e5415f4966e8b6a4b4894b3d5552141c44b8293063c6ecfab4048b362f943dcb1b9660d76959a461f4c2c9291b3928db027943e9d22f6c16d4b5d84e5e53e52dcd93d64b891f856614f08b5360a6efa6737ae1fa17bf91eea4a358735967620da41a04b9303e172dc431b8fc3e27ec2ffa0d03cff0d769c294eb3aa1ba85ad1d144f8808c392437794eb888c7681ccb15a9e7e2664aabb3f74ecd971d54efdecbe2db6d88cfcd423d4e259ae3",
                status: "4261a86f22d64037a4a1db2c0d318735b7e4f258c1914483bb"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}