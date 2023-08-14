using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserInfos;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserInfos
{
    public class UserInfoRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserInfoRepository _userInfoRepository;

        public UserInfoRepositoryTests()
        {
            _userInfoRepository = GetRequiredService<IUserInfoRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userInfoRepository.GetListAsync(
                    userMainId: Guid.Parse("533dd1e2-3947-4d2d-b9bf-e144523c36c4"),
                    nameC: "36a069fcfe8c4c23b30629318bc39fb4c2ac9bad8e72406cbe",
                    nameE: "95f7f7498fd7496a8c30bda5c4d2c8cdab64569753f243e0bbba39d8bdd0c7d1b9fe5ebd04824f548a523418c77bc55eff01782099034ea98b658b1bf046a81e4185e4bcfb3b48e5b404e4878612560633e3f6b1eeec4eb9ab6c0518d5332d646bfae931",
                    identityNo: "600d15eac7974aae97e9ded6d8c2dff36d073dcd3d4d4afda5",
                    sexCode: "cb76f0c6a3824560966278a7a63bc25220a72c918ffc42e285",
                    bloodCode: "bb7519be371042e1a7800021e8f99e8043696ddd0c35491ba0",
                    placeOfBirthCode: "528bbb34ebd448639ebfd200df7aea25ed737169295f416f9f",
                    passportNo: "235c1b7058d14a3982f4ea262fdef4bc560aed0988bf40bcab",
                    nationalityCode: "f92af1971cef418c973e646804c221e5ca9eddbf8e214fe6ba",
                    residenceNo: "cc38f3d49f384fb7bb6cb3e2575fb17850ca33a2d8b640d689",
                    extendedInformation: "2aab4b3078664f73a273f5c67d799193123728c59f5d4bddb908d127503b6120448817a1935445f0a52d21d8640f6f4de431eb4cf62c449586252efa8b39090f00acfabc14064d8b8cfbf2a45350e920ea128c42fc104cb2bc67a565bd99367b80c14960c0da4ea8b37a7eaf55f9df2df9e487bff7234a468acf385d3f3665f337358934db3c49e8834ba8203a15343558a8c7afec0a47648d9e3ba48a8a1ede8d6b1b7a939b41ea865ed9d66fae1167bb423de020d843ae85046192746279a21113448e58ce4f2c8e2f31d69219a3853bb870f262704b6bbac2067b1fac2c59b52e8b7a0bba48bfb85f9f7478ab1682040fdf8047dd405abf79",
                    note: "6f04c9db76dc4825be39b9e6c3cf5e2366ac59d778ef47bab09f3aec9500862a874559e5283b4b3ea5680eb3c205dc9758804274da7349f896bd21dda6897ca19481e593eb144fdcae2411b222d3cec15f458ece3e244c10b162ee01d97e78dbb6ce6fd457044217871f903813b4340050e7bcefbb9b4857b763d490171da54fe539b46659974d10b560abfd13708f95531325adcb9d4af3889b030859497794a00edcfe897e4df1b2a56dbfdf3f62810288d65624b34d5bb5a0252651b520444f048e99f51a4e6abce7ee56d95cbacd886b069880e64d7693006b827697639c201111e84e9d4a4b858e27f8ab67303e5398a36f42d743dd847b",
                    status: "48e39c5ce68a4cda92a3e4fa81976f0c265ca507f9234d9fbb"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("45110c14-515a-4a15-8f5f-5712ec0741b9"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userInfoRepository.GetCountAsync(
                    userMainId: Guid.Parse("74657150-a626-4220-8e00-148f640821cd"),
                    nameC: "b4b1c2df142249e5a66326ea5c905211e67c35a3bab341c681",
                    nameE: "365cdfc4a7b342f4abdf1486c5eb08882879f8ca3c434b12809d84f1525aa755ce86bca1ae0b43ccb3e2df8a2a44630282fab5ef6f3c49c4ac9215f2a849abed9f19641f64fc4e879fc284522d59ccfcedabe447398e41b0a97f63fd9367e56dfce1d269",
                    identityNo: "6c0ed427a4bc43839276a15d5790c1e0e454e9e669be4aa69b",
                    sexCode: "6ee68c62e4a44182990748cef13a5048259a00825d624821bb",
                    bloodCode: "6b84e90c4d20481abbe87578931b43ff441fe53a3c5f48f88b",
                    placeOfBirthCode: "369dcb2803f94b70814eee6e78a22abb1daf45edcdd2433abd",
                    passportNo: "f3ffc62713264369a7d2aab6b4ea81b3bbc7e58f1356417eb5",
                    nationalityCode: "410b9e54692a48b199c711186343015fa493e7dfd9684faf8e",
                    residenceNo: "d5aadcbf61504d8daa35d9d3b3acb4486a1c12525053424fa0",
                    extendedInformation: "09ed56ecafd7489a92ef676311f75ecb10d654815637401f945091c38db9a6209bbf9dafd62e4ab3ae68ac0cdddde78f50065c4834d64b56b4e3bafc9989c3c34be533663dd34651bf797448ec0d9c3f291e735134ac4fdea66ce59a89e3723c8e0e4d5dee3a4d7280aa17801b431d227a52f597f74744e08be54330ae45a6c9fd073e40f2a8440188a6bae6ac872b15ca034843999143169a24e03f5dcba19f96ac4a1d45c646e589334267e42bebca21d24ad0de9a4b2ba1b7dcb45aaad1a26e3559dc867d4f0484b81e5e2c3cf5b05c2e4bf8ca8b4652a38cf4344323ce65ddd06f4f5f7b49dd85328c398e38606a8375cad1e94f44a69bba",
                    note: "134369bfe77543418e59d69db5112a0ce6fc8557d6cb4326bd9b0d3848e838b738f563281c2f4cafa7013818c808f2a7755333f410e744d2baafd77343bea067270d99da81fc40ee96bd36c430eb6d565b5c89b8ddfd494e9c02b08a75a4296ccf16b0a205854b6c91ce810b59e7f993c38e9c2c3ff84f048a0411f3a614e45e677aa027b46a426aa93de61cb0ae17fdf809e8d3f5104709ac324f4f15e6a6822b44b5f482274411ae68b15c1e8f7cf3e17eb28ba496405d824757e03e3365bd51eb4d58b07a4b969139a7eaced3a8cba8908856aa9e4a17ac7d613dc03828335f96b170ff494617b2f766d81141f45f1eac0bc9e0bb430d9845",
                    status: "f652db2c661a4ee4bc2ccc1286e437933af03e37150e4ea2bd"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}