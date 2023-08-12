using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserTokens;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserTokens
{
    public class UserTokenRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserTokenRepository _userTokenRepository;

        public UserTokenRepositoryTests()
        {
            _userTokenRepository = GetRequiredService<IUserTokenRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userTokenRepository.GetListAsync(
                    userMainId: Guid.Parse("d8b73cf8-8ed5-4480-a46d-2478b1d089e7"),
                    tokenOld: "d601d0c1c3d14050afe19a6a7cc9c73956cbec92e4974aef8",
                    tokenNew: "ed679b7d7ffc47ddb0a2750b6763cac44740a0d6",
                    extendedInformation: "52104740124c47609289c7283488b63ad8ebb10a487444c5871e890bf584607fde9535ed9dbb4b64bf5cce67a65ec8e1ea164248280248e8b6d3efa48e33be239acb775835314fa994e8cfc3de66746b6da7e9093db544a0851f3c57ca61e0855b2fc1dc74d24fa8baef6ae49edbb81aa168146bbb5a480ba0a0da1d3657ce1ddc8bb7a0a70844b580de36bcecbf10f9fde10c0593a34dabade5689191f459d6bdc10eb618b34583bbe021667384216a8b5aa4c7755c46bd88115f049a852dd87be29ec06c534a058fb46e83c75a6b31d791007319ab45c382a46487a6d4bb00cd1e3c80419e402f822d81a5535942a5c8080c03a3914bf9989a",
                    note: "8dd1ed1924664a7095477aaa3786aea0189a60c032934b08af49649b0ed608795e7d6d72d524490faf8743a0ca79a16ff0a1b6e356564e08ba53b50e65e5125706accb785ceb4841b0a77be2e37dcdb7b5d6a0489e364b18aceda279080b2937f2c09a9c415b43039f17d034d43a221f6cc56a83992449bdb7067049f78da4ffcb57380225c34deabd436ca803f8b3a519868f27e7f540288dcfbbae7ef9797588d14092250f4dc2ab9bea6441f4d066b409e59bcdd04d588825597f30bd0971b7052f218ad44647a745ff7646d3112c031f82af50de462f8ae54f1898c3975b00fd9498de144113945a1e6f9c17e910689f008bab4545fb83a6",
                    status: "348f0b93aa294335806202104b4945d5218ed91471aa485faf"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("fe972314-7be5-47c3-808b-19bc06f69c04"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userTokenRepository.GetCountAsync(
                    userMainId: Guid.Parse("7a2444ef-a52d-4eaf-adc6-35b259cd8211"),
                    tokenOld: "2fc5d970e2f04233b5ae7",
                    tokenNew: "dd0b6e1ec9eb46c4a058db807b6cecca738de6130dd54254bd689",
                    extendedInformation: "7a5790f440a14c5e91eed2a2ff00d326c634e3c0743344e7b5cb36e058b2d5d2ad93a6361719437081efb95f805ad62def89c793f79e4433904b61163ca72baebe35ee6b16fb4d37993be9014cf4b253547511619cb84ec8955029573a36104415355299380c40009a9401663e32f5bce2e6c21bdbe640f7af7dd5c9f1f8b97d3388562308d54a78843ff01d22c11289c4603fa9cd6b4853ac68b4dd849ffbe29b37cb1c39f64ac7ad80170c813774b1d4382b70824d4da6808c1b2d04a0630f159202a3b8e54f2e8d1caa69c6bb3c601355089638cf4932b26c62e2cdaecedddcc2b66db7b74a6aa183137ebba7c4494f21b68fbd6445359a1f",
                    note: "81129044b680458bb8b1817d0511b107f5b036a2a6f24707bd3ac310517bfa5abf8fa5f20751483e9656a626debf3511ca6e3834bf244730b367c068da26268c2957761788f64aea8883f7d27d48f941b1e977c1bab94d44adb66bed7d396100cb5e3b2580e942488781593c0cc658ef7cb38aad157544fb812b19554bb969f3902ebe5c419f45159f815aabf1be2525c2fb6d7881a247a1a24e1dd3a40791cfb44ef592e38b40b3b14631d77e4f44c898e74c7f6ac14bce98fce57eb2fb112fba0dde05785f4d9e987babff1c464a931f85c8dbff5140b78b1b09ad5a5e2d804754696805104d1293f1b28c3749c673af51ec49fe31408a9c2f",
                    status: "6b8518df1843458dbd955f8cb45a54c3bc5672e474b94e9cae"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}