using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.CompanyJobApplicationMethods;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.CompanyJobApplicationMethods
{
    public class CompanyJobApplicationMethodRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly ICompanyJobApplicationMethodRepository _companyJobApplicationMethodRepository;

        public CompanyJobApplicationMethodRepositoryTests()
        {
            _companyJobApplicationMethodRepository = GetRequiredService<ICompanyJobApplicationMethodRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetListAsync(
                    companyMainId: Guid.Parse("a532ad80-c51b-4112-be38-0f53db409246"),
                    companyJobId: Guid.Parse("3596213d-1f9c-4e6f-8bb7-4228074b2d57"),
                    orgContactPerson: "37d59a0646884190b04aca5f7faaf3d150298a8ac7974bf1a2",
                    orgContactMail: "f2c8a90292f844ada2f27bb4c4b5035296bccd225e7741358863b200dc73f7e040d82b613f6d4fd18b742ba073aa0e57aeafb7fbe8de4f09bb8824afc16d40ea39c01650de81449caf70bacbb22635897e4a0d8b0f5f493d96593052ee6f4c52861f82b894cf4ae5accbadf11ec822d303f97644d5db4ad4a1162cd434480ac888392d6f889c4192b2a94f8f98cca8f6539f767f5f034d4982936bd2399e1e5a1dd235285b03474bbceb80768e213095a7ce7692abba41828f576a5cddacfdb6704b62b324134264a7baff06d391544b4f4837d9ec884c4eb8b63cf876517490a191ca990f9c4932abbfc52e9568a08434514a51bc184086962f",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "a1e5f96693054caa9e4a9565c9c270c486c4e178881d4ec7bb",
                    personally: "6418644443814ef187c3c527a994acbd0ba14ce3f79d43f5a96bca7c72392c2867612dbdf7d04351897a85052282c6cbe5d696be35e249e8a4fade088dd9df22e9cc0b6bff1b4414bb041d25e5e434af2123b24c73db43a1a54943f941932ef958898e1d",
                    personallyAddress: "b8672aa6bf714ab9b406a08cd6b593d84071113da25d4a70beef8a3d6d5303bd33eef20fa130435691b54d8f34bd7098b69ea0cbca854c65a262c237284a018a5b34192a213345bd93ee3310ed4f36da7db39f09de184c0a9fc13aa7d9031767310c38c9",
                    extendedInformation: "cee9159ed37548528f792cf00daeea9b770142a8b05e414c894f709891d16d77d078481afd5b403b83e078ca962d38cfcf39cbcdf460492bbba2e1ebee95227ddeb114fea7d742219527d3589be1c04b71cbed9559c1420294f947681cbd97f2f84fafee137447edbffe6405d0f2ccfbe2379c99c86443c59344528d4f81ad9de92017fce7dc40859570d3ba085102eef5cee96c6b7949728f63d068bc43beb786f98c588bfe4960b7951925a8e341bfde8b92dafe494e1ab65b07beb8879a59e6d5cf0fdbd149c694cde06abc02dc177f48bfee7019418ab8b935e68acb2a448c674bdbaeae4a30bdf2f9c3d4d54eb713fa4f3d24704c0eb35b",
                    note: "d9764567fd8e42b7a0398a2f35c7e070b8015b8bf3094eed82912a27af37f8003cf40f148ab94981ad0021edebda02f1485e6b73063949bc8c982025028da112ca561a83f1d1459eb0b67c98bc20916ee842a16d782e42d8b7eab9add80a9a0a259d477d59014060a81495928139760555b0cac8285f42b5b65bb24e2f5c4bdd1887feba528f450584800c340751c12a566bc95fff45438d94c4d9c041eddd50468c7a84ee6a48129aeea9948561703297f69d6988cc4bb9ad2724f99d2c7d69dbff36f4b9d84ebeb01e4570f8dbd6c625dfbbe13884484f85abe8a567b28d117723b65c9d39421ba96312cd6c8ca7caae296b544fd64d2fb5ad",
                    status: "b870da3c97984faca190681da0a65deedc897b7237b244668e"
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("efa1f844-242a-40b9-8484-3f0dd2fb252e"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _companyJobApplicationMethodRepository.GetCountAsync(
                    companyMainId: Guid.Parse("3a84011b-3454-46a9-b904-bd689924a9b6"),
                    companyJobId: Guid.Parse("6d96f365-990e-48c8-934b-f7164a0c26de"),
                    orgContactPerson: "c1e5abbdd45d4421b5b056e4a06b7a5b63bde1d6617a4376b6",
                    orgContactMail: "c9f3e71ec8ad4562a0ca287bc39b7dcbbe039a26a2b04c7e99f9ec415fcc9c2602b435f1eaec49b68b9d38d25195b776a02ccd982882400d87992970a94d2af5c20b6519d0c04d8ba861b7b344f9ca2384f48a52fdcb4fa0a2ecdaede37350f3740cdc89b07549b9b8af4b3f23f252af23c9900ed08b491b942fa4adc415c57f8c6ffac9b8604a679e54e98206ccb9d0932c5a2bf2624d449f1f54d92a1c5524e553225a50154d1998f57725de257dd1992523137c8c42c4bafa8acc36a07d054ad4594cc3214da2992f9ca6c9ddc919fae5294c634144eb8e8c6ef754f2cd68a76c4edadb814972b9f0db04a83975a9450476d4d6c145cb9da5",
                    toRespond: true,
                    systemSendResume: true,
                    displayMail: true,
                    telephone: "2c949e85393f42d8928ce7644ec9ac135eee9d03dda8496bba",
                    personally: "a27e79c1ad3d49eaa1515510915a059fbc4edfad52604228a73fed0b878ff1209da3da25c2004b87a013b08b908e9620bf108cd6aa764cd1ac51a05e323ded67b0dfc39de2cc482db3049e716476b6a1317bf5b719a048cca78ebca07d54bb053039df82",
                    personallyAddress: "3e168cbb03024517be1ba7acff67f85a9d228365aee8419281c6b7d64655a01b9230c64253c94b83bac470c29c0c4383a14fed2f61ec422b9fb2625b05c897fcdcf2a2d8ece7423595336ff37383c2076fc4b2e206334534970010055ad9b3cb455663fc",
                    extendedInformation: "6c9246e92b5345b5bc6decd215d2788ec0342614cd404bf485349280e74f1d857f77c130a5904b5a85aee4cbaf6954fc45ead958e1394a95bc9871359a308e199d15864e44024e8fb4fd2521bb30634aa185cc93ba67451f8a5b83c1138acb185c3f634a74194fcaa5ec85cf2385be5175e7212d4ebf47fe934b118d5e59899546a3960720e949a98b81b5d813b01d391ca051cad4304a44a12b404b487dea9f2bb5832bd4c341b29a9931fb559f2f4290334da3dc004124a4766b64fa4ed774a003e88dea7a4f4d8c7b790410a0a05164e4338c8b8d4657b518c233a7cf42976db6c1a2ea174930ac49d972538b70f4faf376082d0f4e66bc68",
                    note: "8cca7bdb8dce4a2988dde73eefdeb928194542777ade4ecdaaa19110c997c9b38abf4d449c3f44ce8fb7bead0b14d0065c95b194b0284797949440f4f12c6ade844f9d3273c34a80b0272cb8f4e7f9c95f17bdf8fa6a4f0e8d366ea441b7cb9d5457209892c04d11b0597f2f9e797d9faf70841e1a2a40019816a76f479d8c36f1698861547a4a27838ca12763b3f9a36f5b934abf304ed3b62b68eb5be440e68b413e7a59f642a6b11fd7359092ce54179d6210ea8b473baf2ab9989f0d9cb1ff1d9555aad34baea5bbc085b69b3d5bf879d4b1488544859cfb4504bed1d381aa7c60954be74183b680f63c21f52bea215ffde7bef542408c7b",
                    status: "c2ae4d9ca8134c1dadbb8bd52aba66f999dee573d70242e38c"
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}