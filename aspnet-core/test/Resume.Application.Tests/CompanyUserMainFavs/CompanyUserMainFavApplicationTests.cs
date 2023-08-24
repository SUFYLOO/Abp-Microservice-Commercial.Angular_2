using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyUserMainFavsAppService _companyUserMainFavsAppService;
        private readonly IRepository<CompanyUserMainFav, Guid> _companyUserMainFavRepository;

        public CompanyUserMainFavsAppServiceTests()
        {
            _companyUserMainFavsAppService = GetRequiredService<ICompanyUserMainFavsAppService>();
            _companyUserMainFavRepository = GetRequiredService<IRepository<CompanyUserMainFav, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyUserMainFavsAppService.GetListAsync(new GetCompanyUserMainFavsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("2f20f2ea-ee8a-42ff-9950-f1da774130c7")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyUserMainFavsAppService.GetAsync(Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyUserMainFavCreateDto
            {
                CompanyMainId = Guid.Parse("d9dcbbb8-e157-47d4-9eb1-28316cb869a5"),
                CompanyJobId = Guid.Parse("19f725e0-2238-44e3-89e8-8294537622cf"),
                UserMainId = Guid.Parse("967c3ee3-d8bb-4a42-b0f7-b69d0bae39ee"),
                ExtendedInformation = "2497348316df4b39a09eeb089389239627039cf9334841b1bcb9ae3b36dd669e8bb486cb4a3d46e59ad7c7374870878d75c78281f33944a39e67c2959bbadf19a3c789ea29284a67a4c6072cc31d119d360be1decdb343299ee0b7f801913d64d3c2dbfab8464773adbb3c290ddcab53abbfa4a13a824c4082356b6d8762a3e2ef0e9c564d954c9eab59ad347fead92a806fb9aab71445908d243ff34610839ae3ddf1a2048b4d819f01dd0e5296a1937b3e3603d084421b97a1f9aacaf694b9e4f78104076f446d9aad7b66f8a72e1b987322127fe04008babdec35ded4c9f2110ce026d6b34b13a40500eb7a8a2d9e4daebf95f2784f9ea359",
                DateA = new DateTime(2011, 8, 23),
                DateD = new DateTime(2005, 9, 7),
                Sort = 529712742,
                Note = "a7557db5ad5145358daf36063e1194e855b8ca2647884a7cae9e7f8caf89050062adff429d2f46738fb504a49e6d093ca36a7dc07a134b6ca754dfdffd89d185b810813206bc487fa38fbc3fa50c2878c44b78d0012240d1b25ef2039af8e31fb14b20aa32524a7d9155c3cfc419d36be872c40230dd4d8bb4a4558c740eae40dbf5113c9af446d4845d0ad60b7a914c8fdaf53ca7d745bfa37fa78bc241fa5b03253f48851442acae388b03ada8cc998f398e8e1c7d4d82995b00ca9f70ec9d7d4c11c918b24d4188176182f124dfc83fb11963285e412f9dbebc5091c9995fb7665d75b23845c699be15bb043d9ac1b752aa018672412aa01b",
                Status = "4c6b38542a66492b80576056bd7f1a26971fe83328e242368e"
            };

            // Act
            var serviceResult = await _companyUserMainFavsAppService.CreateAsync(input);

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("d9dcbbb8-e157-47d4-9eb1-28316cb869a5"));
            result.CompanyJobId.ShouldBe(Guid.Parse("19f725e0-2238-44e3-89e8-8294537622cf"));
            result.UserMainId.ShouldBe(Guid.Parse("967c3ee3-d8bb-4a42-b0f7-b69d0bae39ee"));
            result.ExtendedInformation.ShouldBe("2497348316df4b39a09eeb089389239627039cf9334841b1bcb9ae3b36dd669e8bb486cb4a3d46e59ad7c7374870878d75c78281f33944a39e67c2959bbadf19a3c789ea29284a67a4c6072cc31d119d360be1decdb343299ee0b7f801913d64d3c2dbfab8464773adbb3c290ddcab53abbfa4a13a824c4082356b6d8762a3e2ef0e9c564d954c9eab59ad347fead92a806fb9aab71445908d243ff34610839ae3ddf1a2048b4d819f01dd0e5296a1937b3e3603d084421b97a1f9aacaf694b9e4f78104076f446d9aad7b66f8a72e1b987322127fe04008babdec35ded4c9f2110ce026d6b34b13a40500eb7a8a2d9e4daebf95f2784f9ea359");
            result.DateA.ShouldBe(new DateTime(2011, 8, 23));
            result.DateD.ShouldBe(new DateTime(2005, 9, 7));
            result.Sort.ShouldBe(529712742);
            result.Note.ShouldBe("a7557db5ad5145358daf36063e1194e855b8ca2647884a7cae9e7f8caf89050062adff429d2f46738fb504a49e6d093ca36a7dc07a134b6ca754dfdffd89d185b810813206bc487fa38fbc3fa50c2878c44b78d0012240d1b25ef2039af8e31fb14b20aa32524a7d9155c3cfc419d36be872c40230dd4d8bb4a4558c740eae40dbf5113c9af446d4845d0ad60b7a914c8fdaf53ca7d745bfa37fa78bc241fa5b03253f48851442acae388b03ada8cc998f398e8e1c7d4d82995b00ca9f70ec9d7d4c11c918b24d4188176182f124dfc83fb11963285e412f9dbebc5091c9995fb7665d75b23845c699be15bb043d9ac1b752aa018672412aa01b");
            result.Status.ShouldBe("4c6b38542a66492b80576056bd7f1a26971fe83328e242368e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyUserMainFavUpdateDto()
            {
                CompanyMainId = Guid.Parse("b444d24e-5cfd-4831-aaa8-2ca33444adb1"),
                CompanyJobId = Guid.Parse("ecdc07ff-863e-45a5-b638-bd127622d202"),
                UserMainId = Guid.Parse("e383ef0b-0c4f-4e19-977e-0c66f6020a45"),
                ExtendedInformation = "e32ff2094a824429bb06d22efa668198828262ab3f34429cb68bfe20b5da33c69824d598cf384437a4ee01e87a39b838fe8cbbd8e6ac439eb49bd06e8ac2fb20c904d07e311749bda5b0ef040f91d29b1d1bf870a19748dca1552915b262346a7bb30cefa4c34a8e9b5c21af5157b8c9e4442c02499948be8db17dc24173ce93b7493da22fac4bddbbc6dae3279edee7bf831108ea0346168fda7428d971718ea57075d4dd8f41a2871807a41082d912a587841504264a6e9f9865ce1fd0b448d87a9f73bf10498c89b2fbd71f25fb98c897459665e14fea9a1c3ae36a212efb89a890743943402da40ba8881a08c1435e8bac8d7e8e43eabb8c",
                DateA = new DateTime(2016, 6, 4),
                DateD = new DateTime(2012, 6, 14),
                Sort = 468575541,
                Note = "8d55b18a738441f595841b64fb174ebc4a294a44484b4c8ab4a10c0f6bc2bf57376c46123e5c44a3a1990caf7148c8f72ea0b3e84c1d4ed78ff7cba3ff8a62b9e3214b24d8f4486e8ac4d53decc2773cdbf62da0ab874dd0961d210bd570bf09159172456fa2495a97773cecd99162f834b04d422b634e779941b00663c378259b891dd419a746c5854d0b5d3af6e2d1ee64603713374064b7c5be4e709e5b03d1474c0cf51b460999057fb45286e92545a1922bf06645d0bc174f2e923d9492ceaabaca43764b739778151133586e79229d1d39d32241ea9740f123b5c692d5396d4645adf845028da252b0f77cdf4e1ef44ab2e5f5462c9597",
                Status = "4b362517b3284fa9b3962c5d0695680bb0e200de377a4a1194"
            };

            // Act
            var serviceResult = await _companyUserMainFavsAppService.UpdateAsync(Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"), input);

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("b444d24e-5cfd-4831-aaa8-2ca33444adb1"));
            result.CompanyJobId.ShouldBe(Guid.Parse("ecdc07ff-863e-45a5-b638-bd127622d202"));
            result.UserMainId.ShouldBe(Guid.Parse("e383ef0b-0c4f-4e19-977e-0c66f6020a45"));
            result.ExtendedInformation.ShouldBe("e32ff2094a824429bb06d22efa668198828262ab3f34429cb68bfe20b5da33c69824d598cf384437a4ee01e87a39b838fe8cbbd8e6ac439eb49bd06e8ac2fb20c904d07e311749bda5b0ef040f91d29b1d1bf870a19748dca1552915b262346a7bb30cefa4c34a8e9b5c21af5157b8c9e4442c02499948be8db17dc24173ce93b7493da22fac4bddbbc6dae3279edee7bf831108ea0346168fda7428d971718ea57075d4dd8f41a2871807a41082d912a587841504264a6e9f9865ce1fd0b448d87a9f73bf10498c89b2fbd71f25fb98c897459665e14fea9a1c3ae36a212efb89a890743943402da40ba8881a08c1435e8bac8d7e8e43eabb8c");
            result.DateA.ShouldBe(new DateTime(2016, 6, 4));
            result.DateD.ShouldBe(new DateTime(2012, 6, 14));
            result.Sort.ShouldBe(468575541);
            result.Note.ShouldBe("8d55b18a738441f595841b64fb174ebc4a294a44484b4c8ab4a10c0f6bc2bf57376c46123e5c44a3a1990caf7148c8f72ea0b3e84c1d4ed78ff7cba3ff8a62b9e3214b24d8f4486e8ac4d53decc2773cdbf62da0ab874dd0961d210bd570bf09159172456fa2495a97773cecd99162f834b04d422b634e779941b00663c378259b891dd419a746c5854d0b5d3af6e2d1ee64603713374064b7c5be4e709e5b03d1474c0cf51b460999057fb45286e92545a1922bf06645d0bc174f2e923d9492ceaabaca43764b739778151133586e79229d1d39d32241ea9740f123b5c692d5396d4645adf845028da252b0f77cdf4e1ef44ab2e5f5462c9597");
            result.Status.ShouldBe("4b362517b3284fa9b3962c5d0695680bb0e200de377a4a1194");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyUserMainFavsAppService.DeleteAsync(Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"));

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == Guid.Parse("14641554-659e-43c4-aa33-52ea119d1119"));

            result.ShouldBeNull();
        }
    }
}