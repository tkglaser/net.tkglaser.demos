﻿using System.Web;
using System.Web.Mvc;

namespace net.tkglaser.demos
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}