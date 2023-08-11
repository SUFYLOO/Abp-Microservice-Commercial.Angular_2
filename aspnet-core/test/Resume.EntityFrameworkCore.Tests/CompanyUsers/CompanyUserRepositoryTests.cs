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
                    companyMainId: Guid.Parse("fd1862ef-91ae-4afe-878f-447e7cc619c2"),
                    userMainId: Guid.Parse("1f6c1aa4-a9cb-46ea-bb84-c3969ea622b7"),
                    jobName: "418e7dedac2b443eb6a4216530ed1ccc0440b274136542d39b",
                    officePhone: "de2125096a1d43ffb92a174950548d68bf575ccd16e74b29a1",
                    extendedInformation: "063ae382d774498faf2c32d7cb49eb85119ae2f27fdf491c8c0dd96a7eaf71dc68a6759ddda04d44bfca9e404f7e6b8f93873f8fd221458a8afb78a30fc6c4786b19dca14d3142e98f808cc1b24282c84db17bc0464843b584d02469ad6af34c835eeb40393d4b45b07bca37874ba0aec7c95211299a4d698b116bbbb086df7233f75d48a3a0442a892d04154a4f1e49a797a9007c42488aa3008489deb1094cd6ef01c2e6a14e96aa7d30f3a73747b04da3abf0bba4407f941ae1aa46686cc6797fcd4cb73641c8af94c8024bd4e5d743c8597be74b4477a25aa69f3f5510758b7ad259c1e440a28257a48b3f73b449009fc83d212542019c24",
                    note: "51f676defa6146aa8fc175ff5bf0e6f1277f703b987140f7be58023e61793aaf8d0c3068731248ec83c191c0daf63570848938747a5148968e01056de9b6a4501c3f17e580194091ac05103416f5163815fb3db750494f7eb877a11ef6af06931e11f5bd4629466d89232ee386432c4e4769edf5c577487c9c7886bb66b75d56cf18b69dd62f4a58925a9a29c111058c48f888e96141482d93d45ab96bf4d74e4285c098617c474286e62fb9f032486c5effad27356140dda4bd25e7d98fdebbf721e2b2d91f43549a8bed0a9d5e16f74416bc2d14ca4268ba187d66611a735b82f8cc2f52484fd88ddd1d917696169adfd6f8aafd5843c78368",
                    status: "53d605b5b0f6491b904ac0183629120f09b11247ac584a4989",
                    matchingReceive: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("a2e6c164-6fe0-4914-bd80-c8b069161ad1"));
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
                    companyMainId: Guid.Parse("31966666-5586-48b3-9733-099d29fe5286"),
                    userMainId: Guid.Parse("71a4c8bb-0d50-42ea-adc9-279662ccd2f7"),
                    jobName: "736dcc00004243ab8df463f352720f32f309a959735f4fca9d",
                    officePhone: "0874f85022ae4ccebca3baae6a2d275f81387272b2fe4cd68e",
                    extendedInformation: "b7114969bad4470682db771b15835a1a58ca55f788b94bf6a4d05552b021048e65d03a6ac8bc4c3e8d97c5e54446571156fd2e8ffcb04d979fe3da88420aa1df515ead94aaf14fccb2ea31f8e35b8c6fb59047fc6d4b4255af3f173a0b2f42403cd79a4e96604b0aa1620102732af959d785774c5a6c4a1c9d276802768a1e6e45b8595cddaa45c7980fd4620681a65f5c9b393c332b4c74b3e95b03074cb5c0014a8dd0ee2e433eadf0534d641cf3627f1d689fa89a4db8becc44cc5ac57657d1c736d4de4e4112a70bf9622c4ed9832e9f48a98770473f923c4c39121ddfd8dbad7c3885f24c79a7b7ad8de9c71fb5a68793861d6c4225ba88",
                    note: "f692a13e3bd54601961c18205639a52741cc6527a3ef4a83ac22a0a8deeab0dc41437e111428453695fac5f88fe433cf43f3abd48fa54cec9f68a60883fb0c359bf564f9719e49b8a7998ce74b9c3d6ee2b0849b24bb44bb9f03cbe9c2dcb06e540637be8ee14104a889d84c71d4f869881f8a4d2c034a3c913551b00233cbf838d8fcbd92c54846aa3c385825ebfde30cf25238a09d408a8abc8323503d9ebbb8d2faef08224efcac531ee1aabe1171f02d3011a1da4fe697436880c163e236a105548cef604d969dd94bd83000aef71b845ede424046a885511923266344ddcce7fce92d214f7e922d2ec83728f4f4e74b0ba6f52443f2a279",
                    status: "36ea4eb9d4a34ca793c9242302eb45359da29c32545a4d1ebf",
                    matchingReceive: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}