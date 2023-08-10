using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemDisplayMessagesAppService _systemDisplayMessagesAppService;
        private readonly IRepository<SystemDisplayMessage, Guid> _systemDisplayMessageRepository;

        public SystemDisplayMessagesAppServiceTests()
        {
            _systemDisplayMessagesAppService = GetRequiredService<ISystemDisplayMessagesAppService>();
            _systemDisplayMessageRepository = GetRequiredService<IRepository<SystemDisplayMessage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemDisplayMessagesAppService.GetListAsync(new GetSystemDisplayMessagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("10115326-f6b8-4864-b43e-9ec720731077")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemDisplayMessagesAppService.GetAsync(Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemDisplayMessageCreateDto
            {
                DisplayTypeCode = "973cd25bf2ac479fbdd702346f52b22271ac04cc4d3f45bb99",
                TitleContents = "88dfe94d110844019dda0250ea19e4ec1a2eff3eaa2c49dc8b1fa90222c456f65d9e65d6eb024c8dadac1f86f9a2204e614926f6894f4a6093fb9582c0c547f0465eb649ab7a44909220b9ea9aff0b6620095d6fe4a44dbe9710432d199c9ea5f9d9d77cca3c401f8ceb1563434f28018f0dc09292254a48b4e664a46a5768cfd0b035450e1b44dba98d810e57bff5b068d3d85455f04d988c3d90f2f986c2372e472fe48b2e404f98071dd7c56a4672c97ea531a5634faca5bc66be49e05ddd558be1a315364ade936ee181bf71a159811f9327b9a14dfbb0c2bea1c71cb8f25e7bb09cc1dd4372b5ee07e1281da7cf1087237beb574df1ba4e",
                Contents = "392e482bb5394ada968976b3a1b33a25b3ab2ed22fc048aca70f56d272917a28c2cc9ddb748b4f69b348c37fcb28b03f3494f83bdf7a4d1c80d0c0a70b0cddfc030f0d672b3b4636af7a2bccdfd23c7628665b7f1793405fb28f1bd457869eb3e244a29f5a764f5fa7d3a289b46a90eb4195b526dbf74b0a8b5433fc87fbb9d9735e706def2d4cc6acdd9c00004099b4fd2ade6eac084de1bb92ea8e71ca2207ef76294ee02e4e36a0dc4c16745cae3547bbf428b11d4e14949a8992d16d93d51d113119e2064c6ea92f5ca61d1cd52d2dd6a03b589949b3b1917d02a30075b5058724dbf6234b1b80ba84970bd4d49bf830792d68c44ce3b9c7",
                ExtendedInformation = "d4a0172c449043a3a2111aa4c3bc78679ebbd06424b144bd8e57c5ae1babdf4a6a18174f532b419086c195a98a1184296c48eb40c8ce499e81d2603446d1dbff1bfc4718db064748ab65e018798c3623d488f4e42a89463e9c1cd869275ad5fd602e764b07254031bfc6cdd539c11c7c0834a0eee3d0452ab71eee922dce33c23102a7443f9f493c8c79d724f85471bc33860a311d2e4f878e67db4dad0722e84a02bfdbc27f4e1f8045308d53eb39c78b13ded46cfa4ca09205c0f8fcb5225401148516521147bf81f7a222ecaee53e8d67c60764ec42059d5b4aef7b79ce405dd96f22cf0f4cd79622c712da3267ca48ab0afd995c44d68304",
                DateA = new DateTime(2022, 5, 2),
                DateD = new DateTime(2003, 6, 7),
                Sort = 1197908183,
                Note = "837f8a6a6bc5415397c30f9929c317e6280e7fbf0d3a47d08c35a6211e98c8842666d43dfbcb45a9966dbe3319c8dd9d617c935789d64465958d240675e9ddd733bd35a6c33f48a1a23f0fb80104ef15f2dc52dcbaec4e4480a2eac54aef1ffe9508c5dc890448ca9ca5709b5a6862084a8131e3b1c74a8981dca5dc500510353927bd0c08a443808b6bb528a06325fbd35568d1971a4204b29c8019b928189235038a5f49664014811133d28b8d2589e9bbf289618b4276919b4bf43785db93da0dc4ca340144379ffe3075af6070efeb6b5649194d459fb4d9618ad3a9ebcbfd555c657fda450ba091cb07dadbeeb30d7041df2ece460ca174",
                Status = "eab799b79c0e4dcab088d942d8b8cf0c993ca53ff88344539a"
            };

            // Act
            var serviceResult = await _systemDisplayMessagesAppService.CreateAsync(input);

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.DisplayTypeCode.ShouldBe("973cd25bf2ac479fbdd702346f52b22271ac04cc4d3f45bb99");
            result.TitleContents.ShouldBe("88dfe94d110844019dda0250ea19e4ec1a2eff3eaa2c49dc8b1fa90222c456f65d9e65d6eb024c8dadac1f86f9a2204e614926f6894f4a6093fb9582c0c547f0465eb649ab7a44909220b9ea9aff0b6620095d6fe4a44dbe9710432d199c9ea5f9d9d77cca3c401f8ceb1563434f28018f0dc09292254a48b4e664a46a5768cfd0b035450e1b44dba98d810e57bff5b068d3d85455f04d988c3d90f2f986c2372e472fe48b2e404f98071dd7c56a4672c97ea531a5634faca5bc66be49e05ddd558be1a315364ade936ee181bf71a159811f9327b9a14dfbb0c2bea1c71cb8f25e7bb09cc1dd4372b5ee07e1281da7cf1087237beb574df1ba4e");
            result.Contents.ShouldBe("392e482bb5394ada968976b3a1b33a25b3ab2ed22fc048aca70f56d272917a28c2cc9ddb748b4f69b348c37fcb28b03f3494f83bdf7a4d1c80d0c0a70b0cddfc030f0d672b3b4636af7a2bccdfd23c7628665b7f1793405fb28f1bd457869eb3e244a29f5a764f5fa7d3a289b46a90eb4195b526dbf74b0a8b5433fc87fbb9d9735e706def2d4cc6acdd9c00004099b4fd2ade6eac084de1bb92ea8e71ca2207ef76294ee02e4e36a0dc4c16745cae3547bbf428b11d4e14949a8992d16d93d51d113119e2064c6ea92f5ca61d1cd52d2dd6a03b589949b3b1917d02a30075b5058724dbf6234b1b80ba84970bd4d49bf830792d68c44ce3b9c7");
            result.ExtendedInformation.ShouldBe("d4a0172c449043a3a2111aa4c3bc78679ebbd06424b144bd8e57c5ae1babdf4a6a18174f532b419086c195a98a1184296c48eb40c8ce499e81d2603446d1dbff1bfc4718db064748ab65e018798c3623d488f4e42a89463e9c1cd869275ad5fd602e764b07254031bfc6cdd539c11c7c0834a0eee3d0452ab71eee922dce33c23102a7443f9f493c8c79d724f85471bc33860a311d2e4f878e67db4dad0722e84a02bfdbc27f4e1f8045308d53eb39c78b13ded46cfa4ca09205c0f8fcb5225401148516521147bf81f7a222ecaee53e8d67c60764ec42059d5b4aef7b79ce405dd96f22cf0f4cd79622c712da3267ca48ab0afd995c44d68304");
            result.DateA.ShouldBe(new DateTime(2022, 5, 2));
            result.DateD.ShouldBe(new DateTime(2003, 6, 7));
            result.Sort.ShouldBe(1197908183);
            result.Note.ShouldBe("837f8a6a6bc5415397c30f9929c317e6280e7fbf0d3a47d08c35a6211e98c8842666d43dfbcb45a9966dbe3319c8dd9d617c935789d64465958d240675e9ddd733bd35a6c33f48a1a23f0fb80104ef15f2dc52dcbaec4e4480a2eac54aef1ffe9508c5dc890448ca9ca5709b5a6862084a8131e3b1c74a8981dca5dc500510353927bd0c08a443808b6bb528a06325fbd35568d1971a4204b29c8019b928189235038a5f49664014811133d28b8d2589e9bbf289618b4276919b4bf43785db93da0dc4ca340144379ffe3075af6070efeb6b5649194d459fb4d9618ad3a9ebcbfd555c657fda450ba091cb07dadbeeb30d7041df2ece460ca174");
            result.Status.ShouldBe("eab799b79c0e4dcab088d942d8b8cf0c993ca53ff88344539a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemDisplayMessageUpdateDto()
            {
                DisplayTypeCode = "fd91e415bdeb4c0cb49a59e5826bd556adb7725d24c44d67b7",
                TitleContents = "3b5ff0766fea46f4a31ef3b11784003f686ff4ffa3f94840980aaafe264c56e5b9137cc59ecd49ce8512eac090caa5c03ceffa019f584dc1ac9e5876198d7e709bf2c8bc486f4c09b8020e45c6ab8f87002e0454161a49daa4b9c5ad073f6d7c914290e4de9f412b8ff6b4bd10452be2fab684bc46e84d54a16a0368668af1a22376521561f74d048a5251ef57418b488c7aa7c7d583400087a7b6a35cdca9281f8092377657408ca61469a61d5e4aac61633f2671014eec805204483dc322983b1530c4517d44579d8343d07d8318f200d6cee71e424dbb9dd481967a1cbef3e8c557c724dc4347acf45e38fc7bb543c1a3135a499549a8a5fa",
                Contents = "355c6d63c42241cc968baa3a7b0e816030e58584abcd41978e31737da37966644131c15754294094b41566588ff4e4f2ff493bfebae14f0baf1ef7c27bfde8568c19cfa638094cbca0ff8ca0db46d61a9199a12a79a942a3bd40b75eacf3f35b1406019f14c54361a7d3165cedc93f5634166a13befe4e809f7e00377efa6a2bdc796f1bb8e04a1996f872ef030d5c0f4fb95b031b244e23ac60b64134da4051b753b31f0a5a4bdca9959c2e5e0b54fba1fd84bc6c8d4f40a864098c5e39c4ba0798b98cba4448249cf96f69eec28b271032919ff6d44160b50408eaf6d3543bc586aad52b734ff689e75921a517edacc0486ca43a2f4363a125",
                ExtendedInformation = "fbd01191500e4463a160a731c54824eaae7bcb336c1a4caa831a10f8216cdb001ea2207181214ec09708a1ab55c35373b025b40f5d9246e18327bbfccbad17d2be90fa01f6d34b64bbe2a99e54f5ed973ac04475a10143048304d329331890910084c65c39724b22b2b896c240897321cd6387bc7293483a831fb81819ca3bbec42438e8d9534c9c9f51ac1bfc83498e0a5ac517bed24a24968f6394b8a9657d60f5bc18cf2f494784db9c7e705f5debcb9abe2f2ac644a29a6388941aeb909f432856f263f742ffabbcd1afe62d1de676c2ac6171f74d00a419348058903358f31c9ea3d71343089f9453c849f5003fd96aa66720274b0a87be",
                DateA = new DateTime(2005, 5, 24),
                DateD = new DateTime(2021, 7, 22),
                Sort = 1322539961,
                Note = "b67b4c0aadc44a9f9ba6f2a3c9e906bb6329008858ad4cbb8ee3d2288a5b44be3ab798b6fc4a486680b886ee24b633a738492c5fdbba47a683e4708b733852ab5cd5497b13c3499583ead77b4f06b240b45ad06ec3cf4f3082a6455ebd6859082a038793d0164f2ba97ce095374d685ac0e60ee43b4541c3b440aa5880a17b1e6b72a1cda74f429c80b752fcd381cf88acfe3aeb79854555890c35ba9af743f0e989e6a2dc7949d4b859a83a03422699094761458ffe460fa97fe88f4b01341d8a8fe63563fa41419cea751ee40729e2897a63b8125742e5a6f8df90f876c8c146800ec5cbbb4ecdb61079b741245fc5594501e869f84b97b72a",
                Status = "e1668fb62fc04ba7926dc7b672bc17582d9c95d0b4874a24ae"
            };

            // Act
            var serviceResult = await _systemDisplayMessagesAppService.UpdateAsync(Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"), input);

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.DisplayTypeCode.ShouldBe("fd91e415bdeb4c0cb49a59e5826bd556adb7725d24c44d67b7");
            result.TitleContents.ShouldBe("3b5ff0766fea46f4a31ef3b11784003f686ff4ffa3f94840980aaafe264c56e5b9137cc59ecd49ce8512eac090caa5c03ceffa019f584dc1ac9e5876198d7e709bf2c8bc486f4c09b8020e45c6ab8f87002e0454161a49daa4b9c5ad073f6d7c914290e4de9f412b8ff6b4bd10452be2fab684bc46e84d54a16a0368668af1a22376521561f74d048a5251ef57418b488c7aa7c7d583400087a7b6a35cdca9281f8092377657408ca61469a61d5e4aac61633f2671014eec805204483dc322983b1530c4517d44579d8343d07d8318f200d6cee71e424dbb9dd481967a1cbef3e8c557c724dc4347acf45e38fc7bb543c1a3135a499549a8a5fa");
            result.Contents.ShouldBe("355c6d63c42241cc968baa3a7b0e816030e58584abcd41978e31737da37966644131c15754294094b41566588ff4e4f2ff493bfebae14f0baf1ef7c27bfde8568c19cfa638094cbca0ff8ca0db46d61a9199a12a79a942a3bd40b75eacf3f35b1406019f14c54361a7d3165cedc93f5634166a13befe4e809f7e00377efa6a2bdc796f1bb8e04a1996f872ef030d5c0f4fb95b031b244e23ac60b64134da4051b753b31f0a5a4bdca9959c2e5e0b54fba1fd84bc6c8d4f40a864098c5e39c4ba0798b98cba4448249cf96f69eec28b271032919ff6d44160b50408eaf6d3543bc586aad52b734ff689e75921a517edacc0486ca43a2f4363a125");
            result.ExtendedInformation.ShouldBe("fbd01191500e4463a160a731c54824eaae7bcb336c1a4caa831a10f8216cdb001ea2207181214ec09708a1ab55c35373b025b40f5d9246e18327bbfccbad17d2be90fa01f6d34b64bbe2a99e54f5ed973ac04475a10143048304d329331890910084c65c39724b22b2b896c240897321cd6387bc7293483a831fb81819ca3bbec42438e8d9534c9c9f51ac1bfc83498e0a5ac517bed24a24968f6394b8a9657d60f5bc18cf2f494784db9c7e705f5debcb9abe2f2ac644a29a6388941aeb909f432856f263f742ffabbcd1afe62d1de676c2ac6171f74d00a419348058903358f31c9ea3d71343089f9453c849f5003fd96aa66720274b0a87be");
            result.DateA.ShouldBe(new DateTime(2005, 5, 24));
            result.DateD.ShouldBe(new DateTime(2021, 7, 22));
            result.Sort.ShouldBe(1322539961);
            result.Note.ShouldBe("b67b4c0aadc44a9f9ba6f2a3c9e906bb6329008858ad4cbb8ee3d2288a5b44be3ab798b6fc4a486680b886ee24b633a738492c5fdbba47a683e4708b733852ab5cd5497b13c3499583ead77b4f06b240b45ad06ec3cf4f3082a6455ebd6859082a038793d0164f2ba97ce095374d685ac0e60ee43b4541c3b440aa5880a17b1e6b72a1cda74f429c80b752fcd381cf88acfe3aeb79854555890c35ba9af743f0e989e6a2dc7949d4b859a83a03422699094761458ffe460fa97fe88f4b01341d8a8fe63563fa41419cea751ee40729e2897a63b8125742e5a6f8df90f876c8c146800ec5cbbb4ecdb61079b741245fc5594501e869f84b97b72a");
            result.Status.ShouldBe("e1668fb62fc04ba7926dc7b672bc17582d9c95d0b4874a24ae");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemDisplayMessagesAppService.DeleteAsync(Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"));

            // Assert
            var result = await _systemDisplayMessageRepository.FindAsync(c => c.Id == Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"));

            result.ShouldBeNull();
        }
    }
}