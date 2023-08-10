using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserCompanyJobPairsAppService _userCompanyJobPairsAppService;
        private readonly IRepository<UserCompanyJobPair, Guid> _userCompanyJobPairRepository;

        public UserCompanyJobPairsAppServiceTests()
        {
            _userCompanyJobPairsAppService = GetRequiredService<IUserCompanyJobPairsAppService>();
            _userCompanyJobPairRepository = GetRequiredService<IRepository<UserCompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetListAsync(new GetUserCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("24ab1425-9912-441a-8348-af7f8ac5cc08")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userCompanyJobPairsAppService.GetAsync(Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairCreateDto
            {
                UserMainId = Guid.Parse("4e58cb08-f410-473e-a93a-a6c517bb1b98"),
                Name = "23e65ac0f4944c189cecbef512350d87bd4f0579512a48dab7",
                PairCondition = "1abd42d1495c411ab18bd2802e398243af47d86e490e497980db0c584fdcbbe6346abefb39e142c5aa624400158cdfc15563cd5086df4da5828324f72aea0878dc5ca3e7e26d49cba9ca593d45b5d8bd98a0b419bbc2477aa43d049992af78e0e2464fe116d2423da0d81c1f40e9acc24625b63015244ce692928bf9814ca5d866525c183d274c9b890ae69469b6d55cc8d8b6c3018a4bb9b3970bd031b79316de98f825c8084675bdfdd8e3a3ce01ed4da4cb8f7c8a45b79bf5787494d92128f3ec33bea6294d0596676003faaffb153a62d5880561481f8b4394856e1e87f2a4a9c07818ce4d3c9ee3d05f6160b4a1e324a54bddee47309ee1",
                ExtendedInformation = "e2d26131644c4aa08e7c328ed2efeaeb9eae41b2fc9d43868c25a4dbeb7cc219cc9c15b77470469eadd09f1e762890250b79387c3da8408fb4f7342c284231122a7ce7e93a3f4420a9848ddd0453b263acf61ca4192a4fa9bf499c55c17ea81bba9af69f4f1a4a78afcb1c4aa7b2d15c195c17d1fd694e35be9821d32f049b3b1a8322fbfdb64b788d91da2f8baefc0495d94fe6e25d48eb864aaec06e995f2e2f69793d354d4d3dbbeb34e6e7c2545096f042d080b94bf9aa848bd4ab2dfd316f2071a72b994be996d95f8f68ccf54569e005f24ba544f8a5d2beee19c08ec7013fec234e834504b23f1fa7bac012516a3e1a99661a4d03851b",
                DateA = new DateTime(2012, 2, 27),
                DateD = new DateTime(2010, 7, 22),
                Sort = 1773795540,
                Note = "ea957c1d8cf141a3ac7f85be42bbfa1337a947cdf64145ca93c638f2db0377ebc6ed912861e74a9ebab50e429b35d365acf56da8f2674e40906bb2582765688cdbd73e8566524ad9bb57509e0410336c3e6ec64deed84a438772eeb40c0fe5cc693b9198f5284f288e0a3411813bb60cf5e0af1c0dc14b0cab5454723e2b2453187fa9440eae40da8dd7a1ffdc37bedcf6906a5daaf64177a59210b3bf6556aa53a3b3c174eb447ca629b8064fa8e76c50002f3bf73e487398541e249a9a861aa195b86c89f5474892919c053fd6218f1963d207994049b581bf636f8f7ba0791f74d7fb1084415ba5c2cbccd52f85cfe7862816a4d2453fab26",
                Status = "0afc089aa7024badad33ff77b514a20b871af0fc38994ca89f"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("4e58cb08-f410-473e-a93a-a6c517bb1b98"));
            result.Name.ShouldBe("23e65ac0f4944c189cecbef512350d87bd4f0579512a48dab7");
            result.PairCondition.ShouldBe("1abd42d1495c411ab18bd2802e398243af47d86e490e497980db0c584fdcbbe6346abefb39e142c5aa624400158cdfc15563cd5086df4da5828324f72aea0878dc5ca3e7e26d49cba9ca593d45b5d8bd98a0b419bbc2477aa43d049992af78e0e2464fe116d2423da0d81c1f40e9acc24625b63015244ce692928bf9814ca5d866525c183d274c9b890ae69469b6d55cc8d8b6c3018a4bb9b3970bd031b79316de98f825c8084675bdfdd8e3a3ce01ed4da4cb8f7c8a45b79bf5787494d92128f3ec33bea6294d0596676003faaffb153a62d5880561481f8b4394856e1e87f2a4a9c07818ce4d3c9ee3d05f6160b4a1e324a54bddee47309ee1");
            result.ExtendedInformation.ShouldBe("e2d26131644c4aa08e7c328ed2efeaeb9eae41b2fc9d43868c25a4dbeb7cc219cc9c15b77470469eadd09f1e762890250b79387c3da8408fb4f7342c284231122a7ce7e93a3f4420a9848ddd0453b263acf61ca4192a4fa9bf499c55c17ea81bba9af69f4f1a4a78afcb1c4aa7b2d15c195c17d1fd694e35be9821d32f049b3b1a8322fbfdb64b788d91da2f8baefc0495d94fe6e25d48eb864aaec06e995f2e2f69793d354d4d3dbbeb34e6e7c2545096f042d080b94bf9aa848bd4ab2dfd316f2071a72b994be996d95f8f68ccf54569e005f24ba544f8a5d2beee19c08ec7013fec234e834504b23f1fa7bac012516a3e1a99661a4d03851b");
            result.DateA.ShouldBe(new DateTime(2012, 2, 27));
            result.DateD.ShouldBe(new DateTime(2010, 7, 22));
            result.Sort.ShouldBe(1773795540);
            result.Note.ShouldBe("ea957c1d8cf141a3ac7f85be42bbfa1337a947cdf64145ca93c638f2db0377ebc6ed912861e74a9ebab50e429b35d365acf56da8f2674e40906bb2582765688cdbd73e8566524ad9bb57509e0410336c3e6ec64deed84a438772eeb40c0fe5cc693b9198f5284f288e0a3411813bb60cf5e0af1c0dc14b0cab5454723e2b2453187fa9440eae40da8dd7a1ffdc37bedcf6906a5daaf64177a59210b3bf6556aa53a3b3c174eb447ca629b8064fa8e76c50002f3bf73e487398541e249a9a861aa195b86c89f5474892919c053fd6218f1963d207994049b581bf636f8f7ba0791f74d7fb1084415ba5c2cbccd52f85cfe7862816a4d2453fab26");
            result.Status.ShouldBe("0afc089aa7024badad33ff77b514a20b871af0fc38994ca89f");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserCompanyJobPairUpdateDto()
            {
                UserMainId = Guid.Parse("2ae505e3-ef55-4607-b8b0-4cf8a12d3781"),
                Name = "5e5ecbcd3a0b4211845b0965e0841c862da1987bdd55489abd",
                PairCondition = "c93ed4d5a8754208bc0cee13b1e4ddbb452811347a544e42a6bb81e81ca763d8438bd46842674e14b03b899349b6c92b1244ac650620479e944e100dab0219df3f7b3a25521f4c13b52a51bc9c668328f225c8d069b04f59ac5306514ded2d5eb2b50eb422a64e6b955fc453ac962b8d6de8b30f828f437ebbaa2a85eb741fa4dea38db43f3441b7863ef864e71c0032db4f288848cf4c629c2aa37f2adcac89c2cd0ad0ca97419f9438d96f186499163e00c7b8f8aa4d1193ac98069a6e6d89e712a31986104750ae211d1a65cfaf55e8dcb02848f34f369b94abbf16a4372ece3cbb90a4ef4e4a9cd40e0def436093b029d265702d436c9122",
                ExtendedInformation = "ed6f24c9fdb449faa14d38d8e4be1b867353c466aea44b0483477effbad0f9d30aaa7915e27b42bc9285339c1d33dd97679a74d0d9494934a618de16a58a6f04c5342d10d3b547ee9bffe2459bfd89c4d26b8d61b2d2426aa3d97eb07c82b2831d5956b91a4d420189c2027f52472a90d5bc411cf87a4afd85c3f054e26579e4fe2e8f066730479e85fd3d4e87a56ff2729f41609e4f4fc39a014f5476853ba259dc7e663b7d436bab478ef8cdd403310d53fe703d214d4d8e68a2a7afcb38ef4ba32f8c36b1404092dbe63a88b5b4a8927775ba52fa4b97b72d7a35be9401232e55917ceb66475c8abb441942502d5751292593c72b491f9ee1",
                DateA = new DateTime(2005, 10, 27),
                DateD = new DateTime(2008, 1, 8),
                Sort = 448361321,
                Note = "4f7d071c6a364d6582376c5c843cc1795a6883ae28b347f89b59992d44e1ea2b4554dc12e91443a98e82435155041e399bb6fa8965d848cbab2ccb550bf259bc2ed79b1090a542e0b79fe6dac88bcc5d75ada29a713a413bb3bf934272c7d7baac4bfc95edf347c1b0556b64e8001914d812fe86151c45a5ae4d70f1ed29a9840f4b16aa340c4d5f98e543143363786275f6595cd8944e558c6a1f5164d6ccbe069e65cf125449c49d686a0d337b6d84d4126dd6b6484b798b59b292560def0f747c456c443e4edebc211330f9e5256f8d9ed527a6fd4513b1e1069b568b052497c66e7097f8436d880742978fd8954625dd7076249f469e9647",
                Status = "41c1b24d90d14181981c4e8b3e496b956218fa93222b4003a9"
            };

            // Act
            var serviceResult = await _userCompanyJobPairsAppService.UpdateAsync(Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"), input);

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("2ae505e3-ef55-4607-b8b0-4cf8a12d3781"));
            result.Name.ShouldBe("5e5ecbcd3a0b4211845b0965e0841c862da1987bdd55489abd");
            result.PairCondition.ShouldBe("c93ed4d5a8754208bc0cee13b1e4ddbb452811347a544e42a6bb81e81ca763d8438bd46842674e14b03b899349b6c92b1244ac650620479e944e100dab0219df3f7b3a25521f4c13b52a51bc9c668328f225c8d069b04f59ac5306514ded2d5eb2b50eb422a64e6b955fc453ac962b8d6de8b30f828f437ebbaa2a85eb741fa4dea38db43f3441b7863ef864e71c0032db4f288848cf4c629c2aa37f2adcac89c2cd0ad0ca97419f9438d96f186499163e00c7b8f8aa4d1193ac98069a6e6d89e712a31986104750ae211d1a65cfaf55e8dcb02848f34f369b94abbf16a4372ece3cbb90a4ef4e4a9cd40e0def436093b029d265702d436c9122");
            result.ExtendedInformation.ShouldBe("ed6f24c9fdb449faa14d38d8e4be1b867353c466aea44b0483477effbad0f9d30aaa7915e27b42bc9285339c1d33dd97679a74d0d9494934a618de16a58a6f04c5342d10d3b547ee9bffe2459bfd89c4d26b8d61b2d2426aa3d97eb07c82b2831d5956b91a4d420189c2027f52472a90d5bc411cf87a4afd85c3f054e26579e4fe2e8f066730479e85fd3d4e87a56ff2729f41609e4f4fc39a014f5476853ba259dc7e663b7d436bab478ef8cdd403310d53fe703d214d4d8e68a2a7afcb38ef4ba32f8c36b1404092dbe63a88b5b4a8927775ba52fa4b97b72d7a35be9401232e55917ceb66475c8abb441942502d5751292593c72b491f9ee1");
            result.DateA.ShouldBe(new DateTime(2005, 10, 27));
            result.DateD.ShouldBe(new DateTime(2008, 1, 8));
            result.Sort.ShouldBe(448361321);
            result.Note.ShouldBe("4f7d071c6a364d6582376c5c843cc1795a6883ae28b347f89b59992d44e1ea2b4554dc12e91443a98e82435155041e399bb6fa8965d848cbab2ccb550bf259bc2ed79b1090a542e0b79fe6dac88bcc5d75ada29a713a413bb3bf934272c7d7baac4bfc95edf347c1b0556b64e8001914d812fe86151c45a5ae4d70f1ed29a9840f4b16aa340c4d5f98e543143363786275f6595cd8944e558c6a1f5164d6ccbe069e65cf125449c49d686a0d337b6d84d4126dd6b6484b798b59b292560def0f747c456c443e4edebc211330f9e5256f8d9ed527a6fd4513b1e1069b568b052497c66e7097f8436d880742978fd8954625dd7076249f469e9647");
            result.Status.ShouldBe("41c1b24d90d14181981c4e8b3e496b956218fa93222b4003a9");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userCompanyJobPairsAppService.DeleteAsync(Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"));

            // Assert
            var result = await _userCompanyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"));

            result.ShouldBeNull();
        }
    }
}