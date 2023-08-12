using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeSnapshots;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeSnapshots
{
    public class ResumeSnapshotRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeSnapshotRepository _resumeSnapshotRepository;

        public ResumeSnapshotRepositoryTests()
        {
            _resumeSnapshotRepository = GetRequiredService<IResumeSnapshotRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeSnapshotRepository.GetListAsync(
                    userMainId: Guid.Parse("f47b2736-4e2b-47a7-a265-c78ee5a194d6"),
                    resumeMainId: Guid.Parse("7704046a-0b53-4a53-85ab-405bc120dda7"),
                    companyMainId: Guid.Parse("f9fc9b98-32a9-4c31-a3a6-38b918d54cb4"),
                    companyJobId: Guid.Parse("613bcc50-50b2-4289-9158-1c0ab138bbf7"),
                    snapshot: "e5deccb64738462893eb35423463688832886e95cb714d828447eb075f8a57b30136f4caa97745ff8bef1c649e2117349",
                    userCompanyBindId: Guid.Parse("a61fef2c-d15a-4976-bdc5-c1b5bb49634e"),
                    extendedInformation: "190e3fc1a3834bd988e86f43ff196ee08884bf42dea9453bb974e980db7dfc1fefa0c8819a9b4b93aef2dd5f93d5b3085f3d0902438942bf892207097cfabfbd0a24d5d562e2498291c70d858aff30a1381035d3719c483f8db9e98aef5daafb6a7f23ef47134bcd9f7b876bb10112877e3bd4f152544e87aeeb87968e96a381c807beb2a85e476898115013d3f3d170c4b69288bebd4a9dacc72389d19e4cb1a2a157eaf157452db15a98d9ea1b641555ef62fe96454e7fb2ba17e5ff25d09bc7350416d2ed4c69a086e34fe71cd492ff344b110a4a46329b314b91613343304cd27130a31a4f8ba141058ca30fe30a39ae809ce7cb4ecb9049",
                    note: "ba32587c588441229a7fb10d1cb72781a29b5e55500e4d6b83623cfeecee93930ce4715de2064a0688a4b195319166febfd2b3a825db4980a235928e6a83ab11f71133def4914aa6bd7d89efc8c7d60cd1756889a4f54e77bc58a14186d0b5653ca01049761242b8ae9bc8962d70944ad4ff2df7f58d4b2f9163d996045e5317b0ce84dfdda841b3ba823c6a7ff06c8a4964c0fce7094e80ba9d59375b2f030985e8e8e7fd934ec494828651a0b2d86c893c979b72f745ba9810b6f1eb18d2de0bdcda7fa7cf4672b45031905436a6fc8e515ba07c4e471db0c19e2e7adff71c081db8dbd051410cb366de19d96688aa326d307365934e6aa857",
                    status: "c4cce0a7ce594ad4a43bd510832271544eb33b0d1fd94ccbb8"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a9082218-5311-4a49-8afd-fb8f250873e3"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeSnapshotRepository.GetCountAsync(
                    userMainId: Guid.Parse("957ab820-3536-47e2-9fff-cea673efb9d7"),
                    resumeMainId: Guid.Parse("edb5ce81-d6ad-40fb-85a7-0b76e3aef374"),
                    companyMainId: Guid.Parse("0ca9cbfd-a39e-42b9-a82c-de6035bd942e"),
                    companyJobId: Guid.Parse("87368ed6-6137-499c-aedf-49c18308a40d"),
                    snapshot: "81d632c1da0f490b96620dd1f58ec0b2a55d860492b849519ae7d5ffae35",
                    userCompanyBindId: Guid.Parse("266ade8a-5471-4994-beab-1debd4484c3c"),
                    extendedInformation: "1d3be543cb21470e82c9b6092b4aeda363704e14e9b7461eb0ea38e908d97510e73f43c252e14e1f8ee27e30a24979d6514c835a84fd4b7f91fa47411541374af08a9c7c712341a0b97049279988ab96bf5bc8d3d27e4b87b289be4cfd9c993eae39c755ad64490e8f132dd7f2c0fef3025080eb3a0e45d894318343df797cea9a7b156a1f7947b6ad9b4eee8d453ce46ac2c5ee13084b8ea778010fdba32f76b1beea1854684fe49905f4ff99319e94f6aca0e5ae6d48599b48429f4b029ba245044a261a0f4073a9c201089768085c6b9419253fe74db8ab9085ebc730e567ee59da9a0c234530ba4739850c9c245b98a881649d85451cb2de",
                    note: "f56984e3ae1c423cb72915032a882c8812b117775aa14c0ca2f3f40c893d04199cbe167f391c4a25905b79bb86e79958f648d6b344fc4d1197bf65182e37ca1188486e465279402c956863a8141679bd16343cc1526a4b5c9296a1995d3d1507a4bb69635d8e4b4c9a2aa53aa32da3ddc88da698bcbf485fb4c937d7c62b380fda287654691b4dc6b56cdc52f24d8dc6d008f42a31aa4e25a38372088cfed73b15f9b089bee64a86b7668a16e98b05e9dcf860ca1ba446ba928703a8df0e7542eff5eaa872d641ada1ee8df13a20d70b152fdb306fed49acab4837fc6dc84fd22cc4876bb1e44cc9b5a38b676c7b487d0831897a332e453d8aba",
                    status: "5bff75d3fd6d4326ac0a3a6f669487c2cfb660ed303a46ce8f"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}