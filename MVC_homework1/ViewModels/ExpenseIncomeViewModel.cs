using MVC_homework1.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_homework1.ViewModels
{
    public class ExpenseIncomeViewModel
    {
        [DisplayFormat(DataFormatString ="{0:N0}")]
        [DisplayName("金額")]
        [Required]
        [Range(1,Int32.MaxValue,ErrorMessage = "「金額」只能輸入正整數")]
        public decimal Money { get; set; }
        [Required]
        [DisplayName("類別")]
        public string ExpenseIncometype { get; set; }
        [Required]
        //[BeforeCurrentDate(ErrorMessage = "「日期」不得大於今天")]        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        [RemoteDoublePlus("DateCheck", "Valid", AreaReference.UseRoot, ErrorMessage = "「日期」不得大於今天")]
        [DisplayName("日期")]
        public DateTime CreateTime { get; set; }
        [Required]
        [StringLength(100,ErrorMessage = "「備註」最多輸入100個字元")]
        [DataType(DataType.MultilineText)]
        //[RemoteDoublePlus("RemarkCheck", "Valid", AreaReference.UseRoot,ErrorMessage = "「備註」最多輸入100個字元")]
        [DisplayName("備註")]
        public string Remark { get; set; }


    }
}