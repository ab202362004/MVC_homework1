using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_homework1.Filters;
using MVC_homework1.Repository;
using MVC_homework1.Service;
using MVC_homework1.ViewModels;
using PagedList;

namespace MVC_homework1.Controllers
{
    public class ExpenseIncomeController : Controller
    {
        private readonly AccountBookService _accountBookService;
        private readonly UnitOfWork _unitOfWork;
        private readonly ClassifyService _classifyService;

        public ExpenseIncomeController()
        {
            _unitOfWork = new UnitOfWork();
            _accountBookService = new AccountBookService(_unitOfWork);
            _classifyService = new ClassifyService(_unitOfWork);
        }

        // GET: ExpenseIncome
        public ActionResult Index()
        {
            return View();
        }

        [ChildActionOnly]
        public ActionResult Create()
        {
            ViewData["TypeList"] = _classifyService.getOptionToSelectList("account_kind");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Money,ExpenseIncometype,CreateTime,Remark")]
                                   ExpenseIncomeViewModel expenseIncomeViewModel)
        {
            if (ModelState.IsValid)
            {
                _accountBookService.Add(expenseIncomeViewModel);
                _unitOfWork.Commit();
                ModelState.Clear();
            }
            ViewData["TypeList"] = _classifyService.getOptionToSelectList("account_kind");

            return View();
        }

        [AjaxOnly]
        public ActionResult List(int page = 1, int pageCount = 20)
        {
            //int page = 1;
            //int pageCount = 100;
            var skipCount = ((page - 1) * pageCount);
            ViewData["pageItemIndex"] = skipCount + 1;

            var expenseIncomeList = _accountBookService.Lookup()
                                                        .OrderByDescending(c => c.CreateTime);
                                                        //.Skip(skipCount)
                                                        //.Take(pageCount);

            return View(expenseIncomeList.ToPagedList(page, pageCount));
        }



    }
}
