using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeExperiencess
{
    public class ResumeExperiencessAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeExperiencessAppService _resumeExperiencessAppService;
        private readonly IRepository<ResumeExperiences, Guid> _resumeExperiencesRepository;

        public ResumeExperiencessAppServiceTests()
        {
            _resumeExperiencessAppService = GetRequiredService<IResumeExperiencessAppService>();
            _resumeExperiencesRepository = GetRequiredService<IRepository<ResumeExperiences, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetListAsync(new GetResumeExperiencessInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("010c82aa-6d7a-406f-b088-b7b8099b79f8")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeExperiencessAppService.GetAsync(Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesCreateDto
            {
                ResumeMainId = Guid.Parse("b268fd90-0584-4b96-89a5-bbc18661bb19"),
                Name = "54b9656e28a1410eba32104ea9adba420cc78de77fe04b9695",
                WorkNatureCode = "dc8404a87dca436db48249900213c63448e84c4a1df841018d",
                HideCompanyName = true,
                IndustryCategoryCode = "7031dcba10ef459ca6a95fbe3420270eb78077b3590348ec91a5e7d9a74498a43594d77634da468396b509e73e926e10e2117031ab8b4c889634bd6dfe92a795ed065a7a3e1f4351ba774e091e30999a39f80000b4b44e36ac649d72db6cd7b907d9f06c585546c2bda3f3d3338d950883be4a5e03e14d0ca7c858a50bc2b7f3e89a977f3a2241a2968d2a4f28224cbd1a7b43d4035c4336a66cee8a7c451fc3c7d5bcaa14904dd18e9c5b460b7c23d8f897a96af87341eaa28257f035b924b4299f8ce226364e13a3a6b77f766cb0eda3ea9375458a4f7490fae42e63e3f671401ad1b607864035b09d4ba463503c172f62faa4d7764fb59cc8",
                JobName = "7b0527d96f4e46f8b5921bb6518a863fb330c65e1180448290",
                JobType = "1617dc922b6344caaa115d3a8066687aa88d196835e94cd599f3fa46636252569d5c6152e51c44839ce29c93224e5b478f7c3963830f4bab8ac09bd0b055d37eeec20d58451440bca741ded49cad6d1d2f91ff765cb74f31b3d03f33f76d5e1fbb25099f973743009394573fb9c26f3df6c1d5a445064f389900fc9c76ab25307f893ed2b74041faa6db69a325a2a603d17ec12965d94fa680129016d5caef3d6607f69213e6469aafd8756e3f9ca03de3b8e48190a5490a81338841087d439f0eba5e2cd43a47fc9cf74cbf63d4d2ff110a15b2bcb94f41ad9b3ab94cff7367e1373f6637dd437fae34f704830add1d9222366a7f9d46559bfe",
                Working = true,
                WorkPlaceCode = "3b62cf8a14ca4a3e80cccb04e94e99d19cdde0fc39d9403183fb526b80f25f65abd4af24c7e44da4bc25e0e072e94cdad489a91dbb1145b1a5e9fd2f25083e8e73228a89198142c4ac40541d0437e04293df93cbd9054708b8628eb4f4e7c1afb84a716af81f4d8d9df100d956f10b5c470b9960229d45cea3c45e88bc878579161725a95737480c9c7d641ef2f891e1f1c5ef172a7b4fb0a3d03bc9dfdef53ef9238f4df0ec460981d2e686939387ba32cbf0975253416e98ca3d00d458ed3d94e8a07f0c1045759fec7a390deb7ab57698669b856e47acbb3f14b82658dd2b831ada708ee14b54999e22bcdbc92004b2faa9b21c9a4dd88ccb",
                HideWorkSalary = true,
                SalaryPayTypeCode = "2ca35f8434794e04ac1eb6d06debd0feb60993f90fdc426c83",
                CurrencyTypeCode = "a69135765d03425da13fdbf4cf9bb7d9bf7dfe2858954d0cb1",
                Salary1 = 39602732,
                Salary2 = 307720032,
                CompanyScaleCode = "43b76b704c6144e3a606a4b3d5c16ce65f713d2d427444bbaa",
                CompanyManagementNumberCode = "f51657536dbd47528a3d2f76ddde2f94aa7cdd7ff692491192",
                ExtendedInformation = "5b52e1ccff8a4f7bb81e10c62bc325451d29529f99f74d0a831a261777130a7063463094ca4e40e2a869629dd00b675541bacff4df7e4a37b3615a88e3fb15d4ba32cecd5c1d4cc8afcb9ce9d662bbaa5022ff4a84a942cebcc665a0e4fea6e28b8850ec3f5f4ed487f40ea49aa8603b7a2ade5087a14e64b7ce9327d27ae3b5ac380742ae8d4112acc49b0d2f06b49d7493d6af3a2242c09fc177e1ac4d1d2f1e6ce62838a2482994ee4a201940465ff83e354a52ce4ed4a939f5226565b32d2f5adbce9e044ffd9c86c5fda3f794aaf66d8b4b25384f5dab2c8d7e4343506221ed51393b1d4071abe88b147c7b6cf6ee59bf84114e46f1ab7f",
                DateA = new DateTime(2019, 6, 18),
                DateD = new DateTime(2012, 5, 9),
                Sort = 2137990051,
                Note = "a0e543c6233c478db645816d5b569463aca2edab5d854e7383d5dc098d765c469161d777247e43d49699511cfcfcad3f0b718ef842e941939b17f014eb716fbec75a518083c34dfab5f2282894bd8e2f1372792c2b9f4d2a842f9ce9585faf1af0898b47caeb4af0a5827097378bf2eeb2e03ca0b475425babb9b4c054b968b889e300287b724dc784cfad6722a1c7c3804a03e699634f9da0c4448cc9ed7bbe76294603c7824ba69f7f0d50d4f8e1b6956d08d36f014c96a59d8c9ec96198e6a5ac32d7663d40d798e173a52285fac11e4a0afa0ec14994aec8629a555f4735686a2266fcc34bdcb36859dc4a1a77b3daba5c2b638f42f79b96",
                Status = "266a96a4853748a889b7317b758b93d8b7564ebc17cb48508a"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.CreateAsync(input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("b268fd90-0584-4b96-89a5-bbc18661bb19"));
            result.Name.ShouldBe("54b9656e28a1410eba32104ea9adba420cc78de77fe04b9695");
            result.WorkNatureCode.ShouldBe("dc8404a87dca436db48249900213c63448e84c4a1df841018d");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategoryCode.ShouldBe("7031dcba10ef459ca6a95fbe3420270eb78077b3590348ec91a5e7d9a74498a43594d77634da468396b509e73e926e10e2117031ab8b4c889634bd6dfe92a795ed065a7a3e1f4351ba774e091e30999a39f80000b4b44e36ac649d72db6cd7b907d9f06c585546c2bda3f3d3338d950883be4a5e03e14d0ca7c858a50bc2b7f3e89a977f3a2241a2968d2a4f28224cbd1a7b43d4035c4336a66cee8a7c451fc3c7d5bcaa14904dd18e9c5b460b7c23d8f897a96af87341eaa28257f035b924b4299f8ce226364e13a3a6b77f766cb0eda3ea9375458a4f7490fae42e63e3f671401ad1b607864035b09d4ba463503c172f62faa4d7764fb59cc8");
            result.JobName.ShouldBe("7b0527d96f4e46f8b5921bb6518a863fb330c65e1180448290");
            result.JobType.ShouldBe("1617dc922b6344caaa115d3a8066687aa88d196835e94cd599f3fa46636252569d5c6152e51c44839ce29c93224e5b478f7c3963830f4bab8ac09bd0b055d37eeec20d58451440bca741ded49cad6d1d2f91ff765cb74f31b3d03f33f76d5e1fbb25099f973743009394573fb9c26f3df6c1d5a445064f389900fc9c76ab25307f893ed2b74041faa6db69a325a2a603d17ec12965d94fa680129016d5caef3d6607f69213e6469aafd8756e3f9ca03de3b8e48190a5490a81338841087d439f0eba5e2cd43a47fc9cf74cbf63d4d2ff110a15b2bcb94f41ad9b3ab94cff7367e1373f6637dd437fae34f704830add1d9222366a7f9d46559bfe");
            result.Working.ShouldBe(true);
            result.WorkPlaceCode.ShouldBe("3b62cf8a14ca4a3e80cccb04e94e99d19cdde0fc39d9403183fb526b80f25f65abd4af24c7e44da4bc25e0e072e94cdad489a91dbb1145b1a5e9fd2f25083e8e73228a89198142c4ac40541d0437e04293df93cbd9054708b8628eb4f4e7c1afb84a716af81f4d8d9df100d956f10b5c470b9960229d45cea3c45e88bc878579161725a95737480c9c7d641ef2f891e1f1c5ef172a7b4fb0a3d03bc9dfdef53ef9238f4df0ec460981d2e686939387ba32cbf0975253416e98ca3d00d458ed3d94e8a07f0c1045759fec7a390deb7ab57698669b856e47acbb3f14b82658dd2b831ada708ee14b54999e22bcdbc92004b2faa9b21c9a4dd88ccb");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("2ca35f8434794e04ac1eb6d06debd0feb60993f90fdc426c83");
            result.CurrencyTypeCode.ShouldBe("a69135765d03425da13fdbf4cf9bb7d9bf7dfe2858954d0cb1");
            result.Salary1.ShouldBe(39602732);
            result.Salary2.ShouldBe(307720032);
            result.CompanyScaleCode.ShouldBe("43b76b704c6144e3a606a4b3d5c16ce65f713d2d427444bbaa");
            result.CompanyManagementNumberCode.ShouldBe("f51657536dbd47528a3d2f76ddde2f94aa7cdd7ff692491192");
            result.ExtendedInformation.ShouldBe("5b52e1ccff8a4f7bb81e10c62bc325451d29529f99f74d0a831a261777130a7063463094ca4e40e2a869629dd00b675541bacff4df7e4a37b3615a88e3fb15d4ba32cecd5c1d4cc8afcb9ce9d662bbaa5022ff4a84a942cebcc665a0e4fea6e28b8850ec3f5f4ed487f40ea49aa8603b7a2ade5087a14e64b7ce9327d27ae3b5ac380742ae8d4112acc49b0d2f06b49d7493d6af3a2242c09fc177e1ac4d1d2f1e6ce62838a2482994ee4a201940465ff83e354a52ce4ed4a939f5226565b32d2f5adbce9e044ffd9c86c5fda3f794aaf66d8b4b25384f5dab2c8d7e4343506221ed51393b1d4071abe88b147c7b6cf6ee59bf84114e46f1ab7f");
            result.DateA.ShouldBe(new DateTime(2019, 6, 18));
            result.DateD.ShouldBe(new DateTime(2012, 5, 9));
            result.Sort.ShouldBe(2137990051);
            result.Note.ShouldBe("a0e543c6233c478db645816d5b569463aca2edab5d854e7383d5dc098d765c469161d777247e43d49699511cfcfcad3f0b718ef842e941939b17f014eb716fbec75a518083c34dfab5f2282894bd8e2f1372792c2b9f4d2a842f9ce9585faf1af0898b47caeb4af0a5827097378bf2eeb2e03ca0b475425babb9b4c054b968b889e300287b724dc784cfad6722a1c7c3804a03e699634f9da0c4448cc9ed7bbe76294603c7824ba69f7f0d50d4f8e1b6956d08d36f014c96a59d8c9ec96198e6a5ac32d7663d40d798e173a52285fac11e4a0afa0ec14994aec8629a555f4735686a2266fcc34bdcb36859dc4a1a77b3daba5c2b638f42f79b96");
            result.Status.ShouldBe("266a96a4853748a889b7317b758b93d8b7564ebc17cb48508a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeExperiencesUpdateDto()
            {
                ResumeMainId = Guid.Parse("d1cda4ac-411b-42a3-9d33-cc6914fd1781"),
                Name = "2bdb8767dc6543bf939367602aa3704b1866a05d21ce41a09d",
                WorkNatureCode = "1b3d2db8ad08486eae8dbca9c99cae7f39f82a610d8f4512a0",
                HideCompanyName = true,
                IndustryCategoryCode = "ea8a6bae825c45f0883fdf7af7c898beba164e78c2224e819c2a7ac6344f8dfc92602f9c166842e888ede7cf2e1c5d00f0956a28404d4202b34ea8a73118e3bbea6cc19f77ed4a5584b9f21eb64ab9b3bd60141d25394d769532f38aa6c0086fc2bd811496e74b02a6c9a8605f1eabf5917bb57a86794153baafd3902cb8b07e53bd8eb6e3a64bd88e9367e4a91f2bce77fa52d5c69f4e198b7118087037ab2c6002d00458f14ff5a43119b5521b5d23d3bacaf54be94c43b0ec9210d12f5883ba88432faeaa4ab48dd9f118909cd954dcec611309374646a7bda03ea9a06628f499e767816a45aca2e9b5fe0d791bfd7b3a0fd4149c4cb0aa3f",
                JobName = "4ee299d56b624143b9613d8a8e63c5780288097b87c84d53b3",
                JobType = "f7948baaa2194124a6a4f09861a7862430ee5e72417647aebfc7273304f78a9bb28f7bf9dfcf4535a4ba634e05748a75ebde1816dd63494f880d5bb048576b1d72c67a8f70df4204be34eb9aeb99e98d01f17b50ac49475fb62df22749cc6e83dc3beea81fb94975abc2a71b065263b4009c10f29a4148c096a8b892bf718e97f27a3705e29e4ff0adf3f2e069a710c5054bf5e40c1a4a2f855628e181dd4b414c1523a3ea674e368c559ce9a3d6da8e93725cffe06747ca9f696a8a3fcb41f83305a34d6fc1416fb71cbbc289691321b62ab1f6661c40429df26a900d2c43bdb8a6eed6699c411e8b0a6f3e439eb0e6142a3a2b5e9c44509ca5",
                Working = true,
                WorkPlaceCode = "434b1d4b215b40c9af8ad04b41f7d7fd9deb8d38f7c148caac0cdd101bfa6d6be0fb0bf131304be783245a57adeb8220981d467613674af1bdf433f11bf1c7fd45909a91902c492682859ed4417142f978c1ee3c5727470aa2e19290e27d8a2b648baeb6d338419282fbe05cbb805ef26c26b543462748a2a3de59c25b2da0f1497cea87b70e47c3b6cb61e82e63b62bc3ecf4599a664a8db8896468a8016845b16d527badff421687b6aa69d3c020bf50436222722e41e7867a3402239836c24735faeb74c4491184d67abc045427a397c7755ed57b4d90837a3af2471282ad5af03281d5a04f81a7ffb0aa48c007a243cbc7d6e8c5489dae0b",
                HideWorkSalary = true,
                SalaryPayTypeCode = "a0cdfaf54cba48f7a8e79a3bfb9942140d57db46089245be85",
                CurrencyTypeCode = "05aa6a56fa6a44cf8512facbe0533404200b4f55f51e4b5b9f",
                Salary1 = 1688839673,
                Salary2 = 1804895026,
                CompanyScaleCode = "f3dbfb9fdd9e4c3baeee523794140c9fcaa551ca590e40b4bf",
                CompanyManagementNumberCode = "2d63f516733e455aaabed295eeb55d6fb7b9306ae00c496997",
                ExtendedInformation = "bbb17d909fde4546b4b8060de952b3dedadf96c8d0d74afc8bd01fd5356cedb8e657065f505e4576aaeab0874ad9c047bd962a6d0ad04f33a8c056a948b660f6294a12a0bd964e84ac8cfcaea6838e7b30347af342ee425a8621981ea5b1b45947d4275ccbc34e0181feeaece04d2b2c34762d1a8d444c3f9b7a48692c1e40962a901638f0f6446cb2cddf184232a02d05c550e350324198a80b88774461a4f3b0f8190bc41b4cbb89b840f39f4d913a2055eaed461c4e25a68316bf66dc6df0e69d1a99063c4403b0c597dfc5bda2eca8a5650a585245fd8131356a886eba52301389a7cc714c20adb7aca3bb60425fc8f49ee379234b539c4d",
                DateA = new DateTime(2002, 6, 23),
                DateD = new DateTime(2020, 8, 18),
                Sort = 1777952870,
                Note = "df3075b67c564780a7dfaafc943d6e5c9c056fde453043eeb459e2ab9649a2ce5496a1be601949959c1a087f7db3e6ef1cc7d9db79d247ef854c48924a130d66c88ff18114b649d2ba5bd3eaa9154af42851ced0f5fc4ad5958da92dcd65dca2c1899cc7d3fa488b85080351486cb0a9324d3e9421734e46af6f0e1dd2edecaf3302e89244444cd587035c4016aba4932e346aa18bb242b9bdeb77411fcb6a822dc95485afc544fbb49e9dd1a49ca1a2e97d175ea4d94190b17472dcb0bce6bcfd0408ba94c140e0934e341ce8be74ca227fb5b973044d68a5fb6e27e86281b9acb6dd8ae46b41918c362374a62ec5d5201a4a79023d44a295c0",
                Status = "096ae67a01034b7895bd0fd03afd61cb359218c96b7a41a785"
            };

            // Act
            var serviceResult = await _resumeExperiencessAppService.UpdateAsync(Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"), input);

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("d1cda4ac-411b-42a3-9d33-cc6914fd1781"));
            result.Name.ShouldBe("2bdb8767dc6543bf939367602aa3704b1866a05d21ce41a09d");
            result.WorkNatureCode.ShouldBe("1b3d2db8ad08486eae8dbca9c99cae7f39f82a610d8f4512a0");
            result.HideCompanyName.ShouldBe(true);
            result.IndustryCategoryCode.ShouldBe("ea8a6bae825c45f0883fdf7af7c898beba164e78c2224e819c2a7ac6344f8dfc92602f9c166842e888ede7cf2e1c5d00f0956a28404d4202b34ea8a73118e3bbea6cc19f77ed4a5584b9f21eb64ab9b3bd60141d25394d769532f38aa6c0086fc2bd811496e74b02a6c9a8605f1eabf5917bb57a86794153baafd3902cb8b07e53bd8eb6e3a64bd88e9367e4a91f2bce77fa52d5c69f4e198b7118087037ab2c6002d00458f14ff5a43119b5521b5d23d3bacaf54be94c43b0ec9210d12f5883ba88432faeaa4ab48dd9f118909cd954dcec611309374646a7bda03ea9a06628f499e767816a45aca2e9b5fe0d791bfd7b3a0fd4149c4cb0aa3f");
            result.JobName.ShouldBe("4ee299d56b624143b9613d8a8e63c5780288097b87c84d53b3");
            result.JobType.ShouldBe("f7948baaa2194124a6a4f09861a7862430ee5e72417647aebfc7273304f78a9bb28f7bf9dfcf4535a4ba634e05748a75ebde1816dd63494f880d5bb048576b1d72c67a8f70df4204be34eb9aeb99e98d01f17b50ac49475fb62df22749cc6e83dc3beea81fb94975abc2a71b065263b4009c10f29a4148c096a8b892bf718e97f27a3705e29e4ff0adf3f2e069a710c5054bf5e40c1a4a2f855628e181dd4b414c1523a3ea674e368c559ce9a3d6da8e93725cffe06747ca9f696a8a3fcb41f83305a34d6fc1416fb71cbbc289691321b62ab1f6661c40429df26a900d2c43bdb8a6eed6699c411e8b0a6f3e439eb0e6142a3a2b5e9c44509ca5");
            result.Working.ShouldBe(true);
            result.WorkPlaceCode.ShouldBe("434b1d4b215b40c9af8ad04b41f7d7fd9deb8d38f7c148caac0cdd101bfa6d6be0fb0bf131304be783245a57adeb8220981d467613674af1bdf433f11bf1c7fd45909a91902c492682859ed4417142f978c1ee3c5727470aa2e19290e27d8a2b648baeb6d338419282fbe05cbb805ef26c26b543462748a2a3de59c25b2da0f1497cea87b70e47c3b6cb61e82e63b62bc3ecf4599a664a8db8896468a8016845b16d527badff421687b6aa69d3c020bf50436222722e41e7867a3402239836c24735faeb74c4491184d67abc045427a397c7755ed57b4d90837a3af2471282ad5af03281d5a04f81a7ffb0aa48c007a243cbc7d6e8c5489dae0b");
            result.HideWorkSalary.ShouldBe(true);
            result.SalaryPayTypeCode.ShouldBe("a0cdfaf54cba48f7a8e79a3bfb9942140d57db46089245be85");
            result.CurrencyTypeCode.ShouldBe("05aa6a56fa6a44cf8512facbe0533404200b4f55f51e4b5b9f");
            result.Salary1.ShouldBe(1688839673);
            result.Salary2.ShouldBe(1804895026);
            result.CompanyScaleCode.ShouldBe("f3dbfb9fdd9e4c3baeee523794140c9fcaa551ca590e40b4bf");
            result.CompanyManagementNumberCode.ShouldBe("2d63f516733e455aaabed295eeb55d6fb7b9306ae00c496997");
            result.ExtendedInformation.ShouldBe("bbb17d909fde4546b4b8060de952b3dedadf96c8d0d74afc8bd01fd5356cedb8e657065f505e4576aaeab0874ad9c047bd962a6d0ad04f33a8c056a948b660f6294a12a0bd964e84ac8cfcaea6838e7b30347af342ee425a8621981ea5b1b45947d4275ccbc34e0181feeaece04d2b2c34762d1a8d444c3f9b7a48692c1e40962a901638f0f6446cb2cddf184232a02d05c550e350324198a80b88774461a4f3b0f8190bc41b4cbb89b840f39f4d913a2055eaed461c4e25a68316bf66dc6df0e69d1a99063c4403b0c597dfc5bda2eca8a5650a585245fd8131356a886eba52301389a7cc714c20adb7aca3bb60425fc8f49ee379234b539c4d");
            result.DateA.ShouldBe(new DateTime(2002, 6, 23));
            result.DateD.ShouldBe(new DateTime(2020, 8, 18));
            result.Sort.ShouldBe(1777952870);
            result.Note.ShouldBe("df3075b67c564780a7dfaafc943d6e5c9c056fde453043eeb459e2ab9649a2ce5496a1be601949959c1a087f7db3e6ef1cc7d9db79d247ef854c48924a130d66c88ff18114b649d2ba5bd3eaa9154af42851ced0f5fc4ad5958da92dcd65dca2c1899cc7d3fa488b85080351486cb0a9324d3e9421734e46af6f0e1dd2edecaf3302e89244444cd587035c4016aba4932e346aa18bb242b9bdeb77411fcb6a822dc95485afc544fbb49e9dd1a49ca1a2e97d175ea4d94190b17472dcb0bce6bcfd0408ba94c140e0934e341ce8be74ca227fb5b973044d68a5fb6e27e86281b9acb6dd8ae46b41918c362374a62ec5d5201a4a79023d44a295c0");
            result.Status.ShouldBe("096ae67a01034b7895bd0fd03afd61cb359218c96b7a41a785");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeExperiencessAppService.DeleteAsync(Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"));

            // Assert
            var result = await _resumeExperiencesRepository.FindAsync(c => c.Id == Guid.Parse("041a4afd-83fd-4fe0-865d-8625ef7d4957"));

            result.ShouldBeNull();
        }
    }
}