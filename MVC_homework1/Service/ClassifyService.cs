using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_homework1.Service
{
    public class ClassifyService
    {

        public List<SelectListItem> getExpenseIncomeTypeToSelectList()
        {
            var typelist = new List<SelectListItem>();
            typelist.Add(new SelectListItem { Text = "支出", Value = "支出" });
            typelist.Add(new SelectListItem { Text = "收入", Value = "收入" });
            return typelist;

        }

    }
}