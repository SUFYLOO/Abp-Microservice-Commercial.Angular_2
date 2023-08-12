using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeWorkss
{
    public class ResumeWorkssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeWorkssAppService _resumeWorkssAppService;
        private readonly IRepository<ResumeWorks, Guid> _resumeWorksRepository;

        public ResumeWorkssAppServiceTests()
        {
            _resumeWorkssAppService = GetRequiredService<IResumeWorkssAppService>();
            _resumeWorksRepository = GetRequiredService<IRepository<ResumeWorks, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeWorkssAppService.GetListAsync(new GetResumeWorkssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("c9948a48-83b8-4305-88a8-1d9185e04c69")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeWorkssAppService.GetAsync(Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeWorksCreateDto
            {
                ResumeMainId = Guid.Parse("f381693f-237a-4d6c-9c71-04c80a2c36b2"),
                Name = "7a5f0014e7514e53ad1c732db53d2cf7ce80a2466b99476e9c2c9f2302ecb692288c0dc020ce472482c764c19943f386f19d8b0598364cba8d7dd3abb47dbe64754c62faedef415a9be2794f144c4a88e5cd15926c4c41738598b2ef33cf6da4dc2769bc",
                Link = "fb58d279f0f949f8ba7a126ee57ffa58a0d108cc5c18485b80f04114443cabaceddaaef5923847eeb221f274d7c5b68e1390636ff6084dea86607f3a03d927adab14461b88924f78bb5227c42d570a6a5710c093c1844771bdee3d8d1c764fe9cb8ecd7897a645f6af947ab1d5eef51c3efd66d6f2bc493c9529fcc41026b82c07d4ae72ce8a49f4884b1da9cfa042369547d417a57f44298caa3a438d8c853a93c1e1ced8194ef19396603cb732a31964a17f011aca42308e1197d31f44454045432148c3e54165882a0478bd026a67f23de06278974fbc88145662081178ad678e936dccca4c028a02aaa3f270ec9d665f8c15698d405eb50d",
                ExtendedInformation = "0fbc5189994e41bdbe9099206ff6c08193fd17ca8d5346bfa92b931e9aa24ea424d7aa72c3a44d208a59ed7969ee4a688ea87110363d4cfc9f3a5f22b722b3b505a14087d6d942ed8fffdcacec639f5d376780966b0f49cb8af938c432cb75e2faf34e566d6345acbd9e871b2f2d8fba0597b528279840c7b1a2d0f9800a685439a3583024f94230b4dee3213aabcfc7c713609ebb9c4a379767abafd99f46ed52c0d0f92607495f9af2f11bd26960045d5e53fe4b9845e2881d442a491f3d3baa0d1a3248e44dbf88f86605e2fd284c6fab67ff734c4abba143efb33204560ff11a0b999c6f4a39a6f2812d37a55de67bcc5b184dd748a38e13",
                DateA = new DateTime(2018, 11, 15),
                DateD = new DateTime(2004, 5, 22),
                Sort = 1211997996,
                Note = "53f4090d127a422e8e4b01bba9e9c68d9f55ae561fda490e8b23f6fc6fbed64135b8204f0c0e4b07bca6a1a1b7f9a2dc11d307452e0948259c9323a74ba51649233a13b516c3426f8ed3668ef20ffa70b57ca4a2a6284b818d5b60737a0ca683e7e71ec7f7d7445cbd73eaf3cd5f27be84efe17da6a2479e87e5796de77fd0ea09d940b1ffa340cc8e948dc8f2acd408d11f5f97ee7646dfa563537da75d767a3cd7df24f9b34ecc8a01b04eed5961aae85929721ff3410e85a2b59f03e0260b3bd7461c57d641b18a8aef9f21b1e6e42d78a13f97b24fbeb435db15857ea16e3e3ac16a232d4759896f9a72bbbf352f708a0b1b6b744047bbe5",
                Status = "acef322fe6f74d94877c0edd920f93f07e611b022a0745db85"
            };

            // Act
            var serviceResult = await _resumeWorkssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("f381693f-237a-4d6c-9c71-04c80a2c36b2"));
            result.Name.ShouldBe("7a5f0014e7514e53ad1c732db53d2cf7ce80a2466b99476e9c2c9f2302ecb692288c0dc020ce472482c764c19943f386f19d8b0598364cba8d7dd3abb47dbe64754c62faedef415a9be2794f144c4a88e5cd15926c4c41738598b2ef33cf6da4dc2769bc");
            result.Link.ShouldBe("fb58d279f0f949f8ba7a126ee57ffa58a0d108cc5c18485b80f04114443cabaceddaaef5923847eeb221f274d7c5b68e1390636ff6084dea86607f3a03d927adab14461b88924f78bb5227c42d570a6a5710c093c1844771bdee3d8d1c764fe9cb8ecd7897a645f6af947ab1d5eef51c3efd66d6f2bc493c9529fcc41026b82c07d4ae72ce8a49f4884b1da9cfa042369547d417a57f44298caa3a438d8c853a93c1e1ced8194ef19396603cb732a31964a17f011aca42308e1197d31f44454045432148c3e54165882a0478bd026a67f23de06278974fbc88145662081178ad678e936dccca4c028a02aaa3f270ec9d665f8c15698d405eb50d");
            result.ExtendedInformation.ShouldBe("0fbc5189994e41bdbe9099206ff6c08193fd17ca8d5346bfa92b931e9aa24ea424d7aa72c3a44d208a59ed7969ee4a688ea87110363d4cfc9f3a5f22b722b3b505a14087d6d942ed8fffdcacec639f5d376780966b0f49cb8af938c432cb75e2faf34e566d6345acbd9e871b2f2d8fba0597b528279840c7b1a2d0f9800a685439a3583024f94230b4dee3213aabcfc7c713609ebb9c4a379767abafd99f46ed52c0d0f92607495f9af2f11bd26960045d5e53fe4b9845e2881d442a491f3d3baa0d1a3248e44dbf88f86605e2fd284c6fab67ff734c4abba143efb33204560ff11a0b999c6f4a39a6f2812d37a55de67bcc5b184dd748a38e13");
            result.DateA.ShouldBe(new DateTime(2018, 11, 15));
            result.DateD.ShouldBe(new DateTime(2004, 5, 22));
            result.Sort.ShouldBe(1211997996);
            result.Note.ShouldBe("53f4090d127a422e8e4b01bba9e9c68d9f55ae561fda490e8b23f6fc6fbed64135b8204f0c0e4b07bca6a1a1b7f9a2dc11d307452e0948259c9323a74ba51649233a13b516c3426f8ed3668ef20ffa70b57ca4a2a6284b818d5b60737a0ca683e7e71ec7f7d7445cbd73eaf3cd5f27be84efe17da6a2479e87e5796de77fd0ea09d940b1ffa340cc8e948dc8f2acd408d11f5f97ee7646dfa563537da75d767a3cd7df24f9b34ecc8a01b04eed5961aae85929721ff3410e85a2b59f03e0260b3bd7461c57d641b18a8aef9f21b1e6e42d78a13f97b24fbeb435db15857ea16e3e3ac16a232d4759896f9a72bbbf352f708a0b1b6b744047bbe5");
            result.Status.ShouldBe("acef322fe6f74d94877c0edd920f93f07e611b022a0745db85");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeWorksUpdateDto()
            {
                ResumeMainId = Guid.Parse("e93cc306-a473-4e3b-b224-0a7457f9cdab"),
                Name = "c7c52912433343319733c9268fd35a5ed7454fb871ba4487bc8737079b0fba937ca98589c7614df6a993509cc6d5d954c71d93bc12ef420183a07b461efe2d8ebf08cc97322444e8af49fde451c0691ca5950173f4284683ae78fabbc8f63a7f764bcea0",
                Link = "1366c55a42ed4c4888bb30c0d2dadd3cc43604c4c7dc42be8cee7b957094d5fd350501885d35492db4c16ee6f67ce7e52490a1718760429291fc357740dab3c7d8d582ef82534952990010bb3fc207b189a5f6d063374c7a92ab9aa84d56c8e3f70f5f4470e048768ed5e1bc6fc979bc07c9dcf5fd074ea48fff2f41fe666142b2f4ad24fd8849ce80a01f8dce9d183ecf5d2c2cc2cc49ab9f44398f23578c80be228d4028b04a27a7bc7f066ac067ec038bd3a5fafa4b4ebe1897d1cd60d176e910ec91bf034de4bf51461afdffa861cd2083e41d2246de98c87d350bf9b6e11d057f7947af427b98434fb6c7ed47f33193bfef2cb748c48daf",
                ExtendedInformation = "f83692be3d934f42bf918790f407a73b21a3574ecf5a4eacac8244583d37a01c1d1611c1a33f4a46aad75f727475757d483bc39565424945aad651879a6168f591ba3a9d11ee4c809448c19186f6ccf8adcb518cae6444a4ab852800ccf22498e028b1cd2c42431393ff07e20afac9d88aabced885784c4b855f563488d76634e206c6a1e98e4d7bb5909f845fd09238bd9fa02e94d3429398a3a67ca9735244fa315c31f6e5409fa72b6b627fa6633447e0e15179d4450ea8a2f036d6f4628ee2d32981c23b40a593c15a7c36b06c3f84e74b60b4c34326ab6ee954ec27b5af9f0f60ad80b44d2a8d37a62646756fbb32ecc25b982d4c12a298",
                DateA = new DateTime(2009, 1, 25),
                DateD = new DateTime(2013, 6, 6),
                Sort = 1246756910,
                Note = "f75260f63af7472db446198e2934168e1c4592d6dac24e06b0cd774bc016d0020dc05ed3cf2f4b87a94ef75c3848dc4e517fa6ec12174b02ae204df4f39e598e3bc0b4992e5e4d3fae0c20f2fc27b3247636d6f605e2433b9e19af47594d473aa8722ccba0ae4e5da352252906148d02911bf3a234844ecdb30632a521c1fefa73577ddf9c014f8a92b8237ae115e57ec6eb740ca9ae4bd7881128f5347ad82c4910a7bded954f22959e36d80a8c529d5aa20b09e276483fa185bd0314ca6303216183582e2444e8b511b8549f8df736e49f9225769542cda881e579ce914b7c903742b6c6834615b3ec1ac7040662db5c9ff5d88bc841f389ce",
                Status = "c63e6675a0f14e9fab0255e9d5107ef87683cc054693452a87"
            };

            // Act
            var serviceResult = await _resumeWorkssAppService.UpdateAsync(Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"), input);

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("e93cc306-a473-4e3b-b224-0a7457f9cdab"));
            result.Name.ShouldBe("c7c52912433343319733c9268fd35a5ed7454fb871ba4487bc8737079b0fba937ca98589c7614df6a993509cc6d5d954c71d93bc12ef420183a07b461efe2d8ebf08cc97322444e8af49fde451c0691ca5950173f4284683ae78fabbc8f63a7f764bcea0");
            result.Link.ShouldBe("1366c55a42ed4c4888bb30c0d2dadd3cc43604c4c7dc42be8cee7b957094d5fd350501885d35492db4c16ee6f67ce7e52490a1718760429291fc357740dab3c7d8d582ef82534952990010bb3fc207b189a5f6d063374c7a92ab9aa84d56c8e3f70f5f4470e048768ed5e1bc6fc979bc07c9dcf5fd074ea48fff2f41fe666142b2f4ad24fd8849ce80a01f8dce9d183ecf5d2c2cc2cc49ab9f44398f23578c80be228d4028b04a27a7bc7f066ac067ec038bd3a5fafa4b4ebe1897d1cd60d176e910ec91bf034de4bf51461afdffa861cd2083e41d2246de98c87d350bf9b6e11d057f7947af427b98434fb6c7ed47f33193bfef2cb748c48daf");
            result.ExtendedInformation.ShouldBe("f83692be3d934f42bf918790f407a73b21a3574ecf5a4eacac8244583d37a01c1d1611c1a33f4a46aad75f727475757d483bc39565424945aad651879a6168f591ba3a9d11ee4c809448c19186f6ccf8adcb518cae6444a4ab852800ccf22498e028b1cd2c42431393ff07e20afac9d88aabced885784c4b855f563488d76634e206c6a1e98e4d7bb5909f845fd09238bd9fa02e94d3429398a3a67ca9735244fa315c31f6e5409fa72b6b627fa6633447e0e15179d4450ea8a2f036d6f4628ee2d32981c23b40a593c15a7c36b06c3f84e74b60b4c34326ab6ee954ec27b5af9f0f60ad80b44d2a8d37a62646756fbb32ecc25b982d4c12a298");
            result.DateA.ShouldBe(new DateTime(2009, 1, 25));
            result.DateD.ShouldBe(new DateTime(2013, 6, 6));
            result.Sort.ShouldBe(1246756910);
            result.Note.ShouldBe("f75260f63af7472db446198e2934168e1c4592d6dac24e06b0cd774bc016d0020dc05ed3cf2f4b87a94ef75c3848dc4e517fa6ec12174b02ae204df4f39e598e3bc0b4992e5e4d3fae0c20f2fc27b3247636d6f605e2433b9e19af47594d473aa8722ccba0ae4e5da352252906148d02911bf3a234844ecdb30632a521c1fefa73577ddf9c014f8a92b8237ae115e57ec6eb740ca9ae4bd7881128f5347ad82c4910a7bded954f22959e36d80a8c529d5aa20b09e276483fa185bd0314ca6303216183582e2444e8b511b8549f8df736e49f9225769542cda881e579ce914b7c903742b6c6834615b3ec1ac7040662db5c9ff5d88bc841f389ce");
            result.Status.ShouldBe("c63e6675a0f14e9fab0255e9d5107ef87683cc054693452a87");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeWorkssAppService.DeleteAsync(Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"));

            // Assert
            var result = await _resumeWorksRepository.FindAsync(c => c.Id == Guid.Parse("a2626a9f-35a8-4510-b711-a0d29368c24d"));

            result.ShouldBeNull();
        }
    }
}