using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeLanguages
{
    public class ResumeLanguagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeLanguagesAppService _resumeLanguagesAppService;
        private readonly IRepository<ResumeLanguage, Guid> _resumeLanguageRepository;

        public ResumeLanguagesAppServiceTests()
        {
            _resumeLanguagesAppService = GetRequiredService<IResumeLanguagesAppService>();
            _resumeLanguageRepository = GetRequiredService<IRepository<ResumeLanguage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeLanguagesAppService.GetListAsync(new GetResumeLanguagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3eb9b099-5da2-4aff-8654-6f943440d5fa")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeLanguagesAppService.GetAsync(Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeLanguageCreateDto
            {
                ResumeMainId = Guid.Parse("3c3d304e-b334-4289-b804-dee073b862cf"),
                LanguageCategoryCode = "8818c70e551640d4a451fa4a8e0f0b63d052eacd0dec486d93",
                LevelSayCode = "f665a7a63a3240ed9493ca5ea0cfd68243c67a5e843e4d2c94",
                LevelListenCode = "4c34594e92074d6789b5d6689921128101e6729fdd7a4ae386",
                LevelReadCode = "02f0d3ee6f18422aada3da8bbe477185c928895f58dd435eb2",
                LevelWriteCode = "b183277cd88148b7bba8a66864f9e7900082f6c4e9ee48dd80",
                ExtendedInformation = "eaa6fbea866c4fb393583aa33f13c7b2dcf60f3242f84687971b19224d4229a1aa6224c0277f4b36ac97422ad26a158a1e7b7b7a48b0483a875a9ae36ce45ff57e011b8317764041b8a508edd8fbc9b3aad9107e3f78451c85e2cf769dfc62be14678b294b5f4b3ea4258edcc4b445309e1c1df759ae4d06932c2b6b63a48e9d5cff315ce4af49ac84ff99bcbbe93c6e64cda0c5e3044518ab8e9686947099b710f7b3d9244846d7a976c63b5c1f52f61563bff0c1cd40d9933ced831bd2abcb4779f18029ca49bf82121ad3e682d42b194a877176a54430a029cf3a3e466f446089736dbdbc40a0af2ad59828c6a428eb13645adf1a4cd7a50f",
                DateA = new DateTime(2016, 7, 23),
                DateD = new DateTime(2015, 3, 16),
                Sort = 1917777567,
                Note = "40a0652191614c5c8b9ec143d37a1359ea1596bc7cc741a2b563a83819a632d9659d741c204b46fe97af3b8305c12b78a703be1f5d43480b922d7bf53dea63c898326c6ee655400fb699298dff076c12af2fd31e6f9345c1b439f79a69f25ffa718d58992a104531a7853ac456e907fcfa7592f3f893412bb866cc5ebf16a193933c67437d804931a4a7197bd196fa73ccf909503ef64bfd954d8c2ff6b13eae8773a4b9730d4a978adef2ca9ce9929b971e181536dd4e2bac67f817bccf9ec8bcddb20583234fc88e510f4491793c1914f5402fc14f48e3a46bcf7547826911f14939b2ea56498c98fe7285c61fd1b189a43bea5686481e8821",
                Status = "b2ab474dec314c12bdf566016b3226a5ac229fb073b14010ba"
            };

            // Act
            var serviceResult = await _resumeLanguagesAppService.CreateAsync(input);

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("3c3d304e-b334-4289-b804-dee073b862cf"));
            result.LanguageCategoryCode.ShouldBe("8818c70e551640d4a451fa4a8e0f0b63d052eacd0dec486d93");
            result.LevelSayCode.ShouldBe("f665a7a63a3240ed9493ca5ea0cfd68243c67a5e843e4d2c94");
            result.LevelListenCode.ShouldBe("4c34594e92074d6789b5d6689921128101e6729fdd7a4ae386");
            result.LevelReadCode.ShouldBe("02f0d3ee6f18422aada3da8bbe477185c928895f58dd435eb2");
            result.LevelWriteCode.ShouldBe("b183277cd88148b7bba8a66864f9e7900082f6c4e9ee48dd80");
            result.ExtendedInformation.ShouldBe("eaa6fbea866c4fb393583aa33f13c7b2dcf60f3242f84687971b19224d4229a1aa6224c0277f4b36ac97422ad26a158a1e7b7b7a48b0483a875a9ae36ce45ff57e011b8317764041b8a508edd8fbc9b3aad9107e3f78451c85e2cf769dfc62be14678b294b5f4b3ea4258edcc4b445309e1c1df759ae4d06932c2b6b63a48e9d5cff315ce4af49ac84ff99bcbbe93c6e64cda0c5e3044518ab8e9686947099b710f7b3d9244846d7a976c63b5c1f52f61563bff0c1cd40d9933ced831bd2abcb4779f18029ca49bf82121ad3e682d42b194a877176a54430a029cf3a3e466f446089736dbdbc40a0af2ad59828c6a428eb13645adf1a4cd7a50f");
            result.DateA.ShouldBe(new DateTime(2016, 7, 23));
            result.DateD.ShouldBe(new DateTime(2015, 3, 16));
            result.Sort.ShouldBe(1917777567);
            result.Note.ShouldBe("40a0652191614c5c8b9ec143d37a1359ea1596bc7cc741a2b563a83819a632d9659d741c204b46fe97af3b8305c12b78a703be1f5d43480b922d7bf53dea63c898326c6ee655400fb699298dff076c12af2fd31e6f9345c1b439f79a69f25ffa718d58992a104531a7853ac456e907fcfa7592f3f893412bb866cc5ebf16a193933c67437d804931a4a7197bd196fa73ccf909503ef64bfd954d8c2ff6b13eae8773a4b9730d4a978adef2ca9ce9929b971e181536dd4e2bac67f817bccf9ec8bcddb20583234fc88e510f4491793c1914f5402fc14f48e3a46bcf7547826911f14939b2ea56498c98fe7285c61fd1b189a43bea5686481e8821");
            result.Status.ShouldBe("b2ab474dec314c12bdf566016b3226a5ac229fb073b14010ba");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeLanguageUpdateDto()
            {
                ResumeMainId = Guid.Parse("a3835268-543e-4a6c-903c-4d70c2482873"),
                LanguageCategoryCode = "85f5b09e7607492d8303cda10086198a66dfa50fa806483f99",
                LevelSayCode = "81609f2a7f4a495cb753ebd6b878eea26648b08cd728418686",
                LevelListenCode = "921b30ccbf884dc594710293d4ae9c09419b7cd4d752458486",
                LevelReadCode = "be5f804d2cc04ce58acc8793ac77cb6e0b7e65ada5ca4fae89",
                LevelWriteCode = "551257b7719249a7beac8d6fa52caf87c2607be681a0479b85",
                ExtendedInformation = "43bf1baeffbf4f938657f8c7e34416e1deba0651e5e845debd7a325aa5dc36897697811ad49b4332b4bbb94424fdbbfa95ff327e681b421fae366dfdca3e6afbf7910a74e9624099a2b2210d19fc030a2ef2e1adc36a477abb4787d5fc04d0b19348956237a34e5ba809132777e0dfe696522d88fefa4e3787bfeb1fffa03c61097d3d440fda45cc8f6ab60eae44fcfc1ce36e36c8fa482798feccf311a17e94add02ca5311a483890dd40f2af2df39116618e3beb9c4c34aaa88df45c70bdff3c9dee10e3154d3f9d46c0631ab815fcae28f4a762694f30b552f37e36c38d6ec7e3178cc7ef44eaa957d6943af59b03614637aa248b4352b084",
                DateA = new DateTime(2009, 4, 19),
                DateD = new DateTime(2002, 1, 16),
                Sort = 1228955328,
                Note = "0e95d123b09145029b2649f327bca530af75d6ae02344419922012d91e7fdb9646d2fc3e34684432a4d200b2d9e4b60d3eafc4b261f447bfb82ca066a7e42a65b5b48ed93b7c492e86663bbc3a8779803c9862eba2414fceaf14060f7509108fdffa50ad9138499db94d1837ca5545f56de031ee39694e14b931d166ab25df2316a4ecd9db2f40a08e16455015b34c8ffe19b4a14f0e4d489c7594de3cb722b1c812b4399db143e19b03af29ec163a36b50ac593d9c745109b153a1cfbc0a3fac9ae11de990d40b9b64e57c4846896ef054f00be33e544df9e22ab4a1a15eddf3c6027a1db1042b9b504ecfb2e512ed27e31b3b49f7146b2ae33",
                Status = "954eb07e7a8447b3ac54946b3b171403d61872f705f14bc599"
            };

            // Act
            var serviceResult = await _resumeLanguagesAppService.UpdateAsync(Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"), input);

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("a3835268-543e-4a6c-903c-4d70c2482873"));
            result.LanguageCategoryCode.ShouldBe("85f5b09e7607492d8303cda10086198a66dfa50fa806483f99");
            result.LevelSayCode.ShouldBe("81609f2a7f4a495cb753ebd6b878eea26648b08cd728418686");
            result.LevelListenCode.ShouldBe("921b30ccbf884dc594710293d4ae9c09419b7cd4d752458486");
            result.LevelReadCode.ShouldBe("be5f804d2cc04ce58acc8793ac77cb6e0b7e65ada5ca4fae89");
            result.LevelWriteCode.ShouldBe("551257b7719249a7beac8d6fa52caf87c2607be681a0479b85");
            result.ExtendedInformation.ShouldBe("43bf1baeffbf4f938657f8c7e34416e1deba0651e5e845debd7a325aa5dc36897697811ad49b4332b4bbb94424fdbbfa95ff327e681b421fae366dfdca3e6afbf7910a74e9624099a2b2210d19fc030a2ef2e1adc36a477abb4787d5fc04d0b19348956237a34e5ba809132777e0dfe696522d88fefa4e3787bfeb1fffa03c61097d3d440fda45cc8f6ab60eae44fcfc1ce36e36c8fa482798feccf311a17e94add02ca5311a483890dd40f2af2df39116618e3beb9c4c34aaa88df45c70bdff3c9dee10e3154d3f9d46c0631ab815fcae28f4a762694f30b552f37e36c38d6ec7e3178cc7ef44eaa957d6943af59b03614637aa248b4352b084");
            result.DateA.ShouldBe(new DateTime(2009, 4, 19));
            result.DateD.ShouldBe(new DateTime(2002, 1, 16));
            result.Sort.ShouldBe(1228955328);
            result.Note.ShouldBe("0e95d123b09145029b2649f327bca530af75d6ae02344419922012d91e7fdb9646d2fc3e34684432a4d200b2d9e4b60d3eafc4b261f447bfb82ca066a7e42a65b5b48ed93b7c492e86663bbc3a8779803c9862eba2414fceaf14060f7509108fdffa50ad9138499db94d1837ca5545f56de031ee39694e14b931d166ab25df2316a4ecd9db2f40a08e16455015b34c8ffe19b4a14f0e4d489c7594de3cb722b1c812b4399db143e19b03af29ec163a36b50ac593d9c745109b153a1cfbc0a3fac9ae11de990d40b9b64e57c4846896ef054f00be33e544df9e22ab4a1a15eddf3c6027a1db1042b9b504ecfb2e512ed27e31b3b49f7146b2ae33");
            result.Status.ShouldBe("954eb07e7a8447b3ac54946b3b171403d61872f705f14bc599");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeLanguagesAppService.DeleteAsync(Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"));

            // Assert
            var result = await _resumeLanguageRepository.FindAsync(c => c.Id == Guid.Parse("85c9c21d-e528-41b0-9648-9a508a96c6b8"));

            result.ShouldBeNull();
        }
    }
}