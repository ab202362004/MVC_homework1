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
        private readonly IRepository<Classify> _classifyRepository;
        public AccountBookService(IUnitOfWork unitOfWork)
        {
            _accountBookRepository = new Repository<AccountBook>(unitOfWork);
            _classifyRepository = new Repository<Classify>(unitOfWork);
        }

        public IQueryable<ExpenseIncomeViewModel> Lookup()
        {
            var source = _accountBookRepository.LookupAll();
            var kind = _classifyRepository.LookupAll().Where(c=>c.Kind== "account_kind");
            var result = source

            .Join(kind,
                c => c.Categoryyy,
                s => (s.Value),
                (c, s) => new ExpenseIncomeViewModel()
                {
                    ExpenseIncometype = s.Desc,
                    CreateTime = c.Dateee,
                    Money = c.Amounttt,
                    Remark = c.Remarkkk
                }
              );

      
            return result;
        }

        public ExpenseIncomeViewModel GetSingle(Guid accountBookId)
        {
            var source = _accountBookRepository.GetSingle(d => d.Id == accountBookId);
            var kind = _classifyRepository.LookupAll().Where(c => c.Kind == "account_kind");
            return new ExpenseIncomeViewModel
            {
                ExpenseIncometype = kind.Where(c=>c.Value == source.Categoryyy).FirstOrDefault().Desc,
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
                Categoryyy = int.Parse(accountBook.ExpenseIncometype),
                Dateee = accountBook.CreateTime,
                Amounttt = (int)accountBook.Money,
                Remarkkk = accountBook.Remark
            }) ;
        }

        public void Edit(Guid id, ExpenseIncomeViewModel pageData)
        {

            var oldData = _accountBookRepository.GetSingle(d => d.Id == id);
            if (oldData != null)
            {
                oldData.Categoryyy = int.Parse(pageData.ExpenseIncometype);
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