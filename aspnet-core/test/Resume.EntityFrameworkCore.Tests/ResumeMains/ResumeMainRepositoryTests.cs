using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeMains;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeMains
{
    public class ResumeMainRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeMainRepository _resumeMainRepository;

        public ResumeMainRepositoryTests()
        {
            _resumeMainRepository = GetRequiredService<IResumeMainRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeMainRepository.GetListAsync(
                    userMainId: Guid.Parse("760a202f-4ed1-4a6c-898d-f0cedffa7f55"),
                    resumeName: "b1d7ea4a1f2c4b92b5f8390299b54dd5618e5212c0254fce9a",
                    marriageCode: "309082e2244a422784685bbd9b5a83ead929ccfd7ef54a8f84",
                    militaryCode: "fe3acfda2c1b43af8d4c4578f17b5098a5da252bc78147a28a",
                    disabilityCategoryCode: "9178d96f4e3b44168b3092b7cbdcb70eb4dced5ab2d04a23a8",
                    specialIdentityCode: "10d877008cce44a899e5e6c0e3f662bdf4b56d83e8ac4064a9",
                    main: true,
                    autobiography1: "11dad2abf56d4",
                    autobiography2: "e163bd4549854071b4005f0e504",
                    extendedInformation: "61a2ea12c70f45618ab26ad094bcf66498c2214f25ee4298b8a7a3bf08fd04f626d7dd67216f44caa22f34363a5b2332196659b9dc404c5b8ad60b1e641e0902e8625f0f9e5b4baf93ddba6efdfe2651a1ffa5508cc14083a46476546324fb010a1943396fb0495bbd2ec918c61d76a418a6cf4d2e194a8fb1ace80ae3e20d40377eb9bde3ce436689d944f50f0b348f2a7deff142a64f9b816eefc10fe0dc3608bd83230aee4c5e993606aea7abc59a11a42c0203b942f0a0ff63cafd220dda363d650ad984430a9a456f7496f3147a29a5694af3fc4da2813e6f28ebc76e8d0f5da85666284111ad0c830863ed06f1dc74d0ce9641474eb04b",
                    note: "5e51ef8136074d049ace12df3721f67495c5b49e335841d589290f5026ffaa9091130a61bc5c45a9aca43fe6bd434d3ca1d658d11ba74aa48cee1d7541a15b4984772ecfd72a4a2fad8765d2d51ee83d7eef8cf98b7a45faaf6a27fac2047b500aeb9b5f12be4e8f9c5ddfaa72dd0e5bfe516f9d799f425faaf63305625d1c87caffb33b4a0746dab6e98c82b50bd643771a5d5738e24fa090843b262eb71cda945ba6bce32d4572a29290a598b471158e9498a021e9444cb5767c8bbc146bc3bc2d6ee4476f4c6eb1d8c9caec69635bd9c13ed3d85e4b319ce105417b0f48f3cce331ba47404dceacce50b2a2ab6451095c70529f2f44288e14",
                    status: "a711d740a2d247168f7eeea8b9aee10f556578f99a22485fa6"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeMainRepository.GetCountAsync(
                    userMainId: Guid.Parse("f0bf39a1-c21f-447d-899e-77b25c0144f2"),
                    resumeName: "7a5c7d33ff4540aabd293e8b2b775a48a8bf2cd6d8cc402d84",
                    marriageCode: "ceeaa7af7bde42baa176bf5d7c508e31a04550dbf3914f9c81",
                    militaryCode: "42fff270a1394e51806e99f264720ea4a0819ee8d3ff4443a9",
                    disabilityCategoryCode: "9bc049f27ae946faa76cda2d61c25a07eb18e8c0189c4d2199",
                    specialIdentityCode: "0e1cae702ce5461993216bcd34eb4fe010cec331ae1f4f3cb7",
                    main: true,
                    autobiography1: "2e035a21d6834a2785533bfdd8fc7f925929f4a3b8bb448f",
                    autobiography2: "95c634b19fef4088a11d7426",
                    extendedInformation: "a717544f22e948c6b37d6cfc8a8e778d9b11789eaad243559bf8518829542d1bc592ec52b12745b1904c2546184df0107f594aec106e4c799e86363787109a23a99337e30648441196a78b688b49edf7240c06cbc7204b39a66acb5878fda802fee69bd4f3564a4fab0b9767ded4fdfbe66c2667a4994fc6b8b5f6953f728798dbf1a27b0ae143f8984dfe0e37748bb1af30fbdd039a40a89ef8ee1444c664dbb75dd185374b4dd480021c67701a13e63ab17e441b3f4e6d9407d493ec13ff7ac9ec3d186335403aba776793d46984553097f02bf25a417eaac006c565d1b58a91f4c020822e403dbc2e4e536f854f1a53976786b89f4bd9a091",
                    note: "c6b63a1dd2574667a23b6ec79635b63b7ecd07a24cd74f54898725ec46354483bd9d2ca06add400491b333d193a1bae580ba9b3f427149bbb09cd6c4f1b67b740a29917c4ba74a4aa1199ca9dcae9a857c23b3e911394cfea196ab15d3e1210ac0afb78219c447d58804f25ca4062d31136af3d6ac2d42cc8a6580389643631a8abff22b0e104ebb89d134cc738c16038696f666a7cd4888994d7accfe363dab1b8bde3281eb4790bc909c77f26c864c359269ca3e7f4f998a7a8e84f39fedfcd262950f4c364b09b95c34cf9d6d304f74bcd61c9d2c4c1ebc59ef95cbac700bdf4c2ffe2e254ba38b3841bcc1a1fd243bb91ecae8b449c3899e",
                    status: "73b903c41a1045719779812dc882fe1d028194f404b141dbae"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}