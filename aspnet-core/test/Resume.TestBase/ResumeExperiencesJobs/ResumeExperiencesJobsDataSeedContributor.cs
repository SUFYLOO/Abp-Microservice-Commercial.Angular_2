using System;
using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Uow;
using Resume.ResumeExperiencesJobs;

namespace Resume.ResumeExperiencesJobs
{
    public class ResumeExperiencesJobsDataSeedContributor : IDataSeedContributor, ISingletonDependency
    {
        private bool IsSeeded = false;
        private readonly IResumeExperiencesJobRepository _resumeExperiencesJobRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public ResumeExperiencesJobsDataSeedContributor(IResumeExperiencesJobRepository resumeExperiencesJobRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _resumeExperiencesJobRepository = resumeExperiencesJobRepository;
            _unitOfWorkManager = unitOfWorkManager;

        }

        public async Task SeedAsync(DataSeedContext context)
        {
            if (IsSeeded)
            {
                return;
            }

            await _resumeExperiencesJobRepository.InsertAsync(new ResumeExperiencesJob
            (
                id: Guid.Parse("d0919b7b-4b1c-4429-b30d-f3b7f1d2c81e"),
                resumeMainId: Guid.Parse("135d209e-0682-4922-a771-f4ed8c76e0c4"),
                resumeExperiencesId: Guid.Parse("50011822-40d4-4e61-a559-94c438ce6844"),
                jobType: "c92cf8fe3ea446669c8727860601f49d36326d8e46ce4e5a85abdf72cb0d5eeb2b53e4d39b424fd0b0b8d88ea391178a25cb666507b443c58e0e49a93ae051a7c29fa668a4c34d7180fedc742a1abba88f40e69264e8425c939192672bbe34f20c6fda4b2070420c992a1d255438063550c285cf7bfe49da8c8bcf38a9552f0014ce3c39b7704a73882c871a4a7269111841a787979045c793260c2bfaaaa79dc37d1f9069d74986a4be420033cef77a1db4fc6d896f4cabab2f357af38d0783d1f9d4f275f8406b948cdd25335e0f94691569421ad6469582ad069ffd654d5e4dc62a50d7b642608f69c4481f1b16cef3c2bfd9a0d449c0a9fb",
                year: 1306166513,
                month: 1747241938,
                extendedInformation: "382ada45f1f84ddfbef08347dfb43d59695628ccbc464e8bb53a1f9cfc12fd4af560e112809d4c02bd9965ae17e387e1e413c0eea87a4802b3a7631cbde2ba48e5169d69787643fa93f5bb34ba0e4b002893c253933d4452bd19617220a2752c109f1b27f59f416e978c10cebe47600fff0b23bafc284eefb65eeb260482b27c76b8e2a5666a42cb8d473416c745c02649381e7df6ff4b0780fbc444de13bded3f48dd889cf7425ba1c0929a5aeb5f6bc80b6c0484704ee78ba85991ca532441ba32b84cee4743a4893a6bfeb5e4322c4ab458c668d6417ca7c45c7a4cb1ac1b8e51ae21bf1f4abeb50da3a31777d6da4eb2419a36414959a283",
                dateA: new DateTime(2018, 8, 27),
                dateD: new DateTime(2015, 7, 10),
                sort: 1874344832,
                note: "7937b77c6baa4e5ca6df474a3fdd4d0c0405e572fa1048039018740e4129cc39f35dd2fe350a4d6b985019a0f3d59c6cc1f31d1a891c49ddb2b9f1eaafdc4f9d54cbc192026b43de844149e0d6a85250634f80764a6542c694bb89c29d553f77d9f1fece5e8c4f74adf67cc670ffaf6648918d82675a443387bc2ba40b9278893245272c4f8045889015d9c910273a505ed2b1a2018c426985ce0537847bed4c823b99b0db7549d1949b13a3729f9b0f3979e610019e4cfcb22434a9096a12a917b5b9e016fe40faa878b9324191d317d43a87fb3743427aa08155a2f615a68b8dc5e72df24a4e76927ccf42b802bd2dd87b9193b7a949609512",
                status: "cfa09eabfa1546edaafdc7696e09ad42ba7929a0f3884f35a4"
            ));

            await _resumeExperiencesJobRepository.InsertAsync(new ResumeExperiencesJob
            (
                id: Guid.Parse("f701d2ad-33aa-44cc-98cd-b79aa447433d"),
                resumeMainId: Guid.Parse("0e721302-6fca-4d30-a46f-acb4a67b0479"),
                resumeExperiencesId: Guid.Parse("e7146ed5-ae97-46b1-b9b6-817644e07344"),
                jobType: "1c1729f15c124b60a032077e92612e2cc2175e0ef2f3487fb0cd07e8b2741024e202d582dffa4503acdf74d207a1ad4e30fecc6cfe2143b4bf907e2dcbd26ab7cc41c7277ce2430e91cd1e710775166665a5880d7a8647ed843ceb8a91fb8c9fe896bf9aa9e04ea2bc38d021911ccadb5f092959903b4b7380ee57603e7dcf62a7947580f1ab4bb196022a21255825bc9ff8eeb7da2e48a6937c5aa53bd07a17b63a0f56c7d148d99a7adce55058898ebb9c1230f0814b17b21e077a87cd4db0ec87c72e34e44499964494240083d6035d9dee47ec6b4bedb468317dc23acb03fae019d6c61d4f44aaeb6d45a1c5754ede875a79229f4beaa90d",
                year: 1242267222,
                month: 1740935041,
                extendedInformation: "564fe4cdd1ab442490af28d7d9247e6a1ae3ce2b5b604662852720a9a40523b0e722e9a0b21e410ba77107fc39b214bdcc987318bc5947b18ec4f455d75f64684eac52323abe49e5ae95ee8f7c018646b4c8c05617564cf0ab000aa6bfbe5a6b732846256cb14e9dbc979a75e9c7d3e9e0bfd57a71b84aae80f9259130526419162979dd2e33435783c72202e060c895288988136ba84832be5cdda9dfe546f91c5acd0078634909a4e1d52acbc6b5e1d9e8b7961e21430c901f7470133d5f2cc3844b59a1a24e639756cbc64fbc60f3144135c4b8e949e6aa032ce453c8de438ab4381bb11945daa5db5e066c69d5b79ac92d3c10e3401da54a",
                dateA: new DateTime(2022, 1, 14),
                dateD: new DateTime(2015, 2, 26),
                sort: 157244149,
                note: "e0abd51663d0471a86a8a1519bb8255d7802184f3f6d4872953ce353c6da90ce735e8d1657394fa58872280a3e7c99edac52c20a41024a3ba8c33fc7631c6829d3377687d56b4e7ea787c748b079dcd6b64b060e90dd4f05994d6ff0f1f1171ca4a3377d9a26413d88b323a8f38c2fc21cf1c2b6e79344a58762984afe7ae5628aeaef5aa74543b49dd393c1e5a6d7dfaa64c01eec9a401f892d6a9d395a15830a851843c7f249f29404f12acb215e1365feb351c92f460b970612d3e0beef7ee1ddb86a06f649ac98fcc096b358289d7a70ba7840174669a1bb0ed3b7709da01d7503cc4c56449bb9591128f56f17ba84548283540d4473a0c7",
                status: "1b0097877b9c4ef6adce032102945a770949d3b0dfa6458993"
            ));

            await _unitOfWorkManager.Current.SaveChangesAsync();

            IsSeeded = true;
        }
    }
}