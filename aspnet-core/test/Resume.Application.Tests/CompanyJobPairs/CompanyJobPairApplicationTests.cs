using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobPairs
{
    public class CompanyJobPairsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobPairsAppService _companyJobPairsAppService;
        private readonly IRepository<CompanyJobPair, Guid> _companyJobPairRepository;

        public CompanyJobPairsAppServiceTests()
        {
            _companyJobPairsAppService = GetRequiredService<ICompanyJobPairsAppService>();
            _companyJobPairRepository = GetRequiredService<IRepository<CompanyJobPair, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetListAsync(new GetCompanyJobPairsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("d4d4ecaf-34a8-485f-99a0-42c5686fca66")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobPairsAppService.GetAsync(Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobPairCreateDto
            {
                CompanyMainId = Guid.Parse("8cc3da4e-afd8-4401-ac61-1d15f5a81a29"),
                Name = "e896ef7811da408fa581c5b5a4116f885c4dc44b97d04e83ae",
                PairCondition = "efc8f0e6100041e3a7f26bfa45481995675d0c34212b404497c69250d4f96c7f3d43770712ac4baa889d7476af9e73b78ffed992f4874c8e8b3e883fc3ecf272523f64c1fe9e40c3a40e594e0a24ac1ebb550c3fb2ee4fa4be82b60dace34683bac43a809ab74819be3d4139fc63997027c9d1540a9c4744ae9cfdf9eca5551a7c80ae1663c14e6a97d4c374226a7ac7abcfcd7bdb81434abe166b5190be4e0e6b31f97c02de49dfbd16f5900a48d7d5cc1c3b07be3d47f09e4f73d1dc97af8a5932db1f4b174b0fa72bc83aa632c28817186ee9bbeb444ab102ddd8ff0e4e38ee5e2ae601a14d1bbb618d623d1ea3933582b547378b4542bc8d",
                ExtendedInformation = "d0da867982b349c4bd024efc52dff974da91bbf8d51649ee853dfba0dc781a892e72649c05c840f2bbafb2dd1e7d0ddedee793a47f6e411a9a77d8c45bb21b954586c978c87d4662aefffddb44444c8015556fff17344e8993ee4fe53205c29a50636b4446514a07a776a295402c87d7eb2e55557b0749a894ec292671c154b2a9b62f046eba4f9b96d57ce8a941544dc7ab5bc90c7442138f4416aa43ad77ebc81d17fa5a354b87bfd18679086e95f53b5ce5a4ac664dc684b30f2d24564094071d59b62987482f878e76d177a7b359752fdbe83c154163a12d405001627b66f2d251f7b0a848799b237d911645d4d54c00456268e54bb8ad6f",
                DateA = new DateTime(2021, 9, 14),
                DateD = new DateTime(2017, 3, 23),
                Sort = 86372399,
                Note = "3880ca2b255143609b3c8087723136b589fd220288e44f5aa9a34307d74b7525f3c0ab6119004d968c3852dee6d612dc8c76d2ffe35f4726b21b5695c8de8d2fa889a38f4d2143cdb349b9da81424c97e31ff4452d1a4225aa7c6ee05ed2ce1d955a546208e04286be83d1aaefd147e61f8890f7a59f4342b978d559ea1e34045777bde3e5dd41358c1ebdb29d94dd69f787e7f2e08b4d619b2ccaf63ce0bc51568de80c963d45938c9aebfa5669fd2408fdf1eec2214f2cb91420faf8408839e4dbe24b4b5f42eebe3518bfe29a95d2e4f6df000b6742fb87aeb11db3f950b6053c02243305422493a0cf6351f2b95410bb9a60bc454794adb1",
                Status = "5ddde3ae8fa84b8f9f767ad08d42392898239bed7388400091"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("8cc3da4e-afd8-4401-ac61-1d15f5a81a29"));
            result.Name.ShouldBe("e896ef7811da408fa581c5b5a4116f885c4dc44b97d04e83ae");
            result.PairCondition.ShouldBe("efc8f0e6100041e3a7f26bfa45481995675d0c34212b404497c69250d4f96c7f3d43770712ac4baa889d7476af9e73b78ffed992f4874c8e8b3e883fc3ecf272523f64c1fe9e40c3a40e594e0a24ac1ebb550c3fb2ee4fa4be82b60dace34683bac43a809ab74819be3d4139fc63997027c9d1540a9c4744ae9cfdf9eca5551a7c80ae1663c14e6a97d4c374226a7ac7abcfcd7bdb81434abe166b5190be4e0e6b31f97c02de49dfbd16f5900a48d7d5cc1c3b07be3d47f09e4f73d1dc97af8a5932db1f4b174b0fa72bc83aa632c28817186ee9bbeb444ab102ddd8ff0e4e38ee5e2ae601a14d1bbb618d623d1ea3933582b547378b4542bc8d");
            result.ExtendedInformation.ShouldBe("d0da867982b349c4bd024efc52dff974da91bbf8d51649ee853dfba0dc781a892e72649c05c840f2bbafb2dd1e7d0ddedee793a47f6e411a9a77d8c45bb21b954586c978c87d4662aefffddb44444c8015556fff17344e8993ee4fe53205c29a50636b4446514a07a776a295402c87d7eb2e55557b0749a894ec292671c154b2a9b62f046eba4f9b96d57ce8a941544dc7ab5bc90c7442138f4416aa43ad77ebc81d17fa5a354b87bfd18679086e95f53b5ce5a4ac664dc684b30f2d24564094071d59b62987482f878e76d177a7b359752fdbe83c154163a12d405001627b66f2d251f7b0a848799b237d911645d4d54c00456268e54bb8ad6f");
            result.DateA.ShouldBe(new DateTime(2021, 9, 14));
            result.DateD.ShouldBe(new DateTime(2017, 3, 23));
            result.Sort.ShouldBe(86372399);
            result.Note.ShouldBe("3880ca2b255143609b3c8087723136b589fd220288e44f5aa9a34307d74b7525f3c0ab6119004d968c3852dee6d612dc8c76d2ffe35f4726b21b5695c8de8d2fa889a38f4d2143cdb349b9da81424c97e31ff4452d1a4225aa7c6ee05ed2ce1d955a546208e04286be83d1aaefd147e61f8890f7a59f4342b978d559ea1e34045777bde3e5dd41358c1ebdb29d94dd69f787e7f2e08b4d619b2ccaf63ce0bc51568de80c963d45938c9aebfa5669fd2408fdf1eec2214f2cb91420faf8408839e4dbe24b4b5f42eebe3518bfe29a95d2e4f6df000b6742fb87aeb11db3f950b6053c02243305422493a0cf6351f2b95410bb9a60bc454794adb1");
            result.Status.ShouldBe("5ddde3ae8fa84b8f9f767ad08d42392898239bed7388400091");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobPairUpdateDto()
            {
                CompanyMainId = Guid.Parse("12d3d23f-c6b4-46ac-aff7-a5fec6c95652"),
                Name = "2697e80363664b418b64bbef511e6fe7bca85285b6124da9ad",
                PairCondition = "834eab8d10b04b80b157e91ea4223ffdd2ec2d20f67a4a20bc4ba4d35b20b419726a6cccc5c249b7bc674922b18854ff12b385577dbb41b7b1ae6aa4ea882afbb6b510d03775497d82b225e3eea290d425a7459117e64cb1a55e67230b42305a7c48246b1f8747bb949c1ac5ffdb73569078b05bf3ea4d0e9a6896d99d8a7c09fc82ed0f8541487086921305e293f607a527e56e414a490d830fd6a6b6a2fe90ca7cc24208c44b74a101418a992e7064f38598d3f08a4c409ae26e36b0d8d94dad41a44622224487a63b8332d9abb6d6fa1c206319d64a55b1e5a2c1d82b59e19942e59dc99a4ce8a7010e146fb2bedc7dd430227f854fa686c6",
                ExtendedInformation = "69c3c3d02f5a4e029b2748f3e1ff3f3ba57fca6d934849d99aea360c6d3f1fde9ab829f4099f4937af18c6fac1c7319c29d481eae6e5446e946abbaa0498a284b5e335fc663240b2998d87d90d07052bf0881bbdd5a7410eb7dbbd28227cf9ab334d1f69dc9d4c6c9f78e52ec999085c5c9e94d841664d19878a64f24ece204d711a9c833b0c4db6b2bcf703f51d5ce01a01c770e1924839be4eb306cf01a4053a7a18740d1442f4be640c8b7d101f00dfdc2ecec2a0482b92095fe84b1fc742b22cf64b47884bb5b0886038f0dd6ed7e9869b99abaa4f939c3d0ca0e4be11544f36dbe249c745949873185de0141aa3d9c62f398b554f208c81",
                DateA = new DateTime(2005, 3, 19),
                DateD = new DateTime(2012, 7, 10),
                Sort = 2021374906,
                Note = "0f19978aacd64dffa7579228d232c44bf51dca8161414856ba2e751202c6d30f458bf8133fcf4e85b9f47a0b0ec391d4858ffa43351244d7bd58083271a0e390e039669098284b9a861196531b9aac1d679bc65272ef42c0a8bccca69220653fbc799bdbd3b84ead941f1d345d7336f678b9640f24274472afe74f343d91d6537f3ff8106a2848edb6d62569ccbe453e7f60cc3928ab4c6c908a698c71694974623d65dd24a64eb2b09c91008cecce14bb26013404174d04a6bf14dab3b8ac0bbd8c9f56e2b843ab9273b8777fe03a57ff8572b0311441e692835f8022235f9f0ba58d558ca741cd98e63a4734c5f621b5f0ed0868724f1ba55c",
                Status = "79f1975af40a4c9bae276d4095dab8b8ccc9ea25052f4e73a7"
            };

            // Act
            var serviceResult = await _companyJobPairsAppService.UpdateAsync(Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"), input);

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("12d3d23f-c6b4-46ac-aff7-a5fec6c95652"));
            result.Name.ShouldBe("2697e80363664b418b64bbef511e6fe7bca85285b6124da9ad");
            result.PairCondition.ShouldBe("834eab8d10b04b80b157e91ea4223ffdd2ec2d20f67a4a20bc4ba4d35b20b419726a6cccc5c249b7bc674922b18854ff12b385577dbb41b7b1ae6aa4ea882afbb6b510d03775497d82b225e3eea290d425a7459117e64cb1a55e67230b42305a7c48246b1f8747bb949c1ac5ffdb73569078b05bf3ea4d0e9a6896d99d8a7c09fc82ed0f8541487086921305e293f607a527e56e414a490d830fd6a6b6a2fe90ca7cc24208c44b74a101418a992e7064f38598d3f08a4c409ae26e36b0d8d94dad41a44622224487a63b8332d9abb6d6fa1c206319d64a55b1e5a2c1d82b59e19942e59dc99a4ce8a7010e146fb2bedc7dd430227f854fa686c6");
            result.ExtendedInformation.ShouldBe("69c3c3d02f5a4e029b2748f3e1ff3f3ba57fca6d934849d99aea360c6d3f1fde9ab829f4099f4937af18c6fac1c7319c29d481eae6e5446e946abbaa0498a284b5e335fc663240b2998d87d90d07052bf0881bbdd5a7410eb7dbbd28227cf9ab334d1f69dc9d4c6c9f78e52ec999085c5c9e94d841664d19878a64f24ece204d711a9c833b0c4db6b2bcf703f51d5ce01a01c770e1924839be4eb306cf01a4053a7a18740d1442f4be640c8b7d101f00dfdc2ecec2a0482b92095fe84b1fc742b22cf64b47884bb5b0886038f0dd6ed7e9869b99abaa4f939c3d0ca0e4be11544f36dbe249c745949873185de0141aa3d9c62f398b554f208c81");
            result.DateA.ShouldBe(new DateTime(2005, 3, 19));
            result.DateD.ShouldBe(new DateTime(2012, 7, 10));
            result.Sort.ShouldBe(2021374906);
            result.Note.ShouldBe("0f19978aacd64dffa7579228d232c44bf51dca8161414856ba2e751202c6d30f458bf8133fcf4e85b9f47a0b0ec391d4858ffa43351244d7bd58083271a0e390e039669098284b9a861196531b9aac1d679bc65272ef42c0a8bccca69220653fbc799bdbd3b84ead941f1d345d7336f678b9640f24274472afe74f343d91d6537f3ff8106a2848edb6d62569ccbe453e7f60cc3928ab4c6c908a698c71694974623d65dd24a64eb2b09c91008cecce14bb26013404174d04a6bf14dab3b8ac0bbd8c9f56e2b843ab9273b8777fe03a57ff8572b0311441e692835f8022235f9f0ba58d558ca741cd98e63a4734c5f621b5f0ed0868724f1ba55c");
            result.Status.ShouldBe("79f1975af40a4c9bae276d4095dab8b8ccc9ea25052f4e73a7");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobPairsAppService.DeleteAsync(Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"));

            // Assert
            var result = await _companyJobPairRepository.FindAsync(c => c.Id == Guid.Parse("a96606fe-32e0-4f05-a89c-ad449d8d27dd"));

            result.ShouldBeNull();
        }
    }
}