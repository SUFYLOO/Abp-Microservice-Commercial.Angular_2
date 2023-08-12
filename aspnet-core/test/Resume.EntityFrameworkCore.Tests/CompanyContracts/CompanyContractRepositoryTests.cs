using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyContracts;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyContracts
{
    public class CompanyContractRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyContractRepository _companyContractRepository;

        public CompanyContractRepositoryTests()
        {
            _companyContractRepository = GetRequiredService<ICompanyContractRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyContractRepository.GetListAsync(
                    companyMainId: Guid.Parse("0c991428-12a5-434c-b775-5edb2bd10b7f"),
                    planCode: "c2dee266c345452d9744989f14149170e2f2ed5ccadd499bb9",
                    extendedInformation: "9751940b8fd045e89630361b73b4b8b99b680126af6f463db716f9e47935ea8d32bd5f884bb947969ff4ac000db86fc73b3d40e1b71849738aefabd676ef9944761cb2a12445496da4e9e5bd9883565a8388fdc2caf8401f90e719f69f7d83a9ef06354c98d84ee4bc7aae6c987dbc2d2ee166b4ae4146109cdf5118193ebc542b2789fdcff94d72ab74f439fd8a5bd9211003d1321e4971a02fe59029fa587a38653362ce394aeba179b8827e0d60584878fcd08a93406e98da1d5298c701ce1767e80fbcd64b37ac8dd164f0dfac9e8d7e146cb5bd4465aacdbc0a32531177e9cccc1cf10e4ce88a366122c74e193e57b482e7f7134c21aa52",
                    note: "67018cdf3d0448a5a7f8f468266a17aa44e9bd051f3c4e968840121dc20004102430f08de24746c3bf7e9b44901c02c898147257d86d43b4af2b33a882cc9c2b242f1ef4ab934e4692c829f6dcc0e61ff649ecb2e52e4480860d9be8c8a865b84b0f8439528441acb5e96d58625525b0c41a71b00beb44c293d2175ab0a9a687598c2cb426d84d9988049a06248903ab04456e8de0974fb887fb5c81f7f0e3460fbee1d774d9424e99b4b280f5db889bab50a917dd8c4112930f7dbc4a3aa27b4497e461cd0d47dd8c18fd7456e3b1ec15397a2073574b7fa4bc0aaede375ec1c0dea689cb304333a509ea6212dabb57c1a38a74750e4d199fde",
                    status: "5a5f8ebb291645bb87049945f0f0eb18604f7a4125764e2483"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("9b5b8292-bba1-4714-b666-9284dc9c5d04"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyContractRepository.GetCountAsync(
                    companyMainId: Guid.Parse("3b364d1f-12ad-4a15-adfd-7b5136ce7b83"),
                    planCode: "21966dd80a664f00aa40d97b5d7d5d5b4d59d0eacc63484681",
                    extendedInformation: "ce64a57dfa83415db9777b7cea53c6ee827f03fed471427bb2e493e692e51b88f02a667a508742ba9f05b1ce17e42c0c38259f8310884695b914a559f44ac6ab3a3a522f9f5a474aa1b13d27137b4c419e7eceead71b44daa7d53c48be03afe8153d63703840443d8d577765199ca3be25c3645a25b44229a2cb040a24cee85877582ceb936846d88954630f7837cbcc261be08e23bc41bb8ab2f41d07f25e59c9af05f7661f455fa90b9d1bd171ce2aa8c5f1ca67c940078f85407bf257c3d8b84e490b5fb44625b812ea727092eaf01dd22d34840a4174b2200d36ca097e9279e676e64298476fa9f77432ea130e0cc2e29a72aa68437fae6b",
                    note: "8768ecd45c1045198aec33c9c4aff7add6123239124047c6abd913fd638454d97f66ee1311084042b6f828498d3d748c233ac547d2314f08b6d54dc913a25cfef64c57ad11e54b3395a91271c9ae5fc21b8d64b67f7c4391acbf3a735c7e41f0e170c15e876b4ba59d4a5a53cd5d1248ef4d2e0da2754df48276c6da26152ec4d970545d6ccf4e1486232adc478ccca33ed4ac3ad04b464aa51e50edf83051dacea620f2e45a42ec8bffa1c90075561a23a7207ebbd044a8a54ec55e143e825ff8d3cb15d6a84c1da9f1c4f3ab13cc56129d32c4b1f5497ca83ab875f3ed1fbb1ad39d251d1d44c292c0c4613727a336effca625d3cf4be0a41f",
                    status: "abfff1c5d9314e6e950ce585c041705dc3f04b19b6b1445582"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}