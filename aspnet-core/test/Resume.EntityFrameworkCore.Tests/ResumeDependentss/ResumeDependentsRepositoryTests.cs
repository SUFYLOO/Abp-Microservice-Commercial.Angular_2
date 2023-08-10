using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeDependentss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeDependentss
{
    public class ResumeDependentsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeDependentsRepository _resumeDependentsRepository;

        public ResumeDependentsRepositoryTests()
        {
            _resumeDependentsRepository = GetRequiredService<IResumeDependentsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeDependentsRepository.GetListAsync(
                    resumeMainId: Guid.Parse("0cf06f78-53e2-4c2c-aba2-75f89f5b63ef"),
                    name: "53d6387cb56042659a5fbdea7194cc9505d9dced37d645f8b3",
                    identityNo: "6bcae800e74f4dd99e719a0676944c64127b16513e894d5a96",
                    kinshipCode: "4ed2a83335c24859ae91b3ddbcbac3e00f7fa211a6784ceb9c",
                    address: "4c4b7f924cf34dc2b47260da7656b56950a9537ef4ff439fa64d25e142478b52afd6426d42b940d29506f4e364b861687628235da48b406c8b953f7de5a124bf0801326e2f8242b8bdf7ce53f9da80c8f8b887ab6d734472809be6311e740318fb1e5017",
                    mobilePhone: "a1655faaeedf45f89ede9973959622b647a5cebaf6734e7992",
                    extendedInformation: "c1e7fca77a0042738305a329f810a92343bb5fcdec554d45938da75d7597363247f3d01423654a3ea081da3b45f39df7d7b359d771a34cfeaabd5adf786f8f4cff3d0cb7004b413d807d2d2cf8613520840e2893d82b4faca18a912fa0d6b98df0339ce8b4f649be9b1cfc962757cc0e4ed784fec402441a8f49c2d01ebbb755a9089f747b4148a1bca6a8030e92d72a03c257b4566840f0a239604583cf73defbc6b5b8164848769e9581de6e612c9b3457416b959d4522b02f0879349d786fb2b4d46b7e8745b391730d7fa13b706a66cca3b41ccd4a3082cd562e82f71a2ec4b943b46f8a4e319959139e221bc0b7986223333c9e48948824",
                    note: "8d90fea0ac574d01aa15e9dc5170ff6509fbed6cf70d49bdab42fc57714e5620cc3210147dce409eb3c7266983a486365866efe41a4643d78149aa70e70b6a08de20b55ada50458c92690587cf98db24af125286fd3a46c7b8bb15d888eb5bc15f8884c984244ef4bf5aa3ec329f34d497d394b1c4e344adb3bc402ab10048ed2e3f66d2524e4ba59c0ba7262daf1c228101d581a18549fab18225a6acd5b2e118b1fc765c034df08a9da50b1373e69eb3f9b573985a4a6d8a4205eb534e1e55645cdae332a94c7b8b1152c54b13cf4ccdf7181a1ba34a1f8e9dcfb97f3bd2c1370bd979d50a427ca1937bedcd43c455e81bc4b6f5454271be15",
                    status: "5d8cd9bd556e4c24bebb26146ffc56a54db4e9376a84488a88"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("c68600f7-5537-438a-af64-8db308fcaf3e"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeDependentsRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("b9a8af79-280c-43c6-8000-b51183f645f3"),
                    name: "977f506ef81a41b7a36c5be2e180426dc221887b43cf4e86b9",
                    identityNo: "1baf922d83eb461287da2bafdb6334768c373c1f5c3d4f3cb9",
                    kinshipCode: "45b9464c357f4abdb72405df6c385fb7b3e4dd86410948d68c",
                    address: "455bc4a20767428b9029d7548758e201ecf7e90906124d779d137c460760f4fefd84b693b7354261aaf6f7ec19ca722fb50e748701fd4d93aedb82beb1e218ae25b63c7b15ea46cca67abd17edcc1a793e3c368a1e4f489591cb16392f06d158a2a5bd8c",
                    mobilePhone: "50d8040c9143455cb367a5a320a624a76089a04e3d1b43dda2",
                    extendedInformation: "eae0e5f22cc94449a9c2da860ef89b9ba1319a8a87b0400fa5df35690ed312cf0824acf4e8194d44bd10a9b3e5bf832f38ca996ccd674899a1e7109deca5f541c47687847b7e448ca9ad38ccc15622b96a9e6a01a27c428c881544a387dcd85fcb5f28afac3442d6a38423b167ac9ed3465928fa6fa9438d8a9c47d613957435034ab150201e40e59fa753ab163f7afa085e36e29bcd403bb8ad243ca843ee1a9652dbc0bccf4cdd9ba725c3bec337d1953b065fb4564fc5a98244382f09d0cbe6e2349d29ea40ca81221e1dd32be595e886214f8a494613af9f98c875c7b21be21b6360cf504b0baa5adc969d786934f242e6c1e7d541dbb0ad",
                    note: "a05ac6bdfddb410299b8db906869869eea66ddf3ca654109b90d22bb4643089eb06fdb55f843450a840e6c3523006293ffc81fedd80c473cbfed7e0093eda72de3a02761dfb541159de297478ff891b9f855518bfd16427eadebb54f87c548a6e218f9dc0f104414b92b56cec2723815b81ccfd6cea8436d9e6dcf04cce0c1fc766feda44a8449359d7610cd30d76fe89e9f12954fbc4cc8a8dea6abdafb2cea8b3a3a78fe07472882bb7c6cce393ee6a12784c07f2d43c887a0e7c36f6cc70eab632246bef44020a01cc209c40c26a593d17dbf1a0d45b0a303b603f26117872f3bf13f31174c7f94c8b57f45ab9f5847769e6f2db24d6591ed",
                    status: "4dac461ca1be45c6bce445f7cfd064039ff7186d3f0a4af1aa"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}