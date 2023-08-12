using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobContentsAppService _companyJobContentsAppService;
        private readonly IRepository<CompanyJobContent, Guid> _companyJobContentRepository;

        public CompanyJobContentsAppServiceTests()
        {
            _companyJobContentsAppService = GetRequiredService<ICompanyJobContentsAppService>();
            _companyJobContentRepository = GetRequiredService<IRepository<CompanyJobContent, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobContentsAppService.GetListAsync(new GetCompanyJobContentsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("57c9888f-e2d5-47fc-92b4-d61c535ae050")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobContentsAppService.GetAsync(Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobContentCreateDto
            {
                CompanyMainId = Guid.Parse("c2923c6d-8410-418e-a534-c9d64efccd85"),
                CompanyJobId = Guid.Parse("3b421c3e-8faf-4f02-9651-c3b15cf81768"),
                Name = "bc38c139a2a04f2c85b8a28379d83b262dbfb124d2e14ad0bc",
                JobTypeCode = "50298918ce56483da8e04824f574355385d4773671f1420e9c",
                PeopleRequiredNumber = 1094146079,
                PeopleRequiredNumberUnlimited = true,
                JobType = "266afa998ec9415bb33e8084b999f0b810d017d0c9c64c3a8ed2f8ba9ffd5b5f96260c77779a4fb684b0ec1efc4599746e144c3bf63c49a281aab0a81df94ea5683e0a8b6b55415ea8bb1e8a82146d4ad439bb116ed94d949af378e764823db428d884ce",
                JobTypeContent = "381ca868f7",
                SalaryPayTypeCode = "4d8251532c494ab297985feef614dd67b68e24dde1ee4920bc",
                SalaryMin = 1669963047,
                SalaryMax = 1330059128,
                SalaryUp = true,
                WorkPlace = "304ef785e97444d38e8525c761760871eea2c60a5e9a49e184f1d96a7c3bcd6c0729e4d6f96046b68ecdc199a11e31e75bf307591189430489808724893fec242a331e5109c6402d900d89f56ec73dd53dba9aa7d5b1443b9a4a1f8d829a658768650e14",
                WorkHours = "45f566f2cec24d09880a79f0b53ea5176f0011efd56c4d02a1c9a4cd254ffd8f3f2240fbb3e840379fcce1d46b53001c85eb4d2387b747178bf04aee05d96cb2a0d470d2902e4389980f6f058fb8b4cad50aca4bf3924d19b3d1a4e50c4e5b87e30bd325",
                WorkHour = "762053dd4cea4be68b5d3030afedef3543375481b0fd40ac8b431d9e2f788eb4478bb73df608478ab97b0ae1989ea25baf9e0babe83b4382a7a452049f7515287cdeecdb99be4c3e860297b6acb135cbb983b97303174b7d8db187e9b4a01cc18ef195a2",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "698325b7212c48c7aad7dbe475e71effdaca5e8107774a9baf",
                WorkRemote = "f436c917778e42e99a1d26f5cff270e9208a25d4a5a546fbbf2aa12a3ea32600b83290ecdccf49939b704f8ee56084fae4778924ae7f4c64a6423f34c9500c4f41d12d74f0714b778d82b725d522891d01c087e2983f44b5a8a4f3c807d0cbad8c10c1a3",
                WorkDifferentPlaces = "de615b21d0334053a85cf02c5e7c9554387d1fbe182d46f5b68b47ddccda287157906f2219054cf5ab4d47ac6008463783a6d20f780a45eeb65406138d0db09cf972d0fc420049e0b0879080116d3eeab0644fc5e8914fc2a790b386c48199754c7afa4c",
                HolidaySystemCode = "3d35320e9c494fbf80a10db1edc1aa73ce50eea65f704733a0",
                WorkDayCode = "3dd7ac5331204f139c5c891f2387da8fa7adc60846ad4a25ad",
                WorkIdentityCode = "99a9817800e04c5584febe81ad778311060cf3654a6046d182ac3edd0c3d0c43b5964dc1dc674b5fa9f127232f8eae381c50a35d59174428913b68bc4597a727fc49fde715b84671ada99e8fc3033579284506cf544d4b069c185dbc27d345b46457b95c",
                DisabilityCategory = "eef6737a50da441199db907a3da6b969b3236e0585924dd583632f7c723545576459077335c5430e9ccfdc45b00805ff52d50584e4614e2a891b384b5dcbc0fffdf52bba4d844a73b6221829ff897c8c9367156a99aa4df58bd53ebb7d0124e3b515918a",
                ExtendedInformation = "6186d3fe9d174fa6abe23051904590e1935fcf10519140d39b712765be123671af4f8aa0e9774769a77b308a09e2070d225f0f241e91481092c708af8bd6e9eeebb919e224b148108ec369e444abafd4249ef9cb4b70483cb0cab7cc347a5b4570c38b8203db4175a613a5e85ac35a1ae48167d2b2a64c91a14142e2ef425d363fdf0641e7184d9294935eabd83e3137d4b753b96dc14895a3593779d4d7e2aa355e04ec4a394273998462587c2e6d66e7e8404fdab647228d75afa8d88ba8c473e8f4aa67d5424ea0b4d42f97775b9cfee7094f46e84d2a9f9b1f8c6cb8dfb9c4405780bad34504b393e5960a10ee9c43f638ad92c743c8a51f",
                DateA = new DateTime(2004, 2, 13),
                DateD = new DateTime(2003, 8, 21),
                Sort = 1808694292,
                Note = "5b32f72ae02c47d09a7506556b6829992732b3f46bb84242b5cea3da613b20cf2a36242f5d1a4e6989f90769943bdaa5914103582788498891c17f298cc5fb26c96eef470ec24a70a4eabe62b9b78a97b4fc2a6388f24aef8d02d417bc160325b2ed3638693b4cadace41053ac382674af1523b068d54f17af83cb908039af268da4d0290e3242919cf4a8fc16af32d748356c0842b24cb1a41d44fdd08ddffb99c864487eb14d29bea1328d7d42449f77b2c36264b0471aa2a6b7da876a76354fa868eaca434dbe986cc111da760db68190976c71c140ccaed02af919bdc56a482a3dacb39a403c992137f6c1af495a6cc4a2f6062b441ba682",
                Status = "de988c9ae03f4c16b746c200c2fef6aa927cd48419b947828b"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c2923c6d-8410-418e-a534-c9d64efccd85"));
            result.CompanyJobId.ShouldBe(Guid.Parse("3b421c3e-8faf-4f02-9651-c3b15cf81768"));
            result.Name.ShouldBe("bc38c139a2a04f2c85b8a28379d83b262dbfb124d2e14ad0bc");
            result.JobTypeCode.ShouldBe("50298918ce56483da8e04824f574355385d4773671f1420e9c");
            result.PeopleRequiredNumber.ShouldBe(1094146079);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("266afa998ec9415bb33e8084b999f0b810d017d0c9c64c3a8ed2f8ba9ffd5b5f96260c77779a4fb684b0ec1efc4599746e144c3bf63c49a281aab0a81df94ea5683e0a8b6b55415ea8bb1e8a82146d4ad439bb116ed94d949af378e764823db428d884ce");
            result.JobTypeContent.ShouldBe("381ca868f7");
            result.SalaryPayTypeCode.ShouldBe("4d8251532c494ab297985feef614dd67b68e24dde1ee4920bc");
            result.SalaryMin.ShouldBe(1669963047);
            result.SalaryMax.ShouldBe(1330059128);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("304ef785e97444d38e8525c761760871eea2c60a5e9a49e184f1d96a7c3bcd6c0729e4d6f96046b68ecdc199a11e31e75bf307591189430489808724893fec242a331e5109c6402d900d89f56ec73dd53dba9aa7d5b1443b9a4a1f8d829a658768650e14");
            result.WorkHours.ShouldBe("45f566f2cec24d09880a79f0b53ea5176f0011efd56c4d02a1c9a4cd254ffd8f3f2240fbb3e840379fcce1d46b53001c85eb4d2387b747178bf04aee05d96cb2a0d470d2902e4389980f6f058fb8b4cad50aca4bf3924d19b3d1a4e50c4e5b87e30bd325");
            result.WorkHour.ShouldBe("762053dd4cea4be68b5d3030afedef3543375481b0fd40ac8b431d9e2f788eb4478bb73df608478ab97b0ae1989ea25baf9e0babe83b4382a7a452049f7515287cdeecdb99be4c3e860297b6acb135cbb983b97303174b7d8db187e9b4a01cc18ef195a2");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("698325b7212c48c7aad7dbe475e71effdaca5e8107774a9baf");
            result.WorkRemote.ShouldBe("f436c917778e42e99a1d26f5cff270e9208a25d4a5a546fbbf2aa12a3ea32600b83290ecdccf49939b704f8ee56084fae4778924ae7f4c64a6423f34c9500c4f41d12d74f0714b778d82b725d522891d01c087e2983f44b5a8a4f3c807d0cbad8c10c1a3");
            result.WorkDifferentPlaces.ShouldBe("de615b21d0334053a85cf02c5e7c9554387d1fbe182d46f5b68b47ddccda287157906f2219054cf5ab4d47ac6008463783a6d20f780a45eeb65406138d0db09cf972d0fc420049e0b0879080116d3eeab0644fc5e8914fc2a790b386c48199754c7afa4c");
            result.HolidaySystemCode.ShouldBe("3d35320e9c494fbf80a10db1edc1aa73ce50eea65f704733a0");
            result.WorkDayCode.ShouldBe("3dd7ac5331204f139c5c891f2387da8fa7adc60846ad4a25ad");
            result.WorkIdentityCode.ShouldBe("99a9817800e04c5584febe81ad778311060cf3654a6046d182ac3edd0c3d0c43b5964dc1dc674b5fa9f127232f8eae381c50a35d59174428913b68bc4597a727fc49fde715b84671ada99e8fc3033579284506cf544d4b069c185dbc27d345b46457b95c");
            result.DisabilityCategory.ShouldBe("eef6737a50da441199db907a3da6b969b3236e0585924dd583632f7c723545576459077335c5430e9ccfdc45b00805ff52d50584e4614e2a891b384b5dcbc0fffdf52bba4d844a73b6221829ff897c8c9367156a99aa4df58bd53ebb7d0124e3b515918a");
            result.ExtendedInformation.ShouldBe("6186d3fe9d174fa6abe23051904590e1935fcf10519140d39b712765be123671af4f8aa0e9774769a77b308a09e2070d225f0f241e91481092c708af8bd6e9eeebb919e224b148108ec369e444abafd4249ef9cb4b70483cb0cab7cc347a5b4570c38b8203db4175a613a5e85ac35a1ae48167d2b2a64c91a14142e2ef425d363fdf0641e7184d9294935eabd83e3137d4b753b96dc14895a3593779d4d7e2aa355e04ec4a394273998462587c2e6d66e7e8404fdab647228d75afa8d88ba8c473e8f4aa67d5424ea0b4d42f97775b9cfee7094f46e84d2a9f9b1f8c6cb8dfb9c4405780bad34504b393e5960a10ee9c43f638ad92c743c8a51f");
            result.DateA.ShouldBe(new DateTime(2004, 2, 13));
            result.DateD.ShouldBe(new DateTime(2003, 8, 21));
            result.Sort.ShouldBe(1808694292);
            result.Note.ShouldBe("5b32f72ae02c47d09a7506556b6829992732b3f46bb84242b5cea3da613b20cf2a36242f5d1a4e6989f90769943bdaa5914103582788498891c17f298cc5fb26c96eef470ec24a70a4eabe62b9b78a97b4fc2a6388f24aef8d02d417bc160325b2ed3638693b4cadace41053ac382674af1523b068d54f17af83cb908039af268da4d0290e3242919cf4a8fc16af32d748356c0842b24cb1a41d44fdd08ddffb99c864487eb14d29bea1328d7d42449f77b2c36264b0471aa2a6b7da876a76354fa868eaca434dbe986cc111da760db68190976c71c140ccaed02af919bdc56a482a3dacb39a403c992137f6c1af495a6cc4a2f6062b441ba682");
            result.Status.ShouldBe("de988c9ae03f4c16b746c200c2fef6aa927cd48419b947828b");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobContentUpdateDto()
            {
                CompanyMainId = Guid.Parse("f3cb0756-ad67-404f-af7b-431f6c9ba3c8"),
                CompanyJobId = Guid.Parse("1c42b46a-d357-4bba-889a-ee7436d9aace"),
                Name = "6af2aec237e54212b07602995cf0ed639da4315b30364e00b8",
                JobTypeCode = "5d460e08bf914834886cc186d98f86b4645551958d544dbc80",
                PeopleRequiredNumber = 1118648115,
                PeopleRequiredNumberUnlimited = true,
                JobType = "48a2f8fc15b6485491b5e7bd8c182d64ecc348115bfb47098880fe88e7a60a67f14183ab77ff4d8f8eb7c3d1aef3d8529bf003d24f024f6fb52038062cb33003744cc1ed67414cc39767245b6e14e789ebda8e08c8534306a72987781c3585cea59207f4",
                JobTypeContent = "e9998433c7654fb98f174c42e8ec9d36273bde1577e",
                SalaryPayTypeCode = "f357dcd0c3b8461d8d6d1f9850b29e953feda28166564b40b5",
                SalaryMin = 399613283,
                SalaryMax = 1391401984,
                SalaryUp = true,
                WorkPlace = "c8c3f5768a7c4d6aa1449fc5046543d0f656cf9a270344d6a975c4552ddee71c1aa711adea3e4351a3eb79ede83f13febd832263254b4f06aeb2b514fd4d66f4115256b5746c4a4f96abbbe87d1fbea8462bd667a80e476bb71347ea889f805c3352d7d4",
                WorkHours = "90a149db3d36440fb9d58375316a93e4d5ceceac013d42e284a27fb0afeb3c84c269802500f04123941bbfa4bace81b99c5bc9135f84441193223299ef3f48627c0fcf08bba44370aedf24e821f4b02dda87d971c43f4337b1b8f5a41d6d53060b5fa2e2",
                WorkHour = "f37b68aacdf245eca05b4a1806fce4ad8f71c00b72b34e54b92de1de85cc9241c65a809dc45b49e191815a66018741ad63ee303af5864c568376411b9e890210b86ffd44861a446297d2d41abe4142132adacb08bef248259eac076451d02b728e5c0556",
                WorkShift = true,
                WorkRemoteAllow = true,
                WorkRemoteTypeCode = "72bcedfe36b449ea9a49db74228ca56621f0018a3b6e436486",
                WorkRemote = "2f05e47e8a124c27a46d70a164072f87d87f22057c144ca5bb3b74ee3bb061682819baf4e41244f8992ed235fa5623f9717791b8250a4ff7a18d3a18f4553f3ea6507ef6bc5d4851a4bad7f1de290f3a06399966e46642c1ac9ad7aedaad6368755acb60",
                WorkDifferentPlaces = "6bd69e3e213c4cecb533afa81aa0998db20eb67ff6204aa4989e2075f4134c1cb677ea5517744de99d56337825c1281732f47b67a9f74abcaec880cd676ab7c2acfb4bab1c154997b890382130e0aa800289c9cf315b4809a6c23d7e4e9b6ee27f1ec841",
                HolidaySystemCode = "a552cf26fe53473983daca29be15f0c4cf12c1585f8a4ffe99",
                WorkDayCode = "d0737626b96c4a92bb146f1c5dbf23ad7a22ab53566b4dc2b5",
                WorkIdentityCode = "0974ea8f5a3141adaef5c1b210e62544f96173a03f094e3ca5851da902ddd69de77004e63dd74944bee150a7ffc4663fe4b0c238555343ddb2c4aed99c35052f1c9527c4088d46089b4089558a48276ebbf86dacc3be40e487edfbc3a980368b845608a8",
                DisabilityCategory = "c269c146af78407b877dbff2d9e82bbe0196d5c2355a444e9b5b822e039e49072276b301250f492e9614e08a711a1159e73e1f4431264039aecc44fdbbc0ee725e73a974ed3a4d20a161cd15b137b7fe921f36ae1596442c99f4cc5f7dc88af9e15b7c4f",
                ExtendedInformation = "7e768a42a5534065addba86a55c199c64d633d8fcc214fa9bfcf71cc297df49e70650f78af24490b8e103e099ddf5146f102a1eedcca4ca1b46488b4487f33fce154713395d1434f972e6996769098d783c10b84b5ed4787a5b7dca537cd1dbe247866622d254f4f8584df5387ac9efbdd4e3249c71442fc8f94d41c2b06466c4b3e2dcd5c664e83b7f8d9e00c0def1d43f1bd1ec3fa4f5aae70767973c4757b808f706890b942db9ad04322453cac7d033cd442e47f42f78f55f01a371ba2afc811c2c0dfc6480baa6b9a724048f98a1d3dec18feed4312a56efe84b8e762662d605c4c7d0d4329a4bb4698f4969c3995145ac7fca340bfba15",
                DateA = new DateTime(2017, 8, 4),
                DateD = new DateTime(2018, 3, 19),
                Sort = 847678255,
                Note = "6ec24b556f21430ebf2d8f252fd385edfac4738a9b0b4dafb30755706880033f222688110b8349d2b1eeb35f32aec3e9531b324b4fa348588c4ce5e6edf7c92091812f94f708442095a0d54dee1e48dc5c4aee98efbc462b8349abe02bd88e89763cd49e928c41a4bfe4088a0302d27448303d90fe24437e83439d144a919aab357a36e2a81e4ae9a18fb7a92248007ecb62864a16ed44b282ad981319d468736851d3f40f584462b4b563159dd135de3203f6c085d24e77b25f0fcb294f4736ca57ac46264a42d88d2273d57ed44d7df146aa892cd441b5927dd9b6679cf00e5a829c9a0c834ae79e45772fad52da32ae2b11c5ec6346ae9e23",
                Status = "17e74f6bb4c5469a9e0caa0098a0031a44837ee867704cabab"
            };

            // Act
            var serviceResult = await _companyJobContentsAppService.UpdateAsync(Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"), input);

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("f3cb0756-ad67-404f-af7b-431f6c9ba3c8"));
            result.CompanyJobId.ShouldBe(Guid.Parse("1c42b46a-d357-4bba-889a-ee7436d9aace"));
            result.Name.ShouldBe("6af2aec237e54212b07602995cf0ed639da4315b30364e00b8");
            result.JobTypeCode.ShouldBe("5d460e08bf914834886cc186d98f86b4645551958d544dbc80");
            result.PeopleRequiredNumber.ShouldBe(1118648115);
            result.PeopleRequiredNumberUnlimited.ShouldBe(true);
            result.JobType.ShouldBe("48a2f8fc15b6485491b5e7bd8c182d64ecc348115bfb47098880fe88e7a60a67f14183ab77ff4d8f8eb7c3d1aef3d8529bf003d24f024f6fb52038062cb33003744cc1ed67414cc39767245b6e14e789ebda8e08c8534306a72987781c3585cea59207f4");
            result.JobTypeContent.ShouldBe("e9998433c7654fb98f174c42e8ec9d36273bde1577e");
            result.SalaryPayTypeCode.ShouldBe("f357dcd0c3b8461d8d6d1f9850b29e953feda28166564b40b5");
            result.SalaryMin.ShouldBe(399613283);
            result.SalaryMax.ShouldBe(1391401984);
            result.SalaryUp.ShouldBe(true);
            result.WorkPlace.ShouldBe("c8c3f5768a7c4d6aa1449fc5046543d0f656cf9a270344d6a975c4552ddee71c1aa711adea3e4351a3eb79ede83f13febd832263254b4f06aeb2b514fd4d66f4115256b5746c4a4f96abbbe87d1fbea8462bd667a80e476bb71347ea889f805c3352d7d4");
            result.WorkHours.ShouldBe("90a149db3d36440fb9d58375316a93e4d5ceceac013d42e284a27fb0afeb3c84c269802500f04123941bbfa4bace81b99c5bc9135f84441193223299ef3f48627c0fcf08bba44370aedf24e821f4b02dda87d971c43f4337b1b8f5a41d6d53060b5fa2e2");
            result.WorkHour.ShouldBe("f37b68aacdf245eca05b4a1806fce4ad8f71c00b72b34e54b92de1de85cc9241c65a809dc45b49e191815a66018741ad63ee303af5864c568376411b9e890210b86ffd44861a446297d2d41abe4142132adacb08bef248259eac076451d02b728e5c0556");
            result.WorkShift.ShouldBe(true);
            result.WorkRemoteAllow.ShouldBe(true);
            result.WorkRemoteTypeCode.ShouldBe("72bcedfe36b449ea9a49db74228ca56621f0018a3b6e436486");
            result.WorkRemote.ShouldBe("2f05e47e8a124c27a46d70a164072f87d87f22057c144ca5bb3b74ee3bb061682819baf4e41244f8992ed235fa5623f9717791b8250a4ff7a18d3a18f4553f3ea6507ef6bc5d4851a4bad7f1de290f3a06399966e46642c1ac9ad7aedaad6368755acb60");
            result.WorkDifferentPlaces.ShouldBe("6bd69e3e213c4cecb533afa81aa0998db20eb67ff6204aa4989e2075f4134c1cb677ea5517744de99d56337825c1281732f47b67a9f74abcaec880cd676ab7c2acfb4bab1c154997b890382130e0aa800289c9cf315b4809a6c23d7e4e9b6ee27f1ec841");
            result.HolidaySystemCode.ShouldBe("a552cf26fe53473983daca29be15f0c4cf12c1585f8a4ffe99");
            result.WorkDayCode.ShouldBe("d0737626b96c4a92bb146f1c5dbf23ad7a22ab53566b4dc2b5");
            result.WorkIdentityCode.ShouldBe("0974ea8f5a3141adaef5c1b210e62544f96173a03f094e3ca5851da902ddd69de77004e63dd74944bee150a7ffc4663fe4b0c238555343ddb2c4aed99c35052f1c9527c4088d46089b4089558a48276ebbf86dacc3be40e487edfbc3a980368b845608a8");
            result.DisabilityCategory.ShouldBe("c269c146af78407b877dbff2d9e82bbe0196d5c2355a444e9b5b822e039e49072276b301250f492e9614e08a711a1159e73e1f4431264039aecc44fdbbc0ee725e73a974ed3a4d20a161cd15b137b7fe921f36ae1596442c99f4cc5f7dc88af9e15b7c4f");
            result.ExtendedInformation.ShouldBe("7e768a42a5534065addba86a55c199c64d633d8fcc214fa9bfcf71cc297df49e70650f78af24490b8e103e099ddf5146f102a1eedcca4ca1b46488b4487f33fce154713395d1434f972e6996769098d783c10b84b5ed4787a5b7dca537cd1dbe247866622d254f4f8584df5387ac9efbdd4e3249c71442fc8f94d41c2b06466c4b3e2dcd5c664e83b7f8d9e00c0def1d43f1bd1ec3fa4f5aae70767973c4757b808f706890b942db9ad04322453cac7d033cd442e47f42f78f55f01a371ba2afc811c2c0dfc6480baa6b9a724048f98a1d3dec18feed4312a56efe84b8e762662d605c4c7d0d4329a4bb4698f4969c3995145ac7fca340bfba15");
            result.DateA.ShouldBe(new DateTime(2017, 8, 4));
            result.DateD.ShouldBe(new DateTime(2018, 3, 19));
            result.Sort.ShouldBe(847678255);
            result.Note.ShouldBe("6ec24b556f21430ebf2d8f252fd385edfac4738a9b0b4dafb30755706880033f222688110b8349d2b1eeb35f32aec3e9531b324b4fa348588c4ce5e6edf7c92091812f94f708442095a0d54dee1e48dc5c4aee98efbc462b8349abe02bd88e89763cd49e928c41a4bfe4088a0302d27448303d90fe24437e83439d144a919aab357a36e2a81e4ae9a18fb7a92248007ecb62864a16ed44b282ad981319d468736851d3f40f584462b4b563159dd135de3203f6c085d24e77b25f0fcb294f4736ca57ac46264a42d88d2273d57ed44d7df146aa892cd441b5927dd9b6679cf00e5a829c9a0c834ae79e45772fad52da32ae2b11c5ec6346ae9e23");
            result.Status.ShouldBe("17e74f6bb4c5469a9e0caa0098a0031a44837ee867704cabab");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobContentsAppService.DeleteAsync(Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"));

            // Assert
            var result = await _companyJobContentRepository.FindAsync(c => c.Id == Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"));

            result.ShouldBeNull();
        }
    }
}