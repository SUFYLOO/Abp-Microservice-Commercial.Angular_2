using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobApplicationMethodsAppService _companyJobApplicationMethodsAppService;
        private readonly IRepository<CompanyJobApplicationMethod, Guid> _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodsAppServiceTests()
        {
            _companyJobApplicationMethodsAppService = GetRequiredService<ICompanyJobApplicationMethodsAppService>();
            _companyJobApplicationMethodRepository = GetRequiredService<IRepository<CompanyJobApplicationMethod, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetListAsync(new GetCompanyJobApplicationMethodsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("9b022e60-9787-4c59-94ca-04bdb6a4a960")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobApplicationMethodsAppService.GetAsync(Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodCreateDto
            {
                CompanyMainId = Guid.Parse("c25f58c1-bf92-477a-a854-4fa5f98b549a"),
                CompanyJobId = Guid.Parse("d5feeaed-6ed8-4bda-85db-383d794e17fa"),
                OrgContactPerson = "aa0808d3a8b04d5f9d38a164424062224f7b3938e2724812ba",
                OrgContactMail = "6ac0518398844a96b95ab4d73362c046fdc8dc82f0ce4e9f98b7731e5b7adeaf5698aab1e1534328bd3fd803b9baca6cc74619e8a4684b9c92e809d76dc1b15e4cd3ca05f7b543c5936c1525a6607cebd8b4eda01bc24357a22932199c2818f92945f907d4dc4db9927608270f157425a8475a96461f464ab0ea175ec81e29e3ea76d4d7cbc1439f8631f4218f322c99ef3c73fba7db45788cbb8c7c5e5e39134664eb01990c437abeb116abc874c9ccbb608b8be0994c1495813107ea85dbe9455cc3d6608d4757849dbd0309b41b70470d27e668c94b05bd9f270bd59b793555e37b69b6e9495d9abd613bb224469d3e481e55f4af432c9f40",
                ToRespondDay = 1296409042,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "9423a903e1f340eea2a0c779e205d82402a0ff505bad4f3e82",
                Personally = "340cbfa6904843d790ef73320e9c3ac983ce71f20a3b448c8adf46fd2b545599d801d1c024c64a388133894c77140a0e5d0b54bbfd504c6089b5e77e52a782ccad209d1b5d274d7fa8a4987d8e466b06d818c29dd2c2475e8d0ac7b3444bc9e242d3a2b5",
                PersonallyAddress = "0e4efcae06754a4c9cea5ff5acaa3a5847520e1db25146d585514e2bb3b5fcc4d0bf509207b3457aaa508b71949fd98c901b42cb8dcb49e6a085af25ad157c870fd31a79a472482bb367cfd111e286e7d39ad8f0f1dd4c3ab75defa4b2fac4046caabf45",
                ExtendedInformation = "450b2715e26f4228988934cfe53ed4a6de6511b04793417ca4b9ea5a96ced49e265133f888244a618ae80c4114ccfe91c8013e4f78bd45af8d18dbf47a52421634f8f486aaa046eb9082abbf63169c1ba0c95d20d2b64dc0beb4203399e57b8ca3c8424393404a45bebe74f0d3434c9f2ea77cd4089a4e17908b3986a3dbf6413e2faf37ebc345f58b8771f115b50bb423a6cb4850744b6f9c6a8d98ab94baef1f6e40325226467fbf3c0e5c7a6504170c0b49883f0944baba1a8b34e84f3b1d39f1a2651eb84e09ba7a15673714fd0cf4997caacae34f779f5c57cb0e12a8ed341ba98f2d7e4c61881351b2dcb2503bd167a782de624c97a09e",
                DateA = new DateTime(2007, 1, 11),
                DateD = new DateTime(2003, 6, 12),
                Sort = 1371276602,
                Note = "3686b3eaf2ff4874a704dc851876bd477b55a0c83551429fbd680c36d04d3b1c51cc8b158a924608a61e747a5cccc0f5609abeb37d4e4f6a8f436343866f9828f2092b2da93148e2ab6681538379b8232721feb56b82492ebe805630ae3eca74a96f80ab69c34a20ba06a1ef60f0ec1ea6318201b1484394a459e94afa85f88acede4df9df1348808cf65fa47b38e8a05187003f77e643a6a67547bce30fc16fb7825a18d4bc4bb0878a1b01967bbfa89fb25788c7cd47fcb29a11e9a9b06f6dab1557ffc8184931a828ef6c728fb17528b53912abd542f682276fe3a8d9f1eef1e7e672e79d4771830e2fe7913b9d6d2842251e52b84826aa06",
                Status = "2de87119fa33417596ccd05f40a74613c6a1a1ef192246698a"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("c25f58c1-bf92-477a-a854-4fa5f98b549a"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d5feeaed-6ed8-4bda-85db-383d794e17fa"));
            result.OrgContactPerson.ShouldBe("aa0808d3a8b04d5f9d38a164424062224f7b3938e2724812ba");
            result.OrgContactMail.ShouldBe("6ac0518398844a96b95ab4d73362c046fdc8dc82f0ce4e9f98b7731e5b7adeaf5698aab1e1534328bd3fd803b9baca6cc74619e8a4684b9c92e809d76dc1b15e4cd3ca05f7b543c5936c1525a6607cebd8b4eda01bc24357a22932199c2818f92945f907d4dc4db9927608270f157425a8475a96461f464ab0ea175ec81e29e3ea76d4d7cbc1439f8631f4218f322c99ef3c73fba7db45788cbb8c7c5e5e39134664eb01990c437abeb116abc874c9ccbb608b8be0994c1495813107ea85dbe9455cc3d6608d4757849dbd0309b41b70470d27e668c94b05bd9f270bd59b793555e37b69b6e9495d9abd613bb224469d3e481e55f4af432c9f40");
            result.ToRespondDay.ShouldBe(1296409042);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("9423a903e1f340eea2a0c779e205d82402a0ff505bad4f3e82");
            result.Personally.ShouldBe("340cbfa6904843d790ef73320e9c3ac983ce71f20a3b448c8adf46fd2b545599d801d1c024c64a388133894c77140a0e5d0b54bbfd504c6089b5e77e52a782ccad209d1b5d274d7fa8a4987d8e466b06d818c29dd2c2475e8d0ac7b3444bc9e242d3a2b5");
            result.PersonallyAddress.ShouldBe("0e4efcae06754a4c9cea5ff5acaa3a5847520e1db25146d585514e2bb3b5fcc4d0bf509207b3457aaa508b71949fd98c901b42cb8dcb49e6a085af25ad157c870fd31a79a472482bb367cfd111e286e7d39ad8f0f1dd4c3ab75defa4b2fac4046caabf45");
            result.ExtendedInformation.ShouldBe("450b2715e26f4228988934cfe53ed4a6de6511b04793417ca4b9ea5a96ced49e265133f888244a618ae80c4114ccfe91c8013e4f78bd45af8d18dbf47a52421634f8f486aaa046eb9082abbf63169c1ba0c95d20d2b64dc0beb4203399e57b8ca3c8424393404a45bebe74f0d3434c9f2ea77cd4089a4e17908b3986a3dbf6413e2faf37ebc345f58b8771f115b50bb423a6cb4850744b6f9c6a8d98ab94baef1f6e40325226467fbf3c0e5c7a6504170c0b49883f0944baba1a8b34e84f3b1d39f1a2651eb84e09ba7a15673714fd0cf4997caacae34f779f5c57cb0e12a8ed341ba98f2d7e4c61881351b2dcb2503bd167a782de624c97a09e");
            result.DateA.ShouldBe(new DateTime(2007, 1, 11));
            result.DateD.ShouldBe(new DateTime(2003, 6, 12));
            result.Sort.ShouldBe(1371276602);
            result.Note.ShouldBe("3686b3eaf2ff4874a704dc851876bd477b55a0c83551429fbd680c36d04d3b1c51cc8b158a924608a61e747a5cccc0f5609abeb37d4e4f6a8f436343866f9828f2092b2da93148e2ab6681538379b8232721feb56b82492ebe805630ae3eca74a96f80ab69c34a20ba06a1ef60f0ec1ea6318201b1484394a459e94afa85f88acede4df9df1348808cf65fa47b38e8a05187003f77e643a6a67547bce30fc16fb7825a18d4bc4bb0878a1b01967bbfa89fb25788c7cd47fcb29a11e9a9b06f6dab1557ffc8184931a828ef6c728fb17528b53912abd542f682276fe3a8d9f1eef1e7e672e79d4771830e2fe7913b9d6d2842251e52b84826aa06");
            result.Status.ShouldBe("2de87119fa33417596ccd05f40a74613c6a1a1ef192246698a");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobApplicationMethodUpdateDto()
            {
                CompanyMainId = Guid.Parse("2c517aa9-d865-45dc-bada-11e3a7bcbbf2"),
                CompanyJobId = Guid.Parse("86ff074b-1c07-4986-bfdc-2818ba328924"),
                OrgContactPerson = "1a268c35afc843afbc4c3b2735810e09597feb07ab034762a6",
                OrgContactMail = "d51b0d74cbac43d1ab640c116f42e851cbb34d9a401d406cb6ee4eb3912e7c523163e7fb589945089c28353c49f562c259e8644f155b4783a327a173f24ea3074b328f5a83f6481fb9977daf2d1031f49a960a51f1384c178bdba0387d2d5685bfffe0b916ea499490df543a2a121f2a80a54790819c44cba69457b47605ef3d47ceaca1ee774dfab989ad3caf825d08a810baf762604762be471c2464e7df40355b06f96c3f407b9115f9ee76f9690921eb9846d15f4604b7578005868d8d0ad4e5373ccd8c42d4939ec7a53025d4a187b75c92beef46b58da76766994c9f46f90231f513264367bb16ba835f33a0217c67d8755850428ab2e9",
                ToRespondDay = 1668361649,
                ToRespond = true,
                SystemSendResume = true,
                DisplayMail = true,
                Telephone = "18be3a63e0b243749b90f56ad2510ee70d13565b47dc4b3999",
                Personally = "c2b8876a9f924be5b9f894606fcd28f1b84ccabad08040d490e4d3e962d7e3dd25434a774fbc41baae1591db4521f1c1bfa4b1df7d9f442d9a9d6ae8cdffae3e9cead0acc52648669d734b16a71f53ab59bc08e4d85c4dcebef301f5af6204d5817af700",
                PersonallyAddress = "172543e195a744ed9e422e3fac12ad1c1d93c031d52d4655911d0282e301e8a1f7a7418a59644ca4b8d8a02e7472b963aa98fe07a6f44d8096b9a12b0e3c794fef74691afddc4716960813136d21b443ee0952db25d14731b143c2609c5e39e039567ed2",
                ExtendedInformation = "fc4528ac0d4b4efc802acfaca27f37e2cbf23f2e6b68448c89f6a4d61706eb93879a356985504d41bd3ef45b3d35a6aa97b5bf64b30b49a88fa056d16b353f9bda31a58195f241c3b2e2c8872ff5be424ec9c64018274476a583df93301164b56544cd075fc7460fa2ecaa4fb97a24dca70bd5c6fc0a4b129567eb862f697e7fcaf9f66b3f774d199d23ad2c8d1187241e197a59377e47538b67a76d3dfcfd182ee345be5b99444d92550378d79f5e16edbd8104e2c84e42a521bf0da5813d8827aec3b4fcc148f0bb284d239b8a3e7883c93960b1d240789a6f07dac760fd84f83d1e04afbd4144b8237ea16798b19c32cfaef594514fb5a9bd",
                DateA = new DateTime(2020, 1, 21),
                DateD = new DateTime(2016, 11, 14),
                Sort = 381970575,
                Note = "16edde3b45d14c4b819c0b2bd6a2a6b18498129f1d9c4875ad596f405914ae12540c12037c374f0ea3e2674038e975f0673218dc97f941d29d4ce526e06147be1923be53a8194afd99828f740603e82bfce4488e90f047c894ec42bfc7c3a6607a79f0a4177c4a2883556f087afb7586de99541b6119497d84e41ae68c1bc87cbcdd1f9dd52f46a2a87ed426cf6ad348b5a16a49c0e64cada737eb997007d397569f1cea2db141abb66d2d2057f6298eeeef67b557874462941a4176e62b7ebb3337f41cc39c4f85b6ae76d968bced9acf7ea5bf1f5449e48222dc8e28c815d9f69d482eed4f47f8bdb9d9556b3f09edc535a873d09043b18021",
                Status = "f37abfa7106d49e081c4f35d20c1f6132fd76fb39a194ee0b0"
            };

            // Act
            var serviceResult = await _companyJobApplicationMethodsAppService.UpdateAsync(Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"), input);

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("2c517aa9-d865-45dc-bada-11e3a7bcbbf2"));
            result.CompanyJobId.ShouldBe(Guid.Parse("86ff074b-1c07-4986-bfdc-2818ba328924"));
            result.OrgContactPerson.ShouldBe("1a268c35afc843afbc4c3b2735810e09597feb07ab034762a6");
            result.OrgContactMail.ShouldBe("d51b0d74cbac43d1ab640c116f42e851cbb34d9a401d406cb6ee4eb3912e7c523163e7fb589945089c28353c49f562c259e8644f155b4783a327a173f24ea3074b328f5a83f6481fb9977daf2d1031f49a960a51f1384c178bdba0387d2d5685bfffe0b916ea499490df543a2a121f2a80a54790819c44cba69457b47605ef3d47ceaca1ee774dfab989ad3caf825d08a810baf762604762be471c2464e7df40355b06f96c3f407b9115f9ee76f9690921eb9846d15f4604b7578005868d8d0ad4e5373ccd8c42d4939ec7a53025d4a187b75c92beef46b58da76766994c9f46f90231f513264367bb16ba835f33a0217c67d8755850428ab2e9");
            result.ToRespondDay.ShouldBe(1668361649);
            result.ToRespond.ShouldBe(true);
            result.SystemSendResume.ShouldBe(true);
            result.DisplayMail.ShouldBe(true);
            result.Telephone.ShouldBe("18be3a63e0b243749b90f56ad2510ee70d13565b47dc4b3999");
            result.Personally.ShouldBe("c2b8876a9f924be5b9f894606fcd28f1b84ccabad08040d490e4d3e962d7e3dd25434a774fbc41baae1591db4521f1c1bfa4b1df7d9f442d9a9d6ae8cdffae3e9cead0acc52648669d734b16a71f53ab59bc08e4d85c4dcebef301f5af6204d5817af700");
            result.PersonallyAddress.ShouldBe("172543e195a744ed9e422e3fac12ad1c1d93c031d52d4655911d0282e301e8a1f7a7418a59644ca4b8d8a02e7472b963aa98fe07a6f44d8096b9a12b0e3c794fef74691afddc4716960813136d21b443ee0952db25d14731b143c2609c5e39e039567ed2");
            result.ExtendedInformation.ShouldBe("fc4528ac0d4b4efc802acfaca27f37e2cbf23f2e6b68448c89f6a4d61706eb93879a356985504d41bd3ef45b3d35a6aa97b5bf64b30b49a88fa056d16b353f9bda31a58195f241c3b2e2c8872ff5be424ec9c64018274476a583df93301164b56544cd075fc7460fa2ecaa4fb97a24dca70bd5c6fc0a4b129567eb862f697e7fcaf9f66b3f774d199d23ad2c8d1187241e197a59377e47538b67a76d3dfcfd182ee345be5b99444d92550378d79f5e16edbd8104e2c84e42a521bf0da5813d8827aec3b4fcc148f0bb284d239b8a3e7883c93960b1d240789a6f07dac760fd84f83d1e04afbd4144b8237ea16798b19c32cfaef594514fb5a9bd");
            result.DateA.ShouldBe(new DateTime(2020, 1, 21));
            result.DateD.ShouldBe(new DateTime(2016, 11, 14));
            result.Sort.ShouldBe(381970575);
            result.Note.ShouldBe("16edde3b45d14c4b819c0b2bd6a2a6b18498129f1d9c4875ad596f405914ae12540c12037c374f0ea3e2674038e975f0673218dc97f941d29d4ce526e06147be1923be53a8194afd99828f740603e82bfce4488e90f047c894ec42bfc7c3a6607a79f0a4177c4a2883556f087afb7586de99541b6119497d84e41ae68c1bc87cbcdd1f9dd52f46a2a87ed426cf6ad348b5a16a49c0e64cada737eb997007d397569f1cea2db141abb66d2d2057f6298eeeef67b557874462941a4176e62b7ebb3337f41cc39c4f85b6ae76d968bced9acf7ea5bf1f5449e48222dc8e28c815d9f69d482eed4f47f8bdb9d9556b3f09edc535a873d09043b18021");
            result.Status.ShouldBe("f37abfa7106d49e081c4f35d20c1f6132fd76fb39a194ee0b0");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobApplicationMethodsAppService.DeleteAsync(Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"));

            // Assert
            var result = await _companyJobApplicationMethodRepository.FindAsync(c => c.Id == Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"));

            result.ShouldBeNull();
        }
    }
}