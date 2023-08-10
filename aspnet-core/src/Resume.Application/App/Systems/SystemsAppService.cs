using Resume.App.Users;
using Resume.Permissions;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Services;
using Volo.Abp;

namespace Resume.App.Systems
{
    [RemoteService(IsEnabled = false)]
    
    public class SystemsAppService : ApplicationService, ISystemsAppService
    {
        private readonly AppService _appService;

        public SystemsAppService(AppService appService)
        {
            _appService = appService;
        }

      
    }
}