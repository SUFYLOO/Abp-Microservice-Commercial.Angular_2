using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ShareCodes;

namespace Resume.ShareCodes
{
    public class ShareCodesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IShareCodeRepository _shareCodeRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ShareCodesDataSeedContributor(IShareCodeRepository shareCodeRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _shareCodeRepository = shareCodeRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _shareCodeRepository.InsertAsync(new ShareCode
            (
                id: Guid.Parse("e045f4b5-83ca-4651-b318-f75c4e7647a5"),
                groupCode: "20286bc796a048ba958805781b95125103adebc6d4db4cd8a0",
                key1: "170cce8e7b9d4b5a95c6fbfca63acb6869d7208f5736469082001afed19bf86ed6316f2a32ca485fb50fbba486923146bd99",
                key2: "69939de1d9d844e5ba080742a72ccfa399fdca87360e4fc1ae47092b747185b6106d482c75b749b1b5eeb7743d33840c5c0b",
                key3: "c820fc7e140c43eaa446d2535a6f8ee0074cf162aafb4142b8071d430c07c176043b5aaa83d54e2c87af0a907648f329da58",
                name: "89ecd886390745fb859f81c3581613480958c9910240427a9229fda77095f98595fb9cc12b434219b4b2b619408e9a6e81fd",
                column1: "63b4cce8f9c74150b10f2ddb0226535c742cf552d52c4e63ae",
                column2: "4dd48d2a6546493cab0044202383aa9a5fdff8ae2abb40eab2",
                column3: "7ea409baf9ea44189e674eaaf5f4b7d2163d0bd0cada476a91",
                systemUse: true,
                extendedInformation: "7493d2cf0a754871bf13b104161835de0df8e089f17047f08395fbec93f59b36ff8e7fa10bab41f7852679e0b84db6eafd8eaf58e1ca4c72a6682878c981dec3ef6b92c90d9e4023a64c916b049d045d1030859095a741bd945f50f52437c84b15b2b84cece1461688e0fba1fd1ca5c2b3f2bd69ef5b47e19e708a5f950b252686107e7f83cf45b0a85507642a3d97c3eb47b4b140e24b98a4c2379cba7758b48ad5d9ef5af34ed385b2692d2a494ebaa13b6cde2f5d4ecd9e31a39ead2a1de67c486ba7a9d34190b77a15d6300e081060311075f33444bba653a606299bd236b8c1b47ec3c845c4a62eceee17a375f750b09d9b4ef243dc84dd",
                dateA: new DateTime(2003, 10, 10),
                dateD: new DateTime(2005, 8, 27),
                sort: 174622182,
                note: "61e0464c8a1a4eb48821a8d5a7d33dd616daa1fdb7394316afb25f73d5736d1d502e5cd841604d92bdb1ef9756d3dd12d46341fdec464776bbbe094550f2f26d523d2e689fd741a482c290de8d075eb0a6db3a75857a4cab9f7b78a2504af52b696c8232b2d5409e9ed10c011146f9e390b80fbee2e8460f85fa41ebc75dc8f083d7cb83b31745e6ab01637992ea5b9dddf5c872d376456fa4696770fca3573bda8cb5c8c2004c3e9ce89dfee45b45a759933bdf1dca4a2b9210fe4fd2fd7b3872279e5d83d44016a02472ccedde4c8cf54e9a37a40e468199368288367f8d4f316f4519280d435aad20f636ca7ccf66bd1f29fbb1d74e779866",
                status: "8298f16116fd44d3a3851063b2fbb11e21e6f8af1340449a87"
            ));

            await _shareCodeRepository.InsertAsync(new ShareCode
            (
                id: Guid.Parse("a0c2fb89-d7ff-4b5a-9dfd-57dc09f1154b"),
                groupCode: "94c163898fec46c7b7835b381cda8285138fecd25eaa44baa7",
                key1: "abc5f21de88147e8ab2346b1da031894bc687306dec14a798e52dc22719d5b7ab4ea1a14036e459496a4c7adc05b05ab303a",
                key2: "86bbd75d4f08425db8f9917d46d5bf2caf2a1ff2cf914ca8865cb568a32203f8ebbd9de4d93a4bb5830c68633e2e665a8d20",
                key3: "91faeece89554cc4bc331364975c00b10b5ad1b42e374c72b5058cd821b0d20e1734ff36c21f48b38195b3dab612f2fb80f4",
                name: "1d9e711fa3314e1ebfac08cd2d1745e0d814a985a77441669b15ae3216940d7c8cb91241e3ff4890a7b0df292b40545b97c4",
                column1: "d1a4f4438b494afbb46380be42c75a4a5472025fe08a433e80",
                column2: "4f1207de8609425ebbd0ba7f761915b59660e812c7cf4d4ca9",
                column3: "f86b72a1b6cb47e0a5177d4a32a37212d28877330ebb4725ac",
                systemUse: true,
                extendedInformation: "b125b3523354494a81af8ade40f36757c19d7bc0a70b4c0592f57df28fc51608bc3539b01f6644918a1fcb44b17339d077e7f2a8ee1d4471919e55f52f70706a3a24aba8abef4e5dbad3b36ac0f4b0735675a8881fd8448d90b298307d4c9996cd4583427ecc48cfb7d44c8bc1450d830ed2ef49b4cd4a408dc486900fb89526dcb0d7aa9c834e969f97d458febfc778347f6d918262486aaed20c0037e17be299886fbb881246d5bf5882ac6315360ee8fcfab60a7f455395784b9b5cbb02ff076fed1b7dd84cc09c31dc7cf4c8da5afa71666af0834cf68432b6c9ffdcc13c4881836ffc2841fa8793dde6658a571eac13498bef1d46ce949d",
                dateA: new DateTime(2000, 11, 6),
                dateD: new DateTime(2005, 1, 19),
                sort: 1432424696,
                note: "fce5d73087714336850bd80afbb5ad1eaed2dc7696224109a6e8c2a8e902028e41973f95d5c141b79f4e44bd71ffffde013ac06b1be045d0b5392cf83a550e8d7153b2d8bb3e4d789c18a76c80474f8472d5db1a9b014701bc6011dc39995bc14f9a415e410943fc947a4594bbe8dfa4ced8782435fb4c8ca51718baec55ec7d17d640262b4e4df99311711e3cdcc07d023874c1e0554f45ab5c8fee4c07cda593e3214582aa4ed885c536a704d57e270ff120c7c09042ed8f036583012400f502f000c831724d2091cbd684eeaea564074abc3350e34faa9d97063442a5e22dca41e7230e0e447680c2b3e04c40caced03d4d814d664e1d92be",
                status: "a12699822b2345c7b27a58cdf376ecb223c553a399c14adc80"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}