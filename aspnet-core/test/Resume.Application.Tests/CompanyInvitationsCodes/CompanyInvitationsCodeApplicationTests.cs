using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyInvitationsCodes
{
    public class CompanyInvitationsCodesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyInvitationsCodesAppService _companyInvitationsCodesAppService;
        private readonly IRepository<CompanyInvitationsCode, Guid> _companyInvitationsCodeRepository;

        public CompanyInvitationsCodesAppServiceTests()
        {
            _companyInvitationsCodesAppService = GetRequiredService<ICompanyInvitationsCodesAppService>();
            _companyInvitationsCodeRepository = GetRequiredService<IRepository<CompanyInvitationsCode, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetListAsync(new GetCompanyInvitationsCodesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("2885aed5-3c12-4038-b214-c471394decce")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("b9d59bc0-ae27-47a0-a0c8-45165c9bdd23")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyInvitationsCodesAppService.GetAsync(Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeCreateDto
            {
                CompanyMainId = Guid.Parse("875079b3-3614-46cf-9706-ec3213d4bba2"),
                CompanyJobId = Guid.Parse("52a536f8-a924-4d43-ae09-32fcbedd1308"),
                CompanyInvitationId = "39268ecb10fe4928a99c7ea8f1cf9bd67571ccfc1ad24bd79c",
                VerifyId = "79bdb07bb82e451e99b614cf9e8153873ef70bd0b7c14a7fbb44fdf02b83ca94e5633412dbf3461d816782c06b88a55c6c0c1377a55943a0884260e0e67a7a2e38e598a733124b888c48b9afe5b56f2e6f3c500b0a79490d84c9c34d9c7d56867f5e07f626e34858b7d0663848e2bd93126c9a4290b84958a6b59fe449ca8e4d08c51307cf1a42a2ae49fc4c3d458abab5ceb9cf9bbf48a5ab53962630373ce33cb108d6bde44f5db4d3d42ffb718ac7cfc59726b452461a94ba193c408e88e03ad687cc181544aeb956d7c530714719f32692039bb64f3cb75a8a594ece11c8bde10269cea94f0cb8e68cefd39cf24dc3d595a96f7c4db697c7",
                VerifyCode = "e8c02f768f9444e0ac899735f774f4fc797448455fcf466f93",
                ExtendedInformation = "f2ee3e067823472d9730af5c7c0bf538a5ef124d48ae416992849c5ec636bc2168d16ccc4b2b49d29bdffe6fd18c9f4769ff7f3d3d844d07a138a1b89df0e154163590b0c1f8491094073a8a6d433038fcf4c1ca736d4502ab6d286696eafcb71a6636d99bba45ab840ea257f4d3891f62812771d2bf461a8da821d9a4d2b4461848d03ae2294d36b51a340b11c4352e04f08cc639bb458288fd9768595e452bcdbe926c13e14650a50a7f749e8c6add6ae9548be82246ceb9b03ae2809da63c4f4b2539dba04c588260a2939fc87affd2fac11f213c4bc7a4ad98c5deab94d55173981e97ee4b91a9862d7f570272f6beac339c7e6a43ec82d1",
                DateA = new DateTime(2006, 1, 24),
                DateD = new DateTime(2022, 8, 1),
                Sort = 1809614826,
                Note = "18cbc8e84afb4523892f5a32d16d22cc7130e048149b4f52922f0172deafe6e68959f2d75d744b999bc5d02919fccd1fc80d69cfb4fb47d28fd22ac613e3d14bc0ebe240733745b18d5a9665e415f815a8c2c03ec42442d297f5d6d5a0577f85e5cfccdf5f374a74964bc039b9c9667f1f23bd718aa8475584bba9dee5a708e038c862d62dea4700b55b208f7a92feff487aee6279344e5383c59e129d0603e6a3ff3e56cb3a4bdfb48a089531fa982cbd47addb93b14ff08e7557c4b8a8ed0d083d72a95542447f8fb2991fa66ee8bf065655107ddc4f7992f253d951920bc602a9dbf58a4740c59fab5b8757f6edb20375f1cb27a9480d84f3",
                Status = "b839299ec9d541298303785fa821c527c606311fe33e4f91ac"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.CreateAsync(input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("875079b3-3614-46cf-9706-ec3213d4bba2"));
            result.CompanyJobId.ShouldBe(Guid.Parse("52a536f8-a924-4d43-ae09-32fcbedd1308"));
            result.CompanyInvitationId.ShouldBe("39268ecb10fe4928a99c7ea8f1cf9bd67571ccfc1ad24bd79c");
            result.VerifyId.ShouldBe("79bdb07bb82e451e99b614cf9e8153873ef70bd0b7c14a7fbb44fdf02b83ca94e5633412dbf3461d816782c06b88a55c6c0c1377a55943a0884260e0e67a7a2e38e598a733124b888c48b9afe5b56f2e6f3c500b0a79490d84c9c34d9c7d56867f5e07f626e34858b7d0663848e2bd93126c9a4290b84958a6b59fe449ca8e4d08c51307cf1a42a2ae49fc4c3d458abab5ceb9cf9bbf48a5ab53962630373ce33cb108d6bde44f5db4d3d42ffb718ac7cfc59726b452461a94ba193c408e88e03ad687cc181544aeb956d7c530714719f32692039bb64f3cb75a8a594ece11c8bde10269cea94f0cb8e68cefd39cf24dc3d595a96f7c4db697c7");
            result.VerifyCode.ShouldBe("e8c02f768f9444e0ac899735f774f4fc797448455fcf466f93");
            result.ExtendedInformation.ShouldBe("f2ee3e067823472d9730af5c7c0bf538a5ef124d48ae416992849c5ec636bc2168d16ccc4b2b49d29bdffe6fd18c9f4769ff7f3d3d844d07a138a1b89df0e154163590b0c1f8491094073a8a6d433038fcf4c1ca736d4502ab6d286696eafcb71a6636d99bba45ab840ea257f4d3891f62812771d2bf461a8da821d9a4d2b4461848d03ae2294d36b51a340b11c4352e04f08cc639bb458288fd9768595e452bcdbe926c13e14650a50a7f749e8c6add6ae9548be82246ceb9b03ae2809da63c4f4b2539dba04c588260a2939fc87affd2fac11f213c4bc7a4ad98c5deab94d55173981e97ee4b91a9862d7f570272f6beac339c7e6a43ec82d1");
            result.DateA.ShouldBe(new DateTime(2006, 1, 24));
            result.DateD.ShouldBe(new DateTime(2022, 8, 1));
            result.Sort.ShouldBe(1809614826);
            result.Note.ShouldBe("18cbc8e84afb4523892f5a32d16d22cc7130e048149b4f52922f0172deafe6e68959f2d75d744b999bc5d02919fccd1fc80d69cfb4fb47d28fd22ac613e3d14bc0ebe240733745b18d5a9665e415f815a8c2c03ec42442d297f5d6d5a0577f85e5cfccdf5f374a74964bc039b9c9667f1f23bd718aa8475584bba9dee5a708e038c862d62dea4700b55b208f7a92feff487aee6279344e5383c59e129d0603e6a3ff3e56cb3a4bdfb48a089531fa982cbd47addb93b14ff08e7557c4b8a8ed0d083d72a95542447f8fb2991fa66ee8bf065655107ddc4f7992f253d951920bc602a9dbf58a4740c59fab5b8757f6edb20375f1cb27a9480d84f3");
            result.Status.ShouldBe("b839299ec9d541298303785fa821c527c606311fe33e4f91ac");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyInvitationsCodeUpdateDto()
            {
                CompanyMainId = Guid.Parse("18fc025e-aec8-4e13-8e1d-f2750b7433dd"),
                CompanyJobId = Guid.Parse("0f79b23d-9e92-44fe-acb3-7b294a45e498"),
                CompanyInvitationId = "f6d7186919dd4f35a62ea47346101504a50219713d2440e8b8",
                VerifyId = "0ccdb7cbc029478cbbe2179e21c8b346877b7b3e1d26478eaba30ae02020c24cb9c305fe684a453fadfff6930796803d90b85601095e47518a69874d76a5a674f3803a042b51480496c40f5999bc7dbcb1972216a3984ebf8e2e2dea271cfe92d1dece455e854ec785cfe10b3103fe7ead3d4a6b012e4ccaaad9d556314d305f88d0f1c3a63946e08c315de94a33ac4e36bc3bb343144d7394d4d43733b6272f5bf20c0dc4a945aca8d1357385c9c7b47ddda2f809184f01b102a85507b73c4afcf460360e134c069cee20281bd76d40bccd6933073a46b8941e3933acdf77c823c3518ea5ae48e19d9dc6b4f745ca5d680642e754fb4a929d52",
                VerifyCode = "288cc8fec872450092ec056566c0cd9e82b06f118a5e44ef9d",
                ExtendedInformation = "f50f4388330c4d0084b7ddbedf319412285b70c1e5d84c9c85918008b4b65ef9f10699bdca3a4048a7e1aea0da3b8cc82ecd10cb9e5447e39002921e84f05fc7d0a9740ad10a4847b707d9805e83e0a7a0cc63d33fd84351926205cecbd27b032283760399f84f5fa223267daef5bd77d082d18c94e44553b2d2449c70126948992d26f155834eb8ab44e9839d67adc9ddd9df622ed84e70889deb33cfb0f92d8bcb486f80ae42b695c1cf08d89d3b23b212742727814554b0bcdee66d779bebba450e32565f4c4a894677a1cbade1634bec2a0e5d514db2a34ddeef9d18f0f0ecf75734ca5a4424b9995fac7b33bc5b9222924709dc4267a924",
                DateA = new DateTime(2022, 7, 17),
                DateD = new DateTime(2002, 7, 18),
                Sort = 1358578772,
                Note = "774c88fd821844b893f700663a95df78197209034d104057974bd6f98011a8b5e662013e28184fae9902927018d022c9e62bccaf1e884a67ba6fd704908c91e957f3497a65e44ebea49d38c08c53a03ae3315a2bd86b4821bd9feda1beef287fbaa059bae6de41e2940fdaabd4a348bbcd4b447367a54339a02304c2e5749ae17088548695114c60974719e85131cc40362f9980a69a44f7bb2410bb89d83c0946d82c1963c84417869e83091f525dde2e0422314e304e8f94db9020780ebbaeda0ae09ee06b4a88a9bf18d84235b2332d5139a6c2bd4cc5bb36e30569ee19e02585202ad55c468489d7cd807a530e6b0f5e992ec1a44e32821e",
                Status = "61a47245044b4d21bd8a016d1546b15c1f69cf7b7f154a2799"
            };

            // Act
            var serviceResult = await _companyInvitationsCodesAppService.UpdateAsync(Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"), input);

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("18fc025e-aec8-4e13-8e1d-f2750b7433dd"));
            result.CompanyJobId.ShouldBe(Guid.Parse("0f79b23d-9e92-44fe-acb3-7b294a45e498"));
            result.CompanyInvitationId.ShouldBe("f6d7186919dd4f35a62ea47346101504a50219713d2440e8b8");
            result.VerifyId.ShouldBe("0ccdb7cbc029478cbbe2179e21c8b346877b7b3e1d26478eaba30ae02020c24cb9c305fe684a453fadfff6930796803d90b85601095e47518a69874d76a5a674f3803a042b51480496c40f5999bc7dbcb1972216a3984ebf8e2e2dea271cfe92d1dece455e854ec785cfe10b3103fe7ead3d4a6b012e4ccaaad9d556314d305f88d0f1c3a63946e08c315de94a33ac4e36bc3bb343144d7394d4d43733b6272f5bf20c0dc4a945aca8d1357385c9c7b47ddda2f809184f01b102a85507b73c4afcf460360e134c069cee20281bd76d40bccd6933073a46b8941e3933acdf77c823c3518ea5ae48e19d9dc6b4f745ca5d680642e754fb4a929d52");
            result.VerifyCode.ShouldBe("288cc8fec872450092ec056566c0cd9e82b06f118a5e44ef9d");
            result.ExtendedInformation.ShouldBe("f50f4388330c4d0084b7ddbedf319412285b70c1e5d84c9c85918008b4b65ef9f10699bdca3a4048a7e1aea0da3b8cc82ecd10cb9e5447e39002921e84f05fc7d0a9740ad10a4847b707d9805e83e0a7a0cc63d33fd84351926205cecbd27b032283760399f84f5fa223267daef5bd77d082d18c94e44553b2d2449c70126948992d26f155834eb8ab44e9839d67adc9ddd9df622ed84e70889deb33cfb0f92d8bcb486f80ae42b695c1cf08d89d3b23b212742727814554b0bcdee66d779bebba450e32565f4c4a894677a1cbade1634bec2a0e5d514db2a34ddeef9d18f0f0ecf75734ca5a4424b9995fac7b33bc5b9222924709dc4267a924");
            result.DateA.ShouldBe(new DateTime(2022, 7, 17));
            result.DateD.ShouldBe(new DateTime(2002, 7, 18));
            result.Sort.ShouldBe(1358578772);
            result.Note.ShouldBe("774c88fd821844b893f700663a95df78197209034d104057974bd6f98011a8b5e662013e28184fae9902927018d022c9e62bccaf1e884a67ba6fd704908c91e957f3497a65e44ebea49d38c08c53a03ae3315a2bd86b4821bd9feda1beef287fbaa059bae6de41e2940fdaabd4a348bbcd4b447367a54339a02304c2e5749ae17088548695114c60974719e85131cc40362f9980a69a44f7bb2410bb89d83c0946d82c1963c84417869e83091f525dde2e0422314e304e8f94db9020780ebbaeda0ae09ee06b4a88a9bf18d84235b2332d5139a6c2bd4cc5bb36e30569ee19e02585202ad55c468489d7cd807a530e6b0f5e992ec1a44e32821e");
            result.Status.ShouldBe("61a47245044b4d21bd8a016d1546b15c1f69cf7b7f154a2799");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyInvitationsCodesAppService.DeleteAsync(Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"));

            // Assert
            var result = await _companyInvitationsCodeRepository.FindAsync(c => c.Id == Guid.Parse("2885aed5-3c12-4038-b214-c471394decce"));

            result.ShouldBeNull();
        }
    }
}