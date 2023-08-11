using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyContracts;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyContracts
{
    public class CompanyContractRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyContractRepository _companyContractRepository;

        public CompanyContractRepositoryTests()
        {
            _companyContractRepository = GetRequiredService<ICompanyContractRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyContractRepository.GetListAsync(
                    companyMainId: Guid.Parse("1d794af7-442c-4759-88e0-257fa5f3267e"),
                    planCode: "9695e88665d845bc98650accfec59ce450e02be2207841bea9",
                    extendedInformation: "3ed7308cf3924e4b8f9e52d99668ba45c35b3018f0ba447e884977e114f4f2e062c7372091d249b5b7242b7d2b6c36ec5fbc278cc19b4ea0b32ffabb667e44e0625ae7d1fefc44e6af0256276d3da3c196ca3b8b84694ac8a5f74c9e64df51735dfc62c1467d48db9ce11190f7350ed438b895a37be74992bff42fe827087c3ca96f651020d34871b44e8181bad9490524c1dfb3c0094299b16a84e45a5652a87b60d7c0e38445e28434358d54d30d77edffffb775d94dedb01ed1eec49b574adee5680063e14532a07de04e4ac1b37203da6e9b8f514b19b4b4a2913557280662a8fad5aba14febabac034911f3385c09e5ad8e8b984a678031",
                    note: "8399e40659044dc5bd3654200c23a63a73d16339d23e41e7bbc6ebcf80c8d3eb47497d41f2234b06a8e2fcf1db3945c3ae81eba34ea64ae7b13c3bad4251d624bf085da735d949cd99a4953eca7697137cff8b94c22549f68c682e1caf40835d434f39c15f5a4218a8966797f259bba663a1fcd6ce5842d18d50dccc8fec467f423aeef0280d4c76ab1017f07b4067e8f3ec108ad334407b97270a11259b39d569041809397d48fca8bb4051cc83befc306e7a0eafe04c9bb79a207b3189281831f60219122c40519e531f8b01e74fe4f1e70828d0714dec9192435c3a8147cfb00a561f0f1749f28e3b83d99572d557ecab78d0ab404f7ea51b",
                    status: "8a10d76971114327b27603847bf3ab816c8b945fbaec426b94"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("14721411-a602-4075-89cb-c2cdc5b2075f"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyContractRepository.GetCountAsync(
                    companyMainId: Guid.Parse("c2b6c549-c9c8-402c-8ef8-f219b0a42e84"),
                    planCode: "0fadf19f202f4e068d5abf013cda8de771959bb7266c4b1d8c",
                    extendedInformation: "206777b4d4834c17986f7be309cb7bba93feed83dfb94717b7b6f03eb0c1debe74f3ba87e6c94cbbafe8ca65a5db5e9bcfe07c6c819d4135bffbfef6ec2174cc1f33b954d9a84a7d9e3c54f74fa158d00df0eeb84e4b454d99371efee34c537c0140ac500cc0429db25c7dbd25d62a513b5a901ba9f24915b811a9729ded009ea1dfc9aef13e4360a084b50836410c478eef2db032f946398747fe8cde3273ded06d26dfb1f14f87a47dde5f99ce75dd33d8b16bcb034ee1a7f4da14baa8f8fec7b44d24e9654ad4a4501abf18ae8e4f5aa5e791ddff46859541790a95c7ffa544dcbdc2cae645079b225d6184f80553b74f633d8e604be781da",
                    note: "ca8ed21aaffa40d0b640e145c5f0dbc3623c1269664a4002858c9efb8ad3a0b4dbf463ad5d134f95aaf10034db7e53734169647b5ace463d89e70d179b43c8f44adce8904e21451dadd286644a561ec6c2f2e4d47f7943c0b1ef627ed4b85d47742f448a789a4f12a1e4acff2754c175c32dc3c271cc4334aa257b232a38bd78daa2e22642774a79a2452793a17903a48be9537bdd4546d28ba407d8768c81acdfa940a650814c25aa5cc06b7b5ff1cd621ef0fcfebf4e1fa8f2c3b363dc21e47251ef416fdf4e578818259925e5f5c779a5eeb850c0423790774ad3f1e1c7e6d22725af9c844789add2e437dfe2b8510ecfd09f0607485a8f20",
                    status: "656942161541423ea7eb7b4af2ed73af5d20911cb76d401889"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}