using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyJobPairs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyJobPairRepository _userCompanyJobPairRepository;

        public UserCompanyJobPairRepositoryTests()
        {
            _userCompanyJobPairRepository = GetRequiredService<IUserCompanyJobPairRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobPairRepository.GetListAsync(
                    userMainId: Guid.Parse("ca96f853-2aa2-46f3-beb8-4e6a772294d3"),
                    name: "c512d9bd571949c391fb3005b85f5c524989e3413f794f448f",
                    pairCondition: "c347788d79fb44fabd7c7e359b350427797bc5926a56472585de5599ed9978f634384cb6bff64a369f90e65a5ec952ea85c6ff76047c48479051edd49e354724a6625066b6104b709c33e6ee66f054deb6728aa6de214d2d8c7ba48b1d4436cda956f524449e4ce6a7f6dde0763cb2458cdbfdc6761a41cc831068e59efcc3b2c541b654093147ed9680359b43900d1dd0bcbfdcdded422cbaf84249f30cbdba74b75e673cd94dd7b97d50e0015785037b717f04b99f49489b6e71e3ee2a5cc36772229976354b228723d8f6d3d41bd2f5ac31d6d1c141e3b622ed729b76ec212b2deb042c57412e9275c5cf6533b557f176f75a891347208a04",
                    extendedInformation: "bc530516e846410b8228e80aff8818555e6af60ab2444b87bcafa513fbb11c9f0e3b40a7e8d445879296ccb7a420312f1cba499c387242059f86c009048af238b74dd2497559431287811584de985650edd9b00c2a0d41f1903586e575900a8ff9ea6ec9343d4fc1ae8fe53c371e7bf08663b090b2e342758e58eb800279a6bab087d61305e341e88ac98e1f09f2fae06e0751acb9ac4455bb7af56b499bc7f3b7e6b78973d2417cb56f4dca5290cd35b5d31bbedba44f7981709f930e4754459c9554f14f394f96b09a78a93db5dc27c524cdcfad96493594b748af2494d92cf73679fa4cc74f4e9fefbd1f4886e9f6bd9097c19da542008198",
                    note: "d5218e2f6b144e1b90c1343003db216b09fe64db57374c3dbfa7424339dcc0850e47e08179364ed6a8c46189e2f3041bea940dd74cc34d7f82faf96d85b05cda0471c2f75c5848988734a32b6975570a63dbf1cab3ca4d51a464fd6d0a04390b82b8c25a627d42efa21020705660e678eab110a9060444918eda5c5233e917de95c38f114a0f44f99a0403082aa937bebfa5325e44ee4e708091f0c6fb38323a4f2e4750e2094ef2911d5956132d1b45712f1bf131294355bb308dde94859dbd7156ccb9f136481fbff9447dade217d248a180262e244e2ca9f32d12d9d4592943486c5267634766b441468672401944fef1582effe24a54b081",
                    status: "0d5cd3bbe90e4977bbf397651ef6675aa4632f9f002d4273b2"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("eff82405-46f6-4ec3-abdc-1e3ed7aee9cd"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobPairRepository.GetCountAsync(
                    userMainId: Guid.Parse("96538242-49a5-4cec-9ade-ba9046401525"),
                    name: "953264343e224015836d4a8c1417ffea27e97a3ffde44fc589",
                    pairCondition: "594d839163e341efa2699a325cb4b5c02904560e36004cce907fc47f2990f779ee31e453261341e7bbe72902b923f34763e40cff19af47bab0cf6de4e184477bddaa03c010564efa80e7e25de051a102dfaf3d4ec62f46f0b46a55b5692f2bbcaa0c4d8dd9554f78ad576ad8a92ce029df102c4c8c614e68acda5fab4da39727627a02e9912949d2a2b71ebbc723061a34f6c3fe50304f8cb93936ce077605aa11c7393dedc347b694a3867dc619a52f1efcd0263ab440a085630ec0a147482bd8759bdea6414c89ae561a934b291610de843820d9f342c9858bd499b06e455662763a957c6744c9966befbf9dec120363d9ddc3d0bc404dbb88",
                    extendedInformation: "2d1c7de3b8ea48efac5ef8867bec779f3acc7e1a33c348a695fcc8deb7ed3a31b8ee6813ea83479eb9b51fc0de6481ccc3f3c677955846abb90ad46753503b04f8598df41b3043bab21107a90f59010a5fb31f6d15e54ad6823b89edd1d067d569e8e7af30fd4d1087170df0652ec0e5c34c70ed0e424df2b263b8d528464900fc9939b8a0a547389889c8f45d8cecfda4d791794ae74bbca06fdcd2054753055d93d429a18240b69c37581e44f347735a0ca82110b34c208e8c543d5ded24514f8b91c94fa341e18078c606617199ba364c33594bb8424ca647bbd761e40afd939c83b62abe4afbaed01493b66a8a60c400bbfc74b94398a575",
                    note: "cdd28e7ef39d4071b539881aa13a6a65b2f7c20b8597400bb4a44b334d86e3ba0278c9c34b5b416f981d8a0dc48dd24395d24860ea2e454cae9a3808575df7a65b2351738ac24137aab3d39200da999543000329e1714a588577d1e84199cec0d846f561c5494f57a3aef5c9bc0e967a95ae9ff0599c44e397c8753638ca5b89e114e7c2b0474a4287a3a94d8f04d7568263ea54835d4388a62e8cc0899d605b4afa1e795717461fabfec717de7703b46648318024374488bc8cd7c7a7f02194ffaee505ba224caabaf7d2eaae6fdb29d9ed401af2944e378d7efccfbe2aba25adaf7d07d7d14ee7b68201bdfc2014fdad393cf99433483d9bd0",
                    status: "e1802c9f5406424d9afb6994d09982f685c6dd002a0c41a7bf"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}