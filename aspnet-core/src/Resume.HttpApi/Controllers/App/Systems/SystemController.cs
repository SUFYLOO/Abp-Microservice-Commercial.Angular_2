using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Content;
using Resume.Shared;
using Resume.App.Users;
using Resume.App;
using Resume.App.Resumes;
using Resume.App.Shares;
using System.Collections.Generic;
using Resume.App.Systems;
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;

namespace Resume.App.Controllers.App.Systems
{
    [RemoteService]
    [Area("app")]
    [ControllerName("System")]
    [Route("api/app/systems")]
    [Authorize(ResumePermissions.SystemPages.Default)]
    public class SystemController : AbpController, ISystemsAppService
    {
        private readonly ISystemsAppService _systemsAppService;

        public SystemController(ISystemsAppService systemsAppService)
        {
            _systemsAppService = systemsAppService;
        }


    }
}