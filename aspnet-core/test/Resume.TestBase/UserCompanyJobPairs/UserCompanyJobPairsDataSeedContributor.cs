using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.UserCompanyJobPairs;

namespace Resume.UserCompanyJobPairs
{
    public class UserCompanyJobPairsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IUserCompanyJobPairRepository _userCompanyJobPairRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public UserCompanyJobPairsDataSeedContributor(IUserCompanyJobPairRepository userCompanyJobPairRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _userCompanyJobPairRepository = userCompanyJobPairRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _userCompanyJobPairRepository.InsertAsync(new UserCompanyJobPair
            (
                id: Guid.Parse("65ef2511-bd27-48ef-8055-f6df509ff03c"),
                userMainId: Guid.Parse("f07e6fb6-a1b8-4392-9d37-6cd69a6896e0"),
                name: "dc9e562a48234ba5a0bd1e95ae751f8202a8983784e54e16b7",
                pairCondition: "eeb3a128e3514c0392c6b1a4d71311c9c6e7673ef2344036a0b353ea87f8268837d0c9099682450f912eda90e71a38ca7b9eba2ca96042c69f37d19cd303c755cbd936e6a3f444adad65dc7f61f805cedc40a93925bd476290da57dc985f06ba8b3a64540e214a239810d9a0e129cae311ad2597921f446b817aee4de28e66f1ff3ece79812f4429a0447797dac480b3c35fd6f808a446a8a6de5b6992ef175f2b98e27997b24058ad037d3eb7d23e2a6e9c4396a07c4da0870145358fa85c5103aec778b4ba45799d31296d0536f8f74891f2779dfd45398874b7f65a9ec89c1bba5bfb625b4e2983190c6a49cf3041ad62b4034f0342c793c1",
                extendedInformation: "462399f369524a3b84f2602cb337022ecdf118189e714d9a91e1d93662e470fd44fb4689e8bb4347892289498d5a73731704f8279fe34a73a1bb8b88511c841dd12804fe912549298b002aaae307e9570ba6fcf28d59414ea143ac94eba9f41a8087103bd2d942b8a18d8c06b8ccf1b08a807057aa49429fa53c666fb66919d720886d8ffb414d9fbba75ef1b36bd8ae6135b03bd89440cb8d330959d84a07286aa2c097d82a48b3927bf174e822270742a84cf372d3465f82f1965119b5273fb6aa7ac7c2e4445d84ec186005795cde41ab16c4ee7b411793e81c5ce181bc56f1da3c92fb6b4f27a1b66bb686bed17ef7a1ac92917d416ea7d6",
                dateA: new DateTime(2020, 2, 2),
                dateD: new DateTime(2021, 11, 7),
                sort: 2044715519,
                note: "280fe770db104cf3b8a677da295756d145383c03e44a42449445c516c5ea1a7bd56d38cdd59040c8be53119a4e0610c708f0f356e7b14868b5bc4447d7af98973cf032f7a9ae4adeb61b7a42e7d7df6ee7f02608282040b59b92f6406cf3af0b695cc636625749debf1a0bf9ce23657ebe1782f5e0a748bd8a9b8fca4f7e660b5222b77009454b59a17df8023513f9258e918484cd734ffbab2917f53197a13ee19dc1fa64964d53a62e47f77fd99d07dd78fbdf1502461e8b2a2b6de71e42373575181e23374734af5e5ef49164b4cb209775d6c81e43509886e785b9a8691532db95b159e848459ff22a9f319841e436ae6801bce7440d8e2d",
                status: "50752e6fef714205b1558b88f2cad3a4694f00a5b60c482596"
            ));

            await _userCompanyJobPairRepository.InsertAsync(new UserCompanyJobPair
            (
                id: Guid.Parse("24ab1425-9912-441a-8348-af7f8ac5cc08"),
                userMainId: Guid.Parse("e5f16b53-a9b2-4713-bb06-4ac2e19eceb8"),
                name: "c2ef293595e04ec9955b9e048e05815d5bd52a30851f40ce84",
                pairCondition: "6c1daaa0fa28481b987de6ddad313f82aa7156b8cb534b099ee54983f89fdf5c34886f6283d34cb4a8598ed383757c3c0ffd625a4f6c4bbcaf97c896b4c91df0f59e1ab2005a4a8191069d1e5d506f94cc60c4de50674859a8051a8db34f1a18c9550ad7eefe4a709ef6aaa046020fcf32bc7006d52748c98198f8e61df8f99e5f32f8abff1640969b62eb50810d77aeaf533b152f664d759c912d58ad1bcc03e374ff7fe0aa43e884da67d96fe3cd462a763d6febef4ee5b7da16c676bb841fe069f57933f9422f907e333ddea79e39e5486084cb644271ac35dfb29d0d6a446f403ec7fba64447bfea121a28c807e75dc645cee79c45069419",
                extendedInformation: "59e3f983af454834971d223693e25bc31fbc54465915404fb06fe9f1b2402e9dc38a6197d24740758d394c668949b3cb15a136c50e064449beff32af3317b8d1dcd728f8941644d3bfb9aa6c7e358b9d64c09ea8589b404bb30f652492c18e2befc2da3d474c4cfc8ead9be83c1c0e4ca96a1cd5df7e4a678db99a486a248c5540a8e2cbff7745a0bba6e6ca4f177ca5d98d84c57bb04ce4a22697a1893227053dd9d7e7ea6e4fada2bea09ebd34f309bc96dcace9e54e02b84ca3efb6cc176f5d5c30951a314982ae55304f8cb209e9a869d93a44a64869a8af46974e47307e74f44a994e674eb3b5306592eb3994d60112cbb510ed465ea6e0",
                dateA: new DateTime(2009, 1, 26),
                dateD: new DateTime(2013, 4, 18),
                sort: 1952516175,
                note: "130caff27a8040ad97fd8668c3e8805fc022b6efffec4e2baa15ff2f10b2be260fe61c6a57634d96a42145151a656977e6a3e7ec0177406aad3a7d5903a4ff4700d815bb0cea45d09e6fac4abbece578056732fa27344563bd757d982ebaaa8f301cf25b8bae416cadfdb2d891ba1dee803633c838ac4bd6b7bf6a6baa1e9bc84a40e28f09ca482f875f6e2f3080d509ee578a00e80b4a10b977cbca7ab53ebbfd1b993c0e6c4e9cb056a25f7f2fe6ca6eef4e3eb11f42779b23212ed9cfd82f41cffe0adb8749c1886e7dc594c8922368d1450d0e1c443b98837ffffc2194c35d49a730f8b64102bc659b8ce537951d393aa8f9c1e74366b968",
                status: "38ca56fea65c490288363d640a377f5a73e66ef4aecd41db89"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}