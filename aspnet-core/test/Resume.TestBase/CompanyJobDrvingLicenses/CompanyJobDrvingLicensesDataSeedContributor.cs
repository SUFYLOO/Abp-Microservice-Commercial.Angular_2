using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.CompanyJobDrvingLicenses;

namespace Resume.CompanyJobDrvingLicenses
{
    public class CompanyJobDrvingLicensesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ICompanyJobDrvingLicenseRepository _companyJobDrvingLicenseRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public CompanyJobDrvingLicensesDataSeedContributor(ICompanyJobDrvingLicenseRepository companyJobDrvingLicenseRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _companyJobDrvingLicenseRepository = companyJobDrvingLicenseRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _companyJobDrvingLicenseRepository.InsertAsync(new CompanyJobDrvingLicense
            (
                id: Guid.Parse("a577e99d-6a24-4db7-94f7-4af6bdffe892"),
                companyMainId: Guid.Parse("939c9ffb-6bae-4277-855c-4cd270c3f02c"),
                companyJobId: Guid.Parse("8bb5e7c6-8061-4504-b8ec-f07410c8d71f"),
                drvingLicenseCode: "3ee8b15956d143c98631e6772c2e449efd459816a85649129f",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "d429226a15f54e958579491a2a7854e29d6f8edb690d4baea3517ba98083a0e64812965fcb3d4da7b9fff42392cabe00f137da5a494244bd86eada58a29551b8d6991962d74747b4ac9c35a839150cc241046837fa4f4bfebf77fa651daaa1e7f466321f11d24333b0903b264052fb658aeefff4b61b43738666b90c08713c382bd38db2fef44864a9db0dab8fea37864afdd7bf4fcf4e7a9822551a02a044aa0be0bd28e4e7424b974175ec0fed949cd79f1cc149ea4db799966b28fe222f10aaa2ffef54c3498380405c174df338979b78d0f19ade4129893413d908e5f639c7a2801bb8514b80b74b7a27bccb9d3b88421557eaca4bc39d0b",
                dateA: new DateTime(2009, 11, 22),
                dateD: new DateTime(2018, 5, 13),
                sort: 73687336,
                note: "8540665cc2c5421294fc37e24d6bbd23314cfc06aaa941a7b4573de61a938de92e3e938c241749b5883cd6cb826fd4e3ecf3e479b63a49f4b4667add185b63c823e7c0fc65ba4c74834d7061920f640f4e35d56445a3454390d1f826c08ddce7b6c3141774934e75a5d8c818b7bf4e214fedca67bab44f238e19f69df14b103259c29e495e2c44acadfc9a403fcc4ef242312195d7e14016a9f0d35181c0103c3c392435148d4b12896fad3d59ec86f43e9bb20ab1a14732b7ce9d78924b1cc3661ec1e306034df78b08fe4e5fb8da748fefbf2f7fdd4e7ea9da63b3967a976affd9102d5c28468792c445b4bc0fcfc3839abc0812ff4577b19c",
                status: "267aaa1cd00847098e6fc985b11650a78b55f55fd3374b5c99"
            ));

            await _companyJobDrvingLicenseRepository.InsertAsync(new CompanyJobDrvingLicense
            (
                id: Guid.Parse("f553a2a7-bd1c-4f9f-bc44-04308ccd4c89"),
                companyMainId: Guid.Parse("bbfd25de-afed-457c-98c2-85a5625cb3c7"),
                companyJobId: Guid.Parse("c0639c8e-4e66-4d66-8ee9-0a41dbe72999"),
                drvingLicenseCode: "27bfeea704da4a4698f7695018d4afb18792386ac3e543a9ba",
                haveDrvingLicense: true,
                haveCar: true,
                extendedInformation: "013faa198f4143b7ac46605149a06b31cda323a03f624ee9b1c0fd4338ac2147c9e7bf8094f44e78b8c6302016c8a8945a2169cabafc4a1dabf31b39150be52210de9ba223d149c8a7f18981374b376eb77259489c034ea39c3535eda5809ae6d628714f92384c249fde0a03bcd745422f0511b27f5642cbb0c5df1e6812a64e5e1ad914e3114dfcb8191edf4836114cb8d9cd726e424efd9d3af9978b6573bade603dec06394e189341da9e6ebfbd547a4062e5f76741908942c49e77c572d897e876bf6ae842c6bfb9fdcd422d08ef678627b8a7ea4f28baa6247d1e44d0e4de4785a20baa4c95a27096182299641d8bbfe62022494dbe9f2e",
                dateA: new DateTime(2007, 11, 13),
                dateD: new DateTime(2011, 5, 10),
                sort: 585119201,
                note: "5d4211af54d04069b668eb58139af90aaf38e62283b54321bd4a8b9f0d33030494ac749f1db442da8a317f303913825cbe2b36a4fb03422a98a7d11d9cf6d817c6eaf5f853c84b5480fb41fb0ea8e010bfd268e07a4646f2ae50347fd7f0cda40a77a583977b4dbe9094ef3b2404604a705508e988264ac1a3f752ebca9bb54b41d13715597f4f71a8b9e887f4bd2d7f85ed29816f714f359e215965e1b7abfaa8f638105a004a5b82008f8be437b8302abfcb9057594c5b9e83039c328dc1f5cb48c0125e8e403db99592f67cfbe00eff839abcf2f545d9aeb37e19e757f574ee7eafc8cf544ed1b79a4512a23d81ef5b511a5492694cff956f",
                status: "f02d82456085451eb6e0019fb1681b0144f245381cb74b98bc"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}