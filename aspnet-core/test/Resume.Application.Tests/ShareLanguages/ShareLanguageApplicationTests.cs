using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareLanguages
{
    public class ShareLanguagesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareLanguagesAppService _shareLanguagesAppService;
        private readonly IRepository<ShareLanguage, Guid> _shareLanguageRepository;

        public ShareLanguagesAppServiceTests()
        {
            _shareLanguagesAppService = GetRequiredService<IShareLanguagesAppService>();
            _shareLanguageRepository = GetRequiredService<IRepository<ShareLanguage, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareLanguagesAppService.GetListAsync(new GetShareLanguagesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("cda9d92d-7803-44f7-bf77-023a3e22494c")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareLanguagesAppService.GetAsync(Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareLanguageCreateDto
            {
                Name = "6472896e9f174332a23b81110a4227b8bbfabda50e7540028a",
                ExtendedInformation = "e6e59c395fac41c2ab0cd86811ab3b3481e9738b845c40d685c38651b6ff229705af2a329bcc44e99978ec4f332ec39431c95c387237404c8bf641957cb2ff9987af3ecf53444f6f9e621b0e6fb061bd690a0d2c6b8949a49afacf7cdd8a538a85c21af8e3784c90868634bfae9e152c5d33b6a530284a68be74fcc17029eb4ef3cba795b8a24c32ac52fcf315572e30cee4bf8552514b7bb8ba1f52f8a6ca3511da20c5823b444f9968d3f9b2316b03f4688d12d9494b7f964b371a200c79382b1c467444294b129f6cfb954a04b0bc5110e430d8e54dbaa2d086095c699ba455e5d51d691f475da2dbd9ae946316f9967b91a0e1984edfa9b9",
                DateA = new DateTime(2011, 6, 18),
                DateD = new DateTime(2002, 5, 15),
                Sort = 1553416866,
                Note = "990a8b4d346049449cdedd117422506a1a388efb013b4c7fa2531c444f0787e2308bcc1e9b684348a81308c992725799932cf73c0562413f8c280b1518b299727cd5f5fac742489fa54c42816aa926a937f63beacbf646029e06045316db3f8cb85f2f53293c41d4a36c61899468e492d44f34d63a5b4d1d90f44f78b810a68f6d23635c901e4050acab13cb10695db1a91165e6ea5d4859968a0a0924a81de7e1bb48b1dc1c4bd4bd1a965d1f0021b888102c0f71524df3a434aa3cb13c524b5dc8ddede256421184fd600b41e6ea78686c3902bb6c47d4933b3fcc8ed2233103731a5813ee47a887b74edaddf818cd02baba7cc30940b2a6f7",
                Status = "794b9531969a45e989c40dcc777281166bffecffa0dd4871aa"
            };

            // Act
            var serviceResult = await _shareLanguagesAppService.CreateAsync(input);

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("6472896e9f174332a23b81110a4227b8bbfabda50e7540028a");
            result.ExtendedInformation.ShouldBe("e6e59c395fac41c2ab0cd86811ab3b3481e9738b845c40d685c38651b6ff229705af2a329bcc44e99978ec4f332ec39431c95c387237404c8bf641957cb2ff9987af3ecf53444f6f9e621b0e6fb061bd690a0d2c6b8949a49afacf7cdd8a538a85c21af8e3784c90868634bfae9e152c5d33b6a530284a68be74fcc17029eb4ef3cba795b8a24c32ac52fcf315572e30cee4bf8552514b7bb8ba1f52f8a6ca3511da20c5823b444f9968d3f9b2316b03f4688d12d9494b7f964b371a200c79382b1c467444294b129f6cfb954a04b0bc5110e430d8e54dbaa2d086095c699ba455e5d51d691f475da2dbd9ae946316f9967b91a0e1984edfa9b9");
            result.DateA.ShouldBe(new DateTime(2011, 6, 18));
            result.DateD.ShouldBe(new DateTime(2002, 5, 15));
            result.Sort.ShouldBe(1553416866);
            result.Note.ShouldBe("990a8b4d346049449cdedd117422506a1a388efb013b4c7fa2531c444f0787e2308bcc1e9b684348a81308c992725799932cf73c0562413f8c280b1518b299727cd5f5fac742489fa54c42816aa926a937f63beacbf646029e06045316db3f8cb85f2f53293c41d4a36c61899468e492d44f34d63a5b4d1d90f44f78b810a68f6d23635c901e4050acab13cb10695db1a91165e6ea5d4859968a0a0924a81de7e1bb48b1dc1c4bd4bd1a965d1f0021b888102c0f71524df3a434aa3cb13c524b5dc8ddede256421184fd600b41e6ea78686c3902bb6c47d4933b3fcc8ed2233103731a5813ee47a887b74edaddf818cd02baba7cc30940b2a6f7");
            result.Status.ShouldBe("794b9531969a45e989c40dcc777281166bffecffa0dd4871aa");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareLanguageUpdateDto()
            {
                Name = "f0ebd97537f8405fa321789e509659d062de2a87275c4861b7",
                ExtendedInformation = "044b36e426a04d878b839618e39673101bd099dfd332496bba1e591f7fd47560b15d454e581f4f249ee3708be11ab7d7fbfb94743a074ce6ae8a2dbcdc72478b1d0d9ed1a8374144b44ef5d05cf9353156d52496d8244dc88b7f4a55a7037599c23fa2356aa9484c8009db4a3cf1378afe56efec2ae443b0ae4bf7aeda8f19309839d975c4314fb08690f6f122f8313b9dd67f0f55d84d6c943883f523de56b327258b6b0bac44059de0d06bf1c960edbd2cb3ead3de4ea19876bb48c9bd5a4f5a068a9ab0d14f3abfeed3d80500de81b4bfb022937b4a37a80f798e8a53b01c7b6a1b06b42b49e6adc2a4d14d221cf90a1c9d5c62ef4dbcbdc0",
                DateA = new DateTime(2018, 2, 6),
                DateD = new DateTime(2020, 10, 6),
                Sort = 31839380,
                Note = "70f1b41edba14437ad3dced72971df1f4087773647c84805aff0b955bad7203b03339efdafdf4e13a0911ae5d81912756598b7a00b8749698a087a5a74b3403b172b92ac463e414d90ed4388007a05672c57ab52362644eea19e6ab4e4640fa60d5bec50bd4d4be6a26aa3b190ba3d7c7fd015eb7d9d41d79877868c0a6d0bd1eaf7452c5d3840269236c57082fcafd3b234aca135614d14be2e0637ebcbba872819bf223d7c45ad9586d1668b17695a055f7874245d4036b9ab23e7912ac4cfac85940cdaa5488cb5acbb0bfe91ab603fa037d8e2084fcfb3f3ceb50a3bb0bcf74cda35844a4374b626829bf4de18be275f3a4c131f4edfa456",
                Status = "61d53a406afc4b068d5b51cb63827b4ad2944d688598431d9d"
            };

            // Act
            var serviceResult = await _shareLanguagesAppService.UpdateAsync(Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"), input);

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.Name.ShouldBe("f0ebd97537f8405fa321789e509659d062de2a87275c4861b7");
            result.ExtendedInformation.ShouldBe("044b36e426a04d878b839618e39673101bd099dfd332496bba1e591f7fd47560b15d454e581f4f249ee3708be11ab7d7fbfb94743a074ce6ae8a2dbcdc72478b1d0d9ed1a8374144b44ef5d05cf9353156d52496d8244dc88b7f4a55a7037599c23fa2356aa9484c8009db4a3cf1378afe56efec2ae443b0ae4bf7aeda8f19309839d975c4314fb08690f6f122f8313b9dd67f0f55d84d6c943883f523de56b327258b6b0bac44059de0d06bf1c960edbd2cb3ead3de4ea19876bb48c9bd5a4f5a068a9ab0d14f3abfeed3d80500de81b4bfb022937b4a37a80f798e8a53b01c7b6a1b06b42b49e6adc2a4d14d221cf90a1c9d5c62ef4dbcbdc0");
            result.DateA.ShouldBe(new DateTime(2018, 2, 6));
            result.DateD.ShouldBe(new DateTime(2020, 10, 6));
            result.Sort.ShouldBe(31839380);
            result.Note.ShouldBe("70f1b41edba14437ad3dced72971df1f4087773647c84805aff0b955bad7203b03339efdafdf4e13a0911ae5d81912756598b7a00b8749698a087a5a74b3403b172b92ac463e414d90ed4388007a05672c57ab52362644eea19e6ab4e4640fa60d5bec50bd4d4be6a26aa3b190ba3d7c7fd015eb7d9d41d79877868c0a6d0bd1eaf7452c5d3840269236c57082fcafd3b234aca135614d14be2e0637ebcbba872819bf223d7c45ad9586d1668b17695a055f7874245d4036b9ab23e7912ac4cfac85940cdaa5488cb5acbb0bfe91ab603fa037d8e2084fcfb3f3ceb50a3bb0bcf74cda35844a4374b626829bf4de18be275f3a4c131f4edfa456");
            result.Status.ShouldBe("61d53a406afc4b068d5b51cb63827b4ad2944d688598431d9d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareLanguagesAppService.DeleteAsync(Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"));

            // Assert
            var result = await _shareLanguageRepository.FindAsync(c => c.Id == Guid.Parse("fed32ea2-e37c-49f6-971a-1b58489c2b0f"));

            result.ShouldBeNull();
        }
    }
}