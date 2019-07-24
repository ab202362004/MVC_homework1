using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC_homework1.Filters
{
    public class BeforeCurrentDateAttribute : ValidationAttribute
    {
        public BeforeCurrentDateAttribute()
        {
        }

        public override bool IsValid(object value)
        {
            try
            {
                var dt = (DateTime)value;
                if (dt >= DateTime.Now)
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}