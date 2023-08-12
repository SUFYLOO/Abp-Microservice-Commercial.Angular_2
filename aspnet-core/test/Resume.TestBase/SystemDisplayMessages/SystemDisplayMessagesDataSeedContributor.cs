using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemDisplayMessages;

namespace Resume.SystemDisplayMessages
{
    public class SystemDisplayMessagesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemDisplayMessageRepository _systemDisplayMessageRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemDisplayMessagesDataSeedContributor(ISystemDisplayMessageRepository systemDisplayMessageRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemDisplayMessageRepository = systemDisplayMessageRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemDisplayMessageRepository.InsertAsync(new SystemDisplayMessage
            (
                id: Guid.Parse("4b3fbd80-5d4b-4992-b53c-30b0233ea672"),
                displayTypeCode: "27fb5164a14a42928caf164c0cf78fc79d2667defed040b0b5",
                titleContents: "6946cf3fdbf04d99aa953fe01eecfb0aed2e63843d254663bffed07e55cac585d97422c240c74717b88a31a8aa5448ce621e8f8717004f8f9d24b13abbe599f1f302db140a6b44b08b5eb8e859499de34d0bd3adc1fd4f048a2c0fe6a2f2593938df334dc8f5489fb36585db29589a1515c37505820841e6a1863ed53c930ba5540e323a24364189a8826421f4b1763fe8193fa457384b62b475fb0fe00c4a144fb2568d62834acaaff3c6cbd5c7207553b663171cd04bdea19655e6258f3352c155011e03e148d6aa50c44b16da05cb3482a25da5dd435da98d7e7365a2d1d854a8c99b561f421b9e6a84b287170d7f4b99778290314747a524",
                contents: "f6705cf889c6416792c328d4aeeede185d44af29483f474c9fa8b1464ca24d721dae65d0ea2945358bac07f3b6c8ca7b36b7ad3c94954d889a0f8305f58631b5c246fe9f9ed844109bceed01f1b090bcf0b738b5986b49cc94298a8fdc98c1839f557a984b37499f80a0ca5aaad2ebaee17385de40c34f5d8a39b19e9c6c59cc889b26148e604e52b37dfe6de929e8e897d1123cc17a4fc89f3fe4cfe4e62c112def90e187e64b028bfe636295cd583cad5dc44da37c4c4a8b45cb20d4de23e3bb01b7aa670d4e1ca77f6ec073255cd6ec018f47bc1b47f0a5aeb1f2aa681b0a15827f03ce88490ea3484f4987d053b819ffc44f981e42c0824b",
                extendedInformation: "b589f026125d41bda5299c9034ea7ba566e95c41a59546f98a58ba89fc2c92e748f7e1f75c03495e9b592ba90885d2fee73b34631fc548d199276db59d1e58ae1fbe921d39b54e03894ecd3ebd054f578badbdc05b8240f286486d3096520e4343a9c274348c46c581aed8638c3cd825ac7e1e4d183e4f3da7da062f531d411a0572cd6b0a9246faab64a59aa8e14e23be62f5266e2b4506a0d1dc8554f3c465e415136b2b314de3b14149a32652807e0bc80887615746ffb1b1728d5549d8a09074a1d9a4ba46169b5d7645de14d0032571d7374b014690b9dbced99a71495df208a39e22e44527beb6c43efeb2b3191851bc1499b44792bba0",
                dateA: new DateTime(2003, 11, 15),
                dateD: new DateTime(2021, 3, 24),
                sort: 2111864740,
                note: "654c279fdf414762a3e1d80abd2c343d89e4d9bce77f4b00b0d1e3b0014186f3a166bf08ffe04f0e9ad2f77b62098048b8179857c8564b6e806650974fa5a4de84eb94d42b1c48e8b87c0178a9240df144aed7fe3e784af791400a55236a5ad7a185bb53b8444e028d947f0f48a9571b2a48ba38fa754894a99e7ebd24a7e92adc5ab056c29e486ba102d7554fa3ecb2128b1c48afc74a09b22da75fec5d301dd6c298d92e1a4b5bb7421434905f543b49ee0966fb7148849b04db26d01ebb2474e247d196b64b088dff853d6d97d25d837a5a0b445847dda46a57160119c3083cf66684ce774e058b8fccfdea06138c8b4d3ec49ff64b56bb34",
                status: "36fb89f4a934407384ede1ff94ef02a843d5f0979fdd4f268d"
            ));

            await _systemDisplayMessageRepository.InsertAsync(new SystemDisplayMessage
            (
                id: Guid.Parse("8ac6c11a-d263-4d5b-9855-5541162ed092"),
                displayTypeCode: "e8169a09764a4972b055b0fbd1432a215d3adfe1b3d5497ca1",
                titleContents: "a1951590ce614f8a85c7da3c6f39459068e1461b15234c20a07524c6bfc218831f3eb93abccc4044bd5e9b14baeea2a2199be4a8e43042079c700770cda0aba60825d749a56a4b0e8089c1fbaf52920005a36918b29e454491bb80be70956989ba43c06e53c940f2ae86974ebd1771a90cdbfc8fa63c4862b194262b02bd39328d77db19acb64932bce22ea1440f04336548b53054cd4465a26ea69b471f3e0b79a5cf29292041dbade04a583f57f2634e03fc2ec8fc46eba1a88d85320696eb8cf9c40a0a4f4e998346dc04f190878f7c102ccdf9d1454cb20e5b9cc057959022a9989c0c9148598dad0e08794051d1e4efbbde10ef49c9a7d0",
                contents: "479d25f49ca74459959a023ba9b828b88aad79aa11e04c5798d95bdb5e9bfa69ddb4297af6324aa89bf0c30caf66d2a197fd52177acf4be480679c5278684c521365189abc854402915673d8984ca65f63b6eb488b184e77ad26a12f463993dec10d2335afb148d8a91555ccddfd111c06a6ec42c5124a9f98f8be78f7fb0b4c25c663c572e64316bffe368022e58343822f4bfbbe7a49dda230dd433aee4d828e8d3a31a6d140ad9a4897afed39a1bbd6006a2ddfce49b2b73c90aefdd27ff34d5a37016b1a4228bde3ba0ab1ef5e59fdcc193b11944f0a898627533bb59dc8bfe099c06edb49b29daa5e9f126194dd5074b478a588423eabdf",
                extendedInformation: "96cc583abbbb4a47aedd8f099ee46cfd6bde9ede7f164cd08222734fdee9cd829360dae837f84d0e9fdbecbaebf4b42df90cfc2438a543d09069cd96d0d9ca0d9343b653024540b8964754b58281db238437e769c70144d0ba245ad9113f36f34feadccffd584c3b9cdea585f1b3c04b614b63eb85584b74b9f7af18582beda51ab2af736ca34ccb9e9190c467b6fc000c7b4f6040514ba9a5bace17b8725c6c5b2e15c6d2f14075bba64fc5ef511cfd18c58890af204e19a4abc72c7846a828dbd1e7937f0e4940940b12a48a2312051738201d3a864522885d5a48644769c365a9944c292345c18b0695e78d8df90ec25bc7eba5034e22aa44",
                dateA: new DateTime(2000, 6, 24),
                dateD: new DateTime(2011, 5, 19),
                sort: 1413667545,
                note: "babceeb0a2564d5c85bff7d3d9fc23f7243d8d5a74ea405fb00c365e74311104d8d11d796d6a49fbba96d09e1dfb1b4f0001d9d5f4194b928078d645d7a894d9317278e2f4874f669a6d414c047e5525786213331e444317804264c97220ec3b5466458a60894eed814abc0c08ce51f9755e91d66f7b409bb07390ad311fd7110fb1713750f8402c8366da85933c22d2042c0e4d18724fceb312ef9d9e3c2359696aff2dccbb45e9a2b4271fb19a33fb386cd50f44ab43a990d5980172adf33c1950049e5d5348f499710ad8062e6786cc4ad11171e1404d941efac96ffd66d346a0ce9fc0e8415d9d91465076b7357af9d66dfe23f8429c9c4f",
                status: "e6440aff713d49d680a3e3975ccf553f242e56f9334c48fdb1"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}