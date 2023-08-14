using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyContracts;

namespace Resume.CompanyContracts
{
    public class CompanyContractsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyContractRepository _companyContractRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyContractsDataSeedContributor(ICompanyContractRepository companyContractRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyContractRepository = companyContractRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyContractRepository.InsertAsync(new CompanyContract
            (
                id: Guid.Parse("f6382efe-693b-4eff-93f1-6c0982f5e58d"),
                companyMainId: Guid.Parse("9d30e81f-cd96-46c6-b184-267ad42a1baa"),
                planCode: "856a38a39d1e43b88fc77eaf74b106de3ee1512ee1024c01a5",
                pointsTotal: 1623340538,
                pointsPay: 1240562279,
                pointsGift: 1733954003,
                extendedInformation: "da0cbd284c254f00ad61081de3f6cb2c74b2e071a814493da8281c765aa24184ba38e3307a274020a7ed87137a50a2994ab80f49f11443328d3f7a3027a7a7ae1806b908538c4aebbb69408c4390e1f519bcc183313a44c19af17696b59e8a9acdbaa73a87e54c40a0b45d26ddc6b2ca030ee16e843b4e36958f4279a8b4fae2be518b5474f64924baab6f4b07e6fa5ef77ab06fa2f84846aa19e14c88247d234c5e0e6d26104a4489b8537f90ec3295d47d3af3d9e64e88a214e933b3901776341a8218db494367ab9abe575b0de51a79ae68d4dea3475da7d4b4aa20ba6cafe3c3685a2a974739aaa2fa61739d611674d1a5ce4bc846c2adb7",
                dateA: new DateTime(2017, 6, 11),
                dateD: new DateTime(2006, 6, 16),
                sort: 222815514,
                note: "aa106e2bff0d490c99c86efae51fe932990e4f15b35c4e04b515a77b975206371c6661bda1774351919cf565f2d7c364be6b3100731b4706858dca6a1988afb9422c4ce5a7844c1c8971a096e786deacaa71c73e566c46ccbe41203a722211413c86f97649d34ac2ac79abe85551d714633fb325cf1c4f8385d05adc947bf25b8f0f0c49eec64bb8bc506ebf876cafafba675bf61cd4411bb441933040afe3ba39ed18c2db2a408ca37cbf8fa6cd416c00f5c592a11042258fa029336e5b328c468609c4bdcf4279a83ee7387c7d076dc60d816e522e4c799bd22746ea9c33fd10709dca40174a89837cbf63adc230144ef3c2200fee4424bc35",
                status: "290777f4b7334281824aa34a243740668f20ea9334044a9d94"
            ));

            await _companyContractRepository.InsertAsync(new CompanyContract
            (
                id: Guid.Parse("419eaabf-9a3e-441f-9f8d-63ac7e4aae22"),
                companyMainId: Guid.Parse("a6991fd3-0e34-4be5-bc4d-9ac3a4e83ff4"),
                planCode: "0248cb8f5ce44acd9e93617a51c79cb5ad83488a2b414b5388",
                pointsTotal: 1989777613,
                pointsPay: 1780753989,
                pointsGift: 821152139,
                extendedInformation: "bfd1ae2e5d9446d790f53f2547e845294a7d86753ff84770ba262695ee00740b0c89c0fc6f12431ea1a54eaeac0fdae1e3b741b28c5c4d82b3f48085cc80d8fadd9a389768e8428abbafe148a96f864ac96e1e2a13ac446c84b83b18ab57ad253f7662541f884edba590a9092a2f9ab2dee2f099c2a248ca980c10b17620b4d55f32dc8f2304440cbb39a797d241aa666322fbabb0734cb5803f543e6d95af4645380bc82eda45a886682f4f4656e97d7cfbd7d4dfbe40ab9d7eb87e3cf8ad0c624a83f4bee84790a5300d02581505181764e1cbd12e4342a29a13e6341f071eb3e9a7978fef4c7794a67bdcfe57849fe5c86466b09e48e49ecd",
                dateA: new DateTime(2022, 8, 6),
                dateD: new DateTime(2021, 4, 8),
                sort: 1169820050,
                note: "ef1b0f91b32e4c7aa6389cb3bad01ff318656619bfe94faca6a36d3cffebe39d7b38dc55bf084975a3a2a7181c222fe4463acee7ec7546418bb96d72f18d73bfbd8b45c45fd047bdafd90efa8b700257491b351094b64b63a7b2f8c0ef1872d4a79efc38b8fa40718620232a6d7899d6b8f5740a0e4340c2b8dacfa481ab91062f3cfa5bb4ab4941acae34a70a54dc7cc09b6861afb44ac0b27e121e72d61f611b32a197555447fda24c9948d211c89b745a55335a174f618a8b5c87aec5b2ce2786aa79a7054fca8ed8fc9d530e795dd27973691afd4030b54dc348b232a053be176e7f39b24663be17687853dab4eaf818a8d3504b440fae27",
                status: "f5b5635927ab4ba69fcb1719cb4edf59f59d234f37094bbdbf"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}