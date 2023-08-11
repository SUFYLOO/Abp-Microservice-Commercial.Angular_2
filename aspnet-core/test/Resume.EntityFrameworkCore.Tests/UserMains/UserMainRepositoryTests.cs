using Shouldly;
using System;
using System.Linq;
using System.Threading.Tasks;
using Resume.UserMains;
using Resume.EntityFrameworkCore;
using Xunit;

namespace Resume.UserMains
{
    public class UserMainRepositoryTests : ResumeEntityFrameworkCoreTestBase
    {
        private readonly IUserMainRepository _userMainRepository;

        public UserMainRepositoryTests()
        {
            _userMainRepository = GetRequiredService<IUserMainRepository>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userMainRepository.GetListAsync(
                    userId: Guid.Parse("7478053b-a3bf-451d-82ba-a6b2ee673d18"),
                    name: "3ed21f6aefdf4461a4827037f7c783346e404358b49246b9a9",
                    anonymousName: "2e18af228f0f406ca12c526ac780ed7124f5bc58232e468a9a",
                    loginAccountCode: "8c35c1385ecf413e8047f485d88ec5449c9c78695a9e44199e",
                    loginMobilePhoneUpdate: "cabf58183cba4ac5aecad7d26db2832f9c1444008cd347cdaf",
                    loginMobilePhone: "0a830a4b43cd4cb08db0c52e7b6aaffb91bfd71e62894b608c",
                    loginEmailUpdate: "a92ed1048116402c9645b82e15f7e1c25a98ee892b7c4d10acb754d659244e0b0cfef58720b14b26a25863e477b893eeb0a4b1d39cdc4de7aa87879bb7aef0938260998004cd4ed5925b3f6b54092340bf83b32fdb7449d599fde30e25b4eef8e3a88533",
                    loginEmail: "a54a6439fe184554a1a2224d13443c71017fafe74d6842f3838f28bfe0fe43a5c0e4254a20ec43bca6084e2192ca4e52dd31c647204f40bcb480085e0df36fc4dbcb218cfbd24b04b3e2822e0de82fd4d3256005b9984fd6bcfa341cc9e07ce6ffdc7563",
                    loginIdentityNo: "12944b7c08b34e40ba8065b1158b9abeffe8dc145bb94dc888",
                    password: "7fa8d0682b0c42bdb395d6ee77c033a9f24e32661c3d40c6bd800d98b303e5c72a824f5faecc45faa882e443f9ba9cc806d0644e73ab4d939d4fe7cebbd29346bf760bff221b4fe5b1d35040f078430396831ddd892940b7a01433e62238ec88850aee02",
                    allowSearch: true,
                    extendedInformation: "76c9f41296304cb5aa52edb3a147dabb8e934a35d77640fcb66e59a06a8423c18be5b3ba3cc640cf99648ae35fdb48badef4b988a799450191d036fa2da46a979d3b0287ac0541adaa796daf81481e06cbb625376ef6495fa78f96bdb91cf01f0a158743340645d2b7a268dde3fb139f059ba0b66eb948b18188c07395ee593e602471e8cd2546f08201bf3de8bda5bd0722f78c1f5e4911bfb27b5f6c6ee85ebd712cdfb6e04e38847053a798a2bf2e60f77340eef84938a576785c3cdc7188161c35a727f4406ab40474382fc387a4311189f8718c449393982347724bc55a7f3260be2d544e17b55ecc0927cf4653287eebb74c1844f09d50",
                    note: "85abcd1e078542358978db1be3305c95882ebbc56a5648b19918cfe9fa2719123adb2f7c5af1486098943201a113e61652b4b808b04e422b80b0af2adacc5ce5405f96a8874a458baae56738e3efe33a7b98fa6dec874e768a66c0fc1efd5e01528df8f74f7d4d4e9e9ab6555bafa7c727db79411dac4fbdb723f13ac33afd1f6cb77f8017f5460985bba0c9ef981a980ca397aa5cbd4024a53279d8f618f30f410e1db413274bfda9a51cadb628d11f3245e2aca9b44dd88e36e8c1e4c2bad64761c069cc2e4d7392fe4b40c73655b1ec21df214c7a4548a5f85cf5fedf4780f9ac15fa76ea42fbb7f332115123307bef271fe6e7704e809e96",
                    status: "faab862cd3c143ebade542a0405e6f3cf009ca2bab5c442eb2",
                    matching: true
                );

                // Assert
                result.Count.ShouldBe(1);
                result.FirstOrDefault().ShouldNotBe(null);
                result.First().Id.ShouldBe(Guid.Parse("ee94154c-0556-4e0a-93c1-f28111a9ea75"));
            });
        }

        [Fact]
        public async Task GetCountAsync()
        {
            // Arrange
            await WithUnitOfWorkAsync(async () =>
            {
                // Act
                var result = await _userMainRepository.GetCountAsync(
                    userId: Guid.Parse("a8a8c879-b0b1-49aa-b7de-6ebf5be00c00"),
                    name: "0a61395c599f4537800d970975631651e920e34699954487bb",
                    anonymousName: "b0558667ff7e4b18907bdf419e26c488776b0c8d0989496183",
                    loginAccountCode: "824b121a2b594d729c5cc3f93c662c0f91134ebb870d470780",
                    loginMobilePhoneUpdate: "4ce94c53b25b4edbb5e1e1f4958690ea8278ac6c1bb34920b5",
                    loginMobilePhone: "a2ab776f2ecd4d6aa010a835363c0232278d3278108f424792",
                    loginEmailUpdate: "7afcd4c4645541dbbfa907ce2477bced952cd9d500c242efbcb72c24100542db7be67935eeae4ab9a307886087e829c6e64de9ee8da04d1a9cdf85e801d63e34682cd6c65b13484798c79e1d9180095b8fd15ae1934345139dd596c5e906dbdd2747d4ca",
                    loginEmail: "8b0a599edb4e45ab8cf885452f0c5520d97e1dd9ab524338a06894846d2deb682a1e3aefbea743eb8d1ec0eaea3e8099b4f69cf6449d49bdaf142119e1c1548866efe2bfd12f42f9960f1caeb62808eff6f97ba9f9ec4e838f4ab96af277c78aa1d132ed",
                    loginIdentityNo: "310e509c8e9f4aed916d22cf23ee90dedd016931bfc242a28c",
                    password: "c11a1c5a031941c9a6a0ebc805addc6070ad9a5d45c5421b9082300ed2a6d2b0eeb7532661cf48e5b8a53ecd35bb2fd7fe526b6f36dd414d842a1a3c27dfd83c6956c847a5274d35831f077d7651db0c38145adec88940518d0f5e6bbfcd22a8cb02e931",
                    allowSearch: true,
                    extendedInformation: "9d69e07cee04445681995b927671aa54d39722f6104c4d80a88957bb012a71f584ff746940974a0a82f4e82337ee2552c347be4486aa4ca79404188d23a91ee18276ca8251d6426fa86cdfa1b5694ab7c5ac022a17534c30b2b484c46c297f7367037047803a4c2080c3b80f38d6ed1525c0b6cc35b24864b8745ed1770c4309ab86142a11264c35a8173d7e7d6f1d1fdc42f341326042e69b9e042353f71c8e4dab8c73d173477badf47dce04a706833aec29f5981c46d589626282046642f85cf8b5350bc04bc8a91412d575a6ffc9273758830abf457db46c5fafbcf633f5ea968b0c0fe14d13a1d360704a0eec4560d05a47bedb4da3839b",
                    note: "7a957090abb94823ba76ea7d465e3fdfe34f7d0fb8a74908a05339da1a4c6accdad91ecea4964a219d27fb4643eb2a45a7800d1a80f64602aa1c2234b2a787f8a627f1c5681f440584ec26fca32ccbaeba3553650a934997a62f7396b8bad928b5fd890fab7c4e21bb8e2e783817b7b943b1928bd88347ba89a21b6407425bb8213d47a77f464ca1bb68362e397e49d10306d772f6b64c53b0b40191fa6c0a2a51ca714ad78e48cda8c8265b6890f4ee1d315d5e7999400f9c9987e8333f4a73969f863e883648bab2ecd49af7b2430bdee39d44bea9461484df41de4a7999df525d3f27f09f4d159c1cc66aeacc9fc6101aac4a841d41498a19",
                    status: "16272880acbf4ae58a34d7957fcd4b6ead59293ea5ba4eb085",
                    matching: true
                );

                // Assert
                result.ShouldBe(1);
            });
        }
    }
}