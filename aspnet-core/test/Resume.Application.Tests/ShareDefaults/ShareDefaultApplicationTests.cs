using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareDefaults
{
    public class ShareDefaultsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareDefaultsAppService _shareDefaultsAppService;
        private readonly IRepository<ShareDefault, Guid> _shareDefaultRepository;

        public ShareDefaultsAppServiceTests()
        {
            _shareDefaultsAppService = GetRequiredService<IShareDefaultsAppService>();
            _shareDefaultRepository = GetRequiredService<IRepository<ShareDefault, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareDefaultsAppService.GetListAsync(new GetShareDefaultsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("858cd8e6-dceb-47d0-9ebd-6b367fea5e1f")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareDefaultsAppService.GetAsync(Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareDefaultCreateDto
            {
                GroupCode = "f362341c6cf54a63ac7542a747020229605c5ec5c3a142f9b8",
                Key1 = "c7292b90a02e4c50bc55b7d888c200d32e4fb7403b384a79a6",
                Key2 = "cc90685c8f1041fd9f40241e95eb1a902f650a23293245738f",
                Key3 = "bbf5f3b15b804160b67460a0d63dcad4cc34988558d34c3397",
                Name = "f32798dc7aac43698a3c38cafcf6fed286c4b4de24e44cb7be481475dac43cbdbbfa2f6ee8224b2082d56fc237602c637fb4f646cb434dd59c5df8ce49cbede5e2e209f645dd43c5aaa77daf9ccf8841777f3e5f1216484296faa64cf005ac109674ed73",
                FieldKey = "f839cf5b784e40bc86926fed767216a8bf19187056a84101a1",
                FieldValue = "282fb8c31bf349c2ad7071bb2441052c8d6bed7c5c504c0090ca7a001be8e4a18644b872e1814edd80af150d257c7b61af9e9c07b90e4c23bd961245f8d20c9ce43925b081f14800b50cd79d231e6beff278622d113a4ef488bc35479222b52cb5a454ab332146859f147832ac57b28caee68d549342466f839d902ac793ec5d6f32ed5e119c4131904f19fe3279013725e26d36ec974311ba11f9eaebd157029e8b4d1a7afe4693865722478288875189495ca15abf4ffbbb9fb463e48ca2d22dc750a270d446f4b8ebb302e39e623212d903c9e62748e798b4c720db57d4d84f960b2ff6a044048e5b96a50b879b95ae23a90119264422b14a",
                ColumnTypeCode = "772b98188bcd48b8ad9da5fd02904afd70173986614d439385",
                FormTypeCode = "dbbd0c10da70464c96e38b0f2a1799eeeaf271506525410fa4",
                SystemUse = true,
                ExtendedInformation = "d79c007aa5d54d599df10f3e329947120bc6890eba6a47e68a269e98e5ab5ca60d2d84f2b72c4f4fb082864c793c1d2ada609b99cc2e4d2583f975713c1d11a97bd170abcdad4602bbb07245c06cb253a2598c50d54244b7a154ac7d0aafb58ebde5c50e96b14d3ba23d71f65e6751efc4e0c42c23a9404887902e7a74677849e3038bff9e9e48a7bf1ef81a8552dd11a678a41a3b4b4f318185e2e98bc938af0616c21496e84629b0a8cb6e401d613d60ef4d1497f249f1ac2a6210a9caafc75f2ba79df2b04d009453b44c52baa7640ea3f42abe9a4d0b9b9837b7cddc0a680e10bded66f744a9b23e134ccc8a08e295bd2a1e897d49f8a119",
                DateA = new DateTime(2013, 3, 5),
                DateD = new DateTime(2020, 9, 19),
                Sort = 1706149819,
                Note = "0e2042d738494487be075252da85c0d79f47a08a7aec4bb7950a64aa7174f062896efa1f5f6b449b93f25691e2b1b9fc6c3a55c3bfde4d59b2f4cb37685f0b72b6dee48015c146b5b66057de0632ae88fd103d0a60a74f3c8dfaf772efc28f85de4b1bcaec154cb3b273fbd31cddcedd4ef2bf132c1a451389e22f6384cdf8f62f71eee6097f494fa9fad2e30c1c92200ced066d1d984aa1b5b2d00b36ecd8a2486e8a6487654f398db7f1ff787af64216b69eef435f4c90818165c4f4511ec8a991eb996c094f2fbcc7c6421ae5bafdd7ccacb20f52415aa8cfe68454ef957b0f73e66bddca4665b6c8fa0de6c4b3dac5749828941f4c2f8f20",
                Status = "510e91f887364b4b8edd766b64e5b7ae0aa1122a24a2493586"
            };

            // Act
            var serviceResult = await _shareDefaultsAppService.CreateAsync(input);

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("f362341c6cf54a63ac7542a747020229605c5ec5c3a142f9b8");
            result.Key1.ShouldBe("c7292b90a02e4c50bc55b7d888c200d32e4fb7403b384a79a6");
            result.Key2.ShouldBe("cc90685c8f1041fd9f40241e95eb1a902f650a23293245738f");
            result.Key3.ShouldBe("bbf5f3b15b804160b67460a0d63dcad4cc34988558d34c3397");
            result.Name.ShouldBe("f32798dc7aac43698a3c38cafcf6fed286c4b4de24e44cb7be481475dac43cbdbbfa2f6ee8224b2082d56fc237602c637fb4f646cb434dd59c5df8ce49cbede5e2e209f645dd43c5aaa77daf9ccf8841777f3e5f1216484296faa64cf005ac109674ed73");
            result.FieldKey.ShouldBe("f839cf5b784e40bc86926fed767216a8bf19187056a84101a1");
            result.FieldValue.ShouldBe("282fb8c31bf349c2ad7071bb2441052c8d6bed7c5c504c0090ca7a001be8e4a18644b872e1814edd80af150d257c7b61af9e9c07b90e4c23bd961245f8d20c9ce43925b081f14800b50cd79d231e6beff278622d113a4ef488bc35479222b52cb5a454ab332146859f147832ac57b28caee68d549342466f839d902ac793ec5d6f32ed5e119c4131904f19fe3279013725e26d36ec974311ba11f9eaebd157029e8b4d1a7afe4693865722478288875189495ca15abf4ffbbb9fb463e48ca2d22dc750a270d446f4b8ebb302e39e623212d903c9e62748e798b4c720db57d4d84f960b2ff6a044048e5b96a50b879b95ae23a90119264422b14a");
            result.ColumnTypeCode.ShouldBe("772b98188bcd48b8ad9da5fd02904afd70173986614d439385");
            result.FormTypeCode.ShouldBe("dbbd0c10da70464c96e38b0f2a1799eeeaf271506525410fa4");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("d79c007aa5d54d599df10f3e329947120bc6890eba6a47e68a269e98e5ab5ca60d2d84f2b72c4f4fb082864c793c1d2ada609b99cc2e4d2583f975713c1d11a97bd170abcdad4602bbb07245c06cb253a2598c50d54244b7a154ac7d0aafb58ebde5c50e96b14d3ba23d71f65e6751efc4e0c42c23a9404887902e7a74677849e3038bff9e9e48a7bf1ef81a8552dd11a678a41a3b4b4f318185e2e98bc938af0616c21496e84629b0a8cb6e401d613d60ef4d1497f249f1ac2a6210a9caafc75f2ba79df2b04d009453b44c52baa7640ea3f42abe9a4d0b9b9837b7cddc0a680e10bded66f744a9b23e134ccc8a08e295bd2a1e897d49f8a119");
            result.DateA.ShouldBe(new DateTime(2013, 3, 5));
            result.DateD.ShouldBe(new DateTime(2020, 9, 19));
            result.Sort.ShouldBe(1706149819);
            result.Note.ShouldBe("0e2042d738494487be075252da85c0d79f47a08a7aec4bb7950a64aa7174f062896efa1f5f6b449b93f25691e2b1b9fc6c3a55c3bfde4d59b2f4cb37685f0b72b6dee48015c146b5b66057de0632ae88fd103d0a60a74f3c8dfaf772efc28f85de4b1bcaec154cb3b273fbd31cddcedd4ef2bf132c1a451389e22f6384cdf8f62f71eee6097f494fa9fad2e30c1c92200ced066d1d984aa1b5b2d00b36ecd8a2486e8a6487654f398db7f1ff787af64216b69eef435f4c90818165c4f4511ec8a991eb996c094f2fbcc7c6421ae5bafdd7ccacb20f52415aa8cfe68454ef957b0f73e66bddca4665b6c8fa0de6c4b3dac5749828941f4c2f8f20");
            result.Status.ShouldBe("510e91f887364b4b8edd766b64e5b7ae0aa1122a24a2493586");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareDefaultUpdateDto()
            {
                GroupCode = "18ecbc7c37944fb7962311abe45ef9298f367e71797d40dbab",
                Key1 = "9e1e60faf2494313aa12201c865fa1bd038715174534440b82",
                Key2 = "6dea260280014110839525c1754740fcbb4dc213717a42df96",
                Key3 = "d367bd92152d44489a1369756858d724619816c31b2f4be8b1",
                Name = "1fd7a8841bcf496c9bcc34664db378c86fce971e003343498f6ab11fd2ea28e9476f8ca4e9854609a0f68b40f90a2ccc4fb3a7b30a7b4ea7ab468bddaa46228ba43423c6591642d4a5525d937e19d3926241996d9bdd4ce28428d61735ed6969cdf9d463",
                FieldKey = "f9f70d26eb4948779e841a1ca2649a03f8b1a0105d1f40f59c",
                FieldValue = "54ba378471be4677a8bfc53500c079006ca3a5dca64b4fce91942dc7afb96ab319a62aa598524774ae21fae06a971e7e74ba2f5733a54345a1309946107e85f8dbdff3e3ca4c4a6184ea008e65e2ff23d0f9730efe534566953e7f04d66a00a2142a4b8ebcfa47159ab026585e715e4a7e6c4e10cf974490b41a295b7790e52884c018de5d6c45a09bf57b2f03f0d671fe384b4bf37f4264836411526067788976d39e916dc047d4a0e9c48c3eb570bb55184f5e6ce1416caf9905212973503e42f95e593e654e9e9d9197abebfdd56f1af65fe5efc1467cb183044cca6d4af8635949936c4e40ec9735009c6d867f110179e191ae3c465a804e",
                ColumnTypeCode = "3e0c404fe1e4448b92e362c046924685a245bc7d17724485a0",
                FormTypeCode = "41d9f3862182469f83c96ca30ad0498f2af4edcccc9a4bda86",
                SystemUse = true,
                ExtendedInformation = "e166e69d3b0d412d8472112dd76df8eb5e85d759fb224b8087109fb71ea82a2e7082e8d8d933476989421b1d99e37793b49d2100d952490ea89d7a45fef24ce11b839264dccc43e9aa702f4a17ed599a33f0c2c6ad2244b083617d89ee842dca4b8808c683f944ee816757528db450cb3adf84b1e2574ca3bfe3be4ad881dae50860faa6ea0a453f82f347a0b673fc7aa9c5ce2ee3b54c79a292d12159b6bc1ab2b34aafbb6b459b86208f14bc55f3cae4e358b6006c4ed1aa8d3ded8a118918bf0fb047f3014bc2baf0965ddb17b602d5ddea33a41c418b8c55533b5e72c70ffb95b7ebb3554071931ae1ce5537f4eb6e51a83c53fa49dc9761",
                DateA = new DateTime(2020, 6, 13),
                DateD = new DateTime(2016, 9, 13),
                Sort = 232746609,
                Note = "6de2556e6b1f48b0badd99c52b4a2289136d2a411aac4ac69da256aaa6be846134f27e37887b4f4592bc5f50931e01ab296f1b5f2de8428f9ca2c8b63bc488b34bb03e0ebea24127ae62b8500da5654844fcbf6f32534d919526d06a5db9130e7b8803e3faef40dfbbad348ddc4a10f1c9f369e717d04b5c8ebeb82e943ca88638d698dd6bd54cc29480c7015c2a42dbc2b25d0a67db45f59f4beb8a529a15f1c7dbc8f994cc400e8094e5836eb11bde4fb316ff9b4d453daa5e28ee85116dae8a8c01f237374d369845757410dbb0295c634f42b5854b7bbdec9c54e367eedd9b8b5008c8604d30bb00bb8d9c2ce44566f6394eec934aefa3d1",
                Status = "9edc92f2912a430aa0b9a936e921104cbc6786c7df3543cebb"
            };

            // Act
            var serviceResult = await _shareDefaultsAppService.UpdateAsync(Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"), input);

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.GroupCode.ShouldBe("18ecbc7c37944fb7962311abe45ef9298f367e71797d40dbab");
            result.Key1.ShouldBe("9e1e60faf2494313aa12201c865fa1bd038715174534440b82");
            result.Key2.ShouldBe("6dea260280014110839525c1754740fcbb4dc213717a42df96");
            result.Key3.ShouldBe("d367bd92152d44489a1369756858d724619816c31b2f4be8b1");
            result.Name.ShouldBe("1fd7a8841bcf496c9bcc34664db378c86fce971e003343498f6ab11fd2ea28e9476f8ca4e9854609a0f68b40f90a2ccc4fb3a7b30a7b4ea7ab468bddaa46228ba43423c6591642d4a5525d937e19d3926241996d9bdd4ce28428d61735ed6969cdf9d463");
            result.FieldKey.ShouldBe("f9f70d26eb4948779e841a1ca2649a03f8b1a0105d1f40f59c");
            result.FieldValue.ShouldBe("54ba378471be4677a8bfc53500c079006ca3a5dca64b4fce91942dc7afb96ab319a62aa598524774ae21fae06a971e7e74ba2f5733a54345a1309946107e85f8dbdff3e3ca4c4a6184ea008e65e2ff23d0f9730efe534566953e7f04d66a00a2142a4b8ebcfa47159ab026585e715e4a7e6c4e10cf974490b41a295b7790e52884c018de5d6c45a09bf57b2f03f0d671fe384b4bf37f4264836411526067788976d39e916dc047d4a0e9c48c3eb570bb55184f5e6ce1416caf9905212973503e42f95e593e654e9e9d9197abebfdd56f1af65fe5efc1467cb183044cca6d4af8635949936c4e40ec9735009c6d867f110179e191ae3c465a804e");
            result.ColumnTypeCode.ShouldBe("3e0c404fe1e4448b92e362c046924685a245bc7d17724485a0");
            result.FormTypeCode.ShouldBe("41d9f3862182469f83c96ca30ad0498f2af4edcccc9a4bda86");
            result.SystemUse.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("e166e69d3b0d412d8472112dd76df8eb5e85d759fb224b8087109fb71ea82a2e7082e8d8d933476989421b1d99e37793b49d2100d952490ea89d7a45fef24ce11b839264dccc43e9aa702f4a17ed599a33f0c2c6ad2244b083617d89ee842dca4b8808c683f944ee816757528db450cb3adf84b1e2574ca3bfe3be4ad881dae50860faa6ea0a453f82f347a0b673fc7aa9c5ce2ee3b54c79a292d12159b6bc1ab2b34aafbb6b459b86208f14bc55f3cae4e358b6006c4ed1aa8d3ded8a118918bf0fb047f3014bc2baf0965ddb17b602d5ddea33a41c418b8c55533b5e72c70ffb95b7ebb3554071931ae1ce5537f4eb6e51a83c53fa49dc9761");
            result.DateA.ShouldBe(new DateTime(2020, 6, 13));
            result.DateD.ShouldBe(new DateTime(2016, 9, 13));
            result.Sort.ShouldBe(232746609);
            result.Note.ShouldBe("6de2556e6b1f48b0badd99c52b4a2289136d2a411aac4ac69da256aaa6be846134f27e37887b4f4592bc5f50931e01ab296f1b5f2de8428f9ca2c8b63bc488b34bb03e0ebea24127ae62b8500da5654844fcbf6f32534d919526d06a5db9130e7b8803e3faef40dfbbad348ddc4a10f1c9f369e717d04b5c8ebeb82e943ca88638d698dd6bd54cc29480c7015c2a42dbc2b25d0a67db45f59f4beb8a529a15f1c7dbc8f994cc400e8094e5836eb11bde4fb316ff9b4d453daa5e28ee85116dae8a8c01f237374d369845757410dbb0295c634f42b5854b7bbdec9c54e367eedd9b8b5008c8604d30bb00bb8d9c2ce44566f6394eec934aefa3d1");
            result.Status.ShouldBe("9edc92f2912a430aa0b9a936e921104cbc6786c7df3543cebb");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareDefaultsAppService.DeleteAsync(Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"));

            // Assert
            var result = await _shareDefaultRepository.FindAsync(c => c.Id == Guid.Parse("08a23b4d-27e2-40dd-8d4e-104c01f4518b"));

            result.ShouldBeNull();
        }
    }
}