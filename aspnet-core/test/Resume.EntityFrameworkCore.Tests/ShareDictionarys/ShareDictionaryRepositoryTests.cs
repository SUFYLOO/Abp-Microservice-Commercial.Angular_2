using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareDictionarys;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareDictionarys
{
    public class ShareDictionaryRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareDictionaryRepository _shareDictionaryRepository;

        public ShareDictionaryRepositoryTests()
        {
            _shareDictionaryRepository = GetRequiredService<IShareDictionaryRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareDictionaryRepository.GetListAsync(
                    shareLanguageId: Guid.Parse("f04681c3-1ce9-45af-a749-6ee71f94978e"),
                    shareTagId: Guid.Parse("c7c02959-6ac4-4087-aa27-92792b688c64"),
                    key1: "e81131ca181043cdb87fc096998ca20d10fd662941e24911a9",
                    key2: "9733346b5a204e3ea107cb49f0ede23c0114f0fbb3c3457b93",
                    key3: "0d644920edaa4ebb9255797838deaf77b560fd73748f4aaaa2",
                    name: "09afa0a47aff4233a5ebae9965d79a61b489f82b874344b5b6e4ca4027437d5076f9a56a8bdd469ebfee1b3739f4fc4c45274c99fa4b45819b4d9b18768ac63a2e1c1801daf7465eb4e73b883f9ef3b358e7462b4b9a49e7951407d120eec44708170f7c",
                    extendedInformation: "bed1d98a1d494ff9b29944f0267f7587bbd1777c9af943de98a98ac68384e12be365e23c7fb4499c83035cb931dd542793cce54812f347999f872af8f1970366f286a96791a44cf1bb32606f0364b30eb19a8b036b414b50bc6895cf6d9f6b9aca07f1aef3254acd887bd1ae097aae2b24cb17ac363e4a89919e6446d7d09cccf64de078a8c241ddb1bcc0413b05ee5977f36010d04640e68aadab0f3dfacb247de800da78774bcfbb031af6cffc76aa78d7f6b2786a4882a08759aac26d015eb4fc8d8bafc143f5ad159b56c776cedb78629d3836ff4957b8e40bb6a797a9a6757c7870cdfb4bb28036830135698c178624eb535ed449678bfc",
                    note: "c79447a5e67d45a8aa589c9a6630cd5e1512f8df27f44939b51258df5466cc93f47e162749d547e6bb2fe5b5a46059d571db56cf60e54ee083fa8a4970bd64d7f011701fa44a481baa9b103ea174c670570536f2b3b54cc7ab3453e8ceac4ce30ab59cba059e476f896a1689dcf3b01b56b55afe7ff14098990a7abe13ce5ee993226ad44e274a78b34dda4ec42cf49f62b0a671bbb74d4e8988cc1593a3650b3832370510984e3eaece05011f18494ff446b2b45a804692ae1b4080b8f4c525564e925bbf884ec085b61ad37d1d9d410bd8e063f57e48718ddfe58760594fc3ac8d6820654b42d78ac285c18632b60fe8e0bd14595b4a0c9f06",
                    status: "da8bfe6bc571442596913a29de0dbfed90eb9b49af944da99f"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("2aa1c4a4-7ca5-4ea6-9a97-0a5557a831f7"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareDictionaryRepository.GetCountAsync(
                    shareLanguageId: Guid.Parse("ed9f61e1-67f5-42c9-949f-6a2c323e3625"),
                    shareTagId: Guid.Parse("75d6d953-faf2-4aef-936d-a4c5f0499f78"),
                    key1: "1f3e476b125649af9fddc230bfbaac193852f8b0115248ad82",
                    key2: "418cf2ede6724d448fe125ccb4c71267587640bb20014b0ba3",
                    key3: "e65a078089054bd5a75f5d8989d59e639de089b009ac45a084",
                    name: "09c169592dd34d6493c94b6f458bb6266c86bfae796f4e68acd43c61c3987e88e7a1bc79effe4e60871c387c7605e922ba318b714aa441989f66bb82ba00c6dbb5461d21b93b40e29cb2d4ca0cbdd823135871564fa34dc7815281de4ca714a32f9007a8",
                    extendedInformation: "aa8da6052fdd46dd92642b7dc5fc4b59d2d45b54e083466ab6a7080bd29a518586b407db601a4226a1d252983fc38a63ba9861116e9a4117a065a18010dec8c3dbc586608076439c9e3c0039c521a24a2fb2a855096c4a34aa71c08d41865ef7f46bcf805a3343539291ec644af13cef82db8558b59d4004ac587245331b7b6af6a032c87b72435f8ea616b9f1926bead11a0c80d4f04288a0a09b7746eab12392b2028881a1492ebc8d63a14df3f11e9dd4cb847f0b46c0a5c269f7e23d89ec29026df4776d47abb13d04187a9f69b9276f820a05cf4fc6a85c23ca98c7d9d1db4300edc09245338af7cb39bf8af8b3072dc31bec5e43d48b52",
                    note: "7ce60206147542549bf94498bef84d60f5daaafc807a418cb3ebf1fb7ec7f7a3f2d55df298a94c578f001dcbe04679119b2c870ecefb400bb312a012b6be79903b63153ce6554e5892c93cd4707a382bcb4aab323fd641988e1cb93db08d6356dee73a8889844adca0870a445482b9d1a56045b318c342df94c49081b348aff09241a4bacfd24bd79b35db46e6e358c99d9b4126ceed4d9abc9b49e3df1acac1d59bcb9f872940df955ef3d932d16cb6db4ab5677f7342eeb55e866c4cfbdd6d0ee9f2b3496049c4b8fd772aa848bc95dc4003d47fa641669af2b846c9c4a2474cd3d88bc8ee4075bee3ebafc8e0a15eb8154978a23f415bba14",
                    status: "0b6038b62d574fe29cdc7340ab5aabea6a68682d23694a93ad"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}