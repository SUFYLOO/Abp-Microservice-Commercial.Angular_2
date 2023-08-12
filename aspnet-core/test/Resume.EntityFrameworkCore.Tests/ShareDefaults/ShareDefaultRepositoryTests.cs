using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareDefaults;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareDefaults
{
    public class ShareDefaultRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareDefaultRepository _shareDefaultRepository;

        public ShareDefaultRepositoryTests()
        {
            _shareDefaultRepository = GetRequiredService<IShareDefaultRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareDefaultRepository.GetListAsync(
                    groupCode: "1757d43c9a2a4baeb8966bd715ead3f9fdf083f577a1428484",
                    key1: "37e505e809204e03889a4213125888a8fa1e153e9e43471f85",
                    key2: "efd17e684b88414da9eaaf2c0785bbf88ca3864a737145b599",
                    key3: "9c82c5b83b764db281e22c9c9da1020f0dc4d4f56e634fda9e",
                    name: "7c6211b4480648988803855e2327ee90cffc83a1094f4f59bef8154093d990d2c475baf1e86542d0b290185aa2ed10eb61a8fec6538e4c688cb3547a02a711babcd46cbd0ae541a0aaf552127aad4ce2ef3418c2c0704c6585c1850e2a21d40dea99fb25",
                    fieldKey: "7d5980867500490d82fc2863c9a76be3f3d6aed929d7461ea4",
                    fieldValue: "3571c9e06e2f40fc9650ea1b0846d956b3629b1804894d3aa9ad1bd4ff15d313f092198056574e838ff897d83834421b5b18182db18947f58f2725ee34ebf1cd105c4559039e4159983589c208898a04fb7704e6694048c4aa3099e772ab062d4dd7dfc34ec148bf97b98dca9ea55cce9ae08ef9792f477c8117d6877baede4158f70a6413e341a1b4ad8e89796af0eff0831692e1484f9db8b0503047fabf516508a0577cd84af8944bf388d1a44de9d8e92a4c6c2b47e0b0d4d0a2580c6491e9f5dc37ee8440278bec238636a6f8d79bd093dd40bd4f928c56673e147e176561b381d7d83e47d4a0260e4a68ec998956735eb002014c69a964",
                    columnTypeCode: "7f6b1761b143462bb7b48c4b375c38bfb7653b42ddf14b5d92",
                    formTypeCode: "be13a7b8249a4b50b19d8b33ba13d4a6849e669d54c54ab294",
                    systemUse: true,
                    extendedInformation: "b5bdf7f2d2c24986be4171e5e2561729e9ecd6e88cf64f6aa45104000bdd553dc1e9f76de566422db7dbbb48acae921190d4e8bec24947f083dcb3ab68308b3bd1c51bb4dc0d406dbb7b60818678d57859583cc77ea447d9add6dee0da76762cd87795452c824ed2b30a6d9bfd2cb2ebd6e4c186e0724db492fa8c0150abc589233f3520c4f9467fb124aa25671493a21de8ed5dc62942d8956b43bb7d78a9df1375afa7867b4562840b74df7286cb687e45daafe8544fe5b1b444c50933890b59f77f2056f448bc992f7419542855eb749e2b5a5533435086e3855c5a240ca9a28711f953f74d9e9e6c05f28dd2859a6b6eb6afac5540efa426",
                    note: "518b3f03e662489fa907c7adb2338f909054f925c3004ec1b6a648479105fefa931dd263c5524e4385222ab01c55459ca306f6cd4fc24674b37001289b90f595249e3c00ed574ae0bcacb74d88a4c9bb9379bba724bd4f5bab845b0089d69d190c065764a35b46f6835a7535b7440b76255aa581d3ae4f4fa2e7d25eb11ea8471abd35ac8e4a4406b18b762dca4fdd46da96802938c14594ab5a3607f0b4bd45ec67de08d70c499080800ff93c6024a1173507845cda4763982d9af51ceb06f901f91317e8524b8a89d59a610bb022c36c9552d545b5454cac9c0fc56acfe7e1b8028661a30c475481287d75e69f23bbf8ac3272d089414ca421",
                    status: "e33be78d07284a0483b436a3be18b18647d72b7bc1c54c59a3"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareDefaultRepository.GetCountAsync(
                    groupCode: "942e8a1105aa40d59e1bdd63e543ae5e84d19176c3594ab788",
                    key1: "24db7d048de74192a77931524d9212905da9c81bb63a4b2fb0",
                    key2: "98c1a6217a4c4f3894851ad0bc5243c1c0dc80abd62443fc9d",
                    key3: "e45ddb5e51ea4ee0b6f0b4e8a5054c558bccae97cde4480c96",
                    name: "a666b3765f074e1ab91238594b5992d67e92bf1709a74ce19f656b0ef31a8d233465703dfe904d49b6c256532a7d4f64192cdfac4ca1467cb6c9d8c955c65b4333a1617f2dbe474896326b33953328444db1f1e5a25046b2a5ac4f07aaf13b7033bb749f",
                    fieldKey: "b518a092389e4d1aab636426f511dc0e38cfe017f5824ea8b5",
                    fieldValue: "dd66bb30d9544402891074c7ea872fed4d5047c0303f4193a35e777acc4719bf2a3d3cc7175646fa950a48579142253d2cc9961fd4dc4b23ae7a23ac78b5dd1039655c0a0cc6421e8d0702dca83205fa4a3d812fe9af44e399abd4ba6ac9a4c94f4ded2585cb41ec969ad116e5a432b3e2ec30f5ccae4f7abe986ee7b99fec2c08bb3566c9a1489486cbe824ba4104ad342b0f93344c4be4a42d00cf8e1eb19b0e0e1791ef024ac087869fa24cba2194696f22495a2e4afd8cd9249278e76ad4c5cc0cee6f5c48a7a0d746d64ea022283ae53f2b29434bb4a54204665e138e8042e98642daa54664b0a3480c54096017238b9583f1874c0c85a4",
                    columnTypeCode: "8dcff3f5b032472f9b42829801702ffdb1ac78ae45134d1eaf",
                    formTypeCode: "37b9a27f1cec4d22b9cdb5b7774caff8d818b10048eb4e1594",
                    systemUse: true,
                    extendedInformation: "6d054761866940f385eadd2f77f7372f7d8be23d96d7469db639979f7e01fba0e0a93be22c59421c90f68a8f1411958fd709465630054f729e40b30bfd1d63e18a3dfbe2dcb1481aafe624b0e4ddcedec36b7a68a77b492aa9e0fe7692e90461cb151836d0184116b88ae36cfb17af71ea2f4f500b614416b1ee05bbb60933c961a2c3c5f383499b92d1459312ec2c5159edfd32a4bf43abb6df325b55a19eca4d1f47f39488467da6333025a01f602f3e3146fbebe4418eb8814ac5343aaa355013544939f14824b16355bee02c995e4de74a9bda244ac9b5f6b59438c0c49c743e387b99e844a7a291d5a2dd9caaeb39a02122a40745059355",
                    note: "6f8221b5bc794cf6ab8848f2ad0d284c4384960dd2fa463c8680e846fd9348f4189b4c510f0049d5b2070261562f77119aee51d72a064af4b187a3a4c64bf17930c6cc987c514a098abb93f4ef701ff703b2b5ecbb784582a12fed12516ba7eece55b5b1838444488d5fd2262e73f1fcd3549aa32995464ebbb451b0f8878e2eeba81a43affb4e21a1a066bf050ff22be0fb52372a224925bcc11b031ab7e96eef9196da41094153a0719787f2c162cd21dc427776a24cb6864baa95fc4942baf7917242b71d4fb48fe3476ed19f19fc0961bba69a69409e8f3f3d70c8ef9c512ea8480a9feb48fd9954724df5b0666c1eadd9c697fd42e3988e",
                    status: "f6f9ec071ef74f4683be6971a0a045c74ed3bf9e72264e95ad"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}