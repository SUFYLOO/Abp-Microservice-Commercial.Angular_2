using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.ResumeEducationss
{
    public class ResumeEducationssAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IResumeEducationssAppService _resumeEducationssAppService;
        private readonly IRepository<ResumeEducations, Guid> _resumeEducationsRepository;

        public ResumeEducationssAppServiceTests()
        {
            _resumeEducationssAppService = GetRequiredService<IResumeEducationssAppService>();
            _resumeEducationsRepository = GetRequiredService<IRepository<ResumeEducations, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetListAsync(new GetResumeEducationssInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("7a2736d3-b8bb-47b1-b3ca-905699c617c0")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _resumeEducationssAppService.GetAsync(Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new ResumeEducationsCreateDto
            {
                ResumeMainId = Guid.Parse("1b99f8c1-3d8e-4756-b03d-055abef8d35f"),
                EducationLevelCode = "0be224e027b945d6a6bd228a53ca03af0676820ee5c745dc83",
                SchoolCode = "05a8705ccd3a40389a43f5dbab041a30b28aabd9c0094b6eb7",
                SchoolName = "acc863d24b654e89bbbf4b7c673dc189212dc009b91c44ff89df40ee2a254ce5d33544100f6c48b8be4e4721f692333be22d6c3e939242b8b2fa88a08da0a5d8cf3552392cad461bac501ff0606372c9ab2b190242ad4c15bcaf7207cfd1aeca5460d7af",
                Night = true,
                Working = true,
                MajorDepartmentName = "0978e93d1bbb4091a5bff176bd6e8aed563c09c196624dd493",
                MajorDepartmentCategoryCode = "19f4976ad379480ea49bcb29e5183a910f462b1a034742f0ad71b6e5044d68b66630c8279c104d50b9b469a19bf2ee62df0c54ec3f80426cb88c7da5f8125fb588e11a4d97a74a5f8ed1a383849535bf9b571af7475b4feba11211ce336bc3e928cd6de2200547fd947b2bfef63d7b563de337031b6845f299de9199378daddeb7976421b69e40cbab41ee4a00988747f9c26ee324624abba5b574ed8549df1533c66b2275ba4ac58b7cf43b4f51bc2fffce4dd790df484fb5050e032ff254b1d5f8c4639c284d9cb855c65bb9be0c08df7876d1873c489c9eb299a4acb43a4a161544ca45f843eba9f5a984a5e275726040b6013926479a8fa9",
                MinorDepartmentName = "cb2d94f4dea646d7b6f2b966f0c5ce8bd2e8a0dc7d554b0b9c",
                MinorDepartmentCategoryCode = "351ec237c87843f4bba2408ff2d4514f068d99133ea541feac75f99bf3bf9727f609c9cf84de454080580237045402a3aeaf5e0dbeca44409fa6f126c10335d5a0304412b9794b7fa6df4eab4ea8bd4736f29cf711f3406887fbdfee763a4637ca20765c4a754f8bbd95fca9866e1b67f19dcd1f1f564a0d96ea3133dd4f3c9f6bc5210f3c7b47319432a8a781cf5f3054906b90959f41a0bcfb33ae60559127fd7abc1c89aa4dd4b22713becbd90e9e2a1d2a93e9744a8e923f95a94ddc7c87038d3765b0f34b7fbb2a0436762382db729cb3065cf4401a84933edaeec6800986a53e938d1042a983d0cdfca35b56328311d56d478e4f9d9d5c",
                GraduationCode = "f3ef965712de4a49ab00faaee22cbbce18e77a45ff1e4668aa",
                Domestic = true,
                CountryCode = "6f08dfe23b7a48b28659d78353d2c1ed379eed3f9a5d4310a9",
                ExtendedInformation = "243404a19a61456cb0d51432dc13705dd460d5682f0747ad9b28157176bd82c6d1ee2b7bc4d4462f82c831c0f14be12a5950a95608594d0396d3dd7b155ebfe59ae2345d8cc54bd5997960cf331b25b9cb7c75bca6ad4ab688e3bf143df71f313366ad68c9d7454ba333e318fc020c236dbdef482504472795c380834874ee30ddd07a9e5200436fbec9d3019e6d41d95dcfefac43ff4337b7a72cad3636e64010a26f8fa3a94daaacc3d07121930e1a6fa60caaff95432cb2512e218d5d1ecefb45cc0da3714c0ea07de34df39ed04bcc2836c98661474d984143147f23607534d6cb38963e4718b1c9e079d69e6434ac25f3ac9b3a43cebd41",
                DateA = new DateTime(2020, 4, 7),
                DateD = new DateTime(2000, 5, 14),
                Sort = 1777536209,
                Note = "75429e868e7040fd93039c295f012d3b74ff6f21cd4b49d896990421e3761adc1547eb3931424e8682cc887922c5827e9269d2464bbf4d75b252f3565e6f2fec95b346a3fa4e470e9d6988007951522908ca9b3a14f44d9aa149a9e249878e56501794288d394fe797e2a90ac6f4f857e06f5582c2954ccabf42bd2a7c9c2a4aae2e1be01539453f92647d06ffa73aa220b8b5992fb046a1905b112acc31b66acd093d680e0148a99f62e2f023c0eb095f3bb9eb402d4f17a92b76222c19c2f0e315eafd9d654a6693053d1185f64fb6b17677aa4c41403593dd7d8ff51cfe5f3fe69eadc9c34c66af6b1b1c35e6b27704bc765a7c3344eaa864",
                Status = "65fcc78f03354ea9bcaee2d8b0eb3ccb6c4be990a82349eda4"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.CreateAsync(input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("1b99f8c1-3d8e-4756-b03d-055abef8d35f"));
            result.EducationLevelCode.ShouldBe("0be224e027b945d6a6bd228a53ca03af0676820ee5c745dc83");
            result.SchoolCode.ShouldBe("05a8705ccd3a40389a43f5dbab041a30b28aabd9c0094b6eb7");
            result.SchoolName.ShouldBe("acc863d24b654e89bbbf4b7c673dc189212dc009b91c44ff89df40ee2a254ce5d33544100f6c48b8be4e4721f692333be22d6c3e939242b8b2fa88a08da0a5d8cf3552392cad461bac501ff0606372c9ab2b190242ad4c15bcaf7207cfd1aeca5460d7af");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("0978e93d1bbb4091a5bff176bd6e8aed563c09c196624dd493");
            result.MajorDepartmentCategoryCode.ShouldBe("19f4976ad379480ea49bcb29e5183a910f462b1a034742f0ad71b6e5044d68b66630c8279c104d50b9b469a19bf2ee62df0c54ec3f80426cb88c7da5f8125fb588e11a4d97a74a5f8ed1a383849535bf9b571af7475b4feba11211ce336bc3e928cd6de2200547fd947b2bfef63d7b563de337031b6845f299de9199378daddeb7976421b69e40cbab41ee4a00988747f9c26ee324624abba5b574ed8549df1533c66b2275ba4ac58b7cf43b4f51bc2fffce4dd790df484fb5050e032ff254b1d5f8c4639c284d9cb855c65bb9be0c08df7876d1873c489c9eb299a4acb43a4a161544ca45f843eba9f5a984a5e275726040b6013926479a8fa9");
            result.MinorDepartmentName.ShouldBe("cb2d94f4dea646d7b6f2b966f0c5ce8bd2e8a0dc7d554b0b9c");
            result.MinorDepartmentCategoryCode.ShouldBe("351ec237c87843f4bba2408ff2d4514f068d99133ea541feac75f99bf3bf9727f609c9cf84de454080580237045402a3aeaf5e0dbeca44409fa6f126c10335d5a0304412b9794b7fa6df4eab4ea8bd4736f29cf711f3406887fbdfee763a4637ca20765c4a754f8bbd95fca9866e1b67f19dcd1f1f564a0d96ea3133dd4f3c9f6bc5210f3c7b47319432a8a781cf5f3054906b90959f41a0bcfb33ae60559127fd7abc1c89aa4dd4b22713becbd90e9e2a1d2a93e9744a8e923f95a94ddc7c87038d3765b0f34b7fbb2a0436762382db729cb3065cf4401a84933edaeec6800986a53e938d1042a983d0cdfca35b56328311d56d478e4f9d9d5c");
            result.GraduationCode.ShouldBe("f3ef965712de4a49ab00faaee22cbbce18e77a45ff1e4668aa");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("6f08dfe23b7a48b28659d78353d2c1ed379eed3f9a5d4310a9");
            result.ExtendedInformation.ShouldBe("243404a19a61456cb0d51432dc13705dd460d5682f0747ad9b28157176bd82c6d1ee2b7bc4d4462f82c831c0f14be12a5950a95608594d0396d3dd7b155ebfe59ae2345d8cc54bd5997960cf331b25b9cb7c75bca6ad4ab688e3bf143df71f313366ad68c9d7454ba333e318fc020c236dbdef482504472795c380834874ee30ddd07a9e5200436fbec9d3019e6d41d95dcfefac43ff4337b7a72cad3636e64010a26f8fa3a94daaacc3d07121930e1a6fa60caaff95432cb2512e218d5d1ecefb45cc0da3714c0ea07de34df39ed04bcc2836c98661474d984143147f23607534d6cb38963e4718b1c9e079d69e6434ac25f3ac9b3a43cebd41");
            result.DateA.ShouldBe(new DateTime(2020, 4, 7));
            result.DateD.ShouldBe(new DateTime(2000, 5, 14));
            result.Sort.ShouldBe(1777536209);
            result.Note.ShouldBe("75429e868e7040fd93039c295f012d3b74ff6f21cd4b49d896990421e3761adc1547eb3931424e8682cc887922c5827e9269d2464bbf4d75b252f3565e6f2fec95b346a3fa4e470e9d6988007951522908ca9b3a14f44d9aa149a9e249878e56501794288d394fe797e2a90ac6f4f857e06f5582c2954ccabf42bd2a7c9c2a4aae2e1be01539453f92647d06ffa73aa220b8b5992fb046a1905b112acc31b66acd093d680e0148a99f62e2f023c0eb095f3bb9eb402d4f17a92b76222c19c2f0e315eafd9d654a6693053d1185f64fb6b17677aa4c41403593dd7d8ff51cfe5f3fe69eadc9c34c66af6b1b1c35e6b27704bc765a7c3344eaa864");
            result.Status.ShouldBe("65fcc78f03354ea9bcaee2d8b0eb3ccb6c4be990a82349eda4");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new ResumeEducationsUpdateDto()
            {
                ResumeMainId = Guid.Parse("f2b57a6f-fcdd-4958-a291-1d616c69825d"),
                EducationLevelCode = "7900cbd8762c4f8b99d06623f768166ccfbab02e2ccd4bfca5",
                SchoolCode = "7c13bd02567444e7b7a4f054cc1da6b54ec0d07202d54f9a9e",
                SchoolName = "6c2fc90b2dcc4fceb65c93e4f8fd0a106c1385552f8a4b1481d097dd2854782cf25e079b9a8c4a13874bbdd1caae3ca70d69745dbb0446099befea58c13ab1dff20fe742816b4c2ba524c90e15aeed9a17a6dda2ac64437ea758e35729c429d12b259d52",
                Night = true,
                Working = true,
                MajorDepartmentName = "8d27ac9ea3ed4dfda39b91498d036132f853feaae2da4906a9",
                MajorDepartmentCategoryCode = "a2bf6eb8bbc0431ea045147cae188655692c7a10cc1540a6aa7e7e79db6556bc3e0f03d09bfc4aadb069209b16a74b3adee1ff0c3702477cb8ad1ab9e7e2148d9260bdc41f2d4733af96eb0f8e8729c606e9337851804fc69c81e6fcb4edfc9cec1d63053b6b48d688a84c7bba7271d4d9ecc8fa42054bb69e70834d1e75cd106d99163cb9a54c99af3b46a06cce774490ce796b3fec4ce1b5e6ba9fd5755e75967185b928e64addbf164731e6894b3ad5b8caa560284d8c8318435e14570656434b6bb52ae3462b913e6f41e1e36b8feeebab0d1ecb420183a23f12d7643efb812ce62f9a8f48d691da93182584d3ab8c6ae683acdc4b0093b9",
                MinorDepartmentName = "c3a75ffd9bdb4eaab0e194dea6e53cd803f07e5db0024aac80",
                MinorDepartmentCategoryCode = "7eabc34447454d009bec8289a10a54426d31c170a95b4b36ae552668114ddee2a149a476894d4f2d8e9459ef37e34c00d211dfe5e4974e57979b657bb558069768c7cc2b1ca7404e811403e8ecf5eb1919073f9bcfd64c1c92d55005c429ad36b0a931226372401faf091dcf42dc30df48551e96d14e42ed8ef28e5b8d796a6455d7e995559d4e2dbc818ef5040747e9731488eff2314826b2da352bc70a6bab4040d282d653479185f604532cf40e6df55d1ef2b67a415daf8a295df8feffbf906776ce8014485997500e57b951bc5fd3d7799ef00140b1ba42f9c381e6facbe7d86b78abee430d8ef732e43109f2de2ca09fe8b8554ca1b40e",
                GraduationCode = "3bcac2d97f1b4afb8996b671efc6a16efcea7422f1c84ca5ba",
                Domestic = true,
                CountryCode = "8860c6276621449d922108b6722e98513c58056e04d74ad2a2",
                ExtendedInformation = "93e9178741c04676bd61763be52c955d45b04314cf664515a6dc867273320706c417190d33ba4380addf8c23805dd06a1a227d0fb4b34afda5d46cb76db6d0d057d025f1abd3465a93949760715b476d451c83322ea444a180af51a560fa4e6b35fe3bd5b7d64e11b42c7ebc625440f1010a201688414f0a9182b34e764207b0e533b1c43c014f449ea39e64ce828e5b1fdceedba2494c65b70f8506f998b26befc26ac1c1dc445b9c9e2b0462c2bc81edb864859b1c49e4b3dfcfa56b860636cabc07667c9a44b880737a2b76a9b5357993070b19b748a7895df7302a4458da80727ae3a0334c259a96662467a169e25fabb6424d284f30aa79",
                DateA = new DateTime(2009, 6, 20),
                DateD = new DateTime(2004, 9, 4),
                Sort = 957265143,
                Note = "f8f2ff8a83404ec599df61c1078da5aecaa1585c902a41b498606832874ff03be27f4f9b9a9849e08e782074460dad17cb646a8a520846aab888e3b8f32f5ce0bddf01e2996e43639e6af76e6df8cb612154f0952a474c76b126218e1df23a7767d57cbaf3534c11957f0fa16dd42fc3a458d8705e7642cb8e98223ee640129a84a0359f43d84f44b8b9bc1db9e4142ec67625bcbbb345c080a5c46126304511551741556f4f4747b9f12f59567bed25ba2675371ce04f3f8c57035d8e95ddcf516a3832640940e1a52f092bf2960db7ce752e1192644be8bbc9f82a6b56552650165b25bd9d4e9c9b9a15ac677dc14fb57b58b4575946f08732",
                Status = "14023fc5ffe845f1afe0741fc4dd7eff69a0d49a05ac41d492"
            };

            // Act
            var serviceResult = await _resumeEducationssAppService.UpdateAsync(Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"), input);

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.ResumeMainId.ShouldBe(Guid.Parse("f2b57a6f-fcdd-4958-a291-1d616c69825d"));
            result.EducationLevelCode.ShouldBe("7900cbd8762c4f8b99d06623f768166ccfbab02e2ccd4bfca5");
            result.SchoolCode.ShouldBe("7c13bd02567444e7b7a4f054cc1da6b54ec0d07202d54f9a9e");
            result.SchoolName.ShouldBe("6c2fc90b2dcc4fceb65c93e4f8fd0a106c1385552f8a4b1481d097dd2854782cf25e079b9a8c4a13874bbdd1caae3ca70d69745dbb0446099befea58c13ab1dff20fe742816b4c2ba524c90e15aeed9a17a6dda2ac64437ea758e35729c429d12b259d52");
            result.Night.ShouldBe(true);
            result.Working.ShouldBe(true);
            result.MajorDepartmentName.ShouldBe("8d27ac9ea3ed4dfda39b91498d036132f853feaae2da4906a9");
            result.MajorDepartmentCategoryCode.ShouldBe("a2bf6eb8bbc0431ea045147cae188655692c7a10cc1540a6aa7e7e79db6556bc3e0f03d09bfc4aadb069209b16a74b3adee1ff0c3702477cb8ad1ab9e7e2148d9260bdc41f2d4733af96eb0f8e8729c606e9337851804fc69c81e6fcb4edfc9cec1d63053b6b48d688a84c7bba7271d4d9ecc8fa42054bb69e70834d1e75cd106d99163cb9a54c99af3b46a06cce774490ce796b3fec4ce1b5e6ba9fd5755e75967185b928e64addbf164731e6894b3ad5b8caa560284d8c8318435e14570656434b6bb52ae3462b913e6f41e1e36b8feeebab0d1ecb420183a23f12d7643efb812ce62f9a8f48d691da93182584d3ab8c6ae683acdc4b0093b9");
            result.MinorDepartmentName.ShouldBe("c3a75ffd9bdb4eaab0e194dea6e53cd803f07e5db0024aac80");
            result.MinorDepartmentCategoryCode.ShouldBe("7eabc34447454d009bec8289a10a54426d31c170a95b4b36ae552668114ddee2a149a476894d4f2d8e9459ef37e34c00d211dfe5e4974e57979b657bb558069768c7cc2b1ca7404e811403e8ecf5eb1919073f9bcfd64c1c92d55005c429ad36b0a931226372401faf091dcf42dc30df48551e96d14e42ed8ef28e5b8d796a6455d7e995559d4e2dbc818ef5040747e9731488eff2314826b2da352bc70a6bab4040d282d653479185f604532cf40e6df55d1ef2b67a415daf8a295df8feffbf906776ce8014485997500e57b951bc5fd3d7799ef00140b1ba42f9c381e6facbe7d86b78abee430d8ef732e43109f2de2ca09fe8b8554ca1b40e");
            result.GraduationCode.ShouldBe("3bcac2d97f1b4afb8996b671efc6a16efcea7422f1c84ca5ba");
            result.Domestic.ShouldBe(true);
            result.CountryCode.ShouldBe("8860c6276621449d922108b6722e98513c58056e04d74ad2a2");
            result.ExtendedInformation.ShouldBe("93e9178741c04676bd61763be52c955d45b04314cf664515a6dc867273320706c417190d33ba4380addf8c23805dd06a1a227d0fb4b34afda5d46cb76db6d0d057d025f1abd3465a93949760715b476d451c83322ea444a180af51a560fa4e6b35fe3bd5b7d64e11b42c7ebc625440f1010a201688414f0a9182b34e764207b0e533b1c43c014f449ea39e64ce828e5b1fdceedba2494c65b70f8506f998b26befc26ac1c1dc445b9c9e2b0462c2bc81edb864859b1c49e4b3dfcfa56b860636cabc07667c9a44b880737a2b76a9b5357993070b19b748a7895df7302a4458da80727ae3a0334c259a96662467a169e25fabb6424d284f30aa79");
            result.DateA.ShouldBe(new DateTime(2009, 6, 20));
            result.DateD.ShouldBe(new DateTime(2004, 9, 4));
            result.Sort.ShouldBe(957265143);
            result.Note.ShouldBe("f8f2ff8a83404ec599df61c1078da5aecaa1585c902a41b498606832874ff03be27f4f9b9a9849e08e782074460dad17cb646a8a520846aab888e3b8f32f5ce0bddf01e2996e43639e6af76e6df8cb612154f0952a474c76b126218e1df23a7767d57cbaf3534c11957f0fa16dd42fc3a458d8705e7642cb8e98223ee640129a84a0359f43d84f44b8b9bc1db9e4142ec67625bcbbb345c080a5c46126304511551741556f4f4747b9f12f59567bed25ba2675371ce04f3f8c57035d8e95ddcf516a3832640940e1a52f092bf2960db7ce752e1192644be8bbc9f82a6b56552650165b25bd9d4e9c9b9a15ac677dc14fb57b58b4575946f08732");
            result.Status.ShouldBe("14023fc5ffe845f1afe0741fc4dd7eff69a0d49a05ac41d492");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _resumeEducationssAppService.DeleteAsync(Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"));

            // Assert
            var result = await _resumeEducationsRepository.FindAsync(c => c.Id == Guid.Parse("9e5bebf5-eb42-4978-94f7-ed1ecbde07da"));

            result.ShouldBeNull();
        }
    }
}