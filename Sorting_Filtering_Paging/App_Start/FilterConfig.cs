﻿using System.Web;
using System.Web.Mvc;

namespace Sorting_Filtering_Paging
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
