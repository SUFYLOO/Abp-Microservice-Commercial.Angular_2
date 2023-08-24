using System;
using System.Linq;
using Shouldly;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Xunit;

namespace Resume.CompanyJobDisabilityCategories
{
    public class CompanyJobDisabilityCategoriesAppServiceTests : ResumeApplicationTestBase
    {
        private readonly ICompanyJobDisabilityCategoriesAppService _companyJobDisabilityCategoriesAppService;
        private readonly IRepository<CompanyJobDisabilityCategory, Guid> _companyJobDisabilityCategoryRepository;

        public CompanyJobDisabilityCategoriesAppServiceTests()
        {
            _companyJobDisabilityCategoriesAppService = GetRequiredService<ICompanyJobDisabilityCategoriesAppService>();
            _companyJobDisabilityCategoryRepository = GetRequiredService<IRepository<CompanyJobDisabilityCategory, Guid>>();
        }

        [Fact]
        public async Task GetListAsync()
        {
            // Act
            var result = await _companyJobDisabilityCategoriesAppService.GetListAsync(new GetCompanyJobDisabilityCategoriesInput());

            // Assert
            result.TotalCount.ShouldBe(2);
            result.Items.Count.ShouldBe(2);
            result.Items.Any(x => x.Id == Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31")).ShouldBe(true);
            result.Items.Any(x => x.Id == Guid.Parse("33e681ae-f6b9-4d15-92b3-10ff6b538f2a")).ShouldBe(true);
        }

        [Fact]
        public async Task GetAsync()
        {
            // Act
            var result = await _companyJobDisabilityCategoriesAppService.GetAsync(Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"));

            // Assert
            result.ShouldNotBeNull();
            result.Id.ShouldBe(Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"));
        }

        [Fact]
        public async Task CreateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryCreateDto
            {
                CompanyMainId = Guid.Parse("59486f2d-db12-4fc7-8506-bb4ad98691c2"),
                CompanyJobId = Guid.Parse("4bfa2d71-6cf8-4761-bc6a-e451e7fea79b"),
                DisabilityCategoryCode = "cc862f47d5724b13b11f11e8a129348f0490ce134462436995",
                DisabilityLevelCode = "789c6d94c0284435810a12f269e658c287e0737c25b044a6ad",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "f1f6d5f26f064b9e8e0f3d418ffb7dbd86cf3c65d0de45a9ab9ad3dece6a8c940892b3f01b18480f8d25763f2c256c99e8ae9d3418504a46a2f2908c4267c07f0f54877f6ac844ee937b2bce8b208ca961d4144f72ec4164bb52bd69d78bfbad83f149d0767b4e278c9f90ac615d238f57a38ae9f00e4bcd916618dfcdafb554d5330c4ab53349888b6f987ba571218bdef96881d1b04488868d25bd14affe2abdbb2dc3a7384bc6a91966407c031dbfd8ebf56aec75479493bd2634913130ad37586de7fc84406db8fb090ca7dddbe2fb9c9aa03f02400db1a5f6ebdf0289a01dbee41dc6b14dda8abb3ca97ed492e7dc68fdea8cd542ae8974",
                DateA = new DateTime(2011, 1, 27),
                DateD = new DateTime(2007, 3, 20),
                Sort = 592206499,
                Note = "c5e3f5f6821e419abf3db86a98ec1c3a32eb55be44264133b55481858f17012684d8f2056b344fb4b72dce0f7f3535879df1e571c796497b83cd2c7fb6c7cfb6f2547a8a8b1b44debe17a6f237f3fe1e3046a199a2e446efa035a2f125ddb88dc205bc00240248c9a6cefa1a9150e4019ffbb16e4b2a4bb88d2311fa0b266944298fd734a7b645efa0b56aec8942b0fb1016a9162207490aa45cb298917ad338f2961c433d3641a9b86667487f616c7bab2539d38f8b4c8e82a7f9f7cd045fe8b3a7c1a99f87464b9284741da1c68735b86c2548af11481cbcfc77ef8f0f165847b54a68ccda405eb578999f2fccdcdef2fbbab40b8345219d3f",
                Status = "65d09e8cf66740dfbe1e9c03a80d05aa62a9c373982c44c896"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.CreateAsync(input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("59486f2d-db12-4fc7-8506-bb4ad98691c2"));
            result.CompanyJobId.ShouldBe(Guid.Parse("4bfa2d71-6cf8-4761-bc6a-e451e7fea79b"));
            result.DisabilityCategoryCode.ShouldBe("cc862f47d5724b13b11f11e8a129348f0490ce134462436995");
            result.DisabilityLevelCode.ShouldBe("789c6d94c0284435810a12f269e658c287e0737c25b044a6ad");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("f1f6d5f26f064b9e8e0f3d418ffb7dbd86cf3c65d0de45a9ab9ad3dece6a8c940892b3f01b18480f8d25763f2c256c99e8ae9d3418504a46a2f2908c4267c07f0f54877f6ac844ee937b2bce8b208ca961d4144f72ec4164bb52bd69d78bfbad83f149d0767b4e278c9f90ac615d238f57a38ae9f00e4bcd916618dfcdafb554d5330c4ab53349888b6f987ba571218bdef96881d1b04488868d25bd14affe2abdbb2dc3a7384bc6a91966407c031dbfd8ebf56aec75479493bd2634913130ad37586de7fc84406db8fb090ca7dddbe2fb9c9aa03f02400db1a5f6ebdf0289a01dbee41dc6b14dda8abb3ca97ed492e7dc68fdea8cd542ae8974");
            result.DateA.ShouldBe(new DateTime(2011, 1, 27));
            result.DateD.ShouldBe(new DateTime(2007, 3, 20));
            result.Sort.ShouldBe(592206499);
            result.Note.ShouldBe("c5e3f5f6821e419abf3db86a98ec1c3a32eb55be44264133b55481858f17012684d8f2056b344fb4b72dce0f7f3535879df1e571c796497b83cd2c7fb6c7cfb6f2547a8a8b1b44debe17a6f237f3fe1e3046a199a2e446efa035a2f125ddb88dc205bc00240248c9a6cefa1a9150e4019ffbb16e4b2a4bb88d2311fa0b266944298fd734a7b645efa0b56aec8942b0fb1016a9162207490aa45cb298917ad338f2961c433d3641a9b86667487f616c7bab2539d38f8b4c8e82a7f9f7cd045fe8b3a7c1a99f87464b9284741da1c68735b86c2548af11481cbcfc77ef8f0f165847b54a68ccda405eb578999f2fccdcdef2fbbab40b8345219d3f");
            result.Status.ShouldBe("65d09e8cf66740dfbe1e9c03a80d05aa62a9c373982c44c896");
        }

        [Fact]
        public async Task UpdateAsync()
        {
            // Arrange
            var input = new CompanyJobDisabilityCategoryUpdateDto()
            {
                CompanyMainId = Guid.Parse("b2bf36fa-e228-4cae-900a-1f166dbccfc6"),
                CompanyJobId = Guid.Parse("d537384e-3ba3-4911-b089-feba93e17df7"),
                DisabilityCategoryCode = "0a869c47d0c540bb8583203d9c01c1ef13658190493144dd9e",
                DisabilityLevelCode = "f418b8afa46249518cfaf1e5d99ee502ae6c52d93ed64fa1b7",
                DisabilityCertifiedDocumentsNeed = true,
                ExtendedInformation = "5cbca8956e1f4ea0b87d7021c1196f3430ad9d2c7fb347a4aa52d348f3cc6ee1af18584c9dac4b8295ef2d5d6f74b643a4fedffe850d4087b148741d162ee0dcbd45912519fa4cf799cc042551ae13b8d03189e018e040a0894438eedf1a007d0f850d67e4e349fd995e2d97e5c329eb14ba03bac0814d0b86de5f512f2b9062139b34a3e64845bfb9f6c71b5a0ccb76d876a38865d74cdd8b090788e48078b8bc0ef0e286544cc7a4a2004952cdbc808d36f2c9818e428bbd2a999eb76ef0519fa096cca5294b569914f10a9da6d63e98fa524bfeef427faed7a9b9b3ba8d39aa91ec5ff20e4fa295255cb0946e94b29b42ad39602447b3a2e8",
                DateA = new DateTime(2005, 11, 12),
                DateD = new DateTime(2001, 3, 17),
                Sort = 1218439419,
                Note = "ae2e58b04077413bbf3475995d381bbd9dc14185544142c1a5ad39453a5ee04c302eda31e8e747c6bdfc74b0ab50dd35f21457c1f009409d857f8e1b05fc722fc4154a320ead4896b4537a46c82bf7581e1cad354b104ba1878d5c4026ae1adac82c4cd7c7274ee387bafd9d85db98f05e40318b851d42069999a9e1773778fa7c38278b8e604c33ac76aa038d62bebdaf4c5950499d4aada58872a12109d1cc1468a66649d24ebc882dc8f6ceb4a7bd9e4bc4832e684ae0aa5f38e9057ff9a4e17f549a4b0f47a3b005007163258c32a8c32ac719c94e74a39f131af3759ae7331f739169ba4b38a1ae60a3871ae8522697cc3cfaad4a1db1b9",
                Status = "d2f7eb7ccdec4df6bd1d2002578b4b4373c357a218c944eca6"
            };

            // Act
            var serviceResult = await _companyJobDisabilityCategoriesAppService.UpdateAsync(Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"), input);

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == serviceResult.Id);

            result.ShouldNotBe(null);
            result.CompanyMainId.ShouldBe(Guid.Parse("b2bf36fa-e228-4cae-900a-1f166dbccfc6"));
            result.CompanyJobId.ShouldBe(Guid.Parse("d537384e-3ba3-4911-b089-feba93e17df7"));
            result.DisabilityCategoryCode.ShouldBe("0a869c47d0c540bb8583203d9c01c1ef13658190493144dd9e");
            result.DisabilityLevelCode.ShouldBe("f418b8afa46249518cfaf1e5d99ee502ae6c52d93ed64fa1b7");
            result.DisabilityCertifiedDocumentsNeed.ShouldBe(true);
            result.ExtendedInformation.ShouldBe("5cbca8956e1f4ea0b87d7021c1196f3430ad9d2c7fb347a4aa52d348f3cc6ee1af18584c9dac4b8295ef2d5d6f74b643a4fedffe850d4087b148741d162ee0dcbd45912519fa4cf799cc042551ae13b8d03189e018e040a0894438eedf1a007d0f850d67e4e349fd995e2d97e5c329eb14ba03bac0814d0b86de5f512f2b9062139b34a3e64845bfb9f6c71b5a0ccb76d876a38865d74cdd8b090788e48078b8bc0ef0e286544cc7a4a2004952cdbc808d36f2c9818e428bbd2a999eb76ef0519fa096cca5294b569914f10a9da6d63e98fa524bfeef427faed7a9b9b3ba8d39aa91ec5ff20e4fa295255cb0946e94b29b42ad39602447b3a2e8");
            result.DateA.ShouldBe(new DateTime(2005, 11, 12));
            result.DateD.ShouldBe(new DateTime(2001, 3, 17));
            result.Sort.ShouldBe(1218439419);
            result.Note.ShouldBe("ae2e58b04077413bbf3475995d381bbd9dc14185544142c1a5ad39453a5ee04c302eda31e8e747c6bdfc74b0ab50dd35f21457c1f009409d857f8e1b05fc722fc4154a320ead4896b4537a46c82bf7581e1cad354b104ba1878d5c4026ae1adac82c4cd7c7274ee387bafd9d85db98f05e40318b851d42069999a9e1773778fa7c38278b8e604c33ac76aa038d62bebdaf4c5950499d4aada58872a12109d1cc1468a66649d24ebc882dc8f6ceb4a7bd9e4bc4832e684ae0aa5f38e9057ff9a4e17f549a4b0f47a3b005007163258c32a8c32ac719c94e74a39f131af3759ae7331f739169ba4b38a1ae60a3871ae8522697cc3cfaad4a1db1b9");
            result.Status.ShouldBe("d2f7eb7ccdec4df6bd1d2002578b4b4373c357a218c944eca6");
        }

        [Fact]
        public async Task DeleteAsync()
        {
            // Act
            await _companyJobDisabilityCategoriesAppService.DeleteAsync(Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"));

            // Assert
            var result = await _companyJobDisabilityCategoryRepository.FindAsync(c => c.Id == Guid.Parse("a8e76ab4-1ee8-48db-9a3a-bf16e6692a31"));

            result.ShouldBeNull();
        }
    }
}