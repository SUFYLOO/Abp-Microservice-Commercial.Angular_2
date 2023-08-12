using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemPages;

namespace Resume.SystemPages
{
    public class SystemPagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemPageRepository _systemPageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemPagesDataSeedContributor(ISystemPageRepository systemPageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemPageRepository = systemPageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemPageRepository.InsertAsync(new SystemPage
            (
                id: Guid.Parse("015b50bc-baa5-49f6-beb1-b47c4ba81a7b"),
                typeCode: "d7a9278b4b534831b32731ba9758589fc0acd5ec4ddb4ceba8",
                filePath: "bb32deaf6ae14b4490035fa384e81c852e9d1644c7274e2dbac38e2980019d4dbac0191429874de197976d58bc46ed82876a874a688b40a190279337aa881fa04e4d6d23fec44e6fbd4455a18d30c2973cdd81fd961d472f85a721f4eb924680506cc41504854ed59137e0f93352cd617e745031390648d1a119a13521ee4e5bc0d1f7d84d3448b6a102895115965f5d8ff8ff36cd134221a98bfad79a65d652a70e3bdcfa1f495ab660b688578b51b8a2812037abee491c9ac4ea88807ed85b8d2bc0bdb4194fedb87ec1ad87ae2dd9506a3028fdf2402984e1dbc47f31e9821b4de1b0e5d641db81c564b64e70df5e00e8c4f3f3274aff8154",
                fileName: "adf21d3f2b634b628d456750f068b003f442c8ff7d344da4adddaaf131eb38a45751c0b391ce48fabc6314f4aa87ca0766fba70847f04ff0a4da3fb199e447ec3db9411b45f14d94a8d058f1734c2f261112e96f107e44fc925f4e79ca0465f9f2a312fb99574bd384af9a934a70d9c6bc6e59ce9f0448dabe116760515ce3c2242d9985533d42d4aa1186c6622a1b99caa8518c07844021843240382f7a477304a290b495cd473d8ebb7945172c9f0da9dd0dd19824454d9d24fb8194d10783f4e66600f68048f3b88d699642e5919b57678fbf5409458fa71e24a2b5fc94f5bc492fefd0d1403da5d2c8684426df598d654acbedc141a0bf5a",
                fileTitle: "2b7ed803dc714973b2ed9b0a254a5c3e439a6bedc75b488ba1f928b4eafb0a16b2296b267f7843628a39fb6087b2d2b0e0ae6229e1a14fc3a483b0f65e3f740da250244a8c9b4be6b0f9abda4e417f56592ab05f8466420693664a2f1a452e4646fb8aea",
                systemUserRoleKeys: "8096061f46634b6bb148407941a54aaeb5eeb442e3e244e091",
                parentCode: "daba5b83a5594edaa92071e61815177cbb04766d017b445ebf",
                extendedInformation: "b7434ce7927c4057b649f2baa623866d1bf7b4a7509145f9954d657bba5939e43d8eb0d0dc194ceeaf407e692c3629608459a22cd4554c70933ba612aea333f1fa13eff7b45e48a0b1dbd61fb7e090df7e0c553358e84c4ba70f499fdcd6518c608f302939e84edc9b52f6eda69b7c8d0fc62fe36e6a4b4eb4715f25bb01134712d127527c2c40c19bf6f1a23c8ad8ea2abb2fb55c7345ba9d393ae9ff9ee3c118fb6373dbef48429a34c7ecf6ba9f77d95c48f3f8a54d8e979bd6fb953b800a46fb5bc297714866a4df3893a30f8ea89aa384c182954d6caf83f107e5248fa97aaeb9c1a44b4cfcaf70049f4558da93b6e03797d6cb40f7a2e3",
                dateA: new DateTime(2013, 11, 26),
                dateD: new DateTime(2003, 2, 24),
                sort: 207676704,
                note: "0535eff8b1c743b5aa9faa4a7e722f5ce16b7f4d05744708835cd8f9e77fa9be4d34bf40bfbd4018ad9d8fa2e5ecb904b59b395a1f394c3baa7817c9ad91f0d43b7a7ccfe1f94ed9a2daae4941bb3dd5676f2fff562544d29604854f8d5837139ca2a7127121453884bc0732f3b0d139f29ff05b0a3d47ab8ab92ba655207ef7875dd55ca7a549d998d800df7b42478251f2439493b044bba39dbc6ad6bffc18827101651e554716917832b389555ed5bbcf28666c9c4edbac0b534ca2618fdca3921a441f514c098ccf93e394edcae852d77fc5feab4a03b10f43b967298fb1641831e5a60d4fdbbbdde181ed38e7fdbc2ed9d8207c4ac4ab68",
                status: "a5c2db07ed324ff19e24d6d841fe036543467dd94f8b44bf88"
            ));

            await _systemPageRepository.InsertAsync(new SystemPage
            (
                id: Guid.Parse("48bdc64b-2842-4608-9217-4375e96dae12"),
                typeCode: "b732d759168e467caf04d7c572378da5b89940cb091a45f8b7",
                filePath: "76837df7f9034742950237ee9e794e8d1b21dfcc806648c09d83cf68ae6194089c071618c63941c49aa42575fc175aa481171b5378644fe79be40a261acfdc06803f7d7d525143fb987f8fc124fab0d6d916537f23414bfea02fe953af13ef0b0523576f035743d6aa6d847da1eb56f7c3b08107729b4c379db08879ba3e57559a69479874b24236b3ea3d9800c167166bc0518b1f3e4362bc72b5d926b00d1592a59ff6be894b60aab3e6cc8339cc312de080f807fd4b4793d44fc2cdb2d64e83b93ffa2f7041309c23727148d0203fec191588c12f45db8b92798d85d284f411a41b46c9e54f5ea1ff245fcc131b2a041892cf42dc46f4b1d7",
                fileName: "18452125b5fd433881b44413964e47fccf13d697efdf4a0aa0326603005c0a24b8851f11b5944e9c82dfcdec46b68d8331480a116e66467991761cda5056cb24133e082b33504fefb66d2d727df5b39dccff4b763c654ac0bc9f460e7f544b6ea8429a2e15a14a2b8151b098926e9bb46e00b4ad7041493b8b873894b53f5ae2da66c9a9c71a438091c2a4e61ec832e94a656f69cebb492788ae6719f124af2a4ddceef4c64044dbb78acd07ce37e0642bb5b413daa9414ca9d88636c9dff935ed04cada6a3540e8a0012adcdb2554960d810c40666e4e84a3037a8daae51a64e862aeafde2f45998c976087aa47493ee8fcdabdacb0470884f7",
                fileTitle: "ecce06bd77654b2c811e1746e0f990fa4292168bed954102b6ec1f4211a2b6ea0fba184cc673436cab6a5a065d823c393bdd14a402ab44bb8480220fe952ed51d373943ebf6f44af934f3749d69979e4f080ac314ebb4200bf731a3f2bc6df032c08df8c",
                systemUserRoleKeys: "146123bd0e2543819e29dd31777ffe16d1bb10b287b249068e",
                parentCode: "d0d226e9998345f98682ad01610bc1cf2d051a8110df4d0fba",
                extendedInformation: "97e23b18efa74b10981f9ab57356175311b69cc845f646cb9b306de3cc25c5237ea3a3a918c54e89809e335268df1c8a776b1318d7c94226af0f5b82546e56198517e8f53ccd408db41da7bf454d3d3ddcef0dfcb690432da44909d3c3fbfb6e5d89b89eaac54422a02e5d4fde16b7abe176c7072b65454db7432706f2b4b50fbd696c653ad74a07abf831a95f615f7c758ddc56f67b4a56ae561ecbc205c2e0e37ecd17d7cd4078baccfd7a8810f26e2a2c57c44f8c4f73b947a03585cb69e02cfbe6142d3f4b49adffbec64a065c940d957c3681b4487ebf62581f8a021a5a0122cb0aac37429abccc1916dec52464600f7fb94bde45c9bc0e",
                dateA: new DateTime(2006, 1, 26),
                dateD: new DateTime(2005, 7, 23),
                sort: 1173865469,
                note: "fec0619c04514c74960f636da8cf7bf1bd511f74e63542eb86c93532ea49d94b16b247a761d342f9acc4ea2328d057e96f76f574c7fe4327971ed7730e58c3a7d85ad117d9bf45979ad07c98d07abfa0fd0d221e6c334fa4990189540b9024803f5166a273a441df8f99648abf640efde8e3376ae8ab4f2ba973b6339fde7947e7e25fe87224468fbda0945d2ab8b0193e38c99727b74ccd9039e9e2e497cd58628282b7766247969e7c610b4329278aa4c3868ee0334a31aca48fd3ad51df255ec80987a8af46828c71ad6ddee914cec775019999e04aa2b5653ec6a78bcfacc95a70a9c5454a88bbf4734c7c124fa7d585235ad25b4a7f93f3",
                status: "ae041f7c8bec4785b4dd86298c24ea201c0d6d956c3741fd9d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}