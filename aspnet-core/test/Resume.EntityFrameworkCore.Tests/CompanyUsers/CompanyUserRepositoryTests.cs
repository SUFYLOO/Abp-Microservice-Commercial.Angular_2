using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyUsers;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyUsers
{
    public class CompanyUserRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserRepositoryTests()
        {
            _companyUserRepository = GetRequiredService<ICompanyUserRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyUserRepository.GetListAsync(
                    companyMainId: Guid.Parse("e2fbcb0e-f5e5-43ea-907d-7df1c5a8d9f6"),
                    userMainId: Guid.Parse("1b521318-4e40-4dfe-bc93-3cd5cbca167d"),
                    jobName: "3b99b353119c4d85b6c0c98860ce89b38bd39d08e12b452c84",
                    officePhone: "f8ef2436063c40c6b528292f48b673b1a8be6155f23f4e7caf",
                    extendedInformation: "c2a71775f3194c4bb64f80aa573ab4b280567875e3a14018a82bb1c03daec918065be42b153f4ad69ff150ca3be01985489e051ecc364feabc0b85c86332538ab07474acf053485e8e6bb86a7b6d67218b4b1df294d7440cadc0faf13725e224e2afc0c93ad94ea0b2994379bc5ced8cdadc7088f1e044d38771ffbe848c908ef6d8f5e144334c18815723b3678ba90583c08f64288d4c5484b76be07a74326f5bc4289c6d424944a8ee855ecc7de80c71c1d0babb404190902647ee78024c6382ebefde2abf4935a391cdbc54658790084d9902b1254258b46a91a14029b7e9f4e3e997828b499484c60b3eabd401150afa133a740b40c5bdd6",
                    note: "9871f62322cd4423ae4410d9d99b9e9c2aaad703b215444e98b92e33b644e2d2ae65d25b688a4aa2aba21ac78f6136927089699139ad47c89a189b0e3fb3c313a8dcc5105a73410cb2a8270b65b3176c415a92ac63274b2e980a581db630b68973f0960640764492b8c9bdb87d8af215734207479c4548a298e032e80ae2551175c86f6fd4b44502a6e797eee491b747cd90861e6b514afe8ad7a0e5ab2ecdf7bb888715076f47969cd2067fb55e95aeb67f8d8c71174c45959c136b5e4b91cfb524a2fc38b9417d808b128e21a924261f5eb696f8bf4670b309c052ffb5e9b83992378812af41f992aadae7cb29e71abc87b2b3691146078ac8",
                    status: "433e37913fa6400987863ef74ad073bc0042cf4cc1d442a480",
                    matchingReceive: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("18371266-a376-4ba4-a518-ce6aece5ab88"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyUserRepository.GetCountAsync(
                    companyMainId: Guid.Parse("e7761047-1f2c-4072-ab3c-22ac96eae503"),
                    userMainId: Guid.Parse("6136c1be-3ead-4061-86ce-b4f628eedd6d"),
                    jobName: "4221e29ccdb1498e8f0482a42c5010ab846de36bb7354737ab",
                    officePhone: "e04f51b5a5554b41aeb81d1d19e3f3042ef811790748476cb3",
                    extendedInformation: "1d103ad462c14b8997189c8e527944877eac0278059f48ed8b99e12177145fe1fac35f4809734d79b2311943b0a6d4417263c5534ddf4fde86d63dbaf6d151ad8587fa8bf03743e293e02856959af63905d5a140fd6e48b9ae536d80c70357288642111fafe24894868cd4b2cc20b2109eb60f46ac214d1293b89f146c737f60477ac34767c049b395899f57deae29e0aed0d3081b5c44d8929d21e3515ff9a5b91978ddf31e4f01a984e448cfba84e1c3519d5a2f6a441c86268fc9acc89a5afe91a260f6bd4929bd5e59d8a45affc7989b85d98a0c4cd09392e9c9a18417a3eae4d6c9f1bd4d9b84dd6844b6b910dc440a752884f14c33a880",
                    note: "27c4706c0f0a4defb9186c90844c5d79788a6dd1b5204c948138a419df05d95081f1e181cc5b4ba19947b256b9b6caecd9e30a1cc5dd4e51be64fb349a2eb802c2b63c99d8ac4ababb645bc59d4efc9401645ec53e9746e3ba08eb374393e4112f2b0ef78247419291479496ed1c13aab6c891d201d94258b998e6ea6bbdf4aedf9a86fa4e7943b39c023d9fd6fe58d75036261d89924ba5adc3f6cac278a4ef7e7b631754f24c3087e083df14fc604851d264ce7ea246d4825befa54c347a8dd9f4cd4a7cc84987b919646ef04816364ac179a47f7647dfa2e3f8b2d19fce688718dbe47bf34cf285cb81e9295cb1b11cc21202057147629bb7",
                    status: "ae919735477c421184f6082aac446adc060a7e17414d4dd3b3",
                    matchingReceive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}