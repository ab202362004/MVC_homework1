using MVC_homework1.Filters;
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
        [Required]
        public decimal Money { get; set; }
        [Required]
        [DisplayName("類別")]
        public string ExpenseIncometype { get; set; }
        [Required]
        [BeforeCurrentDate]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [DisplayName("日期")]
        public DateTime CreateTime { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.MultilineText)]
        [DisplayName("備註")]
        public string Remark { get; set; }


    }
}