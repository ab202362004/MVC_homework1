using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_homework1.ViewModels
{
    public class ExpenseIncomeViewModel
    {
        [DisplayFormat(DataFormatString ="{0:N0}")]
        [DisplayName("金額")]
        public decimal Money { get; set; }
        [DisplayName("類別")]
        public string ExpenseIncometype { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("日期")]
        public DateTime CreateTime { get; set; }
        [DisplayName("備註")]
        public string Remark { get; set; }


    }
}