using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.SystemColumns
{
    public class SystemColumnsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ISystemColumnsAppService _systemColumnsAppService;
        private readonly IRepository<SystemColumn, Guid> _systemColumnRepository;

        public SystemColumnsAppServiceTests()
        {
            _systemColumnsAppService = GetRequiredService<ISystemColumnsAppService>();
            _systemColumnRepository = GetRequiredService<IRepository<SystemColumn, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _systemColumnsAppService.GetListAsync(new GetSystemColumnsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("bab14eb0-7273-4588-b219-b4f11e79b0e3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _systemColumnsAppService.GetAsync(Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new SystemColumnCreateDto
            {
                SystemTableId = Guid.Parse("f40f43ee-0d9b-4c71-880a-1f8382cbd6e1"),
                Name = "36e7446ce6dd47a1bdf3bb613be1a6e7ff0b3e7cf1ff417584",
                IsKey = true,
                IsSensitive = true,
                NeedMask = true,
                DefaultValue = "ce16d38595c648beaea769f429c69d2cf4ed39464b744198ba",
                CheckCode = true,
                Related = "c524228b880a44ba97bee229cdb6b3b18297e981c65643d4b19ca7f2a3003515ba15f9abb77b47d0b39181cf1d071b34869fd91b448c4f5d980893d8258465aa54938b6a04c84af08a714fd5b633b015f4fa92aa88104ce097d52836a50f9c8a01402802",
                AllowUpdate = true,
                AllowNull = true,
                AllowEmpty = true,
                AllowExport = true,
                AllowSort = true,
                ColumnTypeCode = "82b82e41aac8490c8495b12d0e0fc76a4874c7efb41f439c9f",
                ExtendedInformation = "514b9ea67b2f47a2b2b2b71ddc0e4dc9a9321f6f4e664c2180fcb82ba6307d1cbccf3078f75343d3a1a04ec42afc236207a002357b5a4210ae6af2317108302e3b093ad213e040d9877b61c4822a6afc4364271b23e64dadaf7e92ba8513978393ee8b4a13fc4a7d94c89579faef56455e32095108194703a6f69c71fe53fe0c1769428dc6ef47bb9b21b3e19501a847bc2e8e4196e24a89a4d8ab43204731b58465dfd2e97444efb2f1de149cbe9ce71056862c939143cabeb77e1b6857fa00655bd3dae3e44e0f8ed8d82c7dd37219c7dca735c85e4ad59c311975477b0218f6f22f917b204a12b6fb84f23f613c9eb42837eeae7c45b5b915",
                DateA = new DateTime(2005, 5, 9),
                DateD = new DateTime(2000, 7, 7),
                Sort = 1787631173,
                Note = "a0a4eca14d1b40b88845bfa29eace727a9a85eef45284d84afad8dbf04d52b337e1e70f48c244b4dae00b08239c3ecb4ad47ad9724c841afa02fef7ba7e9ff819f268fa4c05e478db0d6af44820604f338d227dddd914047897492e42281cb05a3a70dd050f94264bc24138c9ed54e68e08dd1ac42c546d888b2a6a92ae96a06fbc3aedfa3674072aa422283f27bb9a7df5500e88ae84ade93bb25af1928e91871019f122085443184cfdfc76657e1abd4bd49cc98d24af792d6905999865b59a63414a7e3904a6f889fa294a5ccdf2009c25a7fd95e473aac61e9bece54c4e46b39f1dd532545fc96beefb089abcc25a2d4272e28b845a98911",
                Status = "9ad9717393ae46b7b92d08bed35f33db0818bb0d76704f8fbd"
            };

            // Act
            var serviceResult = await _systemColumnsAppService.CreateAsync(input);

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemTableId.ShouldBe(Guid.Parse("f40f43ee-0d9b-4c71-880a-1f8382cbd6e1"));
            result.Name.ShouldBe("36e7446ce6dd47a1bdf3bb613be1a6e7ff0b3e7cf1ff417584");
            result.IsKey.ShouldBe(true);
            result.IsSensitive.ShouldBe(true);
            result.NeedMask.ShouldBe(true);
            result.DefaultValue.ShouldBe("ce16d38595c648beaea769f429c69d2cf4ed39464b744198ba");
            result.CheckCode.ShouldBe(true);
            result.Related.ShouldBe("c524228b880a44ba97bee229cdb6b3b18297e981c65643d4b19ca7f2a3003515ba15f9abb77b47d0b39181cf1d071b34869fd91b448c4f5d980893d8258465aa54938b6a04c84af08a714fd5b633b015f4fa92aa88104ce097d52836a50f9c8a01402802");
            result.AllowUpdate.ShouldBe(true);
            result.AllowNull.ShouldBe(true);
            result.AllowEmpty.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ColumnTypeCode.ShouldBe("82b82e41aac8490c8495b12d0e0fc76a4874c7efb41f439c9f");
            result.ExtendedInformation.ShouldBe("514b9ea67b2f47a2b2b2b71ddc0e4dc9a9321f6f4e664c2180fcb82ba6307d1cbccf3078f75343d3a1a04ec42afc236207a002357b5a4210ae6af2317108302e3b093ad213e040d9877b61c4822a6afc4364271b23e64dadaf7e92ba8513978393ee8b4a13fc4a7d94c89579faef56455e32095108194703a6f69c71fe53fe0c1769428dc6ef47bb9b21b3e19501a847bc2e8e4196e24a89a4d8ab43204731b58465dfd2e97444efb2f1de149cbe9ce71056862c939143cabeb77e1b6857fa00655bd3dae3e44e0f8ed8d82c7dd37219c7dca735c85e4ad59c311975477b0218f6f22f917b204a12b6fb84f23f613c9eb42837eeae7c45b5b915");
            result.DateA.ShouldBe(new DateTime(2005, 5, 9));
            result.DateD.ShouldBe(new DateTime(2000, 7, 7));
            result.Sort.ShouldBe(1787631173);
            result.Note.ShouldBe("a0a4eca14d1b40b88845bfa29eace727a9a85eef45284d84afad8dbf04d52b337e1e70f48c244b4dae00b08239c3ecb4ad47ad9724c841afa02fef7ba7e9ff819f268fa4c05e478db0d6af44820604f338d227dddd914047897492e42281cb05a3a70dd050f94264bc24138c9ed54e68e08dd1ac42c546d888b2a6a92ae96a06fbc3aedfa3674072aa422283f27bb9a7df5500e88ae84ade93bb25af1928e91871019f122085443184cfdfc76657e1abd4bd49cc98d24af792d6905999865b59a63414a7e3904a6f889fa294a5ccdf2009c25a7fd95e473aac61e9bece54c4e46b39f1dd532545fc96beefb089abcc25a2d4272e28b845a98911");
            result.Status.ShouldBe("9ad9717393ae46b7b92d08bed35f33db0818bb0d76704f8fbd");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new SystemColumnUpdateDto()
            {
                SystemTableId = Guid.Parse("398f1cde-6b64-4a8e-9a33-81985ffacedf"),
                Name = "c0fdd146aef34cc4a8c0dccec2930a2266416b0e8f624db7ba",
                IsKey = true,
                IsSensitive = true,
                NeedMask = true,
                DefaultValue = "a3bd06fe1da241d68a0737701bb1decf956e997783334d2a93",
                CheckCode = true,
                Related = "f9f30867e2104efcad0e235243beffd4d069303c6dba4d0fa75fac3082a72f37810c5bcdef324d14a8521d1c840c9d94d9c745d77be64ca0a5a99839eb231c0512ebf67aea7f40a4b555ab1a0aeea3a0b3406e48ac1a400392ee56f5fa1d681abfe30b99",
                AllowUpdate = true,
                AllowNull = true,
                AllowEmpty = true,
                AllowExport = true,
                AllowSort = true,
                ColumnTypeCode = "c872bff435834fa489649597678904fe436f5d48720f4bafaf",
                ExtendedInformation = "3756912746254dbc9570e8a7b1655b5b205e6c9a154a4cd39a96d7314ae4e038f6d6bee73ae64781ae0710370d36c533127de953ae5b4a20a041a45ac82424f85a5fb307da5f46e3a428385e711073982e4e6da06c654d5f88f505774d56f39e06a987bac7bf41cba82b04c002495c15ea7498d5ce154edc85b2b551db41358cf0337c4db1814f3ba57cbf05b1d66a8172f1c4981c974ac6a631a963b1097752dc95ba1992aa4783b5e3b4b06df615196779c3ba792146b4b1db2487025bf4ffb4e385cbb25c47c7a05737dc923270923080ffc02bd24f289d214a80f46b564c36c7dbb2041642e8af82a4905712d98bf9a170d839e6464583a2",
                DateA = new DateTime(2003, 10, 21),
                DateD = new DateTime(2004, 9, 24),
                Sort = 615187457,
                Note = "92abcb255eb44472aed3ea8cf1f1e168469e35a597014c7393c340b14c3a17a26191abecb8674e548856c97d32d0ebc1005d0b90f38e4c31967f96b0da2b22f052612eba14184420b0b55563f775cdc7375ff97292cc4c3cb1e4cbd6a47d64afb4e156f097494095a2fd61dfbb59b6585aa223dc3f55418db06dc28be8e7f9db788a790be6d04c37835ba05d6b7fd356fa9c8bff3d15407c8878db792416d0d1731e4a75ee43433ba21e09f72f9dc2f5d68193e3227f4a74b636e464e21d9bceeece4ca4917542cfa44cfe60f917bebeec7034989c724dfd896618f50604a481545c6d6d14be4d0daf1f4dc96990e6f7643701149d8e4b8c80bc",
                Status = "d14a9ca341284939a3b6cd24a386e98030b30c21c1ff4bf6b6"
            };

            // Act
            var serviceResult = await _systemColumnsAppService.UpdateAsync(Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"), input);

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.SystemTableId.ShouldBe(Guid.Parse("398f1cde-6b64-4a8e-9a33-81985ffacedf"));
            result.Name.ShouldBe("c0fdd146aef34cc4a8c0dccec2930a2266416b0e8f624db7ba");
            result.IsKey.ShouldBe(true);
            result.IsSensitive.ShouldBe(true);
            result.NeedMask.ShouldBe(true);
            result.DefaultValue.ShouldBe("a3bd06fe1da241d68a0737701bb1decf956e997783334d2a93");
            result.CheckCode.ShouldBe(true);
            result.Related.ShouldBe("f9f30867e2104efcad0e235243beffd4d069303c6dba4d0fa75fac3082a72f37810c5bcdef324d14a8521d1c840c9d94d9c745d77be64ca0a5a99839eb231c0512ebf67aea7f40a4b555ab1a0aeea3a0b3406e48ac1a400392ee56f5fa1d681abfe30b99");
            result.AllowUpdate.ShouldBe(true);
            result.AllowNull.ShouldBe(true);
            result.AllowEmpty.ShouldBe(true);
            result.AllowExport.ShouldBe(true);
            result.AllowSort.ShouldBe(true);
            result.ColumnTypeCode.ShouldBe("c872bff435834fa489649597678904fe436f5d48720f4bafaf");
            result.ExtendedInformation.ShouldBe("3756912746254dbc9570e8a7b1655b5b205e6c9a154a4cd39a96d7314ae4e038f6d6bee73ae64781ae0710370d36c533127de953ae5b4a20a041a45ac82424f85a5fb307da5f46e3a428385e711073982e4e6da06c654d5f88f505774d56f39e06a987bac7bf41cba82b04c002495c15ea7498d5ce154edc85b2b551db41358cf0337c4db1814f3ba57cbf05b1d66a8172f1c4981c974ac6a631a963b1097752dc95ba1992aa4783b5e3b4b06df615196779c3ba792146b4b1db2487025bf4ffb4e385cbb25c47c7a05737dc923270923080ffc02bd24f289d214a80f46b564c36c7dbb2041642e8af82a4905712d98bf9a170d839e6464583a2");
            result.DateA.ShouldBe(new DateTime(2003, 10, 21));
            result.DateD.ShouldBe(new DateTime(2004, 9, 24));
            result.Sort.ShouldBe(615187457);
            result.Note.ShouldBe("92abcb255eb44472aed3ea8cf1f1e168469e35a597014c7393c340b14c3a17a26191abecb8674e548856c97d32d0ebc1005d0b90f38e4c31967f96b0da2b22f052612eba14184420b0b55563f775cdc7375ff97292cc4c3cb1e4cbd6a47d64afb4e156f097494095a2fd61dfbb59b6585aa223dc3f55418db06dc28be8e7f9db788a790be6d04c37835ba05d6b7fd356fa9c8bff3d15407c8878db792416d0d1731e4a75ee43433ba21e09f72f9dc2f5d68193e3227f4a74b636e464e21d9bceeece4ca4917542cfa44cfe60f917bebeec7034989c724dfd896618f50604a481545c6d6d14be4d0daf1f4dc96990e6f7643701149d8e4b8c80bc");
            result.Status.ShouldBe("d14a9ca341284939a3b6cd24a386e98030b30c21c1ff4bf6b6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _systemColumnsAppService.DeleteAsync(Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"));

            // Assert
            var result = await _systemColumnRepository.FindAsync(c => c.Id == Guid.Parse("d6a5babe-2697-492d-b6e7-3c64e4993585"));

            result.ShouldBeNull();
        }
    }
}