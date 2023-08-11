using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserVerifys;

namespace Resume.UserVerifys
{
    public class UserVerifysDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserVerifyRepository _userVerifyRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserVerifysDataSeedContributor(IUserVerifyRepository userVerifyRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userVerifyRepository = userVerifyRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userVerifyRepository.InsertAsync(new UserVerify
            (
                verifyId: "899492de7bbd4bf089863b49f3642909949130b88fd6480996400c1fbccda94ff72f18273da644dba672648429f6fd7de5203284d74540778a66488a9f54da1eb8edc2eea5c54281b9b5a39f27a434b22060b00d70d54afbba0732f8f61abd3a0a3e7ce3757148bfbd65d9f2a0e7f2a886fe0d64c4d045479c2cef99d6c5c7dfb12d9678d8ff4362a9afebd9866188bda0958f8264654a18bf2ef72c9f197abdae25653eb9154d42a1f600e7dd80bf891a2fbbb070e7415593b638707419d976402f5af34095494eadaf2a120d11fa1097e831fccbe9488fa6eadd541692d12ac1b7c39db21c4af7b6aa5699989880c4253e9ab162cf46fda4f8",
                verifyCode: "3ba65c1f1f1d4f44a9ddf57fcbd53fdc93f36f7b8d114b469b",
                extendedInformation: "beed078d071d4ce3a1c5f37c1d133546906bebfc62544eb0b71dd86f0d7a8b8e6efcd0624e54446d9386cc2cd75e24b09ee702b69256438aa3a8a7fedc49ef3f866234048b344d538cf80401968b254f8ba119eb92314912b1e5ab1392d9cfd7e9e3fb7f2c8042a8a8ee8619dd336990723531f1c08a4743a63719ec51a281d970322b9d64e344f6814a21259060bf47870c097d70d24a99a39df595e470ce8bbeee2fb1cb9e44eabd722d1ead3e27b1193a5eba3eb643ba97f39bfc642706c1808a594771e84016bcdcaf5d844244cef2e4594a4d9b4e2196b7c994ccbe29343de99f3557154c1297d330edbe5f7ec277488ab74bf34f9d883d",
                dateA: new DateTime(2006, 11, 17),
                dateD: new DateTime(2005, 4, 17),
                sort: 1136756731,
                note: "1e437809a89c4aceb644ce7ccbe5b60e29f28243241247efab8f31ba6eb75652d18f82ecf44c460484c56a5647995fd9c224d708d82a456091c84d7d316eb936feb415e900f94a5ba049151d79096aa8378e7ad6f7824fa6ba36d4ccfd292fd2d6ee3bd389ad450298b62cfe71face06a65275b1d3464444a742cc8c1b99c8a20f0ec008d6194bf0a45336582118599c26552da00bd24932acb9d089afd1b81b3396546b052a4db996bb9c9fe08c0a304c04a2acf4e54cf19099902167ac1ec6cdf962243ea5427ea9c629702c886f4d7a806aa53ddb4b51abc62ba783f398e137c7a68b57ec4388bf3946e3d03cf66ef99d9ddd2c3643bf9cf1",
                status: "f308a93f4bde4257ba9209c2b65097dec5b76c3fa9344888b8"
            ));

            await _userVerifyRepository.InsertAsync(new UserVerify
            (
                verifyId: "84934b2761cb43e1bfa68ec0a187d3784929ec7562d44dd9a2a907f9ad7cf0738013516d4ee1411290e62d78014069c1048bc03c55ac4533b779c7d4fc4add0e40ba89df284641dd95c97a93c26f13c3948cc2fabdbf40068d01ceab0f7224a70f1a8d81b28345318ad9107b3172327e5f7dc29449784d2b8c2a64a7106846a2a37346eafc44462795f5b9d6c04da8b732e8a4526e264778ad3825a704966638fd7c84f30b57470abad27eb8ca1282f2d3d87bb5c2084c9f9141b8242882c0a6afdce6c74c114fbb8695f1620db47ef5281b647d7b9e4bc19961c24b5890c629be6f31234a13477b8b39f03eb559aaf91643692951fb43488a83",
                verifyCode: "9e098521530e4f57b872586c843f1870e2522be440584e2eb5",
                extendedInformation: "0aae46e9b5bf4953a956645a128cf8b984ea52a5b7d148a2806dbfa954433a59a145a8b6199c44c3913c5868d27164bacb21c7bb354f4853ab45f5469d20ef9f4c4d331e72a743a0a7ec486c0d73b6e21024a495abe64778a78cc22ff480999f4e406eb190c44b5caef0deec64aef3806d03555e93e343f59c7d31500e5e7a0cca4dc9a9cc9d4fe7aa90c0e051f067a91b530dcef04f4fbdb125f78e830b66695b9f695e97754a05bf26f485efe262c8cbb65a1ab98841988467a36a18f61fb68ea074531ed34089913bbe52a264f2531718afe5eb4c48f4b95fc0d4595ed4224715a2dec61a4ed6b7f054118e175ce338ab7f992e9742fd982a",
                dateA: new DateTime(2008, 11, 3),
                dateD: new DateTime(2002, 9, 6),
                sort: 1245977462,
                note: "c175dc2b7f69455e8450ffdf959f7ce2a2da5588e8d74afe9ce7cdfab3f66ce8fa87618772fe40e3821f09af1c4c303bfc63a111b8364f8c9f5c6b927ab6881ed75a2697461649acafcbc3615c3c16c785b2edd4ea1d479fb71192fc92da12d60d4cf6dddcfa467ca931f309efca71dd1d32de50e5404ab994d902603dfcc9176ba6f6f769b644ee8168945055171a069d9437b6791e4d4ca842d9cc688abb5b1dd9a910b02d456cbc0832f78a80415e768096c71e3640fb8b7631eece44a71633e35a167d1c4672bbdc290bedae3ede887d2ffdb5f9477a9b26c7fc1194cfc80bc0779250164129a2e438b2e14fd1dcefbb65c60c3441f4853c",
                status: "a135092e1b0c429f9cd3b082d710a1854961b968ce3a4fb79c"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}