﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace 使用__Forms_Authentication__做身份驗證.Models.Helper
{
    public  class UserIdentity
    {
        public static string GetUserData()
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)
            {
                //先取得該使用者的 FormsIdentity
                FormsIdentity id = HttpContext.Current.User.Identity as FormsIdentity;

                //再取出使用者的 FormsAuthenticationTicket
                FormsAuthenticationTicket ticket = id.Ticket;
                var userInfo = id.Ticket.UserData;

                return userInfo;
            }
            return "";
        }
    }
}