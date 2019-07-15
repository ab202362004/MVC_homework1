using MVC_homework1.Models;
using MVC_homework1.Repository;
using MVC_homework1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_homework1.Service
{

    public class AccountBookService
    {
        private readonly IRepository<AccountBook> _accountBookRepository;

        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(unitOfWork);
        }

        public IQueryable<ExpenseIncomeViewModel> Lookup()
        {
            var source = _accountBookRepository.LookupAll();
            var result = source.Select(c => new ExpenseIncomeViewModel()
            {
                ExpenseIncometype = c.Categoryyy==1?"支出":"收入",
                CreateTime = c.Dateee,
                Money = c.Amounttt,
                Remark = c.Remarkkk
            });
            return result;
        }

        public ExpenseIncomeViewModel GetSingle(Guid accountBookId)
        {
            var source = _accountBookRepository.GetSingle(d => d.Id == accountBookId);
            return new ExpenseIncomeViewModel
            {
                ExpenseIncometype = source.Categoryyy == 1 ? "支出" : "收入",
                CreateTime = source.Dateee,
                Money = source.Amounttt,
                Remark = source.Remarkkk
            };
        }

        public void Add(ExpenseIncomeViewModel accountBook)
        {
            _accountBookRepository.Create(new AccountBook
            {
                Id = Guid.NewGuid(),
                Categoryyy = accountBook.ExpenseIncometype == "支出" ? 1 : 2,
                Dateee = DateTime.Now,
                Amounttt = (int)accountBook.Money,
                Remarkkk = accountBook.Remark
            }) ;
        }

        public void Edit(Guid id, ExpenseIncomeViewModel pageData)
        {
            var oldData = _accountBookRepository.GetSingle(d => d.Id == id);
            if (oldData != null)
            {
                oldData.Categoryyy = pageData.ExpenseIncometype == "支出" ? 1 : 2;
                oldData.Dateee = DateTime.Now;
                oldData.Amounttt = (int)pageData.Money;
                oldData.Remarkkk = pageData.Remark;
            }
        }

        public void Delete(Guid id)
        {
            _accountBookRepository.Remove(_accountBookRepository.GetSingle(d => d.Id == id));
        }
    }
}