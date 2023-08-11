using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Resume.App.Users.Login
{
    public static class IdentityBuilderExtensions
    {
        public static IdentityBuilder AddPasswordlessLoginProvider(this IdentityBuilder builder)
        {
            var userType = builder.UserType;
            var totpProvider = typeof(PasswordlessLoginProvider<>).MakeGenericType(userType);
            return builder.AddTokenProvider("PasswordlessLoginProvider", totpProvider);
        }
    }
}
