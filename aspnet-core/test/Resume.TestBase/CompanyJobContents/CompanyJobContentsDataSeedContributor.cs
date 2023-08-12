using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobContents;

namespace Resume.CompanyJobContents
{
    public class CompanyJobContentsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobContentRepository _companyJobContentRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobContentsDataSeedContributor(ICompanyJobContentRepository companyJobContentRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobContentRepository = companyJobContentRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobContentRepository.InsertAsync(new CompanyJobContent
            (
                id: Guid.Parse("c37911ac-6166-4ed0-8c45-724c31b72611"),
                companyMainId: Guid.Parse("21e293ee-b664-4477-8a5a-281eec804f65"),
                companyJobId: Guid.Parse("3bf44163-0d53-40a3-9efd-7b47ec15cf6b"),
                name: "fb64089dcb9346dc84238ebcc7cae424672f880ad7cb47bab0",
                jobTypeCode: "2a65c9b486154ce6a69e5d08a999455a4b43d43fbf8b436b8f",
                peopleRequiredNumber: 1976885107,
                peopleRequiredNumberUnlimited: true,
                jobType: "e20e1af3a26b4dffb4eabd4d8c0d6246ee79b92e7cb1460c846b081d6c66ec20a1cf368cfb824c61a3db9c393042ce85951e12df3abc4f459f8c2572785a27ec4f1021babfc94dc9a20a8700b164692d8606970f5d6a484c99afaed07229bc261382393e",
                jobTypeContent: "2250a3ece9d14e809ccfe0c21c276e698795b3dd712b4469abce45f7bb8448555aa8",
                salaryPayTypeCode: "01d56c69db7d4a8bbc8549d0a3f08dd742474608eac045e69d",
                salaryMin: 1313403983,
                salaryMax: 1097102427,
                salaryUp: true,
                workPlace: "bd882b5136c7491c8b053276bcdb1d5907cb11fae97b41fd9c7b321077738c54c9c9438fced244c18375e5cc59486aac38fa75d97d844d3a8b41dd43403acf31bfec50a87ffe4abe905e40209f5d1cc661b008fab937445ea7761a4a2df1e1c59b132dee",
                workHours: "b2136af722284e4184d71736d94eafca5430c97ab49043eba2797fb8f63ad2525b7d710b570547b8bf2b713b78c2d197c0f185c0836543c28fd5490b7499338490e96ff965c541a8bf06948706b449dfd069b696a1984f7fb88245157d576ac18b572a4b",
                workHour: "c88834ade0e9463398d061ab7e81e6c84b397b29a9e34e6da48ab10b7638856b38a22a69a9794fcd9eff023fc42dd83b3e07dba1d939440da0456dc42e25875b86f043f2125947d4849af76e3e3f110c9b00eeded54a408bbe8c1dc02f87c5886a050050",
                workShift: true,
                workRemoteAllow: true,
                workRemoteTypeCode: "1095c878d8624ff9951cc2b42c1e1bbb0c477670b22745a596",
                workRemote: "0a8404f51a8e4833b4854589fe6282145c9b412135b743c5b86f8f3aa1683ed57f467c4672254aaabaccc3b31124973325cde0dc91c24f21b2743a48c6490bc41fa8534ed209420baf17be2651f48c75543b170d1cf049d6a9fb8be9a123b3c949b2adbc",
                workDifferentPlaces: "f6257508b0be40ae997aa35e3ac86a35d6d849f10d8b4c83a5472dd3e5bf3c72955f214183194502bfd413b512248d8cd80ed29476eb411caa6d5029d4e5ad067dddc6a48b9142398337b8e8912e637f299fa2020cff489a8c54593dd9fcb196bc64659c",
                holidaySystemCode: "e50dd8fa3e5a4db9882916ad80a4dc4518023d4c2f0a43eb82",
                workDayCode: "1ec18dcb3ef4447f84b953e80079a7791afd1761104f45f993",
                workIdentityCode: "7bfc5d9f4e0c482b86aa300d87754ff348631dcf4dca41629f3c48533175a7a5ff0bc5dca92e49d1a6a1330809da9d782d3dc6d0185c454781eb5f0f8adc204042770534804b41608b5998a766aeec1ebed2553dc32b458e99a1e28f26220adac898a916",
                disabilityCategory: "4eae9d09f4a44153ade5f33c8c455376be2747a2b04f4e46b8aa3aa6376f14773b425f5fa28847c5a8f44abdb6ed9db0d281475ee24d41f59a007070e3a01fc3e0769ee600724442b1cf9af4b8664796f5f9721ad7514d85982b5e255252f57e541112f5",
                extendedInformation: "75dc3e8db778418e89b624cd6653ee9f58f5ae28c3d945e4a34c0f74efe1e7c1820f0b6d5c8943dd9695797aa9972a7d3d571cfa46824eae8c247cfc15c3010197939a0a85094a79a7f5c75dd1aec55a48a7e6bd9dc2488b94b23e6eecdb2b41d2ea4753be4c4fe3813240e81e2e1ee7ef58e6af387945418f7d9a728bcaab7563e0c22e571c4f3d9c51a9a88dc14e6de69be196716e43dcb7d7182823035b5133d37fae12b342cea3879cbf98c9a11fd5ebf0c59418428590da950ddec8f2a0b7b64dd8ccef4d3397604d598fc1209e35482f66a8494bba9630c62db5adb0ffe82447bba61146b88e4ca91506f4da992c889e85a13a4dae95f4",
                dateA: new DateTime(2004, 9, 20),
                dateD: new DateTime(2017, 5, 1),
                sort: 493702137,
                note: "c32c0b1daac744f0b99f13fb26472fb16b59bce84ea3426896412df243a4286bb885f9816c3d429388d4b92bec17af68122bb8d48507417a900ef6d61cf1f7a08091f5b7f9554baa8edef494f4aca4970ed5edd7c9584b748fbad2364a6a797f4ee0cf001d294b7a8b130c588f28f53bbd890143799941e9a474054c60152b8996da20deaf554eaaa0dfb847fe36b90b7d49738ff25340be9f9aa2b658a430276b33f7ca9df442039dfc8d085c9042005b2e2336e6164e3e89fd2b8b6da2fae5370e94f564f644d2942983c60512e5b01f19b767492c4de29c95779bc57217514dd984e198c94813bec2d160984d6c72d101c724316142d6a2ca",
                status: "4c4340ed47f341b7b4bc891571ef307f677eec33ef2e4b2b9c"
            ));

            await _companyJobContentRepository.InsertAsync(new CompanyJobContent
            (
                id: Guid.Parse("57c9888f-e2d5-47fc-92b4-d61c535ae050"),
                companyMainId: Guid.Parse("28d77c0c-4a45-4119-8426-890e0832789a"),
                companyJobId: Guid.Parse("4887e766-e550-41c6-b59e-80ab2213faaf"),
                name: "3de24a046f8a4f0ca3e676fc7637fd4f34003dadcb644ec9b2",
                jobTypeCode: "998586b1f6524c768dba17691e51751001431b0bcc3c42cc85",
                peopleRequiredNumber: 350010876,
                peopleRequiredNumberUnlimited: true,
                jobType: "f2b4f96507bd4299ba7cec7a2626fd8e1e8c3bc76a0b49c0a2241035156bfce6d7920ba9b73a4983bcc14a678dc0525004ecb40f5db8487ca35fce926c5e5df08c0a6418a11941eab3ba11f340942a9de1e0d184007f48f2b186f1df20d27e4d1d3f89cf",
                jobTypeContent: "272bad0d12d74852b0f51509d5d76993de0fefdc945a4cf5a2b1496a8d728c9596132cdeddd247",
                salaryPayTypeCode: "a9610fea985f47d3b017284be0715452d587e0cd9af64f7384",
                salaryMin: 2036284253,
                salaryMax: 495999939,
                salaryUp: true,
                workPlace: "093eabb5e65e41a28f07868e2d66c88ba3934e716a1b4e7e9e99b3e8204a4c91fb6d0db46b50462ca2a823b3701415688783d75294ce422fbea0d437422faaf7ece4985b49754dbe859c9b6ac26dc3b94b45aa38b2e344fb92124abcbb0a78d945558105",
                workHours: "831c717c860c452883657c9dc95f69a9e45ec1cce0b149588cc8f6d0bec731336f12fb62772f4346a10841813d3b88dea9dadaa1ab884dc1844a48a02f2ab824070b29c2e65844e4856f5e2b39c26e9eaef22697c3524aa2b7730d6b81abb6db8f21934d",
                workHour: "9665668d6f8e460ab1c43fa76edbf5934f0c649460e54548b7feff45f4d60a378d7b19ff58a848db8dc2ad4ce99bcd88f532c5e2a6864f189a6f273d9e31483837325366487e4d478d058dfdcdaf81c8e732e1b5dfb94129a1d5b0e31d2cf278f6624d63",
                workShift: true,
                workRemoteAllow: true,
                workRemoteTypeCode: "233e7aefeba24dc785016e17d71343b9f397482d12844978ac",
                workRemote: "7271fed9adc043a789786847524051b5865f67797bc5464a96470d2cc90dead967a65d4d734446d3856deb2a6586ef73292e4b9e6f2e4755a2747dd173a96478b82f0262e62b4490819322ff991c4e7325bba6eeafea49208cab1146b98c4037752f583f",
                workDifferentPlaces: "b891bd95c5504e9c9c7da993c447aae55c7b1d653ff2415c8293f702181d2887d5b030cd3a8544d58e124facd55123b8c36523b0334741cbabd7ed8e337e29c7fea3ec08772a4d4581b7f5abecd402709ff798a9c41f4d6a9be8df174268b51a67078ec8",
                holidaySystemCode: "585a9d9044ee4df2a227ae53caa23de34c4d329d40bf44f4bf",
                workDayCode: "f6f876dadf3d4f2db0e0415a19ce3faa6faaf119ab6d447f82",
                workIdentityCode: "4bd20e366d12494783b415395b3f2cab79c840bb1eef4376b5cf80ea95e36ff320586f461d5e4382befbb44b3b21b601f248a059dcc4411cab2a4413584e86722701f30d6da7459a8d2e949b311d5d0e0fd227221b354f16ae28c8a9afb5a9b373db1043",
                disabilityCategory: "713b2a3312574c1cae1e82b1ae50dcff7e65ed4e196948db826b94b5704d48801cdac97748724d8b903cbea0605c33f558442972f32446b683a2cee02d2bd7b0edd1cebf7bd345d8a077e423c96e622c9b7db347c9844a36bf64812fc76872d7a7eb02f8",
                extendedInformation: "9098331e113f48b291b4aece5e88fe216664dac4f1ca4bfc8517e46b0d6d920cc830f3f04e154ec7b0b4879be6bc667a751821a82ad642c78c88162e5c02c74e1011501154574a82936af556fd6f52f447e9a78624b34cf3a03b7e8eada8eb98a3eccb44b2914f71a15d1d04b5da54edd07c862ba7644420a05c7a8b60fb845c865ea5c01b944d769f040437ef63ea46b71b7d65c70e4d128743cedf5f03dddc607807fc4451436097488e736cecc138c68191dc54dd40f8b5e6416e5dffed55ef3950ac416746bb8242cfb598d80837d77dfae6e47c446e8eb59bfa6d6dc26cfcc35005ce2042d6abf81494ee6500f6f70d57f9ca754c879345",
                dateA: new DateTime(2019, 2, 10),
                dateD: new DateTime(2020, 6, 25),
                sort: 354809157,
                note: "ea141d38d5d849149356a21762e8844dfff92a6745594041a905aaf5cbdc7a0cdd410c2be58c482f91b3e862db6e51d58147f8187b4f464493496b283b143903e353ef2e16e242aa8d42c96322d01b7755b176270b5f4af7820f53d0915e1b68733b0624bd574d98ab1d426638b80bcf3f770bf20926451999a369acb6a71d2a004ad404a7504f1b88a5001c941eee47084301537602470292fb226effb1951d97627446146b4e03879e22e84093b99afcdb60936ff04e3ead89fdd980ad926f640a3a74a069469db40bcc2985ef456ecdba28292c544248903bfd0889f44ea593d1c69eb6804e6fa0c4a8931d3c77805e8aa5e266be401f9c5b",
                status: "65917a77d67146048e5f2aa65b841f654592936ab30749779d"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}