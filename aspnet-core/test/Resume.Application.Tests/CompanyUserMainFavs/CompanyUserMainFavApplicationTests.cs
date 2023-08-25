using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyUserMainFavs
{
    public class CompanyUserMainFavsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyUserMainFavsAppService _companyUserMainFavsAppService;
        private readonly IRepository<CompanyUserMainFav, Guid> _companyUserMainFavRepository;

        public CompanyUserMainFavsAppServiceTests()
        {
            _companyUserMainFavsAppService = GetRequiredService<ICompanyUserMainFavsAppService>();
            _companyUserMainFavRepository = GetRequiredService<IRepository<CompanyUserMainFav, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyUserMainFavsAppService.GetListAsync(new GetCompanyUserMainFavsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("f9a4614c-41bd-4cff-9ba7-9ac58a375b24")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyUserMainFavsAppService.GetAsync(Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyUserMainFavCreateDto
            {
                CompanyMainId = Guid.Parse("ca563033-08f4-4b15-991f-72ca6fbba0ad"),
                CompanyJobId = Guid.Parse("a20d7716-9e90-49c4-a490-fb7160d54348"),
                UserMainId = Guid.Parse("b2820676-bd1a-46eb-bc2e-0f1b56d3967d"),
                ExtendedInformation = "cdc43983276942ea8ebb71a0397cad6a455be2fa14f54217a87c1a0290c44241579e6bafb0fc44afb75744ba962c3ca1a52da3b9e10745aea08b1de5fbe4366cfc2342344a854b43b5fec8d441e36a765896c6f05a104848b554e84cc5d2471dd57ad3ddc59a419fb16db06159a3722d1f70f3f916ae48be9614b5e413b38093597691b9d9d646378d19a4bb4dc279cc4f00b9ae78f046e692b666ca324fe2da44a93b588ba94b06ace7a2694fe3ae5e35b36cba32f74e3685ec59022cba94a8341c5326f0fa47b89066235c07dde3af435a97644b594ff491e0a99adc2142222453cfa4f1614c3f949654d77f78ea1d8c46ef479a63484e870d",
                DateA = new DateTime(2018, 1, 1),
                DateD = new DateTime(2021, 3, 25),
                Sort = 2043528309,
                Note = "7e0a9e6093fe4b74b0d188341aa636bfd46f7e581a284dabbb45202762570fcbee632a26ba2a4c849acac439d28dc21a25df4f5a110a47f197e91ab7beefe830e939ec4ea148401fa00d83abe0cdf9947455d94f382c4412b610bf9a9a4ac8ac47a9014f31254e2997c4f96dc19618d5da57fceb9e95496c87d8f55bb85c5a84f421399a62be4f9eb00f15d2b95a54a3d626ff0da2734809a087472386dfdf336c5a4d288d5e471783a1947c0387f28292b5761d2ed1402cbdbbf27c2ef4f177cf0044ed11ab4d51b35a456c8ea520940eb2b8f0c7b84f67b896a6ab12e49877d48f461f59614daab871d17cf2982adb9cd5f01ddc9f4718b2be",
                Status = "7be584d1f7ca47a4b8eb517f2533a18e2aae07ce74284c6ea4"
            };

            // Act
            var serviceResult = await _companyUserMainFavsAppService.CreateAsync(input);

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("ca563033-08f4-4b15-991f-72ca6fbba0ad"));
            result.CompanyJobId.ShouldBe(Guid.Parse("a20d7716-9e90-49c4-a490-fb7160d54348"));
            result.UserMainId.ShouldBe(Guid.Parse("b2820676-bd1a-46eb-bc2e-0f1b56d3967d"));
            result.ExtendedInformation.ShouldBe("cdc43983276942ea8ebb71a0397cad6a455be2fa14f54217a87c1a0290c44241579e6bafb0fc44afb75744ba962c3ca1a52da3b9e10745aea08b1de5fbe4366cfc2342344a854b43b5fec8d441e36a765896c6f05a104848b554e84cc5d2471dd57ad3ddc59a419fb16db06159a3722d1f70f3f916ae48be9614b5e413b38093597691b9d9d646378d19a4bb4dc279cc4f00b9ae78f046e692b666ca324fe2da44a93b588ba94b06ace7a2694fe3ae5e35b36cba32f74e3685ec59022cba94a8341c5326f0fa47b89066235c07dde3af435a97644b594ff491e0a99adc2142222453cfa4f1614c3f949654d77f78ea1d8c46ef479a63484e870d");
            result.DateA.ShouldBe(new DateTime(2018, 1, 1));
            result.DateD.ShouldBe(new DateTime(2021, 3, 25));
            result.Sort.ShouldBe(2043528309);
            result.Note.ShouldBe("7e0a9e6093fe4b74b0d188341aa636bfd46f7e581a284dabbb45202762570fcbee632a26ba2a4c849acac439d28dc21a25df4f5a110a47f197e91ab7beefe830e939ec4ea148401fa00d83abe0cdf9947455d94f382c4412b610bf9a9a4ac8ac47a9014f31254e2997c4f96dc19618d5da57fceb9e95496c87d8f55bb85c5a84f421399a62be4f9eb00f15d2b95a54a3d626ff0da2734809a087472386dfdf336c5a4d288d5e471783a1947c0387f28292b5761d2ed1402cbdbbf27c2ef4f177cf0044ed11ab4d51b35a456c8ea520940eb2b8f0c7b84f67b896a6ab12e49877d48f461f59614daab871d17cf2982adb9cd5f01ddc9f4718b2be");
            result.Status.ShouldBe("7be584d1f7ca47a4b8eb517f2533a18e2aae07ce74284c6ea4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyUserMainFavUpdateDto()
            {
                CompanyMainId = Guid.Parse("c61c82f2-85f5-463e-9f49-d771aa1dccc2"),
                CompanyJobId = Guid.Parse("a512e978-a85d-41c9-bf64-fd0faa57fd37"),
                UserMainId = Guid.Parse("b7bf8004-a75b-41c8-a7a8-b7ed8f3693f3"),
                ExtendedInformation = "4cc74bdd9e90414d986c759e71df65fd5aaebad604904205b57a4316e84cd02ff38c04e464684652bbe53b6c3c6f3f0843649cbb61294e839ab05c8fd6d3d36a3a4c6a7b455f4f18900245ae1cddffe813c913d462e44ef99e4a01e959e49adf59592fdb3f3746289b7bfe98ace225bd074bfe22371e4dc995de88450ac8fb0e1515e86109584a18b91abb5a7232fa45edf580df5a774529bcfae8088023544a0e60e755e283405388eab95f2e4133ffbf001a5dbab840788e838de8d942066c032cb6a781de476f80df905fb19e30af63b17c380b0043a18e4a4538db675fae8e8a6475517648979e1cbf753a2d2898c57d2101305a4a49b061",
                DateA = new DateTime(2021, 9, 11),
                DateD = new DateTime(2003, 7, 19),
                Sort = 1676175541,
                Note = "fa04defebeb54afcaec81703cdef518609859c2445ec410db69535e80475f26909b151c1ae2941fd87ed20de2c165e66ecf087008fe64e64b9825842ae4aef34e3ca97ba5daa4595948b4023b5d62b666b1cb52ffe9f43bd957886edc5f84afe2a6069208856457cb4c94fb35dde1af152bfaf8a352a4e0787c813b1b608e84ae28a0298aa9043fab11c259b46c5eccadcb7b9c89fa742198ceb5ce40cc5122383717ad30fa941e8b192e9dbab98232c19514d8881624e06a50ffdc2cfea605be3c907e2cc474b729721d9ad32e854d7093293b5134e4b2db30bd0d74d42b9498a251056573c4c2f8a38c6c506274b7d7140bc08e520408ab6b6",
                Status = "7f61c4b738b944c98360240a3a961d4c0325c83fa4474c178e"
            };

            // Act
            var serviceResult = await _companyUserMainFavsAppService.UpdateAsync(Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"), input);

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c61c82f2-85f5-463e-9f49-d771aa1dccc2"));
            result.CompanyJobId.ShouldBe(Guid.Parse("a512e978-a85d-41c9-bf64-fd0faa57fd37"));
            result.UserMainId.ShouldBe(Guid.Parse("b7bf8004-a75b-41c8-a7a8-b7ed8f3693f3"));
            result.ExtendedInformation.ShouldBe("4cc74bdd9e90414d986c759e71df65fd5aaebad604904205b57a4316e84cd02ff38c04e464684652bbe53b6c3c6f3f0843649cbb61294e839ab05c8fd6d3d36a3a4c6a7b455f4f18900245ae1cddffe813c913d462e44ef99e4a01e959e49adf59592fdb3f3746289b7bfe98ace225bd074bfe22371e4dc995de88450ac8fb0e1515e86109584a18b91abb5a7232fa45edf580df5a774529bcfae8088023544a0e60e755e283405388eab95f2e4133ffbf001a5dbab840788e838de8d942066c032cb6a781de476f80df905fb19e30af63b17c380b0043a18e4a4538db675fae8e8a6475517648979e1cbf753a2d2898c57d2101305a4a49b061");
            result.DateA.ShouldBe(new DateTime(2021, 9, 11));
            result.DateD.ShouldBe(new DateTime(2003, 7, 19));
            result.Sort.ShouldBe(1676175541);
            result.Note.ShouldBe("fa04defebeb54afcaec81703cdef518609859c2445ec410db69535e80475f26909b151c1ae2941fd87ed20de2c165e66ecf087008fe64e64b9825842ae4aef34e3ca97ba5daa4595948b4023b5d62b666b1cb52ffe9f43bd957886edc5f84afe2a6069208856457cb4c94fb35dde1af152bfaf8a352a4e0787c813b1b608e84ae28a0298aa9043fab11c259b46c5eccadcb7b9c89fa742198ceb5ce40cc5122383717ad30fa941e8b192e9dbab98232c19514d8881624e06a50ffdc2cfea605be3c907e2cc474b729721d9ad32e854d7093293b5134e4b2db30bd0d74d42b9498a251056573c4c2f8a38c6c506274b7d7140bc08e520408ab6b6");
            result.Status.ShouldBe("7f61c4b738b944c98360240a3a961d4c0325c83fa4474c178e");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyUserMainFavsAppService.DeleteAsync(Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"));

            // Assert
            var result = await _companyUserMainFavRepository.FindAsync(c => c.Id == Guid.Parse("bd70bbf9-70ee-49ba-9932-364f3ee9ca2c"));

            result.ShouldBeNull();
        }
    }
}