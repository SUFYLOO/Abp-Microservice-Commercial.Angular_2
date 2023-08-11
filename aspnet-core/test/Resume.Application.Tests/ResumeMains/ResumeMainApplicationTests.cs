using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeMains
{
    public class ResumeMainsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeMainsAppService _resumeMainsAppService;
        private readonly IRepository<ResumeMain, Guid> _resumeMainRepository;

        public ResumeMainsAppServiceTests()
        {
            _resumeMainsAppService = GetRequiredService<IResumeMainsAppService>();
            _resumeMainRepository = GetRequiredService<IRepository<ResumeMain, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeMainsAppService.GetListAsync(new GetResumeMainsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f4d7ae49-5c98-43b1-b6ef-6673b53ab6e3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeMainsAppService.GetAsync(Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeMainCreateDto
            {
                UserMainId = Guid.Parse("8a885d00-0e7a-4961-bb19-25d296f773ef"),
                ResumeName = "b00f942f159b42a1aa69f00c9b265ce51942d376bd294c33bc",
                MarriageCode = "f77568cf88294cceb445aa4c5e63236d0794b184df8746eb9c",
                MilitaryCode = "95b0d298ad9741369399220fde595357c0e886b816bd410a97",
                DisabilityCategoryCode = "303fa138471e4297b8d83caafa1a2f21fdbeacfef52c481380",
                SpecialIdentityCode = "679f8959ade84a96a58c4643120884a18274fd82ae024be195",
                Main = true,
                Autobiography1 = "a519df789d534f9d93cf38424c2ef41ecacf7613b0714f3bad5e28b55b2e431948fc0ea6e",
                Autobiography2 = "a3c56be9daf24a4485953cb0c197e255ce8c40d684a948db9c144ee6e56e2703",
                ExtendedInformation = "bbd96c58e5374d80849224eabffa86c072ca2a3e1bec432389d8bcedfa583b69bb6f5735227c41409601f0e6e0c56961487c596d6d714f6abe375c282b5753bd5de95e7a020e419f9f46d485f34c02f46062d70aac7b4f0889de02e5e963d10c9360baa7f1d94b4baf716e49ae8bd55b677e686452e6499ab2bad427ef6816563cf0cbf59de84f1da666ca855856509aca3421baa51d4129a9b489450357ad5d8798610ad3ed4348b37073d11c9df81dfcdb64b9d1fe4cc5824d8deeebb51351b4d8cc3cfee64070b928044aebeba7e798cf8447e52c4d9eadb5aa38c88e79b9baa6bec8f1d04acbafe98f610ded503d48db1912f2b641d68604",
                DateA = new DateTime(2012, 9, 25),
                DateD = new DateTime(2009, 8, 22),
                Sort = 1421465549,
                Note = "0ee6bd76c8c7489ea016705bb54cb92183f4a48df0ea4f01b38c3be34717c0075b388e09094641f481f17e1dc4632fe8485833a43acf439fbb85e6838548e4830c77c80c60a345279f644908bac05e31189bb0ee09be4f5dafa8ab4fff228249b2dc4296b37a4cb69366207c3a6b5b86fc8d56db24504b5aa5512e037ba161804588beac3e284ea3a86b1cb01c82e60b739732e6424d4f83a12a516fa11382af9181c83519cf45d1a4dbf8dc5852dc90d4e5c061f39d465083e530f3570d48831a7982ba4ccf46899b436f27042c3b55bd1f7de499d34d78b982b9e19764680edd99fb38578745d9878f75245ad3cc7d17c240ca547b49058b7e",
                Status = "38b6fb6bb9ab49a3a2ed5872fce768ed6ceb09ac30874ad6bd"
            };

            // Act
            var serviceResult = await _resumeMainsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("8a885d00-0e7a-4961-bb19-25d296f773ef"));
            result.ResumeName.ShouldBe("b00f942f159b42a1aa69f00c9b265ce51942d376bd294c33bc");
            result.MarriageCode.ShouldBe("f77568cf88294cceb445aa4c5e63236d0794b184df8746eb9c");
            result.MilitaryCode.ShouldBe("95b0d298ad9741369399220fde595357c0e886b816bd410a97");
            result.DisabilityCategoryCode.ShouldBe("303fa138471e4297b8d83caafa1a2f21fdbeacfef52c481380");
            result.SpecialIdentityCode.ShouldBe("679f8959ade84a96a58c4643120884a18274fd82ae024be195");
            result.Main.ShouldBe(true);
            result.Autobiography1.ShouldBe("a519df789d534f9d93cf38424c2ef41ecacf7613b0714f3bad5e28b55b2e431948fc0ea6e");
            result.Autobiography2.ShouldBe("a3c56be9daf24a4485953cb0c197e255ce8c40d684a948db9c144ee6e56e2703");
            result.ExtendedInformation.ShouldBe("bbd96c58e5374d80849224eabffa86c072ca2a3e1bec432389d8bcedfa583b69bb6f5735227c41409601f0e6e0c56961487c596d6d714f6abe375c282b5753bd5de95e7a020e419f9f46d485f34c02f46062d70aac7b4f0889de02e5e963d10c9360baa7f1d94b4baf716e49ae8bd55b677e686452e6499ab2bad427ef6816563cf0cbf59de84f1da666ca855856509aca3421baa51d4129a9b489450357ad5d8798610ad3ed4348b37073d11c9df81dfcdb64b9d1fe4cc5824d8deeebb51351b4d8cc3cfee64070b928044aebeba7e798cf8447e52c4d9eadb5aa38c88e79b9baa6bec8f1d04acbafe98f610ded503d48db1912f2b641d68604");
            result.DateA.ShouldBe(new DateTime(2012, 9, 25));
            result.DateD.ShouldBe(new DateTime(2009, 8, 22));
            result.Sort.ShouldBe(1421465549);
            result.Note.ShouldBe("0ee6bd76c8c7489ea016705bb54cb92183f4a48df0ea4f01b38c3be34717c0075b388e09094641f481f17e1dc4632fe8485833a43acf439fbb85e6838548e4830c77c80c60a345279f644908bac05e31189bb0ee09be4f5dafa8ab4fff228249b2dc4296b37a4cb69366207c3a6b5b86fc8d56db24504b5aa5512e037ba161804588beac3e284ea3a86b1cb01c82e60b739732e6424d4f83a12a516fa11382af9181c83519cf45d1a4dbf8dc5852dc90d4e5c061f39d465083e530f3570d48831a7982ba4ccf46899b436f27042c3b55bd1f7de499d34d78b982b9e19764680edd99fb38578745d9878f75245ad3cc7d17c240ca547b49058b7e");
            result.Status.ShouldBe("38b6fb6bb9ab49a3a2ed5872fce768ed6ceb09ac30874ad6bd");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeMainUpdateDto()
            {
                UserMainId = Guid.Parse("f4ffc2d6-c0d9-49b4-88da-148a314320a4"),
                ResumeName = "8e03d67d91594441a7fd4bd73251c78bee7b82b01142444bac",
                MarriageCode = "8eb5c307e0b94b5992ea20a65a538e9777f0f2737c204cb8b0",
                MilitaryCode = "22b037f19b4643d89edde46c667d64955910c8d980f740ec87",
                DisabilityCategoryCode = "0a0020b658ab473e908df3c4a0c835d9476d8859851a4663a7",
                SpecialIdentityCode = "72955e2e56134d6586455e37286029320a2c638f45104da6bb",
                Main = true,
                Autobiography1 = "5dfd9f2c037c41748cff39",
                Autobiography2 = "b53e3466d379471ab77d64536e5963a4d9b2b3218ec34e8b9747ba88fbbff8f4104ec26c71444528",
                ExtendedInformation = "7a16a15d653a4158a5363c478cca89375cec67f1cbe64e6eb9d273accf9c765a6873371fa01748279e8bea911c85be38d58165ae8dbf47c6aa69d1d510c8f27d7f06f179b6fe4335ae343e29eefd6fccf19c6267cea34effaab9e30bc418e7505631cba1bdc44c4c8ec680f9ec5c1331d7ccc68a51464487a2723735bd20fb0559a3ed970558472398b64f0a2457555bd4572462a64a4329960833bd6bedec56f6cecb32ee2d49d3a9b30aecdce200dbe180f81ac4504e318aa71e6ff478180d039c1cd19a32452396d4a655ca4cff2bbf0d8aa43823478c88b0577c9d0d88b948aef91318e84272af606d8eb60c4b4e222042e0314b49fc8162",
                DateA = new DateTime(2004, 10, 13),
                DateD = new DateTime(2005, 9, 27),
                Sort = 804852368,
                Note = "e35249756a7e4387af26a7ace44ca2d7038de2eee3874ed2bcb880a93bc5cc8390ae307313db41d0b877b94fcbb3caeb35299a539a2f4dcd8e5d3903e39ef2fd992a1e2689d6414abd856bbe04d89c7a2f538cae5d0a49c98b459563a8334ad148fece5001694821900933b016baafe7f864523894f34ce2969a19a0ebbbcbfa9868b575bbd2435b89737b70b32b022e0e6f9c1d41f74c128a27c4410d842f6166582b6ad5c2451b8d07d49f699da9064b692eaccb1e4e18887ab4d18ebd4851b10c10d0a7104e82b7a110cb442eff3d7fce83d169fa4b899b52351342372851298b707aac284bab8a0cc61ca1f135f09fa83dfeb19545dea721",
                Status = "d0dac4b9a00248578491ebd78bfdbdc3a373a443baea4b0eb5"
            };

            // Act
            var serviceResult = await _resumeMainsAppService.UpdateAsync(Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"), input);

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("f4ffc2d6-c0d9-49b4-88da-148a314320a4"));
            result.ResumeName.ShouldBe("8e03d67d91594441a7fd4bd73251c78bee7b82b01142444bac");
            result.MarriageCode.ShouldBe("8eb5c307e0b94b5992ea20a65a538e9777f0f2737c204cb8b0");
            result.MilitaryCode.ShouldBe("22b037f19b4643d89edde46c667d64955910c8d980f740ec87");
            result.DisabilityCategoryCode.ShouldBe("0a0020b658ab473e908df3c4a0c835d9476d8859851a4663a7");
            result.SpecialIdentityCode.ShouldBe("72955e2e56134d6586455e37286029320a2c638f45104da6bb");
            result.Main.ShouldBe(true);
            result.Autobiography1.ShouldBe("5dfd9f2c037c41748cff39");
            result.Autobiography2.ShouldBe("b53e3466d379471ab77d64536e5963a4d9b2b3218ec34e8b9747ba88fbbff8f4104ec26c71444528");
            result.ExtendedInformation.ShouldBe("7a16a15d653a4158a5363c478cca89375cec67f1cbe64e6eb9d273accf9c765a6873371fa01748279e8bea911c85be38d58165ae8dbf47c6aa69d1d510c8f27d7f06f179b6fe4335ae343e29eefd6fccf19c6267cea34effaab9e30bc418e7505631cba1bdc44c4c8ec680f9ec5c1331d7ccc68a51464487a2723735bd20fb0559a3ed970558472398b64f0a2457555bd4572462a64a4329960833bd6bedec56f6cecb32ee2d49d3a9b30aecdce200dbe180f81ac4504e318aa71e6ff478180d039c1cd19a32452396d4a655ca4cff2bbf0d8aa43823478c88b0577c9d0d88b948aef91318e84272af606d8eb60c4b4e222042e0314b49fc8162");
            result.DateA.ShouldBe(new DateTime(2004, 10, 13));
            result.DateD.ShouldBe(new DateTime(2005, 9, 27));
            result.Sort.ShouldBe(804852368);
            result.Note.ShouldBe("e35249756a7e4387af26a7ace44ca2d7038de2eee3874ed2bcb880a93bc5cc8390ae307313db41d0b877b94fcbb3caeb35299a539a2f4dcd8e5d3903e39ef2fd992a1e2689d6414abd856bbe04d89c7a2f538cae5d0a49c98b459563a8334ad148fece5001694821900933b016baafe7f864523894f34ce2969a19a0ebbbcbfa9868b575bbd2435b89737b70b32b022e0e6f9c1d41f74c128a27c4410d842f6166582b6ad5c2451b8d07d49f699da9064b692eaccb1e4e18887ab4d18ebd4851b10c10d0a7104e82b7a110cb442eff3d7fce83d169fa4b899b52351342372851298b707aac284bab8a0cc61ca1f135f09fa83dfeb19545dea721");
            result.Status.ShouldBe("d0dac4b9a00248578491ebd78bfdbdc3a373a443baea4b0eb5");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeMainsAppService.DeleteAsync(Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"));

            // Assert
            var result = await _resumeMainRepository.FindAsync(c => c.Id == Guid.Parse("fbad2b8c-db3d-4bb2-aa67-745c177b2834"));

            result.ShouldBeNull();
        }
    }
}