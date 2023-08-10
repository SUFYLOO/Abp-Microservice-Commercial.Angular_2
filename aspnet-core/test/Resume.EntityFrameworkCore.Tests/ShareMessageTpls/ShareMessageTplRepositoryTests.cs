using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.ShareMessageTpls;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.ShareMessageTpls
{
    public class ShareMessageTplRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IShareMessageTplRepository _shareMessageTplRepository;

        public ShareMessageTplRepositoryTests()
        {
            _shareMessageTplRepository = GetRequiredService<IShareMessageTplRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareMessageTplRepository.GetListAsync(
                    key1: "e095c663baf84e08872ae0f5469c23d950586a1b37e24cbc9b",
                    key2: "3f71bc88911541eaab39585d09ab7de9555085cb36fe4b819b",
                    key3: "cd763808245940ddb1fa45f49a6ed134566e0d4328fe4c64a1",
                    name: "ddf980c6aef44f98b3a1577e042f6b9f5aeea1bd60a54c6188",
                    statement: "af502304237646229406f7b8233618b6501aea4cf89d48d39993934e94601d53f5e6e15cf1144d7290c706b06b8bf97499530d2773984cacab9dbae4934ecb9c10701b87e5d24679a760538b7622f5b6462a2ed7990c4a60ab360184c389d1dba2d98b0f61db4c2cbceb1a508945e01d7fdc150eebc6404c99a4ade96300816ba2f5528b224644c39746cb0235e6f1042687b98d084c4fa6b79f3f77c362df628b9b23643bc740dda7f5fbe722f6ddf6a98d60990a024b7b8a126aa657aa57ba159e11057790434ba46b448b6654f82108a85e98eecc408887df4b8281e363ca61dd466368a5408885f8d4dbc48b0af98eab81cd549d40098445",
                    titleContents: "8096a16af4e1430199c8e2b97b0c715d6dabd6a0b30042bcaf5eac99430afe9c1d7eb2887f8c496e9305fdf6051a7697afcd4410d9914d7d9fc79f275cf09e43f902746bea6c45afa5936e0aa040f5e9f4de6ef89bfa4b53ac7d7f8105675e81a8a41d1cded74d0d8387b6cbc3e5d231375256c3097b47b095e94dfdc04bc7626c154bbc073e4f56881972c250742f389ab5070a4e614d6cb60df43cb966147290dec4126edb4fb8999ce9cc77d529fc40eb8cbf510e4b5ca72455cef8b123960cfbba398a1b449d908b18de9b6c6b490ac39509c9314b3eb76f7cc30396a7d290f20a26cd8d49b9a42c974e8c5af5a5d648880f661f4f0db5c7",
                    contentMail: "eadbe058e0b44463acbc504d2f14fbb2c934082122e54e8f81b",
                    contentSMS: "1ee32fe4ea3c49e79ea1bdef04d0eae10d385411d2de41b9aac348836c0979f57b512e401acd464db2e08fcfed0b96225a5d52070c874e85b54d51c10fc71680f8c35312390244f59650b8ef9a07f0c90be3d41721a6408292d08eddac340aecd018365305994f43804e7e8f853a9f2adfd8819e17284b8a98145f2e7a0a302a84294fc289154a8bb494618683cc2850a6698c212149445f930378e00fb6bb22622ba4684d654db09a4b951d4eab6ca9a972c74fb4574be28110df389249ca6146031895c92c487a8f58e0676dbce73460b0e23219d4454fb709674ff6c456fa8a4ac67ca04747b59ac7adb854a0ec25fc74ea7569de486fbab1",
                    extendedInformation: "644ad6ca62ad450989fdc7ff937b09a00242a22ecd8440688cfd70a8bda2d1f86def0698e96342f382412b3ba7c25a0f5b7744380f21434f94e0bf4520e098b5cfd35a5ed094437fa5ea29eea64fad67128d6e1f33264ca9b8eaf0633bbc7194f791516b0dc1407bb9c474e80ef9917455fcf7fa20f24b05912bb574e01ed7a650fb01c519334cb7812e393fca1be6f111c7864c4f26430fb233da55fa4f48e25a9b2e3569784c3baafe56f02fb33c8365b3e0dceb024ca99b2c6624e85c39da3efbab11542e482db0d36848bc08c972e370145a1e5c424a99adba382fde7b99cc18d001d6af4ce58a6dcc721905ff96922c210c4da44d73b882",
                    note: "50638734bba3435a8992df0f0f5cc2efed7c459127c844bbbfc7316784182c835c3728982c884493913290c55b19749b02d3ad48d72244549d77e65afe5247b694a490dcb0184049a3e7fce00350d6e93d5ede3a4b2840fcbed12dad5464c82d5f397552912d452ca9c7bd3bf52feee8ae7a819a97ed4172bbcad081d6f8acc48bcb0183c67e47fdb462dee76073d91eff91220ef9834b6a889d9cd7cf1702db441321a9500a4d7f9a62278c609c73f8922bc4de4653455ba05918207fd11e6ef210b8f927d941cca6628d31b03ac226a46443b5c49a401b982ecde19fc0d9b4ddbbe812a1f241efad7ee4ae3e415d77fb440177195b45749c76",
                    status: "8a721da6ec9d4a1ea4b1891fb2a322c33c0de4eb18314db784"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("d901234a-a405-447c-8b32-704a6d5e368c"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _shareMessageTplRepository.GetCountAsync(
                    key1: "b6f89bbf6a034c8784f1d36d9cc1561c285c89e18e7c48e08e",
                    key2: "e59e7f12551149b9b70db0f757829acb242e7a82b6ad474da4",
                    key3: "ef23d6c3f2424cab927596dde8f6565ed4a04d11a44f4b52ae",
                    name: "c8ffe359c18f47eba8f6e06a5021ea48e60cf2f10b5243ea94",
                    statement: "b90d16a1fe6a489582b481637b05a087cff5d00ee28c4b92878d0a6bcc13c796da2454048e044133be65dc9be3d72cefb008255f4d7a4708b2dbc259ef655458b54078ff19d440e88e52442785af2a3175ff922085154c5c97578e48e756a89ef1655260ebfb4158a1234654a86dbeaef62fe2d80ab3447c98fc9d53d1c70bb56b009a5e541b46fd9edcbecc644239f3fba7c815e9cb4e47be2d3bab57d0aec1b9df37fe9e3545a0863029eb20ffc47d30b05720b94b4c968f018173fde999bc783fd228926a4a67823b40efaae131f98abe5807c95143ebba580bf7bec3d710b4e504d1005b46bfa6ae42ba6b9a1c5dd24f4bc0b9cf41c8a22d",
                    titleContents: "045f5581fc434c5985a65dbcc13f7c9c084d0482d2414c8eadfcd5733c3b9521c9d3a0e18b62463a80ae2d490e64894fc64f46e460b8434aaf3afcf17a733c01fa552058a45e4217b41e3e24adf220f962869a39b4a5415db9062fe3f14882d53b0db262a35b4567a0576d05c16534030be6b894c0da40e191f8d38da2096c93c36a51aff7224143a4f86c40c37d7894f645746be8b74b4c8909db17382b7b9359f8abdd546444c1bbd467907fa1afcaa1abbbb702e94e059fd3401c2df392664c4e82906071460896b21414ab0e37303ad06447028c422a896978ed942e685d54baf295b5824c328df55fc7204b4acddeda1386f67941579e0b",
                    contentMail: "bbfd858b7eaf42e9b7640e7e048bc7cf3087084abba543f094ae507dcf748960e206c233d1f8",
                    contentSMS: "f6094b2e4a484e43b3cda98e73193c1c88fceb2360b04259a1465f6cbcd019a41d38e02d13b14d109f829e625344dc351bb69fbf952a418ca51affb17c0c0d74f554c602231b4edab8ba2bb391273a9af1b10da7ed044521991c1d7c9038416d17712bb089374f91bbd7bdcbc8d58e517c51a991547b438fafcbd3bc83a94532ec8c1df375c9481bbcf7f454c3b41d99cf0c7e95b8a54fdc80ad0aa881780d3e9619962196c940e6ad00651441ccb7f64f885234e62a48fe9795fb3241835c2bf328239a85db49ee90dc6f1c792ea01eafa7f14964614257945d1eef13b7a73caf52d063cde24b248bb36a45cac9d2d98aae4b5a6722462eabf3",
                    extendedInformation: "ef07f5c378604f40ac4c442bc818ab21d62aa06172504977b66010b590cb78199d9a81af8301415dafb475141b7df3480c218a0f82784435afda7458f6ce633ab5a6cdbae6944ac794ff6894ed0fe11c77cb068e16324655a0ac671243224f15848097d5302e4596bd0a235a304747a12369c6f334aa42a8951e6fa0ad1b43a423a31173fc4b4271acd60fcd6a179378c18a763dec41439d97420e656e85dca73718ea502d46430482c4d604cb3b461b53a6ff70725e4fe79eccc67be3d44e91eb39f4b9e36e41618c11df7eddc3f03862a3e6fd58c5428db1a41ad2218cd765a501a34250994eb59abdc32c79d9fa52dbf31bdb00d2462ea8b1",
                    note: "01d97132c49f438a90aa93c0ca21dc0b286bf17a5c4341edb1bb0bd05f099919176d7be8161245dea285ef9075056ef8ac0166830b0a49629b24de0d9a20fd51753bd642f15e46e08096d17f6d57afad9281a310896e464c8374934fd09bdb982dacb3ccd32d411592e02d83acd24ca760852d1ac574430d96310ea5a7a875ad49ee190ae1a94959b3655e93fb8436bdec9b42319a05407299df27d64281d844e98242ff572b44559151d7a68a6e5fba13be3b8acb56497bbc3125908fcd29c551636b71719348ce8af33ac416c24a5c4dfd0e09436f459c93db90cb6f6ef97343e2e2af62e0459488ed9a5b05fd191b90bd1faa6ecc4509a378",
                    status: "aba22e2b8e7b47d9b39282f99b2e7a6fd108d832bfb048618a"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}