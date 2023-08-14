using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPairsAppService _companyJobPairsAppService;
        private readonly IRepository<CompanyJobPair, Guid> _companyJobPairRepository;

        public CompanyJobPairsAppServiceTests()
        {
            _companyJobPairsAppService = GetRequiredService<ICompanyJobPairsAppService>();
            _companyJobPairRepository = GetRequiredService<IRepository<CompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetListAsync(new GetCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c033aa93-a3c1-4440-9fc1-6337f2f72d32")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetAsync(Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPairCreateDto
            {
                CompanyMainId = Guid.Parse("2d48b530-ebed-4961-8c33-efb636762f98"),
                Name = "8e01f3285d07475cab5142f603b4d84b39f9e1ad2f3b47ff8e",
                PairCondition = "7974e2ef7f9c47ad96cc4a79b5707691e5eaec192daa4152b878e6300cb8ab45c08335aa6cb842e4b159db5658f3127d6145a7af63584a2fa05d2dda0ec4bfdd44fb22f90abb4322971b3a75bb04fb836eec47192bd54d519fc7ef2c6b78b7ead2afd6927b5344db816c71aebbad7ee4825210c457b74dedadac7527679f62e1db5429aa6b7c47bb8ed71746e2b762c71232d89aa84546d98d078a477acdebc52c0c3f4cd41745808dc160346217cea87abbf2f0f176415996f2bd1a887e358c2e6dba7518df4b2889b0a3d01cb2c9ad8a31654295f047a4963f5eba0ea850db40df89d86c7b4a5f8e368e8d2e57b5877b8178a7f0a9478d9f9b",
                ExtendedInformation = "c385f02487044d9e82e88b7a06c7a14279ddd196ae9e44229477b16b64f0de882b89b31d55fc4116aab5e498d5e361be8fc4ef534e344e199def54653c98513272ab3369675b48cb9ca9ce8f964b472f8821e0a2cdc24c4bbfe5cddd9ecbdca6c4357247186447d8a2126f9646fb4248987ce51948c74e4e980b1ef69a523920b8662536a75f4f0a9bbceafd25831d387cb923fd205f4a568c627b3ec4c3e023e807af3c6d1245248f1893ccf467faf6ace8d392065b4f3598931746b2fe19cbd1ea8a8ff57d405aa7a097fd42cbf1a4db94d6d8f36645b8a64f074fef3a70961b5c62a26bad4bb6bf35b7c5d5950932e7f2ea70e6a84eb7893e",
                DateA = new DateTime(2018, 5, 8),
                DateD = new DateTime(2012, 2, 13),
                Sort = 1884127490,
                Note = "ce913b3d45f948adb4697f1e37c82ac9cfef23e1fa84431f958ea13c932e1eaebc0d3b1041c440f9b5a7ddb9ab2679442eddd7ac54304dd6a839441335b379ba5c5055f952374ae49e7e9caefc6879f4bd2dfec65f0f48b5bc11421d75ea59d4dd089b982c9048cbaf2f8ee363d66e0a0639bf2e5eb7477e989c7cc2d4005eb63471b9a911da4d05b6eb17aa917ed150ad09526fe1af4514978a36cb2b053e9f3c5230a484224f13b5911f45cb71daf3ddd9ab6e8a9e488cb974b6f5dfaae2458e5a381953e240cda7e8277eeb5e007c48745594936d4238a5c6d79c6963499f44695c761d9244089acc00c994a5e78b15eb2006f23f4df0ac3f",
                Status = "b215ffa9f95d4225a0dd6890c1620290469b9b63773d41ceb1"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("2d48b530-ebed-4961-8c33-efb636762f98"));
            result.Name.ShouldBe("8e01f3285d07475cab5142f603b4d84b39f9e1ad2f3b47ff8e");
            result.PairCondition.ShouldBe("7974e2ef7f9c47ad96cc4a79b5707691e5eaec192daa4152b878e6300cb8ab45c08335aa6cb842e4b159db5658f3127d6145a7af63584a2fa05d2dda0ec4bfdd44fb22f90abb4322971b3a75bb04fb836eec47192bd54d519fc7ef2c6b78b7ead2afd6927b5344db816c71aebbad7ee4825210c457b74dedadac7527679f62e1db5429aa6b7c47bb8ed71746e2b762c71232d89aa84546d98d078a477acdebc52c0c3f4cd41745808dc160346217cea87abbf2f0f176415996f2bd1a887e358c2e6dba7518df4b2889b0a3d01cb2c9ad8a31654295f047a4963f5eba0ea850db40df89d86c7b4a5f8e368e8d2e57b5877b8178a7f0a9478d9f9b");
            result.ExtendedInformation.ShouldBe("c385f02487044d9e82e88b7a06c7a14279ddd196ae9e44229477b16b64f0de882b89b31d55fc4116aab5e498d5e361be8fc4ef534e344e199def54653c98513272ab3369675b48cb9ca9ce8f964b472f8821e0a2cdc24c4bbfe5cddd9ecbdca6c4357247186447d8a2126f9646fb4248987ce51948c74e4e980b1ef69a523920b8662536a75f4f0a9bbceafd25831d387cb923fd205f4a568c627b3ec4c3e023e807af3c6d1245248f1893ccf467faf6ace8d392065b4f3598931746b2fe19cbd1ea8a8ff57d405aa7a097fd42cbf1a4db94d6d8f36645b8a64f074fef3a70961b5c62a26bad4bb6bf35b7c5d5950932e7f2ea70e6a84eb7893e");
            result.DateA.ShouldBe(new DateTime(2018, 5, 8));
            result.DateD.ShouldBe(new DateTime(2012, 2, 13));
            result.Sort.ShouldBe(1884127490);
            result.Note.ShouldBe("ce913b3d45f948adb4697f1e37c82ac9cfef23e1fa84431f958ea13c932e1eaebc0d3b1041c440f9b5a7ddb9ab2679442eddd7ac54304dd6a839441335b379ba5c5055f952374ae49e7e9caefc6879f4bd2dfec65f0f48b5bc11421d75ea59d4dd089b982c9048cbaf2f8ee363d66e0a0639bf2e5eb7477e989c7cc2d4005eb63471b9a911da4d05b6eb17aa917ed150ad09526fe1af4514978a36cb2b053e9f3c5230a484224f13b5911f45cb71daf3ddd9ab6e8a9e488cb974b6f5dfaae2458e5a381953e240cda7e8277eeb5e007c48745594936d4238a5c6d79c6963499f44695c761d9244089acc00c994a5e78b15eb2006f23f4df0ac3f");
            result.Status.ShouldBe("b215ffa9f95d4225a0dd6890c1620290469b9b63773d41ceb1");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPairUpdateDto()
            {
                CompanyMainId = Guid.Parse("3861b33b-037a-48fb-acfe-734126d5c16a"),
                Name = "c325dab48e37499e9e78fc298d77a829131a764eb36b49e795",
                PairCondition = "b47245fa46954c63b227a39ad7ad00f5518d58af105545b295f98138bf4f09ac9b112879cb9d4dc087dea8337976bdf3f6760e7a8d38409d9a33de2996c77b11353b6f7babd14552b7cc186b29f54075f1aca98d0a6141f1ab09fdf0306a8ef864e7d2d7ffd44d39945decbf2b4b9779237be230030b49309b2568886fe0fd5a8ec4b604d5a4428392aed24b7b2222283e0510a7a9de494ebbd4557a6ae851d893b452a393534919934ec02735802acb9243fe3ac03c4307b18aa96b19b1ad47febd854d49c5421080e39254f091b4a721191b05a0c5417c95278220a9a4921d711a7c3a1ece46a4bfd9e948e8d431f97a834d1a1bb74c848c1a",
                ExtendedInformation = "9e3b1078782f45a69cfd235b7e5498505069c11fffb541169e79095d12cad3af469ca8b848984cee9a2874dee74d9fa9a286677884d4420989580c50e44112ddbbe21a1dec0546f781fcb394503e8cf9a5d2fd73332c4cb2aa15fecdd4d266acdfe6baca8a9b465788abc0b7543894ab321302f2b8a341a5b41898f4efaacd381197dd27480648aa8e66c036794b4aab2df4d855920640f59f8e3530f31107cfbe9712645d414d4d8a3087e4546a0de0a56febea3f214b3a814abece7682c88801089ca218f946d38abd21b0277f602a563de978333a4cbc9f2edc29b149e6c46ff4f2025d52433d88e4a7f21b61123699d39f76bdb84a06a8dc",
                DateA = new DateTime(2013, 2, 25),
                DateD = new DateTime(2019, 9, 2),
                Sort = 2114214049,
                Note = "2fefca011932466c8c85d5c6327fbd2cb862aab345184bc8aaac8c755ff53e01951830359c184410bf63d4fc82f2e9d120d1287b61f945db82700a0e451a6339e94c9dc4f0b74256974beb9a42a0579c77a12d08b15a49eba212e466fb64711b96ca4f84698a42349113d46df5da364df68f0555d2854fbc9ecc9731cbd24d8285664db6ef82455d9f688ea694bd51e72094799749c544e3801d3bf7d13f913ed3efdd40d0234e8aa5f04a566d32412eb61fc5ea356446038bb5d389a73c05d7b08f449a86184d78afeda50be444e02fe3ab43b965e64ac5b2179d6581ab7b539648cd0e98a74cfaa63eae9eaa0cbd688a2b0f75f6a2463ba56d",
                Status = "8806b4b062b54f908f4ee8a4775c6d1324541f9147744fdab6"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.UpdateAsync(Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"), input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("3861b33b-037a-48fb-acfe-734126d5c16a"));
            result.Name.ShouldBe("c325dab48e37499e9e78fc298d77a829131a764eb36b49e795");
            result.PairCondition.ShouldBe("b47245fa46954c63b227a39ad7ad00f5518d58af105545b295f98138bf4f09ac9b112879cb9d4dc087dea8337976bdf3f6760e7a8d38409d9a33de2996c77b11353b6f7babd14552b7cc186b29f54075f1aca98d0a6141f1ab09fdf0306a8ef864e7d2d7ffd44d39945decbf2b4b9779237be230030b49309b2568886fe0fd5a8ec4b604d5a4428392aed24b7b2222283e0510a7a9de494ebbd4557a6ae851d893b452a393534919934ec02735802acb9243fe3ac03c4307b18aa96b19b1ad47febd854d49c5421080e39254f091b4a721191b05a0c5417c95278220a9a4921d711a7c3a1ece46a4bfd9e948e8d431f97a834d1a1bb74c848c1a");
            result.ExtendedInformation.ShouldBe("9e3b1078782f45a69cfd235b7e5498505069c11fffb541169e79095d12cad3af469ca8b848984cee9a2874dee74d9fa9a286677884d4420989580c50e44112ddbbe21a1dec0546f781fcb394503e8cf9a5d2fd73332c4cb2aa15fecdd4d266acdfe6baca8a9b465788abc0b7543894ab321302f2b8a341a5b41898f4efaacd381197dd27480648aa8e66c036794b4aab2df4d855920640f59f8e3530f31107cfbe9712645d414d4d8a3087e4546a0de0a56febea3f214b3a814abece7682c88801089ca218f946d38abd21b0277f602a563de978333a4cbc9f2edc29b149e6c46ff4f2025d52433d88e4a7f21b61123699d39f76bdb84a06a8dc");
            result.DateA.ShouldBe(new DateTime(2013, 2, 25));
            result.DateD.ShouldBe(new DateTime(2019, 9, 2));
            result.Sort.ShouldBe(2114214049);
            result.Note.ShouldBe("2fefca011932466c8c85d5c6327fbd2cb862aab345184bc8aaac8c755ff53e01951830359c184410bf63d4fc82f2e9d120d1287b61f945db82700a0e451a6339e94c9dc4f0b74256974beb9a42a0579c77a12d08b15a49eba212e466fb64711b96ca4f84698a42349113d46df5da364df68f0555d2854fbc9ecc9731cbd24d8285664db6ef82455d9f688ea694bd51e72094799749c544e3801d3bf7d13f913ed3efdd40d0234e8aa5f04a566d32412eb61fc5ea356446038bb5d389a73c05d7b08f449a86184d78afeda50be444e02fe3ab43b965e64ac5b2179d6581ab7b539648cd0e98a74cfaa63eae9eaa0cbd688a2b0f75f6a2463ba56d");
            result.Status.ShouldBe("8806b4b062b54f908f4ee8a4775c6d1324541f9147744fdab6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPairsAppService.DeleteAsync(Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"));

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("5ba3bd8a-5762-4215-b0e4-6cd1a7585653"));

            result.ShouldBeNull();
        }
    }
}