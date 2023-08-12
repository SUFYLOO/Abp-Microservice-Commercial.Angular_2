using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobs
{
    public class CompanyJobsAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobsAppService _companyJobsAppService;
        private readonly IRepository<CompanyJob, Guid> _companyJobRepository;

        public CompanyJobsAppServiceTests()
        {
            _companyJobsAppService = GetRequiredService<ICompanyJobsAppService>();
            _companyJobRepository = GetRequiredService<IRepository<CompanyJob, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobsAppService.GetListAsync(new GetCompanyJobsInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("997dabd7-3aed-42b9-8c8d-eed9b1ce7de3")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobsAppService.GetAsync(Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobCreateDto
            {
                CompanyMainId = Guid.Parse("33d56fd8-4e46-4c0a-9c98-8d6d43543217"),
                Name = "cf63b4d23b64444794ecb8899ec164c5ce080ed40bbc4ffd86",
                JobTypeCode = "118fc7a16d79453a9cfef22bd70ee3a4d7598f34f2bf409e9b",
                JobOpen = true,
                MailTplId = "fd4c56798c0145fd911114fcf66c6eaa5f0a54d242404e0d9a",
                SMSTplId = "925bca92438445c898d6fb73b53eb5e42d1a0a7f7d494c8cac",
                ExtendedInformation = "082e1019c8974d3c85226b54ef300f3f709fe1b8aab942fb94cc1dea209a22a035135e903ecd40e684edd39557d6ad902ec83ab304ef45488a836479b430935ca3499e9e6a7941ffa0d28080dcfc90522c554279b836472787d49652ace0f845ad94fcafb3d64432948cd03baaae110129124ef5aad04187a8503cfdcf0b075f782daab35dd0416ca2b65114627e0e266de9a3f49dd64fa48837d22eaef51e1f0335db0f8f0d4276b5aeb6b8d9e1f812b1d9d9d19bc8425e9432435b22d661a045cd9db4a2c042999741a4c42feeb9d4865f54de5eee4c1f8ea32cf9ad76d30948d84397eaa240a5bebe5b52a7172859b146b39acd464c68ad82",
                DateA = new DateTime(2002, 7, 13),
                DateD = new DateTime(2014, 6, 19),
                Sort = 84490973,
                Note = "cb69888b1e224101b07ae09fe3ea85157bd0c6b233eb4748b10d91e2b2dd3f0b43d9fe79034542b1917a1530effedd7203cc8c62f7ae4a339e961c0df6b74667a065db8c43df462db173d712fe51cfca1d71856155044555a60ef86582b830f19d308366025d403da52dfdeda101ef38e75ff48a3be74ead97c7f0874feae8d5abd11fd8fcfc4d64a3f3e6e81ceb1bdf55004f95bca7401e83e0ebe195c4c359ebba3d8d802b42f4bdcc8db0298e1dd82949960b466243869229c0aecece551bf6cc2928d31040c6a1637632f2062ddce9578f13edc94a2fa818aa128d57cdc40af732dae5f34dc1a83b7820c4fa3ccd0b61f59190b84b5cb73d",
                Status = "fd1ca4aa7a104161aa64e281ffc11b79f1a81aca30f6458b85"
            };

            // Act
            var serviceResult = await _companyJobsAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("33d56fd8-4e46-4c0a-9c98-8d6d43543217"));
            result.Name.ShouldBe("cf63b4d23b64444794ecb8899ec164c5ce080ed40bbc4ffd86");
            result.JobTypeCode.ShouldBe("118fc7a16d79453a9cfef22bd70ee3a4d7598f34f2bf409e9b");
            result.JobOpen.ShouldBe(true);
            result.MailTplId.ShouldBe("fd4c56798c0145fd911114fcf66c6eaa5f0a54d242404e0d9a");
            result.SMSTplId.ShouldBe("925bca92438445c898d6fb73b53eb5e42d1a0a7f7d494c8cac");
            result.ExtendedInformation.ShouldBe("082e1019c8974d3c85226b54ef300f3f709fe1b8aab942fb94cc1dea209a22a035135e903ecd40e684edd39557d6ad902ec83ab304ef45488a836479b430935ca3499e9e6a7941ffa0d28080dcfc90522c554279b836472787d49652ace0f845ad94fcafb3d64432948cd03baaae110129124ef5aad04187a8503cfdcf0b075f782daab35dd0416ca2b65114627e0e266de9a3f49dd64fa48837d22eaef51e1f0335db0f8f0d4276b5aeb6b8d9e1f812b1d9d9d19bc8425e9432435b22d661a045cd9db4a2c042999741a4c42feeb9d4865f54de5eee4c1f8ea32cf9ad76d30948d84397eaa240a5bebe5b52a7172859b146b39acd464c68ad82");
            result.DateA.ShouldBe(new DateTime(2002, 7, 13));
            result.DateD.ShouldBe(new DateTime(2014, 6, 19));
            result.Sort.ShouldBe(84490973);
            result.Note.ShouldBe("cb69888b1e224101b07ae09fe3ea85157bd0c6b233eb4748b10d91e2b2dd3f0b43d9fe79034542b1917a1530effedd7203cc8c62f7ae4a339e961c0df6b74667a065db8c43df462db173d712fe51cfca1d71856155044555a60ef86582b830f19d308366025d403da52dfdeda101ef38e75ff48a3be74ead97c7f0874feae8d5abd11fd8fcfc4d64a3f3e6e81ceb1bdf55004f95bca7401e83e0ebe195c4c359ebba3d8d802b42f4bdcc8db0298e1dd82949960b466243869229c0aecece551bf6cc2928d31040c6a1637632f2062ddce9578f13edc94a2fa818aa128d57cdc40af732dae5f34dc1a83b7820c4fa3ccd0b61f59190b84b5cb73d");
            result.Status.ShouldBe("fd1ca4aa7a104161aa64e281ffc11b79f1a81aca30f6458b85");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobUpdateDto()
            {
                CompanyMainId = Guid.Parse("9cf51f8a-91e4-4d8f-9131-72ca82f63d38"),
                Name = "13ce23aca3ed442eb16428605e9fff95da75733e889d4f359e",
                JobTypeCode = "82f0d873e5b9493aa09efd8990886b40514f0334072d46d498",
                JobOpen = true,
                MailTplId = "e439c391c19045b09b502654c7e38075dcfc9ba174ee46cabd",
                SMSTplId = "d94393074c4b41889cd8dd4c3630afc02c048910149d4428a6",
                ExtendedInformation = "4c03f8a0cbc749bda709ca938657fb2c3ecd96a9970d4e209ff72758d753acf85d1e607baec140a3b1a5fc1182769ec2b1b8882f432a4456b01ae9a4886645e4693ca77a308443449dd891d17e1dea35fdb621239a5f406f9ad0d1850a661a528714437ccdf24fb69984504f091224f3a447bd631742446b8e15cd42a5fbcc0c22239aa50395426095721bec566fd23eace4af70f5134b189f055f056a4676a9d7e70c3d62714d50bfb93e1d908d20953e5a3064694b43e1baa2b91cfaad13d1353b03a843834515a35bf07f0a287a1d2c9b09a1635a43afb1fca98a7344692173823bb2937e4520a7ef4f47a157c22666d0ac2cfa13456eb5c6",
                DateA = new DateTime(2021, 6, 9),
                DateD = new DateTime(2005, 8, 21),
                Sort = 1390472422,
                Note = "a1de1e2acf4c4bc28794b69bba8cda92a90f2379bea84e158a619729b2869c4473528188fdb34024899f89cb3be086599137ce01e102493a971dcffd87f736f5de9a31e042c1458298ba8d35a1eaf06d92b5e119d5ff4f5b9b59f69bcc739c9875624c5f3c7341cc84ffb2b702b4fe152359b66f959847a5b267abc8d04be97d4494c04b46d044a59dad327a89a05794a0129bd9f90f44e8a83ad25c0658b9803593f3d413684bb58407915a166a3d8fc7aa379ae1e24d26bbc292cd8be70d1d163ef87604ad4dffb8e58b838e8e985042229451cc0f47ab9e644fa7df56638634c961b835ab436690fe6bbd8f3506f3557495d8c13a44169b37",
                Status = "b04734ba94d544809e012c58cfea36829a5907a94fa04259b1"
            };

            // Act
            var serviceResult = await _companyJobsAppService.UpdateAsync(Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"), input);

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("9cf51f8a-91e4-4d8f-9131-72ca82f63d38"));
            result.Name.ShouldBe("13ce23aca3ed442eb16428605e9fff95da75733e889d4f359e");
            result.JobTypeCode.ShouldBe("82f0d873e5b9493aa09efd8990886b40514f0334072d46d498");
            result.JobOpen.ShouldBe(true);
            result.MailTplId.ShouldBe("e439c391c19045b09b502654c7e38075dcfc9ba174ee46cabd");
            result.SMSTplId.ShouldBe("d94393074c4b41889cd8dd4c3630afc02c048910149d4428a6");
            result.ExtendedInformation.ShouldBe("4c03f8a0cbc749bda709ca938657fb2c3ecd96a9970d4e209ff72758d753acf85d1e607baec140a3b1a5fc1182769ec2b1b8882f432a4456b01ae9a4886645e4693ca77a308443449dd891d17e1dea35fdb621239a5f406f9ad0d1850a661a528714437ccdf24fb69984504f091224f3a447bd631742446b8e15cd42a5fbcc0c22239aa50395426095721bec566fd23eace4af70f5134b189f055f056a4676a9d7e70c3d62714d50bfb93e1d908d20953e5a3064694b43e1baa2b91cfaad13d1353b03a843834515a35bf07f0a287a1d2c9b09a1635a43afb1fca98a7344692173823bb2937e4520a7ef4f47a157c22666d0ac2cfa13456eb5c6");
            result.DateA.ShouldBe(new DateTime(2021, 6, 9));
            result.DateD.ShouldBe(new DateTime(2005, 8, 21));
            result.Sort.ShouldBe(1390472422);
            result.Note.ShouldBe("a1de1e2acf4c4bc28794b69bba8cda92a90f2379bea84e158a619729b2869c4473528188fdb34024899f89cb3be086599137ce01e102493a971dcffd87f736f5de9a31e042c1458298ba8d35a1eaf06d92b5e119d5ff4f5b9b59f69bcc739c9875624c5f3c7341cc84ffb2b702b4fe152359b66f959847a5b267abc8d04be97d4494c04b46d044a59dad327a89a05794a0129bd9f90f44e8a83ad25c0658b9803593f3d413684bb58407915a166a3d8fc7aa379ae1e24d26bbc292cd8be70d1d163ef87604ad4dffb8e58b838e8e985042229451cc0f47ab9e644fa7df56638634c961b835ab436690fe6bbd8f3506f3557495d8c13a44169b37");
            result.Status.ShouldBe("b04734ba94d544809e012c58cfea36829a5907a94fa04259b1");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobsAppService.DeleteAsync(Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"));

            // Assert
            var result = await _companyJobRepository.FindAsync(c => c.Id == Guid.Parse("5e824e19-49ea-40a9-9ec7-c51baa709e70"));

            result.ShouldBeNull();
        }
    }
}