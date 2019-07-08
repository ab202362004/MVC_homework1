using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_homework1.ViewModels;

namespace MVC_homework1.Controllers
{
    public class ExpenseIncomeController : Controller
    {
        // GET: ExpenseIncome
        public ActionResult Index()
        {
            return View();
        }
        

        [ChildActionOnly]
        public ActionResult List(int page=1,int pageCount=100)
        {
            //int page = 1;
            //int pageCount = 100;

            ViewData["pageItemIndex"] =( (page-1) *  pageCount)+1;

            List<ExpenseIncomeViewModel> expenseIncomeList = new List<ExpenseIncomeViewModel>();
            for (int i = 0; i < 100; i++)
            {
                Random gen = new Random(Guid.NewGuid().GetHashCode());
                int prob = gen.Next(20000);
                int type = gen.Next(0,2);
                
                DateTime Day = new DateTime(2019,1,1).AddDays(gen.Next(0, 365));
 


                expenseIncomeList.Add(new ExpenseIncomeViewModel
                {
                    Money = prob,
                    ExpenseIncometype = (type==1) ?"收入":"支出",
                    CreateTime = Day

                });
            }
            return View(expenseIncomeList.OrderBy(c=>c.CreateTime).Take(pageCount));
        }


    }
}
