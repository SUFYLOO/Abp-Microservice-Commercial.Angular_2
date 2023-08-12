using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ShareTags
{
    public class ShareTagsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IShareTagsAppService _shareTagsAppService;
        private readonly IRepository<ShareTag, Guid> _shareTagRepository;

        public ShareTagsAppServiceTests()
        {
            _shareTagsAppService = GetRequiredService<IShareTagsAppService>();
            _shareTagRepository = GetRequiredService<IRepository<ShareTag, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _shareTagsAppService.GetListAsync(new GetShareTagsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("3b52c94c-881e-4b69-b542-2c4be493fd57")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _shareTagsAppService.GetAsync(Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ShareTagCreateDto
            {
                ColorCode = "c9627a57117e4967bb794ded6fa92939062064522ab7490e94",
                Key1 = "2ab2b326426d4a15bffdeb5fbfd829e90a4f479530cd43a1ae",
                Key2 = "4adeb3334d8a4efbbc3ef5a5a2dcf9deb49d47ebffd24254ad",
                Key3 = "83341df6a14642329bc50b536dabb595eb276e1cd5564b60a8",
                Name = "80c8e15ed68f469ca28e1138e3002944e4aefdebdead442c9e018bd118265212caedc03f7e8b4a77ac2a568dd1700709960efd7b518a4550a4d9af62e17378b362c67fc378ba464e9919b02cc80a514ad4329e02081b46edb029120e39e971d13e4ae19ffba949159d0fe52db215da10c81d2c1e350c48f88bb98a25507bd895fe852c3e788a46e4b23cf6aa341fbaa776a3507d5d9c4ad4a87cb14fababc4a2465a106a62664cd79c64f873d5f3ed0e70e4d5ad60644ca0ac59a8643b37e62301aeb863e3b746d0ba599c438923aceb45451274c69441139f53f8ff41c287396fad055d7005468582da4e4cd402ab96b00a9f34da0240f584b9",
                TagCategoryCode = "a9579e3233fe4fd0af87c96e68fa755c73cc573350674a388c",
                ExtendedInformation = "41d61ce159034f8c9845895c33b929c7f516dc13d2394cd190f44d2f141ec71189c5dda86fb7438c8dd2e340209c498535e980f58c094a0aae276ce3b4d572da8774b72f066241098249c4613b6fe99b20ccaca8211d482aa7f77656ba4f77077d44b1fc6e2f4339bfbfd7e3e243eee261cb76c5a5484bb1bcdd471509572b123a891d0296214c58885bbb85ea05ba67415c13f436dc4681b6c6e912c64e19545dc2d931690941bf9bba4c519a2bc9ff314c9c8639054933a271dd07a3cfb414098fb40b9fc64bd0a1ee0b286b4085836b6ed75a6fe24417912f32ff7c03bbf1612f72b59dd64a1c86422655c8e7c19680b7b98cb6de44c1913e",
                DateA = new DateTime(2013, 2, 7),
                DateD = new DateTime(2006, 1, 22),
                Sort = 1616257558,
                Note = "ca6681dd9c4a4d119adebef03c0b6447330b3ed516384efdbedbb43e8157d9084719ed7d781146c79877ff8186975030cb72edc19c894e1ca68c649eb83615ad0a3cab4b9d15406cbcf18b77fffc3f266f44cd5b97914ef796adce74f3d92d9ccd2ba557afde4e2daeb1a07ecbfb46ee0caa7a88e3fe4a46b8a87bec1d7487fd51b3e20bca404c57b19b31409404ee94cc2f9b0c5dc94b639804eb3ac7b19629577dfa07cce04d3999939f9e581fe5c12cc4e13f30c64cf4b7327d307979da8012b22065fcf84c7eb5bc72bfac0270b8c093c77b820a44158aa8e505af1032e2bc92684cef8f41fea4b20417b504481889911258ebe44840b6ff",
                Status = "53fb197efe7c461aac0c2bfa6e4a7348cb2ba19d36b848f398"
            };

            // Act
            var serviceResult = await _shareTagsAppService.CreateAsync(input);

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ColorCode.ShouldBe("c9627a57117e4967bb794ded6fa92939062064522ab7490e94");
            result.Key1.ShouldBe("2ab2b326426d4a15bffdeb5fbfd829e90a4f479530cd43a1ae");
            result.Key2.ShouldBe("4adeb3334d8a4efbbc3ef5a5a2dcf9deb49d47ebffd24254ad");
            result.Key3.ShouldBe("83341df6a14642329bc50b536dabb595eb276e1cd5564b60a8");
            result.Name.ShouldBe("80c8e15ed68f469ca28e1138e3002944e4aefdebdead442c9e018bd118265212caedc03f7e8b4a77ac2a568dd1700709960efd7b518a4550a4d9af62e17378b362c67fc378ba464e9919b02cc80a514ad4329e02081b46edb029120e39e971d13e4ae19ffba949159d0fe52db215da10c81d2c1e350c48f88bb98a25507bd895fe852c3e788a46e4b23cf6aa341fbaa776a3507d5d9c4ad4a87cb14fababc4a2465a106a62664cd79c64f873d5f3ed0e70e4d5ad60644ca0ac59a8643b37e62301aeb863e3b746d0ba599c438923aceb45451274c69441139f53f8ff41c287396fad055d7005468582da4e4cd402ab96b00a9f34da0240f584b9");
            result.TagCategoryCode.ShouldBe("a9579e3233fe4fd0af87c96e68fa755c73cc573350674a388c");
            result.ExtendedInformation.ShouldBe("41d61ce159034f8c9845895c33b929c7f516dc13d2394cd190f44d2f141ec71189c5dda86fb7438c8dd2e340209c498535e980f58c094a0aae276ce3b4d572da8774b72f066241098249c4613b6fe99b20ccaca8211d482aa7f77656ba4f77077d44b1fc6e2f4339bfbfd7e3e243eee261cb76c5a5484bb1bcdd471509572b123a891d0296214c58885bbb85ea05ba67415c13f436dc4681b6c6e912c64e19545dc2d931690941bf9bba4c519a2bc9ff314c9c8639054933a271dd07a3cfb414098fb40b9fc64bd0a1ee0b286b4085836b6ed75a6fe24417912f32ff7c03bbf1612f72b59dd64a1c86422655c8e7c19680b7b98cb6de44c1913e");
            result.DateA.ShouldBe(new DateTime(2013, 2, 7));
            result.DateD.ShouldBe(new DateTime(2006, 1, 22));
            result.Sort.ShouldBe(1616257558);
            result.Note.ShouldBe("ca6681dd9c4a4d119adebef03c0b6447330b3ed516384efdbedbb43e8157d9084719ed7d781146c79877ff8186975030cb72edc19c894e1ca68c649eb83615ad0a3cab4b9d15406cbcf18b77fffc3f266f44cd5b97914ef796adce74f3d92d9ccd2ba557afde4e2daeb1a07ecbfb46ee0caa7a88e3fe4a46b8a87bec1d7487fd51b3e20bca404c57b19b31409404ee94cc2f9b0c5dc94b639804eb3ac7b19629577dfa07cce04d3999939f9e581fe5c12cc4e13f30c64cf4b7327d307979da8012b22065fcf84c7eb5bc72bfac0270b8c093c77b820a44158aa8e505af1032e2bc92684cef8f41fea4b20417b504481889911258ebe44840b6ff");
            result.Status.ShouldBe("53fb197efe7c461aac0c2bfa6e4a7348cb2ba19d36b848f398");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ShareTagUpdateDto()
            {
                ColorCode = "19fd4ae47e7c49108e61915873d3cbf249fd9ba690d54a67a9",
                Key1 = "61e6cefe7b7d461eba948b4f62970ab6b9debf178afa49fcbe",
                Key2 = "25e1209a588e4f5aaf32bec93dd61362ca726b677bd7407a99",
                Key3 = "b50d67b6fd244a3e8875041fcc929097a1f0e29e0cfb40cea1",
                Name = "2dda8584d3fb4d4a8f363c4c0a0ce3861e5ef4228b954a40b7a1df8e7e89a327bf2d202ae9044439974acc9de1e870a6dd3f5c3255404c45b3d45d73d0fd2a9a6a239462a09046478505c8dd1d19a38763e6be8257b7493d8582cf1099c1f3381d42fbea95f14f709f6646179a19b3ba27f640d8dafb4192af1a689dcff2459c3f03f7b1daf246df94d7f188d62145d82bef872a9f2e4b6494cdbf9a03f1c0aab44c11ea8eea4c4fa0d73b3071346734545272cc5453466f90e5fd93740c9b73252a7730e8b745c4ac2fa76fdb0109d0b2ce9d87448148238d8c04a3feea2be8ce72fbb79e704ff4818f3d6dbf21ffedc8b8252f768644499538",
                TagCategoryCode = "7b84c2764f224e7c9aeccb3431ae767769c72f072a33497081",
                ExtendedInformation = "f6765cd4eac5488cbfe6844938f856339e207570b8e348b3ac800b1bb200b59ee9ae52f9e30a42108af9d57b560ea73e592d7280388d4c399df569824534f38cf12cdd99c40b48ce8a5392d79b23b5524a53b76bafef45ca8e490bde187d438cc6fecd9ba3d146aba8093ff840c46671f3f8abb11fb942aeaf3b1e1f507ad258d6519dc9e0254c02b8cbc96322280e5433243d93c14f4f70a30c52ab889fe8989a1c4569732843bb8e774205f55f96d54336ee6ddaf44b779d0bc690e9b076a4a62b13383ae74c2c8c89255980b9c8ac6d02dd6ec979457783f4739ec9b3a07a76fdc82dc1c1442fa3669a0066b8b94db29c913a8a074bcb8c44",
                DateA = new DateTime(2009, 5, 10),
                DateD = new DateTime(2003, 10, 11),
                Sort = 247446878,
                Note = "9070bf455a4948619c51a297e9893eeb594a5fb0db174d06a27bff773ea34454be5f4d327efb492c890b6961cd9c6e8db7a785325a7c46db86babbd3a58e2aa2f97d8645ec2c40338eaa8476b13eb554ff630b297f4f49fcbcca42eb7dffcf769de0c273b1e845e39e749009b6a9fb4b69ccb62b37ac4b08a88ca2600f6d790673cb7279747e4fcca263152fe48fb62d5f5ca7a7cda44ab79e6911dd7c09dc12643a1c8e75264b598f0ca4b0c7ad585c491755197cce4c0a8facbfb0155f1cffefb036f703264d5d8eac5ffcc5170c479247c2442e9c4aba9d0c69b7d7d0f8f9366bd5cb4b4146f59bd5096177ab0c8b83e8df19b589453b9f76",
                Status = "95c7d32ab312488cb194ede2e739a641d13067fa72584303bd"
            };

            // Act
            var serviceResult = await _shareTagsAppService.UpdateAsync(Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"), input);

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ColorCode.ShouldBe("19fd4ae47e7c49108e61915873d3cbf249fd9ba690d54a67a9");
            result.Key1.ShouldBe("61e6cefe7b7d461eba948b4f62970ab6b9debf178afa49fcbe");
            result.Key2.ShouldBe("25e1209a588e4f5aaf32bec93dd61362ca726b677bd7407a99");
            result.Key3.ShouldBe("b50d67b6fd244a3e8875041fcc929097a1f0e29e0cfb40cea1");
            result.Name.ShouldBe("2dda8584d3fb4d4a8f363c4c0a0ce3861e5ef4228b954a40b7a1df8e7e89a327bf2d202ae9044439974acc9de1e870a6dd3f5c3255404c45b3d45d73d0fd2a9a6a239462a09046478505c8dd1d19a38763e6be8257b7493d8582cf1099c1f3381d42fbea95f14f709f6646179a19b3ba27f640d8dafb4192af1a689dcff2459c3f03f7b1daf246df94d7f188d62145d82bef872a9f2e4b6494cdbf9a03f1c0aab44c11ea8eea4c4fa0d73b3071346734545272cc5453466f90e5fd93740c9b73252a7730e8b745c4ac2fa76fdb0109d0b2ce9d87448148238d8c04a3feea2be8ce72fbb79e704ff4818f3d6dbf21ffedc8b8252f768644499538");
            result.TagCategoryCode.ShouldBe("7b84c2764f224e7c9aeccb3431ae767769c72f072a33497081");
            result.ExtendedInformation.ShouldBe("f6765cd4eac5488cbfe6844938f856339e207570b8e348b3ac800b1bb200b59ee9ae52f9e30a42108af9d57b560ea73e592d7280388d4c399df569824534f38cf12cdd99c40b48ce8a5392d79b23b5524a53b76bafef45ca8e490bde187d438cc6fecd9ba3d146aba8093ff840c46671f3f8abb11fb942aeaf3b1e1f507ad258d6519dc9e0254c02b8cbc96322280e5433243d93c14f4f70a30c52ab889fe8989a1c4569732843bb8e774205f55f96d54336ee6ddaf44b779d0bc690e9b076a4a62b13383ae74c2c8c89255980b9c8ac6d02dd6ec979457783f4739ec9b3a07a76fdc82dc1c1442fa3669a0066b8b94db29c913a8a074bcb8c44");
            result.DateA.ShouldBe(new DateTime(2009, 5, 10));
            result.DateD.ShouldBe(new DateTime(2003, 10, 11));
            result.Sort.ShouldBe(247446878);
            result.Note.ShouldBe("9070bf455a4948619c51a297e9893eeb594a5fb0db174d06a27bff773ea34454be5f4d327efb492c890b6961cd9c6e8db7a785325a7c46db86babbd3a58e2aa2f97d8645ec2c40338eaa8476b13eb554ff630b297f4f49fcbcca42eb7dffcf769de0c273b1e845e39e749009b6a9fb4b69ccb62b37ac4b08a88ca2600f6d790673cb7279747e4fcca263152fe48fb62d5f5ca7a7cda44ab79e6911dd7c09dc12643a1c8e75264b598f0ca4b0c7ad585c491755197cce4c0a8facbfb0155f1cffefb036f703264d5d8eac5ffcc5170c479247c2442e9c4aba9d0c69b7d7d0f8f9366bd5cb4b4146f59bd5096177ab0c8b83e8df19b589453b9f76");
            result.Status.ShouldBe("95c7d32ab312488cb194ede2e739a641d13067fa72584303bd");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _shareTagsAppService.DeleteAsync(Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"));

            // Assert
            var result = await _shareTagRepository.FindAsync(c => c.Id == Guid.Parse("acc48ed4-aaf9-45f4-8b0b-925c68da7bee"));

            result.ShouldBeNull();
        }
    }
}