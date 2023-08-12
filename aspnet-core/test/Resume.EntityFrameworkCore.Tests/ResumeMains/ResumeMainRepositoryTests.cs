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
                    userMainId: Guid.Parse("915d981a-b4ec-46b0-b8d1-7999f160ec63"),
                    resumeName: "01b9690cb2464e579fe7b65e99137b370dc08c57863b4c7986",
                    marriageCode: "6f9174f660ac4e8283f8d70e9a80ee529c2df71528134072a3",
                    militaryCode: "c4f85fdc6897413fb2b2b8bcb4402d0f71a1ccba02274cdf95",
                    disabilityCategoryCode: "4c760f652646466f99d0c487be17137124d91b0aa4304317b3",
                    specialIdentityCode: "517ebcd8f0724222b63b74743f326c6f2bfa4a1ea26b4a55b2",
                    main: true,
                    autobiography1: "347441798c3a44798529b731b837da2c7fea5d8b6f3d41dcbc486e90a8",
                    autobiography2: "db76388441b5405a8ca6375ad31d56f3a4629812690b400f",
                    extendedInformation: "5fc043bd695042a5a91a2b2dc422491b4245230388ea49c4a5a4799b57df7d0c2a389f4a82c5497985b8c5c5daf3c478c2416b742093453fbc333ae6b3cb5a3933c298eaf587488a82d2ef20d21e49ac1770c712360046a392a50460453fdc7aa9675899b6f14736a5aeb17672a70edd99c91342ff2f4544a163e9771637e18af070c4de65bc40449d5033bba2acf5dffabfd110321d4c5da4d0c51795f3b6a59ab00b382c834090ae3169a7f863591cfda5dacad1a947369b04e09a0975e027ac9d40a6807e42f6ab77630465d600bd7665a9af8b544621be0da533349c5deb8acb3f03d42e461b8f4c6272392cf18100963cea64474badb55d",
                    note: "b087930ea7344fcb9321bc002d85e6fef564599ca71f456b8ff6d226d17391a7bb00d811753149adbb9a0e38228c94753cea0e6efec24c22a08cb6489c95a2d705eb8f80b3e044a18b50d67dcf2e7b039a42be8f8ada48e692639fa548d3e4510d81874fedb84a9fbf4bd60431dab633d5695fdba99a4d728a6aa84aa0d2906ce085a706b91c46f3a804a8eb6ca75ca54c492fa5b98c4341a4dd335825185479ebd2e28aab3f431b9e19c8f17cbd94e566c6db652faf4c5d8dda83f7e1a92f51527d9de1e25b432495e3d5312548c6ce462b40ba0f1941e99792253d3a1c7038789b17acf1a749bb94976452dda303bf7d98e57b0b924d5a9f01",
                    status: "31a37e406c2f4ef1986952e7bde984d097139deafa6d4699b1"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a67ce190-d438-4bc4-91fb-0b44c428d4f8"));
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
                    userMainId: Guid.Parse("4cc12c24-d1d2-4a0f-b9aa-46f7a7d82559"),
                    resumeName: "7d29abff074c47f8b42e54140aa5d0349cdb381f68ff41cea9",
                    marriageCode: "87ffd4f525ec435dbf38cdc66c618ffcf8182f2840384fe3ab",
                    militaryCode: "6aaa44c44d0b4e4d8fe9603b7985db5814c84b6430ab43d9bc",
                    disabilityCategoryCode: "0b7cbe060cec41209e7879c1be58c06529d41fdd20a74b61b9",
                    specialIdentityCode: "c9b491f5be2b49e4a5f1350d230fc5cd52c7258a127c44a9b4",
                    main: true,
                    autobiography1: "1312e50b47be4e98813c4bf83d954ceb0d832d0e2e44435c87d6253ca96d155c6787d57650494a82be8948caf924",
                    autobiography2: "72a67369631a4c5ea76d416fbdf28",
                    extendedInformation: "c4f05e0f201c4b679077929354d7a6152fa2fc5e2b36406a97131ff04a91553cf8374b0ad19447b290d7487ddbf18ac94fd0a085a4d742029c710eaaf3f17c794d3277d2b2e343e9b8168833829f652007d8ace6a31448498c9b9d965b4c02fa7704c24230d34e78b5b9320f6648b0bc1398a28440e14a54a98ca5a5320de1e03abc1bcbb26d428da0392120db2379e6de4aa0feb6954d4b87754b9864c046cbfc27a634a5e048bd9e821bdc941f1edd03b127c12cf54140a20efea3db3b7b763e6d2cc5c26e43d79e46f6bba0d788bde1ae65e21cd04c968a4d9e4af1a5e063dc6d3a9fdf6e496d8958d36248637f7296950db1950a4d71a1b4",
                    note: "b4944e512f2e4539bdb65023d014198daf0e6eede3f441ec969cb74ef36e2057bbfe3345b84846f28a4060413aafbb9346d538dd57934ed0bfd757f04c00e6967749303c114342dda1a3c988cd883a759a0cb9f82feb4ee5892794d1686b45ac78e644a261c94991a961cc4a0a26d87b5e0093ed3741459b83d6df17c844072adcf4478e54124bb9aad0c3835adff256f3f006a52b54494ca9fcdabc00a3cc58b06f946643af4f39917d620941f13f4ade9c52caa007441f8ec7fcdda2e7e3e2778ea2c161374ce9998dad8a68a7276ce4fb0cd4dfa34a2ca2fac571647e3b1e26723de807ee422c8834da30b44a6cd5527b96d0a8014de2a234",
                    status: "81956fcfbcc94bd89dc83c066a050f5528f52f978e7f4ba69b"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}