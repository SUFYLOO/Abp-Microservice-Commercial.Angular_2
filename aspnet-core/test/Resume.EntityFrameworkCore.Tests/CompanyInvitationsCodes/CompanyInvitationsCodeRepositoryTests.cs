using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyInvitationsCodes;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodeRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyInvitationsCodeRepository _companyInvitationsCodeRepository;

        public CompanyInvitationsCodeRepositoryTests()
        {
            _companyInvitationsCodeRepository = GetRequiredService<ICompanyInvitationsCodeRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsCodeRepository.GetListAsync(
                    companyMainId: Guid.Parse("a098febe-ebfa-4041-970f-7d727dc53c84"),
                    companyJobId: Guid.Parse("1d720f11-9e0b-4a16-a0b2-294002dc971c"),
                    companyInvitationId: "898ffc28db8f43d5b897379557546fc98b05644318484d8b9c",
                    verifyId: "3d0ca58713f144279e7c5d0264e8055e736ef2d692334be1a48cd7407eed2a3f814de5d3f0d1407192e42724dfe27ca8f6420faba3bf4eef9f84d130ae87ca9469c35d96b5ed4567a7a16311bac49e3f85ef0f084cbf4931babddad2d63e417515a832af1e434ac9b91530cb177d26c82b12b0eed57b469bb0181d2b98d2945feb72367c89934d88834fad87aa3116c0d74f9cf14e93483d85e5a055b854ae6a22f3087a785249e0a7dc86ab5d5f73ef9e94924f2d2d4ec084f8d2a74e3012949c0e6c0769fe4617b5d78e576f4686a0197497f8b5624873a8a55eddfbe0f720cc6a9509777a4fcca5a1bce0443e764a2148c22b8e3144c7ae67",
                    verifyCode: "479829959df647d4af84af9cb940af313b6c0e4ab1af41bc85",
                    extendedInformation: "479d58e2d34e444cb771cbdf7f0136a1f559fd960f1043d0b24bf6b0aed95d701b1604eb86574b2d8daea84a5821335a49b399faf43441378978ec20e2144d22e7a21a95d6cb4df3b262333bb97556ed51482ab8a2504ae9a5b337b6a12d9201fbc51b4d36e84d30a96935ba64c1ec3372c0a72ab04342d4ac2031ef180204df12e11e97caff41448a0a29eed493ccaffc89add6d26b4c48886e24e1a35f04c3dd68afb8a2424b79b64b8518878163d39261d01f31dc411c8d4c76e50c5ec677ac44a2346baf4279b558cd304df76c4e28b20179be7c4d12b83c42914f085cc0899c9ca55822442e99015bb3937c4fe2e39152daf433497e870b",
                    note: "81b7863c3c3c451a9b6d550855431d2facc4a34e3f954ed2a34f9e626465a08354d6949d95a94cd881bcff9382a133b70ebd2f52111447be97da1d509f0dfb3cbe22dddbaa1d4379ab8e5d779e4e5ad18a5052a68a9f40d69664663c1f3f56b2e0a9ba014c0a4bbd99af77ae7b454bde3a15c59ca4e9426ba180acfbc3dfc07655e90806e1674f32bf6258ef43e31e67aadebc9d3e5645d98a91a4d7d61a85cee2204fd787304c40afdd2d392329e94392f73eace0674e988293fcacea91f6ac7e79d24a01ce4847b7b33e7feb1df1a6c8c85d623e5e4fb98b18e75706d11414eccacae690684f5cb10c0492e093bedb65030c8469134c1b84e9",
                    status: "eaabb08c8c8345baa395dfb7e5d15d9c5faf62e65f53401ab3"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a1969ca7-0070-4962-b3e5-6907e586f53c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyInvitationsCodeRepository.GetCountAsync(
                    companyMainId: Guid.Parse("7dc7f0ab-f71d-40e3-8076-4adbef5d8e48"),
                    companyJobId: Guid.Parse("3ff91d38-327d-4172-a820-1f4c1b715088"),
                    companyInvitationId: "d21330084b6b4f0cb1fdf97b696cdd90424b241eee9c4000a7",
                    verifyId: "ef078c7d2c304616a97407598075ecfb8b7a1040eec648fdb88129ce458928dbb9cfb2c2974d467893dad7f221aef23c3b4afdda382b4339af72e686360b79d6d5e41db31ebc42ea83243823e68c853e574bab49ab704acab46c0119c024e4ebcde5c706bb794ba6a6846304296e8ee89fadfb5c31f6415fa9dbfe200eab3f2378a49af774434fa689c8e6a67cbe218548d791e700a1435b98506183830224995e67082b9bf04719aa667667af72453474c5c1456e714dfca29fba1475e23525f19390c3811e43bdbfe94ad843557074de8f0a0a72804d608ca3fb2445835052451ec4c3032e498baf297a674c28e1dd3c6b245db8034acda634",
                    verifyCode: "d0949323b4384bddaff40bc9ad6bf511183ef9b029f14b8984",
                    extendedInformation: "aeea2788005e4158b91e4219284396335fccbb157fc44755aad1ac4fd7762f8a4af61dabb37b43348a1275347569be44ec34c170398242b8b5a77b2ec87d4d4af0d9cc9467e44ac097944e50228ddb0dd374fe727cbb48b4b58756fdbf5026d329840df9a27240249825ebf83ea4ff1b874d9a4fccc740e39fa0adc8234c521e998dfbe35a9346598d6310e21dacc29228cfd5bb3fd14b8ab33181e085c1f83fadb66e81bdaa48a097629db8ef0804e12fad036712124f8abb61c16d05df30a17b1ae917207e4be795d8f9695786324342a8453e363e48fe8e22dc4eba0879b3b2d8ccd815e44756a3b872443c861758400a341087dd476dbf83",
                    note: "cfeaa73ddc49465fab4e52effcc657743792b34bd8f24176960127bef5bf842f699a2b89662b473db56a3d37e669fee1e00c67d767cb4102b0a4aeca40023e05a1836cb51b234838b81a719dae2a25caff704e78138048f7a4c169c1700438e5ade2252ec3cc41afb6ddf493c62bc41821d00dddfd0842b490e1948d26d459e5a97112a582af4eaf920d0f826051fae92107efb19cda4ba9a08e5ac68405b53b938c1aa87e5341389f4b9215b95d6a9950e0e70adb9b4f44b618927192ba82f6cc23a11515df482f9e42d2bbc1064e53c65e332e42ad4c34bb35654e3f9a8051b0773ea488a5465bbd3edac564eddbf9d5571846a51c4177a0ed",
                    status: "3797ec10cddf4e12aae14bba72505dcd2626fbcba2234c0399"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}