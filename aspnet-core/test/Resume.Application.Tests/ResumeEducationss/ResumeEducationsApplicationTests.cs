using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeEducationssAppService _resumeEducationssAppService;
        private readonly IRepository<ResumeEducations, Guid> _resumeEducationsRepository;

        public ResumeEducationssAppServiceTests()
        {
            _resumeEducationssAppService = GetRequiredService<IResumeEducationssAppService>();
            _resumeEducationsRepository = GetRequiredService<IRepository<ResumeEducations, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetListAsync(new GetResumeEducationssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("10c3cc5f-1a8f-40fe-81ad-58270ce868ab")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetAsync(Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeEducationsCreateDto
            {
                ResumeMainId = Guid.Parse("09349c51-8b8d-42b9-b547-64317e6320ef"),
                EducationLevelCode = "a02eb419d1c14e30919d0cd37bcf153600f0761d5fc14ad4a9",
                SchoolCode = "42fad1af0a2c4c569c96ef4e9e67f4ece649eafb1d53426dab",
                SchoolName = "de6aa403c2ea457594ddf3425f3f70a7bba329e4b81b4e14be2b8c9e321603379d624e1366eb4d97ac7d8bb7068504a96b6a1c1017844d5687b018015a11d1db9736a4e78dbf4b909fce71e375a343159eabb8ee2ad94b9cb8a6dbd4025cf77bedfe89f4",
                Night = true,
                Working = true,
                MajorDepartmentName = "d97879f7063f4f40be790de83135cd8fc413be494e7c4e0b8c",
                MajorDepartmentCategoryCode = "90936b8b2e4f4b9b8ecdcbdb769db902138b313efb914b83a53c8f680349e22aaaf5f83882714af6a3d57b7e0ed75030395cec7636df4b8e8cfe93c5fe5c1a81afd43c5308114a629312f532e9177ce5c23cc2d3004243399b16126cb061de12cf2181fad92e4c4bac9caef622a15da6d5d4cf6c25ee417691af36269915755d12f6493b085948998518878fa848ac585c57e99da0bf4c35b389232d91fa4c7d88b74935e883489995aca8f71b4937a6809d089d152b40c980e5773b2781ecc993b23420186349f3a86c475926513d8923afc4dcde4641aca869ac173c3efcf1536e4bb8c2b84eb3bdaf6c7ab74bdf91164231ee545c4026b516",
                MinorDepartmentName = "54d09b2fbc75446a894b7dc4f7e545e9e0919601745642f6b1",
                MinorDepartmentCategoryCode = "2f8b78c595ab42c0b7797ea51555af8cca0bad0c517a40c29a20503f1dfb45c9419933eee4004b8593b437d63df02146d25ae84bf65f419a8693c98b9247e246ddff9b0b5aef41d8b963bb55fcfc50bdbde068003ed74c1f95586f8f203bb7d33ead249095c4496b96283d451ba30ee3cd9c7d09d8d040f6a86f7bb87b12bc7c964b9a0380584ec5bdd712b52c573c4ac8a08f4c94424df38c00be66261abd0f967b094800a9485b9a2608af1c9a1f69c2144523d924424bab88a0027316d1df208c9b1fa5534c6c9b907487673a145acf284884f5dc48e8b21f5b06545526ec4ebf62293f2d4d88bdedb2e7dcfc848def99c5bce426465c8374",
                GraduationCode = "91461a1fd3d54cefba5530bf5b8dd2f244e0c09ad1ee4787ab",
                Domestic = true,
                CountryCode = "29dda6f795224ab9b19de622bd02be6f0fc2c29b50614e3a8c",
                ExtendedInformation = "2ab2ac118f0d45b8af84de85251e2dfa070b4e8e6bfe41b1ab7aa604d8722938345adb07d39e42ffa5913a5edd431becf6a378e2c2c74b9d9118233e403c380a96ab051dbda242bebfec0fdaf19302b2834c04d24d3d46fd8bcac087d61ce9915ac5532595ef4ff5b8f7d724ef2e7c344e9b58d3647d4f9aa1472b3296476e2b237bf79f365a4c5db67865370c1663baf78ea9ed2d09489fae036ad08ae442a9d4ac9e7d1db44124878cdaa3e54504a8d7a4cc0ceded43f795230f5738f420d249a42b7f3ba4479baf8aa21040e21d5fb88539cd84ee41a4be909a003fb866421935287093c249b194ca4624bc7636affae26046894b48b9862c",
                DateA = new DateTime(2000, 2, 7),
                DateD = new DateTime(2011, 8, 16),
                Sort = 2141984302,
                Note = "5a680971917a4333840e48c928f70de012788a3be1854d8f895dc2dc092e560ba8eb07e628b14f919ecf7042c4e556e79fd78296b5a342dcb1e9eeace77bfe8ddfa0dbd87de140dd8fae0fda22e6f58513bc2af5359440f491e431c362808ccba5763abe3fff49088e5c17617ed839b0edb2a177c7b046af9a66537ced4ecd3cabbc8ad7829c4beba94e27e3429b3c5add16320f71df46d5ab08cce98ddba9fd8fa333e4c1f74e11846e9a8e34875208470a8256fdbe4da58e8c0708bb273b38dd335bf946b2498e973a91759213a6685e31d278c947440b9f811535214a3b0c5738b20aa1a4414a8de69cf96aa8646e62817f601a4a4df692ca",
                Status = "794dfb6b38e0433bac6c67eb00311bf4baa3de54c88d414e80"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("09349c51-8b8d-42b9-b547-64317e6320ef"));
            result.EducationLevelCode.ShouldBe("a02eb419d1c14e30919d0cd37bcf153600f0761d5fc14ad4a9");
            result.SchoolCode.ShouldBe("42fad1af0a2c4c569c96ef4e9e67f4ece649eafb1d53426dab");
            result.SchoolName.ShouldBe("de6aa403c2ea457594ddf3425f3f70a7bba329e4b81b4e14be2b8c9e321603379d624e1366eb4d97ac7d8bb7068504a96b6a1c1017844d5687b018015a11d1db9736a4e78dbf4b909fce71e375a343159eabb8ee2ad94b9cb8a6dbd4025cf77bedfe89f4");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("d97879f7063f4f40be790de83135cd8fc413be494e7c4e0b8c");
            result.MajorDepartmentCategoryCode.ShouldBe("90936b8b2e4f4b9b8ecdcbdb769db902138b313efb914b83a53c8f680349e22aaaf5f83882714af6a3d57b7e0ed75030395cec7636df4b8e8cfe93c5fe5c1a81afd43c5308114a629312f532e9177ce5c23cc2d3004243399b16126cb061de12cf2181fad92e4c4bac9caef622a15da6d5d4cf6c25ee417691af36269915755d12f6493b085948998518878fa848ac585c57e99da0bf4c35b389232d91fa4c7d88b74935e883489995aca8f71b4937a6809d089d152b40c980e5773b2781ecc993b23420186349f3a86c475926513d8923afc4dcde4641aca869ac173c3efcf1536e4bb8c2b84eb3bdaf6c7ab74bdf91164231ee545c4026b516");
            result.MinorDepartmentName.ShouldBe("54d09b2fbc75446a894b7dc4f7e545e9e0919601745642f6b1");
            result.MinorDepartmentCategoryCode.ShouldBe("2f8b78c595ab42c0b7797ea51555af8cca0bad0c517a40c29a20503f1dfb45c9419933eee4004b8593b437d63df02146d25ae84bf65f419a8693c98b9247e246ddff9b0b5aef41d8b963bb55fcfc50bdbde068003ed74c1f95586f8f203bb7d33ead249095c4496b96283d451ba30ee3cd9c7d09d8d040f6a86f7bb87b12bc7c964b9a0380584ec5bdd712b52c573c4ac8a08f4c94424df38c00be66261abd0f967b094800a9485b9a2608af1c9a1f69c2144523d924424bab88a0027316d1df208c9b1fa5534c6c9b907487673a145acf284884f5dc48e8b21f5b06545526ec4ebf62293f2d4d88bdedb2e7dcfc848def99c5bce426465c8374");
            result.GraduationCode.ShouldBe("91461a1fd3d54cefba5530bf5b8dd2f244e0c09ad1ee4787ab");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("29dda6f795224ab9b19de622bd02be6f0fc2c29b50614e3a8c");
            result.ExtendedInformation.ShouldBe("2ab2ac118f0d45b8af84de85251e2dfa070b4e8e6bfe41b1ab7aa604d8722938345adb07d39e42ffa5913a5edd431becf6a378e2c2c74b9d9118233e403c380a96ab051dbda242bebfec0fdaf19302b2834c04d24d3d46fd8bcac087d61ce9915ac5532595ef4ff5b8f7d724ef2e7c344e9b58d3647d4f9aa1472b3296476e2b237bf79f365a4c5db67865370c1663baf78ea9ed2d09489fae036ad08ae442a9d4ac9e7d1db44124878cdaa3e54504a8d7a4cc0ceded43f795230f5738f420d249a42b7f3ba4479baf8aa21040e21d5fb88539cd84ee41a4be909a003fb866421935287093c249b194ca4624bc7636affae26046894b48b9862c");
            result.DateA.ShouldBe(new DateTime(2000, 2, 7));
            result.DateD.ShouldBe(new DateTime(2011, 8, 16));
            result.Sort.ShouldBe(2141984302);
            result.Note.ShouldBe("5a680971917a4333840e48c928f70de012788a3be1854d8f895dc2dc092e560ba8eb07e628b14f919ecf7042c4e556e79fd78296b5a342dcb1e9eeace77bfe8ddfa0dbd87de140dd8fae0fda22e6f58513bc2af5359440f491e431c362808ccba5763abe3fff49088e5c17617ed839b0edb2a177c7b046af9a66537ced4ecd3cabbc8ad7829c4beba94e27e3429b3c5add16320f71df46d5ab08cce98ddba9fd8fa333e4c1f74e11846e9a8e34875208470a8256fdbe4da58e8c0708bb273b38dd335bf946b2498e973a91759213a6685e31d278c947440b9f811535214a3b0c5738b20aa1a4414a8de69cf96aa8646e62817f601a4a4df692ca");
            result.Status.ShouldBe("794dfb6b38e0433bac6c67eb00311bf4baa3de54c88d414e80");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeEducationsUpdateDto()
            {
                ResumeMainId = Guid.Parse("2db381a8-e60f-4254-8038-a758a120d54b"),
                EducationLevelCode = "19465c5c979746b6a5162a62b77792cadfbfa108e39d42128a",
                SchoolCode = "b5984ea64c6942b9a9e08d7049fd7bc196ddcdaf880441dd91",
                SchoolName = "c734f2451f04416fb24a2259c528f8f05fc1f4e9d84c4e6087b9eec2d18b71e43f89175c1d094366801e831e8f54ed017595fadae1404c888b7bb348b3c7f2910fa91ce863264e1b8369a0191acc765d413a87a5f7754c84bb7fcf3dbbd3e35eb7e998d6",
                Night = true,
                Working = true,
                MajorDepartmentName = "821a765267fe4fd29f4e39d8662a06c7f9640b205a79498a8c",
                MajorDepartmentCategoryCode = "c1407defb5a84947a301dbf665a96caccdc95e8824534d49a0c96017b965f85793deec9a582b4e1eb97f6eb9b67fa0b3a1772b1fb8524d44aa859563c45a4c2adce024a837774c37b8ac99289ecebb8bc1daa0f801b7408ab4102ef05a27a1cfe2367e0a2f824d7dada227ad6ebf97b9e41b6cfc9db94e3393cc8b0d5d46602abc89a660c97849daaba81de244d9ae5bee0427e7a5ad4a91ad81bc52ff1d08bb1f4361576d184f96b7ad0543ace98f450d1b5f29a5e749108352a47d2b374945414f85e114db46ddadd37dadb4fc3510ee4359ba4ad84ff6bf64565ba96ec0c1dccaeb2718b14754a74667f00a7ad7cf59773cdccce248f7b621",
                MinorDepartmentName = "cee48e9765b44872965658773690467696f18387f7f24225a1",
                MinorDepartmentCategoryCode = "b1dffa46195141d09637e63a8e5c8fbfd694f057ec344f61bb92d1f96ceca5f044d6a8c3032d40bd807c5ca8ad34f372832700c2688b423e85c2a65796b9fcd6f1f80936479b4152a1a9510a24b3d2a2a92aeb6c638c434d8bbafe50a82b57728aebd1593cd74ce483dbcb857a4b45af1cf29fbb400e498f8c9cc8918b7c27646ae3ca03ba374d4ca4bc0fafba1ca7767dbc289ebbab496f9b1cd3f3df858b7743e5f94d2b2d4a43affd92b7b6e3d0a3440c783aeede40018c9c9b7adb02f2d4d49352bdbe244f9eb2f41ae2d1ba966f2378048205c4499ba35c24bccb788d25889fe1c764ab4c9592bc7029b7d581b92453a76d08fd4c798b15",
                GraduationCode = "b0ac3a5047454a40b67639b04fec4de4321f3f0c3cd646eea6",
                Domestic = true,
                CountryCode = "68f547e81e794d60807e2af7822f62e585481b5dcf5641a0a0",
                ExtendedInformation = "726a18638240485cb43d55fd092a0db27b15fbf07697428ebedd047f12f344ba1fa0112d484a4b0d83ca0933f6f6182a8173aa9395bf49fa8d5b3c025555115bab302bc766b940c19f74379e3b1716e06a2154fbd1b44c4c9437686b8769db088cba2d2ae2d4459d880fda26874956f3cf6d4baf2b63476e964d0e4af6eaf6ad14ab1ac039694e60a687dc7407c23f5e0d6922d2918242c38efe9fee55c941645b44e31550874bc38a5ae4cae96eaf5d062d778b8bd049998d40b1ccf3a74082c1523528cd844f22b1e4e2eac807230759b590455b5f49d7ba8d81919609b42e115126f7d1764361bdc61861b3cd872820ee2249cd204bdaba80",
                DateA = new DateTime(2006, 9, 9),
                DateD = new DateTime(2011, 7, 7),
                Sort = 634520534,
                Note = "4c1540e8d9e04a6db3fae7958533ee18b7d11921aaba428b8efd29b6f844dc1e062b9b5f640d4492b91e7543b61ded335afe143bbe3d4972b8ff53532c5ca6f6dcddf8d2cc1640ea872421bdab563d3b673e597d448d47b18621e7e0223e19d0b3b8078b621e45a4a855e5af901669b224b51f6c74ae4335a94d08985359240266e7733795ba4a98a663e70ac5dd2e5133702a95afe449c4b6489246e23e4875c9e7bc411b0f47308c5301bd0e4d12c4cf7395ec003a40c0b7a777e277e548e3476cb0e581c341489558ba0c874bd7d383207363581041fda07e7b739a99605c8c15fa7a3cee40cb95d6d5d7131b985a8dd0d287f3e14f568811",
                Status = "6b9a375795494d34aa55c10a58aa35c3f64f97dd7a194444a7"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.UpdateAsync(Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"), input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("2db381a8-e60f-4254-8038-a758a120d54b"));
            result.EducationLevelCode.ShouldBe("19465c5c979746b6a5162a62b77792cadfbfa108e39d42128a");
            result.SchoolCode.ShouldBe("b5984ea64c6942b9a9e08d7049fd7bc196ddcdaf880441dd91");
            result.SchoolName.ShouldBe("c734f2451f04416fb24a2259c528f8f05fc1f4e9d84c4e6087b9eec2d18b71e43f89175c1d094366801e831e8f54ed017595fadae1404c888b7bb348b3c7f2910fa91ce863264e1b8369a0191acc765d413a87a5f7754c84bb7fcf3dbbd3e35eb7e998d6");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("821a765267fe4fd29f4e39d8662a06c7f9640b205a79498a8c");
            result.MajorDepartmentCategoryCode.ShouldBe("c1407defb5a84947a301dbf665a96caccdc95e8824534d49a0c96017b965f85793deec9a582b4e1eb97f6eb9b67fa0b3a1772b1fb8524d44aa859563c45a4c2adce024a837774c37b8ac99289ecebb8bc1daa0f801b7408ab4102ef05a27a1cfe2367e0a2f824d7dada227ad6ebf97b9e41b6cfc9db94e3393cc8b0d5d46602abc89a660c97849daaba81de244d9ae5bee0427e7a5ad4a91ad81bc52ff1d08bb1f4361576d184f96b7ad0543ace98f450d1b5f29a5e749108352a47d2b374945414f85e114db46ddadd37dadb4fc3510ee4359ba4ad84ff6bf64565ba96ec0c1dccaeb2718b14754a74667f00a7ad7cf59773cdccce248f7b621");
            result.MinorDepartmentName.ShouldBe("cee48e9765b44872965658773690467696f18387f7f24225a1");
            result.MinorDepartmentCategoryCode.ShouldBe("b1dffa46195141d09637e63a8e5c8fbfd694f057ec344f61bb92d1f96ceca5f044d6a8c3032d40bd807c5ca8ad34f372832700c2688b423e85c2a65796b9fcd6f1f80936479b4152a1a9510a24b3d2a2a92aeb6c638c434d8bbafe50a82b57728aebd1593cd74ce483dbcb857a4b45af1cf29fbb400e498f8c9cc8918b7c27646ae3ca03ba374d4ca4bc0fafba1ca7767dbc289ebbab496f9b1cd3f3df858b7743e5f94d2b2d4a43affd92b7b6e3d0a3440c783aeede40018c9c9b7adb02f2d4d49352bdbe244f9eb2f41ae2d1ba966f2378048205c4499ba35c24bccb788d25889fe1c764ab4c9592bc7029b7d581b92453a76d08fd4c798b15");
            result.GraduationCode.ShouldBe("b0ac3a5047454a40b67639b04fec4de4321f3f0c3cd646eea6");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("68f547e81e794d60807e2af7822f62e585481b5dcf5641a0a0");
            result.ExtendedInformation.ShouldBe("726a18638240485cb43d55fd092a0db27b15fbf07697428ebedd047f12f344ba1fa0112d484a4b0d83ca0933f6f6182a8173aa9395bf49fa8d5b3c025555115bab302bc766b940c19f74379e3b1716e06a2154fbd1b44c4c9437686b8769db088cba2d2ae2d4459d880fda26874956f3cf6d4baf2b63476e964d0e4af6eaf6ad14ab1ac039694e60a687dc7407c23f5e0d6922d2918242c38efe9fee55c941645b44e31550874bc38a5ae4cae96eaf5d062d778b8bd049998d40b1ccf3a74082c1523528cd844f22b1e4e2eac807230759b590455b5f49d7ba8d81919609b42e115126f7d1764361bdc61861b3cd872820ee2249cd204bdaba80");
            result.DateA.ShouldBe(new DateTime(2006, 9, 9));
            result.DateD.ShouldBe(new DateTime(2011, 7, 7));
            result.Sort.ShouldBe(634520534);
            result.Note.ShouldBe("4c1540e8d9e04a6db3fae7958533ee18b7d11921aaba428b8efd29b6f844dc1e062b9b5f640d4492b91e7543b61ded335afe143bbe3d4972b8ff53532c5ca6f6dcddf8d2cc1640ea872421bdab563d3b673e597d448d47b18621e7e0223e19d0b3b8078b621e45a4a855e5af901669b224b51f6c74ae4335a94d08985359240266e7733795ba4a98a663e70ac5dd2e5133702a95afe449c4b6489246e23e4875c9e7bc411b0f47308c5301bd0e4d12c4cf7395ec003a40c0b7a777e277e548e3476cb0e581c341489558ba0c874bd7d383207363581041fda07e7b739a99605c8c15fa7a3cee40cb95d6d5d7131b985a8dd0d287f3e14f568811");
            result.Status.ShouldBe("6b9a375795494d34aa55c10a58aa35c3f64f97dd7a194444a7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeEducationssAppService.DeleteAsync(Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"));

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == Guid.Parse("cdd31f4b-34d9-44ea-a30b-02d8be5022c7"));

            result.ShouldBeNull();
        }
    }
}