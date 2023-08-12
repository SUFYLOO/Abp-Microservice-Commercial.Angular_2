using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ResumeEducationss;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationsRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IResumeEducationsRepository _resumeEducationsRepository;

        public ResumeEducationsRepositoryTests()
        {
            _resumeEducationsRepository = GetRequiredService<IResumeEducationsRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeEducationsRepository.GetListAsync(
                    resumeMainId: Guid.Parse("bf3e6997-1472-49eb-823b-d8dd37ef6ad4"),
                    educationLevelCode: "0becd1fbbbd0402fade51fde2ed1e94b6376631a26104c08b6",
                    schoolCode: "f2866c32ccbf410fb1148c9731aa17ce7b688dc8f33543ab8c",
                    schoolName: "b92ce0ec07104ac8a2e90c685da2ac243b23b67ce10d43e98911aee152b58e4a8c584b78fd19497da94cc76765a21ad8c67aaa08fa8b44a9913b2fde84a1b013a917a9623a874022a7342bdc994c757ab11647241265458b9da83314533f96cfed5d6a89",
                    night: true,
                    working: true,
                    majorDepartmentName: "e4ba593e7d994ae2b78fe20f342630cafbb919f6dc274326a5",
                    majorDepartmentCategoryCode: "74fb8b0b1d3b4ff1844a8189b01e7a2961f03dcf69194b58bf632344704712c9b78b11c9562b4d26804d9ff7c97ff1c0dd1fe9f00a1548f198f89276bca235294eb10402e0e1426fb8618fd5bfd41a0588a2d460f9d94054b3530f7c5cb915a0a4095cfad2f549e39aaf9ceb7b96a76b2a932ced043f4285a1f83fe313fe2444c1aacd2858e5495bb9223c0668b4f265d4ea56b12644400e81adce0101857a95d37a915e3627413f87aba3bf14755903a79d7bed2d774056b4e8869a6eead8805695284d25a14b0b94e5660a6f12c8d447a6c34577234bf7a5e7df0bee8236d4eb8d645be5a4435ab9a384204f1c446112c7774ff27c4f099b9a",
                    minorDepartmentName: "ceb730baa07c4f11afbff9030c9c53e57848c0c4a0f4492490",
                    minorDepartmentCategoryCode: "ebb6b88c429b49ab830f991113a81968f6e197fa9beb44d4a7c787fe2d4c33c12c5d8cdf10764e51bc702fb623ea42856eed012905d547159378e442fa2db8a01dc5201990164cf281833f74e83f4b68a7546e4477de4fa39d2053f5d4d6eacc6cf4cc69c06f428abc4f31670f51ba15967dcc937b994209aeb139501615f92218790fac7d58484d89adefccd0a7869a1e7740f3fc2a4097b543d0c356ba31f159bc6bb8faa8414fb88b758bfad3566af0c87c4cd4e64b13aba18e4706d8455d6a26e3a866464d36ba2a20f85b9b97502239763c8aea49c5b817d0bbafbfea8ad517cca632964fca9fb58ac7f258cc7629556fc497c144da969d",
                    graduationCode: "1aba89a0884c443c93acd6337fde1411175231e9eaf7431abc",
                    domestic: true,
                    countryCode: "47dcfc2cc4484f34bcfa1afe10609bd331c20044e5cb4cdcb0",
                    extendedInformation: "664231a2e8444255bb2289a63170e82c83aa01a71ac146edac873712b7472869bde0debca3cf47adacad872d89e7b1bef384bc68c9504f1ea79edce3535f57f6b20723302a354cde84ded0ed30a4bcf8c2d98ddddab6469f8aaa929c43f7db4d6f41a872e6fc4dcb8327df1e487d6870d8403e44c23f4373b9a6a6081df5104209d1cdfa15c9476ea6299b58fe890f367ab1c3023ea54d199039dd3db233235efe79c055ef8a438c9230280a46bb6e17b0f012713c3c4002b3163e01831efab0162d220dcd50431782fe1796b71b297c5435f7e299aa463c98e57360e33ed3fabd83e401bd8d4e64a1b12786339117c0d3292b2304014890a91a",
                    note: "ccc9a442c7d94b0ea0a4e74b0c495b6c66928fb63ae044418ad1bbd00698a377902d9c7206e14988ba3f3186f1f0be604c8c3f45145645fbb2cc0dc8bbd6a1835ba8c9930c3c4e8fa01dd7492c8112b0f061125722db49e98a1ce0bcbad7b8a760557ed35197473f8216c3a2cd116fdfe27f46ce384b4620967fb76bc50ab73e97beddff88914777afa3e6064d05243862e848d8844c4fab8763b71733b4dadb14dc9cf0898b4ddea6f62a89a532d3f9fe4e19b528d949cb89d0d660a7917b7c67d6ad4dd1d24c278993556049847f648725a04df57547e08298444dc2be78cf98989631e96742bfba706ba97315a63d87cad0dd887e4db19430",
                    status: "301abb68bb854c2d91a8d9581fdced4f20683434c4664c5285"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _resumeEducationsRepository.GetCountAsync(
                    resumeMainId: Guid.Parse("ab8312f4-5692-4b21-99b0-aebfb13d1d19"),
                    educationLevelCode: "dd6817596d4b43e3b3532d77e6bbf427d23ed5698f0b44edba",
                    schoolCode: "cb196219e7af47b7af7ad73c7e9adaf2b07854eeb4cf4cc2ad",
                    schoolName: "0ac734d8521b4ce2ba99a6eda8f449fc8e6e7980cedb4b43ba067a0f6a22be2dc0747afd7ae54a3db683a34551b9ff12558fc203c6d94f6fa666b1ea91b8ab88c5b15a3429964efb9f137f215a63975b87644b3e47b24ce8a05950e836f8b6c84bb51e72",
                    night: true,
                    working: true,
                    majorDepartmentName: "ff50445a301643658e05db1645a67d73008451365b404927aa",
                    majorDepartmentCategoryCode: "7b91f48099274803a315cb686cdd6ffc31a3e3a3da26492fb117f2e65d45753ef412657a13714487ac6ec8484ca71d2df11c537ff1b94131ba235a0111687e7439f12eb1b18e4f8e827adaf8fa0ba9ea3328dbffc2b64619926a3befef765a674b000790bddc4c19b9539e34961e2c2e53f6c8d3002e456387f70b88ccaa54eb9eb6ad2e4b81425f9694d346cf8b7afa3e354b5f1e874900b110ea5eaca93e9e9aaa09dcba6c40c489c93cd373976f5ad95eea57341f4bde84fd1a5fcffe163ab1d5d4d655474d50978416958b3eae244b6a29dfd3cd4f4ab28e051b8127afefd5c3a575e18e46a09e2937e4e457c46a02bff69ffd8c47449e42",
                    minorDepartmentName: "54c9b3b3b9184fb287ecd4bfebe5bf30b537c685a3a8435195",
                    minorDepartmentCategoryCode: "5087af7c3ade4e50bc9c893e3aa5eb104545c085970e4e32a0f9a2f662233632358ec1f71cba4be5952b4d60d3768cd77239434fe3bd4d88aa8895c68818b809e88f182fd53744dd90330df2133824132756e0906fa6470aaa3b679ee11fe915ba35376ae3b840f1a2436a8b4c18045499663ed2900b4641abfb70105f203014e5f59d322d2c462a951e033bf3e2bbc49622352fa9774339b8257c4774daa657fd13668c33cc43d78b1ecbda965fabf7909e78f65b334a8687bd826106079a60cbea9d7be1b440e690653e0c4bac89cd59ef09f98a0646949c53a620580684e887b354804701493992dd66fb40a92959f818565ee725494ea980",
                    graduationCode: "acc37c7c7b47464ba3a0608c79dd3785b21ff25c0bb7485f86",
                    domestic: true,
                    countryCode: "8fe9ead70dae4e09948d1e6ced5046563a9d7f7b61d546f188",
                    extendedInformation: "e591fe7fd44f4d0ca0d9547a1865de22f28947dda1414700b6466dd053d2d53357fdd2bdb04a4fc3a0961916abcd264cea8a92bf6b7640a0a37c07b9feac27d37a22d8d248224b24a89f61bf0c591b293522e1d2f5ea4284af56cfaa095ad3c0c134c1ccba0748d9af272edaa852effca9dc04c167d549d2911200512f2395308c329e66ca9541468e3ae4987de061e692e6d5599ece48d5830de5c2f39cdc8693bc03690f3f49ccac2b71b52d41ef9f3870ceb8c153467da43ea7e5a963b46f43a093938c1c4747804f2a3df077f40e0d24aeacac914ebfbff39efe612169614b6c63d4b3f2413890d5212217819e11d6733324206940e081f1",
                    note: "628f213c507344d08f8332e02d428aaaa4fedd41d84c4dfd872b68868865a698b4f5aefbcde34be9accdd08272835965b2e131d9e1984d69a03d28fd3df9322560e44cfb165c40dc8da0e6c49c568470fedd927a53e54820bb719727c7b0938e7ec0dff38c9e48ac984a8263ae18a3038e329ceb68174d07b5d3471975aadb133ede9d3a674c40e0b6b4cc096d85c07ef3da7c62b45048f3babbcd664be4dc537c9438dc708c41c79903416385ed253daf14bef24344498d882517917b35692748f1eb58b81c43dea69b3d04c1e04ba76f17aca7a5bd4969ae6c8aecc850e9548c2c45caf0634106937c669e5d4d001b57624e317e7c4e9a91b0",
                    status: "d06645f1820e4e0da1c61b742d80b3c37be529bc13c14bbcbb"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}