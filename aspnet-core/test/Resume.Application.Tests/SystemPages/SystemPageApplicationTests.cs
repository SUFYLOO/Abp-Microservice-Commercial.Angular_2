using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemPages
{
    public class SystemPagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemPagesAppService _systemPagesAppService;
        private readonly IRepository<SystemPage, Guid> _systemPageRepository;

        public SystemPagesAppServiceTests()
        {
            _systemPagesAppService = GetRequiredService<ISystemPagesAppService>();
            _systemPageRepository = GetRequiredService<IRepository<SystemPage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemPagesAppService.GetListAsync(new GetSystemPagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("e12249a3-1e7b-4463-82cb-2108ba40740a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemPagesAppService.GetAsync(Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemPageCreateDto
            {
                TypeCode = "8730441f2dd140ffbf1f2e85114b45f3b34bbd259da54c3c93",
                FilePath = "71cbdb12793f47109dabaadb929891838aaf28ef53ef40fbb11ffe4969f098c9c64742258f1e422791fdbc90055c9826e9bfc77c845141f38df67976fa9e2ebe5d2ea865ee264811a592b67181bcda414b66dcadbb544eed99edb473b261fdcb14fb2bdf85ae43dfab2299a95cf3ad0994ee4def5cf94a25811e0f7691533fab0055f7b0de814e8fbcd8710fe8881412de731737b5394274b333a3e91ef4bc211ea8783ea1a9411ca18e8c30c57024eac47b7ab0d9704275bfc4b58305cce5f8cc1ebd003d6344e783a0510dc8e02cf817e9ef437739486ba6b5c91fedab7735cd51700cc4bb4964952049db8463272cbf28e15057a64679a94b",
                FileName = "aa7239ea8b8243d3a95fadf87b587b543bb5c70395e24d53ad2ded14582fe151e0eb5343d54240ffae2dc47fb5170cf136c8e19feb3c4a0b8fde6e152bfbcfd544bbd8b6a5e34b2bb5329a7aa1cf64fb619e10ef4ba14706bdca118148ba8e49fb5d1e45259a41d5bebd32839ceda7302e6be4104adb496887d529ddcc604d6261a564822ce84e7eb42babfe4f685d90d2a6c4e3f9234107b8af2eede3f4f8fec464357e96df4aeb9581ea3b5c521e0e0df24bb13b444d5094d3637a23484ae6ba9dc124c2ea45c8b6d30436760366f58e9e0002c38f42849b965b760b2ecb95194209c7426a4546ac2d098de7e31b80fdc21c84baa14b1ba7c2",
                FileTitle = "35b9b00ec1c742048a3bb317a8c4c75c3e5d8091fc994f8aa9f84fde77847e6f82e396dc55bf4b998b64a659b1b135e8056cdba0dc1c4f0faa52a559777cafa51d4e3534d4a04a8ab110af8b5b6614e9f3a428336b074465bb7faae86cff1f198f47da06",
                SystemUserRoleKeys = "e58758d7b8c540fbacf7b781d69b0bdb5b67de3ad3a44cb1bb",
                ParentCode = "69da6ad7434148318da749f62ecaee85b301ab8e03b04fdea2",
                ExtendedInformation = "d628560877f449ee8f10fd27ef5c51b943b58242ccef4204a34f67d56f7ba79693ddab53dcba4937a77770ebd9a00e40ffc0559c95e5416e81c870b1abec0542c490539ea37e449faa6f27bcbbb78f90322f2a45e72343a58a6838bf11f3a2585a60e3a773014fe48869e935f51830028f4a206a135445ed872a4657d874ba164518529bdbf445b7a348042fe2db709370af4d5579d2466583cdd22eeb0e5048cbe3f0fbaa3d43be8f2ab23fe87be68857dfe8eb10a94b46adfc552429d2bbe850e9ccde347746a39edccc4763e8c521c5e9209474524b7bbd86439ae39363de7dff69f5ee5f474795b55b0b66b3054ee0b6f83d1ae84d95ae53",
                DateA = new DateTime(2021, 5, 23),
                DateD = new DateTime(2016, 8, 26),
                Sort = 1982238558,
                Note = "1c08aff97e5d4b3d9528946055fefe2eb12e9d5f289444118c6c297e4df56decf8c639bc40474cc0b201533cf2009eb5081b328bee734dda9d977b2bfdd72eb601920bb0580d4e6890b1733ae1fd0b70c5a935d522ff4426999b4c5a80b0bd734fffcf21968b41458fe0b391ba3fc2657913bb0d32284522ac611033fb698099d2964fd5384b41fa93e8d10b916569b8ed2a8087899e4e36ab823de3de6bba1d70b92a551db94a9a988aa476762ed7840c072784d67c4bd483f07f4fbc70dd7d7eb3f6dce95f460b96d14ab9b1a195500a8d738be1f64e888debdc29f35a2d34ed59f71cb6974e81a270e691d7c77abd1e7cd2f97c474d128a7f",
                Status = "3406e5701b5c4de68ea5d139c15048461e12abd1222b4fa0b0"
            };

            // Act
            var serviceResult = await _systemPagesAppService.CreateAsync(input);

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TypeCode.ShouldBe("8730441f2dd140ffbf1f2e85114b45f3b34bbd259da54c3c93");
            result.FilePath.ShouldBe("71cbdb12793f47109dabaadb929891838aaf28ef53ef40fbb11ffe4969f098c9c64742258f1e422791fdbc90055c9826e9bfc77c845141f38df67976fa9e2ebe5d2ea865ee264811a592b67181bcda414b66dcadbb544eed99edb473b261fdcb14fb2bdf85ae43dfab2299a95cf3ad0994ee4def5cf94a25811e0f7691533fab0055f7b0de814e8fbcd8710fe8881412de731737b5394274b333a3e91ef4bc211ea8783ea1a9411ca18e8c30c57024eac47b7ab0d9704275bfc4b58305cce5f8cc1ebd003d6344e783a0510dc8e02cf817e9ef437739486ba6b5c91fedab7735cd51700cc4bb4964952049db8463272cbf28e15057a64679a94b");
            result.FileName.ShouldBe("aa7239ea8b8243d3a95fadf87b587b543bb5c70395e24d53ad2ded14582fe151e0eb5343d54240ffae2dc47fb5170cf136c8e19feb3c4a0b8fde6e152bfbcfd544bbd8b6a5e34b2bb5329a7aa1cf64fb619e10ef4ba14706bdca118148ba8e49fb5d1e45259a41d5bebd32839ceda7302e6be4104adb496887d529ddcc604d6261a564822ce84e7eb42babfe4f685d90d2a6c4e3f9234107b8af2eede3f4f8fec464357e96df4aeb9581ea3b5c521e0e0df24bb13b444d5094d3637a23484ae6ba9dc124c2ea45c8b6d30436760366f58e9e0002c38f42849b965b760b2ecb95194209c7426a4546ac2d098de7e31b80fdc21c84baa14b1ba7c2");
            result.FileTitle.ShouldBe("35b9b00ec1c742048a3bb317a8c4c75c3e5d8091fc994f8aa9f84fde77847e6f82e396dc55bf4b998b64a659b1b135e8056cdba0dc1c4f0faa52a559777cafa51d4e3534d4a04a8ab110af8b5b6614e9f3a428336b074465bb7faae86cff1f198f47da06");
            result.SystemUserRoleKeys.ShouldBe("e58758d7b8c540fbacf7b781d69b0bdb5b67de3ad3a44cb1bb");
            result.ParentCode.ShouldBe("69da6ad7434148318da749f62ecaee85b301ab8e03b04fdea2");
            result.ExtendedInformation.ShouldBe("d628560877f449ee8f10fd27ef5c51b943b58242ccef4204a34f67d56f7ba79693ddab53dcba4937a77770ebd9a00e40ffc0559c95e5416e81c870b1abec0542c490539ea37e449faa6f27bcbbb78f90322f2a45e72343a58a6838bf11f3a2585a60e3a773014fe48869e935f51830028f4a206a135445ed872a4657d874ba164518529bdbf445b7a348042fe2db709370af4d5579d2466583cdd22eeb0e5048cbe3f0fbaa3d43be8f2ab23fe87be68857dfe8eb10a94b46adfc552429d2bbe850e9ccde347746a39edccc4763e8c521c5e9209474524b7bbd86439ae39363de7dff69f5ee5f474795b55b0b66b3054ee0b6f83d1ae84d95ae53");
            result.DateA.ShouldBe(new DateTime(2021, 5, 23));
            result.DateD.ShouldBe(new DateTime(2016, 8, 26));
            result.Sort.ShouldBe(1982238558);
            result.Note.ShouldBe("1c08aff97e5d4b3d9528946055fefe2eb12e9d5f289444118c6c297e4df56decf8c639bc40474cc0b201533cf2009eb5081b328bee734dda9d977b2bfdd72eb601920bb0580d4e6890b1733ae1fd0b70c5a935d522ff4426999b4c5a80b0bd734fffcf21968b41458fe0b391ba3fc2657913bb0d32284522ac611033fb698099d2964fd5384b41fa93e8d10b916569b8ed2a8087899e4e36ab823de3de6bba1d70b92a551db94a9a988aa476762ed7840c072784d67c4bd483f07f4fbc70dd7d7eb3f6dce95f460b96d14ab9b1a195500a8d738be1f64e888debdc29f35a2d34ed59f71cb6974e81a270e691d7c77abd1e7cd2f97c474d128a7f");
            result.Status.ShouldBe("3406e5701b5c4de68ea5d139c15048461e12abd1222b4fa0b0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemPageUpdateDto()
            {
                TypeCode = "a4d256a5e913479aa3d436820e953106abe26775f9e846e7a9",
                FilePath = "e2310ef36d9e42078ed15dca455b34cc60b0b6541edd4b93b5d14b644b7f9cdb7d537d1156164617bb2bd29f7a94d04f7336492d985a406d9869a437a22d573b3f792bb1604045b28f4458d0f066d541a0d9609cbe1c4d19976219d0a20998f5f7856a3b0af4497eb61b6124fdb2c4bedbf129372fd54dd296814bf1f2dcb86e440f2ff667c24260b34ce87faa93bea3ae418b150b774f9fa967c0461eaab16e8e48475a6e8d4266b452482f062aae91bc165083d48a462faa472dbf6c9b9eddd453adc7d5a549099e267970759fbf1a8b9090bf9385493cbac037b170710ffc05aefe59d6bb4bfba8ab6b074743ba86ecc3f7104d524dc0bb37",
                FileName = "af80c8abc91849ce9e812b6d1c2e5bda09fc8d75fb1c489e9f1e9817ad8e499c2ec7fd0fd8d84416a5e073abd1875ea996f7396f8e354470a25064df29cf140247e650b1b822495396f2679dc0efb8a64441412a4acd4c01b43d093cd69b8ffdb3a42cec6aa046d0a567f3dc22dbbbdf1bbdaa751f8f44d99ce67cc5b02732429e209f4382e64c55aa4fda7651b09b2612d1775445944965bf1dd5a6e726979766ca6a1a7aaa42cfb1f73b1c2b575eb8973b9476f7e34d548f89276dcac65f84f7860dd32d53421fa5d734b567df7253063999374cfe457f9b28fe5fac1d81504823a0479444482c9c898242f7e6363db89c7c0cd81b4d7da924",
                FileTitle = "6fabd02c9a124a6d91b5fe7b8a8b87a754999a960f5144a0b8b8152822b035dabf01ecf7f2a14cbdbc420c3033714867bf830faf9300434ca3f701d8268ea671e94c30010c34459d9ed2ebe5ac7a0bc679555ce87dbf42f695397db428477014300a8367",
                SystemUserRoleKeys = "731adff5c1864c358bb8cf8b7251826f13ab0f937b73408ebf",
                ParentCode = "1dc310bd9fb24dd0840a7e3b202671a630eec76f66d04beaba",
                ExtendedInformation = "3765c2d174204c6e8005acac6088d00057c585da7f064423a6ea6890a379b320b8a2826afddf4323aceac2d9b34bc2265faff5fcb96d4f42a7e5ed1836e39bd37644a43273fe4ad486c7064666dc4a43c1ef2095a32941249ce304f9cd1f734725907bb379214df08a8f19347eb1c5bf6c30479823a14f8c9beec72a9241f99d199ac499b5954132aa67f3a6fcf5a5e4db3cc04826c34367b9a106bb1902ae21c7a4c8e4cff444248d9b844cf33bcf1c9107c0765d2c47ceadb476a30ec13096cabc59de732846e9bc904344efabba09af5c9a9d150e4a229c11f656c8c4555a2089e959efe0407da3327d674a090204d904e44ea2424cf0ab22",
                DateA = new DateTime(2005, 7, 5),
                DateD = new DateTime(2020, 10, 26),
                Sort = 992823643,
                Note = "a087a8b02a9948a2a1cf19baa90881717d6a003c4abd4dc091a4402fb1dcac26f2890b1474e846a0b8de8bfbeb949535ceaa2702202c419ca783b5ba2dbf809b191c8fef9c9d4917b8b45c64cf809b3562094d2b9ceb4a709fba6a41b49c6449974bc8f65b354fc2bed7cae0dc27b0a5be1b7cb0b1d04eb5b9f8f617169d063ca70fc2ab9ef442598caf97419064631f50657a74effe4032a1c787fa5384470449582eaaabfe416dba227625f52710eba4d5f2d860da4d9a8bd85fae6e7aba1ac132c47771bd4c029976eb2c9e64a747f89cf6fe6eeb455a9cdc978272254f64b09ea482caae47839afdec799d78063f533bd9f71d1c4f40a8fb",
                Status = "80353feaffb84faf903074fc77d103d75015e61a277c4d2ca3"
            };

            // Act
            var serviceResult = await _systemPagesAppService.UpdateAsync(Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"), input);

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.TypeCode.ShouldBe("a4d256a5e913479aa3d436820e953106abe26775f9e846e7a9");
            result.FilePath.ShouldBe("e2310ef36d9e42078ed15dca455b34cc60b0b6541edd4b93b5d14b644b7f9cdb7d537d1156164617bb2bd29f7a94d04f7336492d985a406d9869a437a22d573b3f792bb1604045b28f4458d0f066d541a0d9609cbe1c4d19976219d0a20998f5f7856a3b0af4497eb61b6124fdb2c4bedbf129372fd54dd296814bf1f2dcb86e440f2ff667c24260b34ce87faa93bea3ae418b150b774f9fa967c0461eaab16e8e48475a6e8d4266b452482f062aae91bc165083d48a462faa472dbf6c9b9eddd453adc7d5a549099e267970759fbf1a8b9090bf9385493cbac037b170710ffc05aefe59d6bb4bfba8ab6b074743ba86ecc3f7104d524dc0bb37");
            result.FileName.ShouldBe("af80c8abc91849ce9e812b6d1c2e5bda09fc8d75fb1c489e9f1e9817ad8e499c2ec7fd0fd8d84416a5e073abd1875ea996f7396f8e354470a25064df29cf140247e650b1b822495396f2679dc0efb8a64441412a4acd4c01b43d093cd69b8ffdb3a42cec6aa046d0a567f3dc22dbbbdf1bbdaa751f8f44d99ce67cc5b02732429e209f4382e64c55aa4fda7651b09b2612d1775445944965bf1dd5a6e726979766ca6a1a7aaa42cfb1f73b1c2b575eb8973b9476f7e34d548f89276dcac65f84f7860dd32d53421fa5d734b567df7253063999374cfe457f9b28fe5fac1d81504823a0479444482c9c898242f7e6363db89c7c0cd81b4d7da924");
            result.FileTitle.ShouldBe("6fabd02c9a124a6d91b5fe7b8a8b87a754999a960f5144a0b8b8152822b035dabf01ecf7f2a14cbdbc420c3033714867bf830faf9300434ca3f701d8268ea671e94c30010c34459d9ed2ebe5ac7a0bc679555ce87dbf42f695397db428477014300a8367");
            result.SystemUserRoleKeys.ShouldBe("731adff5c1864c358bb8cf8b7251826f13ab0f937b73408ebf");
            result.ParentCode.ShouldBe("1dc310bd9fb24dd0840a7e3b202671a630eec76f66d04beaba");
            result.ExtendedInformation.ShouldBe("3765c2d174204c6e8005acac6088d00057c585da7f064423a6ea6890a379b320b8a2826afddf4323aceac2d9b34bc2265faff5fcb96d4f42a7e5ed1836e39bd37644a43273fe4ad486c7064666dc4a43c1ef2095a32941249ce304f9cd1f734725907bb379214df08a8f19347eb1c5bf6c30479823a14f8c9beec72a9241f99d199ac499b5954132aa67f3a6fcf5a5e4db3cc04826c34367b9a106bb1902ae21c7a4c8e4cff444248d9b844cf33bcf1c9107c0765d2c47ceadb476a30ec13096cabc59de732846e9bc904344efabba09af5c9a9d150e4a229c11f656c8c4555a2089e959efe0407da3327d674a090204d904e44ea2424cf0ab22");
            result.DateA.ShouldBe(new DateTime(2005, 7, 5));
            result.DateD.ShouldBe(new DateTime(2020, 10, 26));
            result.Sort.ShouldBe(992823643);
            result.Note.ShouldBe("a087a8b02a9948a2a1cf19baa90881717d6a003c4abd4dc091a4402fb1dcac26f2890b1474e846a0b8de8bfbeb949535ceaa2702202c419ca783b5ba2dbf809b191c8fef9c9d4917b8b45c64cf809b3562094d2b9ceb4a709fba6a41b49c6449974bc8f65b354fc2bed7cae0dc27b0a5be1b7cb0b1d04eb5b9f8f617169d063ca70fc2ab9ef442598caf97419064631f50657a74effe4032a1c787fa5384470449582eaaabfe416dba227625f52710eba4d5f2d860da4d9a8bd85fae6e7aba1ac132c47771bd4c029976eb2c9e64a747f89cf6fe6eeb455a9cdc978272254f64b09ea482caae47839afdec799d78063f533bd9f71d1c4f40a8fb");
            result.Status.ShouldBe("80353feaffb84faf903074fc77d103d75015e61a277c4d2ca3");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemPagesAppService.DeleteAsync(Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"));

            // Assert
            var result = await _systemPageRepository.FindAsync(c => c.Id == Guid.Parse("8212dec1-c4b9-4172-a55f-c603f378bbbf"));

            result.ShouldBeNull();
        }
    }
}