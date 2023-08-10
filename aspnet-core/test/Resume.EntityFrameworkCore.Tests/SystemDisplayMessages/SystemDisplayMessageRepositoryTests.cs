using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.SystemDisplayMessages;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessageRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ISystemDisplayMessageRepository _systemDisplayMessageRepository;

        public SystemDisplayMessageRepositoryTests()
        {
            _systemDisplayMessageRepository = GetRequiredService<ISystemDisplayMessageRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemDisplayMessageRepository.GetListAsync(
                    displayTypeCode: "ba2761403edf46479438f1af641a67fdc1025b4fd02b404b96",
                    titleContents: "3ee92554c60a40edbb0e78dd9b8a4c43f27a14dac37c42609e704edbce1f90d29287078d96ca40b980089c9d65a4ff414fb98800565948fd9c5339c77fc3a284cf1089d93e5d4963ac101ccd04754a80f9ed0b589a21467ca47834251997a38f38c36a8103bb4deeaf2002a4673b8958bdd7ac976e2b4e7fb6ace71d183cd461820bb61966f34cb396580f8e1ed11884e236017a9b754363b3aad25756994cd1f9782cd6fd714fcb9f6986f03568b0d62a42af0429624872823ebebfce3eeab5fd3d95ee764a40efaf5920d1736e54160d5ea35ec451488aa5e9dc616da10827bf6241003ec04f6fa62adcb657633f7359dc43d1d51b41109c02",
                    contents: "8573b7ca749d4c69ab9dae0b33dd5eeb2fac360d87a94cffbdfecc87d2314d4a215ce9d0a58b4a9aac996f73743916fe200ad6aba7c74192aefd78b257ebedf1813f741340814a3da2dc3ece20c90f5db99593f1ee3949dea1822adee70205c39706ce65019845da9d12b4a44bb3cdc2a783bfd797c74cdeb7c1108309a1dcd4ac45169d11384bae860970931b3f492f559cce282f174fcc8800ca6c187870ac0b5231c562bd46bf9d32994147449634950c0b2f922e4f148649374ff018dbcb35732e6c815944719fdd388f81acb5814502f55aeb474fd481da963123bde88362504d056c4b4f019a47a5b8bbe5fadc64fbc8af204f4090be09",
                    extendedInformation: "3b9b1cbfd16e43a7b0796db9a58c61f9bd98cb58d1d9400ab114de204725e08be88d9b97150044f593a2557c8047ccf6628217467d0b441e8d6591190d7abdbba6cca8a9d30e4d9f8581c46da49f3cd60d81feda7a274d5db370bb91800970fb4b3bd001d4b8486bba3d0e016376f387f921185d42264af9a07e2ca3ce00a3dbd40187c87dc946919b5caa051f8b449a70a78b876ec3448d885f92319150073410fc81f1b7fc4d81938934bb965e4aba664eea17785f4611afcd9e77b51011eb5823e02e33154013bb994cc40a90398482e6e2bad9164d139214acd120345ffff3f650bdf4914f7cab7f20a7522e622a625b81d374a1402495f5",
                    note: "7038bbb73a4e4bb683944803c8a60642afff254d32bb45d2a5930f0fa1f8d8b186246f8c10f54937a62b8419e92690fed814e70768544103b353bdc45127199d17079ceab9c84eb5a07e770d5707c67e1552148c7c3747899ff8fe8c5d1162c39e1b15d8f6fb4f3391556ea5b1214501585f2a5a80534a469992302baff2d4d9293d9a3c52474d24a89d53a1d504b46018c94c1d7e2e43baaa95e251aaa82a1b7e3979acf34e486298efd6c3218ca6a0a79c5575e3104899a294e8370d7962a1ae3fa7129a7240cb8276fa34c3100e69318b0a92662e4c18a58f6938b1cb3caa8be1d5a8b5c547658b1e199be377da9d585cbdfac79147a5948b",
                    status: "96f9fe72254b4b369146eb18c9af43903b29fe0288d4492c86"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("b3a990b0-b0a1-4ca3-8641-960628fa31d9"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _systemDisplayMessageRepository.GetCountAsync(
                    displayTypeCode: "3af552170b7b4a388379b93203e4a2014a0d71fce24f469292",
                    titleContents: "52af2753fdae46f1824e13920ac9e50c2e6aa5cf63784032a8e51ce1f7f05f5ad9ab126575b441129470905e41d04e265657109e5e154bce90fc92f7dcd2552ea4c5c242a8c1457da87c7d438fdd63edd36976ccbbba459c911ebe4f5a6ece667db8808ad93b4efd9608099fc84179bde50ec125cc56402883ac06a159eabd890f2bd4aa10b84217b1487380b3d76555d60caed913564a9bbf5d696a4ca04bd16d6a0f3733f648a094cf2669694ba79e4fdac40637b74822b11d89b6bdf2c613b0ad3360fa97405692a85557c23cfe813b1bbe08f7904182a0c8597cb2ff88ae2bc27b5794d34376ae099f54fe18ab918ab2a2f8e7274f6abae0",
                    contents: "7b55c3607e274f259f141c75415c21a032eed0dfe7e146bda2d40a602e236653244813ba0ca442a29e165c8541d73609c0167d56565d4845aa92eeb74f06df5482d3f3136df54608b24e61782f43ad53a870268b02e5489dac49192eb8b0fe7cf9c15e0862f54a259980a6d032683b4b8e1a4a6e2b36452f989a32d1b2973846cc3df1345259442298cb1de216e0e3a535bd0cfddbfe462096d5ccf15b20bd5e2ac8fdc3560149e8a7834654a8710ecb627c15bd2ef64ca0940dbb06d07e3be87fbe1299ae4b49ef8ee3ce2a0a27b01788e46cb7dced47449fed84d7d6984b14e1c10ee5b5944bb2888683430ed760c49a63b18601334d6d9e18",
                    extendedInformation: "8e00512a94894219863bb09385dddb7387bc984a84924e1aba90f09ef696ae228f4099056ac94e3a9f99b9d41a18384f3eb6ccde126b4f088b7e21a9129dc7afcebcf606c52840008c49849db90ac0a192d4114ef5bd43f9877634e2ff34283c8938d1da3a1d4a24be147316ab18fb099b8404f4bce74a47819a33cc0ee282730693f4962e1a48cb8e4f7cfdeed2e5ff61bfbc0434304483a0cf4090fc55dae7f30e222fd8a246f9aef3d679a618522666efe0b518a04d0590102594f71b31f6286e6a32a88540e5aaabd7f7c71b94e63904d1e2574b489bb50393d181e0eadcd39d0554b64e4076afdd0705d70ed6a84944dd85cb234074bd4c",
                    note: "2d3b00798de6439e960d71185fbe62ba867d960749224135b869a0076e6aecd396b93c35b1d44c0ab0f19e45d55b621eec0910530eb642398b1d60431f44e3f21ce55d0fdf664aacaac2c88c5ab83a8317368eb5b48244698084d252c8552977ca8db73f806d41c0ab9726847d71fda7e9bf8e50593c4705a7f2666f7c3ec664a30b6944758149ae8996973f7c311b2ad31ac16215994012b3c2660d1e1ab42b2add09a26db64fa09d7a0d96e2bc76200596f28393b04d0da23a03f389c92e2646ed207b3d6141349b932b75e1bfa708e2e9ffb324164952865d85e5f492f77859a7140f60974bd1880c273a58024df42a758e78423c464faaa1",
                    status: "87a68217a18343cab0139ccbb19562e34a8b28316256431d86"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}