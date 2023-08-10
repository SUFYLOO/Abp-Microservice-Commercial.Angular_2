using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareDefaults;

namespace Resume.ShareDefaults
{
    public class ShareDefaultsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareDefaultRepository _shareDefaultRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareDefaultsDataSeedContributor(IShareDefaultRepository shareDefaultRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareDefaultRepository = shareDefaultRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareDefaultRepository.InsertAsync(new ShareDefault
            (
                id: Guid.Parse("57057586-a15f-448b-bd15-907bdfc3f587"),
                groupCode: "210a3420456b46d0bd2d7955b0a70b48358602a1c3b74f41a3",
                key1: "f97ca2e6344544faa7c1f84439fa0c7addaebb81cf404a5788",
                key2: "7b5c7d205d95472f9b89fcffff3734fe75a938bcc74544f5a0",
                key3: "26bf85146b15486eaa53b7baf973a52fc7071547b33441c394",
                name: "096c5642f3bc4db5b06582cd389044cc56fcd7fcd8334bf4b91bd87c0533800cf38d4e2ab1bb4e0783978e2cdbfacdb256787f8bfba946b1b3ba2daec418509d561175bf831e454c8015da740f8ca61583a2436690f340cd973009ed4f05936985387c1d",
                fieldKey: "25ae03d865334533b02e65d35b4c7982b96ad9ae71714f11b9",
                fieldValue: "aa501e330ad64ea1bef50eab01cae1ee080dc1acb24d4e5ca60bbdd52735f401da913542e08c46f6b70e1a3d8e765cbe8e4e7a7f48c14f6685d0afd299259b2b7711214b91f3492aa0cc4ca314c5e4648e0b1f5f24344e8cb73d395232f00d2febf6282c06334f29a47d7190a1fe63f2cc0042316a9e4d2d8a0537555a2c283ecf13b224893d48c68e361313c014945c34f15e1ce12544d7b2e374ffbf92af6a78256e06da904f80a33de8bec0e67e0f69b9178541db4b05bb9500657be227bd3b124feda4c54ecf84f77e2fb3c3a4ae3513ea10e06145e4941729740fa575a3d7cbdcbe301a4c74b39925621479459ef0eeac0c2b6040e6bd17",
                columnTypeCode: "1715005a2ccc486a9196db39a9fc4a7b4fd19dba44e445cebd",
                formTypeCode: "ceac71fccd38414a9e1317afc7f512c230c58457adda4b2f90",
                systemUse: true,
                extendedInformation: "9551b7c925314b399f692154851c7ee47e8e438590d44b8586d0fabf214b69d3f255bd35589c49e19d8932e874c2fbbe8ca71b60e2ce4ad78a9bec31a788bc02b5d7fa3a0ed44e25ba264e3309f9c2fd2764750b5c194ddea9f18941f0ce76ab4f5bcbda8a9946feb30dca7d7f6771307f97e41275d64f6d98a9c5e049f500fa1e0dd401eded4895b9e955a263fbc9a2cf48d0e7899e42bd8eb7a274c27ff390526393ec273f4764849260528c858afc2f98289ccff64d75a4e95805d0bc661b0014a737c02149c7897c98c172aa61b86a7cc230cc484282a1261c5f1a8823e9a8b3bbe531454d20871e8415c722d887f1a1a96f51ef4aab8564",
                dateA: new DateTime(2019, 1, 25),
                dateD: new DateTime(2009, 6, 2),
                sort: 1943843372,
                note: "18e27eb3b55a44629a4eba31186c8ba61105ab3532c748cfb34b100edd187013b00e1453947a41aebd6cf9b11e0a96579a39515dfb2d4bd1bf87ff86e2b749ae4d9a9968a4d24f23ac789c591d56f67143b88135359f4e7f9c409982ca7f4bf3d368507d88824d4ea5d79774818d52700a370bcbacc044b4aec20e15ab29fd8577fa1f2a38cc4a50b95f6ad0bd09074061e6022ac2d546e58c06dbe9115e0aede4f5b78a3ecc4003a0cede7607aa0cfa918ac3f828fb4a4ab8273f788a18f0b47fd5eb65fd0447e7a4e974dc202068175fe30d581e3a426f970f850fdfe8cc938cdb1bae3746454f914ae8efe8b6f0b6348b7e96d29d4167b32e",
                status: "32d9f5492a0d4c51bdc911224e0b9036f7316491da384763b8"
            ));

            await _shareDefaultRepository.InsertAsync(new ShareDefault
            (
                id: Guid.Parse("78c25316-3cb5-45e2-9222-347b0dad6b03"),
                groupCode: "307ed8e7f94d4d6e9571634c5fdd8087bee3535133d5480780",
                key1: "1aeff186e8f64ea2b374416dacf342d6f8cae376611f4d8a82",
                key2: "5c10ab4f4ff14d19b6cc0fa06cffd6647ce55631c42949839c",
                key3: "6238eff982fb40faa608f8a5c72133b55fa89afdd99345b090",
                name: "bff10898531a4f93a8269c39d9f7b6f38655abd6fd4149b19309306f658033f40cca9c26b1a047bc91716000601d9a7a9a7ab529d38e434b8e0010263ea2487e9da26c95dfe842578ef0a48f8ba2a42556b58f82267c4e268a6f50fb8a6fa072f294ef3e",
                fieldKey: "209cbf4802454508be8543b4b650c8a87e16d182671e4e2f88",
                fieldValue: "9666cef615d545f4b4a05cd093f7ca1756d63ee2f06446299600d94d5b8b5c7c4bd881b3e51c4a79a3dd9d66cac2428aa837c44c7a5a4910a13251139958d04641d35ca2c5ce4d04810496d03ff51ce7d9fb1351ed5b463488befe65397b8fc031601b73781c4e2b819ae28f1ac633192c05bc5c694640d1a87fc205c9ae77b75b2fcb5b8cf542da80ac05cdb8fc6e4f38c7cc97b9b44b25825532f75d689ee93f1630891f49428dbedce4d8d8a5042d9442aecc338c44e9a7bf9fd058348bda71a61615f0d8405cbfdfb9f5177fffa1e39033d4b7d7401c965b62679fb82db26a4dfda77bb4427eaee4340f78b263cb846008f9fb53467b97a7",
                columnTypeCode: "10cb94fe4cb6415699f68ceb2b285c8318102d8370174b2e9d",
                formTypeCode: "767b77eb9ebb43ca8bad3e10fb53e1703b622039e985426f9e",
                systemUse: true,
                extendedInformation: "453d1e5931a344b2bc879fc00c8cec934e4be490c4814109bc40bc95faf262672aea3178ee884c9e8068274b13cfe32db426e13c4f654c87987c967cc85551580151c558d5864e4b8ae60728787ded5fba4ce9e2bbc743ab9a1cbe991f7cbe4841996895ade3497e9b9381bd6ab98e9ee43d8bc4601c459bac1b49562d623a07376394de816b4bb881e67803f9c583af5e498eee4fe749159854fec01199b5406b5523525d634abaa5b810037a705ba99ba6b8d76a304b2db90ea462a250c193b4ea322992214d0b845534ef7db13215a584690b2c9a4f8596e3dcec9f383edaec819143fd0f4973b0e7c0cc672c6ef0bd2eb40598d441618efb",
                dateA: new DateTime(2000, 9, 17),
                dateD: new DateTime(2002, 3, 8),
                sort: 1074535240,
                note: "00e6a045111549a19b99217a4a01ef2647733b7fc05d4d9e8886a6d507de42469296a33ccf4c4290abec30a0170e3e394804a73c7d2e4962a6dbf4301e92e41e156a67a175684086afb7666b88d0b3185d3a5f6e0c924757a34bfef8d6080664ab180f86847c4e2db8d999129b58b5cd4f18f56efcb64bf493f054e893b347fa964dd02e72384e07b80741b628fadd930857fd0d0b6c4b2fad91d1ea88e3c10bed79726095904fbca59c05f87eadd0779edc1cc94d204d4b94478c071e137aaf37d52b32f2ce4097ba3af185982b5174765b662ffc184eeda0fcdab6cb45471b34e90a80343441729f546d0f6a86fffd59377e0f10b047029bf9",
                status: "267a6c03fe16459aaefbeec5f3982c77072c0d57bde94588b0"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}