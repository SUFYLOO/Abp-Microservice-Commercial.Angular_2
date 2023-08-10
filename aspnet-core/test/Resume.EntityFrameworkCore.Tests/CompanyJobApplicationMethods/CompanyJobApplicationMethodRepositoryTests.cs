using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobApplicationMethods;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodRepositoryTests()
        {
            _companyJobApplicationMethodRepository = GetRequiredService<ICompanyJobApplicationMethodRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetListAsync(
                    companyMainId: Guid.Parse("20783b9e-a9bb-441f-a8dd-3811aa74f6d6"),
                    companyJobId: Guid.Parse("558e99aa-ce0f-4aa4-adfd-8f816a9caecf"),
                    orgDept: "a6bb19e4b6f74476b396643848188e13ba67d2313d3f45378d0a0687a21867ff235697206521420396f3bcb04e3e77391e3e277e0f5243c5aadb51454bc4f5763868872620e949eaab7909006b76e61e081901c06a794009a9262199cf672f44b469cad56e684a5d9321bf24ff8c5c1e89d942647f7a49ed996efb3b2257c79ad32547e5b4f244bd9921429e6be7877ce4ad5cf3ac564d37a763d0c1b8a0a6282b935fb2373646768d03cbdd83dbf18382f05d0bf27e4209a9a9ed29a4dc38cf50c01da0eb4e4c7f8df922816902729faa3319f6a5a1475d86b5954d8b76f5f9fcfd07777d23404a9fbb321e9c690e20ad833ede2df648768989",
                    orgContactPerson: "38270b7cdc204f63b6ef1140636496131b3438f0020a4869b6",
                    orgContactMail: "7256d143f2494cc1a32d3fbd8a40bfdca8c628ab0ee348988e7528f1edc639143fc8a172396a4725992986bb86b8a447077dd14da7014979a19ea7c989650bf78503063fb0d64318b0edf051dd2a9a0477917c286d194d7d8258da451f74365c57ca8051b4314af297f2c542834f18284ef72dc7ae4b4ce888a61bcf062e6aee467a1fad54ab42338f910186f646885d44f34efa2a2e4911993dccc8b7a96896e60f8d495b174dddb73ea7957fc16c5ac7ed189f032c40daa953d166ccc72c31d3901d1683ac404a8930291b6ed5a1200d232e7bc3b84cc0adc0bef900fbe84a31c7922663ed447689247fb23487168f83eb5f3f7f914d36bb1b",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "614ec8e8a44b470aac8164d5853791aeb0d14ff8f62942be8a",
                    personally: "909f5a2076f842cf9920a5bea207b88f048e4887cfac4b5f97fc74c3b6701aa07b8ed2146a1f4c748e7c55f7eaeafca39585cfa9316845b383b5c4417a8763bd90a8b1c050604d88a245c887f84da55a26c08529abdd494b988b7275c12766ed70216661",
                    personallyAddress: "756cacb0d481462d94f89fb30ee94e3830089ce2a81045c79faba098bb202e007bcaaa441a57428eb1decce1f3b2cfdf0c2aca3a68f04b578d31e707a45dd320f3b0aa3ba8f1485ca3409b29c785bef3d79e129aff2648618dfc3cfd250fd1fde0007d15",
                    extendedInformation: "60da9c1b4a5843d1a96a3edf5da52a8fb9ab7c0048fc4b99901cfe4f54732a359db82e441a3846d6b1dc446bbfa53fcfc25bff86da9f459b9c44343fc07de5358fa55e96fcd744f69336cbb7e58053edbf6be5ad305245f2a4e5cd874b063652122000eb239c42f8b28b1804c63a7ac974303abf243b4b248247f43c7fab82e4be3d881051f64f339065e7c359ef11ab02588ac4b0f94f78b70efdb5714be8dd148276124bca44fdbb2282f95bbedd7d577a3f0c78b7475a8c8117447f6f6b3afae8f1ddef4641d7998fef3a4fa4f2c40a8a52003918410985620b0887e6ee9d79672c33f47c40978dbe6612cde16c7caad6af6064804f658cdc",
                    note: "e703097448bf432da672a338b59020678c60e6f530d3485f9be9907e511756d2a75c55fd474645ff8727688218e5d07e122cebbcd4044a48ad56565e74d287773247da5a7a11416b90b41e9c5f7c0dbe47091b34f0c64b1e877c4e7b777b17816d682f8d45a54f318bd716830c03dcc16f0b9eb4eba24c31b9f2991ac8662526fa46ebd9d2e842d3a755f65aff5ee857c1d5bbc08cf34908a88ad7320d65d0d34ae62c22390544eca0182287f7220577afbb7293994d4a9e836afcd2370fdd5d512179f3da63469b9a0e70128082a587696afe4c060d4833812b2344ce630c431464306b70324196b276ecb1732e5be541a412b85bfb42d88361",
                    status: "5cbdc6c53d2843478110823253fe2f92b051446f4785429d90"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("f3d6ff52-7ca6-4c73-811f-cfc09f29fe93"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetCountAsync(
                    companyMainId: Guid.Parse("2d23b220-0bfc-4603-b44a-7204e546dd32"),
                    companyJobId: Guid.Parse("2b99f4b2-22b1-418f-8eb1-79d0703aa488"),
                    orgDept: "e886bb9b4c2c450b97025b08a5ccb6f5a54d550ae0c9425d8c652e737ea77f9cfedb46364bf34de6a331049e1c16b4a1ec9076644b67442090803017e0e323ed4dbaf689d3e34cd69b4afa46d82103cb140d3821c4a14629b4364008de9323dd50ced5e97e6b4ff390cb72ae1d616df07c5ed09221d84d1f86d493210e34d812c1ff9a80f7cc4b3f809c1de19e9d8124f9bf89d1ccc14caab1cb5f80ba8875d2d090d1e0b30c48bfac336e4d85dccff7d57eb6156eff497ba5956dce075e02066a782f4976e347818444b159a21b4a9fb063e6bda5714a09bea8cf896166e79c343ff88b7ff445d0a1ef0ca59d08e6051add25ae501c4cf38d51",
                    orgContactPerson: "96e71715317c4e39b21eaa093fe4878fbae8343a3d6f401b85",
                    orgContactMail: "6a589c19a4894e30bcf377f5f2f32c02baa62af8ffe4476ea2e028a515b83e6b9a18a9d37cfe42d998149f058f8536047e715f3a06714574a44fab2e9c3ba784e0f9d90538f44975a3959c9c5d63950920794f4ab5294b2cbac8cc63202b7f53760bc1a055f14605a3208f270449884a809c09b12962433bbccd032f3bb5b29389716da48c3c42d6a2ef7d2da277199894daec38359d4b7698c578f7c411daf4ab99ae02429b450ba4da32f26b22361d293c3dcaa2ec4b90857ccc12dcdd153ccb973dcde0904f4f8423f5d5cd6e36ed84a92741725d4a93bcc80d6c20cde9aa3f05604201924bca99d725ca634924c02b2e450db48c4a4fb4b0",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "3d75a6037f2742d6bd8deb3b42ff21eddce860c49ccc4ceb84",
                    personally: "37ee50bc4bc74e15aaa8803545ee7cacf922679ca7a54a75a8ccb1c26cb600bb095020f6662f46fa9de4d4667332b0a9285c8e462a54459e9e18c0ac27c6cfcba57fa1d4b821429fa11bb9a03677eca0c2fd14e3e6804b69a3fcd1c265188b004e10c2f1",
                    personallyAddress: "47d889d800614bc4a136d5f4303597ca424c3425f50d45e98a7c16814e8535e3827ef0d6543b481084277c8e2276c6434927832b118a409c949270cd35cc5dc5d5cec682d850414e919abd677dc7eb11eaf0461ef4934ca6a7a6136d96f983660ba344a9",
                    extendedInformation: "e8ecbd2d33484ae9b495312710edddca379db14004b64deeb0ea5c0bf32d1e23221bcf2f819c42a3b10cf318e0c1fc29fba93440dd7c487b9368821e67d33fe929bfad610bfd4c5480dff08d52b1508ea9db7973699c419b8d8604bb6b11578bf516a6417ee4492e9c253198068e0cc523ab6285df7241dcae64b010921c07bcc5226a8b0a4f41a9a792c4fa5e5945bf4f33a9b1978f422aa3ecb7afcdadeeaa2fd7521cc3da4624933f992a909f87e18c7c4e21c6fa4d27b7d0df88c014d5c87c0db2a65cdd4335b81a5332af28d65ca6068d7b2ccd45c7b7b6e691e5d2f258f73de8ee70e546cbb503ee387f71a8c5834066db37244fd09b32",
                    note: "6448c60345dc4fbdbcdb3221b8605304ac680f705fa541699e1f7104331dc8dabe5e7b80a78d43c788f93fb63be1be86b6f644a9a50143bf9d9c66081b9844b2e4c1003736e8489b95316b0737d43c4302c198ba5c9d416e8989b1406afc6708318ce88d9a27495f8544c813f7d558b50e202f312dcf4ac4b478c65d07b490b31a9cbe587cb446aabd1e917428e3902c85605241c83b456e8e7c8f696f759f3e842b5374ef99489095fa2b719f4824fbc9c6ea03514e4997a49b7cd5d9b446e0c0c2647b9238447caf17ca94aba6386bdb20c47333a24b828b1f27aa3e211c376977714ea3cd4a8789ec6a3fb79b79feaa4669870ddf4ba08ffd",
                    status: "800480a658b64866b1d5a8109fb4203dd1f01558883e4f33a4"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}