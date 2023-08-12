using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemTables
{
    public class SystemTablesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemTablesAppService _systemTablesAppService;
        private readonly IRepository<SystemTable, Guid> _systemTableRepository;

        public SystemTablesAppServiceTests()
        {
            _systemTablesAppService = GetRequiredService<ISystemTablesAppService>();
            _systemTableRepository = GetRequiredService<IRepository<SystemTable, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemTablesAppService.GetListAsync(new GetSystemTablesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("42736999-cba3-4be9-b701-ab1ec8497ebb")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemTablesAppService.GetAsync(Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemTableCreateDto
            {
                Name = "ffbbd01fd00948cd991873bf77cb9796f45c8a6bae6f4531ba",
                AllowInsert = true,
                AllowUpdate = true,
                AllowDelete = true,
                AllowSelect = true,
                AllowExport = true,
                AllowImport = true,
                AllowPage = true,
                AllowSort = true,
                ExtendedInformation = "ecf4b5c67ce54947a38354a317e4f8f340c49051870c46d781c4581c0aefae47742d4a655050439a9525f8f9df8850e60ba79e19eaef471a8c4b86debfefa80bc7b4019000ba466e8eb067a1d1676cc335176c981dec4833a39aa09a07ce4c23f8a5ef53f3304d1182b902c16867e213d0a483720af84356b109f5b0509ec5e6703eb52b54ab4cd49af9ee69e88d57683597deb1c1ec4d89a23e3499fbaad1d20477357d72d442e0a31867a4d257e4f3ae6b08e868744cfe9a7ec1ec857a997f8e3af4b485bb485b970204b3e8e522938de287e69cb44fb89c1790f31aee3ed4e8bbe8a5d75d4b188f647a265f9e6c81cff4477acd6844a2ba4f",
                DateA = new DateTime(2008, 11, 25),
                DateD = new DateTime(2002, 4, 25),
                Sort = 1788641657,
                Note = "589e9f7f074c4d37b38727b7d4087d1210d849b8813e4120aa5db9f07420f6ab95667207dcbc4227b739fd5b6d9b706d6a03fb950a484693b86ed3bf96cb6c1644bba891151c4e0db1911c6dbe73a4cfae289da2bc1343abbd82253420f4bc2c48c7a2048cc0483aab97458fc87b8364f309b6fe7bb542af9cf1bd1ca72309eac6cc189c52f44e3097c130fa0f3609b39d317210d4354432b8fd9d770c1e6a5d6c7f6832a9f04c9aa756a2f1ecabebba01827820418b4fe8ab3affb753ceb704bb0ef413acea445da598fb92883a401ebdfd3a269c674d2a8afddff74bc076568fffb6f0db634394957d8c165f2a371b986fa231a2fe497a9ed6",
                Status = "d10782e8077b4ebe8d654128ac758299e8d7ccaedbca4a0995"
            };

            // Act
            var serviceResult = await _systemTablesAppService.CreateAsync(input);

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("ffbbd01fd00948cd991873bf77cb9796f45c8a6bae6f4531ba");
            result.AllowInsert.ShouldBe(true);
            result.AllowUpdate.ShouldBe(true);
            result.AllowDelete.ShouldBe(true);
            result.AllowSelect.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowImport.ShouldBe(true);
            result.AllowPage.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("ecf4b5c67ce54947a38354a317e4f8f340c49051870c46d781c4581c0aefae47742d4a655050439a9525f8f9df8850e60ba79e19eaef471a8c4b86debfefa80bc7b4019000ba466e8eb067a1d1676cc335176c981dec4833a39aa09a07ce4c23f8a5ef53f3304d1182b902c16867e213d0a483720af84356b109f5b0509ec5e6703eb52b54ab4cd49af9ee69e88d57683597deb1c1ec4d89a23e3499fbaad1d20477357d72d442e0a31867a4d257e4f3ae6b08e868744cfe9a7ec1ec857a997f8e3af4b485bb485b970204b3e8e522938de287e69cb44fb89c1790f31aee3ed4e8bbe8a5d75d4b188f647a265f9e6c81cff4477acd6844a2ba4f");
            result.DateA.ShouldBe(new DateTime(2008, 11, 25));
            result.DateD.ShouldBe(new DateTime(2002, 4, 25));
            result.Sort.ShouldBe(1788641657);
            result.Note.ShouldBe("589e9f7f074c4d37b38727b7d4087d1210d849b8813e4120aa5db9f07420f6ab95667207dcbc4227b739fd5b6d9b706d6a03fb950a484693b86ed3bf96cb6c1644bba891151c4e0db1911c6dbe73a4cfae289da2bc1343abbd82253420f4bc2c48c7a2048cc0483aab97458fc87b8364f309b6fe7bb542af9cf1bd1ca72309eac6cc189c52f44e3097c130fa0f3609b39d317210d4354432b8fd9d770c1e6a5d6c7f6832a9f04c9aa756a2f1ecabebba01827820418b4fe8ab3affb753ceb704bb0ef413acea445da598fb92883a401ebdfd3a269c674d2a8afddff74bc076568fffb6f0db634394957d8c165f2a371b986fa231a2fe497a9ed6");
            result.Status.ShouldBe("d10782e8077b4ebe8d654128ac758299e8d7ccaedbca4a0995");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemTableUpdateDto()
            {
                Name = "db210182fd4445b0af08b85521290d975d018a968fe842b694",
                AllowInsert = true,
                AllowUpdate = true,
                AllowDelete = true,
                AllowSelect = true,
                AllowExport = true,
                AllowImport = true,
                AllowPage = true,
                AllowSort = true,
                ExtendedInformation = "a733ac55bac54433b8be18a6f11a669d26ddf2a6a2b24132b8f643114e3c60ebee291b11cfd244fba678174e93b52ae79da47c19ce22457e8db4089a6487278107c7d8c943ad4225a2726c470b605cb716b6cec6d2064aa69a7973ed7c5769b716f2487160454c9d94a4db917a9dc374ec74efa1fb53402591d1ca5f78cfef07d0165998b0b94951b2d5bbd742d45d0d1e1a1a0559a9454ba4a77b8316acdaa676bc5a01e0e44694867c6dd4ee963c3368a9963da1304c4db98a0a4836476182997c36137b68451ca2ca3328c6e6b85c8b5d4a5011164d938144c6fbb151ead891d96eeed730440bb14db6d1430e28e2f2bc2d13888f4b9dbe2e",
                DateA = new DateTime(2006, 11, 10),
                DateD = new DateTime(2010, 6, 3),
                Sort = 1743930379,
                Note = "abf7f9e56c424c2382975a74ec4976efc339bdc2087d487e83ad445793f3f63874555b9ed19341b8afaa2023bedf9004a116e5bbba894c8e9d44852ea4842b0b552d413d74254551912cdbd59bbb8c1e7035010360604823959761a4a1363bc180105892f8ee4227a6073aa9a27facf3800de514ca534a138ce94e48c9e9e777f6bdd1184b4845348c4d29b212c13b66545f7513ed7642f5944771d2225f0a68e127bc2d428d41ea8b67869e44e091e569fe656027e048648d612317b9cda9b5f5fc74188f2e4001b73be7d0b021955228067067937345bdb484ff69e4ec50ccab357edb87494936b9b1e101fff8d7906cf1ef39662443a1b53f",
                Status = "33aa1a27c0b0434a81f66abec8b0ac76af50a09e523a4fd7ad"
            };

            // Act
            var serviceResult = await _systemTablesAppService.UpdateAsync(Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"), input);

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("db210182fd4445b0af08b85521290d975d018a968fe842b694");
            result.AllowInsert.ShouldBe(true);
            result.AllowUpdate.ShouldBe(true);
            result.AllowDelete.ShouldBe(true);
            result.AllowSelect.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowImport.ShouldBe(true);
            result.AllowPage.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("a733ac55bac54433b8be18a6f11a669d26ddf2a6a2b24132b8f643114e3c60ebee291b11cfd244fba678174e93b52ae79da47c19ce22457e8db4089a6487278107c7d8c943ad4225a2726c470b605cb716b6cec6d2064aa69a7973ed7c5769b716f2487160454c9d94a4db917a9dc374ec74efa1fb53402591d1ca5f78cfef07d0165998b0b94951b2d5bbd742d45d0d1e1a1a0559a9454ba4a77b8316acdaa676bc5a01e0e44694867c6dd4ee963c3368a9963da1304c4db98a0a4836476182997c36137b68451ca2ca3328c6e6b85c8b5d4a5011164d938144c6fbb151ead891d96eeed730440bb14db6d1430e28e2f2bc2d13888f4b9dbe2e");
            result.DateA.ShouldBe(new DateTime(2006, 11, 10));
            result.DateD.ShouldBe(new DateTime(2010, 6, 3));
            result.Sort.ShouldBe(1743930379);
            result.Note.ShouldBe("abf7f9e56c424c2382975a74ec4976efc339bdc2087d487e83ad445793f3f63874555b9ed19341b8afaa2023bedf9004a116e5bbba894c8e9d44852ea4842b0b552d413d74254551912cdbd59bbb8c1e7035010360604823959761a4a1363bc180105892f8ee4227a6073aa9a27facf3800de514ca534a138ce94e48c9e9e777f6bdd1184b4845348c4d29b212c13b66545f7513ed7642f5944771d2225f0a68e127bc2d428d41ea8b67869e44e091e569fe656027e048648d612317b9cda9b5f5fc74188f2e4001b73be7d0b021955228067067937345bdb484ff69e4ec50ccab357edb87494936b9b1e101fff8d7906cf1ef39662443a1b53f");
            result.Status.ShouldBe("33aa1a27c0b0434a81f66abec8b0ac76af50a09e523a4fd7ad");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemTablesAppService.DeleteAsync(Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"));

            // Assert
            var result = await _systemTableRepository.FindAsync(c => c.Id == Guid.Parse("653a2e3a-37f6-460a-863b-92adb26e829e"));

            result.ShouldBeNull();
        }
    }
}