using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobLanguageConditions
{
    public class CompanyJobLanguageConditionsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobLanguageConditionsAppService _companyJobLanguageConditionsAppService;
        private readonly IRepository<CompanyJobLanguageCondition, Guid> _companyJobLanguageConditionRepository;

        public CompanyJobLanguageConditionsAppServiceTests()
        {
            _companyJobLanguageConditionsAppService = GetRequiredService<ICompanyJobLanguageConditionsAppService>();
            _companyJobLanguageConditionRepository = GetRequiredService<IRepository<CompanyJobLanguageCondition, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobLanguageConditionsAppService.GetListAsync(new GetCompanyJobLanguageConditionsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("277c778a-c6fd-433c-9753-d46aa79c9c85")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobLanguageConditionsAppService.GetAsync(Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobLanguageConditionCreateDto
            {
                CompanyMainId = Guid.Parse("797c2286-ad53-49a1-b281-4a7dc1cc0ff9"),
                CompanyJobId = Guid.Parse("fe70d03f-72a8-4b52-9b0c-f8c8defa9291"),
                LanguageCategoryCode = "9b4c4a8212b84c198a0d74e723bec6df699854d3e6fe41edb4",
                LevelSayCode = "0f6c4444ce6c415cbc1bc3c692d8911af3289358891c43f085",
                LevelListenCode = "23e57639b4ab44338895d537205dd0dd26113ea302174c4782",
                LevelReadCode = "50f7410c4eb54bb2b2fc2b8511721a7ae5842d07b84f4d02b0",
                LevelWriteCode = "8f5e08123d454b0fb2e7a9cf9c02d7aee978f51a383e46a6a9",
                ExtendedInformation = "498e0ac5728341a394341a83eb77040b214cf3748a1c4894949f8ea9147b78d236ae9e8d8b404996910f9f46ead76195af751887b3784c0e84494f89f7bbe9ad973592063d2b4f659847dd3a1fb25392838c04200316421d9ad604224e7b9c2927a94c67b61e49148f8ce6323922d58791d52fd7ac784efa94586fc657a69352c1902b0e4fbf42548548660359d1ce61dccc3b3711d649a39eaa91b181b26ec50195be970a394640a663ada8928022b371d2692203a6436794c40684e9fa90eb62da733580e643b5a58354b7a5629b0c7103d25f687d42cc93d5e376d4a403b3488b5b6db5b94d6ea2db0709c024a94f7da428cadb9b4461834f",
                DateA = new DateTime(2022, 9, 19),
                DateD = new DateTime(2022, 11, 17),
                Sort = 1721133575,
                Note = "805855abeaaa48dc95bc833544c1536aca130a486e1241d5a307c409c434336bae77ece574a549a78c7ce6424fedf7088b83f88f7fcd4188941512f3771f0d9ae8c6f98dcf5449339068bf8ce0a931ebfc7b14092f61470884ad931c900b6b223bfb9e3c488b439386bf9798b91a909a784d59f37092444f9b43891a82e9cde365c3db0055ed46d99490cf74f66d6629ad1e0227bf9e4e8a8b6103d4c09758a716403df23b794c5b851ca91673ac16aae5f1e883931a431da398ae0cf1ed33e2126367f338414b2dabc095d8ee248b84e9f22f5d2dda4a2e8f1422a4a8dfaee10d5cf7d989b849668b602434442f107a617817b8d7694eeca045",
                Status = "e9d54a3111e64a9c9c121af87c0de9fa82dafc3e5aa94e51be"
            };

            // Act
            var serviceResult = await _companyJobLanguageConditionsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobLanguageConditionRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("797c2286-ad53-49a1-b281-4a7dc1cc0ff9"));
            result.CompanyJobId.ShouldBe(Guid.Parse("fe70d03f-72a8-4b52-9b0c-f8c8defa9291"));
            result.LanguageCategoryCode.ShouldBe("9b4c4a8212b84c198a0d74e723bec6df699854d3e6fe41edb4");
            result.LevelSayCode.ShouldBe("0f6c4444ce6c415cbc1bc3c692d8911af3289358891c43f085");
            result.LevelListenCode.ShouldBe("23e57639b4ab44338895d537205dd0dd26113ea302174c4782");
            result.LevelReadCode.ShouldBe("50f7410c4eb54bb2b2fc2b8511721a7ae5842d07b84f4d02b0");
            result.LevelWriteCode.ShouldBe("8f5e08123d454b0fb2e7a9cf9c02d7aee978f51a383e46a6a9");
            result.ExtendedInformation.ShouldBe("498e0ac5728341a394341a83eb77040b214cf3748a1c4894949f8ea9147b78d236ae9e8d8b404996910f9f46ead76195af751887b3784c0e84494f89f7bbe9ad973592063d2b4f659847dd3a1fb25392838c04200316421d9ad604224e7b9c2927a94c67b61e49148f8ce6323922d58791d52fd7ac784efa94586fc657a69352c1902b0e4fbf42548548660359d1ce61dccc3b3711d649a39eaa91b181b26ec50195be970a394640a663ada8928022b371d2692203a6436794c40684e9fa90eb62da733580e643b5a58354b7a5629b0c7103d25f687d42cc93d5e376d4a403b3488b5b6db5b94d6ea2db0709c024a94f7da428cadb9b4461834f");
            result.DateA.ShouldBe(new DateTime(2022, 9, 19));
            result.DateD.ShouldBe(new DateTime(2022, 11, 17));
            result.Sort.ShouldBe(1721133575);
            result.Note.ShouldBe("805855abeaaa48dc95bc833544c1536aca130a486e1241d5a307c409c434336bae77ece574a549a78c7ce6424fedf7088b83f88f7fcd4188941512f3771f0d9ae8c6f98dcf5449339068bf8ce0a931ebfc7b14092f61470884ad931c900b6b223bfb9e3c488b439386bf9798b91a909a784d59f37092444f9b43891a82e9cde365c3db0055ed46d99490cf74f66d6629ad1e0227bf9e4e8a8b6103d4c09758a716403df23b794c5b851ca91673ac16aae5f1e883931a431da398ae0cf1ed33e2126367f338414b2dabc095d8ee248b84e9f22f5d2dda4a2e8f1422a4a8dfaee10d5cf7d989b849668b602434442f107a617817b8d7694eeca045");
            result.Status.ShouldBe("e9d54a3111e64a9c9c121af87c0de9fa82dafc3e5aa94e51be");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobLanguageConditionUpdateDto()
            {
                CompanyMainId = Guid.Parse("0841d6f3-5e6e-4001-bc23-4679de0b95d7"),
                CompanyJobId = Guid.Parse("9fa7dc78-4a5e-4c5a-8c8a-fadd35113b8f"),
                LanguageCategoryCode = "7cdb8b90644c44049be22942cf4fa0394f959888597443ddad",
                LevelSayCode = "5ed27add42d642f881d9d6b5e6b46c48c97f5ab8618b4685b5",
                LevelListenCode = "9bf1564517a041ab9f39273d1dc17e79fc9e25152cf248e696",
                LevelReadCode = "7e2f55234d494457ad3c1b620b918a6b28580b929753435a93",
                LevelWriteCode = "462ee9f068cf407f9697f62f5bbc9bf835c11413b61e425b91",
                ExtendedInformation = "a027857ddc224647afafc74da3766f44c2b9dcea2a3d48d38e8f222f965846c573fca98813264fe0a637fde9ba280c971b6f8dfe532b471b8e2688dc77c5336c5f52201a308e4b93923441b6e7af41678fa8b2acdb884851a121dea851dd9541241aa28c8fcc4139992529802092158a854166a78f8a4f7b97b6edc8572e007ed2efc9e7b18c4912b6001e35a75007634549912e35ea4effa9b56b9e91b63c7ecd2f94d17a9a41b08c2adcd76dedc76fc24c89689adc4c1fbaa1cb087c75f7e626a95a99d575409694d062ea4cfa658f7b022259d3ac4f13ba4ef4eb7ff570a2e03e3ddb77fb4d61a2078a790e479828ff7be59f018748c8bd9a",
                DateA = new DateTime(2017, 6, 4),
                DateD = new DateTime(2008, 1, 16),
                Sort = 489732346,
                Note = "91ed75651043431e8cd4d8117e20ac99ee1de6522d57429c86e3c699fecf60a8e935189803344d77a32483a361f6a9fcc43d48964caf437eae82069dbecec6e3196fcd4c6f2e46a985d4532b7a294669720f12500d9c4f9fa2b167c6ace92314d459f979d27246ae9b88fdd21d97dd120547151401e94c608910ecfd136a61e85bb2f0543ce74afaa22c830a7a5dbbd3529c6be54fb34a3f83403163e204938cdf61074583da4b7eac62efe759fa3e8d0c5a3fa213734b56a74a3239921811174e3c54a38a664810b359e57b0746ce46e252c10d547b43af9feee0ebc589f3c50cde35f22604477b94d65b8a82406f1b8f994e1657064afc9b5d",
                Status = "f319b0fc1100446cae8d9ea3823e777f9808cbfa4a4a41a684"
            };

            // Act
            var serviceResult = await _companyJobLanguageConditionsAppService.UpdateAsync(Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"), input);

            // Assert
            var result = await _companyJobLanguageConditionRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("0841d6f3-5e6e-4001-bc23-4679de0b95d7"));
            result.CompanyJobId.ShouldBe(Guid.Parse("9fa7dc78-4a5e-4c5a-8c8a-fadd35113b8f"));
            result.LanguageCategoryCode.ShouldBe("7cdb8b90644c44049be22942cf4fa0394f959888597443ddad");
            result.LevelSayCode.ShouldBe("5ed27add42d642f881d9d6b5e6b46c48c97f5ab8618b4685b5");
            result.LevelListenCode.ShouldBe("9bf1564517a041ab9f39273d1dc17e79fc9e25152cf248e696");
            result.LevelReadCode.ShouldBe("7e2f55234d494457ad3c1b620b918a6b28580b929753435a93");
            result.LevelWriteCode.ShouldBe("462ee9f068cf407f9697f62f5bbc9bf835c11413b61e425b91");
            result.ExtendedInformation.ShouldBe("a027857ddc224647afafc74da3766f44c2b9dcea2a3d48d38e8f222f965846c573fca98813264fe0a637fde9ba280c971b6f8dfe532b471b8e2688dc77c5336c5f52201a308e4b93923441b6e7af41678fa8b2acdb884851a121dea851dd9541241aa28c8fcc4139992529802092158a854166a78f8a4f7b97b6edc8572e007ed2efc9e7b18c4912b6001e35a75007634549912e35ea4effa9b56b9e91b63c7ecd2f94d17a9a41b08c2adcd76dedc76fc24c89689adc4c1fbaa1cb087c75f7e626a95a99d575409694d062ea4cfa658f7b022259d3ac4f13ba4ef4eb7ff570a2e03e3ddb77fb4d61a2078a790e479828ff7be59f018748c8bd9a");
            result.DateA.ShouldBe(new DateTime(2017, 6, 4));
            result.DateD.ShouldBe(new DateTime(2008, 1, 16));
            result.Sort.ShouldBe(489732346);
            result.Note.ShouldBe("91ed75651043431e8cd4d8117e20ac99ee1de6522d57429c86e3c699fecf60a8e935189803344d77a32483a361f6a9fcc43d48964caf437eae82069dbecec6e3196fcd4c6f2e46a985d4532b7a294669720f12500d9c4f9fa2b167c6ace92314d459f979d27246ae9b88fdd21d97dd120547151401e94c608910ecfd136a61e85bb2f0543ce74afaa22c830a7a5dbbd3529c6be54fb34a3f83403163e204938cdf61074583da4b7eac62efe759fa3e8d0c5a3fa213734b56a74a3239921811174e3c54a38a664810b359e57b0746ce46e252c10d547b43af9feee0ebc589f3c50cde35f22604477b94d65b8a82406f1b8f994e1657064afc9b5d");
            result.Status.ShouldBe("f319b0fc1100446cae8d9ea3823e777f9808cbfa4a4a41a684");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobLanguageConditionsAppService.DeleteAsync(Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"));

            // Assert
            var result = await _companyJobLanguageConditionRepository.FindAsync(c => c.Id == Guid.Parse("7327c408-6efa-4969-b93e-e2874e9359fd"));

            result.ShouldBeNull();
        }
    }
}