using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobs
{
    public class CompanyJobRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobRepository _companyJobRepository;

        public CompanyJobRepositoryTests()
        {
            _companyJobRepository = GetRequiredService<ICompanyJobRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobRepository.GetListAsync(
                    companyMainId: Guid.Parse("4aa39140-87f6-44ac-bea6-3ba7de6045ec"),
                    name: "b51eb15a9e7841a48b60dcd0502032f4a18952d3f5c24858a3",
                    jobTypeCode: "7c201d50e0744c1c938dfe3394950b2c544d7f3d42244964bb",
                    jobOpen: true,
                    mailTplId: "2049626e9f1c41418d3d48c4a70077ca258d6b2d2b2e4595a0",
                    sMSTplId: "04b67ce647e64829bf894cf406f97a18b846d89fe8dd4cb8a1",
                    extendedInformation: "b17e2ab40c29473a9b5fae8f92bbe538e053c6ee1c554bdc92e7865d479d306c844eee189bf34c1dad4527098fa65f19a1d65e3c5a43477ca95caf78015751df9ab2498779c74d7bb1bf161bed4218a1a29eff37a3e84df0bb80c6b1d306a955bdd2daa4b941425c9fb1f7062d106f46a5f3fb6c05b146af8eec6bced772e13d276a0896b8b14dd79676b73259818604224385506f934e4fa9f4bb84b44477e41b2b112ba7a74b0285d8f74145771b32608dc2b4cba44128bbf76b66825f65592ef4cb1f37fc453cbb4f885416f8e968fa0b4894928e43d68168ba796929e4105c7b6906220640f5a2f7ea59b5e7f509cfcf748710ed4fbdbd5e",
                    note: "4e485e1d97f44f349495ce349a8c631a0838514a38564226b68b28d64c0c27cab0f05925256e4bcb96f8f8d3a76f50f1798e78ca529a4eb7a56e4c5bf6e03acdb7f6a1c77fc74918bbd5bfa04460ed725aec95fd85514bb2b6342d4d6c1d25d9183c8fec989f4349aa605e5e063e41fc8e2309e6a49648c193624a407b1a6292e189cd9b5767435aa26bcd65065a2172c04b6a323288412dba9d68cf4f8967dec54ffaaac932463bb56891115390dadecfe0d4e847ca4ec88151da7ea91389574890d98e6423472798a6c2775522febdc2fa770d8ca94afd9de25b87352e937951b1ba734fbe4a3e8ae10b0c577d7d023df8fe2d76514fd583b4",
                    status: "cce6208769c2463d82732182e6a4477e94271be6548d414fbb"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobRepository.GetCountAsync(
                    companyMainId: Guid.Parse("9eff93d8-11ce-451f-b3ac-859aee798fed"),
                    name: "40565fad34674a928f5a3f3dc17e3aeccd40a561aed84a6dbd",
                    jobTypeCode: "1f4a3c9df2394b4a81814548430c81391996cfa21ba743b095",
                    jobOpen: true,
                    mailTplId: "276e7330a35248e5975db1820a47600084b28c9c5862468984",
                    sMSTplId: "58a8c272a59545388f48d196709ff689b7d0652fa374401e80",
                    extendedInformation: "9a5c577be434450fb68bd70af2a0025f6e43f74354104b6296e9fc0ca4f0832c2bf371d0700449b7b8b4727f24a7477a7c2ce1797eea4636b827281ab468fc7a04937ccf5e1e48239557c332223936aa01845988c5094092928c1a660c84a7286451c9b23a634451928872600ce566d1aab4099e92a04b1db7ad09ba0f322820b9fc4d053559432ba857534ed7368158abb408779e6b4adc812871705119adf52aac3e180d7c48848eed9f6a9dff0e7abd36dc8130bc42958d29047030a9ead505202e55cadd4b22ae55741a4fa540cdd5463b740d324cd49245f4e913958a66cc7f1faf7f13479bbcde74809c282aef8295b82e5d064f569ec4",
                    note: "1a9c451751334508898becae6cccfec46622bd3032784aa6955ea99c4c4d43889428d60daa8b4d0c95957059f2fb04067a4d0330696346adb258474d6c36895b48297252a5244ea285a21e38b00dc260fb8993b3b97b427bbfd7703fc8f616b1e0a91298b00c4ce7ba72b696a91153bc80607065c1894f53bf7a4f919c71d9e759c5414082f148a291bea3d17e91fe09de77dad8a63742a6b62f07ac543f24d3ba88e8cbaa594c8ead5d10b201e27f30d6dc01a8790b4e99b50952d78bd2fb070982b5c6316b4ca385366d59f783a20c27e9464f5cec400f80bb9cb2d8de8f5a26c7f09575b546349507849e5d551aeb909ac1e6adc54e7d927f",
                    status: "af4e7a5df90c402286c1608794e905d763402f2cc1d0495cab"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}