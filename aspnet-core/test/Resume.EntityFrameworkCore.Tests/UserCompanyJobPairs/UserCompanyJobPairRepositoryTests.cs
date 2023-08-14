using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserCompanyJobPairs;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserCompanyJobPairRepository _userCompanyJobPairRepository;

        public UserCompanyJobPairRepositoryTests()
        {
            _userCompanyJobPairRepository = GetRequiredService<IUserCompanyJobPairRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobPairRepository.GetListAsync(
                    userMainId: Guid.Parse("14f83d26-5d14-4c0e-a0c4-40c16b4da782"),
                    name: "b6e2fedecb6d4e739aaf95fb6fd9b60d7b989fdb01c9477ea2",
                    pairCondition: "b6c13ed498474111868b921712dfabbbadacb930fc6b451ebfc2c8d33cedb606e2c2731f025b49998f238be79ad471d2a74d676b553d4036a732df8eb188aee0c87f48309a504eb09c7b7d03f547eadf1cdd2a3a2a9e4a748a2decf2db27ea9a383e62bece624ff3982e693482d0d226402ebbfdfc104a5ea985c388e9ecd1691ec575a3603745449468d847cc39a342258e14b3957148f4b990bbbe476bd49361cb71db8087426abfdecb6310369d8ecb3ec29961df4fa19cb36e614a7bd1357f304b6ddc93418db59a5f00bafcf7a6bf4f7c5fdb1142eb9dee60902adea1b2080b27120b8941c1a4beefa1abe251cda64a5c9a30704955a930",
                    extendedInformation: "f4416e921382482b87666ff5b55f8846ee23f208cc0a4647a47c4bd06de43ed7955573c859bc4f0e8e56673da7ba5e5a94fa1306c1964eb58053d13bb7b9d6372459a48a61194144add87a3ba0326e6959e73e87c9cf406cbf7d8e571848d6a4ba8c6babed2c45ba88ac5e1a8369636540b145e50843409aa3f31219d21aba9861f44aeead4d49a48273c1e2e720cb352565d00a282944748a00710c5a5812848f899d9ac8f84c36971f3883f2939ad61778cba8df634c038f957cb86d33d184526e2e7210174d79b097005feedfb34f7d8e1a8958424fa5be659441c96deb4f73bd86fcd29a4de7a1f9e722771162290659f7f0969d4c62a056",
                    note: "bfb29bb2846545d6a132459fe749164c9d6ff98f61924431939eb8f72af5cd5f95c0881ad2d24f92b13361a492d32cb18b2cd8a4247d465296455b317a8f65930bc9a87085a940ce8802c2cd899d7da59ff8f236318344919cc2c5464bad491c15b1641accd2482ebe54ef24de0077c1f49d6953363141a3badd5191ca51ae8685fec279e7f64e91bece3c85be268342feceab1d9b5544959b2d8317bb822a75463d9f78caa54f98a4af2121eddf1e88f1cc657a1c9c4619b67c742aa84e355edd7e4519d1b04955b1458c5ce18696eb8e4f32ed54cf4798aac5f69c5cdf35dfdb9c3c1c4ae74de7b27b3118e71675858e62b7f6b74d4f0ba382",
                    status: "10d81ab549ac4f639f5c7bbd5bb14aa271b6121cdbff4d62a5"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("9c1921c4-671b-4114-a132-1fdcf31ecfe1"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userCompanyJobPairRepository.GetCountAsync(
                    userMainId: Guid.Parse("4682ed6a-1912-48cf-8468-5daede0fca22"),
                    name: "0a80197ea26546f6b49e16aa7d980ce0e64d21eafcdb4e82b6",
                    pairCondition: "59e38e97c3a4476c8b193597713a709251e93fe3a55649898a1db834e7edee54fca4265236e4478ca3f4fec825e422edd440d46259b744a09c761ed8d6d0bf43553961bd02cb48eb990b1f9ff27d31e7e1f686e453f44b489d09f6efed34894a49e3f7b51bfb4db7b9ae37f2bd1c3e9503082bedde1d46f99081b57ef661b6e7d56ffc5873a74507af9e36a94bad2545777fd12b8f144b8fb472211d9875af94500b368507db4208a07c2939f77202a9ccdc0f49a4ed40d3a2a557a3d60abd4494ada0b7904f465191c9301ccdf416f143955814eeb24ec190d0b9b718c676ebd8d8d2ecda344afd8a1045daae21be3faababc1ede6742a6be9a",
                    extendedInformation: "0d6434328d9c4798b646b0619d42bfa0e034ab78eb7540b89efcc6391d0e8b3aee2c9e2055174ca28e943e1d95f245d18488f55f3eaa42449888243a14c9c454132775d948714cefa75a8e0479eef8c676d02467bec447438b6c3f80181023f6d31276b50e6246b2b4d27e40f33ec95529472c82ee3f4012ab08865414b5f21c99797b66b5e64576a7134f5836d631f2ecfecce778b04154aea0b14770f40f51d4ded15cda0443a4a456c4da9b1a5660b0185eff422f45e3bba5f60c5ff72ea773d7201d696148758834cac0c006896163c0092d8bcc4c858212fe06b56fcc63edc0f2b3c1c04363a7f1578f8ee531abadce8063e89d40b184d0",
                    note: "3b87dbc84d384c999d649747a78e38bcde8601beadfe46c9866f1987f3f9609dbed2492208c94a68a6dd50062d3b5ba75eb66dff4e70448e89346c381771ae2aefe995fdedba48179599ee21cf174156339f19620447494abb80d10c80f3172cd7cb7ac986114eabadd03de9acd9e04c5359177c08f64c9d9b2be1db0df245af6ee0cb0089014932890bd498ad1ee49f09e2c87f0dcb4a9caa5f097ce867bf79eb53bad10f9d4e298a43527c0f055d61940706d17c084846879c137a6e79ec752de87561c3e849f4bdad9287ecce71a786f1ed468c8d495d988495e9769bf6242156b13df27f431d93cba14dba2965cb2a0c190f99f64b7ab85d",
                    status: "d23bd2ff78b140e192d842d7a3ed0e5337b7de7ea81b4658ab"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}