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
            result.Items.Any(x => x.Id == Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("446163c3-feed-4e73-b651-5f35ed56f49a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeSnapshotsAppService.GetAsync(Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeSnapshotCreateDto
            {
                UserMainId = Guid.Parse("8ca9967b-faa8-4eb1-84a2-e1e0e81724a8"),
                ResumeMainId = Guid.Parse("d0a25cca-e223-43a9-b084-47e500d790df"),
                CompanyMainId = Guid.Parse("be28cb4f-c2bf-4bdb-b7dd-06d19e6b6aff"),
                CompanyJobId = Guid.Parse("7abb9feb-81ad-4e21-96c1-480de283e720"),
                Snapshot = "8c94ff68",
                UserCompanyBindId = Guid.Parse("e0207e50-caa2-447c-8df7-85d7a86519db"),
                ExtendedInformation = "f53fe90ebf254388bbf73206b089c582855a787e8b294f6095c3f8c5974572f6b8cc72b6d05044d290c53ad4f5bf9e6cd3a7b5ea54414505afe0f7d33fe327597d5fc069c8d240d7a652590ec49177ebe2b37cc7e5c848f6a13b0fee567ef0d75926d981e96143fe932ddaeead8daac4a01379121cbf49cea9e5e0e5d5338cd894fec6e39bdc4a4b8abcaf8a49f04eb6df9f76c1d6a84bcaa851576c10d55021640edf07fe954761860c50243dc7eb96d0a8f3c3f545471b8ad16f8baddf3cd87e7edbb9e4c4481f92407bb20aa5eafe99bd681d42474ccca389615209b6d835644adb2dff4549a9b483acfa94e7f4abddb5b5f5552442b6ba70",
                DateA = new DateTime(2018, 6, 8),
                DateD = new DateTime(2008, 6, 16),
                Sort = 229646826,
                Note = "20290aed50304db09979977294c0c6acf66aca84b8ca4e649bf2ee664317060aae7f8d4150c5436381883b53e57ca0541cc4707693fd4cffadf9ccc7593196b6fc5d43c0eb7f41748ad8f29f6d1440b4eac8e2d64eca46b6a5b955eeea59460db0816380d1074edc8828f7f78ba9518dcd105be6483d49eea122cc33a906c69127b3a493dd45459cb2f365affce82577c13be633035c4fcc91eac68223a0cf511af874f5fde046d2b1a4c98f7afb8d2fdbf12879024f40f4a9f64c0e2cafe023aefe137a93d340faba18567b98658ecd52e0a01e8ec1492d8120bf121cd95361e2716d15d57e4493a5a26b7f5ade7c5856cfe49475cb41f9a8ad",
                Status = "7165a61b5c50414cbe6e13d21326b644d6c46440bfa1415e92"
            };

            // Act
            var serviceResult = await _resumeSnapshotsAppService.CreateAsync(input);

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("8ca9967b-faa8-4eb1-84a2-e1e0e81724a8"));
            result.ResumeMainId.ShouldBe(Guid.Parse("d0a25cca-e223-43a9-b084-47e500d790df"));
            result.CompanyMainId.ShouldBe(Guid.Parse("be28cb4f-c2bf-4bdb-b7dd-06d19e6b6aff"));
            result.CompanyJobId.ShouldBe(Guid.Parse("7abb9feb-81ad-4e21-96c1-480de283e720"));
            result.Snapshot.ShouldBe("8c94ff68");
            result.UserCompanyBindId.ShouldBe(Guid.Parse("e0207e50-caa2-447c-8df7-85d7a86519db"));
            result.ExtendedInformation.ShouldBe("f53fe90ebf254388bbf73206b089c582855a787e8b294f6095c3f8c5974572f6b8cc72b6d05044d290c53ad4f5bf9e6cd3a7b5ea54414505afe0f7d33fe327597d5fc069c8d240d7a652590ec49177ebe2b37cc7e5c848f6a13b0fee567ef0d75926d981e96143fe932ddaeead8daac4a01379121cbf49cea9e5e0e5d5338cd894fec6e39bdc4a4b8abcaf8a49f04eb6df9f76c1d6a84bcaa851576c10d55021640edf07fe954761860c50243dc7eb96d0a8f3c3f545471b8ad16f8baddf3cd87e7edbb9e4c4481f92407bb20aa5eafe99bd681d42474ccca389615209b6d835644adb2dff4549a9b483acfa94e7f4abddb5b5f5552442b6ba70");
            result.DateA.ShouldBe(new DateTime(2018, 6, 8));
            result.DateD.ShouldBe(new DateTime(2008, 6, 16));
            result.Sort.ShouldBe(229646826);
            result.Note.ShouldBe("20290aed50304db09979977294c0c6acf66aca84b8ca4e649bf2ee664317060aae7f8d4150c5436381883b53e57ca0541cc4707693fd4cffadf9ccc7593196b6fc5d43c0eb7f41748ad8f29f6d1440b4eac8e2d64eca46b6a5b955eeea59460db0816380d1074edc8828f7f78ba9518dcd105be6483d49eea122cc33a906c69127b3a493dd45459cb2f365affce82577c13be633035c4fcc91eac68223a0cf511af874f5fde046d2b1a4c98f7afb8d2fdbf12879024f40f4a9f64c0e2cafe023aefe137a93d340faba18567b98658ecd52e0a01e8ec1492d8120bf121cd95361e2716d15d57e4493a5a26b7f5ade7c5856cfe49475cb41f9a8ad");
            result.Status.ShouldBe("7165a61b5c50414cbe6e13d21326b644d6c46440bfa1415e92");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeSnapshotUpdateDto()
            {
                UserMainId = Guid.Parse("0e124d3e-55a9-48b7-96d1-27fde4d7de3c"),
                ResumeMainId = Guid.Parse("2f37d6d4-abfb-40a1-8e13-9c57ed55bcec"),
                CompanyMainId = Guid.Parse("3bcd75ab-52c3-4d21-8e74-dd520e32f5af"),
                CompanyJobId = Guid.Parse("c56630dc-0042-4b53-9bab-ec9433689369"),
                Snapshot = "c456784f3f0241c9b5d07a3f64c2b8c0056e921f6b68487bbf1e2ff9e6a1156",
                UserCompanyBindId = Guid.Parse("8a422ef7-00cb-4d81-a6ff-051382f1399b"),
                ExtendedInformation = "01953d429fac4879b459a13deb5a609ac99c4d2a6a394ca0bd17a66e9b08896439176d5d4be94786aa64d4edca01aed905d08de6425e4ab285fece6f0bfa75b309284cbe0bc14a1697f97511b429a8cbf93977ebece94bcbac969eb28793493daa8894947490483e91d98103e3498cea4c03a77205e84149a1e447eb39f62f76d364e53b97ff4f4fa4b1c4863dc822f6c29ee0a56d794b7c854df99c23560493cb5d43b863a34c93b8c7301b3f28797f192a238ace1d46e388950bda197f0dc2d1a583f119614aa1a4d2ea333e7ceb5bcf80f2387b8b4d97987fc32c0f07aaa2ce6233f92b2e4debb94cc5412b0c145ed50954865ef14226847b",
                DateA = new DateTime(2016, 1, 4),
                DateD = new DateTime(2008, 3, 6),
                Sort = 1035491728,
                Note = "7257edf93b8d49698fbb9c944a8a4ad419997635c6a34332bbba385989f7cc2e56569dac94e04a78aded6c79969f21034da5c8c1ac9f44bc91424e52c1b2613dffce1f91e4e9421c9cbe6a2c2609f18a4db18b002f384c7eae562ad7c2ea093eba20d385de3a439a86bfdd8c70173a2e5b22e1f747824745ac59e991d6e6c7da655d885186e94cd0a523346d122dcafea98cf09521b143879d18af4df6376b15c8a946dc9b324a76a5f1517e8af202b072539b84760048b19e29edcc1b29806d5c2f02dc3dba4537a40183e6a5216eeae3f440ee5fd94ef1b34384f89518584a20e7382bcfb240089bb56b0ceffa3cc8363a93bd713c4697892e",
                Status = "1ef2458b288f4d188f72366f9e292e236cef2151cb8c450bb3"
            };

            // Act
            var serviceResult = await _resumeSnapshotsAppService.UpdateAsync(Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"), input);

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("0e124d3e-55a9-48b7-96d1-27fde4d7de3c"));
            result.ResumeMainId.ShouldBe(Guid.Parse("2f37d6d4-abfb-40a1-8e13-9c57ed55bcec"));
            result.CompanyMainId.ShouldBe(Guid.Parse("3bcd75ab-52c3-4d21-8e74-dd520e32f5af"));
            result.CompanyJobId.ShouldBe(Guid.Parse("c56630dc-0042-4b53-9bab-ec9433689369"));
            result.Snapshot.ShouldBe("c456784f3f0241c9b5d07a3f64c2b8c0056e921f6b68487bbf1e2ff9e6a1156");
            result.UserCompanyBindId.ShouldBe(Guid.Parse("8a422ef7-00cb-4d81-a6ff-051382f1399b"));
            result.ExtendedInformation.ShouldBe("01953d429fac4879b459a13deb5a609ac99c4d2a6a394ca0bd17a66e9b08896439176d5d4be94786aa64d4edca01aed905d08de6425e4ab285fece6f0bfa75b309284cbe0bc14a1697f97511b429a8cbf93977ebece94bcbac969eb28793493daa8894947490483e91d98103e3498cea4c03a77205e84149a1e447eb39f62f76d364e53b97ff4f4fa4b1c4863dc822f6c29ee0a56d794b7c854df99c23560493cb5d43b863a34c93b8c7301b3f28797f192a238ace1d46e388950bda197f0dc2d1a583f119614aa1a4d2ea333e7ceb5bcf80f2387b8b4d97987fc32c0f07aaa2ce6233f92b2e4debb94cc5412b0c145ed50954865ef14226847b");
            result.DateA.ShouldBe(new DateTime(2016, 1, 4));
            result.DateD.ShouldBe(new DateTime(2008, 3, 6));
            result.Sort.ShouldBe(1035491728);
            result.Note.ShouldBe("7257edf93b8d49698fbb9c944a8a4ad419997635c6a34332bbba385989f7cc2e56569dac94e04a78aded6c79969f21034da5c8c1ac9f44bc91424e52c1b2613dffce1f91e4e9421c9cbe6a2c2609f18a4db18b002f384c7eae562ad7c2ea093eba20d385de3a439a86bfdd8c70173a2e5b22e1f747824745ac59e991d6e6c7da655d885186e94cd0a523346d122dcafea98cf09521b143879d18af4df6376b15c8a946dc9b324a76a5f1517e8af202b072539b84760048b19e29edcc1b29806d5c2f02dc3dba4537a40183e6a5216eeae3f440ee5fd94ef1b34384f89518584a20e7382bcfb240089bb56b0ceffa3cc8363a93bd713c4697892e");
            result.Status.ShouldBe("1ef2458b288f4d188f72366f9e292e236cef2151cb8c450bb3");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeSnapshotsAppService.DeleteAsync(Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"));

            // Assert
            var result = await _resumeSnapshotRepository.FindAsync(c => c.Id == Guid.Parse("b60d9509-c18e-406e-b6e1-3b573f889b51"));

            result.ShouldBeNull();
        }
    }
}