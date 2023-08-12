using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeSnapshotsAppService _resumeSnapshotsAppService;
        private readonly IRepository<ResumeSnapshot, Guid> _resumeSnapshotRepository;

        public ResumeSnapshotsAppServiceTests()
        {
            _resumeSnapshotsAppService = GetRequiredService<IResumeSnapshotsAppService>();
            _resumeSnapshotRepository = GetRequiredService<IRepository<ResumeSnapshot, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeSnapshotsAppService.GetListAsync(new GetResumeSnapshotsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("42ba9321-b044-458e-aaef-40287ebfd28c")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeSnapshotsAppService.GetAsync(Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeSnapshotCreateDto
            {
                UserMainId = Guid.Parse("7de8baae-d735-4a8e-93ce-ccfe7c1af8fe"),
                ResumeMainId = Guid.Parse("6b4dc869-72fa-400b-974b-ba57061310e5"),
                CompanyMainId = Guid.Parse("2d1138b6-3747-43ca-ad62-d197b302ede3"),
                CompanyJobId = Guid.Parse("ed331c7e-17a1-427e-a092-3759961637ef"),
                Snapshot = "b041b099ebfa46708ac83c71b875ed3",
                UserCompanyBindId = Guid.Parse("7e1b2a65-5254-4fef-a877-83ff2b91a68c"),
                ExtendedInformation = "c28ec28a123d4b48a3e19f7e8bef38252159ab72c9d44c4e8b89524402a29f1608bac70e2a384b3cbf3191c6f01c4a654fbdde18cbe841e6b6f6f39f70e7a308eb28474c8ccc4ba7aae1f538d24ebebac46c0e0c01b745129ab5776cab5851dd8ad9ca5f29834356955a210181634ec018ecc9faa058470b939f30f86583854c2073ef855fa04bcb9e6e993073e3928ba4ea675076be488ca26e6eecab7cb74aa3329d5e44c94454b4d61ab74917fcf51ede65ec325a4a9d97bbbba79278d35b091ba5395fa043a08e9bec6dc479b0307220c12dd2a543498ac15a881141ef118d008926432640a1b8cd692d449fc8fd6c96faf6c34c42a894f6",
                DateA = new DateTime(2005, 5, 22),
                DateD = new DateTime(2014, 11, 23),
                Sort = 451628161,
                Note = "1648d713630541afbf6f9145858705e4c1046edaeb984862ab61b69b55086ef573aaadb3d57b4a08a346c7614cad0cd4a5dc322bdc954d1695fa639237a4791b7e72a3b9e8824c82896a9dd216477b9d73e2a5ecd06644ee87e3e467278b78476acd640c06c6489bbe30c19b76e957da256a7c22059e43158983024e7e66801c251773e4939446c69170ed6c0e928821f87ffc1c30944e1eb845bfc2dbbcec40a897bdb12cfc43aaa2bba810e902c94671048c4ae12c4378b48c959c6be94b1eee87e76cdb864d8680de274cffb5efc54372152863bc4d01ad28719b92c599d62dd8840d91224e269fc9ce23e2d1e203f69abf28570e4300af1e",
                Status = "e8a24f2dd47143e7aac9c4210c4649d28bb82b5489724953a3"
            };

            // Act
            var serviceResult = await _resumeSnapshotsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("7de8baae-d735-4a8e-93ce-ccfe7c1af8fe"));
            result.ResumeMainId.ShouldBe(Guid.Parse("6b4dc869-72fa-400b-974b-ba57061310e5"));
            result.CompanyMainId.ShouldBe(Guid.Parse("2d1138b6-3747-43ca-ad62-d197b302ede3"));
            result.CompanyJobId.ShouldBe(Guid.Parse("ed331c7e-17a1-427e-a092-3759961637ef"));
            result.Snapshot.ShouldBe("b041b099ebfa46708ac83c71b875ed3");
            result.UserCompanyBindId.ShouldBe(Guid.Parse("7e1b2a65-5254-4fef-a877-83ff2b91a68c"));
            result.ExtendedInformation.ShouldBe("c28ec28a123d4b48a3e19f7e8bef38252159ab72c9d44c4e8b89524402a29f1608bac70e2a384b3cbf3191c6f01c4a654fbdde18cbe841e6b6f6f39f70e7a308eb28474c8ccc4ba7aae1f538d24ebebac46c0e0c01b745129ab5776cab5851dd8ad9ca5f29834356955a210181634ec018ecc9faa058470b939f30f86583854c2073ef855fa04bcb9e6e993073e3928ba4ea675076be488ca26e6eecab7cb74aa3329d5e44c94454b4d61ab74917fcf51ede65ec325a4a9d97bbbba79278d35b091ba5395fa043a08e9bec6dc479b0307220c12dd2a543498ac15a881141ef118d008926432640a1b8cd692d449fc8fd6c96faf6c34c42a894f6");
            result.DateA.ShouldBe(new DateTime(2005, 5, 22));
            result.DateD.ShouldBe(new DateTime(2014, 11, 23));
            result.Sort.ShouldBe(451628161);
            result.Note.ShouldBe("1648d713630541afbf6f9145858705e4c1046edaeb984862ab61b69b55086ef573aaadb3d57b4a08a346c7614cad0cd4a5dc322bdc954d1695fa639237a4791b7e72a3b9e8824c82896a9dd216477b9d73e2a5ecd06644ee87e3e467278b78476acd640c06c6489bbe30c19b76e957da256a7c22059e43158983024e7e66801c251773e4939446c69170ed6c0e928821f87ffc1c30944e1eb845bfc2dbbcec40a897bdb12cfc43aaa2bba810e902c94671048c4ae12c4378b48c959c6be94b1eee87e76cdb864d8680de274cffb5efc54372152863bc4d01ad28719b92c599d62dd8840d91224e269fc9ce23e2d1e203f69abf28570e4300af1e");
            result.Status.ShouldBe("e8a24f2dd47143e7aac9c4210c4649d28bb82b5489724953a3");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeSnapshotUpdateDto()
            {
                UserMainId = Guid.Parse("19bf76cc-f5d5-4560-8123-b2ece44fd979"),
                ResumeMainId = Guid.Parse("4bf64989-0200-44fd-9e4f-47a274a8b664"),
                CompanyMainId = Guid.Parse("dcd17eb3-f1ea-475b-914b-caecad0687e5"),
                CompanyJobId = Guid.Parse("d27ba0e5-2e83-4c98-ae68-c7ecf8266305"),
                Snapshot = "0ba151fbbc0b480994b595457789b7b43ca0b67e3c634edeac9c0cf21386f8e3b08c15d8403c4cc19526e2c3c2f718d6ad9",
                UserCompanyBindId = Guid.Parse("73fa9f1a-0519-448d-a022-9e5da0005637"),
                ExtendedInformation = "e716a455f54e4d5098579955e78dedf42182261c096e41d4ab57a19fcb2b2ac8158829c9fcec4b0d93a6adf18f548dadcc379af184a84a288ee961aa18a4353047ec7cb3fa3d40749e529df5b2b7e0aac5ffb17b51704aa1900f94fcd674d8fdda94ab8cafd64482ab54945756900205ffe446a391654998b85ab5f35b9236418884ae9cc1f142248d8c2fdd36527a482edd60925d2440f3af92d19828d84fbb159334483a0b43cf854fa8fd3276d77931ca59a0e1bf4382823056e870b890e2e9e5504b944c4de8b8e7f010a3865d5793f1c0475b1e4d3e9af142260be4c49c8a6e2dbf4ed1401d82e2765038f8fb92237fea3f488349e6abc4",
                DateA = new DateTime(2005, 11, 15),
                DateD = new DateTime(2006, 3, 6),
                Sort = 2083017365,
                Note = "1f33ccb53bbb49cdb25831d9b08e006788b7a0f44a5e449eb0baba3165ddd190291d2a1d30e7492a845c0d3beb07dd807409468bfd93424bb0cb1324794ffa52802e6f0e024944e0b8bab74adc21aa0475fe737705c84b668bd4e06e29c408442e19912834d746fb889fcb7fd1c48caf7dcb565f184d4be68ebc106ffe1f5d43e9719e7ac58e4000b7ce77671ef2ff47961682c316b94ff18c5182821c14f80a63d7aa51f8e04e61b46710871a2c072f76ab753b41c44c4ba1e7483487d9b7d377252a8deedc42f9991a33aa2f705eeee579c4075ae94f3cafaefd8bd50eae9f49e3eb23e27d44608b84ddb54ebae21ee2cb33571b774f16b86d",
                Status = "a96fba175b7f4d2bbffafcdd8d9fb1b4a90e38ea643e4c92a6"
            };

            // Act
            var serviceResult = await _resumeSnapshotsAppService.UpdateAsync(Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"), input);

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("19bf76cc-f5d5-4560-8123-b2ece44fd979"));
            result.ResumeMainId.ShouldBe(Guid.Parse("4bf64989-0200-44fd-9e4f-47a274a8b664"));
            result.CompanyMainId.ShouldBe(Guid.Parse("dcd17eb3-f1ea-475b-914b-caecad0687e5"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d27ba0e5-2e83-4c98-ae68-c7ecf8266305"));
            result.Snapshot.ShouldBe("0ba151fbbc0b480994b595457789b7b43ca0b67e3c634edeac9c0cf21386f8e3b08c15d8403c4cc19526e2c3c2f718d6ad9");
            result.UserCompanyBindId.ShouldBe(Guid.Parse("73fa9f1a-0519-448d-a022-9e5da0005637"));
            result.ExtendedInformation.ShouldBe("e716a455f54e4d5098579955e78dedf42182261c096e41d4ab57a19fcb2b2ac8158829c9fcec4b0d93a6adf18f548dadcc379af184a84a288ee961aa18a4353047ec7cb3fa3d40749e529df5b2b7e0aac5ffb17b51704aa1900f94fcd674d8fdda94ab8cafd64482ab54945756900205ffe446a391654998b85ab5f35b9236418884ae9cc1f142248d8c2fdd36527a482edd60925d2440f3af92d19828d84fbb159334483a0b43cf854fa8fd3276d77931ca59a0e1bf4382823056e870b890e2e9e5504b944c4de8b8e7f010a3865d5793f1c0475b1e4d3e9af142260be4c49c8a6e2dbf4ed1401d82e2765038f8fb92237fea3f488349e6abc4");
            result.DateA.ShouldBe(new DateTime(2005, 11, 15));
            result.DateD.ShouldBe(new DateTime(2006, 3, 6));
            result.Sort.ShouldBe(2083017365);
            result.Note.ShouldBe("1f33ccb53bbb49cdb25831d9b08e006788b7a0f44a5e449eb0baba3165ddd190291d2a1d30e7492a845c0d3beb07dd807409468bfd93424bb0cb1324794ffa52802e6f0e024944e0b8bab74adc21aa0475fe737705c84b668bd4e06e29c408442e19912834d746fb889fcb7fd1c48caf7dcb565f184d4be68ebc106ffe1f5d43e9719e7ac58e4000b7ce77671ef2ff47961682c316b94ff18c5182821c14f80a63d7aa51f8e04e61b46710871a2c072f76ab753b41c44c4ba1e7483487d9b7d377252a8deedc42f9991a33aa2f705eeee579c4075ae94f3cafaefd8bd50eae9f49e3eb23e27d44608b84ddb54ebae21ee2cb33571b774f16b86d");
            result.Status.ShouldBe("a96fba175b7f4d2bbffafcdd8d9fb1b4a90e38ea643e4c92a6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeSnapshotsAppService.DeleteAsync(Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"));

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"));

            result.ShouldBeNull();
        }
    }
}