using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.SystemValidates;

namespace Resume.SystemValidates
{
    public class SystemValidatesDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly ISystemValidateRepository _systemValidateRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public SystemValidatesDataSeedContributor(ISystemValidateRepository systemValidateRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _systemValidateRepository = systemValidateRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _systemValidateRepository.InsertAsync(new SystemValidate
            (
                id: Guid.Parse("aa5f7c08-9d41-4798-b084-34ec7b84eebd"),
                param: "d0ca221c301a4e4797f8a248c1c878af94084579820d42c9bf4f66d7ab11f819e3e0b0ac252642d4938a7f930135cfea8080c379dcd440a68e8642287ad610db959d746a79d94e45b68eea11b362bdb692e53b2c82c8493fa31d976526ce706c66fd7d01",
                dateOpen: new DateTime(2014, 7, 18),
                extendedInformation: "ba30460867d94413ba22dbd0e0ff6e7d9fbab1f770144d028f2c16013ace3684823f36cbf85a45b9a4110ce630100ae90cf2506e8aae43ef8e737508ce317d5380adf9f77e654561b1270ad95851246d0c26a792f68d4333828d122fe78824bcede5db4390db4c77aa3a9adeaa3558363f82f3617759483db5a04d03a59fe03f40148b37bc7e4745b3c932527adeb042d8cf18568bfe480ba00803be8dda3d430d22134382604370b716200bd726445a41506b6399ae4b3f894223ec3f5a4b8c6a761a2c4a484d04a8f763e75e0ade8ba016d8088d3545199c4257461925ecea0dd401b172ac433bbf4814f983bbf658aa39220824bf4c648ceb",
                dateA: new DateTime(2014, 3, 23),
                dateD: new DateTime(2017, 9, 23),
                sort: 1772226057,
                note: "804630b2dd01474398eacd8f9320d27d0d59380782b4414a9dbffd1ecbc0ff5dc8beb30cdcd34f1aaa6fb5b32a634ffbcc4e2839428b46179234f439d67dbe039295de2af76941c28d755f65de49256504ebfa0a39164a7c9d0c48af4b50df579d4077c681ad466480b3305404cc368b807a1f5afb3849cfa3e25a9a808342ce68328daa40ff4a0892f48b62c67c9c27fb188cea39744301b4eafb35f58bafffc6a17079eb12497d94395485efbac6e4480f547ec42141809c8b2a431a39e1558eeacf06639046e7bda0f9ce83fd17379fcf6990591447ddb10704a99c295bb34f6481356b91461f92f0ea3d40a98819cf98e5107c1d41fea945",
                status: "90bf8118db5f436481c88875473cb8b9d9caa6437ca3484ab3"
            ));

            await _systemValidateRepository.InsertAsync(new SystemValidate
            (
                id: Guid.Parse("f39cfc47-3dbe-4b74-a654-f8b729ef0c43"),
                param: "3ccce70de31e44238c81984bd49ad52ef113a873eb734da89eccb2c144d162e598511fa34dc844009c8d1147d47a23148bd88a73a09445b68877fa1951552d9f48a211bce3874b17988d9048926e6b5b2c30dc2f5be34156be0aedd62978c33146cc5362",
                dateOpen: new DateTime(2000, 10, 21),
                extendedInformation: "9d56bcef311944baad810091f28bca23474d1dcf4bab41929a0cf9b77ac7ecf7ada76868f9a142baa77527df326a5c3ae990cb7f32714a4481fdb832cca49ecd6ce6d7019987464fb69f4483b40a33acd9a937748f53495a927838ff0ef469d158fea23b81834280bb32a39beba75f0d803bc06048a04e0d9f51cdddca735cd3df731b2c98bb46bb8179a44c9852acf79c695358bd404756bf3318f3c90bbde0a0d0e1c543c7427d841438601b5ffb3140af6b032bf84f82b333ca7074d2cce5cc7a2c3d31fc40b195425d97f0e89b2d5d06a27adb654083bf1c61a324b6e111e3c233a390f14dc5a130da47d258fd2ade98786db53041538801",
                dateA: new DateTime(2009, 9, 7),
                dateD: new DateTime(2013, 2, 14),
                sort: 1449429871,
                note: "3bb05d951a234ad6a1ab42e4d84bc9e6acc462c0466d4fe4a30f873bc71c78316bdd280f32194b868a29ad4f0da11f6b6fc2d73185fa43e8adb76b3b559ea88be7e04f21175b4f628a61730b0de2e0607327c496068e4a81b3df29d0801d3c3d6c0b69e88bf14adf96f2e3141a6dc26ad0e6ed95d02e4630a5afbe76343b1ef072d27aec97f44c40a657e430a366d80e031b127c258348a5a6a5d09302e1f61836f3d89a8106459389187376e98496927f2b178abe4d407b927b9d05181bc0f0d090d71f2ad245fdaf7d4620e99c3a2341d766db23df4b7e80a7bea2da93dbd1cb25359c85364c1a980ade6c1994d7b599944ebce6fa456597f0",
                status: "fac187f51c25412eb58a367901ac194b2081f52dbb3a48a8b1"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}