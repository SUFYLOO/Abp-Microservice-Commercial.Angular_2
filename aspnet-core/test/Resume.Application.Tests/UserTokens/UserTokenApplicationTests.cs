using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.UserTokens
{
    public class UserTokensAppServiceTests : ResumeApplicationTestBase
    {
        private readonly IUserTokensAppService _userTokensAppService;
        private readonly IRepository<UserToken, Guid> _userTokenRepository;

        public UserTokensAppServiceTests()
        {
            _userTokensAppService = GetRequiredService<IUserTokensAppService>();
            _userTokenRepository = GetRequiredService<IRepository<UserToken, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _userTokensAppService.GetListAsync(new GetUserTokensInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("6a0c9efc-8dd0-4777-a985-06e98278bc99")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _userTokensAppService.GetAsync(Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new UserTokenCreateDto
            {
                UserMainId = Guid.Parse("44c6ef3d-6967-460d-bed3-7bc548965beb"),
                TokenOld = "75b3aac0fa064b369176b66f6",
                TokenNew = "d08ff39588d44b77904a",
                ExtendedInformation = "635f121a8a9042b7ab0f2c95b4057c6a7573532223c1451e8c1b4d0b3b5842b1b09de77b170d49a3b9fc643fc6517a153319b84dd1f34761b479dd44347736fd7d90ff4d5a7f4462bce71991704c493c485e458212c54a13bce81e371090ae8d8e896020063c45dbbce6613f69ccc6dc78e1a3c8f11c4b2880d7d10c2de563bd12e86223adcf4a36914f25920e3cb1ff73eb91d3be864f2abdbf96e7b49eeb98e7d3be45f1a043148b59b13000c429a2130c74401bed43a68890c94fe1917473cece2dcf3fbd4391badd9579038d195f360efc9451ff41cbacafb4cce8d3b4c852eec77e176a4692b7f2790d3ada00988f186220fefe4ba28831",
                DateA = new DateTime(2013, 4, 13),
                DateD = new DateTime(2019, 7, 21),
                Sort = 1762353754,
                Note = "c4496f0643d441b88446a993ab079e707c0ed632fd93424da8411a824486c997ded86e92e7764fc8b58abe161da76d8cf070fd213e28460f8ae87be3c5e5336a8165bf28e4c44fc9a1f3771bb684a7a8b1274c4d3f5a42aabbefbbc3fb39f2efb9b6b5d7f62b4498add425f9de229754cb96e6e52ed9448f967345115ab3741ab08d1087e0804f5dbbc82598bdcad4c7b0102ec865ff4bd38333c369802dae22c476b09694d848d78562301a05d6e97b7bc6bccfb6144ced98103e718b7d38633940479f32bd4dd3a01619acab437222e742a3675cba48ae86d5dc7bedfeee5223794260e4ad465fa73a9ecfdddabf61ff14c7d059924522a94b",
                Status = "57e13bcf2360495d8404b4e37f08a8e62a5afb9f23814116b0"
            };

            // Act
            var serviceResult = await _userTokensAppService.CreateAsync(input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("44c6ef3d-6967-460d-bed3-7bc548965beb"));
            result.TokenOld.ShouldBe("75b3aac0fa064b369176b66f6");
            result.TokenNew.ShouldBe("d08ff39588d44b77904a");
            result.ExtendedInformation.ShouldBe("635f121a8a9042b7ab0f2c95b4057c6a7573532223c1451e8c1b4d0b3b5842b1b09de77b170d49a3b9fc643fc6517a153319b84dd1f34761b479dd44347736fd7d90ff4d5a7f4462bce71991704c493c485e458212c54a13bce81e371090ae8d8e896020063c45dbbce6613f69ccc6dc78e1a3c8f11c4b2880d7d10c2de563bd12e86223adcf4a36914f25920e3cb1ff73eb91d3be864f2abdbf96e7b49eeb98e7d3be45f1a043148b59b13000c429a2130c74401bed43a68890c94fe1917473cece2dcf3fbd4391badd9579038d195f360efc9451ff41cbacafb4cce8d3b4c852eec77e176a4692b7f2790d3ada00988f186220fefe4ba28831");
            result.DateA.ShouldBe(new DateTime(2013, 4, 13));
            result.DateD.ShouldBe(new DateTime(2019, 7, 21));
            result.Sort.ShouldBe(1762353754);
            result.Note.ShouldBe("c4496f0643d441b88446a993ab079e707c0ed632fd93424da8411a824486c997ded86e92e7764fc8b58abe161da76d8cf070fd213e28460f8ae87be3c5e5336a8165bf28e4c44fc9a1f3771bb684a7a8b1274c4d3f5a42aabbefbbc3fb39f2efb9b6b5d7f62b4498add425f9de229754cb96e6e52ed9448f967345115ab3741ab08d1087e0804f5dbbc82598bdcad4c7b0102ec865ff4bd38333c369802dae22c476b09694d848d78562301a05d6e97b7bc6bccfb6144ced98103e718b7d38633940479f32bd4dd3a01619acab437222e742a3675cba48ae86d5dc7bedfeee5223794260e4ad465fa73a9ecfdddabf61ff14c7d059924522a94b");
            result.Status.ShouldBe("57e13bcf2360495d8404b4e37f08a8e62a5afb9f23814116b0");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new UserTokenUpdateDto()
            {
                UserMainId = Guid.Parse("954dc2c2-bf1c-42e6-bb1e-6a0088fa8111"),
                TokenOld = "72395196257f4903ade52c05",
                TokenNew = "4c6f8bcb54b64e158449dfa97df0aacd2e0df51069434302bbbbf296cc80993cdc7e8d18ee97491988ebd8794",
                ExtendedInformation = "46d5319fa3444cda8661b366db2c9c97171c27418a314d6588e99200c3f8e16a4dc415c072f34378acd961e77260fe039df6648a02bf405a8780d0bc00282df9f4e2fafc20844984bedb684eb4d68537131037cfd6f749369f39f611621c4bbdec55cba0377e4ee98ea53b8a283bb86d5a86708983674017aaa0938c975ecd78e032b179cb7b47fd87967fe6b96ea9ff083e7220d7d74e7d85e53a529386d148b4bee47606f54673b33c4037a64d0585960d2b9572d24f8cb1731f1d1ee830176415ff1b2df14fffafe6a3f1ad75a26d8b6c1bcd125240fc8d6b791f25e96cdacbe327cba1a14cbd80bc5dd93b7f9be7adab243609214bd1ae9d",
                DateA = new DateTime(2014, 9, 26),
                DateD = new DateTime(2008, 6, 4),
                Sort = 2109212614,
                Note = "b7dd9637bd604743a8efdc10a243001570cbebc80fe34bf0924b572ac8b234919adf0168ce9d48b7b185755e752ad37389780fa5173749278d282f1ef02bcacf294f7b3b68d84dd9b8c9e9070cc13f7fea35ea550eb9424f99cbd29254790f3aeb9b297b34114da3bd0184d29e681c1779a8b1547c1f46fcaf780468051b7cb5d823c71ed84d40798b7b16648a3e102e28bd9a07abdf40b297fe7e87602baab6f61416b03cdc44ad927a495357a6ae8a3a061b173910434e959c66f23e91b3139e0858ef67e64fb09b91d747ee9ba181cb3b4043e90849caa3ca198a0fc27e370d49c8e3c8de4884868860d30b75be027801ed9a7a5146fa9fc9",
                Status = "3545e1981d124657b645e39857f6aaa73f0e0f1b719c4eca82"
            };

            // Act
            var serviceResult = await _userTokensAppService.UpdateAsync(Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"), input);

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.UserMainId.ShouldBe(Guid.Parse("954dc2c2-bf1c-42e6-bb1e-6a0088fa8111"));
            result.TokenOld.ShouldBe("72395196257f4903ade52c05");
            result.TokenNew.ShouldBe("4c6f8bcb54b64e158449dfa97df0aacd2e0df51069434302bbbbf296cc80993cdc7e8d18ee97491988ebd8794");
            result.ExtendedInformation.ShouldBe("46d5319fa3444cda8661b366db2c9c97171c27418a314d6588e99200c3f8e16a4dc415c072f34378acd961e77260fe039df6648a02bf405a8780d0bc00282df9f4e2fafc20844984bedb684eb4d68537131037cfd6f749369f39f611621c4bbdec55cba0377e4ee98ea53b8a283bb86d5a86708983674017aaa0938c975ecd78e032b179cb7b47fd87967fe6b96ea9ff083e7220d7d74e7d85e53a529386d148b4bee47606f54673b33c4037a64d0585960d2b9572d24f8cb1731f1d1ee830176415ff1b2df14fffafe6a3f1ad75a26d8b6c1bcd125240fc8d6b791f25e96cdacbe327cba1a14cbd80bc5dd93b7f9be7adab243609214bd1ae9d");
            result.DateA.ShouldBe(new DateTime(2014, 9, 26));
            result.DateD.ShouldBe(new DateTime(2008, 6, 4));
            result.Sort.ShouldBe(2109212614);
            result.Note.ShouldBe("b7dd9637bd604743a8efdc10a243001570cbebc80fe34bf0924b572ac8b234919adf0168ce9d48b7b185755e752ad37389780fa5173749278d282f1ef02bcacf294f7b3b68d84dd9b8c9e9070cc13f7fea35ea550eb9424f99cbd29254790f3aeb9b297b34114da3bd0184d29e681c1779a8b1547c1f46fcaf780468051b7cb5d823c71ed84d40798b7b16648a3e102e28bd9a07abdf40b297fe7e87602baab6f61416b03cdc44ad927a495357a6ae8a3a061b173910434e959c66f23e91b3139e0858ef67e64fb09b91d747ee9ba181cb3b4043e90849caa3ca198a0fc27e370d49c8e3c8de4884868860d30b75be027801ed9a7a5146fa9fc9");
            result.Status.ShouldBe("3545e1981d124657b645e39857f6aaa73f0e0f1b719c4eca82");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _userTokensAppService.DeleteAsync(Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"));

            // Assert
            var result = await _userTokenRepository.FindAsync(c => c.Id == Guid.Parse("6f37c737-f65e-407a-9fb5-17951a674e6d"));

            result.ShouldBeNull();
        }
    }
}