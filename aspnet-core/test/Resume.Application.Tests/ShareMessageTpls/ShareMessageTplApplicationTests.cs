using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTplsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareMessageTplsAppService _shareMessageTplsAppService;
        private readonly IRepository<ShareMessageTpl, Guid> _shareMessageTplRepository;

        public ShareMessageTplsAppServiceTests()
        {
            _shareMessageTplsAppService = GetRequiredService<IShareMessageTplsAppService>();
            _shareMessageTplRepository = GetRequiredService<IRepository<ShareMessageTpl, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareMessageTplsAppService.GetListAsync(new GetShareMessageTplsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3c8835fb-d3be-4cd4-bcd1-7b7c7813669c")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareMessageTplsAppService.GetAsync(Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareMessageTplCreateDto
            {
                Key1 = "c5035cd654504021b08dd73acb8afa4c29ed350a6d63457ea4",
                Key2 = "6a9bbee04ec743d5ad41b12f7ef30e5ad40816147a544da494",
                Key3 = "c02b9c82f8e840e78c9ad6b421add51ed7d697cadfb14cb087",
                Name = "83d44d33cac04ab29825afed85c46fa6ad8799cd9e6f43fdb7",
                Statement = "5b86e970ca17482e8b6367b6e9acc7f34f671b89d4954129b9d2a6728486c58e3625e7e30db94a21a5228409eb66a6543bb7c750bb9040669e676ad40ffb20086e4afec2727a4a038f5aa165a58aedd2c41cdf27e1d34d2aa950e876d3bfc4f3a95678cf036f482bb04933d99bdc848dca7f100a9da84b9fa8ade4a1fd47e2b87d33379a9b594925bcc6007baadf1a13f15423f80cf24f8c8fd8e8d6608bfdc250fb64fb866e450b82d8bc90a944d62657cec5d167b44a998e7cdd3fb3a635a47a5c15f143264d64bc673dbdc73033ef2471e9ea56c04098a60e33b427d69f8ae229ad2fbf9e46aa8cc835de0b1924fe6497b03e2f4f4670b0e2",
                TitleContents = "061672b0ea5e4fcb97d10ad526d8795ceb9a94930774454f899c3b2f4e9acf80d140efd531934d4498f8f86015deead71d783ea852994416b70406f8fc584d9cdf90f59c00054ae597f64ac625ffc943ad99fbf3d397495986842434b4de5cbbfa30724bdab645968c091106d0ea0397ef03624650a44ba088011a5d6a876abb74c2a50f0ca84578892967c540a84d44ee71e810593e404686fb45fc94cb3558abc515f0de02417a8c5223c2c1fc0ae61a035d283daf44399c2b0750656d980e8525b4b0cccc47bf96d2743422b92594dbfea47042934e3e89725d0557fe2293179a1f864b814b0890c754e88fee90c76da0f373f35d4cc9972a",
                ContentMail = "ff60bd7067c24044aeffb9ab7f5159fab2e0153e839d480aaaa5cc08bf4",
                ContentSMS = "49987913a4844cf0bb19af35ecff19e6f45f4d1f0a8646fea658ebacbb11bfe2d62ef0d6bafa43b7ad2907846456e7de4fc5d50100ce4d1cbec2ddc765ba9872a7baf907b86e4c659a5bd6eaf31c348459afd695e5db41e5ba2c66dea267e85152767a7915904cdaa171f2f5dd5096a84d1c966c6b424cdbb10beea47d3ccb21aa4f87e03ad04379a8bb006e68ddc69c8238181aef4c4658b6f904c141c264129f6d845877a7427db8420d3712511907e2935eba6a5743dea631d66cc84b3a4dc5dd49f26b2a4a17a8f362251aa3a5faa08c71f7c1b84c92b905dbdd684bafc9e1e3b3e6d6d8480c83c407dd5c460aedc3a84e2ad8d140288f4a",
                ExtendedInformation = "5330e67e59d5428884261478a30df760962008e63b7548b6954cb181d323ecc4cab744b7e6b6436bbd59a3409a7ff13bde9cacaf77de4f8386db4f88376105ab8801b271b92146bd8a17fa1657735763ecebac6318aa4b73977515f62fdd913749c69609b0964c8dbdab152133c7806fc056d1d3126c4535a4de972b8bf61d044a09bcc2414e46a899e8ef4d4f46307deecad1c225c34adfb4d6a027b04f1bf5265a6d3e7d3a49c98798bad63b28d5e95fd195b666eb457f941d22086d8ffbf7ce530d65a8d94f528d1aec971eff64cb6feaa668b03541eb97b628c83301eeff28e12044d0a241dc85408e3834c3078173c575243824476a9930",
                DateA = new DateTime(2000, 6, 1),
                DateD = new DateTime(2005, 9, 23),
                Sort = 280613712,
                Note = "d8ea533dec93459fa1ffe18f10f931ef10e660932ff24003bec3225ae11cad883fb52800c46a43829b74af001c4e4dfa45980a0f83c9493cbc6024d3f250dccca33650ce2ddc4a6ca44233f14f0a4d619f18217f0d0d4958abca6132ec5bea168d866a8dca78443b98f74722b4e023617375f76a34ac42e9aaa75adad27124f16ab3b24e04d14bc59dff4493943f968ce6d2214fb2314da58848bd0d2045d83d7e0b971b8c4a43d0abc70584726dff2ea99ddbe946244d638072016fe218d982b40a83bb76d549629a025d0c8058835edfedadec3abf4db5819278a9468a0b78de49b003d5604b4bbc507b4f0e78531da9b703caa37a459bb05c",
                Status = "83fbce8cb51a4d4f9e1b820f6b17cee206d2abf42f78452c9e"
            };

            // Act
            var serviceResult = await _shareMessageTplsAppService.CreateAsync(input);

            // Assert
            var result = await _shareMessageTplRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("c5035cd654504021b08dd73acb8afa4c29ed350a6d63457ea4");
            result.Key2.ShouldBe("6a9bbee04ec743d5ad41b12f7ef30e5ad40816147a544da494");
            result.Key3.ShouldBe("c02b9c82f8e840e78c9ad6b421add51ed7d697cadfb14cb087");
            result.Name.ShouldBe("83d44d33cac04ab29825afed85c46fa6ad8799cd9e6f43fdb7");
            result.Statement.ShouldBe("5b86e970ca17482e8b6367b6e9acc7f34f671b89d4954129b9d2a6728486c58e3625e7e30db94a21a5228409eb66a6543bb7c750bb9040669e676ad40ffb20086e4afec2727a4a038f5aa165a58aedd2c41cdf27e1d34d2aa950e876d3bfc4f3a95678cf036f482bb04933d99bdc848dca7f100a9da84b9fa8ade4a1fd47e2b87d33379a9b594925bcc6007baadf1a13f15423f80cf24f8c8fd8e8d6608bfdc250fb64fb866e450b82d8bc90a944d62657cec5d167b44a998e7cdd3fb3a635a47a5c15f143264d64bc673dbdc73033ef2471e9ea56c04098a60e33b427d69f8ae229ad2fbf9e46aa8cc835de0b1924fe6497b03e2f4f4670b0e2");
            result.TitleContents.ShouldBe("061672b0ea5e4fcb97d10ad526d8795ceb9a94930774454f899c3b2f4e9acf80d140efd531934d4498f8f86015deead71d783ea852994416b70406f8fc584d9cdf90f59c00054ae597f64ac625ffc943ad99fbf3d397495986842434b4de5cbbfa30724bdab645968c091106d0ea0397ef03624650a44ba088011a5d6a876abb74c2a50f0ca84578892967c540a84d44ee71e810593e404686fb45fc94cb3558abc515f0de02417a8c5223c2c1fc0ae61a035d283daf44399c2b0750656d980e8525b4b0cccc47bf96d2743422b92594dbfea47042934e3e89725d0557fe2293179a1f864b814b0890c754e88fee90c76da0f373f35d4cc9972a");
            result.ContentMail.ShouldBe("ff60bd7067c24044aeffb9ab7f5159fab2e0153e839d480aaaa5cc08bf4");
            result.ContentSMS.ShouldBe("49987913a4844cf0bb19af35ecff19e6f45f4d1f0a8646fea658ebacbb11bfe2d62ef0d6bafa43b7ad2907846456e7de4fc5d50100ce4d1cbec2ddc765ba9872a7baf907b86e4c659a5bd6eaf31c348459afd695e5db41e5ba2c66dea267e85152767a7915904cdaa171f2f5dd5096a84d1c966c6b424cdbb10beea47d3ccb21aa4f87e03ad04379a8bb006e68ddc69c8238181aef4c4658b6f904c141c264129f6d845877a7427db8420d3712511907e2935eba6a5743dea631d66cc84b3a4dc5dd49f26b2a4a17a8f362251aa3a5faa08c71f7c1b84c92b905dbdd684bafc9e1e3b3e6d6d8480c83c407dd5c460aedc3a84e2ad8d140288f4a");
            result.ExtendedInformation.ShouldBe("5330e67e59d5428884261478a30df760962008e63b7548b6954cb181d323ecc4cab744b7e6b6436bbd59a3409a7ff13bde9cacaf77de4f8386db4f88376105ab8801b271b92146bd8a17fa1657735763ecebac6318aa4b73977515f62fdd913749c69609b0964c8dbdab152133c7806fc056d1d3126c4535a4de972b8bf61d044a09bcc2414e46a899e8ef4d4f46307deecad1c225c34adfb4d6a027b04f1bf5265a6d3e7d3a49c98798bad63b28d5e95fd195b666eb457f941d22086d8ffbf7ce530d65a8d94f528d1aec971eff64cb6feaa668b03541eb97b628c83301eeff28e12044d0a241dc85408e3834c3078173c575243824476a9930");
            result.DateA.ShouldBe(new DateTime(2000, 6, 1));
            result.DateD.ShouldBe(new DateTime(2005, 9, 23));
            result.Sort.ShouldBe(280613712);
            result.Note.ShouldBe("d8ea533dec93459fa1ffe18f10f931ef10e660932ff24003bec3225ae11cad883fb52800c46a43829b74af001c4e4dfa45980a0f83c9493cbc6024d3f250dccca33650ce2ddc4a6ca44233f14f0a4d619f18217f0d0d4958abca6132ec5bea168d866a8dca78443b98f74722b4e023617375f76a34ac42e9aaa75adad27124f16ab3b24e04d14bc59dff4493943f968ce6d2214fb2314da58848bd0d2045d83d7e0b971b8c4a43d0abc70584726dff2ea99ddbe946244d638072016fe218d982b40a83bb76d549629a025d0c8058835edfedadec3abf4db5819278a9468a0b78de49b003d5604b4bbc507b4f0e78531da9b703caa37a459bb05c");
            result.Status.ShouldBe("83fbce8cb51a4d4f9e1b820f6b17cee206d2abf42f78452c9e");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareMessageTplUpdateDto()
            {
                Key1 = "f2828e63a4e34e598d857467241dfae07248195b9e8b4f2eaf",
                Key2 = "a9ea36ce11504b1c84c736a96dc2ccaafa5813a3b44c4fd496",
                Key3 = "6ce038b0183e43d0b53dbed62402665dc8db5a08d336451a84",
                Name = "c3507abfd8ca485e853a72d37ab7b9f2227134bc6b014460aa",
                Statement = "c38f47a3b24f435b961c784a14108c2b891dc2e53fff46b3a07719a16dc65d345b272d5821904c9b90a415f32040b8e96cac958ffd4543a2bdd1b931bfdebe9c51446e4cb97c48169190a898f3a52f6493cd5c281e164908b913e3b63d64be56fdb0e8a4586b4fa8b98cf620e9eefe48b4dfe0ea4b194921b7d2b5bf318d7c0acb069dd2110e4bc8863cd8dfb61ddc06a3c1114b8cfc45caadd04e5d38c278c955517e3f837f45b4a3bf7bd9373c10f37dd2d8a2d1a246e495fae61f8da27634c1a2ffd466db4da2a000f21076175f3269e4e0efe9a54d5a93233d61f327b6c62621bf7e8d5f4537b3509189d255323505339a39df4a4fd28e60",
                TitleContents = "2d0a8ad876574107a81edb2966f1cb2ad4fbeb2effde4b6e969f249407d57be1957eb458dd1a452c8ebf8e24fa98a9392410a97621f24fab8aeb628427790e479d276acfd8d146f2868bd6169865d4f1df3647b61db9481b9c199ae96cd03e83758e20b35ceb4a8f878aa1a9052cfc47ab5e08407d27470086da77b6d50f5ef5aac680c794084726b213acebefebd8ed68b4861488354e67b678a9f8c095892baa7cb38875d944809ad36a7be9c1551037f0a34b04f34dc5a4a756e932bf531e129fb7cd61464ab4a3d9eb645f7f10b3add11f81769743fc999dcfc9701a40c57e1af0bb14024390b12d5fe4465089c9a8743209f22c48798cd1",
                ContentMail = "ec30874ce6a",
                ContentSMS = "8d42c83b62d4463e90019a68101efd174948d6aa289d4610944cdf3c6903ddfe710db9a2674c45a69c5ee18ceeca68adf52547787ca04f058330af6f29f4fa04fbf936747cdd429fac99c73da8ceb0910a988b1ec8eb4e93a58cf4eadf3c95d14a05f7ae9b2847048be241e43bc087c80cdaefe679d74ed7beece40793538ea56ad46ee09cbb43ff8a050d3ea0a989483bb4931cacaa4e87ad6a5aaa3898035d1d31278f25454a8da8bff3a597c60bf927b13a3dbce6465fb8b741230636a7af57a46f82e0ab4501a6a7c0c76c9d399b785445dbb65d42d98c4fb60629ed8076b3f217017dac41d0b466c6b0c22f664479fd2e2974544777b5dd",
                ExtendedInformation = "c26eacb007d043139acc46cd767f34b2ccfb9c7e965c4137972d8cd4337c517475e7146707304fa294c618b301732bdbcc425e9a24ae48c4b5e5c29bdb551f2c6e7102aee6a946c58b9cc79591cdd7a31a6879c05d084024b3d51ee76e27da656e3cace4b68042498c5cce40baf467d0a8936504c4af4ed7b6d0ff2f9b6918e08b5fff66bcd54310a657b5c293edcf3514eda696bcf04d96a541bd3bbf842067e59661ece5fb4e51bcb359e3437145817cb746872b9e409ab47c828ddaaafc5edcf6be5df4a64f92b12064807cd75bf98104526d4b8a4f0bac1560a2187cc72a20e066d54d4c4f9c9b073a8fb6473243c8bab37c3f2540d4b3ca",
                DateA = new DateTime(2010, 10, 25),
                DateD = new DateTime(2013, 1, 10),
                Sort = 2017592238,
                Note = "f4ac4e59a7c8484dbca694f090691bdfac706665968b488fb3d9fa3a2b622520936f9a14587b47db9bd32468955000d680d1698f8be44470bc20d90a4f7549c2c7a8415cdb144060b0cb9cff7926ad7bc508fe93445a4fb9967607d77f00f5de774643e22b3f4f5d8641d4f1a343381731577f530c81405f8847f1962264eafd529f9a3e2f234ba98735e1c4d7424ab166c54396c4944bf88e00690469b632c32d355a495672485bb84e264f76bc5a0b606748267b7142a7b8f9f66553419ea28f9d477cc97c4b028406b4a5dcf40b4568454e70ad8c48569d6e3ddd1faa7d0b443767210f374a9ebde9f6ff20dfd65c9b215b3222a74b27be24",
                Status = "6266b58990a643e383592a8b98c6326495071fb481bc4569be"
            };

            // Act
            var serviceResult = await _shareMessageTplsAppService.UpdateAsync(Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"), input);

            // Assert
            var result = await _shareMessageTplRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Key1.ShouldBe("f2828e63a4e34e598d857467241dfae07248195b9e8b4f2eaf");
            result.Key2.ShouldBe("a9ea36ce11504b1c84c736a96dc2ccaafa5813a3b44c4fd496");
            result.Key3.ShouldBe("6ce038b0183e43d0b53dbed62402665dc8db5a08d336451a84");
            result.Name.ShouldBe("c3507abfd8ca485e853a72d37ab7b9f2227134bc6b014460aa");
            result.Statement.ShouldBe("c38f47a3b24f435b961c784a14108c2b891dc2e53fff46b3a07719a16dc65d345b272d5821904c9b90a415f32040b8e96cac958ffd4543a2bdd1b931bfdebe9c51446e4cb97c48169190a898f3a52f6493cd5c281e164908b913e3b63d64be56fdb0e8a4586b4fa8b98cf620e9eefe48b4dfe0ea4b194921b7d2b5bf318d7c0acb069dd2110e4bc8863cd8dfb61ddc06a3c1114b8cfc45caadd04e5d38c278c955517e3f837f45b4a3bf7bd9373c10f37dd2d8a2d1a246e495fae61f8da27634c1a2ffd466db4da2a000f21076175f3269e4e0efe9a54d5a93233d61f327b6c62621bf7e8d5f4537b3509189d255323505339a39df4a4fd28e60");
            result.TitleContents.ShouldBe("2d0a8ad876574107a81edb2966f1cb2ad4fbeb2effde4b6e969f249407d57be1957eb458dd1a452c8ebf8e24fa98a9392410a97621f24fab8aeb628427790e479d276acfd8d146f2868bd6169865d4f1df3647b61db9481b9c199ae96cd03e83758e20b35ceb4a8f878aa1a9052cfc47ab5e08407d27470086da77b6d50f5ef5aac680c794084726b213acebefebd8ed68b4861488354e67b678a9f8c095892baa7cb38875d944809ad36a7be9c1551037f0a34b04f34dc5a4a756e932bf531e129fb7cd61464ab4a3d9eb645f7f10b3add11f81769743fc999dcfc9701a40c57e1af0bb14024390b12d5fe4465089c9a8743209f22c48798cd1");
            result.ContentMail.ShouldBe("ec30874ce6a");
            result.ContentSMS.ShouldBe("8d42c83b62d4463e90019a68101efd174948d6aa289d4610944cdf3c6903ddfe710db9a2674c45a69c5ee18ceeca68adf52547787ca04f058330af6f29f4fa04fbf936747cdd429fac99c73da8ceb0910a988b1ec8eb4e93a58cf4eadf3c95d14a05f7ae9b2847048be241e43bc087c80cdaefe679d74ed7beece40793538ea56ad46ee09cbb43ff8a050d3ea0a989483bb4931cacaa4e87ad6a5aaa3898035d1d31278f25454a8da8bff3a597c60bf927b13a3dbce6465fb8b741230636a7af57a46f82e0ab4501a6a7c0c76c9d399b785445dbb65d42d98c4fb60629ed8076b3f217017dac41d0b466c6b0c22f664479fd2e2974544777b5dd");
            result.ExtendedInformation.ShouldBe("c26eacb007d043139acc46cd767f34b2ccfb9c7e965c4137972d8cd4337c517475e7146707304fa294c618b301732bdbcc425e9a24ae48c4b5e5c29bdb551f2c6e7102aee6a946c58b9cc79591cdd7a31a6879c05d084024b3d51ee76e27da656e3cace4b68042498c5cce40baf467d0a8936504c4af4ed7b6d0ff2f9b6918e08b5fff66bcd54310a657b5c293edcf3514eda696bcf04d96a541bd3bbf842067e59661ece5fb4e51bcb359e3437145817cb746872b9e409ab47c828ddaaafc5edcf6be5df4a64f92b12064807cd75bf98104526d4b8a4f0bac1560a2187cc72a20e066d54d4c4f9c9b073a8fb6473243c8bab37c3f2540d4b3ca");
            result.DateA.ShouldBe(new DateTime(2010, 10, 25));
            result.DateD.ShouldBe(new DateTime(2013, 1, 10));
            result.Sort.ShouldBe(2017592238);
            result.Note.ShouldBe("f4ac4e59a7c8484dbca694f090691bdfac706665968b488fb3d9fa3a2b622520936f9a14587b47db9bd32468955000d680d1698f8be44470bc20d90a4f7549c2c7a8415cdb144060b0cb9cff7926ad7bc508fe93445a4fb9967607d77f00f5de774643e22b3f4f5d8641d4f1a343381731577f530c81405f8847f1962264eafd529f9a3e2f234ba98735e1c4d7424ab166c54396c4944bf88e00690469b632c32d355a495672485bb84e264f76bc5a0b606748267b7142a7b8f9f66553419ea28f9d477cc97c4b028406b4a5dcf40b4568454e70ad8c48569d6e3ddd1faa7d0b443767210f374a9ebde9f6ff20dfd65c9b215b3222a74b27be24");
            result.Status.ShouldBe("6266b58990a643e383592a8b98c6326495071fb481bc4569be");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareMessageTplsAppService.DeleteAsync(Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"));

            // Assert
            var result = await _shareMessageTplRepository.FindAsync(c => c.Id == Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"));

            result.ShouldBeNull();
        }
    }
}