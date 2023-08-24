using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareExtendeds;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareExtendeds
{
    public class ShareExtendedRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareExtendedRepository _shareExtendedRepository;

        public ShareExtendedRepositoryTests()
        {
            _shareExtendedRepository = GetRequiredService<IShareExtendedRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareExtendedRepository.GetListAsync(
                    key1: "bba31fffb3c64cb7802a131a6ada84f0f9b005a3d4314d4ca9",
                    key2: "ae55b341212b4a188cfe5989a9b01aff794044be2154401f87",
                    key3: "abd1e8a852da4d0f98ad31c26ef2be37abf7c27c2f754374b2",
                    key4: "49d30ae9477b4ccdbe7f778d6d92a2dfbba99b63d3874e4cbd",
                    key5: "3c02ec46efb649499c3deb1b76e40b0342aa8f29e2e840f898",
                    keyId: Guid.Parse("3b96d54f-49cd-4a89-a24b-594c2b43ef85"),
                    fieldValue: "51ab52888c1a44bb8ce1d801c416a16133f05b70c0814ab7acbeb1a300e2807ec9f0bb4333d944b3909310700dac9f9297ebd45c2dff47cb87262d0872b3806223f35c1655a0434cb8224ea33603ae34a57108b5ffd745a6858f38413e783987cc2a5cf7",
                    extendedInformation: "8362775a15ce4b1784a778318719fd2159a7e71756a6436891f05d5e58fdffcf6574ca3ae9a04379aae089f3c432e3ee9956955144174880bb0ab0ec9cb5966814bc2d0162b94af4bdf00ca92c2e786c66bf6cde93fb4a8fa87c8cbd57b26161a10741f8357840f7868ae65bcc25bf792fb2b14d43764222a0bc4d64f824b5766bc8700ceb7a444684b690acd497074e4d02379792314eb6ab1ddd0665929f74bcc70bf9a1ce4403bae512f37f9f793ed8bb50565a984127ad46dff38e35da6fcd7a572bce6846619e523f66b7123e917fe47e1f6c4a4977a2e6a544e29babc2787376529af7441d8563638f4b95e8b7c18fa4b3ea90421ba5cc",
                    note: "b3a08557b7ef4b468bbd7148256cfc915bc5092d98f747eab8b76578d99bdc2757c4b551c8eb41a7bb86994e912af9926d032b404ba74eb696122c892924f1f249ea6e50fe71414cbd48c20e214bb37097820ed145754bc08c3d537bd9a734c0c29dfb83aad14d46bb489b7917d5451e1db24402db1c48188ddf3ff99c47726c7011c06d5c2041918ac5dee2d11fa1bfd84210708a924311aa73adaa94322dded24ecdfa94bc4e8b82393cfb415ad097031c44387cfe450a932a7243a7cec0a5b1d0086777ab499eb0cd332b24bc194922c9210880f9494f99138a3f76d563347c4abed0d49e4e30bae0a6e44cf09d82d834642b515a47a0aa52",
                    status: "15d615b467834c85a00afefede6884b0be67e371a6e94668af"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("3b22c00d-eb3e-40d0-8964-ee7d4ff1e0d4"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareExtendedRepository.GetCountAsync(
                    key1: "8c15f3072cc449908f29fa067c691f3d10059c6815174a3b93",
                    key2: "55ba28927a2d44b38896905c0f7aa16c7e54647456244b7889",
                    key3: "287e3a5ff0134e44b81e5d5b298f75265b48169e7c494a4ca2",
                    key4: "6d9950e916064e58ac5d828d0dc8041c0de679df51494e3390",
                    key5: "19d6fd37c1a94e5ebe3a19075e94dcf06ca40242e29348e3af",
                    keyId: Guid.Parse("db7e82f8-11e6-4484-8215-d22151d3c76f"),
                    fieldValue: "c8c660d348f242799fb6e627f8bddc416f1f53127a60402bbb440a0c8cdb9ba62d16f3dc5bef44778c381b2de533a391410b9c965d604a039701a0a8e284d7b8af73299e3e834e669a6e43cabbe6e4580e84b96642134b73aa16dd4d227ab6fbc6b73f06",
                    extendedInformation: "53bf402e6ec347f2862131e664259620f7a2f100c3494a8fb1fecedf0b8ca87a27dd48ba286f4a3897cfa905850f0769023bcdc849164aa1bdd69ce910eae514156b955aaf1146339b263f3b3fdee4694d2fadcca2b44e86a1165fd210da42353ba6ec1bfce94c24be5859e42da488f935ec26391d8c4214adbfadfb1c168ea2fc5d06fa0eaf42c39e9efaf41319c55bcb2dd8539600498382a83bb72b3abb26f94af6d3db7147c5a69dd1cd3374fb60c55113bd86214a8d99b08aa7d79863850d77c344a3f947889364ee92a019378f4eb117b00dd34726b94dcafcc2cf0430b2381dccf70a47fc8d16493fd5d294142701554615a348aeade2",
                    note: "321ce36cfd8a4632bf18a43bbc48d09ccabf86c0a08e43b68a09da6a8a44e55b50bb07232c5d4dbdbc5f9ae026553acff75c0c64dca04674a12aa8d144ab3dfe7752890b9a2d4b8fa573e25307612a9fc0889ad2cbbc42bbb4c1eb00bf60e21efb19bed9ca38405696be9d03eaf893962d37d7fcc46744d3b6d9519a656d4bab7fe417d6b0d5472aae7a86405f451e9888633b93f2c8478ba1cab369b32524592426b730d61d412a8b24064cac343288e22da72a83004a9f8d292e607f405c660b45677a7f2045c68857db8a6d790b2ad2030023e0ee440190136156374a6c3bd02070c875da4b90a436995d9dd7441c97e415946d97425eb21f",
                    status: "6fc30ee157d3433cb0fa57bd4c3aef90bc9145b2d9e04db381"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}