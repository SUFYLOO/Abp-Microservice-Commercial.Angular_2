using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using AutoMapper.Internal.Mappers;
using Resume.UserMains;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Org.BouncyCastle.Asn1.Ocsp;
using RestSharp;
using Volo.Abp;
using Volo.Abp.Data;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Identity;
using Volo.Abp.MultiTenancy;
using Volo.Abp.ObjectExtending;
using Volo.Abp.ObjectMapping;
using static Volo.Abp.Identity.Settings.IdentitySettingNames;

namespace Resume.App.Users
{
    public class UserManager : DomainService
    {
        private readonly IDataFilter _dataFilter;
        private readonly IIdentityUserRepository _identityUserRepository;
        private readonly IdentityUserManager _identityUserManager;


        private readonly IUserMainRepository _userMainRepository;

        public UserManager(IDataFilter dataFilter,
            IIdentityUserRepository identityUserRepository,
            IdentityUserManager identityUserManager,
            IUserMainRepository userMainRepository)
        {
            _dataFilter = dataFilter;
            _identityUserRepository = identityUserRepository;
            _identityUserManager = identityUserManager;

            _userMainRepository = userMainRepository;
        }


        public int? login(string userName, string _password, ref string errorMessage)
        {
            RestClient client = new RestClient("https://localhost:44364/connect/token");//api地址
            var request = new RestRequest(Method.Post.ToString());//post提交方式
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(
                new
                {
                    userNameOrEmailAddress = userName,//提交的参数
                    password = _password,
                    rememberClient = true
                });

            var response = client.Execute(request);//返回信息

            if (response.StatusCode == HttpStatusCode.OK)
            {
                try
                {
                    var result = JsonConvert.DeserializeObject<dynamic>(response.Content);
                    string strUserId;
                    strUserId = result.result.userId;//获取返回信息中的id
                    //this.AccessToken = result.result.accessToken;//获取token验证信息   便于访问其它接口使用
                    return (int?)int.Parse(strUserId);

                }
                catch (Exception ex)
                {
                    var result = JsonConvert.DeserializeObject<dynamic>(response.Content);

                    errorMessage = result.error.details;

                    return null;
                }

            }
            else
            {
                var result = JsonConvert.DeserializeObject<dynamic>(response.Content);

                if (result == null)
                {
                    errorMessage = "无法连接到服务器。"; 
                }
                else
                {
                    errorMessage = result.error.details;
                }

                return null;
            }

        }
    }
}