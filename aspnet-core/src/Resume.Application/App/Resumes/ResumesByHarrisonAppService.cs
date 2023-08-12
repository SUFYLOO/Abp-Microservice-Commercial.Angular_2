using Resume.ResumeMains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Services;
using Volo.Abp.ObjectMapping;

namespace Resume.App.Resumes
{
    public partial class ResumesAppService : ApplicationService, IResumesAppService
    {
        public async Task<SaveResumeMainDto> SaveResumeMainsAsync(SaveResumeMainInput input)
        {
            var Result = new SaveResumeMainDto();
            var UserMainId = input.Id;

           var qrbResumeMain = await _appService._resumeMainRepository.GetQueryableAsync();
           var itemResumeMain = qrbResumeMain.FirstOrDefault(p => p.Id == UserMainId);

            if (itemResumeMain == null) 
            {
             var inputResumeMainDto =  ObjectMapper.Map<SaveResumeMainInput, ResumeMainDto>(input);

             inputResumeMainDto.UserMainId = _appService._guidGenerator.Create();

             var itemsResumeMain =  ObjectMapper.Map<ResumeMainDto, ResumeMain>(inputResumeMainDto);
             await _appService._resumeMainRepository.InsertAsync(itemsResumeMain);
             Result = ObjectMapper.Map<ResumeMain, SaveResumeMainDto>(itemsResumeMain);
            }
            else
            {
                var item = ObjectMapper.Map<SaveResumeMainInput, ResumeMain>(input);
                await _appService._resumeMainRepository.UpdateAsync(item);
                Result = ObjectMapper.Map<ResumeMain, SaveResumeMainDto>(item);
            }
            return Result;
        }
    }
}
