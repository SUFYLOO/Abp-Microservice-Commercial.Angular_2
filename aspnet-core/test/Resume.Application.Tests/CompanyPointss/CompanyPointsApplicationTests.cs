using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyPointss
{
    public class CompanyPointssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyPointssAppService _companyPointssAppService;
        private readonly IRepository<CompanyPoints, Guid> _companyPointsRepository;

        public CompanyPointssAppServiceTests()
        {
            _companyPointssAppService = GetRequiredService<ICompanyPointssAppService>();
            _companyPointsRepository = GetRequiredService<IRepository<CompanyPoints, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyPointssAppService.GetListAsync(new GetCompanyPointssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("10a44f11-a205-43c3-9b27-51bf9bb61873")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyPointssAppService.GetAsync(Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyPointsCreateDto
            {
                CompanyMainId = Guid.Parse("c4c5ade1-5790-4cb8-96f6-cca17170638e"),
                CompanyPointsTypeCode = "fe5709b031904916b37719dafbe0985e4ce309d3aa2341dfbc",
                Points = 1778495224,
                ExtendedInformation = "8c5f6ac7c32547e3806d45f808916c2e110603609a3e40c9b8115c036d91fcd5cb71af5b345a4bb98945f179f56e7c7b8f82307f729b41edbd5d5f6181bfc75f2e100a06a4b749d88e4765b30a69dcc4530be0decbb549a3adc007a50a5ab2888439e17cfec74d25bc86f37c69e0a63d5bcac26c13d84a5ca2df5cb428a155a61f22f11727e9489fadad53c1f7ba8a240c2b96b5397f4b618ee2926f3dc906822952e88ccc084aa8b0bc30123a2295f723a589931d0c48c58f51d6ccbd1e848454243990d10b469ea25d1b55e689fe0640880d1ad90c49c98e5b24e86942bf80ed0ebe89aa684ccd944282bad8d5e8bcd61bf98b599a43a0979d",
                DateA = new DateTime(2015, 7, 25),
                DateD = new DateTime(2002, 2, 8),
                Sort = 488431541,
                Note = "f01aa699860246c985b07f28e027d5b887b892cf45da44159d5be14a45ac854755a12bc5c9ce4b6f86d174be2c355d27169c1c96d26a4b3dbf239364854ae4577ad167fd657d40108aad5707f1ce6a7c8b6f39f4ee8d4e389cfe001a75c8cc5ed3eb37d777ed4cf88f43b74be3a437cfcc7b95768a894c8090998ac09f430e7b9f3e9a9d1e1141e0b22b74b89c4fec226d633b1be8f34acc8a7e283586333e2113a57ee5e2154ec8b937dca2197dd212bf6fccec90284d3d9d7d16ac42192eb850643e540b4c44ce931282653bbb6b9bcc7dd34a29154ad2928133d76eb5ac63a20b7fb53f424840816852ad5ecd2994c7f64767c03248d29e92",
                Status = "96e3262d601d497b9ce0722d1b43b1c41a3113535cca4d27be"
            };

            // Act
            var serviceResult = await _companyPointssAppService.CreateAsync(input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c4c5ade1-5790-4cb8-96f6-cca17170638e"));
            result.CompanyPointsTypeCode.ShouldBe("fe5709b031904916b37719dafbe0985e4ce309d3aa2341dfbc");
            result.Points.ShouldBe(1778495224);
            result.ExtendedInformation.ShouldBe("8c5f6ac7c32547e3806d45f808916c2e110603609a3e40c9b8115c036d91fcd5cb71af5b345a4bb98945f179f56e7c7b8f82307f729b41edbd5d5f6181bfc75f2e100a06a4b749d88e4765b30a69dcc4530be0decbb549a3adc007a50a5ab2888439e17cfec74d25bc86f37c69e0a63d5bcac26c13d84a5ca2df5cb428a155a61f22f11727e9489fadad53c1f7ba8a240c2b96b5397f4b618ee2926f3dc906822952e88ccc084aa8b0bc30123a2295f723a589931d0c48c58f51d6ccbd1e848454243990d10b469ea25d1b55e689fe0640880d1ad90c49c98e5b24e86942bf80ed0ebe89aa684ccd944282bad8d5e8bcd61bf98b599a43a0979d");
            result.DateA.ShouldBe(new DateTime(2015, 7, 25));
            result.DateD.ShouldBe(new DateTime(2002, 2, 8));
            result.Sort.ShouldBe(488431541);
            result.Note.ShouldBe("f01aa699860246c985b07f28e027d5b887b892cf45da44159d5be14a45ac854755a12bc5c9ce4b6f86d174be2c355d27169c1c96d26a4b3dbf239364854ae4577ad167fd657d40108aad5707f1ce6a7c8b6f39f4ee8d4e389cfe001a75c8cc5ed3eb37d777ed4cf88f43b74be3a437cfcc7b95768a894c8090998ac09f430e7b9f3e9a9d1e1141e0b22b74b89c4fec226d633b1be8f34acc8a7e283586333e2113a57ee5e2154ec8b937dca2197dd212bf6fccec90284d3d9d7d16ac42192eb850643e540b4c44ce931282653bbb6b9bcc7dd34a29154ad2928133d76eb5ac63a20b7fb53f424840816852ad5ecd2994c7f64767c03248d29e92");
            result.Status.ShouldBe("96e3262d601d497b9ce0722d1b43b1c41a3113535cca4d27be");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyPointsUpdateDto()
            {
                CompanyMainId = Guid.Parse("77588d96-1ca5-4175-9511-07e1ddfe5cdc"),
                CompanyPointsTypeCode = "e2706d4eb7e4400bbcb3d4cb8c20c273f7f741aa2f594e27ae",
                Points = 149903520,
                ExtendedInformation = "aa750876220e456190c93fde74a3a6485f86239e513e4e619b774530b72b5f0284e682cb3a8c49a385f564a23171050d1d88a021ba3a4be4a49e475c3ff020b82ab5a1c1a31a498a98a7110ecfa409523c386b7f315d463e93278561f22800eb1aec120714f94408855e53dac30768ef6b70b1c2b302422888b372198542410631a0ed1ade5a489cb3cf82b7c1a5a48c2c13dfe49b61484da5c7e7c48b3127c93e097b0c16ac464587b8a37ad08d8dec301d1ba11025404693044c4c27343ef7febcec267d694f8aace25550393958d418124305e26f428091661c02c4adaf59929236171d174696bb994757069331d000f2142c82744f9cabef",
                DateA = new DateTime(2011, 8, 16),
                DateD = new DateTime(2005, 11, 22),
                Sort = 1533736530,
                Note = "a956dc628739461bab61fe3fdc127b19fd29ee5bc8fe4881a05ad60a862ecf3bdf2f2ec274074785b1cb2c0f3c67d4309a2ffb735ef44d9ba74da1c06602ee765e1b1d26267f48ffa014111fa8bb94af66c7d9de003e46508b8e0d3ee2271da27a2abbc9a6e8482dbc4c74750b4a8e01bd6f759b8b7f4b91939d87cab01a969c6b9238beac13419c80b7bb43c719d33b52e8b726b0894111b07c5ba1cfec13f66ff7707ac21d4c579f062dc49b4f0cb100edb071be5147049e426687dcb0400e48fa9306670e4820b64b9e48ed98af2de969bb9d494348f18fd1b05645d1ced8a43993f8d5654b3593a056b044d34ac5ffe09729931442ea862c",
                Status = "f6de0f62728f45dcb7b692db67092026ccc3d351a8984a648d"
            };

            // Act
            var serviceResult = await _companyPointssAppService.UpdateAsync(Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"), input);

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("77588d96-1ca5-4175-9511-07e1ddfe5cdc"));
            result.CompanyPointsTypeCode.ShouldBe("e2706d4eb7e4400bbcb3d4cb8c20c273f7f741aa2f594e27ae");
            result.Points.ShouldBe(149903520);
            result.ExtendedInformation.ShouldBe("aa750876220e456190c93fde74a3a6485f86239e513e4e619b774530b72b5f0284e682cb3a8c49a385f564a23171050d1d88a021ba3a4be4a49e475c3ff020b82ab5a1c1a31a498a98a7110ecfa409523c386b7f315d463e93278561f22800eb1aec120714f94408855e53dac30768ef6b70b1c2b302422888b372198542410631a0ed1ade5a489cb3cf82b7c1a5a48c2c13dfe49b61484da5c7e7c48b3127c93e097b0c16ac464587b8a37ad08d8dec301d1ba11025404693044c4c27343ef7febcec267d694f8aace25550393958d418124305e26f428091661c02c4adaf59929236171d174696bb994757069331d000f2142c82744f9cabef");
            result.DateA.ShouldBe(new DateTime(2011, 8, 16));
            result.DateD.ShouldBe(new DateTime(2005, 11, 22));
            result.Sort.ShouldBe(1533736530);
            result.Note.ShouldBe("a956dc628739461bab61fe3fdc127b19fd29ee5bc8fe4881a05ad60a862ecf3bdf2f2ec274074785b1cb2c0f3c67d4309a2ffb735ef44d9ba74da1c06602ee765e1b1d26267f48ffa014111fa8bb94af66c7d9de003e46508b8e0d3ee2271da27a2abbc9a6e8482dbc4c74750b4a8e01bd6f759b8b7f4b91939d87cab01a969c6b9238beac13419c80b7bb43c719d33b52e8b726b0894111b07c5ba1cfec13f66ff7707ac21d4c579f062dc49b4f0cb100edb071be5147049e426687dcb0400e48fa9306670e4820b64b9e48ed98af2de969bb9d494348f18fd1b05645d1ced8a43993f8d5654b3593a056b044d34ac5ffe09729931442ea862c");
            result.Status.ShouldBe("f6de0f62728f45dcb7b692db67092026ccc3d351a8984a648d");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyPointssAppService.DeleteAsync(Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"));

            // Assert
            var result = await _companyPointsRepository.FindAsync(c => c.Id == Guid.Parse("bcde3f61-9faf-4896-8adf-e781e2c9baec"));

            result.ShouldBeNull();
        }
    }
}