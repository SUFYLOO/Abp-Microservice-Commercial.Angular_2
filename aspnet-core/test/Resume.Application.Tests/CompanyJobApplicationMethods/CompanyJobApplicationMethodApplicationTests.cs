using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobApplicationMethodsAppService _companyJobApplicationMethodsAppService;
        private readonly IRepository<CompanyJobApplicationMethod, Guid> _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodsAppServiceTests()
        {
            _companyJobApplicationMethodsAppService = GetRequiredService<ICompanyJobApplicationMethodsAppService>();
            _companyJobApplicationMethodRepository = GetRequiredService<IRepository<CompanyJobApplicationMethod, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetListAsync(new GetCompanyJobApplicationMethodsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3bd8791e-a8b6-48a5-8c4a-ce0da6f7ac67")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetAsync(Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodCreateDto
            {
                CompanyMainId = Guid.Parse("5e8ec77e-6069-4cd3-a441-7e6388b92be2"),
                CompanyJobId = Guid.Parse("8f9d1472-79a7-4222-b204-14672199e85b"),
                OrgDept = "628a387b27154ce0a5ee9cc9e2888ece8392a78183c34a3f91ed38acc0391a04bf45fa040a3443b9aa95e7cdf98ff464c205b097ca5348f58bf34d10dfbf4262909dcb77faf94ab7b4e3b913a01b5c7aab26ea32ad4d40caa06c38333acc72801a2fffba929446c48401c9b53d223f50e4a18eb8dcbc401ca695d9bb28604a3157bbc895fff94f88bb08524254b6be8e90c81f8f70a94f89bdcad7cee89b3cb8e7e3cd6fa06b4d4ba356ba758a76d63e4911c746002144e99b6f78fa5de7baabdaf5da8bcfc24296ac68a5ebcaf8a02cf1adf46327ab417d9f1ab3f9de723030a6bce9ed6236409281295f8ba128d83e5a4b094541274c00ad23",
                OrgContactPerson = "1573591d415c4168945d15b0fa9c2cfdac5c64d727334e43be",
                OrgContactMail = "e8b9ea7f85784c4f90ac0b7da7d2bb9037249b2e39624dadb1c04758ae68ba8ca6bb68849004420482c1d88397d4aa48e9b3d8050d2f4fde8f9929df5898c5f3b615d0b7babd4ed5b8d9dc0cef357eef7f53a6b73e054bd2b78f4c1be3203de71138129bad6f420aaba170691bd9f32616b1a31b146c419899297a9897bc7dd3012de973b17f4843878cf086442ce5cf4d2c7bcf0129431aabfc7e3583117ae0089b1da89d424193a088f1964a0a30803270fc323c9147f3bb2450e9cffc6cd0379f750daafe41b1af8996439cc9ccd2492bec78afda4d729dba4ef547076bfe73b8b0b9c9d345c9b30a48625e3315fd261695ede6704ea2a193",
                ToRespondDay = 1275387437,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "a2f08eba88774039a18a27880d09fd15b44384786bf449a293",
                Personally = "ff21df10431c43ebb066681a5972578175e1809f720a44dda0760468cd5f7b49f060daf31ddb49858623f2539cfa7e806925151e065c43038d05635e4d8abe1f55a2426271e44e029dffae716096a7be63588e6fee0745f08954c089d03febf40ff6c6b5",
                PersonallyAddress = "29f991f17d524fa6b48337a9d3cf16b16670d0b609a9463e8e39d74ed0a60aa2a1976892100540899f6a95b26accda5a85903b27e921407b852fdfe276aa34d94b5fbe89a4ea4a829818015ab487edb2955922d649774948bab0570607b8c2d3a7b5bb5b",
                ExtendedInformation = "614c3fd7177c4356bc1aa996988d955e28d56d2fbb9c4135b4fd84dbc79d2f2f50dd269bd7f44bcab2a7e39d6b05932c9d3e469eccd945358ce29116e58464b25c920c7b00b247859a3479052ce7e19db081b42a780e4930bcf1675d12b6056c16d364ff96284b9d98449ae6c5cea73dea0c4d8e77ea490c8d4c6879ffea7034919afd6705414e54a9d43eb5b2d2558c80d36a1563a1442d8fcb4ab8ff9f5ffd47290c6b31244f2886d0e18274c9602cfbb8665b07f349aa87a2b9717b557411b9413e502f0d4d4eaf187a171ce6fab8a262664ec47043c1afce7fe4ef0e39b83373f7da746344849819a93e04549371fd6c5870775c4510b120",
                DateA = new DateTime(2013, 9, 25),
                DateD = new DateTime(2016, 2, 15),
                Sort = 1035936839,
                Note = "3a66c6e42f7043d8a8f5ecf089be9a5c908facbf26f64ede87e0c363f49496a03fe71cfab04c4c0386683c93ee7403d94c7ad9e7b8404f4d9bdf7b00e138bebfe8468942447848e3b0917b3c3961d71d9dbe07a6cc2f44718ffe00b20c46a3621ff7f2d7eada4cfbaf06801892836a25ace0b1fdc42446ada7b08d787d1eaed73765bacd8a064acfb38ae452fb3b284149cc8ae4f54e48f88534db41c18991ca0c0114f8ca024a05ba0bb37a85008cca330c458a22564bb1bd8ae7b11e20535025b6f1f7ba604981bbb13b682af58e1cf4e68bb289f1425cb08b3bdf757e93a66821c73442ad428da0d4381cf4964e946951584e5fee448b90c9",
                Status = "fc044866743f4d0f972bc6a6cc841d0591f207f0005346bbaf"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("5e8ec77e-6069-4cd3-a441-7e6388b92be2"));
            result.CompanyJobId.ShouldBe(Guid.Parse("8f9d1472-79a7-4222-b204-14672199e85b"));
            result.OrgDept.ShouldBe("628a387b27154ce0a5ee9cc9e2888ece8392a78183c34a3f91ed38acc0391a04bf45fa040a3443b9aa95e7cdf98ff464c205b097ca5348f58bf34d10dfbf4262909dcb77faf94ab7b4e3b913a01b5c7aab26ea32ad4d40caa06c38333acc72801a2fffba929446c48401c9b53d223f50e4a18eb8dcbc401ca695d9bb28604a3157bbc895fff94f88bb08524254b6be8e90c81f8f70a94f89bdcad7cee89b3cb8e7e3cd6fa06b4d4ba356ba758a76d63e4911c746002144e99b6f78fa5de7baabdaf5da8bcfc24296ac68a5ebcaf8a02cf1adf46327ab417d9f1ab3f9de723030a6bce9ed6236409281295f8ba128d83e5a4b094541274c00ad23");
            result.OrgContactPerson.ShouldBe("1573591d415c4168945d15b0fa9c2cfdac5c64d727334e43be");
            result.OrgContactMail.ShouldBe("e8b9ea7f85784c4f90ac0b7da7d2bb9037249b2e39624dadb1c04758ae68ba8ca6bb68849004420482c1d88397d4aa48e9b3d8050d2f4fde8f9929df5898c5f3b615d0b7babd4ed5b8d9dc0cef357eef7f53a6b73e054bd2b78f4c1be3203de71138129bad6f420aaba170691bd9f32616b1a31b146c419899297a9897bc7dd3012de973b17f4843878cf086442ce5cf4d2c7bcf0129431aabfc7e3583117ae0089b1da89d424193a088f1964a0a30803270fc323c9147f3bb2450e9cffc6cd0379f750daafe41b1af8996439cc9ccd2492bec78afda4d729dba4ef547076bfe73b8b0b9c9d345c9b30a48625e3315fd261695ede6704ea2a193");
            result.ToRespondDay.ShouldBe(1275387437);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("a2f08eba88774039a18a27880d09fd15b44384786bf449a293");
            result.Personally.ShouldBe("ff21df10431c43ebb066681a5972578175e1809f720a44dda0760468cd5f7b49f060daf31ddb49858623f2539cfa7e806925151e065c43038d05635e4d8abe1f55a2426271e44e029dffae716096a7be63588e6fee0745f08954c089d03febf40ff6c6b5");
            result.PersonallyAddress.ShouldBe("29f991f17d524fa6b48337a9d3cf16b16670d0b609a9463e8e39d74ed0a60aa2a1976892100540899f6a95b26accda5a85903b27e921407b852fdfe276aa34d94b5fbe89a4ea4a829818015ab487edb2955922d649774948bab0570607b8c2d3a7b5bb5b");
            result.ExtendedInformation.ShouldBe("614c3fd7177c4356bc1aa996988d955e28d56d2fbb9c4135b4fd84dbc79d2f2f50dd269bd7f44bcab2a7e39d6b05932c9d3e469eccd945358ce29116e58464b25c920c7b00b247859a3479052ce7e19db081b42a780e4930bcf1675d12b6056c16d364ff96284b9d98449ae6c5cea73dea0c4d8e77ea490c8d4c6879ffea7034919afd6705414e54a9d43eb5b2d2558c80d36a1563a1442d8fcb4ab8ff9f5ffd47290c6b31244f2886d0e18274c9602cfbb8665b07f349aa87a2b9717b557411b9413e502f0d4d4eaf187a171ce6fab8a262664ec47043c1afce7fe4ef0e39b83373f7da746344849819a93e04549371fd6c5870775c4510b120");
            result.DateA.ShouldBe(new DateTime(2013, 9, 25));
            result.DateD.ShouldBe(new DateTime(2016, 2, 15));
            result.Sort.ShouldBe(1035936839);
            result.Note.ShouldBe("3a66c6e42f7043d8a8f5ecf089be9a5c908facbf26f64ede87e0c363f49496a03fe71cfab04c4c0386683c93ee7403d94c7ad9e7b8404f4d9bdf7b00e138bebfe8468942447848e3b0917b3c3961d71d9dbe07a6cc2f44718ffe00b20c46a3621ff7f2d7eada4cfbaf06801892836a25ace0b1fdc42446ada7b08d787d1eaed73765bacd8a064acfb38ae452fb3b284149cc8ae4f54e48f88534db41c18991ca0c0114f8ca024a05ba0bb37a85008cca330c458a22564bb1bd8ae7b11e20535025b6f1f7ba604981bbb13b682af58e1cf4e68bb289f1425cb08b3bdf757e93a66821c73442ad428da0d4381cf4964e946951584e5fee448b90c9");
            result.Status.ShouldBe("fc044866743f4d0f972bc6a6cc841d0591f207f0005346bbaf");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodUpdateDto()
            {
                CompanyMainId = Guid.Parse("3afe2808-3dc4-445b-a85a-59fd6ec29d14"),
                CompanyJobId = Guid.Parse("bbdf2fba-756a-4fab-b25b-404511f6baee"),
                OrgDept = "75505a88f7754e0a9fd8141f8a494585806498c9efc6427f91c7ef61c6f9957fd38b264804484f8b8b4090a517987242ca0c4b4030d04f7b9f089225927b1a7a29dd34fb369c490680461d541b7b89302f4470ae1687429fbfabda411b3f0fa7875dcdaa55194391a1fc068b771b13ced883826b36294a828a8300e43310a213653f67520d0b42449148168d6a36871503b5164422034b08aaf05426f6e1b628b5fd120cd5334debad24dd97cf04052966d558ed2aac4e0c907ccc6ad51792eaf33858afe4c24b32a32ef469fa658626f729f4daf82a4457881d3099b32d87bf22d577597f6f458bb25b79bfebf492422c0def76ce1a4954ad84",
                OrgContactPerson = "d99c5d458183489e9d7af6cbe0704c9dcb21e1ffce8f43a1b8",
                OrgContactMail = "951acb08ae6d43bdb6b48fe47ec61fa5a8ebd9dc44e346d4821d57f4a511347771db3375bbc44e8ca3038825df0353d4155ba97ea16e46699c8bd272f53a6427b64dd9a04fb04686a1e690b02982e02ad62f8bca8dc64c9b9d6af90af6db58291d331d9503e643818239d2549d19c09e12d8898e125a4f4e9bbde8414f5072a5fde3da57cb334cb18242dd983873d956a4aa431475554f9db03f07ac501b4d490155be7be65c47539e52f0c114fa354f7a44ef0c52984a119b96c85079df74f87168951a211d4e459a52155c9eda3f876aae6ce852e44910b19dc151d894604cd65ac2b58f584acb914c61d36ba5de9864d6948d0c7b4c2da806",
                ToRespondDay = 49599516,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "1b539578a9b944b584bff854de108d4750cba0bdf1b9431faa",
                Personally = "af7adb91836847fc8420ef5e16aa48752bee5bc155fb4a46a801a325f101b80833f7b255426f490c9ebc1fdaa9eeb56a87c664774c734015802c92a0f314d860382d5aaa78a84beca6bd41fda0ceed99ae1b0ab00c3a4f73ba94a8583703e1a634bb9f7b",
                PersonallyAddress = "506c2217030547d89ce2b5cd82c7082547e773eed4e04cb5b55720f8d9ca5890deb0298affe44b80abc12f3df7cf5392e6c94a6da5074e0b9efb89d799b627307b403fc29dc1452f95d6b7e0d67b36eb7714f59ea3ea42a4a37550abed2ddf6bf7d48b0c",
                ExtendedInformation = "a220c0bbb8ec4922a7e92ff20e7f5a983da907ae56cd4c03962240da71221e869979f0ffeb3c496ca15e7fbdb06c16469d4c7f4da4a54655bfeacc8cc7de80bd38aebc88c7914cbf991d401e7a255b815f2670398b2f414784da0b3593812bed80aad80098454f7eac214ec9464cea91ef6c57340f5f4aee92f29106278dca0bd58d496ffef448ea9ae0889c1fc566ed84996569d555422594564a74fd9b783760f088cd86cb4e61a3bc53416bbb2dd9314b221771c4483db2575750fb9549c478c3d41e703e4f7a82a9fe91ae66409cb4b1389eb7e544369560bc94e88585372dacb1ff25b34028ba284172dc2cdf25b1c784d719c0435cac68",
                DateA = new DateTime(2021, 6, 15),
                DateD = new DateTime(2003, 10, 18),
                Sort = 404771652,
                Note = "c5f445c79115453d90586111099a0de2f8b520d8cd364f06bbb9dc5dc1c39b7db24db0a7af6844c2811a9d1e5dc112b7c6f6e2010ff64165beb49f473bf3a39ff65566c04b5143c89f2bd98c085a98b5a26c1dc49945455486999c14bd8c9434d52208407ef4475b9e59bcb251c78039a3f6555ef14f41fdbded09749faaf97e0baa26e690fd4f0ca71ac6cda544d756c7d4829716ed43d8a667ec2dcb39687a84e6cdd8e9dc49639a72258eed4fa3ffa5551b74cac045899b3bb7c2eab8870faddaa344bb464fc6984e22ced954d66efd385b428f564702bbec5d90c7d47e6aca56d523c82c4cd79cda509fbef1a9264ae9a2288cdf44dfbd05",
                Status = "fa9b47e8e1ad4890a9a77fc7877cacf0b82943e77aae4139af"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.UpdateAsync(Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"), input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("3afe2808-3dc4-445b-a85a-59fd6ec29d14"));
            result.CompanyJobId.ShouldBe(Guid.Parse("bbdf2fba-756a-4fab-b25b-404511f6baee"));
            result.OrgDept.ShouldBe("75505a88f7754e0a9fd8141f8a494585806498c9efc6427f91c7ef61c6f9957fd38b264804484f8b8b4090a517987242ca0c4b4030d04f7b9f089225927b1a7a29dd34fb369c490680461d541b7b89302f4470ae1687429fbfabda411b3f0fa7875dcdaa55194391a1fc068b771b13ced883826b36294a828a8300e43310a213653f67520d0b42449148168d6a36871503b5164422034b08aaf05426f6e1b628b5fd120cd5334debad24dd97cf04052966d558ed2aac4e0c907ccc6ad51792eaf33858afe4c24b32a32ef469fa658626f729f4daf82a4457881d3099b32d87bf22d577597f6f458bb25b79bfebf492422c0def76ce1a4954ad84");
            result.OrgContactPerson.ShouldBe("d99c5d458183489e9d7af6cbe0704c9dcb21e1ffce8f43a1b8");
            result.OrgContactMail.ShouldBe("951acb08ae6d43bdb6b48fe47ec61fa5a8ebd9dc44e346d4821d57f4a511347771db3375bbc44e8ca3038825df0353d4155ba97ea16e46699c8bd272f53a6427b64dd9a04fb04686a1e690b02982e02ad62f8bca8dc64c9b9d6af90af6db58291d331d9503e643818239d2549d19c09e12d8898e125a4f4e9bbde8414f5072a5fde3da57cb334cb18242dd983873d956a4aa431475554f9db03f07ac501b4d490155be7be65c47539e52f0c114fa354f7a44ef0c52984a119b96c85079df74f87168951a211d4e459a52155c9eda3f876aae6ce852e44910b19dc151d894604cd65ac2b58f584acb914c61d36ba5de9864d6948d0c7b4c2da806");
            result.ToRespondDay.ShouldBe(49599516);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("1b539578a9b944b584bff854de108d4750cba0bdf1b9431faa");
            result.Personally.ShouldBe("af7adb91836847fc8420ef5e16aa48752bee5bc155fb4a46a801a325f101b80833f7b255426f490c9ebc1fdaa9eeb56a87c664774c734015802c92a0f314d860382d5aaa78a84beca6bd41fda0ceed99ae1b0ab00c3a4f73ba94a8583703e1a634bb9f7b");
            result.PersonallyAddress.ShouldBe("506c2217030547d89ce2b5cd82c7082547e773eed4e04cb5b55720f8d9ca5890deb0298affe44b80abc12f3df7cf5392e6c94a6da5074e0b9efb89d799b627307b403fc29dc1452f95d6b7e0d67b36eb7714f59ea3ea42a4a37550abed2ddf6bf7d48b0c");
            result.ExtendedInformation.ShouldBe("a220c0bbb8ec4922a7e92ff20e7f5a983da907ae56cd4c03962240da71221e869979f0ffeb3c496ca15e7fbdb06c16469d4c7f4da4a54655bfeacc8cc7de80bd38aebc88c7914cbf991d401e7a255b815f2670398b2f414784da0b3593812bed80aad80098454f7eac214ec9464cea91ef6c57340f5f4aee92f29106278dca0bd58d496ffef448ea9ae0889c1fc566ed84996569d555422594564a74fd9b783760f088cd86cb4e61a3bc53416bbb2dd9314b221771c4483db2575750fb9549c478c3d41e703e4f7a82a9fe91ae66409cb4b1389eb7e544369560bc94e88585372dacb1ff25b34028ba284172dc2cdf25b1c784d719c0435cac68");
            result.DateA.ShouldBe(new DateTime(2021, 6, 15));
            result.DateD.ShouldBe(new DateTime(2003, 10, 18));
            result.Sort.ShouldBe(404771652);
            result.Note.ShouldBe("c5f445c79115453d90586111099a0de2f8b520d8cd364f06bbb9dc5dc1c39b7db24db0a7af6844c2811a9d1e5dc112b7c6f6e2010ff64165beb49f473bf3a39ff65566c04b5143c89f2bd98c085a98b5a26c1dc49945455486999c14bd8c9434d52208407ef4475b9e59bcb251c78039a3f6555ef14f41fdbded09749faaf97e0baa26e690fd4f0ca71ac6cda544d756c7d4829716ed43d8a667ec2dcb39687a84e6cdd8e9dc49639a72258eed4fa3ffa5551b74cac045899b3bb7c2eab8870faddaa344bb464fc6984e22ced954d66efd385b428f564702bbec5d90c7d47e6aca56d523c82c4cd79cda509fbef1a9264ae9a2288cdf44dfbd05");
            result.Status.ShouldBe("fa9b47e8e1ad4890a9a77fc7877cacf0b82943e77aae4139af");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobApplicationMethodsAppService.DeleteAsync(Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"));

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"));

            result.ShouldBeNull();
        }
    }
}